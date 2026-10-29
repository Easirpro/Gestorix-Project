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
    public class ClsBalanceDatos
    {
        private Conexion cn = new Conexion();

        // sp_BalanceResumen devuelve dos resultados:
        //   Tables[0] = resumen (Orden, Seccion, Concepto, Importe)
        //   Tables[1] = indicadores (una sola fila)
        public DataSet ObtenerResumen(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_BalanceResumen", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataSet datos = new DataSet();
                        adaptador.Fill(datos);
                        return datos;
                    }
                }
            }
        }

        public DataTable ObtenerPorMedioPago(DateTime desde, DateTime hasta)
        {
            return EjecutarConsultaPorFechas("sp_BalancePorMedioPago", desde, hasta);
        }

        public DataTable ObtenerPorDia(DateTime desde, DateTime hasta)
        {
            return EjecutarConsultaPorFechas("sp_BalancePorDia", desde, hasta);
        }

        public DataTable ObtenerPorEmpleado(DateTime desde, DateTime hasta)
        {
            return EjecutarConsultaPorFechas("sp_BalancePorEmpleado", desde, hasta);
        }

        public DataTable ObtenerPorProducto(DateTime desde, DateTime hasta)
        {
            return EjecutarConsultaPorFechas("sp_BalancePorProducto", desde, hasta);
        }

        public DataTable ObtenerPorPromocion(DateTime desde, DateTime hasta)
        {
            return EjecutarConsultaPorFechas("sp_BalancePorPromocion", desde, hasta);
        }

        // tipo: "I" ingresos, "E" egresos, null todos. Los null no filtran.
        public DataTable ObtenerDetalle(DateTime desde, DateTime hasta, string tipo,
                                        int? idMetodoPago, int? idUsuario)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_BalanceDetalle", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date);
                    cmd.Parameters.AddWithValue("@Tipo",
                        string.IsNullOrWhiteSpace(tipo) ? (object)DBNull.Value : tipo);
                    cmd.Parameters.AddWithValue("@IdMetodoPago",
                        idMetodoPago.HasValue ? (object)idMetodoPago.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdUsuario",
                        idUsuario.HasValue ? (object)idUsuario.Value : DBNull.Value);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        // Todos los SP del balance (salvo el detalle) reciben solo @Desde y @Hasta.
        private DataTable EjecutarConsultaPorFechas(string procedimiento, DateTime desde, DateTime hasta)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(procedimiento, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date);

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
