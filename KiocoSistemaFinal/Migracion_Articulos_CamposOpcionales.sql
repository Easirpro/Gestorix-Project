-- Migración: artículos con solo nombre, marca, unidad de venta y rubro obligatorios.
-- Modifica:
--   - sp_RegistrarProducto: acepta @DVH (el programa ya lo envía y la versión anterior no lo
--     tenía, por eso fallaba el alta de artículos) y guarda NULL si el código de barras
--     o la descripción vienen vacíos.
--   - sp_ObtenerProductoPorCodigoBarra y sp_BuscarArticulos (ventas): si el artículo no tiene
--     descripción se muestra su nombre, y la búsqueda por texto también busca por nombre.
-- Las columnas de la tabla Producto no cambian: CodigoBarra y Descripcion ya admiten NULL,
-- y un artículo sin precio se guarda con PrecioVenta = 0 (ventas no lo deja vender).
-- Se puede correr más de una vez.
USE Gestorix;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegistrarProducto
    @CodigoBarra NVARCHAR(100) = NULL,
    @SKU NVARCHAR(100),
    @Nombre NVARCHAR(200),
    @Descripcion NVARCHAR(MAX) = NULL,
    @IdMarca INT,
    @IdIVA INT,
    @IdCategoria INT,
    @IdUnidad INT,
    @PrecioVenta DECIMAL(18,2),
    @Activo BIT,
    @DVH NVARCHAR(64) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Producto
    (
        CodigoBarra,
        SKU,
        Nombre,
        Descripcion,
        IdMarca,
        IdIVA,
        IdCategoria,
        IdUnidad,
        PrecioVenta,
        Activo,
        DVH
    )
    VALUES
    (
        NULLIF(LTRIM(RTRIM(@CodigoBarra)), N''),
        @SKU,
        @Nombre,
        NULLIF(LTRIM(RTRIM(@Descripcion)), N''),
        @IdMarca,
        @IdIVA,
        @IdCategoria,
        @IdUnidad,
        @PrecioVenta,
        @Activo,
        @DVH
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ObtenerProductoPorCodigoBarra
    @CodigoBarra NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.IdProducto,
        p.CodigoBarra,
        p.SKU,
        p.Nombre,
        COALESCE(NULLIF(p.Descripcion, N''), p.Nombre) AS Descripcion,
        p.PrecioVenta,
        p.Activo,
        s.CantidadActual
    FROM Producto p
    LEFT JOIN Stock s
        ON p.IdProducto = s.IdProducto
    WHERE
        (
            p.CodigoBarra = @CodigoBarra
            OR p.SKU = @CodigoBarra
        )
        AND p.Activo = 1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BuscarArticulos
    @Texto NVARCHAR(200),
    @OcultarDiscontinuos BIT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.IdProducto,
        p.CodigoBarra,
        p.SKU,
        COALESCE(NULLIF(p.Descripcion, N''), p.Nombre) AS Descripcion,
        c.Nombre AS Rubro,
        p.PrecioVenta,
        p.Activo,
        s.CantidadActual
    FROM Producto p

    INNER JOIN Categoria c
        ON p.IdCategoria = c.IdCategoria

    INNER JOIN Stock s
        ON p.IdProducto = s.IdProducto

    WHERE
    (
        p.CodigoBarra LIKE '%' + @Texto + '%'
        OR p.SKU LIKE '%' + @Texto + '%'
        OR p.Descripcion LIKE '%' + @Texto + '%'
        OR p.Nombre LIKE '%' + @Texto + '%'
    )
    AND (@OcultarDiscontinuos = 0 OR p.Activo = 1)
    AND s.CantidadActual > 0

    ORDER BY COALESCE(NULLIF(p.Descripcion, N''), p.Nombre);
END;
GO
