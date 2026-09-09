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
    public class ClsObtenerDomicilioPersona

    {
        Conexion cn = new Conexion();
        public ClsDomicilio ObtenerDomicilioPorPersona(int idPersona)
        {
            SqlConnection conexion = cn.ObtenerConexion();

            string consulta = @"
                SELECT
                    D.IdDireccion,
                    D.Calle,
                    D.Altura,
                    D.Piso,
                    D.Departamento,
                    D.IdLocalidad
                FROM PersonaDireccion PD
                INNER JOIN Direccion D
                    ON PD.IdDireccion = D.IdDireccion
                WHERE PD.IdPersona = @IdPersona
                AND PD.Activo = 1";

            SqlCommand cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@IdPersona", idPersona);

            conexion.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            ClsDomicilio direccion = null;

            if (dr.Read())
            {
                direccion = new ClsDomicilio();

                direccion.IdDireccion = Convert.ToInt32(dr["IdDireccion"]);
                direccion.Calle = dr["Calle"].ToString();
                direccion.Altura = Convert.ToInt32(dr["Altura"]);
                direccion.Piso = dr["Piso"].ToString();
                direccion.Departamento = dr["Departamento"].ToString();
                direccion.IdLocalidad = Convert.ToInt32(dr["IdLocalidad"]);
            }

            dr.Close();
            conexion.Close();

            return direccion;
        }
    }
}
