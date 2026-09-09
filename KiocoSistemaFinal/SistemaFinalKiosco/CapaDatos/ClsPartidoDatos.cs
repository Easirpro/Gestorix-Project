using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClsPartidoDatos
    {
        Conexion conexion = new Conexion();

        public DataTable CargarPartidos(int idProvincia)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"
                         SELECT IdPartido, 
                                NomPartido
                         FROM Partido
                         WHERE IdProvincia = @IdProvincia";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            return dt;
        }
    }
}