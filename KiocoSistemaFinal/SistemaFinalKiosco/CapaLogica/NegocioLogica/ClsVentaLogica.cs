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

        public int RegistrarVenta(decimal total,int idUsuario, List<DetalleVentaEntidad> detalles, List<PagoVentaEntidad> pagos)
        {

            if (total <= 0)
            { 
                throw new Exception("El total de la venta debe ser mayor a cero."); 
            }
                

            if (detalles == null || detalles.Count == 0)
            { 
                throw new Exception("La venta debe contener al menos un producto."); 
            }
                

            if (pagos == null || pagos.Count == 0)
            { 
                throw new Exception("Debe existir al menos un método de pago."); 
            }
                

            decimal totalPagos = pagos.Sum(p => p.Monto);

            if (totalPagos != total)
            {
                throw new Exception($"Los pagos ($ {totalPagos:N2}) no coinciden con el total de la venta ($ {total:N2}).");
            }
              

            return datos.RegistrarVenta(total, idUsuario, detalles, pagos);
        }
    }
}