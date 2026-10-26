using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica.NegocioLogica;

namespace CapaVista
{
    public partial class frmCargaRapidaPrecios : Form
    {
        private ClsPrecioLogica logica = new ClsPrecioLogica();
        private DataTable productosEncontrados;
        public frmCargaRapidaPrecios()
        {
            InitializeComponent();

            txtBuscarProducto.KeyDown += txtBuscarProducto_KeyDown;

            ConfigurarAutocompletadoProductos();
        }

        #region Metodos
        private void ConfigurarAutocompletadoProductos()
        {
            DataTable tabla = logica.BuscarProductos("");

            AutoCompleteStringCollection productos = new AutoCompleteStringCollection();

            foreach (DataRow fila in tabla.Rows)
            {
                string codigo = fila["CodigoBarra"].ToString();
                string sku = fila["SKU"].ToString();
                string nombre = fila["Nombre"].ToString();

                string texto = codigo;

                if (!string.IsNullOrWhiteSpace(sku))
                {
                    texto += " / " + sku;
                }

                texto += " - " + nombre;

                productos.Add(texto);
            }

            txtBuscarProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscarProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBuscarProducto.AutoCompleteCustomSource = productos;
        }
        private bool ProductoYaCargado(int idProducto)
        {
            foreach (DataGridViewRow fila in dgvPrecios.Rows)
            {
                if (fila.Tag == null)
                    continue;

                if (Convert.ToInt32(fila.Tag) == idProducto)
                {
                    return true;
                }
            }

            return false;
        }
        private void CargarProductoEnGrid(DataRow producto)
        {
            int idProducto = Convert.ToInt32(producto["IdProducto"]);

            if (ProductoYaCargado(idProducto))
            {
                MessageBox.Show("El producto ya fue agregado a la lista.", "Producto duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBuscarProducto.SelectAll();
                return;
            }

            string codigo = producto["CodigoBarra"].ToString();
            string sku = producto["SKU"].ToString();
            string nombre = producto["Nombre"].ToString();
            decimal precio = Convert.ToDecimal(producto["PrecioVenta"]);

            int indice = dgvPrecios.Rows.Add();

            dgvPrecios.Rows[indice].Cells["clnCodigo"].Value = string.IsNullOrWhiteSpace(sku) ? codigo : codigo + " / " + sku;
            dgvPrecios.Rows[indice].Cells["clnProducto"].Value = nombre;
            dgvPrecios.Rows[indice].Cells["clnPrecioActual"].Value = precio.ToString("N2");
            dgvPrecios.Rows[indice].Cells["clnNuevoPrecio"].Value = precio.ToString("N2");
            dgvPrecios.Rows[indice].Tag = idProducto;

            txtBuscarProducto.Clear();
            txtBuscarProducto.Focus();
        }
        #endregion


        #region Eventos
        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;

            string texto = txtBuscarProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                return;
            }

            // Si el texto viene del autocompletado:
            // "77980 / 1002 - bizcocho de grasa"
            // tomamos solamente el código de barra.
            if (texto.Contains(" / "))
            {
                texto = texto.Split(new[] { " / " }, StringSplitOptions.None)[0].Trim();
            }
            else if (texto.Contains(" - "))
            {
                texto = texto.Split(new[] { " - " }, StringSplitOptions.None)[0].Trim();
            }

            DataTable tabla = logica.BuscarProductos(texto);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró ningún producto.",
                    "Producto no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (tabla.Rows.Count > 1)
            {
                MessageBox.Show(
                    "Se encontraron varios productos. Ingrese un código, SKU o nombre más específico.",
                    "Varios productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            CargarProductoEnGrid(tabla.Rows[0]);
        }
        private void btnAplicarAumento_Click(object sender, EventArgs e)
        {
            if (dgvPrecios.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos cargados para aplicar el aumento.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            decimal porcentaje = nudPorcentaje.Value;

            if (porcentaje == 0)
            {
                MessageBox.Show("Ingrese un porcentaje distinto de cero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                nudPorcentaje.Focus();
                return;
            }

            foreach (DataGridViewRow fila in dgvPrecios.Rows)
            {
                if (fila.Cells["clnPrecioActual"].Value == null)
                {
                    continue;
                }

                if (!decimal.TryParse(fila.Cells["clnPrecioActual"].Value.ToString(), out decimal precioActual))
                {
                    continue;
                }

                decimal nuevoPrecio = precioActual + (precioActual * porcentaje / 100);
                fila.Cells["clnNuevoPrecio"].Value = nuevoPrecio.ToString("N2");
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvPrecios.Rows.Count == 0)
            {
                MessageBox.Show("No hay precios para guardar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de guardar los nuevos precios?", "Confirmar actualización",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                DataTable tablaPrecios = new DataTable();

                tablaPrecios.Columns.Add("IdProducto", typeof(int));
                tablaPrecios.Columns.Add("PrecioVenta", typeof(decimal));

                foreach (DataGridViewRow fila in dgvPrecios.Rows)
                {
                    if (fila.Tag == null)
                    {
                        continue;
                    }

                    if (!decimal.TryParse(fila.Cells["clnNuevoPrecio"].Value?.ToString(), out decimal nuevoPrecio))
                    {
                        MessageBox.Show("Uno de los productos tiene un precio nuevo inválido.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    if (nuevoPrecio < 0)
                    {
                        MessageBox.Show("El precio no puede ser negativo.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    int idProducto = Convert.ToInt32(fila.Tag);

                    tablaPrecios.Rows.Add(idProducto, nuevoPrecio);
                }

                if (tablaPrecios.Rows.Count == 0)
                {
                    MessageBox.Show("No hay precios válidos para guardar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                logica.ActualizarPrecios(tablaPrecios);

                MessageBox.Show("Los precios se actualizaron correctamente.", "Precios actualizados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron actualizar los precios.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        private void gpbBusqueda_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
