using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public static class SesionUsuario
    {
        public static List<int> Permisos { get; set; } = new List<int>();
        public static int IdUsuario { get; set; }
        public static bool Estado { get; set; }
        public static int IdPersona { get; set; }
        public static string Username { get; set; }
        public static bool PrimerIngreso { get; set; }
        public static int ContadorLogin { get; set; }
        public static DateTime? UltimoIngreso { get; set; }
        public static int IdRol { get; set; }
        public static bool Activo { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static bool Sexo { get; set; }
        public static int? IdGenero { get; set; }
        public static DateTime? FeNac { get; set; }
        public static string DNI { get; set; }
        public static string CUIT { get; set; }
        public static bool PreguntasCompletadas { get; set; }

    }
}
