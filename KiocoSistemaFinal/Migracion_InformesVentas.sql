USE Gestorix;
GO

CREATE OR ALTER PROCEDURE dbo.sp_InformeVentas
    @Tipo         VARCHAR(10),
    @Desde        DATE,
    @Hasta        DATE,
    @IdUsuario    INT = NULL,
    @IdMetodoPago INT = NULL,
    @IdCategoria  INT = NULL,
    @IdProducto   INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Tipo NOT IN ('FECHA', 'DETALLE', 'RUBRO', 'ARTICULO', 'MEDIO')
    BEGIN
        THROW 50400, 'El tipo de informe no es válido.', 1;
    END;

    IF @Desde IS NULL OR @Hasta IS NULL OR @Desde > @Hasta
    BEGIN
        THROW 50401, 'El rango de fechas no es válido.', 1;
    END;

    DECLARE @HastaExclusivo DATE = DATEADD(DAY, 1, @Hasta);
    DECLARE @IdEfectivo INT = (SELECT TOP 1 IdMetodoPago FROM dbo.MetodoPago WHERE Nombre = N'Efectivo');

    DECLARE @Pagos TABLE (IdVenta INT, IdMetodoPago INT, Monto DECIMAL(18,2));

    INSERT INTO @Pagos (IdVenta, IdMetodoPago, Monto)
    SELECT vp.IdVenta, vp.IdMetodoPago, vp.Monto
    FROM dbo.VentaPago AS vp
    INNER JOIN dbo.Venta AS v ON v.IdVenta = vp.IdVenta
    WHERE v.Anulada = 0
      AND v.FechaHora >= @Desde AND v.FechaHora < @HastaExclusivo
    UNION ALL
    SELECT v.IdVenta, v.IdMetodoPago, v.Total
    FROM dbo.Venta AS v
    WHERE v.Anulada = 0
      AND v.FechaHora >= @Desde AND v.FechaHora < @HastaExclusivo
      AND NOT EXISTS (SELECT 1 FROM dbo.VentaPago AS vp WHERE vp.IdVenta = v.IdVenta);

    DECLARE @Ventas TABLE (IdVenta INT PRIMARY KEY, FechaHora DATETIME2, Total DECIMAL(18,2), IdUsuario INT);

    INSERT INTO @Ventas (IdVenta, FechaHora, Total, IdUsuario)
    SELECT v.IdVenta, v.FechaHora, v.Total, v.IdUsuario
    FROM dbo.Venta AS v
    WHERE v.Anulada = 0
      AND v.FechaHora >= @Desde AND v.FechaHora < @HastaExclusivo
      AND (@IdUsuario IS NULL OR v.IdUsuario = @IdUsuario)
      AND (@IdMetodoPago IS NULL OR EXISTS (SELECT 1 FROM @Pagos AS p WHERE p.IdVenta = v.IdVenta AND p.IdMetodoPago = @IdMetodoPago));

    DECLARE @Lineas TABLE
    (
        IdVenta        INT,
        FechaHora      DATETIME2,
        IdUsuario      INT,
        IdProducto     INT,
        Cantidad       DECIMAL(18,3),
        PrecioUnitario DECIMAL(18,2),
        Subtotal       DECIMAL(18,2),
        Importe        DECIMAL(18,2)
    );

    INSERT INTO @Lineas
    SELECT
        dv.IdVenta,
        v.FechaHora,
        v.IdUsuario,
        dv.IdProducto,
        dv.Cantidad,
        dv.PrecioUnitario,
        dv.Subtotal,
        CASE
            WHEN t.SumaSubtotal > 0 THEN ROUND(dv.Subtotal * v.Total / t.SumaSubtotal, 2)
            ELSE 0
        END
    FROM dbo.DetalleVenta AS dv
    INNER JOIN @Ventas AS v ON v.IdVenta = dv.IdVenta
    INNER JOIN dbo.Producto AS p ON p.IdProducto = dv.IdProducto
    CROSS APPLY (SELECT SUM(x.Subtotal) AS SumaSubtotal FROM dbo.DetalleVenta AS x WHERE x.IdVenta = dv.IdVenta) AS t
    WHERE (@IdCategoria IS NULL OR p.IdCategoria = @IdCategoria)
      AND (@IdProducto IS NULL OR dv.IdProducto = @IdProducto);

    DECLARE @Devoluciones TABLE
    (
        IdDevolucion   INT,
        FechaHora      DATETIME2,
        IdVenta        INT,
        IdUsuario      INT,
        IdProducto     INT,
        Cantidad       DECIMAL(18,3),
        PrecioUnitario DECIMAL(18,2),
        Importe        DECIMAL(18,2),
        IdMetodoPago   INT
    );

    INSERT INTO @Devoluciones
    SELECT
        d.IdDevolucion,
        d.FechaHora,
        d.IdVenta,
        COALESCE(v.IdUsuario, d.IdUsuario),
        d.IdProducto,
        d.Cantidad,
        d.PrecioUnitario,
        d.ImporteDevuelto,
        COALESCE(d.IdMetodoPago, @IdEfectivo)
    FROM dbo.Devolucion AS d
    INNER JOIN dbo.Producto AS p ON p.IdProducto = d.IdProducto
    LEFT JOIN dbo.Venta AS v ON v.IdVenta = d.IdVenta
    WHERE d.TipoReintegro = 1
      AND d.FechaHora >= @Desde AND d.FechaHora < @HastaExclusivo
      AND (v.IdVenta IS NULL OR v.Anulada = 0)
      AND (@IdUsuario IS NULL OR COALESCE(v.IdUsuario, d.IdUsuario) = @IdUsuario)
      AND (@IdMetodoPago IS NULL OR COALESCE(d.IdMetodoPago, @IdEfectivo) = @IdMetodoPago)
      AND (@IdCategoria IS NULL OR p.IdCategoria = @IdCategoria)
      AND (@IdProducto IS NULL OR d.IdProducto = @IdProducto);

    IF @Tipo = 'FECHA'
    BEGIN
        SELECT
            x.Fecha,
            SUM(x.Ventas) AS Ventas,
            SUM(x.Unidades) AS Unidades,
            SUM(x.Vendido) AS Vendido,
            SUM(x.Devuelto) AS Devuelto,
            SUM(x.Vendido) - SUM(x.Devuelto) AS Total
        FROM
        (
            SELECT CONVERT(DATE, FechaHora) AS Fecha, COUNT(DISTINCT IdVenta) AS Ventas,
                   SUM(Cantidad) AS Unidades, SUM(Importe) AS Vendido, CONVERT(DECIMAL(18,2), 0) AS Devuelto
            FROM @Lineas
            GROUP BY CONVERT(DATE, FechaHora)
            UNION ALL
            SELECT CONVERT(DATE, FechaHora), 0, -SUM(Cantidad), 0, SUM(Importe)
            FROM @Devoluciones
            GROUP BY CONVERT(DATE, FechaHora)
        ) AS x
        GROUP BY x.Fecha
        ORDER BY x.Fecha;
    END
    ELSE IF @Tipo = 'DETALLE'
    BEGIN
        SELECT
            x.FechaHora,
            x.Movimiento,
            x.IdVenta,
            u.Username AS Vendedor,
            p.CodigoBarra,
            p.Nombre AS Articulo,
            c.Nombre AS Rubro,
            x.Cantidad,
            x.PrecioUnitario,
            x.Subtotal,
            x.Importe,
            x.MediosPago
        FROM
        (
            SELECT
                l.FechaHora,
                N'Venta' AS Movimiento,
                l.IdVenta,
                l.IdUsuario,
                l.IdProducto,
                l.Cantidad,
                l.PrecioUnitario,
                l.Subtotal,
                l.Importe,
                (
                    SELECT STRING_AGG(m.Nombre, N' + ')
                    FROM @Pagos AS pg
                    INNER JOIN dbo.MetodoPago AS m ON m.IdMetodoPago = pg.IdMetodoPago
                    WHERE pg.IdVenta = l.IdVenta
                ) AS MediosPago
            FROM @Lineas AS l
            UNION ALL
            SELECT
                d.FechaHora,
                N'Devolución',
                d.IdVenta,
                d.IdUsuario,
                d.IdProducto,
                -d.Cantidad,
                d.PrecioUnitario,
                -d.Importe,
                -d.Importe,
                m.Nombre
            FROM @Devoluciones AS d
            LEFT JOIN dbo.MetodoPago AS m ON m.IdMetodoPago = d.IdMetodoPago
        ) AS x
        INNER JOIN dbo.Producto AS p ON p.IdProducto = x.IdProducto
        LEFT JOIN dbo.Categoria AS c ON c.IdCategoria = p.IdCategoria
        LEFT JOIN dbo.Usuario AS u ON u.IdUsuario = x.IdUsuario
        ORDER BY x.FechaHora DESC, x.IdVenta DESC, p.Nombre;
    END
    ELSE IF @Tipo IN ('RUBRO', 'ARTICULO')
    BEGIN
        DECLARE @PorArticulo TABLE
        (
            IdProducto INT PRIMARY KEY,
            Ventas     INT,
            Unidades   DECIMAL(18,3),
            Vendido    DECIMAL(18,2),
            Devuelto   DECIMAL(18,2)
        );

        INSERT INTO @PorArticulo
        SELECT
            x.IdProducto,
            SUM(x.Ventas),
            SUM(x.Unidades),
            SUM(x.Vendido),
            SUM(x.Devuelto)
        FROM
        (
            SELECT IdProducto, COUNT(DISTINCT IdVenta) AS Ventas, SUM(Cantidad) AS Unidades,
                   SUM(Importe) AS Vendido, CONVERT(DECIMAL(18,2), 0) AS Devuelto
            FROM @Lineas
            GROUP BY IdProducto
            UNION ALL
            SELECT IdProducto, 0, -SUM(Cantidad), 0, SUM(Importe)
            FROM @Devoluciones
            GROUP BY IdProducto
        ) AS x
        GROUP BY x.IdProducto;

        IF @Tipo = 'RUBRO'
        BEGIN
            SELECT
                r.Rubro,
                ISNULL(v.Ventas, 0) AS Ventas,
                r.Unidades,
                r.Vendido,
                r.Devuelto,
                r.Total,
                CASE
                    WHEN SUM(r.Total) OVER () > 0
                    THEN ROUND(r.Total * 100.0 / SUM(r.Total) OVER (), 2)
                    ELSE 0
                END AS Porcentaje
            FROM
            (
                SELECT
                    ISNULL(c.Nombre, N'Sin rubro') AS Rubro,
                    SUM(a.Unidades) AS Unidades,
                    SUM(a.Vendido) AS Vendido,
                    SUM(a.Devuelto) AS Devuelto,
                    SUM(a.Vendido) - SUM(a.Devuelto) AS Total
                FROM @PorArticulo AS a
                INNER JOIN dbo.Producto AS p ON p.IdProducto = a.IdProducto
                LEFT JOIN dbo.Categoria AS c ON c.IdCategoria = p.IdCategoria
                GROUP BY c.Nombre
            ) AS r
            LEFT JOIN
            (
                SELECT ISNULL(c.Nombre, N'Sin rubro') AS Rubro, COUNT(DISTINCT l.IdVenta) AS Ventas
                FROM @Lineas AS l
                INNER JOIN dbo.Producto AS p ON p.IdProducto = l.IdProducto
                LEFT JOIN dbo.Categoria AS c ON c.IdCategoria = p.IdCategoria
                GROUP BY c.Nombre
            ) AS v ON v.Rubro = r.Rubro
            ORDER BY r.Total DESC;
        END
        ELSE
        BEGIN
            SELECT
                p.CodigoBarra,
                p.Nombre AS Articulo,
                c.Nombre AS Rubro,
                a.Ventas,
                a.Unidades,
                a.Vendido,
                a.Devuelto,
                a.Vendido - a.Devuelto AS Total,
                CASE
                    WHEN SUM(a.Vendido - a.Devuelto) OVER () > 0
                    THEN ROUND((a.Vendido - a.Devuelto) * 100.0 / SUM(a.Vendido - a.Devuelto) OVER (), 2)
                    ELSE 0
                END AS Porcentaje
            FROM @PorArticulo AS a
            INNER JOIN dbo.Producto AS p ON p.IdProducto = a.IdProducto
            LEFT JOIN dbo.Categoria AS c ON c.IdCategoria = p.IdCategoria
            ORDER BY Total DESC, p.Nombre;
        END;
    END
    ELSE
    BEGIN
        SELECT
            m.Nombre AS MedioPago,
            SUM(x.Pagos) AS Pagos,
            SUM(x.Cobrado) AS Cobrado,
            SUM(x.Devuelto) AS Devuelto,
            SUM(x.Cobrado) - SUM(x.Devuelto) AS Total,
            CASE
                WHEN SUM(SUM(x.Cobrado) - SUM(x.Devuelto)) OVER () > 0
                THEN ROUND((SUM(x.Cobrado) - SUM(x.Devuelto)) * 100.0 / SUM(SUM(x.Cobrado) - SUM(x.Devuelto)) OVER (), 2)
                ELSE 0
            END AS Porcentaje
        FROM
        (
            SELECT pg.IdMetodoPago, COUNT(*) AS Pagos, SUM(pg.Monto) AS Cobrado, CONVERT(DECIMAL(18,2), 0) AS Devuelto
            FROM @Pagos AS pg
            WHERE EXISTS (SELECT 1 FROM @Lineas AS l WHERE l.IdVenta = pg.IdVenta)
              AND (@IdMetodoPago IS NULL OR pg.IdMetodoPago = @IdMetodoPago)
            GROUP BY pg.IdMetodoPago
            UNION ALL
            SELECT IdMetodoPago, 0, 0, SUM(Importe)
            FROM @Devoluciones
            GROUP BY IdMetodoPago
        ) AS x
        INNER JOIN dbo.MetodoPago AS m ON m.IdMetodoPago = x.IdMetodoPago
        GROUP BY m.Nombre
        ORDER BY Total DESC;
    END;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_InformeVentasVendedores
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT u.IdUsuario, u.Username
    FROM dbo.Usuario AS u
    INNER JOIN dbo.Venta AS v ON v.IdUsuario = u.IdUsuario
    ORDER BY u.Username;
END;
GO
