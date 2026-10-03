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
        ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

        private int idCategoria = 0;
        public frmNuevoRubro()
        {
            InitializeComponent();

            this.Text = "Nuevo Rubro";
            lblNuevoRubro.Text = "Nuevo Rubro";
        }
        public frmNuevoRubro(int idCategoria, string nombre)
        {
            InitializeComponent();

            this.idCategoria = idCategoria;

            this.Text = "Modificar Rubro";
            lblNuevoRubro.Text = "Modificar Rubro";

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
                MessageBox.Show("Ingrese el nombre del rubro.", "Aviso",
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
                        MessageBox.Show("Rubro registrado correctamente.", "Éxito",
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
                        MessageBox.Show("Rubro modificado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el rubro.\n\n" + ex.Message, "Error",
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
