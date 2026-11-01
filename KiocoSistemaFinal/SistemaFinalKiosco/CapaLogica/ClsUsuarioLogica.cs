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

        // Controla un cambio de rol o de estado antes de guardarlo. Devuelve el motivo si no se
        // puede hacer, o una cadena vacía si se puede:
        // - nadie puede darse de baja ni cambiarse el rol a sí mismo;
        // - siempre tiene que quedar al menos un Administrador activo.
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

                if (idRolNuevo != idRolActual)
                {
                    return "No puede cambiar su propio rol.";
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