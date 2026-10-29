using CapaLogica.NegocioLogica;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmBalance : Form
    {
        private ClsBalanceLogica logica = new ClsBalanceLogica();
        private ClsCajaLogica logicaCaja = new ClsCajaLogica();

        // Resultado de la última consulta (se reutiliza para exportar).
        private DataTable tablaResumen;
        private DataTable tablaIndicadores;
        private DataTable tablaMedioPago;
        private DataTable tablaPorDia;
        private DataTable tablaEmpleados;
        private DataTable tablaProductos;
        private DataTable tablaDetalle;
        private DateTime desdeConsultado;
        private DateTime hastaConsultado;

        // Títulos de columnas: se usan en las grillas y en el Excel.
        private static readonly Dictionary<string, string> Titulos = new Dictionary<string, string>
        {
            { "Seccion", "Sección" },
            { "MedioPago", "Medio de pago" },
            { "CantidadVentas", "Ventas" },
            { "TotalVendido", "Total vendido" },
            { "CantidadAnuladas", "Anuladas" },
            { "ImporteAnulado", "Importe anulado" },
            { "ImporteDevuelto", "Devuelto" },
            { "EgresosRegistrados", "Egresos registrados" },
            { "ValesAdelantos", "Vales / adelantos" },
            { "CajasCerradas", "Cajas cerradas" },
            { "DiferenciaCaja", "Dif. de caja" },
            { "Categoria", "Categoría" },
            { "VentasBrutas", "Ventas brutas" },
            { "VentasNetas", "Ventas netas" },
            { "CostoUnitarioEstimado", "Costo unit. est." },
            { "CostoEstimado", "Costo est." },
            { "GananciaEstimada", "Ganancia est." },
            { "MargenPorcentaje", "Margen %" },
            { "FechaHora", "Fecha y hora" },
            { "NroOperacion", "N.º operación" },
            { "RegistradoPor", "Registrado por" },
            { "SesionCaja", "Caja" },
            { "Observacion", "Observación" }
        };

        // Columnas técnicas que no se muestran.
        private static readonly string[] Ocultas = { "Orden", "IdMetodoPago", "IdUsuario", "IdProducto" };

        public frmBalance()
        {
            InitializeComponent();

            foreach (DataGridView grilla in new[] { dgvResumen, dgvMedioPago, dgvPorDia,
                                                    dgvEmpleados, dgvProductos, dgvDetalle })
            {
                ConfigurarGrid(grilla);
            }
        }

        private void frmBalance_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;
            btnExportar.Enabled = false;

            CargarFiltrosDetalle();
            Consultar();
        }

        #region Metodos

        private void ConfigurarGrid(DataGridView grilla)
        {
            grilla.AutoGenerateColumns = true;
            grilla.ReadOnly = true;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.MultiSelect = false;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToResizeColumns = false;
            grilla.AllowUserToOrderColumns = false;
            grilla.RowHeadersVisible = false;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarFiltrosDetalle()
        {
            cmbTipoDetalle.Items.Clear();
            cmbTipoDetalle.Items.Add("Todos");
            cmbTipoDetalle.Items.Add("Ingresos");
            cmbTipoDetalle.Items.Add("Egresos");
            cmbTipoDetalle.SelectedIndex = 0;

            try
            {
                // Medios de pago con la opción "Todos" (Id 0) al principio.
                DataTable medios = new DataTable();
                medios.Columns.Add("IdMetodoPago", typeof(int));
                medios.Columns.Add("Nombre", typeof(string));
                medios.Rows.Add(0, "Todos");
                foreach (DataRow fila in logicaCaja.ObtenerMetodosPago().Rows)
                {
                    medios.Rows.Add(Convert.ToInt32(fila["IdMetodoPago"]), fila["Nombre"].ToString());
                }
                cmbMedioDetalle.DataSource = medios;
                cmbMedioDetalle.DisplayMember = "Nombre";
                cmbMedioDetalle.ValueMember = "IdMetodoPago";

                DataTable usuarios = new DataTable();
                usuarios.Columns.Add("IdUsuario", typeof(int));
                usuarios.Columns.Add("Empleado", typeof(string));
                usuarios.Rows.Add(0, "Todos");
                foreach (DataRow fila in logicaCaja.ObtenerEmpleadosActivos().Rows)
                {
                    usuarios.Rows.Add(Convert.ToInt32(fila["IdUsuario"]), fila["Empleado"].ToString());
                }
                cmbUsuarioDetalle.DataSource = usuarios;
                cmbUsuarioDetalle.DisplayMember = "Empleado";
                cmbUsuarioDetalle.ValueMember = "IdUsuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los filtros del detalle.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Consultar()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                DataSet resumen = logica.ObtenerResumen(desde, hasta);
                tablaResumen = resumen.Tables[0];
                tablaIndicadores = resumen.Tables.Count > 1 ? resumen.Tables[1] : null;

                tablaMedioPago = logica.ObtenerPorMedioPago(desde, hasta);
                tablaPorDia = logica.ObtenerPorDia(desde, hasta);
                tablaEmpleados = logica.ObtenerPorEmpleado(desde, hasta);
                tablaProductos = logica.ObtenerPorProducto(desde, hasta);

                desdeConsultado = desde;
                hastaConsultado = hasta;

                dgvResumen.DataSource = tablaResumen;
                dgvMedioPago.DataSource = tablaMedioPago;
                dgvPorDia.DataSource = tablaPorDia;
                dgvEmpleados.DataSource = tablaEmpleados;
                dgvProductos.DataSource = tablaProductos;

                MostrarIndicadores();
                ConsultarDetalle();

                btnExportar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener el balance.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ConsultarDetalle()
        {
            string tipo = null;
            if (cmbTipoDetalle.SelectedIndex == 1) tipo = "I";
            if (cmbTipoDetalle.SelectedIndex == 2) tipo = "E";

            int? idMetodoPago = null;
            if (cmbMedioDetalle.SelectedValue != null && Convert.ToInt32(cmbMedioDetalle.SelectedValue) > 0)
            {
                idMetodoPago = Convert.ToInt32(cmbMedioDetalle.SelectedValue);
            }

            int? idUsuario = null;
            if (cmbUsuarioDetalle.SelectedValue != null && Convert.ToInt32(cmbUsuarioDetalle.SelectedValue) > 0)
            {
                idUsuario = Convert.ToInt32(cmbUsuarioDetalle.SelectedValue);
            }

            try
            {
                tablaDetalle = logica.ObtenerDetalle(dtpDesde.Value.Date, dtpHasta.Value.Date,
                                                     tipo, idMetodoPago, idUsuario);
                dgvDetalle.DataSource = tablaDetalle;

                decimal ingresos = 0;
                decimal egresos = 0;
                foreach (DataRow fila in tablaDetalle.Rows)
                {
                    decimal importe = Convert.ToDecimal(fila["Importe"]);
                    if (importe >= 0) ingresos += importe;
                    else egresos += importe;
                }

                lblTotalDetalle.Text = $"Movimientos: {tablaDetalle.Rows.Count}    " +
                                       $"Ingresos: $ {ingresos:N2}    Egresos: $ {egresos:N2}    " +
                                       $"Neto: $ {ingresos + egresos:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener el detalle de movimientos.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarIndicadores()
        {
            if (tablaIndicadores == null || tablaIndicadores.Rows.Count == 0)
            {
                return;
            }

            DataRow fila = tablaIndicadores.Rows[0];

            lblIndVentas.Text = Convert.ToInt32(fila["CantidadVentas"]).ToString();
            lblIndTicket.Text = $"$ {Convert.ToDecimal(fila["TicketPromedio"]):N2}";
            lblIndAnuladas.Text = Convert.ToInt32(fila["CantidadAnuladas"]) +
                                  $"  ($ {Convert.ToDecimal(fila["ImporteAnulado"]):N2})";
            lblIndDevoluciones.Text = Convert.ToInt32(fila["CantidadDevoluciones"]).ToString();
            lblIndCajas.Text = Convert.ToInt32(fila["CajasCerradas"]).ToString();
            lblIndFaltantes.Text = Convert.ToInt32(fila["CajasConFaltante"]).ToString();
        }

        private static string TituloColumna(string columna)
        {
            return Titulos.ContainsKey(columna) ? Titulos[columna] : columna;
        }

        private static bool EsImporte(DataColumn columna)
        {
            return columna.DataType == typeof(decimal) || columna.DataType == typeof(double);
        }

        // Escribe una tabla en una hoja de Excel con título, período y encabezados.
        private void ExportarHoja(XLWorkbook libro, string nombreHoja, string titulo, DataTable tabla)
        {
            IXLWorksheet hoja = libro.Worksheets.Add(nombreHoja);

            hoja.Cell(1, 1).Value = titulo;
            hoja.Cell(1, 1).Style.Font.Bold = true;
            hoja.Cell(1, 1).Style.Font.FontSize = 14;
            hoja.Cell(2, 1).Value = "Período: " + desdeConsultado.ToString("dd/MM/yyyy") +
                                    " al " + hastaConsultado.ToString("dd/MM/yyyy");

            if (tabla == null)
            {
                return;
            }

            List<DataColumn> columnas = tabla.Columns.Cast<DataColumn>()
                .Where(c => !Ocultas.Contains(c.ColumnName))
                .ToList();

            int filaEncabezado = 4;
            for (int i = 0; i < columnas.Count; i++)
            {
                IXLCell celda = hoja.Cell(filaEncabezado, i + 1);
                celda.Value = TituloColumna(columnas[i].ColumnName);
                celda.Style.Font.Bold = true;
                celda.Style.Fill.BackgroundColor = XLColor.LightGray;
            }

            int numeroFila = filaEncabezado + 1;
            foreach (DataRow fila in tabla.Rows)
            {
                for (int i = 0; i < columnas.Count; i++)
                {
                    object valor = fila[columnas[i]];
                    IXLCell celda = hoja.Cell(numeroFila, i + 1);

                    if (valor == DBNull.Value)
                    {
                        continue;
                    }

                    if (EsImporte(columnas[i]))
                    {
                        celda.Value = Convert.ToDecimal(valor);
                        celda.Style.NumberFormat.Format = "#,##0.00";
                    }
                    else if (columnas[i].DataType == typeof(DateTime))
                    {
                        celda.Value = Convert.ToDateTime(valor);
                        celda.Style.DateFormat.Format =
                            columnas[i].ColumnName == "Fecha" ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm";
                    }
                    else if (columnas[i].DataType == typeof(int) || columnas[i].DataType == typeof(long))
                    {
                        celda.Value = Convert.ToInt64(valor);
                    }
                    else
                    {
                        celda.Value = valor.ToString();
                    }
                }
                numeroFila++;
            }

            hoja.Columns().AdjustToContents();
        }

        #endregion

        #region Eventos

        // Formato común para las grillas (títulos, importes, fechas, columnas ocultas).
        private void grilla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grilla = (DataGridView)sender;

            foreach (DataGridViewColumn columna in grilla.Columns)
            {
                if (Ocultas.Contains(columna.DataPropertyName))
                {
                    columna.Visible = false;
                    continue;
                }

                columna.HeaderText = TituloColumna(columna.DataPropertyName);

                if (columna.ValueType == typeof(decimal) || columna.ValueType == typeof(double))
                {
                    columna.DefaultCellStyle.Format = "N2";
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (columna.ValueType == typeof(DateTime))
                {
                    columna.DefaultCellStyle.Format =
                        columna.DataPropertyName == "Fecha" ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm";
                }
            }

            // Importes negativos en rojo.
            foreach (string nombre in new[] { "Importe", "Neto", "GananciaEstimada", "DiferenciaCaja" })
            {
                if (!grilla.Columns.Contains(nombre))
                {
                    continue;
                }

                foreach (DataGridViewRow fila in grilla.Rows)
                {
                    object valor = fila.Cells[nombre].Value;
                    if (valor != null && valor != DBNull.Value && Convert.ToDecimal(valor) < 0)
                    {
                        fila.Cells[nombre].Style.ForeColor = Color.Firebrick;
                    }
                }
            }
        }

        private void dgvResumen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grilla_DataBindingComplete(sender, e);

            // Los totales del bloque "Resultado" se destacan en negrita.
            Font negrita = new Font(dgvResumen.Font, FontStyle.Bold);
            foreach (DataGridViewRow fila in dgvResumen.Rows)
            {
                if (fila.Cells["Seccion"].Value?.ToString() == "Resultado")
                {
                    fila.DefaultCellStyle.Font = negrita;
                    fila.DefaultCellStyle.BackColor = Color.Honeydew;
                }
                else if (fila.Cells["Seccion"].Value?.ToString() == "Compras (informativo)")
                {
                    fila.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                }
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            Consultar();
        }

        private void btnEsteMes_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;
            Consultar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void btnFiltrarDetalle_Click(object sender, EventArgs e)
        {
            ConsultarDetalle();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Title = "Exportar balance";
                guardar.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                guardar.DefaultExt = "xlsx";
                guardar.FileName = "Balance_" + desdeConsultado.ToString("yyyyMMdd") + "_" +
                                   hastaConsultado.ToString("yyyyMMdd") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (XLWorkbook libro = new XLWorkbook())
                    {
                        ExportarHoja(libro, "Resumen", "Balance - Resumen", tablaResumen);
                        ExportarHoja(libro, "Medio de pago", "Balance por medio de pago", tablaMedioPago);
                        ExportarHoja(libro, "Por dia", "Balance por día", tablaPorDia);
                        ExportarHoja(libro, "Empleados", "Balance por empleado", tablaEmpleados);
                        ExportarHoja(libro, "Productos", "Balance por producto", tablaProductos);
                        ExportarHoja(libro, "Detalle", "Detalle de movimientos", tablaDetalle);

                        libro.SaveAs(guardar.FileName);
                    }

                    MessageBox.Show("El balance se exportó correctamente.\n\n" + Path.GetFileName(guardar.FileName),
                        "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo exportar el balance.\n\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
