using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    // Promoción aplicada en una venta (se guarda en VentaPromocion).
    public class ClsPromocionVentaEntidad
    {
        public int IdPromocion { get; set; }
        public string Nombre { get; set; }
        public int Veces { get; set; }              // cuántas veces se aplicó en la venta
        public decimal ImporteLista { get; set; }   // precio normal de los productos
        public decimal ImporteCobrado { get; set; } // precio con la promoción

        public decimal Descuento
        {
            get { return ImporteLista - ImporteCobrado; }
        }
    }
}
