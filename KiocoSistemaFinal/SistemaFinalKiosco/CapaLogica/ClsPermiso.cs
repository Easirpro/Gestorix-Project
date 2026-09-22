using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsPermiso
    {
        ClsPermisoDatos permisoDatos = new ClsPermisoDatos();

        public DataTable ObtenerPermisos()
        {
            return permisoDatos.ObtenerPermisos();
        }
    }
}
