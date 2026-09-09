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
    public class ClsProvinciaDatos
    {
        Conexion conexion = new Conexion();

        public DataTable CargarProvincias()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"SELECT IdProvincia,
                                        NomProvincia
                                 FROM Provincia";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                da.Fill(dt);
            }

            return dt;
        }
    }
}
