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
    public class clsPersonaDatos
    {
        Conexion cn = new Conexion();

        public int RegistrarPersona(ClsPersona persona)
        {
            int idPersona = 0;

            using (SqlConnection con = cn.ObtenerConexion())
            {
                con.Open();
                
                string verificar = @"
                    SELECT COUNT(*)
                    FROM Persona
                    WHERE DNI = @DNI
                    OR CUIT = @CUIT";

                SqlCommand cmdVerificar = new SqlCommand(verificar, con);

                cmdVerificar.Parameters.AddWithValue( "@DNI",persona.DNI);
                cmdVerificar.Parameters.AddWithValue("@CUIT",persona.CUIT);
                int cantidad = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if(cantidad > 0)
                { 
                    throw new Exception("No se puede registrar la persona porque ya existe " +
                    "una persona con ese DNI o CUIT.\n\n" 
                    + "DNI: " + persona.DNI + "\n" + "CUIT: " + persona.CUIT); 
                }

                string query = @"
                    INSERT INTO Persona
                    (
                        Activo,
                        Nombre,
                        Apellido,
                        Sexo,
                        IdGenero,
                        FechaNacimiento,
                        DNI,
                        CUIT
                    )
                    VALUES
                    (
                        @Activo,
                        @Nombre,
                        @Apellido,
                        @Sexo,
                        @IdGenero,
                        @FechaNacimiento,
                        @DNI,
                        @CUIT
                    );

                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Activo",persona.Activo);
                cmd.Parameters.AddWithValue("@Nombre",persona.Nombre);
                cmd.Parameters.AddWithValue( "@Apellido", persona.Apellido);
                cmd.Parameters.AddWithValue( "@Sexo",persona.Sexo);
                cmd.Parameters.AddWithValue("@IdGenero",persona.IdGenero);
                cmd.Parameters.AddWithValue( "@FechaNacimiento",persona.FeNac);
                cmd.Parameters.AddWithValue("@DNI", persona.DNI);
                cmd.Parameters.AddWithValue("@CUIT",persona.CUIT);
                idPersona = Convert.ToInt32(cmd.ExecuteScalar());
            
            }

            return idPersona;
        }
        public int ObtenerIdPersonaPorDniOCuit(string dni, string cuit)
        {
            using (SqlConnection con = cn.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT TOP 1 IdPersona
                    FROM Persona
                    WHERE DNI = @DNI
                       OR CUIT = @CUIT";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DNI", dni);
                    cmd.Parameters.AddWithValue("@CUIT", cuit);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado == null)
                    { 
                        return 0; 
                    }
                        

                    return Convert.ToInt32(resultado);
                }
            }
        }
    }
}
