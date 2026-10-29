using CapaDatos.NegocioDatos;
using CapaEntidades.NegocioEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.NegocioLogica
{
    public class ClsDevolucionLogica
    {
        private ClsDevolucionDatos datos = new ClsDevolucionDatos();

        public DataTable ObtenerDevoluciones(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerDevoluciones(desde, hasta);
        }

        public DataTable ObtenerVentasParaDevolucion(DateTime desde, DateTime hasta, int? idVenta)
        {
            return datos.ObtenerVentasParaDevolucion(desde, hasta, idVenta);
        }

        public DataTable ObtenerDetalleParaDevolucion(int idVenta)
        {
            return datos.ObtenerDetalleParaDevolucion(idVenta);
        }

        public ClsDevolucionEntidad RegistrarDevolucion(ClsDevolucionEntidad devolucion)
        {
            return datos.RegistrarDevolucion(devolucion);
        }
    }
}
