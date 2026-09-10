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
    public class ClsTipoTelefonoDatos
    {
        Conexion cn = new Conexion();

        public DataTable CargarTiposTelefono()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdTipo,
                        Tipo
                    FROM TipoTelefono
                    ORDER BY Tipo";

                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
