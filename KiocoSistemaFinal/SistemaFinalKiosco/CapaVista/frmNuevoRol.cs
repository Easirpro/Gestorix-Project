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

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string nombre = txtNuevoRol.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese un nombre para el rol.","Aviso",
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
                    MessageBox.Show("Ya existe un rol con ese nombre.","Rol existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtNuevoRol.Focus();
                    return;
                }

                MessageBox.Show("El rol se creó correctamente.", "Nuevo Rol",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el rol.\n\n" + ex.Message,"Error",
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
