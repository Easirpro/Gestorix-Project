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
    public class clsDomicilioDatos
    {
        Conexion cn = new Conexion();
        public int RegistrarDomicilio(ClsDomicilio domicilio)
        {
            int idDireccion = 0;

            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Direccion
                    (
                        Calle,
                        Altura,
                        Piso,
                        Departamento,
                        IdLocalidad
                    )
                    VALUES
                    (
                        @Calle,
                        @Altura,
                        @Piso,
                        @Departamento,
                        @IdLocalidad
                    );

                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Calle", domicilio.Calle);
                    cmd.Parameters.AddWithValue("@Altura", domicilio.Altura);
                    cmd.Parameters.AddWithValue("@Piso", domicilio.Piso);
                    cmd.Parameters.AddWithValue("@Departamento", domicilio.Departamento);
                    cmd.Parameters.AddWithValue("@IdLocalidad", domicilio.IdLocalidad);

                    conexion.Open();

                    idDireccion = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return idDireccion;
        }

        
    }
}
