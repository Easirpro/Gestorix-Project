using CapaEntidades;
using CapaLogica;
using CapaLogica.NegocioLogica;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Spreadsheet;
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
using CapaEntidades.NegocioEntidad;
using CapaEntidades.NegocioEntidades;

namespace CapaVista
{
    public partial class frmmenuPres : Form
    {

        // El idioma es el de todo el sistema (ClsIdioma): se guarda en esta PC y traduce todos los formularios.
        private bool idiomaIngles => ClsIdioma.Ingles;
        private ClsCampanaAlertas campanaAlertas;
        private decimal subtotal = 0.00m;
        private decimal descuentoRecargo = 0.00m;
        private decimal total;
        private ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();
        private DataTable tablaProductosEncontrados;
        private readonly HashSet<DataGridViewRow> filasDePromocion = new HashSet<DataGridViewRow>();

        private frmCobroSecundario formularioSecundario;

        // [PROMO] Promociones aplicadas en la venta en curso (se guardan al cobrar)
        private readonly List<ClsPromocionVentaEntidad> promocionesAplicadas = new List<ClsPromocionVentaEntidad>();


        public frmmenuPres()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            MinimumSize = new Size(900, 620);
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;

            ActualizarFechaHora();
            tmrFechaHora.Start();

            dtgPresentacion.ReadOnly = true;
            dtgPresentacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPresentacion.MultiSelect = false;
            dtgPresentacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Se puede cambiar el ancho de las columnas arrastrando el borde del encabezado.
            dtgPresentacion.AllowUserToResizeColumns = true;
            dtgPresentacion.AllowUserToResizeRows = false;

            foreach (DataGridViewColumn columna in dtgPresentacion.Columns)
            {
                columna.Resizable = DataGridViewTriState.True;
                columna.MinimumWidth = 50;   // que ninguna columna se pueda achicar hasta desaparecer
            }
            dtgPresentacion.AllowUserToOrderColumns = false;
            dtgPresentacion.RowHeadersVisible = false;

            Load += frmmenuPres_Load;
            Load += FrmPresentacion_Load;

            Resize += (sender, e) => AjustarDiseno();
            Shown += (sender, e) => AjustarDiseno();
        }

        private void frmmenuPres_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = SesionUsuario.Username;

            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

            txtRol.Text = rol.ObtenerNombreRol(SesionUsuario.IdRol);

            txtCantidad.Text = "1";

            this.KeyPreview = true;

            CargarBotones();
            AplicarModoPantalla();

