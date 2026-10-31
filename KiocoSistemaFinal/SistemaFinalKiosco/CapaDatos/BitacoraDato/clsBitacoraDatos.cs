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
        public DataTable ObtenerBitacora(DateTime? fechaDesde, DateTime? fechaHasta, string categoria, string buscar)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerBitacora", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = (object)fechaDesde?.Date ?? DBNull.Value;
                cmd.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = (object)fechaHasta?.Date ?? DBNull.Value;
                cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar, 30).Value = string.IsNullOrWhiteSpace(categoria) ? (object)DBNull.Value : categoria;
                cmd.Parameters.Add("@Buscar", SqlDbType.NVarChar, 255).Value = string.IsNullOrWhiteSpace(buscar) ? (object)DBNull.Value : buscar.Trim();

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }
        public DataTable ObtenerComprasBitacora(DateTime? fechaDesde, DateTime? fechaHasta, string buscar)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerComprasBitacora", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = (object)fechaDesde?.Date ?? DBNull.Value;
                cmd.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = (object)fechaHasta?.Date ?? DBNull.Value;
                cmd.Parameters.Add("@Buscar", SqlDbType.NVarChar, 255).Value = string.IsNullOrWhiteSpace(buscar) ? (object)DBNull.Value : buscar.Trim();

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }
        public void RegistrarError(int? idUsuario, string modulo, string tipoExcepcion, string mensaje, string detalleTecnico)
        {
            if (string.IsNullOrWhiteSpace(modulo))
                throw new ArgumentException("El módulo es obligatorio.", nameof(modulo));

            if (modulo.Length > 100)
                modulo = modulo.Substring(0, 100);

            if (tipoExcepcion?.Length > 250)
                tipoExcepcion = tipoExcepcion.Substring(0, 250);

            if (string.IsNullOrWhiteSpace(mensaje))
                mensaje = "Error sin mensaje.";

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_RegistrarErrorTecnico", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value =
                    (object)idUsuario ?? DBNull.Value;

                cmd.Parameters.Add("@Modulo", SqlDbType.NVarChar, 100).Value = modulo;

                cmd.Parameters.Add("@TipoExcepcion", SqlDbType.NVarChar, 250).Value =
                    string.IsNullOrWhiteSpace(tipoExcepcion)
                        ? (object)DBNull.Value
                        : tipoExcepcion;

                cmd.Parameters.Add("@Mensaje", SqlDbType.NVarChar, -1).Value = mensaje;

                cmd.Parameters.Add("@DetalleTecnico", SqlDbType.NVarChar, -1).Value =
                    string.IsNullOrWhiteSpace(detalleTecnico)
                        ? (object)DBNull.Value
                        : detalleTecnico;

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ObtenerErrores(DateTime? fechaDesde, DateTime? fechaHasta, string buscar, string estado)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerErroresTecnicos", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = fechaDesde.HasValue ? (object)fechaDesde.Value.Date : DBNull.Value;
                cmd.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = fechaHasta.HasValue ? (object)fechaHasta.Value.Date : DBNull.Value;
                cmd.Parameters.Add("@Buscar", SqlDbType.NVarChar, 255).Value = string.IsNullOrWhiteSpace(buscar) ? (object)DBNull.Value : buscar.Trim();
                cmd.Parameters.Add("@Estado", SqlDbType.NVarChar, 20).Value = string.IsNullOrWhiteSpace(estado) ? (object)DBNull.Value : estado;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }
    }
}
