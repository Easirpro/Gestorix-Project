using CapaLogica;
using CapaSesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CapaVista
{
    public partial class FrmRecuperarPass : Form
    {
        private int idUsuario = 0;
        public FrmRecuperarPass(int idUsuario)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.idUsuario = idUsuario;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnMostrar1_Click(object sender, EventArgs e)
        {

            txtIngCodigo.UseSystemPasswordChar = !txtIngCodigo.UseSystemPasswordChar;

            if (txtIngCodigo.UseSystemPasswordChar)
            {
                btnMostrar1.Text = "👁️";
            }
            else
            {
                btnMostrar1.Text = "🔒";
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            txtCorreo.UseSystemPasswordChar = !txtCorreo.UseSystemPasswordChar;

            if (txtCorreo.UseSystemPasswordChar)
            {
                btnMostrar.Text = "👁️";
            }
            else
            {
                btnMostrar.Text = "🔒";
            }
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtIngCodigo.Text))
            {
                MessageBox.Show(ClsIdioma.T(" Complete ambos campos. "), ClsIdioma.T(" Campos incompletos "),MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            // txtCorreo es la contraseña nueva y txtIngCodigo su confirmación (nombres de un diseño anterior).
            ClsRecuperarPassword recuperar = new ClsRecuperarPassword();

            ResultadoCambioPassword resultado = recuperar.CambiarPassword(idUsuario, txtCorreo.Text, txtIngCodigo.Text);

            switch (resultado)
            {
                case ResultadoCambioPassword.Correcto:
                    MessageBox.Show(ClsIdioma.T("La contraseña se cambió correctamente."), ClsIdioma.T("Contraseña actualizada"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;

                case ResultadoCambioPassword.PasswordNoCoinciden:
                    MessageBox.Show(ClsIdioma.T("Las contraseñas no coinciden."), ClsIdioma.T("Contraseña no válida"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case ResultadoCambioPassword.PasswordNoCumpleRequisitos:
                    MessageBox.Show(ClsReglasPassword.Requisitos, ClsIdioma.T("Contraseña no válida"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                    break;

                case ResultadoCambioPassword.PasswordIgualAnterior:
                    MessageBox.Show(ClsIdioma.T("La contraseña nueva debe ser distinta de la actual."), ClsIdioma.T("Contraseña no válida"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case ResultadoCambioPassword.PasswordUsadaRecientemente:
                    MessageBox.Show(ClsIdioma.T("No puede utilizar ninguna de sus últimas 3 contraseñas."), ClsIdioma.T("Contraseña no válida"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                default:
                    MessageBox.Show(ClsIdioma.T("No se pudo cambiar la contraseña."), ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        //validacion txt de correro
        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionCampoVacio validar = new ValidacionCampoVacio();

            if (validar.EsEspacioInicial(txtCorreo.Text, e.KeyChar))
            {
                e.Handled = true;
            }

        }

        //validacion txt de ingcodigo
        private void txtIngCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionCampoVacio validar = new ValidacionCampoVacio();

            if (validar.EsEspacioInicial(txtIngCodigo.Text, e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
