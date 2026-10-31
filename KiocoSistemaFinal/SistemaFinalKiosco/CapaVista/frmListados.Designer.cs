namespace CapaVista
{
    partial class frmListados
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListados));
            lblTitulo = new Label();
            pnlModo = new Panel();
            lblModo = new Label();
            btnPrecios = new Button();
            btnReposicion = new Button();
            pnlFiltros = new Panel();
            lblProveedor = new Label();
            cmbProveedor = new ComboBox();
            lblSucursal = new Label();
            cmbSucursal = new ComboBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblMarca = new Label();
            cmbMarca = new ComboBox();
            lblArticulo = new Label();
            txtArticulo = new TextBox();
            chkFiltro = new CheckBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            lstArticulos = new ListBox();
            dgvListado = new DataGridView();
            lblCantidad = new Label();
            btnExportar = new Button();
            btnVolver = new Button();
            pnlModo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(13, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1054, 42);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listados de precios y reposición";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlModo
            // 
            pnlModo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlModo.Controls.Add(lblModo);
            pnlModo.Controls.Add(btnPrecios);
            pnlModo.Controls.Add(btnReposicion);
            pnlModo.Location = new Point(13, 55);
            pnlModo.Name = "pnlModo";
            pnlModo.Size = new Size(1054, 40);
            pnlModo.TabIndex = 1;
            // 
            // lblModo
            // 
            lblModo.AutoSize = true;
            lblModo.Location = new Point(3, 14);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(134, 15);
            lblModo.TabIndex = 0;
            lblModo.Text = "¿Qué listado querés ver?";
            // 
            // btnPrecios
            // 
            btnPrecios.Location = new Point(160, 3);
            btnPrecios.Name = "btnPrecios";
            btnPrecios.Size = new Size(150, 34);
            btnPrecios.TabIndex = 1;
            btnPrecios.Text = "Lista de precios";
            btnPrecios.UseVisualStyleBackColor = true;
            btnPrecios.Click += btnPrecios_Click;
            // 
            // btnReposicion
            // 
            btnReposicion.Location = new Point(325, 3);
            btnReposicion.Name = "btnReposicion";
            btnReposicion.Size = new Size(150, 34);
            btnReposicion.TabIndex = 2;
            btnReposicion.Text = "Reposición";
            btnReposicion.UseVisualStyleBackColor = true;
            btnReposicion.Click += btnReposicion_Click;
            // 
            // pnlFiltros
            // 
            pnlFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFiltros.Controls.Add(lblProveedor);
            pnlFiltros.Controls.Add(cmbProveedor);
            pnlFiltros.Controls.Add(lblSucursal);
            pnlFiltros.Controls.Add(cmbSucursal);
            pnlFiltros.Controls.Add(lblCategoria);
            pnlFiltros.Controls.Add(cmbCategoria);
            pnlFiltros.Controls.Add(lblMarca);
            pnlFiltros.Controls.Add(cmbMarca);
            pnlFiltros.Controls.Add(lblArticulo);
            pnlFiltros.Controls.Add(txtArticulo);
            pnlFiltros.Controls.Add(chkFiltro);
            pnlFiltros.Controls.Add(btnBuscar);
            pnlFiltros.Controls.Add(btnLimpiar);
            pnlFiltros.Location = new Point(13, 101);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1054, 72);
            pnlFiltros.TabIndex = 2;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(3, 11);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(64, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(70, 7);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(190, 23);
            cmbProveedor.TabIndex = 1;
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(275, 11);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(54, 15);
            lblSucursal.TabIndex = 2;
            lblSucursal.Text = "Sucursal:";
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(335, 7);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(170, 23);
            cmbSucursal.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(520, 11);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(587, 7);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(170, 23);
            cmbCategoria.TabIndex = 5;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(772, 11);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 6;
            lblMarca.Text = "Marca:";
            // 
            // cmbMarca
            // 
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(821, 7);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(170, 23);
            cmbMarca.TabIndex = 7;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Location = new Point(3, 45);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(52, 15);
            lblArticulo.TabIndex = 8;
            lblArticulo.Text = "Artículo:";
            // 
            // txtArticulo
            // 
            txtArticulo.Location = new Point(70, 41);
            txtArticulo.Name = "txtArticulo";
            txtArticulo.PlaceholderText = "SKU, código de barras o nombre (Enter o doble clic para agregar)";
            txtArticulo.Size = new Size(392, 23);
            txtArticulo.TabIndex = 9;
            // 
            // chkFiltro
            // 
            chkFiltro.AutoSize = true;
            chkFiltro.Location = new Point(477, 43);
            chkFiltro.Name = "chkFiltro";
            chkFiltro.Size = new Size(106, 19);
            chkFiltro.TabIndex = 10;
            chkFiltro.Text = "Solo con oferta";
            chkFiltro.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(821, 38);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(87, 29);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(914, 38);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(87, 29);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lstArticulos
            // 
            lstArticulos.FormattingEnabled = true;
            lstArticulos.IntegralHeight = false;
            lstArticulos.ItemHeight = 15;
            lstArticulos.Location = new Point(83, 165);
            lstArticulos.Name = "lstArticulos";
            lstArticulos.Size = new Size(392, 140);
            lstArticulos.TabIndex = 11;
            lstArticulos.Visible = false;
            // 
            // dgvListado
            // 
            dgvListado.AllowUserToAddRows = false;
            dgvListado.AllowUserToDeleteRows = false;
            dgvListado.AllowUserToResizeRows = false;
            dgvListado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvListado.BackgroundColor = SystemColors.Window;
            dgvListado.ColumnHeadersHeight = 32;
            dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvListado.Location = new Point(13, 179);
            dgvListado.MultiSelect = false;
            dgvListado.Name = "dgvListado";
            dgvListado.ReadOnly = true;
            dgvListado.RowHeadersVisible = false;
            dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListado.Size = new Size(1054, 362);
            dgvListado.TabIndex = 12;
            // 
            // lblCantidad
            // 
            lblCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(13, 559);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(0, 15);
            lblCantidad.TabIndex = 13;
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportar.Location = new Point(837, 551);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(124, 30);
            btnExportar.TabIndex = 14;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Location = new Point(967, 551);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.TabIndex = 15;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmListados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 592);
            Controls.Add(lstArticulos);
            Controls.Add(btnVolver);
            Controls.Add(btnExportar);
            Controls.Add(lblCantidad);
            Controls.Add(dgvListado);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlModo);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1096, 631);
            Name = "frmListados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listados de precios y reposición";
            pnlModo.ResumeLayout(false);
            pnlModo.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlModo;
        private Label lblModo;
        private Button btnPrecios;
        private Button btnReposicion;
        private Panel pnlFiltros;
        private Label lblProveedor;
        private ComboBox cmbProveedor;
        private Label lblSucursal;
        private ComboBox cmbSucursal;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblMarca;
        private ComboBox cmbMarca;
        private Label lblArticulo;
        private TextBox txtArticulo;
        private CheckBox chkFiltro;
        private Button btnBuscar;
        private Button btnLimpiar;
        private ListBox lstArticulos;
        private DataGridView dgvListado;
        private Label lblCantidad;
        private Button btnExportar;
        private Button btnVolver;
    }
}
