using CapaEntidades;
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
    public partial class frmInformeCobro : Form
    {
        private readonly decimal totalVenta;
        private readonly DataGridView carritoVenta;
        private decimal totalPagado = 0;
        private decimal vueltoVenta = 0;
        private bool cargandoMonto = false;
        private DataTable metodosPago;
        private List<ClsPromocionVentaEntidad> promociones = new List<ClsPromocionVentaEntidad>();
        public frmInformeCobro(decimal total, DataGridView carrito)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            totalVenta = total;
            carritoVenta = carrito;

            lblTotal.Text = $"$ {totalVenta:N2}";
            lblPagado.Text = "$ 0,00";
            lblRestante.Text = $"$ {totalVenta:N2}";
            lblVuelto.Text = "$ 0,00";
            lblRestaP.Text = $"$ {totalVenta:N2}";

            PonerMonto(totalVenta);

            btnConfirmar.Visible = true;
            btnConfirmar.Enabled = false;
            btnConfirmar.BringToFront();

        }

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
                MessageBox.Show(ClsIdioma.T("La venta ya está completamente pagada."), ClsIdioma.T("Agregar pago"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!TryLeerMonto(txtMontoRecibido.Text, out decimal monto))
            {
                MessageBox.Show(ClsIdioma.T("Ingrese un monto válido."), ClsIdioma.T("Monto inválido"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.Focus();
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show(ClsIdioma.T("El monto debe ser mayor que cero."), ClsIdioma.T("Monto inválido"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.SelectAll();
                txtMontoRecibido.Focus();
                return;
            }

            bool yaHayPagos = totalPagado > 0;

            if (yaHayPagos && monto < restante)
            {
                MessageBox.Show((ClsIdioma.Ingles ? $"The amount is not enough to complete the payment with this method.\n\n" : $"El importe no alcanza para completar el pago con este método.\n\n") + (ClsIdioma.Ingles ? $"Outstanding balance: $ {restante:N2}\n" : $"Saldo pendiente: $ {restante:N2}\n") + (ClsIdioma.Ingles ? $"Amount entered: $ {monto:N2}" : $"Importe ingresado: $ {monto:N2}"), ClsIdioma.T("Importe insuficiente"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.SelectAll();
                txtMontoRecibido.Focus();
                return;
            }

            bool esEfectivo = metodoPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase);

            decimal montoAplicado = monto;
            decimal vuelto = 0;

            if (esEfectivo)
            {
                if (monto > restante)
                {
                    montoAplicado = restante;
                    vuelto = monto - restante;
                }
            }
            else if (monto > restante)
            {
                MessageBox.Show((ClsIdioma.Ingles ? $"The amount exceeds the remaining balance.\n\n" : $"El monto supera el saldo restante.\n\n") + (ClsIdioma.Ingles ? $"Outstanding balance: $ {restante:N2}" : $"Saldo pendiente: $ {restante:N2}"), ClsIdioma.T("Monto inválido"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMontoRecibido.SelectAll();
                txtMontoRecibido.Focus();
                return;
            }

            int idMetodoPago;

            try
            {
                idMetodoPago = ObtenerIdMetodoPago(metodoPago);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo agregar el pago.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtgPagos.Rows.Add(idMetodoPago, metodoPago, montoAplicado);

            CalcularPagos();
            ActualizarBotonesMetodo();

            vueltoVenta = vuelto;
            lblVuelto.Text = $"$ {vueltoVenta:N2}";

            PonerMonto(Math.Max(totalVenta - totalPagado, 0));
        }
        private int ObtenerIdMetodoPago(string metodoPago)
        {
            if (metodosPago == null)
            {
                ClsGestorVentaLogica gestorVenta = new ClsGestorVentaLogica();
                metodosPago = gestorVenta.ObtenerMetodosPago();
            }

            foreach (DataRow fila in metodosPago.Rows)
            {
                string nombre = fila["Nombre"].ToString();

                if (nombre.Equals(metodoPago, StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToInt32(fila["IdMetodoPago"]);
                }
            }

            throw new Exception(
                (ClsIdioma.Ingles ? $"The payment method '{metodoPago}' was not found in the database." : $"No se encontró el método de pago '{metodoPago}' en la base de datos."));
        }
        private static bool TryLeerMonto(string texto, out decimal monto)
        {
            monto = 0;
            texto = (texto ?? "").Replace("$", "").Replace(" ", "").Trim();

            if (texto.Length == 0)
                return false;

            int ultimoPunto = texto.LastIndexOf('.');
            int ultimaComa = texto.LastIndexOf(',');
            int separador = Math.Max(ultimoPunto, ultimaComa);

            if (ultimaComa < 0 && ultimoPunto >= 0 && texto.Length - ultimoPunto - 1 == 3)
            {
                texto = texto.Replace(".", "");
                separador = -1;
            }

            if (separador >= 0)
            {
                string entera = texto.Substring(0, separador).Replace(".", "").Replace(",", "");
                string decimales = texto.Substring(separador + 1);
                texto = entera + "." + decimales;
            }

            return decimal.TryParse(texto, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out monto);
        }
        private void PonerMonto(decimal monto)
        {
            cargandoMonto = true;
            txtMontoRecibido.Text = monto > 0 ? monto.ToString("0.00") : "";
            cargandoMonto = false;
        }
        private void CalcularVuelto()
        {
            decimal restante = Math.Max(totalVenta - totalPagado, 0);

            if (restante == 0)
                return;

            if (!TryLeerMonto(txtMontoRecibido.Text, out decimal montoRecibido))
            {
                vueltoVenta = 0;
                lblVuelto.Text = "$ 0,00";
                return;
            }

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
        private HashSet<string> MetodosUtilizados()
        {
            HashSet<string> metodos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (DataGridViewRow fila in dtgPagos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                object valor = fila.Cells["ClnMetodoPago"].Value;

                if (valor != null)
                    metodos.Add(valor.ToString());
            }

            return metodos;
        }
        private void ActualizarBotonesMetodo()
        {
            HashSet<string> usados = MetodosUtilizados();

            MarcarBoton(btnEfectivo, usados.Contains("Efectivo"));
            MarcarBoton(btnTransferencia, usados.Contains("Transferencia"));
            MarcarBoton(btnDebito, usados.Contains("Débito"));
        }
        private static void MarcarBoton(Button boton, bool usado)
        {
            boton.UseVisualStyleBackColor = !usado;
            boton.BackColor = usado ? Color.LightGreen : SystemColors.Control;
        }
        private bool SeleccionarMetodoPago(string metodoPago)
        {
            HashSet<string> metodosUtilizados = MetodosUtilizados();

            if (metodosUtilizados.Contains(metodoPago))
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

                CalcularPagos();
                ActualizarBotonesMetodo();

                vueltoVenta = 0;
                lblVuelto.Text = "$ 0,00";

                PonerMonto(Math.Max(totalVenta - totalPagado, 0));

                return false;
            }

            if (metodosUtilizados.Count >= 2)
            {
                MessageBox.Show(ClsIdioma.T("Solo se permiten dos métodos de pago diferentes por venta."), ClsIdioma.T("Límite de métodos de pago"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }


        #endregion

        #region Eventos
        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (SeleccionarMetodoPago("Efectivo"))
                AgregarPago("Efectivo");
        }
        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (SeleccionarMetodoPago("Transferencia"))
                AgregarPago("Transferencia");
        }
        private void btnDebito_Click(object sender, EventArgs e)
        {
            if (SeleccionarMetodoPago("Débito"))
                AgregarPago("Débito");
        }
        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            if (cargandoMonto)
                return;

            CalcularVuelto();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = false;

            try
            {

                if (totalPagado != totalVenta)
                {
                    MessageBox.Show(ClsIdioma.T("La venta todavía no está completamente pagada."), ClsIdioma.T("Confirmar venta"),
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

                ClsGestorVentaLogica gestorVenta = new ClsGestorVentaLogica();

                int idVenta = gestorVenta.RegistrarVenta(totalVenta, SesionUsuario.IdUsuario, null, detalles, pagos, promociones);

                MessageBox.Show((ClsIdioma.Ingles ? $"Sale #{idVenta} registered successfully." : $"Venta #{idVenta} registrada correctamente."), ClsIdioma.T("Venta registrada"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ClsIdioma.Ingles ? $"The sale could not be registered.\n\n{ex.Message}" : $"No se pudo registrar la venta.\n\n{ex.Message}"), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed && DialogResult != DialogResult.OK)
                {
                    btnConfirmar.Enabled = totalPagado == totalVenta;
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
