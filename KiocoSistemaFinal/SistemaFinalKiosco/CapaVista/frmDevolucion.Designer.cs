namespace CapaVista
{
    partial class frmDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevolucion));
            btnNuevaDevolucion = new Button();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            btnBuscar = new Button();
            dataGridView1 = new DataGridView();
            btnVolver = new Button();
            btnGuardar = new Button();
            btnActualizar = new Button();
            Column1 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnNuevaDevolucion
            // 
            btnNuevaDevolucion.Image = (Image)resources.GetObject("btnNuevaDevolucion.Image");
            btnNuevaDevolucion.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevaDevolucion.Location = new Point(24, 12);
            btnNuevaDevolucion.Name = "btnNuevaDevolucion";
            btnNuevaDevolucion.Size = new Size(143, 32);
            btnNuevaDevolucion.TabIndex = 0;
            btnNuevaDevolucion.Text = "Nueva Devolución";
            btnNuevaDevolucion.TextAlign = ContentAlignment.MiddleRight;
            btnNuevaDevolucion.UseVisualStyleBackColor = true;
            btnNuevaDevolucion.Click += btnNuevaDevolucion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 21);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 21);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 2;
            label2.Text = "Hasta:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "d/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(243, 15);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(84, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "d/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(379, 15);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(85, 23);
            dateTimePicker2.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(472, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(45, 32);
            btnBuscar.TabIndex = 5;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column10, Column2, Column3, Column4, Column5, Column6, Column8, Column9 });
            dataGridView1.Location = new Point(12, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(764, 296);
            dataGridView1.TabIndex = 6;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(695, 384);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(614, 384);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.Location = new Point(523, 12);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(45, 32);
            btnActualizar.TabIndex = 9;
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Fecha";
            Column1.Name = "Column1";
            // 
            // Column10
            // 
            Column10.HeaderText = "Estado";
            Column10.Name = "Column10";
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
            Column5.HeaderText = "Tipo de Comprobante";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Nro. Comprobante";
            Column6.Name = "Column6";
            // 
            // Column8
            // 
            Column8.HeaderText = "Total";
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "Producto/Servicio";
            Column9.Name = "Column9";
            // 
            // frmDevolucion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 416);
            Controls.Add(btnActualizar);
            Controls.Add(btnGuardar);
            Controls.Add(btnVolver);
            Controls.Add(dataGridView1);
            Controls.Add(btnBuscar);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnNuevaDevolucion);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmDevolucion";
            Text = "Devolución";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevaDevolucion;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button btnBuscar;
        private DataGridView dataGridView1;
        private Button btnVolver;
        private Button btnGuardar;
        private Button btnActualizar;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
    }
}