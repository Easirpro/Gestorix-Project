using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsObtenerProvinciaPer
    {
        public ClsTraeProvincia ObtenerProvincia(int idProvincia)
        {
            ClsObtenerProvincia datos = new ClsObtenerProvincia();

            return datos.ObtenerProvincia( idProvincia);
        }
    }
}
