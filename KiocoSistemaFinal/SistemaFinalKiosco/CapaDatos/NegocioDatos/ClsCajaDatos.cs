using CapaEntidades.NegocioEntidad;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.NegocioDatos
{
    public class ClsCajaDatos
    {
        private Conexion cn = new Conexion();

        public ClsSesionCajaEntidad ObtenerSesionAbierta(int idCaja)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerSesionCajaAbierta", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCaja", idCaja);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (!lector.Read())
                        {
                            return null;
                        }

                        ClsSesionCajaEntidad sesion = new ClsSesionCajaEntidad();
                        sesion.IdSesionCaja = Convert.ToInt32(lector["IdSesionCaja"]);
                        sesion.IdCaja = Convert.ToInt32(lector["IdCaja"]);
                        sesion.FechaApertura = Convert.ToDateTime(lector["FechaApertura"]);
                        sesion.IdUsuarioApertura = Convert.ToInt32(lector["IdUsuarioApertura"]);
                        sesion.UsuarioApertura = lector["UsuarioApertura"].ToString();
                        sesion.MontoInicial = Convert.ToDecimal(lector["MontoInicial"]);
                        sesion.IngresosEfectivo = Convert.ToDecimal(lector["IngresosEfectivo"]);
                        sesion.EgresosEfectivo = Convert.ToDecimal(lector["EgresosEfectivo"]);
                        sesion.EfectivoEsperado = Convert.ToDecimal(lector["EfectivoEsperado"]);
                        sesion.IngresosOtrosMedios = Convert.ToDecimal(lector["IngresosOtrosMedios"]);
                        return sesion;
                    }
                }
            }
        }

        public int AbrirCaja(int idCaja, int idUsuario, decimal montoInicial)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_AbrirCaja", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCaja", idCaja);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@MontoInicial", montoInicial);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public DataTable ObtenerConceptos(string tipo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerConceptosCaja", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo",
                        string.IsNullOrWhiteSpace(tipo) ? (object)DBNull.Value : tipo);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        public int RegistrarMovimiento(ClsMovimientoCajaEntidad movimiento)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_RegistrarMovimientoCaja", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSesionCaja", movimiento.IdSesionCaja);
                    cmd.Parameters.AddWithValue("@IdConceptoCaja", movimiento.IdConceptoCaja);
                    cmd.Parameters.AddWithValue("@IdMetodoPago", movimiento.IdMetodoPago);
                    cmd.Parameters.AddWithValue("@Importe", movimiento.Importe);
                    cmd.Parameters.AddWithValue("@Observacion", movimiento.Observacion);
                    cmd.Parameters.AddWithValue("@IdUsuario", movimiento.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdEmpleado",
                        movimiento.IdEmpleado.HasValue ? (object)movimiento.IdEmpleado.Value : DBNull.Value);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void AnularMovimiento(int idMovimientoCaja, string motivo, int idUsuario)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_AnularMovimientoCaja", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMovimientoCaja", idMovimientoCaja);
                    cmd.Parameters.AddWithValue("@Motivo", motivo);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClsCierreCajaEntidad CerrarCaja(ClsCierreCajaEntidad cierre)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_CerrarCaja", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSesionCaja", cierre.IdSesionCaja);
                    cmd.Parameters.AddWithValue("@IdUsuario", cierre.IdUsuario);
                    cmd.Parameters.AddWithValue("@EfectivoContado", cierre.EfectivoContado);
                    cmd.Parameters.AddWithValue("@Observacion",
                        string.IsNullOrWhiteSpace(cierre.Observacion) ? (object)DBNull.Value : cierre.Observacion);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            cierre.EfectivoEsperado = Convert.ToDecimal(lector["EfectivoEsperado"]);
                            cierre.EfectivoContado = Convert.ToDecimal(lector["EfectivoContado"]);
                            cierre.Diferencia = Convert.ToDecimal(lector["Diferencia"]);
                        }
                    }

                    return cierre;
                }
            }
        }

        public DataTable ObtenerMovimientosSesion(int idSesionCaja)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerMovimientosSesionCaja", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSesionCaja", idSesionCaja);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        public DataTable ObtenerSesiones(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerSesionesCaja", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        // todos los usuarios para el filtro del balance; DeBaja marca a los que ya no estan activos
        public DataTable ObtenerUsuariosParaFiltro()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT u.IdUsuario,
                       CONCAT(p.Apellido, N', ', p.Nombre) AS Empleado,
                       CAST(CASE WHEN u.Estado = 1 AND p.Activo = 1 THEN 0 ELSE 1 END AS BIT) AS DeBaja
                FROM dbo.Usuario AS u
                INNER JOIN dbo.Persona AS p ON p.IdPersona = u.IdPersona
                ORDER BY DeBaja, p.Apellido, p.Nombre;", conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }
        // empleados para vales y sueldos: la baja marca la persona, por eso se filtra tambien por Persona.Activo
        public DataTable ObtenerEmpleadosActivos()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT u.IdUsuario,
                       CONCAT(p.Apellido, N', ', p.Nombre) AS Empleado,
                       u.Username
                FROM dbo.Usuario AS u
                INNER JOIN dbo.Persona AS p ON p.IdPersona = u.IdPersona
                WHERE u.Estado = 1
                  AND p.Activo = 1
                ORDER BY p.Apellido, p.Nombre;", conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        public DataTable ObtenerMetodosPago()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerMetodosPago", conexion))
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
        }
    }
}
