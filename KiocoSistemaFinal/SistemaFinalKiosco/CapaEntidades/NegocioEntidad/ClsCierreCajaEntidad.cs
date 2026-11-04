using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    public class ClsCierreCajaEntidad
    {
        // Entrada
        public int IdSesionCaja { get; set; }
        public int IdUsuario { get; set; }
        public decimal EfectivoContado { get; set; }
        public string Observacion { get; set; }

        public decimal EfectivoEsperado { get; set; }
        public decimal Diferencia { get; set; }
    }
}
