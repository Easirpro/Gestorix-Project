using CapaEntidades;
using CapaLogica;
using DocumentFormat.OpenXml.Office.Word;
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
using CapaLogica.NegocioLogica;
using System.Data;
namespace CapaVista
{
    public partial class frmmenuPres : Form
    {
        private bool idiomaIngles = false;

        private decimal subtotal = 0.00m;
        private decimal descuentoRecargo = 0.00m;
        private decimal total;

        public frmmenuPres()
        {
            InitializeComponent();
            ActualizarFechaHora();
            //tmrFechaHora.Start();

            dtgPresentacion.ReadOnly = true;
            dtgPresentacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPresentacion.MultiSelect = false;

            dtgPresentacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgPresentacion.AllowUserToResizeColumns = false;
            dtgPresentacion.AllowUserToOrderColumns = false;
            dtgPresentacion.RowHeadersVisible = false;

            this.KeyPreview = true;

            this.Load += frmmenuPres_Load;
            this.Load += FrmPresentacion_Load;
        }
        private void frmmenuPres_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = SesionUsuario.Username;

            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

            txtRol.Text = rol.ObtenerNombreRol(SesionUsuario.IdRol);

            CargarBotones();

            RellenarFilas();
            CalcularYMostrarMontos();
        }

        private void AplicarIdioma()
        {
            // menu principal
            btnArt.Text = idiomaIngles ? "Products" : "Artículos";
            btnVentas.Text = idiomaIngles ? "Sales" : "Ventas";
            btnCompras.Text = idiomaIngles ? "Purchases" : "Compras";
            btnProve.Text = idiomaIngles ? "Suppliers" : "Proveedores";
            toolStripMenuItem1.Text = idiomaIngles ? "Lists" : "Listados";
            btnInformes.Text = idiomaIngles ? "Reports" : "Informes";
            btnCaja.Text = idiomaIngles ? "Cash Register" : "Caja";
            btnIdioma.Text = idiomaIngles ? "Language" : "Idioma";
            btnEmpleado.Text = idiomaIngles ? "Employees" : "Empleado";
            toolStripMenuItem2.Text = idiomaIngles ? "Promotions" : "Promociones";

            // articulos
            cargarArticuloNuevoToolStripMenuItem.Text = idiomaIngles ? "Add New Product" : "Cargar artículo nuevo";
            menuitemAdmistradorarticulos.Text = idiomaIngles ? "Edit Product" : "Modificar artículo";
            menuitemAdministradoarticulos.Text = idiomaIngles ? "Add Category" : "Agregar categoría";
            meniitemReporapida.Text = idiomaIngles ? "Quick Stock Replenishment" : "Reposición rápida de stock";
            cargaRapidaDePreciosToolStripMenuItem.Text = idiomaIngles ? "Quick Price Update" : "Carga rápida de precios";
            cargarDeLasMarcasToolStripMenuItem.Text = idiomaIngles ? "Load Brands" : "Cargar de las marcas";
            menuitemImporexcel.Text = idiomaIngles ? "Import Products from Excel" : "Importar artículos desde Excel";
            menuitemExporexcel.Text = idiomaIngles ? "Export Products to Excel" : "Exportar artículos a Excel";

            // ventas
            menuitemAdministradorventas.Text = idiomaIngles ? "Sales Management" : "Administrador de ventas";
            notaDeCreditoToolStripMenuItem.Text = idiomaIngles ? "Returns" : "Devolución";

            // compras
            menuitemAministradorcompras.Text = idiomaIngles ? "Purchase Management" : "Administrador de compras";

            // proveedores
            administradorDeProveedoresToolStripMenuItem.Text = idiomaIngles ? "Supplier Management" : "Administrador de proveedores";
            cuentaCorrienteDeProveedoresToolStripMenuItem.Text = idiomaIngles ? "Supplier Account" : "Cuenta corriente de proveedores";

            // listados
            listaDePreciosToolStripMenuItem.Text = idiomaIngles ? "Price List" : "Lista de precios";
            listadoDeReposiciónToolStripMenuItem.Text = idiomaIngles ? "Restocking List" : "Listado de reposición";

            // informes
            ventasPorDiaToolStripMenuItem.Text = idiomaIngles ? "Sales by Date" : "Ventas por fecha";
            ventaToolStripMenuItem.Text = idiomaIngles ? "Sales Details by Date" : "Venta con detalle de fecha";
            ventaPorRubroToolStripMenuItem.Text = idiomaIngles ? "Sales by Category" : "Venta por rubro";
            ventaPorArticulosToolStripMenuItem.Text = idiomaIngles ? "Sales by Product" : "Venta por artículos";
            ventaPorMedioDePagoToolStripMenuItem.Text = idiomaIngles ? "Sales by Payment Method" : "Venta por medio de pago";
            ajustesToolStripMenuItem.Text = idiomaIngles ? "Settings" : "Ajustes";

            // caja
            nuevoIngresoToolStripMenuItem.Text = idiomaIngles ? "New Deposit" : "Nuevo ingreso";
            nuevoEgresoToolStripMenuItem.Text = idiomaIngles ? "New Withdrawal" : "Nuevo egreso";
            cerrarSeToolStripMenuItem.Text = idiomaIngles ? "Close Cash Register" : "Cerrar caja";
            abrirCajaToolStripMenuItem.Text = idiomaIngles ? "Open Cash Register" : "Abrir caja";

            // idioma
            idiomaToolStripMenuItem.Text = idiomaIngles ? "Language" : "Idioma";
            inglesToolStripMenuItem.Text = idiomaIngles ? "Ingles" : "English";

            // empleados
            permisosToolStripMenuItem.Text = idiomaIngles ? "Employees" : "Empleado";
            gestioToolStripMenuItem.Text = idiomaIngles ? "Backup Management" : "Gestión de Backup";
            bitacoraToolStripMenuItem.Text = idiomaIngles ? "Activity Log" : "Bitácora";

            // promociones
            administrarPromocionesToolStripMenuItem.Text = idiomaIngles ? "Manage Promotions" : "Administrar promociones";
            btnPromocion.Text = idiomaIngles ? "Promotions" : "Promociones";

            // botones de vernta
            btnCobrar.Text = idiomaIngles ? "F2 - Pay" : "F2 - Cobrar";
            btnNuevaCompra.Text = idiomaIngles ? "F4 - New Purchase" : "F4 - Nueva Compra";
            btnVerPrecio.Text = idiomaIngles ? "F5 - View Price" : "F5 - Ver Precio";
            btnCambiarcantidad.Text = idiomaIngles ? "Change Quantity" : "Cambiar cantidad";
            btnBuscarArticulo.Text = idiomaIngles ? "Search Product" : "Buscar artículo";
            btnQuitar.Text = idiomaIngles ? "Remove" : "Quitar";
            btnDescuento.Text = idiomaIngles ? "Discount" : "Descuento";
            btnRecargo.Text = idiomaIngles ? "Surcharge" : "Recargo";

            // etiqueta de productos
            label3.Text = idiomaIngles ? "Barcode" : "Código de barras";
            label4.Text = idiomaIngles ? "Quantity" : "Cantidad";

            // totales
            label1.Text = idiomaIngles ? "Subtotal" : "Subtotal";
            label2.Text = idiomaIngles ? "Discount/Surcharge" : "Descuento/Recargo";
            label5.Text = idiomaIngles ? "Total" : "Total";

            // datos del usuario
            label6.Text = idiomaIngles ? "User:" : "Usuario:";
            label7.Text = idiomaIngles ? "Role:" : "Rol:";
            lblFecha.Text = idiomaIngles ? "Date:" : "Fecha:";
            lblHora.Text = idiomaIngles ? "Time:" : "Hora:";

            // columna de las tablas
            ClnSKU.HeaderText = "SKU";
            ClnIdProducto.HeaderText = idiomaIngles ? "Product ID" : "IdProducto";
            ClnCodigo.HeaderText = idiomaIngles ? "Code" : "Código";
            ClnDescripcion.HeaderText = idiomaIngles ? "Description" : "Descripción";
            ClnCantidad.HeaderText = idiomaIngles ? "Quantity" : "Cantidad";
            ClnPrecioUnitario.HeaderText = idiomaIngles ? "Unit Price" : "Precio Unitario";
            ClnImporte.HeaderText = idiomaIngles ? "Amount" : "Importe";

            // Tabla de importes
            label1.Text = idiomaIngles ? "Subtotal" : "Subtotal";
            label2.Text = idiomaIngles ? "Discount/Surcharge" : "Descuento/Recargo";
            label5.Text = idiomaIngles ? "Total" : "Total";

            // fromulario
            this.Text = idiomaIngles ? "Sales Terminal" : "Presentación";
        }

