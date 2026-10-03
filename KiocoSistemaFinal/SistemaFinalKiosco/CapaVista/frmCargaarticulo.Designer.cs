namespace CapaVista
{
    partial class frmCargaarticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaarticulo));
            btnNuevoArticulo = new Button();
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
            clnProveedor = new DataGridViewTextBoxColumn();
            clmSucursal = new DataGridViewTextBoxColumn();
            clnVencimiento = new DataGridViewTextBoxColumn();
            clnUltActualizacion = new DataGridViewTextBoxColumn();
            clnUltVenta = new DataGridViewTextBoxColumn();
            clnPrecioCosto = new DataGridViewTextBoxColumn();
            clnPrecioVenta = new DataGridViewTextBoxColumn();
            clnIva = new DataGridViewTextBoxColumn();
            clnStockActual = new DataGridViewTextBoxColumn();
            clnStockMinimo = new DataGridViewTextBoxColumn();
            clnStockMaximo = new DataGridViewTextBoxColumn();
            clnActivo = new DataGridViewTextBoxColumn();
            btnSalir = new Button();
            btnEliminar = new Button();
            lblCodigoNombre = new Label();
            cmbMarca = new ComboBox();
            cmbRubro = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgCargaarticulo).BeginInit();
            SuspendLayout();
            // 
            // btnNuevoArticulo
            // 
            btnNuevoArticulo.Image = (Image)resources.GetObject("btnNuevoArticulo.Image");
            btnNuevoArticulo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevoArticulo.Location = new Point(12, 9);
            btnNuevoArticulo.Name = "btnNuevoArticulo";
            btnNuevoArticulo.Size = new Size(116, 42);
            btnNuevoArticulo.TabIndex = 0;
            btnNuevoArticulo.Text = "Nuevo articulo";
            btnNuevoArticulo.TextAlign = ContentAlignment.MiddleRight;
            btnNuevoArticulo.UseVisualStyleBackColor = true;
            btnNuevoArticulo.Click += btnNuevoArticulo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Image = (Image)resources.GetObject("btnModificar.Image");
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(134, 9);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(83, 42);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnDiscontinuar
            // 
            btnDiscontinuar.Location = new Point(223, 9);
            btnDiscontinuar.Name = "btnDiscontinuar";
            btnDiscontinuar.Size = new Size(91, 43);
            btnDiscontinuar.TabIndex = 2;
            btnDiscontinuar.Text = "Discontinuar";
            btnDiscontinuar.UseVisualStyleBackColor = true;
            btnDiscontinuar.Click += btnDiscontinuar_Click;
            // 
            // txtBuscarCodigoNombre
            // 
            txtBuscarCodigoNombre.Location = new Point(320, 28);
            txtBuscarCodigoNombre.Name = "txtBuscarCodigoNombre";
            txtBuscarCodigoNombre.Size = new Size(248, 23);
            txtBuscarCodigoNombre.TabIndex = 3;
            txtBuscarCodigoNombre.TextChanged += txtBuscarCodigoNombre_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(891, 9);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(79, 42);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // chkArticulodiscontinaudo
            // 
            chkArticulodiscontinaudo.AutoSize = true;
            chkArticulodiscontinaudo.Location = new Point(1078, 28);
            chkArticulodiscontinaudo.Name = "chkArticulodiscontinaudo";
            chkArticulodiscontinaudo.Size = new Size(197, 19);
            chkArticulodiscontinaudo.TabIndex = 5;
            chkArticulodiscontinaudo.Text = "Mostrar articulos discontinuado.";
            chkArticulodiscontinaudo.UseVisualStyleBackColor = true;
            chkArticulodiscontinaudo.CheckedChanged += chkArticulodiscontinaudo_CheckedChanged;
            // 
            // dtgCargaarticulo
            // 
            dtgCargaarticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCargaarticulo.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnDescripcion, clnRubro, clnMarca, clnProveedor, clmSucursal, clnVencimiento, clnUltActualizacion, clnUltVenta, clnPrecioCosto, clnPrecioVenta, clnIva, clnStockActual, clnStockMinimo, clnStockMaximo, clnActivo });
            dtgCargaarticulo.Location = new Point(12, 55);
            dtgCargaarticulo.Name = "dtgCargaarticulo";
            dtgCargaarticulo.Size = new Size(1263, 401);
            dtgCargaarticulo.TabIndex = 6;
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
            // clnProveedor
            // 
            clnProveedor.HeaderText = "Proveedor";
            clnProveedor.Name = "clnProveedor";
            // 
            // clmSucursal
            // 
            clmSucursal.HeaderText = "Sucursal";
            clmSucursal.Name = "clmSucursal";
            // 
            // clnVencimiento
            // 
            clnVencimiento.HeaderText = "Vencimiento";
            clnVencimiento.Name = "clnVencimiento";
            // 
            // clnUltActualizacion
            // 
            clnUltActualizacion.HeaderText = "Ultima Actualización";
            clnUltActualizacion.Name = "clnUltActualizacion";
            // 
            // clnUltVenta
            // 
            clnUltVenta.HeaderText = "Ultima Venta";
            clnUltVenta.Name = "clnUltVenta";
            // 
            // clnPrecioCosto
            // 
            clnPrecioCosto.HeaderText = "Precio Costo";
            clnPrecioCosto.Name = "clnPrecioCosto";
            // 
            // clnPrecioVenta
            // 
            clnPrecioVenta.HeaderText = "Precio Venta";
            clnPrecioVenta.Name = "clnPrecioVenta";
            // 
            // clnIva
            // 
            clnIva.HeaderText = "Iva";
            clnIva.Name = "clnIva";
            // 
            // clnStockActual
            // 
            clnStockActual.HeaderText = "Stock Actual";
            clnStockActual.Name = "clnStockActual";
            // 
            // clnStockMinimo
            // 
            clnStockMinimo.HeaderText = "Stock Mínimo";
            clnStockMinimo.Name = "clnStockMinimo";
            // 
            // clnStockMaximo
            // 
            clnStockMaximo.HeaderText = "Stock Maximo";
            clnStockMaximo.Name = "clnStockMaximo";
            // 
            // clnActivo
            // 
            clnActivo.HeaderText = "Activo";
            clnActivo.Name = "clnActivo";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(1167, 462);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(108, 37);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 9F);
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(984, 9);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 43);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblCodigoNombre
            // 
            lblCodigoNombre.AutoSize = true;
            lblCodigoNombre.Location = new Point(320, 9);
            lblCodigoNombre.Name = "lblCodigoNombre";
            lblCodigoNombre.Size = new Size(162, 15);
            lblCodigoNombre.TabIndex = 9;
            lblCodigoNombre.Text = "Buscar por Codigo o Nombre";
            // 
            // cmbMarca
            // 
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(741, 29);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(133, 23);
            cmbMarca.TabIndex = 10;
            // 
            // cmbRubro
            // 
            cmbRubro.FormattingEnabled = true;
            cmbRubro.Location = new Point(602, 29);
            cmbRubro.Name = "cmbRubro";
            cmbRubro.Size = new Size(133, 23);
            cmbRubro.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(602, 6);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 12;
            label1.Text = "Rubro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(741, 6);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 13;
            label2.Text = "Marca";
            // 
            // frmCargaarticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 506);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbRubro);
            Controls.Add(cmbMarca);
            Controls.Add(lblCodigoNombre);
            Controls.Add(btnEliminar);
            Controls.Add(btnSalir);
            Controls.Add(dtgCargaarticulo);
            Controls.Add(chkArticulodiscontinaudo);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarCodigoNombre);
            Controls.Add(btnDiscontinuar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevoArticulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCargaarticulo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar Articulo";
            ((System.ComponentModel.ISupportInitialize)dtgCargaarticulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevoArticulo;
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
        private DataGridViewTextBoxColumn clnProveedor;
        private DataGridViewTextBoxColumn clmSucursal;
        private DataGridViewTextBoxColumn clnVencimiento;
        private DataGridViewTextBoxColumn clnUltActualizacion;
        private DataGridViewTextBoxColumn clnUltVenta;
        private DataGridViewTextBoxColumn clnPrecioCosto;
        private DataGridViewTextBoxColumn clnPrecioVenta;
        private DataGridViewTextBoxColumn clnIva;
        private DataGridViewTextBoxColumn clnStockActual;
        private DataGridViewTextBoxColumn clnStockMinimo;
        private DataGridViewTextBoxColumn clnStockMaximo;
        private DataGridViewTextBoxColumn clnActivo;
    }
}