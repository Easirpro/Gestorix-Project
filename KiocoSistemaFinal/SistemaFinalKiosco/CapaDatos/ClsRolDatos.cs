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

                string query = "SELECT IdRol, Nombre FROM Rol ORDER BY Nombre";

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
        // Cantidad de usuarios activos con ese rol (a quiénes afecta cambiar sus permisos).
        public int ContarUsuariosPorRol(int idRol)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT COUNT(*)
                FROM Usuario
                WHERE IdRol = @IdRol
                  AND Estado = 1";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdRol", idRol);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
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
        public void GuardarPermisos(int idRol, List<int> permisos)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string eliminar = @"
                            DELETE FROM RolPermiso
                            WHERE IdRol = @IdRol";

                        using (SqlCommand cmdEliminar = new SqlCommand(eliminar, conn, transaction))
                        {
                            cmdEliminar.Parameters.AddWithValue("@IdRol", idRol);
                            cmdEliminar.ExecuteNonQuery();
                        }

                        string insertar = @"
                            INSERT INTO RolPermiso (IdRol, IdPermiso)
                            VALUES (@IdRol, @IdPermiso)";

                        foreach (int idPermiso in permisos)
                        {
                            using (SqlCommand cmdInsertar = new SqlCommand(insertar, conn, transaction))
                            {
                                cmdInsertar.Parameters.AddWithValue("@IdRol", idRol);
                                cmdInsertar.Parameters.AddWithValue("@IdPermiso", idPermiso);

                                cmdInsertar.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public int CrearRol(string nombre)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string verificar = @"
                    SELECT COUNT(*)
                    FROM Rol
                    WHERE Nombre = @Nombre";

                using (SqlCommand cmdVerificar = new SqlCommand(verificar, conn))
                {
                    cmdVerificar.Parameters.AddWithValue("@Nombre", nombre);

                    int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                    if (existe > 0)
                    {
                        return 0;
                    }
                }

                string query = @"
                    INSERT INTO Rol (Nombre)
                    VALUES (@Nombre);

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public void EliminarRol(int idRol)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string eliminarPermisos = @"
                            DELETE FROM RolPermiso
                            WHERE IdRol = @IdRol";

                        using (SqlCommand cmdPermisos =
                            new SqlCommand(eliminarPermisos, conn, transaction))
                        {
                            cmdPermisos.Parameters.AddWithValue("@IdRol", idRol);
                            cmdPermisos.ExecuteNonQuery();
                        }

                        string eliminarRol = @"
                            DELETE FROM Rol
                            WHERE IdRol = @IdRol";

                        using (SqlCommand cmdRol =
                            new SqlCommand(eliminarRol, conn, transaction))
                        {
                            cmdRol.Parameters.AddWithValue("@IdRol", idRol);

                            int filasEliminadas = cmdRol.ExecuteNonQuery();

                            if (filasEliminadas != 1)
                            {
                                throw new Exception("No se pudo eliminar el rol seleccionado.");
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


    }
}