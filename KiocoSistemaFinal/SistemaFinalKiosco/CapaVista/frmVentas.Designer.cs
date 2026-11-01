namespace CapaVista
{
    partial class frmVentas
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
            components = new System.ComponentModel.Container();
            ttAyuda = new ToolTip(components);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentas));
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnDetalle = new Button();
            btnAnular = new Button();
            btnActualizar = new Button();
            label1 = new Label();
            dtpDesde = new DateTimePicker();
            label2 = new Label();
            dtpHasta = new DateTimePicker();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnLimpiarFiltros = new Button();
            dtgVentas = new DataGridView();
            clnTransaccion = new DataGridViewTextBoxColumn();
            clnFecha = new DataGridViewTextBoxColumn();
            clnCajero = new DataGridViewTextBoxColumn();
            clnCaja = new DataGridViewTextBoxColumn();
            clnArticulos = new DataGridViewTextBoxColumn();
            clnMedios = new DataGridViewTextBoxColumn();
            clnTotal = new DataGridViewTextBoxColumn();
            clnEstado = new DataGridViewTextBoxColumn();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            lblResumen = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgVentas).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(170, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de ventas";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = SystemColors.GrayText;
            lblDescripcion.Location = new Point(13, 38);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(520, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Consultá las ventas, mirá su detalle y anulá las que correspondan. Doble clic en una venta para ver el detalle.";
            //
            // btnDetalle
            //
            btnDetalle.Location = new Point(12, 64);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(110, 34);
            btnDetalle.TabIndex = 2;
            btnDetalle.Text = "Ver detalle";
            btnDetalle.UseVisualStyleBackColor = true;
            btnDetalle.Click += btnDetalle_Click;
            //
            // btnAnular
            //
            btnAnular.Image = (Image)resources.GetObject("btnAnular.Image");
            btnAnular.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnular.Location = new Point(130, 64);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(110, 34);
            btnAnular.TabIndex = 3;
            btnAnular.Text = "Anular";
            btnAnular.TextAlign = ContentAlignment.MiddleRight;
            btnAnular.UseVisualStyleBackColor = true;
            btnAnular.Click += btnAnular_Click;
            //
            // btnActualizar
            //
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(248, 64);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 34);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextAlign = ContentAlignment.MiddleRight;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(12, 117);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 5;
            label1.Text = "Desde:";
            //
            // dtpDesde
            //
            dtpDesde.CustomFormat = "dd/MM/yyyy";
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.Location = new Point(60, 113);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(110, 23);
            dtpDesde.TabIndex = 6;
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(184, 117);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 7;
            label2.Text = "Hasta:";
            //
            // dtpHasta
            //
            dtpHasta.CustomFormat = "dd/MM/yyyy";
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.Location = new Point(230, 113);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(110, 23);
            dtpHasta.TabIndex = 8;
            dtpHasta.ValueChanged += dtpHasta_ValueChanged;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(356, 117);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 9;
            lblEstado.Text = "Estado:";
            //
            // cmbEstado
            //
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Activas", "Anuladas", "Todas" });
            cmbEstado.Location = new Point(407, 113);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(110, 23);
            cmbEstado.TabIndex = 10;
            cmbEstado.SelectedIndexChanged += Filtros_Changed;
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(533, 117);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 11;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(584, 113);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "N.º de venta, cajero o medio de pago";
            txtBuscar.Size = new Size(293, 23);
            txtBuscar.TabIndex = 12;
            txtBuscar.TextChanged += Filtros_Changed;
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
            // dtgVentas
            //
            dtgVentas.AllowUserToAddRows = false;
            dtgVentas.AllowUserToDeleteRows = false;
            dtgVentas.AllowUserToResizeRows = false;
            dtgVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgVentas.BackgroundColor = SystemColors.Window;
            dtgVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgVentas.Columns.AddRange(new DataGridViewColumn[] { clnTransaccion, clnFecha, clnCajero, clnCaja, clnArticulos, clnMedios, clnTotal, clnEstado });
            dtgVentas.Location = new Point(12, 149);
            dtgVentas.MultiSelect = false;
            dtgVentas.Name = "dtgVentas";
            dtgVentas.ReadOnly = true;
            dtgVentas.RowHeadersVisible = false;
            dtgVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgVentas.Size = new Size(976, 350);
            dtgVentas.TabIndex = 14;
            dtgVentas.CellDoubleClick += dtgVentas_CellDoubleClick;
            dtgVentas.SelectionChanged += dtgVentas_SelectionChanged;
            dtgVentas.KeyDown += dtgVentas_KeyDown;
            //
            // clnTransaccion
            //
            clnTransaccion.FillWeight = 45F;
            clnTransaccion.HeaderText = "N.º venta";
            clnTransaccion.MinimumWidth = 70;
            clnTransaccion.Name = "clnTransaccion";
            clnTransaccion.ReadOnly = true;
            //
            // clnFecha
            //
            clnFecha.FillWeight = 80F;
            clnFecha.HeaderText = "Fecha y hora";
            clnFecha.MinimumWidth = 120;
            clnFecha.Name = "clnFecha";
            clnFecha.ReadOnly = true;
            //
            // clnCajero
            //
            clnCajero.FillWeight = 70F;
            clnCajero.HeaderText = "Cajero";
            clnCajero.MinimumWidth = 90;
            clnCajero.Name = "clnCajero";
            clnCajero.ReadOnly = true;
            //
            // clnCaja
            //
            clnCaja.FillWeight = 40F;
            clnCaja.HeaderText = "Caja";
            clnCaja.MinimumWidth = 55;
            clnCaja.Name = "clnCaja";
            clnCaja.ReadOnly = true;
            //
            // clnArticulos
            //
            clnArticulos.FillWeight = 45F;
            clnArticulos.HeaderText = "Artículos";
            clnArticulos.MinimumWidth = 70;
            clnArticulos.Name = "clnArticulos";
            clnArticulos.ReadOnly = true;
            //
            // clnMedios
            //
            clnMedios.FillWeight = 100F;
            clnMedios.HeaderText = "Medio de pago";
            clnMedios.MinimumWidth = 120;
            clnMedios.Name = "clnMedios";
            clnMedios.ReadOnly = true;
            //
            // clnTotal
            //
            clnTotal.FillWeight = 60F;
            clnTotal.HeaderText = "Total";
            clnTotal.MinimumWidth = 95;
            clnTotal.Name = "clnTotal";
            clnTotal.ReadOnly = true;
            //
            // clnEstado
            //
            clnEstado.FillWeight = 50F;
            clnEstado.HeaderText = "Estado";
            clnEstado.MinimumWidth = 75;
            clnEstado.Name = "clnEstado";
            clnEstado.ReadOnly = true;
            //
            // lblObservaciones
            //
            lblObservaciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(12, 507);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(260, 15);
            lblObservaciones.TabIndex = 15;
            lblObservaciones.Text = "Observaciones y motivo de anulación de la venta elegida:";
            //
            // txtObservaciones
            //
            txtObservaciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtObservaciones.BackColor = SystemColors.Window;
            txtObservaciones.Location = new Point(12, 525);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ReadOnly = true;
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(860, 70);
            txtObservaciones.TabIndex = 16;
            //
            // lblResumen
            //
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResumen.Location = new Point(12, 612);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(0, 15);
            lblResumen.TabIndex = 17;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Location = new Point(893, 604);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 34);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "Salir";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // frmVentas
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescripcion);
            Controls.Add(btnDetalle);
            Controls.Add(btnAnular);
            Controls.Add(btnActualizar);
            Controls.Add(label1);
            Controls.Add(dtpDesde);
            Controls.Add(label2);
            Controls.Add(dtpHasta);
            Controls.Add(lblEstado);
            Controls.Add(cmbEstado);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(dtgVentas);
            Controls.Add(lblObservaciones);
            Controls.Add(txtObservaciones);
            Controls.Add(lblResumen);
            Controls.Add(btnVolver);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 500);
            Name = "frmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)dtgVentas).EndInit();
            // 
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbEstado, "Mostrá las ventas activas, las anuladas o todas.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

        private Label lblTitulo;
        private Label lblDescripcion;
        private Button btnDetalle;
        private Button btnAnular;
        private Button btnActualizar;
        private Label label1;
        private DateTimePicker dtpDesde;
        private Label label2;
        private DateTimePicker dtpHasta;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnLimpiarFiltros;
        private DataGridView dtgVentas;
        private DataGridViewTextBoxColumn clnTransaccion;
        private DataGridViewTextBoxColumn clnFecha;
        private DataGridViewTextBoxColumn clnCajero;
        private DataGridViewTextBoxColumn clnCaja;
        private DataGridViewTextBoxColumn clnArticulos;
        private DataGridViewTextBoxColumn clnMedios;
        private DataGridViewTextBoxColumn clnTotal;
        private DataGridViewTextBoxColumn clnEstado;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Label lblResumen;
        private Button btnVolver;
    }
}
