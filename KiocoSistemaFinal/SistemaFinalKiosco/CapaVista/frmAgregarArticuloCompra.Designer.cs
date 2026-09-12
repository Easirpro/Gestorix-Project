namespace CapaVista
{
    partial class frmAgregarArticuloCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarArticuloCompra));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtArticulo = new TextBox();
            txtCantidad = new TextBox();
            txtPrecioSinIva = new TextBox();
            txtPrecioConIva = new TextBox();
            cmbIva = new ComboBox();
            chkCompraSinIva = new CheckBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 32);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Articulo: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 61);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Cantidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 90);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 2;
            label3.Text = "Precio sin IVA: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 119);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 3;
            label4.Text = "IVA: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(-1, 148);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 4;
            label5.Text = "Precio con IVA: $";
            // 
            // txtArticulo
            // 
            txtArticulo.Location = new Point(100, 24);
            txtArticulo.Name = "txtArticulo";
            txtArticulo.Size = new Size(337, 23);
            txtArticulo.TabIndex = 5;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(100, 53);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(63, 23);
            txtCantidad.TabIndex = 6;
            // 
            // txtPrecioSinIva
            // 
            txtPrecioSinIva.Location = new Point(100, 82);
            txtPrecioSinIva.Name = "txtPrecioSinIva";
            txtPrecioSinIva.Size = new Size(100, 23);
            txtPrecioSinIva.TabIndex = 7;
            // 
            // txtPrecioConIva
            // 
            txtPrecioConIva.Location = new Point(100, 140);
            txtPrecioConIva.Name = "txtPrecioConIva";
            txtPrecioConIva.Size = new Size(100, 23);
            txtPrecioConIva.TabIndex = 8;
            // 
            // cmbIva
            // 
            cmbIva.FormattingEnabled = true;
            cmbIva.Location = new Point(100, 111);
            cmbIva.Name = "cmbIva";
            cmbIva.Size = new Size(63, 23);
            cmbIva.TabIndex = 9;
            // 
            // chkCompraSinIva
            // 
            chkCompraSinIva.AutoSize = true;
            chkCompraSinIva.Location = new Point(169, 115);
            chkCompraSinIva.Name = "chkCompraSinIva";
            chkCompraSinIva.Size = new Size(107, 19);
            chkCompraSinIva.TabIndex = 10;
            chkCompraSinIva.Text = "Compra sin IVA";
            chkCompraSinIva.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(281, 182);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(362, 182);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmAgregarArticuloCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 231);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(chkCompraSinIva);
            Controls.Add(cmbIva);
            Controls.Add(txtPrecioConIva);
            Controls.Add(txtPrecioSinIva);
            Controls.Add(txtCantidad);
            Controls.Add(txtArticulo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmAgregarArticuloCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Articulo a la Compra";
            Load += frmAgregarArticuloCompra_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtArticulo;
        private TextBox txtCantidad;
        private TextBox txtPrecioSinIva;
        private TextBox txtPrecioConIva;
        private ComboBox cmbIva;
        private CheckBox chkCompraSinIva;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}