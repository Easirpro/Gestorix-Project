USE Gestorix;
GO

DECLARE @Nuevos TABLE (IdPermiso INT, CodigoPermiso VARCHAR(20), Nombre NVARCHAR(100), Descripcion NVARCHAR(300));

INSERT INTO @Nuevos (IdPermiso, CodigoPermiso, Nombre, Descripcion) VALUES
(250,  '2.5.0',  N'Anular Ventas',                 N'Permite anular ventas realizadas.'),
(310,  '3.1.0',  N'Nueva Compra',                  N'Permite acceder al Administrador de Compras y registrar nuevas compras.'),
(320,  '3.2.0',  N'Recepción de Mercadería',       N'Permite recibir la mercadería de las compras pendientes.'),
(330,  '3.3.0',  N'Anular Compras',                N'Permite anular compras registradas.'),
(660,  '6.6.0',  N'Balance',                       N'Permite consultar y exportar el Balance.'),
(750,  '7.5.0',  N'Estado e Historial de Caja',    N'Permite ver el estado de la caja y el historial de cajas.'),
(760,  '7.6.0',  N'Anular Movimiento de Caja',     N'Permite anular ingresos y egresos de la caja.'),
(1280, '12.8.0', N'Gestión de Backup',             N'Permite generar y restaurar copias de seguridad de la base de datos.'),
(1290, '12.9.0', N'Bitácora',                      N'Permite consultar la bitácora del sistema.');

SET IDENTITY_INSERT dbo.Permiso ON;

INSERT INTO dbo.Permiso (IdPermiso, CodigoPermiso, Nombre, Descripcion)
SELECT n.IdPermiso, n.CodigoPermiso, n.Nombre, n.Descripcion
FROM @Nuevos n
WHERE NOT EXISTS (SELECT 1 FROM dbo.Permiso p WHERE p.IdPermiso = n.IdPermiso);

SET IDENTITY_INSERT dbo.Permiso OFF;
GO

DECLARE @RolPermiso TABLE (Rol NVARCHAR(50), IdPermiso INT);

INSERT INTO @RolPermiso (Rol, IdPermiso)
SELECT N'Empleado Ventas', IdPermiso FROM (VALUES
    (210), (220), (221), (222),
    (510),
    (710), (720), (730), (740), (750),
    (900),
    (1030),
    (1110)
) v(IdPermiso);

INSERT INTO @RolPermiso (Rol, IdPermiso)
SELECT N'Empleado Compras', IdPermiso FROM (VALUES
    (110), (111), (112), (113), (121), (130), (131), (132), (140),
    (310), (320),
    (420),
    (520),
    (710), (720),
    (900),
    (1030),
    (1100), (1110), (1120)
) v(IdPermiso);

INSERT INTO @RolPermiso (Rol, IdPermiso)
SELECT N'Empleado General', IdPermiso FROM (VALUES
    (110), (111), (112), (113), (121), (130), (131), (132), (140),
    (210), (220), (221), (222), (230), (240),
    (310), (320),
    (420),
    (510), (520),
    (710), (720), (730), (740), (750),
    (900),
    (1030),
    (1100), (1110), (1120)
) v(IdPermiso);

BEGIN TRANSACTION;

DELETE rp
FROM dbo.RolPermiso rp
JOIN dbo.Rol r ON r.IdRol = rp.IdRol
WHERE r.Nombre IN (N'Administrador', N'Empleado Ventas', N'Empleado Compras', N'Empleado General');

INSERT INTO dbo.RolPermiso (IdRol, IdPermiso)
SELECT r.IdRol, p.IdPermiso
FROM dbo.Rol r
CROSS JOIN dbo.Permiso p
WHERE r.Nombre = N'Administrador';

INSERT INTO dbo.RolPermiso (IdRol, IdPermiso)
SELECT r.IdRol, x.IdPermiso
FROM @RolPermiso x
JOIN dbo.Rol r ON r.Nombre = x.Rol
JOIN dbo.Permiso p ON p.IdPermiso = x.IdPermiso;

COMMIT TRANSACTION;
GO
