namespace CapaVista
{
    partial class frmDetalleCompra
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox gpbComprobante;
        private System.Windows.Forms.Label lblProveedorTitulo;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lblFechaTitulo;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblTipoTitulo;
        private System.Windows.Forms.TextBox txtTipoComprobante;
        private System.Windows.Forms.Label lblNumeroTitulo;
        private System.Windows.Forms.TextBox txtNumeroComprobante;

        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTotal;

        private System.Windows.Forms.GroupBox gpbObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;

        private System.Windows.Forms.Label lblSubtotalTitulo;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblIVATitulo;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.TextBox txtTotal;

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleCompra));
            gpbComprobante = new GroupBox();
            lblProveedorTitulo = new Label();
            txtProveedor = new TextBox();
            lblFechaTitulo = new Label();
            txtFecha = new TextBox();
            lblTipoTitulo = new Label();
            txtTipoComprobante = new TextBox();
            lblNumeroTitulo = new Label();
            txtNumeroComprobante = new TextBox();
            lblProductos = new Label();
            dgvDetalle = new DataGridView();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnProducto = new DataGridViewTextBoxColumn();
            clnCantidad = new DataGridViewTextBoxColumn();
            clnPrecio = new DataGridViewTextBoxColumn();
            clnIVA = new DataGridViewTextBoxColumn();
            clnTotal = new DataGridViewTextBoxColumn();
            gpbObservaciones = new GroupBox();
            txtObservaciones = new TextBox();
            lblSubtotalTitulo = new Label();
            txtSubtotal = new TextBox();
            lblIVATitulo = new Label();
            txtIVA = new TextBox();
            lblTotalTitulo = new Label();
            txtTotal = new TextBox();
            btnCerrar = new Button();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            gpbComprobante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            gpbObservaciones.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 11;
            lblTitulo.Text = "Detalle de la compra";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = SystemColors.GrayText;
            lblDescripcion.Location = new Point(13, 40);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.TabIndex = 12;
            lblDescripcion.Text = "Datos del comprobante, productos y totales de la compra seleccionada.";
            //
            // gpbComprobante
            //
            gpbComprobante.Controls.Add(lblProveedorTitulo);
            gpbComprobante.Controls.Add(txtProveedor);
            gpbComprobante.Controls.Add(lblFechaTitulo);
            gpbComprobante.Controls.Add(txtFecha);
            gpbComprobante.Controls.Add(lblTipoTitulo);
            gpbComprobante.Controls.Add(txtTipoComprobante);
            gpbComprobante.Controls.Add(lblNumeroTitulo);
            gpbComprobante.Controls.Add(txtNumeroComprobante);
            gpbComprobante.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbComprobante.Location = new Point(12, 64);
            gpbComprobante.Name = "gpbComprobante";
            gpbComprobante.Size = new Size(776, 105);
            gpbComprobante.TabIndex = 0;
            gpbComprobante.TabStop = false;
            gpbComprobante.Text = "Datos del comprobante";
            // 
            // lblProveedorTitulo
            // 
            lblProveedorTitulo.AutoSize = true;
            lblProveedorTitulo.Location = new Point(18, 28);
            lblProveedorTitulo.Name = "lblProveedorTitulo";
            lblProveedorTitulo.Size = new Size(64, 15);
            lblProveedorTitulo.TabIndex = 0;
            lblProveedorTitulo.Text = "Proveedor:";
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(90, 25);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.ReadOnly = true;
            txtProveedor.Size = new Size(300, 23);
            txtProveedor.TabIndex = 0;
            // 
            // lblFechaTitulo
            // 
            lblFechaTitulo.AutoSize = true;
            lblFechaTitulo.Location = new Point(420, 28);
            lblFechaTitulo.Name = "lblFechaTitulo";
            lblFechaTitulo.Size = new Size(41, 15);
            lblFechaTitulo.TabIndex = 1;
            lblFechaTitulo.Text = "Fecha:";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(470, 25);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(120, 23);
            txtFecha.TabIndex = 1;
            // 
            // lblTipoTitulo
            // 
            lblTipoTitulo.AutoSize = true;
            lblTipoTitulo.Location = new Point(18, 65);
            lblTipoTitulo.Name = "lblTipoTitulo";
            lblTipoTitulo.Size = new Size(108, 15);
            lblTipoTitulo.TabIndex = 2;
            lblTipoTitulo.Text = "Tipo comprobante:";
            // 
            // txtTipoComprobante
            // 
            txtTipoComprobante.Location = new Point(135, 62);
            txtTipoComprobante.Name = "txtTipoComprobante";
            txtTipoComprobante.ReadOnly = true;
            txtTipoComprobante.Size = new Size(170, 23);
            txtTipoComprobante.TabIndex = 2;
            // 
            // lblNumeroTitulo
            // 
            lblNumeroTitulo.AutoSize = true;
            lblNumeroTitulo.Location = new Point(420, 65);
            lblNumeroTitulo.Name = "lblNumeroTitulo";
            lblNumeroTitulo.Size = new Size(64, 15);
            lblNumeroTitulo.TabIndex = 3;
            lblNumeroTitulo.Text = "N.º comp.:";
            // 
            // txtNumeroComprobante
            // 
            txtNumeroComprobante.Location = new Point(490, 62);
            txtNumeroComprobante.Name = "txtNumeroComprobante";
            txtNumeroComprobante.ReadOnly = true;
            txtNumeroComprobante.Size = new Size(150, 23);
            txtNumeroComprobante.TabIndex = 3;
            // 
            // lblProductos
            // 
            lblProductos.AutoSize = true;
            lblProductos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductos.Location = new Point(12, 180);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(63, 15);
            lblProductos.TabIndex = 10;
            lblProductos.Text = "Productos";
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnProducto, clnCantidad, clnPrecio, clnIVA, clnTotal });
            dgvDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalle.Location = new Point(12, 200);
            dgvDetalle.MultiSelect = false;
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(776, 220);
            dgvDetalle.TabIndex = 1;
            // 
            // clnCodigo
            // 
            clnCodigo.HeaderText = "Código";
            clnCodigo.Name = "clnCodigo";
            clnCodigo.ReadOnly = true;
            // 
            // clnProducto
            // 
            clnProducto.HeaderText = "Producto";
            clnProducto.Name = "clnProducto";
            clnProducto.ReadOnly = true;
            // 
            // clnCantidad
            // 
            clnCantidad.HeaderText = "Cantidad";
            clnCantidad.Name = "clnCantidad";
            clnCantidad.ReadOnly = true;
            // 
            // clnPrecio
            // 
            clnPrecio.HeaderText = "Precio S/IVA";
            clnPrecio.Name = "clnPrecio";
            clnPrecio.ReadOnly = true;
            // 
            // clnIVA
            // 
            clnIVA.HeaderText = "% IVA";
            clnIVA.Name = "clnIVA";
            clnIVA.ReadOnly = true;
            // 
            // clnTotal
            // 
            clnTotal.HeaderText = "Total";
            clnTotal.Name = "clnTotal";
            clnTotal.ReadOnly = true;
            // 
            // gpbObservaciones
            // 
            gpbObservaciones.Controls.Add(txtObservaciones);
            gpbObservaciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbObservaciones.Location = new Point(12, 432);
            gpbObservaciones.Name = "gpbObservaciones";
            gpbObservaciones.Size = new Size(470, 105);
            gpbObservaciones.TabIndex = 2;
            gpbObservaciones.TabStop = false;
            gpbObservaciones.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Dock = DockStyle.Fill;
            txtObservaciones.Location = new Point(3, 19);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ReadOnly = true;
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(464, 83);
            txtObservaciones.TabIndex = 0;
            // 
            // lblSubtotalTitulo
            // 
            lblSubtotalTitulo.AutoSize = true;
            lblSubtotalTitulo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSubtotalTitulo.Location = new Point(500, 437);
            lblSubtotalTitulo.Name = "lblSubtotalTitulo";
            lblSubtotalTitulo.Size = new Size(85, 15);
            lblSubtotalTitulo.TabIndex = 9;
            lblSubtotalTitulo.Text = "Subtotal S/IVA:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtSubtotal.Location = new Point(640, 434);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(148, 23);
            txtSubtotal.TabIndex = 3;
            txtSubtotal.TextAlign = HorizontalAlignment.Right;
            // 
            // lblIVATitulo
            // 
            lblIVATitulo.AutoSize = true;
            lblIVATitulo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblIVATitulo.Location = new Point(500, 472);
            lblIVATitulo.Name = "lblIVATitulo";
            lblIVATitulo.Size = new Size(27, 15);
            lblIVATitulo.TabIndex = 8;
            lblIVATitulo.Text = "IVA:";
            // 
            // txtIVA
            // 
            txtIVA.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtIVA.Location = new Point(640, 469);
            txtIVA.Name = "txtIVA";
            txtIVA.ReadOnly = true;
            txtIVA.Size = new Size(148, 23);
            txtIVA.TabIndex = 4;
            txtIVA.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTotalTitulo
            // 
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalTitulo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalTitulo.Location = new Point(500, 507);
            lblTotalTitulo.Name = "lblTotalTitulo";
            lblTotalTitulo.Size = new Size(46, 15);
            lblTotalTitulo.TabIndex = 7;
            lblTotalTitulo.Text = "TOTAL:";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTotal.Location = new Point(640, 504);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(148, 23);
            txtTotal.TabIndex = 5;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Location = new Point(688, 547);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 32);
            btnCerrar.TabIndex = 6;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmDetalleCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 591);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescripcion);
            Controls.Add(btnCerrar);
            Controls.Add(txtTotal);
            Controls.Add(lblTotalTitulo);
            Controls.Add(txtIVA);
            Controls.Add(lblIVATitulo);
            Controls.Add(txtSubtotal);
            Controls.Add(lblSubtotalTitulo);
            Controls.Add(gpbObservaciones);
            Controls.Add(dgvDetalle);
            Controls.Add(lblProductos);
            Controls.Add(gpbComprobante);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            MinimumSize = new Size(816, 630);
            Name = "frmDetalleCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de compra";
            gpbComprobante.ResumeLayout(false);
            gpbComprobante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            gpbObservaciones.ResumeLayout(false);
            gpbObservaciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}