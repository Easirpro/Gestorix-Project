using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsModificarCorreo
    {
        ClsModificarCorreoPer datos =
        new ClsModificarCorreoPer();

        public bool ModificarCorreo(ClsCorreo correo)
        {
            return datos.ModificarCorreoPer(correo);
        }
    }
}
