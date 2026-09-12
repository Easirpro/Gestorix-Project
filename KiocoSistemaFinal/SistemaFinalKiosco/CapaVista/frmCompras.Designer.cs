namespace CapaVista
{
    partial class frmCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompras));
            btnNuevacompra = new Button();
            btnDetalle = new Button();
            btnAnular = new Button();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnBuscar = new Button();
            button5 = new Button();
            dataGridView1 = new DataGridView();
            columFecha = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnNuevacompra
            // 
            btnNuevacompra.Image = (Image)resources.GetObject("btnNuevacompra.Image");
            btnNuevacompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevacompra.Location = new Point(4, 7);
            btnNuevacompra.Name = "btnNuevacompra";
            btnNuevacompra.Size = new Size(115, 33);
            btnNuevacompra.TabIndex = 0;
            btnNuevacompra.Text = "Nueva Compra";
            btnNuevacompra.TextAlign = ContentAlignment.MiddleRight;
            btnNuevacompra.UseVisualStyleBackColor = true;
            btnNuevacompra.Click += btnNuevacompra_Click;
            // 
            // btnDetalle
            // 
            btnDetalle.Image = (Image)resources.GetObject("btnDetalle.Image");
            btnDetalle.ImageAlign = ContentAlignment.MiddleLeft;
            btnDetalle.Location = new Point(132, 7);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(90, 33);
            btnDetalle.TabIndex = 1;
            btnDetalle.Text = "Ver detalle";
            btnDetalle.TextAlign = ContentAlignment.MiddleRight;
            btnDetalle.UseVisualStyleBackColor = true;
            btnDetalle.Click += btnDetalle_Click;
            // 
            // btnAnular
            // 
            btnAnular.Image = (Image)resources.GetObject("btnAnular.Image");
            btnAnular.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnular.Location = new Point(235, 7);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(78, 33);
            btnAnular.TabIndex = 2;
            btnAnular.Text = "Anular";
            btnAnular.TextAlign = ContentAlignment.MiddleRight;
            btnAnular.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "d/M/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(378, 10);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(98, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "d/M/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(525, 10);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(98, 23);
            dateTimePicker2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(333, 16);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Desde";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(482, 16);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 6;
            label2.Text = "Hasta";
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(629, 7);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 33);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(710, 7);
            button5.Name = "button5";
            button5.Size = new Size(97, 33);
            button5.TabIndex = 8;
            button5.Text = "Actualizar";
            button5.TextAlign = ContentAlignment.MiddleRight;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { columFecha });
            dataGridView1.Location = new Point(4, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(803, 365);
            dataGridView1.TabIndex = 9;
            // 
            // columFecha
            // 
            columFecha.HeaderText = "Fecha";
            columFecha.Name = "columFecha";
            // 
            // frmCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button5);
            Controls.Add(btnBuscar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnAnular);
            Controls.Add(btnDetalle);
            Controls.Add(btnNuevacompra);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCompras";
            RightToLeft = RightToLeft.No;
            Text = "Compras";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevacompra;
        private Button btnDetalle;
        private Button btnAnular;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private Button btnBuscar;
        private Button button5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn columFecha;
    }
}