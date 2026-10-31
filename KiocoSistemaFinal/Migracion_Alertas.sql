-- Migración: alertas del sistema (campana del menú principal).
-- 1) Lote.DiasAlertaVencimiento: cuántos días antes del vencimiento avisar (lo pide Nuevo artículo).
--    sp_RegistrarLote y sp_ModificarLote lo reciben como parámetro opcional (las llamadas viejas siguen andando).
-- 2) sp_ObtenerAlertas: las alertas vigentes, una fila por cada cosa a revisar.
-- Se puede ejecutar más de una vez sin problemas.
USE Gestorix;
GO

IF COL_LENGTH('dbo.Lote', 'DiasAlertaVencimiento') IS NULL
BEGIN
    ALTER TABLE dbo.Lote ADD DiasAlertaVencimiento INT NULL;
END
GO

IF OBJECT_ID('dbo.CK_Lote_DiasAlertaVencimiento', 'C') IS NULL
BEGIN
    ALTER TABLE dbo.Lote
        ADD CONSTRAINT CK_Lote_DiasAlertaVencimiento CHECK (DiasAlertaVencimiento IS NULL OR DiasAlertaVencimiento >= 0);
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegistrarLote
    @IdProducto INT,
    @CodigoLote NVARCHAR(100),
    @FechaFabricacion DATETIME,
    @FechaVencimiento DATETIME,
    @FechaIngreso DATETIME,
    @Stock DECIMAL(10,3),
    @Activo BIT,
    @IdSucursal INT,
    @DiasAlertaVencimiento INT = NULL   -- [ALERTAS] días de aviso antes del vencimiento
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Lote
    (
        IdProducto,
        CodigoLote,
        FechaFabricacion,
        FechaVencimiento,
        FechaIngreso,
        Stock,
        Activo,
        IdSucursal,
        DiasAlertaVencimiento
    )
    VALUES
    (
        @IdProducto,
        @CodigoLote,
        @FechaFabricacion,
        @FechaVencimiento,
        @FechaIngreso,
        @Stock,
        @Activo,
        @IdSucursal,
        @DiasAlertaVencimiento
    );

    SELECT @@ROWCOUNT;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ModificarLote
    @IdProducto INT,
    @CodigoLote NVARCHAR(100),
    @FechaFabricacion DATE,
    @FechaVencimiento DATE,
    @FechaIngreso DATETIME2,
    @Stock DECIMAL(10,3),
    @Activo BIT,
    @IdSucursal INT,
    @DiasAlertaVencimiento INT = NULL   -- [ALERTAS] días de aviso antes del vencimiento
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Lote
    SET
        CodigoLote = @CodigoLote,
        FechaFabricacion = @FechaFabricacion,
        FechaVencimiento = @FechaVencimiento,
        FechaIngreso = @FechaIngreso,
        Stock = @Stock,
        Activo = @Activo,
        IdSucursal = @IdSucursal,
        DiasAlertaVencimiento = @DiasAlertaVencimiento
    WHERE IdProducto = @IdProducto;

    SELECT @@ROWCOUNT;
END;
GO

