namespace CapaEntidades.NegocioEntidades
{
    public enum TipoAlerta
    {
        Lote,
        Stock,
        Entrega,
        Caja,
        Pago,
        Promocion,
        Precio
    }

    public class ClsAlertaEntidad
    {
        public TipoAlerta Tipo { get; set; }
        public bool Urgente { get; set; }
        public string Descripcion { get; set; }
        public int IdReferencia { get; set; }
    }
}
