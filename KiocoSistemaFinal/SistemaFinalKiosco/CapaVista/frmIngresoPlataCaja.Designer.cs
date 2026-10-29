namespace CapaVista
{
    partial class frmIngresoPlataCaja
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
            lblTitulo = new System.Windows.Forms.Label();
            lblConcepto = new System.Windows.Forms.Label();
            cmbConcepto = new System.Windows.Forms.ComboBox();
            lblMedioPago = new System.Windows.Forms.Label();
            cmbMedioPago = new System.Windows.Forms.ComboBox();
            lblImporte = new System.Windows.Forms.Label();
            nudImporte = new System.Windows.Forms.NumericUpDown();
            lblDisponible = new System.Windows.Forms.Label();
            lblEmpleado = new System.Windows.Forms.Label();
            cmbEmpleado = new System.Windows.Forms.ComboBox();
            lblObservacion = new System.Windows.Forms.Label();
            txtObservacion = new System.Windows.Forms.TextBox();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)nudImporte).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new System.Drawing.Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo movimiento";
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblConcepto
            // 
            lblConcepto.Location = new System.Drawing.Point(15, 55);
            lblConcepto.Name = "lblConcepto";
            lblConcepto.TabIndex = 1;
            lblConcepto.Text = "Concepto:";
            lblConcepto.AutoSize = true;
            // 
            // cmbConcepto
            // 
            cmbConcepto.Location = new System.Drawing.Point(130, 51);
            cmbConcepto.Name = "cmbConcepto";
            cmbConcepto.Size = new System.Drawing.Size(250, 23);
            cmbConcepto.TabIndex = 2;
            cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbConcepto.FormattingEnabled = true;
            cmbConcepto.SelectedIndexChanged += cmbConcepto_SelectedIndexChanged;
            // 
            // lblMedioPago
            // 
            lblMedioPago.Location = new System.Drawing.Point(15, 90);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.TabIndex = 3;
            lblMedioPago.Text = "Medio de pago:";
            lblMedioPago.AutoSize = true;
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.Location = new System.Drawing.Point(130, 86);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new System.Drawing.Size(250, 23);
            cmbMedioPago.TabIndex = 4;
            cmbMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.SelectedIndexChanged += cmbMedioPago_SelectedIndexChanged;
            // 
            // lblImporte
            // 
            lblImporte.Location = new System.Drawing.Point(15, 125);
            lblImporte.Name = "lblImporte";
            lblImporte.TabIndex = 5;
            lblImporte.Text = "Importe:";
            lblImporte.AutoSize = true;
            // 
            // nudImporte
            // 
            nudImporte.Location = new System.Drawing.Point(130, 121);
            nudImporte.Name = "nudImporte";
            nudImporte.Size = new System.Drawing.Size(140, 23);
            nudImporte.TabIndex = 6;
            nudImporte.DecimalPlaces = 2;
            nudImporte.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudImporte.ThousandsSeparator = true;
            nudImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDisponible
            // 
            lblDisponible.Location = new System.Drawing.Point(280, 125);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.TabIndex = 7;
            lblDisponible.Text = "";
            lblDisponible.AutoSize = true;
            lblDisponible.ForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // lblEmpleado
            // 
            lblEmpleado.Location = new System.Drawing.Point(15, 160);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.TabIndex = 8;
            lblEmpleado.Text = "Empleado:";
            lblEmpleado.AutoSize = true;
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.Location = new System.Drawing.Point(130, 156);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new System.Drawing.Size(250, 23);
            cmbEmpleado.TabIndex = 9;
            cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEmpleado.FormattingEnabled = true;
            // 
            // lblObservacion
            // 
            lblObservacion.Location = new System.Drawing.Point(15, 195);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.TabIndex = 10;
            lblObservacion.Text = "Observación:";
            lblObservacion.AutoSize = true;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new System.Drawing.Point(130, 192);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new System.Drawing.Size(250, 60);
            txtObservacion.TabIndex = 11;
            txtObservacion.Multiline = true;
            txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtObservacion.MaxLength = 255;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new System.Drawing.Point(160, 270);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(105, 32);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(275, 270);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(105, 32);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmIngresoPlataCaja
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new System.Drawing.Size(400, 316);
            Controls.Add(lblTitulo);
            Controls.Add(lblConcepto);
            Controls.Add(cmbConcepto);
            Controls.Add(lblMedioPago);
            Controls.Add(cmbMedioPago);
            Controls.Add(lblImporte);
            Controls.Add(nudImporte);
            Controls.Add(lblDisponible);
            Controls.Add(lblEmpleado);
            Controls.Add(cmbEmpleado);
            Controls.Add(lblObservacion);
            Controls.Add(txtObservacion);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmIngresoPlataCaja";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Movimiento de caja";
            Load += frmIngresoPlataCaja_Load;
            ((System.ComponentModel.ISupportInitialize)nudImporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label lblMedioPago;
        private System.Windows.Forms.ComboBox cmbMedioPago;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.NumericUpDown nudImporte;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
