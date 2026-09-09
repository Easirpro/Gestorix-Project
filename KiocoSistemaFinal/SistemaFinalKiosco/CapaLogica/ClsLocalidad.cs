using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsLocalidad
    {
        public DataTable CargarLocalidades(int idPartido)
        {
            ClsLocalidadDatos datos = new ClsLocalidadDatos();

            return datos.CargarLocalidades(idPartido);
        }
    }
}
