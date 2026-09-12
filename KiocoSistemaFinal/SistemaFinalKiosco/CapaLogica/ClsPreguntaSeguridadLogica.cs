using CapaDatos;
using CapaEntidades;
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

        public bool ValidarRespuesta(int idUsuario,int idPregunta,string respuesta)
        {
            return datos.ValidarRespuesta(idUsuario,idPregunta,respuesta);
        }

        public bool GuardarPreguntas(int idUsuario,int idPregunta1,string respuesta1,int idPregunta2,string respuesta2,int idPregunta3,string respuesta3)
        {
            bool ok = true;

            ok &= datos.RegistrarRespuestaUsuario(idUsuario,idPregunta1,respuesta1);
            ok &= datos.RegistrarRespuestaUsuario(idUsuario,idPregunta2,respuesta2);
            ok &= datos.RegistrarRespuestaUsuario(idUsuario,idPregunta3,respuesta3);

            return ok;
        }


    }
}
