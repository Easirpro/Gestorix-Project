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
    public class clsCorreoDatos
    {
        Conexion cn = new Conexion();

        public int RegistrarCorreo(ClsCorreo correo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Correo
                    (
                        Correo
                    )
                    VALUES
                    (
                        @Correo
                    );

                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue( "@Correo",correo.DireccionCorreo);

                    conexion.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public string ObtenerCorreoPorPersona(int idPersona)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT TOP 1 C.Correo
                    FROM PersonaCorreo AS PC
                    INNER JOIN Correo AS C
                        ON PC.IdCorreo = C.IdCorreo
                    WHERE PC.IdPersona = @IdPersona;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = idPersona;

                    conexion.Open();

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value) 
                    { 
                        return resultado.ToString(); 
                    }
                       

                    return "";
                }
            }
        }
        public int ObtenerIdCorreoPorPersona(int idPersona)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT PC.IdCorreo
                    FROM PersonaCorreo PC
                    WHERE PC.IdPersona = @IdPersona";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdPersona",idPersona);

                    conexion.Open();

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null) 
                    {
                        return Convert.ToInt32(resultado);
                    }

                    return 0;
                }
            }
        }
        public bool RegistrarNuevaRelacionCorreo(int idPersona,int idCorreo)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO PersonaCorreo
                    (
                        IdPersona,
                        IdCorreo
                    )
                    VALUES
                    (
                        @IdPersona,
                        @IdCorreo
                    )";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue( "@IdPersona",idPersona);
                    cmd.Parameters.AddWithValue( "@IdCorreo", idCorreo);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool DesactivarCorreo(int idPersona)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE PersonaCorreo
                    SET Activo = 0
                    WHERE IdPersona = @IdPersona
                    AND Activo = 1";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdPersona", idPersona);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
