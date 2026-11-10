using CapaDatos.NegocioDatos;
using CapaEntidades;
using CapaEntidades.NegocioEntidades;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogica.NegocioLogica
{
    public class ClsAlertaLogica
    {
        public const int DIAS_AVISO_PAGOS = 3;

        private ClsAlertaDatos datos = new ClsAlertaDatos();

        private static readonly Dictionary<TipoAlerta, int[]> Permisos = new Dictionary<TipoAlerta, int[]>
        {
            [TipoAlerta.Lote] = new[] { 110, 111, 112, 113, 520 },
            [TipoAlerta.Stock] = new[] { 110, 111, 112, 113, 520 },
            [TipoAlerta.Entrega] = new[] { 300, 320 },
            [TipoAlerta.Caja] = new[] { 700, 740 },
            [TipoAlerta.Pago] = new[] { 420 },                        
            [TipoAlerta.Promocion] = new[] { 110, 111, 112, 113 },
            [TipoAlerta.Precio] = new[] { 110, 111, 112, 113 }
        };

        public List<ClsAlertaEntidad> ObtenerAlertas()
        {
            var ocultas = datos.ObtenerOcultas();

            return datos.ObtenerAlertas(DIAS_AVISO_PAGOS)
                .Where(a => PuedeVer(a.Tipo) && !ocultas.Contains((a.Tipo, a.IdReferencia)))
                .ToList();
        }
        public const int DIAS_OCULTAR = 7;

        // solo el administrador, por decision del proyecto
        public static bool PuedeOcultar
        {
            get { return SesionUsuario.IdRol == ClsUsuarioLogica.ID_ROL_ADMINISTRADOR && SesionUsuario.Permisos.Contains(1120); }
        }
        public void Ocultar(ClsAlertaEntidad alerta)
        {
            datos.Ocultar(alerta.Tipo, alerta.IdReferencia, DIAS_OCULTAR, SesionUsuario.IdUsuario);

            string detalle = "Alerta oculta " + DIAS_OCULTAR + " días: " + alerta.Descripcion;

            ClsRegistroSeguridad.Registrar(SesionUsuario.IdUsuario, "OCULTAR_ALERTA", detalle.Length > 255 ? detalle.Substring(0, 255) : detalle);
        }
        public static bool PuedeVer(TipoAlerta tipo)
        {
            return Permisos.TryGetValue(tipo, out int[] permisos) && permisos.Any(SesionUsuario.Permisos.Contains);
        }
    }
}
