
namespace CapaVista
{
    partial class frmNuevaCompra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ttAyuda = new ToolTip(components);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaCompra));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label8 = new Label();
            label9 = new Label();
            labelNumeroComprobante = new Label();
            gpbProveedor = new GroupBox();
            btnBuscar = new Button();
            txtProveedor = new TextBox();
            lblSucursal = new Label();
            cmbSucursal = new ComboBox();
            lstProveedores = new ListBox();
            gpbPedido = new GroupBox();
            labelNumeroPedido = new Label();
            txtNumeroPedidoInterno = new TextBox();
            dtpFechaPedido = new DateTimePicker();
            labelFechaEntrega = new Label();
            dtpEntrega = new DateTimePicker();
            labelEstadoPedido = new Label();
            lblEstadoPedido = new Label();
            gpbComprobante = new GroupBox();
            cmbTipoComprobante = new ComboBox();
            txtNumeroComprobante = new TextBox();
            gpbProductos = new GroupBox();
            txtCodigobarra = new TextBox();
            btnCargarProducto = new Button();
            lstProductos = new ListBox();
            dtgNuevaCompra = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnEliminarCompra = new Button();
            gpbTotales = new GroupBox();
            txtTotal = new TextBox();
            txtIva = new TextBox();
            txtSubsinImpuesto = new TextBox();
            txtObservaciones = new TextBox();
            btnGuardar = new Button();
            btnCacelar = new Button();
            grpCondicionPago = new GroupBox();
            dtpVencimiento = new DateTimePicker();
            lblVencimiento = new Label();
            chkPagaDesdeCaja = new CheckBox();
            cmbMedioPagoCompra = new ComboBox();
            lblMedioPagoCompra = new Label();
            cmbCondicionPago = new ComboBox();
            lblCondicionPago = new Label();
            gpbProveedor.SuspendLayout();
            gpbPedido.SuspendLayout();
            gpbComprobante.SuspendLayout();
            gpbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgNuevaCompra).BeginInit();
            gpbTotales.SuspendLayout();
            grpCondicionPago.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 20);
            label1.Name = "label1";
            label1.Size = new Size(250, 15);
            label1.TabIndex = 0;
            label1.Text = "Código de barras / nombre de producto / SKU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 24);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 0;
            label2.Text = "Tipo de comprobante";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(145, 20);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 2;
            label3.Text = "Fecha del pedido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.Location = new Point(12, 530);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 5;
            label4.Text = "Observaciones";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(445, 24);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 4;
            label5.Text = "Subtotal sin IVA";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(230, 24);
            label8.Name = "label8";
            label8.Size = new Size(24, 15);
            label8.TabIndex = 2;
            label8.Text = "IVA";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 24);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 0;
            label9.Text = "Total";
            // 
            // labelNumeroComprobante
            // 
            labelNumeroComprobante.AutoSize = true;
            labelNumeroComprobante.Location = new Point(360, 24);
            labelNumeroComprobante.Name = "labelNumeroComprobante";
            labelNumeroComprobante.Size = new Size(115, 15);
            labelNumeroComprobante.TabIndex = 3;
            labelNumeroComprobante.Text = "N.º de comprobante";
            // 
            // gpbProveedor
            // 
            gpbProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gpbProveedor.Controls.Add(btnBuscar);
            gpbProveedor.Controls.Add(txtProveedor);
            gpbProveedor.Controls.Add(lblSucursal);
            gpbProveedor.Controls.Add(cmbSucursal);
            gpbProveedor.Location = new Point(540, 8);
            gpbProveedor.Name = "gpbProveedor";
            gpbProveedor.Size = new Size(348, 78);
            gpbProveedor.TabIndex = 1;
            gpbProveedor.TabStop = false;
            gpbProveedor.Text = "Proveedor";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(232, 19);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(104, 25);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(12, 20);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.PlaceholderText = "Escribí el nombre o CUIT y elegilo de la lista";
            txtProveedor.Size = new Size(214, 23);
            txtProveedor.TabIndex = 0;
            txtProveedor.TextChanged += txtProveedor_TextChanged;
            txtProveedor.DoubleClick += txtProveedor_DoubleClick;
            txtProveedor.KeyDown += txtProveedor_KeyDown;
            //
            // lblSucursal
            //
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(12, 52);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(54, 15);
            lblSucursal.TabIndex = 2;
            lblSucursal.Text = "Sucursal:";
            //
            // cmbSucursal
            //
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursal.Enabled = false;
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(75, 48);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(261, 23);
            cmbSucursal.TabIndex = 3;
            //
            // lstProveedores
            //
            lstProveedores.FormattingEnabled = true;
            lstProveedores.IntegralHeight = false;
            lstProveedores.ItemHeight = 15;
            lstProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstProveedores.Location = new Point(552, 51);
            lstProveedores.Name = "lstProveedores";
            lstProveedores.Size = new Size(214, 100);
            lstProveedores.TabIndex = 9;
            lstProveedores.Visible = false;
            lstProveedores.DoubleClick += lstProveedores_DoubleClick;
            lstProveedores.KeyDown += lstProveedores_KeyDown;
            // 
            // gpbPedido
            // 
            gpbPedido.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbPedido.Controls.Add(labelNumeroPedido);
            gpbPedido.Controls.Add(txtNumeroPedidoInterno);
            gpbPedido.Controls.Add(label3);
            gpbPedido.Controls.Add(dtpFechaPedido);
            gpbPedido.Controls.Add(labelFechaEntrega);
            gpbPedido.Controls.Add(dtpEntrega);
            gpbPedido.Controls.Add(labelEstadoPedido);
            gpbPedido.Controls.Add(lblEstadoPedido);
            gpbPedido.Location = new Point(12, 8);
            gpbPedido.Name = "gpbPedido";
            gpbPedido.Size = new Size(520, 78);
            gpbPedido.TabIndex = 0;
            gpbPedido.TabStop = false;
            gpbPedido.Text = "Datos del pedido";
            // 
            // labelNumeroPedido
            // 
            labelNumeroPedido.AutoSize = true;
            labelNumeroPedido.Location = new Point(14, 20);
            labelNumeroPedido.Name = "labelNumeroPedido";
            labelNumeroPedido.Size = new Size(105, 15);
            labelNumeroPedido.TabIndex = 0;
            labelNumeroPedido.Text = "N.º interno pedido";
            // 
            // txtNumeroPedidoInterno
            // 
            txtNumeroPedidoInterno.Location = new Point(14, 40);
            txtNumeroPedidoInterno.Name = "txtNumeroPedidoInterno";
            txtNumeroPedidoInterno.ReadOnly = true;
            txtNumeroPedidoInterno.Size = new Size(120, 23);
            txtNumeroPedidoInterno.TabIndex = 1;
            txtNumeroPedidoInterno.TabStop = false;
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Format = DateTimePickerFormat.Short;
            dtpFechaPedido.Location = new Point(145, 40);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(120, 23);
            dtpFechaPedido.TabIndex = 3;
            // 
            // labelFechaEntrega
            // 
            labelFechaEntrega.AutoSize = true;
            labelFechaEntrega.Location = new Point(275, 20);
            labelFechaEntrega.Name = "labelFechaEntrega";
            labelFechaEntrega.Size = new Size(98, 15);
            labelFechaEntrega.TabIndex = 4;
            labelFechaEntrega.Text = "Entrega estimada";
            // 
            // dtpEntrega
            // 
            dtpEntrega.Checked = false;
            dtpEntrega.Format = DateTimePickerFormat.Short;
            dtpEntrega.Location = new Point(275, 40);
            dtpEntrega.Name = "dtpEntrega";
            dtpEntrega.ShowCheckBox = true;
            dtpEntrega.Size = new Size(120, 23);
            dtpEntrega.TabIndex = 5;
            // 
            // labelEstadoPedido
            // 
            labelEstadoPedido.AutoSize = true;
            labelEstadoPedido.Location = new Point(410, 20);
            labelEstadoPedido.Name = "labelEstadoPedido";
            labelEstadoPedido.Size = new Size(42, 15);
            labelEstadoPedido.TabIndex = 6;
            labelEstadoPedido.Text = "Estado";
            // 
            // lblEstadoPedido
            // 
            lblEstadoPedido.AutoSize = true;
            lblEstadoPedido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoPedido.ForeColor = Color.DarkGoldenrod;
            lblEstadoPedido.Location = new Point(410, 44);
            lblEstadoPedido.Name = "lblEstadoPedido";
            lblEstadoPedido.Size = new Size(57, 15);
            lblEstadoPedido.TabIndex = 7;
            lblEstadoPedido.Text = "Borrador";
            // 
            // gpbComprobante
            // 
            gpbComprobante.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbComprobante.Controls.Add(label2);
            gpbComprobante.Controls.Add(cmbTipoComprobante);
            gpbComprobante.Controls.Add(labelNumeroComprobante);
            gpbComprobante.Controls.Add(txtNumeroComprobante);
            gpbComprobante.Location = new Point(12, 92);
            gpbComprobante.Name = "gpbComprobante";
            gpbComprobante.Size = new Size(876, 56);
            gpbComprobante.TabIndex = 2;
            gpbComprobante.TabStop = false;
            gpbComprobante.Text = "Comprobante del proveedor (si corresponde)";
            // 
            // cmbTipoComprobante
            // 
            cmbTipoComprobante.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoComprobante.FormattingEnabled = true;
            cmbTipoComprobante.Items.AddRange(new object[] { "Factura A", "Factura B", "Factura C" });
            cmbTipoComprobante.Location = new Point(140, 20);
            cmbTipoComprobante.Name = "cmbTipoComprobante";
            cmbTipoComprobante.Size = new Size(200, 23);
            cmbTipoComprobante.TabIndex = 2;
            // 
            // txtNumeroComprobante
            // 
            txtNumeroComprobante.Location = new Point(482, 20);
            txtNumeroComprobante.Name = "txtNumeroComprobante";
            txtNumeroComprobante.PlaceholderText = "Ej.: 0001-00001234";
            txtNumeroComprobante.Size = new Size(200, 23);
            txtNumeroComprobante.TabIndex = 3;
            // 
            // gpbProductos
            // 
            gpbProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbProductos.Controls.Add(label1);
            gpbProductos.Controls.Add(txtCodigobarra);
            gpbProductos.Controls.Add(btnCargarProducto);
            gpbProductos.Controls.Add(lstProductos);
            gpbProductos.Controls.Add(dtgNuevaCompra);
            gpbProductos.Controls.Add(btnEliminarCompra);
            gpbProductos.Location = new Point(12, 154);
            gpbProductos.Name = "gpbProductos";
            gpbProductos.Size = new Size(876, 250);
            gpbProductos.TabIndex = 3;
            gpbProductos.TabStop = false;
            gpbProductos.Text = "Productos del pedido";
            // 
            // txtCodigobarra
            // 
            txtCodigobarra.Location = new Point(14, 38);
            txtCodigobarra.Name = "txtCodigobarra";
            txtCodigobarra.PlaceholderText = "Código de barras, SKU o nombre del producto";
            txtCodigobarra.Size = new Size(270, 23);
            txtCodigobarra.TabIndex = 1;
            txtCodigobarra.TextChanged += txtCodigobarra_TextChanged;
            txtCodigobarra.KeyDown += txtCodigobarra_KeyDown;
            // 
            // btnCargarProducto
            // 
            btnCargarProducto.Location = new Point(292, 37);
            btnCargarProducto.Name = "btnCargarProducto";
            btnCargarProducto.Size = new Size(95, 25);
            btnCargarProducto.TabIndex = 2;
            btnCargarProducto.Text = "Agregar";
            btnCargarProducto.UseVisualStyleBackColor = true;
            btnCargarProducto.Click += btnCargarProducto_Click;
            // 
            // lstProductos
            // 
            lstProductos.FormattingEnabled = true;
            lstProductos.ImeMode = ImeMode.On;
            lstProductos.ItemHeight = 15;
            lstProductos.Location = new Point(14, 61);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(373, 64);
            lstProductos.TabIndex = 3;
            lstProductos.Visible = false;
            lstProductos.DoubleClick += lstProductos_DoubleClick;
            // 
            // dtgNuevaCompra
            // 
            dtgNuevaCompra.AllowUserToAddRows = false;
            dtgNuevaCompra.AllowUserToResizeRows = false;
            dtgNuevaCompra.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgNuevaCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgNuevaCompra.BackgroundColor = SystemColors.Window;
            dtgNuevaCompra.BorderStyle = BorderStyle.Fixed3D;
            dtgNuevaCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgNuevaCompra.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dtgNuevaCompra.Location = new Point(14, 68);
            dtgNuevaCompra.MultiSelect = false;
            dtgNuevaCompra.Name = "dtgNuevaCompra";
            dtgNuevaCompra.RowHeadersVisible = false;
            dtgNuevaCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgNuevaCompra.Size = new Size(848, 146);
            dtgNuevaCompra.TabIndex = 4;
            dtgNuevaCompra.CellContentClick += dataGridView1_CellContentClick;
            dtgNuevaCompra.CellEndEdit += dataGridView1_CellEndEdit_1;
            // 
            // Column1
            // 
            Column1.FillWeight = 75F;
            Column1.HeaderText = "Código";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.FillWeight = 65F;
            Column2.HeaderText = "Cantidad";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.FillWeight = 180F;
            Column3.HeaderText = "Descripción";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.FillWeight = 105F;
            Column4.HeaderText = "Costo unitario sin IVA";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.FillWeight = 55F;
            Column5.HeaderText = "% IVA";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "Total con IVA";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // btnEliminarCompra
            // 
            btnEliminarCompra.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminarCompra.Location = new Point(14, 220);
            btnEliminarCompra.Name = "btnEliminarCompra";
            btnEliminarCompra.Size = new Size(120, 25);
            btnEliminarCompra.TabIndex = 5;
            btnEliminarCompra.Text = "Quitar producto";
            btnEliminarCompra.UseVisualStyleBackColor = true;
            btnEliminarCompra.Click += btnEliminarCompra_Click;
            // 
            // gpbTotales
            // 
            gpbTotales.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbTotales.Controls.Add(label9);
            gpbTotales.Controls.Add(txtTotal);
            gpbTotales.Controls.Add(label8);
            gpbTotales.Controls.Add(txtIva);
            gpbTotales.Controls.Add(label5);
            gpbTotales.Controls.Add(txtSubsinImpuesto);
            gpbTotales.Location = new Point(12, 410);
            gpbTotales.Name = "gpbTotales";
            gpbTotales.Size = new Size(876, 52);
            gpbTotales.TabIndex = 4;
            gpbTotales.TabStop = false;
            gpbTotales.Text = "Totales estimados";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(55, 20);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(150, 23);
            txtTotal.TabIndex = 1;
            txtTotal.TabStop = false;
            // 
            // txtIva
            // 
            txtIva.Location = new Point(270, 20);
            txtIva.Name = "txtIva";
            txtIva.ReadOnly = true;
            txtIva.Size = new Size(150, 23);
            txtIva.TabIndex = 3;
            txtIva.TabStop = false;
            // 
            // txtSubsinImpuesto
            // 
            txtSubsinImpuesto.Location = new Point(545, 20);
            txtSubsinImpuesto.Name = "txtSubsinImpuesto";
            txtSubsinImpuesto.ReadOnly = true;
            txtSubsinImpuesto.Size = new Size(200, 23);
            txtSubsinImpuesto.TabIndex = 5;
            txtSubsinImpuesto.TabStop = false;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtObservaciones.Location = new Point(12, 548);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Notas de la compra (opcional)";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(876, 50);
            txtObservaciones.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(632, 604);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 30);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar compra";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCacelar
            // 
            btnCacelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCacelar.Location = new Point(765, 604);
            btnCacelar.Name = "btnCacelar";
            btnCacelar.Size = new Size(123, 30);
            btnCacelar.TabIndex = 8;
            btnCacelar.Text = "Cancelar";
            btnCacelar.UseVisualStyleBackColor = true;
            // 
            // grpCondicionPago
            // 
            grpCondicionPago.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpCondicionPago.Controls.Add(dtpVencimiento);
            grpCondicionPago.Controls.Add(lblVencimiento);
            grpCondicionPago.Controls.Add(chkPagaDesdeCaja);
            grpCondicionPago.Controls.Add(cmbMedioPagoCompra);
            grpCondicionPago.Controls.Add(lblMedioPagoCompra);
            grpCondicionPago.Controls.Add(cmbCondicionPago);
            grpCondicionPago.Controls.Add(lblCondicionPago);
            grpCondicionPago.Location = new Point(12, 468);
            grpCondicionPago.Name = "grpCondicionPago";
            grpCondicionPago.Size = new Size(876, 56);
            grpCondicionPago.TabIndex = 10;
            grpCondicionPago.TabStop = false;
            grpCondicionPago.Text = "Condición de pago";
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.Location = new Point(621, 22);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(218, 23);
            dtpVencimiento.TabIndex = 6;
            // 
            // lblVencimiento
            // 
            lblVencimiento.AutoSize = true;
            lblVencimiento.Location = new Point(574, 26);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(41, 15);
            lblVencimiento.TabIndex = 5;
            lblVencimiento.Text = "Vence:";
            // 
            // chkPagaDesdeCaja
            // 
            chkPagaDesdeCaja.AutoSize = true;
            chkPagaDesdeCaja.Location = new Point(429, 24);
            chkPagaDesdeCaja.Name = "chkPagaDesdeCaja";
            chkPagaDesdeCaja.Size = new Size(138, 19);
            chkPagaDesdeCaja.TabIndex = 4;
            chkPagaDesdeCaja.Text = "Sale de la caja abierta";
            chkPagaDesdeCaja.UseVisualStyleBackColor = true;
            // 
            // cmbMedioPagoCompra
            // 
            cmbMedioPagoCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPagoCompra.FormattingEnabled = true;
            cmbMedioPagoCompra.Location = new Point(303, 21);
            cmbMedioPagoCompra.Name = "cmbMedioPagoCompra";
            cmbMedioPagoCompra.Size = new Size(101, 23);
            cmbMedioPagoCompra.TabIndex = 3;
            // 
            // lblMedioPagoCompra
            // 
            lblMedioPagoCompra.AutoSize = true;
            lblMedioPagoCompra.Location = new Point(204, 24);
            lblMedioPagoCompra.Name = "lblMedioPagoCompra";
            lblMedioPagoCompra.Size = new Size(90, 15);
            lblMedioPagoCompra.TabIndex = 2;
            lblMedioPagoCompra.Text = "Medio de pago:";
            // 
            // cmbCondicionPago
            // 
            cmbCondicionPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCondicionPago.FormattingEnabled = true;
            cmbCondicionPago.Location = new Point(85, 20);
            cmbCondicionPago.Name = "cmbCondicionPago";
            cmbCondicionPago.Size = new Size(101, 23);
            cmbCondicionPago.TabIndex = 1;
            cmbCondicionPago.SelectedIndexChanged += cmbCondicionPago_SelectedIndexChanged;
            // 
            // lblCondicionPago
            // 
            lblCondicionPago.AutoSize = true;
            lblCondicionPago.Location = new Point(14, 23);
            lblCondicionPago.Name = "lblCondicionPago";
            lblCondicionPago.Size = new Size(65, 15);
            lblCondicionPago.TabIndex = 0;
            lblCondicionPago.Text = "Condición:";
            // 
            // frmNuevaCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 644);
            Controls.Add(grpCondicionPago);
            Controls.Add(lstProveedores);
            Controls.Add(gpbPedido);
            Controls.Add(gpbProveedor);
            Controls.Add(gpbComprobante);
            Controls.Add(gpbProductos);
            Controls.Add(gpbTotales);
            Controls.Add(label4);
            Controls.Add(txtObservaciones);
            Controls.Add(btnGuardar);
            Controls.Add(btnCacelar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(916, 683);
            Name = "frmNuevaCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva compra";
            gpbProveedor.ResumeLayout(false);
            gpbProveedor.PerformLayout();
            gpbPedido.ResumeLayout(false);
            gpbPedido.PerformLayout();
            gpbComprobante.ResumeLayout(false);
            gpbComprobante.PerformLayout();
            gpbProductos.ResumeLayout(false);
            gpbProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgNuevaCompra).EndInit();
            gpbTotales.ResumeLayout(false);
            gpbTotales.PerformLayout();
            grpCondicionPago.ResumeLayout(false);
            grpCondicionPago.PerformLayout();
            // 
            // ttAyuda: explicación de cada combo al pasar el mouse
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbSucursal, "Sucursal del proveedor a la que le comprás: los productos y sus costos dependen de ella.");
            ttAyuda.SetToolTip(cmbTipoComprobante, "Tipo de factura del proveedor: A, B o C.");
            ttAyuda.SetToolTip(cmbCondicionPago, "Contado: se paga ahora. Cuenta corriente: queda como deuda con fecha de vencimiento.");
            ttAyuda.SetToolTip(cmbMedioPagoCompra, "Con qué se paga la compra de contado.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label9;
        private Label labelNumeroComprobante;

        private GroupBox gpbProveedor;
        private Button btnBuscar;
        private TextBox txtProveedor;
        private Label lblSucursal;
        private ComboBox cmbSucursal;
        private ListBox lstProveedores;

        private GroupBox gpbPedido;
        private Label labelNumeroPedido;
        private TextBox txtNumeroPedidoInterno;
        private DateTimePicker dtpFechaPedido;
        private Label labelFechaEntrega;
        private DateTimePicker dtpEntrega;
        private Label labelEstadoPedido;
        private Label lblEstadoPedido;

        private GroupBox gpbComprobante;
        private ComboBox cmbTipoComprobante;
        private TextBox txtNumeroComprobante;

        private GroupBox gpbProductos;
        private TextBox txtCodigobarra;
        private Button btnCargarProducto;
        private ListBox lstProductos;

        private DataGridView dtgNuevaCompra;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;

        private Button btnEliminarCompra;

        private GroupBox gpbTotales;
        private TextBox txtSubsinImpuesto;
        private TextBox txtIva;
        private TextBox txtTotal;

        private TextBox txtObservaciones;
        private Button btnGuardar;
        private Button btnCacelar;
        private GroupBox grpCondicionPago;
        private Label lblCondicionPago;
        private CheckBox chkPagaDesdeCaja;
        private ComboBox cmbMedioPagoCompra;
        private Label lblMedioPagoCompra;
        private ComboBox cmbCondicionPago;
        private DateTimePicker dtpVencimiento;
        private Label lblVencimiento;
    }
}
