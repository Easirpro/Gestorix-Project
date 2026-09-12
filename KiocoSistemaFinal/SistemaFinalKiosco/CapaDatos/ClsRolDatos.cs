using CapaEntidades;
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
    public class ClsRolDatos
    {
        Conexion conexion = new Conexion();

        public DataTable ObtenerRoles()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT IdRol, Nombre FROM Rol ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                da.Fill(dt);
            }

            return dt;
        }

        public List<int> ObtenerPermisos(int idRol)
        {
            List<int> permisos = new List<int>();

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    SELECT IdPermiso
                    FROM RolPermiso
                    WHERE IdRol = @IdRol";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdRol", idRol);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    permisos.Add(Convert.ToInt32(reader["IdPermiso"]));
                }
            }

            return permisos;
        }

        public string ObtenerNombreRol(int idRol)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT Nombre
                FROM Rol
                WHERE IdRol = @IdRol";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdRol", idRol);

                object resultado = cmd.ExecuteScalar();

                if (resultado == null) 
                { 
                    return ""; 
                }
                   

                return resultado.ToString();
            }
        }
    }
}