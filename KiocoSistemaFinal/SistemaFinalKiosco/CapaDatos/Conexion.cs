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
        private string cadena = "Server=DESKTOP-QHDK5QJ\\SQLEXPRESS;Database=Gestorix;Trusted_Connection=True;TrustServerCertificate=True;";
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
