-- Migración: recepción de compras, sucursal en compras y bitácora de compras.
-- 1) Compra: columnas IdSucursal (sucursal del proveedor) y EstadoRecepcion (PENDIENTE / APROBADA).
-- 2) Tablas RecepcionCompra y DetalleRecepcionCompra, y tipo dbo.TipoDetalleRecepcion.
-- 3) sp_GuardarCompra recibe @IdSucursal; sp_AnularCompra no anula compras ya recibidas y lo deja en la bitácora.
-- 4) sp_ObtenerBitacora: la categoría 'Compras' incluye los pagos a proveedores.
-- 5) Nuevos: sp_ObtenerComprasPendientesRecepcion, sp_ConfirmarRecepcionCompra, sp_ObtenerComprasBitacora
--    (todas las compras con quién la cargó, quién la recibió y estado de entrega y pago).
-- 6) Costo de compra por sucursal: sp_BuscarProductoCompra (solo productos de la sucursal, con su costo)
--    y sp_GuardarCompra valida los productos de la sucursal y actualiza su PrecioCompra.
-- 7) Fechas: Compra.FechaEntregaEstimada; sp_GuardarCompra exige que la fecha del pedido sea hoy
--    y que la entrega estimada no sea anterior a hoy. Las pendientes de recepción la devuelven.
-- 8) sp_GuardarCompra no acepta notas de crédito como comprobante de compra.
-- Se puede ejecutar más de una vez sin problemas.
USE Gestorix;
GO

IF COL_LENGTH('dbo.Compra', 'IdSucursal') IS NULL
BEGIN
    ALTER TABLE dbo.Compra ADD IdSucursal INT NULL;
END
GO

IF OBJECT_ID('dbo.FK_Compra_SucursalProveedor', 'F') IS NULL
BEGIN
    ALTER TABLE dbo.Compra
        ADD CONSTRAINT FK_Compra_SucursalProveedor
        FOREIGN KEY (IdSucursal) REFERENCES dbo.SucursalProveedor (IdSucursal);
END
GO

IF COL_LENGTH('dbo.Compra', 'FechaEntregaEstimada') IS NULL
BEGIN
    ALTER TABLE dbo.Compra ADD FechaEntregaEstimada DATE NULL;
END
GO

IF COL_LENGTH('dbo.Compra', 'EstadoRecepcion') IS NULL
BEGIN
    ALTER TABLE dbo.Compra
        ADD EstadoRecepcion NVARCHAR(20) NOT NULL
        CONSTRAINT DF_Compra_EstadoRecepcion DEFAULT N'PENDIENTE';
END
GO

IF OBJECT_ID('dbo.CK_Compra_EstadoRecepcion', 'C') IS NULL
BEGIN
    ALTER TABLE dbo.Compra
        ADD CONSTRAINT CK_Compra_EstadoRecepcion
        CHECK (EstadoRecepcion IN (N'PENDIENTE', N'APROBADA'));
END
GO

