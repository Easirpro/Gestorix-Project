USE Gestorix;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GuardarCompra
    @IdProveedor INT,
    @Fecha DATETIME,
    @TipoComprobante NVARCHAR(50),
    @NumeroComprobante NVARCHAR(50),
    @SubtotalSinIVA DECIMAL(18,2),
    @IVA DECIMAL(18,2),
    @Total DECIMAL(18,2),
    @Observaciones NVARCHAR(MAX),
    @Detalles dbo.TipoDetalleCompra READONLY,
    @IdUsuario         INT          = NULL,       -- quien carga la compra
    @CondicionPago     VARCHAR(10)  = 'CONTADO',  -- 'CONTADO' o 'CTA_CTE'
    @FechaVencimiento  DATE         = NULL,       -- solo Cta. Cte
    @IdMetodoPago      INT          = NULL,
    @IdSesionCaja      INT          = NULL,
    @IdSucursal        INT          = NULL,
    @FechaEntregaEstimada DATE      = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        -- Validar proveedor
        IF @IdProveedor IS NULL OR @IdProveedor <= 0
           OR NOT EXISTS
           (
               SELECT 1
               FROM dbo.Proveedor
               WHERE IdProveedor = @IdProveedor
           )
        BEGIN
            THROW 50010, 'El proveedor seleccionado no es válido.', 1;
        END;

        IF @Fecha IS NULL
           OR CONVERT(DATE, @Fecha) <> CONVERT(DATE, GETDATE())
        BEGIN
            THROW 50011, 'La fecha del pedido debe ser la de hoy.', 1;
        END;

        IF @FechaEntregaEstimada IS NOT NULL
           AND @FechaEntregaEstimada < CONVERT(DATE, GETDATE())
        BEGIN
            THROW 50026, 'La entrega estimada no puede ser anterior a hoy.', 1;
        END;

        IF @TipoComprobante LIKE N'Nota de Cr%dito%'
        BEGIN
            THROW 50027, 'Las notas de crédito no se registran como compra.', 1;
        END;

        -- Validar comprobante
        IF NULLIF(LTRIM(RTRIM(@TipoComprobante)), N'') IS NULL
        BEGIN
            THROW 50012, 'El tipo de comprobante es obligatorio.', 1;
        END;

        IF NULLIF(LTRIM(RTRIM(@NumeroComprobante)), N'') IS NULL
        BEGIN
            THROW 50013, 'El número de comprobante es obligatorio.', 1;
        END;

        -- Validar observaciones
        IF LEN(@Observaciones) > 500
        BEGIN
            THROW 50014, 'Las observaciones no pueden superar los 500 caracteres.', 1;
        END;

        -- Validar importes generales
        IF @SubtotalSinIVA IS NULL
           OR @IVA IS NULL
           OR @Total IS NULL
           OR @SubtotalSinIVA < 0
           OR @IVA < 0
           OR @Total < 0
        BEGIN
            THROW 50015, 'Los importes de la compra no pueden ser negativos ni nulos.', 1;
        END;

        IF ABS(@Total - (@SubtotalSinIVA + @IVA)) > 0.01
        BEGIN
            THROW 50016, 'El total no coincide con el subtotal más el IVA.', 1;
        END;

        IF NOT EXISTS (SELECT 1 FROM @Detalles)
        BEGIN
            THROW 50017, 'La compra debe contener al menos un producto.', 1;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM @Detalles
            WHERE IdProducto IS NULL
               OR IdProducto <= 0
               OR Cantidad IS NULL
               OR Cantidad <= 0
               OR PrecioSinIVA IS NULL
               OR PrecioSinIVA < 0
               OR PorcentajeIVA IS NULL
               OR PorcentajeIVA < 0
               OR PorcentajeIVA > 100
               OR Total IS NULL
               OR Total < 0
        )
        BEGIN
            THROW 50018, 'Hay productos con cantidades o importes inválidos.', 1;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM @Detalles AS D
            LEFT JOIN dbo.Producto AS P
                ON P.IdProducto = D.IdProducto
            WHERE P.IdProducto IS NULL
        )
        BEGIN
            THROW 50019, 'Uno o más productos de la compra no existen.', 1;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM @Detalles
            WHERE Total <>
                ROUND(Cantidad * PrecioSinIVA, 2)
                + ROUND(
                    ROUND(Cantidad * PrecioSinIVA, 2)
                    * PorcentajeIVA / 100,
                    2
                )
        )
        BEGIN
            THROW 50020, 'El total de uno o más detalles no coincide con sus importes.', 1;
        END;

        DECLARE @SubtotalCalculado DECIMAL(18,2);
        DECLARE @IVACalculado DECIMAL(18,2);
        DECLARE @TotalCalculado DECIMAL(18,2);

        SELECT
            @SubtotalCalculado = COALESCE(
                SUM(ROUND(Cantidad * PrecioSinIVA, 2)), 0
            ),
            @IVACalculado = COALESCE(
                SUM(
                    ROUND(
                        ROUND(Cantidad * PrecioSinIVA, 2)
                        * PorcentajeIVA / 100,
                        2
                    )
                ), 0
            ),
            @TotalCalculado = COALESCE(
                SUM(
                    ROUND(Cantidad * PrecioSinIVA, 2)
                    + ROUND(
                        ROUND(Cantidad * PrecioSinIVA, 2)
                        * PorcentajeIVA / 100,
                        2
                    )
                ), 0
            )
        FROM @Detalles;

        IF @SubtotalSinIVA <> @SubtotalCalculado
        BEGIN
            THROW 50021, 'El subtotal no coincide con los detalles de la compra.', 1;
        END;

        IF @IVA <> @IVACalculado
        BEGIN
            THROW 50022, 'El IVA no coincide con los detalles de la compra.', 1;
        END;

        IF @Total <> @TotalCalculado
        BEGIN
            THROW 50023, 'El total no coincide con los detalles de la compra.', 1;
        END;

        IF @IdUsuario IS NOT NULL
           AND NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE IdUsuario = @IdUsuario AND Estado = 1)
        BEGIN
            THROW 50210, 'El usuario que carga la compra no es válido.', 1;
        END;

        SET @CondicionPago = UPPER(LTRIM(RTRIM(COALESCE(@CondicionPago, 'CONTADO'))));

        IF @CondicionPago NOT IN ('CONTADO', 'CTA_CTE')
        BEGIN
            THROW 50211, 'La condición de pago debe ser CONTADO o CTA_CTE.', 1;
        END;

        IF @CondicionPago = 'CTA_CTE'
        BEGIN
            SET @IdMetodoPago = NULL;
            SET @IdSesionCaja = NULL;

            IF @FechaVencimiento IS NOT NULL
               AND @FechaVencimiento < CONVERT(DATE, @Fecha)
            BEGIN
                THROW 50212, 'La fecha de vencimiento no puede ser anterior a la fecha de compra.', 1;
            END;
        END
        ELSE
        BEGIN
            SET @FechaVencimiento = NULL;
        END;

        DECLARE @MetodoPago NVARCHAR(30);
        DECLARE @Disponible DECIMAL(10,2);

        IF @IdMetodoPago IS NOT NULL
        BEGIN
            SELECT @MetodoPago = Nombre
            FROM dbo.MetodoPago
            WHERE IdMetodoPago = @IdMetodoPago
              AND Activo = 1;

            IF @MetodoPago IS NULL OR @MetodoPago = N'Cuenta Corriente'
            BEGIN
                THROW 50200, 'El medio de pago no es válido para pagar una compra.', 1;
            END;

            IF @IdUsuario IS NULL
            BEGIN
                THROW 50213, 'Para registrar el pago de la compra debe indicarse el usuario.', 1;
            END;

            IF @Total <= 0
            BEGIN
                SET @IdMetodoPago = NULL;   -- nada que pagar
            END;
        END;

        IF @IdSesionCaja IS NOT NULL AND @IdMetodoPago IS NOT NULL
        BEGIN
            IF NOT EXISTS
            (
                SELECT 1
                FROM dbo.SesionCaja
                WHERE IdSesionCaja = @IdSesionCaja
                  AND FechaCierre IS NULL
            )
            BEGIN
                THROW 50104, 'La sesión de caja no existe o ya está cerrada.', 1;
            END;

            IF @MetodoPago = N'Efectivo'
            BEGIN
                SELECT @Disponible = EfectivoEsperado
                FROM dbo.vw_ArqueoSesionCaja
                WHERE IdSesionCaja = @IdSesionCaja;

                IF @Total > @Disponible
                BEGIN
                    THROW 50115, 'El importe supera el efectivo disponible en la caja.', 1;
                END;
            END;
        END;

        IF @IdSucursal IS NOT NULL
           AND NOT EXISTS
           (
               SELECT 1
               FROM dbo.SucursalProveedor
               WHERE IdSucursal = @IdSucursal
                 AND IdProveedor = @IdProveedor
           )
        BEGIN
            THROW 50024, 'La sucursal seleccionada no pertenece al proveedor.', 1;
        END;

        IF @IdSucursal IS NOT NULL
           AND EXISTS
           (
               SELECT 1
               FROM @Detalles AS D
               WHERE NOT EXISTS
               (
                   SELECT 1
                   FROM dbo.ProductoSucursalProveedor AS PSP
                   WHERE PSP.IdProducto = D.IdProducto
                     AND PSP.IdSucursal = @IdSucursal
                     AND PSP.Activo = 1
               )
           )
        BEGIN
            THROW 50025, 'Uno o más productos no pertenecen a la sucursal del proveedor.', 1;
        END;

        BEGIN TRANSACTION;

        DECLARE @IdCompra INT;

        INSERT INTO dbo.Compra
        (
            IdProveedor,
            Fecha,
            TipoComprobante,
            NumeroComprobante,
            SubtotalSinIVA,
            IVA,
            Total,
            Observaciones,
            IdUsuario,
            CondicionPago,
            FechaVencimiento,
            IdSucursal,
            FechaEntregaEstimada
        )
        VALUES
        (
            @IdProveedor,
            @Fecha,
            @TipoComprobante,
            @NumeroComprobante,
            @SubtotalSinIVA,
            @IVA,
            @Total,
            @Observaciones,
            @IdUsuario,
            @CondicionPago,
            @FechaVencimiento,
            @IdSucursal,
            @FechaEntregaEstimada
        );

        SET @IdCompra = CONVERT(INT, SCOPE_IDENTITY());

        INSERT INTO dbo.DetalleCompra
        (
            IdCompra,
            IdProducto,
            Cantidad,
            PrecioSinIVA,
            PorcentajeIVA,
            Total
        )
        SELECT
            @IdCompra,
            IdProducto,
            Cantidad,
            PrecioSinIVA,
            PorcentajeIVA,
            Total
        FROM @Detalles;

        IF @IdSucursal IS NOT NULL
        BEGIN
            UPDATE PSP
            SET PSP.PrecioCompra = D.PrecioSinIVA,
                PSP.FechaPrecioCompra = SYSDATETIME()
            FROM dbo.ProductoSucursalProveedor AS PSP
            INNER JOIN
            (
                SELECT IdProducto, MAX(PrecioSinIVA) AS PrecioSinIVA
                FROM @Detalles
                GROUP BY IdProducto
            ) AS D
                ON D.IdProducto = PSP.IdProducto
            WHERE PSP.IdSucursal = @IdSucursal
              AND (PSP.PrecioCompra IS NULL OR PSP.PrecioCompra <> D.PrecioSinIVA);
        END;

        IF @IdMetodoPago IS NOT NULL
        BEGIN
            INSERT INTO dbo.PagoCompra
            (
                IdCompra,
                FechaPago,
                IdMetodoPago,
                Monto,
                IdUsuario,
                IdSesionCaja,
                Observacion
            )
            VALUES
            (
                @IdCompra,
                GETDATE(),
                @IdMetodoPago,
                @Total,
                @IdUsuario,
                @IdSesionCaja,
                N'Pago de contado al registrar la compra'
            );
        END;

        INSERT INTO dbo.Bitacora
        (
            IdUsuario,
            FechaHora,
            Accion,
            TablaAfectada,
            IdRegistroAfectado,
            Descripcion
        )
        VALUES
        (
            @IdUsuario,
            SYSDATETIME(),
            N'CREAR',
            N'Compra',
            @IdCompra,
            LEFT(CONCAT(
                N'Compra #', @IdCompra,
                N' | Total: $', @Total,
                N' | ', @CondicionPago,
                CASE WHEN @IdMetodoPago IS NOT NULL THEN N' | Pagada con ' + @MetodoPago ELSE N'' END
            ), 255)
        );

        COMMIT TRANSACTION;

        SELECT @IdCompra AS IdCompra;

    END TRY
    BEGIN CATCH

        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH
END;
GO