            try
            {
                if (SesionUsuario.Permisos.Contains(730) && !new ClsCajaLogica().HayCajaAbierta())
                {
                    DialogResult abrir = MessageBox.Show(ClsIdioma.T("La caja está cerrada.\n\n¿Desea abrirla ahora?"),
                        ClsIdioma.T("Caja"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (abrir == DialogResult.Yes)
                    {
                        using (frmAbrirCaja apertura = new frmAbrirCaja())
                        {
                            apertura.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo verificar la caja.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            IniciarAlertas();

            RellenarFilas();
            CalcularYMostrarMontos();

            // Si la última vez se eligió inglés en esta PC, el menú principal arranca en inglés.
            if (ClsIdioma.Ingles)
            {
                AplicarIdioma();
            }
        }

        // Quien no tiene el permiso de vender (210) no ve la pantalla de venta: solo el logo al centro
        // con un mensaje de bienvenida. El menú de arriba queda igual, con las opciones de su rol.
        private bool modoBienvenida = false;
        private Label? lblBienvenida;
        private Label? lblBienvenidaAyuda;

        private System.Windows.Forms.Control[] ControlesDeVenta()
        {
            return new System.Windows.Forms.Control[]
            {
                label3, txtCodigoBarra, label4, txtCantidad, lstDescripcion, lblDescripcionSku,
                dtgPresentacion, btnPromocion, btnQuitar, btnCambiarcantidad,
                tableLayoutPanel1, btnCobrar, btnNuevaCompra
            };
        }
        private void AplicarModoPantalla()
        {
            modoBienvenida = !SesionUsuario.Permisos.Contains(210);

            foreach (System.Windows.Forms.Control control in ControlesDeVenta())
            {
                control.Visible = !modoBienvenida;
            }

            // La lista de sugerencias arranca oculta: solo aparece al escribir en el buscador de productos.
            lstDescripcion.Visible = false;

            if (!modoBienvenida)
            {
                if (lblBienvenida != null) lblBienvenida.Visible = false;
                if (lblBienvenidaAyuda != null) lblBienvenidaAyuda.Visible = false;

                AjustarDiseno();
                return;
            }

            string nombre = string.IsNullOrWhiteSpace(SesionUsuario.Nombre) ? SesionUsuario.Username : SesionUsuario.Nombre;

            if (lblBienvenida == null)
            {
                lblBienvenida = new Label
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                    Anchor = AnchorStyles.None
                };

                lblBienvenidaAyuda = new Label
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new System.Drawing.Font("Segoe UI", 10.5F),
                    ForeColor = SystemColors.GrayText,
                    Anchor = AnchorStyles.None
                };

                Controls.Add(lblBienvenida);
                Controls.Add(lblBienvenidaAyuda);
            }

            lblBienvenida.Text = ClsIdioma.Ingles
                ? "Hello, " + nombre + "! Welcome to Gestorix"
                : "¡Hola, " + nombre + "! Te damos la bienvenida a Gestorix";
            lblBienvenidaAyuda!.Text = ClsIdioma.Ingles
                ? "Use the menu above to work with the options of your role."
                : "Usá el menú de arriba para trabajar con las opciones de tu rol.";
            lblBienvenida.Visible = true;
            lblBienvenidaAyuda.Visible = true;

            AjustarDiseno();
        }
        // Logo grande al centro y el mensaje debajo, entre el menú y el pie con el usuario.
        private void UbicarBienvenida(int ancho, int altoMenu, int abajo)
        {
            int margen = 12;
            int disponibleAlto = Math.Max(200, abajo - altoMenu);

            int anchoLogo = Math.Min(520, (int)(ancho * 0.5));
            int altoLogo = anchoLogo * 169 / 270;   // misma proporción que el logo original

            int altoTextos = 40 + 6 + 30;

            if (altoLogo + altoTextos + 20 > disponibleAlto)
            {
                altoLogo = Math.Max(80, disponibleAlto - altoTextos - 20);
                anchoLogo = altoLogo * 270 / 169;
            }

            int yLogo = altoMenu + (disponibleAlto - altoLogo - altoTextos) / 2;

            pcbLogo.SetBounds((ancho - anchoLogo) / 2, yLogo, anchoLogo, altoLogo);
            pcbLogo.Visible = true;

            lblBienvenida?.SetBounds(margen, pcbLogo.Bottom + 10, ancho - margen * 2, 40);
            lblBienvenidaAyuda?.SetBounds(margen, pcbLogo.Bottom + 56, ancho - margen * 2, 30);

            lblBienvenida?.BringToFront();
            lblBienvenidaAyuda?.BringToFront();
        }

        // Campana de alertas arriba a la derecha, al lado de cerrar sesión. Cada tipo de alerta
        // abre la pantalla donde se resuelve, usando las mismas opciones del menú (respetan los permisos).
        private void IniciarAlertas()
        {
            // Sin permiso para visualizar alarmas no se muestra la campana.
            if (!SesionUsuario.Permisos.Contains(1110))
            {
                return;
            }

            campanaAlertas = new ClsCampanaAlertas(this, btnConfig, tollClosed, CrearAccionesAlertas());

            // Quien ve la campana puede abrir la lista completa (cada uno ve solo los tipos que le corresponden).
            campanaAlertas.VerTodas = AbrirAlertas;
            campanaAlertas.PuedeResolver = PuedeResolverAlerta;

            campanaAlertas.Iniciar(mostrarAviso: true);
        }
        // Si el usuario puede entrar a la pantalla donde se resuelve cada tipo de alerta
        // (los mismos permisos que habilitan esas opciones del menú en CargarBotones).
        private bool PuedeResolverAlerta(TipoAlerta tipo)
        {
            switch (tipo)
            {
                case TipoAlerta.Lote:
                case TipoAlerta.Precio:
                    return TieneAlguno(110, 111, 112, 113);         // Modificar artículo
                case TipoAlerta.Stock:
                    return TieneAlguno(520, 110, 111, 112, 113);    // Reposición o Modificar artículo
                case TipoAlerta.Entrega:
                    return SesionUsuario.Permisos.Contains(320);     // Recepción de mercadería
                case TipoAlerta.Caja:
                    return SesionUsuario.Permisos.Contains(740);     // Cerrar caja
                case TipoAlerta.Pago:
                    return SesionUsuario.Permisos.Contains(420);     // Cuenta corriente de proveedores
                case TipoAlerta.Promocion:
                    return TieneAlguno(230, 240);                   // Administrar promociones
                default:
                    return false;
            }
        }
        // Qué pantalla abre cada tipo de alerta (las mismas opciones del menú: respetan los permisos).
        private Dictionary<TipoAlerta, Action> CrearAccionesAlertas()
        {
            return new Dictionary<TipoAlerta, Action>
            {
                [TipoAlerta.Lote] = () => menuitemAdmistradorarticulos.PerformClick(),
                [TipoAlerta.Stock] = AbrirReposicion,
                [TipoAlerta.Entrega] = () => recepciónDeMercaderiaToolStripMenuItem.PerformClick(),
                [TipoAlerta.Caja] = () => cerrarSeToolStripMenuItem.PerformClick(),
                [TipoAlerta.Pago] = () => cuentaCorrienteDeProveedoresToolStripMenuItem.PerformClick(),
                [TipoAlerta.Promocion] = () => administrarPromocionesToolStripMenuItem.PerformClick(),
                [TipoAlerta.Precio] = () => menuitemAdmistradorarticulos.PerformClick()
            };
        }
        // Ocultar alertas y configurar los días de aviso (cuando se agreguen) son solo del rol Administrador.
        private const int ID_ROL_ADMINISTRADOR = 1;

        private static bool EsAdministrador
        {
            get { return SesionUsuario.IdRol == ID_ROL_ADMINISTRADOR; }
        }
        // Lista completa de alertas: la ve quien tiene el permiso de visualizar alarmas (1110).
        private void AbrirAlertas()
        {
            if (!SesionUsuario.Permisos.Contains(1110))
            {
                MessageBox.Show(ClsIdioma.T("No tenés permiso para ver las alertas."), ClsIdioma.T("Alertas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmAlertas alertas = new frmAlertas(CrearAccionesAlertas(), PuedeResolverAlerta, () => campanaAlertas?.Actualizar()))
            {
                alertas.Icon = Icon;
                alertas.ShowDialog(this);
            }

            campanaAlertas?.Actualizar();
        }
        private void AbrirReposicion()
        {
            // Con permiso de reposición abre ese listado; si no, la administración de artículos.
            if (!SesionUsuario.Permisos.Contains(520))
            {
                menuitemAdmistradorarticulos.PerformClick();
                return;
            }

            using (frmListados listados = new frmListados(frmListados.Modo.Reposicion))
            {
                listados.ShowDialog();
            }
        }

        private void AplicarIdioma()
        {
            // menu principal
            btnArt.Text = idiomaIngles ? "Products" : ClsIdioma.T("Artículos");
            btnVentas.Text = idiomaIngles ? "Sales" : ClsIdioma.T("Ventas");
            btnCompras.Text = idiomaIngles ? "Purchases" : ClsIdioma.T("Compras");
            btnProve.Text = idiomaIngles ? "Suppliers" : ClsIdioma.T("Proveedores");
            toolStripMenuItem1.Text = idiomaIngles ? "Lists" : ClsIdioma.T("Listados");
            btnInformes.Text = idiomaIngles ? "Reports" : ClsIdioma.T("Informes");
            btnCaja.Text = idiomaIngles ? "Cash Register" : ClsIdioma.T("Caja");
            btnIdioma.Text = idiomaIngles ? "Language" : ClsIdioma.T("Idioma");
            btnEmpleado.Text = idiomaIngles ? "Employees" : ClsIdioma.T("Empleado");
            toolStripMenuItem2.Text = idiomaIngles ? "Promotions" : ClsIdioma.T("Promociones");

            // articulos
            cargarArticuloNuevoToolStripMenuItem.Text = idiomaIngles ? "Add New Product" : ClsIdioma.T("Cargar artículo nuevo");
            menuitemAdmistradorarticulos.Text = idiomaIngles ? "Edit Product" : ClsIdioma.T("Modificar artículo");
            menuitemAdministradoarticulos.Text = idiomaIngles ? "Categories and Brands" : ClsIdioma.T("Categorías y marcas");
            meniitemReporapida.Text = idiomaIngles ? "Quick Stock Replenishment" : ClsIdioma.T("Reposición rápida de stock");
            menuitemImporexcel.Text = idiomaIngles ? "Import Products from Excel" : ClsIdioma.T("Importar artículos desde Excel");
            menuitemExporexcel.Text = idiomaIngles ? "Export Products to Excel" : ClsIdioma.T("Exportar artículos a Excel");

            // ventas
            menuitemAdministradorventas.Text = idiomaIngles ? "Sales Management" : ClsIdioma.T("Administrador de ventas");
            notaDeCreditoToolStripMenuItem.Text = idiomaIngles ? "Returns" : ClsIdioma.T("Devolución");

            // compras
            menuitemAministradorcompras.Text = idiomaIngles ? "Purchase Management" : ClsIdioma.T("Administrador de compras");

            // proveedores
            administradorDeProveedoresToolStripMenuItem.Text = idiomaIngles ? "Supplier Management" : ClsIdioma.T("Administrador de proveedores");
            cuentaCorrienteDeProveedoresToolStripMenuItem.Text = idiomaIngles ? "Supplier Account" : ClsIdioma.T("Cuenta corriente de proveedores");

            // listados
            preciosYReposicionToolStripMenuItem.Text = idiomaIngles ? "Prices and Restocking" : ClsIdioma.T("Precios y reposición");

            // informes
            informesVentasToolStripMenuItem.Text = idiomaIngles ? "Sales" : ClsIdioma.T("Ventas");

            // caja
            nuevoIngresoToolStripMenuItem.Text = idiomaIngles ? "New Deposit" : ClsIdioma.T("Nuevo ingreso");
            nuevoEgresoToolStripMenuItem.Text = idiomaIngles ? "New Withdrawal" : ClsIdioma.T("Nuevo egreso");
            cerrarSeToolStripMenuItem.Text = idiomaIngles ? "Close Cash Register" : ClsIdioma.T("Cerrar caja");
            abrirCajaToolStripMenuItem.Text = idiomaIngles ? "Open Cash Register" : ClsIdioma.T("Abrir caja");

            // idioma
            idiomaToolStripMenuItem.Text = idiomaIngles ? "Language" : ClsIdioma.T("Idioma");
            inglesToolStripMenuItem.Text = "English";

            // empleados
            permisosToolStripMenuItem.Text = idiomaIngles ? "Employees" : ClsIdioma.T("Empleado");
            gestioToolStripMenuItem.Text = idiomaIngles ? "Backup Management" : ClsIdioma.T("Gestión de Backup");
            bitacoraToolStripMenuItem.Text = idiomaIngles ? "Activity Log" : ClsIdioma.T("Bitácora");

            // promociones
            administrarPromocionesToolStripMenuItem.Text = idiomaIngles ? "Manage Promotions" : ClsIdioma.T("Administrar promociones");
            btnPromocion.Text = idiomaIngles ? "Promotions" : ClsIdioma.T("Promociones");

            // botones de vernta
            btnCobrar.Text = idiomaIngles ? "F2 - Pay" : ClsIdioma.T("F2 - Cobrar");
            btnNuevaCompra.Text = idiomaIngles ? "F4 - New Purchase" : ClsIdioma.T("F4 - Nueva Compra");
            btnCambiarcantidad.Text = idiomaIngles ? "Change Quantity" : ClsIdioma.T("Cambiar cantidad");
            btnQuitar.Text = idiomaIngles ? "Remove" : ClsIdioma.T("Quitar");

            // etiqueta de productos
            label3.Text = idiomaIngles ? "Scan a code or type part of the SKU or name." : ClsIdioma.T("Escaneá un código o escribí parte del SKU o del nombre."); label4.Text = idiomaIngles ? "Quantity" : ClsIdioma.T("Cantidad");

            // totales
            label1.Text = idiomaIngles ? ClsIdioma.T("Subtotal") : ClsIdioma.T("Subtotal");
            label2.Text = idiomaIngles ? "Discount/Surcharge" : ClsIdioma.T("Descuento/Recargo");
            label5.Text = idiomaIngles ? ClsIdioma.T("Total") : ClsIdioma.T("Total");

            // datos del usuario
            label6.Text = idiomaIngles ? "User:" : ClsIdioma.T("Usuario:");
            label7.Text = idiomaIngles ? "Role:" : ClsIdioma.T("Rol:");
            ActualizarFechaHora();

            // columna de las tablas
            ClnSKU.HeaderText = "SKU";
            ClnIdProducto.HeaderText = idiomaIngles ? "Product ID" : "IdProducto";
            ClnCodigo.HeaderText = idiomaIngles ? "Code" : ClsIdioma.T("Código");
            ClnDescripcion.HeaderText = idiomaIngles ? "Description" : ClsIdioma.T("Descripción");
            ClnCantidad.HeaderText = idiomaIngles ? "Quantity" : ClsIdioma.T("Cantidad");
            ClnPrecioUnitario.HeaderText = idiomaIngles ? "Unit Price" : ClsIdioma.T("Precio Unitario");
            ClnImporte.HeaderText = idiomaIngles ? "Amount" : ClsIdioma.T("Importe");

            // Tabla de importes
            label1.Text = idiomaIngles ? ClsIdioma.T("Subtotal") : ClsIdioma.T("Subtotal");
            label2.Text = idiomaIngles ? "Discount/Surcharge" : ClsIdioma.T("Descuento/Recargo");
            label5.Text = idiomaIngles ? ClsIdioma.T("Total") : ClsIdioma.T("Total");

            // fromulario
            this.Text = idiomaIngles ? "Sales Terminal" : ClsIdioma.T("Presentación");

            // Fecha, hora y mensaje de bienvenida se arman por código: se vuelven a armar en el idioma nuevo.
            ActualizarFechaHora();

            if (modoBienvenida)
            {
                AplicarModoPantalla();
            }
        }

        #region Metodo

        private void AjustarDiseno()
        {
            if (WindowState == FormWindowState.Minimized || !IsHandleCreated)
                return;

            SuspendLayout();

            try
            {
                int ancho = ClientSize.Width;
                int alto = ClientSize.Height;
                int margen = 12;
                int altoMenu = btnConfig.Bottom;
                int altoPie = pnlUsuario.Height;
                int espacioInferior = 10;

                pnlUsuario.SetBounds(0, alto - altoPie, ancho, altoPie);

                if (modoBienvenida)
                {
                    UbicarBienvenida(ancho, altoMenu, pnlUsuario.Top);
                    UbicarFechaHora();
                    return;   // el finally reanuda el diseño
                }

                int anchoDerecha = Math.Clamp((int)(ancho * 0.32), 260, 360);
                int xDerecha = ancho - margen - anchoDerecha;
                int anchoIzquierda = xDerecha - margen * 2;
                int anchoCantidad = Math.Clamp((int)(anchoIzquierda * 0.25), 95, 140);
                int separacion = 12;
                int anchoCodigo = Math.Max(150, anchoIzquierda - anchoCantidad - separacion);

                label3.SetBounds(margen, altoMenu + 11, anchoCodigo, 18);
                txtCodigoBarra.SetBounds(margen, altoMenu + 30, anchoCodigo, 25);
                label4.SetBounds(margen + anchoCodigo + separacion, altoMenu + 11, anchoCantidad, 18);
                txtCantidad.SetBounds(margen + anchoCodigo + separacion, altoMenu + 30, anchoCantidad, 25);

                int yGrilla = altoMenu + 70;
                int yBotones = alto - altoPie - 94;
                int altoGrilla = Math.Max(150, yBotones - yGrilla - 6);

                dtgPresentacion.SetBounds(margen, yGrilla, anchoIzquierda, altoGrilla);
                yBotones = dtgPresentacion.Bottom + 6;
                btnPromocion.SetBounds(margen, yBotones, 207, 74);
                btnQuitar.SetBounds(Math.Max(margen + 215, xDerecha - 208), yBotones, 75, 28);
                btnCambiarcantidad.SetBounds(Math.Max(margen + 295, xDerecha - 127), yBotones, 115, 28);
                tableLayoutPanel1.SetBounds(xDerecha, altoMenu + 30, anchoDerecha, 145);
                btnCobrar.SetBounds(xDerecha, tableLayoutPanel1.Bottom + 6, anchoDerecha, 45);
                btnNuevaCompra.SetBounds(xDerecha, btnCobrar.Bottom + 6, anchoDerecha, 45);

                int yLogo = btnNuevaCompra.Bottom + 8;
                int altoLogo = Math.Max(60, pnlUsuario.Top - yLogo - espacioInferior);

                pcbLogo.SetBounds(xDerecha, yLogo, anchoDerecha, altoLogo);

                lstDescripcion.Left = txtCodigoBarra.Left;
                lstDescripcion.Width = txtCodigoBarra.Width;
                lstDescripcion.Height = 94;

                if (lstDescripcion.Visible)
                {
                    lstDescripcion.BringToFront();
                }

                UbicarFechaHora();
            }
            finally
            {
                ResumeLayout(true);
            }
        }
        // true si el usuario tiene al menos uno de los permisos.
        private static bool TieneAlguno(params int[] permisos)
        {
            return permisos.Any(SesionUsuario.Permisos.Contains);
        }
        private void CargarBotones()
        {
            // Cada sección del menú se habilita si el rol tiene el Total o alguno de sus permisos.

            //Articulo
            btnArt.Enabled = TieneAlguno(100, 110, 111, 112, 113, 120, 121, 122, 130, 131, 132, 140, 150);

            //Promociones
            toolStripMenuItem2.Enabled = TieneAlguno(230, 240);

            //Ventas
            btnVentas.Enabled = TieneAlguno(200, 210, 220, 221, 222, 250);

            //Compras
            btnCompras.Enabled = TieneAlguno(300, 310, 320, 330);

            //Proveedores
            btnProve.Enabled = TieneAlguno(400, 410, 411, 412, 420);

            //Listados
            toolStripMenuItem1.Enabled = TieneAlguno(500, 510, 520);

            //Informes
            btnInformes.Enabled = TieneAlguno(600, 610, 620, 630, 640, 650, 660);

            //Caja
            btnCaja.Enabled = TieneAlguno(700, 710, 720, 730, 740, 750, 760);

            //Ajustes
            btnIdioma.Enabled = SesionUsuario.Permisos.Contains(800);

            //Administración (empleados, backup y bitácora)
            btnEmpleado.Enabled = TieneAlguno(1000, 1010, 1020, 1270, 1280, 1290);

            //Listados
            preciosYReposicionToolStripMenuItem.Enabled = TieneAlguno(510, 520);

            //Articulos operaciones

            // Cargar artículo nuevo
            cargarArticuloNuevoToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(111);
            // Gestión de Articulos
            menuitemAdmistradorarticulos.Enabled = TieneAlguno(110, 111, 112, 113);
            // Gestión de Categorías y Marcas
            menuitemAdministradoarticulos.Enabled = TieneAlguno(120, 121, 122, 130, 131, 132);
            // Reposicion rapida de stock
            meniitemReporapida.Enabled = SesionUsuario.Permisos.Contains(113);
            // Importar articulos desde Excel
            menuitemImporexcel.Enabled = SesionUsuario.Permisos.Contains(140);
            // Exportar articulos a Excel
            menuitemExporexcel.Enabled = SesionUsuario.Permisos.Contains(150);

            //Promociones operaciones
            administrarPromocionesToolStripMenuItem.Enabled = TieneAlguno(230, 240);

            //Ventas

            // Administrador de ventas (ver ventas; anular pide 250)
            menuitemAdministradorventas.Enabled = TieneAlguno(210, 250);
            // Devoluciones
            notaDeCreditoToolStripMenuItem.Enabled = TieneAlguno(220, 221, 222);

            // Pantalla de venta: cargar artículos, cobrar, segunda venta (F4) y aplicar promociones
            bool puedeVender = SesionUsuario.Permisos.Contains(210);
            txtCodigoBarra.Enabled = puedeVender;
            txtCantidad.Enabled = puedeVender;
            btnCambiarcantidad.Enabled = puedeVender;
            btnQuitar.Enabled = puedeVender;
            btnCobrar.Enabled = puedeVender;
            btnNuevaCompra.Enabled = puedeVender;
            btnPromocion.Enabled = puedeVender;

            //Compras operaciones
            menuitemAministradorcompras.Enabled = TieneAlguno(310, 330);
            recepciónDeMercaderiaToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(320);

            //Proveedores

            // Gestión de proveedores
            administradorDeProveedoresToolStripMenuItem.Enabled = TieneAlguno(410, 411, 412);
            // Cuenta corriente
            cuentaCorrienteDeProveedoresToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(420);
            //Informe operaciones
            // Un solo acceso a los cinco informes de ventas; adentro cada informe respeta su permiso (610 a 650).
            informesVentasToolStripMenuItem.Enabled = TieneAlguno(610, 620, 630, 640, 650);
            balanceToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(660);
            //Caja operaciones
            nuevoIngresoToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(710);
            nuevoEgresoToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(720);
            abrirCajaToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(730);
            cerrarSeToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(740);
            estadoCajaToolStripMenuItem.Enabled = TieneAlguno(750, 760);

            //Administración operaciones
            permisosToolStripMenuItem.Enabled = TieneAlguno(1010, 1020, 1270);
            gestioToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(1280);
            bitacoraToolStripMenuItem.Enabled = SesionUsuario.Permisos.Contains(1290);        }
        //Ingreso de plata
        public enum TipoMovimiento
        {
            Ingreso,
            Egreso
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
            estadoCajaToolStripMenuItem.Enabled = false;
            abrirCajaToolStripMenuItem.Enabled = true;

            // Botones del formulario
            btnCambiarcantidad.Enabled = false;
            btnQuitar.Enabled = false;
            btnCobrar.Enabled = false;
            btnNuevaCompra.Enabled = false;
            btnPromocion.Enabled = false;

            // Entrada de datos
            txtCodigoBarra.Enabled = false;
            txtCantidad.Enabled = false;
            dtgPresentacion.Enabled = false;

            txtUsuario.Text = "";
            txtRol.Text = "";
        }
        private bool AgregarProductoAGrilla(int idProducto, string sku, string codigoBarra, string descripcion, decimal precio, decimal cantidad, decimal stockDisponible)
        {
            if (cantidad <= 0)
            {
                MessageBox.Show(ClsIdioma.T("La cantidad debe ser mayor a cero."), ClsIdioma.T("Cantidad inválida"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (precio < 0)
            {
                MessageBox.Show(ClsIdioma.T("El precio no puede ser negativo."), ClsIdioma.T("Precio inválido"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal cantidadYaCargada = 0m;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    continue;

                if (int.TryParse(Convert.ToString(fila.Cells["ClnIdProducto"].Value), out int idCargado) && idCargado == idProducto)
                {
                    if (decimal.TryParse(Convert.ToString(fila.Cells["ClnCantidad"].Value), out decimal cantidadCargada))
                    {
                        cantidadYaCargada += cantidadCargada;
                    }
                }
            }

            decimal cantidadEnGrillaSecundaria = 0m;

            if (formularioSecundario != null && !formularioSecundario.IsDisposed)
            {
                cantidadEnGrillaSecundaria = formularioSecundario.ObtenerCantidadCargada(idProducto);
            }

            decimal cantidadTotal = cantidadYaCargada + cantidadEnGrillaSecundaria + cantidad;

            if (stockDisponible <= 0 || cantidadTotal > stockDisponible)
            {
                decimal stockRestante = Math.Max(0m, stockDisponible - cantidadYaCargada - cantidadEnGrillaSecundaria);

                MessageBox.Show((ClsIdioma.Ingles ? $"Insufficient stock.\n" : $"Stock insuficiente.\n") + (ClsIdioma.Ingles ? $"Stock in system: {stockDisponible}\n" : $"Stock en sistema: {stockDisponible}\n") + (ClsIdioma.Ingles ? $"Quantity in main sale: {cantidadYaCargada}\n" : $"Cantidad en venta principal: {cantidadYaCargada}\n") +
                    (ClsIdioma.Ingles ? $"Quantity in secondary sale: {cantidadEnGrillaSecundaria}\n" : $"Cantidad en venta secundaria: {cantidadEnGrillaSecundaria}\n") + (ClsIdioma.Ingles ? $"Stock available to add: {stockRestante}\n" : $"Stock disponible para agregar: {stockRestante}\n") + (ClsIdioma.Ingles ? $"Quantity to add: {cantidad}" : $"Cantidad a agregar: {cantidad}"),
                    ClsIdioma.T("Stock insuficiente"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }


            // Si el producto ya está en la venta (fuera de promociones), se suma la cantidad
            // a esa fila en vez de agregar otra. Las filas de promoción no se mezclan.
            if (codigoBarra != "PROMOCION")
            {
                foreach (DataGridViewRow fila in dtgPresentacion.Rows)
                {
                    if (fila.IsNewRow || Convert.ToString(fila.Cells["ClnCodigo"].Value) == "PROMOCION")
                        continue;

                    if (int.TryParse(Convert.ToString(fila.Cells["ClnIdProducto"].Value), out int idFila) && idFila == idProducto)
                    {
                        decimal.TryParse(Convert.ToString(fila.Cells["ClnCantidad"].Value), out decimal cantidadFila);
                        decimal.TryParse(Convert.ToString(fila.Cells["ClnPrecioUnitario"].Value), out decimal precioFila);

                        decimal nuevaCantidad = cantidadFila + cantidad;

                        fila.Cells["ClnCantidad"].Value = nuevaCantidad;
                        fila.Cells["ClnImporte"].Value = Math.Round(nuevaCantidad * precioFila, 2);

                        dtgPresentacion.ClearSelection();
                        dtgPresentacion.CurrentCell = fila.Cells["ClnDescripcion"];
                        fila.Selected = true;

                        CalcularYMostrarMontos();
                        dtgPresentacion.Refresh();

                        return true;
                    }
                }
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

            return true;
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
                    MessageBox.Show(ClsIdioma.T("Ingrese una cantidad válida mayor a 0."), ClsIdioma.T("Cantidad inválida"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }
            }

            ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();

            DataTable tablaProducto = logicaProducto.ObtenerProductoPorCodigoBarra(codigoBarra);

            if (tablaProducto.Rows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("No se encontró un producto con ese código de barras."), ClsIdioma.T("Producto no encontrado"),
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
            DateTime ahora = DateTime.Now;

            lblFecha.Text = (idiomaIngles ? "Date: " : ClsIdioma.T("Fecha: ")) + ahora.ToString("dd/MM/yyyy");
            lblHora.Text = (idiomaIngles ? "Time: " : ClsIdioma.T("Hora: ")) + ahora.ToString("HH:mm:ss");

            // El ancho de los labels cambia con el texto: se reubican para que no se corran.
            UbicarFechaHora();
        }
        private void UbicarFechaHora()
        {
            int margen = 12;

            lblHora.Left = ClientSize.Width - lblHora.Width - margen;
            lblFecha.Left = lblHora.Left - lblFecha.Width - 20;
        }
        private void LimpiarVenta()
        {
            dtgPresentacion.Rows.Clear();

            subtotal = 0.00m;
            descuentoRecargo = 0.00m;
            total = 0.00m;
            promocionesAplicadas.Clear();   // [PROMO]

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
        // [PROMO] Anota una promoción aplicada. Si la misma promo se aplica de nuevo
        // en la misma venta, suma una vez más.
        private void RegistrarPromocionAplicada(int idPromocion, string nombre, decimal importeLista, decimal importeCobrado)
        {
            ClsPromocionVentaEntidad existente = promocionesAplicadas.FirstOrDefault(p => p.IdPromocion == idPromocion);

            if (existente == null)
            {
                promocionesAplicadas.Add(new ClsPromocionVentaEntidad
                {
                    IdPromocion = idPromocion,
                    Nombre = nombre,
                    Veces = 1,
                    ImporteLista = Math.Round(importeLista, 2),
                    ImporteCobrado = Math.Round(importeCobrado, 2)
                });
            }
            else
            {
                existente.Veces += 1;
                existente.ImporteLista += Math.Round(importeLista, 2);
                existente.ImporteCobrado += Math.Round(importeCobrado, 2);
            }
        }

        // [CAJA] Devuelve true si hay caja abierta. Si no la hay y el usuario
        // tiene permiso (730), ofrece abrirla en el momento.
        private bool VerificarCajaAbierta()
        {
            try
            {
                ClsCajaLogica logicaCaja = new ClsCajaLogica();

                if (logicaCaja.HayCajaAbierta())
                {
                    return true;
                }

                if (!SesionUsuario.Permisos.Contains(730))
                {
                    MessageBox.Show(ClsIdioma.T("No hay una caja abierta. Pida a un encargado que abra la caja para poder vender."),
                        ClsIdioma.T("Caja cerrada"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                DialogResult respuesta = MessageBox.Show(ClsIdioma.T("No hay una caja abierta.\n\n¿Desea abrirla ahora?"),
                    ClsIdioma.T("Caja cerrada"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return false;
                }

                using (frmAbrirCaja abrir = new frmAbrirCaja())
                {
                    return abrir.ShowDialog() == DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo verificar la caja.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void AgregarProductoSeleccionado()
        {
            if (lstDescripcion.SelectedIndex < 0 || tablaProductosEncontrados == null)
                return;

            // Sin cantidad escrita se agrega 1, igual que con el código de barras.
            decimal cantidad = 1;

            if (!string.IsNullOrWhiteSpace(txtCantidad.Text) &&
                (!decimal.TryParse(txtCantidad.Text.Trim(), out cantidad) || cantidad <= 0))
            {
                MessageBox.Show(ClsIdioma.T("Ingresá una cantidad válida mayor que cero."), ClsIdioma.T("Cantidad inválida"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCantidad.Focus();
                txtCantidad.SelectAll();
                return;
            }

            int indice = lstDescripcion.SelectedIndex;

            if (indice >= tablaProductosEncontrados.Rows.Count)
                return;

            DataRow fila = tablaProductosEncontrados.Rows[indice];

            int idProducto = Convert.ToInt32(fila["IdProducto"]);
            string sku = fila["SKU"].ToString();
            string codigoBarra = fila["CodigoBarra"].ToString();
            string descripcion = fila["Descripcion"].ToString();
            decimal precio = Convert.ToDecimal(fila["PrecioVenta"]);

            ClsGestorProductoLogica logica = new ClsGestorProductoLogica();
            DataTable tablaStock = logica.ObtenerStockPorProducto(idProducto);

            decimal stockDisponible = 0m;

            if (tablaStock != null && tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
            {
                stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
            }

            // Agregar usando la cantidad ingresada
            AgregarProductoAGrilla(idProducto, sku, codigoBarra, descripcion, precio, cantidad, stockDisponible);

            lstDescripcion.Visible = false;
            lstDescripcion.Items.Clear();
            txtCodigoBarra.Clear();
            txtCantidad.Clear();   // la próxima vuelve a ser 1 si no se escribe otra
            txtCodigoBarra.Focus();
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
        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCodigoBarra.Text.Trim();

            lstDescripcion.Items.Clear();
            tablaProductosEncontrados = null;

            if (string.IsNullOrWhiteSpace(texto))
            {
                lstDescripcion.Visible = false;
                return;
            }

            try
            {
                tablaProductosEncontrados = logicaProducto.BuscarArticulos(texto, true);

                if (tablaProductosEncontrados == null || tablaProductosEncontrados.Rows.Count == 0)
                {
                    lstDescripcion.Visible = false;
                    return;
                }

                foreach (DataRow fila in tablaProductosEncontrados.Rows)
                {
                    string descripcion = fila["Descripcion"].ToString();

                    lstDescripcion.Items.Add(descripcion);
                }

                lstDescripcion.Visible = lstDescripcion.Items.Count > 0;
            }
            catch (Exception ex)
            {
                lstDescripcion.Visible = false;

                MessageBox.Show(ClsIdioma.T("Error al buscar artículos: ") + ex.Message, ClsIdioma.T("Búsqueda de artículos"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void lstDescripcion_DoubleClick(object sender, EventArgs e)
        {
            AgregarProductoSeleccionado();
        }
        private void lstDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AgregarProductoSeleccionado();
            }
        }
        //Menu Item
        private void frmmenuPres_KeyDown(object sender, KeyEventArgs e)
        {
            // Sin pantalla de venta no hay cobro (F2) ni segunda venta (F4).
            if (modoBienvenida)
                return;

            if (e.KeyCode == Keys.F2)
            {
                e.SuppressKeyPress = true;
                btnCobrar.PerformClick();
            }
            else if (e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true;
                btnNuevaCompra.PerformClick();
            }
        }
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
        private void informesVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmInformesVentas informes = new frmInformesVentas(frmInformesVentas.InformeInicialSegunPermisos()))
            {
                informes.ShowDialog();
            }
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
        private void preciosYReposicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Con un solo permiso se abre directo en ese listado; con los dos, se elige adentro.
            bool precios = SesionUsuario.Permisos.Contains(510);
            bool reposicion = SesionUsuario.Permisos.Contains(520);

            frmListados.Modo modo = precios && reposicion ? frmListados.Modo.Ninguno
                                  : precios ? frmListados.Modo.Precios
                                  : frmListados.Modo.Reposicion;

            using (frmListados listados = new frmListados(modo))
            {
                listados.ShowDialog();
            }
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

            try
            {
                ClsCajaLogica logicaCaja = new ClsCajaLogica();
                var sesionCaja = logicaCaja.ObtenerSesionAbierta();

                if (sesionCaja != null)
                {
                    DialogResult arqueo = MessageBox.Show(
                        ClsIdioma.T("¿Desea hacer el arqueo y cerrar la caja?\n\n") +
                        ClsIdioma.T("Sí: cuenta el efectivo y cierra la caja.\n") +
                        ClsIdioma.T("No: cierra solo su sesión y la caja sigue abierta para el próximo turno."),
                        ClsIdioma.T("Cerrar caja"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (arqueo == DialogResult.Cancel)
                    {
                        return;
                    }

                    if (arqueo == DialogResult.Yes)
                    {
                        using (frmCerrarCaja cierre = new frmCerrarCaja(sesionCaja.IdSesionCaja))
                        {

                            if (cierre.ShowDialog() != DialogResult.OK)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo verificar la caja.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DialogResult resultado = MessageBox.Show(ClsIdioma.T("Estas seguro de cerrar la sesión?"), ClsIdioma.T("Cerrar sesión"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    ClsIdioma.T("Ya hay una sesión abierta. Debe cerrar la sesión actual antes de iniciar otra."),
                    ClsIdioma.T("Sesión abierta"),
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
            DialogResult resultado = MessageBox.Show(ClsIdioma.T("Estas seguro de cerrar la sesión?"), ClsIdioma.T("Cerrar sesión"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();

            }
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
            bool hayProductos = false;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    continue;

                if (!string.IsNullOrWhiteSpace(Convert.ToString(fila.Cells["ClnIdProducto"].Value)))
                {
                    hayProductos = true;
                    break;
                }
            }

            if (!hayProductos)
            {
                MessageBox.Show(ClsIdioma.T("Primero debe cargar al menos un producto en la venta principal."), ClsIdioma.T("Venta sin productos"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigoBarra.Focus();
                return;
            }

            // Evita abrir una segunda ventana secundaria
            if (formularioSecundario != null && !formularioSecundario.IsDisposed)
            {
                formularioSecundario.Activate();
                return;
            }

            formularioSecundario = new frmCobroSecundario(dtgPresentacion);

            formularioSecundario.FormClosed += (s, arg) =>
            {
                formularioSecundario = null;
            };

            formularioSecundario.Show();

        }
        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            using (frmBuscarArticulo buscarArticulo = new frmBuscarArticulo())
            {
                buscarArticulo.ShowDialog();

                ClsProducto producto = buscarArticulo.ProductoSeleccionado;

                if (producto == null)
                {
                    MessageBox.Show(ClsIdioma.T("No se recibió ningún producto seleccionado. ") + ClsIdioma.T("Revisá el botón de selección de frmBuscarArticulo."), ClsIdioma.T("Producto no seleccionado"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();

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
                MessageBox.Show(ClsIdioma.T("Debe agregar al menos un producto para realizar el cobro."), ClsIdioma.T("Cobrar venta"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigoBarra.Focus();
                return;
            }

            // [CAJA] Sin caja abierta no se puede vender
            if (!VerificarCajaAbierta())
            {
                return;
            }

            frmInformeCobro cobro = new frmInformeCobro(total, dtgPresentacion, promocionesAplicadas);   // [PROMO]

            if (cobro.ShowDialog() == DialogResult.OK)
            {
                LimpiarVenta();
            }
        }
        private void menuitemAdministradoarticulos_Click(object sender, EventArgs e)
        {
            frmCategoriaMarca categoriaMarca = new frmCategoriaMarca();
            categoriaMarca.ShowDialog();
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
                    ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();

                    DataSet datos = logicaPromo.ObtenerPromocionPorId(idPromocion);

                    if (datos == null || datos.Tables.Count < 2 || datos.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(ClsIdioma.T("No se encontraron los datos de la promoción."));
                        return;
                    }

                    DataRow promo = datos.Tables[0].Rows[0];

                    if (promo["Activo"] == DBNull.Value || !Convert.ToBoolean(promo["Activo"]))
                    {
                        MessageBox.Show(ClsIdioma.T("La promoción seleccionada está inactiva."));
                        return;
                    }

                    DataTable detalles = datos.Tables[1];

                    if (detalles.Rows.Count == 0)
                    {
                        MessageBox.Show(ClsIdioma.T("La promoción no tiene productos asociados."));
                        return;
                    }

                    int idTipoPromocion = Convert.ToInt32(promo["IdTipoPromocion"]);
                    decimal valor = Convert.ToDecimal(promo["Valor"]);

                    DataTable tipos = logicaPromo.ObtenerTiposPromocion();

                    DataRow[] tiposEncontrados = tipos.Select("IdTipoPromocion = " + idTipoPromocion);

                    if (tiposEncontrados.Length == 0)
                    {
                        MessageBox.Show(ClsIdioma.T("No se encontró el tipo de promoción."));
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

                        if (cantidadLleva <= 0 || cantidadPaga <= 0 || cantidadPaga >= cantidadLleva)
                        {
                            MessageBox.Show(ClsIdioma.T("La mecánica de volumen no es válida."));
                            return;
                        }
                    }
                    else if (idTipoPromocion == 4)
                    {
                        if (valor <= 0 || valor > 100)
                        {
                            MessageBox.Show(ClsIdioma.T("El porcentaje de descuento no es válido."));
                            return;
                        }
                    }
                    else if (idTipoPromocion == 5)
                    {
                        if (valor <= 0)
                        {
                            MessageBox.Show(ClsIdioma.T("El precio especial no es válido."));
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(ClsIdioma.T("El tipo de promoción no es válido."));
                        return;
                    }

                    decimal precioFinal = 0m;

                    DataTable respaldoGrilla = new DataTable();

                    foreach (DataGridViewColumn columna in dtgPresentacion.Columns)
                    {
                        respaldoGrilla.Columns.Add(columna.Name, typeof(object));
                    }

                    foreach (DataGridViewRow fila in dtgPresentacion.Rows)
                    {
                        if (fila.IsNewRow)
                            continue;

                        DataRow nuevaFila = respaldoGrilla.NewRow();

                        foreach (DataGridViewColumn columna in dtgPresentacion.Columns)
                        {
                            nuevaFila[columna.Name] = fila.Cells[columna.Name].Value ?? DBNull.Value;
                        }

                        respaldoGrilla.Rows.Add(nuevaFila);
                    }

                    decimal subtotalAnterior = subtotal;
                    decimal ajusteAnterior = descuentoRecargo;
                    decimal totalAnterior = total;

                    foreach (DataRow detalle in detalles.Rows)
                    {
                        decimal cantidadConfigurada = Convert.ToDecimal(detalle["Cantidad"]);
                        decimal precioUnitario = Convert.ToDecimal(detalle["PrecioVenta"]);

                        if (cantidadConfigurada <= 0 || precioUnitario < 0)
                        {
                            MessageBox.Show(ClsIdioma.T("La cantidad o el precio de un producto no son válidos."));
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

                    var cantidadesPromocion = new Dictionary<int, decimal>();

                    foreach (DataRow detalle in detalles.Rows)
                    {
                        int idProducto = Convert.ToInt32(detalle["IdProducto"]);
                        decimal cantidadConfigurada = Convert.ToDecimal(detalle["Cantidad"]);

                        decimal cantidadAgregar = esVolumen ? cantidadConfigurada * cantidadLleva : cantidadConfigurada;

                        if (cantidadesPromocion.ContainsKey(idProducto))
                        {
                            cantidadesPromocion[idProducto] += cantidadAgregar;
                        }
                        else
                        {
                            cantidadesPromocion[idProducto] = cantidadAgregar;
                        }
                    }

                    foreach (var producto in cantidadesPromocion)
                    {
                        int idProducto = producto.Key;
                        decimal cantidadAgregar = producto.Value;

                        DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

                        decimal stockDisponible = 0m;

                        if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                        {
                            stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                        }

                        decimal cantidadEnPrincipal = 0m;

                        foreach (DataGridViewRow fila in dtgPresentacion.Rows)
                        {
                            if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                            {
                                continue;
                            }

                            if (int.TryParse(Convert.ToString(fila.Cells["ClnIdProducto"].Value), out int idCargado) && idCargado == idProducto)
                            {
                                if (decimal.TryParse(Convert.ToString(fila.Cells["ClnCantidad"].Value), out decimal cantidadCargada))
                                {
                                    cantidadEnPrincipal += cantidadCargada;
                                }
                            }
                        }

                        decimal cantidadEnSecundaria = 0m;

                        if (formularioSecundario != null && !formularioSecundario.IsDisposed)
                        {
                            cantidadEnSecundaria = formularioSecundario.ObtenerCantidadCargada(idProducto);
                        }

                        if (cantidadEnPrincipal + cantidadEnSecundaria + cantidadAgregar > stockDisponible)
                        {
                            MessageBox.Show(ClsIdioma.T("Stock insuficiente para un producto de la promoción.\n\n") + (ClsIdioma.Ingles ? $"Product ID: {idProducto}\n" : $"ID del producto: {idProducto}\n") +
                                (ClsIdioma.Ingles ? $"Stock in system: {stockDisponible}\n" : $"Stock en sistema: {stockDisponible}\n") + (ClsIdioma.Ingles ? $"In main sale: {cantidadEnPrincipal}\n" : $"En venta principal: {cantidadEnPrincipal}\n") + (ClsIdioma.Ingles ? $"In secondary sale: {cantidadEnSecundaria}\n" : $"En venta secundaria: {cantidadEnSecundaria}\n") +
                                (ClsIdioma.Ingles ? $"Quantity required by the promotion: {cantidadAgregar}" : $"Cantidad requerida por la promoción: {cantidadAgregar}"),
                                ClsIdioma.T("Promociones"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                    }


                    foreach (DataRow detalle in detalles.Rows)
                    {
                        int idProducto = Convert.ToInt32(detalle["IdProducto"]);
                        string sku = detalle["SKU"].ToString();
                        string codigoPromocion = "PROMOCION";
                        decimal precio = Convert.ToDecimal(detalle["PrecioVenta"]);
                        decimal cantidadConfigurada = Convert.ToDecimal(detalle["Cantidad"]);

                        decimal cantidad = esVolumen ? cantidadConfigurada * cantidadLleva : cantidadConfigurada;

                        DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

                        decimal stockDisponible = 0m;

                        if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                        {
                            stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                        }

                        bool agregado = AgregarProductoAGrilla(idProducto, sku, codigoPromocion, detalle["NombreProducto"].ToString(), precio, cantidad, stockDisponible);

                        if (agregado && dtgPresentacion.Rows.Count > 0)
                        {
                            DataGridViewRow filaAgregada = dtgPresentacion.Rows[dtgPresentacion.Rows.Count - 1];

                            filasDePromocion.Add(filaAgregada);
                        }

                        if (!agregado)
                        {
                            dtgPresentacion.Rows.Clear();

                            foreach (DataRow filaRespaldo in respaldoGrilla.Rows)
                            {
                                int indice = dtgPresentacion.Rows.Add();
                                DataGridViewRow filaNueva = dtgPresentacion.Rows[indice];

                                foreach (DataGridViewColumn columna in dtgPresentacion.Columns)
                                {
                                    object valorCelda = filaRespaldo[columna.Name];

                                    filaNueva.Cells[columna.Name].Value = valorCelda == DBNull.Value ? null : valorCelda;
                                }
                            }

                            subtotal = subtotalAnterior;
                            descuentoRecargo = ajusteAnterior;
                            total = totalAnterior;

                            RellenarFilas();
                            CalcularYMostrarMontos();
                            txtCodigoBarra.Focus();

                            MessageBox.Show(ClsIdioma.T("No se pudo cargar toda la promoción. Se restauró la venta anterior."), ClsIdioma.T("Promociones"),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }

                    }

                    decimal importeNormalAgregado = subtotal - subtotalAnterior;
                    decimal descuentoPromocion = importeNormalAgregado - precioFinal;

                    descuentoRecargo = ajusteAnterior - descuentoPromocion;

                    // [PROMO] Anotar la promoción para guardarla al cobrar
                    RegistrarPromocionAplicada(
                        idPromocion,
                        promo.Table.Columns.Contains("Nombre") ? Convert.ToString(promo["Nombre"]) : "",
                        importeNormalAgregado,
                        precioFinal);

                    CalcularYMostrarMontos();


                    txtCodigoBarra.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ClsIdioma.T("Error al cargar la promoción: ") + ex.Message, ClsIdioma.T("Promociones"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void btnCambiarcantidad_Click(object sender, EventArgs e)
        {
            if (dtgPresentacion.CurrentRow == null || dtgPresentacion.CurrentRow.Cells["ClnIdProducto"].Value == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un producto para cambiar la cantidad."), ClsIdioma.T("Cambiar cantidad"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dtgPresentacion.CurrentRow;

            string codigoFila = Convert.ToString(fila.Cells["ClnCodigo"].Value);

            if (codigoFila == "PROMOCION")
            {
                MessageBox.Show(
                    ClsIdioma.T("No se puede modificar la cantidad de un producto que pertenece a una promoción."),
                    ClsIdioma.T("Cambiar cantidad"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCodigoBarra.Focus();
                return;
            }


            int idProducto = Convert.ToInt32(fila.Cells["ClnIdProducto"].Value);
            decimal cantidadActual = Convert.ToDecimal(fila.Cells["ClnCantidad"].Value);
            string entrada = Microsoft.VisualBasic.Interaction.InputBox(ClsIdioma.T("Ingrese la nueva cantidad:"), ClsIdioma.T("Cambiar cantidad"), cantidadActual.ToString());

            if (string.IsNullOrWhiteSpace(entrada))
            {
                return;
            }

            if (!decimal.TryParse(entrada, out decimal nuevaCantidad) || nuevaCantidad <= 0)
            {
                MessageBox.Show(ClsIdioma.T("Ingrese una cantidad válida mayor a 0."), ClsIdioma.T("Cantidad inválida"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();

            DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

            decimal stockDisponible = 0;

            if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
            {
                stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
            }

            decimal cantidadEnGrillaPrincipalSinFila = 0m;

            foreach (DataGridViewRow otraFila in dtgPresentacion.Rows)
            {
                if (otraFila.IsNewRow || otraFila == fila || otraFila.Cells["ClnIdProducto"].Value == null)
                    continue;

                if (int.TryParse(Convert.ToString(otraFila.Cells["ClnIdProducto"].Value), out int idCargado) && idCargado == idProducto)
                {
                    if (decimal.TryParse(Convert.ToString(otraFila.Cells["ClnCantidad"].Value), out decimal cantidadCargada))
                    {
                        cantidadEnGrillaPrincipalSinFila += cantidadCargada;
                    }
                }
            }

            decimal cantidadEnGrillaSecundaria = 0m;

            if (formularioSecundario != null && !formularioSecundario.IsDisposed)
            {
                cantidadEnGrillaSecundaria = formularioSecundario.ObtenerCantidadCargada(idProducto);
            }

            decimal cantidadTotal = cantidadEnGrillaPrincipalSinFila + cantidadEnGrillaSecundaria + nuevaCantidad;

            if (stockDisponible <= 0 || cantidadTotal > stockDisponible)
            {
                decimal stockRestante = Math.Max(0m, stockDisponible - cantidadEnGrillaPrincipalSinFila - cantidadEnGrillaSecundaria);

                MessageBox.Show((ClsIdioma.Ingles ? $"Insufficient stock.\n\n" : $"Stock insuficiente.\n\n") + (ClsIdioma.Ingles ? $"Stock in system: {stockDisponible}\n" : $"Stock en sistema: {stockDisponible}\n") +
                    (ClsIdioma.Ingles ? $"Other units in main sale: {cantidadEnGrillaPrincipalSinFila}\n" : $"Otras unidades en venta principal: {cantidadEnGrillaPrincipalSinFila}\n") + (ClsIdioma.Ingles ? $"Units in secondary sale: {cantidadEnGrillaSecundaria}\n" : $"Unidades en venta secundaria: {cantidadEnGrillaSecundaria}\n") +
                    (ClsIdioma.Ingles ? $"Available for this row: {stockRestante}\n" : $"Disponible para esta fila: {stockRestante}\n") + (ClsIdioma.Ingles ? $"Requested quantity: {nuevaCantidad}" : $"Cantidad solicitada: {nuevaCantidad}"),
                    ClsIdioma.T("Stock insuficiente"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                MessageBox.Show(ClsIdioma.T("Seleccione un producto para quitar."), ClsIdioma.T("Quitar producto"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dtgPresentacion.CurrentRow;

            // [PROMO] Si el producto es de una promoción, se quitan todas las
            // promociones juntas (si no, el descuento quedaba aplicado igual).
            if (Convert.ToString(fila.Cells["ClnCodigo"].Value) == "PROMOCION")
            {
                DialogResult quitarPromos = MessageBox.Show(
                    ClsIdioma.T("Ese producto pertenece a una promoción.\n\n") +
                    ClsIdioma.T("Se van a quitar todos los productos de promociones y su descuento. ¿Continuar?"),
                    ClsIdioma.T("Quitar promoción"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (quitarPromos != DialogResult.Yes)
                {
                    return;
                }

                // Se eliminan las filas (no solo se vacían), así no quedan huecos en la grilla.
                List<DataGridViewRow> filasPromo = dtgPresentacion.Rows.Cast<DataGridViewRow>()
                    .Where(f => !f.IsNewRow && Convert.ToString(f.Cells["ClnCodigo"].Value) == "PROMOCION")
                    .ToList();

                foreach (DataGridViewRow filaPromo in filasPromo)
                {
                    dtgPresentacion.Rows.Remove(filaPromo);
                }

                filasDePromocion.Clear();
                promocionesAplicadas.Clear();
                descuentoRecargo = 0m;

                RellenarFilas();
                CalcularYMostrarMontos();
                txtCodigoBarra.Focus();
                return;
            }

            // Se elimina la fila: los productos de abajo suben y las filas vacías quedan al final.
            dtgPresentacion.Rows.Remove(fila);

            RellenarFilas();
            CalcularYMostrarMontos();

            txtCodigoBarra.Focus();
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
        private async void FrmPresentacion_Load(object sender, EventArgs e)
        {

            // backup automatico: con la base remota se descarga por la red, así que se hace
            // en segundo plano para no congelar la pantalla al iniciar.

            try
            {
                ClsBackupLogica backup = new ClsBackupLogica();
                await Task.Run(() => backup.BackupAutomatico());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ClsIdioma.T("No se pudo generar el backup automático: ") + ex.Message, ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cargarArticuloNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoArticulo nuevoarticulo = new frmNuevoArticulo();
            nuevoarticulo.ShowDialog();

        }
        private void lstDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //idioma
        private void btnIdioma_Click(object sender, EventArgs e)
        {

        }
        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsIdioma.CambiarIdioma(false);
            AplicarIdioma();
        }
        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsIdioma.CambiarIdioma(true);
            AplicarIdioma();
        }

        //bitacora
        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacora bitacora = new frmBitacora();
            bitacora.ShowDialog();
        }
        #endregion




























        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void recepciónDeMercaderiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecepcionCompra recepcion = new frmRecepcionCompra();
            recepcion.ShowDialog();
        }

        private void estadoCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCaja caja = new frmCaja())
            {
                caja.ShowDialog();
            }
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmBalance balance = new frmBalance())
            {
                balance.ShowDialog();
            }
        }
    }

}