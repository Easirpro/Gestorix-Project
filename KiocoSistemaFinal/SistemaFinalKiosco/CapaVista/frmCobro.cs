using CapaEntidades.NegocioEntidad;
using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmCobro : Form
    {
        private decimal totalVenta;
        private int idUsuario;
        private List<DetalleVentaEntidad> detallesVenta;
        private ClsGestorVentaLogica logicaVenta = new ClsGestorVentaLogica();

        public frmCobro(decimal total, int usuario, List<DetalleVentaEntidad> detalles)
        {
            InitializeComponent();

            totalVenta = total;
            idUsuario = usuario;
            detallesVenta = detalles;

            lblTotal.Text = $"$ {totalVenta:N2}";
            lblPagado.Text = "$ 0,00";
            lblRestante.Text = $"$ {totalVenta:N2}";
            lblRestoPago.Text = $"$ {totalVenta:N2}";
            lblVuelto.Text = "$ 0,00";

            txtMontoRecibido.Clear();

            dtgPagos.Rows.Clear();
        }

        #region Metodos
        private void ActualizarTotales()
        {
            decimal totalPagado = 0m;

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.Cells["ClnMontoPago"].Value != null)
                {
                    totalPagado += Convert.ToDecimal(fila.Cells["ClnMontoPago"].Value);
                }
            }

            decimal restante = totalVenta - totalPagado;

            if (restante < 0)
            {
                restante = 0m;
            }

            lblPagado.Text = $"$ {totalPagado:N2}";
            lblRestante.Text = $"$ {restante:N2}";
            lblRestoPago.Text = $"$ {restante:N2}";

            if (totalPagado >= totalVenta)
            {
                lblVuelto.Text = "$ 0,00";
            }
            else
            {
                lblVuelto.Text = "$ 0,00";
            }
        }
        private void CalcularVuelto()
        {
            decimal totalEfectivo = 0m;
            decimal totalOtrosPagos = 0m;

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnIdMetodoPago"].Value == null || fila.Cells["ClnMontoPago"].Value == null)
                {
                    continue;
                }

                int idMetodoPago = Convert.ToInt32(fila.Cells["ClnIdMetodoPago"].Value);

                decimal monto = Convert.ToDecimal(fila.Cells["ClnMontoPago"].Value);

                if (idMetodoPago == 1)
                {
                    totalEfectivo += monto;
                }
                else
                {
                    totalOtrosPagos += monto;
                }
            }

            decimal montoNecesarioEnEfectivo = totalVenta - totalOtrosPagos;

            decimal vuelto = totalEfectivo - montoNecesarioEnEfectivo;

            if (vuelto < 0)
            {
                vuelto = 0m;
            }

            lblVuelto.Text = $"$ {vuelto:N2}";
        }
        private void AgregarPagoEfectivo()
        {
            string textoMonto = txtMontoRecibido.Text.Trim();

            if (!decimal.TryParse(textoMonto, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal monto))
            {
                MessageBox.Show("Ingrese un monto válido.", "Efectivo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Efectivo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            dtgPagos.Rows.Add(1, "Efectivo", monto);

            ActualizarTotales();
            CalcularVuelto();

            txtMontoRecibido.Clear();
            txtMontoRecibido.Focus();
        }
        private void AgregarPagoTransferencia()
        {
            string textoMonto = txtMontoRecibido.Text.Trim();

            if (!decimal.TryParse(textoMonto, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal monto))
            {
                MessageBox.Show("Ingrese un monto válido.", "Transferencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Transferencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            decimal restante = ObtenerRestante();

            if (monto > restante)
            {
                MessageBox.Show($"El monto de transferencia no puede superar el restante de $ {restante:N2}.", "Transferencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            dtgPagos.Rows.Add(2, "Transferencia", monto);

            ActualizarTotales();
            CalcularVuelto();

            txtMontoRecibido.Clear();
            txtMontoRecibido.Focus();
        }
        private void AgregarPagoDebito()
        {
            string textoMonto = txtMontoRecibido.Text.Trim();

            if (!decimal.TryParse(textoMonto, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal monto))
            {
                MessageBox.Show("Ingrese un monto válido.", "Débito",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Débito",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            decimal restante = ObtenerRestante();

            if (monto > restante)
            {
                MessageBox.Show($"El monto de débito no puede superar el restante de $ {restante:N2}.", "Débito",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            dtgPagos.Rows.Add(3, "Débito", monto);

            ActualizarTotales();
            CalcularVuelto();

            txtMontoRecibido.Clear();
            txtMontoRecibido.Focus();
        }
        private bool ValidarPago()
        {
            if (dtgPagos.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un método de pago.", "Pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (dtgPagos.Rows.Count > 2)
            {
                MessageBox.Show("Solo se pueden utilizar hasta 2 métodos de pago.", "Métodos de pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            decimal totalPagado = 0m;

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnMontoPago"].Value == null)
                {
                    MessageBox.Show("Existe un pago sin monto.", "Pago",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                decimal monto = Convert.ToDecimal(fila.Cells["ClnMontoPago"].Value);

                if (monto <= 0)
                {
                    MessageBox.Show("Todos los pagos deben ser mayores a cero.", "Pago",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                totalPagado += monto;
            }

            if (totalPagado < totalVenta)
            {
                decimal faltante = totalVenta - totalPagado;

                MessageBox.Show($"Falta pagar $ {faltante:N2}.", "Pago incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
        private bool MetodoPagoAgregado(int idMetodoPago)
        {
            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnIdMetodoPago"].Value != null)
                {
                    int id = Convert.ToInt32(fila.Cells["ClnIdMetodoPago"].Value);

                    if (id == idMetodoPago)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private void QuitarMetodoPago(int idMetodoPago)
        {
            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnIdMetodoPago"].Value != null)
                {
                    int id = Convert.ToInt32(fila.Cells["ClnIdMetodoPago"].Value);

                    if (id == idMetodoPago)
                    {
                        dtgPagos.Rows.Remove(fila);
                        break;
                    }
                }
            }

            ActualizarTotales();
            CalcularVuelto();
        }
        private decimal ObtenerTotalPagado()
        {
            decimal totalPagado = 0m;

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnMontoPago"].Value != null)
                {
                    totalPagado += Convert.ToDecimal(fila.Cells["ClnMontoPago"].Value);
                }
            }

            return totalPagado;
        }
        private decimal ObtenerRestante()
        {
            decimal restante = totalVenta - ObtenerTotalPagado();

            if (restante < 0)
            {
                restante = 0m;
            }

            return restante;
        }
        private List<PagoVentaEntidad> ObtenerPagosVenta()
        {
            List<PagoVentaEntidad> pagos = new List<PagoVentaEntidad>();

            decimal restante = totalVenta;

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnIdMetodoPago"].Value == null || fila.Cells["ClnMontoPago"].Value == null)
                {
                    continue;
                }

                int idMetodoPago = Convert.ToInt32( fila.Cells["ClnIdMetodoPago"].Value);

                decimal monto = Convert.ToDecimal( fila.Cells["ClnMontoPago"].Value);
                decimal montoAplicado = monto;

                if (montoAplicado > restante)
                {
                    montoAplicado = restante;
                }

                if (montoAplicado > 0)
                {
                    pagos.Add(new PagoVentaEntidad
                    {
                        IdMetodoPago = idMetodoPago,
                        Monto = montoAplicado
                    });

                    restante -= montoAplicado;
                }

                if (restante <= 0)
                {
                    break;
                }
            }

            return pagos;
        }


        #endregion

        #region Eventos
        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (MetodoPagoAgregado(1))
            {
                QuitarMetodoPago(1);

                btnEfectivo.BackColor = SystemColors.Control;
                btnEfectivo.ForeColor = SystemColors.ControlText;

                return;
            }

            if (dtgPagos.Rows.Count >= 2)
            {
                MessageBox.Show("Solo se pueden utilizar hasta 2 métodos de pago.", "Métodos de pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            AgregarPagoEfectivo();

            if (MetodoPagoAgregado(1))
            {
                btnEfectivo.BackColor = Color.Green;
                btnEfectivo.ForeColor = Color.White;
            }
        }
        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (MetodoPagoAgregado(2))
            {
                QuitarMetodoPago(2);

                btnTransferencia.BackColor = SystemColors.Control;
                btnTransferencia.ForeColor = SystemColors.ControlText;

                return;
            }

            if (dtgPagos.Rows.Count >= 2)
            {
                MessageBox.Show("Solo se pueden utilizar hasta 2 métodos de pago.", "Métodos de pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            AgregarPagoTransferencia();

            if (MetodoPagoAgregado(2))
            {
                btnTransferencia.BackColor = Color.Green;
                btnTransferencia.ForeColor = Color.White;
            }
        }
        private void btnDebito_Click(object sender, EventArgs e)
        {
            if (MetodoPagoAgregado(3))
            {
                QuitarMetodoPago(3);

                btnDebito.BackColor = SystemColors.Control;
                btnDebito.ForeColor = SystemColors.ControlText;

                return;
            }

            if (dtgPagos.Rows.Count >= 2)
            {
                MessageBox.Show("Solo se pueden utilizar hasta 2 métodos de pago.", "Métodos de pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            AgregarPagoDebito();

            if (MetodoPagoAgregado(3))
            {
                btnDebito.BackColor = Color.Green;
                btnDebito.ForeColor = Color.White;
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarPago())
            {
                return;
            }

            List<PagoVentaEntidad> pagos = ObtenerPagosVenta();

            try
            {
                int resultado = logicaVenta.RegistrarVenta(totalVenta, idUsuario, null, detallesVenta, pagos);

                MessageBox.Show("¡Venta realizada correctamente!\n\n" + $"Total cobrado: $ {totalVenta:N2}", "Venta realizada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtMontoRecibido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                AgregarPagoEfectivo();
            }
        }


        #endregion






    }
}
