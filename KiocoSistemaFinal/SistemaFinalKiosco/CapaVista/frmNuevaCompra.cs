using CapaEntidades.NegocioEntidades;
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
    public partial class frmNuevaCompra : Form
    {
        private ClsCompraLogica logica = new ClsCompraLogica();
        private ClsLogicaProveedor logicaProveedor = new ClsLogicaProveedor();
        private int idProveedor = 0;
        private DataTable productosEncontrados;
        private DataTable proveedoresEncontrados;

        public frmNuevaCompra(bool mostrarChk)
        {
            InitializeComponent();

            dtgNuevaCompra.Columns["Column1"].ReadOnly = true;
            dtgNuevaCompra.Columns["Column2"].ReadOnly = false;
            dtgNuevaCompra.Columns["Column3"].ReadOnly = true;
            dtgNuevaCompra.Columns["Column4"].ReadOnly = true;
            dtgNuevaCompra.Columns["Column5"].ReadOnly = true;
            dtgNuevaCompra.Columns["Column6"].ReadOnly = true;

            dtgNuevaCompra.CellEndEdit += dataGridView1_CellEndEdit_1;
            txtCodigobarra.TextChanged += txtCodigobarra_TextChanged;
            txtCodigobarra.KeyDown += txtCodigobarra_KeyDown;

            ConfigurarAutocompletadoProveedores();
        }



        #region Metodos
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
            if (proveedoresEncontrados == null ||
                lstProveedores.SelectedIndex < 0 ||
                lstProveedores.SelectedIndex >= proveedoresEncontrados.Rows.Count)
            {
                return;
            }

            DataRow proveedor = proveedoresEncontrados.Rows[lstProveedores.SelectedIndex];

            idProveedor = Convert.ToInt32(proveedor["IdProveedor"]);
            txtProveedor.Text = proveedor["Nombre"].ToString();

            lstProveedores.Visible = false;
            lstProveedores.Items.Clear();
            proveedoresEncontrados = null;

            txtProveedor.SelectionStart = txtProveedor.Text.Length;
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
                MessageBox.Show("Seleccione un producto de la lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigobarra.Focus();
                return;
            }

            DataRow producto = productosEncontrados.Rows[lstProductos.SelectedIndex];

            int idProducto = Convert.ToInt32(producto["IdProducto"]);
            string codigoBarra = producto["CodigoBarra"].ToString();
            string nombre = producto["Nombre"].ToString();
            decimal precio = Convert.ToDecimal(producto["PrecioVenta"]);
            decimal iva = Convert.ToDecimal(producto["Alicuota"]);

            int indice = dtgNuevaCompra.Rows.Add();

            DataGridViewRow fila = dtgNuevaCompra.Rows[indice];

            fila.Cells["Column1"].Value = codigoBarra;
            fila.Cells["Column2"].Value = 1;
            fila.Cells["Column3"].Value = nombre;
            fila.Cells["Column4"].Value = precio;
            fila.Cells["Column5"].Value = iva;
            decimal subtotal = Math.Round(precio, 2, MidpointRounding.AwayFromZero);
            decimal ivaCalculado = Math.Round(subtotal * iva / 100, 2, MidpointRounding.AwayFromZero);
            fila.Cells["Column6"].Value = subtotal + ivaCalculado;

            fila.Tag = idProducto;

            CalcularTotales();

            txtCodigobarra.Clear();
            lstProductos.Items.Clear();
            lstProductos.Visible = false;
            productosEncontrados = null;

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

            if (fila.Cells["Column2"].Value == null || fila.Cells["Column4"].Value == null || fila.Cells["Column5"].Value == null)
            {
                return;
            }

            if (!decimal.TryParse(fila.Cells["Column2"].Value.ToString(), out decimal cantidad))
            {
                cantidad = 0;
                fila.Cells["Column2"].Value = 0;
            }

            decimal precio = Convert.ToDecimal(fila.Cells["Column4"].Value);
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
                MessageBox.Show("Seleccione un producto para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar el producto seleccionado?", "Confirmar eliminación",
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
                MessageBox.Show("Debe seleccionar un proveedor.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtProveedor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbTipoComprobante.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de comprobante.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbTipoComprobante.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroComprobante.Text))
            {
                MessageBox.Show("Debe ingresar el número de comprobante.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNumeroComprobante.Focus();
                return;
            }

            if (dtpFechaPedido.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de compra no puede ser futura.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dtpFechaPedido.Focus();
                return;
            }

            if (dtgNuevaCompra.Rows.Cast<DataGridViewRow>().All(fila => fila.IsNewRow))
            {
                MessageBox.Show("Debe agregar al menos un producto a la compra.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigobarra.Focus();
                return;
            }

            try
            {
                ClsCompraEntidad compra = new ClsCompraEntidad();

                compra.IdProveedor = idProveedor;
                compra.Fecha = dtpFechaPedido.Value;
                compra.TipoComprobante = cmbTipoComprobante.Text.Trim();
                compra.NumeroComprobante = txtNumeroComprobante.Text.Trim();
                compra.SubtotalSinIVA = Convert.ToDecimal(txtSubsinImpuesto.Text);
                compra.IVA = Convert.ToDecimal(txtIva.Text);
                compra.Total = Convert.ToDecimal(txtTotal.Text);
                compra.Observaciones = txtObservaciones.Text.Trim();
                compra.Detalles = new List<ClsDetalleCompraEntidad>();

                foreach (DataGridViewRow fila in dtgNuevaCompra.Rows)
                {
                    if (fila.IsNewRow)
                    {
                        continue;
                    }

                    if (fila.Tag == null)
                    {
                        MessageBox.Show("Uno de los productos no tiene un identificador válido.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    if (fila.Cells["Column2"].Value == null || fila.Cells["Column4"].Value == null || fila.Cells["Column5"].Value == null)
                    {
                        MessageBox.Show("Complete la cantidad, el precio y el IVA del producto.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    if (!decimal.TryParse(fila.Cells["Column2"].Value.ToString(), out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("La cantidad debe ser mayor que cero.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    if (!decimal.TryParse(fila.Cells["Column4"].Value.ToString(), out decimal precio) || precio < 0)
                    {
                        MessageBox.Show("El precio sin IVA no puede ser negativo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    if (!decimal.TryParse(fila.Cells["Column5"].Value.ToString(), out decimal porcentajeIVA) ||  porcentajeIVA < 0 || porcentajeIVA > 100)
                    {
                        MessageBox.Show("El porcentaje de IVA debe estar entre 0 y 100.", "Aviso",
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

                MessageBox.Show("La compra se guardó correctamente.\n\nN.º de compra: " + idCompra,
                    "Compra guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la compra.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtProveedor.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Ingrese el nombre o CUIT del proveedor.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtProveedor.Focus();
                return;
            }

            DataTable tabla = logicaProveedor.BuscarProveedor(texto);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún proveedor activo.", "Proveedor no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtProveedor.Focus();
                return;
            }

            if (tabla.Rows.Count > 1)
            {
                MessageBox.Show("Se encontraron varios proveedores. Ingrese un nombre o CUIT más específico.",
                    "Varios proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            idProveedor = Convert.ToInt32(tabla.Rows[0]["IdProveedor"]);
            txtProveedor.Text = tabla.Rows[0]["Nombre"].ToString();


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

            productosEncontrados = logica.BuscarProducto(texto);

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
            if (!lstProveedores.Visible || lstProveedores.Items.Count == 0)
                return;

            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;

                if (lstProveedores.SelectedIndex < lstProveedores.Items.Count - 1)
                    lstProveedores.SelectedIndex++;
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;

                if (lstProveedores.SelectedIndex > 0)
                    lstProveedores.SelectedIndex--;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SeleccionarProveedor();
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


        #endregion














 
    }
}
