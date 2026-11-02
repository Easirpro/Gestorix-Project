-- Respaldo de los procedimientos antes de Migracion_Articulos_CamposOpcionales.sql (2026-11-02).
-- Para volver atrás: correr este archivo.
USE Gestorix;
GO

CREATE OR ALTER PROCEDURE sp_RegistrarProducto
    @CodigoBarra NVARCHAR(100),
    @SKU NVARCHAR(100),
    @Nombre NVARCHAR(200),
    @Descripcion NVARCHAR(MAX),
    @IdMarca INT,
    @IdIVA INT,
    @IdCategoria INT,
    @IdUnidad INT,
    @PrecioVenta DECIMAL(18,2),
    @Activo BIT
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
        Activo
    )
    VALUES
    (
        @CodigoBarra,
        @SKU,
        @Nombre,
        @Descripcion,
        @IdMarca,
        @IdIVA,
        @IdCategoria,
        @IdUnidad,
        @PrecioVenta,
        @Activo
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerProductoPorCodigoBarra
    @CodigoBarra NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.IdProducto,
        p.CodigoBarra,
        p.SKU,
        p.Nombre,
        p.Descripcion,
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

CREATE OR ALTER PROCEDURE sp_BuscarArticulos
    @Texto NVARCHAR(200),
    @OcultarDiscontinuos BIT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.IdProducto,
        p.CodigoBarra,
        p.SKU,
        p.Descripcion,
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
    )
    AND (@OcultarDiscontinuos = 0 OR p.Activo = 1)
    AND s.CantidadActual > 0

    ORDER BY p.Descripcion;
END;
GO
