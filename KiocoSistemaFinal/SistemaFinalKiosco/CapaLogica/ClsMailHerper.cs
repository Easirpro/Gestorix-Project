using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EnviarMail
{
    public static class MailHelper
    {
        public static void Enviar(string destino, string asunto, string cuerpo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("tobicalafatello@gmail.com", "Gestorix");
                mail.To.Add(destino);
                mail.Subject = asunto;
                mail.Body = cuerpo;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("tobicalafatello@gmail.com", "txqs otae xyia dgws");
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch
            {
                throw new Exception("Error al enviar el mail. \n \n " +
                    "Por favor verifica tu conexión a internet y que tus datos sean correctos");
            }
        }

        public static void Enviar(string destino, string nuevaContraseña)
        {
            string asunto = "Recuperación de contraseña";
            string cuerpo = CrearCuerpoRecuperacion(nuevaContraseña);

            Enviar(destino, asunto, cuerpo); // reutiliza el metodo principal
        }

        private static string CrearCuerpoRecuperacion(string nuevaContraseña)
        {
            return @"<style>
                        h1{color:dodgerblue;}
                        h2{color:darkorange;}
                    </style>
                    <h1>Contraseña de ingreso:</h1>
                    <h2>" + nuevaContraseña + "</h2>";
        }
    }
}