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

        private ClsSesionCajaEntidad? sesionCaja;   // null = no hay caja abierta
        private decimal precioDevolucion = 0;
        // Cuántas devoluciones se registraron sin cerrar el formulario (se pueden cargar varias).
        private int registradas = 0;

        // Motivos que, por defecto, indican que la unidad devuelta NO vuelve al stock
        private static readonly string[] MotivosSinReingreso = { "Producto fallado", "Producto vencido" };

        public frmNuevaDevolucion()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ConfigurarGrid(dgvVentas);
            ConfigurarGrid(dgvDetalle);

            Resize += (sender, e) => DistribuirAltura();
        }

        // Reparte el alto disponible entre "1. Venta" y "2. Producto" en la misma
        // proporción del diseño (205 / 155). "3. Datos" y los botones quedan abajo por Anchor.
        private void DistribuirAltura()
        {
            const int separacion = 5;

            int arriba = grpVenta.Top;
            int abajo = grpDatos.Top - separacion;
            int disponible = abajo - arriba - separacion;

            if (disponible <= 0)
                return;

            grpVenta.Height = disponible * 205 / 360;
            grpProducto.Top = grpVenta.Bottom + separacion;
            grpProducto.Height = abajo - grpProducto.Top;
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

            RefrescarCaja(mostrarError: true);

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
            grilla.AllowUserToResizeColumns = true;   // se puede ajustar el ancho de las columnas
            grilla.AllowUserToResizeRows = false;
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
                    MessageBox.Show(ClsIdioma.T("Ingrese un número de venta válido."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroVenta.Focus();
                    return;
                }
                idVenta = numero;
            }
            else if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(ClsIdioma.T("La fecha desde no puede ser mayor a la fecha hasta."), ClsIdioma.T("Aviso"),
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
                        MessageBox.Show(ClsIdioma.T("No se encontró la venta N.º ") + idVenta + ".", ClsIdioma.T("Aviso"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron obtener las ventas.\n\n") + ex.Message, ClsIdioma.T("Error"),
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
                lblCaja.Text = ClsIdioma.T("La venta está anulada: no admite devoluciones.");
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
                MessageBox.Show(ClsIdioma.T("No se pudo obtener el detalle de la venta.\n\n") + ex.Message, ClsIdioma.T("Error"),
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
            decimal vendida = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["CantidadVendida"].Value);
            precioDevolucion = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["PrecioDevolucion"].Value);

            // Productos vendidos con decimales (por peso): la cantidad acepta hasta 3 decimales.
            bool conDecimales = vendida % 1 != 0 || disponible % 1 != 0;
            nudCantidad.DecimalPlaces = conDecimales ? 3 : 0;
            nudCantidad.Increment = conDecimales ? 0.1m : 1m;

            lblPrecioValor.Text = $"$ {precioDevolucion:N2}";

            if (disponible <= 0)
            {
                nudCantidad.Minimum = 0;
                nudCantidad.Maximum = 0;
                nudCantidad.Value = 0;
                nudCantidad.Enabled = false;
                btnRegistrar.Enabled = false;
                lblCaja.Text = ClsIdioma.T("Ese producto ya se devolvió completo.");
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

        // Vuelve a leer la caja abierta y su efectivo (puede haber cambiado desde que se abrió el formulario).
        private void RefrescarCaja(bool mostrarError = false)
        {
            try
            {
                sesionCaja = logicaCaja.ObtenerSesionAbierta();
            }
            catch (Exception ex)
            {
                sesionCaja = null;

                if (mostrarError)
                {
                    MessageBox.Show(ClsIdioma.T("No se pudo obtener el estado de la caja.\n\n") + ex.Message, ClsIdioma.T("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private decimal ImporteADevolver()
        {
            return Math.Round(precioDevolucion * nudCantidad.Value, 2);
        }

        private void ActualizarImporte()
        {
            lblImporteValor.Text = rbEfectivo.Checked
                ? $"$ {ImporteADevolver():N2}"
                : ClsIdioma.T("Sin reintegro de dinero");
        }

        private void ActualizarInfoCaja()
        {
            if (rbCambio.Checked)
            {
                lblCaja.Text = ClsIdioma.T("Se entrega otra unidad: no se mueve dinero de la caja.");
                lblCaja.ForeColor = SystemColors.GrayText;
            }
            else if (sesionCaja == null)
            {
                lblCaja.Text = ClsIdioma.T("No hay caja abierta: no se puede devolver dinero.");
                lblCaja.ForeColor = Color.Firebrick;
            }
            else
            {
                lblCaja.Text = (ClsIdioma.Ingles ? $"Cash available in register: $ {sesionCaja.EfectivoEsperado:N2}" : $"Efectivo disponible en caja: $ {sesionCaja.EfectivoEsperado:N2}");
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
                MessageBox.Show(ClsIdioma.T("Seleccione la venta y el producto a devolver."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show(ClsIdioma.T("La cantidad a devolver debe ser mayor a cero."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return false;
            }

            if (cmbMotivo.SelectedIndex < 0)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione el motivo de la devolución."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMotivo.Focus();
                return false;
            }

            if (cmbMotivo.Text == "Otro" && string.IsNullOrWhiteSpace(txtObservacion.Text))
            {
                MessageBox.Show(ClsIdioma.T("Si el motivo es \"Otro\", explíquelo en Observaciones."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacion.Focus();
                return false;
            }

            if (rbEfectivo.Checked)
            {
                if (sesionCaja == null)
                {
                    MessageBox.Show(ClsIdioma.T("No hay una caja abierta. Abra la caja para devolver dinero, ") +
                                    ClsIdioma.T("o elija entregar otra unidad del producto."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (ImporteADevolver() > sesionCaja.EfectivoEsperado)
                {
                    MessageBox.Show(ClsIdioma.T("No hay efectivo suficiente en la caja ($ ") +
                                    sesionCaja.EfectivoEsperado.ToString("N2") + ").", ClsIdioma.T("Aviso"),
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
                dgvVentas.Columns["IdVenta"].HeaderText = ClsIdioma.T("N.º venta");
            }
            if (dgvVentas.Columns.Contains("FechaHora"))
            {
                dgvVentas.Columns["FechaHora"].HeaderText = ClsIdioma.T("Fecha y hora");
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
                    dgvDetalle.Columns[titulo.Key].HeaderText = ClsIdioma.T(titulo.Value);
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
            // El efectivo de la caja se valida con el dato actual, no con el de cuando se abrió el formulario.
            RefrescarCaja();
            ActualizarInfoCaja();

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

            string resumen = ClsIdioma.T("Venta N.º ") + devolucion.IdVenta +
                             ClsIdioma.T("\nProducto: ") + producto.Cells["Producto"].Value +
                             ClsIdioma.T("\nCantidad: ") + devolucion.Cantidad +
                             (devolucion.ReintegroEfectivo
                                 ? ClsIdioma.T("\nSe devuelven $ ") + ImporteADevolver().ToString("N2") + ClsIdioma.T(" en efectivo")
                                 : ClsIdioma.T("\nSe entrega otra unidad del producto")) +
                             ClsIdioma.T("\nVuelve al stock: ") + (devolucion.ReingresaStock ? ClsIdioma.T("Sí") : ClsIdioma.T("No")) +
                             ClsIdioma.T("\nMotivo: ") + devolucion.Motivo;

            DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Confirma la devolución?\n\n") + resumen,
                ClsIdioma.T("Confirmar devolución"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                devolucion = logica.RegistrarDevolucion(devolucion);
                registradas++;

                MessageBox.Show(ClsIdioma.T("La devolución se registró correctamente.\n\n") +
                                ClsIdioma.T("Devolución N.º ") + devolucion.IdDevolucion +
                                (devolucion.ReintegroEfectivo
                                    ? ClsIdioma.T("\nImporte devuelto: $ ") + devolucion.ImporteDevuelto.ToString("N2")
                                    : ClsIdioma.T("\nCambio por otra unidad")) +
                                ClsIdioma.T("\n\nPodés devolver otro producto de la misma venta o tocar Cerrar."),
                    ClsIdioma.T("Devolución registrada"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                // El formulario queda abierto en la misma venta para seguir devolviendo.
                PrepararSiguienteDevolucion(venta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo registrar la devolución.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Después de registrar: marca la venta, recarga lo que queda por devolver y vacía los datos.
        private void PrepararSiguienteDevolucion(DataGridViewRow venta)
        {
            try
            {
                venta.Cells["Estado"].Value = "Con devoluciones";
            }
            catch
            {
                // Es solo el texto de la grilla; si no se puede cambiar, se verá al volver a buscar.
            }

            RefrescarCaja();
            CargarDetalle();

            cmbMotivo.SelectedIndex = -1;
            txtObservacion.Clear();

            btnCancelar.Text = ClsIdioma.T("Cerrar");
            dgvDetalle.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = registradas > 0 ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
