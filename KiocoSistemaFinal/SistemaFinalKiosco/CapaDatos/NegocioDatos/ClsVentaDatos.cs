using CapaDatos.SistemaKiosco;
using CapaEntidades.NegocioEntidad;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.NegocioDatos
{
    public class ClsVentaDatos
    {
        Conexion cn = new Conexion();

        public DataTable ObtenerMetodosPago()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
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
        public int RegistrarVenta(decimal total, int idUsuario, string observaciones, List<DetalleVentaEntidad> detalles, List<PagoVentaEntidad> pagos)
        {
            string dvh = GenerarDVHVenta(total, idUsuario);
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = total;
                cmd.Parameters["@Total"].Precision = 18;
                cmd.Parameters["@Total"].Scale = 2;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                cmd.Parameters.AddWithValue("@DVH", dvh);

                SqlParameter parametroObservaciones = cmd.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 1000);

                parametroObservaciones.Value = string.IsNullOrWhiteSpace(observaciones) ? DBNull.Value : observaciones.Trim();

                DataTable tablaDetalles = new DataTable();

                tablaDetalles.Columns.Add("IdProducto", typeof(int));
                tablaDetalles.Columns.Add("Cantidad", typeof(decimal));
                tablaDetalles.Columns.Add("PrecioUnitario", typeof(decimal));
                tablaDetalles.Columns.Add("Subtotal", typeof(decimal));

                foreach (DetalleVentaEntidad detalle in detalles)
                {
                    tablaDetalles.Rows.Add(
                        detalle.IdProducto,
                        detalle.Cantidad,
                        detalle.PrecioUnitario,
                        detalle.Subtotal);
                }

                SqlParameter parametroDetalles = cmd.Parameters.AddWithValue("@Detalles", tablaDetalles);

                parametroDetalles.SqlDbType = SqlDbType.Structured;
                parametroDetalles.TypeName = "dbo.TipoDetalleVenta";

                DataTable tablaPagos = new DataTable();

                tablaPagos.Columns.Add("IdMetodoPago", typeof(int));
                tablaPagos.Columns.Add("Monto", typeof(decimal));

                foreach (PagoVentaEntidad pago in pagos)
                {
                    tablaPagos.Rows.Add(pago.IdMetodoPago, pago.Monto);
                }

                SqlParameter parametroPagos = cmd.Parameters.AddWithValue("@Pagos", tablaPagos);

                parametroPagos.SqlDbType = SqlDbType.Structured;
                parametroPagos.TypeName = "dbo.TipoPagoVenta";

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public DataTable ObtenerVentas(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerVentas", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Desde", SqlDbType.DateTime).Value = desde;
                cmd.Parameters.Add("@Hasta", SqlDbType.DateTime).Value = hasta;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public void CambiarEstadoVenta(int idVenta, bool anulada, string motivo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_CambiarEstadoVenta", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                cmd.Parameters.Add("@Anulada", SqlDbType.Bit).Value = anulada;

                SqlParameter parametroMotivo =
                    cmd.Parameters.Add("@MotivoAnulacion", SqlDbType.VarChar, 500);

                parametroMotivo.Value = string.IsNullOrWhiteSpace(motivo)
                    ? DBNull.Value
                    : motivo.Trim();

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ActualizarObservaciones(int idVenta, string observaciones)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                  @"UPDATE dbo.Venta
                  SET Observaciones = @Observaciones
                  WHERE IdVenta = @IdVenta", conexion))
            {
                cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;

                cmd.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 1000).Value = string.IsNullOrWhiteSpace(observaciones) ? (object)DBNull.Value : observaciones.Trim();

                conexion.Open();

                int filas = cmd.ExecuteNonQuery();

                if (filas == 0)
                    throw new Exception("No se encontró la venta seleccionada.");
            }
        }
        private string GenerarDVHVenta(decimal total, int idUsuario)
        {
            string cadena = total.ToString() + idUsuario.ToString();

            return ClsDigitoVerificador.GenerarHash(cadena);
        }


    }
}