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
    public partial class frmIngresoUsuarioContra : Form
    {
        private int idUsuario = 0;
        public frmIngresoUsuarioContra()
        {
            InitializeComponent();
        }

        private void btnValidarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIngresoUsuario.Text))
            {
                MessageBox.Show("Ingrese un usuario.");
                return;
            }

            ClsUsuarioLogica logica = new ClsUsuarioLogica();

            idUsuario = logica.ObtenerIdUsuario(txtIngresoUsuario.Text.Trim());

            // Mismo mensaje si el usuario no existe o no tiene preguntas cargadas,
            // para no revelar qué usuarios existen.
            if (idUsuario == 0 || !new ClsPreguntaSeguridadLogica().UsuarioTienePreguntas(idUsuario))
            {
                MessageBox.Show("No es posible recuperar la contraseña con los datos ingresados.\n" +
                    "Verifique el usuario o contacte al administrador.", "Recuperar contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (new ClsPreguntaSeguridadLogica().RecuperoBloqueado(idUsuario))
            {
                MessageBox.Show(ClsPreguntaSeguridadLogica.MensajeRecuperoBloqueado, "Recuperar contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmRecupResSegur frm = new frmRecupResSegur(idUsuario);

            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void txtIngresoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionCampoVacio validar = new ValidacionCampoVacio();

            if (validar.EsEspacioInicial(txtIngresoUsuario.Text, e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
