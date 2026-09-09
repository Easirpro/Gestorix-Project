using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;


namespace CapaDatos.NegocioDatos
{
    public class ClsGestorProveedorDatos
    {
        Conexion cn = new Conexion();
        public int RegistrarProveedor(ClsProveedor proveedor)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Proveedor
                    (
                        Nombre,
                        CUIT,
                        Activo
                    )
                    VALUES
                    (
                        @Nombre,
                        @CUIT,
                        @Activo
                    );

                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
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
        }
        public int RegistrarSucursalProveedor(ClsSucursalProveedor sucursal)
        { 
            using (SqlConnection conexion = cn.ObtenerConexion()) 
            { 
                string consulta = @" 
                    INSERT INTO SucursalProveedor 
                    (
                        IdProveedor,
                        Nombre,
                        Activo,
                        IdDireccion,
                        [CondiciónIVA],
                        Observacion
                    )
                    VALUES
                    ( 
                        @IdProveedor,
                        @Nombre,
                        @Activo,
                        @IdDireccion,
                        @CondicionIVA,
                        @Observacion
                    ); 
                    SELECT SCOPE_IDENTITY();"; 

                using (SqlCommand cmd = new SqlCommand(consulta, conexion)) 
                { 
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
        }
        public int RegistrarDireccion(ClsDireccion direccion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Direccion
                    (
                        Calle,
                        Altura,
                        Piso,
                        Departamento,
                        IdLocalidad
                    )
                    VALUES
                    (
                        @Calle,
                        @Altura,
                        @Piso,
                        @Departamento,
                        @IdLocalidad
                    );

                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
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
        }
        public int RegistrarTelefono(ClsTelefono telefono)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Telefono
                    (
                        NumTelefono,
                        IdTipo
                    )
                    VALUES
                    (
                        @NumTelefono,
                        @IdTipo
                    );

                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@NumTelefono", telefono.NumTelefono);
                    cmd.Parameters.AddWithValue("@IdTipo", telefono.IdTipo);

                    conexion.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public void RegistrarSucursalProveedorTelefono(ClsSucursalProveedorTelefono telefonoSucursal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO SucursalProveedorTelefono
                    (
                        IdSucursal,
                        IdTelefono,
                        Activo,
                        NombreTelefono,
                        DescripciónTelefono
                    )
                    VALUES
                    (
                        @IdSucursal,
                        @IdTelefono,
                        @Activo,
                        @NombreTelefono,
                        @DescripcionTelefono
                    );";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
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
        }
        public int RegistrarCorreo(ClsCorreo correo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Correo
                    (
                        Correo
                    )
                    VALUES
                    (
                        @Correo
                    );

                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo.Correo);

                    conexion.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public void RegistrarSucursalProveedorCorreo(ClsSucursalProveedorCorreo correoSucursal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO SucursalProveedorCorreo
                    (
                        IdCorreo,
                        IdSucursal,
                        Activo,
                        TipoCorreo,
                        DescripciónCorreo
                    )
                    VALUES
                    (
                        @IdCorreo,
                        @IdSucursal,
                        @Activo,
                        @TipoCorreo,
                        @DescripcionCorreo
                    );";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
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
        }
        public DataTable ObtenerLocalidades()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdLocalidad,
                        NomLocalidad
                    FROM Localidad
                    ORDER BY NomLocalidad;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public DataTable ObtenerTiposTelefono()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdTipo,
                        Tipo
                    FROM TipoTelefono
                    ORDER BY Tipo;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }
        public DataTable ObtenerProveedores()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        p.IdProveedor,
                        p.Nombre AS RazonSocial,
                        p.CUIT,
                        sp.[CondiciónIVA],
                        t.NumTelefono,
                        c.Correo,
                        CONCAT(
                        d.Calle, ' ',
                        ISNULL(CAST(d.Altura AS VARCHAR(10)), ''),
                        CASE 
                            WHEN d.Piso IS NOT NULL AND d.Piso <> '' 
                            THEN ' Piso ' + d.Piso 
                            ELSE '' 
                            END,
                        CASE 
                            WHEN d.Departamento IS NOT NULL AND d.Departamento <> '' 
                            THEN ' Depto. ' + d.Departamento 
                            ELSE '' 
                            END
                        ) 
                        AS Direccion,
                        CASE 
                            WHEN p.Activo = 1 THEN 'Activo'
                            ELSE 'Inactivo'
                        END AS Estado,
                        sp.Observacion
                    FROM Proveedor p
                    INNER JOIN SucursalProveedor sp 
                        ON p.IdProveedor = sp.IdProveedor
                    INNER JOIN Direccion d 
                        ON sp.IdDireccion = d.IdDireccion
                    LEFT JOIN SucursalProveedorTelefono spt 
                        ON sp.IdSucursal = spt.IdSucursal
                        AND spt.Activo = 1
                    LEFT JOIN Telefono t 
                        ON spt.IdTelefono = t.IdTelefono
                    LEFT JOIN SucursalProveedorCorreo spc 
                        ON sp.IdSucursal = spc.IdSucursal
                        AND spc.Activo = 1
                    LEFT JOIN Correo c 
                        ON spc.IdCorreo = c.IdCorreo
                    ORDER BY p.IdProveedor;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
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

}
