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
    public class ClsObtenerLocalidad
    {
        Conexion cn = new Conexion();

        public ClsLocalidad ObtenerLocalidad(int idPersona)
        {
            ClsLocalidad localidad = null;

            SqlConnection conexion = cn.ObtenerConexion();

            string consulta = @"
                SELECT 
                    L.IdLocalidad,
                    L.NomLocalidad,
                    L.CodigoPostal,
                    L.IdPartido
                FROM PersonaDireccion PD
                INNER JOIN Direccion D
                    ON PD.IdDireccion = D.IdDireccion
                INNER JOIN Localidad L
                    ON D.IdLocalidad = L.IdLocalidad
                WHERE PD.IdPersona = @IdPersona
                AND PD.Activo = 1";

            SqlCommand cmd = new SqlCommand( consulta, conexion);

            cmd.Parameters.Add("@IdPersona", System.Data.SqlDbType.Int).Value = idPersona;

            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                localidad = new ClsLocalidad();
                localidad.IdLocalidad = Convert.ToInt32(reader["IdLocalidad"]);
                localidad.NomLocalidad =  reader["NomLocalidad"].ToString();
                localidad.CodigoPostal =  reader["CodigoPostal"].ToString();
                localidad.IdPartido = Convert.ToInt32(reader["IdPartido"]);
            }

            reader.Close();
            conexion.Close();

            return localidad;
        }
    }

}
