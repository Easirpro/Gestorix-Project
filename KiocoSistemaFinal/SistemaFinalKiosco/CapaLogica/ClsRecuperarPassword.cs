using CapaSesion;

namespace CapaLogica
{
    public class ClsRecuperarPassword
    {
        public ResultadoCambioPassword CambiarPassword(int idUsuario, string nuevaPass, string confirmarPass)
        {
            if (nuevaPass != confirmarPass)
                return ResultadoCambioPassword.PasswordNoCoinciden;

            if (!ClsReglasPassword.CumpleRequisitos(nuevaPass))
                return ResultadoCambioPassword.PasswordNoCumpleRequisitos;

            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            string username = datos.ObtenerUsername(idUsuario);
            string hashNueva = ClsSeguridad.SHA256(username + nuevaPass);

            if (datos.EsPasswordActual(idUsuario, hashNueva))
                return ResultadoCambioPassword.PasswordIgualAnterior;

            if (datos.PasswordUsadaUltimasTres(idUsuario, hashNueva))
                return ResultadoCambioPassword.PasswordUsadaRecientemente;

            if (!datos.CambiarPasswordRecuperacion(idUsuario, hashNueva))
                return ResultadoCambioPassword.PasswordTemporalIncorrecta;

            ClsRegistroSeguridad.Registrar(idUsuario, "RECUPERO_PASSWORD",
                "Cambio de contraseña con la pregunta de seguridad.");

            return ResultadoCambioPassword.Correcto;
        }
    }
}
