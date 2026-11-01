USE Gestorix;
GO

SET NOCOUNT ON;

DECLARE @def NVARCHAR(MAX) = OBJECT_DEFINITION(OBJECT_ID(N'dbo.sp_GuardarCompra'));
DECLARE @nuevo NVARCHAR(MAX) = @def;

SET @nuevo = REPLACE(@nuevo, N'CREATE   PROCEDURE dbo.sp_GuardarCompra', N'ALTER PROCEDURE dbo.sp_GuardarCompra');

SET @nuevo = REPLACE(@nuevo,
    N'THROW 50013, ''El número de comprobante es obligatorio.'', 1;',
    N'SET @NumeroComprobante = NULL;');

SET @nuevo = REPLACE(@nuevo,
    N'-- Validar observaciones.',
    N'IF @NumeroComprobante IS NOT NULL
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

IF CHARINDEX(N'ALTER PROCEDURE dbo.sp_GuardarCompra', @nuevo) = 0
   OR CHARINDEX(N'THROW 50013', @nuevo) > 0
   OR CHARINDEX(N'THROW 50028', @nuevo) = 0
BEGIN
    THROW 51000, N'No se encontraron los textos a reemplazar; no se modificó el procedimiento.', 1;
END;

EXEC sys.sp_executesql @nuevo;

PRINT N'sp_GuardarCompra modificado.';
GO
