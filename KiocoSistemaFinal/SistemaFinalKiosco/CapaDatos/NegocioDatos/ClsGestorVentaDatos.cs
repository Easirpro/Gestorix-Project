using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades.NegocioEntidad;
using System.Collections.Generic;

namespace CapaDatos.NegocioDatos
{
    public class ClsGestorVentaDatos
    {
        Conexion cn = new Conexion();

        public DataTable ObtenerMetodosPago()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdMetodoPago,
                        Nombre
                    FROM MetodoPago
                    WHERE Activo = 1
                    ORDER BY Nombre;";

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
        public int RegistrarVenta(decimal total, int idUsuario, List<DetalleVentaEntidad> detalles, List<PagoVentaEntidad> pagos)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {

                    string sqlVenta = @"
                        INSERT INTO Venta
                            (FechaHora, Total, IdUsuario)
                        VALUES
                            (@FechaHora, @Total, @IdUsuario);

                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int idVenta;

                    using (SqlCommand cmdVenta = new SqlCommand(sqlVenta, conexion, transaccion))
                    {
                        cmdVenta.Parameters.AddWithValue("@FechaHora", DateTime.Now);
                        cmdVenta.Parameters.AddWithValue("@Total", total);
                        cmdVenta.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());
                    }

                    foreach (DetalleVentaEntidad detalle in detalles)
                    {
                        string sqlDetalle = @"
                            INSERT INTO DetalleVenta
                                (
                                    IdVenta,
                                    IdProducto,
                                    Cantidad,
                                    PrecioUnitario,
                                    Subtotal
                                )
                            VALUES
                                (
                                    @IdVenta,
                                    @IdProducto,
                                    @Cantidad,
                                    @PrecioUnitario,
                                    @Subtotal
                                );";

                        using (SqlCommand cmdDetalle = new SqlCommand(sqlDetalle,conexion,transaccion))
                        {
                            cmdDetalle.Parameters.AddWithValue("@IdVenta", idVenta);
                            cmdDetalle.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);
                            cmdDetalle.ExecuteNonQuery();
                        }

                        string sqlStock = @"
                            UPDATE Stock
                            SET CantidadActual =
                                CantidadActual - @Cantidad
                            WHERE IdProducto = @IdProducto
                              AND CantidadActual >= @Cantidad;";

                        int filasAfectadas;

                        using (SqlCommand cmdStock = new SqlCommand(sqlStock,conexion,transaccion))
                        {
                            cmdStock.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmdStock.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                            filasAfectadas = cmdStock.ExecuteNonQuery();
                        }

                        if (filasAfectadas == 0)
                        {
                            throw new Exception($"Stock insuficiente para el producto " + $"{detalle.IdProducto}.");
                        }

                        string sqlMovimiento = @"
                            INSERT INTO MovimientoStock
                                (
                                    IdProducto,
                                    TipoMovimiento,
                                    Cantidad,
                                    FechaHora,
                                    Observacion,
                                    IdUsuario
                                )
                            VALUES
                                (
                                    @IdProducto,
                                    @TipoMovimiento,
                                    @Cantidad,
                                    @FechaHora,
                                    @Observacion,
                                    @IdUsuario
                                );";

                        using (SqlCommand cmdMovimiento = new SqlCommand(sqlMovimiento, conexion, transaccion))
                        {
                            cmdMovimiento.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                            cmdMovimiento.Parameters.AddWithValue("@TipoMovimiento", "EGRESO");
                            cmdMovimiento.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmdMovimiento.Parameters.AddWithValue("@FechaHora", DateTime.Now);
                            cmdMovimiento.Parameters.AddWithValue("@Observacion", $"Venta #{idVenta}");
                            cmdMovimiento.Parameters.AddWithValue("@IdUsuario", idUsuario);
                            cmdMovimiento.ExecuteNonQuery();
                        }
                    }

                    foreach (PagoVentaEntidad pago in pagos)
                    {
                        string sqlPago = @"
                            INSERT INTO VentaMetodoPago
                                (
                                    IdVenta,
                                    IdMetodoPago,
                                    Monto
                                )
                            VALUES
                                (
                                    @IdVenta,
                                    @IdMetodoPago,
                                    @Monto
                                );";

                        using (SqlCommand cmdPago = new SqlCommand( sqlPago, conexion, transaccion))
                        {
                            cmdPago.Parameters.AddWithValue("@IdVenta", idVenta);
                            cmdPago.Parameters.AddWithValue("@IdMetodoPago", pago.IdMetodoPago);
                            cmdPago.Parameters.AddWithValue("@Monto", pago.Monto);
                            cmdPago.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();

                    return idVenta;
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }
    }
}