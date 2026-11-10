using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Data;

namespace CapaDatos.NegocioDatos
{
    public class ClsDevolucionProveedorDatos
    {
        private Conexion cn = new Conexion();

        public DataTable ObtenerLotesVencidos(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerLotesVencidosProducto", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }

        public DataTable ObtenerDevoluciones(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerDevolucionesProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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

        // numero e importe
        public (int IdDevolucion, decimal Importe) Registrar(int idLote, decimal cantidad, string motivo, int idUsuario)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_RegistrarDevolucionProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdLote", SqlDbType.Int).Value = idLote;

                SqlParameter parametroCantidad = cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal);
                parametroCantidad.Precision = 10;
                parametroCantidad.Scale = 3;
                parametroCantidad.Value = cantidad;

                cmd.Parameters.Add("@Motivo", SqlDbType.NVarChar, 255).Value = motivo;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;

                conexion.Open();

                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    if (!lector.Read())
                        throw new Exception("No se pudo registrar la devolución.");

                    return (Convert.ToInt32(lector["IdDevolucionProveedor"]), Convert.ToDecimal(lector["Importe"]));
                }
            }
        }
    }
}
