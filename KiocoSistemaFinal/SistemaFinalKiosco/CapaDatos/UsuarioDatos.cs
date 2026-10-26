using CapaDatos;
using CapaDatos.SistemaKiosco;
using CapaEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;


public class ClsUsuarioDatos
{
    Conexion conexion = new Conexion();

    public bool UsuarioBloqueado { get; set; }
    public bool ValidarUsuario(string usuario, string password)
    {

        UsuarioBloqueado = false;

        using (SqlConnection conn = conexion.ObtenerConexion())
        {
            conn.Open();

            string query = @"
                SELECT
                    u.IdUsuario,
                    u.Estado,
                    u.IdPersona,
                    u.IdRol,
                    u.Username,
                    u.PrimerIngreso,
                    u.UltimoIngreso,
                    CASE
                        WHEN
                        (
                            SELECT COUNT(*)
                            FROM RespuestaSeguridad rs
                            WHERE rs.IdUsuario = u.IdUsuario
                        ) >= 3
                        THEN CAST(1 AS bit)
                        ELSE CAST(0 AS bit)
                    END AS PreguntasCompletadas,
                    p.Activo,
                    p.Nombre,
                    p.Apellido,
                    p.Sexo,
                    p.IdGenero,
                    p.FechaNacimiento AS FeNac,
                    p.DNI,
                    p.CUIT
                FROM Usuario u
                INNER JOIN Persona p
                    ON u.IdPersona = p.IdPersona
                WHERE u.Username = @user
                AND u.PassActual = @pass";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.Parameters.AddWithValue("@pass", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                    SesionUsuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    SesionUsuario.Estado = reader["Estado"] != DBNull.Value && Convert.ToBoolean(reader["Estado"]);
                    SesionUsuario.IdPersona = Convert.ToInt32(reader["IdPersona"]);
                    SesionUsuario.IdRol = Convert.ToInt32(reader["IdRol"]);
                    SesionUsuario.Username = reader["Username"].ToString();
                    SesionUsuario.PrimerIngreso = reader["PrimerIngreso"] != DBNull.Value && Convert.ToBoolean(reader["PrimerIngreso"]);
                    SesionUsuario.UltimoIngreso = reader["UltimoIngreso"] != DBNull.Value? Convert.ToDateTime(reader["UltimoIngreso"]): (DateTime?)null;
                    SesionUsuario.Nombre = reader["Nombre"].ToString();
                    SesionUsuario.Apellido = reader["Apellido"].ToString();
                    SesionUsuario.DNI = reader["DNI"].ToString();
                    SesionUsuario.CUIT = reader["CUIT"].ToString();
                    SesionUsuario.Activo = reader["Activo"] != DBNull.Value && Convert.ToBoolean(reader["Activo"]);
                    SesionUsuario.Sexo = reader["Sexo"] != DBNull.Value && Convert.ToBoolean(reader["Sexo"]);
                    SesionUsuario.IdGenero = reader["IdGenero"] != DBNull.Value? Convert.ToInt32(reader["IdGenero"]): (int?)null;
                    SesionUsuario.FeNac = reader["FeNac"] != DBNull.Value? Convert.ToDateTime(reader["FeNac"]): (DateTime?)null; SesionUsuario.PreguntasCompletadas = reader["PreguntasCompletadas"] != DBNull.Value &&Convert.ToBoolean(reader["PreguntasCompletadas"]);

                    if (!SesionUsuario.Estado)
                    {
                        UsuarioBloqueado = true;
                        return false;
                    }

                    if (!SesionUsuario.Activo)
                    {
                        UsuarioBloqueado = true;
                        return false;
                    }

                    ClsRolDatos rolDatos = new ClsRolDatos();

                    SesionUsuario.Permisos = rolDatos.ObtenerPermisos(SesionUsuario.IdRol);
                    SesionUsuario.SesionActiva = true;

                        return true;

                    }
                    return false;
                }
            }
        }
    }
    public bool ExisteUsuario(string username)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string query = @"
                SELECT COUNT(*)
                FROM Usuario
                WHERE Username = @Username";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Username", username);

            con.Open();

            int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

            return cantidad > 0;
        }
    }
    public int RegistrarUsuario(ClslUsuario usuario)
    {
        int idUsuario = 0;
        string dvh = GenerarDVHUsuario(usuario);
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            con.Open();

            string verificar = @"
                SELECT COUNT(*)
                FROM Usuario
                WHERE Username = @Username";

            using (SqlCommand cmdVerificar = new SqlCommand(verificar, con))
            {
                cmdVerificar.Parameters.AddWithValue("@Username",usuario.Username);

                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    return 0;
                }
            }

            string query = @"
                INSERT INTO Usuario
                (
                    Estado,
                    IdPersona,
                    IdRol,
                    Username,
                    PassActual,
                    PrimerIngreso,
                    UltimoIngreso
                    DVH
                )
                VALUES
                (
                    @Estado,
                    @IdPersona,
                    @IdRol,
                    @Username,
                    @PassActual,
                    @PrimerIngreso,
                    @UltimoIngreso
                    @DVH
                );

                SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Estado",usuario.Estado);
                cmd.Parameters.AddWithValue("@IdPersona",usuario.IdPersona);
                cmd.Parameters.AddWithValue("@IdRol",usuario.IdRol);
                cmd.Parameters.AddWithValue("@Username",usuario.Username);
                cmd.Parameters.AddWithValue("@PassActual", usuario.PassActual);
                cmd.Parameters.AddWithValue("@PrimerIngreso", usuario.PrimerIngreso);
                cmd.Parameters.AddWithValue( "@UltimoIngreso",(object)usuario.UltimoLogin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DVH",dvh);
                idUsuario =Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        return idUsuario;
    }
    public bool CambiarPasswordPrimerIngreso( int idUsuario,string hashTemporal,string hashNueva)
    {
        using (SqlConnection conn = conexion.ObtenerConexion())
        {
            conn.Open();

            string query = @"
                UPDATE Usuario
                SET
                    PassActual = @NuevaPass,
                    PrimerIngreso = 0,
                    UltimoIngreso = GETDATE()
                WHERE
                    IdUsuario = @IdUsuario
                AND
                    PassActual = @PassTemporal";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@NuevaPass",hashNueva);
            cmd.Parameters.AddWithValue("@IdUsuario",idUsuario);
            cmd.Parameters.AddWithValue("@PassTemporal",hashTemporal);
            int filasAfectadas =cmd.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }
    public bool CambiarPasswordRecuperacion(int idUsuario, string nuevaPassword)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            con.Open();

            SqlTransaction trans = con.BeginTransaction();

            try
            {
                string sqlAntigua = @"
                    INSERT INTO UsuarioPassAntigua
                    (
                        IdUsuario,
                        PassAntigua
                    )
                    SELECT
                        IdUsuario,
                        PassActual
                    FROM Usuario
                    WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmdAntigua = new SqlCommand(sqlAntigua, con, trans))
                {
                    cmdAntigua.Parameters.AddWithValue( "@IdUsuario", idUsuario);
                    cmdAntigua.ExecuteNonQuery();
                }

                string sqlNueva = @"
                    UPDATE Usuario
                    SET
                        PassActual = @NuevaPassword,
                        UltimoIngreso = GETDATE()
                    WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmdNueva = new SqlCommand(sqlNueva, con, trans))
                {
                    cmdNueva.Parameters.AddWithValue( "@NuevaPassword", nuevaPassword);
                    cmdNueva.Parameters.AddWithValue( "@IdUsuario", idUsuario);

                    int filas = cmdNueva.ExecuteNonQuery();

                    trans.Commit();

                    return filas > 0;
                }
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
    }
    public bool PasswordUsadaUltimasTres(int idUsuario,string nuevaPassword)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"
                SELECT TOP 3
                    PassAntigua
                FROM UsuarioPassAntigua
                WHERE IdUsuario = @IdUsuario
                ORDER BY IdPass DESC";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@IdUsuario",idUsuario);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["PassAntigua"].ToString() == nuevaPassword)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
    }
    public string ObtenerUltimaPasswordAntigua(int idUsuario)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"
                SELECT TOP 1 PassAntigua
                FROM UsuarioPassAntigua
                WHERE IdUsuario = @IdUsuario
                ORDER BY IdPass DESC";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue( "@IdUsuario",idUsuario);

            con.Open();

            object resultado = cmd.ExecuteScalar();

            if (resultado == null)
            { 
                return ""; 
            } 

            return resultado.ToString();
        }
    }
    public DataTable ObtenerUsuarios()
    {
        using (SqlConnection conn = conexion.ObtenerConexion())
        {
            conn.Open();

            string query = @"
                SELECT
                    u.IdPersona,
                    u.Username
                FROM Usuario u
                ORDER BY u.Username";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
    }
    public ClsPersona ObtenerPersonaPorId(int idPersona)
    {
        using (SqlConnection conn = conexion.ObtenerConexion())
        {
            conn.Open();

            string query = @"
                SELECT
                    p.IdPersona,
                    p.Nombre,
                    p.Apellido,
                    p.DNI,
                    p.CUIT,
                    p.Sexo,
                    p.IdGenero,
                    p.FechaNacimiento AS FeNac,
                    p.Activo,
                    u.IdRol
                FROM Persona p
                LEFT JOIN Usuario u
                    ON u.IdPersona = p.IdPersona
                WHERE p.IdPersona = @IdPersona";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IdPersona", idPersona);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ClsPersona
                        {
                            IdPersona = Convert.ToInt32(reader["IdPersona"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            DNI = reader["DNI"].ToString(),
                            CUIT = reader["CUIT"].ToString(),
                            Sexo = reader["Sexo"] != DBNull.Value? Convert.ToBoolean(reader["Sexo"]) : false,
                            IdGenero = reader["IdGenero"] != DBNull.Value? Convert.ToInt32(reader["IdGenero"]): 0,
                            FeNac = reader["FeNac"] != DBNull.Value? Convert.ToDateTime(reader["FeNac"]): DateTime.MinValue,
                            Activo = reader["Activo"] != DBNull.Value&& Convert.ToBoolean(reader["Activo"]),
                            IdRol = reader["IdRol"] != DBNull.Value ? Convert.ToInt32(reader["IdRol"]): 0
                        };
                    }
                }
            }

            return null;
        }
    }
    public int ObtenerIdUsuarioPorUsername(string username)
    {
        using (SqlConnection con =conexion.ObtenerConexion())
        {
            string sql = @"
                SELECT IdUsuario
                FROM Usuario
                WHERE Username = @Username";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Username",username);

            con.Open();

            object resultado =cmd.ExecuteScalar();

            if (resultado == null)
            {
                return 0;
            }  

            return Convert.ToInt32(resultado);
        }
    }
    public string ObtenerPreguntaUsuario( int idUsuario)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"
                SELECT TOP 1
                    ps.Pregunta
                FROM RespuestaSeguridad rs
                INNER JOIN PreguntaSeguridad ps
                    ON rs.IdPregunta = ps.IdPregunta
                WHERE rs.IdUsuario = @IdUsuario
                ORDER BY rs.IdPregunta";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue( "@IdUsuario",idUsuario);

            con.Open();

            object resultado =cmd.ExecuteScalar();

            if (resultado == null)
            {
                return ""; 
            }  

            return resultado.ToString();
        }
    }//revisar quedo asi por el cambio de la bd
    public bool ValidarRespuestaSeguridad(int idUsuario,string respuesta)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"
                SELECT COUNT(*)
                FROM RespuestaSeguridad
                WHERE IdUsuario = @IdUsuario
                AND Respuesta = @Respuesta";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue( "@IdUsuario", idUsuario);
            cmd.Parameters.AddWithValue( "@Respuesta", respuesta);

            con.Open();

            int cantidad = Convert.ToInt32( cmd.ExecuteScalar());

            return cantidad > 0;
        }
    }
    public string ObtenerUsername(int idUsuario)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"
                SELECT Username
                FROM Usuario
                WHERE IdUsuario = @IdUsuario";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue( "@IdUsuario", idUsuario);

            con.Open();

            object resultado = cmd.ExecuteScalar();

            if (resultado == null)
            { 
                return ""; 
            }

            return resultado.ToString();
        }
    }
    public bool ExistePersonaDatos(string dni,string cuit,string nombre,string apellido,int idPersonaActual)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string sql = @"
                SELECT COUNT(*)
                FROM Persona
                WHERE (DNI = @DNI OR CUIT = @CUIT)
                AND IdPersona <> @IdPersona";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue( "@DNI", dni);
            cmd.Parameters.AddWithValue( "@CUIT", cuit);
            cmd.Parameters.AddWithValue( "@IdPersona", idPersonaActual);

            con.Open();

            int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

            return cantidad > 0;
        }
    }//revisar quedo o la bd anterior
    public bool ExisteUsuarioPorIdPersona(int idPersona)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            con.Open();

            string query = @"
                SELECT COUNT(*)
                FROM Usuario
                WHERE IdPersona = @IdPersona";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@IdPersona", idPersona);

                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                return cantidad > 0;
            }
        }
    }
    public int ObtenerIdRolPorPersona(int idPersona)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string consulta = @"
                SELECT U.IdRol
                FROM Usuario AS U
                WHERE U.IdPersona = @IdPersona";

            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@IdPersona", idPersona);

            con.Open();

            object resultado = cmd.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
                return 0;

            return Convert.ToInt32(resultado);
        }
    }
    private string GenerarDVHUsuario(ClslUsuario usuario)
    {
        string cadena =
            usuario.Estado.ToString() +
            usuario.IdPersona.ToString() +
            usuario.IdRol.ToString() +
            (usuario.Username ?? "") +
            (usuario.PassActual ?? "") +
            usuario.PrimerIngreso.ToString() +
            (usuario.UltimoLogin?.ToString() ?? "");

        return ClsDigitoVerificador
            .GenerarHash(cadena);
    }
    public void RecalcularDVHUsuarios()
    {
        using (SqlConnection con =
            conexion.ObtenerConexion())
        {
            con.Open();

            string sql =
            @"SELECT
            IdUsuario,
            Estado,
            IdPersona,
            IdRol,
            Username,
            PassActual,
            PrimerIngreso,
            UltimoIngreso
          FROM Usuario
          WHERE DVH IS NULL";

            using (SqlCommand cmd =
                new SqlCommand(sql, con))
            {
                using (SqlDataReader dr =
                    cmd.ExecuteReader())
                {
                    List<ClslUsuario> usuarios =
                        new List<ClslUsuario>();

                    while (dr.Read())
                    {
                        usuarios.Add(new ClslUsuario
                        {
                            IdUsuario =
                                Convert.ToInt32(dr["IdUsuario"]),
                            Estado =
                                Convert.ToBoolean(dr["Estado"]),
                            IdPersona =
                                Convert.ToInt32(dr["IdPersona"]),
                            IdRol =
                                Convert.ToInt32(dr["IdRol"]),
                            Username =
                                dr["Username"].ToString(),
                            PassActual =
                                dr["PassActual"].ToString(),
                            PrimerIngreso =
                                Convert.ToBoolean(dr["PrimerIngreso"]),
                            UltimoLogin =
                                dr["UltimoIngreso"] == DBNull.Value
                                ? null
                                : Convert.ToDateTime(dr["UltimoIngreso"])
                        });
                    }

                    dr.Close();

                    foreach (var usuario in usuarios)
                    {
                        string dvh =
                            GenerarDVHUsuario(usuario);

                        string update =
                            @"UPDATE Usuario
                          SET DVH = @DVH
                          WHERE IdUsuario = @IdUsuario";

                        using (SqlCommand updateCmd =
                            new SqlCommand(update, con))
                        {
                            updateCmd.Parameters.AddWithValue(
                                "@DVH", dvh);

                            updateCmd.Parameters.AddWithValue(
                                "@IdUsuario",
                                usuario.IdUsuario);

                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }

}

