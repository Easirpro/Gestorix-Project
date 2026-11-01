using CapaDatos.NegocioDatos;
using CapaEntidades;
using CapaEntidades.NegocioEntidades;
using System;
using System.Data;
using System.Linq;

namespace CapaLogica.NegocioLogica
{
    public class ClsCompraLogica
    {
        private ClsCompraDatos datos = new ClsCompraDatos();

        public DataTable BuscarProducto(string texto)
        {
            return datos.BuscarProducto(texto);
        }
        public DataTable BuscarProductoCompra(string texto, int idSucursal)
        {
            if (idSucursal <= 0)
            {
                throw new InvalidOperationException("Seleccione la sucursal del proveedor antes de agregar productos.");
            }

            return datos.BuscarProductoCompra(texto, idSucursal);
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
        // El número es opcional: sin número no hay nada que comparar.
        public bool ExisteComprobante(int idProveedor, string tipoComprobante, string? numeroComprobante)
        {
            if (string.IsNullOrWhiteSpace(numeroComprobante))
            {
                return false;
            }

            return datos.ExisteComprobante(idProveedor, tipoComprobante, numeroComprobante);
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
        public DataTable ObtenerComprasPendientesRecepcion(string buscar, DateTime? fecha)
        {
            return datos.ObtenerComprasPendientesRecepcion(buscar, fecha);
        }
        public int ConfirmarRecepcion(ClsRecepcionCompraEntidad recepcion)
        {
            int idUsuario = SesionUsuario.IdUsuario;

            if (idUsuario <= 0)
            {
                throw new InvalidOperationException("No hay una sesión de usuario válida. Volvé a iniciar sesión.");
            }

            if (recepcion == null || recepcion.IdCompra <= 0)
            {
                throw new InvalidOperationException("Seleccione una compra para recibir.");
            }

            if (recepcion.Detalles == null || recepcion.Detalles.Count == 0)
            {
                throw new InvalidOperationException("La recepción debe tener al menos un producto.");
            }

            if (recepcion.Detalles.Any(d => d.IdProducto <= 0 || d.CantidadRecibida < 0))
            {
                throw new InvalidOperationException("Las cantidades recibidas no pueden ser negativas.");
            }

            if (recepcion.Detalles.GroupBy(d => d.IdProducto).Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException("Hay productos repetidos en la recepción.");
            }

            if (recepcion.TotalBoleta < 0)
            {
                throw new InvalidOperationException("El total de la boleta no puede ser negativo.");
            }

            bool hayDiferencias = recepcion.TotalBoleta != recepcion.TotalCompra
                || recepcion.Detalles.Any(d => d.CantidadRecibida != d.CantidadPedida);

            if (hayDiferencias && string.IsNullOrWhiteSpace(recepcion.Motivos))
            {
                throw new InvalidOperationException("Hay diferencias con la compra: seleccione al menos un motivo.");
            }

            if (recepcion.Motivos != null && recepcion.Motivos.Contains("Otro motivo") && string.IsNullOrWhiteSpace(recepcion.Observaciones))
            {
                throw new InvalidOperationException("Si elige \"Otro motivo\", detalle el motivo en las observaciones.");
            }

            if (recepcion.Observaciones != null && recepcion.Observaciones.Length > 500)
            {
                throw new InvalidOperationException("Las observaciones no pueden superar los 500 caracteres.");
            }

            return datos.ConfirmarRecepcion(recepcion, idUsuario);
        }
    }
}
