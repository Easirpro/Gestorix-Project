using CapaLogica.BitacoraLogi;

namespace CapaLogica
{
    // Registra en la bitácora (categoría Seguridad) los cambios y recuperos de contraseña.
    // Un fallo al registrar no debe cortar el cambio de contraseña.
    public static class ClsRegistroSeguridad
    {
        public static void Registrar(int idUsuario, string accion, string detalle)
        {
            try
            {
                clsBitacoraLogica bitacora = new clsBitacoraLogica();
                bitacora.RegistrarBitacora(idUsuario > 0 ? idUsuario : (int?)null, accion, "Seguridad", idUsuario, detalle);
            }
            catch
            {
            }
        }
    }
}
