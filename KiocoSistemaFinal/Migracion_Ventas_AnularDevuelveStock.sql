-- Migración: anular una venta devuelve el stock (y reactivarla lo vuelve a descontar).
-- Reemplaza sp_CambiarEstadoVenta. Ver el comentario del procedimiento para el detalle.
-- La aplicación envía @IdUsuario solo si el procedimiento ya lo tiene, así que funciona antes y después de ejecutarlo.
-- Para volver atrás: Respaldo_sp_CambiarEstadoVenta_original.sql.
USE Gestorix;
GO

/* =====================================================================
   sp_CambiarEstadoVenta: anular / reactivar una venta  (cambio marcado con [STOCK])

   Antes solo cambiaba la marca Anulada: la plata salía de la caja, pero los
   productos seguían descontados del stock.

   Ahora:
   - Al ANULAR, devuelve al stock las cantidades vendidas y registra un
     movimiento INGRESO "Anulación venta N.º X".
   - Al REACTIVAR, las vuelve a descontar (EGRESO "Reactivación venta N.º X").
     Si no hay stock suficiente, no deja reactivar.
   - No deja anular una venta ya anulada ni reactivar una activa (así el stock
     no se mueve dos veces).
   - Todo en una transacción: si algo falla, no cambia nada.
   - @IdUsuario (opcional): quién anula o reactiva. Si no se envía, se usa el
     usuario que hizo la venta (MovimientoStock exige un usuario).

   Se mantienen las validaciones anteriores: caja cerrada (50003),
   devoluciones (50004) y motivo obligatorio (50002).
   ===================================================================== */
ALTER PROCEDURE dbo.sp_CambiarEstadoVenta
    @IdVenta INT,
    @Anulada BIT,
    @MotivoAnulacion VARCHAR(500) = NULL,
    @IdUsuario INT = NULL                    -- [STOCK] quién anula o reactiva
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @AnuladaActual BIT;
        DECLARE @IdUsuarioVenta INT;

        SELECT
            @AnuladaActual = Anulada,
            @IdUsuarioVenta = IdUsuario
        FROM dbo.Venta WITH (UPDLOCK, HOLDLOCK)
        WHERE IdVenta = @IdVenta;

        IF @AnuladaActual IS NULL
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

        -- [STOCK] Sin cambio de estado no se toca nada (si no, el stock se movería dos veces).
        IF @AnuladaActual = @Anulada
        BEGIN
            IF @Anulada = 1
                THROW 50005, 'La venta ya está anulada.', 1;
            ELSE
                THROW 50006, 'La venta ya está activa.', 1;
        END;

        DECLARE @IdUsuarioMovimiento INT = COALESCE(@IdUsuario, @IdUsuarioVenta);

        IF @IdUsuarioMovimiento IS NULL
        BEGIN
            THROW 50007, 'No se pudo determinar el usuario para registrar el movimiento de stock.', 1;
        END;

        -- [STOCK] Cantidades vendidas por producto.
        DECLARE @Cantidades TABLE
        (
            IdProducto INT PRIMARY KEY,
            Cantidad   DECIMAL(10,3) NOT NULL
        );

        INSERT INTO @Cantidades (IdProducto, Cantidad)
        SELECT IdProducto, SUM(Cantidad)
        FROM dbo.DetalleVenta
        WHERE IdVenta = @IdVenta
        GROUP BY IdProducto;

        IF @Anulada = 1
        BEGIN
            -- Anular: devolver al stock.
            UPDATE s
            SET s.CantidadActual = s.CantidadActual + c.Cantidad
            FROM dbo.Stock AS s WITH (UPDLOCK, HOLDLOCK)
            INNER JOIN @Cantidades AS c
                ON c.IdProducto = s.IdProducto;

            INSERT INTO dbo.Stock (IdProducto, CantidadActual, StockMinimo, StockIdeal)
            SELECT c.IdProducto, c.Cantidad, 0, 0
            FROM @Cantidades AS c
            WHERE NOT EXISTS (SELECT 1 FROM dbo.Stock AS s WHERE s.IdProducto = c.IdProducto);

            INSERT INTO dbo.MovimientoStock (IdProducto, TipoMovimiento, Cantidad, FechaHora, Observacion, IdUsuario)
            SELECT
                c.IdProducto,
                N'INGRESO',
                c.Cantidad,
                SYSDATETIME(),
                LEFT(CONCAT(N'Anulación venta N.º ', @IdVenta, N' - ', LTRIM(RTRIM(@MotivoAnulacion))), 255),
                @IdUsuarioMovimiento
            FROM @Cantidades AS c;
        END
        ELSE
        BEGIN
            -- Reactivar: volver a descontar, solo si alcanza el stock.
            IF EXISTS
            (
                SELECT 1
                FROM @Cantidades AS c
                LEFT JOIN dbo.Stock AS s WITH (UPDLOCK, HOLDLOCK)
                    ON s.IdProducto = c.IdProducto
                WHERE s.IdProducto IS NULL
                   OR s.CantidadActual < c.Cantidad
            )
            BEGIN
                THROW 50008, 'No hay stock suficiente para reactivar la venta. Verificá las existencias actuales.', 1;
            END;

            UPDATE s
            SET s.CantidadActual = s.CantidadActual - c.Cantidad
            FROM dbo.Stock AS s
            INNER JOIN @Cantidades AS c
                ON c.IdProducto = s.IdProducto;

            INSERT INTO dbo.MovimientoStock (IdProducto, TipoMovimiento, Cantidad, FechaHora, Observacion, IdUsuario)
            SELECT
                c.IdProducto,
                N'EGRESO',
                c.Cantidad,
                SYSDATETIME(),
                CONCAT(N'Reactivación venta N.º ', @IdVenta),
                @IdUsuarioMovimiento
            FROM @Cantidades AS c;
        END;

        UPDATE dbo.Venta
        SET Anulada = @Anulada,
            MotivoAnulacion =
                CASE
                    WHEN @Anulada = 1 THEN @MotivoAnulacion
                    ELSE NULL
                END
        WHERE IdVenta = @IdVenta;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO
