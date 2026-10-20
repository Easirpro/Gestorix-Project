namespace CapaVista
{
    partial class frmmenuPres
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer tmrFechaHora;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmenuPres));
            btnCambiarcantidad = new Button();
            btnRecargo = new Button();
            btnDescuento = new Button();
            btnQuitar = new Button();
            pcbLogo = new PictureBox();
            btnCobrar = new Button();
            btnNuevaCompra = new Button();
            btnVerPrecio = new Button();
            lblTotalMonto = new Label();
            label5 = new Label();
            lblDescuentoMonto = new Label();
            lblSubtotalMonto = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtCodigoBarra = new TextBox();
            txtCantidad = new TextBox();
            btnBuscarArticulo = new Button();
            dtgPresentacion = new DataGridView();
            ClnSKU = new DataGridViewTextBoxColumn();
            ClnIdProducto = new DataGridViewTextBoxColumn();
            ClnCodigo = new DataGridViewTextBoxColumn();
            ClnDescripcion = new DataGridViewTextBoxColumn();
            ClnCantidad = new DataGridViewTextBoxColumn();
            ClnPrecioUnitario = new DataGridViewTextBoxColumn();
            ClnImporte = new DataGridViewTextBoxColumn();
            pnlUsuario = new Panel();
            lblHora = new Label();
            lblFecha = new Label();
            label7 = new Label();
            txtRol = new TextBox();
            txtUsuario = new TextBox();
            label6 = new Label();
            btnPromocion = new Button();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            btnArt = new ToolStripMenuItem();
            cargarArticuloNuevoToolStripMenuItem = new ToolStripMenuItem();
            menuitemAdmistradorarticulos = new ToolStripMenuItem();
            menuitemAdministradoarticulos = new ToolStripMenuItem();
            meniitemReporapida = new ToolStripMenuItem();
            cargaRapidaDePreciosToolStripMenuItem = new ToolStripMenuItem();
            cargarDeLasMarcasToolStripMenuItem = new ToolStripMenuItem();
            menuitemImporexcel = new ToolStripMenuItem();
            menuitemExporexcel = new ToolStripMenuItem();
            btnVentas = new ToolStripMenuItem();
            menuitemAdministradorventas = new ToolStripMenuItem();
            notaDeCreditoToolStripMenuItem = new ToolStripMenuItem();
            btnCompras = new ToolStripMenuItem();
            menuitemAministradorcompras = new ToolStripMenuItem();
            btnProve = new ToolStripMenuItem();
            administradorDeProveedoresToolStripMenuItem = new ToolStripMenuItem();
            cuentaCorrienteDeProveedoresToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            listaDePreciosToolStripMenuItem = new ToolStripMenuItem();
            listadoDeReposiciónToolStripMenuItem = new ToolStripMenuItem();
            btnInformes = new ToolStripMenuItem();
            ventasPorDiaToolStripMenuItem = new ToolStripMenuItem();
            ventaToolStripMenuItem = new ToolStripMenuItem();
            ventaPorRubroToolStripMenuItem = new ToolStripMenuItem();
            ventaPorArticulosToolStripMenuItem = new ToolStripMenuItem();
            ventaPorMedioDePagoToolStripMenuItem = new ToolStripMenuItem();
            ajustesToolStripMenuItem = new ToolStripMenuItem();
            btnCaja = new ToolStripMenuItem();
            nuevoIngresoToolStripMenuItem = new ToolStripMenuItem();
            nuevoEgresoToolStripMenuItem = new ToolStripMenuItem();
            cerrarSeToolStripMenuItem = new ToolStripMenuItem();
            abrirCajaToolStripMenuItem = new ToolStripMenuItem();
            btnIdioma = new ToolStripMenuItem();
            inglesToolStripMenuItem = new ToolStripMenuItem();
            españolToolStripMenuItem = new ToolStripMenuItem();
            idiomaToolStripMenuItem = new ToolStripMenuItem();
            btnEmpleado = new ToolStripMenuItem();
            gestioToolStripMenuItem = new ToolStripMenuItem();
            permisosToolStripMenuItem = new ToolStripMenuItem();
            bitacoraToolStripMenuItem = new ToolStripMenuItem();
            tollClosed = new ToolStripMenuItem();
            btnConfig = new MenuStrip();
            toolStripMenuItem2 = new ToolStripMenuItem();
            administrarPromocionesToolStripMenuItem = new ToolStripMenuItem();
            tmrFechaHora = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pcbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgPresentacion).BeginInit();
            pnlUsuario.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            btnConfig.SuspendLayout();
            SuspendLayout();
            //
            // tmrFechaHora
            //
            tmrFechaHora.Interval = 1000;
            tmrFechaHora.Tick += tmrFechaHora_Tick;
            //
            // btnCambiarcantidad
            //
            btnCambiarcantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCambiarcantidad.Location = new Point(454, 399);
            btnCambiarcantidad.Name = "btnCambiarcantidad";
            btnCambiarcantidad.Size = new Size(115, 23);
            btnCambiarcantidad.TabIndex = 12;
            btnCambiarcantidad.Text = "Cambiar cantidad";
            btnCambiarcantidad.UseVisualStyleBackColor = true;
            btnCambiarcantidad.Click += btnCambiarcantidad_Click;
            //
            // btnRecargo
            //
            btnRecargo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRecargo.Location = new Point(173, 399);
            btnRecargo.Name = "btnRecargo";
            btnRecargo.Size = new Size(75, 23);
            btnRecargo.TabIndex = 11;
            btnRecargo.Text = "Recargo";
            btnRecargo.UseVisualStyleBackColor = true;
            //
            // btnDescuento
            //
            btnDescuento.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDescuento.Location = new Point(92, 399);
            btnDescuento.Name = "btnDescuento";
            btnDescuento.Size = new Size(75, 23);
            btnDescuento.TabIndex = 10;
            btnDescuento.Text = "Descuento";
            btnDescuento.UseVisualStyleBackColor = true;
            //
            // btnQuitar
            //
            btnQuitar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnQuitar.Location = new Point(11, 399);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(75, 23);
            btnQuitar.TabIndex = 9;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            //
            // pcbLogo
            //
            pcbLogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pcbLogo.Image = (Image)resources.GetObject("pcbLogo.Image");
            pcbLogo.Location = new Point(589, 320);
            pcbLogo.Name = "pcbLogo";
            pcbLogo.Size = new Size(270, 169);
            pcbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pcbLogo.TabIndex = 16;
            pcbLogo.TabStop = false;
            //
            // btnCobrar
            //
            btnCobrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCobrar.BackColor = Color.ForestGreen;
            btnCobrar.FlatStyle = FlatStyle.Flat;
            btnCobrar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCobrar.ForeColor = Color.White;
            btnCobrar.Location = new Point(586, 205);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(273, 45);
            btnCobrar.TabIndex = 2;
            btnCobrar.Text = "F2-Cobrar";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click_1;
            //
            // btnNuevaCompra
            //
            btnNuevaCompra.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNuevaCompra.BackColor = Color.ForestGreen;
            btnNuevaCompra.FlatStyle = FlatStyle.Flat;
            btnNuevaCompra.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevaCompra.ForeColor = SystemColors.Control;
            btnNuevaCompra.Location = new Point(586, 251);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(131, 45);
            btnNuevaCompra.TabIndex = 8;
            btnNuevaCompra.Text = "F4-Nueva Compra";
            btnNuevaCompra.UseVisualStyleBackColor = false;
            btnNuevaCompra.Click += btnNuevaCompra_Click;
            //
            // btnVerPrecio
            //
            btnVerPrecio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVerPrecio.BackColor = Color.ForestGreen;
            btnVerPrecio.FlatStyle = FlatStyle.Flat;
            btnVerPrecio.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerPrecio.ForeColor = SystemColors.Control;
            btnVerPrecio.Location = new Point(726, 251);
            btnVerPrecio.Name = "btnVerPrecio";
            btnVerPrecio.Size = new Size(133, 45);
            btnVerPrecio.TabIndex = 14;
            btnVerPrecio.Text = "F5-Ver Precio";
            btnVerPrecio.UseVisualStyleBackColor = false;
            //
            // lblTotalMonto
            //
            lblTotalMonto.AutoSize = true;
            lblTotalMonto.Dock = DockStyle.Fill;
            lblTotalMonto.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalMonto.ForeColor = Color.LawnGreen;
            lblTotalMonto.Location = new Point(139, 103);
            lblTotalMonto.Margin = new Padding(3, 5, 3, 5);
            lblTotalMonto.Name = "lblTotalMonto";
            lblTotalMonto.Size = new Size(131, 37);
            lblTotalMonto.TabIndex = 5;
            lblTotalMonto.Text = "$0000";
            lblTotalMonto.TextAlign = ContentAlignment.MiddleRight;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(3, 103);
            label5.Margin = new Padding(3, 5, 3, 5);
            label5.Name = "label5";
            label5.Size = new Size(130, 37);
            label5.TabIndex = 4;
            label5.Text = "Total";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblDescuentoMonto
            //
            lblDescuentoMonto.AutoSize = true;
            lblDescuentoMonto.Dock = DockStyle.Fill;
            lblDescuentoMonto.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescuentoMonto.ForeColor = SystemColors.ScrollBar;
            lblDescuentoMonto.Location = new Point(139, 54);
            lblDescuentoMonto.Margin = new Padding(3, 5, 3, 5);
            lblDescuentoMonto.Name = "lblDescuentoMonto";
            lblDescuentoMonto.Size = new Size(131, 39);
            lblDescuentoMonto.TabIndex = 3;
            lblDescuentoMonto.Text = "$0000";
            lblDescuentoMonto.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblSubtotalMonto
            //
            lblSubtotalMonto.AutoSize = true;
            lblSubtotalMonto.Dock = DockStyle.Fill;
            lblSubtotalMonto.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotalMonto.ForeColor = Color.LawnGreen;
            lblSubtotalMonto.Location = new Point(139, 5);
            lblSubtotalMonto.Margin = new Padding(3, 5, 3, 5);
            lblSubtotalMonto.Name = "lblSubtotalMonto";
            lblSubtotalMonto.Size = new Size(131, 39);
            lblSubtotalMonto.TabIndex = 2;
            lblSubtotalMonto.Text = "$0000";
            lblSubtotalMonto.TextAlign = ContentAlignment.MiddleRight;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ScrollBar;
            label2.Location = new Point(3, 54);
            label2.Margin = new Padding(3, 5, 3, 5);
            label2.Name = "label2";
            label2.Size = new Size(130, 39);
            label2.TabIndex = 1;
            label2.Text = "Descuento/Recargo";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(3, 5);
            label1.Margin = new Padding(3, 5, 3, 5);
            label1.Name = "label1";
            label1.Size = new Size(130, 39);
            label1.TabIndex = 0;
            label1.Text = "Subtotal";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.BackColor = Color.ForestGreen;
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 35);
            label3.Name = "label3";
            label3.Size = new Size(130, 15);
            label3.TabIndex = 3;
            label3.Text = "Código de barras           ";
            //
            // label4
            //
            label4.AutoSize = true;
            label4.BackColor = Color.ForestGreen;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(164, 35);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 4;
            label4.Text = "Cantidad    ";
            //
            // txtCodigoBarra
            //
            txtCodigoBarra.Location = new Point(12, 54);
            txtCodigoBarra.Name = "txtCodigoBarra";
            txtCodigoBarra.Size = new Size(130, 23);
            txtCodigoBarra.TabIndex = 5;
            txtCodigoBarra.KeyDown += txtCodigoBarra_KeyDown;
            //
            // txtCantidad
            //
            txtCantidad.Location = new Point(164, 54);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(67, 23);
            txtCantidad.TabIndex = 6;
            txtCantidad.KeyDown += txtCantidad_KeyDown;
            //
            // btnBuscarArticulo
            //
            btnBuscarArticulo.Image = (Image)resources.GetObject("btnBuscarArticulo.Image");
            btnBuscarArticulo.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscarArticulo.Location = new Point(265, 35);
            btnBuscarArticulo.Name = "btnBuscarArticulo";
            btnBuscarArticulo.Size = new Size(120, 42);
            btnBuscarArticulo.TabIndex = 15;
            btnBuscarArticulo.Text = "Buscar Articulo";
            btnBuscarArticulo.TextAlign = ContentAlignment.MiddleRight;
            btnBuscarArticulo.UseVisualStyleBackColor = true;
            btnBuscarArticulo.Click += btnBuscarArticulo_Click;
            //
            // dtgPresentacion
            //
            dtgPresentacion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgPresentacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgPresentacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgPresentacion.Columns.AddRange(new DataGridViewColumn[] { ClnSKU, ClnIdProducto, ClnCodigo, ClnDescripcion, ClnCantidad, ClnPrecioUnitario, ClnImporte });
            dtgPresentacion.Location = new Point(12, 83);
            dtgPresentacion.Name = "dtgPresentacion";
            dtgPresentacion.Size = new Size(557, 310);
            dtgPresentacion.TabIndex = 7;
            //
            // ClnSKU
            //
            ClnSKU.HeaderText = "SKU";
            ClnSKU.Name = "ClnSKU";
            //
            // ClnIdProducto
            //
            ClnIdProducto.HeaderText = "IdProducto";
            ClnIdProducto.Name = "ClnIdProducto";
            ClnIdProducto.ReadOnly = true;
            ClnIdProducto.Visible = false;
            //
            // ClnCodigo
            //
            ClnCodigo.HeaderText = "Código";
            ClnCodigo.Name = "ClnCodigo";
            //
            // ClnDescripcion
            //
            ClnDescripcion.HeaderText = "Descripción";
            ClnDescripcion.Name = "ClnDescripcion";
            //
            // ClnCantidad
            //
            ClnCantidad.HeaderText = "Cantidad";
            ClnCantidad.Name = "ClnCantidad";
            //
            // ClnPrecioUnitario
            //
            ClnPrecioUnitario.HeaderText = "Precio Unitario";
            ClnPrecioUnitario.Name = "ClnPrecioUnitario";
            //
            // ClnImporte
            //
            ClnImporte.HeaderText = "Importe";
            ClnImporte.Name = "ClnImporte";
            //
            // pnlUsuario
            //
            pnlUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlUsuario.BackColor = Color.Navy;
            pnlUsuario.BorderStyle = BorderStyle.Fixed3D;
            pnlUsuario.Controls.Add(lblHora);
            pnlUsuario.Controls.Add(lblFecha);
            pnlUsuario.Controls.Add(label7);
            pnlUsuario.Controls.Add(txtRol);
            pnlUsuario.Controls.Add(txtUsuario);
            pnlUsuario.Controls.Add(label6);
            pnlUsuario.ForeColor = Color.Transparent;
            pnlUsuario.Location = new Point(0, 495);
            pnlUsuario.Name = "pnlUsuario";
            pnlUsuario.Size = new Size(877, 38);
            pnlUsuario.TabIndex = 17;
            //
            // lblHora
            //
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHora.Location = new Point(703, 7);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(40, 15);
            lblHora.TabIndex = 5;
            lblHora.Text = "Hora: ";
            //
            // lblFecha
            //
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(549, 8);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(45, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha: ";
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(202, 10);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 3;
            label7.Text = "Rol :";
            //
            // txtRol
            //
            txtRol.Enabled = false;
            txtRol.Location = new Point(238, 8);
            txtRol.Name = "txtRol";
            txtRol.ReadOnly = true;
            txtRol.Size = new Size(100, 23);
            txtRol.TabIndex = 2;
            //
            // txtUsuario
            //
            txtUsuario.Enabled = false;
            txtUsuario.Location = new Point(65, 7);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.ReadOnly = true;
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 1;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(12, 10);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 0;
            label6.Text = "Usuario :";
            //
            // btnPromocion
            //
            btnPromocion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPromocion.Location = new Point(399, 428);
            btnPromocion.Name = "btnPromocion";
            btnPromocion.Size = new Size(170, 61);
            btnPromocion.TabIndex = 18;
            btnPromocion.Text = "Promociónes";
            btnPromocion.UseVisualStyleBackColor = true;
            btnPromocion.Click += btnPromocion_Click;
            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = SystemColors.ActiveCaptionText;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblSubtotalMonto, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDescuentoMonto, 1, 1);
            tableLayoutPanel1.Controls.Add(lblTotalMonto, 1, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Location = new Point(586, 54);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel1.Size = new Size(273, 145);
            tableLayoutPanel1.TabIndex = 19;
            //
            // btnArt
            //
            btnArt.DropDownItems.AddRange(new ToolStripItem[] { cargarArticuloNuevoToolStripMenuItem, menuitemAdmistradorarticulos, menuitemAdministradoarticulos, meniitemReporapida, cargaRapidaDePreciosToolStripMenuItem, cargarDeLasMarcasToolStripMenuItem, menuitemImporexcel, menuitemExporexcel });
            btnArt.Enabled = false;
            btnArt.Name = "btnArt";
            btnArt.Size = new Size(66, 20);
            btnArt.Text = "Artículos";
            //
            // cargarArticuloNuevoToolStripMenuItem
            //
            cargarArticuloNuevoToolStripMenuItem.Name = "cargarArticuloNuevoToolStripMenuItem";
            cargarArticuloNuevoToolStripMenuItem.Size = new Size(232, 22);
            cargarArticuloNuevoToolStripMenuItem.Text = "Cargar articulo nuevo";
            cargarArticuloNuevoToolStripMenuItem.Click += cargarArticuloNuevoToolStripMenuItem_Click;
            //
            // menuitemAdmistradorarticulos
            //
            menuitemAdmistradorarticulos.Name = "menuitemAdmistradorarticulos";
            menuitemAdmistradorarticulos.Size = new Size(232, 22);
            menuitemAdmistradorarticulos.Text = "Modificar artículo";
            menuitemAdmistradorarticulos.Click += menuitemAdmistradorarticulos_Click;
            //
            // menuitemAdministradoarticulos
            //
            menuitemAdministradoarticulos.Name = "menuitemAdministradoarticulos";
            menuitemAdministradoarticulos.Size = new Size(232, 22);
            menuitemAdministradoarticulos.Text = "Agregar categoria ";
            menuitemAdministradoarticulos.Click += menuitemAdministradoarticulos_Click;
            //
            // meniitemReporapida
            //
            meniitemReporapida.Name = "meniitemReporapida";
            meniitemReporapida.Size = new Size(232, 22);
            meniitemReporapida.Text = "Reposición rápida de stock";
            meniitemReporapida.Click += meniitemReporapida_Click;
            //
            // cargaRapidaDePreciosToolStripMenuItem
            //
            cargaRapidaDePreciosToolStripMenuItem.Name = "cargaRapidaDePreciosToolStripMenuItem";
            cargaRapidaDePreciosToolStripMenuItem.Size = new Size(232, 22);
            cargaRapidaDePreciosToolStripMenuItem.Text = "Carga Rapida de Precios";
            cargaRapidaDePreciosToolStripMenuItem.Click += cargaRapidaDePreciosToolStripMenuItem_Click;
            //
            // cargarDeLasMarcasToolStripMenuItem
            //
            cargarDeLasMarcasToolStripMenuItem.Name = "cargarDeLasMarcasToolStripMenuItem";
            cargarDeLasMarcasToolStripMenuItem.Size = new Size(232, 22);
            cargarDeLasMarcasToolStripMenuItem.Text = "Cargar de las marcas";
            cargarDeLasMarcasToolStripMenuItem.Click += cargarDeLasMarcasToolStripMenuItem_Click;
            //
            // menuitemImporexcel
            //
            menuitemImporexcel.Name = "menuitemImporexcel";
            menuitemImporexcel.Size = new Size(232, 22);
            menuitemImporexcel.Text = "Importar artículos desde Excel";
            menuitemImporexcel.Click += menuitemImporexcel_Click;
            //
            // menuitemExporexcel
            //
            menuitemExporexcel.Name = "menuitemExporexcel";
            menuitemExporexcel.Size = new Size(232, 22);
            menuitemExporexcel.Text = "Exportar artículos a Excel";
            menuitemExporexcel.Click += menuitemExporexcel_Click;
            //
            // btnVentas
            //
            btnVentas.DropDownItems.AddRange(new ToolStripItem[] { menuitemAdministradorventas, notaDeCreditoToolStripMenuItem });
            btnVentas.Enabled = false;
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(53, 20);
            btnVentas.Text = "Ventas";
            //
            // menuitemAdministradorventas
            //
            menuitemAdministradorventas.Name = "menuitemAdministradorventas";
            menuitemAdministradorventas.Size = new Size(203, 22);
            menuitemAdministradorventas.Text = "Administrador de Ventas";
            menuitemAdministradorventas.Click += menuitemAdministradorventas_Click;
            //
            // notaDeCreditoToolStripMenuItem
            //
            notaDeCreditoToolStripMenuItem.Name = "notaDeCreditoToolStripMenuItem";
            notaDeCreditoToolStripMenuItem.Size = new Size(203, 22);
            notaDeCreditoToolStripMenuItem.Text = "Devolución";
            notaDeCreditoToolStripMenuItem.Click += notaDeCreditoToolStripMenuItem_Click;
            //
            // btnCompras
            //
            btnCompras.DropDownItems.AddRange(new ToolStripItem[] { menuitemAministradorcompras });
            btnCompras.Enabled = false;
            btnCompras.Name = "btnCompras";
            btnCompras.Size = new Size(67, 20);
            btnCompras.Text = "Compras";
            //
            // menuitemAministradorcompras
            //
            menuitemAministradorcompras.Name = "menuitemAministradorcompras";
            menuitemAministradorcompras.Size = new Size(217, 22);
            menuitemAministradorcompras.Text = "Administrador de Compras";
            menuitemAministradorcompras.Click += menuitemAministradorcompras_Click;
            //
            // btnProve
            //
            btnProve.DropDownItems.AddRange(new ToolStripItem[] { administradorDeProveedoresToolStripMenuItem, cuentaCorrienteDeProveedoresToolStripMenuItem });
            btnProve.Enabled = false;
            btnProve.Name = "btnProve";
            btnProve.Size = new Size(84, 20);
            btnProve.Text = "Proveedores";
            //
            // administradorDeProveedoresToolStripMenuItem
            //
            administradorDeProveedoresToolStripMenuItem.Name = "administradorDeProveedoresToolStripMenuItem";
            administradorDeProveedoresToolStripMenuItem.Size = new Size(246, 22);
            administradorDeProveedoresToolStripMenuItem.Text = "Administrador de Proveedores";
            administradorDeProveedoresToolStripMenuItem.Click += administradorDeProveedoresToolStripMenuItem_Click;
            //
            // cuentaCorrienteDeProveedoresToolStripMenuItem
            //
            cuentaCorrienteDeProveedoresToolStripMenuItem.Name = "cuentaCorrienteDeProveedoresToolStripMenuItem";
            cuentaCorrienteDeProveedoresToolStripMenuItem.Size = new Size(246, 22);
            cuentaCorrienteDeProveedoresToolStripMenuItem.Text = "Cuenta corriente de Proveedores";
            cuentaCorrienteDeProveedoresToolStripMenuItem.Click += cuentaCorrienteDeProveedoresToolStripMenuItem_Click;
            //
            // toolStripMenuItem1
            //
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { listaDePreciosToolStripMenuItem, listadoDeReposiciónToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(62, 20);
            toolStripMenuItem1.Text = "Listados";
            //
            // listaDePreciosToolStripMenuItem
            //
            listaDePreciosToolStripMenuItem.Name = "listaDePreciosToolStripMenuItem";
            listaDePreciosToolStripMenuItem.Size = new Size(186, 22);
            listaDePreciosToolStripMenuItem.Text = "Lista de precios";
            listaDePreciosToolStripMenuItem.Click += listaDePreciosToolStripMenuItem_Click;
            //
            // listadoDeReposiciónToolStripMenuItem
            //
            listadoDeReposiciónToolStripMenuItem.Name = "listadoDeReposiciónToolStripMenuItem";
            listadoDeReposiciónToolStripMenuItem.Size = new Size(186, 22);
            listadoDeReposiciónToolStripMenuItem.Text = "Listado de reposición";
            listadoDeReposiciónToolStripMenuItem.Click += listadoDeReposiciónToolStripMenuItem_Click;
            //
            // btnInformes
            //
            btnInformes.DropDownItems.AddRange(new ToolStripItem[] { ventasPorDiaToolStripMenuItem, ventaToolStripMenuItem, ventaPorRubroToolStripMenuItem, ventaPorArticulosToolStripMenuItem, ventaPorMedioDePagoToolStripMenuItem, ajustesToolStripMenuItem });
            btnInformes.Enabled = false;
            btnInformes.Name = "btnInformes";
            btnInformes.Size = new Size(66, 20);
            btnInformes.Text = "Informes";
            //
            // ventasPorDiaToolStripMenuItem
            //
            ventasPorDiaToolStripMenuItem.Name = "ventasPorDiaToolStripMenuItem";
            ventasPorDiaToolStripMenuItem.Size = new Size(212, 22);
            ventasPorDiaToolStripMenuItem.Text = "Ventas por fecha";
            ventasPorDiaToolStripMenuItem.Click += ventasPorDiaToolStripMenuItem_Click_1;
            //
            // ventaToolStripMenuItem
            //
            ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            ventaToolStripMenuItem.Size = new Size(212, 22);
            ventaToolStripMenuItem.Text = "Venta con detalle de fecha";
            ventaToolStripMenuItem.Click += ventaToolStripMenuItem_Click;
            //
            // ventaPorRubroToolStripMenuItem
            //
            ventaPorRubroToolStripMenuItem.Name = "ventaPorRubroToolStripMenuItem";
            ventaPorRubroToolStripMenuItem.Size = new Size(212, 22);
            ventaPorRubroToolStripMenuItem.Text = "Venta por rubro";
            ventaPorRubroToolStripMenuItem.Click += ventaPorRubroToolStripMenuItem_Click;
            //
            // ventaPorArticulosToolStripMenuItem
            //
            ventaPorArticulosToolStripMenuItem.Name = "ventaPorArticulosToolStripMenuItem";
            ventaPorArticulosToolStripMenuItem.Size = new Size(212, 22);
            ventaPorArticulosToolStripMenuItem.Text = "Venta por articulos";
            ventaPorArticulosToolStripMenuItem.Click += ventaPorArticulosToolStripMenuItem_Click;
            //
            // ventaPorMedioDePagoToolStripMenuItem
            //
            ventaPorMedioDePagoToolStripMenuItem.Name = "ventaPorMedioDePagoToolStripMenuItem";
            ventaPorMedioDePagoToolStripMenuItem.Size = new Size(212, 22);
            ventaPorMedioDePagoToolStripMenuItem.Text = "Venta por medio de pago";
            ventaPorMedioDePagoToolStripMenuItem.Click += ventaPorMedioDePagoToolStripMenuItem_Click;
            //
            // ajustesToolStripMenuItem
            //
            ajustesToolStripMenuItem.Name = "ajustesToolStripMenuItem";
            ajustesToolStripMenuItem.Size = new Size(212, 22);
            ajustesToolStripMenuItem.Text = "Ajustes";
            //
            // btnCaja
            //
            btnCaja.DropDownItems.AddRange(new ToolStripItem[] { nuevoIngresoToolStripMenuItem, nuevoEgresoToolStripMenuItem, cerrarSeToolStripMenuItem, abrirCajaToolStripMenuItem });
            btnCaja.Enabled = false;
            btnCaja.Name = "btnCaja";
            btnCaja.Size = new Size(42, 20);
            btnCaja.Text = "Caja";
            //
            // nuevoIngresoToolStripMenuItem
            //
            nuevoIngresoToolStripMenuItem.Name = "nuevoIngresoToolStripMenuItem";
            nuevoIngresoToolStripMenuItem.Size = new Size(151, 22);
            nuevoIngresoToolStripMenuItem.Text = "Nuevo Ingreso";
            nuevoIngresoToolStripMenuItem.Click += nuevoIngresoToolStripMenuItem_Click;
            //
            // nuevoEgresoToolStripMenuItem
            //
            nuevoEgresoToolStripMenuItem.Name = "nuevoEgresoToolStripMenuItem";
            nuevoEgresoToolStripMenuItem.Size = new Size(151, 22);
            nuevoEgresoToolStripMenuItem.Text = "Nuevo Egreso";
            nuevoEgresoToolStripMenuItem.Click += nuevoEgresoToolStripMenuItem_Click;
            //
            // cerrarSeToolStripMenuItem
            //
            cerrarSeToolStripMenuItem.Name = "cerrarSeToolStripMenuItem";
            cerrarSeToolStripMenuItem.Size = new Size(151, 22);
            cerrarSeToolStripMenuItem.Text = "Cerrar caja";
            cerrarSeToolStripMenuItem.Click += cerrarSeToolStripMenuItem_Click;
            //
            // abrirCajaToolStripMenuItem
            //
            abrirCajaToolStripMenuItem.Name = "abrirCajaToolStripMenuItem";
            abrirCajaToolStripMenuItem.Size = new Size(151, 22);
            abrirCajaToolStripMenuItem.Text = "Abrir Caja";
            abrirCajaToolStripMenuItem.Click += abrirCajaToolStripMenuItem_Click;
            //
            // btnIdioma
            //
            btnIdioma.DropDownItems.AddRange(new ToolStripItem[] { inglesToolStripMenuItem, españolToolStripMenuItem });
            btnIdioma.Name = "btnIdioma";
            btnIdioma.Size = new Size(56, 20);
            btnIdioma.Text = "Idioma";
            //
            // inglesToolStripMenuItem
            //
            inglesToolStripMenuItem.Image = (Image)resources.GetObject("inglesToolStripMenuItem.Image");
            inglesToolStripMenuItem.Name = "inglesToolStripMenuItem";
            inglesToolStripMenuItem.Size = new Size(180, 22);
            inglesToolStripMenuItem.Text = "English";
            inglesToolStripMenuItem.Click += inglesToolStripMenuItem_Click;
            //
            // españolToolStripMenuItem
            //
            españolToolStripMenuItem.Image = (Image)resources.GetObject("españolToolStripMenuItem.Image");
            españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            españolToolStripMenuItem.Size = new Size(180, 22);
            españolToolStripMenuItem.Text = "Español";
            españolToolStripMenuItem.Click += españolToolStripMenuItem_Click;
            //
            // idiomaToolStripMenuItem
            //
            idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            idiomaToolStripMenuItem.Size = new Size(32, 19);
            //
            // btnEmpleado
            //
            btnEmpleado.DropDownItems.AddRange(new ToolStripItem[] { gestioToolStripMenuItem, permisosToolStripMenuItem, bitacoraToolStripMenuItem });
            btnEmpleado.Enabled = false;
            btnEmpleado.Name = "btnEmpleado";
            btnEmpleado.Size = new Size(72, 20);
            btnEmpleado.Text = "Empleado";
            //
            // gestioToolStripMenuItem
            //
            gestioToolStripMenuItem.Name = "gestioToolStripMenuItem";
            gestioToolStripMenuItem.Size = new Size(180, 22);
            gestioToolStripMenuItem.Text = "Gestión de Backup";
            gestioToolStripMenuItem.Click += gestioToolStripMenuItem_Click;
            //
            // permisosToolStripMenuItem
            //
            permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            permisosToolStripMenuItem.Size = new Size(180, 22);
            permisosToolStripMenuItem.Text = "Empleado";
            permisosToolStripMenuItem.Click += permisosToolStripMenuItem_Click;
            //
            // bitacoraToolStripMenuItem
            //
            bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            bitacoraToolStripMenuItem.Size = new Size(180, 22);
            bitacoraToolStripMenuItem.Text = "Bitacora";
            bitacoraToolStripMenuItem.Click += bitacoraToolStripMenuItem_Click;
            //
            // tollClosed
            //
            tollClosed.Image = (Image)resources.GetObject("tollClosed.Image");
            tollClosed.Name = "tollClosed";
            tollClosed.Size = new Size(28, 20);
            tollClosed.Click += tollClosed_Click;
            //
            // btnConfig
            //
            btnConfig.Items.AddRange(new ToolStripItem[] { btnArt, toolStripMenuItem2, btnVentas, btnCompras, btnProve, toolStripMenuItem1, btnInformes, btnCaja, btnIdioma, btnEmpleado, tollClosed });
            btnConfig.Location = new Point(0, 0);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(877, 24);
            btnConfig.TabIndex = 0;
            btnConfig.Text = "menuStrip1";
            btnConfig.ItemClicked += btnConfig_ItemClicked;
            //
            // toolStripMenuItem2
            //
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { administrarPromocionesToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(89, 20);
            toolStripMenuItem2.Text = "Promociones";
            //
            // administrarPromocionesToolStripMenuItem
            //
            administrarPromocionesToolStripMenuItem.Name = "administrarPromocionesToolStripMenuItem";
            administrarPromocionesToolStripMenuItem.Size = new Size(209, 22);
            administrarPromocionesToolStripMenuItem.Text = "Administrar Promociones";
            administrarPromocionesToolStripMenuItem.Click += administrarPromocionesToolStripMenuItem_Click;
            //
            // frmmenuPres
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 532);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnPromocion);
            Controls.Add(pnlUsuario);
            Controls.Add(dtgPresentacion);
            Controls.Add(btnBuscarArticulo);
            Controls.Add(txtCantidad);
            Controls.Add(txtCodigoBarra);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pcbLogo);
            Controls.Add(btnVerPrecio);
            Controls.Add(btnNuevaCompra);
            Controls.Add(btnCobrar);
            Controls.Add(btnCambiarcantidad);
            Controls.Add(btnRecargo);
            Controls.Add(btnDescuento);
            Controls.Add(btnQuitar);
            Controls.Add(btnConfig);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = btnConfig;
            Name = "frmmenuPres";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Presentación";
            ((System.ComponentModel.ISupportInitialize)pcbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgPresentacion).EndInit();
            pnlUsuario.ResumeLayout(false);
            pnlUsuario.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            btnConfig.ResumeLayout(false);
            btnConfig.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCambiarcantidad;
        private Button btnRecargo;
        private Button btnDescuento;
        private Button btnQuitar;
        private PictureBox pcbLogo;
        private Button btnCobrar;
        private Button btnNuevaCompra;
        private Button btnVerPrecio;
        private Label lblTotalMonto;
        private Label label5;
        private Label lblDescuentoMonto;
        private Label lblSubtotalMonto;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox txtCodigoBarra;
        private TextBox txtCantidad;
        private Button btnBuscarArticulo;
        private DataGridView dtgPresentacion;
        private Panel pnlUsuario;
        private Label label7;
        private TextBox txtRol;
        private TextBox txtUsuario;
        private Label label6;
        private Button btnPromocion;
        private ToolTip toolTip1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn ClnSKU;
        private DataGridViewTextBoxColumn ClnIdProducto;
        private DataGridViewTextBoxColumn ClnCodigo;
        private DataGridViewTextBoxColumn ClnDescripcion;
        private DataGridViewTextBoxColumn ClnCantidad;
        private DataGridViewTextBoxColumn ClnPrecioUnitario;
        private DataGridViewTextBoxColumn ClnImporte;
        private Label lblHora;
        private Label lblFecha;
        private System.Windows.Forms.Timer tmrFechaHora;
        private ToolStripMenuItem btnArt;
        private ToolStripMenuItem menuitemAdmistradorarticulos;
        private ToolStripMenuItem menuitemAdministradoarticulos;
        private ToolStripMenuItem meniitemReporapida;
        private ToolStripMenuItem cargarDeLasMarcasToolStripMenuItem;
        private ToolStripMenuItem menuitemImporexcel;
        private ToolStripMenuItem menuitemExporexcel;
        private ToolStripMenuItem btnVentas;
        private ToolStripMenuItem menuitemAdministradorventas;
        private ToolStripMenuItem notaDeCreditoToolStripMenuItem;
        private ToolStripMenuItem btnCompras;
        private ToolStripMenuItem menuitemAministradorcompras;
        private ToolStripMenuItem btnProve;
        private ToolStripMenuItem administradorDeProveedoresToolStripMenuItem;
        private ToolStripMenuItem cuentaCorrienteDeProveedoresToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem listaDePreciosToolStripMenuItem;
        private ToolStripMenuItem listadoDeReposiciónToolStripMenuItem;
        private ToolStripMenuItem btnInformes;
        private ToolStripMenuItem ventasPorDiaToolStripMenuItem;
        private ToolStripMenuItem ventaToolStripMenuItem;
        private ToolStripMenuItem ventaPorRubroToolStripMenuItem;
        private ToolStripMenuItem ventaPorArticulosToolStripMenuItem;
        private ToolStripMenuItem ventaPorMedioDePagoToolStripMenuItem;
        private ToolStripMenuItem btnCaja;
        private ToolStripMenuItem nuevoIngresoToolStripMenuItem;
        private ToolStripMenuItem nuevoEgresoToolStripMenuItem;
        private ToolStripMenuItem cerrarSeToolStripMenuItem;
        private ToolStripMenuItem abrirCajaToolStripMenuItem;
        private ToolStripMenuItem btnIdioma;
        private ToolStripMenuItem idiomaToolStripMenuItem;
        private ToolStripMenuItem inglesToolStripMenuItem;
        private ToolStripMenuItem btnEmpleado;
        private ToolStripMenuItem permisosToolStripMenuItem;
        private ToolStripMenuItem tollClosed;
        private MenuStrip btnConfig;
        private ToolStripMenuItem cargaRapidaDePreciosToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem administrarPromocionesToolStripMenuItem;

        private ToolStripMenuItem ajustesToolStripMenuItem;
        private ToolStripMenuItem gestioToolStripMenuItem;

        private ToolStripMenuItem cargarArticuloNuevoToolStripMenuItem;
        private ToolStripMenuItem bitacoraToolStripMenuItem;
        private ToolStripMenuItem españolToolStripMenuItem;
    }
}