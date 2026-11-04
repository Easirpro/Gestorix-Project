using CapaLogica.BitacoraLogi;

namespace CapaLogica
{
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
