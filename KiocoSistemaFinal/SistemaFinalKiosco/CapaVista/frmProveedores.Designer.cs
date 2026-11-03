namespace CapaVista
{
    partial class frmProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedores));
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnNuevoProveedor = new Button();
            btnModificar = new Button();
            btnDescontinuar = new Button();
            btnActualizar = new Button();
            btnNuevaSucursal = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lstProveedores = new ListBox();
            chkOcultarProveedores = new CheckBox();
            btnLimpiarFiltros = new Button();
            dtgProveedores = new DataGridView();
            clnId = new DataGridViewTextBoxColumn();
            clnIdSucursal = new DataGridViewTextBoxColumn();
            clnSucursal = new DataGridViewTextBoxColumn();
            clnRazonSocial = new DataGridViewTextBoxColumn();
            clnCuit = new DataGridViewTextBoxColumn();
            clnIva = new DataGridViewTextBoxColumn();
            clnTelefono = new DataGridViewTextBoxColumn();
            clnCorreo = new DataGridViewTextBoxColumn();
            clnDireccion = new DataGridViewTextBoxColumn();
            clnEstado = new DataGridViewTextBoxColumn();
            lblObservaciones = new Label();
            txtObsevaciones = new TextBox();
            lblCantidad = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgProveedores).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de proveedores";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = SystemColors.GrayText;
            lblDescripcion.Location = new Point(13, 38);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(600, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Se ven todos los proveedores. Buscá uno por nombre o CUIT para ver solo ese. Doble clic en la fila para modificar esa sucursal.";
            //
            // btnNuevoProveedor
            //
            btnNuevoProveedor.Image = (Image)resources.GetObject("btnNuevoProveedor.Image");
            btnNuevoProveedor.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevoProveedor.Location = new Point(12, 64);
            btnNuevoProveedor.Name = "btnNuevoProveedor";
            btnNuevoProveedor.Size = new Size(145, 34);
            btnNuevoProveedor.TabIndex = 2;
            btnNuevoProveedor.Text = "Nuevo proveedor";
            btnNuevoProveedor.TextAlign = ContentAlignment.MiddleRight;
            btnNuevoProveedor.UseVisualStyleBackColor = true;
            btnNuevoProveedor.Click += btnNuevoProveedor_Click;
            //
            // btnModificar
            //
            btnModificar.Image = (Image)resources.GetObject("btnModificar.Image");
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(165, 64);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(110, 34);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += BtnModificar_Click;
            //
            // btnDescontinuar
            //
            btnDescontinuar.Location = new Point(283, 64);
            btnDescontinuar.Name = "btnDescontinuar";
            btnDescontinuar.Size = new Size(110, 34);
            btnDescontinuar.TabIndex = 4;
            btnDescontinuar.Text = "Descontinuar";
            btnDescontinuar.UseVisualStyleBackColor = true;
            btnDescontinuar.Click += btnDescontinuar_Click;
            //
            // btnActualizar
            //
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(401, 64);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 34);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextAlign = ContentAlignment.MiddleRight;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // btnNuevaSucursal
            //
            btnNuevaSucursal.Location = new Point(519, 64);
            btnNuevaSucursal.Name = "btnNuevaSucursal";
            btnNuevaSucursal.Size = new Size(130, 34);
            btnNuevaSucursal.TabIndex = 6;
            btnNuevaSucursal.Text = "Nueva sucursal";
            btnNuevaSucursal.UseVisualStyleBackColor = true;
            btnNuevaSucursal.Click += btnNuevaSucursal_Click;
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 117);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(64, 15);
            lblBuscar.TabIndex = 6;
            lblBuscar.Text = "Proveedor:";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(82, 113);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Escriba el nombre o CUIT del proveedor";
            txtBuscar.Size = new Size(590, 23);
            txtBuscar.TabIndex = 7;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            //
            // lstProveedores
            //
            lstProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstProveedores.FormattingEnabled = true;
            lstProveedores.IntegralHeight = false;
            lstProveedores.Location = new Point(82, 137);
            lstProveedores.Name = "lstProveedores";
            lstProveedores.Size = new Size(590, 140);
            lstProveedores.TabIndex = 8;
            lstProveedores.Visible = false;
            lstProveedores.DoubleClick += lstProveedores_DoubleClick;
            lstProveedores.KeyDown += lstProveedores_KeyDown;
            //
            // chkOcultarProveedores
            //
            chkOcultarProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkOcultarProveedores.AutoSize = true;
            chkOcultarProveedores.Location = new Point(688, 116);
            chkOcultarProveedores.Name = "chkOcultarProveedores";
            chkOcultarProveedores.Size = new Size(183, 19);
            chkOcultarProveedores.TabIndex = 9;
            chkOcultarProveedores.Text = "Ocultar proveedores inactivos";
            chkOcultarProveedores.UseVisualStyleBackColor = true;
            chkOcultarProveedores.CheckedChanged += chkOcultarProveedores_CheckedChanged;
            //
            // btnLimpiarFiltros
            //
            btnLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiarFiltros.Location = new Point(883, 109);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(105, 32);
            btnLimpiarFiltros.TabIndex = 10;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            //
            // dtgProveedores
            //
            dtgProveedores.AllowUserToAddRows = false;
            dtgProveedores.AllowUserToDeleteRows = false;
            dtgProveedores.AllowUserToOrderColumns = false;
            dtgProveedores.AllowUserToResizeRows = false;
            dtgProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgProveedores.BackgroundColor = SystemColors.Window;
            dtgProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProveedores.Columns.AddRange(new DataGridViewColumn[] { clnId, clnIdSucursal, clnSucursal, clnRazonSocial, clnCuit, clnIva, clnTelefono, clnCorreo, clnDireccion, clnEstado });
            dtgProveedores.Location = new Point(12, 149);
            dtgProveedores.MultiSelect = false;
            dtgProveedores.Name = "dtgProveedores";
            dtgProveedores.ReadOnly = true;
            dtgProveedores.RowHeadersVisible = false;
            dtgProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgProveedores.Size = new Size(976, 340);
            dtgProveedores.TabIndex = 11;
            dtgProveedores.CellDoubleClick += dtgProveedores_CellDoubleClick;
            dtgProveedores.SelectionChanged += dtgProveedores_SelectionChanged;
            //
            // clnId
            //
            clnId.FillWeight = 45F;
            clnId.HeaderText = "N.º";
            clnId.MinimumWidth = 45;
            clnId.Name = "clnId";
            clnId.ReadOnly = true;
            //
            // clnIdSucursal
            //
            clnIdSucursal.HeaderText = "IdSucursal";
            clnIdSucursal.Name = "clnIdSucursal";
            clnIdSucursal.ReadOnly = true;
            clnIdSucursal.Visible = false;
            //
            // clnSucursal
            //
            clnSucursal.FillWeight = 90F;
            clnSucursal.HeaderText = "Sucursal";
            clnSucursal.MinimumWidth = 80;
            clnSucursal.Name = "clnSucursal";
            clnSucursal.ReadOnly = true;
            //
            // clnRazonSocial
            //
            clnRazonSocial.FillWeight = 140F;
            clnRazonSocial.HeaderText = "Razón social";
            clnRazonSocial.MinimumWidth = 120;
            clnRazonSocial.Name = "clnRazonSocial";
            clnRazonSocial.ReadOnly = true;
            //
            // clnCuit
            //
            clnCuit.FillWeight = 90F;
            clnCuit.HeaderText = "CUIT";
            clnCuit.MinimumWidth = 95;
            clnCuit.Name = "clnCuit";
            clnCuit.ReadOnly = true;
            //
            // clnIva
            //
            clnIva.FillWeight = 110F;
            clnIva.HeaderText = "Condición IVA";
            clnIva.MinimumWidth = 100;
            clnIva.Name = "clnIva";
            clnIva.ReadOnly = true;
            //
            // clnTelefono
            //
            clnTelefono.FillWeight = 85F;
            clnTelefono.HeaderText = "Teléfono";
            clnTelefono.MinimumWidth = 85;
            clnTelefono.Name = "clnTelefono";
            clnTelefono.ReadOnly = true;
            //
            // clnCorreo
            //
            clnCorreo.FillWeight = 140F;
            clnCorreo.HeaderText = "E-mail";
            clnCorreo.MinimumWidth = 120;
            clnCorreo.Name = "clnCorreo";
            clnCorreo.ReadOnly = true;
            //
            // clnDireccion
            //
            clnDireccion.FillWeight = 130F;
            clnDireccion.HeaderText = "Dirección";
            clnDireccion.MinimumWidth = 110;
            clnDireccion.Name = "clnDireccion";
            clnDireccion.ReadOnly = true;
            //
            // clnEstado
            //
            clnEstado.FillWeight = 65F;
            clnEstado.HeaderText = "Estado";
            clnEstado.MinimumWidth = 65;
            clnEstado.Name = "clnEstado";
            clnEstado.ReadOnly = true;
            //
            // lblObservaciones
            //
            lblObservaciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(12, 497);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(213, 15);
            lblObservaciones.TabIndex = 12;
            lblObservaciones.Text = "Observaciones del proveedor elegido:";
            //
            // txtObsevaciones
            //
            txtObsevaciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtObsevaciones.BackColor = SystemColors.Window;
            txtObsevaciones.Location = new Point(12, 515);
            txtObsevaciones.Multiline = true;
            txtObsevaciones.Name = "txtObsevaciones";
            txtObsevaciones.ReadOnly = true;
            txtObsevaciones.ScrollBars = ScrollBars.Vertical;
            txtObsevaciones.Size = new Size(860, 80);
            txtObsevaciones.TabIndex = 13;
            //
            // lblCantidad
            //
            lblCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCantidad.AutoSize = true;
            lblCantidad.ForeColor = SystemColors.GrayText;
            lblCantidad.Location = new Point(12, 612);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(0, 15);
            lblCantidad.TabIndex = 14;
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
            // frmProveedores
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(lstProveedores);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescripcion);
            Controls.Add(btnNuevoProveedor);
            Controls.Add(btnModificar);
            Controls.Add(btnDescontinuar);
            Controls.Add(btnActualizar);
            Controls.Add(btnNuevaSucursal);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(chkOcultarProveedores);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(dtgProveedores);
            Controls.Add(lblObservaciones);
            Controls.Add(txtObsevaciones);
            Controls.Add(lblCantidad);
            Controls.Add(btnSalir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 500);
            Name = "frmProveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)dtgProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDescripcion;
        private Button btnNuevoProveedor;
        private Button btnModificar;
        private Button btnDescontinuar;
        private Button btnActualizar;
        private Button btnNuevaSucursal;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private ListBox lstProveedores;
        private CheckBox chkOcultarProveedores;
        private Button btnLimpiarFiltros;
        private DataGridView dtgProveedores;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnIdSucursal;
        private DataGridViewTextBoxColumn clnSucursal;
        private DataGridViewTextBoxColumn clnRazonSocial;
        private DataGridViewTextBoxColumn clnCuit;
        private DataGridViewTextBoxColumn clnIva;
        private DataGridViewTextBoxColumn clnTelefono;
        private DataGridViewTextBoxColumn clnCorreo;
        private DataGridViewTextBoxColumn clnDireccion;
        private DataGridViewTextBoxColumn clnEstado;
        private Label lblObservaciones;
        private TextBox txtObsevaciones;
        private Label lblCantidad;
        private Button btnSalir;
    }
}
