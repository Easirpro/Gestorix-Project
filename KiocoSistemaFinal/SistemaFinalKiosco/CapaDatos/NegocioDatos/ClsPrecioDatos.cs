using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System.Data;

namespace CapaDatos.NegocioDatos
{
    public class ClsPrecioDatos
    {
        private Conexion cn = new Conexion();

        public DataTable BuscarProductos(string texto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_BuscarProductosPrecio", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Texto", SqlDbType.NVarChar, 200).Value = texto ?? string.Empty;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }

        public void ActualizarPrecios(DataTable precios)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ActualizarPreciosProductos", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parametroPrecios = cmd.Parameters.Add("@Precios", SqlDbType.Structured);

                parametroPrecios.TypeName = "dbo.TipoActualizacionPrecio";
                parametroPrecios.Value = precios;

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}