using CapaEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClsPreguntaSeguridaDatos
    {
        Conexion conexion = new Conexion();
        public DataTable ObtenerPreguntas()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdPregunta,
                        Pregunta
                    FROM PreguntaSeguridad";

                SqlDataAdapter da =new SqlDataAdapter(consulta,con);
                da.Fill(dt);
            }

            return dt;
        }
        public bool RegistrarRespuestaUsuario(int IdUsuario,int IdPregunta,string Respuesta)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO RespuestaSeguridad
                    (
                        IdPregunta,
                        Respuesta,
                        IdUsuario
                    )
                    VALUES
                    (
                        @IdPregunta,
                        @Respuesta,
                        @IdUsuario
                    )";

                SqlCommand cmd = new SqlCommand(consulta,con);

                cmd.Parameters.AddWithValue("@IdPregunta",IdPregunta);
                cmd.Parameters.AddWithValue("@Respuesta",Respuesta);
                cmd.Parameters.AddWithValue( "@IdUsuario",IdUsuario);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Reemplaza todas las respuestas del usuario en una sola transacción:
        // o quedan guardadas las tres, o no cambia nada (sin respuestas a medias ni duplicadas).
        public bool GuardarRespuestas(int idUsuario, List<KeyValuePair<int, string>> respuestas)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmdBorrar = new SqlCommand(
                            "DELETE FROM RespuestaSeguridad WHERE IdUsuario = @IdUsuario", con, trans))
                        {
                            cmdBorrar.Parameters.AddWithValue("@IdUsuario", idUsuario);
                            cmdBorrar.ExecuteNonQuery();
                        }

                        foreach (KeyValuePair<int, string> respuesta in respuestas)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO RespuestaSeguridad (IdPregunta, Respuesta, IdUsuario)
                                VALUES (@IdPregunta, @Respuesta, @IdUsuario)", con, trans))
                            {
                                cmd.Parameters.AddWithValue("@IdPregunta", respuesta.Key);
                                cmd.Parameters.AddWithValue("@Respuesta", respuesta.Value);
                                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        public ClsPreguntaSeguridad ObtenerPreguntaAleatoria(int IdUsuario)
        {
            ClsPreguntaSeguridad pregunta = null;

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string consulta = @"
                    SELECT TOP 1
                        PS.IdPregunta,
                        PS.Pregunta
                    FROM RespuestaSeguridad RS
                    INNER JOIN PreguntaSeguridad PS
                        ON RS.IdPregunta = PS.IdPregunta
                    WHERE RS.IdUsuario = @IdUsuario
                    ORDER BY NEWID()";

                SqlCommand cmd = new SqlCommand(consulta,con);

                cmd.Parameters.AddWithValue("@IdUsuario",IdUsuario);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pregunta = new ClsPreguntaSeguridad();

                    pregunta.IdPregunta = Convert.ToInt32( reader["IdPregunta"]);

                    pregunta.Pregunta = reader["Pregunta"].ToString();
                }

                return pregunta;
            }
        }
        public bool ValidarRespuesta( int idUsuario,int idPregunta,string respuesta)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string consulta = @"
                    SELECT COUNT(*)
                    FROM RespuestaSeguridad
                    WHERE IdUsuario = @IdUsuario
                    AND IdPregunta = @IdPregunta
                    AND Respuesta = @Respuesta";

                SqlCommand cmd = new SqlCommand( consulta,con);

                cmd.Parameters.AddWithValue( "@IdUsuario",idUsuario);
                cmd.Parameters.AddWithValue("@IdPregunta",idPregunta);
                cmd.Parameters.AddWithValue("@Respuesta",respuesta);

                con.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool UsuarioTienePreguntas(int idUsuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string consulta = @"
                    SELECT COUNT(*)
                    FROM RespuestaSeguridad
                    WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@IdUsuario",idUsuario);

                con.Open();

                int cantidad = Convert.ToInt32( cmd.ExecuteScalar());

                return cantidad >= 3;
            }
        }
    }
}
