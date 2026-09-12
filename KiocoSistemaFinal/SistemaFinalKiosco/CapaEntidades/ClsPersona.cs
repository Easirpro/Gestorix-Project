using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ClsPersona
    {
        public int IdPersona { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Sexo { get; set; }
        public int IdGenero { get; set; }
        public DateTime FeNac { get; set; }
        public string DNI { get; set; }
        public string CUIT { get; set; }
    }
}
