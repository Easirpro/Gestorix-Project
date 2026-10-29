using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    // Pago total o parcial de una compra (sp_RegistrarPagoCompra).
    public class ClsPagoCompraEntidad
    {
        public int IdPagoCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal Monto { get; set; }
        public int IdUsuario { get; set; }
        public int? IdSesionCaja { get; set; }   // null = no sale de la caja
        public string Observacion { get; set; }

        // Resultado que devuelve el SP
        public decimal SaldoRestante { get; set; }
    }
}
