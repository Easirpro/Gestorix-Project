-- Migración: compras con número de comprobante opcional y sin comprobantes repetidos.
-- Modifica sp_GuardarCompra:
--   - El número de comprobante deja de ser obligatorio (al hacer el pedido puede no saberse todavía).
--   - Si se carga número, no puede repetirse para el mismo proveedor y tipo en una compra no anulada (error 50028).
-- Toma la versión actual del procedimiento en el servidor y reemplaza solo esas dos partes;
-- si no encuentra los textos esperados, se cancela sin tocar nada.
-- Para volver atrás: Respaldo_sp_GuardarCompra_original.sql.
USE Gestorix;
GO

SET NOCOUNT ON;

DECLARE @def NVARCHAR(MAX) = OBJECT_DEFINITION(OBJECT_ID(N'dbo.sp_GuardarCompra'));
DECLARE @nuevo NVARCHAR(MAX) = @def;

-- 1) CREATE -> ALTER
SET @nuevo = REPLACE(@nuevo, N'CREATE   PROCEDURE dbo.sp_GuardarCompra', N'ALTER PROCEDURE dbo.sp_GuardarCompra');

-- 2) Número de comprobante opcional: si viene vacío se guarda NULL en vez de rechazar la compra.
SET @nuevo = REPLACE(@nuevo,
    N'THROW 50013, ''El número de comprobante es obligatorio.'', 1;',
    N'-- [COMPROBANTE] Opcional: al hacer el pedido puede no saberse todavía. Vacío se guarda como NULL.
            SET @NumeroComprobante = NULL;');

-- 3) Comprobante repetido: mismo proveedor, tipo y número en una compra no anulada.
SET @nuevo = REPLACE(@nuevo,
    N'-- Validar observaciones.',
    N'-- [COMPROBANTE] Si se indica número, no puede repetirse para el mismo proveedor y tipo (salvo compras anuladas).
        IF @NumeroComprobante IS NOT NULL
           AND EXISTS
           (
               SELECT 1
               FROM dbo.Compra
               WHERE IdProveedor = @IdProveedor
                 AND TipoComprobante = @TipoComprobante
                 AND LTRIM(RTRIM(NumeroComprobante)) = LTRIM(RTRIM(@NumeroComprobante))
                 AND Anulada = 0
           )
        BEGIN
            THROW 50028, ''Ese comprobante ya está cargado para este proveedor.'', 1;
        END;

        -- Validar observaciones.');

-- Las tres partes tienen que haberse encontrado; si no, no se toca nada.
IF CHARINDEX(N'ALTER PROCEDURE dbo.sp_GuardarCompra', @nuevo) = 0
   OR CHARINDEX(N'THROW 50013', @nuevo) > 0
   OR CHARINDEX(N'THROW 50028', @nuevo) = 0
BEGIN
    THROW 51000, N'No se encontraron los textos a reemplazar; no se modificó el procedimiento.', 1;
END;

EXEC sys.sp_executesql @nuevo;

PRINT N'sp_GuardarCompra modificado.';
GO
