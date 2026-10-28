namespace CapaVista
{
    partial class frmCompras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompras));
            btnNuevacompra = new Button();
            btnDetalle = new Button();
            btnAnular = new Button();
            btnRecepcionCompra = new Button();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            lblBuscarCompra = new Label();
            txtBuscarCompra = new TextBox();
            btnBuscar = new Button();
            btnLimpiarFiltros = new Button();
            button5 = new Button();
            dataGridView1 = new DataGridView();
            clnFecha = new DataGridViewTextBoxColumn();
            clnProveedor = new DataGridViewTextBoxColumn();
            clnTipoFactura = new DataGridViewTextBoxColumn();
            clnNCoprobante = new DataGridViewTextBoxColumn();
            clnTotal = new DataGridViewTextBoxColumn();
            clnEstado = new DataGridViewTextBoxColumn();
            btnSalir = new Button();
            pnlPrincipal = new TableLayoutPanel();
            flpAcciones = new FlowLayoutPanel();
            pnlFiltros = new TableLayoutPanel();
            flpFechas = new FlowLayoutPanel();
            flpBusqueda = new FlowLayoutPanel();
            flpPie = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlPrincipal.SuspendLayout();
            flpAcciones.SuspendLayout();
            pnlFiltros.SuspendLayout();
            flpFechas.SuspendLayout();
            flpBusqueda.SuspendLayout();
            flpPie.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.ColumnCount = 1;
            pnlPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlPrincipal.Controls.Add(flpAcciones, 0, 0);
            pnlPrincipal.Controls.Add(pnlFiltros, 0, 1);
            pnlPrincipal.Controls.Add(dataGridView1, 0, 2);
            pnlPrincipal.Controls.Add(flpPie, 0, 3);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.RowCount = 4;
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlPrincipal.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pnlPrincipal.Padding = new Padding(8);
            pnlPrincipal.TabIndex = 0;
            // 
            // flpAcciones
            // 
            flpAcciones.AutoSize = true;
            flpAcciones.Dock = DockStyle.Fill;
            flpAcciones.WrapContents = true;
            flpAcciones.Name = "flpAcciones";
            flpAcciones.Padding = new Padding(0, 0, 0, 6);
            flpAcciones.TabIndex = 0;
            // 
            // btnNuevacompra
            // 
            btnNuevacompra.Image = (Image)resources.GetObject("btnNuevacompra.Image");
            btnNuevacompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevacompra.Margin = new Padding(0, 0, 6, 4);
            btnNuevacompra.Name = "btnNuevacompra";
            btnNuevacompra.Size = new Size(125, 34);
            btnNuevacompra.TabIndex = 0;
            btnNuevacompra.Text = "Nueva compra";
            btnNuevacompra.TextAlign = ContentAlignment.MiddleRight;
            btnNuevacompra.UseVisualStyleBackColor = true;
            btnNuevacompra.Click += btnNuevacompra_Click;
            // 
            // btnDetalle
            // 
            btnDetalle.Image = (Image)resources.GetObject("btnDetalle.Image");
            btnDetalle.ImageAlign = ContentAlignment.MiddleLeft;
            btnDetalle.Margin = new Padding(0, 0, 6, 4);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(100, 34);
            btnDetalle.TabIndex = 1;
            btnDetalle.Text = "Ver detalle";
            btnDetalle.TextAlign = ContentAlignment.MiddleRight;
            btnDetalle.UseVisualStyleBackColor = true;
            btnDetalle.Click += btnDetalle_Click;
            // 
            // btnRecepcionCompra
            // 
            btnRecepcionCompra.Margin = new Padding(0, 0, 6, 4);
            btnRecepcionCompra.Name = "btnRecepcionCompra";
            btnRecepcionCompra.Size = new Size(145, 34);
            btnRecepcionCompra.TabIndex = 2;
            btnRecepcionCompra.Text = "Controlar recepción";
            btnRecepcionCompra.UseVisualStyleBackColor = true;
            // 
            // btnAnular
            // 
            btnAnular.Image = (Image)resources.GetObject("btnAnular.Image");
            btnAnular.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnular.Margin = new Padding(0, 0, 6, 4);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(85, 34);
            btnAnular.TabIndex = 3;
            btnAnular.Text = "Anular";
            btnAnular.TextAlign = ContentAlignment.MiddleRight;
            btnAnular.UseVisualStyleBackColor = true;
            btnAnular.Click += btnAnular_Click;
            // 
            // button5
            // 
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Margin = new Padding(0, 0, 6, 4);
            button5.Name = "button5";
            button5.Size = new Size(105, 34);
            button5.TabIndex = 4;
            button5.Text = "Actualizar";
            button5.TextAlign = ContentAlignment.MiddleRight;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            flpAcciones.Controls.Add(btnNuevacompra);
            flpAcciones.Controls.Add(btnDetalle);
            flpAcciones.Controls.Add(btnRecepcionCompra);
            flpAcciones.Controls.Add(btnAnular);
            flpAcciones.Controls.Add(button5);
            // 
            // pnlFiltros
            // 
            pnlFiltros.AutoSize = true;
            pnlFiltros.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlFiltros.ColumnCount = 1;
            pnlFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlFiltros.Controls.Add(flpFechas, 0, 0);
            pnlFiltros.Controls.Add(flpBusqueda, 0, 1);
            pnlFiltros.Dock = DockStyle.Fill;
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.RowCount = 2;
            pnlFiltros.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pnlFiltros.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pnlFiltros.Padding = new Padding(0, 4, 0, 8);
            pnlFiltros.TabIndex = 1;
            // 
            // flpFechas
            // 
            flpFechas.AutoSize = true;
            flpFechas.Dock = DockStyle.Fill;
            flpFechas.WrapContents = true;
            flpFechas.Name = "flpFechas";
            flpFechas.Padding = new Padding(0, 0, 0, 4);
            flpFechas.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Margin = new Padding(0, 7, 5, 4);
            label1.Name = "label1";
            label1.Text = "Desde";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Margin = new Padding(0, 2, 14, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(115, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Margin = new Padding(0, 7, 5, 4);
            label2.Name = "label2";
            label2.Text = "Hasta";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Margin = new Padding(0, 2, 14, 4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(115, 23);
            dateTimePicker2.TabIndex = 1;
            flpFechas.Controls.Add(label1);
            flpFechas.Controls.Add(dateTimePicker1);
            flpFechas.Controls.Add(label2);
            flpFechas.Controls.Add(dateTimePicker2);
            // 
            // flpBusqueda
            // 
            flpBusqueda.AutoSize = true;
            flpBusqueda.Dock = DockStyle.Fill;
            flpBusqueda.WrapContents = true;
            flpBusqueda.Name = "flpBusqueda";
            flpBusqueda.TabIndex = 1;
            // 
            // lblBuscarCompra
            // 
            lblBuscarCompra.AutoSize = true;
            lblBuscarCompra.Margin = new Padding(0, 7, 6, 4);
            lblBuscarCompra.Name = "lblBuscarCompra";
            lblBuscarCompra.Text = "Proveedor o comprobante:";
            // 
            // txtBuscarCompra
            // 
            txtBuscarCompra.Margin = new Padding(0, 3, 8, 4);
            txtBuscarCompra.Name = "txtBuscarCompra";
            txtBuscarCompra.PlaceholderText = "Nombre o número";
            txtBuscarCompra.Size = new Size(240, 23);
            txtBuscarCompra.TabIndex = 2;
            txtBuscarCompra.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Margin = new Padding(0, 0, 6, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(85, 32);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Margin = new Padding(0, 0, 6, 4);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(105, 32);
            btnLimpiarFiltros.TabIndex = 4;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            flpBusqueda.Controls.Add(lblBuscarCompra);
            flpBusqueda.Controls.Add(txtBuscarCompra);
            flpBusqueda.Controls.Add(btnBuscar);
            flpBusqueda.Controls.Add(btnLimpiarFiltros);
            pnlFiltros.Controls.Add(flpFechas, 0, 0);
            pnlFiltros.Controls.Add(flpBusqueda, 0, 1);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.ScrollBars = ScrollBars.Both;
            clnFecha.MinimumWidth = 90;
            clnProveedor.MinimumWidth = 150;
            clnTipoFactura.MinimumWidth = 110;
            clnNCoprobante.MinimumWidth = 130;
            clnTotal.MinimumWidth = 100;
            clnEstado.MinimumWidth = 120;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clnFecha, clnProveedor, clnTipoFactura, clnNCoprobante, clnTotal, clnEstado });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.TabIndex = 2;
            // 
            // clnFecha
            // 
            clnFecha.FillWeight = 80F;
            clnFecha.HeaderText = "Fecha";
            clnFecha.Name = "clnFecha";
            clnFecha.ReadOnly = true;
            // 
            // clnProveedor
            // 
            clnProveedor.FillWeight = 150F;
            clnProveedor.HeaderText = "Proveedor";
            clnProveedor.Name = "clnProveedor";
            clnProveedor.ReadOnly = true;
            // 
            // clnTipoFactura
            // 
            clnTipoFactura.FillWeight = 100F;
            clnTipoFactura.HeaderText = "Tipo comprobante";
            clnTipoFactura.Name = "clnTipoFactura";
            clnTipoFactura.ReadOnly = true;
            // 
            // clnNCoprobante
            // 
            clnNCoprobante.FillWeight = 100F;
            clnNCoprobante.HeaderText = "N.º comprobante";
            clnNCoprobante.Name = "clnNCoprobante";
            clnNCoprobante.ReadOnly = true;
            // 
            // clnTotal
            // 
            clnTotal.FillWeight = 80F;
            clnTotal.HeaderText = "Total";
            clnTotal.Name = "clnTotal";
            clnTotal.ReadOnly = true;
            // 
            // clnEstado
            // 
            clnEstado.FillWeight = 100F;
            clnEstado.HeaderText = "Estado";
            clnEstado.Name = "clnEstado";
            clnEstado.ReadOnly = true;
            // 
            // flpPie
            // 
            flpPie.AutoSize = true;
            flpPie.Dock = DockStyle.Fill;
            flpPie.FlowDirection = FlowDirection.RightToLeft;
            flpPie.WrapContents = true;
            flpPie.Name = "flpPie";
            flpPie.Padding = new Padding(0, 8, 0, 0);
            flpPie.TabIndex = 3;
            // 
            // btnSalir
            // 
            btnSalir.Margin = new Padding(6, 0, 0, 0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(95, 34);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            flpPie.Controls.Add(btnSalir);
            // 
            // frmCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(pnlPrincipal);
            MinimumSize = new Size(700, 450);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCompras";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compras";
            WindowState = FormWindowState.Normal;

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flpPie.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            flpFechas.ResumeLayout(false);
            flpFechas.PerformLayout();
            flpBusqueda.ResumeLayout(false);
            flpBusqueda.PerformLayout();
            flpAcciones.ResumeLayout(false);
            pnlPrincipal.ResumeLayout(false);
            pnlPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNuevacompra;
        private Button btnDetalle;
        private Button btnAnular;
        private Button btnRecepcionCompra;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private Label lblBuscarCompra;
        private TextBox txtBuscarCompra;
        private Button btnBuscar;
        private Button btnLimpiarFiltros;
        private Button button5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn clnFecha;
        private DataGridViewTextBoxColumn clnProveedor;
        private DataGridViewTextBoxColumn clnTipoFactura;
        private DataGridViewTextBoxColumn clnNCoprobante;
        private DataGridViewTextBoxColumn clnTotal;
        private DataGridViewTextBoxColumn clnEstado;
        private Button btnSalir;
        private TableLayoutPanel pnlPrincipal;
        private FlowLayoutPanel flpAcciones;
        private TableLayoutPanel pnlFiltros;
        private FlowLayoutPanel flpFechas;
        private FlowLayoutPanel flpBusqueda;
        private FlowLayoutPanel flpPie;
    }
}
