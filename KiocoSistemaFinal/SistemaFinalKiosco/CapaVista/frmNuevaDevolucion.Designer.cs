namespace CapaVista
{
    partial class frmNuevaDevolucion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpVenta = new System.Windows.Forms.GroupBox();
            lblDesde = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            lblNroVenta = new System.Windows.Forms.Label();
            txtNroVenta = new System.Windows.Forms.TextBox();
            btnBuscarVentas = new System.Windows.Forms.Button();
            dgvVentas = new System.Windows.Forms.DataGridView();
            grpProducto = new System.Windows.Forms.GroupBox();
            dgvDetalle = new System.Windows.Forms.DataGridView();
            grpDatos = new System.Windows.Forms.GroupBox();
            lblCantidad = new System.Windows.Forms.Label();
            nudCantidad = new System.Windows.Forms.NumericUpDown();
            lblPrecio = new System.Windows.Forms.Label();
            lblPrecioValor = new System.Windows.Forms.Label();
            lblImporte = new System.Windows.Forms.Label();
            lblImporteValor = new System.Windows.Forms.Label();
            lblMotivo = new System.Windows.Forms.Label();
            cmbMotivo = new System.Windows.Forms.ComboBox();
            lblObservacion = new System.Windows.Forms.Label();
            txtObservacion = new System.Windows.Forms.TextBox();
            lblReintegro = new System.Windows.Forms.Label();
            rbEfectivo = new System.Windows.Forms.RadioButton();
            rbCambio = new System.Windows.Forms.RadioButton();
            chkReingresaStock = new System.Windows.Forms.CheckBox();
            lblCaja = new System.Windows.Forms.Label();
            btnRegistrar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            grpVenta.SuspendLayout();
            grpProducto.SuspendLayout();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // grpVenta
            // 
            grpVenta.Controls.Add(lblDesde);
            grpVenta.Controls.Add(dtpDesde);
            grpVenta.Controls.Add(lblHasta);
            grpVenta.Controls.Add(dtpHasta);
            grpVenta.Controls.Add(lblNroVenta);
            grpVenta.Controls.Add(txtNroVenta);
            grpVenta.Controls.Add(btnBuscarVentas);
            grpVenta.Controls.Add(dgvVentas);
            grpVenta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpVenta.Location = new System.Drawing.Point(12, 8);
            grpVenta.Name = "grpVenta";
            grpVenta.Size = new System.Drawing.Size(796, 205);
            grpVenta.TabIndex = 0;
            grpVenta.Text = "1. Venta de la que se devuelve";
            grpVenta.TabStop = false;
            // 
            // lblDesde
            // 
            lblDesde.Location = new System.Drawing.Point(12, 28);
            lblDesde.Name = "lblDesde";
            lblDesde.TabIndex = 1;
            lblDesde.Text = "Desde:";
            lblDesde.AutoSize = true;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new System.Drawing.Point(60, 24);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new System.Drawing.Size(115, 23);
            dtpDesde.TabIndex = 2;
            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblHasta
            // 
            lblHasta.Location = new System.Drawing.Point(185, 28);
            lblHasta.Name = "lblHasta";
            lblHasta.TabIndex = 3;
            lblHasta.Text = "Hasta:";
            lblHasta.AutoSize = true;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new System.Drawing.Point(230, 24);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new System.Drawing.Size(115, 23);
            dtpHasta.TabIndex = 4;
            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblNroVenta
            // 
            lblNroVenta.Location = new System.Drawing.Point(370, 28);
            lblNroVenta.Name = "lblNroVenta";
            lblNroVenta.TabIndex = 5;
            lblNroVenta.Text = "o N.º de venta:";
            lblNroVenta.AutoSize = true;
            // 
            // txtNroVenta
            // 
            txtNroVenta.Location = new System.Drawing.Point(470, 24);
            txtNroVenta.Name = "txtNroVenta";
            txtNroVenta.Size = new System.Drawing.Size(90, 23);
            txtNroVenta.TabIndex = 6;
            // 
            // btnBuscarVentas
            // 
            btnBuscarVentas.Location = new System.Drawing.Point(575, 22);
            btnBuscarVentas.Name = "btnBuscarVentas";
            btnBuscarVentas.Size = new System.Drawing.Size(100, 27);
            btnBuscarVentas.TabIndex = 7;
            btnBuscarVentas.Text = "Buscar";
            btnBuscarVentas.UseVisualStyleBackColor = true;
            btnBuscarVentas.Click += btnBuscarVentas_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvVentas.Location = new System.Drawing.Point(12, 58);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new System.Drawing.Size(772, 135);
            dgvVentas.TabIndex = 8;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
            dgvVentas.DataBindingComplete += dgvVentas_DataBindingComplete;
            // 
            // grpProducto
            // 
            grpProducto.Controls.Add(dgvDetalle);
            grpProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpProducto.Location = new System.Drawing.Point(12, 218);
            grpProducto.Name = "grpProducto";
            grpProducto.Size = new System.Drawing.Size(796, 155);
            grpProducto.TabIndex = 9;
            grpProducto.Text = "2. Producto a devolver";
            grpProducto.TabStop = false;
            // 
            // dgvDetalle
            // 
            dgvDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvDetalle.Location = new System.Drawing.Point(12, 22);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new System.Drawing.Size(772, 122);
            dgvDetalle.TabIndex = 10;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.SelectionChanged += dgvDetalle_SelectionChanged;
            dgvDetalle.DataBindingComplete += dgvDetalle_DataBindingComplete;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblCantidad);
            grpDatos.Controls.Add(nudCantidad);
            grpDatos.Controls.Add(lblPrecio);
            grpDatos.Controls.Add(lblPrecioValor);
            grpDatos.Controls.Add(lblImporte);
            grpDatos.Controls.Add(lblImporteValor);
            grpDatos.Controls.Add(lblMotivo);
            grpDatos.Controls.Add(cmbMotivo);
            grpDatos.Controls.Add(lblObservacion);
            grpDatos.Controls.Add(txtObservacion);
            grpDatos.Controls.Add(lblReintegro);
            grpDatos.Controls.Add(rbEfectivo);
            grpDatos.Controls.Add(rbCambio);
            grpDatos.Controls.Add(chkReingresaStock);
            grpDatos.Controls.Add(lblCaja);
            grpDatos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpDatos.Location = new System.Drawing.Point(12, 378);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new System.Drawing.Size(796, 195);
            grpDatos.TabIndex = 11;
            grpDatos.Text = "3. Datos de la devolución";
            grpDatos.TabStop = false;
            // 
            // lblCantidad
            // 
            lblCantidad.Location = new System.Drawing.Point(15, 30);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.TabIndex = 12;
            lblCantidad.Text = "Cantidad:";
            lblCantidad.AutoSize = true;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new System.Drawing.Point(105, 26);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new System.Drawing.Size(100, 23);
            nudCantidad.TabIndex = 13;
            nudCantidad.DecimalPlaces = 2;
            nudCantidad.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudCantidad.ThousandsSeparator = true;
            nudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudCantidad.DecimalPlaces = 0;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            // 
            // lblPrecio
            // 
            lblPrecio.Location = new System.Drawing.Point(225, 30);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.TabIndex = 14;
            lblPrecio.Text = "Precio por unidad:";
            lblPrecio.AutoSize = true;
            // 
            // lblPrecioValor
            // 
            lblPrecioValor.Location = new System.Drawing.Point(340, 30);
            lblPrecioValor.Name = "lblPrecioValor";
            lblPrecioValor.TabIndex = 15;
            lblPrecioValor.Text = "$ 0,00";
            lblPrecioValor.AutoSize = true;
            lblPrecioValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblImporte
            // 
            lblImporte.Location = new System.Drawing.Point(470, 30);
            lblImporte.Name = "lblImporte";
            lblImporte.TabIndex = 16;
            lblImporte.Text = "Importe:";
            lblImporte.AutoSize = true;
            // 
            // lblImporteValor
            // 
            lblImporteValor.Location = new System.Drawing.Point(535, 26);
            lblImporteValor.Name = "lblImporteValor";
            lblImporteValor.TabIndex = 17;
            lblImporteValor.Text = "$ 0,00";
            lblImporteValor.AutoSize = true;
            lblImporteValor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblMotivo
            // 
            lblMotivo.Location = new System.Drawing.Point(15, 66);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.TabIndex = 18;
            lblMotivo.Text = "Motivo:";
            lblMotivo.AutoSize = true;
            // 
            // cmbMotivo
            // 
            cmbMotivo.Location = new System.Drawing.Point(105, 62);
            cmbMotivo.Name = "cmbMotivo";
            cmbMotivo.Size = new System.Drawing.Size(245, 23);
            cmbMotivo.TabIndex = 19;
            cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMotivo.FormattingEnabled = true;
            cmbMotivo.SelectedIndexChanged += cmbMotivo_SelectedIndexChanged;
            // 
            // lblObservacion
            // 
            lblObservacion.Location = new System.Drawing.Point(375, 66);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.TabIndex = 20;
            lblObservacion.Text = "Observaciones (opcional):";
            lblObservacion.AutoSize = true;
            // 
            // txtObservacion
            // 
            txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtObservacion.Location = new System.Drawing.Point(375, 86);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new System.Drawing.Size(405, 55);
            txtObservacion.TabIndex = 21;
            txtObservacion.Multiline = true;
            txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtObservacion.MaxLength = 150;
            // 
            // lblReintegro
            // 
            lblReintegro.Location = new System.Drawing.Point(15, 100);
            lblReintegro.Name = "lblReintegro";
            lblReintegro.TabIndex = 22;
            lblReintegro.Text = "Reintegro:";
            lblReintegro.AutoSize = true;
            // 
            // rbEfectivo
            // 
            rbEfectivo.Location = new System.Drawing.Point(105, 98);
            rbEfectivo.Name = "rbEfectivo";
            rbEfectivo.TabIndex = 23;
            rbEfectivo.Text = "Devolver el dinero en efectivo";
            rbEfectivo.AutoSize = true;
            rbEfectivo.UseVisualStyleBackColor = true;
            rbEfectivo.Checked = true;
            rbEfectivo.CheckedChanged += rbReintegro_CheckedChanged;
            // 
            // rbCambio
            // 
            rbCambio.Location = new System.Drawing.Point(105, 121);
            rbCambio.Name = "rbCambio";
            rbCambio.TabIndex = 24;
            rbCambio.Text = "Entregar otra unidad del mismo producto";
            rbCambio.AutoSize = true;
            rbCambio.UseVisualStyleBackColor = true;
            rbCambio.CheckedChanged += rbReintegro_CheckedChanged;
            // 
            // chkReingresaStock
            // 
            chkReingresaStock.Location = new System.Drawing.Point(15, 155);
            chkReingresaStock.Name = "chkReingresaStock";
            chkReingresaStock.TabIndex = 25;
            chkReingresaStock.Text = "La unidad devuelta está en condiciones y vuelve al stock";
            chkReingresaStock.AutoSize = true;
            chkReingresaStock.UseVisualStyleBackColor = true;
            // 
            // lblCaja
            // 
            lblCaja.Location = new System.Drawing.Point(375, 155);
            lblCaja.Name = "lblCaja";
            lblCaja.TabIndex = 26;
            lblCaja.Text = "";
            lblCaja.AutoSize = true;
            lblCaja.ForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRegistrar.Location = new System.Drawing.Point(582, 582);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new System.Drawing.Size(110, 32);
            btnRegistrar.TabIndex = 27;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancelar.Location = new System.Drawing.Point(698, 582);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(110, 32);
            btnCancelar.TabIndex = 28;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmNuevaDevolucion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new System.Drawing.Size(820, 626);
            Controls.Add(grpVenta);
            Controls.Add(grpProducto);
            Controls.Add(grpDatos);
            Controls.Add(btnRegistrar);
            Controls.Add(btnCancelar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new System.Drawing.Size(836, 665);
            MinimizeBox = false;
            Name = "frmNuevaDevolucion";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Nueva devolución";
            Load += frmNuevaDevolucion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpProducto.ResumeLayout(false);
            grpProducto.PerformLayout();
            grpVenta.ResumeLayout(false);
            grpVenta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpVenta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblNroVenta;
        private System.Windows.Forms.TextBox txtNroVenta;
        private System.Windows.Forms.Button btnBuscarVentas;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.GroupBox grpProducto;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblPrecioValor;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblImporteValor;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.ComboBox cmbMotivo;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label lblReintegro;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.RadioButton rbCambio;
        private System.Windows.Forms.CheckBox chkReingresaStock;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
