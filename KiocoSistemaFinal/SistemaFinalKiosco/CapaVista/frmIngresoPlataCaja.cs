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
    public partial class frmIngresoPlataCaja : Form
    {
        private ClsCajaLogica logica = new ClsCajaLogica();

        private readonly string tipo;                      // "I" ingreso, "E" egreso
        private ClsSesionCajaEntidad sesion;               // caja abierta
        private DataTable tablaConceptos;
        private bool cargando = true;

        // Mismo constructor que ya usa el menú principal:
        //   new frmIngresoPlataCaja(TipoMovimiento.Ingreso) / (TipoMovimiento.Egreso)
        public frmIngresoPlataCaja(frmmenuPres.TipoMovimiento tipoMovimiento)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            this.tipo = tipoMovimiento == frmmenuPres.TipoMovimiento.Ingreso ? "I" : "E";
        }

        private void frmIngresoPlataCaja_Load(object sender, EventArgs e)
        {
            // Sin caja abierta no se pueden registrar movimientos.
            try
            {
                sesion = logica.ObtenerSesionAbierta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo obtener el estado de la caja.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (sesion == null)
            {
                MessageBox.Show(ClsIdioma.T("No hay una caja abierta. Abra la caja antes de registrar movimientos."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            bool esIngreso = tipo == "I";
            this.Text = esIngreso ? ClsIdioma.T("Nuevo ingreso de caja") : ClsIdioma.T("Nuevo egreso de caja");
            lblTitulo.Text = esIngreso ? ClsIdioma.T("Nuevo ingreso") : ClsIdioma.T("Nuevo egreso");
            lblTitulo.ForeColor = esIngreso ? Color.SeaGreen : Color.Firebrick;

            try
            {
                CargarConceptos();
                CargarMediosPago();
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los datos.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cargando = false;
            ActualizarEmpleado();
            ActualizarDisponible();
        }

        #region Metodos

        private void CargarConceptos()
        {
            tablaConceptos = logica.ObtenerConceptos(tipo);
            cmbConcepto.DataSource = tablaConceptos;
            cmbConcepto.DisplayMember = "Nombre";
            cmbConcepto.ValueMember = "IdConceptoCaja";
        }

        private void CargarMediosPago()
        {
            DataTable tabla = logica.ObtenerMetodosPago();

            // "Cuenta Corriente" no mueve dinero de la caja: se quita del combo.
            foreach (DataRow fila in tabla.Select("Nombre = 'Cuenta Corriente'"))
            {
                tabla.Rows.Remove(fila);
            }

            cmbMedioPago.DataSource = tabla;
            cmbMedioPago.DisplayMember = "Nombre";
            cmbMedioPago.ValueMember = "IdMetodoPago";

            // Por defecto, efectivo.
            int indiceEfectivo = cmbMedioPago.FindStringExact("Efectivo");
            if (indiceEfectivo >= 0)
            {
                cmbMedioPago.SelectedIndex = indiceEfectivo;
            }
        }

        private void CargarEmpleados()
        {
            cmbEmpleado.DataSource = logica.ObtenerEmpleadosActivos();
            cmbEmpleado.DisplayMember = "Empleado";
            cmbEmpleado.ValueMember = "IdUsuario";
            cmbEmpleado.SelectedIndex = -1;
        }

        private bool ConceptoRequiereEmpleado()
        {
            DataRowView concepto = cmbConcepto.SelectedItem as DataRowView;
            return concepto != null && Convert.ToBoolean(concepto["RequiereEmpleado"]);
        }

        private bool EsEfectivo()
        {
            return cmbMedioPago.Text == "Efectivo";
        }

        private void ActualizarEmpleado()
        {
            bool requiere = ConceptoRequiereEmpleado();
            lblEmpleado.Enabled = requiere;
            cmbEmpleado.Enabled = requiere;

            if (!requiere)
            {
                cmbEmpleado.SelectedIndex = -1;
            }
        }

        private void ActualizarDisponible()
        {
            // En egresos de efectivo se muestra cuánto hay en la caja.
            if (tipo == "E" && EsEfectivo())
            {
                lblDisponible.Text = (ClsIdioma.Ingles ? $"Available: $ {sesion.EfectivoEsperado:N2}" : $"Disponible: $ {sesion.EfectivoEsperado:N2}");
            }
            else
            {
                lblDisponible.Text = "";
            }
        }

        private bool ValidarCampos()
        {
            if (cmbConcepto.SelectedValue == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un concepto."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbConcepto.Focus();
                return false;
            }

            if (cmbMedioPago.SelectedValue == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un medio de pago."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMedioPago.Focus();
                return false;
            }

            if (nudImporte.Value <= 0)
            {
                MessageBox.Show(ClsIdioma.T("El importe debe ser mayor a cero."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudImporte.Focus();
                return false;
            }

            if (tipo == "E" && EsEfectivo() && nudImporte.Value > sesion.EfectivoEsperado)
            {
                MessageBox.Show(ClsIdioma.T("El importe supera el efectivo disponible en la caja ($ ") +
                                sesion.EfectivoEsperado.ToString("N2") + ").", ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudImporte.Focus();
                return false;
            }

            if (ConceptoRequiereEmpleado() && cmbEmpleado.SelectedValue == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione el empleado que recibe el dinero."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmpleado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtObservacion.Text))
            {
                MessageBox.Show(ClsIdioma.T("Ingrese una observación (motivo del movimiento)."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacion.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Eventos

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargando)
            {
                ActualizarEmpleado();
            }
        }

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargando)
            {
                ActualizarDisponible();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            ClsMovimientoCajaEntidad movimiento = new ClsMovimientoCajaEntidad();
            movimiento.IdSesionCaja = sesion.IdSesionCaja;
            movimiento.IdConceptoCaja = Convert.ToInt32(cmbConcepto.SelectedValue);
            movimiento.IdMetodoPago = Convert.ToInt32(cmbMedioPago.SelectedValue);
            movimiento.Importe = nudImporte.Value;
            movimiento.Observacion = txtObservacion.Text.Trim();
            movimiento.IdUsuario = SesionUsuario.IdUsuario;
            movimiento.IdEmpleado = ConceptoRequiereEmpleado()
                ? Convert.ToInt32(cmbEmpleado.SelectedValue)
                : (int?)null;

            try
            {
                logica.RegistrarMovimiento(movimiento);

                MessageBox.Show(ClsIdioma.T("El movimiento se registró correctamente.\n\n") +
                                cmbConcepto.Text + ": $ " + movimiento.Importe.ToString("N2"),
                    ClsIdioma.T("Movimiento registrado"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo registrar el movimiento.\n\n") + ex.Message, ClsIdioma.T("Error"),
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
