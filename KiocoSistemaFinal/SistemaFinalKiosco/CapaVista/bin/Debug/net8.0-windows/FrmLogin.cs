using CapaEntidades;
using CapaLogica;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaVista
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.AcceptButton = this.btnLogin;         
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
                MessageBox.Show("Complete todos los campos antes de continuar", "Datos incompletos",MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            ClsLogin login = new ClsLogin();

            bool ingreso = login.IniciarSesion(txtUser.Text, txtPass.Text);

            if (!ingreso)
            {
                if (login.UsuarioBloqueado)
                {
                    MessageBox.Show("Usuario bloqueado.","Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show( "Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                return;
            }

            if (SesionUsuario.PrimerIngreso)
            {
                FrmPrimerIngreso primerIngreso = new FrmPrimerIngreso();

                AbrirFormularioPrincipal(primerIngreso);

                return;
            }

            ClsPreguntaSeguridadLogica preguntas = new ClsPreguntaSeguridadLogica();

            bool tienePreguntas = preguntas.UsuarioTienePreguntas(SesionUsuario.IdUsuario);

            if (!tienePreguntas)
            {
                frmPreguntasSegu frm = new frmPreguntasSegu();

                AbrirFormularioPrincipal(frm);
            }
            else
            {
                frmmenuPres frm = new frmmenuPres();

                AbrirFormularioPrincipal(frm);
            }
        }
        private void AbrirFormularioPrincipal(Form formulario)
        {
            formulario.FormClosed += (s, e) =>
            {
                if (formulario is frmmenuPres)
                {
                    this.Show();
                    this.BringToFront();
                    LimpiarCampos();
                }
                else if (formulario is FrmPrimerIngreso)
                {
                    ClsPreguntaSeguridadLogica preguntas = new ClsPreguntaSeguridadLogica();

                    bool tienePreguntas = preguntas.UsuarioTienePreguntas(SesionUsuario.IdUsuario);

                    if (!tienePreguntas)
                    {
                        frmPreguntasSegu frmPreguntas = new frmPreguntasSegu();

                        AbrirFormularioPrincipal(frmPreguntas);
                    }
                    else
                    {
                        frmmenuPres menu = new frmmenuPres();

                        AbrirFormularioPrincipal(menu);
                    }
                }
                else if (formulario is frmPreguntasSegu)
                {
                    frmmenuPres menu = new frmmenuPres();

                    AbrirFormularioPrincipal(menu);
                }
            };

            formulario.Show();
            this.Hide();
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
        private void button1_Click(object sender, EventArgs e)
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            lblUsuario.Parent = panel1;
            lblUsuario.BackColor = Color.Transparent;
            lblContraseña.Parent = panel1;
            lblContraseña.BackColor = Color.Transparent;
            lkbOlvideContraseña.Parent = panel1;
            lkbOlvideContraseña.BackColor = Color.Transparent;
            btnMostrar.Parent = panel1;
            btnMostrar.BackColor = Color.Transparent;
            lkbOlvideContraseña.Parent= panel1;
            lkbOlvideContraseña.BackColor = Color.Transparent;

        }


    }

}
