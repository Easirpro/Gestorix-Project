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
        private string username = "";
        public FrmRecuperarPass(int idUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;

            ClsUsuarioLogica logica = new ClsUsuarioLogica();

            username = logica.ObtenerUsername(idUsuario);
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
                MessageBox.Show(" Complete ambos campos. ", " Campos incompletos ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (txtCorreo.Text != txtIngCodigo.Text)
            {
                MessageBox.Show(" Las contraseñas no coinciden. ", " Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClsUsuarioLogica logica = new ClsUsuarioLogica();

            string nuevaPasswordHash = ClsSeguridad.SHA256(username + txtCorreo.Text);

            string passAnterior = logica.ObtenerUltimaPasswordAntigua(idUsuario);

            if (passAnterior == nuevaPasswordHash)
            {
                MessageBox.Show("No puede utilizar la contraseña anterior.", "Contraseña no válida",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            bool usada = logica.PasswordUsadaUltimasTres(idUsuario, nuevaPasswordHash);

            if (usada)
            {
                MessageBox.Show("No puede utilizar ninguna de sus últimas 3 contraseñas.","Contraseña no válida",MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            bool cambio = logica.CambiarPasswordRecuperacion(idUsuario, nuevaPasswordHash);

            if (cambio)
            {
                MessageBox.Show("La contraseña se cambió correctamente.", "Contraseña actualizada",MessageBoxButtons.OK,MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo cambiar la contraseña.","Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
