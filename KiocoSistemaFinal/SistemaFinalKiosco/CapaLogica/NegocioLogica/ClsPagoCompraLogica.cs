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
    public class ClsPagoCompraLogica
    {
        private ClsPagoCompraDatos datos = new ClsPagoCompraDatos();

        public DataTable ObtenerComprasPendientes(int? idProveedor, bool incluirPagadas)
        {
            return datos.ObtenerComprasPendientes(idProveedor, incluirPagadas);
        }

        public DataTable ObtenerPagosCompra(int idCompra)
        {
            return datos.ObtenerPagosCompra(idCompra);
        }

        public ClsPagoCompraEntidad RegistrarPago(ClsPagoCompraEntidad pago)
        {
            return datos.RegistrarPago(pago);
        }

        public void AnularPago(int idPagoCompra, string motivo, int idUsuario)
        {
            datos.AnularPago(idPagoCompra, motivo, idUsuario);
        }
    }
}
