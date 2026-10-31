using CapaLogica.NegocioLogica;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaVista
{
    // Detalle de una venta: datos generales, productos vendidos, pagos y observaciones.
    // Reemplaza al cuadro de mensaje anterior, que no mostraba los productos y mostraba los pagos en cero.
    public partial class frmDetalleVenta : Form
    {
        private readonly ClsGestorVentaLogica logica = new ClsGestorVentaLogica();

        // venta: la fila del listado de frmVentas (ObtenerVentasListado).
        public frmDetalleVenta(DataRow venta)
        {
            InitializeComponent();

            MostrarDatosGenerales(venta);
            CargarProductosYPagos(Convert.ToInt32(venta["IdVenta"]));
        }

        private void MostrarDatosGenerales(DataRow venta)
        {
            int idVenta = Convert.ToInt32(venta["IdVenta"]);
            bool anulada = venta["Anulada"] != DBNull.Value && Convert.ToBoolean(venta["Anulada"]);

            lblTitulo.Text = "Venta N.º " + idVenta;
            Text = "Detalle de la venta N.º " + idVenta;

            lblEstado.Text = anulada ? "ANULADA" : "Activa";
            lblEstado.ForeColor = anulada ? Color.Firebrick : Color.SeaGreen;
            lblEstado.Left = lblTitulo.Right + 10;

            lblFecha.Text = "Fecha: " + Convert.ToDateTime(venta["FechaHora"]).ToString("dd/MM/yyyy HH:mm");
            lblCajero.Text = "Cajero: " + (string.IsNullOrWhiteSpace(venta["Cajero"]?.ToString()) ? "Sin dato" : venta["Cajero"]);
            lblCaja.Text = "Caja: " + (venta["IdSesionCaja"] == DBNull.Value ? "Sin dato" : "N.º " + venta["IdSesionCaja"]);

            lblTotal.Text = Convert.ToDecimal(venta["Total"]).ToString("C2");

            if (anulada)
            {
                lblTotal.ForeColor = Color.Firebrick;
                lblTotalTexto.Text = "Total (venta anulada)";
            }

            StringBuilder notas = new StringBuilder();

            string observaciones = venta["Observaciones"]?.ToString() ?? "";
            string motivo = venta["MotivoAnulacion"]?.ToString() ?? "";

            if (!string.IsNullOrWhiteSpace(observaciones))
                notas.AppendLine("Observaciones: " + observaciones);

            if (!string.IsNullOrWhiteSpace(motivo))
                notas.AppendLine("Motivo de anulación: " + motivo);

            txtNotas.Text = notas.Length > 0 ? notas.ToString().TrimEnd() : "Sin observaciones ni motivo de anulación.";
        }
        private void CargarProductosYPagos(int idVenta)
        {
            try
            {
                DataTable productos = logica.ObtenerProductosVenta(idVenta);

                foreach (DataRow fila in productos.Rows)
                {
                    dgvProductos.Rows.Add(
                        fila["CodigoBarra"]?.ToString(),
                        fila["Producto"]?.ToString(),
                        Convert.ToDecimal(fila["Cantidad"]).ToString("0.###"),
                        Convert.ToDecimal(fila["PrecioUnitario"]).ToString("C2"),
                        Convert.ToDecimal(fila["Subtotal"]).ToString("C2"));
                }

                lblProductos.Text = "Productos (" + productos.Rows.Count + ")";

                DataTable pagos = logica.ObtenerPagosVenta(idVenta);

                foreach (DataRow fila in pagos.Rows)
                {
                    dgvPagos.Rows.Add(fila["Medio"]?.ToString(), Convert.ToDecimal(fila["Monto"]).ToString("C2"));
                }

                if (pagos.Rows.Count == 0)
                {
                    dgvPagos.Rows.Add("Sin datos de pago", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los productos o los pagos de la venta.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvProductos.ClearSelection();
            dgvPagos.ClearSelection();
        }
    }
}
