namespace CapaVista
{
    partial class frmDetalleVenta
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
            lblEstado = new Label();
            lblFecha = new Label();
            lblCajero = new Label();
            lblCaja = new Label();
            lblProductos = new Label();
            dgvProductos = new DataGridView();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnProducto = new DataGridViewTextBoxColumn();
            clnCantidad = new DataGridViewTextBoxColumn();
            clnPrecio = new DataGridViewTextBoxColumn();
            clnSubtotal = new DataGridViewTextBoxColumn();
            lblPagos = new Label();
            dgvPagos = new DataGridView();
            clnMedio = new DataGridViewTextBoxColumn();
            clnMonto = new DataGridViewTextBoxColumn();
            lblTotalTexto = new Label();
            lblTotal = new Label();
            lblNotas = new Label();
            txtNotas = new TextBox();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(110, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Venta N.º";
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstado.Location = new Point(200, 15);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(50, 19);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Activa";
            //
            // lblFecha
            //
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(13, 44);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            //
            // lblCajero
            //
            lblCajero.AutoSize = true;
            lblCajero.Location = new Point(230, 44);
            lblCajero.Name = "lblCajero";
            lblCajero.Size = new Size(44, 15);
            lblCajero.TabIndex = 3;
            lblCajero.Text = "Cajero:";
            //
            // lblCaja
            //
            lblCaja.AutoSize = true;
            lblCaja.Location = new Point(420, 44);
            lblCaja.Name = "lblCaja";
            lblCaja.Size = new Size(33, 15);
            lblCaja.TabIndex = 4;
            lblCaja.Text = "Caja:";
            //
            // lblProductos
            //
            lblProductos.AutoSize = true;
            lblProductos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductos.Location = new Point(13, 72);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(65, 15);
            lblProductos.TabIndex = 5;
            lblProductos.Text = "Productos";
            //
            // dgvProductos
            //
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = SystemColors.Window;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnProducto, clnCantidad, clnPrecio, clnSubtotal });
            dgvProductos.Location = new Point(12, 90);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(696, 230);
            dgvProductos.TabIndex = 6;
            //
            // clnCodigo
            //
            clnCodigo.FillWeight = 70F;
            clnCodigo.HeaderText = "Código";
            clnCodigo.MinimumWidth = 90;
            clnCodigo.Name = "clnCodigo";
            clnCodigo.ReadOnly = true;
            //
            // clnProducto
            //
            clnProducto.FillWeight = 160F;
            clnProducto.HeaderText = "Producto";
            clnProducto.MinimumWidth = 150;
            clnProducto.Name = "clnProducto";
            clnProducto.ReadOnly = true;
            //
            // clnCantidad
            //
            clnCantidad.FillWeight = 50F;
            clnCantidad.HeaderText = "Cantidad";
            clnCantidad.MinimumWidth = 70;
            clnCantidad.Name = "clnCantidad";
            clnCantidad.ReadOnly = true;
            //
            // clnPrecio
            //
            clnPrecio.FillWeight = 70F;
            clnPrecio.HeaderText = "Precio unitario";
            clnPrecio.MinimumWidth = 90;
            clnPrecio.Name = "clnPrecio";
            clnPrecio.ReadOnly = true;
            //
            // clnSubtotal
            //
            clnSubtotal.FillWeight = 70F;
            clnSubtotal.HeaderText = "Subtotal";
            clnSubtotal.MinimumWidth = 90;
            clnSubtotal.Name = "clnSubtotal";
            clnSubtotal.ReadOnly = true;
            //
            // lblPagos
            //
            lblPagos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPagos.AutoSize = true;
            lblPagos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPagos.Location = new Point(13, 330);
            lblPagos.Name = "lblPagos";
            lblPagos.Size = new Size(41, 15);
            lblPagos.TabIndex = 7;
            lblPagos.Text = "Pagos";
            //
            // dgvPagos
            //
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.AllowUserToResizeRows = false;
            dgvPagos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.BackgroundColor = SystemColors.Window;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Columns.AddRange(new DataGridViewColumn[] { clnMedio, clnMonto });
            dgvPagos.Location = new Point(12, 348);
            dgvPagos.MultiSelect = false;
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersVisible = false;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.Size = new Size(320, 100);
            dgvPagos.TabIndex = 9;
            //
            // clnMedio
            //
            clnMedio.FillWeight = 120F;
            clnMedio.HeaderText = "Medio de pago";
            clnMedio.Name = "clnMedio";
            clnMedio.ReadOnly = true;
            //
            // clnMonto
            //
            clnMonto.HeaderText = "Monto";
            clnMonto.Name = "clnMonto";
            clnMonto.ReadOnly = true;
            //
            // lblTotalTexto
            //
            lblTotalTexto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalTexto.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalTexto.Location = new Point(448, 348);
            lblTotalTexto.Name = "lblTotalTexto";
            lblTotalTexto.Size = new Size(260, 22);
            lblTotalTexto.TabIndex = 8;
            lblTotalTexto.Text = "Total de la venta";
            lblTotalTexto.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTotal
            //
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotal.Location = new Point(448, 372);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(260, 36);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "$ 0,00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblNotas
            //
            lblNotas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblNotas.AutoSize = true;
            lblNotas.Location = new Point(13, 458);
            lblNotas.Name = "lblNotas";
            lblNotas.Size = new Size(185, 15);
            lblNotas.TabIndex = 11;
            lblNotas.Text = "Observaciones y motivo de anulación:";
            //
            // txtNotas
            //
            txtNotas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNotas.BackColor = SystemColors.Window;
            txtNotas.Location = new Point(12, 476);
            txtNotas.Multiline = true;
            txtNotas.Name = "txtNotas";
            txtNotas.ReadOnly = true;
            txtNotas.ScrollBars = ScrollBars.Vertical;
            txtNotas.Size = new Size(590, 50);
            txtNotas.TabIndex = 12;
            //
            // btnCerrar
            //
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Location = new Point(613, 492);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(95, 34);
            btnCerrar.TabIndex = 13;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            //
            // frmDetalleVenta
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCerrar;
            ClientSize = new Size(720, 538);
            Controls.Add(lblTitulo);
            Controls.Add(lblEstado);
            Controls.Add(lblFecha);
            Controls.Add(lblCajero);
            Controls.Add(lblCaja);
            Controls.Add(lblProductos);
            Controls.Add(dgvProductos);
            Controls.Add(lblPagos);
            Controls.Add(dgvPagos);
            Controls.Add(lblTotalTexto);
            Controls.Add(lblTotal);
            Controls.Add(lblNotas);
            Controls.Add(txtNotas);
            Controls.Add(btnCerrar);
            MinimizeBox = false;
            MinimumSize = new Size(736, 500);
            Name = "frmDetalleVenta";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de la venta";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblEstado;
        private Label lblFecha;
        private Label lblCajero;
        private Label lblCaja;
        private Label lblProductos;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn clnCodigo;
        private DataGridViewTextBoxColumn clnProducto;
        private DataGridViewTextBoxColumn clnCantidad;
        private DataGridViewTextBoxColumn clnPrecio;
        private DataGridViewTextBoxColumn clnSubtotal;
        private Label lblPagos;
        private DataGridView dgvPagos;
        private DataGridViewTextBoxColumn clnMedio;
        private DataGridViewTextBoxColumn clnMonto;
        private Label lblTotalTexto;
        private Label lblTotal;
        private Label lblNotas;
        private TextBox txtNotas;
        private Button btnCerrar;
    }
}
