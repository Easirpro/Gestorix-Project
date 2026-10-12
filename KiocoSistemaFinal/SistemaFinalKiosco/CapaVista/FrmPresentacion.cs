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
        public int IdRol { get; set; }

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
        }
        private void frmmenuPres_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = SesionUsuario.Username;

            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

            txtRol.Text = rol.ObtenerNombreRol(SesionUsuario.IdRol);

            CargarBotones();

            RellenarFilas();
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
            btnAjuste.Enabled = SesionUsuario.Permisos.Contains(800);

            //Ayuda
            btnAyuda.Enabled = SesionUsuario.Permisos.Contains(900);

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
            btnAjuste.Enabled = false;
            btnAyuda.Enabled = false;
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

            if (stockDisponible <= 0)
            {
                MessageBox.Show("El producto no tiene stock disponible.", "Sin stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Buscar si el producto ya está cargado
            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow)
                {
                    continue;
                }

                if (fila.Cells["ClnIdProducto"].Value != null && Convert.ToInt32(fila.Cells["ClnIdProducto"].Value) == idProducto)
                {
                    decimal cantidadActual = Convert.ToDecimal(fila.Cells["ClnCantidad"].Value);
                    decimal cantidadFinal = cantidadActual + cantidad;

                    if (cantidadFinal > stockDisponible)
                    {
                        MessageBox.Show($"Stock insuficiente.\n\n" + $"Stock disponible: {stockDisponible}\n" + $"Cantidad cargada: {cantidadActual}\n" +
                            $"Cantidad a agregar: {cantidad}\n" + $"Cantidad resultante: {cantidadFinal}",
                            "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    fila.Cells["ClnCantidad"].Value = cantidadFinal;
                    fila.Cells["ClnImporte"].Value = cantidadFinal * precio;

                    CalcularYMostrarMontos();
                    return;
                }
            }

            if (cantidad > stockDisponible)
            {
                MessageBox.Show($"Stock insuficiente.\n\n" + $"Stock disponible: {stockDisponible}\n" +
                    $"Cantidad solicitada: {cantidad}", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            int nuevaFila = -1;

            for (int i = 0; i < dtgPresentacion.Rows.Count; i++)
            {
                if (dtgPresentacion.Rows[i].IsNewRow)
                {
                    continue;
                }


                if (dtgPresentacion.Rows[i].Cells["ClnIdProducto"].Value == null)
                {
                    nuevaFila = i;
                    break;
                }
            }

            if (nuevaFila == -1)
            {
                nuevaFila = dtgPresentacion.Rows.Add();
            }

            dtgPresentacion.Rows[nuevaFila].Cells["ClnIdProducto"].Value = idProducto;
            dtgPresentacion.Rows[nuevaFila].Cells["ClnSKU"].Value = sku;
            dtgPresentacion.Rows[nuevaFila].Cells["ClnCodigo"].Value = codigoBarra;
            dtgPresentacion.Rows[nuevaFila].Cells["ClnDescripcion"].Value = descripcion;
            dtgPresentacion.Rows[nuevaFila].Cells["ClnCantidad"].Value = cantidad;
            dtgPresentacion.Rows[nuevaFila].Cells["ClnPrecioUnitario"].Value = precio;
            dtgPresentacion.Rows[nuevaFila].Cells["ClnImporte"].Value = cantidad * precio;

            CalcularYMostrarMontos();
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
            subtotal = 0.00m;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow)
                {
                    continue;
                }


                if (fila.Cells["ClnImporte"].Value != null && decimal.TryParse(fila.Cells["ClnImporte"].Value.ToString(), out decimal importe))
                {
                    subtotal += importe;
                }
            }

            total = subtotal + descuentoRecargo;

            lblSubtotalMonto.Text = $"$ {subtotal:N2}";
            lblDescuentoMonto.Text = $"$ {descuentoRecargo:N2}";
            lblTotalMonto.Text = $"$ {total:N2}";
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
            frmBuscarArticulo buscarArticulo = new frmBuscarArticulo();

            if (buscarArticulo.ShowDialog() == DialogResult.OK)
            {
                ClsProducto producto = buscarArticulo.ProductoSeleccionado;

                if (producto != null)
                {
                    int fila = -1;

                    for (int i = 0; i < dtgPresentacion.Rows.Count; i++)
                    {
                        if (dtgPresentacion.Rows[i].IsNewRow)
                        {
                            continue;
                        }


                        if (dtgPresentacion.Rows[i].Cells["ClnSKU"].Value == null ||
                            string.IsNullOrWhiteSpace(dtgPresentacion.Rows[i].Cells["ClnSKU"].Value.ToString()))
                        {
                            fila = i;
                            break;
                        }
                    }

                    if (fila == -1)
                    {
                        fila = dtgPresentacion.Rows.Add();
                    }

                    dtgPresentacion.Rows[fila].Cells["ClnIdProducto"].Value = producto.IdProducto;
                    dtgPresentacion.Rows[fila].Cells["ClnSKU"].Value = producto.SKU;
                    dtgPresentacion.Rows[fila].Cells["ClnCodigo"].Value = producto.CodigoBarra;
                    dtgPresentacion.Rows[fila].Cells["ClnDescripcion"].Value = producto.Descripcion;
                    dtgPresentacion.Rows[fila].Cells["ClnCantidad"].Value = 1;
                    dtgPresentacion.Rows[fila].Cells["ClnPrecioUnitario"].Value = producto.PrecioVenta;
                    dtgPresentacion.Rows[fila].Cells["ClnImporte"].Value = producto.PrecioVenta;

                    CalcularYMostrarMontos();
                }
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

                    decimal precioFinal = Convert.ToDecimal(promo["Valor"]);

                    if (precioFinal < 0)
                    {
                        MessageBox.Show("El precio final de la promoción no es válido.");
                        return;
                    }

                    foreach (DataRow detalle in detalles.Rows)
                    {
                        int idProducto = Convert.ToInt32(detalle["IdProducto"]);
                        decimal cantidad = Convert.ToDecimal(detalle["Cantidad"]);

                        DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

                        decimal stockDisponible = 0m;

                        if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                        {
                            stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                        }

                        if (cantidad <= 0 || cantidad > stockDisponible)
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
                        decimal cantidad = Convert.ToDecimal(detalle["Cantidad"]);
                        DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);
                        decimal stockDisponible = 0m;

                        if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                        {
                            stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                        }

                        AgregarProductoAGrilla(idProducto, sku, codigoPromocion, detalle["NombreProducto"].ToString(), precio, cantidad, stockDisponible);
                    }

                    decimal importeNormalAgregado = subtotal - subtotalAnterior;

                    descuentoRecargo = ajusteAnterior + precioFinal - importeNormalAgregado;

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


        #endregion



















    }

}
