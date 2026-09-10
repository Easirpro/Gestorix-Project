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
    public partial class frmCobroSecundario : Form
    {
        public frmCobroSecundario()
        {
            InitializeComponent();
        }

        private void Cobro_Secundario_Load(object sender, EventArgs e)
        {

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            frmmenuPres frmmenu = new frmmenuPres();
            this.Close();
        }
    }
}
