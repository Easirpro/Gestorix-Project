using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class clsPersonaCorreoDatos
    {
        Conexion cn = new Conexion();

        public void RegistrarPersonaCorreo(int idPersona,int idCorreo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO PersonaCorreo
                    (
                        IdPersona,
                        IdCorreo
                    )
                    VALUES
                    (
                        @IdPersona,
                        @IdCorreo
                    )";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdPersona",idPersona);
                    cmd.Parameters.AddWithValue("@IdCorreo",idCorreo);

                    conexion.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int ObtenerIdCorreoPorPersona(int idPersona)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT TOP 1 IdCorreo
                    FROM PersonaCorreo
                    WHERE IdPersona = @IdPersona";

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
