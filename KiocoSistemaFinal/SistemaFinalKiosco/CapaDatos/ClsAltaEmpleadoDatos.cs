using CapaEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;

namespace CapaDatos
{
    // alta completa del empleado en una sola transaccion
    public class ClsAltaEmpleadoDatos
    {
        Conexion conexion = new Conexion();

        public int RegistrarEmpleado(ClsPersona persona, ClsCorreo correo, ClsTelefono telefono, ClsDomicilio domicilio, ClslUsuario usuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmdExiste = new SqlCommand(
                            "SELECT COUNT(*) FROM Persona WHERE DNI = @DNI OR CUIT = @CUIT", con, trans);
                        cmdExiste.Parameters.AddWithValue("@DNI", persona.DNI);
                        cmdExiste.Parameters.AddWithValue("@CUIT", persona.CUIT);

                        if (Convert.ToInt32(cmdExiste.ExecuteScalar()) > 0)
                        {
                            throw new InvalidOperationException("El empleado ya está registrado.");
                        }

                        SqlCommand cmdCorreo = new SqlCommand(
                            "INSERT INTO Correo (Correo) VALUES (@Correo); SELECT SCOPE_IDENTITY();", con, trans);
                        cmdCorreo.Parameters.AddWithValue("@Correo", correo.DireccionCorreo);
                        int idCorreo = Convert.ToInt32(cmdCorreo.ExecuteScalar());

                        SqlCommand cmdTelefono = new SqlCommand(
                            "INSERT INTO Telefono (NumTelefono, IdTipo) VALUES (@NumTelefono, @IdTipo); SELECT SCOPE_IDENTITY();", con, trans);
                        cmdTelefono.Parameters.AddWithValue("@NumTelefono", telefono.NumTelefono);
                        cmdTelefono.Parameters.AddWithValue("@IdTipo", telefono.IdTipo);
                        int idTelefono = Convert.ToInt32(cmdTelefono.ExecuteScalar());

                        SqlCommand cmdDomicilio = new SqlCommand(@"
                            INSERT INTO Direccion (Calle, Altura, Piso, Departamento, IdLocalidad)
                            VALUES (@Calle, @Altura, @Piso, @Departamento, @IdLocalidad);
                            SELECT SCOPE_IDENTITY();", con, trans);
                        cmdDomicilio.Parameters.AddWithValue("@Calle", domicilio.Calle);
                        cmdDomicilio.Parameters.AddWithValue("@Altura", domicilio.Altura);
                        cmdDomicilio.Parameters.AddWithValue("@Piso", domicilio.Piso);
                        cmdDomicilio.Parameters.AddWithValue("@Departamento", domicilio.Departamento);
                        cmdDomicilio.Parameters.AddWithValue("@IdLocalidad", domicilio.IdLocalidad);
                        int idDomicilio = Convert.ToInt32(cmdDomicilio.ExecuteScalar());

                        SqlCommand cmdPersona = new SqlCommand(@"
                            INSERT INTO Persona (Activo, Nombre, Apellido, Sexo, IdGenero, FechaNacimiento, DNI, CUIT)
                            VALUES (@Activo, @Nombre, @Apellido, @Sexo, @IdGenero, @FechaNacimiento, @DNI, @CUIT);
                            SELECT SCOPE_IDENTITY();", con, trans);
                        cmdPersona.Parameters.AddWithValue("@Activo", persona.Activo);
                        cmdPersona.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        cmdPersona.Parameters.AddWithValue("@Apellido", persona.Apellido);
                        cmdPersona.Parameters.AddWithValue("@Sexo", persona.Sexo);
                        cmdPersona.Parameters.AddWithValue("@IdGenero", persona.IdGenero);
                        cmdPersona.Parameters.AddWithValue("@FechaNacimiento", persona.FeNac);
                        cmdPersona.Parameters.AddWithValue("@DNI", persona.DNI);
                        cmdPersona.Parameters.AddWithValue("@CUIT", persona.CUIT);
                        int idPersona = Convert.ToInt32(cmdPersona.ExecuteScalar());

                        SqlCommand cmdRelaciones = new SqlCommand(@"
                            INSERT INTO PersonaCorreo (IdPersona, IdCorreo) VALUES (@IdPersona, @IdCorreo);
                            INSERT INTO PersonaTelefono (IdPersona, IdTelefono, Activo) VALUES (@IdPersona, @IdTelefono, 1);
                            INSERT INTO PersonaDireccion (IdPersona, IdDireccion, Activo) VALUES (@IdPersona, @IdDireccion, 1);", con, trans);
                        cmdRelaciones.Parameters.AddWithValue("@IdPersona", idPersona);
                        cmdRelaciones.Parameters.AddWithValue("@IdCorreo", idCorreo);
                        cmdRelaciones.Parameters.AddWithValue("@IdTelefono", idTelefono);
                        cmdRelaciones.Parameters.AddWithValue("@IdDireccion", idDomicilio);
                        cmdRelaciones.ExecuteNonQuery();

                        SqlCommand cmdUsername = new SqlCommand(
                            "SELECT COUNT(*) FROM Usuario WHERE Username = @Username", con, trans);
                        cmdUsername.Parameters.AddWithValue("@Username", usuario.Username);

                        if (Convert.ToInt32(cmdUsername.ExecuteScalar()) > 0)
                        {
                            throw new InvalidOperationException("El nombre de usuario generado ya existe. Intente nuevamente.");
                        }

                        usuario.IdPersona = idPersona;

                        SqlCommand cmdUsuario = new SqlCommand(@"
                            INSERT INTO Usuario (Estado, IdPersona, IdRol, Username, PassActual, PrimerIngreso, UltimoIngreso, DVH)
                            VALUES (@Estado, @IdPersona, @IdRol, @Username, @PassActual, @PrimerIngreso, @UltimoIngreso, @DVH);
                            SELECT SCOPE_IDENTITY();", con, trans);
                        cmdUsuario.Parameters.AddWithValue("@Estado", usuario.Estado);
                        cmdUsuario.Parameters.AddWithValue("@IdPersona", idPersona);
                        cmdUsuario.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                        cmdUsuario.Parameters.AddWithValue("@Username", usuario.Username);
                        cmdUsuario.Parameters.AddWithValue("@PassActual", usuario.PassActual);
                        cmdUsuario.Parameters.AddWithValue("@PrimerIngreso", usuario.PrimerIngreso);
                        cmdUsuario.Parameters.AddWithValue("@UltimoIngreso", (object)usuario.UltimoLogin ?? DBNull.Value);
                        cmdUsuario.Parameters.AddWithValue("@DVH", new ClsUsuarioDatos().GenerarDVHUsuario(usuario));
                        int idUsuario = Convert.ToInt32(cmdUsuario.ExecuteScalar());

                        trans.Commit();

                        return idUsuario;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
