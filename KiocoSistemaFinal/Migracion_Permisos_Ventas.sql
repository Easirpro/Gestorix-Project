USE Gestorix;
GO

-- agrega los permisos de venta que le faltan a Empleado Ventas
-- se puede correr mas de una vez, no toca los demas roles
INSERT INTO dbo.RolPermiso (IdRol, IdPermiso)
SELECT r.IdRol, p.IdPermiso
FROM dbo.Rol r
JOIN dbo.Permiso p ON p.IdPermiso IN (210, 220, 221, 222)
WHERE r.Nombre = N'Empleado Ventas'
  AND NOT EXISTS (SELECT 1 FROM dbo.RolPermiso rp WHERE rp.IdRol = r.IdRol AND rp.IdPermiso = p.IdPermiso);
GO
