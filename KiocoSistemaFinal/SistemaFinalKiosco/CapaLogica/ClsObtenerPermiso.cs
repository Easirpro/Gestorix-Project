using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsObtenerPermiso
    {
        public void CargarPermisos()
        {
            ClsRolDatos datos = new ClsRolDatos();

            SesionUsuario.Permisos = datos.ObtenerPermisos(SesionUsuario.IdRol);
        }
    }
}
