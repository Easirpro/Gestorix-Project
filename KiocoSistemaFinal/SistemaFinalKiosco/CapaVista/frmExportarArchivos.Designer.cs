namespace CapaVista
{
    partial class frmExportarArchivos
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
            components = new System.ComponentModel.Container();
            ttAyuda = new ToolTip(components);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportarArchivos));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            cmbProveedor = new ComboBox();
            cmbRubro = new ComboBox();
            cmbMarca = new ComboBox();
            cmbSucursal = new ComboBox();
            cmbEstado = new ComboBox();
            chkArticulosStock = new CheckBox();
            chkArticulosVencimiento = new CheckBox();
            chkArticuloLote = new CheckBox();
            btnExportar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(112, 18);
            label1.Name = "label1";
            label1.Size = new Size(189, 30);
            label1.TabIndex = 0;
            label1.Text = "Exportar Archivos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 83);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Proveedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 113);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 3;
            label3.Text = "Rubro";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 142);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 5;
            label4.Text = "Marca";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 171);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 8;
            label5.Text = "Sucursal";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(68, 200);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 10;
            label7.Text = "Estado";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(127, 80);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(151, 23);
            cmbProveedor.TabIndex = 2;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // cmbRubro
            // 
            cmbRubro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRubro.FormattingEnabled = true;
            cmbRubro.Location = new Point(127, 110);
            cmbRubro.Name = "cmbRubro";
            cmbRubro.Size = new Size(151, 23);
            cmbRubro.TabIndex = 4;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(127, 139);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(151, 23);
            cmbMarca.TabIndex = 7;
            // 
            // cmbSucursal
            // 
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(127, 168);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(151, 23);
            cmbSucursal.TabIndex = 9;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(127, 197);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(151, 23);
            cmbEstado.TabIndex = 11;
            // 
            // chkArticulosStock
            // 
            chkArticulosStock.AutoSize = true;
            chkArticulosStock.Location = new Point(49, 258);
            chkArticulosStock.Name = "chkArticulosStock";
            chkArticulosStock.Size = new Size(151, 19);
            chkArticulosStock.TabIndex = 12;
            chkArticulosStock.Text = "Solo articulos con stock";
            chkArticulosStock.UseVisualStyleBackColor = true;
            // 
            // chkArticulosVencimiento
            // 
            chkArticulosVencimiento.AutoSize = true;
            chkArticulosVencimiento.Location = new Point(49, 283);
            chkArticulosVencimiento.Name = "chkArticulosVencimiento";
            chkArticulosVencimiento.Size = new Size(189, 19);
            chkArticulosVencimiento.TabIndex = 13;
            chkArticulosVencimiento.Text = "Solo articulos con vencimiento";
            chkArticulosVencimiento.UseVisualStyleBackColor = true;
            // 
            // chkArticuloLote
            // 
            chkArticuloLote.AutoSize = true;
            chkArticuloLote.Location = new Point(49, 308);
            chkArticuloLote.Name = "chkArticuloLote";
            chkArticuloLote.Size = new Size(200, 19);
            chkArticuloLote.TabIndex = 14;
            chkArticuloLote.Text = "Solo articulos con control de lote";
            chkArticuloLote.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.Transparent;
            btnExportar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportar.Image = (Image)resources.GetObject("btnExportar.Image");
            btnExportar.ImageAlign = ContentAlignment.TopCenter;
            btnExportar.Location = new Point(309, 80);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(130, 111);
            btnExportar.TabIndex = 15;
            btnExportar.Text = "Exportar";
            btnExportar.TextAlign = ContentAlignment.BottomCenter;
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(360, 302);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 16;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmExportarArchivos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 359);
            Controls.Add(btnSalir);
            Controls.Add(btnExportar);
            Controls.Add(chkArticuloLote);
            Controls.Add(chkArticulosVencimiento);
            Controls.Add(chkArticulosStock);
            Controls.Add(cmbEstado);
            Controls.Add(cmbSucursal);
            Controls.Add(cmbMarca);
            Controls.Add(cmbRubro);
            Controls.Add(cmbProveedor);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmExportarArchivos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exportar Archivos";
            Load += frmExportarArchivos_Load_1;
            // 
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbProveedor, "Opcional: exportá solo los artículos de este proveedor.");
            ttAyuda.SetToolTip(cmbSucursal, "Opcional: exportá solo los artículos de esta sucursal del proveedor.");
            ttAyuda.SetToolTip(cmbRubro, "Opcional: exportá solo los artículos de este rubro.");
            ttAyuda.SetToolTip(cmbMarca, "Opcional: exportá solo los artículos de esta marca.");
            ttAyuda.SetToolTip(cmbEstado, "Elegí si se exportan los artículos activos, inactivos o todos.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private ComboBox cmbProveedor;
        private ComboBox cmbRubro;
        private ComboBox cmbMarca;
        private ComboBox cmbSucursal;
        private ComboBox cmbEstado;
        private CheckBox chkArticulosStock;
        private CheckBox chkArticulosVencimiento;
        private CheckBox chkArticuloLote;
        private Button btnExportar;
        private Button btnSalir;
    }
}