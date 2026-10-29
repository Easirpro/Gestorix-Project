using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    // Devolución de un producto de una venta (sp_RegistrarDevolucion).
    public class ClsDevolucionEntidad
    {
        public int IdDevolucion { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public string Motivo { get; set; }

        // true = reintegro en efectivo (sale de la caja)
        // false = se entrega otra unidad del mismo producto
        public bool ReintegroEfectivo { get; set; }

        // true = la unidad devuelta está en condiciones y vuelve al stock
        public bool ReingresaStock { get; set; }

        public int IdUsuario { get; set; }

        // Resultado que devuelve el SP
        public decimal ImporteDevuelto { get; set; }
    }
}
