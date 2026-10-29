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
            lblDesde = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            btnBuscar = new System.Windows.Forms.Button();
            dgvSesiones = new System.Windows.Forms.DataGridView();
            lblTotales = new System.Windows.Forms.Label();
            btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).BeginInit();
            SuspendLayout();
            // 
            // lblDesde
            // 
            lblDesde.Location = new System.Drawing.Point(12, 18);
            lblDesde.Name = "lblDesde";
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            lblDesde.AutoSize = true;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new System.Drawing.Point(60, 14);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new System.Drawing.Size(120, 23);
            dtpDesde.TabIndex = 1;
            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblHasta
            // 
            lblHasta.Location = new System.Drawing.Point(195, 18);
            lblHasta.Name = "lblHasta";
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            lblHasta.AutoSize = true;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new System.Drawing.Point(240, 14);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new System.Drawing.Size(120, 23);
            dtpHasta.TabIndex = 3;
            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new System.Drawing.Point(375, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(100, 28);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvSesiones
            // 
            dgvSesiones.Location = new System.Drawing.Point(12, 52);
            dgvSesiones.Name = "dgvSesiones";
            dgvSesiones.Size = new System.Drawing.Size(960, 450);
            dgvSesiones.TabIndex = 5;
            dgvSesiones.AllowUserToAddRows = false;
            dgvSesiones.AllowUserToDeleteRows = false;
            dgvSesiones.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvSesiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSesiones.ReadOnly = true;
            dgvSesiones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvSesiones.DataBindingComplete += dgvSesiones_DataBindingComplete;
            // 
            // lblTotales
            // 
            lblTotales.Location = new System.Drawing.Point(12, 515);
            lblTotales.Name = "lblTotales";
            lblTotales.TabIndex = 6;
            lblTotales.Text = "";
            lblTotales.AutoSize = true;
            lblTotales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotales.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            // 
            // btnSalir
            // 
            btnSalir.Location = new System.Drawing.Point(852, 510);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(120, 30);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmHistorialCaja
            // 
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new System.Drawing.Size(984, 552);
            Controls.Add(lblDesde);
            Controls.Add(dtpDesde);
            Controls.Add(lblHasta);
            Controls.Add(dtpHasta);
            Controls.Add(btnBuscar);
            Controls.Add(dgvSesiones);
            Controls.Add(lblTotales);
            Controls.Add(btnSalir);
            Name = "frmHistorialCaja";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
