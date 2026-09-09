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
    public class ClsObtenerTelefonoPersona
    {
        Conexion cn = new Conexion();

        public ClsTelefono ObtenerTelefonoPorPersona(int idPersona)
        {
            ClsTelefono telefono = null;

            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        T.IdTelefono,
                        T.NumTelefono,
                        T.IdTipo
                    FROM PersonaTelefono PT
                    INNER JOIN Telefono T
                        ON PT.IdTelefono = T.IdTelefono
                    WHERE PT.IdPersona = @IdPersona
                      AND PT.Activo = 1;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdPersona", idPersona);

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            telefono = new ClsTelefono
                            {
                                IdTelefono = Convert.ToInt32(reader["IdTelefono"]),
                                NumTelefono = reader["NumTelefono"].ToString(),
                                IdTipo = Convert.ToInt32(reader["IdTipo"])
                            };
                        }
                    }
                }
            }

            return telefono;
        }
        public int ObtenerIdTelefonoPorPersona(int idPersona)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT PT.IdTelefono
                    FROM PersonaTelefono PT
                    WHERE PT.IdPersona = @IdPersona
                    AND PT.Activo = 1";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue( "@IdPersona",idPersona);

                    conexion.Open();

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null) 
                    { 
                        return Convert.ToInt32(resultado);
                    }
                       

                    return 0;
                }
            }
        }
    }
}
