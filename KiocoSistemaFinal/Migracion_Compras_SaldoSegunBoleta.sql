USE Gestorix;
GO

-- con recepcion, la deuda es el total de la boleta
CREATE OR ALTER VIEW dbo.vw_SaldoCompra
AS
    SELECT
        c.IdCompra,
        c.IdProveedor,
        c.Fecha,
        c.CondicionPago,
        c.FechaVencimiento,
        ISNULL(r.TotalBoleta, c.Total) AS Total,
        ISNULL(SUM(CASE WHEN pc.Anulado = 0 THEN pc.Monto END), 0) AS Pagado,
        ISNULL(r.TotalBoleta, c.Total) - ISNULL(SUM(CASE WHEN pc.Anulado = 0 THEN pc.Monto END), 0) AS Saldo,
        CASE
            WHEN ISNULL(SUM(CASE WHEN pc.Anulado = 0 THEN pc.Monto END), 0) >= ISNULL(r.TotalBoleta, c.Total) THEN 'PAGADA'
            WHEN ISNULL(SUM(CASE WHEN pc.Anulado = 0 THEN pc.Monto END), 0) = 0 THEN 'PENDIENTE'
            ELSE 'PARCIAL'
        END AS EstadoPago
    FROM dbo.Compra AS c
    LEFT JOIN dbo.PagoCompra AS pc ON pc.IdCompra = c.IdCompra
    LEFT JOIN dbo.RecepcionCompra AS r ON r.IdCompra = c.IdCompra
    WHERE c.Anulada = 0
    GROUP BY c.IdCompra, c.IdProveedor, c.Fecha, c.CondicionPago, c.FechaVencimiento, c.Total, r.TotalBoleta;
GO
