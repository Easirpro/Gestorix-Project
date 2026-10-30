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
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnNuevacompra = new Button();
            btnDetalle = new Button();
            btnAnular = new Button();
            button5 = new Button();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            lblBuscarCompra = new Label();
            txtBuscarCompra = new TextBox();
            btnBuscar = new Button();
            btnLimpiarFiltros = new Button();
            dataGridView1 = new DataGridView();
            clnFecha = new DataGridViewTextBoxColumn();
            clnProveedor = new DataGridViewTextBoxColumn();
            clnTipoFactura = new DataGridViewTextBoxColumn();
            clnNCoprobante = new DataGridViewTextBoxColumn();
            clnTotal = new DataGridViewTextBoxColumn();
            clnEstado = new DataGridViewTextBoxColumn();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(192, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de compras";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = SystemColors.GrayText;
            lblDescripcion.Location = new Point(13, 38);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(293, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Registrá, consultá y anulá las compras a proveedores.";
            //
            // btnNuevacompra
            //
            btnNuevacompra.Image = (Image)resources.GetObject("btnNuevacompra.Image");
            btnNuevacompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevacompra.Location = new Point(12, 64);
            btnNuevacompra.Name = "btnNuevacompra";
            btnNuevacompra.Size = new Size(125, 34);
            btnNuevacompra.TabIndex = 2;
            btnNuevacompra.Text = "Nueva compra";
            btnNuevacompra.TextAlign = ContentAlignment.MiddleRight;
            btnNuevacompra.UseVisualStyleBackColor = true;
            btnNuevacompra.Click += btnNuevacompra_Click;
            //
            // btnDetalle
            //
            btnDetalle.Image = (Image)resources.GetObject("btnDetalle.Image");
            btnDetalle.ImageAlign = ContentAlignment.MiddleLeft;
            btnDetalle.Location = new Point(143, 64);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(100, 34);
            btnDetalle.TabIndex = 3;
            btnDetalle.Text = "Ver detalle";
            btnDetalle.TextAlign = ContentAlignment.MiddleRight;
            btnDetalle.UseVisualStyleBackColor = true;
            btnDetalle.Click += btnDetalle_Click;
            //
            // btnAnular
            //
            btnAnular.Image = (Image)resources.GetObject("btnAnular.Image");
            btnAnular.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnular.Location = new Point(249, 64);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(85, 34);
            btnAnular.TabIndex = 4;
            btnAnular.Text = "Anular";
            btnAnular.TextAlign = ContentAlignment.MiddleRight;
            btnAnular.UseVisualStyleBackColor = true;
            btnAnular.Click += btnAnular_Click;
            //
            // button5
            //
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(340, 64);
            button5.Name = "button5";
            button5.Size = new Size(105, 34);
            button5.TabIndex = 5;
            button5.Text = "Actualizar";
            button5.TextAlign = ContentAlignment.MiddleRight;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(12, 117);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 6;
            label1.Text = "Desde";
            //
            // dateTimePicker1
            //
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(56, 113);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(115, 23);
            dateTimePicker1.TabIndex = 7;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(185, 117);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 8;
            label2.Text = "Hasta";
            //
            // dateTimePicker2
            //
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(227, 113);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(115, 23);
            dateTimePicker2.TabIndex = 9;
            //
            // lblBuscarCompra
            //
            lblBuscarCompra.AutoSize = true;
            lblBuscarCompra.Location = new Point(360, 117);
            lblBuscarCompra.Name = "lblBuscarCompra";
            lblBuscarCompra.Size = new Size(147, 15);
            lblBuscarCompra.TabIndex = 10;
            lblBuscarCompra.Text = "Proveedor o comprobante:";
            //
            // txtBuscarCompra
            //
            txtBuscarCompra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarCompra.Location = new Point(513, 113);
            txtBuscarCompra.Name = "txtBuscarCompra";
            txtBuscarCompra.PlaceholderText = "Nombre o número";
            txtBuscarCompra.Size = new Size(271, 23);
            txtBuscarCompra.TabIndex = 11;
            //
            // btnBuscar
            //
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(792, 109);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(85, 32);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            //
            // btnLimpiarFiltros
            //
            btnLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiarFiltros.Location = new Point(883, 109);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(105, 32);
            btnLimpiarFiltros.TabIndex = 13;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            //
            // dataGridView1
            //
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clnFecha, clnProveedor, clnTipoFactura, clnNCoprobante, clnTotal, clnEstado });
            dataGridView1.Location = new Point(12, 149);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(976, 447);
            dataGridView1.TabIndex = 14;
            //
            // clnFecha
            //
            clnFecha.FillWeight = 80F;
            clnFecha.HeaderText = "Fecha";
            clnFecha.MinimumWidth = 90;
            clnFecha.Name = "clnFecha";
            clnFecha.ReadOnly = true;
            //
            // clnProveedor
            //
            clnProveedor.FillWeight = 150F;
            clnProveedor.HeaderText = "Proveedor";
            clnProveedor.MinimumWidth = 150;
            clnProveedor.Name = "clnProveedor";
            clnProveedor.ReadOnly = true;
            //
            // clnTipoFactura
            //
            clnTipoFactura.HeaderText = "Tipo comprobante";
            clnTipoFactura.MinimumWidth = 110;
            clnTipoFactura.Name = "clnTipoFactura";
            clnTipoFactura.ReadOnly = true;
            //
            // clnNCoprobante
            //
            clnNCoprobante.HeaderText = "N.º comprobante";
            clnNCoprobante.MinimumWidth = 130;
            clnNCoprobante.Name = "clnNCoprobante";
            clnNCoprobante.ReadOnly = true;
            //
            // clnTotal
            //
            clnTotal.FillWeight = 80F;
            clnTotal.HeaderText = "Total";
            clnTotal.MinimumWidth = 100;
            clnTotal.Name = "clnTotal";
            clnTotal.ReadOnly = true;
            //
            // clnEstado
            //
            clnEstado.HeaderText = "Estado";
            clnEstado.MinimumWidth = 120;
            clnEstado.Name = "clnEstado";
            clnEstado.ReadOnly = true;
            //
            // btnSalir
            //
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(893, 604);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(95, 34);
            btnSalir.TabIndex = 15;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // frmCompras
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescripcion);
            Controls.Add(btnNuevacompra);
            Controls.Add(btnDetalle);
            Controls.Add(btnAnular);
            Controls.Add(button5);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(dateTimePicker2);
            Controls.Add(lblBuscarCompra);
            Controls.Add(txtBuscarCompra);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(dataGridView1);
            Controls.Add(btnSalir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 450);
            Name = "frmCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compras";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDescripcion;
        private Button btnNuevacompra;
        private Button btnDetalle;
        private Button btnAnular;
        private Button button5;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private Label lblBuscarCompra;
        private TextBox txtBuscarCompra;
        private Button btnBuscar;
        private Button btnLimpiarFiltros;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn clnFecha;
        private DataGridViewTextBoxColumn clnProveedor;
        private DataGridViewTextBoxColumn clnTipoFactura;
        private DataGridViewTextBoxColumn clnNCoprobante;
        private DataGridViewTextBoxColumn clnTotal;
        private DataGridViewTextBoxColumn clnEstado;
        private Button btnSalir;
    }
}
