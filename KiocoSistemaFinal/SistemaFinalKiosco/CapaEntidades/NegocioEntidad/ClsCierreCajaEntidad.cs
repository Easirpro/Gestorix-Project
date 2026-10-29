using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    // Datos de entrada y resultado del arqueo (sp_CerrarCaja).
    public class ClsCierreCajaEntidad
    {
        // Entrada
        public int IdSesionCaja { get; set; }
        public int IdUsuario { get; set; }
        public decimal EfectivoContado { get; set; }
        public string Observacion { get; set; }

        // Resultado que devuelve el SP
        public decimal EfectivoEsperado { get; set; }
        public decimal Diferencia { get; set; }   // negativo = faltante, positivo = sobrante
    }
}
