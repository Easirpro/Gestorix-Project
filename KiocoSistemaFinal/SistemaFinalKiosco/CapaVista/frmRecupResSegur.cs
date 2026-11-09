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
            ClsIdioma.Registrar(this);

            this.idUsuario = idUsuario;

            // aviso segun las constantes del bloqueo
            int intentos = ClsPreguntaSeguridadLogica.MAX_INTENTOS_RECUPERO;
            int minutos = ClsPreguntaSeguridadLogica.MINUTOS_BLOQUEO_RECUPERO;

            lblIntentos.Text = ClsIdioma.Ingles
                ? "For security, after " + intentos + " wrong answers you will have to wait " + minutos + " minutes."
                : "Por seguridad, después de " + intentos + " respuestas incorrectas vas a tener que esperar " + minutos + " minutos.";

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

                lblPregun.Text = ClsIdioma.T(pregunta.Pregunta);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // vacia no cuenta como intento
            if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                MessageBox.Show(ClsIdioma.T("Escriba la respuesta."), ClsIdioma.T("Recuperar contraseña"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtRespuesta.Focus();
                return;
            }

            ClsPreguntaSeguridadLogica logica = new ClsPreguntaSeguridadLogica();

            if (logica.RecuperoBloqueado(idUsuario))
            {
                MessageBox.Show(ClsIdioma.T(ClsPreguntaSeguridadLogica.MensajeRecuperoBloqueado), ClsIdioma.T("Recuperar contraseña"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
                return;
            }

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
            else if (logica.RecuperoBloqueado(idUsuario))
            {
                MessageBox.Show(ClsIdioma.T(ClsPreguntaSeguridadLogica.MensajeRecuperoBloqueado), ClsIdioma.T("Recuperar contraseña"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }
            else
            {
                MessageBox.Show(ClsIdioma.T("Respuesta incorrecta."), ClsIdioma.T("Recuperar contraseña"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtRespuesta.Clear();
                txtRespuesta.Focus();
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