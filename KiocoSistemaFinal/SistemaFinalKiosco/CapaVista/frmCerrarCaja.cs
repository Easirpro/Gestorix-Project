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
    public partial class frmCerrarCaja : Form
    {
        private ClsCajaLogica logica = new ClsCajaLogica();

        private readonly int idSesionCaja;
        private decimal efectivoEsperado;

        public frmCerrarCaja(int idSesionCaja)
        {
            InitializeComponent();
            this.idSesionCaja = idSesionCaja;
        }

        private void frmCerrarCaja_Load(object sender, EventArgs e)
        {
            // Se vuelve a leer la sesión para tener el esperado al momento del cierre.
            try
            {
                ClsSesionCajaEntidad sesion = logica.ObtenerSesionAbierta();

                if (sesion == null || sesion.IdSesionCaja != idSesionCaja)
                {
                    MessageBox.Show("La caja ya no está abierta.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                efectivoEsperado = sesion.EfectivoEsperado;
                lblFondo.Text = $"$ {sesion.MontoInicial:N2}";
                lblIngresos.Text = $"$ {sesion.IngresosEfectivo:N2}";
                lblEgresos.Text = $"$ {sesion.EgresosEfectivo:N2}";
                lblEsperado.Text = $"$ {efectivoEsperado:N2}";

                nudEfectivoContado.Value = 0;
                MostrarDiferencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la caja.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #region Metodos

        private void MostrarDiferencia()
        {
            decimal diferencia = nudEfectivoContado.Value - efectivoEsperado;

            if (diferencia < 0)
            {
                lblDiferencia.Text = $"$ {diferencia:N2}  (faltante)";
                lblDiferencia.ForeColor = Color.Firebrick;
            }
            else if (diferencia > 0)
            {
                lblDiferencia.Text = $"$ {diferencia:N2}  (sobrante)";
                lblDiferencia.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblDiferencia.Text = "$ 0,00  (correcta)";
                lblDiferencia.ForeColor = Color.SeaGreen;
            }
        }

        #endregion

        #region Eventos

        private void nudEfectivoContado_ValueChanged(object sender, EventArgs e)
        {
            MostrarDiferencia();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            decimal diferencia = nudEfectivoContado.Value - efectivoEsperado;

            if (diferencia != 0 && string.IsNullOrWhiteSpace(txtObservacion.Text))
            {
                MessageBox.Show("Hay una diferencia en la caja. Ingrese una observación que la explique.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacion.Focus();
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Confirma el cierre de la caja?\n\n" +
                "Esperado: $ " + efectivoEsperado.ToString("N2") +
                "\nContado: $ " + nudEfectivoContado.Value.ToString("N2") +
                "\nDiferencia: $ " + diferencia.ToString("N2") +
                "\n\nUna vez cerrada no se podrán modificar sus movimientos.",
                "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            ClsCierreCajaEntidad cierre = new ClsCierreCajaEntidad();
            cierre.IdSesionCaja = idSesionCaja;
            cierre.IdUsuario = SesionUsuario.IdUsuario;
            cierre.EfectivoContado = nudEfectivoContado.Value;
            cierre.Observacion = txtObservacion.Text.Trim();

            try
            {
                cierre = logica.CerrarCaja(cierre);

                string resultado = cierre.Diferencia < 0 ? "Faltante"
                                 : cierre.Diferencia > 0 ? "Sobrante"
                                 : "Sin diferencias";

                MessageBox.Show("La caja se cerró correctamente.\n\n" +
                                "Esperado: $ " + cierre.EfectivoEsperado.ToString("N2") +
                                "\nContado: $ " + cierre.EfectivoContado.ToString("N2") +
                                "\nDiferencia: $ " + cierre.Diferencia.ToString("N2") + "  (" + resultado + ")",
                    "Caja cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cerrar la caja.\n\n" + ex.Message, "Error",
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
