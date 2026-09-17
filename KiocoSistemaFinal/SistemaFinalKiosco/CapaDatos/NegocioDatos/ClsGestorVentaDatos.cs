using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos.NegocioDatos
{
    public class ClsGestorVentaDatos
    {
        Conexion cn = new Conexion();

        public DataTable ObtenerMetodosPago()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdMetodoPago,
                        Nombre
                    FROM MetodoPago
                    WHERE Activo = 1
                    ORDER BY Nombre;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
    }
}