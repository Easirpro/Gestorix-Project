using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsValidarCUIL
    {
        public bool CuilValido(string cuil)
        {
            if (string.IsNullOrWhiteSpace(cuil))
            {
                return false; 
            }
              
            cuil = cuil.Replace("-", "").Trim();

            if (cuil.Length != 11) 
            { 
                return false;
            }
               
            if (!cuil.All(char.IsDigit))
            {
                return false;
            }

            int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += (cuil[i] - '0') * multiplicadores[i];
            }

            int resto = suma % 11;
            int digito = 11 - resto;

            if (digito == 11)
            {
                digito = 0;
            }
            else if (digito == 10)
            {
                return false;
            }

            return digito == (cuil[10] - '0');
        }
        public string MotivoCuilInvalido(string cuil)
        {
            string digitos = new string((cuil ?? "").Where(char.IsDigit).ToArray());

            if (digitos.Length == 0)
            {
                return "Ingrese el CUIL.";
            }

            if (digitos.Length != 11)
            {
                return "Complete los 11 dígitos del CUIL (si el DNI tiene 7 números, agregue un 0 adelante).";
            }

            if (!CuilValido(digitos))
            {
                return "El CUIL ingresado no es válido: el dígito verificador no coincide.";
            }

            return string.Empty;
        }
        public bool CuilVacio(string cuil)
        {
            return !(cuil ?? "").Any(char.IsDigit);
        }
        public bool CuitValido(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
            {
                return false;
            }

            cuit = cuit.Replace("-", "").Trim();

            if (cuit.Length != 11)
            {
                return false;
            }

            if (!cuit.All(char.IsDigit))
            {
                return false;
            }

            int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += (cuit[i] - '0') * multiplicadores[i];
            }

            int resto = suma % 11;
            int digito = 11 - resto;

            if (digito == 11)
            {
                digito = 0;
            }
            else if (digito == 10)
            {
                digito = 9;
            }

            return digito == (cuit[10] - '0');
        }
        public string ObtenerDNI(string cuil)
        {
            if (!CuilValido(cuil)) 
            {
                return string.Empty; 
            }
               
            cuil = cuil.Replace("-", "").Trim();

            return cuil.Substring(2, 8);
        }
    }
}
