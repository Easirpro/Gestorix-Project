using CapaEntidades;
using CapaLogica;
using CapaLogica.BitacoraLogi;
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

namespace CapaVista
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            this.AcceptButton = this.btnLogin;
            ConfigurarTransparencias();
        }
        private void ConfigurarTransparencias()
        {
            lblUsuario.Parent = panel1;
            lblUsuario.BackColor = Color.Transparent;
            lblContraseña.Parent = panel1;
            lblContraseña.BackColor = Color.Transparent;
            lkbOlvideContraseña.Parent = panel1;
            lkbOlvideContraseña.BackColor = Color.Transparent;
            btnMostrar.Parent = panel1;
            btnMostrar.BackColor = Color.Transparent;
        }
        public void LimpiarCampos()
        {
            txtUser.Clear();
            txtPass.Clear();
            txtUser.Focus();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidacionCampoVacio validoCV = new ValidacionCampoVacio();

            if (validoCV.ValidarCamposVacios(txtUser.Text) || validoCV.ValidarCamposVacios(txtPass.Text))
            {
                MessageBox.Show(ClsIdioma.T("Complete todos los campos antes de continuar"), ClsIdioma.T("Datos incompletos"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                ClsLogin login = new ClsLogin();

                bool ingreso = login.IniciarSesion(txtUser.Text.Trim(), txtPass.Text);

                if (!ingreso)
                {
                    if (login.UsuarioBloqueado)
                    {
                        MessageBox.Show(ClsIdioma.T("Usuario bloqueado."), ClsIdioma.T("Acceso denegado"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(ClsIdioma.T("Usuario o contraseña incorrectos."), ClsIdioma.T("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }

                ContinuarIngreso();
            }
            catch (Exception ex)
            {
                try
                {
                    clsBitacoraLogica bitacora = new clsBitacoraLogica();

                    bitacora.RegistrarError(SesionUsuario.IdUsuario > 0 ? SesionUsuario.IdUsuario : (int?)null, "Login",
                        ex.GetType().FullName ?? ex.GetType().Name, ex.Message, ex.ToString());
                }
                catch
                {
                    // Evita que un fallo al registrar la bitácora oculte el error original.
                }

                // Si falló a mitad del ingreso, el login no puede quedar oculto.
                this.Show();

                MessageBox.Show(ClsIdioma.T("Ocurrió un error técnico durante el inicio de sesión.\n") + ClsIdioma.T("Si el problema continúa, contacte al administrador."), ClsIdioma.T("Error del sistema"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Después de un login correcto: primero el cambio de la contraseña temporal y después las
        // preguntas de seguridad, los dos obligatorios. Si se cierra alguno sin completarlo, se
        // cierra la sesión y se vuelve al login. Al final se abre el menú principal, una sola vez.
        private void ContinuarIngreso()
        {
            this.Hide();

            if (SesionUsuario.PrimerIngreso)
            {
                using (FrmPrimerIngreso primerIngreso = new FrmPrimerIngreso())
                {
                    if (primerIngreso.ShowDialog() != DialogResult.OK)
                    {
                        CancelarIngreso(ClsIdioma.T("Para ingresar al sistema debe cambiar la contraseña temporal."));
                        return;
                    }
                }
            }

            ClsPreguntaSeguridadLogica preguntas = new ClsPreguntaSeguridadLogica();

            if (!preguntas.UsuarioTienePreguntas(SesionUsuario.IdUsuario))
            {
                using (frmPreguntasSegu frmPreguntas = new frmPreguntasSegu())
                {
                    if (frmPreguntas.ShowDialog() != DialogResult.OK)
                    {
                        CancelarIngreso(ClsIdioma.T("Para ingresar al sistema debe responder las preguntas de seguridad."));
                        return;
                    }
                }
            }

            frmmenuPres menu = new frmmenuPres();

            menu.FormClosed += (s, e) =>
            {
                this.Show();
                this.BringToFront();
                LimpiarCampos();
            };

            menu.Show();
        }
        private void CancelarIngreso(string motivo)
        {
            new ClsLogin().CerrarSesion();

            this.Show();
            this.BringToFront();
            LimpiarCampos();

            MessageBox.Show(motivo, ClsIdioma.T("Ingreso incompleto"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmIngresoUsuarioContra recupero = new frmIngresoUsuarioContra();
            recupero.ShowDialog(this);

            this.Show();
            this.BringToFront();

            txtPass.Clear();
            txtUser.Clear();

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;

            if (txtPass.UseSystemPasswordChar)
            {
                btnMostrar.Text = "👁️";
            }
            else
            {
                btnMostrar.Text = "🔒";
            }
        }
    }

}
