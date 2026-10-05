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
        public int RegistrarVenta( decimal total, int idUsuario, List<DetalleVentaEntidad> detalles, List<PagoVentaEntidad> pagos)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = total;
                cmd.Parameters["@Total"].Precision = 18;
                cmd.Parameters["@Total"].Scale = 2;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;


                DataTable tablaDetalles = new DataTable();

                tablaDetalles.Columns.Add("IdProducto", typeof(int));
                tablaDetalles.Columns.Add("Cantidad", typeof(decimal));
                tablaDetalles.Columns.Add("PrecioUnitario", typeof(decimal));
                tablaDetalles.Columns.Add("Subtotal", typeof(decimal));

                foreach (DetalleVentaEntidad detalle in detalles)
                {
                    tablaDetalles.Rows.Add(detalle.IdProducto, detalle.Cantidad, detalle.PrecioUnitario, detalle.Subtotal);
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
    }
}