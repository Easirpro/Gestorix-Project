using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SistemaKiosco
{
    public class Conexion
    {

        private string cadena = @"Server=.\SQLEXPRESS;Database=Gestorix;Integrated Security=True;TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }

        public SqlConnection ObtenerConexionMaster()
        {
            SqlConnectionStringBuilder cadenaMaster = new SqlConnectionStringBuilder(cadena);
            cadenaMaster.InitialCatalog = "master";

            return new SqlConnection(cadenaMaster.ConnectionString);
        }
    }
}
