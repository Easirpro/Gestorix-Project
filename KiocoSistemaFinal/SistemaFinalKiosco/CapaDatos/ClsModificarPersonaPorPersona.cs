using CapaEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClsModificarPorPersona
    {
        Conexion conexion = new Conexion();

        public bool ModificarPersona(ClsPersona persona, int idRol)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    string queryPersona = @"
                        UPDATE Persona
                        SET
                            Activo = @Activo,
                            Nombre = @Nombre,
                            Apellido = @Apellido,
                            Sexo = @Sexo,
                            IdGenero = @IdGenero,
                            FechaNacimiento = @FechaNacimiento,
                            DNI = @DNI,
                            CUIT = @CUIT
                        WHERE IdPersona = @IdPersona";

                    SqlCommand cmdPersona = new SqlCommand(queryPersona,con,trans);

                    cmdPersona.Parameters.AddWithValue("@IdPersona",persona.IdPersona);
                    cmdPersona.Parameters.AddWithValue("@Activo",persona.Activo);
                    cmdPersona.Parameters.AddWithValue("@Nombre",persona.Nombre);
                    cmdPersona.Parameters.AddWithValue("@Apellido",persona.Apellido);
                    cmdPersona.Parameters.AddWithValue("@Sexo",persona.Sexo);
                    cmdPersona.Parameters.AddWithValue("@IdGenero",persona.IdGenero);
                    cmdPersona.Parameters.AddWithValue("@FechaNacimiento",persona.FeNac);
                    cmdPersona.Parameters.AddWithValue("@DNI",persona.DNI);
                    cmdPersona.Parameters.AddWithValue("@CUIT",string.IsNullOrWhiteSpace(persona.CUIT) ? DBNull.Value : persona.CUIT);

                    int filasPersona = cmdPersona.ExecuteNonQuery();

                    string queryUsuario = @"
                        UPDATE Usuario
                        SET IdRol = @IdRol
                        WHERE IdPersona = @IdPersona";

                    SqlCommand cmdUsuario = new SqlCommand(queryUsuario,con,trans);

                    cmdUsuario.Parameters.AddWithValue("@IdRol",idRol);
                    cmdUsuario.Parameters.AddWithValue("@IdPersona",persona.IdPersona);
                    cmdUsuario.ExecuteNonQuery();

                    SqlCommand cmdIdUsuario = new SqlCommand("SELECT IdUsuario FROM Usuario WHERE IdPersona = @IdPersona", con, trans);
                    cmdIdUsuario.Parameters.AddWithValue("@IdPersona", persona.IdPersona);

                    object idUsuario = cmdIdUsuario.ExecuteScalar();

                    if (idUsuario != null && idUsuario != DBNull.Value)
                    {
                        new ClsUsuarioDatos().ActualizarDVHUsuario(Convert.ToInt32(idUsuario), con, trans);
                    }

                    trans.Commit();

                    return filasPersona > 0;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        // persona, rol, domicilio, telefono y correo: todo o nada
        public void ModificarEmpleado(ClsPersona persona, int idRol, ClsDomicilio domicilio, ClsTelefono telefono, string correoNuevo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmdPersona = new SqlCommand(@"
                            UPDATE Persona
                            SET Activo = @Activo, Nombre = @Nombre, Apellido = @Apellido, Sexo = @Sexo,
                                IdGenero = @IdGenero, FechaNacimiento = @FechaNacimiento, DNI = @DNI, CUIT = @CUIT
                            WHERE IdPersona = @IdPersona", con, trans);
                        cmdPersona.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                        cmdPersona.Parameters.AddWithValue("@Activo", persona.Activo);
                        cmdPersona.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        cmdPersona.Parameters.AddWithValue("@Apellido", persona.Apellido);
                        cmdPersona.Parameters.AddWithValue("@Sexo", persona.Sexo);
                        cmdPersona.Parameters.AddWithValue("@IdGenero", persona.IdGenero);
                        cmdPersona.Parameters.AddWithValue("@FechaNacimiento", persona.FeNac);
                        cmdPersona.Parameters.AddWithValue("@DNI", persona.DNI);
                        cmdPersona.Parameters.AddWithValue("@CUIT", string.IsNullOrWhiteSpace(persona.CUIT) ? DBNull.Value : persona.CUIT);

                        if (cmdPersona.ExecuteNonQuery() == 0)
                        {
                            throw new InvalidOperationException("No se encontró la persona a modificar.");
                        }

                        SqlCommand cmdRol = new SqlCommand(
                            "UPDATE Usuario SET IdRol = @IdRol WHERE IdPersona = @IdPersona; SELECT IdUsuario FROM Usuario WHERE IdPersona = @IdPersona;", con, trans);
                        cmdRol.Parameters.AddWithValue("@IdRol", idRol);
                        cmdRol.Parameters.AddWithValue("@IdPersona", persona.IdPersona);

                        object idUsuario = cmdRol.ExecuteScalar();

                        if (idUsuario != null && idUsuario != DBNull.Value)
                        {
                            new ClsUsuarioDatos().ActualizarDVHUsuario(Convert.ToInt32(idUsuario), con, trans);
                        }

                        // IdDireccion 0: la persona no tenia domicilio, se crea
                        SqlCommand cmdDomicilio = new SqlCommand(domicilio.IdDireccion > 0
                            ? @"UPDATE Direccion
                                SET Calle = @Calle, Altura = @Altura, Piso = @Piso, Departamento = @Departamento, IdLocalidad = @IdLocalidad
                                WHERE IdDireccion = @IdDireccion"
                            : @"INSERT INTO Direccion (Calle, Altura, Piso, Departamento, IdLocalidad)
                                VALUES (@Calle, @Altura, @Piso, @Departamento, @IdLocalidad);
                                INSERT INTO PersonaDireccion (IdPersona, IdDireccion, Activo) VALUES (@IdPersona, SCOPE_IDENTITY(), 1);", con, trans);
                        cmdDomicilio.Parameters.AddWithValue("@IdDireccion", domicilio.IdDireccion);
                        cmdDomicilio.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                        cmdDomicilio.Parameters.AddWithValue("@Calle", domicilio.Calle);
                        cmdDomicilio.Parameters.AddWithValue("@Altura", domicilio.Altura);
                        cmdDomicilio.Parameters.AddWithValue("@Piso", domicilio.Piso);
                        cmdDomicilio.Parameters.AddWithValue("@Departamento", domicilio.Departamento);
                        cmdDomicilio.Parameters.AddWithValue("@IdLocalidad", domicilio.IdLocalidad);

                        if (cmdDomicilio.ExecuteNonQuery() == 0)
                        {
                            throw new InvalidOperationException("No se pudo modificar el domicilio.");
                        }

                        // IdTelefono 0: la persona no tenia telefono, se crea
                        SqlCommand cmdTelefono = new SqlCommand(telefono.IdTelefono > 0
                            ? "UPDATE Telefono SET NumTelefono = @NumTelefono, IdTipo = @IdTipo WHERE IdTelefono = @IdTelefono"
                            : @"INSERT INTO Telefono (NumTelefono, IdTipo) VALUES (@NumTelefono, @IdTipo);
                                INSERT INTO PersonaTelefono (IdPersona, IdTelefono, Activo) VALUES (@IdPersona, SCOPE_IDENTITY(), 1);", con, trans);
                        cmdTelefono.Parameters.AddWithValue("@IdTelefono", telefono.IdTelefono);
                        cmdTelefono.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                        cmdTelefono.Parameters.AddWithValue("@NumTelefono", telefono.NumTelefono);
                        cmdTelefono.Parameters.AddWithValue("@IdTipo", telefono.IdTipo);

                        if (cmdTelefono.ExecuteNonQuery() == 0)
                        {
                            throw new InvalidOperationException("No se pudo modificar el teléfono.");
                        }

                        if (correoNuevo != null)
                        {
                            SqlCommand cmdCorreo = new SqlCommand(@"
                                DELETE FROM PersonaCorreo WHERE IdPersona = @IdPersona;
                                INSERT INTO Correo (Correo) VALUES (@Correo);
                                INSERT INTO PersonaCorreo (IdPersona, IdCorreo) VALUES (@IdPersona, SCOPE_IDENTITY());", con, trans);
                            cmdCorreo.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                            cmdCorreo.Parameters.AddWithValue("@Correo", correoNuevo);
                            cmdCorreo.ExecuteNonQuery();
                        }

                        trans.Commit();
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

