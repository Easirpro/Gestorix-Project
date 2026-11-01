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
        public int ContarUsuariosPorRol(int idRol)
        {
            ClsRolDatos datos = new ClsRolDatos();

            return datos.ContarUsuariosPorRol(idRol);
        }
        public string ObtenerNombreRol(int idRol)
        {
            ClsRolDatos datos = new ClsRolDatos();

            return datos.ObtenerNombreRol(idRol);
        }
        public void GuardarPermisos(int idRol, List<int> permisos)
        {
            ClsRolDatos datos = new ClsRolDatos();

            datos.GuardarPermisos(idRol, permisos);
        }
        public int CrearRol(string nombre)
        {
            ClsRolDatos datos = new ClsRolDatos();

            return datos.CrearRol(nombre);
        }
        public void EliminarRol(int idRol)
        {
            ClsRolDatos datos = new ClsRolDatos();

            datos.EliminarRol(idRol);
        }
    }
}

