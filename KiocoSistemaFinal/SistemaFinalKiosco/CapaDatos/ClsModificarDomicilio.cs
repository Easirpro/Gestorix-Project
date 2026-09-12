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
    public class ClsModificarDomicilioPer
    {
        Conexion conexion = new Conexion();

        public bool ModificarDomicilio(ClsDomicilio domicilio)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"UPDATE Direccion
                    SET
                        Calle = @Calle,
                        Altura = @Altura,
                        Piso = @Piso,
                        Departamento = @Departamento,
                        IdLocalidad = @IdLocalidad
                    WHERE IdDireccion = @IdDireccion";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@IdDireccion", domicilio.IdDireccion);
                cmd.Parameters.AddWithValue("@Calle", domicilio.Calle);
                cmd.Parameters.AddWithValue("@Altura", domicilio.Altura);
                cmd.Parameters.AddWithValue("@Piso", domicilio.Piso);
                cmd.Parameters.AddWithValue("@Departamento", domicilio.Departamento);
                cmd.Parameters.AddWithValue("@IdLocalidad", domicilio.IdLocalidad);

                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }
    }
}
