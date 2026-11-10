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
            ClsIdioma.Registrar(this);
            ClsCampoNumerico.Enteros(txtCantidadLleva, txtCantidadPaga);



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
                lblLoQueLleva.Text = ClsIdioma.T("Llevás: —");
                lblLoQueRecibe.Text = ClsIdioma.T("Pagás: —");
                return;
            }

            lblLoQueLleva.Text = (ClsIdioma.Ingles ? $"You take {lleva} units" : $"Llevás {lleva} unidades");
            lblLoQueRecibe.Text = (ClsIdioma.Ingles ? $"You pay {paga} units" : $"Pagás {paga} unidades");
        }


        #endregion

        #region Eventos
        private void btnGuardarMecanica_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCantidadLleva.Text.Trim(), out int lleva) || lleva <= 0)
            {
                MessageBox.Show(ClsIdioma.T("Ingresá una cantidad válida para lo que lleva."));
                txtCantidadLleva.Focus();
                return;
            }

            if (!int.TryParse(txtCantidadPaga.Text.Trim(), out int paga) || paga <= 0)
            {
                MessageBox.Show(ClsIdioma.T("Ingresá una cantidad válida para lo que paga."));
                txtCantidadPaga.Focus();
                return;
            }

            if (paga >= lleva)
            {
                MessageBox.Show(ClsIdioma.T("La cantidad que paga debe ser menor que la cantidad que lleva."));
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
        #endregion

  
    }
}
