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
    public partial class fmrNuevoPagoProvee : Form
    {
        public fmrNuevoPagoProvee()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
        }

        private void fmrNuevoPagoProvee_Load(object sender, EventArgs e)
        {

        }
    }
}
