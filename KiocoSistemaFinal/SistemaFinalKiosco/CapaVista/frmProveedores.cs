using System;
using CapaLogica.NegocioLogica;
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
    public partial class frmProveedores : Form
    {
        ClsGestorLogicaProveedor logica = new ClsGestorLogicaProveedor();
        DataTable tablaProveedores;

        public frmProveedores()
        {
            InitializeComponent();

            dtgProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgProveedores.MultiSelect = false;
            dtgProveedores.ScrollBars = ScrollBars.Both;
            dtgProveedores.SelectionChanged += dataGridView1_SelectionChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            CargarProveedores();
        }
        #region Metodos
        private void CargarProveedores()
        {
            tablaProveedores = logica.ObtenerProveedores();

            dtgProveedores.Rows.Clear();

            foreach (DataRow fila in tablaProveedores.Rows)
            {
                int indice = dtgProveedores.Rows.Add(
                    fila["IdProveedor"],
                    fila["RazonSocial"],
                    fila["CUIT"],
                    fila["CondiciónIVA"],
                    fila["NumTelefono"],
                    fila["Correo"],
                    fila["Direccion"],
                    fila["Estado"]
                );

                dtgProveedores.Rows[indice].Tag = fila["Observacion"]?.ToString() ?? "";
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgProveedores.CurrentRow == null)
            {
                txtObsevaciones.Clear();
                return;
            }

            txtObsevaciones.Text = dtgProveedores.CurrentRow.Tag?.ToString() ?? "";
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            dtgProveedores.Rows.Clear();

            foreach (DataRow fila in tablaProveedores.Rows)
            {
                string razonSocial = fila["RazonSocial"]?.ToString().ToLower() ?? "";
                string cuit = fila["CUIT"]?.ToString().ToLower() ?? "";

                if (razonSocial.Contains(texto) || cuit.Contains(texto))
                {
                    int indice = dtgProveedores.Rows.Add(
                        fila["IdProveedor"],
                        fila["RazonSocial"],
                        fila["CUIT"],
                        fila["CondiciónIVA"],
                        fila["NumTelefono"],
                        fila["Correo"],
                        fila["Direccion"],
                        fila["Estado"]
                    );

                    dtgProveedores.Rows[indice].Tag =
                        fila["Observacion"]?.ToString() ?? "";
                }
            }
        }
   

        #endregion



        #region Eventos
        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmNuevoProveedor nuevoProveedor = new frmNuevoProveedor();
            nuevoProveedor.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoProveedor modproveedor = new frmNuevoProveedor();
            modproveedor.Text = "Modificar";
            modproveedor.ShowDialog();
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(txtBuscar, EventArgs.Empty);
            //ver si lo dejamos ya que el txtbuscar funciona filtrando
        }
        #endregion


    }
}
