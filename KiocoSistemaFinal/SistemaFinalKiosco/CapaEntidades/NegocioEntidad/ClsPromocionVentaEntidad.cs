using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    public class ClsPromocionVentaEntidad
    {
        public int IdPromocion { get; set; }
        public string Nombre { get; set; }
        public int Veces { get; set; }
        public decimal ImporteLista { get; set; }
        public decimal ImporteCobrado { get; set; } // precio con la promocion

        public decimal Descuento
        {
            get { return ImporteLista - ImporteCobrado; }
        }
    }
}
