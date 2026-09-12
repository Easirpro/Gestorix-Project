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

            FiltrarProveedores();
        }
        private void FiltrarProveedores()
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            dtgProveedores.Rows.Clear();

            foreach (DataRow fila in tablaProveedores.Rows)
            {
                string razonSocial = fila["RazonSocial"]?.ToString().ToLower() ?? "";
                string cuit = fila["CUIT"]?.ToString().ToLower() ?? "";
                string estado = fila["Estado"]?.ToString() ?? "";

                if (chkOcultarProveedores.Checked && estado == "Inactivo")
                {
                    continue;
                }

                if (!razonSocial.Contains(texto) && !cuit.Contains(texto))
                {
                    continue;
                }

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
                btnDescontinuar.Text = "Descontinuar";
                return;
            }

            txtObsevaciones.Text = dtgProveedores.CurrentRow.Tag?.ToString() ?? "";

            string estado = dtgProveedores.CurrentRow.Cells[7].Value?.ToString() ?? "";

            if (estado == "Inactivo")
            {
                btnDescontinuar.Text = "Activar";
            }
            else
            {
                btnDescontinuar.Text = "Descontinuar";
            }
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

                    dtgProveedores.Rows[indice].Tag = fila["Observacion"]?.ToString() ?? "";
                }
            }
        }


        #endregion



        #region Eventos
        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmNuevoProveedor nuevoProveedor = new frmNuevoProveedor();
            nuevoProveedor.ShowDialog();

            CargarProveedores();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dtgProveedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor para modificar.");
                return;
            }

            int idProveedor = Convert.ToInt32(dtgProveedores.CurrentRow.Cells[0].Value);

            frmNuevoProveedor modproveedor = new frmNuevoProveedor(idProveedor);

            modproveedor.Text = "Modificar";
            modproveedor.ShowDialog();

            CargarProveedores();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        private void chkOcultarProveedores_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarProveedores();
        }
        private void btnDescontinuar_Click(object sender, EventArgs e)
        {
            if (dtgProveedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return;
            }

            int idProveedor = Convert.ToInt32(dtgProveedores.CurrentRow.Cells[0].Value);
            string razonSocial = dtgProveedores.CurrentRow.Cells[1].Value?.ToString() ?? "";
            string estado = dtgProveedores.CurrentRow.Cells[7].Value?.ToString() ?? "";

            if (estado == "Inactivo")
            {
                logica.ActivarProveedor(idProveedor);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de descontinuar al proveedor " + razonSocial + "?",
                    "Descontinuar proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                logica.DescontinuarProveedor(idProveedor);
            }

            CargarProveedores();
        }

        #endregion






     
    }
}
