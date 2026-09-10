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


    }
}