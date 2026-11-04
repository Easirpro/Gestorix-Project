using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    using System.Security.Cryptography;
    using System.Text;

    namespace SistemaKiosco
    {
        public class ClsDigitoVerificador
        {
            public static string GenerarHash(string texto)
            {
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));

                    return Convert.ToHexString(bytes);
                }
            }

            
            public static string FormatoImporte(decimal valor)
            {
                return valor.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            }

            public static string FormatoFecha(DateTime? valor)
            {
                return valor?.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) ?? "";
            }

            
            public static string CompararDVH(string dvhGuardado, string dvhCalculado)
            {
                if (string.IsNullOrWhiteSpace(dvhGuardado))
                {
                    return "El registro no tiene DVH.";
                }

                return string.Equals(dvhGuardado.Trim(), dvhCalculado, StringComparison.OrdinalIgnoreCase)
                    ? null
                    : "Los datos no coinciden con el DVH: el registro se modificó por fuera del sistema.";
            }
        }
    }
}
