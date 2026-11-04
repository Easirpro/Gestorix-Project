using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    public class ClsSesionCajaEntidad
    {
        public int IdSesionCaja { get; set; }
        public int IdCaja { get; set; }
        public DateTime FechaApertura { get; set; }
        public int IdUsuarioApertura { get; set; }
        public string UsuarioApertura { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal IngresosEfectivo { get; set; }
        public decimal EgresosEfectivo { get; set; }
        public decimal EfectivoEsperado { get; set; }
        public decimal IngresosOtrosMedios { get; set; }
    }
}
