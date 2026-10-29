using CapaEntidades.NegocioEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.NegocioDatos
{
    // Arma el parámetro @Promociones (dbo.TipoPromocionVenta) de sp_RegistrarVenta.
    // Se usa desde el RegistrarVenta de la capa de datos de ventas, justo antes
    // de ejecutar el comando:
    //     ClsPromocionVentaDatos.AgregarParametroPromociones(cmd, promociones);
    public static class ClsPromocionVentaDatos
    {
        public static void AgregarParametroPromociones(SqlCommand cmd, List<ClsPromocionVentaEntidad> promociones)
        {
            // Sin promociones no se envía el parámetro: el SP lo toma como tabla vacía.
            if (promociones == null || promociones.Count == 0)
            {
                return;
            }

            DataTable tablaPromociones = new DataTable();
            tablaPromociones.Columns.Add("IdPromocion", typeof(int));
            tablaPromociones.Columns.Add("Veces", typeof(int));
            tablaPromociones.Columns.Add("ImporteLista", typeof(decimal));
            tablaPromociones.Columns.Add("ImporteCobrado", typeof(decimal));

            foreach (ClsPromocionVentaEntidad promocion in promociones)
            {
                tablaPromociones.Rows.Add(promocion.IdPromocion, promocion.Veces,
                    Math.Round(promocion.ImporteLista, 2), Math.Round(promocion.ImporteCobrado, 2));
            }

            SqlParameter parametroPromociones = cmd.Parameters.AddWithValue("@Promociones", tablaPromociones);
            parametroPromociones.SqlDbType = SqlDbType.Structured;
            parametroPromociones.TypeName = "dbo.TipoPromocionVenta";
        }
    }
}
