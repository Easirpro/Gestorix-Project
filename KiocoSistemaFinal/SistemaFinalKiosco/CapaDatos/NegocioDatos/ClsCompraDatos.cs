using CapaEntidades.NegocioEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Data;
using System.Linq;

namespace CapaDatos.NegocioDatos
{
    public class ClsCompraDatos
    {
        private Conexion cn = new Conexion();

        public DataTable BuscarProducto(string texto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_BuscarProducto", conexion))
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
        public DataTable BuscarProductoCompra(string texto, int idSucursal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_BuscarProductoCompra", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Texto", SqlDbType.NVarChar, 200).Value = texto;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = idSucursal;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public int GuardarCompra(ClsCompraEntidad compra, int idUsuario)
        {
            if (compra == null)
                throw new ArgumentNullException(nameof(compra));

            if (compra.Detalles == null || compra.Detalles.Count == 0)
                throw new InvalidOperationException("La compra debe tener al menos un producto.");

            if (idUsuario <= 0)
                throw new InvalidOperationException("No hay un usuario válido para registrar la compra.");

            if (compra.Detalles.Any(d => d.IdProducto <= 0 || d.Cantidad <= 0))
            {
                throw new InvalidOperationException("La compra contiene productos o cantidades inválidas.");
            }

            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        int idCompra;

                        using (SqlCommand cmd = new SqlCommand("sp_GuardarCompra", conexion, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IdProveedor", compra.IdProveedor);
                            cmd.Parameters.AddWithValue("@Fecha", compra.Fecha);
                            cmd.Parameters.AddWithValue("@TipoComprobante", compra.TipoComprobante);
                            cmd.Parameters.AddWithValue("@NumeroComprobante", string.IsNullOrWhiteSpace(compra.NumeroComprobante) ? (object)DBNull.Value : compra.NumeroComprobante);

                            SqlParameter parametroSubtotal = cmd.Parameters.Add("@SubtotalSinIVA", SqlDbType.Decimal);
                            parametroSubtotal.Precision = 18;
                            parametroSubtotal.Scale = 2;
                            parametroSubtotal.Value = decimal.Round(compra.SubtotalSinIVA, 2, MidpointRounding.AwayFromZero);

                            SqlParameter parametroIVA = cmd.Parameters.Add("@IVA", SqlDbType.Decimal);
                            parametroIVA.Precision = 18;
                            parametroIVA.Scale = 2;
                            parametroIVA.Value = decimal.Round(compra.IVA, 2, MidpointRounding.AwayFromZero);

                            SqlParameter parametroTotal = cmd.Parameters.Add("@Total", SqlDbType.Decimal);
                            parametroTotal.Precision = 18;
                            parametroTotal.Scale = 2;
                            parametroTotal.Value = decimal.Round(compra.Total, 2, MidpointRounding.AwayFromZero);

                            cmd.Parameters.AddWithValue("@Observaciones", string.IsNullOrWhiteSpace(compra.Observaciones) ? (object)DBNull.Value : compra.Observaciones);

                            cmd.Parameters.AddWithValue("@IdUsuario",
                                compra.IdUsuario.HasValue ? (object)compra.IdUsuario.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@CondicionPago",
                                string.IsNullOrWhiteSpace(compra.CondicionPago) ? "CONTADO" : compra.CondicionPago);
                            cmd.Parameters.AddWithValue("@FechaVencimiento",
                                compra.FechaVencimiento.HasValue ? (object)compra.FechaVencimiento.Value.Date : DBNull.Value);
                            cmd.Parameters.AddWithValue("@IdMetodoPago",
                                compra.IdMetodoPago.HasValue ? (object)compra.IdMetodoPago.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@IdSesionCaja",
                                compra.IdSesionCaja.HasValue ? (object)compra.IdSesionCaja.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@IdSucursal",
                                compra.IdSucursal.HasValue ? (object)compra.IdSucursal.Value : DBNull.Value);
                            cmd.Parameters.Add("@FechaEntregaEstimada", SqlDbType.Date).Value =
                                compra.FechaEntregaEstimada.HasValue ? (object)compra.FechaEntregaEstimada.Value.Date : DBNull.Value;

                            DataTable tablaDetalles = new DataTable();
                            tablaDetalles.Columns.Add("IdProducto", typeof(int));
                            tablaDetalles.Columns.Add("Cantidad", typeof(decimal));
                            tablaDetalles.Columns.Add("PrecioSinIVA", typeof(decimal));
                            tablaDetalles.Columns.Add("PorcentajeIVA", typeof(decimal));
                            tablaDetalles.Columns.Add("Total", typeof(decimal));

                            foreach (ClsDetalleCompraEntidad detalle in compra.Detalles)
                            {
                                decimal cantidadDetalle = decimal.Round(detalle.Cantidad, 3, MidpointRounding.AwayFromZero);
                                decimal precioDetalle = decimal.Round(detalle.PrecioSinIVA, 2, MidpointRounding.AwayFromZero);
                                decimal porcentajeIVA = decimal.Round(detalle.PorcentajeIVA, 2, MidpointRounding.AwayFromZero);
                                decimal subtotalDetalle = decimal.Round(cantidadDetalle * precioDetalle, 2, MidpointRounding.AwayFromZero);
                                decimal ivaDetalle = decimal.Round(subtotalDetalle * porcentajeIVA / 100, 2, MidpointRounding.AwayFromZero);
                                decimal totalDetalle = subtotalDetalle + ivaDetalle;

                                tablaDetalles.Rows.Add(detalle.IdProducto, cantidadDetalle, precioDetalle, porcentajeIVA, totalDetalle);
                            }

                            SqlParameter parametroDetalles = cmd.Parameters.AddWithValue("@Detalles", tablaDetalles);
                            parametroDetalles.SqlDbType = SqlDbType.Structured;
                            parametroDetalles.TypeName = "dbo.TipoDetalleCompra";

                            idCompra = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        foreach (var grupo in compra.Detalles.GroupBy(d => d.IdProducto))
                        {
                            decimal cantidad = decimal.Round(grupo.Sum(d => d.Cantidad), 3, MidpointRounding.AwayFromZero);

                            using (SqlCommand cmdStock = new SqlCommand(@"
                                    UPDATE dbo.Stock WITH (UPDLOCK, HOLDLOCK)
                                    SET CantidadActual = CantidadActual + @Cantidad
                                    WHERE IdProducto = @IdProducto;

                                    IF @@ROWCOUNT = 0
                                    BEGIN
                                        INSERT INTO dbo.Stock
                                            (IdProducto, CantidadActual,
                                             StockMinimo, StockIdeal)
                                        VALUES
                                            (@IdProducto, @Cantidad, 0, 0);
                                    END;", conexion, transaccion))
                            {
                                cmdStock.Parameters.Add("@IdProducto", SqlDbType.Int).Value = grupo.Key;
                                cmdStock.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = cantidad;
                                cmdStock.Parameters["@Cantidad"].Precision = 10;
                                cmdStock.Parameters["@Cantidad"].Scale = 3;

                                cmdStock.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdMovimiento = new SqlCommand(@"
                                    INSERT INTO dbo.MovimientoStock
                                        (IdProducto, TipoMovimiento, Cantidad,
                                         FechaHora, Observacion, IdUsuario)
                                    VALUES
                                        (@IdProducto, N'INGRESO', @Cantidad,
                                         SYSDATETIME(), @Observacion, @IdUsuario);",
                                conexion, transaccion))
                            {
                                cmdMovimiento.Parameters.Add("@IdProducto", SqlDbType.Int).Value = grupo.Key;
                                cmdMovimiento.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = cantidad;
                                cmdMovimiento.Parameters["@Cantidad"].Precision = 10;
                                cmdMovimiento.Parameters["@Cantidad"].Scale = 3;
                                cmdMovimiento.Parameters.Add("@Observacion", SqlDbType.NVarChar, 255).Value = "Compra #" + idCompra;
                                cmdMovimiento.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                                cmdMovimiento.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                        return idCompra;
                    }
                    catch
                    {
                        try
                        {
                            transaccion.Rollback();
                        }
                        catch
                        {

                        }

                        throw;
                    }
                }
            }
        }
        public DataTable ObtenerCompras(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerCompras", conexion))
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
        public DataTable ObtenerDetalleCompra(int idCompra)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerDetalleCompra", conexion))
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
        public void AnularCompra(int idCompra, string motivo, int idUsuario)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_AnularCompra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCompra", idCompra);
                    cmd.Parameters.AddWithValue("@Motivo", motivo);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable ObtenerComprasPendientesRecepcion(string buscar, DateTime? fecha)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerComprasPendientesRecepcion", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Buscar", SqlDbType.NVarChar, 100).Value = string.IsNullOrWhiteSpace(buscar) ? (object)DBNull.Value : buscar.Trim();
                cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha.HasValue ? (object)fecha.Value.Date : DBNull.Value;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public int ConfirmarRecepcion(ClsRecepcionCompraEntidad recepcion, int idUsuario)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ConfirmarRecepcionCompra", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = recepcion.IdCompra;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;

                SqlParameter parametroTotalBoleta = cmd.Parameters.Add("@TotalBoleta", SqlDbType.Decimal);
                parametroTotalBoleta.Precision = 10;
                parametroTotalBoleta.Scale = 2;
                parametroTotalBoleta.Value = decimal.Round(recepcion.TotalBoleta, 2, MidpointRounding.AwayFromZero);

                cmd.Parameters.Add("@Motivos", SqlDbType.NVarChar, 500).Value = string.IsNullOrWhiteSpace(recepcion.Motivos) ? (object)DBNull.Value : recepcion.Motivos;
                cmd.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 500).Value = string.IsNullOrWhiteSpace(recepcion.Observaciones) ? (object)DBNull.Value : recepcion.Observaciones;

                DataTable tablaDetalles = new DataTable();
                tablaDetalles.Columns.Add("IdProducto", typeof(int));
                tablaDetalles.Columns.Add("CantidadRecibida", typeof(decimal));

                foreach (ClsDetalleRecepcionEntidad detalle in recepcion.Detalles)
                {
                    tablaDetalles.Rows.Add(detalle.IdProducto, decimal.Round(detalle.CantidadRecibida, 3, MidpointRounding.AwayFromZero));
                }

                SqlParameter parametroDetalles = cmd.Parameters.AddWithValue("@Detalles", tablaDetalles);
                parametroDetalles.SqlDbType = SqlDbType.Structured;
                parametroDetalles.TypeName = "dbo.TipoDetalleRecepcion";

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
