namespace CapaVista
{
    partial class frmDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevolucion));
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnNuevaDevolucion = new Button();
            btnActualizar = new Button();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnLimpiarFiltros = new Button();
            dataGridView1 = new DataGridView();
            clnId = new DataGridViewTextBoxColumn();
            clnFecha = new DataGridViewTextBoxColumn();
            clnVenta = new DataGridViewTextBoxColumn();
            clnProducto = new DataGridViewTextBoxColumn();
            clnCantidad = new DataGridViewTextBoxColumn();
            clnTipo = new DataGridViewTextBoxColumn();
            clnImporte = new DataGridViewTextBoxColumn();
            clnStock = new DataGridViewTextBoxColumn();
            clnCajero = new DataGridViewTextBoxColumn();
            clnCaja = new DataGridViewTextBoxColumn();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            lblResumen = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(140, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Devoluciones";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = SystemColors.GrayText;
            lblDescripcion.Location = new Point(13, 38);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(480, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Consultá las devoluciones registradas o cargá una nueva. El motivo de la elegida se ve abajo.";
            //
            // btnNuevaDevolucion
            //
            btnNuevaDevolucion.Image = (Image)resources.GetObject("btnNuevaDevolucion.Image");
            btnNuevaDevolucion.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevaDevolucion.Location = new Point(12, 64);
            btnNuevaDevolucion.Name = "btnNuevaDevolucion";
            btnNuevaDevolucion.Size = new Size(150, 34);
            btnNuevaDevolucion.TabIndex = 2;
            btnNuevaDevolucion.Text = "Nueva devolución";
            btnNuevaDevolucion.TextAlign = ContentAlignment.MiddleRight;
            btnNuevaDevolucion.UseVisualStyleBackColor = true;
            btnNuevaDevolucion.Click += btnNuevaDevolucion_Click;
            //
            // btnActualizar
            //
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(170, 64);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 34);
            btnActualizar.TabIndex = 3;
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
            label1.TabIndex = 4;
            label1.Text = "Desde:";
            //
            // dateTimePicker1
            //
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(60, 113);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(110, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(184, 117);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 6;
            label2.Text = "Hasta:";
            //
            // dateTimePicker2
            //
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(230, 113);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(110, 23);
            dateTimePicker2.TabIndex = 7;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(356, 117);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 15);
            lblTipo.TabIndex = 8;
            lblTipo.Text = "Tipo:";
            //
            // cmbTipo
            //
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Todas", "Reintegro en efectivo", "Cambio de unidad" });
            cmbTipo.Location = new Point(396, 113);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(160, 23);
            cmbTipo.TabIndex = 9;
            cmbTipo.SelectedIndexChanged += Filtros_Changed;
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(572, 117);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 10;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(623, 113);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "N.º de venta, producto o cajero";
            txtBuscar.Size = new Size(254, 23);
            txtBuscar.TabIndex = 11;
            txtBuscar.TextChanged += Filtros_Changed;
            //
            // btnLimpiarFiltros
            //
            btnLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiarFiltros.Location = new Point(883, 109);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(105, 32);
            btnLimpiarFiltros.TabIndex = 12;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            //
            // dataGridView1
            //
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clnId, clnFecha, clnVenta, clnProducto, clnCantidad, clnTipo, clnImporte, clnStock, clnCajero, clnCaja });
            dataGridView1.Location = new Point(12, 149);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(976, 350);
            dataGridView1.TabIndex = 13;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            //
            // clnId
            //
            clnId.FillWeight = 45F;
            clnId.HeaderText = "N.º devol.";
            clnId.MinimumWidth = 65;
            clnId.Name = "clnId";
            clnId.ReadOnly = true;
            //
            // clnFecha
            //
            clnFecha.FillWeight = 75F;
            clnFecha.HeaderText = "Fecha y hora";
            clnFecha.MinimumWidth = 115;
            clnFecha.Name = "clnFecha";
            clnFecha.ReadOnly = true;
            //
            // clnVenta
            //
            clnVenta.FillWeight = 45F;
            clnVenta.HeaderText = "N.º venta";
            clnVenta.MinimumWidth = 65;
            clnVenta.Name = "clnVenta";
            clnVenta.ReadOnly = true;
            //
            // clnProducto
            //
            clnProducto.FillWeight = 130F;
            clnProducto.HeaderText = "Producto";
            clnProducto.MinimumWidth = 140;
            clnProducto.Name = "clnProducto";
            clnProducto.ReadOnly = true;
            //
            // clnCantidad
            //
            clnCantidad.FillWeight = 45F;
            clnCantidad.HeaderText = "Cantidad";
            clnCantidad.MinimumWidth = 65;
            clnCantidad.Name = "clnCantidad";
            clnCantidad.ReadOnly = true;
            //
            // clnTipo
            //
            clnTipo.FillWeight = 85F;
            clnTipo.HeaderText = "Tipo";
            clnTipo.MinimumWidth = 120;
            clnTipo.Name = "clnTipo";
            clnTipo.ReadOnly = true;
            //
            // clnImporte
            //
            clnImporte.FillWeight = 55F;
            clnImporte.HeaderText = "Importe devuelto";
            clnImporte.MinimumWidth = 90;
            clnImporte.Name = "clnImporte";
            clnImporte.ReadOnly = true;
            //
            // clnStock
            //
            clnStock.FillWeight = 50F;
            clnStock.HeaderText = "Volvió al stock";
            clnStock.MinimumWidth = 80;
            clnStock.Name = "clnStock";
            clnStock.ReadOnly = true;
            //
            // clnCajero
            //
            clnCajero.FillWeight = 80F;
            clnCajero.HeaderText = "Cajero";
            clnCajero.MinimumWidth = 100;
            clnCajero.Name = "clnCajero";
            clnCajero.ReadOnly = true;
            //
            // clnCaja
            //
            clnCaja.FillWeight = 35F;
            clnCaja.HeaderText = "Caja";
            clnCaja.MinimumWidth = 50;
            clnCaja.Name = "clnCaja";
            clnCaja.ReadOnly = true;
            //
            // lblMotivo
            //
            lblMotivo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(12, 507);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(200, 15);
            lblMotivo.TabIndex = 14;
            lblMotivo.Text = "Motivo de la devolución elegida:";
            //
            // txtMotivo
            //
            txtMotivo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMotivo.BackColor = SystemColors.Window;
            txtMotivo.Location = new Point(12, 525);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.ReadOnly = true;
            txtMotivo.ScrollBars = ScrollBars.Vertical;
            txtMotivo.Size = new Size(860, 70);
            txtMotivo.TabIndex = 15;
            //
            // lblResumen
            //
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResumen.Location = new Point(12, 612);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(0, 15);
            lblResumen.TabIndex = 16;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Location = new Point(893, 604);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 34);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "Salir";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // frmDevolucion
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescripcion);
            Controls.Add(btnNuevaDevolucion);
            Controls.Add(btnActualizar);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(dateTimePicker2);
            Controls.Add(lblTipo);
            Controls.Add(cmbTipo);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(dataGridView1);
            Controls.Add(lblMotivo);
            Controls.Add(txtMotivo);
            Controls.Add(lblResumen);
            Controls.Add(btnVolver);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 500);
            Name = "frmDevolucion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Devoluciones";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            // 
            // ttAyuda: explicación de cada combo al pasar el mouse
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbTipo, "Filtrá por reintegro en efectivo o cambio de unidad.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

        private Label lblTitulo;
        private Label lblDescripcion;
        private Button btnNuevaDevolucion;
        private Button btnActualizar;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnLimpiarFiltros;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnFecha;
        private DataGridViewTextBoxColumn clnVenta;
        private DataGridViewTextBoxColumn clnProducto;
        private DataGridViewTextBoxColumn clnCantidad;
        private DataGridViewTextBoxColumn clnTipo;
        private DataGridViewTextBoxColumn clnImporte;
        private DataGridViewTextBoxColumn clnStock;
        private DataGridViewTextBoxColumn clnCajero;
        private DataGridViewTextBoxColumn clnCaja;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Label lblResumen;
        private Button btnVolver;
    }
}
