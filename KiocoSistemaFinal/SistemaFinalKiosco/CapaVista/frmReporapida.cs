using CapaEntidades;
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
    public partial class frmReporapida : Form
    {
        private ClsLogicaProducto logica = new ClsLogicaProducto();
        public frmReporapida()
        {
            InitializeComponent();

            txtNombre.ReadOnly = true;

            AplicarPermisos();
        }

        #region Metodos
        private void AplicarPermisos()
        {
            bool puedeReponer = SesionUsuario.Permisos.Contains(141);

        }

        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese un código de barras o SKU.","Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigo.Focus();
                return;
            }

            if (!int.TryParse(txtNuevoStock.Text.Trim(), out int cantidad))
            {
                MessageBox.Show("Ingrese una cantidad de stock válida.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNuevoStock.Focus();
                return;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad a reponer debe ser mayor a cero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNuevoStock.Focus();
                return;
            }

            DataTable tabla = logica.ObtenerProductoPorCodigoBarra(codigo);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún producto con ese código de barras o SKU.",
                    "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigo.Focus();
                return;
            }

            int idProducto = Convert.ToInt32(tabla.Rows[0]["IdProducto"]);
            string nombre = tabla.Rows[0]["Nombre"].ToString();

            try
            {
                bool resultado = logica.AgregarStock(idProducto, cantidad);

                if (resultado)
                {
                    MessageBox.Show($"Se agregaron {cantidad} unidades al stock de:\n\n{nombre}", "Reposición realizada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCodigo.Clear();
                    txtNombre.Clear();
                    txtNuevoStock.Clear();

                    txtCodigo.Focus();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el stock del producto.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la reposición.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                txtNombre.Clear();
                return;
            }

            DataTable tabla = logica.BuscarProductoPorCodigoOSku(texto);

            if (tabla.Rows.Count > 0)
            {
                txtNombre.Text = tabla.Rows[0]["Nombre"].ToString();
            }
            else
            {
                txtNombre.Clear();
            }
        }

        #endregion



    }
}
