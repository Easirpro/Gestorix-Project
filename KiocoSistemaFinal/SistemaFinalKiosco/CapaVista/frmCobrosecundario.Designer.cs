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
            panel1 = new Panel();
            lblTotalMonto = new Label();
            label5 = new Label();
            lblDescuentoMonto = new Label();
            lblSubtotalMonto = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCobrar = new Button();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
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
            btnConfig = new MenuStrip();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(lblTotalMonto);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblDescuentoMonto);
            panel1.Controls.Add(lblSubtotalMonto);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(543, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 140);
            panel1.TabIndex = 1;
            // 
            // lblTotalMonto
            // 
            lblTotalMonto.AutoSize = true;
            lblTotalMonto.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalMonto.ForeColor = Color.LawnGreen;
            lblTotalMonto.Location = new Point(121, 88);
            lblTotalMonto.Name = "lblTotalMonto";
            lblTotalMonto.Size = new Size(105, 45);
            lblTotalMonto.TabIndex = 5;
            lblTotalMonto.Text = "label6";
            lblTotalMonto.TextAlign = ContentAlignment.BottomRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(3, 96);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 4;
            label5.Text = "Total";
            // 
            // lblDescuentoMonto
            // 
            lblDescuentoMonto.AutoSize = true;
            lblDescuentoMonto.ForeColor = SystemColors.ScrollBar;
            lblDescuentoMonto.Location = new Point(188, 40);
            lblDescuentoMonto.Name = "lblDescuentoMonto";
            lblDescuentoMonto.Size = new Size(38, 15);
            lblDescuentoMonto.TabIndex = 3;
            lblDescuentoMonto.Text = "label4";
            lblDescuentoMonto.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtotalMonto
            // 
            lblSubtotalMonto.AutoSize = true;
            lblSubtotalMonto.ForeColor = Color.LawnGreen;
            lblSubtotalMonto.Location = new Point(188, 18);
            lblSubtotalMonto.Name = "lblSubtotalMonto";
            lblSubtotalMonto.Size = new Size(38, 15);
            lblSubtotalMonto.TabIndex = 2;
            lblSubtotalMonto.Text = "label3";
            lblSubtotalMonto.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ScrollBar;
            label2.Location = new Point(0, 40);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 1;
            label2.Text = "Descuento/Recargo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(0, 12);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 0;
            label1.Text = "Subtotal";
            // 
            // btnCobrar
            // 
            btnCobrar.BackColor = Color.ForestGreen;
            btnCobrar.FlatStyle = FlatStyle.Flat;
            btnCobrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCobrar.ForeColor = Color.White;
            btnCobrar.Location = new Point(543, 176);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(229, 45);
            btnCobrar.TabIndex = 2;
            btnCobrar.Text = "F2-Cobrar";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.ForestGreen;
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 40);
            label3.Name = "label3";
            label3.Size = new Size(130, 15);
            label3.TabIndex = 3;
            label3.Text = "Código de barras           ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.ForestGreen;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(164, 40);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 4;
            label4.Text = "Cantidad    ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 55);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(130, 23);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(164, 54);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(67, 23);
            textBox2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(525, 213);
            dataGridView1.TabIndex = 7;
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
            // btnConfig
            // 
            btnConfig.Location = new Point(0, 0);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(800, 24);
            btnConfig.TabIndex = 9;
            // 
            // frmCobroSecundario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCobrar);
            Controls.Add(panel1);
            Controls.Add(btnConfig);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = btnConfig;
            Name = "frmCobroSecundario";
            Text = "Segundo Cobro";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label lblDescuentoMonto;
        private Label lblSubtotalMonto;
        private Label lblTotalMonto;
        private Button btnCobrar;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private DataGridView dataGridView1;
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
        private MenuStrip btnConfig;


    }
}