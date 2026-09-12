using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsPartido
    {
        public DataTable CargarPartidos(int idProvincia)
        {
            ClsPartidoDatos datos = new ClsPartidoDatos();

            return datos.CargarPartidos(idProvincia);
        }
    }
}
