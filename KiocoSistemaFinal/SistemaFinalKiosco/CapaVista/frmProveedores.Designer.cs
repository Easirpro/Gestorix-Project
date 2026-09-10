namespace CapaVista
{
    partial class frmProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedores));
            btnNuevoProveedor = new Button();
            btnModificar = new Button();
            btnDiscontinuar = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            chkOcultarProveedores = new CheckBox();
            dtgProveedores = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            txtObsevaciones = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgProveedores).BeginInit();
            SuspendLayout();
            // 
            // btnNuevoProveedor
            // 
            btnNuevoProveedor.Image = (Image)resources.GetObject("btnNuevoProveedor.Image");
            btnNuevoProveedor.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevoProveedor.Location = new Point(25, 6);
            btnNuevoProveedor.Name = "btnNuevoProveedor";
            btnNuevoProveedor.Size = new Size(137, 36);
            btnNuevoProveedor.TabIndex = 0;
            btnNuevoProveedor.Text = "Nuevo Proveedor";
            btnNuevoProveedor.TextAlign = ContentAlignment.MiddleRight;
            btnNuevoProveedor.UseVisualStyleBackColor = true;
            btnNuevoProveedor.Click += btnNuevoProveedor_Click;
            // 
            // btnModificar
            // 
            btnModificar.Image = (Image)resources.GetObject("btnModificar.Image");
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(168, 6);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(90, 36);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnDiscontinuar
            // 
            btnDiscontinuar.Location = new Point(278, 6);
            btnDiscontinuar.Name = "btnDiscontinuar";
            btnDiscontinuar.Size = new Size(84, 36);
            btnDiscontinuar.TabIndex = 2;
            btnDiscontinuar.Text = "Discontinuar";
            btnDiscontinuar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(495, 6);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(82, 36);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(379, 14);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 23);
            txtBuscar.TabIndex = 5;
            // 
            // chkOcultarProveedores
            // 
            chkOcultarProveedores.AutoSize = true;
            chkOcultarProveedores.Location = new Point(590, 17);
            chkOcultarProveedores.Name = "chkOcultarProveedores";
            chkOcultarProveedores.Size = new Size(194, 19);
            chkOcultarProveedores.TabIndex = 6;
            chkOcultarProveedores.Text = "Ocultar Proveedores Eliminados";
            chkOcultarProveedores.UseVisualStyleBackColor = true;
            // 
            // dtgProveedores
            // 
            dtgProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProveedores.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8 });
            dtgProveedores.Location = new Point(23, 55);
            dtgProveedores.Name = "dtgProveedores";
            dtgProveedores.Size = new Size(823, 275);
            dtgProveedores.TabIndex = 7;
            // 
            // Column1
            // 
            Column1.FillWeight = 70F;
            Column1.HeaderText = "Nro. Proveedor";
            Column1.Name = "Column1";
            Column1.Width = 60;
            // 
            // Column2
            // 
            Column2.FillWeight = 150F;
            Column2.HeaderText = "Razón Social";
            Column2.Name = "Column2";
            Column2.Width = 129;
            // 
            // Column3
            // 
            Column3.HeaderText = "CUIT";
            Column3.Name = "Column3";
            Column3.Width = 85;
            // 
            // Column4
            // 
            Column4.FillWeight = 110F;
            Column4.HeaderText = "Condición IVA";
            Column4.Name = "Column4";
            Column4.Width = 95;
            // 
            // Column5
            // 
            Column5.HeaderText = "Telefono";
            Column5.Name = "Column5";
            Column5.Width = 85;
            // 
            // Column6
            // 
            Column6.FillWeight = 150F;
            Column6.HeaderText = "E-mail";
            Column6.Name = "Column6";
            Column6.Width = 129;
            // 
            // Column7
            // 
            Column7.FillWeight = 150F;
            Column7.HeaderText = "Direción";
            Column7.Name = "Column7";
            Column7.Width = 128;
            // 
            // Column8
            // 
            Column8.FillWeight = 80F;
            Column8.HeaderText = "Estado";
            Column8.Name = "Column8";
            Column8.Width = 69;
            // 
            // txtObsevaciones
            // 
            txtObsevaciones.Location = new Point(23, 371);
            txtObsevaciones.Multiline = true;
            txtObsevaciones.Name = "txtObsevaciones";
            txtObsevaciones.Size = new Size(478, 95);
            txtObsevaciones.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 353);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 9;
            label1.Text = "Observaciones:";
            // 
            // frmProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 517);
            Controls.Add(label1);
            Controls.Add(txtObsevaciones);
            Controls.Add(dtgProveedores);
            Controls.Add(chkOcultarProveedores);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnDiscontinuar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevoProveedor);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmProveedores";
            Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)dtgProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevoProveedor;
        private Button btnModificar;
        private Button btnDiscontinuar;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private CheckBox chkOcultarProveedores;
        private DataGridView dtgProveedores;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private TextBox txtObsevaciones;
        private Label label1;
    }
}