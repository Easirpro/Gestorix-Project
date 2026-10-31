namespace CapaVista
{
    partial class frmCobroSecundario
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobroSecundario));
            btnArchivo = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            btnArt = new ToolStripMenuItem();
            btnVentas = new ToolStripMenuItem();
            btnCompras = new ToolStripMenuItem();
            btnProve = new ToolStripMenuItem();
            btnListados = new ToolStripMenuItem();
            btnInformes = new ToolStripMenuItem();
            btnHerra = new ToolStripMenuItem();
            btnCaja = new ToolStripMenuItem();
            cerrarSeToolStripMenuItem = new ToolStripMenuItem();
            btnAyuda = new ToolStripMenuItem();
            btnAjustes = new ToolStripMenuItem();
            permisosToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            lblSubtotalMonto = new Label();
            lblDescuentoMonto = new Label();
            lblTotalMonto = new Label();
            label5 = new Label();
            label2 = new Label();
            btnPromocion = new Button();
            dtgPresentacion = new DataGridView();
            ClnSKU = new DataGridViewTextBoxColumn();
            ClnIdProducto = new DataGridViewTextBoxColumn();
            ClnCodigo = new DataGridViewTextBoxColumn();
            ClnDescripcion = new DataGridViewTextBoxColumn();
            ClnCantidad = new DataGridViewTextBoxColumn();
            ClnPrecioUnitario = new DataGridViewTextBoxColumn();
            ClnImporte = new DataGridViewTextBoxColumn();
            txtCantidad = new TextBox();
            txtCodigoBarra = new TextBox();
            label4 = new Label();
            label3 = new Label();
            pcbLogo = new PictureBox();
            btnCobrar = new Button();
            btnCambiarcantidad = new Button();
            btnQuitar = new Button();
            btnSalir = new Button();
            lstDescripcion = new ListBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgPresentacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbLogo).BeginInit();
            SuspendLayout();
            // 
            // btnArchivo
            // 
            btnArchivo.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            btnArchivo.Enabled = false;
            btnArchivo.Name = "btnArchivo";
            btnArchivo.Size = new Size(60, 20);
            btnArchivo.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(96, 22);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // btnArt
            // 
            btnArt.Enabled = false;
            btnArt.Name = "btnArt";
            btnArt.Size = new Size(66, 20);
            btnArt.Text = "Artículos";
            // 
            // btnVentas
            // 
            btnVentas.Enabled = false;
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(53, 20);
            btnVentas.Text = "Ventas";
            // 
            // btnCompras
            // 
            btnCompras.Enabled = false;
            btnCompras.Name = "btnCompras";
            btnCompras.Size = new Size(67, 20);
            btnCompras.Text = "Compras";
            // 
            // btnProve
            // 
            btnProve.Enabled = false;
            btnProve.Name = "btnProve";
            btnProve.Size = new Size(84, 20);
            btnProve.Text = "Proveedores";
            // 
            // btnListados
            // 
            btnListados.Enabled = false;
            btnListados.Name = "btnListados";
            btnListados.Size = new Size(62, 20);
            btnListados.Text = "Listados";
            // 
            // btnInformes
            // 
            btnInformes.Enabled = false;
            btnInformes.Name = "btnInformes";
            btnInformes.Size = new Size(66, 20);
            btnInformes.Text = "Informes";
            // 
            // btnHerra
            // 
            btnHerra.Enabled = false;
            btnHerra.Name = "btnHerra";
            btnHerra.Size = new Size(90, 20);
            btnHerra.Text = "Herramientas";
            // 
            // btnCaja
            // 
            btnCaja.Name = "btnCaja";
            btnCaja.Size = new Size(32, 19);
            // 
            // cerrarSeToolStripMenuItem
            // 
            cerrarSeToolStripMenuItem.Name = "cerrarSeToolStripMenuItem";
            cerrarSeToolStripMenuItem.Size = new Size(32, 19);
            // 
            // btnAyuda
            // 
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(32, 19);
            // 
            // btnAjustes
            // 
            btnAjustes.Name = "btnAjustes";
            btnAjustes.Size = new Size(32, 19);
            // 
            // permisosToolStripMenuItem
            // 
            permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            permisosToolStripMenuItem.Size = new Size(32, 19);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = SystemColors.ActiveCaptionText;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblSubtotalMonto, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDescuentoMonto, 1, 1);
            tableLayoutPanel1.Controls.Add(lblTotalMonto, 1, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Location = new Point(597, 13);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel1.Size = new Size(273, 126);
            tableLayoutPanel1.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(3, 5);
            label1.Margin = new Padding(3, 5, 3, 5);
            label1.Name = "label1";
            label1.Size = new Size(130, 29);
            label1.TabIndex = 0;
            label1.Text = "Subtotal";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtotalMonto
            // 
            lblSubtotalMonto.AutoSize = true;
            lblSubtotalMonto.Dock = DockStyle.Fill;
            lblSubtotalMonto.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotalMonto.ForeColor = Color.LawnGreen;
            lblSubtotalMonto.Location = new Point(139, 5);
            lblSubtotalMonto.Margin = new Padding(3, 5, 3, 5);
            lblSubtotalMonto.Name = "lblSubtotalMonto";
            lblSubtotalMonto.Size = new Size(131, 29);
            lblSubtotalMonto.TabIndex = 2;
            lblSubtotalMonto.Text = "$0000";
            lblSubtotalMonto.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDescuentoMonto
            // 
            lblDescuentoMonto.AutoSize = true;
            lblDescuentoMonto.Dock = DockStyle.Fill;
            lblDescuentoMonto.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescuentoMonto.ForeColor = SystemColors.ScrollBar;
            lblDescuentoMonto.Location = new Point(139, 44);
            lblDescuentoMonto.Margin = new Padding(3, 5, 3, 5);
            lblDescuentoMonto.Name = "lblDescuentoMonto";
            lblDescuentoMonto.Size = new Size(131, 29);
            lblDescuentoMonto.TabIndex = 3;
            lblDescuentoMonto.Text = "$0000";
            lblDescuentoMonto.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalMonto
            // 
            lblTotalMonto.AutoSize = true;
            lblTotalMonto.Dock = DockStyle.Fill;
            lblTotalMonto.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalMonto.ForeColor = Color.LawnGreen;
            lblTotalMonto.Location = new Point(139, 83);
            lblTotalMonto.Margin = new Padding(3, 5, 3, 5);
            lblTotalMonto.Name = "lblTotalMonto";
            lblTotalMonto.Size = new Size(131, 38);
            lblTotalMonto.TabIndex = 5;
            lblTotalMonto.Text = "$0000";
            lblTotalMonto.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(3, 83);
            label5.Margin = new Padding(3, 5, 3, 5);
            label5.Name = "label5";
            label5.Size = new Size(130, 38);
            label5.TabIndex = 4;
            label5.Text = "Total";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ScrollBar;
            label2.Location = new Point(3, 44);
            label2.Margin = new Padding(3, 5, 3, 5);
            label2.Name = "label2";
            label2.Size = new Size(130, 29);
            label2.TabIndex = 1;
            label2.Text = "Descuento/Recargo";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnPromocion
            // 
            btnPromocion.AccessibleRole = AccessibleRole.None;
            btnPromocion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPromocion.BackColor = Color.Transparent;
            btnPromocion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPromocion.Image = (Image)resources.GetObject("btnPromocion.Image");
            btnPromocion.ImageAlign = ContentAlignment.MiddleLeft;
            btnPromocion.Location = new Point(23, 351);
            btnPromocion.Name = "btnPromocion";
            btnPromocion.Size = new Size(207, 74);
            btnPromocion.TabIndex = 34;
            btnPromocion.Text = "Promociónes";
            btnPromocion.TextAlign = ContentAlignment.MiddleRight;
            btnPromocion.UseVisualStyleBackColor = false;
            btnPromocion.Click += btnPromocion_Click;
            // 
            // dtgPresentacion
            // 
            dtgPresentacion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgPresentacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgPresentacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgPresentacion.Columns.AddRange(new DataGridViewColumn[] { ClnSKU, ClnIdProducto, ClnCodigo, ClnDescripcion, ClnCantidad, ClnPrecioUnitario, ClnImporte });
            dtgPresentacion.Location = new Point(23, 73);
            dtgPresentacion.Name = "dtgPresentacion";
            dtgPresentacion.Size = new Size(557, 272);
            dtgPresentacion.TabIndex = 25;
            // 
            // ClnSKU
            // 
            ClnSKU.HeaderText = "SKU";
            ClnSKU.Name = "ClnSKU";
            // 
            // ClnIdProducto
            // 
            ClnIdProducto.HeaderText = "IdProducto";
            ClnIdProducto.Name = "ClnIdProducto";
            ClnIdProducto.ReadOnly = true;
            ClnIdProducto.Visible = false;
            // 
            // ClnCodigo
            // 
            ClnCodigo.HeaderText = "Código";
            ClnCodigo.Name = "ClnCodigo";
            // 
            // ClnDescripcion
            // 
            ClnDescripcion.HeaderText = "Descripción";
            ClnDescripcion.Name = "ClnDescripcion";
            // 
            // ClnCantidad
            // 
            ClnCantidad.HeaderText = "Cantidad";
            ClnCantidad.Name = "ClnCantidad";
            // 
            // ClnPrecioUnitario
            // 
            ClnPrecioUnitario.HeaderText = "Precio Unitario";
            ClnPrecioUnitario.Name = "ClnPrecioUnitario";
            // 
            // ClnImporte
            // 
            ClnImporte.HeaderText = "Importe";
            ClnImporte.Name = "ClnImporte";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(369, 32);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(114, 23);
            txtCantidad.TabIndex = 24;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            txtCantidad.KeyDown += txtCantidad_KeyDown;
            // 
            // txtCodigoBarra
            // 
            txtCodigoBarra.Location = new Point(23, 32);
            txtCodigoBarra.Name = "txtCodigoBarra";
            txtCodigoBarra.Size = new Size(327, 23);
            txtCodigoBarra.TabIndex = 23;
            txtCodigoBarra.TextChanged += txtCodigoBarra_TextChanged;
            txtCodigoBarra.KeyDown += txtCodigoBarra_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.ForestGreen;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(369, 13);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 22;
            label4.Text = "Agregar la cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.ForestGreen;
            label3.ForeColor = Color.White;
            label3.Location = new Point(23, 13);
            label3.Name = "label3";
            label3.Size = new Size(327, 15);
            label3.TabIndex = 21;
            label3.Text = "Escaneá un código o escribí parte del SKU o del nombre.        ";
            // 
            // pcbLogo
            // 
            pcbLogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pcbLogo.Image = (Image)resources.GetObject("pcbLogo.Image");
            pcbLogo.Location = new Point(597, 208);
            pcbLogo.Name = "pcbLogo";
            pcbLogo.Size = new Size(270, 208);
            pcbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pcbLogo.TabIndex = 33;
            pcbLogo.TabStop = false;
            // 
            // btnCobrar
            // 
            btnCobrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCobrar.BackColor = Color.ForestGreen;
            btnCobrar.FlatStyle = FlatStyle.Flat;
            btnCobrar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCobrar.ForeColor = Color.White;
            btnCobrar.Location = new Point(597, 145);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(273, 45);
            btnCobrar.TabIndex = 20;
            btnCobrar.Text = "F2-Cobrar";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click_1;
            // 
            // btnCambiarcantidad
            // 
            btnCambiarcantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCambiarcantidad.Location = new Point(465, 351);
            btnCambiarcantidad.Name = "btnCambiarcantidad";
            btnCambiarcantidad.Size = new Size(115, 23);
            btnCambiarcantidad.TabIndex = 30;
            btnCambiarcantidad.Text = "Cambiar cantidad";
            btnCambiarcantidad.UseVisualStyleBackColor = true;
            btnCambiarcantidad.Click += btnCambiarcantidad_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnQuitar.Location = new Point(384, 351);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(75, 23);
            btnQuitar.TabIndex = 27;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(764, 495);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(103, 43);
            btnSalir.TabIndex = 36;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lstDescripcion
            // 
            lstDescripcion.FormattingEnabled = true;
            lstDescripcion.ItemHeight = 15;
            lstDescripcion.Location = new Point(23, 57);
            lstDescripcion.Name = "lstDescripcion";
            lstDescripcion.Size = new Size(327, 94);
            lstDescripcion.TabIndex = 37;
            lstDescripcion.Visible = false;
            lstDescripcion.SelectedIndexChanged += lstDescripcion_SelectedIndexChanged;
            lstDescripcion.DoubleClick += lstDescripcion_DoubleClick;
            lstDescripcion.KeyDown += lstDescripcion_KeyDown;
            // 
            // frmCobroSecundario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 560);
            Controls.Add(lstDescripcion);
            Controls.Add(btnSalir);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnPromocion);
            Controls.Add(dtgPresentacion);
            Controls.Add(txtCantidad);
            Controls.Add(txtCodigoBarra);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pcbLogo);
            Controls.Add(btnCobrar);
            Controls.Add(btnCambiarcantidad);
            Controls.Add(btnQuitar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCobroSecundario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Segundo Cobro";
            Load += frmCobroSecundario_Load;
            KeyDown += frmCobroSecundario_KeyDown;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgPresentacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolStripMenuItem btnArchivo;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem btnArt;
        private ToolStripMenuItem btnVentas;
        private ToolStripMenuItem btnCompras;
        private ToolStripMenuItem btnProve;
        private ToolStripMenuItem btnListados;
        private ToolStripMenuItem btnInformes;
        private ToolStripMenuItem btnHerra;
        private ToolStripMenuItem btnCaja;
        private ToolStripMenuItem cerrarSeToolStripMenuItem;
        private ToolStripMenuItem btnAyuda;
        private ToolStripMenuItem btnAjustes;
        private ToolStripMenuItem permisosToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label lblSubtotalMonto;
        private Label lblDescuentoMonto;
        private Label lblTotalMonto;
        private Label label5;
        private Label label2;
        private Button btnPromocion;
        private DataGridView dtgPresentacion;
        private DataGridViewTextBoxColumn ClnSKU;
        private DataGridViewTextBoxColumn ClnIdProducto;
        private DataGridViewTextBoxColumn ClnCodigo;
        private DataGridViewTextBoxColumn ClnDescripcion;
        private DataGridViewTextBoxColumn ClnCantidad;
        private DataGridViewTextBoxColumn ClnPrecioUnitario;
        private DataGridViewTextBoxColumn ClnImporte;
        private TextBox txtCantidad;
        private TextBox txtCodigoBarra;
        private Label label4;
        private Label label3;
        private PictureBox pcbLogo;
        private Button btnCobrar;
        private Button btnCambiarcantidad;
        private Button btnQuitar;
        private Button btnSalir;
        private ListBox lstDescripcion;
    }
}