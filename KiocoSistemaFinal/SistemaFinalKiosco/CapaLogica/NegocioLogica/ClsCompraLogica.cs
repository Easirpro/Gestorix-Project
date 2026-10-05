using CapaDatos.NegocioDatos;
using CapaEntidades.NegocioEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.NegocioLogica
{
    public class ClsCompraLogica
    {
        private ClsCompraDatos datos = new ClsCompraDatos();

        public DataTable BuscarProducto(string texto)
        {
            return datos.BuscarProducto(texto);
        }
        public int GuardarCompra(ClsCompraEntidad compra)
        {
            return datos.GuardarCompra(compra);
        }
        public DataTable ObtenerCompras(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerCompras(desde, hasta);
        }
        public DataTable ObtenerDetalleCompra(int idCompra)
        {
            return datos.ObtenerDetalleCompra(idCompra);
        }
        public void AnularCompra(int idCompra, string motivo)
        {
            datos.AnularCompra(idCompra, motivo);
        }
    }
}
