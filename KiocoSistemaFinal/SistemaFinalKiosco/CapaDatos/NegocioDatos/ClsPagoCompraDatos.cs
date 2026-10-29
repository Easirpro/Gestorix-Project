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
    public class ClsPagoCompraDatos
    {
        private Conexion cn = new Conexion();

        // idProveedor null = todos los proveedores.
        // incluirPagadas = true muestra también las compras con saldo 0.
        public DataTable ObtenerComprasPendientes(int? idProveedor, bool incluirPagadas)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerComprasPendientes", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor",
                        idProveedor.HasValue ? (object)idProveedor.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IncluirPagadas", incluirPagadas);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        public DataTable ObtenerPagosCompra(int idCompra)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerPagosCompra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCompra", idCompra);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        // Registra el pago y completa en la entidad el Id y el saldo que queda.
        public ClsPagoCompraEntidad RegistrarPago(ClsPagoCompraEntidad pago)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_RegistrarPagoCompra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCompra", pago.IdCompra);
                    cmd.Parameters.AddWithValue("@IdMetodoPago", pago.IdMetodoPago);
                    cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                    cmd.Parameters.AddWithValue("@IdUsuario", pago.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdSesionCaja",
                        pago.IdSesionCaja.HasValue ? (object)pago.IdSesionCaja.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Observacion",
                        string.IsNullOrWhiteSpace(pago.Observacion) ? (object)DBNull.Value : pago.Observacion);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            pago.IdPagoCompra = Convert.ToInt32(lector["IdPagoCompra"]);
                            pago.SaldoRestante = Convert.ToDecimal(lector["SaldoRestante"]);
                        }
                    }

                    return pago;
                }
            }
        }

        public void AnularPago(int idPagoCompra, string motivo, int idUsuario)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_AnularPagoCompra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPagoCompra", idPagoCompra);
                    cmd.Parameters.AddWithValue("@Motivo", motivo);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
