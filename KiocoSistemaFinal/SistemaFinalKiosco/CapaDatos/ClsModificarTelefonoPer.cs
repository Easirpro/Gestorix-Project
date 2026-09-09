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
    public class ClsModificarTelefonoPer
    {
        Conexion cn = new Conexion();

        public bool ModificarTelefonoPer(ClsTelefono telefono)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE Telefono
                    SET
                        NumTelefono = @NumTelefono,
                        IdTipo = @IdTipo
                    WHERE IdTelefono = @IdTelefono";

                SqlCommand cmd = new SqlCommand(consulta, conexion);

                cmd.Parameters.AddWithValue("@IdTelefono", telefono.IdTelefono);
                cmd.Parameters.AddWithValue("@NumTelefono", telefono.NumTelefono);
                cmd.Parameters.AddWithValue("@IdTipo", telefono.IdTipo);

                conexion.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}
