using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsGenero
    {
        public DataTable CargarGeneros()
        {
            ClsGeneroDatos datos = new ClsGeneroDatos();

            return datos.CargarGeneros();
        }
    }
}
