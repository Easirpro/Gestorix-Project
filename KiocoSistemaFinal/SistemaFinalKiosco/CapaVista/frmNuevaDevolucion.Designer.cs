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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaDevolucion));
            grpVenta = new GroupBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            lblNroVenta = new Label();
            txtNroVenta = new TextBox();
            btnBuscarVentas = new Button();
            dgvVentas = new DataGridView();
            grpProducto = new GroupBox();
            dgvDetalle = new DataGridView();
            grpDatos = new GroupBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            lblPrecio = new Label();
            lblPrecioValor = new Label();
            lblImporte = new Label();
            lblImporteValor = new Label();
            lblMotivo = new Label();
            cmbMotivo = new ComboBox();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            lblReintegro = new Label();
            rbEfectivo = new RadioButton();
            rbCambio = new RadioButton();
            chkReingresaStock = new CheckBox();
            lblCaja = new Label();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            grpVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            grpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // grpVenta
            // 
            grpVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpVenta.Controls.Add(lblDesde);
            grpVenta.Controls.Add(dtpDesde);
            grpVenta.Controls.Add(lblHasta);
            grpVenta.Controls.Add(dtpHasta);
            grpVenta.Controls.Add(lblNroVenta);
            grpVenta.Controls.Add(txtNroVenta);
            grpVenta.Controls.Add(btnBuscarVentas);
            grpVenta.Controls.Add(dgvVentas);
            grpVenta.Location = new Point(12, 8);
            grpVenta.Name = "grpVenta";
            grpVenta.Size = new Size(796, 205);
            grpVenta.TabIndex = 0;
            grpVenta.TabStop = false;
            grpVenta.Text = "1. Venta de la que se devuelve";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(12, 28);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 1;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(60, 24);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(115, 23);
            dtpDesde.TabIndex = 2;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(185, 28);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 3;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(230, 24);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(115, 23);
            dtpHasta.TabIndex = 4;
            // 
            // lblNroVenta
            // 
            lblNroVenta.AutoSize = true;
            lblNroVenta.Location = new Point(370, 28);
            lblNroVenta.Name = "lblNroVenta";
            lblNroVenta.Size = new Size(85, 15);
            lblNroVenta.TabIndex = 5;
            lblNroVenta.Text = "o N.º de venta:";
            // 
            // txtNroVenta
            // 
            txtNroVenta.Location = new Point(470, 24);
            txtNroVenta.Name = "txtNroVenta";
            txtNroVenta.Size = new Size(90, 23);
            txtNroVenta.TabIndex = 6;
            // 
            // btnBuscarVentas
            // 
            btnBuscarVentas.Location = new Point(575, 22);
            btnBuscarVentas.Name = "btnBuscarVentas";
            btnBuscarVentas.Size = new Size(100, 27);
            btnBuscarVentas.TabIndex = 7;
            btnBuscarVentas.Text = "Buscar";
            btnBuscarVentas.UseVisualStyleBackColor = true;
            btnBuscarVentas.Click += btnBuscarVentas_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentas.BackgroundColor = SystemColors.Window;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(12, 58);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.Size = new Size(772, 135);
            dgvVentas.TabIndex = 8;
            dgvVentas.DataBindingComplete += dgvVentas_DataBindingComplete;
            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
            // 
            // grpProducto
            // 
            grpProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpProducto.Controls.Add(dgvDetalle);
            grpProducto.Location = new Point(12, 218);
            grpProducto.Name = "grpProducto";
            grpProducto.Size = new Size(796, 155);
            grpProducto.TabIndex = 9;
            grpProducto.TabStop = false;
            grpProducto.Text = "2. Producto a devolver";
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalle.BackgroundColor = SystemColors.Window;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(12, 22);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.Size = new Size(772, 122);
            dgvDetalle.TabIndex = 10;
            dgvDetalle.DataBindingComplete += dgvDetalle_DataBindingComplete;
            dgvDetalle.SelectionChanged += dgvDetalle_SelectionChanged;
            // 
            // grpDatos
            // 
            grpDatos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            grpDatos.Location = new Point(12, 378);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(796, 195);
            grpDatos.TabIndex = 11;
            grpDatos.TabStop = false;
            grpDatos.Text = "3. Datos de la devolución";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(15, 30);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 12;
            lblCantidad.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(105, 26);
            nudCantidad.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(100, 23);
            nudCantidad.TabIndex = 13;
            nudCantidad.TextAlign = HorizontalAlignment.Right;
            nudCantidad.ThousandsSeparator = true;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(225, 30);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(104, 15);
            lblPrecio.TabIndex = 14;
            lblPrecio.Text = "Precio por unidad:";
            // 
            // lblPrecioValor
            // 
            lblPrecioValor.AutoSize = true;
            lblPrecioValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecioValor.Location = new Point(340, 30);
            lblPrecioValor.Name = "lblPrecioValor";
            lblPrecioValor.Size = new Size(41, 15);
            lblPrecioValor.TabIndex = 15;
            lblPrecioValor.Text = "$ 0,00";
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Location = new Point(470, 30);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(52, 15);
            lblImporte.TabIndex = 16;
            lblImporte.Text = "Importe:";
            // 
            // lblImporteValor
            // 
            lblImporteValor.AutoSize = true;
            lblImporteValor.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblImporteValor.Location = new Point(535, 26);
            lblImporteValor.Name = "lblImporteValor";
            lblImporteValor.Size = new Size(53, 20);
            lblImporteValor.TabIndex = 17;
            lblImporteValor.Text = "$ 0,00";
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(15, 66);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(48, 15);
            lblMotivo.TabIndex = 18;
            lblMotivo.Text = "Motivo:";
            // 
            // cmbMotivo
            // 
            cmbMotivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMotivo.FormattingEnabled = true;
            cmbMotivo.Location = new Point(105, 62);
            cmbMotivo.Name = "cmbMotivo";
            cmbMotivo.Size = new Size(245, 23);
            cmbMotivo.TabIndex = 19;
            cmbMotivo.SelectedIndexChanged += cmbMotivo_SelectedIndexChanged;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(375, 66);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(144, 15);
            lblObservacion.TabIndex = 20;
            lblObservacion.Text = "Observaciones (opcional):";
            // 
            // txtObservacion
            // 
            txtObservacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObservacion.Location = new Point(375, 86);
            txtObservacion.MaxLength = 150;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.ScrollBars = ScrollBars.Vertical;
            txtObservacion.Size = new Size(405, 55);
            txtObservacion.TabIndex = 21;
            // 
            // lblReintegro
            // 
            lblReintegro.AutoSize = true;
            lblReintegro.Location = new Point(15, 100);
            lblReintegro.Name = "lblReintegro";
            lblReintegro.Size = new Size(61, 15);
            lblReintegro.TabIndex = 22;
            lblReintegro.Text = "Reintegro:";
            // 
            // rbEfectivo
            // 
            rbEfectivo.AutoSize = true;
            rbEfectivo.Checked = true;
            rbEfectivo.Location = new Point(105, 98);
            rbEfectivo.Name = "rbEfectivo";
            rbEfectivo.Size = new Size(181, 19);
            rbEfectivo.TabIndex = 23;
            rbEfectivo.TabStop = true;
            rbEfectivo.Text = "Devolver el dinero en efectivo";
            rbEfectivo.UseVisualStyleBackColor = true;
            rbEfectivo.CheckedChanged += rbReintegro_CheckedChanged;
            // 
            // rbCambio
            // 
            rbCambio.AutoSize = true;
            rbCambio.Location = new Point(105, 121);
            rbCambio.Name = "rbCambio";
            rbCambio.Size = new Size(244, 19);
            rbCambio.TabIndex = 24;
            rbCambio.Text = "Entregar otra unidad del mismo producto";
            rbCambio.UseVisualStyleBackColor = true;
            rbCambio.CheckedChanged += rbReintegro_CheckedChanged;
            // 
            // chkReingresaStock
            // 
            chkReingresaStock.AutoSize = true;
            chkReingresaStock.Location = new Point(15, 155);
            chkReingresaStock.Name = "chkReingresaStock";
            chkReingresaStock.Size = new Size(322, 19);
            chkReingresaStock.TabIndex = 25;
            chkReingresaStock.Text = "La unidad devuelta está en condiciones y vuelve al stock";
            chkReingresaStock.UseVisualStyleBackColor = true;
            // 
            // lblCaja
            // 
            lblCaja.AutoSize = true;
            lblCaja.ForeColor = SystemColors.GrayText;
            lblCaja.Location = new Point(375, 155);
            lblCaja.Name = "lblCaja";
            lblCaja.Size = new Size(0, 15);
            lblCaja.TabIndex = 26;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegistrar.Location = new Point(582, 582);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(110, 32);
            btnRegistrar.TabIndex = 27;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(698, 582);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 32);
            btnCancelar.TabIndex = 28;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmNuevaDevolucion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(820, 626);
            Controls.Add(grpVenta);
            Controls.Add(grpProducto);
            Controls.Add(grpDatos);
            Controls.Add(btnRegistrar);
            Controls.Add(btnCancelar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            MinimumSize = new Size(836, 665);
            Name = "frmNuevaDevolucion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva devolución";
            Load += frmNuevaDevolucion_Load;
            grpVenta.ResumeLayout(false);
            grpVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            grpProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
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
