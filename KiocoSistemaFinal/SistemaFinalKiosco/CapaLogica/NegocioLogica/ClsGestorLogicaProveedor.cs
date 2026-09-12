using CapaDatos.NegocioDatos;
using CapaEntidades.NegocioEntidad;
using System.Data;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaLogica.NegocioLogica
{
    public class ClsGestorLogicaProveedor
    {
        ClsGestorProveedorDatos datos = new ClsGestorProveedorDatos();

        public int RegistrarProveedor(ClsProveedor proveedor)
        {
            return datos.RegistrarProveedor(proveedor);
        }
        public int RegistrarSucursalProveedor(ClsSucursalProveedor sucursal)
        {
            return datos.RegistrarSucursalProveedor(sucursal);
        }
        public int RegistrarDireccion(ClsDireccion direccion)
        {
            return datos.RegistrarDireccion(direccion);
        }
        public int RegistrarTelefono(ClsTelefono telefono)
        {
            return datos.RegistrarTelefono(telefono);
        }
        public void RegistrarSucursalProveedorTelefono(ClsSucursalProveedorTelefono telefonoSucursal)
        {
            datos.RegistrarSucursalProveedorTelefono(telefonoSucursal);
        }
        public int RegistrarCorreo(ClsCorreo correo)
        {
            return datos.RegistrarCorreo(correo);
        }
        public void RegistrarSucursalProveedorCorreo(ClsSucursalProveedorCorreo correoSucursal)
        {
            datos.RegistrarSucursalProveedorCorreo(correoSucursal);
        }
        public DataTable ObtenerLocalidades()
        {
            return datos.ObtenerLocalidades();
        }
        public DataTable ObtenerTiposTelefono()
        {
            return datos.ObtenerTiposTelefono();
        }
        public DataTable ObtenerProveedores()
        {
            return datos.ObtenerProveedores();
        }
        public DataTable ObtenerProveedorPorId(int idProveedor)
        {
            return datos.ObtenerProveedorPorId(idProveedor);
        }
        public void DescontinuarProveedor(int idProveedor)
        {
            datos.DescontinuarProveedor(idProveedor);

        }
        public void ActivarProveedor(int idProveedor)
        {
            datos.ActivarProveedor(idProveedor);
        }
        public void ModificarProveedor (ClsProveedor proveedor)
        {
            datos.ModificarProveedor(proveedor);
        }
        public void ModificarDireccion(ClsDireccion direccion)
        {
            datos.ModificarDireccion(direccion);
        }
        public void ModificarSucursalProveedor(ClsSucursalProveedor sucursal)
        {
            datos.ModificarSucursalProveedor(sucursal);
        }
        public void ModificarTelefono(ClsTelefono telefono)
        {
            datos.ModificarTelefono(telefono);
        }
        public void ModificarCorreo(ClsCorreo correo)
        {
            datos.ModificarCorreo(correo);
        }

    }
}