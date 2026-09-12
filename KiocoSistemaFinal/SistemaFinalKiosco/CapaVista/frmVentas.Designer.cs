namespace CapaVista
{
    partial class frmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentas));
            btnVerDetalle = new Button();
            btnAnular = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            gpbTotales = new GroupBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnActualizar = new Button();
            btnVolver = new Button();
            Column1 = new DataGridViewTextBoxColumn();
            Column16 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            gpbTotales.SuspendLayout();
            SuspendLayout();
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Image = (Image)resources.GetObject("btnVerDetalle.Image");
            btnVerDetalle.ImageAlign = ContentAlignment.MiddleLeft;
            btnVerDetalle.Location = new Point(12, 15);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(99, 33);
            btnVerDetalle.TabIndex = 1;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.TextAlign = ContentAlignment.MiddleRight;
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnAnular
            // 
            btnAnular.Image = (Image)resources.GetObject("btnAnular.Image");
            btnAnular.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnular.Location = new Point(117, 15);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(83, 33);
            btnAnular.TabIndex = 2;
            btnAnular.Text = "Anular";
            btnAnular.TextAlign = ContentAlignment.MiddleRight;
            btnAnular.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(491, 15);
            button4.Name = "button4";
            button4.Size = new Size(45, 33);
            button4.TabIndex = 3;
            button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(226, 25);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(363, 25);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 5;
            label2.Text = "Hasta:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "d/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(270, 20);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(78, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "d/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(401, 19);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(79, 23);
            dateTimePicker2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column16, Column15, Column12, Column13, Column14, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11 });
            dataGridView1.Location = new Point(12, 54);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(832, 275);
            dataGridView1.TabIndex = 8;
            // 
            // gpbTotales
            // 
            gpbTotales.Controls.Add(textBox7);
            gpbTotales.Controls.Add(textBox6);
            gpbTotales.Controls.Add(textBox5);
            gpbTotales.Controls.Add(textBox4);
            gpbTotales.Controls.Add(textBox3);
            gpbTotales.Controls.Add(textBox2);
            gpbTotales.Controls.Add(textBox1);
            gpbTotales.Controls.Add(label9);
            gpbTotales.Controls.Add(label8);
            gpbTotales.Controls.Add(label7);
            gpbTotales.Controls.Add(label6);
            gpbTotales.Controls.Add(label5);
            gpbTotales.Controls.Add(label4);
            gpbTotales.Controls.Add(label3);
            gpbTotales.Location = new Point(11, 349);
            gpbTotales.Name = "gpbTotales";
            gpbTotales.Size = new Size(833, 131);
            gpbTotales.TabIndex = 9;
            gpbTotales.TabStop = false;
            gpbTotales.Text = "Totales";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(619, 27);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 13;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(397, 94);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 12;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(397, 61);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(397, 27);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(160, 94);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(160, 61);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(160, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(518, 30);
            label9.Name = "label9";
            label9.Size = new Size(95, 15);
            label9.TabIndex = 6;
            label9.Text = "Tarjeta de Debito";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(294, 95);
            label8.Name = "label8";
            label8.Size = new Size(97, 15);
            label8.TabIndex = 5;
            label8.Text = "Cuenta Corriente";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(292, 66);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 4;
            label7.Text = "Tarjeta de Credito";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(342, 30);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 3;
            label6.Text = "Efectivo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(120, 97);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 2;
            label5.Text = "Total";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 66);
            label4.Name = "label4";
            label4.Size = new Size(121, 15);
            label4.TabIndex = 1;
            label4.Text = "Descuentos/Recargos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 30);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 0;
            label3.Text = "Subtotal";
            // 
            // btnActualizar
            // 
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.Location = new Point(542, 15);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(49, 33);
            btnActualizar.TabIndex = 10;
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(719, 486);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(81, 23);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Fecha";
            Column1.Name = "Column1";
            // 
            // Column16
            // 
            Column16.HeaderText = "Anulada";
            Column16.Name = "Column16";
            // 
            // Column15
            // 
            Column15.HeaderText = "Tranferencia";
            Column15.Name = "Column15";
            // 
            // Column12
            // 
            Column12.HeaderText = "Debito";
            Column12.Name = "Column12";
            // 
            // Column13
            // 
            Column13.HeaderText = "Observaciones";
            Column13.Name = "Column13";
            // 
            // Column14
            // 
            Column14.HeaderText = "Completa";
            Column14.Name = "Column14";
            // 
            // Column2
            // 
            Column2.HeaderText = "Nro. Transacción";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Nro. Caja";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Cajero";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Nro. Comprobante";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Subtotal";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "Descuento/Recargo";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "Total";
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "Efectivo";
            Column9.Name = "Column9";
            // 
            // Column10
            // 
            Column10.HeaderText = "Tarjeta de Credito";
            Column10.Name = "Column10";
            // 
            // Column11
            // 
            Column11.HeaderText = "Cta. Cte";
            Column11.Name = "Column11";
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 538);
            Controls.Add(btnVolver);
            Controls.Add(btnActualizar);
            Controls.Add(gpbTotales);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(btnAnular);
            Controls.Add(btnVerDetalle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmVentas";
            Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            gpbTotales.ResumeLayout(false);
            gpbTotales.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnVerDetalle;
        private Button btnAnular;
        private Button button4;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DataGridView dataGridView1;
        private GroupBox gpbTotales;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox7;
        private Button btnActualizar;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private Button btnVolver;
    }
}