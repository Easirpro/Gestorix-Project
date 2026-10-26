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
            btnAnular = new Button();
            btnBuscar = new Button();
            label1 = new Label();
            label2 = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            dataGridView1 = new DataGridView();
            clnFecha = new DataGridViewTextBoxColumn();
            clnTransaccion = new DataGridViewTextBoxColumn();
            clnCajero = new DataGridViewTextBoxColumn();
            clnTotal = new DataGridViewTextBoxColumn();
            clnAnulada = new DataGridViewTextBoxColumn();
            clnDetalle = new DataGridViewButtonColumn();
            btnActualizar = new Button();
            btnVolver = new Button();
            lblObservaciones = new Label();
            lstObservaciones = new ListBox();
            lblDescripcion = new Label();
            btnAnuladas = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAnular
            // 
            btnAnular.Image = (Image)resources.GetObject("btnAnular.Image");
            btnAnular.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnular.Location = new Point(12, 22);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(84, 36);
            btnAnular.TabIndex = 2;
            btnAnular.Text = "Anular";
            btnAnular.TextAlign = ContentAlignment.MiddleRight;
            btnAnular.UseVisualStyleBackColor = true;
            btnAnular.Click += btnAnular_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(376, 27);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(78, 33);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 36);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(245, 36);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 5;
            label2.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            dtpDesde.CustomFormat = "d/MM/yyyy";
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.Location = new Point(155, 30);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(78, 23);
            dtpDesde.TabIndex = 6;
            // 
            // dtpHasta
            // 
            dtpHasta.CustomFormat = "d/MM/yyyy";
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.Location = new Point(291, 30);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(79, 23);
            dtpHasta.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clnFecha, clnTransaccion, clnCajero, clnTotal, clnAnulada, clnDetalle });
            dataGridView1.Location = new Point(12, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(745, 223);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // clnFecha
            // 
            clnFecha.HeaderText = "Fecha";
            clnFecha.Name = "clnFecha";
            // 
            // clnTransaccion
            // 
            clnTransaccion.HeaderText = "N° Transacción";
            clnTransaccion.Name = "clnTransaccion";
            // 
            // clnCajero
            // 
            clnCajero.HeaderText = "Cajero";
            clnCajero.Name = "clnCajero";
            // 
            // clnTotal
            // 
            clnTotal.HeaderText = "Total";
            clnTotal.Name = "clnTotal";
            // 
            // clnAnulada
            // 
            clnAnulada.HeaderText = "Anulada";
            clnAnulada.Name = "clnAnulada";
            // 
            // clnDetalle
            // 
            clnDetalle.HeaderText = "Ver Detalle";
            clnDetalle.Name = "clnDetalle";
            clnDetalle.Resizable = DataGridViewTriState.True;
            clnDetalle.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // btnActualizar
            // 
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(460, 27);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(98, 33);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextAlign = ContentAlignment.MiddleRight;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(676, 400);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(81, 23);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(13, 311);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(84, 15);
            lblObservaciones.TabIndex = 12;
            lblObservaciones.Text = "Observaciones";
            // 
            // lstObservaciones
            // 
            lstObservaciones.FormattingEnabled = true;
            lstObservaciones.ItemHeight = 15;
            lstObservaciones.Location = new Point(12, 329);
            lstObservaciones.Name = "lstObservaciones";
            lstObservaciones.Size = new Size(562, 94);
            lstObservaciones.TabIndex = 13;
            lstObservaciones.SelectedIndexChanged += lstObservaciones_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(107, 56);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(224, 12);
            lblDescripcion.TabIndex = 14;
            lblDescripcion.Text = "* Seleccione las fechas de busqueda para ver las ventas.\r\n";
            // 
            // btnAnuladas
            // 
            btnAnuladas.AutoSize = true;
            btnAnuladas.Location = new Point(576, 32);
            btnAnuladas.Name = "btnAnuladas";
            btnAnuladas.Size = new Size(154, 19);
            btnAnuladas.TabIndex = 15;
            btnAnuladas.Text = "Ver solo ventas anuladas";
            btnAnuladas.UseVisualStyleBackColor = true;
            btnAnuladas.CheckedChanged += btnAnuladas_CheckedChanged;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 436);
            Controls.Add(btnAnuladas);
            Controls.Add(lblDescripcion);
            Controls.Add(lstObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(btnVolver);
            Controls.Add(btnActualizar);
            Controls.Add(dataGridView1);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBuscar);
            Controls.Add(btnAnular);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmVentas";
            Text = "Ventas";
            Load += frmVentas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAnular;
        private Button btnBuscar;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private DataGridView dataGridView1;
        private Button btnActualizar;
        private Button btnVolver;
        private Label lblObservaciones;
        private ListBox lstObservaciones;
        private DataGridViewTextBoxColumn clnFecha;
        private DataGridViewTextBoxColumn clnTransaccion;
        private DataGridViewTextBoxColumn clnCajero;
        private DataGridViewTextBoxColumn clnTotal;
        private DataGridViewTextBoxColumn clnAnulada;
        private DataGridViewButtonColumn clnDetalle;
        private Label lblDescripcion;
        private CheckBox btnAnuladas;
    }
}