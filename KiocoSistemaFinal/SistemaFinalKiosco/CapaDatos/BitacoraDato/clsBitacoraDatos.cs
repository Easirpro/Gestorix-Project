using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaKiosco;

namespace CapaDatos.BitacoraDato
{
    public class clsBitacoraDatos
    {
        private Conexion cn = new Conexion();

        public int RegistrarBitacora(int? idUsuario, string accion, string tablaAfectada, int? idRegistroAfectado, string descripcion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarBitacora", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = (object)idUsuario ?? DBNull.Value;
                cmd.Parameters.Add("@Accion", SqlDbType.NVarChar, 50).Value = accion;
                cmd.Parameters.Add("@TablaAfectada", SqlDbType.NVarChar, 50).Value = (object)tablaAfectada ?? DBNull.Value;
                cmd.Parameters.Add("@IdRegistroAfectado", SqlDbType.Int).Value = (object)idRegistroAfectado ?? DBNull.Value;
                cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 255).Value = (object)descripcion ?? DBNull.Value;

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public DataTable ObtenerBitacora( DateTime? fechaDesde, DateTime? fechaHasta, string categoria, string buscar)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerBitacora", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = (object)fechaDesde?.Date ?? DBNull.Value;
                cmd.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = (object)fechaHasta?.Date ?? DBNull.Value;
                cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar, 30).Value = string.IsNullOrWhiteSpace(categoria) ? DBNull.Value : categoria;
                cmd.Parameters.Add("@Buscar", SqlDbType.NVarChar, 255).Value = string.IsNullOrWhiteSpace(buscar) ? DBNull.Value : buscar.Trim();

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }
    }
}
