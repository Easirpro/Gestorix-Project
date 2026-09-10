using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EnviarMail
{
    /// <summary>
    /// Clase auxiliar para el envío de correos electrónicos.
    /// Permite enviar mails genéricos y también correos específicos
    /// como recuperación de contraseña.
    /// Si escribimos SOLAMENTE destinatario y nuevaContraseña, se generará un correo de recuperación.
    /// En cambio si escribimos destinatario, asunto y cuerpo, se enviará un correo con esos datos específicos.
    /// </summary>
    public static class MailHelper
    {
        /// <summary>
        /// Envía un correo electrónico con todos los datos necesarios.
        /// Este es el método más completo y el que realiza el envío real.
        /// </summary>
        /// <param name="destino">Dirección de correo del destinatario.</param>
        /// <param name="asunto">Asunto del mensaje.</param>
        /// <param name="cuerpo">Contenido del mensaje (puede estar en formato HTML).</param>
        public static void Enviar(string destino, string asunto, string cuerpo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                //IMPORTANTE: Esta direccion de correo se debe cambiar por la generada por Uds.y despues de la coma va el nombre de su sistema o el que corresponda.
                mail.From = new MailAddress("tobicalafatello@gmail.com", "Gestorix");
                mail.To.Add(destino);
                mail.Subject = asunto;
                mail.Body = cuerpo;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //IMPORTANTE: Esta direccion de correo y contraseña se deben cambiar por la generada por Uds.
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

        /// <summary>
        /// Envía un correo de recuperación de contraseña.
        /// Esta es una versión simplificada del método Enviar.
        /// Genera automáticamente el asunto y el contenido del mensaje.
        /// </summary>
        /// <param name="destino">Dirección de correo del destinatario.</param>
        /// <param name="nuevaContraseña">Nueva contraseña generada para el usuario.</param> 
        public static void Enviar(string destino, string nuevaContraseña)
        {
            string asunto = "Recuperación de contraseña";
            string cuerpo = CrearCuerpoRecuperacion(nuevaContraseña);

            Enviar(destino, asunto, cuerpo); // reutiliza el método principal
        }

        /// <summary>
        /// Genera el contenido HTML para el correo de recuperación de contraseña.
        /// Este método es privado porque solo se utiliza dentro de la clase.
        /// </summary>
        /// <param name="nuevaContraseña">Nueva contraseña generada.</param>
        /// <returns>Cadena con el contenido HTML del mensaje.</returns>
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