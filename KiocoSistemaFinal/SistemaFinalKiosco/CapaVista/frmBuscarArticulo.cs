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
    public partial class frmBuscarArticulo : Form
    {
        public frmBuscarArticulo()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmAgregarArticuloCompra articuloCompra = new frmAgregarArticuloCompra();
            articuloCompra.ShowDialog();
        }
    }
}
