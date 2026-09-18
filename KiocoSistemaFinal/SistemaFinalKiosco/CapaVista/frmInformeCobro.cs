using CapaEntidades;
using CapaEntidades.NegocioEntidad;
using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
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
    public partial class frmInformeCobro : Form
    {
        private readonly decimal totalVenta;
        private decimal totalPagado = 0;
        private decimal vueltoVenta = 0;
        private readonly DataGridView carritoVenta;
        public frmInformeCobro(decimal total, DataGridView carrito)
        {
            InitializeComponent();

            totalVenta = total;
            carritoVenta = carrito;

            lblTotal.Text = $"$ {totalVenta:N2}";
            lblPagado.Text = "$ 0,00";
            lblRestante.Text = $"$ {totalVenta:N2}";
            lblVuelto.Text = "$ 0,00";

            btnConfirmar.Visible = true;
            btnConfirmar.BringToFront();

            CargarMetodosPago();

            txtMonto.Text = totalVenta.ToString("0.00");
        }

        private void CargarMetodosPago()
        {
            ClsGestorVentaLogica gestorVenta = new ClsGestorVentaLogica();

            DataTable tabla = gestorVenta.ObtenerMetodosPago();

            cmbMetodoPago.DataSource = tabla;
            cmbMetodoPago.DisplayMember = "Nombre";
            cmbMetodoPago.ValueMember = "IdMetodoPago";
            cmbMetodoPago.SelectedIndex = -1;
        }

        private void CalcularPagos()
        {
            totalPagado = 0;

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnMontoPago"].Value != null &&
                    decimal.TryParse(
                        fila.Cells["ClnMontoPago"].Value.ToString(),
                        out decimal monto))
                {
                    totalPagado += monto;
                }
            }

            decimal restante = totalVenta - totalPagado;

            lblPagado.Text = $"$ {totalPagado:N2}";
            lblRestante.Text = $"$ {Math.Max(restante, 0):N2}";

            btnConfirmar.Enabled = restante == 0;
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un método de pago.",
                    "Método de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbMetodoPago.Focus();
                return;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show(
                    "Ingrese un monto válido mayor a 0.",
                    "Monto inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMonto.SelectAll();
                txtMonto.Focus();
                return;
            }

            decimal restante = totalVenta - totalPagado;

            if (monto > restante)
            {
                MessageBox.Show(
                    $"El monto ingresado supera el saldo restante.\n\n" +
                    $"Restante: $ {restante:N2}",
                    "Monto inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMonto.SelectAll();
                txtMonto.Focus();
                return;
            }

            int idMetodoPago =
                Convert.ToInt32(cmbMetodoPago.SelectedValue);

            string metodoPago = cmbMetodoPago.Text;

            bool esEfectivo = metodoPago.Equals(
                "Efectivo",
                StringComparison.OrdinalIgnoreCase);

            if (esEfectivo)
            {
                decimal montoRecibido;

                // Si está vacío, asumimos que entregó justo
                if (string.IsNullOrWhiteSpace(txtMontoRecibido.Text))
                {
                    montoRecibido = monto;
                }
                else
                {
                    if (!decimal.TryParse(
                        txtMontoRecibido.Text,
                        out montoRecibido) ||
                        montoRecibido <= 0)
                    {
                        MessageBox.Show(
                            "Ingrese un monto recibido válido.",
                            "Monto recibido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtMontoRecibido.SelectAll();
                        txtMontoRecibido.Focus();
                        return;
                    }

                    if (montoRecibido < monto)
                    {
                        MessageBox.Show(
                            $"El monto recibido no alcanza.\n\n" +
                            $"Monto a aplicar: $ {monto:N2}\n" +
                            $"Monto recibido: $ {montoRecibido:N2}",
                            "Efectivo insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtMontoRecibido.SelectAll();
                        txtMontoRecibido.Focus();
                        return;
                    }
                }

                vueltoVenta = montoRecibido - monto;
            }

            dtgPagos.Rows.Add(
                idMetodoPago,
                metodoPago,
                monto);

            CalcularPagos();

            txtMonto.Clear();
            txtMontoRecibido.Clear();

            cmbMetodoPago.SelectedIndex = -1;

            lblVuelto.Text = $"$ {vueltoVenta:N2}";

            cmbMetodoPago.Focus();
        }
        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }
        private void cmbMetodoPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                cmbMetodoPago.SelectedIndex != -1)
            {
                e.SuppressKeyPress = true;

                btnAgregarPago.PerformClick();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // ==========================
                // 1. VALIDAR PAGO COMPLETO
                // ==========================

                if (totalPagado != totalVenta)
                {
                    MessageBox.Show(
                        "La venta todavía no está completamente pagada.",
                        "Confirmar venta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ==========================
                // 2. ARMAR DETALLES
                // ==========================

                List<DetalleVentaEntidad> detalles =
                    new List<DetalleVentaEntidad>();

                foreach (DataGridViewRow fila in carritoVenta.Rows)
                {
                    if (fila.IsNewRow ||
                        fila.Cells["ClnIdProducto"].Value == null)
                    {
                        continue;
                    }

                    int idProducto =
                        Convert.ToInt32(
                            fila.Cells["ClnIdProducto"].Value);

                    decimal cantidad =
                        Convert.ToDecimal(
                            fila.Cells["ClnCantidad"].Value);

                    decimal precioUnitario =
                        Convert.ToDecimal(
                            fila.Cells["ClnPrecioUnitario"].Value);

                    decimal subtotal =
                        Convert.ToDecimal(
                            fila.Cells["ClnImporte"].Value);

                    detalles.Add(
                        new DetalleVentaEntidad
                        {
                            IdProducto = idProducto,
                            Cantidad = cantidad,
                            PrecioUnitario = precioUnitario,
                            Subtotal = subtotal
                        });
                }


                // ==========================
                // 3. ARMAR PAGOS
                // ==========================

                List<PagoVentaEntidad> pagos =
                    new List<PagoVentaEntidad>();

                foreach (DataGridViewRow fila in dtgPagos.Rows)
                {
                    if (fila.IsNewRow ||
                        fila.Cells["ClnIdMetodoPago"].Value == null)
                    {
                        continue;
                    }

                    int idMetodoPago =
                        Convert.ToInt32(
                            fila.Cells["ClnIdMetodoPago"].Value);

                    decimal monto =
                        Convert.ToDecimal(
                            fila.Cells["ClnMontoPago"].Value);

                    pagos.Add(
                        new PagoVentaEntidad
                        {
                            IdMetodoPago = idMetodoPago,
                            Monto = monto
                        });
                }


                // ==========================
                // 4. REGISTRAR VENTA
                // ==========================

                ClsGestorVentaLogica gestorVenta =
                    new ClsGestorVentaLogica();

                int idVenta = gestorVenta.RegistrarVenta(
                    totalVenta,
                    SesionUsuario.IdUsuario,
                    detalles,
                    pagos);


                // ==========================
                // 5. VENTA CORRECTA
                // ==========================

                MessageBox.Show(
                    $"Venta #{idVenta} registrada correctamente.",
                    "Venta registrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo registrar la venta.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedIndex == -1)
            {
                txtMontoRecibido.Clear();
                txtMontoRecibido.Enabled = false;
                return;
            }

            decimal restante = totalVenta - totalPagado;

            // Propone automáticamente cobrar todo lo que falta
            txtMonto.Text = restante.ToString("0.00");

            string metodo = cmbMetodoPago.Text;

            bool esEfectivo = metodo.Equals(
                "Efectivo",
                StringComparison.OrdinalIgnoreCase);

            txtMontoRecibido.Enabled = esEfectivo;

            if (esEfectivo)
            {
                // Vacío significa que paga justo
                txtMontoRecibido.Clear();

                txtMonto.SelectAll();
                txtMonto.Focus();
            }
            else
            {
                txtMontoRecibido.Clear();
            }
        }

        private void CalcularVuelto()
        {
            if (cmbMetodoPago.SelectedIndex == -1 ||
                !cmbMetodoPago.Text.Equals(
                    "Efectivo",
                    StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (!decimal.TryParse(
                txtMonto.Text,
                out decimal montoEfectivo))
            {
                lblVuelto.Text = "$ 0,00";
                return;
            }

            // Vacío = entrega el monto justo
            if (string.IsNullOrWhiteSpace(txtMontoRecibido.Text))
            {
                lblVuelto.Text = "$ 0,00";
                return;
            }

            if (!decimal.TryParse(
                txtMontoRecibido.Text,
                out decimal recibido))
            {
                lblVuelto.Text = "$ 0,00";
                return;
            }

            decimal vuelto = recibido - montoEfectivo;

            lblVuelto.Text = vuelto >= 0
                ? $"$ {vuelto:N2}"
                : "$ 0,00";
        }

        private void btnQuitarPago_Click(object sender, EventArgs e)
        {
            if (dtgPagos.CurrentRow == null ||
                dtgPagos.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Seleccione un método de pago para quitar.",
                    "Quitar pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Quitamos el pago seleccionado
            dtgPagos.Rows.Remove(dtgPagos.CurrentRow);

            // Recalculamos pagado y restante
            CalcularPagos();

            decimal restante = totalVenta - totalPagado;

            // Volvemos a proponer automáticamente todo lo que falta
            txtMonto.Text = restante.ToString("0.00");

            // Como quitamos un pago, reiniciamos el vuelto
            vueltoVenta = 0;
            lblVuelto.Text = "$ 0,00";

            txtMontoRecibido.Clear();

            // Dejamos listo para seleccionar otro método
            cmbMetodoPago.SelectedIndex = -1;
            cmbMetodoPago.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
