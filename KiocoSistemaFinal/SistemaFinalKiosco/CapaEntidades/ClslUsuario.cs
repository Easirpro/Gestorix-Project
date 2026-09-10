using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ClslUsuario
    {
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public string Username { get; set; }
        public string PassActual { get; set; }
        public bool PrimerIngreso { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public bool PreguntasCompletadas { get; set; }

    }
}
