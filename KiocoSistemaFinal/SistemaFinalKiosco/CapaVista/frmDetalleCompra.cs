using System;
using System.Data;
using System.Windows.Forms;
using CapaLogica.NegocioLogica;

namespace CapaVista
{
    public partial class frmDetalleCompra : Form
    {
        private ClsCompraLogica logica = new ClsCompraLogica();

        private int idCompra;
        // Si no hay detalle, el formulario se cierra apenas termina de abrirse.
        private bool sinDetalle = false;

        public frmDetalleCompra(int idCompra)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.idCompra = idCompra;

            CargarDetalle();

            this.Load += frmDetalleCompra_Load;
        }
        // Cerrar desde el constructor destruía el formulario antes del ShowDialog y daba error.
        private void frmDetalleCompra_Load(object? sender, EventArgs e)
        {
            if (sinDetalle)
            {
                BeginInvoke(new Action(Close));
            }
        }

        #region Metodos
        private void CargarDetalle()
        {
            try
            {
                DataTable tabla = logica.ObtenerDetalleCompra(idCompra);

                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show(ClsIdioma.T("No se encontró el detalle de la compra."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    sinDetalle = true;
                    return;
                }

                DataRow primeraFila = tabla.Rows[0];

                txtProveedor.Text = primeraFila["Proveedor"].ToString();
                txtFecha.Text = Convert.ToDateTime(primeraFila["Fecha"]).ToString("dd/MM/yyyy");
                txtTipoComprobante.Text = primeraFila["TipoComprobante"].ToString();
                txtNumeroComprobante.Text = primeraFila["NumeroComprobante"].ToString();
                txtSubtotal.Text = Convert.ToDecimal(primeraFila["SubtotalSinIVA"]).ToString("N2");
                txtIVA.Text = Convert.ToDecimal(primeraFila["IVA"]).ToString("N2");
                txtTotal.Text = Convert.ToDecimal(primeraFila["Total"]).ToString("N2");
                txtObservaciones.Text = primeraFila["Observaciones"] == DBNull.Value ? "" : primeraFila["Observaciones"].ToString();
                dgvDetalle.Rows.Clear();

                foreach (DataRow fila in tabla.Rows)
                {
                    int indice = dgvDetalle.Rows.Add();

                    dgvDetalle.Rows[indice].Cells["clnCodigo"].Value = fila["CodigoBarra"].ToString();
                    dgvDetalle.Rows[indice].Cells["clnProducto"].Value = fila["Producto"].ToString();
                    dgvDetalle.Rows[indice].Cells["clnCantidad"].Value = Convert.ToDecimal(fila["Cantidad"]).ToString("N3");
                    dgvDetalle.Rows[indice].Cells["clnPrecio"].Value = Convert.ToDecimal(fila["PrecioSinIVA"]).ToString("N2");
                    dgvDetalle.Rows[indice].Cells["clnIVA"].Value = Convert.ToDecimal(fila["PorcentajeIVA"]).ToString("N2");
                    dgvDetalle.Rows[indice].Cells["clnTotal"].Value = Convert.ToDecimal(fila["TotalDetalle"]).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo cargar el detalle de la compra.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Eventos
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion



    }
}
