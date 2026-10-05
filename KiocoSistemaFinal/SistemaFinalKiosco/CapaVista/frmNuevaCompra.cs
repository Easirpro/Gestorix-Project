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
        private ClsGestorLogicaProveedor logicaProveedor = new ClsGestorLogicaProveedor();
        private int idProveedor = 0;
        private DataTable productosEncontrados;

        public frmNuevaCompra(bool mostrarChk)
        {
            InitializeComponent();

            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit_1;
            txtCodigobarra.TextChanged += txtCodigobarra_TextChanged;
            txtCodigobarra.KeyDown += txtCodigobarra_KeyDown;

            ConfigurarAutocompletadoProveedores();
        }



        #region Metodos
        private void CalcularTotales()
        {
            decimal subtotalSinIVA = 0;
            decimal ivaTotal = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
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

                decimal subtotal = cantidad * precio;
                decimal iva = subtotal * porcentajeIVA / 100;

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
            DataTable tabla = logicaProveedor.BuscarProveedor("");
            AutoCompleteStringCollection proveedores = new AutoCompleteStringCollection();

            foreach (DataRow fila in tabla.Rows)
            {
                proveedores.Add(fila["Nombre"].ToString());
            }

            txtProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProveedor.AutoCompleteCustomSource = proveedores;
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

            int indice = dataGridView1.Rows.Add();

            DataGridViewRow fila = dataGridView1.Rows[indice];

            fila.Cells["Column1"].Value = codigoBarra;
            fila.Cells["Column2"].Value = 1;
            fila.Cells["Column3"].Value = nombre;
            fila.Cells["Column4"].Value = precio;
            fila.Cells["Column5"].Value = iva;
            fila.Cells["Column6"].Value = precio * (1 + iva / 100);

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

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            if (fila.Cells["Column2"].Value == null || fila.Cells["Column4"].Value == null || fila.Cells["Column5"].Value == null)
            {
                return;
            }


            if (!decimal.TryParse(fila.Cells["Column2"].Value.ToString(), out decimal cantidad) || cantidad <= 0)
            {
                cantidad = 1;
                fila.Cells["Column2"].Value = 1;
            }

            if (!decimal.TryParse(fila.Cells["Column4"].Value.ToString(), out decimal precio) || precio < 0)
            {
                precio = 0;
                fila.Cells["Column4"].Value = 0;
            }

            if (!decimal.TryParse(fila.Cells["Column5"].Value.ToString(), out decimal iva))
            {
                iva = 0;
            }

            decimal subtotal = cantidad * precio;
            decimal total = subtotal + (subtotal * iva / 100);

            fila.Cells["Column6"].Value = total;

            CalcularTotales();
        }
        private void txtSubsinImpuesto_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnEliminarCompra_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
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

            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

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

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de comprobante.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                comboBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroComprobante.Text))
            {
                MessageBox.Show("Debe ingresar el número de comprobante.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNumeroComprobante.Focus();
                return;
            }

            if (dataGridView1.Rows.Count == 0)
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
                compra.Fecha = dateTimePicker1.Value;
                compra.TipoComprobante = comboBox1.Text.Trim();
                compra.NumeroComprobante = txtNumeroComprobante.Text.Trim();
                compra.SubtotalSinIVA = Convert.ToDecimal(txtSubsinImpuesto.Text);
                compra.IVA = Convert.ToDecimal(txtIva.Text);
                compra.Total = Convert.ToDecimal(txtTotal.Text);
                compra.Observaciones = txtObservaciones.Text.Trim();
                compra.Detalles = new List<ClsDetalleCompraEntidad>();

                foreach (DataGridViewRow fila in dataGridView1.Rows)
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

                    ClsDetalleCompraEntidad detalle = new ClsDetalleCompraEntidad();

                    detalle.IdProducto = Convert.ToInt32(fila.Tag);
                    detalle.Cantidad = Convert.ToDecimal(fila.Cells["Column2"].Value);
                    detalle.PrecioSinIVA = Convert.ToDecimal(fila.Cells["Column4"].Value);
                    detalle.PorcentajeIVA = Convert.ToDecimal(fila.Cells["Column5"].Value);
                    detalle.Total = Convert.ToDecimal(fila.Cells["Column6"].Value);

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

        #endregion











    }
}
