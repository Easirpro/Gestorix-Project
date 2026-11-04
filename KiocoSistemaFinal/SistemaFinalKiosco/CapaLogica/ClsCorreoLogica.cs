using CapaDatos;
using CapaEntidades;
using EnviarMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsCorreoLogica
    {
        clsCorreoDatos datos = new clsCorreoDatos();
        
        public string ObtenerCorreoPorPersona(int idPersona)
        {
            return datos.ObtenerCorreoPorPersona(idPersona);
        }// revisar
        public int ObtenerIdCorreoPorPersona(int idPersona)
        {
            return datos.ObtenerIdCorreoPorPersona(idPersona);
        }// revisar
        public bool CambiarCorreoPersona(int idPersona,string nuevoCorreo)
        {

            ClsCorreo correo = new ClsCorreo();

            correo.DireccionCorreo = nuevoCorreo;

            bool desactivo = datos.DesactivarCorreo(idPersona);

            if (!desactivo) 
            {
                return false;
            }

            int idNuevoCorreo = datos.RegistrarCorreo(correo);

            if (idNuevoCorreo <= 0) 
            { 
                return false; 
            } 
            bool relacion = datos.RegistrarNuevaRelacionCorreo( idPersona,idNuevoCorreo);

            if (!relacion)
                return false;

            string asunto = "Actualización de correo - Gestorix";

            string cuerpo =
                $@"<h2>Gestorix</h2>

                <p>Su correo electrónico fue actualizado correctamente.</p>

                <p>A partir de ahora recibirá las comunicaciones en este correo.</p>";


            MailHelper.Enviar(nuevoCorreo,asunto,cuerpo);


            return true;


            return datos.RegistrarNuevaRelacionCorreo(idPersona,idNuevoCorreo);
        }
    }
}
