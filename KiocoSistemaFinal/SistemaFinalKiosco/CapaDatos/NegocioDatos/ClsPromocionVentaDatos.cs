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
    public static class ClsPromocionVentaDatos
    {
        public static void AgregarParametroPromociones(SqlCommand cmd, List<ClsPromocionVentaEntidad> promociones)
        {
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
