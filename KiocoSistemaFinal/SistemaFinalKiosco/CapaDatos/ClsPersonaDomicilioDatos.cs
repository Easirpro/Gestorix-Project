using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class clsPersonaDomicilioDatos
    {
        Conexion cn = new Conexion();

        public void RegistrarPersonaDomicilio(int idPersona, int idDomicilio)
        {
            SqlConnection conexion = cn.ObtenerConexion();

            string consulta = @"
                INSERT INTO PersonaDireccion
                (IdPersona, IdDireccion, Activo)
                VALUES
                (@IdPersona, @IdDireccion, 1)";

            SqlCommand cmd = new SqlCommand(consulta, conexion);

            cmd.Parameters.AddWithValue("@IdPersona", idPersona);
            cmd.Parameters.AddWithValue("@IdDireccion", idDomicilio);

            conexion.Open();

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
        public int ObtenerIdDomicilioPorPersona(int idPersona)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT TOP 1 IdDireccion
                    FROM PersonaDireccion
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
