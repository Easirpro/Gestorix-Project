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
using CapaEntidades;
namespace CapaVista
{
    public partial class frmRegistrarPagoCompra : Form
    {
        private ClsPagoCompraLogica logica = new ClsPagoCompraLogica();
        private ClsCajaLogica logicaCaja = new ClsCajaLogica();

        private readonly int idCompra;
        private readonly string proveedor;
        private readonly decimal saldo;
        private ClsSesionCajaEntidad sesionCaja;

        public frmRegistrarPagoCompra(int idCompra, string proveedor, decimal saldo)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            this.idCompra = idCompra;
            this.proveedor = proveedor;
            this.saldo = saldo;
        }

        private void frmRegistrarPagoCompra_Load(object sender, EventArgs e)
        {
            lblCompra.Text = ClsIdioma.T("Compra N.º ") + idCompra + "  -  " + proveedor;
            lblSaldo.Text = (ClsIdioma.Ingles ? $"Outstanding balance: {saldo:C2}" : $"Saldo pendiente: {saldo:C2}");

            nudMonto.Maximum = saldo;
            nudMonto.Value = saldo;

            try
            {
                CargarMediosPago();
                sesionCaja = logicaCaja.ObtenerSesionAbierta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los datos.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (sesionCaja == null)
            {
                chkDesdeCaja.Checked = false;
                chkDesdeCaja.Enabled = false;
                chkDesdeCaja.Text = ClsIdioma.T("El dinero sale de la caja (no hay caja abierta)");
            }
            else
            {
                chkDesdeCaja.Checked = EsEfectivo();
            }

            ActualizarDisponible();
        }

        #region Metodos

        private void CargarMediosPago()
        {
            DataTable tabla = logicaCaja.ObtenerMetodosPago();

            foreach (DataRow fila in tabla.Select("Nombre = 'Cuenta Corriente'"))
            {
                tabla.Rows.Remove(fila);
            }

            cmbMedioPago.DataSource = tabla;
            cmbMedioPago.DisplayMember = "Nombre";
            cmbMedioPago.ValueMember = "IdMetodoPago";

            ClsIdioma.TraducirDatosAlMostrar(cmbMedioPago);

            int indiceEfectivo = tabla.Rows.IndexOf(tabla.Select("Nombre = 'Efectivo'").FirstOrDefault());
            if (indiceEfectivo >= 0)
            {
                cmbMedioPago.SelectedIndex = indiceEfectivo;
            }
        }

        private bool EsEfectivo()
        {
            return cmbMedioPago.SelectedItem is DataRowView medio && Convert.ToString(medio["Nombre"]) == "Efectivo";
        }

        private void ActualizarDisponible()
        {
            if (sesionCaja != null && chkDesdeCaja.Checked && EsEfectivo())
            {
                lblDisponible.Text = (ClsIdioma.Ingles ? $"Cash available in register: {sesionCaja.EfectivoEsperado:C2}" : $"Efectivo disponible en caja: {sesionCaja.EfectivoEsperado:C2}");
            }
            else
            {
                lblDisponible.Text = "";
            }
        }

        private bool ValidarCampos()
        {
            if (cmbMedioPago.SelectedValue == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un medio de pago."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMedioPago.Focus();
                return false;
            }

            if (nudMonto.Value <= 0)
            {
                MessageBox.Show(ClsIdioma.T("El monto debe ser mayor a cero."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMonto.Focus();
                return false;
            }

            if (nudMonto.Value > saldo)
            {
                MessageBox.Show(ClsIdioma.T("El monto no puede superar el saldo pendiente."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMonto.Focus();
                return false;
            }

            if (sesionCaja != null && chkDesdeCaja.Checked && EsEfectivo()
                && nudMonto.Value > sesionCaja.EfectivoEsperado)
            {
                MessageBox.Show(ClsIdioma.T("El monto supera el efectivo disponible en la caja ($ ") +
                                sesionCaja.EfectivoEsperado.ToString("N2") + ").", ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMonto.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Eventos

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDisponible();
        }

        private void chkDesdeCaja_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarDisponible();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            nudMonto.Value = saldo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            ClsPagoCompraEntidad pago = new ClsPagoCompraEntidad();
            pago.IdCompra = idCompra;
            pago.IdMetodoPago = Convert.ToInt32(cmbMedioPago.SelectedValue);
            pago.Monto = nudMonto.Value;
            pago.IdUsuario = SesionUsuario.IdUsuario;
            pago.IdSesionCaja = (sesionCaja != null && chkDesdeCaja.Checked)
                ? sesionCaja.IdSesionCaja
                : (int?)null;
            pago.Observacion = txtObservacion.Text.Trim();

            try
            {
                pago = logica.RegistrarPago(pago);

                string mensaje = ClsIdioma.T("El pago se registró correctamente.\n\n") +
                                 ClsIdioma.T("Pago N.º ") + pago.IdPagoCompra +
                                 ClsIdioma.T("\nMonto: $ ") + pago.Monto.ToString("N2") +
                                 ClsIdioma.T("\nSaldo restante: $ ") + pago.SaldoRestante.ToString("N2");

                if (pago.SaldoRestante == 0)
                {
                    mensaje += ClsIdioma.T("\n\nLa compra quedó totalmente pagada.");
                }

                MessageBox.Show(mensaje, ClsIdioma.T("Pago registrado"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo registrar el pago.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
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
