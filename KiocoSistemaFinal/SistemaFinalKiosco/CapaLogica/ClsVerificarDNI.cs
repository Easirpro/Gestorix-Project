using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsVerificarDNI
    {
        public static bool DniValido(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) 
            { 
                return false;
            }
                
            dni = dni.Trim();

            return dni.Length == 8 && dni.All(char.IsDigit) && dni.Distinct().Count() > 1;

        }
    }
}
