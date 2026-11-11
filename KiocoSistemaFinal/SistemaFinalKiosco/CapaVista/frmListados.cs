using CapaEntidades;
using CapaLogica.NegocioLogica;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmListados : Form
    {
        public enum Modo { Ninguno, Precios, Reposicion }

        private const int PERMISO_PRECIOS = 510;
        private const int PERMISO_REPOSICION = 520;
        private const int MAXIMO_SUGERENCIAS = 15;

        private readonly ClsGestorProductoLogica logica = new ClsGestorProductoLogica();
        private readonly ClsLogicaProveedor logicaProveedor = new ClsLogicaProveedor();

        private Modo modoActual = Modo.Ninguno;
        private DataTable listado;
        private DataTable sugerencias;

        private static readonly (string Campo, string Encabezado, string Formato)[] ColumnasPrecios =
        {
            ("CodigoBarra", "Código", null),
            ("Nombre", "Artículo", null),
            ("Categoria", "Categoría", null),
            ("Marca", "Marca", null),
            ("Unidad", "Unidad", null),
            ("Proveedor", "Proveedor", null),
            ("Sucursal", "Sucursal", null),
            ("Costo", "Costo", "C2"),
            ("PrecioVenta", "Precio venta", "C2"),
            ("Oferta", "Oferta", null)
        };

        private static readonly (string Campo, string Encabezado, string Formato)[] ColumnasReposicion =
        {
            ("CodigoBarra", "Código", null),
            ("Nombre", "Artículo", null),
            ("Categoria", "Categoría", null),
            ("Marca", "Marca", null),
            ("StockActual", "Stock actual", "0.###"),
            ("StockMinimo", "Mínimo", "0.###"),
            ("StockIdeal", "Ideal", "0.###"),
            ("AReponer", "A reponer", "0.###"),
            ("EstadoStock", "Estado", null),
            ("Proveedor", "Proveedor", null),
            ("Sucursal", "Sucursal", null)
        };

        public frmListados() : this(Modo.Ninguno)
        {
        }

        public frmListados(Modo modoInicial)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            ConfigurarGrilla();
            ConfigurarEventos();
            CargarFiltros();
            AplicarModo(modoInicial);
        }
        // desde las alertas
        public frmListados(Modo modoInicial, int? idProducto) : this(modoInicial)
        {
            if (idProducto.HasValue)
                Shown += (sender, e) => MostrarArticulo(idProducto.Value);
        }

        #region Metodos
        private void ConfigurarGrilla()
        {
            dgvListado.AutoGenerateColumns = false;
            dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvListado.AllowUserToResizeColumns = false;
            dgvListado.EnableHeadersVisualStyles = false;
            dgvListado.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }
        private void ConfigurarEventos()
        {
            txtArticulo.TextChanged += txtArticulo_TextChanged;
            txtArticulo.KeyDown += txtArticulo_KeyDown;
            txtArticulo.DoubleClick += (sender, e) => AgregarSugerenciaSeleccionada();
            lstArticulos.DoubleClick += (sender, e) => AgregarSugerenciaSeleccionada();
            dgvListado.CellFormatting += dgvListado_CellFormatting;
            dgvListado.SizeChanged += (sender, e) => AjustarAnchoColumnas();

            foreach (ComboBox combo in new[] { cmbProveedor, cmbSucursal, cmbCategoria, cmbMarca })
            {
                combo.DropDownStyle = ComboBoxStyle.DropDown;
                combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo.AutoCompleteSource = AutoCompleteSource.ListItems;
                combo.Validating += combo_Validating;
            }

            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
        }
        private void CargarFiltros()
        {
            try
            {
                DataTable proveedores = new DataTable();
                proveedores.Columns.Add("IdProveedor", typeof(int));
                proveedores.Columns.Add("Nombre", typeof(string));
                proveedores.Rows.Add(0, ClsIdioma.T("Todos"));

                foreach (var proveedor in logicaProveedor.ObtenerProveedores().Rows
                    .Cast<DataRow>()
                    .GroupBy(f => Convert.ToInt32(f["IdProveedor"]))
                    .Select(g => new { Id = g.Key, Nombre = g.First()["RazonSocial"].ToString() })
                    .OrderBy(p => p.Nombre))
                {
                    proveedores.Rows.Add(proveedor.Id, proveedor.Nombre);
                }

                CargarCombo(cmbProveedor, proveedores, "IdProveedor");
                CargarCombo(cmbCategoria, ConTodos(logica.CargarCategoriasActivas(), "IdCategoria", ClsIdioma.T("Todas")), "IdCategoria");
                CargarCombo(cmbMarca, ConTodos(logica.CargarMarcasActivas(), "IdMarca", ClsIdioma.T("Todas")), "IdMarca");
                CargarSucursales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los filtros.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarSucursales()
        {
            int? idProveedor = ObtenerFiltro(cmbProveedor);
            DataTable sucursales = new DataTable();
            sucursales.Columns.Add("IdSucursal", typeof(int));
            sucursales.Columns.Add("Nombre", typeof(string));
            sucursales.Rows.Add(0, ClsIdioma.T("Todas"));

            if (idProveedor.HasValue)
            {
                try
                {
                    foreach (DataRow fila in logicaProveedor.ObtenerSucursalesPorProveedor(idProveedor.Value).Rows)
                    {
                        sucursales.Rows.Add(Convert.ToInt32(fila["IdSucursal"]), fila["Sucursal"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ClsIdioma.T("No se pudieron cargar las sucursales del proveedor.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            CargarCombo(cmbSucursal, sucursales, "IdSucursal");
            cmbSucursal.Enabled = modoActual != Modo.Ninguno && idProveedor.HasValue;
        }
        private static DataTable ConTodos(DataTable origen, string campoId, string textoTodos)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add(campoId, typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Rows.Add(0, textoTodos);

            foreach (DataRow fila in origen.Rows)
            {
                tabla.Rows.Add(Convert.ToInt32(fila[campoId]), fila["Nombre"].ToString());
            }

            return tabla;
        }
        private static void CargarCombo(ComboBox combo, DataTable tabla, string campoId)
        {
            combo.DisplayMember = "Nombre";
            combo.ValueMember = campoId;
            combo.DataSource = tabla;
            combo.SelectedIndex = 0;
        }
        private static int? ObtenerFiltro(ComboBox combo)
        {
            return combo.SelectedValue is int id && id > 0 ? id : (int?)null;
        }
        private bool TienePermiso(Modo modo)
        {
            return modo == Modo.Precios ? SesionUsuario.Permisos.Contains(PERMISO_PRECIOS)
                 : modo == Modo.Reposicion && SesionUsuario.Permisos.Contains(PERMISO_REPOSICION);
        }
        private void AplicarModo(Modo modo)
        {
            if (modoActual == modo && modo != Modo.Ninguno)
                modo = Modo.Ninguno;

            if (modo != Modo.Ninguno && !TienePermiso(modo))
                modo = Modo.Ninguno;

            modoActual = modo;

            bool modoActivo = modo != Modo.Ninguno;
            bool precios = modo == Modo.Precios;

            OcultarSugerencias();
            txtArticulo.Clear();
            chkFiltro.Checked = false;
            listado = null;
            dgvListado.DataSource = null;
            dgvListado.Columns.Clear();

            foreach (Control control in pnlFiltros.Controls)
                control.Enabled = modoActivo;

            cmbSucursal.Enabled = modoActivo && ObtenerFiltro(cmbProveedor).HasValue;

            btnExportar.Enabled = modoActivo;

            // Textos segun el modo
            chkFiltro.Text = precios ? ClsIdioma.T("Solo con oferta") : ClsIdioma.T("Solo para reponer");
            lblTitulo.Text = precios ? ClsIdioma.T("Lista de precios")
                           : modo == Modo.Reposicion ? ClsIdioma.T("Listado de reposición")
                           : ClsIdioma.T("Listados de precios y reposición");

            Color colorPrecios = Color.DodgerBlue;
            Color colorReposicion = Color.SeaGreen;

            foreach (Button boton in new[] { btnPrecios, btnReposicion })
            {
                boton.FlatStyle = FlatStyle.Flat;
                boton.UseVisualStyleBackColor = false;
            }

            btnPrecios.BackColor = precios ? colorPrecios : SystemColors.Control;
            btnPrecios.ForeColor = precios ? Color.White : Color.Black;
            btnReposicion.BackColor = modo == Modo.Reposicion ? colorReposicion : SystemColors.Control;
            btnReposicion.ForeColor = modo == Modo.Reposicion ? Color.White : Color.Black;

            btnPrecios.Enabled = SesionUsuario.Permisos.Contains(PERMISO_PRECIOS);
            btnReposicion.Enabled = SesionUsuario.Permisos.Contains(PERMISO_REPOSICION);

            dgvListado.BackgroundColor = precios ? Color.AliceBlue : modo == Modo.Reposicion ? Color.Honeydew : SystemColors.Window;
            dgvListado.DefaultCellStyle.SelectionBackColor = precios ? Color.LightSteelBlue : modo == Modo.Reposicion ? Color.LightGreen : SystemColors.Highlight;
            dgvListado.DefaultCellStyle.SelectionForeColor = modoActivo ? Color.Black : SystemColors.HighlightText;
            dgvListado.ColumnHeadersDefaultCellStyle.BackColor = precios ? colorPrecios : modo == Modo.Reposicion ? colorReposicion : SystemColors.Control;
            dgvListado.ColumnHeadersDefaultCellStyle.ForeColor = modoActivo ? Color.White : SystemColors.ControlText;

            if (modoActivo)
            {
                CrearColumnas(precios ? ColumnasPrecios : ColumnasReposicion);
                Buscar();
                txtArticulo.Focus();
            }

            ActualizarCantidad();
        }
        private void CrearColumnas((string Campo, string Encabezado, string Formato)[] columnas)
        {
            foreach (var definicion in columnas)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn
                {
                    Name = definicion.Campo,
                    DataPropertyName = definicion.Campo,
                    HeaderText = ClsIdioma.T(definicion.Encabezado),
                    SortMode = DataGridViewColumnSortMode.Automatic
                };

                if (definicion.Formato != null)
                {
                    columna.DefaultCellStyle.Format = definicion.Formato;
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvListado.Columns.Add(columna);
            }
        }
        private DataTable Consultar(string texto, int? idProducto)
        {
            return logica.ObtenerListadoArticulos(
                texto,
                idProducto,
                ObtenerFiltro(cmbProveedor),
                ObtenerFiltro(cmbSucursal),
                ObtenerFiltro(cmbCategoria),
                ObtenerFiltro(cmbMarca),
                modoActual == Modo.Precios && chkFiltro.Checked,
                modoActual == Modo.Reposicion && chkFiltro.Checked);
        }
        private void Buscar()
        {
            if (modoActual == Modo.Ninguno)
                return;

            try
            {
                OcultarSugerencias();
                listado = Consultar(null, null);
                dgvListado.DataSource = listado;
                AjustarAnchoColumnas();
                ActualizarCantidad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo cargar el listado.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarArticulo(int idProducto)
        {
            if (modoActual == Modo.Ninguno)
                return;

            try
            {
                listado = Consultar(null, idProducto);
                dgvListado.DataSource = listado;
                AjustarAnchoColumnas();
                ActualizarCantidad();

                if (listado.Rows.Count > 0)
                    SeleccionarEnGrilla(listado.Rows[0]);

                dgvListado.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo cargar el artículo.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarSugerencias()
        {
            string texto = txtArticulo.Text.Trim();

            if (modoActual == Modo.Ninguno || texto.Length == 0)
            {
                OcultarSugerencias();
                return;
            }

            try
            {
                sugerencias = Consultar(texto, null);
            }
            catch (Exception ex)
            {
                OcultarSugerencias();
                MessageBox.Show(ClsIdioma.T("No se pudieron buscar los artículos.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstArticulos.Items.Clear();

            foreach (DataRow fila in sugerencias.Rows.Cast<DataRow>().Take(MAXIMO_SUGERENCIAS))
            {
                string sku = fila["SKU"] == DBNull.Value || string.IsNullOrWhiteSpace(fila["SKU"].ToString())
                    ? ""
                    : " (SKU " + fila["SKU"] + ")";

                lstArticulos.Items.Add(fila["CodigoBarra"] + " - " + fila["Nombre"] + sku);
            }

            if (lstArticulos.Items.Count == 0)
            {
                OcultarSugerencias();
                return;
            }

            lstArticulos.SelectedIndex = 0;
            lstArticulos.Visible = true;
            lstArticulos.BringToFront();
        }
        private void OcultarSugerencias()
        {
            lstArticulos.Visible = false;
            lstArticulos.Items.Clear();
            sugerencias = null;
        }
        private void AgregarSugerenciaSeleccionada()
        {
            if (sugerencias == null || lstArticulos.SelectedIndex < 0 || lstArticulos.SelectedIndex >= sugerencias.Rows.Count)
            {
                MostrarSugerencias();
                return;
            }

            DataRow articulo = sugerencias.Rows[lstArticulos.SelectedIndex];
            int idProducto = Convert.ToInt32(articulo["IdProducto"]);

            if (listado == null)
            {
                listado = sugerencias.Clone();
                dgvListado.DataSource = listado;
            }

            DataRow existente = listado.Rows.Cast<DataRow>().FirstOrDefault(f => Convert.ToInt32(f["IdProducto"]) == idProducto);

            if (existente == null)
            {
                listado.ImportRow(articulo);
                existente = listado.Rows[listado.Rows.Count - 1];
                AjustarAnchoColumnas();
                ActualizarCantidad();
            }

            SeleccionarEnGrilla(existente);

            OcultarSugerencias();
            txtArticulo.Clear();
            txtArticulo.Focus();
        }
        private void SeleccionarEnGrilla(DataRow fila)
        {
            foreach (DataGridViewRow filaGrilla in dgvListado.Rows)
            {
                if (filaGrilla.DataBoundItem is DataRowView vista && vista.Row == fila)
                {
                    dgvListado.ClearSelection();
                    filaGrilla.Selected = true;
                    dgvListado.FirstDisplayedScrollingRowIndex = filaGrilla.Index;
                    return;
                }
            }
        }
        private void ActualizarCantidad()
        {
            lblCantidad.Text = modoActual == Modo.Ninguno
                ? ClsIdioma.T("Elegí un listado para empezar.")
                : (dgvListado.Rows.Count == 1 ? ClsIdioma.T("1 artículo") : dgvListado.Rows.Count + ClsIdioma.T(" artículos"));
        }
        private void AjustarAnchoColumnas()
        {
            if (dgvListado.Columns.Count == 0 || !dgvListado.Columns.Contains("Nombre"))
                return;

            dgvListado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            DataGridViewColumn articulo = dgvListado.Columns["Nombre"];

            bool barraVertical = dgvListado.ColumnHeadersHeight + dgvListado.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                > dgvListado.ClientSize.Height;
            int disponible = dgvListado.ClientSize.Width - 4 - (barraVertical ? SystemInformation.VerticalScrollBarWidth : 0);
            int otras = dgvListado.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible && c != articulo).Sum(c => c.Width);
            int minimo = Math.Min(140, articulo.Width);

            articulo.Width = Math.Max(minimo, disponible - otras);
        }
        private void ExportarAExcel()
        {
            if (modoActual == Modo.Ninguno || dgvListado.Rows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("No hay artículos para exportar."), ClsIdioma.T("Exportar"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string titulo = modoActual == Modo.Precios ? "Lista de precios" : "Listado de reposición";

            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                guardar.Title = ClsIdioma.Ingles ? "Save " + ClsIdioma.T(titulo).ToLower() : "Guardar " + titulo.ToLower();
                guardar.FileName = titulo + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    GenerarExcel(guardar.FileName, titulo);

                    MessageBox.Show(ClsIdioma.T("El archivo se exportó correctamente."), ClsIdioma.T("Exportar"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ClsIdioma.T("No se pudo exportar.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GenerarExcel(string ruta, string titulo)
        {
            List<DataGridViewColumn> columnas = dgvListado.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add(titulo);
                int ultimaColumna = columnas.Count;

                hoja.Range(1, 1, 1, ultimaColumna).Merge();
                hoja.Cell(1, 1).Value = titulo;
                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 16;
                hoja.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                hoja.Row(1).Height = 30;

                hoja.Range(2, 1, 2, ultimaColumna).Merge();
                hoja.Cell(2, 1).Value =
                    "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                    "   |   Proveedor: " + cmbProveedor.Text +
                    "   |   Sucursal: " + cmbSucursal.Text +
                    "   |   Categoría: " + cmbCategoria.Text +
                    "   |   Marca: " + cmbMarca.Text +
                    (chkFiltro.Checked ? "   |   " + chkFiltro.Text : "");
                hoja.Cell(2, 1).Style.Font.Bold = true;

                // Encabezados
                for (int i = 0; i < columnas.Count; i++)
                {
                    hoja.Cell(4, i + 1).Value = columnas[i].HeaderText;
                }

                IXLRange encabezado = hoja.Range(4, 1, 4, ultimaColumna);
                encabezado.Style.Font.Bold = true;
                encabezado.Style.Font.FontColor = XLColor.White;
                encabezado.Style.Fill.BackgroundColor = modoActual == Modo.Precios ? XLColor.DodgerBlue : XLColor.SeaGreen;
                encabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                hoja.Row(4).Height = 22;

                int filaExcel = 5;

                foreach (DataGridViewRow fila in dgvListado.Rows)
                {
                    for (int i = 0; i < columnas.Count; i++)
                    {
                        object valor = fila.Cells[columnas[i].Index].Value;
                        IXLCell celda = hoja.Cell(filaExcel, i + 1);

                        if (valor is decimal numero)
                        {
                            celda.Value = numero;
                            celda.Style.NumberFormat.Format = columnas[i].DefaultCellStyle.Format == "C2" ? ClsIdioma.FormatoMonedaExcel : "#,##0.###";
                        }
                        else
                        {
                            celda.Value = valor == null || valor == DBNull.Value ? "" : valor.ToString();
                        }
                    }

                    filaExcel++;
                }

                if (filaExcel > 5)
                {
                    IXLRange datos = hoja.Range(4, 1, filaExcel - 1, ultimaColumna);
                    datos.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    datos.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    datos.SetAutoFilter();
                }

                hoja.Columns(1, ultimaColumna).AdjustToContents(4, filaExcel);
                hoja.SheetView.FreezeRows(4);

                libro.SaveAs(ruta);
            }
        }
        #endregion

        #region Eventos
        private void btnPrecios_Click(object sender, EventArgs e)
        {
            AplicarModo(Modo.Precios);
        }
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSucursales();
        }
        private void combo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.SelectedIndex >= 0 && combo.Text == combo.GetItemText(combo.SelectedItem))
                return;

            int indice = combo.FindStringExact(combo.Text.Trim());
            combo.SelectedIndex = indice >= 0 ? indice : 0;

            combo.Text = combo.GetItemText(combo.SelectedItem);
        }
        private void btnReposicion_Click(object sender, EventArgs e)
        {
            AplicarModo(Modo.Reposicion);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbProveedor.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;
            cmbMarca.SelectedIndex = 0;
            chkFiltro.Checked = false;
            txtArticulo.Clear();
            Buscar();
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            MostrarSugerencias();
        }
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AgregarSugerenciaSeleccionada();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                OcultarSugerencias();
            }
            else if (lstArticulos.Visible && e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                if (lstArticulos.SelectedIndex < lstArticulos.Items.Count - 1)
                    lstArticulos.SelectedIndex++;
            }
            else if (lstArticulos.Visible && e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                if (lstArticulos.SelectedIndex > 0)
                    lstArticulos.SelectedIndex--;
            }
        }
        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvListado.Columns[e.ColumnIndex].Name != "EstadoStock")
                return;

            string estado = Convert.ToString(e.Value);

            if (estado == "Sin stock")
                e.CellStyle.ForeColor = Color.Firebrick;
            else if (estado == "Bajo mínimo")
                e.CellStyle.ForeColor = Color.DarkOrange;
        }
        #endregion
    }
}
