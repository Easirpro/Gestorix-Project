using CapaEntidades.NegocioEntidad;
using CapaLogica.BitacoraLogi;
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
        ClsLogicaProveedor logicaProveedor = new ClsLogicaProveedor();
        ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

        private clsBitacoraLogica logicaBitacora = new clsBitacoraLogica();
        private int idProductoModificar = 0;

        // Proveedores del artículo (cada fila es una sucursal de un proveedor). Al modificar se
        // recuerdan las que tenía, para dar de baja las que se quiten de la lista.
        private DataTable tablaProveedores = CrearTablaProveedores();
        private List<int> sucursalesOriginales = new List<int>();
        public frmNuevoArticulo()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.Load += frmNuevoArticulo_Load;


        }
        public frmNuevoArticulo(int idProducto)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            idProductoModificar = idProducto;

            this.Load += frmNuevoArticulo_Load;


        }

        #region Metodos
        private void CargarProximoSKU()
        {
            ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

            int proximoSKU = logica.ObtenerProximoSKU();

            txtSKU.Text = proximoSKU.ToString();
        }
        private void frmNuevoArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                new ClsGestorProductoLogica().RecalcularDVHProductos();
                CargarMarcas();
                CargarCategorias();
                CargarUnidades();
                CargarIVAs();
                CargarProveedores();
                ConfigurarGrillaProveedores();

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
            catch (Exception ex)
            {
                string errorRegistro = null;

                try
                {
                    this.logicaBitacora.RegistrarError(null, "frmNuevoArticulo.frmNuevoArticulo_Load",
                        ex.GetType().FullName, ex.Message, ex.ToString());
                }
                catch (Exception exRegistro)
                {
                    errorRegistro = exRegistro.Message;
                }

                string mensaje = ClsIdioma.T("Ocurrió un error al cargar el formulario de artículos.\n\n") + ex.Message;

                if (errorRegistro != null)
                {
                    mensaje += ClsIdioma.T("\n\nNo se pudo registrar el error técnico:\n") + errorRegistro;
                }

                MessageBox.Show(mensaje, ClsIdioma.T("Error al cargar artículos"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }
        private void CargarProductoModificar()
        {
            ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

            DataTable tabla = logica.ObtenerProductoPorId(idProductoModificar);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("No se encontró el artículo."), ClsIdioma.T("Modificar artículo"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataRow fila = tabla.Rows[0];

            DataTable tablaProveedor = logica.ObtenerProveedoresPorProducto(idProductoModificar);

            foreach (DataRow proveedor in tablaProveedor.Rows)
            {
                if (proveedor["Activo"] != DBNull.Value && !Convert.ToBoolean(proveedor["Activo"]))
                    continue;

                int idSucursal = Convert.ToInt32(proveedor["IdSucursal"]);

                tablaProveedores.Rows.Add(idSucursal, proveedor["Proveedor"].ToString(), proveedor["Sucursal"].ToString());
                sucursalesOriginales.Add(idSucursal);

                // El costo que se muestra es el del primer proveedor que lo tenga cargado.
                if (txtPrecioCosto.Text == "" && proveedor["PrecioCompra"] != DBNull.Value)
                {
                    txtPrecioCosto.Text = proveedor["PrecioCompra"].ToString();
                }
            }

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

            DataTable tablaStock = logica.ObtenerStockPorProducto(idProductoModificar);

            if (tablaStock.Rows.Count > 0)
            {
                DataRow stock = tablaStock.Rows[0];

                txtStockActual.Text = stock["CantidadActual"]?.ToString() ?? "0";
                txtStockMinimo.Text = stock["StockMinimo"]?.ToString() ?? "0";
                txtStockMaximo.Text = stock["StockIdeal"]?.ToString() ?? "0";
            }
            else
            {
                txtStockActual.Text = "0";
                txtStockMinimo.Text = "0";
                txtStockMaximo.Text = "0";
            }
        }
        private void CargarMarcas()
        {
            ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

            cmbMarca.DataSource = logica.CargarMarcasActivas();

            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "IdMarca";

            cmbMarca.SelectedIndex = -1;
        }
        private void CargarCategorias()
        {
            ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

            cmbRubro.DataSource = logica.CargarCategoriasActivas();

            cmbRubro.DisplayMember = "Nombre";
            cmbRubro.ValueMember = "IdCategoria";

            cmbRubro.SelectedIndex = -1;
        }
        private void CargarUnidades()
        {
            ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

            cmbUnidadVenta.DataSource = logica.CargarUnidades();

            cmbUnidadVenta.DisplayMember = "Nombre";
            cmbUnidadVenta.ValueMember = "IdUnidad";

            cmbUnidadVenta.SelectedIndex = -1;
        }
        private void CargarIVAs()
        {
            ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

            cmbIva.DataSource = logica.CargarIVAsActivos();
            cmbIva.DisplayMember = "Alicuota";
            cmbIva.ValueMember = "IdIVA";
            cmbIva.SelectedIndex = -1;
        }
        // Obligatorios: nombre, marca, unidad de venta y rubro (y el SKU, que se genera solo).
        // El resto es opcional: si se deja vacío se guarda sin dato (o en 0), pero si se carga
        // tiene que ser válido.
        private bool ValidarDatos()
        {
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

            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                txtSKU.Focus();
                return false;
            }

            string codigoBarra = txtCodigo.Text.Trim();

            if (codigoBarra != "" && new ClsGestorProductoLogica().ExisteCodigoBarra(codigoBarra, idProductoModificar))
            {
                txtCodigo.Focus();
                return false;
            }

            if (!DecimalOpcional(txtPrecioCosto, out _))
            {
                txtPrecioCosto.Focus();
                return false;
            }

            if (!DecimalOpcional(txtGanancia, out _))
            {
                txtGanancia.Focus();
                return false;
            }

            if (!DecimalOpcional(txtPrecioVenta, out _))
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

            if (!DecimalOpcional(txtStockActual, out _))
            {
                txtStockActual.Focus();
                return false;
            }

            if (!DecimalOpcional(txtStockMinimo, out decimal stockMinimo))
            {
                txtStockMinimo.Focus();
                return false;
            }

            if (!DecimalOpcional(txtStockMaximo, out decimal stockIdeal))
            {
                txtStockMaximo.Focus();
                return false;
            }

            if (chkControlStock.Checked && stockIdeal < stockMinimo)
            {
                txtStockMaximo.Focus();
                return false;
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
            }

            return true;
        }
        // Campo numérico opcional: vacío vale 0; si tiene algo, tiene que ser un número no negativo.
        private static bool DecimalOpcional(TextBox texto, out decimal valor)
        {
            valor = 0;

            if (string.IsNullOrWhiteSpace(texto.Text))
            {
                return true;
            }

            return decimal.TryParse(texto.Text, out valor) && valor >= 0;
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
        private void CargarProveedores()
        {
            DataTable tabla = logicaProveedor.ObtenerProveedores();

            DataRow fila = tabla.NewRow();
            fila["IdProveedor"] = 0;
            fila["RazonSocial"] = ClsIdioma.T("-Seleccione Proveedor-");
            tabla.Rows.InsertAt(fila, 0);

            cmbProveedor.DataSource = tabla;
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "IdProveedor";

            cmbProveedor.SelectedIndex = 0;
        }
        private static DataTable CrearTablaProveedores()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("IdSucursal", typeof(int));
            tabla.Columns.Add("Proveedor", typeof(string));
            tabla.Columns.Add("Sucursal", typeof(string));

            return tabla;
        }
        private void ConfigurarGrillaProveedores()
        {
            dgvProveedores.DataSource = tablaProveedores;

            dgvProveedores.Columns["IdSucursal"].Visible = false;
            dgvProveedores.Columns["Proveedor"].HeaderText = ClsIdioma.T("Proveedor");
            dgvProveedores.Columns["Sucursal"].HeaderText = ClsIdioma.T("Sucursal");
        }
        // Proveedor y sucursal elegidos en los combos (los dos tienen que estar elegidos).
        private bool ObtenerSucursalElegida(out int idSucursal)
        {
            idSucursal = 0;

            return cmbProveedor.SelectedValue != null &&
                   int.TryParse(cmbProveedor.SelectedValue.ToString(), out int idProveedor) && idProveedor > 0 &&
                   cmbSucursal.SelectedValue != null &&
                   int.TryParse(cmbSucursal.SelectedValue.ToString(), out idSucursal) && idSucursal > 0;
        }
        private bool ProveedorElegido()
        {
            return cmbProveedor.SelectedValue != null &&
                   int.TryParse(cmbProveedor.SelectedValue.ToString(), out int idProveedor) && idProveedor > 0;
        }
        private void AgregarSucursalALista(int idSucursal)
        {
            tablaProveedores.Rows.Add(idSucursal, cmbProveedor.Text, cmbSucursal.Text);
        }
        private List<int> ObtenerSucursalesDeLista()
        {
            return tablaProveedores.Rows.Cast<DataRow>().Select(fila => Convert.ToInt32(fila["IdSucursal"])).ToList();
        }
        // Deja activos los proveedores de la lista (los nuevos se agregan) y da de baja los que se quitaron.
        private bool GuardarProveedores(int idProducto, List<int> sucursales)
        {
            foreach (int idSucursal in sucursales)
            {
                if (!GuardarRelacionProveedor(idProducto, idSucursal, true))
                    return false;
            }

            foreach (int idSucursal in sucursalesOriginales.Except(sucursales))
            {
                if (!GuardarRelacionProveedor(idProducto, idSucursal, false))
                    return false;
            }

            return true;
        }
        private bool GuardarRelacionProveedor(int idProducto, int idSucursal, bool activo)
        {
            ClsProductoSucursalProveedor relacion = new ClsProductoSucursalProveedor();

            relacion.IdProducto = idProducto;
            relacion.IdSucursal = idSucursal;
            relacion.Activo = activo;

            return logica.ModificarProductoSucursalProveedor(relacion);
        }


        #endregion



        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                {
                    MessageBox.Show(ClsIdioma.T("Complete los campos obligatorios (nombre, marca, unidad de venta y rubro) y revise los valores ingresados."), ClsIdioma.T("Validación"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Los proveedores son opcionales. Si la lista está vacía pero hay uno elegido en los
                // combos, se toma ese, así alcanza con elegirlo cuando el artículo tiene uno solo.
                if (tablaProveedores.Rows.Count == 0 && ProveedorElegido())
                {
                    if (!ObtenerSucursalElegida(out int idSucursalElegida))
                    {
                        MessageBox.Show(ClsIdioma.T("Seleccione una sucursal."));
                        cmbSucursal.Focus();
                        return;
                    }

                    AgregarSucursalALista(idSucursalElegida);
                }

                List<int> sucursales = ObtenerSucursalesDeLista();

                // El lote se guarda por sucursal: se usa la del primer proveedor de la lista.
                int idSucursal = sucursales.Count > 0 ? sucursales[0] : 0;

                if ((chkControlLote.Checked || chkAlertaVencimiento.Checked) && idSucursal == 0)
                {
                    MessageBox.Show(ClsIdioma.T("Para cargar lote o vencimiento agregue al menos un proveedor."));
                    cmbProveedor.Focus();
                    return;
                }

                // Ya validados en ValidarDatos: vacíos quedan en 0 (precio 0 = sin precio cargado).
                DecimalOpcional(txtPrecioVenta, out decimal precioVenta);
                DecimalOpcional(txtStockActual, out decimal stockActual);
                DecimalOpcional(txtStockMinimo, out decimal stockMinimo);
                DecimalOpcional(txtStockMaximo, out decimal stockIdeal);

                ClsProducto producto = new ClsProducto();

                producto.CodigoBarra = txtCodigo.Text.Trim();
                producto.SKU = txtSKU.Text.Trim();
                producto.Nombre = txtNombreProducto.Text.Trim();
                producto.Descripcion = txtDescripcion.Text.Trim();
                producto.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                producto.IdCategoria = Convert.ToInt32(cmbRubro.SelectedValue);
                producto.IdUnidad = Convert.ToInt32(cmbUnidadVenta.SelectedValue);
                producto.IdIVA = chkActivarIva.Checked ? Convert.ToInt32(cmbIva.SelectedValue) : 1;
                producto.PrecioVenta = precioVenta;
                

                if (idProductoModificar != 0)
                {
                    producto.IdProducto = idProductoModificar;

                    bool modificado = logica.ModificarProducto(producto);

                    if (!modificado)
                    {
                        MessageBox.Show(ClsIdioma.T("No se pudo modificar el artículo."), ClsIdioma.T("Modificar artículo"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool stockModificado = logica.ModificarStock(idProductoModificar, stockActual, stockMinimo, stockIdeal);

                    if (!stockModificado)
                    {
                        MessageBox.Show(ClsIdioma.T("El artículo se modificó, pero no se pudo actualizar el stock."), ClsIdioma.T("Modificar artículo"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!GuardarProveedores(idProductoModificar, sucursales))
                    {
                        MessageBox.Show(ClsIdioma.T("El artículo y el stock se actualizaron, pero no se pudieron guardar los proveedores."), ClsIdioma.T("Modificar artículo"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (chkControlLote.Checked || chkAlertaVencimiento.Checked)
                    {
                        ClsLote lote = new ClsLote();

                        lote.IdProducto = idProductoModificar;
                        lote.CodigoLote = txtCodigoPorLote.Text.Trim();
                        lote.FechaFabricacion = dtpFechaFabricacion.Value.Date;
                        lote.FechaVencimiento = dtpFechaVencimiento.Value.Date;
                        lote.IdSucursal = idSucursal;
                        lote.Stock = 0;
                        lote.Activo = true;
                        lote.DiasAlertaVencimiento = ObtenerDiasAlertaVencimiento();

                        bool loteModificado = logica.ModificarLote(lote);

                        if (!loteModificado)
                        {
                            MessageBox.Show(ClsIdioma.T("El artículo, el stock y la sucursal se actualizaron, pero no se pudo modificar el lote."), ClsIdioma.T("Modificar artículo"),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    MessageBox.Show(ClsIdioma.T("Artículo modificado correctamente."), ClsIdioma.T("Modificar artículo"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                int idProducto = logica.RegistrarProducto(producto);

                if (idProducto <= 0)
                {
                    MessageBox.Show(ClsIdioma.T("No se pudo registrar el artículo."), ClsIdioma.T("Nuevo artículo"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                logica.RegistrarStock(idProducto, stockActual, stockMinimo, stockIdeal);

                if (!GuardarProveedores(idProducto, sucursales))
                {
                    MessageBox.Show(ClsIdioma.T("El artículo se registró, pero no se pudieron guardar los proveedores."), ClsIdioma.T("Nuevo artículo"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (chkAlertaVencimiento.Checked || chkControlLote.Checked)
                {
                    ClsLote lote = new ClsLote();

                    lote.IdProducto = idProducto;
                    lote.CodigoLote = txtCodigoPorLote.Text.Trim();
                    lote.FechaFabricacion = dtpFechaFabricacion.Value.Date;
                    lote.FechaVencimiento = dtpFechaVencimiento.Value.Date;
                    lote.FechaIngreso = DateTime.Now;
                    lote.Stock = 0;
                    lote.Activo = true;
                    lote.IdSucursal = idSucursal;
                    lote.DiasAlertaVencimiento = ObtenerDiasAlertaVencimiento();

                    bool loteRegistrado = logica.RegistrarLote(lote);

                    if (!loteRegistrado)
                    {
                        MessageBox.Show(ClsIdioma.T("El artículo se registró, pero no se pudo registrar el lote."), ClsIdioma.T("Nuevo artículo"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                MessageBox.Show(ClsIdioma.T("Artículo registrado correctamente."), ClsIdioma.T("Nuevo artículo"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            catch (Exception ex)
            {
                string errorRegistro = null;

                try
                {
                    this.logicaBitacora.RegistrarError(null, "frmNuevoArticulo.btnGuardar_Click", ex.GetType().FullName, ex.Message,ex.ToString());
                }
                catch (Exception exRegistro)
                {
                    errorRegistro = exRegistro.Message;
                }

                string mensaje = ClsIdioma.T("Ocurrió un error al guardar el artículo.\n\n") + ex.Message;

                if (errorRegistro != null)
                {
                    mensaje += ClsIdioma.T("\n\nAdemás, no se pudo guardar el error técnico en la bitácora:\n") +
                               errorRegistro;
                }

                MessageBox.Show(mensaje, ClsIdioma.T("Guardar artículo"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtStockActual.ReadOnly = false;

            txtStockMinimo.Enabled = chkControlStock.Checked;
            txtStockMaximo.Enabled = chkControlStock.Checked;
        }
        private int? ObtenerDiasAlertaVencimiento()
        {
            return chkAlertaVencimiento.Checked && int.TryParse(txtAlertaVencimiento.Text, out int dias) && dias >= 0
                ? dias
                : (int?)null;
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

        }
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProveedor.SelectedValue == null)
                    return;

                if (!int.TryParse(cmbProveedor.SelectedValue.ToString(), out int idProveedor))
                    return;

                if (idProveedor == 0)
                {
                    cmbSucursal.DataSource = null;
                    return;
                }

                DataTable tabla = logicaProveedor.ObtenerSucursalesPorProveedor(idProveedor);

                if (tabla == null || tabla.Rows.Count == 0)
                {
                    cmbSucursal.DataSource = null;
                    MessageBox.Show(ClsIdioma.T("El proveedor seleccionado no tiene sucursales activas."));
                    return;
                }

                DataRow fila = tabla.NewRow();
                fila["IdSucursal"] = 0;
                fila["Sucursal"] = ClsIdioma.T("-Seleccione Sucursal-");
                tabla.Rows.InsertAt(fila, 0);

                cmbSucursal.DataSource = tabla;
                cmbSucursal.DisplayMember = "Sucursal";
                cmbSucursal.ValueMember = "IdSucursal";
                cmbSucursal.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                try
                {
                    logicaBitacora.RegistrarError(null, "frmNuevoArticulo.cmbProveedor_SelectedIndexChanged", ex.GetType().FullName, ex.Message, ex.ToString());
                }
                catch (Exception exRegistro)
                {
                    System.Diagnostics.Debug.WriteLine(exRegistro.ToString());
                }

                MessageBox.Show(ClsIdioma.T("Ocurrió un error al cargar las sucursales del proveedor.\n\n") + ex.Message,ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (!ObtenerSucursalElegida(out int idSucursal))
            {
                MessageBox.Show(ClsIdioma.T("Seleccione el proveedor y la sucursal."), ClsIdioma.T("Proveedores"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProveedor.Focus();
                return;
            }

            if (ObtenerSucursalesDeLista().Contains(idSucursal))
            {
                MessageBox.Show(ClsIdioma.T("Ese proveedor y sucursal ya están en la lista."), ClsIdioma.T("Proveedores"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AgregarSucursalALista(idSucursal);
        }
        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow?.DataBoundItem is not DataRowView fila)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un proveedor de la lista."), ClsIdioma.T("Proveedores"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tablaProveedores.Rows.Remove(fila.Row);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion








    }
}
