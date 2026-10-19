using System;
using System.Collections.Generic;

namespace CapaEntidades
{
    public class ClsPromocion
    {
        public int IdPromocion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoPromocion { get; set; }
        public decimal Valor { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool Activo { get; set; }
        public bool EsRecurrente { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public List<DayOfWeek> DiasSeleccionados { get; set; } = new List<DayOfWeek>();
    }

    public class ClsDetallePromocion
    {
        public int IdDetallePromocion { get; set; }
        public int IdPromocion { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
    }
}
