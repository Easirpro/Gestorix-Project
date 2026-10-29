using CapaDatos.NegocioDatos;
using CapaEntidades.NegocioEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogica.NegocioLogica
{
    public class ClsVentaLogica
    {
        ClsVentaDatos datos = new ClsVentaDatos();

        public DataTable ObtenerMetodosPago()
        {
            return datos.ObtenerMetodosPago();
        }
        public int RegistrarVenta( decimal total, int idUsuario, string observaciones, List<DetalleVentaEntidad> detalles, List<PagoVentaEntidad> pagos,
                                   List<ClsPromocionVentaEntidad> promociones = null)   // [PROMO] opcional
        {
            if (total <= 0)
                throw new Exception("El total de la venta debe ser mayor a cero.");

            if (detalles == null || detalles.Count == 0)
                throw new Exception("La venta debe contener al menos un producto.");

            if (pagos == null || pagos.Count == 0)
                throw new Exception("Debe existir al menos un método de pago.");

            decimal totalPagos = pagos.Sum(p => p.Monto);

            if (totalPagos != total)
            {
                throw new Exception(
                    $"Los pagos ($ {totalPagos:N2}) no coinciden con el total de la venta ($ {total:N2}).");
            }

            return datos.RegistrarVenta( total, idUsuario, observaciones, detalles, pagos, promociones);
        }
        public DataTable ObtenerVentas(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerVentas(desde, hasta);
        }
        public void CambiarEstadoVenta(int idVenta, bool anulada, string motivo)
        {
            if (idVenta <= 0)
                throw new Exception("El número de venta no es válido.");

            if (anulada && string.IsNullOrWhiteSpace(motivo))
                throw new Exception("Debe ingresar el motivo de anulación.");

            datos.CambiarEstadoVenta(idVenta, anulada, motivo);
        }
        public void ActualizarObservaciones(int idVenta, string observaciones)
        {
            if (idVenta <= 0)
                throw new Exception("La venta seleccionada no es válida.");

            if (observaciones != null && observaciones.Length > 1000)
                throw new Exception("Las observaciones no pueden superar los 1000 caracteres.");

            CapaDatos.NegocioDatos.ClsVentaDatos datos = new CapaDatos.NegocioDatos.ClsVentaDatos();

            datos.ActualizarObservaciones(idVenta, observaciones);
        }




    }
}