using CapaDatos.NegocioDatos;
using CapaEntidades;
using CapaEntidades.NegocioEntidades;
using System;
using System.Data;

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
            int idUsuario = SesionUsuario.IdUsuario;

            if (idUsuario <= 0)
            {
                throw new InvalidOperationException(
                    "No hay una sesión de usuario válida. Volvé a iniciar sesión.");
            }

            return datos.GuardarCompra(compra, idUsuario);
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
            int idUsuario = SesionUsuario.IdUsuario;

            if (idUsuario <= 0)
            {
                throw new InvalidOperationException("No hay una sesión de usuario válida. Volvé a iniciar sesión.");
            }

            datos.AnularCompra(idCompra, motivo, idUsuario);
        }
    }
}
