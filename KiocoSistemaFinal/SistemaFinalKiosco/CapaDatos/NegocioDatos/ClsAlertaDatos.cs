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
        public HashSet<(TipoAlerta Tipo, int IdReferencia)> ObtenerOcultas()
        {
            HashSet<(TipoAlerta, int)> ocultas = new HashSet<(TipoAlerta, int)>();

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Tipo, IdReferencia FROM dbo.AlertaOculta WHERE Hasta >= CONVERT(DATE, GETDATE())", conexion))
            {
                conexion.Open();

                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        if (Tipos.TryGetValue(lector.GetString(0), out TipoAlerta tipo))
                        {
                            ocultas.Add((tipo, lector.GetInt32(1)));
                        }
                    }
                }
            }

            return ocultas;
        }
        public void Ocultar(TipoAlerta tipo, int idReferencia, int dias, int idUsuario)
        {
            string codigo = "";

            foreach (KeyValuePair<string, TipoAlerta> par in Tipos)
            {
                if (par.Value == tipo)
                {
                    codigo = par.Key;
                }
            }

            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(@"
                DELETE FROM dbo.AlertaOculta WHERE Tipo = @Tipo AND IdReferencia = @IdReferencia;
                INSERT INTO dbo.AlertaOculta (Tipo, IdReferencia, Hasta, IdUsuario)
                VALUES (@Tipo, @IdReferencia, DATEADD(DAY, @Dias, CONVERT(DATE, GETDATE())), @IdUsuario);", conexion))
            {
                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 20).Value = codigo;
                cmd.Parameters.Add("@IdReferencia", SqlDbType.Int).Value = idReferencia;
                cmd.Parameters.Add("@Dias", SqlDbType.Int).Value = dias;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
