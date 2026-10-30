using CapaDatos;
using CapaEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsUsuarioLogica
    {
        private Conexion conexion = new Conexion();


        public DataTable ObtenerUsuarios()
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerUsuarios();
        }
        public ClsPersona ObtenerPersonaPorId(int idPersona)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerPersonaPorId(idPersona);
        }
        public int ObtenerIdUsuario(string username)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerIdUsuarioPorUsername(username);
        }
        public ClsPreguntaSeguridad ObtenerPregunta(int idUsuario)
        {
            ClsPreguntaSeguridaDatos datos = new ClsPreguntaSeguridaDatos();

            return datos.ObtenerPreguntaAleatoria(idUsuario);
        }
        public bool CambiarPasswordRecuperacion(int idUsuario, string nuevaPassword)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.CambiarPasswordRecuperacion(
                idUsuario,
                nuevaPassword
            );
        }
        public string ObtenerUsername(int idUsuario)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerUsername(idUsuario);
        }
        public string ObtenerUltimaPasswordAntigua(int idUsuario)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerUltimaPasswordAntigua(idUsuario);
        }
        public bool PasswordUsadaUltimasTres(int idUsuario, string password)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.PasswordUsadaUltimasTres(
                idUsuario,
                password
            );
        }
        public bool ExistePersonaDatos(string dni, string cuit, int idPersonaActual)
        { 
            using (SqlConnection con = conexion.ObtenerConexion())

            {
                string sql = @"
                SELECT COUNT(*)
                FROM Persona
                WHERE (DNI = @DNI OR CUIT = @CUIT)
                AND IdPersona <> @IdPersona";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@CUIT", cuit);
                cmd.Parameters.AddWithValue("@IdPersona", idPersonaActual);

                con.Open();

                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                return cantidad > 0;
            }
        }
        public bool ExisteUsuarioPorIdPersona(int idPersona)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ExisteUsuarioPorIdPersona(idPersona);
        }
        public int ObtenerIdRolPorPersona(int idPersona)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            return datos.ObtenerIdRolPorPersona(idPersona);
        }
    }
}