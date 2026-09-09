using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsValidarNumero
    {
        public class ClsValidarNumeros
        {
            public static bool SoloNumeros(char tecla)
            {
                return char.IsControl(tecla) || char.IsDigit(tecla);
            }
            public static bool NumeroValido(string numero)
            {
                if (string.IsNullOrWhiteSpace(numero))
                {
                    return false;
                }

                numero = numero.Trim();

                return numero.All(char.IsDigit);
            }
            public static bool NumeroEnteroValido(string numero)
            {
                if (string.IsNullOrWhiteSpace(numero))
                {
                    return false;
                }

                return int.TryParse(numero.Trim(), out _);
            }
        }
    }
}
