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
        private string cadena =
            "Server=tcp:gestorix.database.windows.net,1433;" +
            "Initial Catalog=Gestorix;" +
            "User ID=GestorAdmin;" +
            "Password=Gestorix123;" +
            "Encrypt=True;" +
            "TrustServerCertificate=False;" +
            "Connection Timeout=30;";
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
