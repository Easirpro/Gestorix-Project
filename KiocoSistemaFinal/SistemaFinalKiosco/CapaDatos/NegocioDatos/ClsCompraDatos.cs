using CapaEntidades.NegocioEntidades;
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
    public class ClsCompraDatos
    {
        private Conexion cn = new Conexion();

        public DataTable BuscarProducto(string texto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
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
        }
        public int GuardarCompra(ClsCompraEntidad compra)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_GuardarCompra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", compra.IdProveedor);
                    cmd.Parameters.AddWithValue("@Fecha", compra.Fecha);
                    cmd.Parameters.AddWithValue("@TipoComprobante", compra.TipoComprobante);
                    cmd.Parameters.AddWithValue("@NumeroComprobante", compra.NumeroComprobante);
                    cmd.Parameters.AddWithValue("@SubtotalSinIVA", compra.SubtotalSinIVA);
                    cmd.Parameters.AddWithValue("@IVA", compra.IVA);
                    cmd.Parameters.AddWithValue("@Total", compra.Total);
                    cmd.Parameters.AddWithValue("@Observaciones", string.IsNullOrWhiteSpace(compra.Observaciones) ? (object)DBNull.Value : compra.Observaciones);

                    DataTable tablaDetalles = new DataTable();

                    tablaDetalles.Columns.Add("IdProducto", typeof(int));
                    tablaDetalles.Columns.Add("Cantidad", typeof(decimal));
                    tablaDetalles.Columns.Add("PrecioSinIVA", typeof(decimal));
                    tablaDetalles.Columns.Add("PorcentajeIVA", typeof(decimal));
                    tablaDetalles.Columns.Add("Total", typeof(decimal));

                    foreach (ClsDetalleCompraEntidad detalle in compra.Detalles)
                    {
                        tablaDetalles.Rows.Add(detalle.IdProducto, detalle.Cantidad, detalle.PrecioSinIVA,detalle.PorcentajeIVA, detalle.Total);
                    }

                    SqlParameter parametroDetalles = cmd.Parameters.AddWithValue("@Detalles", tablaDetalles);

                    parametroDetalles.SqlDbType = SqlDbType.Structured;
                    parametroDetalles.TypeName = "dbo.TipoDetalleCompra";

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public DataTable ObtenerCompras(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
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
        }
        public DataTable ObtenerDetalleCompra(int idCompra)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
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
        }
        public void AnularCompra(int idCompra, string motivo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_AnularCompra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCompra", idCompra);
                    cmd.Parameters.AddWithValue("@Motivo", motivo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
