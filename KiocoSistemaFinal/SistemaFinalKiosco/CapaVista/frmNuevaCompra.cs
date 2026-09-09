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
    public partial class frmNuevaCompra : Form
    {
        public frmNuevaCompra(bool mostrarChk)
        {
            InitializeComponent();

            chkCompraAnulada.Visible = mostrarChk;
        }
    
        private void chkActualizarprecio_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarArticulo BuscarArt = new frmBuscarArticulo();
            BuscarArt.ShowDialog();

        }
        private void chkCompraAnulada_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
