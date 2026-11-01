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
    public partial class frmInformesVentas : Form
    {
        public enum Informe { Ninguno, PorFecha, Detalle, PorRubro, PorArticulo, PorMedioPago }

        private class DefinicionInforme
        {
            public string Tipo;
            public string Titulo;
            public int Permiso;
            public string ColumnaFlexible;
            public (string Campo, string Encabezado, string Formato)[] Columnas;
        }

        private static readonly Dictionary<Informe, DefinicionInforme> Informes = new Dictionary<Informe, DefinicionInforme>
        {
            [Informe.PorFecha] = new DefinicionInforme
            {
                Tipo = "FECHA", Titulo = "Ventas por fecha", Permiso = 610, ColumnaFlexible = "Fecha",
                Columnas = new[]
                {
                    ("Fecha", "Fecha", "dd/MM/yyyy"), ("Ventas", "Ventas", "0"), ("Unidades", "Unidades", "0.###"),
                    ("Vendido", "Vendido", "C2"), ("Devuelto", "Devuelto", "C2"), ("Total", "Total", "C2")
                }
            },
            [Informe.Detalle] = new DefinicionInforme
            {
                Tipo = "DETALLE", Titulo = "Ventas con detalle", Permiso = 620, ColumnaFlexible = "Articulo",
                Columnas = new[]
                {
                    ("FechaHora", "Fecha y hora", "dd/MM/yy HH:mm"), ("Movimiento", "Movimiento", (string)null), ("IdVenta", "Venta", "0"),
                    ("Vendedor", "Vendedor", null), ("CodigoBarra", "Código", null), ("Articulo", "Artículo", null), ("Rubro", "Rubro", null),
                    ("Cantidad", "Cantidad", "0.###"), ("PrecioUnitario", "Precio", "C2"), ("Subtotal", "Subtotal", "C2"),
                    ("Importe", "Importe", "C2"), ("MediosPago", "Medio de pago", null)
                }
            },
            [Informe.PorRubro] = new DefinicionInforme
            {
                Tipo = "RUBRO", Titulo = "Ventas por rubro", Permiso = 630, ColumnaFlexible = "Rubro",
                Columnas = new[]
                {
                    ("Rubro", "Rubro", (string)null), ("Ventas", "Ventas", "0"), ("Unidades", "Unidades", "0.###"),
                    ("Vendido", "Vendido", "C2"), ("Devuelto", "Devuelto", "C2"), ("Total", "Total", "C2"), ("Porcentaje", "% del total", "0.00' %'")
                }
            },
            [Informe.PorArticulo] = new DefinicionInforme
            {
                Tipo = "ARTICULO", Titulo = "Ventas por artículo", Permiso = 640, ColumnaFlexible = "Articulo",
                Columnas = new[]
                {
                    ("CodigoBarra", "Código", (string)null), ("Articulo", "Artículo", null), ("Rubro", "Rubro", null),
                    ("Ventas", "Ventas", "0"), ("Unidades", "Unidades", "0.###"), ("Vendido", "Vendido", "C2"),
                    ("Devuelto", "Devuelto", "C2"), ("Total", "Total", "C2"), ("Porcentaje", "% del total", "0.00' %'")
                }
            },
            [Informe.PorMedioPago] = new DefinicionInforme
            {
                Tipo = "MEDIO", Titulo = "Ventas por medio de pago", Permiso = 650, ColumnaFlexible = "MedioPago",
                Columnas = new[]
                {
                    ("MedioPago", "Medio de pago", (string)null), ("Pagos", "Pagos", "0"), ("Cobrado", "Cobrado", "C2"),
                    ("Devuelto", "Devuelto", "C2"), ("Total", "Total", "C2"), ("Porcentaje", "% del total", "0.00' %'")
                }
            }
        };

        private static readonly Color ColorActivo = Color.SteelBlue;

        private readonly ClsInformeVentasLogica logica = new ClsInformeVentasLogica();
        private readonly ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();
        private readonly ClsCajaLogica logicaCaja = new ClsCajaLogica();

        private readonly Dictionary<Informe, Button> botones;
        private Informe informeActual = Informe.Ninguno;

        public frmInformesVentas() : this(Informe.Ninguno)
        {
        }

        public frmInformesVentas(Informe informeInicial)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            botones = new Dictionary<Informe, Button>
            {
                [Informe.PorFecha] = btnPorFecha,
                [Informe.Detalle] = btnDetalle,
                [Informe.PorRubro] = btnPorRubro,
                [Informe.PorArticulo] = btnPorArticulo,
                [Informe.PorMedioPago] = btnPorMedioPago
            };

            ConfigurarGrilla();
            ConfigurarEventos();
            CargarFiltros();
            AplicarInforme(informeInicial);
        }

        public static Informe InformeInicialSegunPermisos()
        {
            List<Informe> permitidos = Informes.Where(i => SesionUsuario.Permisos.Contains(i.Value.Permiso)).Select(i => i.Key).ToList();
            return permitidos.Count == 1 ? permitidos[0] : Informe.Ninguno;
        }

        #region Metodos
        private void ConfigurarGrilla()
        {
            dgvInforme.AutoGenerateColumns = false;
            dgvInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvInforme.AllowUserToResizeColumns = true;
            dgvInforme.EnableHeadersVisualStyles = false;
            dgvInforme.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }
        private void ConfigurarEventos()
        {
            foreach (var boton in botones)
            {
                Informe informe = boton.Key;
                boton.Value.Click += (sender, e) => AplicarInforme(informe);
            }

            btnBuscar.Click += (sender, e) => Buscar();
            btnLimpiar.Click += (sender, e) => LimpiarFiltros();
            btnExportar.Click += (sender, e) => ExportarAExcel();
            btnVolver.Click += (sender, e) => this.Close();
            dgvInforme.SizeChanged += (sender, e) => AjustarAnchoColumnas();
            dgvInforme.CellFormatting += dgvInforme_CellFormatting;

            foreach (ComboBox combo in new[] { cmbVendedor, cmbMedioPago, cmbCategoria, cmbArticulo })
            {
                combo.DropDownStyle = ComboBoxStyle.DropDown;
                combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo.AutoCompleteSource = AutoCompleteSource.ListItems;
                combo.Validating += combo_Validating;
            }
        }
        private void CargarFiltros()
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;

            try
            {
                CargarCombo(cmbVendedor, ConTodos(logica.ObtenerVendedores(), "IdUsuario", "Username", ClsIdioma.T("Todos")), "IdUsuario");
                CargarCombo(cmbMedioPago, ConTodos(logicaCaja.ObtenerMetodosPago(), "IdMetodoPago", "Nombre", ClsIdioma.T("Todos")), "IdMetodoPago");
            ClsIdioma.TraducirDatosAlMostrar(cmbMedioPago);
                CargarCombo(cmbCategoria, ConTodos(logicaProducto.CargarCategoriasActivas(), "IdCategoria", "Nombre", ClsIdioma.T("Todas")), "IdCategoria");
                CargarCombo(cmbArticulo, ConTodos(logicaProducto.ObtenerListadoArticulos(null, null, null, null, null, null, false, false), "IdProducto", "Nombre", ClsIdioma.T("Todos")), "IdProducto");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los filtros.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static DataTable ConTodos(DataTable origen, string campoId, string campoNombre, string textoTodos)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add(campoId, typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Rows.Add(0, textoTodos);

            foreach (DataRow fila in origen.Rows)
            {
                tabla.Rows.Add(Convert.ToInt32(fila[campoId]), fila[campoNombre].ToString());
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
        private void AplicarInforme(Informe informe)
        {
            if (informeActual == informe && informe != Informe.Ninguno)
                informe = Informe.Ninguno;

            if (informe != Informe.Ninguno && !SesionUsuario.Permisos.Contains(Informes[informe].Permiso))
                informe = Informe.Ninguno;

            informeActual = informe;
            bool activo = informe != Informe.Ninguno;

            dgvInforme.DataSource = null;
            dgvInforme.Columns.Clear();

            foreach (Control control in pnlFiltros.Controls)
                control.Enabled = activo;

            btnExportar.Enabled = activo;
            lblTitulo.Text = activo ? ClsIdioma.T(Informes[informe].Titulo) : ClsIdioma.T("Informes de ventas");

            foreach (var boton in botones)
            {
                bool elegido = boton.Key == informe;
                boton.Value.FlatStyle = FlatStyle.Flat;
                boton.Value.UseVisualStyleBackColor = false;
                boton.Value.BackColor = elegido ? ColorActivo : SystemColors.Control;
                boton.Value.ForeColor = elegido ? Color.White : Color.Black;
                boton.Value.Enabled = SesionUsuario.Permisos.Contains(Informes[boton.Key].Permiso);
            }

            dgvInforme.BackgroundColor = activo ? Color.AliceBlue : SystemColors.Window;
            dgvInforme.DefaultCellStyle.SelectionBackColor = activo ? Color.LightSteelBlue : SystemColors.Highlight;
            dgvInforme.DefaultCellStyle.SelectionForeColor = activo ? Color.Black : SystemColors.HighlightText;
            dgvInforme.ColumnHeadersDefaultCellStyle.BackColor = activo ? ColorActivo : SystemColors.Control;
            dgvInforme.ColumnHeadersDefaultCellStyle.ForeColor = activo ? Color.White : SystemColors.ControlText;

            if (activo)
            {
                CrearColumnas(Informes[informe].Columnas);
                Buscar();
            }
            else
            {
                lblTotales.Text = ClsIdioma.T("Elegí un informe para empezar.");
            }
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

                    if (!definicion.Formato.StartsWith("dd"))
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvInforme.Columns.Add(columna);
            }
        }
        private void Buscar()
        {
            if (informeActual == Informe.Ninguno)
                return;

            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(ClsIdioma.T("La fecha desde no puede ser posterior a la fecha hasta."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDesde.Focus();
                return;
            }

            try
            {
                DataTable datos = logica.ObtenerInforme(
                    Informes[informeActual].Tipo,
                    dtpDesde.Value.Date,
                    dtpHasta.Value.Date,
                    ObtenerFiltro(cmbVendedor),
                    ObtenerFiltro(cmbMedioPago),
                    ObtenerFiltro(cmbCategoria),
                    ObtenerFiltro(cmbArticulo));

                dgvInforme.DataSource = datos;
                AjustarAnchoColumnas();
                ActualizarTotales(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo generar el informe.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarFiltros()
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;

            foreach (ComboBox combo in new[] { cmbVendedor, cmbMedioPago, cmbCategoria, cmbArticulo })
                combo.SelectedIndex = 0;

            Buscar();
        }
        private void ActualizarTotales(DataTable datos)
        {
            decimal Sumar(string columna) => datos.Columns.Contains(columna)
                ? datos.Rows.Cast<DataRow>().Where(f => f[columna] != DBNull.Value).Sum(f => Convert.ToDecimal(f[columna]))
                : 0;

            if (datos.Rows.Count == 0)
            {
                lblTotales.Text = ClsIdioma.T("No hay ventas con estos filtros.");
                return;
            }

            string importes = $"Vendido: {Sumar("Vendido"):C2}   |   Devuelto: {Sumar("Devuelto"):C2}   |   Total: {Sumar("Total"):C2}";

            switch (informeActual)
            {
                case Informe.PorFecha:
                    lblTotales.Text = (ClsIdioma.Ingles ? $"{Sumar("Ventas"):0} sales   |   {Sumar("Unidades"):0.###} units   |" : $"{Sumar("Ventas"):0} ventas   |   {Sumar("Unidades"):0.###} unidades   |   ") + importes;
                    break;
                case Informe.Detalle:
                    List<DataRow> ventas = datos.Rows.Cast<DataRow>().Where(f => f["Movimiento"].ToString() == "Venta").ToList();
                    List<DataRow> devoluciones = datos.Rows.Cast<DataRow>().Where(f => f["Movimiento"].ToString() != "Venta").ToList();
                    lblTotales.Text =
                        (ClsIdioma.Ingles ? $"{ventas.Select(f => Convert.ToInt32(f["IdVenta"])).Distinct().Count()} sales: {ventas.Sum(f => Convert.ToDecimal(f["Importe"])):C2}   |" : $"{ventas.Select(f => Convert.ToInt32(f["IdVenta"])).Distinct().Count()} ventas: {ventas.Sum(f => Convert.ToDecimal(f["Importe"])):C2}   |   ") +
                        (ClsIdioma.Ingles ? $"{devoluciones.Count} returns: {-devoluciones.Sum(f => Convert.ToDecimal(f["Importe"])):C2}   |   Total: {Sumar("Importe"):C2}" : $"{devoluciones.Count} devoluciones: {-devoluciones.Sum(f => Convert.ToDecimal(f["Importe"])):C2}   |   Total: {Sumar("Importe"):C2}");
                    break;
                case Informe.PorMedioPago:
                    lblTotales.Text = (ClsIdioma.Ingles ? $"{Sumar("Pagos"):0} payments   |   Collected: {Sumar("Cobrado"):C2}   |   Refunded: {Sumar("Devuelto"):C2}   |   Total: {Sumar("Total"):C2}" : $"{Sumar("Pagos"):0} pagos   |   Cobrado: {Sumar("Cobrado"):C2}   |   Devuelto: {Sumar("Devuelto"):C2}   |   Total: {Sumar("Total"):C2}");
                    break;
                default:
                    lblTotales.Text = (ClsIdioma.Ingles ? $"{datos.Rows.Count} {(informeActual == Informe.PorRubro ? "categories" : "products")}   |   {Sumar("Unidades"):0.###} units   |" : $"{datos.Rows.Count} {(informeActual == Informe.PorRubro ? "rubros" : "artículos")}   |   {Sumar("Unidades"):0.###} unidades   |   ") + importes;
                    break;
            }
        }
        private void AjustarAnchoColumnas()
        {
            if (informeActual == Informe.Ninguno || dgvInforme.Columns.Count == 0)
                return;

            string nombreFlexible = Informes[informeActual].ColumnaFlexible;

            if (!dgvInforme.Columns.Contains(nombreFlexible))
                return;

            dgvInforme.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            DataGridViewColumn flexible = dgvInforme.Columns[nombreFlexible];

            bool barraVertical = dgvInforme.ColumnHeadersHeight + dgvInforme.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                > dgvInforme.ClientSize.Height;
            int disponible = dgvInforme.ClientSize.Width - 4 - (barraVertical ? SystemInformation.VerticalScrollBarWidth : 0);
            int otras = dgvInforme.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible && c != flexible).Sum(c => c.Width);
            int minimo = Math.Min(140, flexible.Width);

            flexible.Width = Math.Max(minimo, disponible - otras);
        }
        private void ExportarAExcel()
        {
            if (informeActual == Informe.Ninguno || dgvInforme.Rows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("No hay datos para exportar."), ClsIdioma.T("Exportar"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string titulo = Informes[informeActual].Titulo;

            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                guardar.Title = ClsIdioma.T("Guardar informe");
                guardar.FileName = titulo + " " + dtpDesde.Value.ToString("dd-MM-yyyy") + " al " + dtpHasta.Value.ToString("dd-MM-yyyy") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    GenerarExcel(guardar.FileName, titulo);

                    MessageBox.Show(ClsIdioma.T("El informe se exportó correctamente."), ClsIdioma.T("Exportar"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ClsIdioma.T("No se pudo exportar.\n\n") + ex.Message, ClsIdioma.T("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GenerarExcel(string ruta, string titulo)
        {
            List<DataGridViewColumn> columnas = dgvInforme.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Informe");
                int ultimaColumna = columnas.Count;

                hoja.Range(1, 1, 1, ultimaColumna).Merge();
                hoja.Cell(1, 1).Value = titulo;
                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 16;
                hoja.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                hoja.Row(1).Height = 30;

                hoja.Range(2, 1, 2, ultimaColumna).Merge();
                hoja.Cell(2, 1).Value =
                    "Del " + dtpDesde.Value.ToString("dd/MM/yyyy") + " al " + dtpHasta.Value.ToString("dd/MM/yyyy") +
                    "   |   Vendedor: " + cmbVendedor.Text +
                    "   |   Medio de pago: " + cmbMedioPago.Text +
                    "   |   Categoría: " + cmbCategoria.Text +
                    "   |   Artículo: " + cmbArticulo.Text;
                hoja.Cell(2, 1).Style.Font.Bold = true;

                hoja.Range(3, 1, 3, ultimaColumna).Merge();
                hoja.Cell(3, 1).Value = lblTotales.Text;

                // Encabezados
                for (int i = 0; i < columnas.Count; i++)
                {
                    hoja.Cell(5, i + 1).Value = columnas[i].HeaderText;
                }

                IXLRange encabezado = hoja.Range(5, 1, 5, ultimaColumna);
                encabezado.Style.Font.Bold = true;
                encabezado.Style.Font.FontColor = XLColor.White;
                encabezado.Style.Fill.BackgroundColor = XLColor.SteelBlue;
                encabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                hoja.Row(5).Height = 22;

                int filaExcel = 6;

                foreach (DataGridViewRow fila in dgvInforme.Rows)
                {
                    for (int i = 0; i < columnas.Count; i++)
                    {
                        object valor = fila.Cells[columnas[i].Index].Value;
                        string formato = columnas[i].DefaultCellStyle.Format;
                        IXLCell celda = hoja.Cell(filaExcel, i + 1);

                        switch (valor)
                        {
                            case DateTime fecha:
                                celda.Value = fecha;
                                celda.Style.DateFormat.Format = formato == "dd/MM/yyyy" ? "dd/mm/yyyy" : "dd/mm/yyyy hh:mm";
                                break;
                            case decimal numero:
                                celda.Value = numero;
                                celda.Style.NumberFormat.Format = formato == "C2" ? ClsIdioma.FormatoMonedaExcel : formato == "0.00' %'" ? "0.00\" %\"" : "#,##0.###";
                                break;
                            case int entero:
                                celda.Value = entero;
                                break;
                            default:
                                celda.Value = valor == null || valor == DBNull.Value ? "" : valor.ToString();
                                break;
                        }
                    }

                    filaExcel++;
                }

                if (filaExcel > 6)
                {
                    IXLRange datos = hoja.Range(5, 1, filaExcel - 1, ultimaColumna);
                    datos.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    datos.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    datos.SetAutoFilter();
                }

                hoja.Columns(1, ultimaColumna).AdjustToContents(5, filaExcel);
                hoja.SheetView.FreezeRows(5);

                libro.SaveAs(ruta);
            }
        }
        #endregion

        #region Eventos
        private void dgvInforme_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columna = dgvInforme.Columns[e.ColumnIndex].Name;

            if (informeActual == Informe.Detalle && dgvInforme.Columns.Contains("Movimiento"))
            {
                if (dgvInforme.Rows[e.RowIndex].Cells["Movimiento"].Value?.ToString() == "Devolución")
                    e.CellStyle.ForeColor = Color.Firebrick;
            }
            else if (columna == "Devuelto" && e.Value is decimal devuelto && devuelto > 0)
            {
                e.CellStyle.ForeColor = Color.Firebrick;
            }
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
        #endregion
    }
}
