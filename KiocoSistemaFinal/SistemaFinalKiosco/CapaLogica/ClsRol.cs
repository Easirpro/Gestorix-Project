using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
   
    public class ClsRol
    {
        public DataTable ObtenerRoles()
        {
            ClsRolDatos datos = new ClsRolDatos();

            return datos.ObtenerRoles();
        }

        public List<int> ObtenerPermisos(int idRol)
        {
            ClsRolDatos datos = new ClsRolDatos();

            return datos.ObtenerPermisos(idRol);
        }
        public string ObtenerNombreRol(int idRol)
        {
            ClsRolDatos datos = new ClsRolDatos();

            return datos.ObtenerNombreRol(idRol);
        }
    }
}

