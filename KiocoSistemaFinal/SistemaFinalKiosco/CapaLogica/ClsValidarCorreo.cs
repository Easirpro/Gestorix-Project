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

                // Verifica que sea exactamente el mismo texto ingresado
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
    }
}
