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
        private System.Windows.Forms.Button btnAplicarAumento;
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
            lblBuscar = new Label();
            txtBuscarProducto = new TextBox();
            dgvPrecios = new DataGridView();
            gpbAumento = new GroupBox();
            lblPorcentaje = new Label();
            nudPorcentaje = new NumericUpDown();
            btnAplicarAumento = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnProducto = new DataGridViewTextBoxColumn();
            clnPrecioActual = new DataGridViewTextBoxColumn();
            clnNuevoPrecio = new DataGridViewTextBoxColumn();
            gpbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrecios).BeginInit();
            gpbAumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).BeginInit();
            SuspendLayout();
            // 
            // gpbBusqueda
            // 
            gpbBusqueda.Controls.Add(lblBuscar);
            gpbBusqueda.Controls.Add(txtBuscarProducto);
            gpbBusqueda.Location = new Point(12, 12);
            gpbBusqueda.Name = "gpbBusqueda";
            gpbBusqueda.Size = new Size(776, 70);
            gpbBusqueda.TabIndex = 0;
            gpbBusqueda.TabStop = false;
            gpbBusqueda.Text = "Buscar producto";
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
            dgvPrecios.Size = new Size(776, 250);
            dgvPrecios.TabIndex = 2;
            // 
            // gpbAumento
            // 
            gpbAumento.Controls.Add(lblPorcentaje);
            gpbAumento.Controls.Add(nudPorcentaje);
            gpbAumento.Controls.Add(btnAplicarAumento);
            gpbAumento.Location = new Point(12, 360);
            gpbAumento.Name = "gpbAumento";
            gpbAumento.Size = new Size(450, 75);
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
            // btnAplicarAumento
            // 
            btnAplicarAumento.Location = new Point(205, 28);
            btnAplicarAumento.Name = "btnAplicarAumento";
            btnAplicarAumento.Size = new Size(150, 27);
            btnAplicarAumento.TabIndex = 2;
            btnAplicarAumento.Text = "Aplicar aumento";
            btnAplicarAumento.UseVisualStyleBackColor = true;
            btnAplicarAumento.Click += btnAplicarAumento_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(568, 455);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 32);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar precios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(683, 455);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 32);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
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
            clnNuevoPrecio.ReadOnly = false;
            // 
            // frmCargaRapidaPrecios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 505);
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
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn clnCodigo;
        private DataGridViewTextBoxColumn clnProducto;
        private DataGridViewTextBoxColumn clnPrecioActual;
        private DataGridViewTextBoxColumn clnNuevoPrecio;
    }
}