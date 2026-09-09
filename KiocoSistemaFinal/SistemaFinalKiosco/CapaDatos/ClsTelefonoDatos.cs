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
    public class clsTelefonoDatos
    {
        Conexion cn = new Conexion();

        public int RegistrarTelefono(ClsTelefono telefono)
        {
            int idTelefono = 0;

            SqlConnection conexion = cn.ObtenerConexion();

            string consulta = @"INSERT INTO Telefono 
                        (NumTelefono, IdTipo) 
                        VALUES 
                        (@NumTelefono, @IdTipo);

                        SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(consulta, conexion);

            cmd.Parameters.AddWithValue("@NumTelefono", telefono.NumTelefono);
            cmd.Parameters.AddWithValue("@IdTipo", telefono.IdTipo);

            conexion.Open();

            idTelefono = Convert.ToInt32(cmd.ExecuteScalar());

            conexion.Close();

            return idTelefono;


        }
    }
}