IF OBJECT_ID('dbo.RecepcionCompra', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RecepcionCompra
    (
        IdRecepcion    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_RecepcionCompra PRIMARY KEY,
        IdCompra       INT           NOT NULL,
        FechaRecepcion DATETIME2     NOT NULL CONSTRAINT DF_RecepcionCompra_Fecha DEFAULT SYSDATETIME(),
        IdUsuario      INT           NOT NULL,
        TotalCompra    DECIMAL(10,2) NOT NULL,
        TotalBoleta    DECIMAL(10,2) NOT NULL,
        Motivos        NVARCHAR(500) NULL,
        Observaciones  NVARCHAR(500) NULL,
        CONSTRAINT UQ_RecepcionCompra_IdCompra UNIQUE (IdCompra),
        CONSTRAINT FK_RecepcionCompra_Compra FOREIGN KEY (IdCompra) REFERENCES dbo.Compra (IdCompra),
        CONSTRAINT FK_RecepcionCompra_Usuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario (IdUsuario)
    );
END
GO

IF OBJECT_ID('dbo.DetalleRecepcionCompra', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.DetalleRecepcionCompra
    (
        IdDetalleRecepcion INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DetalleRecepcionCompra PRIMARY KEY,
        IdRecepcion        INT           NOT NULL,
        IdProducto         INT           NOT NULL,
        CantidadPedida     DECIMAL(10,3) NOT NULL,
        CantidadRecibida   DECIMAL(10,3) NOT NULL,
        CONSTRAINT FK_DetalleRecepcionCompra_Recepcion FOREIGN KEY (IdRecepcion) REFERENCES dbo.RecepcionCompra (IdRecepcion),
        CONSTRAINT FK_DetalleRecepcionCompra_Producto FOREIGN KEY (IdProducto) REFERENCES dbo.Producto (IdProducto)
    );
END
GO

IF TYPE_ID('dbo.TipoDetalleRecepcion') IS NULL
BEGIN
    CREATE TYPE dbo.TipoDetalleRecepcion AS TABLE
    (
        IdProducto       INT           NOT NULL,
        CantidadRecibida DECIMAL(10,3) NOT NULL
    );
END
GO
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerBitacora
    @FechaDesde DATE = NULL,
    @FechaHasta DATE = NULL,
    @Categoria NVARCHAR(30) = NULL,
    @Buscar NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH Registros AS
    (
        -- Bitácora general existente
        SELECT
            CAST(b.IdBitacora AS BIGINT) AS IdBitacora,
            b.IdUsuario,
            u.Username,
            b.FechaHora,
            b.Accion,
            b.TablaAfectada,
            b.IdRegistroAfectado,
            b.Descripcion
        FROM dbo.Bitacora AS b
        LEFT JOIN dbo.Usuario AS u
            ON b.IdUsuario = u.IdUsuario

        UNION ALL

        -- Historial específico de promociones
        SELECT
            hp.IdHistorial AS IdBitacora,
            CAST(NULL AS INT) AS IdUsuario,
            CAST(hp.UsuarioBD AS NVARCHAR(256)) AS Username,
            CAST(hp.FechaEvento AS DATETIME) AS FechaHora,
            CAST(hp.Accion AS NVARCHAR(50)) AS Accion,
            CAST(N'Promocion' AS NVARCHAR(50)) AS TablaAfectada,
            hp.IdPromocion AS IdRegistroAfectado,
            CAST(
                CONCAT(
                    N'Promoción: ', hp.NombrePromocion,
                    N' | Código: ', COALESCE(hp.CodigoPromocion, N'Sin código'),
                    N' | ', COALESCE(hp.Detalle, N'')
                ) AS NVARCHAR(1000)
            ) AS Descripcion
        FROM dbo.HistorialPromocion AS hp
    )
    SELECT
        IdBitacora,
        IdUsuario,
        Username,
        FechaHora,
        Accion,
        TablaAfectada,
        IdRegistroAfectado,
        Descripcion
    FROM Registros
    WHERE
        (@FechaDesde IS NULL OR FechaHora >= @FechaDesde)
        AND (
            @FechaHasta IS NULL
            OR FechaHora < DATEADD(DAY, 1, @FechaHasta)
        )
        AND (
            @Buscar IS NULL
            OR @Buscar = ''
            OR Accion LIKE '%' + @Buscar + '%'
            OR TablaAfectada LIKE '%' + @Buscar + '%'
            OR Descripcion LIKE '%' + @Buscar + '%'
            OR Username LIKE '%' + @Buscar + '%'
        )
        AND (
            @Categoria IS NULL
            OR @Categoria = ''

            OR (
                @Categoria = 'Usuarios'
                AND TablaAfectada IN
                    ('Usuario', 'Rol', 'RolPermiso', 'Permiso')
            )

            OR (
                @Categoria = 'Seguridad'
                AND (
                    Accion IN ('LOGIN', 'LOGOUT', 'LOGIN_FALLIDO')
                    OR TablaAfectada = 'Seguridad'
                )
            )

            OR (
                @Categoria = 'ProductosStock'
                AND TablaAfectada IN (
                    'Producto', 'Categoria', 'Marca',
                    'HistorialPrecio', 'Stock', 'Lote',
                    'MovimientoStock', 'Devolucion'
                )
            )

            OR (
                @Categoria = 'VentasPagos'
                AND TablaAfectada IN (
                    'Venta', 'DetalleVenta', 'VentaPago'
                )
            )

            OR (
                @Categoria = 'Compras'
                AND TablaAfectada IN ('Compra', 'DetalleCompra', 'PagoCompra')
            )

            OR (
                @Categoria = 'Promociones'
                AND TablaAfectada IN (
                    'Promocion', 'DetallePromocion'
                )
            )

            OR (
                @Categoria = 'Errores'
                AND Accion = 'ERROR'
            )
        )
    ORDER BY
        FechaHora DESC,
        IdBitacora DESC;
END;
GO

/* ---------------------------------------------------------------------
   MODIFICADO: sp_GuardarCompra  (cambios marcados con [PAGOS])
   --------------------------------------------------------------------- */
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
    -- [PAGOS] Parámetros nuevos (opcionales para no romper llamadas actuales)
    @IdUsuario         INT          = NULL,       -- quién carga la compra
    @CondicionPago     VARCHAR(10)  = 'CONTADO',  -- 'CONTADO' o 'CTA_CTE'
    @FechaVencimiento  DATE         = NULL,       -- solo Cta. Cte.
    @IdMetodoPago      INT          = NULL,       -- contado: con qué se pagó
    @IdSesionCaja      INT          = NULL,        -- contado: si el pago sale de la caja abierta
    @IdSucursal        INT          = NULL,       -- [RECEPCION] sucursal del proveedor
    @FechaEntregaEstimada DATE      = NULL        -- [FECHAS] cuándo se espera la mercadería
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        -- Validar proveedor.
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

        -- [FECHAS] La fecha del pedido es siempre la de hoy: ni pasada ni futura.
        IF @Fecha IS NULL
           OR CONVERT(DATE, @Fecha) <> CONVERT(DATE, GETDATE())
        BEGIN
            THROW 50011, 'La fecha del pedido debe ser la de hoy.', 1;
        END;

        -- [FECHAS] La entrega estimada, si se indica, no puede ser anterior a hoy.
        IF @FechaEntregaEstimada IS NOT NULL
           AND @FechaEntregaEstimada < CONVERT(DATE, GETDATE())
        BEGIN
            THROW 50026, 'La entrega estimada no puede ser anterior a hoy.', 1;
        END;

        -- [NOTAS DE CREDITO] Una nota de crédito no es una compra: resta deuda en vez de sumarla.
        -- Hasta que tengan su propia funcionalidad, no se pueden registrar como compra.
        IF @TipoComprobante LIKE N'Nota de Cr%dito%'
        BEGIN
            THROW 50027, 'Las notas de crédito no se registran como compra.', 1;
        END;

        -- Validar comprobante.
        IF NULLIF(LTRIM(RTRIM(@TipoComprobante)), N'') IS NULL
        BEGIN
            THROW 50012, 'El tipo de comprobante es obligatorio.', 1;
        END;

        IF NULLIF(LTRIM(RTRIM(@NumeroComprobante)), N'') IS NULL
        BEGIN
            THROW 50013, 'El número de comprobante es obligatorio.', 1;
        END;

        -- Validar observaciones.
        IF LEN(@Observaciones) > 500
        BEGIN
            THROW 50014, 'Las observaciones no pueden superar los 500 caracteres.', 1;
        END;

        -- Validar importes generales.
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

        -- Exigir al menos un detalle.
        IF NOT EXISTS (SELECT 1 FROM @Detalles)
        BEGIN
            THROW 50017, 'La compra debe contener al menos un producto.', 1;
        END;

        -- Validar cantidades e importes de los detalles.
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

        -- Comprobar que los productos existan.
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

        -- Validar el total de cada detalle.
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

        -- Calcular los importes esperados a partir de los detalles.
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

        -- Comparar el subtotal general con los detalles.
        IF @SubtotalSinIVA <> @SubtotalCalculado
        BEGIN
            THROW 50021, 'El subtotal no coincide con los detalles de la compra.', 1;
        END;

        -- Comparar el IVA general con los detalles.
        IF @IVA <> @IVACalculado
        BEGIN
            THROW 50022, 'El IVA no coincide con los detalles de la compra.', 1;
        END;

        -- Comparar el total general con los detalles.
        IF @Total <> @TotalCalculado
        BEGIN
            THROW 50023, 'El total no coincide con los detalles de la compra.', 1;
        END;

        -- [PAGOS] Validar usuario y condición de pago.
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
            -- En Cta. Cte. no se registra pago al cargar la compra.
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

        -- [PAGOS] Compra de contado con medio de pago: se registra el pago.
        -- (Si no se envía @IdMetodoPago, la compra queda pendiente de pago,
        --  igual que antes del cambio, y se paga con sp_RegistrarPagoCompra.)
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

        -- [RECEPCION] La sucursal, si se indica, tiene que ser del proveedor.
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

        -- [COSTO] Con sucursal, los productos tienen que estar asociados a ella.
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

        -- [COSTO] El costo de esta compra pasa a ser el costo vigente de la sucursal.
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

        -- [PAGOS] Registrar el pago de contado.
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

        -- [PAGOS] Registrar en la bitácora.
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

/* ---------------------------------------------------------------------
   MODIFICADO: sp_AnularCompra  (cambio marcado con [PAGOS])
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_AnularCompra
    @IdCompra INT,
    @Motivo NVARCHAR(500),
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Anulada BIT;
        DECLARE @Observacion NVARCHAR(255);
        DECLARE @MotivoFinal NVARCHAR(500);

        SET @MotivoFinal = COALESCE(
            NULLIF(LTRIM(RTRIM(@Motivo)), N''),
            N'Sin motivo especificado'
        );

        IF @IdUsuario <= 0
        BEGIN
            THROW 50001, N'El usuario que anula la compra no es válido.', 1;
        END;

        SELECT @Anulada = Anulada
        FROM dbo.Compra WITH (UPDLOCK, HOLDLOCK)
        WHERE IdCompra = @IdCompra;

        IF @Anulada IS NULL
        BEGIN
            THROW 50002, N'La compra indicada no existe.', 1;
        END;

        IF @Anulada = 1
        BEGIN
            THROW 50003, N'La compra ya está anulada.', 1;
        END;

        -- [RECEPCION] Una compra recibida ya tiene el stock controlado y ajustado: no se anula.
        IF EXISTS (SELECT 1 FROM dbo.Compra WHERE IdCompra = @IdCompra AND EstadoRecepcion = N'APROBADA')
        BEGIN
            THROW 50007, N'La compra ya fue recibida y aprobada; no se puede anular.', 1;
        END;

        -- [PAGOS] Si la compra tiene pagos activos, primero hay que anularlos
        -- (si no, el dinero que salió desaparecería del balance).
        IF EXISTS
        (
            SELECT 1
            FROM dbo.PagoCompra
            WHERE IdCompra = @IdCompra
              AND Anulado = 0
        )
        BEGIN
            THROW 50006,
                N'La compra tiene pagos registrados. Anulá los pagos antes de anular la compra.',
                1;
        END;

        -- Verificamos que exista stock suficiente para revertir
        -- las cantidades ingresadas por esta compra.
        IF EXISTS
        (
            SELECT 1
            FROM
            (
                SELECT
                    IdProducto,
                    SUM(Cantidad) AS Cantidad
                FROM dbo.DetalleCompra
                WHERE IdCompra = @IdCompra
                GROUP BY IdProducto
            ) AS D
            LEFT JOIN dbo.Stock AS S WITH (UPDLOCK, HOLDLOCK)
                ON S.IdProducto = D.IdProducto
            WHERE S.IdProducto IS NULL
               OR S.CantidadActual < D.Cantidad
        )
        BEGIN
            THROW 50004,
                N'No hay stock suficiente para anular la compra. Verificá las existencias actuales.',
                1;
        END;

        -- Revertimos las cantidades ingresadas.
        UPDATE S
        SET S.CantidadActual = S.CantidadActual - D.Cantidad
        FROM dbo.Stock AS S
        INNER JOIN
        (
            SELECT
                IdProducto,
                SUM(Cantidad) AS Cantidad
            FROM dbo.DetalleCompra
            WHERE IdCompra = @IdCompra
            GROUP BY IdProducto
        ) AS D
            ON D.IdProducto = S.IdProducto;

        -- Registramos un egreso por cada producto de la compra.
        SET @Observacion = LEFT(
            CONCAT(N'Anulación compra #', @IdCompra, N' - ', @MotivoFinal),
            255
        );

        INSERT INTO dbo.MovimientoStock
        (
            IdProducto,
            TipoMovimiento,
            Cantidad,
            FechaHora,
            Observacion,
            IdUsuario
        )
        SELECT
            D.IdProducto,
            N'EGRESO',
            SUM(D.Cantidad),
            SYSDATETIME(),
            @Observacion,
            @IdUsuario
        FROM dbo.DetalleCompra AS D
        WHERE D.IdCompra = @IdCompra
        GROUP BY D.IdProducto;

        -- Marcamos la compra como anulada y guardamos el motivo.
        UPDATE dbo.Compra
        SET
            Anulada = 1,
            Observaciones = LEFT(
                CASE
                    WHEN Observaciones IS NULL
                      OR LTRIM(RTRIM(Observaciones)) = N''
                    THEN CONCAT(N'ANULADA - Motivo: ', @MotivoFinal)
                    ELSE CONCAT(
                        Observaciones,
                        CHAR(13), CHAR(10),
                        N'ANULADA - Motivo: ', @MotivoFinal
                    )
                END,
                500
            )
        WHERE IdCompra = @IdCompra
          AND Anulada = 0;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 50005, N'No se pudo actualizar el estado de la compra.', 1;
        END;

        -- Registrar la anulación en la bitácora.
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
            N'ANULAR',
            N'Compra',
            @IdCompra,
            LEFT(CONCAT(N'Compra #', @IdCompra, N' anulada | Motivo: ', @MotivoFinal), 255)
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;

        THROW;
    END CATCH;
END;
GO

/* ---------------------------------------------------------------------
   sp_ObtenerComprasPendientesRecepcion: compras activas que todavía no
   se recibieron. Filtra por proveedor / sucursal / comprobante y fecha.
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerComprasPendientesRecepcion
    @Buscar NVARCHAR(100) = NULL,
    @Fecha  DATE          = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SET @Buscar = NULLIF(LTRIM(RTRIM(@Buscar)), N'');

    SELECT
        c.IdCompra,
        c.Fecha,
        p.Nombre AS Proveedor,
        s.Nombre AS Sucursal,
        LTRIM(CONCAT(c.TipoComprobante, N' ', c.NumeroComprobante)) AS Comprobante,
        c.Total,
        c.EstadoRecepcion,
        c.FechaEntregaEstimada
    FROM dbo.Compra AS c
    INNER JOIN dbo.Proveedor AS p
        ON p.IdProveedor = c.IdProveedor
    LEFT JOIN dbo.SucursalProveedor AS s
        ON s.IdSucursal = c.IdSucursal
    WHERE c.Anulada = 0
      AND c.EstadoRecepcion = N'PENDIENTE'
      AND (@Fecha IS NULL OR CONVERT(DATE, c.Fecha) = @Fecha)
      AND (
            @Buscar IS NULL
            OR p.Nombre LIKE N'%' + @Buscar + N'%'
            OR p.CUIT LIKE N'%' + @Buscar + N'%'
            OR s.Nombre LIKE N'%' + @Buscar + N'%'
            OR c.NumeroComprobante LIKE N'%' + @Buscar + N'%'
          )
    ORDER BY c.Fecha, c.IdCompra;
END;
GO

/* ---------------------------------------------------------------------
   sp_ConfirmarRecepcionCompra: aprueba la recepción de una compra.
   - El stock ya ingresó al guardar la compra; acá solo se ajusta la
     diferencia entre lo pedido y lo recibido (faltantes y sobrantes).
   - Guarda la recepción y su detalle, marca la compra como APROBADA
     y lo registra en la bitácora.
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_ConfirmarRecepcionCompra
    @IdCompra      INT,
    @IdUsuario     INT,
    @TotalBoleta   DECIMAL(10,2),
    @Motivos       NVARCHAR(500) = NULL,
    @Observaciones NVARCHAR(500) = NULL,
    @Detalles      dbo.TipoDetalleRecepcion READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        IF @IdUsuario IS NULL
           OR NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE IdUsuario = @IdUsuario AND Estado = 1)
        BEGIN
            THROW 50300, N'El usuario que recibe la compra no es válido.', 1;
        END;

        IF @TotalBoleta IS NULL OR @TotalBoleta < 0
        BEGIN
            THROW 50301, N'El total de la boleta no puede ser negativo.', 1;
        END;

        IF NOT EXISTS (SELECT 1 FROM @Detalles)
        BEGIN
            THROW 50302, N'La recepción debe tener al menos un producto.', 1;
        END;

        IF EXISTS (SELECT 1 FROM @Detalles WHERE IdProducto IS NULL OR CantidadRecibida IS NULL OR CantidadRecibida < 0)
        BEGIN
            THROW 50303, N'Hay productos con cantidades recibidas inválidas.', 1;
        END;

        IF EXISTS (SELECT IdProducto FROM @Detalles GROUP BY IdProducto HAVING COUNT(*) > 1)
        BEGIN
            THROW 50304, N'Hay productos repetidos en la recepción.', 1;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM @Detalles AS d
            LEFT JOIN dbo.Producto AS p ON p.IdProducto = d.IdProducto
            WHERE p.IdProducto IS NULL
        )
        BEGIN
            THROW 50305, N'Uno o más productos recibidos no existen.', 1;
        END;

        BEGIN TRANSACTION;

        DECLARE @Anulada BIT;
        DECLARE @Estado NVARCHAR(20);
        DECLARE @TotalCompra DECIMAL(10,2);
        DECLARE @IdRecepcion INT;

        SELECT
            @Anulada = Anulada,
            @Estado = EstadoRecepcion,
            @TotalCompra = Total
        FROM dbo.Compra WITH (UPDLOCK, HOLDLOCK)
        WHERE IdCompra = @IdCompra;

        IF @Anulada IS NULL
        BEGIN
            THROW 50306, N'La compra indicada no existe.', 1;
        END;

        IF @Anulada = 1
        BEGIN
            THROW 50307, N'La compra está anulada.', 1;
        END;

        IF @Estado <> N'PENDIENTE'
        BEGIN
            THROW 50308, N'La compra ya fue recibida.', 1;
        END;

        -- Todos los productos de la compra tienen que figurar (con 0 si no llegaron).
        IF EXISTS
        (
            SELECT 1
            FROM dbo.DetalleCompra AS dc
            WHERE dc.IdCompra = @IdCompra
              AND NOT EXISTS (SELECT 1 FROM @Detalles AS d WHERE d.IdProducto = dc.IdProducto)
        )
        BEGIN
            THROW 50309, N'Faltan productos de la compra en la recepción. Indicá 0 si no llegaron.', 1;
        END;

        DECLARE @Comparacion TABLE
        (
            IdProducto INT PRIMARY KEY,
            Pedida     DECIMAL(10,3) NOT NULL,
            Recibida   DECIMAL(10,3) NOT NULL,
            Diferencia DECIMAL(10,3) NOT NULL
        );

        INSERT INTO @Comparacion (IdProducto, Pedida, Recibida, Diferencia)
        SELECT
            d.IdProducto,
            ISNULL(p.Pedida, 0),
            d.CantidadRecibida,
            d.CantidadRecibida - ISNULL(p.Pedida, 0)
        FROM @Detalles AS d
        LEFT JOIN
        (
            SELECT IdProducto, SUM(Cantidad) AS Pedida
            FROM dbo.DetalleCompra
            WHERE IdCompra = @IdCompra
            GROUP BY IdProducto
        ) AS p
            ON p.IdProducto = d.IdProducto;

        -- Para descontar faltantes tiene que haber stock suficiente.
        IF EXISTS
        (
            SELECT 1
            FROM @Comparacion AS c
            LEFT JOIN dbo.Stock AS s WITH (UPDLOCK, HOLDLOCK)
                ON s.IdProducto = c.IdProducto
            WHERE c.Diferencia < 0
              AND (s.IdProducto IS NULL OR s.CantidadActual < -c.Diferencia)
        )
        BEGIN
            THROW 50310, N'No hay stock suficiente para descontar los faltantes. Verificá las existencias actuales.', 1;
        END;

        -- Ajustar el stock por las diferencias.
        UPDATE s
        SET s.CantidadActual = s.CantidadActual + c.Diferencia
        FROM dbo.Stock AS s
        INNER JOIN @Comparacion AS c
            ON c.IdProducto = s.IdProducto
        WHERE c.Diferencia <> 0;

        INSERT INTO dbo.Stock (IdProducto, CantidadActual, StockMinimo, StockIdeal)
        SELECT c.IdProducto, c.Diferencia, 0, 0
        FROM @Comparacion AS c
        WHERE c.Diferencia > 0
          AND NOT EXISTS (SELECT 1 FROM dbo.Stock AS s WHERE s.IdProducto = c.IdProducto);

        INSERT INTO dbo.MovimientoStock
        (
            IdProducto,
            TipoMovimiento,
            Cantidad,
            FechaHora,
            Observacion,
            IdUsuario
        )
        SELECT
            c.IdProducto,
            CASE WHEN c.Diferencia > 0 THEN N'INGRESO' ELSE N'EGRESO' END,
            ABS(c.Diferencia),
            SYSDATETIME(),
            CONCAT(N'Recepción compra #', @IdCompra,
                   CASE WHEN c.Diferencia > 0 THEN N' - sobrante' ELSE N' - faltante' END),
            @IdUsuario
        FROM @Comparacion AS c
        WHERE c.Diferencia <> 0;

        -- Guardar la recepción.
        INSERT INTO dbo.RecepcionCompra
        (
            IdCompra,
            FechaRecepcion,
            IdUsuario,
            TotalCompra,
            TotalBoleta,
            Motivos,
            Observaciones
        )
        VALUES
        (
            @IdCompra,
            SYSDATETIME(),
            @IdUsuario,
            @TotalCompra,
            @TotalBoleta,
            NULLIF(LTRIM(RTRIM(@Motivos)), N''),
            NULLIF(LTRIM(RTRIM(@Observaciones)), N'')
        );

        SET @IdRecepcion = CONVERT(INT, SCOPE_IDENTITY());

        INSERT INTO dbo.DetalleRecepcionCompra (IdRecepcion, IdProducto, CantidadPedida, CantidadRecibida)
        SELECT @IdRecepcion, IdProducto, Pedida, Recibida
        FROM @Comparacion;

        UPDATE dbo.Compra
        SET EstadoRecepcion = N'APROBADA'
        WHERE IdCompra = @IdCompra;

        DECLARE @ConDiferencias BIT =
            CASE
                WHEN EXISTS (SELECT 1 FROM @Comparacion WHERE Diferencia <> 0)
                  OR @TotalBoleta <> @TotalCompra
                THEN 1 ELSE 0
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
            N'APROBAR',
            N'Compra',
            @IdCompra,
            LEFT(CONCAT(
                N'Recepción compra #', @IdCompra,
                N' | Total compra: $', @TotalCompra,
                N' | Total boleta: $', @TotalBoleta,
                CASE WHEN @ConDiferencias = 1 THEN N' | Con diferencias' ELSE N' | Sin diferencias' END
            ), 255)
        );

        COMMIT TRANSACTION;

        SELECT @IdRecepcion AS IdRecepcion;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;

        THROW;
    END CATCH;
END;
GO

-- Reemplazado por sp_ObtenerComprasBitacora (muestra todas las compras, no solo las recibidas).
DROP PROCEDURE IF EXISTS dbo.sp_ObtenerComprasAprobadas;
GO

/* ---------------------------------------------------------------------
   sp_ObtenerComprasBitacora: todas las compras para la bitácora, con
   quién la cargó, quién la recibió y su estado de entrega y de pago.
   Una compra entra en el rango de fechas si se cargó o se recibió en él.
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerComprasBitacora
    @FechaDesde DATE          = NULL,
    @FechaHasta DATE          = NULL,
    @Buscar     NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SET @Buscar = NULLIF(LTRIM(RTRIM(@Buscar)), N'');

    DECLARE @Desde DATETIME2 = ISNULL(CONVERT(DATETIME2, @FechaDesde), '19000101');
    DECLARE @Hasta DATETIME2 = DATEADD(DAY, 1, ISNULL(CONVERT(DATETIME2, @FechaHasta), '99981231'));

    SELECT
        c.IdCompra,
        c.Fecha AS FechaCompra,
        ISNULL(uc.Username, N'Sin registrar') AS CargadoPor,
        p.Nombre AS Proveedor,
        ISNULL(s.Nombre, N'Sin sucursal') AS Sucursal,
        LTRIM(CONCAT(c.TipoComprobante, N' ', c.NumeroComprobante)) AS Comprobante,
        c.Total AS TotalCompra,
        -- Estado único que combina entrega y pago, para que no se lea como contradicción.
        CASE
            WHEN c.Anulada = 1 THEN N'Anulada'
            WHEN c.EstadoRecepcion = N'APROBADA' AND sc.EstadoPago = 'PAGADA' THEN N'Completada'
            WHEN c.EstadoRecepcion = N'APROBADA' AND sc.EstadoPago = 'PARCIAL' THEN N'Entregada, pago parcial'
            WHEN c.EstadoRecepcion = N'APROBADA' THEN N'Entregada, falta pagar'
            WHEN sc.EstadoPago = 'PAGADA' THEN N'Pagada, falta entregar'
            WHEN sc.EstadoPago = 'PARCIAL' THEN N'Pago parcial, falta entregar'
            ELSE N'Pendiente de entrega y pago'
        END AS Estado,
        CASE
            WHEN c.Anulada = 1 THEN N'Anulada'
            WHEN c.EstadoRecepcion = N'APROBADA' THEN N'Entregada'
            ELSE N'Pendiente de entrega'
        END AS EstadoEntrega,
        r.FechaRecepcion,
        ur.Username AS RecibidoPor,
        CASE
            WHEN r.IdRecepcion IS NULL THEN NULL
            WHEN r.TotalBoleta <> r.TotalCompra
              OR EXISTS
                 (
                     SELECT 1
                     FROM dbo.DetalleRecepcionCompra AS d
                     WHERE d.IdRecepcion = r.IdRecepcion
                       AND d.CantidadRecibida <> d.CantidadPedida
                 )
            THEN N'Con diferencias'
            ELSE N'Sin diferencias'
        END AS Resultado,
        CASE c.CondicionPago
            WHEN 'CTA_CTE' THEN N'Cuenta corriente'
            ELSE N'Contado'
        END AS CondicionPago,
        CASE sc.EstadoPago
            WHEN 'PAGADA' THEN N'Pagada'
            WHEN 'PARCIAL' THEN N'Parcial'
            WHEN 'PENDIENTE' THEN N'Pendiente'
            ELSE N'-'
        END AS EstadoPago,
        sc.Saldo,
        c.FechaEntregaEstimada,
        r.TotalBoleta,
        r.TotalBoleta - r.TotalCompra AS Diferencia,
        p.CUIT,
        r.Motivos,
        r.Observaciones,
        r.IdRecepcion
    FROM dbo.Compra AS c
    LEFT JOIN dbo.RecepcionCompra AS r
        ON r.IdCompra = c.IdCompra
    INNER JOIN dbo.Proveedor AS p
        ON p.IdProveedor = c.IdProveedor
    LEFT JOIN dbo.SucursalProveedor AS s
        ON s.IdSucursal = c.IdSucursal
    LEFT JOIN dbo.Usuario AS ur
        ON ur.IdUsuario = r.IdUsuario
    LEFT JOIN dbo.Usuario AS uc
        ON uc.IdUsuario = c.IdUsuario
    LEFT JOIN dbo.vw_SaldoCompra AS sc
        ON sc.IdCompra = c.IdCompra
    WHERE (
            (c.Fecha >= @Desde AND c.Fecha < @Hasta)
            OR (r.FechaRecepcion >= @Desde AND r.FechaRecepcion < @Hasta)
          )
      AND (
            @Buscar IS NULL
            OR p.Nombre LIKE N'%' + @Buscar + N'%'
            OR p.CUIT LIKE N'%' + @Buscar + N'%'
            OR s.Nombre LIKE N'%' + @Buscar + N'%'
            OR c.NumeroComprobante LIKE N'%' + @Buscar + N'%'
            OR ur.Username LIKE N'%' + @Buscar + N'%'
            OR uc.Username LIKE N'%' + @Buscar + N'%'
            OR CONVERT(NVARCHAR(20), c.IdCompra) = @Buscar
          )
    ORDER BY COALESCE(r.FechaRecepcion, c.Fecha) DESC, c.IdCompra DESC;
END;
GO

/* ---------------------------------------------------------------------
   sp_BuscarProductoCompra: productos de una sucursal del proveedor para
   cargar en una compra, con su costo (sin IVA) y la alícuota de IVA.
   PrecioCompra puede venir NULL si todavía no se cargó el costo.
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_BuscarProductoCompra
    @Texto      NVARCHAR(200),
    @IdSucursal INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.IdProducto,
        p.CodigoBarra,
        p.SKU,
        p.Nombre,
        psp.PrecioCompra,
        i.Alicuota
    FROM dbo.Producto AS p
    INNER JOIN dbo.IVA AS i
        ON p.IdIVA = i.IdIVA
    INNER JOIN dbo.ProductoSucursalProveedor AS psp
        ON psp.IdProducto = p.IdProducto
       AND psp.IdSucursal = @IdSucursal
       AND psp.Activo = 1
    WHERE p.Activo = 1
      AND (
            p.CodigoBarra LIKE @Texto + '%'
            OR p.SKU LIKE @Texto + '%'
            OR p.Nombre LIKE @Texto + '%'
            OR psp.CodigoProveedor LIKE @Texto + '%'
          )
    ORDER BY
        CASE
            WHEN p.CodigoBarra = @Texto THEN 1
            WHEN p.SKU = @Texto THEN 2
            WHEN p.Nombre = @Texto THEN 3
            ELSE 4
        END,
        p.Nombre;
END;
GO
