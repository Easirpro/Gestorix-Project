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
    public class ClsObtenerProvincia
    {
        Conexion cn = new Conexion();

        public ClsTraeProvincia ObtenerProvincia(int idProvincia)
        {
            ClsTraeProvincia provincia = null;

            SqlConnection conexion = cn.ObtenerConexion();

            string consulta = @"
                SELECT
                    IdProvincia,
                    NomProvincia
                FROM Provincia
                WHERE IdProvincia = @IdProvincia";

            SqlCommand cmd =new SqlCommand( consulta, conexion);

            cmd.Parameters.Add("@IdProvincia", System.Data.SqlDbType.Int).Value = idProvincia;

            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                provincia = new ClsTraeProvincia();
                provincia.IdProvincia = Convert.ToInt32( reader["IdProvincia"]);
                provincia.NomProvincia = reader["NomProvincia"].ToString();
            }

            reader.Close();
            conexion.Close();

            return provincia;
        }
    }

}
