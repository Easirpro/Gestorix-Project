using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class ClsModificarPersona
    {
        ClsModificarPorPersona datos = new ClsModificarPorPersona();

        public bool ModificarPersona(ClsPersona persona, int idRol)
        {
            return datos.ModificarPersona(persona, idRol);
        }
    }
}
