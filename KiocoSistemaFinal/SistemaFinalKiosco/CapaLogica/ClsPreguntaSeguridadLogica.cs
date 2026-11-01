using CapaDatos;
using CapaEntidades;
using CapaSesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsPreguntaSeguridadLogica
    {

        ClsPreguntaSeguridaDatos datos = new ClsPreguntaSeguridaDatos();
        public bool UsuarioTienePreguntas(int idUsuario)
        {
            return datos.UsuarioTienePreguntas(idUsuario);
        }

        public DataTable ObtenerPreguntas()
        {
            return datos.ObtenerPreguntas();
        }
     
        public ClsPreguntaSeguridad ObtenerPreguntaAleatoria(int idUsuario)
        {
            return datos.ObtenerPreguntaAleatoria(idUsuario);
        }

        // Tope de respuestas incorrectas al recuperar la contraseña: después de MAX_INTENTOS_RECUPERO
        // fallidos, el usuario tiene que esperar MINUTOS_BLOQUEO_RECUPERO para volver a intentar.
        // Los intentos se cuentan en la bitácora, así que no se reinician al volver a abrir la pantalla.
        public const int MAX_INTENTOS_RECUPERO = 3;
        public const int MINUTOS_BLOQUEO_RECUPERO = 15;
        private const string ACCION_RECUPERO_FALLIDO = "RECUPERO_FALLIDO";

        public static string MensajeRecuperoBloqueado
        {
            get
            {
                return "Se superó la cantidad de intentos para responder la pregunta de seguridad.\n" +
                    "Vuelva a intentar en " + MINUTOS_BLOQUEO_RECUPERO + " minutos o contacte al administrador.";
            }
        }

        public bool RecuperoBloqueado(int idUsuario)
        {
            BitacoraLogi.clsBitacoraLogica bitacora = new BitacoraLogi.clsBitacoraLogica();

            return bitacora.ContarAccionesRecientes(ACCION_RECUPERO_FALLIDO, idUsuario, MINUTOS_BLOQUEO_RECUPERO)
                >= MAX_INTENTOS_RECUPERO;
        }

        // Una respuesta incorrecta queda en la bitácora y cuenta para el tope de intentos.
        public bool ValidarRespuesta(int idUsuario,int idPregunta,string respuesta)
        {
            bool correcta = datos.ValidarRespuesta(idUsuario,idPregunta,ClsSeguridad.HashRespuesta(idUsuario,respuesta));

            if (!correcta)
            {
                ClsRegistroSeguridad.Registrar(idUsuario, ACCION_RECUPERO_FALLIDO,
                    "Respuesta de seguridad incorrecta al recuperar la contraseña.");
            }

            return correcta;
        }

        public bool GuardarPreguntas(int idUsuario,int idPregunta1,string respuesta1,int idPregunta2,string respuesta2,int idPregunta3,string respuesta3)
        {
            List<KeyValuePair<int, string>> respuestas = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(idPregunta1, ClsSeguridad.HashRespuesta(idUsuario, respuesta1)),
                new KeyValuePair<int, string>(idPregunta2, ClsSeguridad.HashRespuesta(idUsuario, respuesta2)),
                new KeyValuePair<int, string>(idPregunta3, ClsSeguridad.HashRespuesta(idUsuario, respuesta3))
            };

            return datos.GuardarRespuestas(idUsuario, respuestas);
        }


    }
}
