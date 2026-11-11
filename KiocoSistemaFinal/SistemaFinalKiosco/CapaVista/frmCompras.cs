using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica.NegocioLogica;
using CapaEntidades;


namespace CapaVista
{
    public partial class frmCompras : Form
    {
        private ClsCompraLogica logica = new ClsCompraLogica();
        private ClsLogicaProveedor logicaProveedor = new ClsLogicaProveedor();
        private List<string> nombresProveedores = new List<string>();
        private DataTable? comprasCargadas;
        private string? proveedorSeleccionado = null;
        private bool cambiandoTexto = false;

        public frmCompras()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            ConfigurarGrid();
            CargarNombresProveedores();
            CargarCompras();
            AplicarPermisos();

        }

        #region Metodos
        private void AplicarPermisos()
        {
            btnNuevacompra.Enabled = SesionUsuario.Permisos.Contains(310);
            btnAnular.Enabled = SesionUsuario.Permisos.Contains(330);
        }
        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            clnFecha.Width = 100;
            clnProveedor.Width = 220;
            clnTipoFactura.Width = 130;
            clnNCoprobante.Width = 150;
            clnTotal.Width = 120;
            clnEstado.Width = 100;
        }
        private void CargarCompras()
        {
            try
            {
                DateTime desde = dateTimePicker1.Value.Date;
                DateTime hasta = dateTimePicker2.Value.Date;

                comprasCargadas = logica.ObtenerCompras(desde, hasta);
            }
            catch (Exception ex)
            {
                comprasCargadas = null;

                MessageBox.Show(ClsIdioma.T("No se pudieron cargar las compras.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarCompras();
        }
        private void MostrarCompras()
        {
            dataGridView1.Rows.Clear();

            if (comprasCargadas == null)
            {
                return;
            }

            try
            {
                foreach (DataRow fila in comprasCargadas.Rows)
                {
                    if (proveedorSeleccionado != null &&
                        !string.Equals(fila["Proveedor"].ToString(), proveedorSeleccionado, StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }

                    int indice = dataGridView1.Rows.Add();

                    dataGridView1.Rows[indice].Cells["clnFecha"].Value = Convert.ToDateTime(fila["Fecha"]).ToString("dd/MM/yyyy");
                    dataGridView1.Rows[indice].Cells["clnProveedor"].Value = fila["Proveedor"].ToString();
                    dataGridView1.Rows[indice].Cells["clnTipoFactura"].Value = fila["TipoComprobante"].ToString();
                    dataGridView1.Rows[indice].Cells["clnNCoprobante"].Value = fila["NumeroComprobante"].ToString(); dataGridView1.Rows[indice].Cells["clnTotal"].Value = Convert.ToDecimal(fila["Total"]).ToString("N2");
                    dataGridView1.Rows[indice].Cells["clnEstado"].Value = fila["Estado"].ToString();
                    dataGridView1.Rows[indice].Tag = Convert.ToInt32(fila["IdCompra"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron mostrar las compras.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarNombresProveedores()
        {
            try
            {
                nombresProveedores = logicaProveedor.ObtenerProveedores().AsEnumerable()
                    .Select(f => f["RazonSocial"].ToString() ?? "")
                    .Where(n => n != "")
                    .Distinct(StringComparer.CurrentCultureIgnoreCase)
                    .OrderBy(n => n)
                    .ToList();
            }
            catch (Exception ex)
            {
                nombresProveedores = new List<string>();

                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los proveedores para el buscador.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarSugerencias(string texto)
        {
            lstProveedores.Items.Clear();

            foreach (string nombre in nombresProveedores.Where(n => n.StartsWith(texto, StringComparison.CurrentCultureIgnoreCase)))
            {
                lstProveedores.Items.Add(nombre);
            }

            lstProveedores.Visible = lstProveedores.Items.Count > 0;

            if (lstProveedores.Visible)
            {
                lstProveedores.SelectedIndex = 0;
                lstProveedores.BringToFront();
            }
        }
        private void SeleccionarProveedor()
        {
            if (!lstProveedores.Visible || lstProveedores.SelectedItem == null)
            {
                return;
            }

            proveedorSeleccionado = lstProveedores.SelectedItem.ToString() ?? "";

            cambiandoTexto = true;

            try
            {
                txtBuscarCompra.Text = proveedorSeleccionado;
                txtBuscarCompra.SelectionStart = txtBuscarCompra.Text.Length;
            }
            finally
            {
                cambiandoTexto = false;
            }

            lstProveedores.Visible = false;
            MostrarCompras();

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("\"" + proveedorSeleccionado + ClsIdioma.T("\" no tiene compras entre el ") +
                    dateTimePicker1.Value.ToString("dd/MM/yyyy") + ClsIdioma.T(" y el ") + dateTimePicker2.Value.ToString("dd/MM/yyyy") +
                    ClsIdioma.T(".\n\nAmplíe las fechas Desde y Hasta para ver sus compras."), ClsIdioma.T("Sin compras"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                dateTimePicker1.Focus();
                return;
            }

            dataGridView1.Focus();
        }
        private void OcultarSugerencias()
        {
            lstProveedores.Items.Clear();
            lstProveedores.Visible = false;
        }


        #endregion



        #region Eventos
        private void btnNuevacompra_Click(object sender, EventArgs e)
        {
            using (frmNuevaCompra Nuevacomp = new frmNuevaCompra(false))
            {
                Nuevacomp.ShowDialog();
            }

            CargarCompras();
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione una compra para ver el detalle."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dataGridView1.SelectedRows[0];

            if (fila.Tag == null)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo obtener el identificador de la compra."), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int idCompra = Convert.ToInt32(fila.Tag);

            using (frmDetalleCompra formulario = new frmDetalleCompra(idCompra))
            {
                formulario.ShowDialog();
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            CargarNombresProveedores();
            CargarCompras();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.Date;
                return;
            }

            CargarCompras();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                dateTimePicker1.Value = dateTimePicker2.Value.Date;
                return;
            }

            CargarCompras();
        }
        private void txtBuscarCompra_TextChanged(object sender, EventArgs e)
        {
            if (cambiandoTexto)
            {
                return;
            }

            string texto = txtBuscarCompra.Text.Trim();

            if (proveedorSeleccionado != null)
            {
                proveedorSeleccionado = null;
                MostrarCompras();
            }

            if (texto == string.Empty)
            {
                OcultarSugerencias();
                return;
            }

            MostrarSugerencias(texto);
        }
        private void txtBuscarCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SeleccionarProveedor();
                return;
            }

            if (!lstProveedores.Visible || lstProveedores.Items.Count == 0)
            {
                return;
            }

            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;

                if (lstProveedores.SelectedIndex < lstProveedores.Items.Count - 1)
                {
                    lstProveedores.SelectedIndex++;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;

                if (lstProveedores.SelectedIndex > 0)
                {
                    lstProveedores.SelectedIndex--;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                OcultarSugerencias();
            }
        }
        private void lstProveedores_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarProveedor();
        }
        private void lstProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SeleccionarProveedor();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                OcultarSugerencias();
                txtBuscarCompra.Focus();
            }
        }
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            proveedorSeleccionado = null;

            cambiandoTexto = true;

            try
            {
                txtBuscarCompra.Clear();
            }
            finally
            {
                cambiandoTexto = false;
            }

            OcultarSugerencias();

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;

            CargarCompras();

            txtBuscarCompra.Focus();
        }
        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione una compra para anular."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dataGridView1.SelectedRows[0];

            if (fila.Tag == null)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo obtener el identificador de la compra."), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string estado = fila.Cells["clnEstado"].Value?.ToString();

            if (estado == "Anulada")
            {
                MessageBox.Show(ClsIdioma.T("La compra seleccionada ya se encuentra anulada."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            int idCompra = Convert.ToInt32(fila.Tag);

            string motivo = Microsoft.VisualBasic.Interaction.InputBox(ClsIdioma.T("Ingrese el motivo de la anulación:"), ClsIdioma.T("Anular compra"), "");

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show(ClsIdioma.T("Debe ingresar un motivo para anular la compra."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Está seguro de anular esta compra?\n\nMotivo: ") + motivo, ClsIdioma.T("Confirmar anulación"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                logica.AnularCompra(idCompra, motivo);

                MessageBox.Show(ClsIdioma.T("La compra fue anulada correctamente."), ClsIdioma.T("Compra anulada"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo anular la compra.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion



    }
}