        #region Metodo
        private void CargarBotones()
        {
            //Articulo
            btnArt.Enabled = SesionUsuario.Permisos.Contains(100) || SesionUsuario.Permisos.Contains(110) ||
                SesionUsuario.Permisos.Contains(111) || SesionUsuario.Permisos.Contains(112) || SesionUsuario.Permisos.Contains(113) ||
                SesionUsuario.Permisos.Contains(120) || SesionUsuario.Permisos.Contains(121) || SesionUsuario.Permisos.Contains(122) ||
                SesionUsuario.Permisos.Contains(130) || SesionUsuario.Permisos.Contains(131) || SesionUsuario.Permisos.Contains(132) ||
                SesionUsuario.Permisos.Contains(140) || SesionUsuario.Permisos.Contains(150);

            //Ventas
            btnVentas.Enabled = SesionUsuario.Permisos.Contains(200) || SesionUsuario.Permisos.Contains(210) || SesionUsuario.Permisos.Contains(220) ||
                SesionUsuario.Permisos.Contains(221) || SesionUsuario.Permisos.Contains(222) ||
                SesionUsuario.Permisos.Contains(230) || SesionUsuario.Permisos.Contains(240);

            //Compras
            btnCompras.Enabled = SesionUsuario.Permisos.Contains(300);

            //Proveedores
            btnProve.Enabled = SesionUsuario.Permisos.Contains(400) ||
                SesionUsuario.Permisos.Contains(410) || SesionUsuario.Permisos.Contains(411) ||
                SesionUsuario.Permisos.Contains(412) || SesionUsuario.Permisos.Contains(420);

            //Listados
            toolStripMenuItem1.Enabled = SesionUsuario.Permisos.Contains(500) ||
                SesionUsuario.Permisos.Contains(510) || SesionUsuario.Permisos.Contains(520);

            //Informes
            btnInformes.Enabled = SesionUsuario.Permisos.Contains(600) || SesionUsuario.Permisos.Contains(610) || SesionUsuario.Permisos.Contains(620) ||
                SesionUsuario.Permisos.Contains(630) || SesionUsuario.Permisos.Contains(640) || SesionUsuario.Permisos.Contains(650);

            //Caja
            btnCaja.Enabled = SesionUsuario.Permisos.Contains(700) || SesionUsuario.Permisos.Contains(710) ||
                SesionUsuario.Permisos.Contains(720) || SesionUsuario.Permisos.Contains(730) || SesionUsuario.Permisos.Contains(740);

            //Ajustes
            btnIdioma.Enabled = SesionUsuario.Permisos.Contains(800);

            //Empleado
            btnEmpleado.Enabled = SesionUsuario.Permisos.Contains(1000) || SesionUsuario.Permisos.Contains(1010) || SesionUsuario.Permisos.Contains(1020) ||
                SesionUsuario.Permisos.Contains(1030) || SesionUsuario.Permisos.Contains(1270);

            //Listados
            listaDePreciosToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(510);
            listadoDeReposiciónToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(520);

            //Articulos operaciones

            // Gestión de Articulos
            menuitemAdmistradorarticulos.Enabled = SesionUsuario.Permisos.Contains(110) || SesionUsuario.Permisos.Contains(111) ||
                SesionUsuario.Permisos.Contains(112) || SesionUsuario.Permisos.Contains(113);
            // Gestión de Rubros
            menuitemAdministradoarticulos.Enabled = SesionUsuario.Permisos.Contains(120) ||
                SesionUsuario.Permisos.Contains(121) || SesionUsuario.Permisos.Contains(122);
            // Reposicion rapida de stock
            meniitemReporapida.Enabled = SesionUsuario.Permisos.Contains(113);
            // Gestión de Marcas
            cargarDeLasMarcasToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(130) ||
                SesionUsuario.Permisos.Contains(131) || SesionUsuario.Permisos.Contains(132);
            // Importar articulos desde Excel
            menuitemImporexcel.Enabled = SesionUsuario.Permisos.Contains(140);
            // Exportar articulos a Excel
            menuitemExporexcel.Enabled = SesionUsuario.Permisos.Contains(150);

            //Ventas

            // Realizar ventas
            menuitemAdministradorventas.Enabled = SesionUsuario.Permisos.Contains(210);
            // Devoluciones
            notaDeCreditoToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(220) ||
                SesionUsuario.Permisos.Contains(221) || SesionUsuario.Permisos.Contains(222);

            //Proveedores

            // Gestión de proveedores
            administradorDeProveedoresToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(410) ||
                SesionUsuario.Permisos.Contains(411) || SesionUsuario.Permisos.Contains(412);
            // Cuenta corriente
            cuentaCorrienteDeProveedoresToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(420);
            //Informe operaciones
            ventasPorDiaToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(610);
            ventaToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(620);
            ventaPorRubroToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(630);
            ventaPorArticulosToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(640);
            ventaPorMedioDePagoToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(650);
            //Caja operaciones
            nuevoIngresoToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(710);
            nuevoEgresoToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(720);
            abrirCajaToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(730);
            cerrarSeToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(740);

            permisosToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(1270);
        }
        //Ingreso de plata
        public enum TipoMovimiento
        {
            Ingreso,
            Egreso
        }
        public enum TipoInforme
        {
            VentasPorFecha,
            VentasConDetallePorFecha,
            VentasPorRubro,
            VentasPorArticulo,
            VentaPorMedioPago
        }
        //bloqueo menu
        private void BloquearMenu()
        {
            // Menu superior
            btnArt.Enabled = false;
            btnVentas.Enabled = false;
            btnCompras.Enabled = false;
            btnProve.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            btnInformes.Enabled = false;
            btnIdioma.Enabled = false;
            btnEmpleado.Enabled = false;

            // Caja queda disponible
            btnCaja.Enabled = true;

            nuevoIngresoToolStripMenuItem.Enabled = false;
            nuevoEgresoToolStripMenuItem.Enabled = false;
            cerrarSeToolStripMenuItem.Enabled = false;
            abrirCajaToolStripMenuItem.Enabled = true;

            // Botones del formulario
            btnCambiarcantidad.Enabled = false;
            btnRecargo.Enabled = false;
            btnDescuento.Enabled = false;
            btnQuitar.Enabled = false;
            btnCobrar.Enabled = false;
            btnNuevaCompra.Enabled = false;
            btnVerPrecio.Enabled = false;
            btnBuscarArticulo.Enabled = false;
            btnPromocion.Enabled = false;

            // Entrada de datos
            txtCodigoBarra.Enabled = false;
            txtCantidad.Enabled = false;
            dtgPresentacion.Enabled = false;

            txtUsuario.Text = "";
            txtRol.Text = "";
        }
        private void AgregarProductoAGrilla(int idProducto, string sku, string codigoBarra, string descripcion, decimal precio, decimal cantidad, decimal stockDisponible)
        {
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Cantidad inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.", "Precio inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal cantidadYaCargada = 0m;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    continue;

                if (Convert.ToInt32(fila.Cells["ClnIdProducto"].Value) == idProducto)
                {
                    cantidadYaCargada += Convert.ToDecimal(fila.Cells["ClnCantidad"].Value);
                }
            }

