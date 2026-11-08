USE Gestorix;
GO

-- alertas ocultadas por el administrador
IF OBJECT_ID('dbo.AlertaOculta', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.AlertaOculta
    (
        IdAlertaOculta INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_AlertaOculta PRIMARY KEY,
        Tipo           VARCHAR(20)  NOT NULL,
        IdReferencia   INT          NOT NULL,
        Hasta          DATE         NOT NULL,
        IdUsuario      INT          NOT NULL CONSTRAINT FK_AlertaOculta_Usuario REFERENCES dbo.Usuario (IdUsuario),
        FechaHora      DATETIME2    NOT NULL CONSTRAINT DF_AlertaOculta_FechaHora DEFAULT SYSDATETIME(),
        CONSTRAINT UQ_AlertaOculta UNIQUE (Tipo, IdReferencia)
    );
END;
GO
