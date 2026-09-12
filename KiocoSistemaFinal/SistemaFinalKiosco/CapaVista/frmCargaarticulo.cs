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
    public partial class frmCargaarticulo : Form
    {
        public frmCargaarticulo()
        {
            InitializeComponent();
        }

        //Metodos
        #region Metodos

        #endregion


        //Evevnto
        #region Evento
        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            frmNuevoArticulo nuevoArticulo = new frmNuevoArticulo();
            nuevoArticulo.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoArticulo modificararticulo = new frmNuevoArticulo();
            modificararticulo.Text = "Modificar Articulo";
            modificararticulo.ShowDialog();
        }

        #endregion
        private void frmCargaarticulo_Load(object sender, EventArgs e)
        {

        }

  
        private void dtgCargaarticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
