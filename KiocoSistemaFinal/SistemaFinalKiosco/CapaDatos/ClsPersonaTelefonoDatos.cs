using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class clsPersonaTelefonoDatos
    {
        Conexion cn = new Conexion();

        public void RegistrarPersonaTelefono(int idPersona, int idTelefono)
        {
            SqlConnection conexion = cn.ObtenerConexion();

            string consulta = @"INSERT INTO PersonaTelefono
                                (IdPersona, IdTelefono, Activo)
                                VALUES
                                (@IdPersona, @IdTelefono, 1)";

            SqlCommand cmd = new SqlCommand(consulta, conexion);

            cmd.Parameters.AddWithValue("@IdPersona", idPersona);
            cmd.Parameters.AddWithValue("@IdTelefono", idTelefono);

            conexion.Open();

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public int ObtenerIdTelefonoPorPersona(int idPersona)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT TOP 1 IdTelefono
                    FROM PersonaTelefono
                    WHERE IdPersona = @IdPersona
                      AND Activo = 1";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdPersona", idPersona);

                    conexion.Open();

                    object resultado = cmd.ExecuteScalar();

                    if (resultado == null)                
                    {
                        return 0;
                    }
                    return Convert.ToInt32(resultado);
                }
            }
        }
    }
}
