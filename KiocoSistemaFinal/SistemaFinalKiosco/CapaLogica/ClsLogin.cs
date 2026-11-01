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

        public bool UsuarioBloqueado { get; private set; }

        // Registros con DVH inválido encontrados al iniciar sesión (vacía si la base está íntegra).
        public List<ClsInconsistenciaDVH> Inconsistencias { get; private set; } = new List<ClsInconsistenciaDVH>();

        public bool IniciarSesion(string usuario, string password)
        {
            UsuarioBloqueado = false;

            usuario = (usuario ?? "").Trim();

            ClsUsuarioLogin encontrado = datos.ObtenerUsuarioLogin(usuario);

            if (encontrado == null)
            {
                RegistrarBitacora(null, "LOGIN_FALLIDO", "Intento de inicio de sesión fallido para el usuario: " + usuario);
                return false;
            }

            string pass = ClsSeguridad.SHA256(encontrado.Username + password);

            if (pass != encontrado.PassActual)
            {
                RegistrarBitacora(encontrado.IdUsuario, "LOGIN_FALLIDO", "Intento de inicio de sesión fallido para el usuario: " + usuario);

                return false;
            }

            if (!encontrado.Estado || !encontrado.Activo)
            {
                UsuarioBloqueado = true;
                RegistrarBitacora(encontrado.IdUsuario, "LOGIN_FALLIDO", "Intento de inicio de sesión de un usuario bloqueado o inactivo: " + usuario);
                return false;
            }

            // La verificación de integridad va antes de registrar el ingreso: RegistrarIngresoExitoso
            // recalcula el DVH del usuario y taparía una modificación hecha a su fila. Si su fila está
            // alterada no se toca, así sigue apareciendo en la verificación.
            Inconsistencias = new ClsIntegridadLogica().Verificar();

            bool usuarioAlterado = Inconsistencias.Any(i => i.Tabla == "Usuario" && i.IdRegistro == encontrado.IdUsuario);

            DateTime fechaIngreso = DateTime.Now;

            if (!usuarioAlterado)
            {
                datos.RegistrarIngresoExitoso(encontrado, fechaIngreso);
            }

            CargarSesion(encontrado, fechaIngreso);

            RegistrarBitacora(SesionUsuario.IdUsuario, "LOGIN", "Inicio de sesión correcto.");

            return true;
        }
        private void CargarSesion(ClsUsuarioLogin usuario, DateTime fechaIngreso)
        {
            SesionUsuario.IdUsuario = usuario.IdUsuario;
            SesionUsuario.Estado = usuario.Estado;
            SesionUsuario.IdPersona = usuario.IdPersona;
            SesionUsuario.IdRol = usuario.IdRol;
            SesionUsuario.Username = usuario.Username;
            SesionUsuario.PrimerIngreso = usuario.PrimerIngreso;
            SesionUsuario.UltimoIngreso = fechaIngreso;
            SesionUsuario.Nombre = usuario.Nombre;
            SesionUsuario.Apellido = usuario.Apellido;
            SesionUsuario.DNI = usuario.DNI;
            SesionUsuario.CUIT = usuario.CUIT;
            SesionUsuario.Activo = usuario.Activo;
            SesionUsuario.Sexo = usuario.Sexo;
            SesionUsuario.IdGenero = usuario.IdGenero;
            SesionUsuario.FeNac = usuario.FeNac;
            SesionUsuario.PreguntasCompletadas = usuario.PreguntasCompletadas;

            ClsRolDatos rolDatos = new ClsRolDatos();

            SesionUsuario.Permisos = rolDatos.ObtenerPermisos(SesionUsuario.IdRol);
            SesionUsuario.SesionActiva = true;
        }
        private void RegistrarBitacora(int? idUsuario, string accion, string detalle)
        {
            try
            {
                clsBitacoraLogica bitacora = new clsBitacoraLogica();

                bitacora.RegistrarBitacora(idUsuario, accion, "Seguridad", idUsuario, detalle);
            }
            catch
            {
            }
        }
        public void CerrarSesion()
        {
            if (SesionUsuario.IdUsuario > 0)
            {
                RegistrarBitacora(SesionUsuario.IdUsuario, "LOGOUT", "Cierre de sesión.");
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
