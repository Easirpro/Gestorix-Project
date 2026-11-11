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
    public class ClsUsuarioLogica
    {
        public DataTable ObtenerUsuarios()
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerUsuarios();
        }
        public ClsPersona ObtenerPersonaPorId(int idPersona)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerPersonaPorId(idPersona);
        }
        public int ObtenerIdUsuario(string username)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerIdUsuarioPorUsername(username);
        }
        public bool UsuarioHabilitado(int idUsuario)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.UsuarioHabilitado(idUsuario);
        }
        public ClsPreguntaSeguridad ObtenerPregunta(int idUsuario)
        {
            ClsPreguntaSeguridaDatos datos = new ClsPreguntaSeguridaDatos();

            return datos.ObtenerPreguntaAleatoria(idUsuario);
        }
        public bool CambiarPasswordRecuperacion(int idUsuario, string nuevaPassword)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.CambiarPasswordRecuperacion(
                idUsuario,
                nuevaPassword
            );
        }
        public string ObtenerUsername(int idUsuario)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerUsername(idUsuario);
        }
        public string ObtenerUltimaPasswordAntigua(int idUsuario)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerUltimaPasswordAntigua(idUsuario);
        }
        public bool PasswordUsadaUltimasTres(int idUsuario, string password)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.PasswordUsadaUltimasTres(
                idUsuario,
                password
            );
        }
        public bool ExistePersonaDatos(string dni, string cuit, int idPersonaActual)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ExistePersonaDatos(dni, cuit, idPersonaActual);
        }
        public bool ExisteUsuarioPorIdPersona(int idPersona)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ExisteUsuarioPorIdPersona(idPersona);
        }
        public int ObtenerIdRolPorPersona(int idPersona)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerIdRolPorPersona(idPersona);
        }

        public const int ID_ROL_ADMINISTRADOR = 1;

        // solo un admin asigna o quita el rol Administrador
        public string ValidarRolAsignable(int idRol)
        {
            if (idRol == ID_ROL_ADMINISTRADOR && SesionUsuario.IdRol != ID_ROL_ADMINISTRADOR)
            {
                return "Solo un Administrador puede asignar o quitar el rol Administrador.";
            }

            return string.Empty;
        }

        public string ValidarCambioRolYEstado(int idPersona, int idRolNuevo, bool activoNuevo)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            int idRolActual = datos.ObtenerIdRolPorPersona(idPersona);
            ClsPersona persona = datos.ObtenerPersonaPorId(idPersona);
            bool activoActual = persona != null && persona.Activo;

            if (idPersona == SesionUsuario.IdPersona)
            {
                if (activoActual && !activoNuevo)
                {
                    return "No puede darse de baja a sí mismo.";
                }

                // un admin puede bajarse el rol (si queda otro admin, se valida abajo); el resto no
                if (idRolNuevo != idRolActual && SesionUsuario.IdRol != ID_ROL_ADMINISTRADOR)
                {
                    return "No puede cambiar su propio rol.";
                }
            }

            if (idRolNuevo != idRolActual && (idRolNuevo == ID_ROL_ADMINISTRADOR || idRolActual == ID_ROL_ADMINISTRADOR))
            {
                string motivo = ValidarRolAsignable(ID_ROL_ADMINISTRADOR);

                if (motivo != string.Empty)
                {
                    return motivo;
                }
            }

            bool eraAdministradorActivo = idRolActual == ID_ROL_ADMINISTRADOR && activoActual;
            bool sigueAdministradorActivo = idRolNuevo == ID_ROL_ADMINISTRADOR && activoNuevo;

            if (eraAdministradorActivo && !sigueAdministradorActivo &&
                datos.ContarAdministradoresActivos(ID_ROL_ADMINISTRADOR, idPersona) == 0)
            {
                return "Es el único Administrador activo: el sistema no puede quedar sin administradores.";
            }

            return string.Empty;
        }
    }
}