namespace CapaVista
{
    partial class frmListadoReposicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoReposicion));
            gpbBuscarReposicion = new GroupBox();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnBuscar = new Button();
            btnExportarStock = new Button();
            btnSalir = new Button();
            dgvStock = new DataGridView();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnDescripcion = new DataGridViewTextBoxColumn();
            clnRubro = new DataGridViewTextBoxColumn();
            clnStockActual = new DataGridViewTextBoxColumn();
            clnStockMinimo = new DataGridViewTextBoxColumn();
            clnStockMaximo = new DataGridViewTextBoxColumn();
            clnProveedor = new DataGridViewTextBoxColumn();
            gpbBuscarReposicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // gpbBuscarReposicion
            // 
            gpbBuscarReposicion.Controls.Add(textBox2);
            gpbBuscarReposicion.Controls.Add(comboBox2);
            gpbBuscarReposicion.Controls.Add(comboBox1);
            gpbBuscarReposicion.Controls.Add(textBox1);
            gpbBuscarReposicion.Controls.Add(label4);
            gpbBuscarReposicion.Controls.Add(label3);
            gpbBuscarReposicion.Controls.Add(label2);
            gpbBuscarReposicion.Controls.Add(label1);
            gpbBuscarReposicion.Location = new Point(12, 24);
            gpbBuscarReposicion.Name = "gpbBuscarReposicion";
            gpbBuscarReposicion.Size = new Size(462, 162);
            gpbBuscarReposicion.TabIndex = 0;
            gpbBuscarReposicion.TabStop = false;
            gpbBuscarReposicion.Text = "Buscar por Opciones";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(148, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(202, 23);
            textBox2.TabIndex = 7;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(148, 111);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(161, 23);
            comboBox2.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(148, 56);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(161, 23);
            comboBox1.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(148, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 23);
            textBox1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 114);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 88);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 2;
            label3.Text = "Proveedores";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 59);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Rubro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 31);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 0;
            label1.Text = "Articulo / Descripción";
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(480, 34);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(99, 64);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnExportarStock
            // 
            btnExportarStock.Image = (Image)resources.GetObject("btnExportarStock.Image");
            btnExportarStock.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportarStock.Location = new Point(595, 34);
            btnExportarStock.Name = "btnExportarStock";
            btnExportarStock.Size = new Size(113, 64);
            btnExportarStock.TabIndex = 7;
            btnExportarStock.Text = "Exportar Lista";
            btnExportarStock.TextAlign = ContentAlignment.MiddleRight;
            btnExportarStock.UseVisualStyleBackColor = true;
            btnExportarStock.Click += btnExportarStock_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(683, 415);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // dgvStock
            // 
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnDescripcion, clnRubro, clnStockActual, clnStockMinimo, clnStockMaximo, clnProveedor });
            dgvStock.Location = new Point(12, 208);
            dgvStock.Name = "dgvStock";
            dgvStock.Size = new Size(746, 150);
            dgvStock.TabIndex = 9;
            // 
            // clnCodigo
            // 
            clnCodigo.HeaderText = "Codigo";
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
            // clnStockActual
            // 
            clnStockActual.HeaderText = "Stock Actual";
            clnStockActual.Name = "clnStockActual";
            // 
            // clnStockMinimo
            // 
            clnStockMinimo.HeaderText = "Stock Minimo";
            clnStockMinimo.Name = "clnStockMinimo";
            // 
            // clnStockMaximo
            // 
            clnStockMaximo.HeaderText = "Stock Maximo";
            clnStockMaximo.Name = "clnStockMaximo";
            // 
            // clnProveedor
            // 
            clnProveedor.HeaderText = "Proveedor";
            clnProveedor.Name = "clnProveedor";
            // 
            // frmListadoReposicion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStock);
            Controls.Add(btnSalir);
            Controls.Add(btnExportarStock);
            Controls.Add(btnBuscar);
            Controls.Add(gpbBuscarReposicion);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmListadoReposicion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado de Reposicion";
            gpbBuscarReposicion.ResumeLayout(false);
            gpbBuscarReposicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbBuscarReposicion;
        private Label label1;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnBuscar;
        private Button btnExportarStock;
        private Button btnSalir;
        private DataGridView dgvStock;
        private DataGridViewTextBoxColumn clnCodigo;
        private DataGridViewTextBoxColumn clnDescripcion;
        private DataGridViewTextBoxColumn clnRubro;
        private DataGridViewTextBoxColumn clnStockActual;
        private DataGridViewTextBoxColumn clnStockMinimo;
        private DataGridViewTextBoxColumn clnStockMaximo;
        private DataGridViewTextBoxColumn clnProveedor;
    }
}