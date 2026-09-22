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
    public class ClsPermisoDatos
    {
        Conexion conexion = new Conexion();

        public DataTable ObtenerPermisos()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    SELECT
                        IdPermiso,
                        Nombre,
                        Descripcion,
                        CodigoPermiso
                    FROM Permiso
                    ORDER BY IdPermiso";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                da.Fill(dt);
            }

            return dt;
        }
    }
}
