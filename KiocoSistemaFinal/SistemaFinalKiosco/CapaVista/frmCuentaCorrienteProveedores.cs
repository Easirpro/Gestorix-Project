using CapaLogica;
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
using CapaEntidades;
namespace CapaVista
{
    public partial class frmCuentaCorrienteProveedores : Form
    {
        private ClsPagoCompraLogica logica = new ClsPagoCompraLogica();
        private ClsGestorLogicaProveedor logicaProveedor = new ClsGestorLogicaProveedor();

        public frmCuentaCorrienteProveedores()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ClsGrilla.AjustarAlContenido(dgvCompras);
            ClsGrilla.AjustarAlContenido(dgvPagos);
            ConfigurarGrid(dgvCompras);
            ConfigurarGrid(dgvPagos);
        }

        private void frmCuentaCorrienteProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            chkTodos.Checked = true;
            CargarBotones();
            CargarCompras();
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

        private void CargarBotones()
        {
            bool permiso = SesionUsuario.Permisos.Contains(420);
            btnRegistrarPago.Enabled = permiso;
            btnAnularPago.Enabled = permiso;
        }

        private void CargarProveedores()
        {
            try
            {
                DataTable tablaProveedores = logicaProveedor.ObtenerProveedores();
                cmbProveedor.DataSource = tablaProveedores;
                cmbProveedor.DisplayMember = tablaProveedores.Columns.Contains("RazonSocial") ? "RazonSocial" : "Nombre";
                cmbProveedor.ValueMember = "IdProveedor";
                cmbProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los proveedores.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCompras()
        {
            int? idProveedor = null;

            if (!chkTodos.Checked)
            {
                if (cmbProveedor.SelectedValue == null)
                {
                    MessageBox.Show(ClsIdioma.T("Seleccione un proveedor o marque \"Todos los proveedores\"."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
            }

            try
            {
                DataTable tabla = logica.ObtenerComprasPendientes(idProveedor, chkIncluirPagadas.Checked);
                dgvCompras.DataSource = tabla;

                decimal deuda = 0;
                decimal vencido = 0;
                foreach (DataRow fila in tabla.Rows)
                {
                    decimal saldo = Convert.ToDecimal(fila["Saldo"]);
                    deuda += saldo;
                    if (Convert.ToInt32(fila["Vencida"]) == 1)
                    {
                        vencido += saldo;
                    }
                }

                lblTotalDeuda.Text = (ClsIdioma.Ingles ? $"Total debt: $ {deuda:N2}" : $"Deuda total: $ {deuda:N2}");
                lblVencido.Text = (ClsIdioma.Ingles ? $"Overdue: $ {vencido:N2}" : $"Vencido: $ {vencido:N2}");

                CargarPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron obtener las compras.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPagos()
        {
            if (dgvCompras.CurrentRow == null)
            {
                dgvPagos.DataSource = null;
                lblPagos.Text = ClsIdioma.T("Pagos de la compra seleccionada");
                return;
            }

            try
            {
                int idCompra = Convert.ToInt32(dgvCompras.CurrentRow.Cells["IdCompra"].Value);
                dgvPagos.DataSource = logica.ObtenerPagosCompra(idCompra);
                lblPagos.Text = ClsIdioma.T("Pagos de la compra N.º ") + idCompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron obtener los pagos.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void FormatearImportes(DataGridView grilla, params string[] columnas)
        {
            foreach (string columna in columnas)
            {
                if (grilla.Columns.Contains(columna))
                {
                    grilla.Columns[columna].DefaultCellStyle.Format = "N2";
                    grilla.Columns[columna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        #endregion

        #region Eventos

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            cmbProveedor.Enabled = !chkTodos.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void dgvCompras_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvCompras.Columns.Contains("Vencida"))
            {
                dgvCompras.Columns["Vencida"].Visible = false;
            }
            if (dgvCompras.Columns.Contains("IdCompra"))
            {
                dgvCompras.Columns["IdCompra"].HeaderText = ClsIdioma.T("N.º compra");
            }
            if (dgvCompras.Columns.Contains("CondicionPago"))
            {
                dgvCompras.Columns["CondicionPago"].HeaderText = ClsIdioma.T("Condición");
            }
            if (dgvCompras.Columns.Contains("FechaVencimiento"))
            {
                dgvCompras.Columns["FechaVencimiento"].HeaderText = ClsIdioma.T("Vencimiento");
                dgvCompras.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvCompras.Columns.Contains("Fecha"))
            {
                dgvCompras.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvCompras.Columns.Contains("EstadoPago"))
            {
                dgvCompras.Columns["EstadoPago"].HeaderText = ClsIdioma.T("Estado");
            }
            FormatearImportes(dgvCompras, "Total", "Pagado", "Saldo");

            foreach (DataGridViewRow fila in dgvCompras.Rows)
            {
                if (Convert.ToInt32(fila.Cells["Vencida"].Value) == 1)
                {
                    fila.DefaultCellStyle.ForeColor = Color.Firebrick;
                }
                else if (fila.Cells["EstadoPago"].Value?.ToString() == "PAGADA")
                {
                    fila.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                }
            }
        }

        private void dgvPagos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvPagos.Columns.Contains("IdPagoCompra"))
            {
                dgvPagos.Columns["IdPagoCompra"].HeaderText = ClsIdioma.T("N.º pago");
            }
            if (dgvPagos.Columns.Contains("FechaPago"))
            {
                dgvPagos.Columns["FechaPago"].HeaderText = ClsIdioma.T("Fecha");
                dgvPagos.Columns["FechaPago"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvPagos.Columns.Contains("MedioPago"))
            {
                dgvPagos.Columns["MedioPago"].HeaderText = ClsIdioma.T("Medio de pago");
            }
            if (dgvPagos.Columns.Contains("RegistradoPor"))
            {
                dgvPagos.Columns["RegistradoPor"].HeaderText = ClsIdioma.T("Registrado por");
            }
            if (dgvPagos.Columns.Contains("SalioDeCaja"))
            {
                dgvPagos.Columns["SalioDeCaja"].HeaderText = ClsIdioma.T("Salió de caja");
            }
            if (dgvPagos.Columns.Contains("Observacion"))
            {
                dgvPagos.Columns["Observacion"].HeaderText = ClsIdioma.T("Observación");
            }
            if (dgvPagos.Columns.Contains("MotivoAnulacion"))
            {
                dgvPagos.Columns["MotivoAnulacion"].HeaderText = ClsIdioma.T("Motivo anulación");
            }
            FormatearImportes(dgvPagos, "Monto");

            foreach (DataGridViewRow fila in dgvPagos.Rows)
            {
                if (fila.Cells["Estado"].Value?.ToString() == "Anulado")
                {
                    fila.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                    fila.DefaultCellStyle.Font = new Font(dgvPagos.Font, FontStyle.Strikeout);
                }
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione una compra."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvCompras.CurrentRow;
            int idCompra = Convert.ToInt32(fila.Cells["IdCompra"].Value);
            string proveedor = fila.Cells["Proveedor"].Value.ToString();
            decimal saldo = Convert.ToDecimal(fila.Cells["Saldo"].Value);

            if (saldo <= 0)
            {
                MessageBox.Show(ClsIdioma.T("La compra seleccionada ya está pagada."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (frmRegistrarPagoCompra formulario = new frmRegistrarPagoCompra(idCompra, proveedor, saldo))
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    CargarCompras();
                }
            }
        }

        private void btnAnularPago_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione el pago a anular."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvPagos.CurrentRow;

            if (fila.Cells["Estado"].Value?.ToString() == "Anulado")
            {
                MessageBox.Show(ClsIdioma.T("El pago seleccionado ya se encuentra anulado."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPago = Convert.ToInt32(fila.Cells["IdPagoCompra"].Value);
            decimal monto = Convert.ToDecimal(fila.Cells["Monto"].Value);

            string motivo = Microsoft.VisualBasic.Interaction.InputBox(ClsIdioma.T("Ingrese el motivo de la anulación:"),
                ClsIdioma.T("Anular pago"), "");

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show(ClsIdioma.T("Debe ingresar un motivo para anular el pago."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Está seguro de anular este pago?\n\n") +
                ClsIdioma.T("Pago N.º ") + idPago + "  $ " + monto.ToString("N2") + ClsIdioma.T("\nMotivo: ") + motivo,
                ClsIdioma.T("Confirmar anulación"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                logica.AnularPago(idPago, motivo.Trim(), SesionUsuario.IdUsuario);

                MessageBox.Show(ClsIdioma.T("El pago fue anulado correctamente."), ClsIdioma.T("Pago anulado"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo anular el pago.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
