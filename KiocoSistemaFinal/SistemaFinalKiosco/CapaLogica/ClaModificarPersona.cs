using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using EnviarMail;

namespace CapaLogica
{
    public class ClsModificarPersona
    {
        ClsModificarPorPersona datos = new ClsModificarPorPersona();

        public bool ModificarPersona(ClsPersona persona, int idRol)
        {
            return datos.ModificarPersona(persona, idRol);
        }
        // correoNuevo null = el correo no cambia
        public void ModificarEmpleado(ClsPersona persona, int idRol, ClsDomicilio domicilio, ClsTelefono telefono, string correoNuevo)
        {
            datos.ModificarEmpleado(persona, idRol, domicilio, telefono, correoNuevo);

            if (correoNuevo == null)
            {
                return;
            }

            // el aviso no debe deshacer lo ya guardado
            try
            {
                MailHelper.Enviar(correoNuevo, "Actualización de correo - Gestorix",
                    @"<h2>Gestorix</h2>
                    <p>Su correo electrónico fue actualizado correctamente.</p>
                    <p>A partir de ahora recibirá las comunicaciones en este correo.</p>");
            }
            catch
            {
            }
        }
    }
}
