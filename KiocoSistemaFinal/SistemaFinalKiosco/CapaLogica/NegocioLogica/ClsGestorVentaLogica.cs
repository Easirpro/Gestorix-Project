using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.NegocioDatos;
using System.Data;

namespace CapaLogica.NegocioLogica
{
    public class ClsGestorVentaLogica
    {
        ClsGestorVentaDatos datos = new ClsGestorVentaDatos();

        public DataTable ObtenerMetodosPago()
        {
            return datos.ObtenerMetodosPago();
        }
    }
}