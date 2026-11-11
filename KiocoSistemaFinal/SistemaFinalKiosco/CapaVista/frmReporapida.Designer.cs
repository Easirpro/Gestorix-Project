namespace CapaVista
{
    partial class frmReporapida
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPrecioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNuevoPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCantidadReponer;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.ListBox lstDescripcion;
        private System.Windows.Forms.Label lblCodigoArticulo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TableLayoutPanel tlpFiltros;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Panel pnlModo;
        private System.Windows.Forms.Button btnActualizarPrecios;
        private System.Windows.Forms.Button btnReponerStock;
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporapida));
            ttAyuda = new ToolTip(components);
            cmbProveedor = new ComboBox();
            cmbSucursal = new ComboBox();
            cmbCategoria = new ComboBox();
            cmbMarca = new ComboBox();
            txtPorcentaje = new TextBox();
            btnAplicarPorcentaje = new Button();
            pnlBotones = new Panel();
            btnCancelar = new Button();
            btnGuardarCambios = new Button();
            dgvProductos = new DataGridView();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnProducto = new DataGridViewTextBoxColumn();
            clnPrecioActual = new DataGridViewTextBoxColumn();
            clnNuevoPrecio = new DataGridViewTextBoxColumn();
            clnStockActual = new DataGridViewTextBoxColumn();
            clnCantidadReponer = new DataGridViewTextBoxColumn();
            pnlBusqueda = new Panel();
            lblPorcentaje = new Label();
            txtCodigo = new TextBox();
            lblCodigoArticulo = new Label();
            lstDescripcion = new ListBox();
            tlpFiltros = new TableLayoutPanel();
            lblProveedor = new Label();
            lblCategoria = new Label();
            lblMarca = new Label();
            lblSucursal = new Label();
            pnlModo = new Panel();
            btnActualizarPrecios = new Button();
            btnReponerStock = new Button();
            lblModo = new Label();
            lblTitulo = new Label();
            pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            pnlBusqueda.SuspendLayout();
            tlpFiltros.SuspendLayout();
            pnlModo.SuspendLayout();
            SuspendLayout();
            // 
            // ttAyuda
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            // 
            // cmbProveedor
            // 
            cmbProveedor.Dock = DockStyle.Fill;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(3, 30);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(239, 23);
            cmbProveedor.TabIndex = 3;
            ttAyuda.SetToolTip(cmbProveedor, "Filtrá los productos por proveedor.");
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(738, 30);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(239, 23);
            cmbSucursal.TabIndex = 7;
            ttAyuda.SetToolTip(cmbSucursal, "Filtrá los productos por sucursal del proveedor.");
            // 
            // cmbCategoria
            // 
            cmbCategoria.Dock = DockStyle.Fill;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(248, 30);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(239, 23);
            cmbCategoria.TabIndex = 4;
            ttAyuda.SetToolTip(cmbCategoria, "Filtrá los productos por categoría.");
            // 
            // cmbMarca
            // 
            cmbMarca.Dock = DockStyle.Fill;
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(493, 30);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(239, 23);
            cmbMarca.TabIndex = 5;
            ttAyuda.SetToolTip(cmbMarca, "Filtrá los productos por marca.");
            // 
            // txtPorcentaje
            // 
            txtPorcentaje.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPorcentaje.Location = new Point(745, 13);
            txtPorcentaje.Name = "txtPorcentaje";
            txtPorcentaje.PlaceholderText = "Ej.: 15";
            txtPorcentaje.Size = new Size(70, 23);
            txtPorcentaje.TabIndex = 3;
            txtPorcentaje.TextAlign = HorizontalAlignment.Right;
            ttAyuda.SetToolTip(txtPorcentaje, "Porcentaje de aumento sobre el precio actual. Para bajar el precio, poné un número negativo.");
            txtPorcentaje.KeyDown += txtPorcentaje_KeyDown;
            txtPorcentaje.KeyPress += txtPorcentaje_KeyPress;
            // 
            // btnAplicarPorcentaje
            // 
            btnAplicarPorcentaje.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAplicarPorcentaje.Location = new Point(825, 12);
            btnAplicarPorcentaje.Name = "btnAplicarPorcentaje";
            btnAplicarPorcentaje.Size = new Size(150, 25);
            btnAplicarPorcentaje.TabIndex = 4;
            btnAplicarPorcentaje.Text = "Aplicar aumento";
            ttAyuda.SetToolTip(btnAplicarPorcentaje, "Calcula el nuevo precio de todos los productos de la grilla con el porcentaje indicado.");
            btnAplicarPorcentaje.UseVisualStyleBackColor = true;
            btnAplicarPorcentaje.Click += btnAplicarPorcentaje_Click;
            // 
            // pnlBotones
            // 
            pnlBotones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnGuardarCambios);
            pnlBotones.Location = new Point(13, 569);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(977, 40);
            pnlBotones.TabIndex = 6;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.Location = new Point(743, 8);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardarCambios.Location = new Point(854, 8);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(116, 23);
            btnGuardarCambios.TabIndex = 0;
            btnGuardarCambios.Text = "Guardar cambios";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            btnGuardarCambios.Click += btnGuardarCambios_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.BackgroundColor = SystemColors.Window;
            dgvProductos.BorderStyle = BorderStyle.Fixed3D;
            dgvProductos.ColumnHeadersHeight = 32;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnProducto, clnPrecioActual, clnNuevoPrecio, clnStockActual, clnCantidadReponer });
            dgvProductos.Location = new Point(13, 215);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(980, 348);
            dgvProductos.TabIndex = 5;
            dgvProductos.CellClick += dgvProductos_CellClick;
            dgvProductos.CellEnter += dgvProductos_CellEnter;
            dgvProductos.EditingControlShowing += dgvProductos_EditingControlShowing;
            // 
            // clnCodigo
            // 
            clnCodigo.FillWeight = 15F;
            clnCodigo.HeaderText = "Código / SKU";
            clnCodigo.MinimumWidth = 85;
            clnCodigo.Name = "clnCodigo";
            clnCodigo.ReadOnly = true;
            // 
            // clnProducto
            // 
            clnProducto.FillWeight = 25F;
            clnProducto.HeaderText = "Producto";
            clnProducto.MinimumWidth = 150;
            clnProducto.Name = "clnProducto";
            clnProducto.ReadOnly = true;
            clnProducto.Width = 150;
            // 
            // clnPrecioActual
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            clnPrecioActual.DefaultCellStyle = dataGridViewCellStyle1;
            clnPrecioActual.FillWeight = 15F;
            clnPrecioActual.HeaderText = "Precio actual";
            clnPrecioActual.MinimumWidth = 95;
            clnPrecioActual.Name = "clnPrecioActual";
            clnPrecioActual.ReadOnly = true;
            // 
            // clnNuevoPrecio
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            clnNuevoPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            clnNuevoPrecio.FillWeight = 15F;
            clnNuevoPrecio.HeaderText = "Nuevo precio";
            clnNuevoPrecio.MinimumWidth = 95;
            clnNuevoPrecio.Name = "clnNuevoPrecio";
            // 
            // clnStockActual
            // 
            clnStockActual.FillWeight = 12F;
            clnStockActual.HeaderText = "Stock actual";
            clnStockActual.MinimumWidth = 90;
            clnStockActual.Name = "clnStockActual";
            clnStockActual.ReadOnly = true;
            // 
            // clnCantidadReponer
            // 
            clnCantidadReponer.FillWeight = 18F;
            clnCantidadReponer.HeaderText = "Cantidad a ingresar";
            clnCantidadReponer.MinimumWidth = 125;
            clnCantidadReponer.Name = "clnCantidadReponer";
            clnCantidadReponer.Width = 125;
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBusqueda.Controls.Add(btnAplicarPorcentaje);
            pnlBusqueda.Controls.Add(txtPorcentaje);
            pnlBusqueda.Controls.Add(lblPorcentaje);
            pnlBusqueda.Controls.Add(txtCodigo);
            pnlBusqueda.Controls.Add(lblCodigoArticulo);
            pnlBusqueda.Location = new Point(13, 167);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Size = new Size(980, 42);
            pnlBusqueda.TabIndex = 3;
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Location = new Point(662, 16);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(81, 15);
            lblPorcentaje.TabIndex = 2;
            lblPorcentaje.Text = "Aumento (%):";
            // 
            // txtCodigo
            // 
            txtCodigo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCodigo.Location = new Point(179, 13);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "Código, SKU o nombre del producto";
            txtCodigo.Size = new Size(470, 23);
            txtCodigo.TabIndex = 1;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            txtCodigo.KeyDown += txtCodigo_KeyDown;
            // 
            // lblCodigoArticulo
            // 
            lblCodigoArticulo.AutoSize = true;
            lblCodigoArticulo.Location = new Point(3, 16);
            lblCodigoArticulo.Name = "lblCodigoArticulo";
            lblCodigoArticulo.Size = new Size(170, 15);
            lblCodigoArticulo.TabIndex = 0;
            lblCodigoArticulo.Text = "Buscar código / SKU / nombre:";
            // 
            // lstDescripcion
            // 
            lstDescripcion.IntegralHeight = false;
            lstDescripcion.ItemHeight = 15;
            lstDescripcion.Location = new Point(192, 205);
            lstDescripcion.Name = "lstDescripcion";
            lstDescripcion.Size = new Size(550, 120);
            lstDescripcion.TabIndex = 4;
            lstDescripcion.Visible = false;
            lstDescripcion.DoubleClick += lstDescripcion_DoubleClick;
            lstDescripcion.KeyDown += lstDescripcion_KeyDown;
            // 
            // tlpFiltros
            // 
            tlpFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpFiltros.ColumnCount = 4;
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFiltros.Controls.Add(lblProveedor, 0, 0);
            tlpFiltros.Controls.Add(cmbProveedor, 0, 1);
            tlpFiltros.Controls.Add(lblCategoria, 1, 0);
            tlpFiltros.Controls.Add(cmbCategoria, 1, 1);
            tlpFiltros.Controls.Add(lblMarca, 2, 0);
            tlpFiltros.Controls.Add(cmbMarca, 2, 1);
            tlpFiltros.Controls.Add(cmbSucursal, 3, 1);
            tlpFiltros.Controls.Add(lblSucursal, 3, 0);
            tlpFiltros.Location = new Point(13, 99);
            tlpFiltros.Name = "tlpFiltros";
            tlpFiltros.Padding = new Padding(0, 2, 0, 2);
            tlpFiltros.RowCount = 2;
            tlpFiltros.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlpFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFiltros.Size = new Size(980, 62);
            tlpFiltros.TabIndex = 2;
            // 
            // lblProveedor
            // 
            lblProveedor.Dock = DockStyle.Fill;
            lblProveedor.Location = new Point(3, 2);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(239, 25);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor";
            lblProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategoria
            // 
            lblCategoria.Dock = DockStyle.Fill;
            lblCategoria.Location = new Point(248, 2);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(239, 25);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoría";
            lblCategoria.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMarca
            // 
            lblMarca.Dock = DockStyle.Fill;
            lblMarca.Location = new Point(493, 2);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(239, 25);
            lblMarca.TabIndex = 5;
            lblMarca.Text = "Marca";
            lblMarca.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(738, 2);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(51, 15);
            lblSucursal.TabIndex = 6;
            lblSucursal.Text = "Sucursal";
            // 
            // pnlModo
            // 
            pnlModo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlModo.Controls.Add(btnActualizarPrecios);
            pnlModo.Controls.Add(btnReponerStock);
            pnlModo.Controls.Add(lblModo);
            pnlModo.Location = new Point(13, 55);
            pnlModo.Name = "pnlModo";
            pnlModo.Size = new Size(980, 38);
            pnlModo.TabIndex = 1;
            // 
            // btnActualizarPrecios
            // 
            btnActualizarPrecios.Location = new Point(149, 3);
            btnActualizarPrecios.Name = "btnActualizarPrecios";
            btnActualizarPrecios.Size = new Size(150, 34);
            btnActualizarPrecios.TabIndex = 1;
            btnActualizarPrecios.Text = "Actualizar precios";
            btnActualizarPrecios.UseVisualStyleBackColor = true;
            btnActualizarPrecios.Click += btnActualizarPrecios_Click;
            // 
            // btnReponerStock
            // 
            btnReponerStock.Location = new Point(314, 4);
            btnReponerStock.Name = "btnReponerStock";
            btnReponerStock.Size = new Size(150, 34);
            btnReponerStock.TabIndex = 2;
            btnReponerStock.Text = "Reponer stock";
            btnReponerStock.UseVisualStyleBackColor = true;
            btnReponerStock.Click += btnReponerStock_Click;
            // 
            // lblModo
            // 
            lblModo.AutoSize = true;
            lblModo.Location = new Point(3, 14);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(109, 15);
            lblModo.TabIndex = 0;
            lblModo.Text = "¿Qué querés hacer?";
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(13, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(980, 42);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión rápida de productos";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmReporapida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 622);
            Controls.Add(lstDescripcion);
            Controls.Add(pnlBotones);
            Controls.Add(dgvProductos);
            Controls.Add(pnlBusqueda);
            Controls.Add(tlpFiltros);
            Controls.Add(pnlModo);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 500);
            Name = "frmReporapida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión rápida de productos";
            pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            tlpFiltros.ResumeLayout(false);
            tlpFiltros.PerformLayout();
            pnlModo.ResumeLayout(false);
            pnlModo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolTip ttAyuda;

        private ComboBox cmbSucursal;
        private Label lblSucursal;
        private Label lblPorcentaje;
        private TextBox txtPorcentaje;
        private Button btnAplicarPorcentaje;
    }
}
