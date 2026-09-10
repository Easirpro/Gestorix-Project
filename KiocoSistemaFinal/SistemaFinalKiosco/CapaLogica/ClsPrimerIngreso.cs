using CapaEntidades;
using CapaSesion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CapaLogica
{
    public class ClsPrimerIngreso
    {
        public ResultadoCambioPassword CambiarPassword( string passTemporal, string nuevaPass, string confirmarPass)
        {
            if (nuevaPass != confirmarPass)
                return ResultadoCambioPassword.PasswordNoCoinciden;

            if (!Regex.IsMatch(nuevaPass, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                return ResultadoCambioPassword.PasswordNoCumpleRequisitos;

            if (passTemporal == nuevaPass)
                return ResultadoCambioPassword.PasswordIgualAnterior;

            string hashTemporal = ClsSeguridad.SHA256(SesionUsuario.Username + passTemporal);

            string hashNueva = ClsSeguridad.SHA256(SesionUsuario.Username + nuevaPass);

            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            bool cambio = datos.CambiarPasswordPrimerIngreso(
                SesionUsuario.IdUsuario,
                hashTemporal,
                hashNueva);

            if (!cambio)
                return ResultadoCambioPassword.PasswordTemporalIncorrecta;

            SesionUsuario.PrimerIngreso = false;
            SesionUsuario.ContadorLogin++;
            SesionUsuario.UltimoIngreso = DateTime.Now;

            return ResultadoCambioPassword.Correcto;
        }
    }
}