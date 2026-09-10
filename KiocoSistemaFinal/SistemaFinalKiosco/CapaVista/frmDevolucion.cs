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
    public partial class frmDevolucion : Form
    {
        public frmDevolucion()
        {
            InitializeComponent();
        }

        private void btnNuevaDevolucion_Click(object sender, EventArgs e)
        {
            frmNuevaDevolucion devolucion = new frmNuevaDevolucion();
            devolucion.ShowDialog();
        }
    }
}
