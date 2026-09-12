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
    public class ClsLocalidadDatos
    {
        Conexion conexion = new Conexion();

        public DataTable CargarLocalidades(int idPartido)
        {
            DataTable dt = new DataTable(); 
            using (SqlConnection con = conexion.ObtenerConexion()) 
            { 
                string query = @" 
                    SELECT 
                    IdLocalidad, 
                    NomLocalidad, 
                    CodigoPostal 
                    FROM Localidad 
                    WHERE IdPartido = @IdPartido"; 

                SqlCommand cmd = new SqlCommand(query, con);
                
                cmd.Parameters.AddWithValue("@IdPartido", idPartido); 

                SqlDataAdapter da = new SqlDataAdapter(cmd); da.Fill(dt); 
            
            }
            return dt;
        }
    }
}