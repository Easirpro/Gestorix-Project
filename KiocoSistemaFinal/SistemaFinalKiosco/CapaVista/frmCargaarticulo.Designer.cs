namespace CapaVista
{
    partial class frmCargaarticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaarticulo));
            btnModificar = new Button();
            btnDiscontinuar = new Button();
            txtBuscarCodigoNombre = new TextBox();
            btnBuscar = new Button();
            chkArticulodiscontinaudo = new CheckBox();
            dtgCargaarticulo = new DataGridView();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnDescripcion = new DataGridViewTextBoxColumn();
            clnRubro = new DataGridViewTextBoxColumn();
            clnMarca = new DataGridViewTextBoxColumn();
            clnPrecioVenta = new DataGridViewTextBoxColumn();
            clnStockActual = new DataGridViewTextBoxColumn();
            clnDetalle = new DataGridViewButtonColumn();
            btnSalir = new Button();
            btnEliminar = new Button();
            lblCodigoNombre = new Label();
            cmbMarca = new ComboBox();
            cmbRubro = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgCargaarticulo).BeginInit();
            SuspendLayout();
            // 
            // btnModificar
            // 
            btnModificar.Image = (Image)resources.GetObject("btnModificar.Image");
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(415, 25);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(124, 42);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar articulo";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnDiscontinuar
            // 
            btnDiscontinuar.Location = new Point(545, 25);
            btnDiscontinuar.Name = "btnDiscontinuar";
            btnDiscontinuar.Size = new Size(115, 42);
            btnDiscontinuar.TabIndex = 2;
            btnDiscontinuar.Text = "Discontinuar";
            btnDiscontinuar.UseVisualStyleBackColor = true;
            btnDiscontinuar.Click += btnDiscontinuar_Click;
            // 
            // txtBuscarCodigoNombre
            // 
            txtBuscarCodigoNombre.Location = new Point(11, 36);
            txtBuscarCodigoNombre.Name = "txtBuscarCodigoNombre";
            txtBuscarCodigoNombre.Size = new Size(270, 23);
            txtBuscarCodigoNombre.TabIndex = 5;
            txtBuscarCodigoNombre.TextChanged += txtBuscarCodigoNombre_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(296, 20);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(95, 52);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // chkArticulodiscontinaudo
            // 
            chkArticulodiscontinaudo.AutoSize = true;
            chkArticulodiscontinaudo.Location = new Point(405, 123);
            chkArticulodiscontinaudo.Name = "chkArticulodiscontinaudo";
            chkArticulodiscontinaudo.Size = new Size(199, 19);
            chkArticulodiscontinaudo.TabIndex = 11;
            chkArticulodiscontinaudo.Text = "Mostrar artículos discontinuados";
            chkArticulodiscontinaudo.UseVisualStyleBackColor = true;
            chkArticulodiscontinaudo.CheckedChanged += chkArticulodiscontinaudo_CheckedChanged;
            // 
            // dtgCargaarticulo
            // 
            dtgCargaarticulo.AllowUserToAddRows = false;
            dtgCargaarticulo.AllowUserToDeleteRows = false;
            dtgCargaarticulo.AllowUserToResizeRows = false;
            dtgCargaarticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCargaarticulo.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnDescripcion, clnRubro, clnMarca, clnPrecioVenta, clnStockActual, clnDetalle });
            dtgCargaarticulo.Location = new Point(8, 164);
            dtgCargaarticulo.Name = "dtgCargaarticulo";
            dtgCargaarticulo.Size = new Size(827, 303);
            dtgCargaarticulo.TabIndex = 12;
            dtgCargaarticulo.CellContentClick += dtgCargaarticulo_CellContentClick;
            // 
            // clnCodigo
            // 
            clnCodigo.HeaderText = "Código";
            clnCodigo.Name = "clnCodigo";
            // 
            // clnDescripcion
            // 
            clnDescripcion.HeaderText = "Descripción";
            clnDescripcion.Name = "clnDescripcion";
            // 
            // clnRubro
            // 
            clnRubro.HeaderText = "Rubro";
            clnRubro.Name = "clnRubro";
            // 
            // clnMarca
            // 
            clnMarca.HeaderText = "Marca";
            clnMarca.Name = "clnMarca";
            // 
            // clnPrecioVenta
            // 
            clnPrecioVenta.HeaderText = "Precio venta";
            clnPrecioVenta.Name = "clnPrecioVenta";
            // 
            // clnStockActual
            // 
            clnStockActual.HeaderText = "Stock actual";
            clnStockActual.Name = "clnStockActual";
            // 
            // clnDetalle
            // 
            clnDetalle.HeaderText = "Detalle";
            clnDetalle.Name = "clnDetalle";
            clnDetalle.Text = "Ver detalle";
            clnDetalle.UseColumnTextForButtonValue = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(727, 490);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(108, 35);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 9F);
            btnEliminar.Location = new Point(666, 25);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 42);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblCodigoNombre
            // 
            lblCodigoNombre.AutoSize = true;
            lblCodigoNombre.Location = new Point(11, 15);
            lblCodigoNombre.Name = "lblCodigoNombre";
            lblCodigoNombre.Size = new Size(161, 15);
            lblCodigoNombre.TabIndex = 4;
            lblCodigoNombre.Text = "Buscar por código o nombre.";
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(211, 119);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(175, 23);
            cmbMarca.TabIndex = 10;
            cmbMarca.SelectedIndexChanged += cmbMarca_SelectedIndexChanged;
            // 
            // cmbRubro
            // 
            cmbRubro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRubro.FormattingEnabled = true;
            cmbRubro.Location = new Point(11, 119);
            cmbRubro.Name = "cmbRubro";
            cmbRubro.Size = new Size(175, 23);
            cmbRubro.TabIndex = 8;
            cmbRubro.SelectedIndexChanged += cmbRubro_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 98);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 7;
            label1.Text = "Rubro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 98);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 9;
            label2.Text = "Marca";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(8, 75);
            label3.Name = "label3";
            label3.Size = new Size(266, 15);
            label3.TabIndex = 14;
            label3.Text = "Seleccione Rubro o Marca para buscar el articulo.";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(602, 490);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(108, 35);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // frmCargaarticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 547);
            Controls.Add(btnGuardar);
            Controls.Add(label3);
            Controls.Add(btnSalir);
            Controls.Add(dtgCargaarticulo);
            Controls.Add(chkArticulodiscontinaudo);
            Controls.Add(cmbMarca);
            Controls.Add(cmbRubro);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarCodigoNombre);
            Controls.Add(lblCodigoNombre);
            Controls.Add(btnEliminar);
            Controls.Add(btnDiscontinuar);
            Controls.Add(btnModificar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 500);
            Name = "frmCargaarticulo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar articulo";
            ((System.ComponentModel.ISupportInitialize)dtgCargaarticulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnModificar;
        private Button btnDiscontinuar;
        private TextBox txtBuscarCodigoNombre;
        private Button btnBuscar;
        private CheckBox chkArticulodiscontinaudo;
        private DataGridView dtgCargaarticulo;
        private Button btnSalir;
        private Button btnEliminar;
        private Label lblCodigoNombre;
        private ComboBox cmbMarca;
        private ComboBox cmbRubro;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn clnCodigo;
        private DataGridViewTextBoxColumn clnDescripcion;
        private DataGridViewTextBoxColumn clnRubro;
        private DataGridViewTextBoxColumn clnMarca;
        private DataGridViewTextBoxColumn clnPrecioVenta;
        private DataGridViewTextBoxColumn clnStockActual;
        private DataGridViewButtonColumn clnDetalle;
        private Label label3;
        private Button btnGuardar;
    }
}
