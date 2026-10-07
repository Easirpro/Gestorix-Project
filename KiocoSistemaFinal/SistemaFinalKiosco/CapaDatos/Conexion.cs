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
        //private string cadena = "Server=(localdb)\\MSSQLLocalDB;Database=Gestorix;Trusted_Connection=True;TrustServerCertificate=True;";
        private string cadena = "Server=tcp:gestorix.database.windows.net,1433; Initial Catalog = GestorixNueva;User ID = GestorAdmin;Password=Admin123;Encrypt=True;TrustServerCertificate=False;";
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
