using CapaEntidades;

namespace CapaVista
{
    // permisos 12.x para modificar datos sensibles
    public static class ClsDatosSensibles
    {
        public static bool Articulo => Tiene(1210);
        public static bool Rubro => Tiene(1220);
        public static bool Marca => Tiene(1230);
        public static bool Proveedor => Tiene(1240);
        public static bool Empleado => Tiene(1250);
        public static bool Promocion => Tiene(1260);

        private static bool Tiene(int permiso)
        {
            return SesionUsuario.Permisos.Contains(1200) || SesionUsuario.Permisos.Contains(permiso);
        }
    }
}
