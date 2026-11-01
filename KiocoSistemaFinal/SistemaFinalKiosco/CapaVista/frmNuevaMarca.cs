using CapaEntidades.NegocioEntidad;
using CapaLogica.NegocioLogica;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaVista
{
    public partial class frmNuevaMarca : Form
    {
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }

        public frmNuevaMarca()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.Load += frmNuevaMarca_Load;
        }

        #region Metodos

        private void frmNuevaMarca_Load(object sender, EventArgs e)
        {
            if (IdMarca > 0)
            {
                txtNombre.Text = NombreMarca;
            }
        }

        #endregion

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show(ClsIdioma.T("Ingrese el nombre de la marca."),ClsIdioma.T("Validación"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNombre.Focus();

                    return;
                }

                ClsMarca marca = new ClsMarca();

                marca.IdMarca = IdMarca;
                marca.Nombre = txtNombre.Text.Trim();
                marca.Activo = true;

                ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

                if (IdMarca == 0)
                {
                    int idMarca = logica.RegistrarMarca(marca);

                    if (idMarca > 0)
                    {
                        MessageBox.Show(ClsIdioma.T("Marca registrada correctamente."),ClsIdioma.T("Registro"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                else
                {
                    bool resultado = logica.ModificarMarca(marca);

                    if (resultado)
                    {
                        MessageBox.Show(ClsIdioma.T("Marca modificada correctamente."),ClsIdioma.T("Modificación"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("Ocurrió un error al registrar la marca.\n\n") + ex.Message,ClsIdioma.T("Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
