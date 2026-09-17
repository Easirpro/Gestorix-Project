using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica.NegocioLogica;


namespace CapaVista
{
    public partial class frmInformeCobro : Form
    {
        private readonly decimal totalVenta;
        private decimal totalPagado = 0;
        private decimal vueltoVenta = 0;
        public frmInformeCobro(decimal total)
        {
            InitializeComponent();

            totalVenta = total;


            lblTotal.Text = $"$ {totalVenta:N2}";
            lblPagado.Text = "$ 0,00";
            lblRestante.Text = $"$ {totalVenta:N2}";
            lblVuelto.Text = "$ 0,00";

            btnConfirmar.Enabled = false;
            CargarMetodosPago();
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
            // Validar método de pago
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

            // Validar monto a aplicar
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

            // Calcular cuánto falta pagar
            decimal restante = totalVenta - totalPagado;

            // No permitir pagar más de lo que resta
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

            // Obtener método seleccionado
            int idMetodoPago =
                Convert.ToInt32(cmbMetodoPago.SelectedValue);

            string metodoPago =
                cmbMetodoPago.Text;

            // Verificar si es efectivo
            bool esEfectivo = metodoPago.Equals(
                "Efectivo",
                StringComparison.OrdinalIgnoreCase);

            // Validaciones especiales para efectivo
            if (esEfectivo)
            {
                if (!decimal.TryParse(
                    txtMontoRecibido.Text,
                    out decimal montoRecibido) ||
                    montoRecibido <= 0)
                {
                    MessageBox.Show(
                        "Ingrese el monto recibido en efectivo.",
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
                        $"El monto recibido no alcanza para cubrir el pago en efectivo.\n\n" +
                        $"Pago en efectivo: $ {monto:N2}\n" +
                        $"Recibido: $ {montoRecibido:N2}",
                        "Efectivo insuficiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMontoRecibido.SelectAll();
                    txtMontoRecibido.Focus();
                    return;
                }

                // Guardar el vuelto
                vueltoVenta = montoRecibido - monto;
            }

            // Agregar pago a la grilla
            dtgPagos.Rows.Add(
                idMetodoPago,
                metodoPago,
                monto);

            // Actualizar Pagado y Restante
            CalcularPagos();

            // Limpiar campos
            txtMonto.Clear();
            txtMontoRecibido.Clear();

            cmbMetodoPago.SelectedIndex = -1;

            // Los TextChanged pueden haber puesto el vuelto en 0.
            // Lo volvemos a mostrar usando el valor guardado.
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

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedIndex == -1)
            {
                txtMontoRecibido.Clear();
                txtMontoRecibido.Enabled = false;
                return;
            }

            string metodo = cmbMetodoPago.Text;

            bool esEfectivo = metodo.Equals(
                "Efectivo",
                StringComparison.OrdinalIgnoreCase);

            txtMontoRecibido.Enabled = esEfectivo;

            if (!esEfectivo)
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
                lblVuelto.Text = "$ 0,00";
                return;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal montoEfectivo) ||
                !decimal.TryParse(txtMontoRecibido.Text, out decimal recibido))
            {
                lblVuelto.Text = "$ 0,00";
                return;
            }

            decimal vuelto = recibido - montoEfectivo;

            lblVuelto.Text = vuelto >= 0
                ? $"$ {vuelto:N2}"
                : "$ 0,00";
        }








    }
}
