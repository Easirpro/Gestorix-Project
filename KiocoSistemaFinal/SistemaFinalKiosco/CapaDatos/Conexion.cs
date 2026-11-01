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

        private  string cadena = @"Server = 26.202.1.233,1433; Database=Gestorix;User ID = gestorix_user; Password=Admin123;TrustServerCertificate=True";
        //@"Server=PCALA\SQLEXPRESS;Database=Gestorix;Integrated Security=True;TrustServerCertificate=True;";
        //private string cadena = "Server=DESKTOP-QHDK5QJ\\SQLEXPRESS;Database=Gestorix;Trusted_Connection=True;TrustServerCertificate=True;";
        //private string cadena = "Server=tcp:gestorix.database.windows.net,1433; Initial Catalog=Gestorix; User ID=GestorAdmin; Password=Gestorix123; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;";
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }

        // Misma cadena pero conectada a master: backup y restore no pueden depender de que
        // la base Gestorix esté accesible. Así solo hay que cambiar el servidor en un lugar.
        public SqlConnection ObtenerConexionMaster()
        {
            SqlConnectionStringBuilder cadenaMaster = new SqlConnectionStringBuilder(cadena);
            cadenaMaster.InitialCatalog = "master";

            return new SqlConnection(cadenaMaster.ConnectionString);
        }
    }
}

