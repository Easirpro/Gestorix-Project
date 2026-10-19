using CapaDatos;
using CapaEntidades;
using CapaLogica.BitacoraLogi;
using CapaSesion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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

            bool resultado = datos.ValidarUsuario(usuario, pass);

            clsBitacoraLogica bitacora = new clsBitacoraLogica();

            if (resultado)
            {
                bitacora.RegistrarBitacora( SesionUsuario.IdUsuario, "LOGIN", "Seguridad", 
                    SesionUsuario.IdUsuario, "Inicio de sesión correcto.");
            }
            else
            {
                bitacora.RegistrarBitacora( null, "LOGIN_FALLIDO", "Seguridad",
                    null, "Intento de inicio de sesión fallido para el usuario: " + usuario);
            }

            return resultado;
        }
        public void CerrarSesion()
        {
            if (SesionUsuario.IdUsuario > 0)
            {
                clsBitacoraLogica bitacora = new clsBitacoraLogica();

                bitacora.RegistrarBitacora(
                    SesionUsuario.IdUsuario,
                    "LOGOUT",
                    "Seguridad",
                    SesionUsuario.IdUsuario,
                    "Cierre de sesión."
                );
            }


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