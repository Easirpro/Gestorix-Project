using CapaSesion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;



namespace CapaLogica
{
    public class ClsLogin
    {
        private ClsUsuarioDatos datos = new ClsUsuarioDatos();
        
        public bool UsuarioBloqueado
        {
            get { return datos.UsuarioBloqueado; }
        }
        public bool IniciarSesion(string usuario, string password)
        {
            string pass = ClsSeguridad.SHA256(usuario + password);

            return datos.ValidarUsuario(usuario, pass);
        }
        public void CerrarSesion()
        {
            SesionUsuario.Permisos.Clear();

            SesionUsuario.IdUsuario = 0;
            SesionUsuario.Estado = false;
            SesionUsuario.IdPersona = 0;
            SesionUsuario.Username = null;
            SesionUsuario.PrimerIngreso = false;
            SesionUsuario.ContadorLogin = 0;
            SesionUsuario.UltimoIngreso = null;
            SesionUsuario.IdRol = 0;
            SesionUsuario.Activo = false;
            SesionUsuario.Nombre = null;
            SesionUsuario.Apellido = null;
            SesionUsuario.Sexo = false;
            SesionUsuario.IdGenero = null;
            SesionUsuario.FeNac = null;
            SesionUsuario.DNI = null;
            SesionUsuario.CUIT = null;
            SesionUsuario.PreguntasCompletadas = false;

            SesionUsuario.SesionActiva = false;
        }
    }
}