USE Gestorix;
GO

IF COL_LENGTH('dbo.Usuario', 'IntentosFallidos') IS NULL
BEGIN
    ALTER TABLE dbo.Usuario
        ADD IntentosFallidos INT NOT NULL
        CONSTRAINT DF_Usuario_IntentosFallidos DEFAULT 0;
END
GO

UPDATE dbo.RespuestaSeguridad
SET Respuesta = CONVERT(NVARCHAR(64),
        HASHBYTES('SHA2_256',
            CAST(IdUsuario AS NVARCHAR(10)) + N'|' + LOWER(LTRIM(RTRIM(Respuesta)))),
        2)
WHERE NOT (LEN(Respuesta) = 64 AND Respuesta NOT LIKE '%[^0-9A-Fa-f]%');
GO