            if (stockDisponible <= 0 || cantidadYaCargada + cantidad > stockDisponible)
            {
                MessageBox.Show($"Stock insuficiente.\nStock disponible: {stockDisponible}\n" + $"Cantidad ya cargada: {cantidadYaCargada}\n" +
                    $"Cantidad a agregar: {cantidad}", "Stock insuficiente",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaDestino = null;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnIdProducto"].Value == null || string.IsNullOrWhiteSpace(Convert.ToString(fila.Cells["ClnIdProducto"].Value)))
                {
                    filaDestino = fila;
                    break;
                }
            }

            if (filaDestino == null)
            {
                int indice = dtgPresentacion.Rows.Add();
                filaDestino = dtgPresentacion.Rows[indice];
            }

            filaDestino.Cells["ClnIdProducto"].Value = idProducto;
            filaDestino.Cells["ClnSKU"].Value = sku;
            filaDestino.Cells["ClnCodigo"].Value = codigoBarra;
            filaDestino.Cells["ClnDescripcion"].Value = descripcion;
            filaDestino.Cells["ClnCantidad"].Value = cantidad;
            filaDestino.Cells["ClnPrecioUnitario"].Value = precio;
            filaDestino.Cells["ClnImporte"].Value = Math.Round(cantidad * precio, 2);

            CalcularYMostrarMontos();
            dtgPresentacion.Refresh();
        }
        private void IngresarProductoPorCodigo()
        {
            string codigoBarra = txtCodigoBarra.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigoBarra))
            {
                txtCodigoBarra.Focus();
                return;
            }

            decimal cantidad = 1;

            if (!string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                if (!decimal.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Cantidad inválida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }
            }

            ClsLogicaProducto logicaProducto = new ClsLogicaProducto();

            DataTable tablaProducto = logicaProducto.ObtenerProductoPorCodigoBarra(codigoBarra);

            if (tablaProducto.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró un producto con ese código de barras.", "Producto no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigoBarra.SelectAll();
                txtCodigoBarra.Focus();
                return;
            }

            DataRow producto = tablaProducto.Rows[0];

            int idProducto = Convert.ToInt32(producto["IdProducto"]);
            string sku = producto["SKU"].ToString();
            string codigo = producto["CodigoBarra"].ToString();
            string descripcion = producto["Descripcion"].ToString();
            decimal precio = Convert.ToDecimal(producto["PrecioVenta"]);

            decimal stockDisponible = producto["CantidadActual"] == DBNull.Value ? 0 : Convert.ToDecimal(producto["CantidadActual"]);

            AgregarProductoAGrilla(idProducto, sku, codigo, descripcion, precio, cantidad, stockDisponible);

            txtCodigoBarra.Clear();
            txtCantidad.Clear();

            txtCodigoBarra.Focus();
        }
        private void tmrFechaHora_Tick(object sender, EventArgs e)
        {
            ActualizarFechaHora();
        }
        private void ActualizarFechaHora()
        {
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            lblHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
        }


        #endregion

        #region Eventos

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                IngresarProductoPorCodigo();
            }
        }
        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                IngresarProductoPorCodigo();
            }
        }
        //Menu Item

        //Importar y Exportar
        private void menuitemImporexcel_Click(object sender, EventArgs e)
        {
            frmImportarArticulos frmImportar = new frmImportarArticulos();
            frmImportar.ShowDialog();
        }
        private void menuitemExporexcel_Click(object sender, EventArgs e)
        {
            frmExportarArchivos exportararchivos = new frmExportarArchivos();
            exportararchivos.ShowDialog();
        }
        private void cuentaCorrienteDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCuentaCorrienteProveedores cuentacorr = new frmCuentaCorrienteProveedores();
            cuentacorr.ShowDialog();
        }
        //Informes
        private void ventasPorDiaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmVentaFecha ventaFecha = new frmVentaFecha(TipoInforme.VentasPorFecha);
            ventaFecha.ShowDialog();
        }
        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentaFecha ventaFecha = new frmVentaFecha(TipoInforme.VentasConDetallePorFecha);
            ventaFecha.ShowDialog();
        }
        private void ventaPorRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentaFecha ventaRubro = new frmVentaFecha(TipoInforme.VentasPorRubro);
            ventaRubro.ShowDialog();
        }
        private void ventaPorArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentaFecha ventaArticulo = new frmVentaFecha(TipoInforme.VentasPorArticulo);
            ventaArticulo.ShowDialog();
        }
        private void ventaPorMedioDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentaFecha ventraPago = new frmVentaFecha(TipoInforme.VentaPorMedioPago);
            ventraPago.ShowDialog();
        }
        //Caja
        private void nuevoIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngresoPlataCaja ingresoPlata = new frmIngresoPlataCaja(TipoMovimiento.Ingreso);

            ingresoPlata.ShowDialog();
        }
        private void nuevoEgresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngresoPlataCaja egresoPlata = new frmIngresoPlataCaja(TipoMovimiento.Egreso);

            egresoPlata.ShowDialog();
        }
        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoPrecios listaprecio = new frmListadoPrecios();
            listaprecio.ShowDialog();
        }
        private void listadoDeReposiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoReposicion listarepo = new frmListadoReposicion();
            listarepo.ShowDialog();
        }
        private void menuitemAministradorcompras_Click(object sender, EventArgs e)
        {
            frmCompras compra = new frmCompras();
            compra.ShowDialog();
        }
        private void menuitemAdmistradorarticulos_Click(object sender, EventArgs e)
        {
            frmCargaarticulo cargaarticulo = new frmCargaarticulo();
            cargaarticulo.ShowDialog();
        }
        private void meniitemReporapida_Click(object sender, EventArgs e)
        {
            frmReporapida reporapida = new frmReporapida();
            reporapida.ShowDialog();
        }
        private void menuitemAdministradorventas_Click(object sender, EventArgs e)
        {
            frmVentas ventas = new frmVentas();
            ventas.Show();

        }
        private void notaDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDevolucion devolucion = new frmDevolucion();
            devolucion.ShowDialog();
        }
        private void administradorDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            proveedores.ShowDialog();
        }
        //Cerrar sesion
        private void cerrarSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Estas seguro de cerrar la sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                ClsLogin login = new ClsLogin();
                login.CerrarSesion();

                BloquearMenu();

            }
        }
        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SesionUsuario.SesionActiva)
            {
                MessageBox.Show(
                    "Ya hay una sesión abierta. Debe cerrar la sesión actual antes de iniciar otra.",
                    "Sesión abierta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            FrmLogin login = Application.OpenForms.OfType<FrmLogin>().FirstOrDefault();

            if (login != null)
            {
                login.LimpiarCampos();
            }

            this.Close();
        }
        private void tollClosed_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Estas seguro de cerrar la sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
        private void CalcularYMostrarMontos()
        {
            decimal nuevoSubtotal = 0m;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    continue;

                object valorImporte = fila.Cells["ClnImporte"].Value;

                if (valorImporte != null && valorImporte != DBNull.Value && decimal.TryParse(Convert.ToString(valorImporte), out decimal importe))
                {
                    nuevoSubtotal += importe;
                }
            }

            subtotal = Math.Round(nuevoSubtotal, 2);
            total = Math.Max(0m, Math.Round(subtotal + descuentoRecargo, 2));

            lblSubtotalMonto.Text = subtotal.ToString("C2");
            lblDescuentoMonto.Text = Math.Abs(descuentoRecargo).ToString("C2");

            lblTotalMonto.Visible = true;
            lblTotalMonto.AutoSize = false;
            lblTotalMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTotalMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblTotalMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);

            lblTotalMonto.Text = total.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("es-AR"));
        }
        private void btnConfig_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargaEmpleados Carga = new frmCargaEmpleados();
            Carga.ShowDialog();
        }
        private void btnNuevaCompra_Click(object sender, EventArgs e)

        {
            btnNuevaCompra.Enabled = false;
            frmCobroSecundario secundario = new frmCobroSecundario();

            secundario.FormClosed += (s, arg) =>
            {
                btnNuevaCompra.Enabled = true;
            };

            secundario.Show();

        }
        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            using (frmBuscarArticulo buscarArticulo = new frmBuscarArticulo())
            {
                buscarArticulo.ShowDialog();

                ClsProducto producto = buscarArticulo.ProductoSeleccionado;

                if (producto == null)
                {
                    MessageBox.Show("No se recibió ningún producto seleccionado. " + "Revisá el botón de selección de frmBuscarArticulo.", "Producto no seleccionado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClsLogicaProducto logicaProducto = new ClsLogicaProducto();

                DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(producto.IdProducto);

                decimal stockDisponible = 0m;

                if (tablaStock != null && tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                {
                    stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                }

                AgregarProductoAGrilla(producto.IdProducto, producto.SKU, producto.CodigoBarra, producto.Descripcion, producto.PrecioVenta, 1m, stockDisponible);

                txtCodigoBarra.Focus();
            }
        }
        private void btnCobrar_Click_1(object sender, EventArgs e)
        {
            if (total <= 0)
            {
                MessageBox.Show("Debe agregar al menos un producto para realizar el cobro.", "Cobrar venta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigoBarra.Focus();
                return;
            }

            frmInformeCobro cobro = new frmInformeCobro(total, dtgPresentacion);

            if (cobro.ShowDialog() == DialogResult.OK)
            {
                LimpiarVenta();
            }
        }
        private void LimpiarVenta()
        {
            dtgPresentacion.Rows.Clear();

            subtotal = 0.00m;
            descuentoRecargo = 0.00m;
            total = 0.00m;

            CalcularYMostrarMontos();
            RellenarFilas();

            txtCodigoBarra.Clear();
            txtCodigoBarra.Focus();
        }
        private void RellenarFilas()
        {
            int filasVisibles = dtgPresentacion.Height / dtgPresentacion.RowTemplate.Height;
            while (dtgPresentacion.Rows.Count < filasVisibles)
            {
                dtgPresentacion.Rows.Add();
            }
        }
        private void menuitemAdministradoarticulos_Click(object sender, EventArgs e)
        {
            frmBuscarRubro buscarRubro = new frmBuscarRubro();
            buscarRubro.ShowDialog();
        }
        private void btnPromocion_Click(object sender, EventArgs e)
        {
            using (frmBuscarPromo buscarPromo = new frmBuscarPromo())
            {
                if (buscarPromo.ShowDialog() != DialogResult.OK)
                    return;

                int idPromocion = buscarPromo.IdPromocionSeleccionada;

                try
                {
                    ClsPromocionLogica logicaPromo = new ClsPromocionLogica();
                    ClsLogicaProducto logicaProducto = new ClsLogicaProducto();

                    DataSet datos = logicaPromo.ObtenerPromocionPorId(idPromocion);

                    if (datos == null || datos.Tables.Count < 2 || datos.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron los datos de la promoción.");
                        return;
                    }

                    DataRow promo = datos.Tables[0].Rows[0];

                    if (promo["Activo"] == DBNull.Value || !Convert.ToBoolean(promo["Activo"]))
                    {
                        MessageBox.Show("La promoción seleccionada está inactiva.");
                        return;
                    }

                    DataTable detalles = datos.Tables[1];

                    if (detalles.Rows.Count == 0)
                    {
                        MessageBox.Show("La promoción no tiene productos asociados.");
                        return;
                    }

                    int idTipoPromocion = Convert.ToInt32(promo["IdTipoPromocion"]);
                    decimal valor = Convert.ToDecimal(promo["Valor"]);

                    DataTable tipos = logicaPromo.ObtenerTiposPromocion();

                    DataRow[] tiposEncontrados = tipos.Select("IdTipoPromocion = " + idTipoPromocion);

                    if (tiposEncontrados.Length == 0)
                    {
                        MessageBox.Show("No se encontró el tipo de promoción.");
                        return;
                    }

                    DataRow tipoPromocion = tiposEncontrados[0];

                    bool esVolumen = tipoPromocion["CantidadLleva"] != DBNull.Value && tipoPromocion["CantidadPaga"] != DBNull.Value;

                    int cantidadLleva = 0;
                    int cantidadPaga = 0;

                    if (esVolumen)
                    {
                        cantidadLleva = Convert.ToInt32(tipoPromocion["CantidadLleva"]);
                        cantidadPaga = Convert.ToInt32(tipoPromocion["CantidadPaga"]);

                        if (cantidadLleva <= 0 || cantidadPaga <= 0 ||
                            cantidadPaga >= cantidadLleva)
                        {
                            MessageBox.Show("La mecánica de volumen no es válida.");
                            return;
                        }
                    }
                    else if (idTipoPromocion == 4)
                    {
                        if (valor <= 0 || valor > 100)
                        {
                            MessageBox.Show("El porcentaje de descuento no es válido.");
                            return;
                        }
                    }
                    else if (idTipoPromocion == 5)
                    {
                        if (valor <= 0)
                        {
                            MessageBox.Show("El precio especial no es válido.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El tipo de promoción no es válido.");
                        return;
                    }

                    decimal precioFinal = 0m;

                    foreach (DataRow detalle in detalles.Rows)
                    {
                        decimal cantidadConfigurada = Convert.ToDecimal(detalle["Cantidad"]);
                        decimal precioUnitario = Convert.ToDecimal(detalle["PrecioVenta"]);

                        if (cantidadConfigurada <= 0 || precioUnitario < 0)
                        {
                            MessageBox.Show("La cantidad o el precio de un producto no son válidos.");
                            return;
                        }

                        if (esVolumen)
                        {
                            precioFinal += cantidadConfigurada * cantidadPaga * precioUnitario;
                        }
                        else if (idTipoPromocion == 4)
                        {
                            precioFinal += cantidadConfigurada * precioUnitario * (1m - valor / 100m);
                        }
                        else if (idTipoPromocion == 5)
                        {
                            precioFinal += cantidadConfigurada * valor;
                        }
                    }

                    precioFinal = Math.Round(precioFinal, 2);

                    foreach (DataRow detalle in detalles.Rows)
                    {
                        int idProducto = Convert.ToInt32(detalle["IdProducto"]);
                        decimal cantidadConfigurada = Convert.ToDecimal(detalle["Cantidad"]);
                        decimal cantidadAgregar = esVolumen ? cantidadConfigurada * cantidadLleva : cantidadConfigurada;

                        DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

                        decimal stockDisponible = 0m;

                        if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                        {
                            stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                        }

                        if (cantidadAgregar > stockDisponible)
                        {
                            MessageBox.Show("Stock insuficiente para el producto: " + detalle["NombreProducto"].ToString(), "Promociones",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    decimal subtotalAnterior = subtotal;
                    decimal ajusteAnterior = descuentoRecargo;

                    foreach (DataRow detalle in detalles.Rows)
                    {
                        int idProducto = Convert.ToInt32(detalle["IdProducto"]);
                        string sku = detalle["SKU"].ToString();
                        string codigoPromocion = promo["CodigoPromocion"].ToString();
                        decimal precio = Convert.ToDecimal(detalle["PrecioVenta"]);
                        decimal cantidadConfigurada = Convert.ToDecimal(detalle["Cantidad"]);
                        decimal cantidad = esVolumen ? cantidadConfigurada * cantidadLleva : cantidadConfigurada;

                        DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

                        decimal stockDisponible = 0m;

                        if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                        {
                            stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                        }

                        AgregarProductoAGrilla(idProducto, sku, codigoPromocion, detalle["NombreProducto"].ToString(), precio, cantidad, stockDisponible);
                    }

                    decimal importeNormalAgregado = subtotal - subtotalAnterior;
                    decimal descuentoPromocion = importeNormalAgregado - precioFinal;

                    descuentoRecargo = ajusteAnterior - descuentoPromocion;

                    CalcularYMostrarMontos();

                    txtCodigoBarra.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la promoción: " + ex.Message, "Promociones",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cargarDeLasMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarMarca marca = new frmBuscarMarca();
            marca.ShowDialog();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void btnCambiarcantidad_Click(object sender, EventArgs e)
        {
            if (dtgPresentacion.CurrentRow == null || dtgPresentacion.CurrentRow.Cells["ClnIdProducto"].Value == null)
            {
                MessageBox.Show("Seleccione un producto para cambiar la cantidad.", "Cambiar cantidad",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dtgPresentacion.CurrentRow;

            int idProducto = Convert.ToInt32(fila.Cells["ClnIdProducto"].Value);
            decimal cantidadActual = Convert.ToDecimal(fila.Cells["ClnCantidad"].Value);
            string entrada = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nueva cantidad:", "Cambiar cantidad", cantidadActual.ToString());

            if (string.IsNullOrWhiteSpace(entrada))
            {
                return;
            }

            if (!decimal.TryParse(entrada, out decimal nuevaCantidad) || nuevaCantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Cantidad inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            ClsLogicaProducto logicaProducto = new ClsLogicaProducto();

            DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

            decimal stockDisponible = 0;

            if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
            {
                stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
            }

            if (nuevaCantidad > stockDisponible)
            {
                MessageBox.Show($"Stock insuficiente.\n\n" + $"Stock disponible: {stockDisponible}\n" + $"Cantidad solicitada: {nuevaCantidad}",
                    "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            decimal precioUnitario = Convert.ToDecimal(fila.Cells["ClnPrecioUnitario"].Value);

            fila.Cells["ClnCantidad"].Value = nuevaCantidad;
            fila.Cells["ClnImporte"].Value = nuevaCantidad * precioUnitario;

            CalcularYMostrarMontos();

            txtCodigoBarra.Focus();
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgPresentacion.CurrentRow == null || dtgPresentacion.CurrentRow.Cells["ClnIdProducto"].Value == null)
            {
                MessageBox.Show("Seleccione un producto para quitar.", "Quitar producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dtgPresentacion.CurrentRow;

            foreach (DataGridViewCell celda in fila.Cells)
            {
                celda.Value = null;
            }

            CalcularYMostrarMontos();

            txtCodigoBarra.Focus();
        }
        private void cargaRapidaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargaRapidaPrecios formulario = new frmCargaRapidaPrecios();

            formulario.ShowDialog();
        }
        private void administrarPromocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPromocion promo = new frmPromocion();
            promo.ShowDialog();
        }

        private void gestioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionBackup frm = new frmGestionBackup();
            frm.ShowDialog();
        }
        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            // backup automatico

            try
            {
                ClsBackupLogica backup = new ClsBackupLogica();
                backup.BackupAutomatico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarArticuloNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoArticulo nuevoarticulo = new frmNuevoArticulo();
            nuevoarticulo.ShowDialog();

        }

        //idioma
        private void btnIdioma_Click(object sender, EventArgs e)
        {

        }
        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idiomaIngles = false;
            AplicarIdioma();
        }
        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idiomaIngles = true;
            AplicarIdioma();
        }

        //bitacora
        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacora bitacora = new frmBitacora();
            bitacora.ShowDialog();
        }
        #endregion




























    }

}
