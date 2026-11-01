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
    public partial class frmPreguntasSegu : Form
    {
        public frmPreguntasSegu()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
        }

        #region Metodos
        private bool GuardarPreguntas()
        {
            if (string.IsNullOrWhiteSpace(txtNombreMascota.Text) ||
                string.IsNullOrWhiteSpace(txtLibro.Text) ||
                string.IsNullOrWhiteSpace(txtComida.Text))
            {
                MessageBox.Show(ClsIdioma.T("Debe responder las tres preguntas."), ClsIdioma.T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            ClsPreguntaSeguridadLogica logica = new ClsPreguntaSeguridadLogica();

            bool ok;

            try
            {
                ok = logica.GuardarPreguntas(SesionUsuario.IdUsuario, 1, txtNombreMascota.Text.Trim(), 2, txtLibro.Text.Trim(), 3, txtComida.Text.Trim());
            }
            catch
            {
                ok = false;
            }

            if (!ok)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron guardar las preguntas."), ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
        #endregion

        #region Evento
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (GuardarPreguntas())
            {
                MessageBox.Show( ClsIdioma.T("Las preguntas de seguridad se guardaron correctamente."),ClsIdioma.T("Información"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();

                #endregion

            }
        }
    }
}
