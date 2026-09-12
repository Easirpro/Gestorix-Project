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
    public partial class frmCuentaCorrienteProveedores : Form
    {
        public frmCuentaCorrienteProveedores()
        {
            InitializeComponent();
        }

      

        private void btnNuevoPago_Click(object sender, EventArgs e)
        {
            fmrNuevoPagoProvee pagoprovee = new fmrNuevoPagoProvee();
            pagoprovee.ShowDialog();
        }
    }
}
