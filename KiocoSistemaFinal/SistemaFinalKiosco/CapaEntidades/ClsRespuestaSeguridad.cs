using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ClsRespuestaSeguridad
    {
        public int IdRespuesta {  get; set; }
        public int IdUsuario { get; set; }
        public int IdPregunta { get; set; }
        public string Respuesta { get; set; }

    }
}
