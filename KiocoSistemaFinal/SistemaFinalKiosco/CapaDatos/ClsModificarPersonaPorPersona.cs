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
                    cmdPersona.Parameters.AddWithValue("@CUIT",persona.CUIT);

                    int filasPersona = cmdPersona.ExecuteNonQuery();

                    string queryUsuario = @"
                        UPDATE Usuario
                        SET IdRol = @IdRol
                        WHERE IdPersona = @IdPersona";

                    SqlCommand cmdUsuario = new SqlCommand(queryUsuario,con,trans);

                    cmdUsuario.Parameters.AddWithValue("@IdRol",idRol);
                    cmdUsuario.Parameters.AddWithValue("@IdPersona",persona.IdPersona);
                    cmdUsuario.ExecuteNonQuery();

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
    }
}

