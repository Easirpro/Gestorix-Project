USE Gestorix;
GO

-- devoluciones al proveedor
IF OBJECT_ID('dbo.DevolucionProveedor', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.DevolucionProveedor
    (
        IdDevolucionProveedor INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DevolucionProveedor PRIMARY KEY,
        IdProducto            INT            NOT NULL CONSTRAINT FK_DevolucionProveedor_Producto REFERENCES dbo.Producto (IdProducto),
        IdLote                INT            NULL     CONSTRAINT FK_DevolucionProveedor_Lote REFERENCES dbo.Lote (IdLote),
        IdSucursal            INT            NOT NULL CONSTRAINT FK_DevolucionProveedor_Sucursal REFERENCES dbo.SucursalProveedor (IdSucursal),
        Cantidad              DECIMAL(10,3)  NOT NULL CONSTRAINT CK_DevolucionProveedor_Cantidad CHECK (Cantidad > 0),
        CostoUnitario         DECIMAL(18,2)  NOT NULL,
        Importe               DECIMAL(18,2)  NOT NULL,
        Motivo                NVARCHAR(255)  NOT NULL,
        FechaHora             DATETIME2      NOT NULL CONSTRAINT DF_DevolucionProveedor_FechaHora DEFAULT (GETDATE()),
        IdUsuario             INT            NOT NULL CONSTRAINT FK_DevolucionProveedor_Usuario REFERENCES dbo.Usuario (IdUsuario)
    );
END
GO

-- sp_ObtenerLotesVencidosProducto
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerLotesVencidosProducto
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Hoy DATE = CONVERT(DATE, GETDATE());

    SELECT
        l.IdLote,
        l.CodigoLote,
        l.FechaVencimiento,
        p.IdProducto,
        p.Nombre AS Producto,
        p.CodigoBarra,
        s.CantidadActual AS StockActual,
        CASE WHEN l.Stock > 0 AND l.Stock <= s.CantidadActual THEN l.Stock ELSE s.CantidadActual END AS CantidadSugerida,
        sp.IdSucursal,
        pr.Nombre AS Proveedor,
        sp.Nombre AS Sucursal,
        ISNULL(costo.PrecioCompra, 0) AS CostoUnitario
    FROM dbo.Lote AS l
    INNER JOIN dbo.Producto AS p ON p.IdProducto = l.IdProducto
    INNER JOIN dbo.Stock AS s ON s.IdProducto = l.IdProducto
    INNER JOIN dbo.SucursalProveedor AS sp ON sp.IdSucursal = l.IdSucursal
    INNER JOIN dbo.Proveedor AS pr ON pr.IdProveedor = sp.IdProveedor
    OUTER APPLY
    (
        SELECT TOP 1 psp.PrecioCompra
        FROM dbo.ProductoSucursalProveedor AS psp
        WHERE psp.IdProducto = l.IdProducto
          AND psp.PrecioCompra IS NOT NULL
        ORDER BY CASE WHEN psp.IdSucursal = l.IdSucursal THEN 0 ELSE 1 END, psp.FechaPrecioCompra DESC
    ) AS costo
    WHERE l.IdProducto = @IdProducto
      AND l.Activo = 1
      AND l.FechaVencimiento < @Hoy
    ORDER BY l.FechaVencimiento, l.IdLote;
END
GO

-- sp_RegistrarDevolucionProveedor
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarDevolucionProveedor
    @IdLote     INT,
    @Cantidad   DECIMAL(10,3),
    @Motivo     NVARCHAR(255),
    @IdUsuario  INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        DECLARE @IdProducto INT, @IdSucursal INT, @StockLote DECIMAL(10,3), @LoteActivo BIT, @CodigoLote NVARCHAR(100);
        DECLARE @StockActual DECIMAL(10,3), @Costo DECIMAL(18,2), @Importe DECIMAL(18,2);
        DECLARE @IdDevolucion INT, @Producto NVARCHAR(120), @Proveedor NVARCHAR(100);

        SET @Motivo = NULLIF(LTRIM(RTRIM(@Motivo)), N'');

        IF @Motivo IS NULL
            THROW 50450, N'Debe ingresar el motivo de la devolución.', 1;

        IF @Cantidad IS NULL OR @Cantidad <= 0
            THROW 50451, N'La cantidad a devolver debe ser mayor a cero.', 1;

        IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE IdUsuario = @IdUsuario AND Estado = 1)
            THROW 50452, N'El usuario no es válido.', 1;

        BEGIN TRANSACTION;

        SELECT @IdProducto = IdProducto, @IdSucursal = IdSucursal, @StockLote = Stock, @LoteActivo = Activo, @CodigoLote = CodigoLote
        FROM dbo.Lote WITH (UPDLOCK, HOLDLOCK)
        WHERE IdLote = @IdLote;

        IF @IdProducto IS NULL
            THROW 50453, N'El lote no existe.', 1;

        IF @LoteActivo = 0
            THROW 50454, N'El lote ya fue dado de baja.', 1;

        SELECT @StockActual = CantidadActual
        FROM dbo.Stock WITH (UPDLOCK, HOLDLOCK)
        WHERE IdProducto = @IdProducto;

        IF @StockActual IS NULL
            THROW 50455, N'El producto no tiene registro de stock.', 1;

        IF @Cantidad > @StockActual
            THROW 50456, N'La cantidad supera el stock del producto.', 1;

        SELECT TOP 1 @Costo = PrecioCompra
        FROM dbo.ProductoSucursalProveedor
        WHERE IdProducto = @IdProducto
          AND PrecioCompra IS NOT NULL
        ORDER BY CASE WHEN IdSucursal = @IdSucursal THEN 0 ELSE 1 END, FechaPrecioCompra DESC;

        SET @Costo = ISNULL(@Costo, 0);
        SET @Importe = ROUND(@Costo * @Cantidad, 2);

        INSERT INTO dbo.DevolucionProveedor (IdProducto, IdLote, IdSucursal, Cantidad, CostoUnitario, Importe, Motivo, FechaHora, IdUsuario)
        VALUES (@IdProducto, @IdLote, @IdSucursal, @Cantidad, @Costo, @Importe, @Motivo, GETDATE(), @IdUsuario);

        SET @IdDevolucion = CONVERT(INT, SCOPE_IDENTITY());

        UPDATE dbo.Stock
        SET CantidadActual = CantidadActual - @Cantidad
        WHERE IdProducto = @IdProducto;

        -- baja del lote si no le queda stock
        UPDATE dbo.Lote
        SET Stock  = CASE WHEN Stock > @Cantidad THEN Stock - @Cantidad ELSE 0 END,
            Activo = CASE WHEN Stock > @Cantidad THEN 1 ELSE 0 END
        WHERE IdLote = @IdLote;

        INSERT INTO dbo.MovimientoStock (IdProducto, TipoMovimiento, Cantidad, FechaHora, Observacion, IdUsuario)
        VALUES (@IdProducto, N'EGRESO', @Cantidad, GETDATE(),
                LEFT(CONCAT(N'Devolución a proveedor #', @IdDevolucion,
                            CASE WHEN NULLIF(LTRIM(RTRIM(@CodigoLote)), N'') IS NULL THEN N'' ELSE N' (lote ' + @CodigoLote + N')' END,
                            N': ', @Motivo), 255),
                @IdUsuario);

        SELECT @Producto = Nombre FROM dbo.Producto WHERE IdProducto = @IdProducto;

        SELECT @Proveedor = CONCAT(pr.Nombre, N' - ', sp.Nombre)
        FROM dbo.SucursalProveedor AS sp
        INNER JOIN dbo.Proveedor AS pr ON pr.IdProveedor = sp.IdProveedor
        WHERE sp.IdSucursal = @IdSucursal;

        INSERT INTO dbo.Bitacora (IdUsuario, FechaHora, Accion, TablaAfectada, IdRegistroAfectado, Descripcion)
        VALUES
        (
            @IdUsuario, SYSDATETIME(), N'CREAR', N'DevolucionProveedor', @IdDevolucion,
            LEFT(CONCAT(N'Devolución a proveedor #', @IdDevolucion, N' | ', @Producto, N' x ', @Cantidad,
                        N' | ', @Proveedor, N' | $', @Importe, N' | Motivo: ', @Motivo), 255)
        );

        COMMIT TRANSACTION;

        SELECT @IdDevolucion AS IdDevolucionProveedor,
               @Importe      AS Importe;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- sp_ObtenerDevolucionesProveedor
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerDevolucionesProveedor
    @Desde DATE,
    @Hasta DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        d.FechaHora AS Fecha,
        p.Nombre AS Producto,
        d.Cantidad,
        CONCAT(pr.Nombre, N' - ', sp.Nombre) AS Proveedor,
        d.Importe
    FROM dbo.DevolucionProveedor AS d
    INNER JOIN dbo.Producto AS p ON p.IdProducto = d.IdProducto
    INNER JOIN dbo.SucursalProveedor AS sp ON sp.IdSucursal = d.IdSucursal
    INNER JOIN dbo.Proveedor AS pr ON pr.IdProveedor = sp.IdProveedor
    WHERE d.FechaHora >= @Desde
      AND d.FechaHora < DATEADD(DAY, 1, @Hasta)
    ORDER BY d.FechaHora DESC;
END
GO
