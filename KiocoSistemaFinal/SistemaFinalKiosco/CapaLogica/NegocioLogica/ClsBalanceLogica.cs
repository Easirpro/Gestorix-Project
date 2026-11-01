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
    public class ClsBalanceLogica
    {
        private ClsBalanceDatos datos = new ClsBalanceDatos();

        public DataSet ObtenerResumen(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerResumen(desde, hasta);
        }

        public DataTable ObtenerPorMedioPago(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerPorMedioPago(desde, hasta);
        }

        public DataTable ObtenerPorDia(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerPorDia(desde, hasta);
        }

        public DataTable ObtenerPorEmpleado(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerPorEmpleado(desde, hasta);
        }

        public DataTable ObtenerPorProducto(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerPorProducto(desde, hasta);
        }

        public DataTable ObtenerPorPromocion(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerPorPromocion(desde, hasta);
        }

        public DataTable ObtenerDetalle(DateTime desde, DateTime hasta, string tipo, int? idMetodoPago, int? idUsuario)
        {
            return datos.ObtenerDetalle(desde, hasta, tipo, idMetodoPago, idUsuario);
        }
    }
}
