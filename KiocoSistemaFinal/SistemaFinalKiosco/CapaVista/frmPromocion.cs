using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaVista
{
    public partial class frmPromocion : Form
    {
        private CapaLogica.NegocioLogica.ClsPromocionLogica logica = new CapaLogica.NegocioLogica.ClsPromocionLogica();
        private DataTable tiposPromocion;
        private int idPromocionSeleccionada = 0;
        private bool actualizandoListaPromociones = false;


        public frmPromocion()
        {
            InitializeComponent();
        }

        #region Metodos
        private void ConfigurarGrillaProductos()
        {
            dgtCargaArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgtCargaArticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgtCargaArticulo.MultiSelect = false;
            dgtCargaArticulo.ReadOnly = true;
            dgtCargaArticulo.AllowUserToAddRows = false;
            dgtCargaArticulo.RowHeadersVisible = false;

            if (dgtCargaArticulo.Columns.Contains("IdProducto"))
            {
                dgtCargaArticulo.Columns["IdProducto"].Visible = false;
            }

            if (dgtCargaArticulo.Columns.Contains("Nombre"))
            {
                dgtCargaArticulo.Columns["Nombre"].HeaderText = "Producto";
            }

            if (dgtCargaArticulo.Columns.Contains("SKU"))
            {
                dgtCargaArticulo.Columns["SKU"].HeaderText = "SKU";
            }

            if (dgtCargaArticulo.Columns.Contains("PrecioVenta"))
            {
                dgtCargaArticulo.Columns["PrecioVenta"].HeaderText = "Precio";
                dgtCargaArticulo.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            }

            if (dgtCargaArticulo.Columns.Contains("CantidadActual"))
            {
                dgtCargaArticulo.Columns["CantidadActual"].HeaderText = "Stock disponible";
            }

            if (dgtCargaArticulo.Columns.Contains("clnEliminar"))
            {
                DataGridViewButtonColumn columna = dgtCargaArticulo.Columns["clnEliminar"] as DataGridViewButtonColumn;

                if (columna != null)
                {
                    columna.HeaderText = "Acción";
                    columna.Text = "Eliminar";
                    columna.UseColumnTextForButtonValue = true;
                    columna.FlatStyle = FlatStyle.Standard;
                }
            }

        }
        private void CargarTiposPromocion()
        {
            try
            {
                tiposPromocion = logica.ObtenerTiposPromocion();

                DataView vista = new DataView(tiposPromocion);
                vista.RowFilter = "CantidadLleva IS NOT NULL AND CantidadPaga IS NOT NULL";

                cmbDescuentoVolumen.DataSource = vista;
                cmbDescuentoVolumen.DisplayMember = "Nombre";
                cmbDescuentoVolumen.ValueMember = "IdTipoPromocion";
                cmbDescuentoVolumen.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las promociones por volumen: " + ex.Message, "Promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCategoriasPromocion()
        {
            DataTable categorias = new DataTable();

            categorias.Columns.Add("IdCategoria", typeof(int));
            categorias.Columns.Add("Nombre", typeof(string));

            categorias.Rows.Add(1, "Descuento por volumen");
            categorias.Rows.Add(2, "Descuento porcentual");
            categorias.Rows.Add(3, "Precio especial");

            cmbMecanicaPromocional.DataSource = categorias;
            cmbMecanicaPromocional.DisplayMember = "Nombre";
            cmbMecanicaPromocional.ValueMember = "IdCategoria";
            cmbMecanicaPromocional.SelectedIndex = -1;
        }
        private decimal ObtenerValorPromocion()
        {
            int idTipo = ObtenerIdTipoPromocion();

            if (idTipo == 4)
            {
                if (string.IsNullOrWhiteSpace(txtDescuentoPorcentual.Text))
                    throw new Exception("Ingresá el porcentaje de descuento.");

                if (!decimal.TryParse(txtDescuentoPorcentual.Text.Trim(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out decimal porcentaje))
                {
                    throw new Exception("Ingresá un porcentaje válido.");
                }

                if (porcentaje <= 0 || porcentaje > 100)
                    throw new Exception("El descuento debe ser mayor que 0 y no superar el 100%.");

                return porcentaje;
            }

            if (idTipo == 5)
            {
                if (string.IsNullOrWhiteSpace(txtBajaPrecio.Text))
                    throw new Exception("Ingresá el precio especial.");

                if (!decimal.TryParse(txtBajaPrecio.Text.Trim(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out decimal precio))
                {
                    throw new Exception("Ingresá un precio especial válido.");
                }

                if (precio <= 0)
                    throw new Exception("El precio especial debe ser mayor que cero.");

                return precio;
            }

            return 0;
        }
        private void ActualizarCategoriaPromocion()
        {
            if (cmbMecanicaPromocional.SelectedValue == null || !int.TryParse(cmbMecanicaPromocional.SelectedValue.ToString(), out int idCategoria))
            {
                cmbDescuentoVolumen.Enabled = false;
                txtDescuentoPorcentual.Enabled = false;
                txtBajaPrecio.Enabled = false;
                return;
            }

            bool esVolumen = idCategoria == 1;
            bool esPorcentaje = idCategoria == 2;
            bool esPrecioEspecial = idCategoria == 3;

            if (esVolumen && HayProductosDiferentes())
            {
                MessageBox.Show("La mecánica de volumen (2x1, 3x2, 6x4, etc.) " + "solo puede aplicarse a un mismo producto. " + "Quitá los productos diferentes para utilizarla.", "Mecánica de volumen",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbMecanicaPromocional.SelectedIndex = -1;
                cmbDescuentoVolumen.SelectedIndex = -1;

                cmbDescuentoVolumen.Enabled = false;
                txtDescuentoPorcentual.Enabled = false;
                txtBajaPrecio.Enabled = false;

                ActualizarVistaPrevia();
                return;
            }

            cmbDescuentoVolumen.Enabled = esVolumen;
            txtDescuentoPorcentual.Enabled = esPorcentaje;
            txtBajaPrecio.Enabled = esPrecioEspecial;

            if (!esVolumen)
                cmbDescuentoVolumen.SelectedIndex = -1;

            if (!esPorcentaje)
                txtDescuentoPorcentual.Clear();

            if (!esPrecioEspecial)
                txtBajaPrecio.Clear();

            ActualizarVistaPrevia();
        }
        private bool HayProductosDiferentes()
        {
            HashSet<int> productos = new HashSet<int>();

            foreach (DataGridViewRow fila in dgtCargaArticulo.Rows)
            {
                if (fila.IsNewRow || fila.Tag == null)
                    continue;

                if (int.TryParse(Convert.ToString(fila.Tag), out int idProducto))
                {
                    productos.Add(idProducto);
                }
            }

            return productos.Count > 1;
        }
        private int ObtenerIdTipoPromocion()
        {
            if (cmbMecanicaPromocional.SelectedValue == null)
                throw new Exception("Debe seleccionar una mecánica promocional.");

            int idCategoria = Convert.ToInt32(cmbMecanicaPromocional.SelectedValue);

            if (idCategoria == 1)
            {
                if (cmbDescuentoVolumen.SelectedValue == null)
                    throw new Exception("Debe seleccionar una promoción por volumen.");

                return Convert.ToInt32(cmbDescuentoVolumen.SelectedValue);
            }

            if (idCategoria == 2)
                return 4;

            if (idCategoria == 3)
                return 5;

            throw new Exception("La categoría promocional seleccionada no es válida.");
        }
        private DataRow ObtenerMecanicaVolumenSeleccionada()
        {
            if (tiposPromocion == null || cmbDescuentoVolumen.SelectedValue == null)
            {
                return null;
            }

            if (!int.TryParse(cmbDescuentoVolumen.SelectedValue.ToString(), out int idTipoPromocion))
            {
                return null;
            }

            foreach (DataRow fila in tiposPromocion.Rows)
            {
                if (Convert.ToInt32(fila["IdTipoPromocion"]) == idTipoPromocion)
                {
                    if (fila["CantidadLleva"] == DBNull.Value || fila["CantidadPaga"] == DBNull.Value)
                    {
                        return null;
                    }

                    return fila;
                }
            }

            return null;
        }
        private void ActualizarVistaPrevia()
        {
            decimal precioNormal = 0m;
            decimal precioPromocional = 0m;

            lblPrecioNormal.Text = "0,00";
            lblDescuento.Text = "0,00";
            lblPrecioPromocional.Text = "0,00";

            if (cmbMecanicaPromocional.SelectedValue == null)
                return;

            try
            {
                int idTipoPromocion = ObtenerIdTipoPromocion();

                decimal valor = 0m;
                int cantidadLleva = 0;
                int cantidadPaga = 0;

                if (idTipoPromocion == 4)
                {
                    if (!decimal.TryParse(txtDescuentoPorcentual.Text, out valor))
                        return;
                }
                else if (idTipoPromocion == 5)
                {
                    if (!decimal.TryParse(txtBajaPrecio.Text, out valor))
                        return;
                }
                else
                {
                    DataRow mecanica = ObtenerMecanicaVolumenSeleccionada();

                    if (mecanica == null || mecanica.IsNull("CantidadLleva") || mecanica.IsNull("CantidadPaga"))
                        return;

                    cantidadLleva = Convert.ToInt32(mecanica["CantidadLleva"]);
                    cantidadPaga = Convert.ToInt32(mecanica["CantidadPaga"]);

                    if (cantidadLleva <= 0 || cantidadPaga <= 0 || cantidadPaga > cantidadLleva)
                        return;
                }

                foreach (DataGridViewRow fila in dgtCargaArticulo.Rows)
                {
                    if (fila.IsNewRow || fila.Cells["clnCantidad"].Value == null || fila.Cells["clnPrecio"].Value == null)
                        continue;

                    if (!decimal.TryParse(fila.Cells["clnCantidad"].Value.ToString(), out decimal cantidad) || !decimal.TryParse(fila.Cells["clnPrecio"].Value.ToString(), out decimal precio))
                        continue;

                    if (cantidad <= 0 || precio < 0)
                        continue;

                    decimal cantidadParaCalcular = cantidad;

                    if (idTipoPromocion >= 1 && idTipoPromocion <= 3)
                    {
                        cantidadParaCalcular = cantidadLleva;
                    }

                    decimal subtotalNormal = cantidadParaCalcular * precio;
                    decimal subtotalPromocional = logica.CalcularPrecioPromocionalPorCantidad(precio, cantidadParaCalcular, idTipoPromocion, valor, cantidadLleva, cantidadPaga);

                    precioNormal += subtotalNormal;
                    precioPromocional += subtotalPromocional;

                }

                precioNormal = Math.Round(precioNormal, 2);
                precioPromocional = Math.Round(precioPromocional, 2);

                decimal descuento = logica.CalcularPorcentajeDescuento(precioNormal, precioPromocional);

                lblPrecioNormal.Text = precioNormal.ToString("N2");
                lblPrecioPromocional.Text = precioPromocional.ToString("N2");
                lblDescuento.Text = descuento.ToString("N2");
            }
            catch (Exception)
            {
                lblDescuento.Text = "0,00";
                lblPrecioPromocional.Text = "0,00";
            }
        }
        private void CargarPromocionSeleccionada(int idPromocion)
        {
            try
            {
                DataSet datosPromocion = logica.ObtenerPromocionPorId(idPromocion);

                if (datosPromocion == null || datosPromocion.Tables.Count < 2 || datosPromocion.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron los datos de la promoción.", "Promociones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow promocion = datosPromocion.Tables[0].Rows[0];
                DataTable detalles = datosPromocion.Tables[1];

                idPromocionSeleccionada = idPromocion;

                txtCodigoPromocion.Text = promocion["CodigoPromocion"].ToString();
                txtNombrePromocion.Text = promocion["Nombre"].ToString();

                txtBuscarPromo.Text = promocion["CodigoPromocion"].ToString() + " - " + promocion["Nombre"].ToString();

                chkDesactivarPromo.Checked = !Convert.ToBoolean(promocion["Activo"]);

                DateTime fechaInicio = Convert.ToDateTime(promocion["FechaInicio"]);

                string resumenVigencia = "Inicio: " + fechaInicio.ToString("dd/MM/yyyy");

                if (promocion["FechaFin"] != DBNull.Value)
                {
                    DateTime fechaFin = Convert.ToDateTime(promocion["FechaFin"]);
                    resumenVigencia += Environment.NewLine + "Fin: " + fechaFin.ToString("dd/MM/yyyy");
                }
                else
                {
                    resumenVigencia += Environment.NewLine + "Sin fecha de finalización";
                }

                lblResumenVigencia.Text = resumenVigencia;

                int idTipo = Convert.ToInt32(promocion["IdTipoPromocion"]);


                if (idTipo >= 1 && idTipo <= 3)
                {
                    cmbMecanicaPromocional.SelectedValue = 1;
                    cmbDescuentoVolumen.SelectedValue = idTipo;
                }
                else if (idTipo == 4)
                {
                    cmbMecanicaPromocional.SelectedValue = 2;
                    txtDescuentoPorcentual.Text = promocion["Valor"].ToString();
                }
                else if (idTipo == 5)
                {
                    cmbMecanicaPromocional.SelectedValue = 3;
                    txtBajaPrecio.Text = promocion["Valor"].ToString();
                }

                dgtCargaArticulo.Rows.Clear();

                foreach (DataRow detalle in detalles.Rows)
                {
                    int indice = dgtCargaArticulo.Rows.Add();

                    dgtCargaArticulo.Rows[indice].Tag = Convert.ToInt32(detalle["IdProducto"]);
                    dgtCargaArticulo.Rows[indice].Cells["clnProducto"].Value = detalle["NombreProducto"].ToString();
                    dgtCargaArticulo.Rows[indice].Cells["clnCantidad"].Value = detalle["Cantidad"];
                    dgtCargaArticulo.Rows[indice].Cells["clnPrecio"].Value = detalle["PrecioVenta"];
                }

                ActualizarVistaPrevia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la promoción: " + ex.Message,
                    "Promociones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarFormularioPromocion()
        {
            VaciarFormularios.LimpiarControles(this);

            idPromocionSeleccionada = 0;

            txtCodigoPromocion.ReadOnly = true;
            txtCodigoPromocion.Enabled = true;

            lstPromocionesEncontradas.DataSource = null;
            lstPromocionesEncontradas.Visible = false;

            dgtCargaArticulo.Rows.Clear();

            lblPrecioNormal.Text = "0,00";
            lblDescuento.Text = "0,00";
            lblPrecioPromocional.Text = "0,00";
            lblResumenVigencia.Text = string.Empty;

            cmbDescuentoVolumen.Enabled = false;
            txtDescuentoPorcentual.Enabled = false;
            txtBajaPrecio.Enabled = false;
        }



        #endregion


        #region Eventos
        private void frmPromocion_Load(object sender, EventArgs e)
        {
            CargarCategoriasPromocion();
            CargarTiposPromocion();
            ConfigurarGrillaProductos();

            lstPromocionesEncontradas.Visible = false;

            txtCodigoPromocion.Text = string.Empty;
            txtCodigoPromocion.ReadOnly = true;
            txtCodigoPromocion.Enabled = true;

            txtDescuentoPorcentual.Clear();
            txtBajaPrecio.Clear();

            txtDescuentoPorcentual.Enabled = false;
            txtBajaPrecio.Enabled = false;
            cmbDescuentoVolumen.Enabled = false;
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            using (frmBuscarArticulo formulario = new frmBuscarArticulo())
            {
                formulario.ProductoAgregado = producto =>
                {
                    foreach (DataGridViewRow fila in dgtCargaArticulo.Rows)
                    {
                        if (fila.IsNewRow)
                            continue;

                        if (fila.Tag != null &&
                            Convert.ToInt32(fila.Tag) == producto.IdProducto)
                        {
                            MessageBox.Show("Este artículo ya fue agregado a la promoción.", "Promociones",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    int indice = dgtCargaArticulo.Rows.Add();

                    dgtCargaArticulo.Rows[indice].Tag = producto.IdProducto;
                    dgtCargaArticulo.Rows[indice].Cells["clnProducto"].Value = producto.Descripcion;
                    dgtCargaArticulo.Rows[indice].Cells["clnCantidad"].Value = 1;
                    dgtCargaArticulo.Rows[indice].Cells["clnPrecio"].Value = producto.PrecioVenta;
                };

                formulario.ShowDialog();
            }
        }
        private void lblMecanicaPromo_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardarPromo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMecanicaPromocional.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una mecánica promocional.", "Promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbMecanicaPromocional.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombrePromocion.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de la promoción.", "Promociones",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtNombrePromocion.Focus();
                    return;
                }

                bool hayProductos = dgtCargaArticulo.Rows.Cast<DataGridViewRow>().Any(fila => !fila.IsNewRow && fila.Tag != null);

                if (!hayProductos)
                {
                    MessageBox.Show("Debe agregar al menos un producto a la promoción.", "Promociones",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                int idTipoPromocion = ObtenerIdTipoPromocion();

                if (idTipoPromocion >= 1 && idTipoPromocion <= 3
                    && HayProductosDiferentes())
                {
                    MessageBox.Show("Las promociones por volumen solo pueden aplicarse a un mismo producto. No se pueden combinar productos diferentes.", "Validación de promoción",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                List<ClsDetallePromocion> detalles = new List<ClsDetallePromocion>();

                foreach (DataGridViewRow fila in dgtCargaArticulo.Rows)
                {
                    if (fila.IsNewRow || fila.Tag == null)
                        continue;

                    int idProducto = Convert.ToInt32(fila.Tag);

                    if (fila.Cells["clnCantidad"].Value == null || !decimal.TryParse(fila.Cells["clnCantidad"].Value.ToString(), out decimal cantidad) || cantidad <= 0)
                    {
                        throw new Exception("Todos los productos deben tener una cantidad mayor que cero.");
                    }

                    detalles.Add(new ClsDetallePromocion
                    {
                        IdProducto = idProducto,
                        Cantidad = cantidad
                    });
                }

                decimal valorPromocion = ObtenerValorPromocion();

                ClsPromocion promocion = new ClsPromocion
                {
                    Nombre = txtNombrePromocion.Text.Trim(),
                    Descripcion = string.Empty,
                    IdTipoPromocion = idTipoPromocion,
                    Valor = valorPromocion,
                    FechaInicio = DateTime.Today,
                    FechaFin = null,
                    Activo = !chkDesactivarPromo.Checked
                };

                string codigoPromocion;

                int idPromocion = logica.GuardarPromocion(promocion, detalles, out codigoPromocion);

                MessageBox.Show("La promoción se guardó correctamente.\nCódigo: " + codigoPromocion, "Promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioPromocion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la promoción: " + ex.Message, "Promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtBuscarPromo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string texto = txtBuscarPromo.Text.Trim();

                actualizandoListaPromociones = true;

                lstPromocionesEncontradas.DataSource = null;
                lstPromocionesEncontradas.Visible = false;

                if (texto.Length == 0)
                    return;

                DataTable resultados = logica.BuscarPromociones(texto);

                if (resultados == null || resultados.Rows.Count == 0)
                    return;

                if (!resultados.Columns.Contains("TextoMostrar"))
                    resultados.Columns.Add("TextoMostrar", typeof(string));

                foreach (DataRow fila in resultados.Rows)
                {
                    fila["TextoMostrar"] = fila["CodigoPromocion"].ToString() + " - " + fila["Nombre"].ToString();
                }

                lstPromocionesEncontradas.DisplayMember = "TextoMostrar";
                lstPromocionesEncontradas.ValueMember = "IdPromocion";
                lstPromocionesEncontradas.DataSource = resultados;
                lstPromocionesEncontradas.ClearSelected();
                lstPromocionesEncontradas.Visible = true;
                lstPromocionesEncontradas.BringToFront();
            }
            catch (Exception ex)
            {
                lstPromocionesEncontradas.DataSource = null;
                lstPromocionesEncontradas.Visible = false;

                MessageBox.Show("Error al buscar promociones: " + ex.Message, "Promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                actualizandoListaPromociones = false;
            }
        }
        private void lstPromocionesEncontradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizandoListaPromociones)
                return;

        }
        private void btnCofigurarFechas_Click(object sender, EventArgs e)
        {
            using (frmTiempoPromocion ventana = new frmTiempoPromocion())
            {
                if (ventana.ShowDialog(this) == DialogResult.OK)
                {
                    if (ventana.EsRecurrente)
                    {
                        string dias = string.Join(", ", ventana.DiasSeleccionados);

                        lblResumenVigencia.Text = $"Días: {dias}\n" +
                            $"Horario: {ventana.HoraInicioSeleccionada:hh\\:mm} - " + $"{ventana.HoraFinSeleccionada:hh\\:mm}";
                    }
                    else
                    {
                        lblResumenVigencia.Text = $"Del {ventana.FechaInicioSeleccionada:dd/MM/yyyy} " + $"al {ventana.FechaFinSeleccionada:dd/MM/yyyy}\n" +
                            $"Horario: {ventana.HoraInicioSeleccionada:hh\\:mm} - " + $"{ventana.HoraFinSeleccionada:hh\\:mm}";
                    }
                }
            }
        }
        private void cmbMecanicaPromocional_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCategoriaPromocion();
        }
        private void dgtCargaArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgtCargaArticulo.Columns[e.ColumnIndex].Name == "clnEliminar")
            {
                dgtCargaArticulo.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void cmbDescuentoVolumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVistaPrevia();
        }
        private void txtDescuentoPorcentual_TextChanged(object sender, EventArgs e)
        {
            ActualizarVistaPrevia();
        }
        private void txtBajaPrecio_TextChanged(object sender, EventArgs e)
        {
            ActualizarVistaPrevia();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPromocionSeleccionada <= 0)
                {
                    MessageBox.Show(
                        "Primero buscá y seleccioná la promoción que querés eliminar.", "Promociones",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Estás seguro de que querés eliminar esta promoción?\nEsta acción no se puede deshacer.", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                    return;

                logica.EliminarPromocion(idPromocionSeleccionada);

                MessageBox.Show("La promoción se eliminó correctamente.", "Promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioPromocion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la promoción: " + ex.Message, "Promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPromocionSeleccionada <= 0)
                {
                    MessageBox.Show("Primero debe buscar y seleccionar una promoción para modificar.", "Modificar promoción",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombrePromocion.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de la promoción.", "Modificar promoción",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombrePromocion.Focus();
                    return;
                }

                int idTipoPromocion = ObtenerIdTipoPromocion();

                if (idTipoPromocion >= 1 && idTipoPromocion <= 3 && HayProductosDiferentes())
                {
                    MessageBox.Show("Las promociones por volumen solo pueden aplicarse a un mismo producto. No se pueden combinar productos diferentes.", "Validación de promoción",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                decimal valorPromocion = ObtenerValorPromocion();

                DataSet datosPromocion = logica.ObtenerPromocionPorId(idPromocionSeleccionada);

                if (datosPromocion == null || datosPromocion.Tables.Count == 0 || datosPromocion.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron los datos de la promoción.");
                    return;
                }

                DataRow filaPromocion = datosPromocion.Tables[0].Rows[0];

                string descripcion = filaPromocion["Descripcion"] == DBNull.Value ? string.Empty : Convert.ToString(filaPromocion["Descripcion"]);

                DateTime fechaInicio = Convert.ToDateTime(filaPromocion["FechaInicio"]);

                DateTime? fechaFin = filaPromocion["FechaFin"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(filaPromocion["FechaFin"]);

                ClsPromocion promocion = new ClsPromocion
                {
                    IdPromocion = idPromocionSeleccionada,
                    Nombre = txtNombrePromocion.Text.Trim(),
                    Descripcion = descripcion,
                    IdTipoPromocion = idTipoPromocion,
                    Valor = valorPromocion,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Activo = !chkDesactivarPromo.Checked
                };

                List<ClsDetallePromocion> detalles = new List<ClsDetallePromocion>();

                foreach (DataGridViewRow fila in dgtCargaArticulo.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    if (fila.Tag == null || !int.TryParse(Convert.ToString(fila.Tag), out int idProducto) || idProducto <= 0)
                    {
                        throw new Exception("No se pudo identificar uno de los artículos. " + "Quitalo de la grilla y volvé a agregarlo.");
                    }

                    if (fila.Cells["clnCantidad"].Value == null || !decimal.TryParse(Convert.ToString(fila.Cells["clnCantidad"].Value), out decimal cantidad) || cantidad <= 0)
                    {
                        throw new Exception("Verificá que todos los artículos tengan una cantidad válida mayor que cero.");
                    }

                    detalles.Add(new ClsDetallePromocion
                    {
                        IdProducto = idProducto,
                        Cantidad = cantidad
                    });
                }

                logica.ModificarPromocion(promocion, detalles);

                MessageBox.Show("La promoción y sus artículos se modificaron correctamente.", "Modificar promoción",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioPromocion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar la promoción: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lstPromocionesEncontradas_DoubleClick(object sender, EventArgs e)
        {
            if (lstPromocionesEncontradas.SelectedItem == null)
                return;

            DataRowView fila = lstPromocionesEncontradas.SelectedItem as DataRowView;

            if (fila == null)
                return;

            if (!int.TryParse(Convert.ToString(fila["IdPromocion"]), out int idPromocion))
                return;

            lstPromocionesEncontradas.Visible = false;

            CargarPromocionSeleccionada(idPromocion);
        }


        #endregion

  

     
    }
}
