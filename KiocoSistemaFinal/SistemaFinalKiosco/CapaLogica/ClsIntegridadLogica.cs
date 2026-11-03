using CapaDatos.NegocioDatos;
using CapaEntidades;
using CapaLogica.BitacoraLogi;

namespace CapaLogica
{
    // Verificación de integridad con el dígito verificador horizontal (DVH): para cada fila de
    // Producto, Usuario y Venta se vuelve a calcular el DVH con sus datos y se compara con el
    // guardado. Si no coinciden, la fila se modificó por fuera del sistema.
    public class ClsIntegridadLogica
    {
        // Quien puede generar y restaurar backups es quien resuelve los problemas de integridad.
        public const int PermisoIntegridad = 1280;

        public List<ClsInconsistenciaDVH> Verificar()
        {
            List<ClsInconsistenciaDVH> inconsistencias = new List<ClsInconsistenciaDVH>();

            inconsistencias.AddRange(new ClsGestorProductoDatos().VerificarDVHProductos());
            inconsistencias.AddRange(new ClsUsuarioDatos().VerificarDVHUsuarios());
            inconsistencias.AddRange(new ClsGestorVentaDatos().VerificarDVHVentas());

            return inconsistencias;
        }

        // Da por buenos los datos actuales: vuelve a calcular el DVH de todas las filas.
        public void RecalcularTodo(int idUsuario)
        {
            new ClsGestorProductoDatos().RecalcularDVHTodosLosProductos();
            new ClsUsuarioDatos().RecalcularDVHTodosLosUsuarios();
            new ClsGestorVentaDatos().RecalcularDVHTodasLasVentas();

            RegistrarBitacora(idUsuario, "RECALCULAR_DVH", "Se recalculó el DVH de productos, usuarios y ventas.");
        }

        public void RegistrarInconsistencias(int idUsuario, int cantidad)
        {
            RegistrarBitacora(idUsuario, "INTEGRIDAD", "La verificación de integridad encontró " + cantidad + " registro(s) con DVH inválido.");
        }

        // Un fallo al registrar la bitácora no debe cortar la verificación.
        private void RegistrarBitacora(int idUsuario, string accion, string detalle)
        {
            try
            {
                new clsBitacoraLogica().RegistrarBitacora(idUsuario, accion, "Seguridad", null, detalle);
            }
            catch
            {
            }
        }
    }
}
