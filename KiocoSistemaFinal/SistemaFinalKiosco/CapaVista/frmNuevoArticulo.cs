using CapaEntidades.NegocioEntidad;
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
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaVista
{
    public partial class frmNuevoArticulo : Form
    {
        private int idProductoModificar = 0;
        public frmNuevoArticulo()
        {
            InitializeComponent();

            this.Load += frmNuevoArticulo_Load;

            chkActivarIva.CheckedChanged += chkActivarIva_CheckedChanged;
            chkControlLote.CheckedChanged += chkControlLote_CheckedChanged;
        }
        public frmNuevoArticulo(int idProducto)
        {
            InitializeComponent();

            idProductoModificar = idProducto;

            this.Load += frmNuevoArticulo_Load;

            chkActivarIva.CheckedChanged += chkActivarIva_CheckedChanged;
            chkControlLote.CheckedChanged += chkControlLote_CheckedChanged;
        }

        #region Metodos

        #endregion
        private void CargarProximoSKU()
        {
            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            int proximoSKU = logica.ObtenerProximoSKU();

            txtSKU.Text = proximoSKU.ToString();
        }
        private void frmNuevoArticulo_Load(object sender, EventArgs e)
        {

            CargarMarcas();
            CargarCategorias();
            CargarUnidades();
            CargarIVAs();

            if (idProductoModificar == 0)
            {
                CargarProximoSKU();
            }
            else
            {
                CargarProductoModificar();
            }

            chkControlStock_CheckedChanged(null, null);
            chkAlertaVencimiento_CheckedChanged(null, null);
            chkControlLote_CheckedChanged(null, null);
        }
        private void CargarProductoModificar()
        {
            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            DataTable tabla = logica.ObtenerProductoPorId(idProductoModificar);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el artículo.","Modificar artículo",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);

                return;
            }

            DataRow fila = tabla.Rows[0];

            txtCodigo.Text = fila["CodigoBarra"]?.ToString() ?? "";
            txtSKU.Text = fila["SKU"]?.ToString() ?? "";
            txtNombreProducto.Text = fila["Nombre"]?.ToString() ?? "";
            txtDescripcion.Text = fila["Descripcion"]?.ToString() ?? "";

            if (fila["IdMarca"] != DBNull.Value)
            {
                cmbMarca.SelectedValue = Convert.ToInt32(fila["IdMarca"]);
            }

            if (fila["IdCategoria"] != DBNull.Value)
            {
                cmbRubro.SelectedValue = Convert.ToInt32(fila["IdCategoria"]);
            }

            if (fila["IdUnidad"] != DBNull.Value)
            {
                cmbUnidadVenta.SelectedValue = Convert.ToInt32(fila["IdUnidad"]);
            }

            if (fila["IdIVA"] != DBNull.Value)
            {
                int idIVA = Convert.ToInt32(fila["IdIVA"]);

                if (idIVA == 1)
                {
                    chkActivarIva.Checked = false;
                }
                else
                {
                    chkActivarIva.Checked = true;
                    cmbIva.SelectedValue = idIVA;
                }
            }

            txtPrecioVenta.Text = fila["PrecioVenta"]?.ToString() ?? "";
        }
        private void CargarMarcas()
        {
            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            cmbMarca.DataSource = logica.CargarMarcasActivas();

            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "IdMarca";

            cmbMarca.SelectedIndex = -1;
        }
        private void CargarCategorias()
        {
            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            cmbRubro.DataSource = logica.CargarCategoriasActivas();

            cmbRubro.DisplayMember = "Nombre";
            cmbRubro.ValueMember = "IdCategoria";

            cmbRubro.SelectedIndex = -1;
        }
        private void CargarUnidades()
        {
            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            cmbUnidadVenta.DataSource = logica.CargarUnidades();

            cmbUnidadVenta.DisplayMember = "Nombre";
            cmbUnidadVenta.ValueMember = "IdUnidad";

            cmbUnidadVenta.SelectedIndex = -1;
        }
        private void CargarIVAs()
        {
            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            cmbIva.DataSource = logica.CargarIVAsActivos();
            cmbIva.DisplayMember = "Alicuota";
            cmbIva.ValueMember = "IdIVA";
            cmbIva.SelectedIndex = -1;
        }
        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                txtCodigo.Focus();
                return false;
            }

            string codigoBarra = txtCodigo.Text.Trim();

            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            if (logica.ExisteCodigoBarra(codigoBarra, idProductoModificar))
            {
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                txtDescripcion.Focus();
                return false;
            }

            if (cmbUnidadVenta.SelectedIndex == -1 || cmbUnidadVenta.SelectedValue == null)
            {
                cmbUnidadVenta.Focus();
                return false;
            }

            if (cmbRubro.SelectedIndex == -1 || cmbRubro.SelectedValue == null)
            {
                cmbRubro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioCosto.Text))
            {
                txtPrecioCosto.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto))
            {
                txtPrecioCosto.Focus();
                return false;
            }

            if (precioCosto <= 0)
            {
                txtPrecioCosto.Focus();
                return false;
            }

            if (chkActivarIva.Checked)
            {
                if (cmbIva.SelectedIndex == -1 || cmbIva.SelectedValue == null)
                {
                    cmbIva.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtGanancia.Text))
            {
                txtGanancia.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGanancia.Text, out decimal ganancia))
            {
                txtGanancia.Focus();
                return false;
            }

            if (ganancia < 0)
            {
                txtGanancia.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
            {
                txtPrecioCosto.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
            {
                txtPrecioCosto.Focus();
                return false;
            }

            if (precioVenta <= 0)
            {
                txtPrecioCosto.Focus();
                return false;
            }

            decimal stockMinimo = 0;

            if (chkControlStock.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtStockMinimo.Text))
                {
                    txtStockMinimo.Focus();
                    return false;
                }

                if (!decimal.TryParse(txtStockMinimo.Text, out stockMinimo))
                {
                    txtStockMinimo.Focus();
                    return false;
                }

                if (stockMinimo < 0)
                {
                    txtStockMinimo.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtStockMaximo.Text))
                {
                    txtStockMaximo.Focus();
                    return false;
                }

                if (!decimal.TryParse(txtStockMaximo.Text, out decimal stockIdeal))
                {
                    txtStockMaximo.Focus();
                    return false;
                }

                if (stockIdeal < 0)
                {
                    txtStockMaximo.Focus();
                    return false;
                }

                if (stockIdeal < stockMinimo)
                {
                    txtStockMaximo.Focus();
                    return false;
                }
            }

            if (chkAlertaVencimiento.Checked)
            {
                if (dtpFechaVencimiento.Value.Date < DateTime.Today)
                {
                    dtpFechaVencimiento.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtAlertaVencimiento.Text))
                {
                    txtAlertaVencimiento.Focus();
                    return false;
                }

                if (!int.TryParse(txtAlertaVencimiento.Text, out int diasAlerta))
                {
                    txtAlertaVencimiento.Focus();
                    return false;
                }

                if (diasAlerta < 0)
                {
                    txtAlertaVencimiento.Focus();
                    return false;
                }
            }

            if (chkControlLote.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtCodigoPorLote.Text))
                {
                    txtCodigoPorLote.Focus();
                    return false;
                }

                if (dtpFechaFabricacion.Value.Date > DateTime.Today)
                {
                    dtpFechaFabricacion.Focus();
                    return false;
                }

                if (dtpFechaVencimiento.Value.Date < dtpFechaFabricacion.Value.Date)
                {
                    dtpFechaVencimiento.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                txtNombreProducto.Focus();
                return false;
            }

            if (cmbMarca.SelectedIndex == -1 || cmbMarca.SelectedValue == null)
            {
                cmbMarca.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                txtSKU.Focus();
                return false;
            }

            return true;
        }
        private void CalcularPrecioVenta()
        {
            if (!decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto))
            {
                txtPrecioVenta.Text = "";
                return;
            }

            if (!decimal.TryParse(txtGanancia.Text, out decimal ganancia))
            {
                txtPrecioVenta.Text = "";
                return;
            }

            if (precioCosto <= 0)
            {
                txtPrecioVenta.Text = "";
                return;
            }

            decimal precioVenta = precioCosto + (precioCosto * ganancia / 100);

            txtPrecioVenta.Text = precioVenta.ToString("0.##");
        }


        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                {
                    return;
                }

                ClsProducto producto = new ClsProducto();

                producto.IdProducto = idProductoModificar;
                producto.CodigoBarra = txtCodigo.Text.Trim();
                producto.SKU = txtSKU.Text.Trim();
                producto.Nombre = txtNombreProducto.Text.Trim();
                producto.Descripcion = txtDescripcion.Text.Trim();
                producto.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                producto.IdCategoria = Convert.ToInt32(cmbRubro.SelectedValue);
                producto.IdUnidad = Convert.ToInt32(cmbUnidadVenta.SelectedValue);

                if (chkActivarIva.Checked)
                {
                    producto.IdIVA = Convert.ToInt32(cmbIva.SelectedValue);
                }

                else
                {
                    producto.IdIVA = 1;
                }

                producto.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);

                ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

                if (idProductoModificar == 0)
                {
                    producto.Activo = true;

                    int idProducto = logica.RegistrarProducto(producto);

                    if (idProducto > 0)
                    {

                        ClsStock stock = new ClsStock();

                        stock.IdProducto = idProducto;
                        stock.CantidadActual = 0;

                        if (chkControlStock.Checked)
                        {
                            stock.StockMinimo = Convert.ToDecimal(txtStockMinimo.Text);
                            stock.StockIdeal = Convert.ToDecimal(txtStockMaximo.Text);
                        }
                        else
                        {
                            stock.StockMinimo = 0;
                            stock.StockIdeal = 0;
                        }

                        bool stockRegistrado = logica.RegistrarStock(stock);

                        if (!stockRegistrado)
                        {
                            MessageBox.Show("El artículo fue registrado, pero no se pudo registrar su Stock.",
                                "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                            return;
                        }

                        MessageBox.Show("Artículo registrado correctamente.","Registro",
                            MessageBoxButtons.OK,MessageBoxIcon.Information);

                        this.Close();
                    }
                }

                else
                {
                    bool modificado = logica.ModificarProducto(producto);

                    if (!modificado)
                    {
                        MessageBox.Show("No se pudo modificar el artículo.","Modificar artículo",
                            MessageBoxButtons.OK,MessageBoxIcon.Warning);

                        return;
                    }

                    MessageBox.Show("Artículo modificado correctamente.","Modificar artículo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el artículo.\n\n" + ex.Message,
                    "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void chkActivarIva_CheckedChanged(object sender, EventArgs e)
        {
            cmbIva.Enabled = chkActivarIva.Checked;
        }
        private void txtPrecioCosto_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecioVenta();
        }
        private void txtGanancia_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecioVenta();
        }
        private void gpbCargarPrecio_Enter(object sender, EventArgs e)
        {

        }
        private void chkControlStock_CheckedChanged(object sender, EventArgs e)
        {
            txtStockActual.Enabled = true;
            txtStockActual.ReadOnly = true;
            txtStockActual.Text = "0";

            txtStockMinimo.Enabled = chkControlStock.Checked;
            txtStockMaximo.Enabled = chkControlStock.Checked;
        }
        private void chkAlertaVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaVencimiento.Enabled = chkAlertaVencimiento.Checked;
            txtAlertaVencimiento.Enabled = chkAlertaVencimiento.Checked;
        }
        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {

        }
        private void chkControlLote_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigoPorLote.Enabled = chkControlLote.Checked;
            dtpFechaFabricacion.Enabled = chkControlLote.Checked;
            dtpFechaVencimiento.Enabled = chkControlLote.Checked;
            chkAlertaVencimiento.Enabled = chkControlLote.Checked;
            txtAlertaVencimiento.Enabled = chkControlLote.Checked;
        }


        #endregion





    }
}
