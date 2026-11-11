using CapaEntidades;
using CapaLogica;
using System;
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
    public partial class FrmPrimerIngreso : Form
    {
        public FrmPrimerIngreso()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ValidarRequisitosPassword();
        }
        private void ValidarRequisitosPassword()
        {
            string password = txtNuevaPass.Text;
            string confirmar = txtConfirmarPass.Text;

            bool minimo = password.Length >= 8;
            bool mayuscula = password.Any(char.IsUpper);
            bool minuscula = password.Any(char.IsLower);
            bool numero = password.Any(char.IsDigit);
            bool coincide = password == confirmar && confirmar.Length > 0;

            // Cambia el texto
            lblMinimo.Text = (minimo ? "✔" : "❌") + ClsIdioma.T(" Mínimo 8 caracteres");
            lblMayuscula.Text = (mayuscula ? "✔" : "❌") + ClsIdioma.T(" Una mayúscula");
            lblMinuscula.Text = (minuscula ? "✔" : "❌") + ClsIdioma.T(" Una minúscula");
            lblNumero.Text = (numero ? "✔" : "❌") + ClsIdioma.T(" Un número");
            lblCoincide.Text = (coincide ? "✔" : "❌") + ClsIdioma.T(" Las contraseñas coinciden");

            // Cambia el color
            lblMinimo.ForeColor = minimo ? Color.Green : Color.Red;
            lblMayuscula.ForeColor = mayuscula ? Color.Green : Color.Red;
            lblMinuscula.ForeColor = minuscula ? Color.Green : Color.Red;
            lblNumero.ForeColor = numero ? Color.Green : Color.Red;
            lblCoincide.ForeColor = coincide ? Color.Green : Color.Red;
        }
        private void btnCambiarPass_Click(object sender, EventArgs e)
        {

            ValidacionCampoVacio validar = new ValidacionCampoVacio();

            if (validar.ValidarCamposVacios(txtPassTemporal.Text) || validar.ValidarCamposVacios(txtNuevaPass.Text) || validar.ValidarCamposVacios(txtConfirmarPass.Text))
            {
                MessageBox.Show(ClsIdioma.T("Complete todos los campos."), ClsIdioma.T("Datos incompletos"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClsPrimerIngreso primerIngreso = new ClsPrimerIngreso();

            ResultadoCambioPassword resultado =primerIngreso.CambiarPassword( txtPassTemporal.Text, txtNuevaPass.Text, txtConfirmarPass.Text);

            switch (resultado)
            {
                case ResultadoCambioPassword.Correcto:

                    MessageBox.Show(ClsIdioma.T("Contraseña modificada correctamente."), ClsIdioma.T("Primer ingreso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    break;

                case ResultadoCambioPassword.PasswordTemporalIncorrecta:

                    MessageBox.Show(ClsIdioma.T("La contraseña temporal es incorrecta."), ClsIdioma.T("Contraseña no válida"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;

                case ResultadoCambioPassword.PasswordNoCoinciden:

                    MessageBox.Show(ClsIdioma.T("Las contraseñas no coinciden."), ClsIdioma.T("Contraseña no válida"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;

                case ResultadoCambioPassword.PasswordIgualAnterior:

                    MessageBox.Show(ClsIdioma.T("La nueva contraseña debe ser distinta de la temporal."), ClsIdioma.T("Contraseña no válida"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;

                case ResultadoCambioPassword.PasswordNoCumpleRequisitos:

                    MessageBox.Show(
                        ClsIdioma.T(ClsReglasPassword.Requisitos),
                        ClsIdioma.T("Contraseña no válida"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNuevaPass.Focus();
                    txtNuevaPass.SelectAll();

                    break;
            }
        }
        // muestra u oculta la contraseña del campo de al lado
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            TextBox campo = boton == btnMostrarTemporal ? txtPassTemporal : boton == btnMostrarNueva ? txtNuevaPass : txtConfirmarPass;

            campo.UseSystemPasswordChar = !campo.UseSystemPasswordChar;
            boton.Text = campo.UseSystemPasswordChar ? "👁️" : "🔒";
        }
        private void txtNuevaPass_TextChanged(object sender, EventArgs e)
        {
            ValidarRequisitosPassword();
        }
        private void txtConfirmarPass_TextChanged(object sender, EventArgs e)
        {
            ValidarRequisitosPassword();
        }
    }
}
