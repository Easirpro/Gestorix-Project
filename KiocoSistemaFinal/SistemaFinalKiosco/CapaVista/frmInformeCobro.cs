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
        private readonly DataGridView carritoVenta;
        private decimal totalPagado = 0;
        private decimal vueltoVenta = 0;
        private Button botonMetodoSeleccionado = null;
        private List<ClsPromocionVentaEntidad> promociones = new List<ClsPromocionVentaEntidad>();   // [PROMO]
        public frmInformeCobro(decimal total, DataGridView carrito)
        {
            InitializeComponent();

            totalVenta = total;
            carritoVenta = carrito;

            lblTotal.Text = $"$ {totalVenta:N2}";
            lblPagado.Text = "$ 0,00";
            lblRestante.Text = $"$ {totalVenta:N2}";
            lblVuelto.Text = "$ 0,00";
            lblRestaP.Text = $"$ {totalVenta:N2}";

            txtMontoRecibido.Text = totalVenta.ToString("0.00");

            btnConfirmar.Visible = true;
            btnConfirmar.Enabled = false;
            btnConfirmar.BringToFront();

        }

        // [PROMO] Igual que el anterior, pero recibe las promociones aplicadas en la venta
        public frmInformeCobro(decimal total, DataGridView carrito, List<ClsPromocionVentaEntidad> promocionesAplicadas)
            : this(total, carrito)
        {
            if (promocionesAplicadas != null)
            {
                promociones = promocionesAplicadas;
            }
        }

        #region Metodos
        private void AgregarPago(string metodoPago)
        {
            decimal restante = totalVenta - totalPagado;

            if (restante <= 0)
            {
                MessageBox.Show("La venta ya está completamente pagada.", "Agregar pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!decimal.TryParse(txtMontoRecibido.Text, out decimal monto))
            {
                MessageBox.Show("Ingrese un monto válido.", "Monto inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero.", "Monto inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.SelectAll();
                txtMontoRecibido.Focus();
                return;
            }

            bool esEfectivo = metodoPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase);

            decimal montoAplicado = monto;

            if (esEfectivo)
            {
                if (monto < restante)
                {
                    montoAplicado = monto;
                    vueltoVenta = 0;
                }
                else
                {
                    montoAplicado = restante;
                    vueltoVenta = monto - restante;
                }
            }

            else
            {
                bool yaHayPagos = totalPagado > 0;

                if (yaHayPagos && monto < restante)
                {
                    MessageBox.Show($"El importe no alcanza para completar el pago con este método.\n\n" + $"Saldo pendiente: $ {restante:N2}\n" + $"Importe ingresado: $ {monto:N2}", "Importe insuficiente",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtMontoRecibido.SelectAll();
                    txtMontoRecibido.Focus();
                    return;
                }

                if (monto > restante)
                {
                    MessageBox.Show($"El monto supera el saldo restante.\n\n" + $"Saldo pendiente: $ {restante:N2}", "Monto inválido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtMontoRecibido.SelectAll();
                    txtMontoRecibido.Focus();
                    return;
                }

                vueltoVenta = 0;
            }


            int idMetodoPago = ObtenerIdMetodoPago(metodoPago);

            dtgPagos.Rows.Add(idMetodoPago, metodoPago, montoAplicado);

            CalcularPagos();

            lblVuelto.Text = $"$ {vueltoVenta:N2}";

            txtMontoRecibido.Clear();
        }
        private int ObtenerIdMetodoPago(string metodoPago)
        {
            ClsVentaLogica gestorVenta = new ClsVentaLogica();

            DataTable tabla = gestorVenta.ObtenerMetodosPago();

            foreach (DataRow fila in tabla.Rows)
            {
                string nombre = fila["Nombre"].ToString();

                if (nombre.Equals(
                    metodoPago,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToInt32(fila["IdMetodoPago"]);
                }
            }

            throw new Exception(
                $"No se encontró el método de pago '{metodoPago}' en la base de datos.");
        }
        private void CalcularVuelto()
        {
            if (!decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido))
            {
                vueltoVenta = 0;
                lblVuelto.Text = "$ 0,00";
                return;
            }

            decimal restante = Math.Max(totalVenta - totalPagado, 0);

            vueltoVenta = montoRecibido > restante ? montoRecibido - restante : 0;

            lblVuelto.Text = $"$ {vueltoVenta:N2}";
        }
        private void CalcularPagos()
        {
            totalPagado = 0;

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnMontoPago"].Value != null && decimal.TryParse(fila.Cells["ClnMontoPago"].Value.ToString(), out decimal monto))
                {
                    totalPagado += monto;
                }
            }

            decimal restante = Math.Max(totalVenta - totalPagado, 0);

            lblPagado.Text = $"$ {totalPagado:N2}";
            lblRestante.Text = $"$ {restante:N2}";
            lblRestaP.Text = $"$ {restante:N2}";

            btnConfirmar.Enabled = restante == 0;
        }
        private bool SeleccionarMetodoPago(string metodoPago, Button boton)
        {
            if (botonMetodoSeleccionado == boton)
            {
                for (int i = dtgPagos.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow fila = dtgPagos.Rows[i];

                    if (fila.IsNewRow)
                        continue;

                    string metodoFila = fila.Cells["ClnMetodoPago"].Value?.ToString();

                    if (string.Equals(metodoFila, metodoPago, StringComparison.OrdinalIgnoreCase))
                    {
                        dtgPagos.Rows.RemoveAt(i);
                    }
                }

                boton.UseVisualStyleBackColor = true;
                boton.BackColor = SystemColors.Control;
                botonMetodoSeleccionado = null;

                CalcularPagos();

                decimal restante = Math.Max(totalVenta - totalPagado, 0);

                txtMontoRecibido.Text = restante.ToString("0.00");

                CalcularVuelto();

                return false;
            }

            HashSet<string> metodosUtilizados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                object valor = fila.Cells["ClnMetodoPago"].Value;

                if (valor != null)
                    metodosUtilizados.Add(valor.ToString());
            }

            if (metodosUtilizados.Count >= 2 &&
                !metodosUtilizados.Contains(metodoPago))
            {
                MessageBox.Show("Solo se permiten dos métodos de pago diferentes por venta.", "Límite de métodos de pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (botonMetodoSeleccionado != null)
            {
                botonMetodoSeleccionado.UseVisualStyleBackColor = true;
                botonMetodoSeleccionado.BackColor = SystemColors.Control;
            }

            botonMetodoSeleccionado = boton;
            botonMetodoSeleccionado.UseVisualStyleBackColor = false;
            botonMetodoSeleccionado.BackColor = Color.LightGreen;

            return true;
        }


        #endregion

        #region Eventos
        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (SeleccionarMetodoPago("Efectivo", btnEfectivo))
                AgregarPago("Efectivo");
        }
        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (SeleccionarMetodoPago("Transferencia", btnTransferencia))
                AgregarPago("Transferencia");
        }
        private void btnDebito_Click(object sender, EventArgs e)
        {
            if (SeleccionarMetodoPago("Débito", btnDebito))
                AgregarPago("Débito");
        }
        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                if (totalPagado != totalVenta)
                {
                    MessageBox.Show("La venta todavía no está completamente pagada.", "Confirmar venta",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                List<DetalleVentaEntidad> detalles = new List<DetalleVentaEntidad>();

                foreach (DataGridViewRow fila in carritoVenta.Rows)
                {
                    if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    {
                        continue;
                    }

                    int idProducto = Convert.ToInt32(fila.Cells["ClnIdProducto"].Value);
                    decimal cantidad = Convert.ToDecimal(fila.Cells["ClnCantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(fila.Cells["ClnPrecioUnitario"].Value);
                    decimal subtotal = Convert.ToDecimal(fila.Cells["ClnImporte"].Value);

                    detalles.Add(
                        new DetalleVentaEntidad
                        {
                            IdProducto = idProducto,
                            Cantidad = cantidad,
                            PrecioUnitario = precioUnitario,
                            Subtotal = subtotal
                        });
                }

                List<PagoVentaEntidad> pagos = new List<PagoVentaEntidad>();

                foreach (DataGridViewRow fila in dtgPagos.Rows)
                {
                    if (fila.IsNewRow || fila.Cells["ClnIdMetodoPago"].Value == null)
                    {
                        continue;
                    }

                    int idMetodoPago = Convert.ToInt32(fila.Cells["ClnIdMetodoPago"].Value);
                    decimal monto = Convert.ToDecimal(fila.Cells["ClnMontoPago"].Value);

                    pagos.Add(
                        new PagoVentaEntidad
                        {
                            IdMetodoPago = idMetodoPago,
                            Monto = monto
                        });
                }

                ClsVentaLogica gestorVenta = new ClsVentaLogica();

                int idVenta = gestorVenta.RegistrarVenta(totalVenta, SesionUsuario.IdUsuario, null, detalles, pagos, promociones);   // [PROMO]

                MessageBox.Show($"Venta #{idVenta} registrada correctamente.", "Venta registrada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo registrar la venta.\n\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        private void frmInformeCobro_Load(object sender, EventArgs e)
        {

        }
    }
}
