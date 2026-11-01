using CapaDatos.NegocioDatos;
using System;
using System.Data;

namespace CapaLogica.NegocioLogica
{
    public class ClsInformeVentasLogica
    {
        private ClsInformeVentasDatos datos = new ClsInformeVentasDatos();

        // tipo: FECHA, DETALLE, RUBRO, ARTICULO o MEDIO.
        public DataTable ObtenerInforme(string tipo, DateTime desde, DateTime hasta, int? idUsuario, int? idMetodoPago, int? idCategoria, int? idProducto)
        {
            if (desde.Date > hasta.Date)
            {
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta.");
            }

            return datos.ObtenerInforme(tipo, desde, hasta, idUsuario, idMetodoPago, idCategoria, idProducto);
        }
        public DataTable ObtenerVendedores()
        {
            return datos.ObtenerVendedores();
        }
    }
}