/* ---------------------------------------------------------------------
   sp_ObtenerAlertas: alertas vigentes, una fila por cada cosa a revisar.
   Tipo: LOTE | STOCK | ENTREGA | CAJA | PAGO | PROMOCION | PRECIO
   Prioridad: 1 = urgente, 2 = aviso.
   IdReferencia: el registro al que se refiere (producto, compra, caja...).
   Qué tipos ve cada usuario lo decide la aplicación según sus permisos.
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerAlertas
    @DiasAvisoPagos INT = 3
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Hoy DATE = CONVERT(DATE, GETDATE());

    DECLARE @Alertas TABLE
    (
        Tipo         VARCHAR(20),
        Prioridad    TINYINT,
        Descripcion  NVARCHAR(300),
        IdReferencia INT,
        Orden        INT
    );

    -- Lotes vencidos o dentro de sus días de aviso (sin días configurados: avisa el día que vence).
    -- Solo de productos con stock: el stock por lote todavía no se descuenta con las ventas.
    INSERT INTO @Alertas
    SELECT
        'LOTE',
        CASE WHEN l.FechaVencimiento < @Hoy THEN 1 ELSE 2 END,
        CONCAT(p.Nombre,
               CASE WHEN NULLIF(LTRIM(RTRIM(l.CodigoLote)), N'') IS NULL THEN N'' ELSE N' (lote ' + l.CodigoLote + N')' END,
               CASE
                   WHEN l.FechaVencimiento < @Hoy THEN N': venció el ' + FORMAT(l.FechaVencimiento, 'dd/MM/yyyy')
                   WHEN l.FechaVencimiento = @Hoy THEN N': vence hoy'
                   ELSE N': vence el ' + FORMAT(l.FechaVencimiento, 'dd/MM/yyyy')
                        + N' (en ' + CONVERT(NVARCHAR(10), DATEDIFF(DAY, @Hoy, l.FechaVencimiento)) + N' días)'
               END),
        l.IdProducto,
        DATEDIFF(DAY, @Hoy, l.FechaVencimiento)
    FROM dbo.Lote AS l
    INNER JOIN dbo.Producto AS p ON p.IdProducto = l.IdProducto
    INNER JOIN dbo.Stock AS s ON s.IdProducto = l.IdProducto
    WHERE l.Activo = 1
      AND p.Activo = 1
      AND s.CantidadActual > 0
      AND DATEADD(DAY, -ISNULL(l.DiasAlertaVencimiento, 0), l.FechaVencimiento) <= @Hoy;

    -- Stock en el mínimo o por debajo (solo productos con mínimo cargado).
    INSERT INTO @Alertas
    SELECT
        'STOCK',
        CASE WHEN s.CantidadActual <= 0 THEN 1 ELSE 2 END,
        CONCAT(p.Nombre, N': quedan ', FORMAT(s.CantidadActual, '0.###'), N' (mínimo ', FORMAT(s.StockMinimo, '0.###'), N')'),
        p.IdProducto,
        CONVERT(INT, s.CantidadActual)
    FROM dbo.Stock AS s
    INNER JOIN dbo.Producto AS p ON p.IdProducto = s.IdProducto
    WHERE p.Activo = 1
      AND s.StockMinimo > 0
      AND s.CantidadActual <= s.StockMinimo;

    -- Pedidos sin recibir que llegan hoy o están atrasados.
    INSERT INTO @Alertas
    SELECT
        'ENTREGA',
        CASE WHEN c.FechaEntregaEstimada < @Hoy THEN 1 ELSE 2 END,
        CONCAT(N'Compra N.º ', c.IdCompra, N' - ', pr.Nombre,
               CASE
                   WHEN c.FechaEntregaEstimada < @Hoy
                   THEN N': atrasada ' + CONVERT(NVARCHAR(10), DATEDIFF(DAY, c.FechaEntregaEstimada, @Hoy)) + N' día(s)'
                   ELSE N': llega hoy'
               END),
        c.IdCompra,
        DATEDIFF(DAY, @Hoy, c.FechaEntregaEstimada)
    FROM dbo.Compra AS c
    INNER JOIN dbo.Proveedor AS pr ON pr.IdProveedor = c.IdProveedor
    WHERE c.Anulada = 0
      AND c.EstadoRecepcion = N'PENDIENTE'
      AND c.FechaEntregaEstimada <= @Hoy;

    -- Cajas que quedaron abiertas desde un día anterior.
    INSERT INTO @Alertas
    SELECT
        'CAJA',
        1,
        CONCAT(N'Caja abierta desde el ', FORMAT(sc.FechaApertura, 'dd/MM/yyyy HH:mm'), N' sin cerrar'),
        sc.IdSesionCaja,
        DATEDIFF(DAY, @Hoy, CONVERT(DATE, sc.FechaApertura))
    FROM dbo.SesionCaja AS sc
    WHERE sc.FechaCierre IS NULL
      AND CONVERT(DATE, sc.FechaApertura) < @Hoy;

    -- Pagos a proveedores vencidos o que vencen dentro de @DiasAvisoPagos días.
    INSERT INTO @Alertas
    SELECT
        'PAGO',
        CASE WHEN sc.FechaVencimiento < @Hoy THEN 1 ELSE 2 END,
        CONCAT(N'Compra N.º ', sc.IdCompra, N' - ', pr.Nombre, N': saldo ', FORMAT(sc.Saldo, 'C2', 'es-AR'),
               CASE
                   WHEN sc.FechaVencimiento < @Hoy THEN N', venció el ' + FORMAT(sc.FechaVencimiento, 'dd/MM/yyyy')
                   WHEN sc.FechaVencimiento = @Hoy THEN N', vence hoy'
                   ELSE N', vence el ' + FORMAT(sc.FechaVencimiento, 'dd/MM/yyyy')
               END),
        sc.IdCompra,
        DATEDIFF(DAY, @Hoy, sc.FechaVencimiento)
    FROM dbo.vw_SaldoCompra AS sc
    INNER JOIN dbo.Proveedor AS pr ON pr.IdProveedor = sc.IdProveedor
    WHERE sc.Saldo > 0
      AND sc.FechaVencimiento IS NOT NULL
      AND sc.FechaVencimiento <= DATEADD(DAY, @DiasAvisoPagos, @Hoy);

    -- Promociones que siguen activas pero ya terminaron (fin de su vigencia o de la promoción).
    INSERT INTO @Alertas
    SELECT
        'PROMOCION',
        2,
        CONCAT(pm.Nombre, N': terminó el ', FORMAT(COALESCE(v.FechaFin, CONVERT(DATE, pm.FechaFin)), 'dd/MM/yyyy'), N' y sigue activa'),
        pm.IdPromocion,
        DATEDIFF(DAY, @Hoy, COALESCE(v.FechaFin, CONVERT(DATE, pm.FechaFin)))
    FROM dbo.Promocion AS pm
    LEFT JOIN dbo.VigenciaPromocion AS v ON v.IdPromocion = pm.IdPromocion
    WHERE pm.Activo = 1
      AND COALESCE(v.FechaFin, CONVERT(DATE, pm.FechaFin)) < @Hoy;

    -- Precio de venta menor que el costo de alguna de sus sucursales de proveedor.
    INSERT INTO @Alertas
    SELECT
        'PRECIO',
        2,
        CONCAT(p.Nombre, N': se vende a ', FORMAT(p.PrecioVenta, 'C2', 'es-AR'),
               N' y cuesta ', FORMAT(c.Costo, 'C2', 'es-AR'), N' (', c.Proveedor, N')'),
        p.IdProducto,
        0
    FROM dbo.Producto AS p
    CROSS APPLY
    (
        SELECT TOP 1 psp.PrecioCompra AS Costo, pr.Nombre AS Proveedor
        FROM dbo.ProductoSucursalProveedor AS psp
        INNER JOIN dbo.SucursalProveedor AS sp ON sp.IdSucursal = psp.IdSucursal
        INNER JOIN dbo.Proveedor AS pr ON pr.IdProveedor = sp.IdProveedor
        WHERE psp.IdProducto = p.IdProducto
          AND psp.Activo = 1
          AND psp.PrecioCompra IS NOT NULL
        ORDER BY psp.PrecioCompra DESC
    ) AS c
    WHERE p.Activo = 1
      AND p.PrecioVenta < c.Costo;

    SELECT Tipo, Prioridad, Descripcion, IdReferencia
    FROM @Alertas
    ORDER BY Prioridad, Tipo, Orden, Descripcion;
END;
GO
