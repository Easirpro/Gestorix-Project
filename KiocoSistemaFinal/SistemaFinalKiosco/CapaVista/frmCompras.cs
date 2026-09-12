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
    public partial class frmCompras : Form
    {

        public frmCompras()
        {
            InitializeComponent();


        }

        private void btnNuevacompra_Click(object sender, EventArgs e)
        {
            frmNuevaCompra Nuevacomp = new frmNuevaCompra(false);
            Nuevacomp.ShowDialog();


        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            frmNuevaCompra DetalleCompra = new frmNuevaCompra(true);

            DetalleCompra.Text = "Detalle de Compra";
            DetalleCompra.ShowDialog();


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}