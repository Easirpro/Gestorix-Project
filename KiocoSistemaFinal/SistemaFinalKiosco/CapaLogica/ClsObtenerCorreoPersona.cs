using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsObtenerCorreoPersona
    {
        clsCorreoDatos datos = new clsCorreoDatos();

        public string ObtenerCorreoPorPersona(int idPersona)
        {
            return datos.ObtenerCorreoPorPersona(idPersona);
        }

    }
}
