using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{

    public class ClsObtenerPartido
    {
        Conexion cn = new Conexion();

        public ClsTraerPartido ObtenerPartido( int idLocalidad)
        {
            ClsTraerPartido partido = null;

            SqlConnection conexion = cn.ObtenerConexion();

            string consulta = @"
                SELECT
                    P.IdPartido,
                    P.NomPartido,
                    P.IdProvincia
                FROM Localidad L
                INNER JOIN Partido P
                    ON L.IdPartido = P.IdPartido
                WHERE L.IdLocalidad = @IdLocalidad";

            SqlCommand cmd = new SqlCommand(consulta,conexion);

            cmd.Parameters.Add( "@IdLocalidad", System.Data.SqlDbType.Int).Value = idLocalidad;

            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                partido = new ClsTraerPartido();
                partido.IdPartido = Convert.ToInt32(reader["IdPartido"]);
                partido.NomPartido = reader["NomPartido"].ToString();
                partido.IdProvincia = Convert.ToInt32(reader["IdProvincia"]);
            }

            reader.Close();
            conexion.Close();

            return partido;
        }
    }

}
