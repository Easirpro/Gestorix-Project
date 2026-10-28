namespace CapaVista
{
    partial class frmCargaRapidaPrecios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox gpbBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPrecioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNuevoPrecio;

        private System.Windows.Forms.GroupBox gpbProveedorCategoria;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;

        private System.Windows.Forms.GroupBox gpbAumento;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.NumericUpDown nudPorcentaje;
        private System.Windows.Forms.Label lblAplicar;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(
                    typeof(frmCargaRapidaPrecios));

            gpbBusqueda = new System.Windows.Forms.GroupBox();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscarProducto = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();

            gpbProveedorCategoria = new System.Windows.Forms.GroupBox();
            lblProveedor = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            lblSucursal = new System.Windows.Forms.Label();
            comboBox2 = new System.Windows.Forms.ComboBox();
            lblCategoria = new System.Windows.Forms.Label();
            comboBox3 = new System.Windows.Forms.ComboBox();
            lblRubro = new System.Windows.Forms.Label();
            comboBox4 = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();

            dgvPrecios = new System.Windows.Forms.DataGridView();
            clnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clnProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clnPrecioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clnNuevoPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();

            gpbAumento = new System.Windows.Forms.GroupBox();
            lblPorcentaje = new System.Windows.Forms.Label();
            nudPorcentaje = new System.Windows.Forms.NumericUpDown();
            lblAplicar = new System.Windows.Forms.Label();

            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

            gpbBusqueda.SuspendLayout();
            gpbProveedorCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrecios).BeginInit();
            gpbAumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).BeginInit();
            SuspendLayout();

            // 
            // gpbBusqueda
            // 
            gpbBusqueda.Controls.Add(lblBuscar);
            gpbBusqueda.Controls.Add(txtBuscarProducto);
            gpbBusqueda.Controls.Add(label1);
            gpbBusqueda.Location = new System.Drawing.Point(12, 12);
            gpbBusqueda.Name = "gpbBusqueda";
            gpbBusqueda.Size = new System.Drawing.Size(1160, 65);
            gpbBusqueda.TabIndex = 0;
            gpbBusqueda.TabStop = false;
            gpbBusqueda.Text = "Buscar producto";
            gpbBusqueda.Anchor =
                AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbBusqueda.Enter += gpbBusqueda_Enter;

            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new System.Drawing.Point(15, 29);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new System.Drawing.Size(136, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Código / SKU / Nombre:";

            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new System.Drawing.Point(160, 25);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new System.Drawing.Size(400, 23);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.KeyDown += txtBuscarProducto_KeyDown;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font(
                "Segoe UI", 8F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(580, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(235, 13);
            label1.TabIndex = 2;
            label1.Text = "* La modificación de precio se carga por artículo.";

            // 
            // gpbProveedorCategoria
            // 
            gpbProveedorCategoria.Controls.Add(lblProveedor);
            gpbProveedorCategoria.Controls.Add(comboBox1);
            gpbProveedorCategoria.Controls.Add(lblSucursal);
            gpbProveedorCategoria.Controls.Add(comboBox2);
            gpbProveedorCategoria.Controls.Add(lblCategoria);
            gpbProveedorCategoria.Controls.Add(comboBox3);
            gpbProveedorCategoria.Controls.Add(lblRubro);
            gpbProveedorCategoria.Controls.Add(comboBox4);
            gpbProveedorCategoria.Controls.Add(label6);

            gpbProveedorCategoria.Location = new System.Drawing.Point(12, 82);
            gpbProveedorCategoria.Name = "gpbProveedorCategoria";
            gpbProveedorCategoria.Size = new System.Drawing.Size(1160, 78);
            gpbProveedorCategoria.TabIndex = 1;
            gpbProveedorCategoria.TabStop = false;
            gpbProveedorCategoria.Text =
                "Filtros: Proveedor / Sucursal / Categoría / Rubro";
            gpbProveedorCategoria.Anchor =
                AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new System.Drawing.Point(15, 38);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new System.Drawing.Size(64, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";

            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(85, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(190, 23);
            comboBox1.TabIndex = 1;

            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new System.Drawing.Point(290, 38);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new System.Drawing.Size(57, 15);
            lblSucursal.TabIndex = 2;
            lblSucursal.Text = "Sucursal:";

            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(352, 34);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(190, 23);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new System.Drawing.Point(558, 38);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new System.Drawing.Size(64, 15);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoría:";

            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(628, 34);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(190, 23);
            comboBox3.TabIndex = 5;

            // 
            // lblRubro
            // 
            lblRubro.AutoSize = true;
            lblRubro.Location = new System.Drawing.Point(835, 38);
            lblRubro.Name = "lblRubro";
            lblRubro.Size = new System.Drawing.Size(45, 15);
            lblRubro.TabIndex = 6;
            lblRubro.Text = "Rubro:";

            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(885, 34);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(250, 23);
            comboBox4.TabIndex = 7;

            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(15, 60);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(0, 15);
            label6.TabIndex = 8;

            // 
            // dgvPrecios
            // 
            dgvPrecios.AllowUserToAddRows = false;
            dgvPrecios.AllowUserToDeleteRows = false;
            dgvPrecios.AllowUserToResizeRows = false;
            dgvPrecios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrecios.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvPrecios.BorderStyle = BorderStyle.Fixed3D;
            dgvPrecios.ColumnHeadersHeight = 35;
            dgvPrecios.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvPrecios.Columns.AddRange(new DataGridViewColumn[]
            {
                clnCodigo,
                clnProducto,
                clnPrecioActual,
                clnNuevoPrecio
            });

            dgvPrecios.Location = new System.Drawing.Point(12, 170);
            dgvPrecios.Name = "dgvPrecios";
            dgvPrecios.Size = new System.Drawing.Size(1160, 465);
            dgvPrecios.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;
            dgvPrecios.MultiSelect = false;
            dgvPrecios.ReadOnly = false;
            dgvPrecios.RowHeadersVisible = false;
            dgvPrecios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrecios.ScrollBars = ScrollBars.Both;
            dgvPrecios.TabIndex = 2;

            // 
            // clnCodigo
            // 
            clnCodigo.FillWeight = 20F;
            clnCodigo.HeaderText = "Código / SKU";
            clnCodigo.Name = "clnCodigo";
            clnCodigo.ReadOnly = true;
            clnCodigo.SortMode = DataGridViewColumnSortMode.NotSortable;

            // 
            // clnProducto
            // 
            clnProducto.FillWeight = 45F;
            clnProducto.HeaderText = "Producto";
            clnProducto.Name = "clnProducto";
            clnProducto.ReadOnly = true;

            // 
            // clnPrecioActual
            // 
            clnPrecioActual.FillWeight = 17F;
            clnPrecioActual.HeaderText = "Precio actual";
            clnPrecioActual.Name = "clnPrecioActual";
            clnPrecioActual.ReadOnly = true;

            // 
            // clnNuevoPrecio
            // 
            clnNuevoPrecio.FillWeight = 18F;
            clnNuevoPrecio.HeaderText = "Precio provisorio / nuevo";
            clnNuevoPrecio.Name = "clnNuevoPrecio";
            clnNuevoPrecio.ReadOnly = false;

            // 
            // gpbAumento
            // Se conserva declarado para compatibilidad con el formulario,
            // pero no se agrega visualmente porque el aumento va en otra pantalla.
            // 
            gpbAumento.Controls.Add(lblPorcentaje);
            gpbAumento.Controls.Add(nudPorcentaje);
            gpbAumento.Controls.Add(lblAplicar);
            gpbAumento.Location = new System.Drawing.Point(12, 170);
            gpbAumento.Name = "gpbAumento";
            gpbAumento.Size = new System.Drawing.Size(272, 125);
            gpbAumento.TabIndex = 3;
            gpbAumento.TabStop = false;
            gpbAumento.Text = "Aumento porcentual";

            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Location = new System.Drawing.Point(18, 33);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new System.Drawing.Size(66, 15);
            lblPorcentaje.TabIndex = 0;
            lblPorcentaje.Text = "Porcentaje:";

            // 
            // nudPorcentaje
            // 
            nudPorcentaje.DecimalPlaces = 2;
            nudPorcentaje.Location = new System.Drawing.Point(95, 30);
            nudPorcentaje.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPorcentaje.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nudPorcentaje.Name = "nudPorcentaje";
            nudPorcentaje.Size = new System.Drawing.Size(90, 23);
            nudPorcentaje.TabIndex = 1;
            nudPorcentaje.TextAlign = HorizontalAlignment.Right;

            // 
            // lblAplicar
            // 
            lblAplicar.AutoSize = true;
            lblAplicar.Font = new System.Drawing.Font("Segoe UI", 7F);
            lblAplicar.Location = new System.Drawing.Point(23, 61);
            lblAplicar.Name = "lblAplicar";
            lblAplicar.Size = new System.Drawing.Size(158, 12);
            lblAplicar.TabIndex = 2;
            lblAplicar.Text = "* Aplica el porcentaje del aumento.";

            // 
            // btnGuardar
            // 
            btnGuardar.Location = new System.Drawing.Point(942, 645);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(110, 32);
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(1062, 645);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(110, 32);
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;

            // 
            // frmCargaRapidaPrecios
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1184, 690);
            MinimumSize = new System.Drawing.Size(1000, 600);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvPrecios);
            Controls.Add(gpbProveedorCategoria);
            Controls.Add(gpbBusqueda);

            FormBorderStyle = FormBorderStyle.Sizable;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = true;
            MinimizeBox = true;
            Name = "frmCargaRapidaPrecios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carga rápida de precios";

            gpbBusqueda.ResumeLayout(false);
            gpbBusqueda.PerformLayout();

            gpbProveedorCategoria.ResumeLayout(false);
            gpbProveedorCategoria.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)dgvPrecios).EndInit();

            gpbAumento.ResumeLayout(false);
            gpbAumento.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).EndInit();

            ResumeLayout(false);
        }

        #endregion
    }
}
