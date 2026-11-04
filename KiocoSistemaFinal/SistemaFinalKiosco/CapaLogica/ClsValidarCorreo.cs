using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsValidarCorreo
    {

        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                MailAddress correo = new MailAddress(email);

                if (correo.Address != email)
                    return false;

                string dominio = email.Split('@')[1].ToLower();

                string[] dominiosPermitidos =
                {
                "gmail.com",
                "hotmail.com",
                "outlook.com",
                "yahoo.com",
                "live.com",
                "icloud.com",

                "hotmail.com.ar",
                "gmail.com.ar",
                "yahoo.com.ar",
                "arnet.com.ar",
                "fibertel.com.ar"
            };

                return dominiosPermitidos.Contains(dominio);
            }
            catch
            {
                return false;
            }
        }

        // Proveedores: acepta dominios propios
        public static bool EsEmailValidoCualquierDominio(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                MailAddress correo = new MailAddress(email);

                if (correo.Address != email)
                    return false;

                string[] partes = correo.Host.Split('.');

                // dominio con punto y terminación de letras
                if (partes.Length < 2)
                    return false;

                foreach (string parte in partes)
                {
                    if (parte.Length == 0 || parte.StartsWith("-") || parte.EndsWith("-") ||
                        !parte.All(c => char.IsLetterOrDigit(c) || c == '-'))
                        return false;
                }

                string terminacion = partes[partes.Length - 1];

                return terminacion.Length >= 2 && terminacion.All(char.IsLetter);
            }
            catch
            {
                return false;
            }
        }
    }
}
