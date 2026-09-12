using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsProvincia
    {
        public DataTable CargarProvincias()
        {
            ClsProvinciaDatos datos = new ClsProvinciaDatos();

            return datos.CargarProvincias();
        }
    }
}
