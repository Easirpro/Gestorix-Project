using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Data;

namespace CapaDatos.NegocioDatos
{
    public class ClsInformeVentasDatos
    {
        private Conexion cn = new Conexion();

        public DataTable ObtenerInforme(string tipo, DateTime desde, DateTime hasta, int? idUsuario, int? idMetodoPago, int? idCategoria, int? idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_InformeVentas", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 10).Value = tipo;
                cmd.Parameters.Add("@Desde", SqlDbType.Date).Value = desde.Date;
                cmd.Parameters.Add("@Hasta", SqlDbType.Date).Value = hasta.Date;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = (object)idUsuario ?? DBNull.Value;
                cmd.Parameters.Add("@IdMetodoPago", SqlDbType.Int).Value = (object)idMetodoPago ?? DBNull.Value;
                cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = (object)idCategoria ?? DBNull.Value;
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = (object)idProducto ?? DBNull.Value;

                DataTable tabla = new DataTable();

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    adaptador.Fill(tabla);
                }

                return tabla;
            }
        }
        public DataTable ObtenerVendedores()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_InformeVentasVendedores", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable tabla = new DataTable();

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    adaptador.Fill(tabla);
                }

                return tabla;
            }
        }
    }
}
