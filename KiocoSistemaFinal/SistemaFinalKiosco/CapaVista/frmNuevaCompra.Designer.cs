namespace CapaVista
{
    partial class frmNuevaCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaCompra));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label8 = new Label();
            label9 = new Label();
            labelNumeroComprobante = new Label();
            gpbProveedor = new GroupBox();
            btnBuscar = new Button();
            txtProveedor = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            txtNumeroComprobante = new TextBox();
            txtCodigobarra = new TextBox();
            btnCargarProducto = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnEliminarCompra = new Button();
            txtSubsinImpuesto = new TextBox();
            txtIva = new TextBox();
            txtTotal = new TextBox();
            txtObservaciones = new TextBox();
            btnGuardar = new Button();
            btnCacelar = new Button();
            lstProductos = new ListBox();
            gpbProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 98);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Código de Barra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(373, 25);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 1;
            label2.Text = "Tipo de Comprobante";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(373, 67);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 2;
            label3.Text = "Fecha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 480);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 21;
            label4.Text = "Observaciones";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(428, 436);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 15;
            label5.Text = "Subtotal S/I";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(213, 436);
            label8.Name = "label8";
            label8.Size = new Size(24, 15);
            label8.TabIndex = 16;
            label8.Text = "IVA";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 440);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 17;
            label9.Text = "Total";
            // 
            // labelNumeroComprobante
            // 
            labelNumeroComprobante.AutoSize = true;
            labelNumeroComprobante.Location = new Point(16, 226);
            labelNumeroComprobante.Name = "labelNumeroComprobante";
            labelNumeroComprobante.Size = new Size(115, 15);
            labelNumeroComprobante.TabIndex = 3;
            labelNumeroComprobante.Text = "N.º de comprobante";
            // 
            // gpbProveedor
            // 
            gpbProveedor.Controls.Add(btnBuscar);
            gpbProveedor.Controls.Add(txtProveedor);
            gpbProveedor.Location = new Point(12, 22);
            gpbProveedor.Name = "gpbProveedor";
            gpbProveedor.Size = new Size(355, 73);
            gpbProveedor.TabIndex = 4;
            gpbProveedor.TabStop = false;
            gpbProveedor.Text = "Proveedor";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(244, 31);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(105, 23);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(6, 32);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(216, 23);
            txtProveedor.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(424, 61);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(215, 23);
            dateTimePicker1.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Factura A", "Factura B", "Factura C", "Nota de Crédito A", "Nota de Crédito B", "Nota de Crédito C" });
            comboBox1.Location = new Point(502, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(137, 23);
            comboBox1.TabIndex = 8;
            // 
            // txtNumeroComprobante
            // 
            txtNumeroComprobante.Location = new Point(148, 223);
            txtNumeroComprobante.Name = "txtNumeroComprobante";
            txtNumeroComprobante.Size = new Size(160, 23);
            txtNumeroComprobante.TabIndex = 9;
            // 
            // txtCodigobarra
            // 
            txtCodigobarra.Location = new Point(18, 116);
            txtCodigobarra.Name = "txtCodigobarra";
            txtCodigobarra.Size = new Size(145, 23);
            txtCodigobarra.TabIndex = 10;
            txtCodigobarra.TextChanged += txtCodigobarra_TextChanged;
            txtCodigobarra.KeyDown += txtCodigobarra_KeyDown;
            // 
            // btnCargarProducto
            // 
            btnCargarProducto.Location = new Point(180, 116);
            btnCargarProducto.Name = "btnCargarProducto";
            btnCargarProducto.Size = new Size(75, 23);
            btnCargarProducto.TabIndex = 11;
            btnCargarProducto.Text = "Cargar";
            btnCargarProducto.UseVisualStyleBackColor = true;
            btnCargarProducto.Click += btnCargarProducto_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridView1.Location = new Point(17, 252);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(621, 134);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit_1;
            // 
            // Column1
            // 
            Column1.HeaderText = "Código";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Cantidad";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Descripción";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Precio sin IVA";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "% IVA";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "Total";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // btnEliminarCompra
            // 
            btnEliminarCompra.Location = new Point(16, 392);
            btnEliminarCompra.Name = "btnEliminarCompra";
            btnEliminarCompra.Size = new Size(75, 23);
            btnEliminarCompra.TabIndex = 13;
            btnEliminarCompra.Text = "Eliminar";
            btnEliminarCompra.UseVisualStyleBackColor = true;
            btnEliminarCompra.Click += btnEliminarCompra_Click;
            // 
            // txtSubsinImpuesto
            // 
            txtSubsinImpuesto.Location = new Point(517, 432);
            txtSubsinImpuesto.Name = "txtSubsinImpuesto";
            txtSubsinImpuesto.ReadOnly = true;
            txtSubsinImpuesto.Size = new Size(121, 23);
            txtSubsinImpuesto.TabIndex = 18;
            // 
            // txtIva
            // 
            txtIva.Location = new Point(255, 432);
            txtIva.Name = "txtIva";
            txtIva.ReadOnly = true;
            txtIva.Size = new Size(121, 23);
            txtIva.TabIndex = 19;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(55, 433);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(121, 23);
            txtTotal.TabIndex = 20;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(107, 477);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(532, 67);
            txtObservaciones.TabIndex = 22;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(467, 550);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 23;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCacelar
            // 
            btnCacelar.Location = new Point(564, 550);
            btnCacelar.Name = "btnCacelar";
            btnCacelar.Size = new Size(75, 23);
            btnCacelar.TabIndex = 24;
            btnCacelar.Text = "Cancelar";
            btnCacelar.UseVisualStyleBackColor = true;
            // 
            // lstProductos
            // 
            lstProductos.FormattingEnabled = true;
            lstProductos.ImeMode = ImeMode.On;
            lstProductos.ItemHeight = 15;
            lstProductos.Location = new Point(18, 150);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(237, 64);
            lstProductos.TabIndex = 25;
            lstProductos.Visible = false;
            lstProductos.DoubleClick += lstProductos_DoubleClick;
            // 
            // frmNuevaCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 590);
            Controls.Add(lstProductos);
            Controls.Add(btnCacelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservaciones);
            Controls.Add(label4);
            Controls.Add(txtTotal);
            Controls.Add(txtIva);
            Controls.Add(txtSubsinImpuesto);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(btnEliminarCompra);
            Controls.Add(dataGridView1);
            Controls.Add(btnCargarProducto);
            Controls.Add(txtCodigobarra);
            Controls.Add(txtNumeroComprobante);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(gpbProveedor);
            Controls.Add(labelNumeroComprobante);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmNuevaCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva Compra";
            gpbProveedor.ResumeLayout(false);
            gpbProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label9;
        private Label labelNumeroComprobante;

        private GroupBox gpbProveedor;
        private Button btnBuscar;
        private TextBox txtProveedor;

        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private TextBox txtNumeroComprobante;

        private TextBox txtCodigobarra;
        private Button btnCargarProducto;

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Button btnEliminarCompra;
        private TextBox txtSubsinImpuesto;
        private TextBox txtIva;
        private TextBox txtTotal;
        private TextBox txtObservaciones;
        private Button btnGuardar;
        private Button btnCacelar;
        private ListBox lstProductos;
    }
}