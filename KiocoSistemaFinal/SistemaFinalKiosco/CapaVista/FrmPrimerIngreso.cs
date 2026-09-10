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
            lblMinimo.Text = (minimo ? "✔" : "❌") + " Mínimo 8 caracteres";
            lblMayuscula.Text = (mayuscula ? "✔" : "❌") + " Una mayúscula";
            lblMinuscula.Text = (minuscula ? "✔" : "❌") + " Una minúscula";
            lblNumero.Text = (numero ? "✔" : "❌") + " Un número";
            lblCoincide.Text = (coincide ? "✔" : "❌") + " Las contraseñas coinciden";

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

            if (validar.ValidarCamposVacios(txtPassTemporal.Text) ||
                validar.ValidarCamposVacios(txtNuevaPass.Text) ||
                validar.ValidarCamposVacios(txtConfirmarPass.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            ClsPrimerIngreso primerIngreso = new ClsPrimerIngreso();

            ResultadoCambioPassword resultado =primerIngreso.CambiarPassword( txtPassTemporal.Text, txtNuevaPass.Text, txtConfirmarPass.Text);

            switch (resultado)
            {
                case ResultadoCambioPassword.Correcto:

                    MessageBox.Show("Contraseña modificada correctamente.");

                    ClsPreguntaSeguridadLogica logica = new ClsPreguntaSeguridadLogica();

                    bool tienePreguntas = logica.UsuarioTienePreguntas(SesionUsuario.IdUsuario);

                    if (!tienePreguntas)
                    {
                        frmPreguntasSegu preguntas = new frmPreguntasSegu();
                        preguntas.Show();
                        this.Close();

                        break;
                    }

                    frmmenuPres menu = new frmmenuPres();
                    menu.Show();

                    this.Close();

                    break;

                case ResultadoCambioPassword.PasswordTemporalIncorrecta:

                    MessageBox.Show("La contraseña temporal es incorrecta.");

                    break;

                case ResultadoCambioPassword.PasswordNoCoinciden:

                    MessageBox.Show("Las contraseñas no coinciden.");

                    break;

                case ResultadoCambioPassword.PasswordIgualAnterior:

                    MessageBox.Show("La nueva contraseña debe ser distinta de la temporal.");

                    break;

                case ResultadoCambioPassword.PasswordNoCumpleRequisitos:

                    MessageBox.Show(
                        "La contraseña debe tener como mínimo 8 caracteres, " +
                        "una mayúscula, una minúscula y un número.",
                        "Contraseña no válida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNuevaPass.Focus();
                    txtNuevaPass.SelectAll();

                    break;
            }
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
