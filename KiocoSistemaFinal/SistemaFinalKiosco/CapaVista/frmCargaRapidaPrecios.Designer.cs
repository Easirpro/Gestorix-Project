namespace CapaVista
{
    partial class frmCargaRapidaPrecios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox gpbBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.GroupBox gpbAumento;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.NumericUpDown nudPorcentaje;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaRapidaPrecios));
            gpbBusqueda = new GroupBox();
            label1 = new Label();
            lblBuscar = new Label();
            txtBuscarProducto = new TextBox();
            dgvPrecios = new DataGridView();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnProducto = new DataGridViewTextBoxColumn();
            clnPrecioActual = new DataGridViewTextBoxColumn();
            clnNuevoPrecio = new DataGridViewTextBoxColumn();
            gpbAumento = new GroupBox();
            lblPorcentaje = new Label();
            nudPorcentaje = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            gpbProveedorCategoria = new GroupBox();
            label6 = new Label();
            comboBox4 = new ComboBox();
            lblRubro = new Label();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            lblSucursal = new Label();
            lblCategoria = new Label();
            lblProveedor = new Label();
            lblAplicar = new Label();
            gpbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrecios).BeginInit();
            gpbAumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).BeginInit();
            gpbProveedorCategoria.SuspendLayout();
            SuspendLayout();
            // 
            // gpbBusqueda
            // 
            gpbBusqueda.Controls.Add(label1);
            gpbBusqueda.Controls.Add(lblBuscar);
            gpbBusqueda.Controls.Add(txtBuscarProducto);
            gpbBusqueda.Location = new Point(12, 12);
            gpbBusqueda.Name = "gpbBusqueda";
            gpbBusqueda.Size = new Size(776, 77);
            gpbBusqueda.TabIndex = 0;
            gpbBusqueda.TabStop = false;
            gpbBusqueda.Text = "Buscar producto";
            gpbBusqueda.Enter += gpbBusqueda_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(516, 33);
            label1.Name = "label1";
            label1.Size = new Size(193, 12);
            label1.TabIndex = 2;
            label1.Text = "* La modificación de precio se carga por articulo.";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(18, 31);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(136, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Código / SKU / Nombre:";
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(160, 28);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(350, 23);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.KeyDown += txtBuscarProducto_KeyDown;
            // 
            // dgvPrecios
            // 
            dgvPrecios.AllowUserToAddRows = false;
            dgvPrecios.AllowUserToDeleteRows = false;
            dgvPrecios.AllowUserToResizeRows = false;
            dgvPrecios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrecios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrecios.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnProducto, clnPrecioActual, clnNuevoPrecio });
            dgvPrecios.Location = new Point(12, 95);
            dgvPrecios.MultiSelect = false;
            dgvPrecios.Name = "dgvPrecios";
            dgvPrecios.RowHeadersVisible = false;
            dgvPrecios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrecios.Size = new Size(776, 150);
            dgvPrecios.TabIndex = 2;
            // 
            // clnCodigo
            // 
            clnCodigo.HeaderText = "Código / SKU";
            clnCodigo.Name = "clnCodigo";
            clnCodigo.ReadOnly = true;
            clnCodigo.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // clnProducto
            // 
            clnProducto.HeaderText = "Producto";
            clnProducto.Name = "clnProducto";
            clnProducto.ReadOnly = true;
            // 
            // clnPrecioActual
            // 
            clnPrecioActual.HeaderText = "Precio actual";
            clnPrecioActual.Name = "clnPrecioActual";
            clnPrecioActual.ReadOnly = true;
            // 
            // clnNuevoPrecio
            // 
            clnNuevoPrecio.HeaderText = "Nuevo precio";
            clnNuevoPrecio.Name = "clnNuevoPrecio";
            // 
            // gpbAumento
            // 
            gpbAumento.Controls.Add(lblAplicar);
            gpbAumento.Controls.Add(lblPorcentaje);
            gpbAumento.Controls.Add(nudPorcentaje);
            gpbAumento.Location = new Point(516, 253);
            gpbAumento.Name = "gpbAumento";
            gpbAumento.Size = new Size(272, 125);
            gpbAumento.TabIndex = 3;
            gpbAumento.TabStop = false;
            gpbAumento.Text = "Aumento porcentual";
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Location = new Point(18, 33);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(66, 15);
            lblPorcentaje.TabIndex = 0;
            lblPorcentaje.Text = "Porcentaje:";
            // 
            // nudPorcentaje
            // 
            nudPorcentaje.DecimalPlaces = 2;
            nudPorcentaje.Location = new Point(95, 30);
            nudPorcentaje.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPorcentaje.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nudPorcentaje.Name = "nudPorcentaje";
            nudPorcentaje.Size = new Size(90, 23);
            nudPorcentaje.TabIndex = 1;
            nudPorcentaje.TextAlign = HorizontalAlignment.Right;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(568, 429);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 32);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(683, 429);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 32);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // gpbProveedorCategoria
            // 
            gpbProveedorCategoria.Controls.Add(label6);
            gpbProveedorCategoria.Controls.Add(comboBox4);
            gpbProveedorCategoria.Controls.Add(lblRubro);
            gpbProveedorCategoria.Controls.Add(comboBox3);
            gpbProveedorCategoria.Controls.Add(comboBox2);
            gpbProveedorCategoria.Controls.Add(comboBox1);
            gpbProveedorCategoria.Controls.Add(lblSucursal);
            gpbProveedorCategoria.Controls.Add(lblCategoria);
            gpbProveedorCategoria.Controls.Add(lblProveedor);
            gpbProveedorCategoria.Location = new Point(15, 253);
            gpbProveedorCategoria.Name = "gpbProveedorCategoria";
            gpbProveedorCategoria.Size = new Size(450, 152);
            gpbProveedorCategoria.TabIndex = 6;
            gpbProveedorCategoria.TabStop = false;
            gpbProveedorCategoria.Text = "Buscar Proveedor / Sucursal /  Categoria / Rubro";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 131);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 8;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(313, 85);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 23);
            comboBox4.TabIndex = 7;
            // 
            // lblRubro
            // 
            lblRubro.AutoSize = true;
            lblRubro.Location = new Point(264, 88);
            lblRubro.Name = "lblRubro";
            lblRubro.Size = new Size(45, 15);
            lblRubro.TabIndex = 6;
            lblRubro.Text = "Rubro :";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(96, 85);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(313, 39);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 4;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(96, 39);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(252, 42);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(57, 15);
            lblSucursal.TabIndex = 2;
            lblSucursal.Text = "Sucursal :";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(29, 88);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(64, 15);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoria :";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(29, 42);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(67, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor :";
            lblProveedor.Click += label2_Click;
            // 
            // lblAplicar
            // 
            lblAplicar.AutoSize = true;
            lblAplicar.Font = new Font("Segoe UI", 7F);
            lblAplicar.Location = new Point(23, 61);
            lblAplicar.Name = "lblAplicar";
            lblAplicar.Size = new Size(158, 12);
            lblAplicar.TabIndex = 2;
            lblAplicar.Text = "* Aplica el porcentaje del aumento.";
            // 
            // frmCargaRapidaPrecios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 484);
            Controls.Add(gpbProveedorCategoria);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(gpbAumento);
            Controls.Add(dgvPrecios);
            Controls.Add(gpbBusqueda);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCargaRapidaPrecios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carga rápida de precios";
            gpbBusqueda.ResumeLayout(false);
            gpbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrecios).EndInit();
            gpbAumento.ResumeLayout(false);
            gpbAumento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).EndInit();
            gpbProveedorCategoria.ResumeLayout(false);
            gpbProveedorCategoria.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn clnCodigo;
        private DataGridViewTextBoxColumn clnProducto;
        private DataGridViewTextBoxColumn clnPrecioActual;
        private DataGridViewTextBoxColumn clnNuevoPrecio;
        private Label label1;
        private GroupBox gpbProveedorCategoria;
        private Label lblSucursal;
        private Label lblCategoria;
        private Label lblProveedor;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox4;
        private Label lblRubro;
        private ComboBox comboBox3;
        private Label label6;
        private Label lblAplicar;
    }
}