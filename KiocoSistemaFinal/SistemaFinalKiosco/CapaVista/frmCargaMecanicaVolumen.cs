using System;
using System.Collections.Generic;
using System.ComponentModel;

using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmCargaMecanicaVolumen : Form
    {
        public int CantidadLlevaSeleccionada { get; private set; }
        public int CantidadPagaSeleccionada { get; private set; }

        public frmCargaMecanicaVolumen()
        {
            InitializeComponent();

            btnGuardarMecanica.Click += btnGuardarMecanica_Click_1;
            btnCancelar.Click += btnCancelar_Click;

            txtCantidadLleva.TextChanged += txtCantidadLleva_TextChanged;
            txtCantidadPaga.TextChanged += txtCantidadPaga_TextChanged;

            ActualizarVistaPrevia();
        }


        #region Metodos
        private void Cantidades_TextChanged(object sender, EventArgs e)
        {
            ActualizarVistaPrevia();
        }
        private void ActualizarVistaPrevia()
        {
            bool llevaValido = int.TryParse(txtCantidadLleva.Text.Trim(), out int lleva);
            bool pagaValida = int.TryParse(txtCantidadPaga.Text.Trim(), out int paga);

            if (!llevaValido || !pagaValida || lleva <= 0 || paga <= 0)
            {
                lblLoQueLleva.Text = "Llevás: —";
                lblLoQueRecibe.Text = "Pagás: —";
                return;
            }

            lblLoQueLleva.Text = $"Llevás {lleva} unidades";
            lblLoQueRecibe.Text = $"Pagás {paga} unidades";
        }


        #endregion

        #region Eventos
        private void btnGuardarMecanica_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCantidadLleva.Text.Trim(), out int lleva) || lleva <= 0)
            {
                MessageBox.Show("Ingresá una cantidad válida para lo que lleva.");
                txtCantidadLleva.Focus();
                return;
            }

            if (!int.TryParse(txtCantidadPaga.Text.Trim(), out int paga) || paga <= 0)
            {
                MessageBox.Show("Ingresá una cantidad válida para lo que paga.");
                txtCantidadPaga.Focus();
                return;
            }

            if (paga >= lleva)
            {
                MessageBox.Show("La cantidad que paga debe ser menor que la cantidad que lleva.");
                txtCantidadPaga.Focus();
                return;
            }

            CantidadLlevaSeleccionada = lleva;
            CantidadPagaSeleccionada = paga;

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void txtCantidadLleva_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCantidadPaga_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
