using CapaEntidades;
using CapaEntidades.NegocioEntidad;
using CapaEntidades.NegocioEntidades;
using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmNuevaCompra : Form
    {
        private ClsCompraLogica logica = new ClsCompraLogica();
        private ClsLogicaProveedor logicaProveedor = new ClsLogicaProveedor();
        private int idProveedor = 0;
        private int idSucursalActual = 0;
        private DataTable productosEncontrados;
        private DataTable proveedoresEncontrados;
        private ClsCajaLogica logicaCaja = new ClsCajaLogica();
        public frmNuevaCompra(bool mostrarChk)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            dtgNuevaCompra.Columns["Column1"].ReadOnly = true;
            dtgNuevaCompra.Columns["Column2"].ReadOnly = false;
            dtgNuevaCompra.Columns["Column3"].ReadOnly = true;
            dtgNuevaCompra.Columns["Column4"].ReadOnly = false;
            dtgNuevaCompra.Columns["Column4"].DefaultCellStyle.BackColor = Color.LightYellow;
            dtgNuevaCompra.Columns["Column5"].ReadOnly = true;
            dtgNuevaCompra.Columns["Column6"].ReadOnly = true;

            cmbSucursal.SelectionChangeCommitted += cmbSucursal_SelectionChangeCommitted;

            dtpFechaPedido.Value = DateTime.Today;
            dtpFechaPedido.Enabled = false;
            dtpEntrega.MinDate = DateTime.Today;
            dtpEntrega.Value = DateTime.Today;
            dtpEntrega.Checked = false;

            ConfigurarAutocompletadoProveedores();
            CargarOpcionesPago();
            ActualizarSucursalSeleccionada();
        }

       
        #region Metodos

        private void CargarOpcionesPago()
        {
            cmbCondicionPago.Items.Clear();
            cmbCondicionPago.Items.Add("Contado");
            cmbCondicionPago.Items.Add("Cuenta corriente");
            cmbCondicionPago.SelectedIndex = 0;

            try
            {
                DataTable medios = logicaCaja.ObtenerMetodosPago();

                foreach (DataRow fila in medios.Select("Nombre = 'Cuenta Corriente'"))
                {
                    medios.Rows.Remove(fila);
                }

                cmbMedioPagoCompra.DataSource = medios;
                cmbMedioPagoCompra.DisplayMember = "Nombre";
                cmbMedioPagoCompra.ValueMember = "IdMetodoPago";
            ClsIdioma.TraducirDatosAlMostrar(cmbMedioPagoCompra);

                chkPagaDesdeCaja.Enabled = logicaCaja.HayCajaAbierta();
                chkPagaDesdeCaja.Checked = chkPagaDesdeCaja.Enabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los medios de pago.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dtpVencimiento.Value = DateTime.Today.AddDays(30);
            ActualizarOpcionesPago();
        }

        private bool EsCuentaCorriente()
        {
            return cmbCondicionPago.SelectedIndex == 1;
        }

        private void ActualizarOpcionesPago()
        {
            bool ctaCte = EsCuentaCorriente();

            lblMedioPagoCompra.Enabled = !ctaCte;
            cmbMedioPagoCompra.Enabled = !ctaCte;
            chkPagaDesdeCaja.Visible = !ctaCte;
            lblVencimiento.Enabled = ctaCte;
            dtpVencimiento.Enabled = ctaCte;
        }

        
        private void CalcularTotales()
        {
            decimal subtotalSinIVA = 0;
            decimal ivaTotal = 0;

            foreach (DataGridViewRow fila in dtgNuevaCompra.Rows)
            {
                if (fila.IsNewRow)
                {
                    continue;
                }

                if (fila.Cells["Column2"].Value == null || fila.Cells["Column4"].Value == null || fila.Cells["Column5"].Value == null)
                {
                    continue;
                }


                decimal cantidad = Convert.ToDecimal(fila.Cells["Column2"].Value);
                decimal precio = Convert.ToDecimal(fila.Cells["Column4"].Value);
                decimal porcentajeIVA = Convert.ToDecimal(fila.Cells["Column5"].Value);

                decimal subtotal = Math.Round(cantidad * precio, 2, MidpointRounding.AwayFromZero);
                decimal iva = Math.Round(subtotal * porcentajeIVA / 100, 2, MidpointRounding.AwayFromZero);

                subtotalSinIVA += subtotal;
                ivaTotal += iva;
            }

            decimal total = subtotalSinIVA + ivaTotal;

            txtSubsinImpuesto.Text = subtotalSinIVA.ToString("N2");
            txtIva.Text = ivaTotal.ToString("N2");
            txtTotal.Text = total.ToString("N2");
        }
        private void ConfigurarAutocompletadoProveedores()
        {
            txtProveedor.AutoCompleteMode = AutoCompleteMode.None;
            txtProveedor.AutoCompleteSource = AutoCompleteSource.None;

            lstProveedores.Visible = false;
        }
        private void SeleccionarProveedor()
        {
            if (proveedoresEncontrados == null || proveedoresEncontrados.Rows.Count == 0)
            {
                return;
            }

            int indice = lstProveedores.SelectedIndex;

            if (indice < 0 || indice >= proveedoresEncontrados.Rows.Count)
            {
                indice = 0;
            }

            DataRow proveedor = proveedoresEncontrados.Rows[indice];

            string nombreProveedor = proveedor["Nombre"].ToString();
            int idSeleccionado = Convert.ToInt32(proveedor["IdProveedor"]);

            txtProveedor.Text = nombreProveedor;
            idProveedor = idSeleccionado;

            lstProveedores.Visible = false;
            lstProveedores.Items.Clear();
            proveedoresEncontrados = null;

            txtProveedor.SelectionStart = txtProveedor.Text.Length;
            CargarSucursales();
            txtCodigobarra.Focus();
        }
        private void CargarSucursales()
        {
            cmbSucursal.DataSource = null;
            cmbSucursal.Enabled = false;

            if (idProveedor == 0)
            {
                return;
            }

            try
            {
                DataTable sucursales = logicaProveedor.ObtenerSucursalesPorProveedor(idProveedor);

                cmbSucursal.DisplayMember = "Sucursal";
                cmbSucursal.ValueMember = "IdSucursal";
                cmbSucursal.DataSource = sucursales;
                cmbSucursal.Enabled = sucursales.Rows.Count > 1;
                cmbSucursal.SelectedIndex = sucursales.Rows.Count > 0 ? 0 : -1;

                if (sucursales.Rows.Count == 0)
                {
                    MessageBox.Show(ClsIdioma.T("El proveedor no tiene sucursales activas. Cargue una sucursal para poder comprarle."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar las sucursales del proveedor.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarSucursalSeleccionada();
        }
        private int ObtenerIdSucursal()
        {
            return cmbSucursal.SelectedValue is int idSucursal ? idSucursal : 0;
        }
        private void ActualizarSucursalSeleccionada()
        {
            int idSucursal = ObtenerIdSucursal();

            txtCodigobarra.Enabled = idSucursal > 0;
            btnCargarProducto.Enabled = idSucursal > 0;

            if (idSucursal == 0 || idSucursal == idSucursalActual)
            {
                return;
            }

            bool hayProductos = dtgNuevaCompra.Rows.Cast<DataGridViewRow>().Any(f => !f.IsNewRow);

            if (hayProductos && idSucursalActual != 0)
            {
                dtgNuevaCompra.Rows.Clear();
                CalcularTotales();

                MessageBox.Show(ClsIdioma.T("Cambió el proveedor o la sucursal: se quitaron los productos cargados, porque sus costos dependen de la sucursal."),
                    ClsIdioma.T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            idSucursalActual = idSucursal;
            txtCodigobarra.Clear();
        }
        private static bool TryLeerDecimal(object valor, out decimal numero)
        {
            if (valor is decimal valorDecimal)
            {
                numero = valorDecimal;
                return true;
            }

            return decimal.TryParse(Convert.ToString(valor), NumberStyles.Number, CultureInfo.CurrentCulture, out numero);
        }

        #endregion

        #region Eventos
        private void chkActualizarprecio_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            if (productosEncontrados == null || lstProductos.SelectedIndex < 0 || lstProductos.SelectedIndex >= productosEncontrados.Rows.Count)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un producto de la lista."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigobarra.Focus();
                return;
            }

            DataRow producto = productosEncontrados.Rows[lstProductos.SelectedIndex];

            int idProducto = Convert.ToInt32(producto["IdProducto"]);
            string codigoBarra = producto["CodigoBarra"].ToString();
            string nombre = producto["Nombre"].ToString();
            decimal? precio = producto["PrecioCompra"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(producto["PrecioCompra"]);
            decimal iva = Convert.ToDecimal(producto["Alicuota"]);

            DataGridViewRow? filaExistente = dtgNuevaCompra.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(f => !f.IsNewRow && f.Tag is int id && id == idProducto);

            if (filaExistente != null)
            {
                TryLeerDecimal(filaExistente.Cells["Column2"].Value, out decimal cantidadActual);
                filaExistente.Cells["Column2"].Value = cantidadActual + 1;

                dataGridView1_CellEndEdit_1(dtgNuevaCompra, new DataGridViewCellEventArgs(filaExistente.Cells["Column2"].ColumnIndex, filaExistente.Index));

                txtCodigobarra.Clear();
                lstProductos.Items.Clear();
                lstProductos.Visible = false;
                productosEncontrados = null;

                dtgNuevaCompra.ClearSelection();
                filaExistente.Selected = true;

                txtCodigobarra.Focus();
                return;
            }

            int indice = dtgNuevaCompra.Rows.Add();

            DataGridViewRow fila = dtgNuevaCompra.Rows[indice];

            fila.Cells["Column1"].Value = codigoBarra;
            fila.Cells["Column2"].Value = 1;
            fila.Cells["Column3"].Value = nombre;
            fila.Cells["Column4"].Value = precio;
            fila.Cells["Column5"].Value = iva;

            if (precio.HasValue)
            {
                decimal subtotal = Math.Round(precio.Value, 2, MidpointRounding.AwayFromZero);
                decimal ivaCalculado = Math.Round(subtotal * iva / 100, 2, MidpointRounding.AwayFromZero);
                fila.Cells["Column6"].Value = subtotal + ivaCalculado;
            }

            fila.Tag = idProducto;

            CalcularTotales();

            txtCodigobarra.Clear();
            lstProductos.Items.Clear();
            lstProductos.Visible = false;
            productosEncontrados = null;

            if (!precio.HasValue)
            {
                MessageBox.Show("\"" + nombre + ClsIdioma.T("\" no tiene costo cargado para esta sucursal.\n\nIngréselo en la columna \"Costo unitario sin IVA\"; al guardar la compra quedará registrado en la sucursal."),
                    ClsIdioma.T("Costo pendiente"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtgNuevaCompra.Focus();
                dtgNuevaCompra.CurrentCell = fila.Cells["Column4"];
                dtgNuevaCompra.BeginEdit(true);
                return;
            }

            txtCodigobarra.Focus();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dtgNuevaCompra.Rows[e.RowIndex];

            if (fila.Cells["Column5"].Value == null)
            {
                return;
            }

            if (!TryLeerDecimal(fila.Cells["Column2"].Value, out decimal cantidad))
            {
                cantidad = 0;
                fila.Cells["Column2"].Value = 0;
            }

            if (!TryLeerDecimal(fila.Cells["Column4"].Value, out decimal precio) || precio < 0)
            {
                fila.Cells["Column4"].Value = null;
                fila.Cells["Column6"].Value = null;
                CalcularTotales();
                return;
            }

            fila.Cells["Column4"].Value = precio;
            decimal iva = Convert.ToDecimal(fila.Cells["Column5"].Value);

            decimal subtotal = Math.Round(cantidad * precio, 2, MidpointRounding.AwayFromZero);
            decimal ivaCalculado = Math.Round(subtotal * iva / 100, 2, MidpointRounding.AwayFromZero);
            decimal total = subtotal + ivaCalculado;

            fila.Cells["Column6"].Value = total;

            CalcularTotales();
        }
        private void txtSubsinImpuesto_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnEliminarCompra_Click(object sender, EventArgs e)
        {
            if (dtgNuevaCompra.SelectedRows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un producto para eliminar."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Está seguro de eliminar el producto seleccionado?"), ClsIdioma.T("Confirmar eliminación"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            dtgNuevaCompra.Rows.RemoveAt(dtgNuevaCompra.SelectedRows[0].Index);

            CalcularTotales();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProveedor == 0)
            {
                MessageBox.Show(ClsIdioma.T("Debe seleccionar un proveedor."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtProveedor.Focus();
                return;
            }

            if (ObtenerIdSucursal() == 0 || ObtenerIdSucursal() != idSucursalActual)
            {
                MessageBox.Show(ClsIdioma.T("Debe seleccionar la sucursal del proveedor."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbSucursal.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbTipoComprobante.Text))
            {
                MessageBox.Show(ClsIdioma.T("Debe seleccionar un tipo de comprobante."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbTipoComprobante.Focus();
                return;
            }

            dtpFechaPedido.Value = DateTime.Today;

            if (dtpEntrega.Checked && dtpEntrega.Value.Date < DateTime.Today)
            {
                MessageBox.Show(ClsIdioma.T("La entrega estimada no puede ser anterior a hoy."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dtpEntrega.Focus();
                return;
            }

            if (dtgNuevaCompra.Rows.Cast<DataGridViewRow>().All(fila => fila.IsNewRow))
            {
                MessageBox.Show(ClsIdioma.T("Debe agregar al menos un producto a la compra."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigobarra.Focus();
                return;
            }

            try
            {
                if (logica.ExisteComprobante(idProveedor, cmbTipoComprobante.Text, txtNumeroComprobante.Text))
                {
                    MessageBox.Show(ClsIdioma.T("Ya está cargada la ") + cmbTipoComprobante.Text.Trim() + " N.º " + txtNumeroComprobante.Text.Trim() +
                        ClsIdioma.T(" de ") + txtProveedor.Text.Trim() + ClsIdioma.T(".\n\nRevise el número o anule la compra anterior si estaba mal cargada."),
                        ClsIdioma.T("Comprobante repetido"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtNumeroComprobante.Focus();
                    return;
                }

                ClsCompraEntidad compra = new ClsCompraEntidad();

                compra.IdProveedor = idProveedor;
                compra.IdSucursal = ObtenerIdSucursal();
                compra.Fecha = DateTime.Now;
                compra.FechaEntregaEstimada = dtpEntrega.Checked ? dtpEntrega.Value.Date : (DateTime?)null;
                compra.TipoComprobante = cmbTipoComprobante.Text.Trim();
                compra.NumeroComprobante = string.IsNullOrWhiteSpace(txtNumeroComprobante.Text) ? null : txtNumeroComprobante.Text.Trim();
                compra.SubtotalSinIVA = Convert.ToDecimal(txtSubsinImpuesto.Text);
                compra.IVA = Convert.ToDecimal(txtIva.Text);
                compra.Total = Convert.ToDecimal(txtTotal.Text);
                compra.Observaciones = txtObservaciones.Text.Trim();

     
                compra.IdUsuario = SesionUsuario.IdUsuario;

                if (EsCuentaCorriente())
                {
                    if (dtpVencimiento.Value.Date < DateTime.Today)
                    {
                        MessageBox.Show(ClsIdioma.T("La fecha de vencimiento no puede ser anterior a la fecha de la compra."),
                            ClsIdioma.T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    compra.CondicionPago = "CTA_CTE";
                    compra.FechaVencimiento = dtpVencimiento.Value.Date;
                    compra.IdMetodoPago = null;
                    compra.IdSesionCaja = null;
                }
                else
                {
                    if (cmbMedioPagoCompra.SelectedValue == null)
                    {
                        MessageBox.Show(ClsIdioma.T("Seleccione el medio de pago de la compra."), ClsIdioma.T("Aviso"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    compra.CondicionPago = "CONTADO";
                    compra.FechaVencimiento = null;
                    compra.IdMetodoPago = Convert.ToInt32(cmbMedioPagoCompra.SelectedValue);

                    if (chkPagaDesdeCaja.Enabled && chkPagaDesdeCaja.Checked)
                    {
                        ClsSesionCajaEntidad sesion = logicaCaja.ObtenerSesionAbierta();
                        compra.IdSesionCaja = sesion != null ? sesion.IdSesionCaja : (int?)null;
                    }
                }

                compra.Detalles = new List<ClsDetalleCompraEntidad>();
                compra.Detalles = new List<ClsDetalleCompraEntidad>();

                foreach (DataGridViewRow fila in dtgNuevaCompra.Rows)
                {
                    if (fila.IsNewRow)
                    {
                        continue;
                    }

                    if (fila.Tag == null)
                    {
                        MessageBox.Show(ClsIdioma.T("Uno de los productos no tiene un identificador válido."), ClsIdioma.T("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    if (fila.Cells["Column4"].Value == null)
                    {
                        MessageBox.Show(ClsIdioma.T("Ingrese el costo de \"") + fila.Cells["Column3"].Value + "\".", ClsIdioma.T("Aviso"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        dtgNuevaCompra.CurrentCell = fila.Cells["Column4"];
                        return;
                    }

                    if (fila.Cells["Column2"].Value == null || fila.Cells["Column5"].Value == null)
                    {
                        MessageBox.Show(ClsIdioma.T("Complete la cantidad, el precio y el IVA del producto."), ClsIdioma.T("Aviso"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    if (!decimal.TryParse(fila.Cells["Column2"].Value.ToString(), out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show(ClsIdioma.T("La cantidad debe ser mayor que cero."), ClsIdioma.T("Aviso"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    if (!decimal.TryParse(fila.Cells["Column4"].Value.ToString(), out decimal precio) || precio < 0)
                    {
                        MessageBox.Show(ClsIdioma.T("El precio sin IVA no puede ser negativo."), ClsIdioma.T("Aviso"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    if (!decimal.TryParse(fila.Cells["Column5"].Value.ToString(), out decimal porcentajeIVA) || porcentajeIVA < 0 || porcentajeIVA > 100)
                    {
                        MessageBox.Show(ClsIdioma.T("El porcentaje de IVA debe estar entre 0 y 100."), ClsIdioma.T("Aviso"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    ClsDetalleCompraEntidad detalle = new ClsDetalleCompraEntidad();

                    detalle.IdProducto = Convert.ToInt32(fila.Tag);
                    detalle.Cantidad = decimal.Round(cantidad, 3, MidpointRounding.AwayFromZero);
                    detalle.PrecioSinIVA = decimal.Round(precio, 2, MidpointRounding.AwayFromZero);
                    detalle.PorcentajeIVA = decimal.Round(porcentajeIVA, 2, MidpointRounding.AwayFromZero);

                    decimal subtotalDetalle = Math.Round(detalle.Cantidad * detalle.PrecioSinIVA, 2, MidpointRounding.AwayFromZero);
                    decimal ivaDetalle = Math.Round(subtotalDetalle * detalle.PorcentajeIVA / 100, 2, MidpointRounding.AwayFromZero);

                    detalle.Total = subtotalDetalle + ivaDetalle;

                    compra.Detalles.Add(detalle);
                }

                int idCompra = logica.GuardarCompra(compra);

                MessageBox.Show(ClsIdioma.T("La compra se guardó correctamente.\n\nN.º de compra: ") + idCompra,
                    ClsIdioma.T("Compra guardada"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo guardar la compra.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtProveedor.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show(ClsIdioma.T("Ingrese el nombre o CUIT del proveedor."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtProveedor.Focus();
                return;
            }

            DataTable tabla = logicaProveedor.BuscarProveedor(texto);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("No se encontró ningún proveedor activo."), ClsIdioma.T("Proveedor no encontrado"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtProveedor.Focus();
                return;
            }

            if (tabla.Rows.Count > 1)
            {
                MessageBox.Show(ClsIdioma.T("Se encontraron varios proveedores. Ingrese un nombre o CUIT más específico."),
                    ClsIdioma.T("Varios proveedores"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            int idEncontrado = Convert.ToInt32(tabla.Rows[0]["IdProveedor"]);
            txtProveedor.Text = tabla.Rows[0]["Nombre"].ToString();

            idProveedor = idEncontrado;
            lstProveedores.Visible = false;
            CargarSucursales();

        }
        private void txtCodigobarra_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCodigobarra.Text.Trim();

            lstProductos.Items.Clear();
            lstProductos.Visible = false;

            if (string.IsNullOrWhiteSpace(texto))
            {
                productosEncontrados = null;
                return;
            }

            if (ObtenerIdSucursal() == 0)
            {
                productosEncontrados = null;
                return;
            }

            try
            {
                productosEncontrados = logica.BuscarProductoCompra(texto, ObtenerIdSucursal());
            }
            catch (Exception ex)
            {
                productosEncontrados = null;
                MessageBox.Show(ClsIdioma.T("No se pudieron buscar los productos.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (productosEncontrados.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow fila in productosEncontrados.Rows)
            {
                lstProductos.Items.Add(fila["CodigoBarra"].ToString() + " - " + fila["Nombre"].ToString());
            }

            lstProductos.Visible = true;
            lstProductos.BringToFront();

            if (lstProductos.Items.Count > 0)
            {
                lstProductos.SelectedIndex = 0;
            }

            txtCodigobarra.Focus();
            txtCodigobarra.SelectionStart = txtCodigobarra.Text.Length;
        }
        private void txtCodigobarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lstProductos.Visible || lstProductos.Items.Count == 0)
            {
                return;
            }

            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;

                if (lstProductos.SelectedIndex < lstProductos.Items.Count - 1)
                {
                    lstProductos.SelectedIndex++;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;

                if (lstProductos.SelectedIndex > 0)
                {
                    lstProductos.SelectedIndex--;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnCargarProducto_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;

                lstProductos.Items.Clear();
                lstProductos.Visible = false;
                productosEncontrados = null;
            }
        }
        private void lstProductos_DoubleClick(object sender, EventArgs e)
        {
            btnCargarProducto_Click(sender, e);
        }
        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            string texto = txtProveedor.Text.Trim();

            idProveedor = 0;
            cmbSucursal.DataSource = null;
            cmbSucursal.Enabled = false;
            ActualizarSucursalSeleccionada();
            lstProveedores.Items.Clear();
            lstProveedores.Visible = false;

            if (string.IsNullOrWhiteSpace(texto))
            {
                proveedoresEncontrados = null;
                return;
            }

            proveedoresEncontrados = logicaProveedor.BuscarProveedor(texto);

            if (proveedoresEncontrados == null || proveedoresEncontrados.Rows.Count == 0)
            {
                proveedoresEncontrados = null;
                return;
            }

            foreach (DataRow fila in proveedoresEncontrados.Rows)
            {
                lstProveedores.Items.Add(fila["Nombre"].ToString() + " - " + fila["IdProveedor"].ToString());
            }

            lstProveedores.Visible = true;
            lstProveedores.BringToFront();

            if (lstProveedores.Items.Count > 0)
                lstProveedores.SelectedIndex = 0;

        }
        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                if (proveedoresEncontrados != null && proveedoresEncontrados.Rows.Count > 0)
                {
                    SeleccionarProveedor();
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

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
                lstProveedores.Visible = false;
            }
        }
        private void txtProveedor_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarProveedor();
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
                lstProveedores.Visible = false;
                txtProveedor.Focus();
            }
        }


        #endregion
















        private void cmbSucursal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ActualizarSucursalSeleccionada();
        }
        private void cmbCondicionPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarOpcionesPago();
        }
    }
}
