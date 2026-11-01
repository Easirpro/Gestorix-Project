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
    public class ClsGestorVentaDatos
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
        public int RegistrarVenta(decimal total, int idUsuario, string observaciones, List<DetalleVentaEntidad> detalles, List<PagoVentaEntidad> pagos,
                                  List<ClsPromocionVentaEntidad> promociones = null)   // [PROMO] opcional
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

                // [PROMO] Promociones aplicadas (si no hay, no se envía el parámetro)
                ClsPromocionVentaDatos.AgregarParametroPromociones(cmd, promociones);

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
        // Listado de ventas con los datos reales (sp_ObtenerVentas devuelve el cajero y los pagos vacíos):
        // cajero, caja, cantidad de artículos y medios de pago de cada venta.
        public DataTable ObtenerVentasListado(DateTime desde, DateTime hasta)
        {
            string query = @"
                SELECT
                    v.IdVenta,
                    v.FechaHora,
                    ISNULL(u.Username, '') AS Cajero,
                    v.IdSesionCaja,
                    v.Total,
                    v.Anulada,
                    v.Observaciones,
                    v.MotivoAnulacion,
                    ISNULL((SELECT SUM(d.Cantidad) FROM dbo.DetalleVenta AS d WHERE d.IdVenta = v.IdVenta), 0) AS Articulos,
                    ISNULL(
                        (SELECT STRING_AGG(mp.Nombre, ', ')
                         FROM dbo.VentaPago AS vp
                         INNER JOIN dbo.MetodoPago AS mp ON mp.IdMetodoPago = vp.IdMetodoPago
                         WHERE vp.IdVenta = v.IdVenta),
                        mpv.Nombre) AS MediosPago
                FROM dbo.Venta AS v
                LEFT JOIN dbo.Usuario AS u ON u.IdUsuario = v.IdUsuario
                LEFT JOIN dbo.MetodoPago AS mpv ON mpv.IdMetodoPago = v.IdMetodoPago
                WHERE v.FechaHora >= @Desde
                  AND v.FechaHora < DATEADD(DAY, 1, @Hasta)
                ORDER BY v.FechaHora DESC;";

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.Add("@Desde", SqlDbType.Date).Value = desde.Date;
                cmd.Parameters.Add("@Hasta", SqlDbType.Date).Value = hasta.Date;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        // Productos vendidos en una venta.
        public DataTable ObtenerProductosVenta(int idVenta)
        {
            string query = @"
                SELECT
                    p.CodigoBarra,
                    p.Nombre AS Producto,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.Subtotal
                FROM dbo.DetalleVenta AS d
                INNER JOIN dbo.Producto AS p ON p.IdProducto = d.IdProducto
                WHERE d.IdVenta = @IdVenta
                ORDER BY d.IdDetalleVenta;";

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        // Cómo se pagó una venta. Las ventas viejas sin VentaPago usan el medio guardado en la venta.
        public DataTable ObtenerPagosVenta(int idVenta)
        {
            string query = @"
                SELECT mp.Nombre AS Medio, vp.Monto
                FROM dbo.VentaPago AS vp
                INNER JOIN dbo.MetodoPago AS mp ON mp.IdMetodoPago = vp.IdMetodoPago
                WHERE vp.IdVenta = @IdVenta

                UNION ALL

                SELECT mp.Nombre, v.Total
                FROM dbo.Venta AS v
                INNER JOIN dbo.MetodoPago AS mp ON mp.IdMetodoPago = v.IdMetodoPago
                WHERE v.IdVenta = @IdVenta
                  AND NOT EXISTS (SELECT 1 FROM dbo.VentaPago AS vp WHERE vp.IdVenta = v.IdVenta);";

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        // idUsuario: quién anula o reactiva (para el movimiento de stock). Solo se envía si el
        // procedimiento ya tiene el parámetro @IdUsuario (script alter_sp_CambiarEstadoVenta);
        // así funciona igual antes y después de aplicar ese script en la base.
        public void CambiarEstadoVenta(int idVenta, bool anulada, string motivo, int idUsuario)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                bool aceptaUsuario;

                using (SqlCommand consulta = new SqlCommand(
                    @"SELECT COUNT(*) FROM sys.parameters
                      WHERE object_id = OBJECT_ID('dbo.sp_CambiarEstadoVenta') AND name = '@IdUsuario'", conexion))
                {
                    aceptaUsuario = Convert.ToInt32(consulta.ExecuteScalar()) > 0;
                }

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

                    if (aceptaUsuario && idUsuario > 0)
                    {
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                    }

                    cmd.ExecuteNonQuery();
                }
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