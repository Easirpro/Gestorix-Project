
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ClsLocalidad
    {
        public int IdLocalidad { get; set; }
        public string NomLocalidad { get; set; }
        public string CodigoPostal { get; set; }
        public int IdPartido { get; set; }
    }
}