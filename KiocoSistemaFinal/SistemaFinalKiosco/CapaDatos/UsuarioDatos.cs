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

    public ClsUsuarioLogin ObtenerUsuarioLogin(string usuario)
    {
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
                    u.PassActual,
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
                WHERE u.Username = @user";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@user", usuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new ClsUsuarioLogin
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Estado = reader["Estado"] != DBNull.Value && Convert.ToBoolean(reader["Estado"]),
                        IdPersona = Convert.ToInt32(reader["IdPersona"]),
                        IdRol = Convert.ToInt32(reader["IdRol"]),
                        Username = reader["Username"].ToString(),
                        PassActual = reader["PassActual"].ToString(),
                        PrimerIngreso = reader["PrimerIngreso"] != DBNull.Value && Convert.ToBoolean(reader["PrimerIngreso"]),
                        UltimoIngreso = reader["UltimoIngreso"] != DBNull.Value ? Convert.ToDateTime(reader["UltimoIngreso"]) : (DateTime?)null,
                        PreguntasCompletadas = reader["PreguntasCompletadas"] != DBNull.Value && Convert.ToBoolean(reader["PreguntasCompletadas"]),
                        Activo = reader["Activo"] != DBNull.Value && Convert.ToBoolean(reader["Activo"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Sexo = reader["Sexo"] != DBNull.Value && Convert.ToBoolean(reader["Sexo"]),
                        IdGenero = reader["IdGenero"] != DBNull.Value ? Convert.ToInt32(reader["IdGenero"]) : (int?)null,
                        FeNac = reader["FeNac"] != DBNull.Value ? Convert.ToDateTime(reader["FeNac"]) : (DateTime?)null,
                        DNI = reader["DNI"].ToString(),
                        CUIT = reader["CUIT"].ToString()
                    };
                }
            }
        }
    }
    public void RegistrarIngresoExitoso(ClsUsuarioLogin usuario, DateTime fechaIngreso)
    {
        string dvh = GenerarDVHUsuario(new ClslUsuario
        {
            Estado = usuario.Estado,
            IdPersona = usuario.IdPersona,
            IdRol = usuario.IdRol,
            Username = usuario.Username,
            PassActual = usuario.PassActual,
            PrimerIngreso = usuario.PrimerIngreso,
            UltimoLogin = fechaIngreso
        });

        using (SqlConnection conn = conexion.ObtenerConexion())
        {
            conn.Open();

            string query = @"
                UPDATE Usuario
                SET
                    UltimoIngreso = @UltimoIngreso,
                    DVH = @DVH
                WHERE IdUsuario = @IdUsuario";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UltimoIngreso", fechaIngreso);
                cmd.Parameters.AddWithValue("@DVH", dvh);
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

                cmd.ExecuteNonQuery();
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
                    UltimoIngreso,
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
                    @UltimoIngreso,
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

            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn, trans);

                cmd.Parameters.AddWithValue("@NuevaPass",hashNueva);
                cmd.Parameters.AddWithValue("@IdUsuario",idUsuario);
                cmd.Parameters.AddWithValue("@PassTemporal",hashTemporal);
                int filasAfectadas =cmd.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    trans.Rollback();
                    return false;
                }

                using (SqlCommand cmdAntigua = new SqlCommand(@"
                    INSERT INTO UsuarioPassAntigua (IdUsuario, PassAntigua)
                    VALUES (@IdUsuario, @PassTemporal)", conn, trans))
                {
                    cmdAntigua.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmdAntigua.Parameters.AddWithValue("@PassTemporal", hashTemporal);
                    cmdAntigua.ExecuteNonQuery();
                }

                ActualizarDVHUsuario(idUsuario, conn, trans);

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
    public bool EsPasswordActual(int idUsuario, string hashPassword)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(*)
                FROM Usuario
                WHERE IdUsuario = @IdUsuario
                  AND PassActual = @PassActual", con);

            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@PassActual", hashPassword);

            con.Open();

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
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

                    if (filas > 0)
                    {
                        ActualizarDVHUsuario(idUsuario, con, trans);
                    }

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
    public bool ExistePersonaDatos(string dni,string cuit,int idPersonaActual)
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
    }
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
    // misma condicion que el login
    public bool UsuarioHabilitado(int idUsuario)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string consulta = @"
                SELECT COUNT(*)
                FROM Usuario AS U
                INNER JOIN Persona AS P ON P.IdPersona = U.IdPersona
                WHERE U.IdUsuario = @IdUsuario
                  AND U.Estado = 1
                  AND P.Activo = 1";

            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

            con.Open();

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
    public int ContarAdministradoresActivos(int idRolAdministrador, int idPersonaExcluida)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            string consulta = @"
                SELECT COUNT(*)
                FROM Usuario AS U
                INNER JOIN Persona AS P ON P.IdPersona = U.IdPersona
                WHERE U.IdRol = @IdRol
                  AND U.Estado = 1
                  AND P.Activo = 1
                  AND U.IdPersona <> @IdPersona";

            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@IdRol", idRolAdministrador);
            cmd.Parameters.AddWithValue("@IdPersona", idPersonaExcluida);

            con.Open();

            return Convert.ToInt32(cmd.ExecuteScalar());
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
            ClsDigitoVerificador.FormatoFecha(usuario.UltimoLogin);

        return ClsDigitoVerificador
            .GenerarHash(cadena);
    }
    internal void ActualizarDVHUsuario(int idUsuario, SqlConnection con, SqlTransaction trans)
    {
        ClslUsuario usuario = null;

        string sql = @"
            SELECT
                Estado,
                IdPersona,
                IdRol,
                Username,
                PassActual,
                PrimerIngreso,
                UltimoIngreso
            FROM Usuario
            WHERE IdUsuario = @IdUsuario";

        using (SqlCommand cmd = new SqlCommand(sql, con, trans))
        {
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    usuario = new ClslUsuario
                    {
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        IdPersona = Convert.ToInt32(dr["IdPersona"]),
                        IdRol = Convert.ToInt32(dr["IdRol"]),
                        Username = dr["Username"].ToString(),
                        PassActual = dr["PassActual"].ToString(),
                        PrimerIngreso = Convert.ToBoolean(dr["PrimerIngreso"]),
                        UltimoLogin = dr["UltimoIngreso"] == DBNull.Value
                            ? null
                            : Convert.ToDateTime(dr["UltimoIngreso"])
                    };
                }
            }
        }

        if (usuario == null)
        {
            return;
        }

        string update = @"
            UPDATE Usuario
            SET DVH = @DVH
            WHERE IdUsuario = @IdUsuario";

        using (SqlCommand cmdUpdate = new SqlCommand(update, con, trans))
        {
            cmdUpdate.Parameters.AddWithValue("@DVH", GenerarDVHUsuario(usuario));
            cmdUpdate.Parameters.AddWithValue("@IdUsuario", idUsuario);

            cmdUpdate.ExecuteNonQuery();
        }
    }
    // Completa el DVH de los usuarios que no lo tienen.
    public void RecalcularDVHUsuarios()
    {
        ActualizarDVHUsuarios("WHERE DVH IS NULL");
    }
    // Recalcula el DVH de todos los usuarios (lo usa el administrador desde Verificar integridad).
    public void RecalcularDVHTodosLosUsuarios()
    {
        ActualizarDVHUsuarios("");
    }
    // Usuarios cuyo DVH guardado no coincide con el que dan sus datos actuales.
    public List<ClsInconsistenciaDVH> VerificarDVHUsuarios()
    {
        List<ClsInconsistenciaDVH> inconsistencias = new List<ClsInconsistenciaDVH>();

        using (SqlConnection con = conexion.ObtenerConexion())
        {
            con.Open();

            foreach (var (usuario, dvhGuardado) in LeerUsuariosParaDVH(con, ""))
            {
                string problema = ClsDigitoVerificador.CompararDVH(dvhGuardado, GenerarDVHUsuario(usuario));

                if (problema != null)
                {
                    inconsistencias.Add(new ClsInconsistenciaDVH
                    {
                        Tabla = "Usuario",
                        IdRegistro = usuario.IdUsuario,
                        Registro = usuario.Username,
                        Problema = problema
                    });
                }
            }
        }

        return inconsistencias;
    }
    private void ActualizarDVHUsuarios(string filtro)
    {
        using (SqlConnection con = conexion.ObtenerConexion())
        {
            con.Open();

            foreach (var (usuario, _) in LeerUsuariosParaDVH(con, filtro))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Usuario SET DVH = @DVH WHERE IdUsuario = @IdUsuario", con))
                {
                    cmd.Parameters.AddWithValue("@DVH", GenerarDVHUsuario(usuario));
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
    // Lee los usuarios con los mismos datos que usa GenerarDVHUsuario, más el DVH guardado.
    // El filtro es un texto fijo armado en esta clase (nunca viene del usuario).
    private List<(ClslUsuario Usuario, string DVH)> LeerUsuariosParaDVH(SqlConnection con, string filtro)
    {
        List<(ClslUsuario, string)> usuarios = new List<(ClslUsuario, string)>();

        string sql = @"
            SELECT IdUsuario, Estado, IdPersona, IdRol, Username, PassActual, PrimerIngreso, UltimoIngreso, DVH
            FROM Usuario " + filtro;

        using (SqlCommand cmd = new SqlCommand(sql, con))
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                ClslUsuario usuario = new ClslUsuario
                {
                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                    Estado = Convert.ToBoolean(dr["Estado"]),
                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                    IdRol = Convert.ToInt32(dr["IdRol"]),
                    Username = dr["Username"].ToString(),
                    PassActual = dr["PassActual"].ToString(),
                    PrimerIngreso = Convert.ToBoolean(dr["PrimerIngreso"]),
                    UltimoLogin = dr["UltimoIngreso"] == DBNull.Value ? null : Convert.ToDateTime(dr["UltimoIngreso"])
                };

                usuarios.Add((usuario, dr["DVH"] == DBNull.Value ? null : dr["DVH"].ToString()));
            }
        }

        return usuarios;
    }

}

