using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsModificarTelefono
    {
        ClsModificarTelefonoPer datos = new ClsModificarTelefonoPer();

        public bool ModificarTelefono(ClsTelefono telefono)
        {
            return datos.ModificarTelefonoPer(telefono);
        }
    }
}
