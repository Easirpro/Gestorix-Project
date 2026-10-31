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

        // Sesión abierta actual (null = caja cerrada).
        private ClsSesionCajaEntidad sesionActual;

        public frmCaja()
        {
            InitializeComponent();
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
                    lblEstado.Text = "CAJA CERRADA";
                    lblEstado.ForeColor = Color.Firebrick;
                    lblAbiertaPor.Text = "Abierta por: -";
                    lblFechaApertura.Text = "Apertura: -";
                    lblFondo.Text = "$ 0,00";
                    lblIngresos.Text = "$ 0,00";
                    lblEgresos.Text = "$ 0,00";
                    lblEsperado.Text = "$ 0,00";
                    lblOtrosMedios.Text = "$ 0,00";
                    dgvMovimientos.DataSource = null;
                }
                else
                {
                    lblEstado.Text = "CAJA ABIERTA";
                    lblEstado.ForeColor = Color.SeaGreen;
                    lblAbiertaPor.Text = "Sesión N.º " + sesionActual.IdSesionCaja + "  -  Abierta por: " + sesionActual.UsuarioApertura;
                    lblFechaApertura.Text = "Apertura: " + sesionActual.FechaApertura.ToString("dd/MM/yyyy HH:mm");
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
                MessageBox.Show("No se pudo obtener el estado de la caja.\n\n" + ex.Message, "Error",
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
            // Anular un movimiento manual queda solo para el administrador.
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
            // Columnas técnicas que no se muestran.
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
                dgvMovimientos.Columns["FechaHora"].HeaderText = "Fecha y hora";
                dgvMovimientos.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvMovimientos.Columns.Contains("MedioPago"))
            {
                dgvMovimientos.Columns["MedioPago"].HeaderText = "Medio de pago";
            }
            if (dgvMovimientos.Columns.Contains("RegistradoPor"))
            {
                dgvMovimientos.Columns["RegistradoPor"].HeaderText = "Registrado por";
            }
            if (dgvMovimientos.Columns.Contains("Observacion"))
            {
                dgvMovimientos.Columns["Observacion"].HeaderText = "Observación";
            }
            if (dgvMovimientos.Columns.Contains("Importe"))
            {
                dgvMovimientos.Columns["Importe"].DefaultCellStyle.Format = "N2";
                dgvMovimientos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Egresos en rojo para leer rápido la grilla.
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
                MessageBox.Show("Seleccione un movimiento.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvMovimientos.CurrentRow;

            if (!Convert.ToBoolean(fila.Cells["Anulable"].Value))
            {
                MessageBox.Show("Solo se pueden anular desde acá los ingresos y egresos manuales.\n\n" +
                                "Las ventas, devoluciones y pagos a proveedores se anulan desde su propio módulo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idMovimiento = Convert.ToInt32(fila.Cells["IdOrigen"].Value);

            string motivo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el motivo de la anulación:",
                "Anular movimiento", "");

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debe ingresar un motivo para anular el movimiento.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de anular este movimiento?\n\n" +
                fila.Cells["Concepto"].Value + "  $ " + Convert.ToDecimal(fila.Cells["Importe"].Value).ToString("N2") +
                "\nMotivo: " + motivo, "Confirmar anulación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                logica.AnularMovimiento(idMovimiento, motivo.Trim(), SesionUsuario.IdUsuario);

                MessageBox.Show("El movimiento fue anulado correctamente.", "Movimiento anulado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo anular el movimiento.\n\n" + ex.Message, "Error",
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
