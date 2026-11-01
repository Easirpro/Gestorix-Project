namespace CapaVista
{
    partial class frmInformesVentas
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
            components = new System.ComponentModel.Container();
            ttAyuda = new ToolTip(components);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformesVentas));
            lblTitulo = new Label();
            pnlModo = new Panel();
            lblModo = new Label();
            btnPorFecha = new Button();
            btnDetalle = new Button();
            btnPorRubro = new Button();
            btnPorArticulo = new Button();
            btnPorMedioPago = new Button();
            pnlFiltros = new Panel();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            lblVendedor = new Label();
            cmbVendedor = new ComboBox();
            lblMedioPago = new Label();
            cmbMedioPago = new ComboBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblArticulo = new Label();
            cmbArticulo = new ComboBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            dgvInforme = new DataGridView();
            lblTotales = new Label();
            btnExportar = new Button();
            btnVolver = new Button();
            pnlModo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInforme).BeginInit();
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
            lblTitulo.Text = "Informes de ventas";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlModo
            // 
            pnlModo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlModo.Controls.Add(lblModo);
            pnlModo.Controls.Add(btnPorFecha);
            pnlModo.Controls.Add(btnDetalle);
            pnlModo.Controls.Add(btnPorRubro);
            pnlModo.Controls.Add(btnPorArticulo);
            pnlModo.Controls.Add(btnPorMedioPago);
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
            lblModo.Size = new Size(141, 15);
            lblModo.TabIndex = 0;
            lblModo.Text = "¿Qué informe querés ver?";
            // 
            // btnPorFecha
            // 
            btnPorFecha.Location = new Point(160, 3);
            btnPorFecha.Name = "btnPorFecha";
            btnPorFecha.Size = new Size(130, 34);
            btnPorFecha.TabIndex = 1;
            btnPorFecha.Text = "Por fecha";
            btnPorFecha.UseVisualStyleBackColor = true;
            // 
            // btnDetalle
            // 
            btnDetalle.Location = new Point(296, 3);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(130, 34);
            btnDetalle.TabIndex = 2;
            btnDetalle.Text = "Detalle";
            btnDetalle.UseVisualStyleBackColor = true;
            // 
            // btnPorRubro
            // 
            btnPorRubro.Location = new Point(432, 3);
            btnPorRubro.Name = "btnPorRubro";
            btnPorRubro.Size = new Size(130, 34);
            btnPorRubro.TabIndex = 3;
            btnPorRubro.Text = "Por rubro";
            btnPorRubro.UseVisualStyleBackColor = true;
            // 
            // btnPorArticulo
            // 
            btnPorArticulo.Location = new Point(568, 3);
            btnPorArticulo.Name = "btnPorArticulo";
            btnPorArticulo.Size = new Size(130, 34);
            btnPorArticulo.TabIndex = 4;
            btnPorArticulo.Text = "Por artículo";
            btnPorArticulo.UseVisualStyleBackColor = true;
            // 
            // btnPorMedioPago
            // 
            btnPorMedioPago.Location = new Point(704, 3);
            btnPorMedioPago.Name = "btnPorMedioPago";
            btnPorMedioPago.Size = new Size(130, 34);
            btnPorMedioPago.TabIndex = 5;
            btnPorMedioPago.Text = "Por medio de pago";
            btnPorMedioPago.UseVisualStyleBackColor = true;
            // 
            // pnlFiltros
            // 
            pnlFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFiltros.Controls.Add(lblDesde);
            pnlFiltros.Controls.Add(dtpDesde);
            pnlFiltros.Controls.Add(lblHasta);
            pnlFiltros.Controls.Add(dtpHasta);
            pnlFiltros.Controls.Add(lblVendedor);
            pnlFiltros.Controls.Add(cmbVendedor);
            pnlFiltros.Controls.Add(lblMedioPago);
            pnlFiltros.Controls.Add(cmbMedioPago);
            pnlFiltros.Controls.Add(lblCategoria);
            pnlFiltros.Controls.Add(cmbCategoria);
            pnlFiltros.Controls.Add(lblArticulo);
            pnlFiltros.Controls.Add(cmbArticulo);
            pnlFiltros.Controls.Add(btnBuscar);
            pnlFiltros.Controls.Add(btnLimpiar);
            pnlFiltros.Location = new Point(13, 101);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1054, 72);
            pnlFiltros.TabIndex = 2;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(3, 11);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(70, 7);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(110, 23);
            dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(195, 11);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(241, 7);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(110, 23);
            dtpHasta.TabIndex = 3;
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(366, 11);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(60, 15);
            lblVendedor.TabIndex = 4;
            lblVendedor.Text = "Vendedor:";
            // 
            // cmbVendedor
            // 
            cmbVendedor.FormattingEnabled = true;
            cmbVendedor.Location = new Point(432, 7);
            cmbVendedor.Name = "cmbVendedor";
            cmbVendedor.Size = new Size(160, 23);
            cmbVendedor.TabIndex = 5;
            // 
            // lblMedioPago
            // 
            lblMedioPago.AutoSize = true;
            lblMedioPago.Location = new Point(607, 11);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(90, 15);
            lblMedioPago.TabIndex = 6;
            lblMedioPago.Text = "Medio de pago:";
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(703, 7);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(160, 23);
            cmbMedioPago.TabIndex = 7;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(3, 45);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 8;
            lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(70, 41);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(281, 23);
            cmbCategoria.TabIndex = 9;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Location = new Point(366, 45);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(52, 15);
            lblArticulo.TabIndex = 10;
            lblArticulo.Text = "Artículo:";
            // 
            // cmbArticulo
            // 
            cmbArticulo.FormattingEnabled = true;
            cmbArticulo.Location = new Point(432, 41);
            cmbArticulo.Name = "cmbArticulo";
            cmbArticulo.Size = new Size(431, 23);
            cmbArticulo.TabIndex = 11;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(878, 38);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(87, 29);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(971, 38);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(80, 29);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // dgvInforme
            // 
            dgvInforme.AllowUserToAddRows = false;
            dgvInforme.AllowUserToDeleteRows = false;
            dgvInforme.AllowUserToResizeRows = false;
            dgvInforme.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInforme.BackgroundColor = SystemColors.Window;
            dgvInforme.ColumnHeadersHeight = 32;
            dgvInforme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvInforme.Location = new Point(13, 179);
            dgvInforme.MultiSelect = false;
            dgvInforme.Name = "dgvInforme";
            dgvInforme.ReadOnly = true;
            dgvInforme.RowHeadersVisible = false;
            dgvInforme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInforme.Size = new Size(1054, 362);
            dgvInforme.TabIndex = 3;
            // 
            // lblTotales
            // 
            lblTotales.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotales.AutoSize = true;
            lblTotales.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotales.Location = new Point(13, 559);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(0, 15);
            lblTotales.TabIndex = 4;
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportar.Location = new Point(837, 551);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(124, 30);
            btnExportar.TabIndex = 5;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Location = new Point(967, 551);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // frmInformesVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 592);
            Controls.Add(btnVolver);
            Controls.Add(btnExportar);
            Controls.Add(lblTotales);
            Controls.Add(dgvInforme);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlModo);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1096, 631);
            Name = "frmInformesVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Informes de ventas";
            pnlModo.ResumeLayout(false);
            pnlModo.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInforme).EndInit();
            // 
            // ttAyuda: explicación de cada combo al pasar el mouse
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbVendedor, "Filtrá el informe por vendedor.");
            ttAyuda.SetToolTip(cmbMedioPago, "Filtrá el informe por medio de pago.");
            ttAyuda.SetToolTip(cmbCategoria, "Filtrá el informe por categoría de artículo.");
            ttAyuda.SetToolTip(cmbArticulo, "Filtrá el informe por un artículo en particular.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

        private Label lblTitulo;
        private Panel pnlModo;
        private Label lblModo;
        private Button btnPorFecha;
        private Button btnDetalle;
        private Button btnPorRubro;
        private Button btnPorArticulo;
        private Button btnPorMedioPago;
        private Panel pnlFiltros;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Label lblVendedor;
        private ComboBox cmbVendedor;
        private Label lblMedioPago;
        private ComboBox cmbMedioPago;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblArticulo;
        private ComboBox cmbArticulo;
        private Button btnBuscar;
        private Button btnLimpiar;
        private DataGridView dgvInforme;
        private Label lblTotales;
        private Button btnExportar;
        private Button btnVolver;
    }
}
