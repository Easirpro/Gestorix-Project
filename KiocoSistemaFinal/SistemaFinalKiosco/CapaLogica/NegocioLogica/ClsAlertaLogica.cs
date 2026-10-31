using CapaDatos.NegocioDatos;
using CapaEntidades;
using CapaEntidades.NegocioEntidades;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogica.NegocioLogica
{
    public class ClsAlertaLogica
    {
        // Días de anticipación para avisar de los pagos a proveedores.
        public const int DIAS_AVISO_PAGOS = 3;

        private ClsAlertaDatos datos = new ClsAlertaDatos();

        // Permisos con los que se ve cada tipo de alerta (alcanza con tener uno).
        private static readonly Dictionary<TipoAlerta, int[]> Permisos = new Dictionary<TipoAlerta, int[]>
        {
            [TipoAlerta.Lote] = new[] { 110, 111, 112, 113, 520 },       // administración de artículos o reposición
            [TipoAlerta.Stock] = new[] { 110, 111, 112, 113, 520 },
            [TipoAlerta.Entrega] = new[] { 300 },                         // compras
            [TipoAlerta.Caja] = new[] { 700, 740 },                       // estado o cierre de caja
            [TipoAlerta.Pago] = new[] { 420 },                            // cuenta corriente de proveedores
            [TipoAlerta.Promocion] = new[] { 110, 111, 112, 113 },        // las promociones no tienen permiso propio
            [TipoAlerta.Precio] = new[] { 110, 111, 112, 113 }
        };

        // Alertas vigentes que el usuario de la sesión puede ver.
        public List<ClsAlertaEntidad> ObtenerAlertas()
        {
            return datos.ObtenerAlertas(DIAS_AVISO_PAGOS)
                .Where(a => PuedeVer(a.Tipo))
                .ToList();
        }
        public static bool PuedeVer(TipoAlerta tipo)
        {
            return Permisos.TryGetValue(tipo, out int[] permisos) && permisos.Any(SesionUsuario.Permisos.Contains);
        }
    }
}
