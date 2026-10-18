using CapaEntidades.NegocioEntidad;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Data;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaDatos.NegocioDatos
{
    public class ClsGestorProveedorDatos
    {
        Conexion cn = new Conexion();

        public int RegistrarProveedor(ClsProveedor proveedor)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);

                if (string.IsNullOrWhiteSpace(proveedor.CUIT))
                {
                    cmd.Parameters.AddWithValue("@CUIT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CUIT", proveedor.CUIT);
                }

                cmd.Parameters.AddWithValue("@Activo", proveedor.Activo);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int RegistrarSucursalProveedor(ClsSucursalProveedor sucursal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarSucursalProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdProveedor", sucursal.IdProveedor);
                cmd.Parameters.AddWithValue("@Nombre", sucursal.Nombre);
                cmd.Parameters.AddWithValue("@Activo", sucursal.Activo);
                cmd.Parameters.AddWithValue("@IdDireccion", sucursal.IdDireccion);
                cmd.Parameters.AddWithValue("@CondicionIVA", sucursal.CondicionIVA);

                if (string.IsNullOrWhiteSpace(sucursal.Observacion))
                {
                    cmd.Parameters.AddWithValue("@Observacion", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Observacion", sucursal.Observacion);
                }

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void ModificarSucursalProveedor(ClsSucursalProveedor sucursal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ModificarSucursalProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdSucursal", sucursal.IdSucursal);
                cmd.Parameters.AddWithValue("@Nombre", sucursal.Nombre);
                cmd.Parameters.AddWithValue("@IdDireccion", sucursal.IdDireccion);
                cmd.Parameters.AddWithValue("@CondicionIVA", sucursal.CondicionIVA);

                if (string.IsNullOrWhiteSpace(sucursal.Observacion))
                {
                    cmd.Parameters.AddWithValue("@Observacion", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Observacion", sucursal.Observacion);
                }

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public int RegistrarDireccion(ClsDireccion direccion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarDireccion", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Calle", direccion.Calle);

                if (direccion.Altura.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Altura", direccion.Altura.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Altura", DBNull.Value);
                }

                if (string.IsNullOrWhiteSpace(direccion.Piso))
                {
                    cmd.Parameters.AddWithValue("@Piso", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Piso", direccion.Piso);
                }

                if (string.IsNullOrWhiteSpace(direccion.Departamento))
                {
                    cmd.Parameters.AddWithValue("@Departamento", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Departamento", direccion.Departamento);
                }

                cmd.Parameters.AddWithValue("@IdLocalidad", direccion.IdLocalidad);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void ModificarDireccion(ClsDireccion direccion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ModificarDireccion", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDireccion", direccion.IdDireccion);
                cmd.Parameters.AddWithValue("@Calle", direccion.Calle);

                if (direccion.Altura.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Altura", direccion.Altura.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Altura", DBNull.Value);
                }

                if (string.IsNullOrWhiteSpace(direccion.Piso))
                {
                    cmd.Parameters.AddWithValue("@Piso", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Piso", direccion.Piso);
                }

                if (string.IsNullOrWhiteSpace(direccion.Departamento))
                {
                    cmd.Parameters.AddWithValue("@Departamento", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Departamento", direccion.Departamento);
                }

                cmd.Parameters.AddWithValue("@IdLocalidad", direccion.IdLocalidad);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public int RegistrarTelefono(ClsTelefono telefono)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarTelefono", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NumTelefono", telefono.NumTelefono);
                cmd.Parameters.AddWithValue("@IdTipo", telefono.IdTipo);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void ModificarTelefono(ClsTelefono telefono)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ModificarTelefono", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdTelefono", telefono.IdTelefono);
                cmd.Parameters.AddWithValue("@NumTelefono", telefono.NumTelefono);
                cmd.Parameters.AddWithValue("@IdTipo", telefono.IdTipo);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void RegistrarSucursalProveedorTelefono(ClsSucursalProveedorTelefono telefonoSucursal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarSucursalProveedorTelefono", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdSucursal", telefonoSucursal.IdSucursal);
                cmd.Parameters.AddWithValue("@IdTelefono", telefonoSucursal.IdTelefono);
                cmd.Parameters.AddWithValue("@Activo", telefonoSucursal.Activo);

                if (string.IsNullOrWhiteSpace(telefonoSucursal.NombreTelefono))
                {
                    cmd.Parameters.AddWithValue("@NombreTelefono", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@NombreTelefono", telefonoSucursal.NombreTelefono);
                }

                if (string.IsNullOrWhiteSpace(telefonoSucursal.DescripcionTelefono))
                {
                    cmd.Parameters.AddWithValue("@DescripcionTelefono", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DescripcionTelefono", telefonoSucursal.DescripcionTelefono);
                }

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public int RegistrarCorreo(ClsCorreo correo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarCorreo", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", correo.Correo);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void ModificarCorreo(ClsCorreo correo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ModificarCorreo", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCorreo", correo.IdCorreo);
                cmd.Parameters.AddWithValue("@Correo", correo.Correo);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void RegistrarSucursalProveedorCorreo(ClsSucursalProveedorCorreo correoSucursal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarSucursalProveedorCorreo", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCorreo", correoSucursal.IdCorreo);
                cmd.Parameters.AddWithValue("@IdSucursal", correoSucursal.IdSucursal);
                cmd.Parameters.AddWithValue("@Activo", correoSucursal.Activo);

                if (string.IsNullOrWhiteSpace(correoSucursal.TipoCorreo))
                {
                    cmd.Parameters.AddWithValue("@TipoCorreo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TipoCorreo", correoSucursal.TipoCorreo);
                }

                if (string.IsNullOrWhiteSpace(correoSucursal.DescripcionCorreo))
                {
                    cmd.Parameters.AddWithValue("@DescripcionCorreo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DescripcionCorreo", correoSucursal.DescripcionCorreo);
                }

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ObtenerLocalidades()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerLocalidades", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }
        public DataTable ObtenerTiposTelefono()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerTiposTelefono", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }
        public DataTable ObtenerProveedores()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerProveedores", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }
        public DataTable ObtenerSucursalesPorProveedor(int idProveedor)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerSucursalesPorProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }
        public DataTable ObtenerProveedorPorId(int idProveedor)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerProveedorPorId", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }
        public void DescontinuarProveedor(int idProveedor)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_DescontinuarProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void ActivarProveedor(int idProveedor)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ActivarProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void ModificarProveedor(ClsProveedor proveedor)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);

                if (string.IsNullOrWhiteSpace(proveedor.CUIT))
                {
                    cmd.Parameters.AddWithValue("@CUIT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CUIT", proveedor.CUIT);
                }

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public DataTable BuscarProveedor(string texto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_BuscarProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Texto", texto);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }
    }
}