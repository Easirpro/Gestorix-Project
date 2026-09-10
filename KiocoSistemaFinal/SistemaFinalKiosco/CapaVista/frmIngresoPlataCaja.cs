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
    public partial class frmIngresoPlataCaja : Form
    {

        public frmIngresoPlataCaja(frmmenuPres.TipoMovimiento tipo)
        {
            InitializeComponent();

            tipoMovimiento = tipo;

            ConfigurarFormulario();
        }

        private frmmenuPres.TipoMovimiento tipoMovimiento;

        private void ConfigurarFormulario()
        {
            switch (tipoMovimiento)
            {
                case frmmenuPres.TipoMovimiento.Ingreso:

                    this.Text = "Ingreso de Dinero.";
                    label1.Text = "Nuevo ingreso de plata a caja.";

                    break;

                case frmmenuPres.TipoMovimiento.Egreso:

                    this.Text = "Egreso de Dinero";
                    label1.Text = "Nuevo egreso de plata. ";

                    break;
            }

        }

    }
}
