using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    // Datos del usuario que necesita el login para validar y armar la sesión.
    public class ClsUsuarioLogin
    {
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public string Username { get; set; }
        public string PassActual { get; set; }
        public bool PrimerIngreso { get; set; }
        public DateTime? UltimoIngreso { get; set; }
        public int IntentosFallidos { get; set; }
        public bool PreguntasCompletadas { get; set; }
        public bool Activo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Sexo { get; set; }
        public int? IdGenero { get; set; }
        public DateTime? FeNac { get; set; }
        public string DNI { get; set; }
        public string CUIT { get; set; }
    }
}
