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
    public partial class frmAbrirCaja : Form
    {
        private ClsCajaLogica logica = new ClsCajaLogica();

        public frmAbrirCaja()
        {
            InitializeComponent();
        }

        private void frmAbrirCaja_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + SesionUsuario.Username;
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            nudMontoInicial.Value = 0;
            nudMontoInicial.Select(0, nudMontoInicial.Text.Length);
        }

        #region Eventos

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            decimal montoInicial = nudMontoInicial.Value;

            if (montoInicial == 0)
            {
                DialogResult respuesta = MessageBox.Show("Va a abrir la caja sin fondo inicial. ¿Desea continuar?",
                    "Confirmar apertura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                int idSesion = logica.AbrirCaja(SesionUsuario.IdUsuario, montoInicial);

                MessageBox.Show("La caja se abrió correctamente.\n\nSesión N.º " + idSesion +
                                "\nFondo inicial: $ " + montoInicial.ToString("N2"),
                    "Caja abierta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la caja.\n\n" + ex.Message, "Error",
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
