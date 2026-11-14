namespace CapaVista
{
    partial class frmRecepcionCompra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionCompra));
            pnlPrincipal = new TableLayoutPanel();
            lblTitulo = new Label();
            pnlBusqueda = new TableLayoutPanel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblFechaFiltro = new Label();
            dtpFechaFiltro = new DateTimePicker();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            lblComprasPendientes = new Label();
            dgvCompras = new DataGridView();
            clnIdCompra = new DataGridViewTextBoxColumn();
            clnFechaCompra = new DataGridViewTextBoxColumn();
            clnProveedor = new DataGridViewTextBoxColumn();
            clnComprobante = new DataGridViewTextBoxColumn();
            clnEstado = new DataGridViewTextBoxColumn();
            pnlDatosCompra = new TableLayoutPanel();
            lblProveedor = new Label();
            lblProveedorValor = new Label();
            lblFechaCompra = new Label();
            lblFechaCompraValor = new Label();
            lblComprobanteCompra = new Label();
            lblComprobanteCompraValor = new Label();
            lblEstadoCompra = new Label();
            lblEstadoCompraValor = new Label();
            lblProductos = new Label();
            dgvProductos = new DataGridView();
            clnIdProducto = new DataGridViewTextBoxColumn();
            clnNombreProducto = new DataGridViewTextBoxColumn();
            clnCantidadPedida = new DataGridViewTextBoxColumn();
            clnCantidadRecibida = new DataGridViewTextBoxColumn();
            clnDiferencia = new DataGridViewTextBoxColumn();
            pnlTotales = new TableLayoutPanel();
            lblTotalCompra = new Label();
            lblTotalCompraValor = new Label();
            lblTotalBoleta = new Label();
            txtTotalBoleta = new TextBox();
            lblDiferenciaTotal = new Label();
            lblDiferenciaTotalValor = new Label();
            pnlAccionesProductos = new FlowLayoutPanel();
            btnAgregarProducto = new Button();
            btnQuitarProducto = new Button();
            pnlObservaciones = new TableLayoutPanel();
            lblMotivos = new Label();
            clbMotivos = new CheckedListBox();
            lblDetalleObservaciones = new Label();
            txtObservaciones = new TextBox();
            pnlPie = new TableLayoutPanel();
            lblEstadoRecepcion = new Label();
            btnCancelar = new Button();
            btnConfirmarRecepcion = new Button();
            pnlPrincipal.SuspendLayout();
            pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            pnlDatosCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            pnlTotales.SuspendLayout();
            pnlAccionesProductos.SuspendLayout();
            pnlObservaciones.SuspendLayout();
            pnlPie.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BackColor = Color.White;
            pnlPrincipal.ColumnCount = 1;
            pnlPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlPrincipal.Controls.Add(lblTitulo, 0, 0);
            pnlPrincipal.Controls.Add(pnlBusqueda, 0, 1);
            pnlPrincipal.Controls.Add(lblComprasPendientes, 0, 2);
            pnlPrincipal.Controls.Add(dgvCompras, 0, 3);
            pnlPrincipal.Controls.Add(pnlDatosCompra, 0, 4);
            pnlPrincipal.Controls.Add(lblProductos, 0, 5);
            pnlPrincipal.Controls.Add(dgvProductos, 0, 6);
            pnlPrincipal.Controls.Add(pnlTotales, 0, 7);
            pnlPrincipal.Controls.Add(pnlAccionesProductos, 0, 8);
            pnlPrincipal.Controls.Add(pnlObservaciones, 0, 9);
            pnlPrincipal.Controls.Add(pnlPie, 0, 10);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Padding = new Padding(10);
            pnlPrincipal.RowCount = 11;
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 105F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            pnlPrincipal.Size = new Size(1050, 666);
            pnlPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(13, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1024, 34);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Recepción de mercadería";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.ColumnCount = 6;
            pnlBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 79F));
            pnlBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            pnlBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            pnlBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            pnlBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            pnlBusqueda.Controls.Add(lblBuscar, 0, 0);
            pnlBusqueda.Controls.Add(txtBuscar, 1, 0);
            pnlBusqueda.Controls.Add(lblFechaFiltro, 2, 0);
            pnlBusqueda.Controls.Add(dtpFechaFiltro, 3, 0);
            pnlBusqueda.Controls.Add(btnBuscar, 4, 0);
            pnlBusqueda.Controls.Add(btnLimpiar, 5, 0);
            pnlBusqueda.Dock = DockStyle.Fill;
            pnlBusqueda.Location = new Point(10, 44);
            pnlBusqueda.Margin = new Padding(0);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.RowCount = 1;
            pnlBusqueda.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            pnlBusqueda.Size = new Size(1030, 34);
            pnlBusqueda.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.Dock = DockStyle.Fill;
            lblBuscar.Location = new Point(3, 0);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(73, 34);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Proveedor:";
            lblBuscar.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBuscar
            // 
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Location = new Point(82, 5);
            txtBuscar.Margin = new Padding(3, 5, 8, 5);
            txtBuscar.MaxLength = 120;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre del proveedor";
            txtBuscar.Size = new Size(560, 23);
            txtBuscar.TabIndex = 1;
            // 
            // lblFechaFiltro
            // 
            lblFechaFiltro.Dock = DockStyle.Fill;
            lblFechaFiltro.Location = new Point(653, 0);
            lblFechaFiltro.Name = "lblFechaFiltro";
            lblFechaFiltro.Size = new Size(79, 34);
            lblFechaFiltro.TabIndex = 2;
            lblFechaFiltro.Text = "Fecha:";
            lblFechaFiltro.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpFechaFiltro
            // 
            dtpFechaFiltro.Checked = false;
            dtpFechaFiltro.Dock = DockStyle.Fill;
            dtpFechaFiltro.Format = DateTimePickerFormat.Short;
            dtpFechaFiltro.Location = new Point(738, 4);
            dtpFechaFiltro.Margin = new Padding(3, 4, 8, 4);
            dtpFechaFiltro.Name = "dtpFechaFiltro";
            dtpFechaFiltro.ShowCheckBox = true;
            dtpFechaFiltro.Size = new Size(114, 23);
            dtpFechaFiltro.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Dock = DockStyle.Fill;
            btnBuscar.Location = new Point(863, 2);
            btnBuscar.Margin = new Padding(3, 2, 3, 2);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(79, 30);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Dock = DockStyle.Fill;
            btnLimpiar.Location = new Point(948, 2);
            btnLimpiar.Margin = new Padding(3, 2, 0, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(82, 30);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            // 
            // lblComprasPendientes
            // 
            lblComprasPendientes.Dock = DockStyle.Fill;
            lblComprasPendientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblComprasPendientes.Location = new Point(10, 78);
            lblComprasPendientes.Margin = new Padding(0);
            lblComprasPendientes.Name = "lblComprasPendientes";
            lblComprasPendientes.Size = new Size(1030, 22);
            lblComprasPendientes.TabIndex = 2;
            lblComprasPendientes.Text = "Compras pendientes de recepción";
            lblComprasPendientes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.AllowUserToResizeRows = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCompras.Columns.AddRange(new DataGridViewColumn[] { clnIdCompra, clnFechaCompra, clnProveedor, clnComprobante, clnEstado });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCompras.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCompras.Dock = DockStyle.Fill;
            dgvCompras.Location = new Point(10, 102);
            dgvCompras.Margin = new Padding(0, 2, 0, 3);
            dgvCompras.MultiSelect = false;
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(1030, 90);
            dgvCompras.TabIndex = 3;
            // 
            // clnIdCompra
            // 
            clnIdCompra.HeaderText = "ID";
            clnIdCompra.Name = "clnIdCompra";
            clnIdCompra.ReadOnly = true;
            clnIdCompra.Visible = false;
            // 
            // clnFechaCompra
            // 
            clnFechaCompra.FillWeight = 75F;
            clnFechaCompra.HeaderText = "Fecha";
            clnFechaCompra.MinimumWidth = 75;
            clnFechaCompra.Name = "clnFechaCompra";
            clnFechaCompra.ReadOnly = true;
            // 
            // clnProveedor
            // 
            clnProveedor.FillWeight = 150F;
            clnProveedor.HeaderText = "Proveedor";
            clnProveedor.MinimumWidth = 120;
            clnProveedor.Name = "clnProveedor";
            clnProveedor.ReadOnly = true;
            // 
            // clnComprobante
            // 
            clnComprobante.FillWeight = 110F;
            clnComprobante.HeaderText = "Comprobante";
            clnComprobante.MinimumWidth = 100;
            clnComprobante.Name = "clnComprobante";
            clnComprobante.ReadOnly = true;
            // 
            // clnEstado
            // 
            clnEstado.FillWeight = 75F;
            clnEstado.HeaderText = "Estado";
            clnEstado.MinimumWidth = 70;
            clnEstado.Name = "clnEstado";
            clnEstado.ReadOnly = true;
            // 
            // pnlDatosCompra
            // 
            pnlDatosCompra.ColumnCount = 8;
            pnlDatosCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            pnlDatosCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            pnlDatosCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            pnlDatosCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            pnlDatosCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            pnlDatosCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlDatosCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
            pnlDatosCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlDatosCompra.Controls.Add(lblProveedor, 0, 0);
            pnlDatosCompra.Controls.Add(lblProveedorValor, 1, 0);
            pnlDatosCompra.Controls.Add(lblFechaCompra, 2, 0);
            pnlDatosCompra.Controls.Add(lblFechaCompraValor, 3, 0);
            pnlDatosCompra.Controls.Add(lblComprobanteCompra, 4, 0);
            pnlDatosCompra.Controls.Add(lblComprobanteCompraValor, 5, 0);
            pnlDatosCompra.Controls.Add(lblEstadoCompra, 6, 0);
            pnlDatosCompra.Controls.Add(lblEstadoCompraValor, 7, 0);
            pnlDatosCompra.Dock = DockStyle.Fill;
            pnlDatosCompra.Location = new Point(10, 195);
            pnlDatosCompra.Margin = new Padding(0);
            pnlDatosCompra.Name = "pnlDatosCompra";
            pnlDatosCompra.RowCount = 1;
            pnlDatosCompra.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            pnlDatosCompra.Size = new Size(1030, 42);
            pnlDatosCompra.TabIndex = 4;
            // 
            // lblProveedor
            // 
            lblProveedor.Dock = DockStyle.Fill;
            lblProveedor.Location = new Point(2, 0);
            lblProveedor.Margin = new Padding(2, 0, 2, 0);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(96, 42);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            lblProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProveedorValor
            // 
            lblProveedorValor.BorderStyle = BorderStyle.FixedSingle;
            lblProveedorValor.Dock = DockStyle.Fill;
            lblProveedorValor.Location = new Point(101, 4);
            lblProveedorValor.Margin = new Padding(1, 4, 4, 4);
            lblProveedorValor.Name = "lblProveedorValor";
            lblProveedorValor.Padding = new Padding(4, 0, 2, 0);
            lblProveedorValor.Size = new Size(202, 34);
            lblProveedorValor.TabIndex = 1;
            lblProveedorValor.Text = "-";
            lblProveedorValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFechaCompra
            // 
            lblFechaCompra.Dock = DockStyle.Fill;
            lblFechaCompra.Location = new Point(309, 0);
            lblFechaCompra.Margin = new Padding(2, 0, 2, 0);
            lblFechaCompra.Name = "lblFechaCompra";
            lblFechaCompra.Size = new Size(56, 42);
            lblFechaCompra.TabIndex = 2;
            lblFechaCompra.Text = "Fecha:";
            lblFechaCompra.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFechaCompraValor
            // 
            lblFechaCompraValor.BorderStyle = BorderStyle.FixedSingle;
            lblFechaCompraValor.Dock = DockStyle.Fill;
            lblFechaCompraValor.Location = new Point(368, 4);
            lblFechaCompraValor.Margin = new Padding(1, 4, 4, 4);
            lblFechaCompraValor.Name = "lblFechaCompraValor";
            lblFechaCompraValor.Padding = new Padding(4, 0, 2, 0);
            lblFechaCompraValor.Size = new Size(133, 34);
            lblFechaCompraValor.TabIndex = 3;
            lblFechaCompraValor.Text = "-";
            lblFechaCompraValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblComprobanteCompra
            // 
            lblComprobanteCompra.Dock = DockStyle.Fill;
            lblComprobanteCompra.Location = new Point(507, 0);
            lblComprobanteCompra.Margin = new Padding(2, 0, 2, 0);
            lblComprobanteCompra.Name = "lblComprobanteCompra";
            lblComprobanteCompra.Size = new Size(111, 42);
            lblComprobanteCompra.TabIndex = 4;
            lblComprobanteCompra.Text = "Comprobante:";
            lblComprobanteCompra.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblComprobanteCompraValor
            // 
            lblComprobanteCompraValor.BorderStyle = BorderStyle.FixedSingle;
            lblComprobanteCompraValor.Dock = DockStyle.Fill;
            lblComprobanteCompraValor.Location = new Point(621, 4);
            lblComprobanteCompraValor.Margin = new Padding(1, 4, 4, 4);
            lblComprobanteCompraValor.Name = "lblComprobanteCompraValor";
            lblComprobanteCompraValor.Padding = new Padding(4, 0, 2, 0);
            lblComprobanteCompraValor.Size = new Size(167, 34);
            lblComprobanteCompraValor.TabIndex = 5;
            lblComprobanteCompraValor.Text = "-";
            lblComprobanteCompraValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEstadoCompra
            // 
            lblEstadoCompra.Dock = DockStyle.Fill;
            lblEstadoCompra.Location = new Point(794, 0);
            lblEstadoCompra.Margin = new Padding(2, 0, 2, 0);
            lblEstadoCompra.Name = "lblEstadoCompra";
            lblEstadoCompra.Size = new Size(61, 42);
            lblEstadoCompra.TabIndex = 6;
            lblEstadoCompra.Text = "Estado:";
            lblEstadoCompra.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEstadoCompraValor
            // 
            lblEstadoCompraValor.BorderStyle = BorderStyle.FixedSingle;
            lblEstadoCompraValor.Dock = DockStyle.Fill;
            lblEstadoCompraValor.Location = new Point(858, 4);
            lblEstadoCompraValor.Margin = new Padding(1, 4, 4, 4);
            lblEstadoCompraValor.Name = "lblEstadoCompraValor";
            lblEstadoCompraValor.Padding = new Padding(4, 0, 2, 0);
            lblEstadoCompraValor.Size = new Size(168, 34);
            lblEstadoCompraValor.TabIndex = 7;
            lblEstadoCompraValor.Text = "-";
            lblEstadoCompraValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProductos
            // 
            lblProductos.Dock = DockStyle.Fill;
            lblProductos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductos.Location = new Point(10, 237);
            lblProductos.Margin = new Padding(0);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(1030, 22);
            lblProductos.TabIndex = 5;
            lblProductos.Text = "Detalle de productos recibidos";
            lblProductos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { clnIdProducto, clnNombreProducto, clnCantidadPedida, clnCantidadRecibida, clnDiferencia });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle4;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(10, 261);
            dgvProductos.Margin = new Padding(0, 2, 0, 2);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(1030, 101);
            dgvProductos.TabIndex = 6;
            // 
            // clnIdProducto
            // 
            clnIdProducto.HeaderText = "ID";
            clnIdProducto.Name = "clnIdProducto";
            clnIdProducto.Visible = false;
            // 
            // clnNombreProducto
            // 
            clnNombreProducto.FillWeight = 200F;
            clnNombreProducto.HeaderText = "Producto";
            clnNombreProducto.MinimumWidth = 150;
            clnNombreProducto.Name = "clnNombreProducto";
            clnNombreProducto.ReadOnly = true;
            // 
            // clnCantidadPedida
            // 
            clnCantidadPedida.FillWeight = 95F;
            clnCantidadPedida.HeaderText = "Cantidad pedida";
            clnCantidadPedida.MinimumWidth = 100;
            clnCantidadPedida.Name = "clnCantidadPedida";
            clnCantidadPedida.ReadOnly = true;
            // 
            // clnCantidadRecibida
            // 
            clnCantidadRecibida.FillWeight = 105F;
            clnCantidadRecibida.HeaderText = "Cantidad recibida";
            clnCantidadRecibida.MinimumWidth = 110;
            clnCantidadRecibida.Name = "clnCantidadRecibida";
            // 
            // clnDiferencia
            // 
            clnDiferencia.FillWeight = 85F;
            clnDiferencia.HeaderText = "Diferencia";
            clnDiferencia.MinimumWidth = 85;
            clnDiferencia.Name = "clnDiferencia";
            clnDiferencia.ReadOnly = true;
            // 
            // pnlTotales
            // 
            pnlTotales.ColumnCount = 6;
            pnlTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            pnlTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            pnlTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            pnlTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            pnlTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            pnlTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            pnlTotales.Controls.Add(lblTotalCompra, 0, 0);
            pnlTotales.Controls.Add(lblTotalCompraValor, 1, 0);
            pnlTotales.Controls.Add(lblTotalBoleta, 2, 0);
            pnlTotales.Controls.Add(txtTotalBoleta, 3, 0);
            pnlTotales.Controls.Add(lblDiferenciaTotal, 4, 0);
            pnlTotales.Controls.Add(lblDiferenciaTotalValor, 5, 0);
            pnlTotales.Dock = DockStyle.Fill;
            pnlTotales.Location = new Point(10, 364);
            pnlTotales.Margin = new Padding(0);
            pnlTotales.Name = "pnlTotales";
            pnlTotales.RowCount = 1;
            pnlTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            pnlTotales.Size = new Size(1030, 34);
            pnlTotales.TabIndex = 7;
            // 
            // lblTotalCompra
            // 
            lblTotalCompra.Dock = DockStyle.Fill;
            lblTotalCompra.Location = new Point(2, 0);
            lblTotalCompra.Margin = new Padding(2, 0, 2, 0);
            lblTotalCompra.Name = "lblTotalCompra";
            lblTotalCompra.Size = new Size(91, 34);
            lblTotalCompra.TabIndex = 0;
            lblTotalCompra.Text = "Total compra:";
            lblTotalCompra.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalCompraValor
            // 
            lblTotalCompraValor.BorderStyle = BorderStyle.FixedSingle;
            lblTotalCompraValor.Dock = DockStyle.Fill;
            lblTotalCompraValor.Location = new Point(97, 3);
            lblTotalCompraValor.Margin = new Padding(2, 3, 6, 3);
            lblTotalCompraValor.Name = "lblTotalCompraValor";
            lblTotalCompraValor.Padding = new Padding(4, 0, 0, 0);
            lblTotalCompraValor.Size = new Size(217, 28);
            lblTotalCompraValor.TabIndex = 1;
            lblTotalCompraValor.Text = "$ 0,00";
            lblTotalCompraValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalBoleta
            // 
            lblTotalBoleta.Dock = DockStyle.Fill;
            lblTotalBoleta.Location = new Point(322, 0);
            lblTotalBoleta.Margin = new Padding(2, 0, 2, 0);
            lblTotalBoleta.Name = "lblTotalBoleta";
            lblTotalBoleta.Size = new Size(101, 34);
            lblTotalBoleta.TabIndex = 2;
            lblTotalBoleta.Text = "Total boleta:";
            lblTotalBoleta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTotalBoleta
            // 
            txtTotalBoleta.Dock = DockStyle.Fill;
            txtTotalBoleta.Location = new Point(427, 4);
            txtTotalBoleta.Margin = new Padding(2, 4, 6, 4);
            txtTotalBoleta.Name = "txtTotalBoleta";
            txtTotalBoleta.PlaceholderText = "Total que figura en la boleta";
            txtTotalBoleta.Size = new Size(217, 23);
            txtTotalBoleta.TabIndex = 3;
            txtTotalBoleta.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDiferenciaTotal
            // 
            lblDiferenciaTotal.Dock = DockStyle.Fill;
            lblDiferenciaTotal.Location = new Point(652, 0);
            lblDiferenciaTotal.Margin = new Padding(2, 0, 2, 0);
            lblDiferenciaTotal.Name = "lblDiferenciaTotal";
            lblDiferenciaTotal.Size = new Size(76, 34);
            lblDiferenciaTotal.TabIndex = 4;
            lblDiferenciaTotal.Text = "Diferencia:";
            lblDiferenciaTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDiferenciaTotalValor
            // 
            lblDiferenciaTotalValor.BorderStyle = BorderStyle.FixedSingle;
            lblDiferenciaTotalValor.Dock = DockStyle.Fill;
            lblDiferenciaTotalValor.Location = new Point(732, 3);
            lblDiferenciaTotalValor.Margin = new Padding(2, 3, 0, 3);
            lblDiferenciaTotalValor.Name = "lblDiferenciaTotalValor";
            lblDiferenciaTotalValor.Padding = new Padding(4, 0, 0, 0);
            lblDiferenciaTotalValor.Size = new Size(298, 28);
            lblDiferenciaTotalValor.TabIndex = 5;
            lblDiferenciaTotalValor.Text = "$ 0,00";
            lblDiferenciaTotalValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAccionesProductos
            // 
            pnlAccionesProductos.Controls.Add(btnAgregarProducto);
            pnlAccionesProductos.Controls.Add(btnQuitarProducto);
            pnlAccionesProductos.Dock = DockStyle.Fill;
            pnlAccionesProductos.Location = new Point(10, 398);
            pnlAccionesProductos.Margin = new Padding(0);
            pnlAccionesProductos.Name = "pnlAccionesProductos";
            pnlAccionesProductos.Size = new Size(1030, 32);
            pnlAccionesProductos.TabIndex = 8;
            pnlAccionesProductos.WrapContents = false;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(0, 1);
            btnAgregarProducto.Margin = new Padding(0, 1, 8, 1);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(145, 28);
            btnAgregarProducto.TabIndex = 0;
            btnAgregarProducto.Text = "+ Agregar producto";
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.Location = new Point(153, 1);
            btnQuitarProducto.Margin = new Padding(0, 1, 0, 1);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(130, 28);
            btnQuitarProducto.TabIndex = 1;
            btnQuitarProducto.Text = "Quitar producto";
            // 
            // pnlObservaciones
            // 
            pnlObservaciones.ColumnCount = 2;
            pnlObservaciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            pnlObservaciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            pnlObservaciones.Controls.Add(lblMotivos, 0, 0);
            pnlObservaciones.Controls.Add(clbMotivos, 0, 1);
            pnlObservaciones.Controls.Add(lblDetalleObservaciones, 1, 0);
            pnlObservaciones.Controls.Add(txtObservaciones, 1, 1);
            pnlObservaciones.Dock = DockStyle.Fill;
            pnlObservaciones.Location = new Point(10, 433);
            pnlObservaciones.Margin = new Padding(0, 3, 0, 3);
            pnlObservaciones.Name = "pnlObservaciones";
            pnlObservaciones.RowCount = 2;
            pnlObservaciones.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            pnlObservaciones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlObservaciones.Size = new Size(1030, 182);
            pnlObservaciones.TabIndex = 9;
            // 
            // lblMotivos
            // 
            lblMotivos.Dock = DockStyle.Fill;
            lblMotivos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMotivos.Location = new Point(0, 0);
            lblMotivos.Margin = new Padding(0);
            lblMotivos.Name = "lblMotivos";
            lblMotivos.Size = new Size(432, 84);
            lblMotivos.TabIndex = 0;
            lblMotivos.Text = "Motivo de la diferencia";
            lblMotivos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // clbMotivos
            // 
            clbMotivos.CheckOnClick = true;
            clbMotivos.Dock = DockStyle.Fill;
            clbMotivos.IntegralHeight = false;
            clbMotivos.Items.AddRange(new object[] { "Faltante de mercadería", "Producto adicional no solicitado", "Producto dañado o incorrecto", "Otro motivo" });
            clbMotivos.Location = new Point(0, 86);
            clbMotivos.Margin = new Padding(0, 2, 8, 0);
            clbMotivos.Name = "clbMotivos";
            clbMotivos.Size = new Size(424, 96);
            clbMotivos.TabIndex = 1;
            // 
            // lblDetalleObservaciones
            // 
            lblDetalleObservaciones.Dock = DockStyle.Fill;
            lblDetalleObservaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetalleObservaciones.Location = new Point(432, 0);
            lblDetalleObservaciones.Margin = new Padding(0);
            lblDetalleObservaciones.Name = "lblDetalleObservaciones";
            lblDetalleObservaciones.Size = new Size(598, 84);
            lblDetalleObservaciones.TabIndex = 2;
            lblDetalleObservaciones.Text = "Detalle / observaciones";
            lblDetalleObservaciones.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Dock = DockStyle.Fill;
            txtObservaciones.Location = new Point(432, 86);
            txtObservaciones.Margin = new Padding(0, 2, 0, 0);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Detalle de faltantes, sobrantes u otras observaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(598, 96);
            txtObservaciones.TabIndex = 3;
            // 
            // pnlPie
            // 
            pnlPie.ColumnCount = 3;
            pnlPie.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlPie.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            pnlPie.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            pnlPie.Controls.Add(lblEstadoRecepcion, 0, 0);
            pnlPie.Controls.Add(btnCancelar, 1, 0);
            pnlPie.Controls.Add(btnConfirmarRecepcion, 2, 0);
            pnlPie.Dock = DockStyle.Fill;
            pnlPie.Location = new Point(10, 618);
            pnlPie.Margin = new Padding(0);
            pnlPie.Name = "pnlPie";
            pnlPie.RowCount = 1;
            pnlPie.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            pnlPie.Size = new Size(1030, 38);
            pnlPie.TabIndex = 10;
            // 
            // lblEstadoRecepcion
            // 
            lblEstadoRecepcion.Dock = DockStyle.Fill;
            lblEstadoRecepcion.Location = new Point(3, 0);
            lblEstadoRecepcion.Name = "lblEstadoRecepcion";
            lblEstadoRecepcion.Size = new Size(744, 38);
            lblEstadoRecepcion.TabIndex = 0;
            lblEstadoRecepcion.Text = "Seleccione una compra pendiente.";
            lblEstadoRecepcion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.Location = new Point(754, 3);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 32);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            // 
            // btnConfirmarRecepcion
            // 
            btnConfirmarRecepcion.Dock = DockStyle.Fill;
            btnConfirmarRecepcion.Location = new Point(859, 3);
            btnConfirmarRecepcion.Margin = new Padding(4, 3, 0, 3);
            btnConfirmarRecepcion.Name = "btnConfirmarRecepcion";
            btnConfirmarRecepcion.Size = new Size(171, 32);
            btnConfirmarRecepcion.TabIndex = 2;
            btnConfirmarRecepcion.Text = "Confirmar recepción";
            // 
            // frmRecepcionCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 666);
            Controls.Add(pnlPrincipal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(950, 650);
            Name = "frmRecepcionCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recepción de compras";
            pnlPrincipal.ResumeLayout(false);
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            pnlDatosCompra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            pnlTotales.ResumeLayout(false);
            pnlTotales.PerformLayout();
            pnlAccionesProductos.ResumeLayout(false);
            pnlObservaciones.ResumeLayout(false);
            pnlObservaciones.PerformLayout();
            pnlPie.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlPrincipal;
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.TableLayoutPanel pnlBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFechaFiltro;
        private System.Windows.Forms.DateTimePicker dtpFechaFiltro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.Label lblComprasPendientes;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEstado;

        private System.Windows.Forms.TableLayoutPanel pnlDatosCompra;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblProveedorValor;
        private System.Windows.Forms.Label lblFechaCompra;
        private System.Windows.Forms.Label lblFechaCompraValor;
        private System.Windows.Forms.Label lblComprobanteCompra;
        private System.Windows.Forms.Label lblComprobanteCompraValor;
        private System.Windows.Forms.Label lblEstadoCompra;
        private System.Windows.Forms.Label lblEstadoCompraValor;

        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCantidadPedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCantidadRecibida;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDiferencia;

        private System.Windows.Forms.TableLayoutPanel pnlTotales;
        private System.Windows.Forms.Label lblTotalCompra;
        private System.Windows.Forms.Label lblTotalCompraValor;
        private System.Windows.Forms.Label lblTotalBoleta;
        private System.Windows.Forms.TextBox txtTotalBoleta;
        private System.Windows.Forms.Label lblDiferenciaTotal;
        private System.Windows.Forms.Label lblDiferenciaTotalValor;

        private System.Windows.Forms.FlowLayoutPanel pnlAccionesProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnQuitarProducto;

        private System.Windows.Forms.TableLayoutPanel pnlObservaciones;
        private System.Windows.Forms.Label lblMotivos;
        private System.Windows.Forms.CheckedListBox clbMotivos;
        private System.Windows.Forms.Label lblDetalleObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;

        private System.Windows.Forms.TableLayoutPanel pnlPie;
        private System.Windows.Forms.Label lblEstadoRecepcion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmarRecepcion;
    }
}
