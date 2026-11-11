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
    public partial class frmNuevoRol : Form
    {
        public int IdRolCreado { get; private set; }

        public frmNuevoRol()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string nombre = txtNuevoRol.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(ClsIdioma.T("Ingrese un nombre para el rol."),ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNuevoRol.Focus();
                return;
            }

            try
            {
                CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

                IdRolCreado = rol.CrearRol(nombre);

                if (IdRolCreado == 0)
                {
                    MessageBox.Show(ClsIdioma.T("Ya existe un rol con ese nombre."),ClsIdioma.T("Rol existente"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtNuevoRol.Focus();
                    return;
                }

                MessageBox.Show(ClsIdioma.T("El rol se creó correctamente."), ClsIdioma.T("Nuevo Rol"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo crear el rol.\n\n") + ClsIdioma.T(ex.Message),ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
