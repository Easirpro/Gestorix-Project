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
    public class ClsDevolucionDatos
    {
        private Conexion cn = new Conexion();

        public DataTable ObtenerDevoluciones(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerDevoluciones", conexion))
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

        // idVenta null = todas las ventas del período.
        public DataTable ObtenerVentasParaDevolucion(DateTime desde, DateTime hasta, int? idVenta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerVentasParaDevolucion", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date);
                    cmd.Parameters.AddWithValue("@IdVenta",
                        idVenta.HasValue ? (object)idVenta.Value : DBNull.Value);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        public DataTable ObtenerDetalleParaDevolucion(int idVenta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerDetalleParaDevolucion", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        // Registra la devolución y completa en la entidad el Id y el importe devuelto.
        public ClsDevolucionEntidad RegistrarDevolucion(ClsDevolucionEntidad devolucion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_RegistrarDevolucion", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdVenta", devolucion.IdVenta);
                    cmd.Parameters.AddWithValue("@IdProducto", devolucion.IdProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", devolucion.Cantidad);
                    cmd.Parameters.AddWithValue("@Motivo", devolucion.Motivo);
                    cmd.Parameters.AddWithValue("@TipoReintegro", devolucion.ReintegroEfectivo);
                    cmd.Parameters.AddWithValue("@ReingresaStock", devolucion.ReingresaStock);
                    cmd.Parameters.AddWithValue("@IdUsuario", devolucion.IdUsuario);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            devolucion.IdDevolucion = Convert.ToInt32(lector["IdDevolucion"]);
                            devolucion.ImporteDevuelto = Convert.ToDecimal(lector["ImporteDevuelto"]);
                        }
                    }

                    return devolucion;
                }
            }
        }
    }
}
