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
            textBox1 = new TextBox();
            btnBuscar = new Button();
            chkArticulodiscontinaudo = new CheckBox();
            dtgCargaarticulo = new DataGridView();
            btnSalir = new Button();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnDescripcion = new DataGridViewTextBoxColumn();
            clnRubro = new DataGridViewTextBoxColumn();
            clnProveedor = new DataGridViewTextBoxColumn();
            clmSucursal = new DataGridViewTextBoxColumn();
            clnVencimiento = new DataGridViewTextBoxColumn();
            clnPrecioVenta = new DataGridViewTextBoxColumn();
            clnUltActualizacion = new DataGridViewTextBoxColumn();
            clnUltVenta = new DataGridViewTextBoxColumn();
            clnPrecioNeto = new DataGridViewTextBoxColumn();
            clnPrecioCosto = new DataGridViewTextBoxColumn();
            clnIva = new DataGridViewTextBoxColumn();
            clnStockActual = new DataGridViewTextBoxColumn();
            clnStockMinimo = new DataGridViewTextBoxColumn();
            clnStockMaximo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dtgCargaarticulo).BeginInit();
            SuspendLayout();
            // 
            // btnNuevoArticulo
            // 
            btnNuevoArticulo.Image = (Image)resources.GetObject("btnNuevoArticulo.Image");
            btnNuevoArticulo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevoArticulo.Location = new Point(12, 11);
            btnNuevoArticulo.Name = "btnNuevoArticulo";
            btnNuevoArticulo.Size = new Size(116, 24);
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
            btnModificar.Location = new Point(134, 11);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(83, 24);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnDiscontinuar
            // 
            btnDiscontinuar.Location = new Point(223, 12);
            btnDiscontinuar.Name = "btnDiscontinuar";
            btnDiscontinuar.Size = new Size(91, 24);
            btnDiscontinuar.TabIndex = 2;
            btnDiscontinuar.Text = "Discontinuar";
            btnDiscontinuar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(320, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(248, 23);
            textBox1.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(574, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(79, 24);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // chkArticulodiscontinaudo
            // 
            chkArticulodiscontinaudo.AutoSize = true;
            chkArticulodiscontinaudo.Location = new Point(700, 14);
            chkArticulodiscontinaudo.Name = "chkArticulodiscontinaudo";
            chkArticulodiscontinaudo.Size = new Size(197, 19);
            chkArticulodiscontinaudo.TabIndex = 5;
            chkArticulodiscontinaudo.Text = "Ocultar atticulos discontinuados";
            chkArticulodiscontinaudo.UseVisualStyleBackColor = true;
            // 
            // dtgCargaarticulo
            // 
            dtgCargaarticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCargaarticulo.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnDescripcion, clnRubro, clnProveedor, clmSucursal, clnVencimiento, clnPrecioVenta, clnUltActualizacion, clnUltVenta, clnPrecioNeto, clnPrecioCosto, clnIva, clnStockActual, clnStockMinimo, clnStockMaximo });
            dtgCargaarticulo.Location = new Point(12, 37);
            dtgCargaarticulo.Name = "dtgCargaarticulo";
            dtgCargaarticulo.Size = new Size(996, 401);
            dtgCargaarticulo.TabIndex = 6;
            dtgCargaarticulo.CellContentClick += dtgCargaarticulo_CellContentClick;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(862, 453);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(108, 37);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
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
            // clnPrecioVenta
            // 
            clnPrecioVenta.HeaderText = "Precio Venta";
            clnPrecioVenta.Name = "clnPrecioVenta";
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
            // clnPrecioNeto
            // 
            clnPrecioNeto.HeaderText = "Precio Neto";
            clnPrecioNeto.Name = "clnPrecioNeto";
            // 
            // clnPrecioCosto
            // 
            clnPrecioCosto.HeaderText = "Precio Costo";
            clnPrecioCosto.Name = "clnPrecioCosto";
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
            // frmCargaarticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 506);
            Controls.Add(btnSalir);
            Controls.Add(dtgCargaarticulo);
            Controls.Add(chkArticulodiscontinaudo);
            Controls.Add(btnBuscar);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private Button btnBuscar;
        private CheckBox chkArticulodiscontinaudo;
        private DataGridView dtgCargaarticulo;
        private Button btnSalir;
        private DataGridViewTextBoxColumn clnCodigo;
        private DataGridViewTextBoxColumn clnDescripcion;
        private DataGridViewTextBoxColumn clnRubro;
        private DataGridViewTextBoxColumn clnProveedor;
        private DataGridViewTextBoxColumn clmSucursal;
        private DataGridViewTextBoxColumn clnVencimiento;
        private DataGridViewTextBoxColumn clnPrecioVenta;
        private DataGridViewTextBoxColumn clnUltActualizacion;
        private DataGridViewTextBoxColumn clnUltVenta;
        private DataGridViewTextBoxColumn clnPrecioNeto;
        private DataGridViewTextBoxColumn clnPrecioCosto;
        private DataGridViewTextBoxColumn clnIva;
        private DataGridViewTextBoxColumn clnStockActual;
        private DataGridViewTextBoxColumn clnStockMinimo;
        private DataGridViewTextBoxColumn clnStockMaximo;
    }
}