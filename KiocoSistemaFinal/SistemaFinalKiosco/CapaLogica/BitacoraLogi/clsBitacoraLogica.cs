using CapaDatos.BitacoraDato;
using System;
using System.Data;

namespace CapaLogica.BitacoraLogi
{
    public class clsBitacoraLogica
    {
        private clsBitacoraDatos datos = new clsBitacoraDatos();

        public int RegistrarBitacora(int? idUsuario, string accion, string tablaAfectada, int? idRegistroAfectado, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(accion))
            {
                throw new ArgumentException("La acción de la bitácora es obligatoria.");
            }

            if (accion.Length > 50)
            {
                throw new ArgumentException("La acción no puede superar los 50 caracteres.");
            }

            if (tablaAfectada != null && tablaAfectada.Length > 50)
            {
                throw new ArgumentException("El nombre de la tabla no puede superar los 50 caracteres.");
            }

            if (descripcion != null && descripcion.Length > 255)
            {
                throw new ArgumentException("La descripción no puede superar los 255 caracteres.");
            }

            return datos.RegistrarBitacora(idUsuario, accion.Trim(),tablaAfectada, idRegistroAfectado, descripcion);
        }
        public DataTable ObtenerBitacora(DateTime? fechaDesde, DateTime? fechaHasta, string categoria, string buscar)
        {
            if (fechaDesde.HasValue && fechaHasta.HasValue && fechaDesde.Value.Date > fechaHasta.Value.Date)
            {
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta.");
            }

            return datos.ObtenerBitacora(fechaDesde, fechaHasta, categoria, buscar);
        }
        public DataTable ObtenerComprasBitacora(DateTime? fechaDesde, DateTime? fechaHasta, string buscar)
        {
            if (fechaDesde.HasValue && fechaHasta.HasValue && fechaDesde.Value.Date > fechaHasta.Value.Date)
            {
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta.");
            }

            return datos.ObtenerComprasBitacora(fechaDesde, fechaHasta, buscar);
        }
        public void RegistrarError( int? idUsuario, string modulo, string tipoExcepcion, string mensaje, string detalleTecnico)
        {
            if (string.IsNullOrWhiteSpace(modulo))
                modulo = "ModuloNoEspecificado";

            if (modulo.Length > 100)
                modulo = modulo.Substring(0, 100);

            if (tipoExcepcion?.Length > 250)
                tipoExcepcion = tipoExcepcion.Substring(0, 250);

            if (string.IsNullOrWhiteSpace(mensaje))
                mensaje = "Error sin mensaje.";

            datos.RegistrarError(
                idUsuario,
                modulo.Trim(),
                tipoExcepcion,
                mensaje,
                detalleTecnico
            );
        }
        public DataTable ObtenerErrores(DateTime? fechaDesde, DateTime? fechaHasta, string buscar, string estado)
        {
            if (fechaDesde.HasValue && fechaHasta.HasValue && fechaDesde.Value.Date > fechaHasta.Value.Date)
            {
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta.");
            }

            if (!string.IsNullOrWhiteSpace(estado) && estado != "Pendiente" && estado != "Revisado" && estado != "Resuelto")
            {
                throw new ArgumentException("El estado del error no es válido.");
            }

            return datos.ObtenerErrores(fechaDesde, fechaHasta, buscar, estado);
        }
    }
}
