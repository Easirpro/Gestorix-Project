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
        }

        #region Metodos
        private bool GuardarPreguntas()
        {
            if (string.IsNullOrWhiteSpace(txtNombreMascota.Text) ||
                string.IsNullOrWhiteSpace(txtLibro.Text) ||
                string.IsNullOrWhiteSpace(txtComida.Text))
            {
                MessageBox.Show("Debe responder las tres preguntas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                MessageBox.Show("No se pudieron guardar las preguntas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show( "Las preguntas de seguridad se guardaron correctamente.","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // El login sigue con el menú principal.
                this.DialogResult = DialogResult.OK;
                this.Close();

                #endregion

            }
        }
    }
}
