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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleVenta));
            label1 = new Label();
            txtNumtransaccion = new TextBox();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            label4 = new Label();
            textBox2 = new TextBox();
            chkVentaAnulada = new CheckBox();
            btnGuardarCambios = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 25);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 0;
            label1.Text = "Nro. Transacción:";
            // 
            // txtNumtransaccion
            // 
            txtNumtransaccion.Location = new Point(24, 41);
            txtNumtransaccion.Name = "txtNumtransaccion";
            txtNumtransaccion.Size = new Size(137, 23);
            txtNumtransaccion.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 85);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 4;
            label3.Text = "Artículos";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridView1.Location = new Point(21, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(638, 148);
            dataGridView1.TabIndex = 5;
            // 
            // Column1
            // 
            Column1.HeaderText = "#";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Código";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Descripción";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Cantidad";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Precio Unitario";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Importe";
            Column6.Name = "Column6";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 265);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 6;
            label4.Text = "Observaciones:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(23, 282);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(636, 84);
            textBox2.TabIndex = 7;
            // 
            // chkVentaAnulada
            // 
            chkVentaAnulada.AutoSize = true;
            chkVentaAnulada.Location = new Point(557, 43);
            chkVentaAnulada.Name = "chkVentaAnulada";
            chkVentaAnulada.Size = new Size(102, 19);
            chkVentaAnulada.TabIndex = 8;
            chkVentaAnulada.Text = "Venta Anulada";
            chkVentaAnulada.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Location = new Point(431, 386);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(111, 23);
            btnGuardarCambios.TabIndex = 9;
            btnGuardarCambios.Text = "Guardar Cambios";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(548, 386);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(111, 23);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 447);
            Controls.Add(btnCerrar);
            Controls.Add(btnGuardarCambios);
            Controls.Add(chkVentaAnulada);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(txtNumtransaccion);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmDetalleVenta";
            Text = "Detalle de Venta";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNumtransaccion;
        private Label label3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Label label4;
        private TextBox textBox2;
        private CheckBox chkVentaAnulada;
        private Button btnGuardarCambios;
        private Button btnCerrar;
    }
}