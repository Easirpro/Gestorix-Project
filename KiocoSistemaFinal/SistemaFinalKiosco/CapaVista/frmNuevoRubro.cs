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

namespace CapaVista
{
    public partial class frmNuevoRubro : Form
    {
        ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

        private int idCategoria = 0;
        public frmNuevoRubro()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.Text = ClsIdioma.T("Nuevo Rubro");
            lblNuevoRubro.Text = ClsIdioma.T("Nuevo Rubro");
        }
        public frmNuevoRubro(int idCategoria, string nombre)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.idCategoria = idCategoria;

            this.Text = ClsIdioma.T("Modificar Rubro");
            lblNuevoRubro.Text = ClsIdioma.T("Modificar Rubro");

            txtNombre.Text = nombre;
        }

        #region Metodos

        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(ClsIdioma.T("Ingrese el nombre del rubro."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            try
            {
                if (idCategoria == 0)
                {
                    int nuevoId = logica.RegistrarCategoria(nombre, null);

                    if (nuevoId > 0)
                    {
                        MessageBox.Show(ClsIdioma.T("Rubro registrado correctamente."), ClsIdioma.T("Éxito"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    bool modificado = logica.ModificarCategoria(idCategoria, nombre, null);

                    if (modificado)
                    {
                        MessageBox.Show(ClsIdioma.T("Rubro modificado correctamente."), ClsIdioma.T("Éxito"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo guardar el rubro.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion


    }
}
