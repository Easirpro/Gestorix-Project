using CapaDatos;
using CapaEntidades;
using CapaLogica.BitacoraLogi;
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
        public int ContarUsuariosPorRol(int idRol, bool soloActivos = true)
        {
            ClsRolDatos datos = new ClsRolDatos();

            return datos.ContarUsuariosPorRol(idRol, soloActivos);
        }
        public string ObtenerNombreRol(int idRol)
        {
            ClsRolDatos datos = new ClsRolDatos();

            return datos.ObtenerNombreRol(idRol);
        }
        // un no-admin no puede tocar los permisos de su propio rol
        public bool PuedeEditarPermisosDelRol(int idRol)
        {
            return SesionUsuario.IdRol == ClsUsuarioLogica.ID_ROL_ADMINISTRADOR || idRol != SesionUsuario.IdRol;
        }
        public void GuardarPermisos(int idRol, List<int> permisos)
        {
            if (!PuedeEditarPermisosDelRol(idRol))
            {
                throw new InvalidOperationException("No podés modificar los permisos de tu propio rol.");
            }

            ClsRolDatos datos = new ClsRolDatos();

            List<int> anteriores = datos.ObtenerPermisos(idRol);

            datos.GuardarPermisos(idRol, permisos);

            List<int> agregados = permisos.Except(anteriores).ToList();
            List<int> quitados = anteriores.Except(permisos).ToList();

            if (agregados.Count == 0 && quitados.Count == 0)
            {
                return;
            }

            string descripcion = "Permisos del rol " + datos.ObtenerNombreRol(idRol) + "." +
                (agregados.Count > 0 ? " Agregados: " + Codigos(agregados) + "." : "") +
                (quitados.Count > 0 ? " Quitados: " + Codigos(quitados) + "." : "");

            RegistrarBitacora("MODIFICAR", "RolPermiso", idRol, descripcion);
        }
        public int CrearRol(string nombre)
        {
            ClsRolDatos datos = new ClsRolDatos();

            int idRol = datos.CrearRol(nombre);

            if (idRol > 0)
            {
                RegistrarBitacora("CREAR", "Rol", idRol, "Alta de rol: " + nombre);
            }

            return idRol;
        }
        public void EliminarRol(int idRol)
        {
            ClsRolDatos datos = new ClsRolDatos();

            int asignados = datos.ContarUsuariosPorRol(idRol, soloActivos: false);

            if (asignados > 0)
            {
                throw new InvalidOperationException("El rol tiene " + asignados + " empleado(s) asignado(s). Reasignalos a otro rol antes de eliminarlo.");
            }

            string nombre = datos.ObtenerNombreRol(idRol);

            datos.EliminarRol(idRol);

            RegistrarBitacora("ELIMINAR", "Rol", idRol, "Eliminación del rol: " + nombre);
        }

        private static string Codigos(List<int> idsPermiso)
        {
            DataTable dt = new ClsPermiso().ObtenerPermisos();

            return string.Join(", ", idsPermiso.OrderBy(id => id).Select(id =>
            {
                DataRow[] filas = dt.Select("IdPermiso = " + id);
                return filas.Length > 0 ? filas[0]["CodigoPermiso"].ToString() : id.ToString();
            }));
        }
        private static void RegistrarBitacora(string accion, string tabla, int idRegistro, string descripcion)
        {
            if (descripcion.Length > 255)
            {
                descripcion = descripcion.Substring(0, 252) + "...";
            }

            new clsBitacoraLogica().RegistrarBitacora(SesionUsuario.IdUsuario > 0 ? SesionUsuario.IdUsuario : (int?)null,
                accion, tabla, idRegistro, descripcion);
        }
    }
}
