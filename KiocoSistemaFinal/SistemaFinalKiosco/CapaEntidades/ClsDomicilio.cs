using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ClsDomicilio
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public int IdLocalidad { get; set; }
    }
}
