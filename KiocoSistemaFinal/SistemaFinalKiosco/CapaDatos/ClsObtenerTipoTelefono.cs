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
    public class ClsObtenerTipoTelefono
    {
        Conexion cn = new Conexion();

        public List<ClsTipoTelefono> ObtenerTiposTelefono()
        {
            List<ClsTipoTelefono> lista = new List<ClsTipoTelefono>();

            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdTipo,
                        Tipo
                    FROM TipoTelefono
                    ORDER BY Tipo;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ClsTipoTelefono
                            {
                                IdTipo = Convert.ToInt32(reader["IdTipo"]),
                                Tipo = reader["Tipo"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
