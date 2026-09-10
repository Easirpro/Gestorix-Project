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

            if (idUsuario == 0)
            {
                MessageBox.Show("El usuario no existe.");
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
