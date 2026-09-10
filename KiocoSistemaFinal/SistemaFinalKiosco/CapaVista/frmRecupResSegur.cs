using CapaEntidades;
using CapaLogica;
using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmRecupResSegur : Form
    {
        private int idUsuario;
        private int idPregunta;

        public frmRecupResSegur(int idUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;

            this.Load += frmRecupResSegur_Load;
            btnAceptar.Click += btnAceptar_Click;
        }

        private void frmRecupResSegur_Load(object sender, EventArgs e)
        {
            ClsUsuarioLogica logica = new ClsUsuarioLogica();

            ClsPreguntaSeguridad pregunta = logica.ObtenerPregunta(idUsuario);

            if (pregunta != null)
            {
                idPregunta = pregunta.IdPregunta;

                lblPregun.Text = pregunta.Pregunta;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ClsPreguntaSeguridadLogica logica = new ClsPreguntaSeguridadLogica();

            bool correcta = logica.ValidarRespuesta(
                idUsuario,
                idPregunta,
                txtRespuesta.Text.Trim()
            );

            if (correcta)
            {
                FrmRecuperarPass frm = new FrmRecuperarPass(idUsuario);
                this.Hide();
                frm.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta.");
            }
        }

        private void txtRespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionCampoVacio validar = new ValidacionCampoVacio();

            if (validar.EsEspacioInicial(txtRespuesta.Text, e.KeyChar))
            {
                e.Handled = true;
            }
        }

    
    }
}