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
    public partial class frmCaja : Form
    {
        private ClsCajaLogica logica = new ClsCajaLogica();

        private ClsSesionCajaEntidad sesionActual;

        public frmCaja()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ClsGrilla.AjustarAlContenido(dgvMovimientos);
            ConfigurarGrid();
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            CargarEstado();
        }

        #region Metodos

        private void ConfigurarGrid()
        {
            dgvMovimientos.AutoGenerateColumns = true;
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToResizeColumns = false;
            dgvMovimientos.AllowUserToOrderColumns = false;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarEstado()
        {
            try
            {
                sesionActual = logica.ObtenerSesionAbierta();

                if (sesionActual == null)
                {
                    lblEstado.Text = ClsIdioma.T("CAJA CERRADA");
                    lblEstado.ForeColor = Color.Firebrick;
                    lblAbiertaPor.Text = ClsIdioma.T("Abierta por: -");
                    lblFechaApertura.Text = ClsIdioma.T("Apertura: -");
                    lblFondo.Text = "$ 0,00";
                    lblIngresos.Text = "$ 0,00";
                    lblEgresos.Text = "$ 0,00";
                    lblEsperado.Text = "$ 0,00";
                    lblOtrosMedios.Text = "$ 0,00";
                    dgvMovimientos.DataSource = null;
                }
                else
                {
                    lblEstado.Text = ClsIdioma.T("CAJA ABIERTA");
                    lblEstado.ForeColor = Color.SeaGreen;
                    lblAbiertaPor.Text = ClsIdioma.T("Sesión N.º ") + sesionActual.IdSesionCaja + ClsIdioma.T("  -  Abierta por: ") + sesionActual.UsuarioApertura;
                    lblFechaApertura.Text = ClsIdioma.T("Apertura: ") + sesionActual.FechaApertura.ToString("dd/MM/yyyy HH:mm");
                    lblFondo.Text = $"$ {sesionActual.MontoInicial:N2}";
                    lblIngresos.Text = $"$ {sesionActual.IngresosEfectivo:N2}";
                    lblEgresos.Text = $"$ {sesionActual.EgresosEfectivo:N2}";
                    lblEsperado.Text = $"$ {sesionActual.EfectivoEsperado:N2}";
                    lblOtrosMedios.Text = $"$ {sesionActual.IngresosOtrosMedios:N2}";

                    dgvMovimientos.DataSource = logica.ObtenerMovimientosSesion(sesionActual.IdSesionCaja);
                }

                CargarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo obtener el estado de la caja.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarBotones()
        {
            bool abierta = sesionActual != null;

            btnAbrirCaja.Enabled = !abierta && SesionUsuario.Permisos.Contains(730);
            btnNuevoIngreso.Enabled = abierta && SesionUsuario.Permisos.Contains(710);
            btnNuevoEgreso.Enabled = abierta && SesionUsuario.Permisos.Contains(720);
            btnCerrarCaja.Enabled = abierta && SesionUsuario.Permisos.Contains(740);
            btnAnularMovimiento.Enabled = abierta && SesionUsuario.Permisos.Contains(760);
            btnHistorial.Enabled = SesionUsuario.Permisos.Contains(750);
        }

        private void AbrirMovimiento(frmmenuPres.TipoMovimiento tipo)
        {
            if (sesionActual == null)
            {
                return;
            }

            using (frmIngresoPlataCaja formulario = new frmIngresoPlataCaja(tipo))
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    CargarEstado();
                }
            }
        }

        #endregion

        #region Eventos

        private void dgvMovimientos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string[] ocultas = { "Origen", "IdOrigen", "Anulable" };
            foreach (string nombre in ocultas)
            {
                if (dgvMovimientos.Columns.Contains(nombre))
                {
                    dgvMovimientos.Columns[nombre].Visible = false;
                }
            }

            if (dgvMovimientos.Columns.Contains("FechaHora"))
            {
                dgvMovimientos.Columns["FechaHora"].HeaderText = ClsIdioma.T("Fecha y hora");
                dgvMovimientos.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvMovimientos.Columns.Contains("MedioPago"))
            {
                dgvMovimientos.Columns["MedioPago"].HeaderText = ClsIdioma.T("Medio de pago");
            }
            if (dgvMovimientos.Columns.Contains("RegistradoPor"))
            {
                dgvMovimientos.Columns["RegistradoPor"].HeaderText = ClsIdioma.T("Registrado por");
            }
            if (dgvMovimientos.Columns.Contains("Observacion"))
            {
                dgvMovimientos.Columns["Observacion"].HeaderText = ClsIdioma.T("Observación");
            }
            if (dgvMovimientos.Columns.Contains("Importe"))
            {
                dgvMovimientos.Columns["Importe"].DefaultCellStyle.Format = "N2";
                dgvMovimientos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            foreach (DataGridViewRow fila in dgvMovimientos.Rows)
            {
                if (fila.Cells["Tipo"].Value?.ToString() == "Egreso")
                {
                    fila.DefaultCellStyle.ForeColor = Color.Firebrick;
                }
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            using (frmAbrirCaja formulario = new frmAbrirCaja())
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    CargarEstado();
                }
            }
        }

        private void btnNuevoIngreso_Click(object sender, EventArgs e)
        {
            AbrirMovimiento(frmmenuPres.TipoMovimiento.Ingreso);
        }

        private void btnNuevoEgreso_Click(object sender, EventArgs e)
        {
            AbrirMovimiento(frmmenuPres.TipoMovimiento.Egreso);
        }

        private void btnAnularMovimiento_Click(object sender, EventArgs e)
        {
            if (dgvMovimientos.CurrentRow == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un movimiento."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvMovimientos.CurrentRow;

            if (!Convert.ToBoolean(fila.Cells["Anulable"].Value))
            {
                MessageBox.Show(ClsIdioma.T("Solo se pueden anular desde acá los ingresos y egresos manuales.\n\n") +
                                ClsIdioma.T("Las ventas, devoluciones y pagos a proveedores se anulan desde su propio módulo."),
                    ClsIdioma.T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idMovimiento = Convert.ToInt32(fila.Cells["IdOrigen"].Value);

            string motivo = Microsoft.VisualBasic.Interaction.InputBox(ClsIdioma.T("Ingrese el motivo de la anulación:"),
                ClsIdioma.T("Anular movimiento"), "");

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show(ClsIdioma.T("Debe ingresar un motivo para anular el movimiento."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Está seguro de anular este movimiento?\n\n") +
                fila.Cells["Concepto"].Value + "  $ " + Convert.ToDecimal(fila.Cells["Importe"].Value).ToString("N2") +
                ClsIdioma.T("\nMotivo: ") + motivo, ClsIdioma.T("Confirmar anulación"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                logica.AnularMovimiento(idMovimiento, motivo.Trim(), SesionUsuario.IdUsuario);

                MessageBox.Show(ClsIdioma.T("El movimiento fue anulado correctamente."), ClsIdioma.T("Movimiento anulado"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo anular el movimiento.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (sesionActual == null)
            {
                return;
            }

            using (frmCerrarCaja formulario = new frmCerrarCaja(sesionActual.IdSesionCaja))
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    CargarEstado();
                }
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            using (frmHistorialCaja formulario = new frmHistorialCaja())
            {
                formulario.ShowDialog();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarEstado();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
