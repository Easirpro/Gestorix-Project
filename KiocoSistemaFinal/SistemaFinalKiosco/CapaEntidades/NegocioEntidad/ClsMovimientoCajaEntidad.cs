using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.NegocioEntidad
{
    // Ingreso o egreso manual de caja (sp_RegistrarMovimientoCaja).
    public class ClsMovimientoCajaEntidad
    {
        public int IdMovimientoCaja { get; set; }
        public int IdSesionCaja { get; set; }
        public int IdConceptoCaja { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal Importe { get; set; }
        public string Observacion { get; set; }
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }   // solo vales/adelantos y sueldos
    }
}
