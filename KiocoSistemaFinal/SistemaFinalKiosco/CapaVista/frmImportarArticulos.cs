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
    public partial class frmImportarArticulos : Form
    {
        public frmImportarArticulos()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirArchivo = new OpenFileDialog();

            abrirArchivo.Title = "Seleccionar archivo de Excel";
            abrirArchivo.Filter = "Archivos de Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            abrirArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                txtTraerArchivo.Text = abrirArchivo.FileName;
            }
        }
    }
}
