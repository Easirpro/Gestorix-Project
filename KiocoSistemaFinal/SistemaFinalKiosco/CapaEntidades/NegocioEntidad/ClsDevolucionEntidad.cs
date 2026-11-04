using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    public class ClsDevolucionEntidad
    {
        public int IdDevolucion { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public string Motivo { get; set; }

        public bool ReintegroEfectivo { get; set; }

        public bool ReingresaStock { get; set; }

        public int IdUsuario { get; set; }

        public decimal ImporteDevuelto { get; set; }
    }
}
