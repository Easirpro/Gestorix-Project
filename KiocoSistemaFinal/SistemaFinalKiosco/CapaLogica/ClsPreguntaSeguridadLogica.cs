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

        public bool ValidarRespuesta(int idUsuario,int idPregunta,string respuesta)
        {
            return datos.ValidarRespuesta(idUsuario,idPregunta,ClsSeguridad.HashRespuesta(idUsuario,respuesta));
        }

        public bool GuardarPreguntas(int idUsuario,int idPregunta1,string respuesta1,int idPregunta2,string respuesta2,int idPregunta3,string respuesta3)
        {
            bool ok = true;

            ok &= datos.RegistrarRespuestaUsuario(idUsuario,idPregunta1,ClsSeguridad.HashRespuesta(idUsuario,respuesta1));
            ok &= datos.RegistrarRespuestaUsuario(idUsuario,idPregunta2,ClsSeguridad.HashRespuesta(idUsuario,respuesta2));
            ok &= datos.RegistrarRespuestaUsuario(idUsuario,idPregunta3,ClsSeguridad.HashRespuesta(idUsuario,respuesta3));

            return ok;
        }


    }
}
