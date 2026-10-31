namespace CapaVista
{
    partial class frmHistorialCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialCaja));
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnBuscar = new Button();
            dgvSesiones = new DataGridView();
            lblTotales = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).BeginInit();
            SuspendLayout();
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(12, 18);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(60, 14);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(120, 23);
            dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(195, 18);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(240, 14);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(120, 23);
            dtpHasta.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(375, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 28);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvSesiones
            // 
            dgvSesiones.AllowUserToAddRows = false;
            dgvSesiones.AllowUserToDeleteRows = false;
            dgvSesiones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSesiones.BackgroundColor = SystemColors.Window;
            dgvSesiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSesiones.Location = new Point(12, 52);
            dgvSesiones.Name = "dgvSesiones";
            dgvSesiones.ReadOnly = true;
            dgvSesiones.Size = new Size(960, 450);
            dgvSesiones.TabIndex = 5;
            dgvSesiones.DataBindingComplete += dgvSesiones_DataBindingComplete;
            // 
            // lblTotales
            // 
            lblTotales.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotales.AutoSize = true;
            lblTotales.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotales.Location = new Point(12, 515);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(0, 15);
            lblTotales.TabIndex = 6;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(852, 510);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 30);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmHistorialCaja
            // 
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new Size(984, 552);
            Controls.Add(lblDesde);
            Controls.Add(dtpDesde);
            Controls.Add(lblHasta);
            Controls.Add(dtpHasta);
            Controls.Add(btnBuscar);
            Controls.Add(dgvSesiones);
            Controls.Add(lblTotales);
            Controls.Add(btnSalir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmHistorialCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de cajas";
            Load += frmHistorialCaja_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvSesiones;
        private System.Windows.Forms.Label lblTotales;
        private System.Windows.Forms.Button btnSalir;
    }
}
