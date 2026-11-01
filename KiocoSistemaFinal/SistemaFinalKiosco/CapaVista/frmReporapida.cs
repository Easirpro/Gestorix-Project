using CapaEntidades;
using CapaLogica.NegocioLogica;
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
    public partial class frmReporapida : Form
    {
        private ClsGestorProductoLogica logica = new ClsGestorProductoLogica();
        private ClsPrecioLogica logicaPrecios = new ClsPrecioLogica();
        private string modoActual = "";
        private DataTable resultadosBusqueda;
        private ClsLogicaProveedor logicaProveedor = new ClsLogicaProveedor();

        public frmReporapida()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            CargarFiltros();


            cmbProveedor.SelectedIndexChanged += Filtros_SelectedIndexChanged;
            cmbSucursal.SelectedIndexChanged += Filtros_SelectedIndexChanged;
            cmbCategoria.SelectedIndexChanged += Filtros_SelectedIndexChanged;
            cmbMarca.SelectedIndexChanged += Filtros_SelectedIndexChanged;

            lstDescripcion.Visible = false;

            AplicarPermisos();
            AplicarModo("");
            ConfigurarGrid();
        }

        #region Metodos
        private void AplicarPermisos()
        {
            //bool puedeReponer = SesionUsuario.Permisos.Contains(141);

            btnReponerStock.Enabled = true;
        }
        private void Filtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                txtCodigo_TextChanged(txtCodigo, EventArgs.Empty);
            }
        }
        private void AplicarModo(string modo)
        {
            if (modoActual == modo && modo != "")
                modo = "";

            modoActual = modo;

            bool modoActivo = modo != "";

            txtCodigo.Clear();
            lstDescripcion.DataSource = null;
            lstDescripcion.Visible = false;
            dgvProductos.Rows.Clear();

            HabilitarComboBox(this, modoActivo);

            txtCodigo.Enabled = modoActivo;

            // Estilo de los botones
            btnActualizarPrecios.FlatStyle = FlatStyle.Flat;
            btnReponerStock.FlatStyle = FlatStyle.Flat;

            btnActualizarPrecios.UseVisualStyleBackColor = false;
            btnReponerStock.UseVisualStyleBackColor = false;

            btnActualizarPrecios.BackColor =
                modo == "PRECIOS" ? Color.DodgerBlue : SystemColors.Control;

            btnActualizarPrecios.ForeColor =
                modo == "PRECIOS" ? Color.White : Color.Black;

            btnReponerStock.BackColor =
                modo == "STOCK" ? Color.SeaGreen : SystemColors.Control;

            btnReponerStock.ForeColor =
                modo == "STOCK" ? Color.White : Color.Black;

            clnNuevoPrecio.Visible = modo == "PRECIOS";
            clnNuevoPrecio.ReadOnly = modo != "PRECIOS";

            clnCantidadReponer.Visible = modo == "STOCK";
            clnCantidadReponer.ReadOnly = modo != "STOCK";

            // Colores de la grilla
            if (modo == "PRECIOS")
            {
                dgvProductos.BackgroundColor = Color.AliceBlue;
                dgvProductos.DefaultCellStyle.SelectionBackColor =
                    Color.LightSteelBlue;
                dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
                    Color.DodgerBlue;
            }
            else if (modo == "STOCK")
            {
                dgvProductos.BackgroundColor = Color.Honeydew;
                dgvProductos.DefaultCellStyle.SelectionBackColor =
                    Color.LightGreen;
                dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
                    Color.SeaGreen;
            }
            else
            {
                dgvProductos.BackgroundColor = SystemColors.Window;
                dgvProductos.DefaultCellStyle.SelectionBackColor =
                    SystemColors.Highlight;
                dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
                    SystemColors.Control;
            }

            dgvProductos.EnableHeadersVisualStyles = false;

            dgvProductos.DefaultCellStyle.SelectionForeColor =
                modoActivo ? Color.Black : SystemColors.HighlightText;

            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor =
                modoActivo ? Color.White : SystemColors.ControlText;

            dgvProductos.Refresh();
        }
        private void SeleccionarProducto()
        {
            if (lstDescripcion.SelectedItem == null)
                return;

            DataRowView seleccionado = lstDescripcion.SelectedItem as DataRowView;

            if (seleccionado == null)
                return;

            DataRow producto = seleccionado.Row;
            int idProducto = Convert.ToInt32(producto["IdProducto"]);

            // Evitar productos duplicados
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Tag != null &&
                    Convert.ToInt32(fila.Tag) == idProducto)
                {
                    MessageBox.Show(
                        ClsIdioma.T("Ese producto ya está cargado en la grilla."),
                        ClsIdioma.T("Producto duplicado"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }

            // Agregar una fila nueva
            int indice = dgvProductos.Rows.Add();
            DataGridViewRow nuevaFila = dgvProductos.Rows[indice];

            nuevaFila.Tag = idProducto;

            string codigoBarra = producto["CodigoBarra"] == DBNull.Value
                ? ""
                : producto["CodigoBarra"].ToString();

            string sku = producto["SKU"] == DBNull.Value
                ? ""
                : producto["SKU"].ToString();

            nuevaFila.Cells["clnCodigo"].Value =
                !string.IsNullOrWhiteSpace(codigoBarra) ? codigoBarra : sku;

            // Nombre del producto
            nuevaFila.Cells["clnProducto"].Value =
                producto["Nombre"] == DBNull.Value
                    ? ""
                    : producto["Nombre"].ToString();

            // Precio actual
            nuevaFila.Cells["clnPrecioActual"].Value =
                producto["PrecioVenta"] == DBNull.Value
                    ? 0m
                    : Convert.ToDecimal(producto["PrecioVenta"]);

            // Stock actual
            nuevaFila.Cells["clnStockActual"].Value =
                producto["CantidadActual"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(producto["CantidadActual"]);

            nuevaFila.Cells["clnNuevoPrecio"].Value = null;
            nuevaFila.Cells["clnCantidadReponer"].Value = null;

            // Limpiar la busqueda
            lstDescripcion.DataSource = null;
            lstDescripcion.Visible = false;

            txtCodigo.Clear();
            txtCodigo.Focus();
        }
        private void HabilitarComboBox(Control contenedor, bool habilitar)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is ComboBox)
                {
                    control.Enabled = habilitar;
                }

                if (control.HasChildren)
                {
                    HabilitarComboBox(control, habilitar);
                }
            }
        }
        private void CargarFiltros()
        {
            // Proveedores
            DataTable proveedores = logicaProveedor.ObtenerProveedores();

            DataRow filaProveedor = proveedores.NewRow();
            filaProveedor["IdProveedor"] = 0;
            filaProveedor["RazonSocial"] = ClsIdioma.T("-Seleccione un proveedor-");
            proveedores.Rows.InsertAt(filaProveedor, 0);

            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "IdProveedor";
            cmbProveedor.DataSource = proveedores;
            cmbProveedor.SelectedIndex = 0;

            // Categorias
            DataTable categorias = logica.CargarCategoriasActivas();

            DataRow filaCategoria = categorias.NewRow();
            filaCategoria["IdCategoria"] = 0;
            filaCategoria["Nombre"] = ClsIdioma.T("-Seleccione una categoría-");
            categorias.Rows.InsertAt(filaCategoria, 0);

            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.DataSource = categorias;
            cmbCategoria.SelectedIndex = 0;

            // Marcas
            DataTable marcas = logica.CargarMarcasActivas();

            DataRow filaMarca = marcas.NewRow();
            filaMarca["IdMarca"] = 0;
            filaMarca["Nombre"] = ClsIdioma.T("-Seleccione una marca-");
            marcas.Rows.InsertAt(filaMarca, 0);

            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "IdMarca";
            cmbMarca.DataSource = marcas;
            cmbMarca.SelectedIndex = 0;

            DataTable sucursales = new DataTable();
            sucursales.Columns.Add("IdSucursal", typeof(int));
            sucursales.Columns.Add("Sucursal", typeof(string));

            DataRow filaSucursal = sucursales.NewRow();
            filaSucursal["IdSucursal"] = 0;
            filaSucursal["Sucursal"] = ClsIdioma.T("-Seleccione una sucursal-");
            sucursales.Rows.Add(filaSucursal);

            cmbSucursal.DisplayMember = "Sucursal";
            cmbSucursal.ValueMember = "IdSucursal";
            cmbSucursal.DataSource = sucursales;
            cmbSucursal.SelectedIndex = 0;
        }
        private int? ObtenerIdFiltro(ComboBox combo)
        {
            if (combo.SelectedValue == null ||
                !int.TryParse(combo.SelectedValue.ToString(), out int id) ||
                id == 0)
                return null;

            return id;
        }
        private void ConfigurarGrid()
        {
            dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProductos.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvProductos.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            dgvProductos.ScrollBars = ScrollBars.Both;

            dgvProductos.Columns["clnCodigo"].MinimumWidth = 85;
            dgvProductos.Columns["clnProducto"].MinimumWidth = 150;
            dgvProductos.Columns["clnPrecioActual"].MinimumWidth = 95;
            dgvProductos.Columns["clnNuevoPrecio"].MinimumWidth = 95;
            dgvProductos.Columns["clnStockActual"].MinimumWidth = 90;
            dgvProductos.Columns["clnCantidadReponer"].MinimumWidth = 125;
        }


        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bool hayProductos = dgvProductos.Rows.Cast<DataGridViewRow>().Any(f => !f.IsNewRow);

            if (hayProductos && MessageBox.Show(ClsIdioma.T("Hay productos cargados que no se guardaron.\n\n¿Querés salir igual?"), ClsIdioma.T("Salir sin guardar"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            Close();
        }
        private void btnActualizarPrecios_Click(object sender, EventArgs e)
        {
            AplicarModo("PRECIOS");
        }
        private void btnReponerStock_Click(object sender, EventArgs e)
        {
            AplicarModo("STOCK");
        }
        private void lstDescripcion_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarProducto();
        }
        private void lstDescripcion_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SeleccionarProducto();
            }
        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            if (lstDescripcion.Visible && lstDescripcion.Items.Count > 0)
            {
                lstDescripcion.SelectedIndex = 0;
                SeleccionarProducto();
            }
        }

        #endregion







        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCodigo.Text.Trim();

            lstDescripcion.Visible = false;
            lstDescripcion.DataSource = null;
            resultadosBusqueda = null;

            if (string.IsNullOrWhiteSpace(texto))
                return;

            try
            {
                resultadosBusqueda = logica.BuscarProductosConFiltrosRapida(
                    texto,
                    ObtenerIdFiltro(cmbProveedor),
                    ObtenerIdFiltro(cmbSucursal),
                    ObtenerIdFiltro(cmbCategoria),
                    ObtenerIdFiltro(cmbMarca)
                );

                if (resultadosBusqueda == null || resultadosBusqueda.Rows.Count == 0)
                    return;

                lstDescripcion.DisplayMember = "Nombre";
                lstDescripcion.ValueMember = "IdProducto";
                lstDescripcion.DataSource = resultadosBusqueda;
                lstDescripcion.Visible = true;
                lstDescripcion.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("Error al buscar productos: ") + ex.Message,
                    ClsIdioma.T("Error de búsqueda"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSucursal.DataSource = null;

            if (cmbProveedor.SelectedValue == null ||
                !int.TryParse(cmbProveedor.SelectedValue.ToString(), out int idProveedor) ||
                idProveedor == 0)
            {
                return;
            }

            try
            {
                DataTable tabla = logicaProveedor.ObtenerSucursalesPorProveedor(idProveedor);

                DataRow fila = tabla.NewRow();
                fila["IdSucursal"] = 0;
                fila["Sucursal"] = ClsIdioma.T("-Seleccione una sucursal-");
                tabla.Rows.InsertAt(fila, 0);

                cmbSucursal.DisplayMember = "Sucursal";
                cmbSucursal.ValueMember = "IdSucursal";
                cmbSucursal.DataSource = tabla;
                cmbSucursal.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ClsIdioma.T("Error al cargar las sucursales: ") + ex.Message,
                    ClsIdioma.T("Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            dgvProductos.EndEdit();

            try
            {
                if (modoActual == "PRECIOS")
                {
                    DataTable precios = new DataTable();
                    precios.Columns.Add("IdProducto", typeof(int));
                    precios.Columns.Add("PrecioVenta", typeof(decimal));

                    foreach (DataGridViewRow fila in dgvProductos.Rows)
                    {
                        if (fila.IsNewRow || fila.Tag == null)
                            continue;

                        object valor = fila.Cells["clnNuevoPrecio"].Value;

                        if (valor == null || string.IsNullOrWhiteSpace(valor.ToString()))
                            continue;

                        if (!decimal.TryParse(valor.ToString(), out decimal precio) || precio < 0)
                        {
                            MessageBox.Show(ClsIdioma.T("Ingresá un precio válido."));
                            return;
                        }

                        int idProducto = Convert.ToInt32(fila.Tag);

                        precios.Rows.Add(idProducto, precio);
                    }

                    if (precios.Rows.Count == 0)
                    {
                        MessageBox.Show(ClsIdioma.T("No hay precios para guardar."));
                        return;
                    }

                    ClsPrecioLogica logicaPrecio = new ClsPrecioLogica();
                    logicaPrecio.ActualizarPrecios(precios);

                    MessageBox.Show(ClsIdioma.T("Precios actualizados correctamente."));
                }
                else if (modoActual == "STOCK")
                {
                    ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();
                    bool hayCambios = false;

                    foreach (DataGridViewRow fila in dgvProductos.Rows)
                    {
                        if (fila.IsNewRow || fila.Tag == null)
                            continue;

                        object valor = fila.Cells["clnCantidadReponer"].Value;

                        if (valor == null || string.IsNullOrWhiteSpace(valor.ToString()))
                            continue;

                        if (!int.TryParse(valor.ToString(), out int cantidad) || cantidad < 0)
                        {
                            MessageBox.Show(ClsIdioma.T("Ingresá una cantidad válida para reponer."));
                            return;
                        }

                        if (cantidad == 0)
                            continue;

                        int idProducto = Convert.ToInt32(fila.Tag);

                        if (!logicaProducto.AgregarStock(idProducto, cantidad))
                        {
                            MessageBox.Show(ClsIdioma.T("No se pudo actualizar el stock del producto con ID ") + idProducto);
                            return;
                        }

                        hayCambios = true;
                    }

                    if (!hayCambios)
                    {
                        MessageBox.Show(ClsIdioma.T("No hay cantidades para reponer."));
                        return;
                    }

                    MessageBox.Show(ClsIdioma.T("Stock actualizado correctamente."));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("Error al guardar los cambios: ") + ex.Message);
            }
        }
    }
}
