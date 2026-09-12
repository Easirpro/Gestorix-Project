using CapaEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClsModificarCorreoPer
    {
        Conexion cn = new Conexion();

        public bool ModificarCorreoPer(ClsCorreo correo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE Correo
                    SET Correo = @Correo
                    WHERE IdCorreo = @IdCorreo";

                SqlCommand cmd = new SqlCommand(consulta, conexion);

                cmd.Parameters.AddWithValue("@IdCorreo", correo.IdCorreo);
                cmd.Parameters.AddWithValue("@Correo", correo.DireccionCorreo);

                conexion.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}
