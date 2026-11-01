using CapaEntidades.NegocioEntidades;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos.NegocioDatos
{
    public class ClsAlertaDatos
    {
        private Conexion cn = new Conexion();

        private static readonly Dictionary<string, TipoAlerta> Tipos = new Dictionary<string, TipoAlerta>
        {
            ["LOTE"] = TipoAlerta.Lote,
            ["STOCK"] = TipoAlerta.Stock,
            ["ENTREGA"] = TipoAlerta.Entrega,
            ["CAJA"] = TipoAlerta.Caja,
            ["PAGO"] = TipoAlerta.Pago,
            ["PROMOCION"] = TipoAlerta.Promocion,
            ["PRECIO"] = TipoAlerta.Precio
        };

        public List<ClsAlertaEntidad> ObtenerAlertas(int diasAvisoPagos)
        {
            List<ClsAlertaEntidad> alertas = new List<ClsAlertaEntidad>();

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerAlertas", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DiasAvisoPagos", SqlDbType.Int).Value = diasAvisoPagos;

                conexion.Open();

                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        // Un tipo nuevo en la base que la aplicación no conoce se ignora.
                        if (!Tipos.TryGetValue(lector.GetString(0), out TipoAlerta tipo))
                            continue;

                        alertas.Add(new ClsAlertaEntidad
                        {
                            Tipo = tipo,
                            Urgente = Convert.ToInt32(lector["Prioridad"]) == 1,
                            Descripcion = lector["Descripcion"].ToString(),
                            IdReferencia = Convert.ToInt32(lector["IdReferencia"])
                        });
                    }
                }
            }

            return alertas;
        }
    }
}
