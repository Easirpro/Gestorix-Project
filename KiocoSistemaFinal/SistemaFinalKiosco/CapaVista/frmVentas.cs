using CapaEntidades;
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
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

        #region Metodos
        private void AplicarPermisos()
        {
            bool puedeGestionarVentas = SesionUsuario.Permisos.Contains(200) || SesionUsuario.Permisos.Contains(210);

            btnVerDetalle.Enabled = puedeGestionarVentas;
            btnAnular.Enabled = puedeGestionarVentas;
        }   //Hay que darle acciones 
        #endregion


        #region Eventos

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            frmDetalleVenta detalleVenta = new frmDetalleVenta();
            detalleVenta.ShowDialog();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
