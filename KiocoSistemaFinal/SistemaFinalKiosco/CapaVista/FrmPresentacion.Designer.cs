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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmenuPres));
            btnArt = new ToolStripMenuItem();
            menuitemAdmistradorarticulos = new ToolStripMenuItem();
            menuitemAdministradoarticulos = new ToolStripMenuItem();
            meniitemReporapida = new ToolStripMenuItem();
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
            btnInformes = new ToolStripMenuItem();
            ventasPorDiaToolStripMenuItem = new ToolStripMenuItem();
            ventaToolStripMenuItem = new ToolStripMenuItem();
            ventaPorRubroToolStripMenuItem = new ToolStripMenuItem();
            ventaPorArticulosToolStripMenuItem = new ToolStripMenuItem();
            ventaPorMedioDePagoToolStripMenuItem = new ToolStripMenuItem();
            btnHerra = new ToolStripMenuItem();
            idiomaToolStripMenuItem = new ToolStripMenuItem();
            inglesToolStripMenuItem = new ToolStripMenuItem();
            btnCaja = new ToolStripMenuItem();
            nuevoIngresoToolStripMenuItem = new ToolStripMenuItem();
            nuevoEgresoToolStripMenuItem = new ToolStripMenuItem();
            cerrarSeToolStripMenuItem = new ToolStripMenuItem();
            abrirCajaToolStripMenuItem = new ToolStripMenuItem();
            btnAyuda = new ToolStripMenuItem();
            btnAjustes = new ToolStripMenuItem();
            permisosToolStripMenuItem = new ToolStripMenuItem();
            btnConfig = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            listaDePreciosToolStripMenuItem = new ToolStripMenuItem();
            listadoDeReposiciónToolStripMenuItem = new ToolStripMenuItem();
            tollClosed = new ToolStripMenuItem();
            btnCambiarcantidad = new Button();
            btnCambiarprecio = new Button();
            btnRecargo = new Button();
            btnDescuento = new Button();
            btnQuitar = new Button();
            pcbLogo = new PictureBox();
            btnCobrar = new Button();
            btnNuevaCompra = new Button();
            btnVerPrecio = new Button();
            panel1 = new Panel();
            lblTotalMonto = new Label();
            label5 = new Label();
            lblDescuentoMonto = new Label();
            lblSubtotalMonto = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnBuscarArticulo = new Button();
            dataGridView1 = new DataGridView();
            ClnNum = new DataGridViewTextBoxColumn();
            ClnCodigo = new DataGridViewTextBoxColumn();
            ClnDescripcion = new DataGridViewTextBoxColumn();
            ClnCantidad = new DataGridViewTextBoxColumn();
            ClnPrecioUnitario = new DataGridViewTextBoxColumn();
            ClnImporte = new DataGridViewTextBoxColumn();
            pnlUsuario = new Panel();
            label7 = new Label();
            txtRol = new TextBox();
            txtUsuario = new TextBox();
            label6 = new Label();
            btnPromocion = new Button();
            toolTip1 = new ToolTip(components);
            cargarDeLasMarcasToolStripMenuItem = new ToolStripMenuItem();
            btnConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbLogo).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // btnArt
            // 
            btnArt.DropDownItems.AddRange(new ToolStripItem[] { menuitemAdmistradorarticulos, menuitemAdministradoarticulos, meniitemReporapida, cargarDeLasMarcasToolStripMenuItem, menuitemImporexcel, menuitemExporexcel });
            btnArt.Enabled = false;
            btnArt.Name = "btnArt";
            btnArt.Size = new Size(66, 20);
            btnArt.Text = "Artículos";
            // 
            // menuitemAdmistradorarticulos
            // 
            menuitemAdmistradorarticulos.Name = "menuitemAdmistradorarticulos";
            menuitemAdmistradorarticulos.Size = new Size(232, 22);
            menuitemAdmistradorarticulos.Text = "Admistrador de artículos";
            menuitemAdmistradorarticulos.Click += menuitemAdmistradorarticulos_Click;
            // 
            // menuitemAdministradoarticulos
            // 
            menuitemAdministradoarticulos.Name = "menuitemAdministradoarticulos";
            menuitemAdministradoarticulos.Size = new Size(232, 22);
            menuitemAdministradoarticulos.Text = "Administrador de rubros";
            menuitemAdministradoarticulos.Click += menuitemAdministradoarticulos_Click;
            // 
            // meniitemReporapida
            // 
            meniitemReporapida.Name = "meniitemReporapida";
            meniitemReporapida.Size = new Size(232, 22);
            meniitemReporapida.Text = "Reposición rápida de stock";
            meniitemReporapida.Click += meniitemReporapida_Click;
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
            // btnInformes
            // 
            btnInformes.DropDownItems.AddRange(new ToolStripItem[] { ventasPorDiaToolStripMenuItem, ventaToolStripMenuItem, ventaPorRubroToolStripMenuItem, ventaPorArticulosToolStripMenuItem, ventaPorMedioDePagoToolStripMenuItem });
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
            // btnHerra
            // 
            btnHerra.DropDownItems.AddRange(new ToolStripItem[] { idiomaToolStripMenuItem });
            btnHerra.Enabled = false;
            btnHerra.Name = "btnHerra";
            btnHerra.Size = new Size(57, 20);
            btnHerra.Text = "Ajustes";
            // 
            // idiomaToolStripMenuItem
            // 
            idiomaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inglesToolStripMenuItem });
            idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            idiomaToolStripMenuItem.Size = new Size(180, 22);
            idiomaToolStripMenuItem.Text = "Idioma";
            // 
            // inglesToolStripMenuItem
            // 
            inglesToolStripMenuItem.Name = "inglesToolStripMenuItem";
            inglesToolStripMenuItem.Size = new Size(105, 22);
            inglesToolStripMenuItem.Text = "Ingles";
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
            nuevoIngresoToolStripMenuItem.Size = new Size(180, 22);
            nuevoIngresoToolStripMenuItem.Text = "Nuevo Ingreso";
            nuevoIngresoToolStripMenuItem.Click += nuevoIngresoToolStripMenuItem_Click;
            // 
            // nuevoEgresoToolStripMenuItem
            // 
            nuevoEgresoToolStripMenuItem.Name = "nuevoEgresoToolStripMenuItem";
            nuevoEgresoToolStripMenuItem.Size = new Size(180, 22);
            nuevoEgresoToolStripMenuItem.Text = "Nuevo Egreso";
            nuevoEgresoToolStripMenuItem.Click += nuevoEgresoToolStripMenuItem_Click;
            // 
            // cerrarSeToolStripMenuItem
            // 
            cerrarSeToolStripMenuItem.Name = "cerrarSeToolStripMenuItem";
            cerrarSeToolStripMenuItem.Size = new Size(180, 22);
            cerrarSeToolStripMenuItem.Text = "Cerrar caja";
            cerrarSeToolStripMenuItem.Click += cerrarSeToolStripMenuItem_Click;
            // 
            // abrirCajaToolStripMenuItem
            // 
            abrirCajaToolStripMenuItem.Name = "abrirCajaToolStripMenuItem";
            abrirCajaToolStripMenuItem.Size = new Size(180, 22);
            abrirCajaToolStripMenuItem.Text = "Abrir Caja";
            abrirCajaToolStripMenuItem.Click += abrirCajaToolStripMenuItem_Click;
            // 
            // btnAyuda
            // 
            btnAyuda.Enabled = false;
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(53, 20);
            btnAyuda.Text = "Ayuda";
            // 
            // btnAjustes
            // 
            btnAjustes.DropDownItems.AddRange(new ToolStripItem[] { permisosToolStripMenuItem });
            btnAjustes.Enabled = false;
            btnAjustes.Name = "btnAjustes";
            btnAjustes.Size = new Size(72, 20);
            btnAjustes.Text = "Empleado";
            // 
            // permisosToolStripMenuItem
            // 
            permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            permisosToolStripMenuItem.Size = new Size(127, 22);
            permisosToolStripMenuItem.Text = "Empleado";
            permisosToolStripMenuItem.Click += permisosToolStripMenuItem_Click;
            // 
            // btnConfig
            // 
            btnConfig.Items.AddRange(new ToolStripItem[] { btnArt, btnVentas, btnCompras, btnProve, toolStripMenuItem1, btnInformes, btnCaja, btnHerra, btnAyuda, btnAjustes, tollClosed });
            btnConfig.Location = new Point(0, 0);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(877, 24);
            btnConfig.TabIndex = 0;
            btnConfig.Text = "menuStrip1";
            btnConfig.ItemClicked += btnConfig_ItemClicked;
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
            // tollClosed
            // 
            tollClosed.Image = (Image)resources.GetObject("tollClosed.Image");
            tollClosed.Name = "tollClosed";
            tollClosed.Size = new Size(28, 20);
            tollClosed.Click += tollClosed_Click;
            // 
            // btnCambiarcantidad
            // 
            btnCambiarcantidad.Location = new Point(333, 315);
            btnCambiarcantidad.Name = "btnCambiarcantidad";
            btnCambiarcantidad.Size = new Size(115, 23);
            btnCambiarcantidad.TabIndex = 12;
            btnCambiarcantidad.Text = "Cambiar cantidad";
            btnCambiarcantidad.UseVisualStyleBackColor = true;
            // 
            // btnCambiarprecio
            // 
            btnCambiarprecio.Location = new Point(454, 315);
            btnCambiarprecio.Name = "btnCambiarprecio";
            btnCambiarprecio.Size = new Size(115, 23);
            btnCambiarprecio.TabIndex = 13;
            btnCambiarprecio.Text = "Cambiar precio";
            btnCambiarprecio.UseVisualStyleBackColor = true;
            // 
            // btnRecargo
            // 
            btnRecargo.Location = new Point(174, 315);
            btnRecargo.Name = "btnRecargo";
            btnRecargo.Size = new Size(75, 23);
            btnRecargo.TabIndex = 11;
            btnRecargo.Text = "Recargo";
            btnRecargo.UseVisualStyleBackColor = true;
            // 
            // btnDescuento
            // 
            btnDescuento.Location = new Point(93, 315);
            btnDescuento.Name = "btnDescuento";
            btnDescuento.Size = new Size(75, 23);
            btnDescuento.TabIndex = 10;
            btnDescuento.Text = "Descuento";
            btnDescuento.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(12, 315);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(75, 23);
            btnQuitar.TabIndex = 9;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // pcbLogo
            // 
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
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(lblTotalMonto);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblDescuentoMonto);
            panel1.Controls.Add(lblSubtotalMonto);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(587, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 140);
            panel1.TabIndex = 1;
            // 
            // lblTotalMonto
            // 
            lblTotalMonto.AutoSize = true;
            lblTotalMonto.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalMonto.ForeColor = Color.LawnGreen;
            lblTotalMonto.Location = new Point(146, 88);
            lblTotalMonto.Name = "lblTotalMonto";
            lblTotalMonto.Size = new Size(105, 45);
            lblTotalMonto.TabIndex = 5;
            lblTotalMonto.Text = "label6";
            lblTotalMonto.TextAlign = ContentAlignment.BottomRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(3, 96);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 4;
            label5.Text = "Total";
            // 
            // lblDescuentoMonto
            // 
            lblDescuentoMonto.AutoSize = true;
            lblDescuentoMonto.ForeColor = SystemColors.ScrollBar;
            lblDescuentoMonto.Location = new Point(213, 40);
            lblDescuentoMonto.Name = "lblDescuentoMonto";
            lblDescuentoMonto.Size = new Size(38, 15);
            lblDescuentoMonto.TabIndex = 3;
            lblDescuentoMonto.Text = "label4";
            lblDescuentoMonto.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtotalMonto
            // 
            lblSubtotalMonto.AutoSize = true;
            lblSubtotalMonto.ForeColor = Color.LawnGreen;
            lblSubtotalMonto.Location = new Point(213, 18);
            lblSubtotalMonto.Name = "lblSubtotalMonto";
            lblSubtotalMonto.Size = new Size(38, 15);
            lblSubtotalMonto.TabIndex = 2;
            lblSubtotalMonto.Text = "label3";
            lblSubtotalMonto.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ScrollBar;
            label2.Location = new Point(0, 40);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 1;
            label2.Text = "Descuento/Recargo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(0, 12);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 0;
            label1.Text = "Subtotal";
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
            // textBox1
            // 
            textBox1.Location = new Point(12, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(130, 23);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(164, 54);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(67, 23);
            textBox2.TabIndex = 6;
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
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ClnNum, ClnCodigo, ClnDescripcion, ClnCantidad, ClnPrecioUnitario, ClnImporte });
            dataGridView1.Location = new Point(12, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(557, 213);
            dataGridView1.TabIndex = 7;
            // 
            // ClnNum
            // 
            ClnNum.HeaderText = "#";
            ClnNum.Name = "ClnNum";
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
            pnlUsuario.BackColor = Color.Navy;
            pnlUsuario.BorderStyle = BorderStyle.Fixed3D;
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
            btnPromocion.Location = new Point(12, 365);
            btnPromocion.Name = "btnPromocion";
            btnPromocion.Size = new Size(170, 61);
            btnPromocion.TabIndex = 18;
            btnPromocion.Text = "Promociónes";
            btnPromocion.UseVisualStyleBackColor = true;
            btnPromocion.Click += btnPromocion_Click;
            // 
            // cargarDeLasMarcasToolStripMenuItem
            // 
            cargarDeLasMarcasToolStripMenuItem.Name = "cargarDeLasMarcasToolStripMenuItem";
            cargarDeLasMarcasToolStripMenuItem.Size = new Size(232, 22);
            cargarDeLasMarcasToolStripMenuItem.Text = "Cargar de las marcas";
            cargarDeLasMarcasToolStripMenuItem.Click += cargarDeLasMarcasToolStripMenuItem_Click;
            // 
            // frmmenuPres
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 532);
            Controls.Add(btnPromocion);
            Controls.Add(pnlUsuario);
            Controls.Add(dataGridView1);
            Controls.Add(btnBuscarArticulo);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pcbLogo);
            Controls.Add(btnVerPrecio);
            Controls.Add(btnNuevaCompra);
            Controls.Add(btnCobrar);
            Controls.Add(panel1);
            Controls.Add(btnCambiarcantidad);
            Controls.Add(btnCambiarprecio);
            Controls.Add(btnRecargo);
            Controls.Add(btnDescuento);
            Controls.Add(btnQuitar);
            Controls.Add(btnConfig);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = btnConfig;
            Name = "frmmenuPres";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Presentación";
            btnConfig.ResumeLayout(false);
            btnConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcbLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlUsuario.ResumeLayout(false);
            pnlUsuario.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem btnArt;
        private ToolStripMenuItem btnVentas;
        private ToolStripMenuItem btnCompras;
        private ToolStripMenuItem btnProve;
        private ToolStripMenuItem btnInformes;
        private ToolStripMenuItem btnHerra;
        private ToolStripMenuItem btnCaja;
        private ToolStripMenuItem cerrarSeToolStripMenuItem;
        private ToolStripMenuItem btnAyuda;
        private ToolStripMenuItem btnAjustes;
        private ToolStripMenuItem permisosToolStripMenuItem;
        private MenuStrip btnConfig;
        private ToolStripMenuItem menuitemAdministradorventas;
        private ToolStripMenuItem menuitemAministradorcompras;
        private ToolStripMenuItem menuitemAdmistradorarticulos;
        private ToolStripMenuItem menuitemAdministradoarticulos;
        private ToolStripMenuItem meniitemReporapida;
        private ToolStripMenuItem menuitemImporexcel;
        private ToolStripMenuItem menuitemExporexcel;
        private ToolStripMenuItem notaDeCreditoToolStripMenuItem;
        private ToolStripMenuItem administradorDeProveedoresToolStripMenuItem;
        private Button btnCambiarcantidad;
        private Button btnCambiarprecio;
        private Button btnRecargo;
        private Button btnDescuento;
        private Button btnQuitar;
        private PictureBox pcbLogo;
        private Button btnCobrar;
        private Button btnNuevaCompra;
        private Button btnVerPrecio;
        private Panel panel1;
        private Label lblTotalMonto;
        private Label label5;
        private Label lblDescuentoMonto;
        private Label lblSubtotalMonto;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnBuscarArticulo;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ClnNum;
        private DataGridViewTextBoxColumn ClnCodigo;
        private DataGridViewTextBoxColumn ClnDescripcion;
        private DataGridViewTextBoxColumn ClnCantidad;
        private DataGridViewTextBoxColumn ClnPrecioUnitario;
        private DataGridViewTextBoxColumn ClnImporte;
        private ToolStripMenuItem ventasPorDiaToolStripMenuItem;
        private ToolStripMenuItem ventaToolStripMenuItem;
        private ToolStripMenuItem ventaPorRubroToolStripMenuItem;
        private ToolStripMenuItem ventaPorArticulosToolStripMenuItem;
        private ToolStripMenuItem ventaPorMedioDePagoToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem listaDePreciosToolStripMenuItem;
        private ToolStripMenuItem listadoDeReposiciónToolStripMenuItem;
        private ToolStripMenuItem cuentaCorrienteDeProveedoresToolStripMenuItem;
        private ToolStripMenuItem nuevoIngresoToolStripMenuItem;
        private ToolStripMenuItem nuevoEgresoToolStripMenuItem;
        private Panel pnlUsuario;
        private Label label7;
        private TextBox txtRol;
        private TextBox txtUsuario;
        private Label label6;
        private Button btnPromocion;
        private ToolStripMenuItem idiomaToolStripMenuItem;
        private ToolStripMenuItem inglesToolStripMenuItem;
        private ToolStripMenuItem abrirCajaToolStripMenuItem;
        private ToolStripMenuItem tollClosed;
        private ToolTip toolTip1;
        private ToolStripMenuItem cargarDeLasMarcasToolStripMenuItem;
    }
}