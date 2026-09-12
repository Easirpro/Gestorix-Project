using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsObtenerPartidoPer
    {
        public ClsTraerPartido ObtenerPartido(int idLocalidad)
        {
            ClsObtenerPartido datos = new ClsObtenerPartido();

            return datos.ObtenerPartido(idLocalidad);
        }
    }
}
