using CapaEntidades;
using CapaEntidades.NegocioEntidad;
using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmNuevaDevolucion : Form
    {
        private ClsDevolucionLogica logica = new ClsDevolucionLogica();
        private ClsCajaLogica logicaCaja = new ClsCajaLogica();

        private ClsSesionCajaEntidad sesionCaja;   // null = no hay caja abierta
        private decimal precioDevolucion = 0;

        // Motivos que, por defecto, indican que la unidad devuelta NO vuelve al stock
        private static readonly string[] MotivosSinReingreso = { "Producto fallado", "Producto vencido" };

        public frmNuevaDevolucion()
        {
            InitializeComponent();
            ConfigurarGrid(dgvVentas);
            ConfigurarGrid(dgvDetalle);
        }

        private void frmNuevaDevolucion_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            cmbMotivo.Items.Clear();
            cmbMotivo.Items.Add("Producto fallado");
            cmbMotivo.Items.Add("Producto vencido");
            cmbMotivo.Items.Add("Error en la venta");
            cmbMotivo.Items.Add("El cliente se arrepintió");
            cmbMotivo.Items.Add("Otro");
            cmbMotivo.SelectedIndex = -1;

            try
            {
                sesionCaja = logicaCaja.ObtenerSesionAbierta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener el estado de la caja.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LimpiarDatosDevolucion();
            ActualizarInfoCaja();
            CargarVentas();
        }

        #region Metodos

        private void ConfigurarGrid(DataGridView grilla)
        {
            grilla.AutoGenerateColumns = true;
            grilla.ReadOnly = true;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.MultiSelect = false;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToResizeColumns = false;
            grilla.AllowUserToOrderColumns = false;
            grilla.RowHeadersVisible = false;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarVentas()
        {
            int? idVenta = null;

            if (!string.IsNullOrWhiteSpace(txtNroVenta.Text))
            {
                if (!int.TryParse(txtNroVenta.Text.Trim(), out int numero) || numero <= 0)
                {
                    MessageBox.Show("Ingrese un número de venta válido.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroVenta.Focus();
                    return;
                }
                idVenta = numero;
            }
            else if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable tabla = logica.ObtenerVentasParaDevolucion(dtpDesde.Value.Date, dtpHasta.Value.Date, idVenta);
                dgvVentas.DataSource = tabla;

                if (tabla.Rows.Count == 0)
                {
                    dgvDetalle.DataSource = null;
                    LimpiarDatosDevolucion();

                    if (idVenta.HasValue)
                    {
                        MessageBox.Show("No se encontró la venta N.º " + idVenta + ".", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron obtener las ventas.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalle()
        {
            LimpiarDatosDevolucion();

            if (dgvVentas.CurrentRow == null)
            {
                dgvDetalle.DataSource = null;
                return;
            }

            if (dgvVentas.CurrentRow.Cells["Estado"].Value?.ToString() == "Anulada")
            {
                dgvDetalle.DataSource = null;
                lblCaja.Text = "La venta está anulada: no admite devoluciones.";
                lblCaja.ForeColor = Color.Firebrick;
                return;
            }

            try
            {
                int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["IdVenta"].Value);
                dgvDetalle.DataSource = logica.ObtenerDetalleParaDevolucion(idVenta);
                ActualizarInfoCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener el detalle de la venta.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarProducto()
        {
            if (dgvDetalle.CurrentRow == null)
            {
                LimpiarDatosDevolucion();
                return;
            }

            decimal disponible = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["CantidadDisponible"].Value);
            precioDevolucion = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["PrecioDevolucion"].Value);

            lblPrecioValor.Text = $"$ {precioDevolucion:N2}";

            if (disponible <= 0)
            {
                nudCantidad.Minimum = 0;
                nudCantidad.Maximum = 0;
                nudCantidad.Value = 0;
                nudCantidad.Enabled = false;
                btnRegistrar.Enabled = false;
                lblCaja.Text = "Ese producto ya se devolvió completo.";
                lblCaja.ForeColor = Color.Firebrick;
            }
            else
            {
                nudCantidad.Enabled = true;
                nudCantidad.Minimum = 0;
                nudCantidad.Maximum = disponible;
                nudCantidad.Value = Math.Min(1, disponible);
                btnRegistrar.Enabled = true;
                ActualizarInfoCaja();
            }

            ActualizarImporte();
        }

        private void LimpiarDatosDevolucion()
        {
            precioDevolucion = 0;
            nudCantidad.Minimum = 0;
            nudCantidad.Maximum = 0;
            nudCantidad.Value = 0;
            nudCantidad.Enabled = false;
            lblPrecioValor.Text = "$ 0,00";
            lblImporteValor.Text = "$ 0,00";
            btnRegistrar.Enabled = false;
        }

        private decimal ImporteADevolver()
        {
            return Math.Round(precioDevolucion * nudCantidad.Value, 2);
        }

        private void ActualizarImporte()
        {
            lblImporteValor.Text = rbEfectivo.Checked
                ? $"$ {ImporteADevolver():N2}"
                : "Sin reintegro de dinero";
        }

        private void ActualizarInfoCaja()
        {
            if (rbCambio.Checked)
            {
                lblCaja.Text = "Se entrega otra unidad: no se mueve dinero de la caja.";
                lblCaja.ForeColor = SystemColors.GrayText;
            }
            else if (sesionCaja == null)
            {
                lblCaja.Text = "No hay caja abierta: no se puede devolver dinero.";
                lblCaja.ForeColor = Color.Firebrick;
            }
            else
            {
                lblCaja.Text = $"Efectivo disponible en caja: $ {sesionCaja.EfectivoEsperado:N2}";
                lblCaja.ForeColor = SystemColors.GrayText;
            }
        }

        private string ArmarMotivo()
        {
            string motivo = cmbMotivo.Text.Trim();
            string observacion = txtObservacion.Text.Trim();

            return string.IsNullOrWhiteSpace(observacion) ? motivo : motivo + " - " + observacion;
        }

        private bool ValidarCampos()
        {
            if (dgvVentas.CurrentRow == null || dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la venta y el producto a devolver.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad a devolver debe ser mayor a cero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return false;
            }

            if (cmbMotivo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el motivo de la devolución.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMotivo.Focus();
                return false;
            }

            if (cmbMotivo.Text == "Otro" && string.IsNullOrWhiteSpace(txtObservacion.Text))
            {
                MessageBox.Show("Si el motivo es \"Otro\", explíquelo en Observaciones.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacion.Focus();
                return false;
            }

            if (rbEfectivo.Checked)
            {
                if (sesionCaja == null)
                {
                    MessageBox.Show("No hay una caja abierta. Abra la caja para devolver dinero, " +
                                    "o elija entregar otra unidad del producto.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (ImporteADevolver() > sesionCaja.EfectivoEsperado)
                {
                    MessageBox.Show("No hay efectivo suficiente en la caja ($ " +
                                    sesionCaja.EfectivoEsperado.ToString("N2") + ").", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Eventos

        private void btnBuscarVentas_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            SeleccionarProducto();
        }

        private void dgvVentas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvVentas.Columns.Contains("IdVenta"))
            {
                dgvVentas.Columns["IdVenta"].HeaderText = "N.º venta";
            }
            if (dgvVentas.Columns.Contains("FechaHora"))
            {
                dgvVentas.Columns["FechaHora"].HeaderText = "Fecha y hora";
                dgvVentas.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvVentas.Columns.Contains("Total"))
            {
                dgvVentas.Columns["Total"].DefaultCellStyle.Format = "N2";
                dgvVentas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            foreach (DataGridViewRow fila in dgvVentas.Rows)
            {
                if (fila.Cells["Estado"].Value?.ToString() == "Anulada")
                {
                    fila.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                }
            }
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvDetalle.Columns.Contains("IdProducto"))
            {
                dgvDetalle.Columns["IdProducto"].Visible = false;
            }

            Dictionary<string, string> titulos = new Dictionary<string, string>
            {
                { "CantidadVendida", "Vendido" },
                { "CantidadDevuelta", "Ya devuelto" },
                { "CantidadDisponible", "Puede devolver" },
                { "PrecioDevolucion", "Precio cobrado x unidad" }
            };

            foreach (KeyValuePair<string, string> titulo in titulos)
            {
                if (dgvDetalle.Columns.Contains(titulo.Key))
                {
                    dgvDetalle.Columns[titulo.Key].HeaderText = titulo.Value;
                    dgvDetalle.Columns[titulo.Key].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            if (dgvDetalle.Columns.Contains("PrecioDevolucion"))
            {
                dgvDetalle.Columns["PrecioDevolucion"].DefaultCellStyle.Format = "N2";
            }

            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (Convert.ToDecimal(fila.Cells["CantidadDisponible"].Value) <= 0)
                {
                    fila.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                }
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarImporte();
        }

        private void rbReintegro_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarImporte();
            ActualizarInfoCaja();
        }

        private void cmbMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el producto está fallado o vencido, por defecto NO vuelve al stock
            // (el usuario igual puede cambiarlo).
            chkReingresaStock.Checked = !MotivosSinReingreso.Contains(cmbMotivo.Text);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            DataGridViewRow venta = dgvVentas.CurrentRow;
            DataGridViewRow producto = dgvDetalle.CurrentRow;

            ClsDevolucionEntidad devolucion = new ClsDevolucionEntidad();
            devolucion.IdVenta = Convert.ToInt32(venta.Cells["IdVenta"].Value);
            devolucion.IdProducto = Convert.ToInt32(producto.Cells["IdProducto"].Value);
            devolucion.Cantidad = nudCantidad.Value;
            devolucion.Motivo = ArmarMotivo();
            devolucion.ReintegroEfectivo = rbEfectivo.Checked;
            devolucion.ReingresaStock = chkReingresaStock.Checked;
            devolucion.IdUsuario = SesionUsuario.IdUsuario;

            string resumen = "Venta N.º " + devolucion.IdVenta +
                             "\nProducto: " + producto.Cells["Producto"].Value +
                             "\nCantidad: " + devolucion.Cantidad +
                             (devolucion.ReintegroEfectivo
                                 ? "\nSe devuelven $ " + ImporteADevolver().ToString("N2") + " en efectivo"
                                 : "\nSe entrega otra unidad del producto") +
                             "\nVuelve al stock: " + (devolucion.ReingresaStock ? "Sí" : "No") +
                             "\nMotivo: " + devolucion.Motivo;

            DialogResult respuesta = MessageBox.Show("¿Confirma la devolución?\n\n" + resumen,
                "Confirmar devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                devolucion = logica.RegistrarDevolucion(devolucion);

                MessageBox.Show("La devolución se registró correctamente.\n\n" +
                                "Devolución N.º " + devolucion.IdDevolucion +
                                (devolucion.ReintegroEfectivo
                                    ? "\nImporte devuelto: $ " + devolucion.ImporteDevuelto.ToString("N2")
                                    : "\nCambio por otra unidad"),
                    "Devolución registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la devolución.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
