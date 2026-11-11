using CapaLogica.BitacoraLogi;
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
    public partial class frmBitacora : Form
    {
        private clsBitacoraLogica logica = new clsBitacoraLogica();
        private string categoriaActual = string.Empty;
        private bool registrandoError = false;

        public frmBitacora()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ConfigurarFormulario();
            ConfigurarEventos();

            dgvBitacora.CellFormatting += (sender, e) =>
            {
                if (ClsIdioma.Ingles && e.RowIndex >= 0 && e.Value is string texto && dgvBitacora.Columns[e.ColumnIndex].Name == "Descripcion")
                {
                    e.Value = ClsIdioma.TraducirBitacora(texto);
                }
            };

            CargarBitacora();

        }

        #region Metodos
        private void ConfigurarFormulario()
        {
            this.dgvBitacora.AutoGenerateColumns = true;
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacora.MultiSelect = false;
            this.dgvBitacora.ScrollBars = ScrollBars.Both;
            this.dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dgvBitacora.BackgroundColor = SystemColors.Window;
            this.dgvBitacora.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.dgvBitacora.AllowUserToResizeColumns = false;
            this.dgvBitacora.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            this.dtpFechaHasta.Value = DateTime.Today;
            this.lblCategoriaActual.Text = ClsIdioma.T("Todos los registros");
        }
        private void ConfigurarEventos()
        {
            this.dgvBitacora.SelectionChanged += dgvBitacora_SelectionChanged;
            this.dgvBitacora.CellFormatting += dgvBitacora_CellFormatting;
            this.dgvBitacora.SizeChanged += (sender, e) => AjustarAnchoColumnas();

            this.Shown += (sender, e) => AjustarAnchoColumnas();

            // solo si la ventana sigue abierta
            Action idioma = () =>
            {
                if (IsHandleCreated && !IsDisposed)
                {
                    BeginInvoke(new Action(AjustarAnchoColumnas));
                }
            };
            ClsIdioma.IdiomaCambiado += idioma;
            this.Disposed += (sender, e) => ClsIdioma.IdiomaCambiado -= idioma;
        }
        private void CargarBitacora()
        {
            this.categoriaActual = string.Empty;
            this.AplicarFiltros();
        }
        private void ConsultarBitacora(DateTime? fechaDesde, DateTime? fechaHasta, string categoria, string buscar)
        {
            try
            {
                DataTable tabla;

                if (categoria == "Errores")
                    tabla = logica.ObtenerErrores(fechaDesde, fechaHasta, buscar, null);
                else if (categoria == "Compras")
                    tabla = logica.ObtenerComprasBitacora(fechaDesde, fechaHasta, buscar);
                else
                    tabla = logica.ObtenerBitacora(fechaDesde, fechaHasta, categoria, buscar);

                dgvBitacora.DataSource = tabla;
                ConfigurarColumnas();
                LimpiarDetalles();

                if (dgvBitacora.Rows.Count > 0)
                    dgvBitacora.ClearSelection();
            }
            catch (Exception ex)
            {
                if (!registrandoError)
                {
                    registrandoError = true;

                    try
                    {
                        logica.RegistrarError(
                            null,
                            "frmBitacora.ConsultarBitacora",
                            ex.GetType().FullName,
                            ex.Message,
                            ex.ToString());
                    }
                    catch (Exception exRegistro)
                    {
                        System.Diagnostics.Debug.WriteLine(exRegistro.ToString());
                    }
                    finally
                    {
                        registrandoError = false;
                    }
                }

                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los registros.\n\n") + ClsIdioma.T(ex.Message),
                    ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarColumnas()
        {
            ConfigurarColumna("IdBitacora", "N.º");
            ConfigurarColumna("IdError", "N.º");
            ConfigurarColumna("Username", "Usuario");
            ConfigurarColumna("FechaHora", "Fecha y hora", "dd/MM/yyyy HH:mm:ss");
            ConfigurarColumna("Accion", "Acción");
            ConfigurarColumna("TablaAfectada", "Módulo");
            ConfigurarColumna("IdRegistroAfectado", "ID afectado");
            ConfigurarColumna("Descripcion", "Descripción");
            ConfigurarColumna("Modulo", "Módulo");
            ConfigurarColumna("TipoExcepcion", "Tipo de excepción");
            ConfigurarColumna("Mensaje", "Mensaje");
            ConfigurarColumna("Estado", "Estado");

            ConfigurarColumna("IdCompra", "N.º");
            ConfigurarColumna("FechaCompra", "Compra", "dd/MM/yy HH:mm");
            ConfigurarColumna("CargadoPor", "Cargó");
            ConfigurarColumna("Proveedor", "Proveedor");
            ConfigurarColumna("Sucursal", "Sucursal");
            ConfigurarColumna("Comprobante", "Comprobante");
            ConfigurarColumna("TotalCompra", "Total", "C2");
            ConfigurarColumna("Estado", "Estado");
            ConfigurarColumna("FechaRecepcion", "Recibida", "dd/MM/yy HH:mm");
            ConfigurarColumna("RecibidoPor", "Recibió");

            string[] ocultas =
            {
                "IdUsuario", "DetalleTecnico", "IdRecepcion", "Saldo", "CUIT", "Motivos", "Observaciones",
                "FechaEntregaEstimada", "TotalBoleta", "Diferencia", "Resultado", "CondicionPago",
                "EstadoEntrega", "EstadoPago"
            };

            foreach (string nombre in ocultas)
            {
                if (this.dgvBitacora.Columns.Contains(nombre))
                {
                    this.dgvBitacora.Columns[nombre].Visible = false;
                }
            }

            foreach (string nombre in new[] { "TotalCompra", "TotalBoleta", "Diferencia" })
            {
                if (this.dgvBitacora.Columns.Contains(nombre))
                {
                    this.dgvBitacora.Columns[nombre].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            this.dgvBitacora.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            AjustarAnchoColumnas();
        }
        private void ConfigurarColumna(string nombre, string encabezado, string formato = null)
        {
            if (!this.dgvBitacora.Columns.Contains(nombre))
            {
                return;
            }

            DataGridViewColumn columna = this.dgvBitacora.Columns[nombre];

            columna.HeaderText = ClsIdioma.T(encabezado);

            if (formato != null)
            {
                columna.DefaultCellStyle.Format = formato;
            }
        }
        // ancho segun contenido y el sobrante repartido hasta llenar la grilla
        private void AjustarAnchoColumnas()
        {
            if (this.dgvBitacora.Columns.Count == 0)
            {
                return;
            }

            ClsGrilla.Ajustar(this.dgvBitacora, repartir: true);
        }
        private void AplicarFiltros()
        {
            ConsultarBitacora(this.dtpFechaDesde.Value.Date, this.dtpFechaHasta.Value.Date, this.categoriaActual, this.txtBuscar.Text.Trim());
        }
        private void SeleccionarCategoria(string categoria, string titulo)
        {
            this.categoriaActual = categoria;
            this.lblCategoriaActual.Text = ClsIdioma.T(titulo);

            this.AplicarFiltros();
        }
        private void MostrarDetalles()
        {
            DataGridViewRow fila = this.dgvBitacora.SelectedRows.Count > 0 ? this.dgvBitacora.SelectedRows[0] : this.dgvBitacora.CurrentRow;

            if (fila == null || fila.IsNewRow)
            {
                this.LimpiarDetalles();
                return;
            }

            if (this.categoriaActual == "Compras")
            {
                if (!this.dgvBitacora.Columns.Contains("IdCompra"))
                {
                    this.LimpiarDetalles();
                    return;
                }

                this.lblDetalleFecha.Text = ClsIdioma.T("Compra: ") + ClsIdioma.Dato(ObtenerValor(fila, "FechaCompra"));
                this.lblDetalleUsuario.Text = ClsIdioma.T("Cargó: ") + ClsIdioma.Dato(ObtenerValor(fila, "CargadoPor")) +
                    ClsIdioma.T("  |  Recibió: ") + ClsIdioma.Dato(ObtenerValor(fila, "RecibidoPor"));
                this.lblDetalleAccion.Text = ClsIdioma.T("Proveedor: ") + ClsIdioma.Dato(ObtenerValor(fila, "Proveedor")) +
                    ClsIdioma.T(" (CUIT ") + ClsIdioma.Dato(ObtenerValor(fila, "CUIT")) + ClsIdioma.T(") - Sucursal: ") + ClsIdioma.Dato(ObtenerValor(fila, "Sucursal"));
                bool recibida = ObtenerValor(fila, "IdRecepcion") != "Sin datos";
                this.lblDetalleDescripcion.Text =
                    ClsIdioma.T("Estado: ") + ClsIdioma.Dato(ObtenerValor(fila, "Estado")) +
                    ClsIdioma.T("  |  Entrega estimada: ") + ClsIdioma.Dato(ObtenerValor(fila, "FechaEntregaEstimada")) +
                    Environment.NewLine +
                    ClsIdioma.T("Pago: ") + (ClsIdioma.Ingles && ObtenerValor(fila, "CondicionPago") == "Contado" ? "Cash" : ClsIdioma.Dato(ObtenerValor(fila, "CondicionPago"))) + ClsIdioma.T(", saldo ") + ClsIdioma.Dato(ObtenerValor(fila, "Saldo")) +
                    (recibida ? ClsIdioma.T("  |  Boleta: ") + ClsIdioma.Dato(ObtenerValor(fila, "TotalBoleta")) + " (" + ClsIdioma.Dato(ObtenerValor(fila, "Resultado")).ToLower() + ")" : ClsIdioma.T("  |  Sin recibir")) +
                    Environment.NewLine +
                    ClsIdioma.T("Motivos: ") + ClsIdioma.Dato(ObtenerValor(fila, "Motivos")) +
                    ClsIdioma.T("  |  Observaciones: ") + ClsIdioma.Dato(ObtenerValor(fila, "Observaciones"));

                return;
            }

            this.lblDetalleFecha.Text = ClsIdioma.T("Fecha: ") + ClsIdioma.Dato(ObtenerValor(fila, "FechaHora"));

            if (this.categoriaActual == "Errores")
            {
                this.lblDetalleUsuario.Text = ClsIdioma.T("ID usuario: ") + ClsIdioma.Dato(ObtenerValor(fila, "IdUsuario"));

                this.lblDetalleAccion.Text = ClsIdioma.T("Excepción: ") + ClsIdioma.Dato(ObtenerValor(fila, "TipoExcepcion"));

                string mensaje = ObtenerValor(fila, "Mensaje");
                string detalle = ObtenerValor(fila, "DetalleTecnico");
                string estado = ClsIdioma.Dato(ObtenerValor(fila, "Estado"));
                string modulo = ClsIdioma.Dato(ObtenerValor(fila, "Modulo"));

                this.lblDetalleDescripcion.Text =
                    ClsIdioma.T("Módulo: ") + modulo +
                    Environment.NewLine +
                    ClsIdioma.T("Estado: ") + estado +
                    Environment.NewLine +
                    ClsIdioma.T("Mensaje: ") + mensaje +
                    Environment.NewLine +
                    ClsIdioma.T("Detalle técnico: ") + detalle;
            }
            else
            {
                this.lblDetalleUsuario.Text = ClsIdioma.T("Usuario: ") + ClsIdioma.Dato(ObtenerValor(fila, "Username"));
                this.lblDetalleAccion.Text = ClsIdioma.T("Acción: ") + ClsIdioma.Dato(ObtenerValor(fila, "Accion"));
                this.lblDetalleDescripcion.Text = ClsIdioma.T("Descripción: ") + ClsIdioma.TraducirBitacora(ObtenerValor(fila, "Descripcion"));
            }
        }
        private string ObtenerValor(DataGridViewRow fila, string columna)
        {
            if (!this.dgvBitacora.Columns.Contains(columna))
            {
                return "Sin datos";
            }

            object valor = fila.Cells[columna].Value;

            if (valor == null || valor == DBNull.Value)
            {
                return "Sin datos";
            }

            if (columna == "FechaHora" && valor is DateTime fecha)
            {
                return fecha.ToString("dd/MM/yyyy HH:mm:ss");
            }

            if (valor is DateTime fechaCompra)
            {
                return fechaCompra.TimeOfDay == TimeSpan.Zero ? fechaCompra.ToString("dd/MM/yyyy") : fechaCompra.ToString("dd/MM/yyyy HH:mm");
            }

            if (valor is decimal importe)
            {
                return importe.ToString("C2");
            }

            return valor.ToString();
        }
        private void LimpiarDetalles()
        {
            this.lblDetalleFecha.Text = ClsIdioma.T("Fecha: "); this.lblDetalleUsuario.Text = ClsIdioma.T("Usuario: "); this.lblDetalleAccion.Text = ClsIdioma.T("Acción: "); this.lblDetalleDescripcion.Text = ClsIdioma.T("Descripción: ");
        }
        private void dgvBitacora_SelectionChanged(object sender, EventArgs e)
        {
            this.MostrarDetalles();
        }
        private void dgvBitacora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || this.categoriaActual != "Compras" || this.dgvBitacora.Columns[e.ColumnIndex].Name != "Estado")
            {
                return;
            }

            string estado = Convert.ToString(e.Value);

            if (estado == "Completada")
                e.CellStyle.ForeColor = Color.DarkGreen;
            else if (estado == "Anulada")
                e.CellStyle.ForeColor = SystemColors.GrayText;
            else
                e.CellStyle.ForeColor = Color.DarkOrange;
        }
        #endregion



        #region Eventos

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoria("Usuarios", "Usuarios");
        }
        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoria("Seguridad", "Seguridad");
        }
        private void btnProducto_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoria("ProductosStock", "Productos");
        }
        private void btnCompras_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoria("Compras", "Compras: quién la cargó, quién la recibió y su estado");
        }
        private void btnPromociones_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoria("Promociones", "Promociones");
        }
        private void btnErrores_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoria("Errores", "Errores técnicos");
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.AplicarFiltros();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.categoriaActual = string.Empty;
            this.dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            this.dtpFechaHasta.Value = DateTime.Today;
            this.txtBuscar.Clear();
            this.lblCategoriaActual.Text = ClsIdioma.T("Todos los registros");

            this.AplicarFiltros();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.AplicarFiltros();
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.AplicarFiltros();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion




    }
}
