namespace CapaVista
{
    partial class frmAlertas
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
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnTotal = new Button();
            btnUrgentes = new Button();
            btnAvisos = new Button();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblPrioridad = new Label();
            cmbPrioridad = new ComboBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnLimpiarFiltros = new Button();
            dtgAlertas = new DataGridView();
            clnPrioridad = new DataGridViewTextBoxColumn();
            clnTipo = new DataGridViewTextBoxColumn();
            clnDescripcion = new DataGridViewTextBoxColumn();
            btnIrResolver = new Button();
            btnActualizar = new Button();
            lblCantidad = new Label();
            lblPermiso = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgAlertas).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(84, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Alertas";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = SystemColors.GrayText;
            lblDescripcion.Location = new Point(13, 38);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(420, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Revisá lo pendiente. Doble clic en una alerta (o Enter) para ir a resolverla.";
            //
            // btnTotal
            //
            btnTotal.FlatStyle = FlatStyle.Flat;
            btnTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTotal.Location = new Point(12, 64);
            btnTotal.Name = "btnTotal";
            btnTotal.Size = new Size(150, 48);
            btnTotal.TabIndex = 2;
            btnTotal.Text = "0 en total";
            btnTotal.UseVisualStyleBackColor = true;
            btnTotal.Click += btnTotal_Click;
            //
            // btnUrgentes
            //
            btnUrgentes.FlatStyle = FlatStyle.Flat;
            btnUrgentes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUrgentes.ForeColor = Color.Firebrick;
            btnUrgentes.Location = new Point(170, 64);
            btnUrgentes.Name = "btnUrgentes";
            btnUrgentes.Size = new Size(150, 48);
            btnUrgentes.TabIndex = 3;
            btnUrgentes.Text = "0 urgentes";
            btnUrgentes.UseVisualStyleBackColor = true;
            btnUrgentes.Click += btnUrgentes_Click;
            //
            // btnAvisos
            //
            btnAvisos.FlatStyle = FlatStyle.Flat;
            btnAvisos.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAvisos.ForeColor = Color.DarkOrange;
            btnAvisos.Location = new Point(328, 64);
            btnAvisos.Name = "btnAvisos";
            btnAvisos.Size = new Size(150, 48);
            btnAvisos.TabIndex = 4;
            btnAvisos.Text = "0 avisos";
            btnAvisos.UseVisualStyleBackColor = true;
            btnAvisos.Click += btnAvisos_Click;
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(12, 131);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 15);
            lblTipo.TabIndex = 5;
            lblTipo.Text = "Tipo:";
            //
            // cmbTipo
            //
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(52, 127);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(210, 23);
            cmbTipo.TabIndex = 6;
            cmbTipo.SelectedIndexChanged += Filtros_Changed;
            //
            // lblPrioridad
            //
            lblPrioridad.AutoSize = true;
            lblPrioridad.Location = new Point(278, 131);
            lblPrioridad.Name = "lblPrioridad";
            lblPrioridad.Size = new Size(58, 15);
            lblPrioridad.TabIndex = 7;
            lblPrioridad.Text = "Prioridad:";
            //
            // cmbPrioridad
            //
            cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridad.FormattingEnabled = true;
            cmbPrioridad.Items.AddRange(new object[] { "Todas", "Solo urgentes", "Solo avisos" });
            cmbPrioridad.Location = new Point(342, 127);
            cmbPrioridad.Name = "cmbPrioridad";
            cmbPrioridad.Size = new Size(130, 23);
            cmbPrioridad.TabIndex = 8;
            cmbPrioridad.SelectedIndexChanged += Filtros_Changed;
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(488, 131);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 9;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(539, 127);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Producto, proveedor o N.º de compra";
            txtBuscar.Size = new Size(238, 23);
            txtBuscar.TabIndex = 10;
            txtBuscar.TextChanged += Filtros_Changed;
            //
            // btnLimpiarFiltros
            //
            btnLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiarFiltros.Location = new Point(783, 123);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(105, 32);
            btnLimpiarFiltros.TabIndex = 11;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            //
            // dtgAlertas
            //
            dtgAlertas.AllowUserToAddRows = false;
            dtgAlertas.AllowUserToDeleteRows = false;
            dtgAlertas.AllowUserToResizeRows = false;
            dtgAlertas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgAlertas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgAlertas.BackgroundColor = SystemColors.Window;
            dtgAlertas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgAlertas.Columns.AddRange(new DataGridViewColumn[] { clnPrioridad, clnTipo, clnDescripcion });
            dtgAlertas.Location = new Point(12, 163);
            dtgAlertas.MultiSelect = false;
            dtgAlertas.Name = "dtgAlertas";
            dtgAlertas.ReadOnly = true;
            dtgAlertas.RowHeadersVisible = false;
            dtgAlertas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAlertas.Size = new Size(876, 330);
            dtgAlertas.TabIndex = 12;
            dtgAlertas.CellDoubleClick += dtgAlertas_CellDoubleClick;
            dtgAlertas.SelectionChanged += dtgAlertas_SelectionChanged;
            dtgAlertas.KeyDown += dtgAlertas_KeyDown;
            //
            // clnPrioridad
            //
            clnPrioridad.FillWeight = 35F;
            clnPrioridad.HeaderText = "Prioridad";
            clnPrioridad.MinimumWidth = 90;
            clnPrioridad.Name = "clnPrioridad";
            clnPrioridad.ReadOnly = true;
            //
            // clnTipo
            //
            clnTipo.FillWeight = 55F;
            clnTipo.HeaderText = "Tipo";
            clnTipo.MinimumWidth = 140;
            clnTipo.Name = "clnTipo";
            clnTipo.ReadOnly = true;
            //
            // clnDescripcion
            //
            clnDescripcion.FillWeight = 200F;
            clnDescripcion.HeaderText = "Descripción";
            clnDescripcion.MinimumWidth = 200;
            clnDescripcion.Name = "clnDescripcion";
            clnDescripcion.ReadOnly = true;
            //
            // btnIrResolver
            //
            btnIrResolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnIrResolver.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnIrResolver.Location = new Point(12, 504);
            btnIrResolver.Name = "btnIrResolver";
            btnIrResolver.Size = new Size(130, 34);
            btnIrResolver.TabIndex = 13;
            btnIrResolver.Text = "Ir a resolver";
            btnIrResolver.UseVisualStyleBackColor = true;
            btnIrResolver.Click += btnIrResolver_Click;
            //
            // btnActualizar
            //
            btnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnActualizar.Location = new Point(150, 504);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(105, 34);
            btnActualizar.TabIndex = 14;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // lblCantidad
            //
            lblCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCantidad.AutoSize = true;
            lblCantidad.ForeColor = SystemColors.GrayText;
            lblCantidad.Location = new Point(268, 505);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(0, 15);
            lblCantidad.TabIndex = 15;
            //
            // lblPermiso
            //
            lblPermiso.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPermiso.AutoSize = true;
            lblPermiso.ForeColor = Color.Firebrick;
            lblPermiso.Location = new Point(268, 523);
            lblPermiso.Name = "lblPermiso";
            lblPermiso.Size = new Size(380, 15);
            lblPermiso.TabIndex = 17;
            lblPermiso.Text = "No tenés permiso para resolver esta alerta. Avisale al administrador.";
            lblPermiso.Visible = false;
            //
            // btnSalir
            //
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(793, 504);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(95, 34);
            btnSalir.TabIndex = 16;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // frmAlertas
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescripcion);
            Controls.Add(btnTotal);
            Controls.Add(btnUrgentes);
            Controls.Add(btnAvisos);
            Controls.Add(lblTipo);
            Controls.Add(cmbTipo);
            Controls.Add(lblPrioridad);
            Controls.Add(cmbPrioridad);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(dtgAlertas);
            Controls.Add(btnIrResolver);
            Controls.Add(btnActualizar);
            Controls.Add(lblCantidad);
            Controls.Add(lblPermiso);
            Controls.Add(btnSalir);
            MinimumSize = new Size(916, 420);
            Name = "frmAlertas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alertas";
            ((System.ComponentModel.ISupportInitialize)dtgAlertas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDescripcion;
        private Button btnTotal;
        private Button btnUrgentes;
        private Button btnAvisos;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblPrioridad;
        private ComboBox cmbPrioridad;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnLimpiarFiltros;
        private DataGridView dtgAlertas;
        private DataGridViewTextBoxColumn clnPrioridad;
        private DataGridViewTextBoxColumn clnTipo;
        private DataGridViewTextBoxColumn clnDescripcion;
        private Button btnIrResolver;
        private Button btnActualizar;
        private Label lblCantidad;
        private Label lblPermiso;
        private Button btnSalir;
    }
}
