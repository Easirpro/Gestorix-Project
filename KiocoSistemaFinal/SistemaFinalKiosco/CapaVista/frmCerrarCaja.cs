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
            ClsIdioma.Registrar(this);
            this.idSesionCaja = idSesionCaja;
        }

        private void frmCerrarCaja_Load(object sender, EventArgs e)
        {
            try
            {
                ClsSesionCajaEntidad sesion = logica.ObtenerSesionAbierta();

                if (sesion == null || sesion.IdSesionCaja != idSesionCaja)
                {
                    MessageBox.Show(ClsIdioma.T("La caja ya no está abierta."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                efectivoEsperado = sesion.EfectivoEsperado;
                lblFondo.Text = $"{sesion.MontoInicial:C2}";
                lblIngresos.Text = $"{sesion.IngresosEfectivo:C2}";
                lblEgresos.Text = $"{sesion.EgresosEfectivo:C2}";
                lblEsperado.Text = $"{efectivoEsperado:C2}";

                nudEfectivoContado.Value = 0;
                MostrarDiferencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo obtener la caja.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
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
                lblDiferencia.Text = (ClsIdioma.Ingles ? $"{diferencia:C2}  (short)" : $"{diferencia:C2}  (faltante)");
                lblDiferencia.ForeColor = Color.Firebrick;
            }
            else if (diferencia > 0)
            {
                lblDiferencia.Text = (ClsIdioma.Ingles ? $"{diferencia:C2}  (over)" : $"{diferencia:C2}  (sobrante)");
                lblDiferencia.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblDiferencia.Text = ClsIdioma.T("$ 0,00  (correcta)");
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
                MessageBox.Show(ClsIdioma.T("Hay una diferencia en la caja. Ingrese una observación que la explique."),
                    ClsIdioma.T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacion.Focus();
                return;
            }

            DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Confirma el cierre de la caja?\n\n") +
                ClsIdioma.T("Esperado: $ ") + efectivoEsperado.ToString("N2") +
                ClsIdioma.T("\nContado: $ ") + nudEfectivoContado.Value.ToString("N2") +
                ClsIdioma.T("\nDiferencia: $ ") + diferencia.ToString("N2") +
                ClsIdioma.T("\n\nUna vez cerrada no se podrán modificar sus movimientos."),
                ClsIdioma.T("Confirmar cierre"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                string resultado = cierre.Diferencia < 0 ? ClsIdioma.T("Faltante")
                                 : cierre.Diferencia > 0 ? ClsIdioma.T("Sobrante")
                                 : ClsIdioma.T("Sin diferencias");

                MessageBox.Show(ClsIdioma.T("La caja se cerró correctamente.\n\n") +
                                ClsIdioma.T("Esperado: $ ") + cierre.EfectivoEsperado.ToString("N2") +
                                ClsIdioma.T("\nContado: $ ") + cierre.EfectivoContado.ToString("N2") +
                                ClsIdioma.T("\nDiferencia: $ ") + cierre.Diferencia.ToString("N2") + "  (" + resultado + ")",
                    ClsIdioma.T("Caja cerrada"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo cerrar la caja.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
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
