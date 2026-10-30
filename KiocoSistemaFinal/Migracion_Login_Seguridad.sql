-- Migración: bloqueo por intentos fallidos y respuestas de seguridad con hash.
-- Se puede ejecutar más de una vez sin problemas.
USE Gestorix;
GO

-- 1) Contador de intentos fallidos de login.
IF COL_LENGTH('dbo.Usuario', 'IntentosFallidos') IS NULL
BEGIN
    ALTER TABLE dbo.Usuario
        ADD IntentosFallidos INT NOT NULL
        CONSTRAINT DF_Usuario_IntentosFallidos DEFAULT 0;
END
GO

-- 2) Respuestas de seguridad: de texto plano a hash.
-- Debe coincidir con ClsSeguridad.HashRespuesta:
--   SHA-256 (UTF-16) de "<IdUsuario>|<respuesta sin espacios en los extremos y en minúsculas>", en hexadecimal.
-- Solo convierte las filas que todavía no son un hash (64 caracteres hexadecimales).
UPDATE dbo.RespuestaSeguridad
SET Respuesta = CONVERT(NVARCHAR(64),
        HASHBYTES('SHA2_256',
            CAST(IdUsuario AS NVARCHAR(10)) + N'|' + LOWER(LTRIM(RTRIM(Respuesta)))),
        2)
WHERE NOT (LEN(Respuesta) = 64 AND Respuesta NOT LIKE '%[^0-9A-Fa-f]%');
GO
