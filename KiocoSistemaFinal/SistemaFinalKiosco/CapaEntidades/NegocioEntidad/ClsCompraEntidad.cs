using System;
using System.Collections.Generic;

namespace CapaEntidades.NegocioEntidades
{
    public class ClsCompraEntidad
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public decimal SubtotalSinIVA { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }
        public int? IdUsuario { get; set; }
        public string CondicionPago { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? IdMetodoPago { get; set; }
        public int? IdSesionCaja { get; set; }
        public List<ClsDetalleCompraEntidad> Detalles { get; set; }
    }
    public class ClsDetalleCompraEntidad
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioSinIVA { get; set; }
        public decimal PorcentajeIVA { get; set; }
        public decimal Total { get; set; }
    }
}