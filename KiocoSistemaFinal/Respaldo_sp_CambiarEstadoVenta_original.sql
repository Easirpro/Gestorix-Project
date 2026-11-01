-- Respaldo de sp_CambiarEstadoVenta tal como estaba en el servidor el 31/10/2026, antes de la migración.
-- Ejecutarlo restaura la versión anterior (deshace la migración correspondiente).
USE Gestorix;
GO

/* ---------------------------------------------------------------------
   MODIFICADO: sp_CambiarEstadoVenta  (cambio marcado con [DEVOLUCION])
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_CambiarEstadoVenta
    @IdVenta INT,
    @Anulada BIT,
    @MotivoAnulacion VARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Venta
        WHERE IdVenta = @IdVenta
    )
    BEGIN
        THROW 50001, 'La venta no existe.', 1;
    END;

    -- [CAJA] Una venta de una caja ya cerrada no se puede anular ni reactivar:
    -- cambiaría un arqueo que ya fue controlado.
    IF EXISTS
    (
        SELECT 1
        FROM dbo.Venta AS v
        INNER JOIN dbo.SesionCaja AS s
            ON s.IdSesionCaja = v.IdSesionCaja
        WHERE v.IdVenta = @IdVenta
          AND s.FechaCierre IS NOT NULL
    )
    BEGIN
        THROW 50003, 'La venta pertenece a una caja cerrada y no se puede modificar.', 1;
    END;

    -- [DEVOLUCION] Una venta con devoluciones no se puede anular:
    -- el dinero o la mercadería ya se reintegraron por la devolución.
    IF @Anulada = 1
       AND EXISTS (SELECT 1 FROM dbo.Devolucion WHERE IdVenta = @IdVenta)
    BEGIN
        THROW 50004, 'La venta tiene devoluciones registradas y no se puede anular.', 1;
    END;

    IF @Anulada = 1
       AND NULLIF(LTRIM(RTRIM(@MotivoAnulacion)), '') IS NULL
    BEGIN
        THROW 50002, 'Debe ingresar el motivo de anulacion.', 1;
    END;

    UPDATE dbo.Venta
    SET Anulada = @Anulada,
        MotivoAnulacion =
            CASE
                WHEN @Anulada = 1 THEN @MotivoAnulacion
                ELSE NULL
            END
    WHERE IdVenta = @IdVenta;
END;
GO
