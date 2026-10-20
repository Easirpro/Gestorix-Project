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
            ConfigurarFormulario();
            ConfigurarEventos();
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
            this.dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBitacora.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.dgvBitacora.AllowUserToResizeColumns = true;
            this.dgvBitacora.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            this.dtpFechaHasta.Value = DateTime.Today;
            this.lblCategoriaActual.Text = "Todos los registros";
        }
        private void ConfigurarEventos()
        {
            this.btnUsuario.Click += btnUsuario_Click;
            this.btnSeguridad.Click += btnSeguridad_Click;
            //this.btnProductosStock.Click += btnProductosStock_Click;
            //this.btnVentasPagos.Click += btnVentasPagos_Click;
            this.btnPromociones.Click += btnPromociones_Click;
            this.btnErrores.Click += btnErrores_Click;
            this.btnFiltrar.Click += btnFiltrar_Click;
            this.btnLimpiar.Click += btnLimpiar_Click;
            this.btnActualizar.Click += btnActualizar_Click;
            this.dgvBitacora.SelectionChanged += dgvBitacora_SelectionChanged;
            this.txtBuscar.TextChanged += txtBuscar_TextChanged;
        }
        private void CargarBitacora()
        {
            this.categoriaActual = string.Empty;
            this.AplicarFiltros();
        }

        private void ConsultarBitacora(
            DateTime? fechaDesde,
            DateTime? fechaHasta,
            string categoria,
            string buscar)
        {
            try
            {
                DataTable tabla;

                if (categoria == "Errores")
                    tabla = logica.ObtenerErrores(fechaDesde, fechaHasta, buscar, null);
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

                MessageBox.Show(
                    "No se pudieron cargar los registros.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ConfigurarColumnas()
        {
            if (this.dgvBitacora.Columns.Contains("IdBitacora"))
            {
                this.dgvBitacora.Columns["IdBitacora"].HeaderText = "N.º";
                this.dgvBitacora.Columns["IdBitacora"].FillWeight = 45;
            }

            if (this.dgvBitacora.Columns.Contains("IdError"))
            {
                this.dgvBitacora.Columns["IdError"].HeaderText = "N.º";
                this.dgvBitacora.Columns["IdError"].FillWeight = 45;
            }

            if (this.dgvBitacora.Columns.Contains("IdUsuario"))
            {
                this.dgvBitacora.Columns["IdUsuario"].Visible = false;
            }

            if (this.dgvBitacora.Columns.Contains("Username"))
            {
                this.dgvBitacora.Columns["Username"].HeaderText = "Usuario";
            }

            if (this.dgvBitacora.Columns.Contains("FechaHora"))
            {
                this.dgvBitacora.Columns["FechaHora"].HeaderText = "Fecha y hora";
                this.dgvBitacora.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                this.dgvBitacora.Columns["FechaHora"].FillWeight = 120;
            }

            if (this.dgvBitacora.Columns.Contains("Accion"))
            {
                this.dgvBitacora.Columns["Accion"].HeaderText = "Acción";
            }

            if (this.dgvBitacora.Columns.Contains("TablaAfectada"))
            {
                this.dgvBitacora.Columns["TablaAfectada"].HeaderText = "Módulo";
            }

            if (this.dgvBitacora.Columns.Contains("IdRegistroAfectado"))
            {
                this.dgvBitacora.Columns["IdRegistroAfectado"].HeaderText = "ID afectado";
            }

            if (this.dgvBitacora.Columns.Contains("Descripcion"))
            {
                this.dgvBitacora.Columns["Descripcion"].HeaderText = "Descripción";
            }

            if (this.dgvBitacora.Columns.Contains("Modulo"))
            {
                this.dgvBitacora.Columns["Modulo"].HeaderText = "Módulo";
            }

            if (this.dgvBitacora.Columns.Contains("TipoExcepcion"))
            {
                this.dgvBitacora.Columns["TipoExcepcion"].HeaderText = "Tipo de excepción";
            }

            if (this.dgvBitacora.Columns.Contains("Mensaje"))
            {
                this.dgvBitacora.Columns["Mensaje"].HeaderText = "Mensaje";
            }

            if (this.dgvBitacora.Columns.Contains("DetalleTecnico"))
            {
                this.dgvBitacora.Columns["DetalleTecnico"].Visible = false;
            }

            if (this.dgvBitacora.Columns.Contains("Estado"))
            {
                this.dgvBitacora.Columns["Estado"].HeaderText = "Estado";
            }

            this.dgvBitacora.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }
        private void AplicarFiltros()
        {
            ConsultarBitacora(this.dtpFechaDesde.Value.Date, this.dtpFechaHasta.Value.Date, this.categoriaActual, this.txtBuscar.Text.Trim());
        }
        private void SeleccionarCategoria(string categoria, string titulo)
        {
            this.categoriaActual = categoria;
            this.lblCategoriaActual.Text = titulo;

            this.AplicarFiltros();
        }
        private void MostrarDetalles()
        {
            if (this.dgvBitacora.CurrentRow == null || this.dgvBitacora.CurrentRow.IsNewRow)
            {
                this.LimpiarDetalles();
                return;
            }

            DataGridViewRow fila = this.dgvBitacora.CurrentRow;

            this.lblDetalleFecha.Text = "Fecha: " + ObtenerValor(fila, "FechaHora");

            if (this.categoriaActual == "Errores")
            {
                this.lblDetalleUsuario.Text = "ID usuario: " + ObtenerValor(fila, "IdUsuario");

                this.lblDetalleAccion.Text = "Excepción: " + ObtenerValor(fila, "TipoExcepcion");

                string mensaje = ObtenerValor(fila, "Mensaje");
                string detalle = ObtenerValor(fila, "DetalleTecnico");
                string estado = ObtenerValor(fila, "Estado");
                string modulo = ObtenerValor(fila, "Modulo");

                this.lblDetalleDescripcion.Text =
                    "Módulo: " + modulo +
                    Environment.NewLine +
                    "Estado: " + estado +
                    Environment.NewLine +
                    "Mensaje: " + mensaje +
                    Environment.NewLine +
                    "Detalle técnico: " + detalle;
            }
            else
            {
                this.lblDetalleUsuario.Text = "Usuario: " + ObtenerValor(fila, "Username");
                this.lblDetalleAccion.Text = "Acción: " + ObtenerValor(fila, "Accion");
                this.lblDetalleDescripcion.Text = "Descripción: " + ObtenerValor(fila, "Descripcion");
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

            return valor.ToString();
        }
        private void LimpiarDetalles()
        {
            this.lblDetalleFecha.Text = "Fecha: "; this.lblDetalleUsuario.Text = "Usuario: "; this.lblDetalleAccion.Text = "Acción: "; this.lblDetalleDescripcion.Text = "Descripción: ";
        }
        private void dgvBitacora_SelectionChanged(object sender, EventArgs e)
        {
            this.MostrarDetalles();
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
        private void btnProductosStock_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoria("ProductosStock", "Productos y Stock");
        }
        private void btnVentasPagos_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoria("VentasPagos", "Ventas y Pagos");
        }
        private void btnCompras_Click(object sender, EventArgs e)
        {

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
            this.lblCategoriaActual.Text = "Todos los registros";

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



        #endregion


        private void lblSubtitulo_Click(object sender, EventArgs e)
        {

        }

    }
}
