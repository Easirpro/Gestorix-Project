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
            components = new System.ComponentModel.Container();
            ttAyuda = new ToolTip(components);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoPlataCaja));
            lblTitulo = new Label();
            lblConcepto = new Label();
            cmbConcepto = new ComboBox();
            lblMedioPago = new Label();
            cmbMedioPago = new ComboBox();
            lblImporte = new Label();
            nudImporte = new NumericUpDown();
            lblDisponible = new Label();
            lblEmpleado = new Label();
            cmbEmpleado = new ComboBox();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudImporte).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(144, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo movimiento";
            // 
            // lblConcepto
            // 
            lblConcepto.AutoSize = true;
            lblConcepto.Location = new Point(15, 55);
            lblConcepto.Name = "lblConcepto";
            lblConcepto.Size = new Size(62, 15);
            lblConcepto.TabIndex = 1;
            lblConcepto.Text = "Concepto:";
            // 
            // cmbConcepto
            // 
            cmbConcepto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConcepto.FormattingEnabled = true;
            cmbConcepto.Location = new Point(130, 51);
            cmbConcepto.Name = "cmbConcepto";
            cmbConcepto.Size = new Size(250, 23);
            cmbConcepto.TabIndex = 2;
            cmbConcepto.SelectedIndexChanged += cmbConcepto_SelectedIndexChanged;
            // 
            // lblMedioPago
            // 
            lblMedioPago.AutoSize = true;
            lblMedioPago.Location = new Point(15, 90);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(90, 15);
            lblMedioPago.TabIndex = 3;
            lblMedioPago.Text = "Medio de pago:";
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(130, 86);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(250, 23);
            cmbMedioPago.TabIndex = 4;
            cmbMedioPago.SelectedIndexChanged += cmbMedioPago_SelectedIndexChanged;
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Location = new Point(15, 125);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(52, 15);
            lblImporte.TabIndex = 5;
            lblImporte.Text = "Importe:";
            // 
            // nudImporte
            // 
            nudImporte.DecimalPlaces = 2;
            nudImporte.Location = new Point(130, 121);
            nudImporte.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudImporte.Name = "nudImporte";
            nudImporte.Size = new Size(140, 23);
            nudImporte.TabIndex = 6;
            nudImporte.TextAlign = HorizontalAlignment.Right;
            nudImporte.ThousandsSeparator = true;
            // 
            // lblDisponible
            // 
            lblDisponible.AutoSize = true;
            lblDisponible.ForeColor = SystemColors.GrayText;
            lblDisponible.Location = new Point(280, 125);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.Size = new Size(0, 15);
            lblDisponible.TabIndex = 7;
            // 
            // lblEmpleado
            // 
            lblEmpleado.AutoSize = true;
            lblEmpleado.Location = new Point(15, 160);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(63, 15);
            lblEmpleado.TabIndex = 8;
            lblEmpleado.Text = "Empleado:";
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpleado.FormattingEnabled = true;
            cmbEmpleado.Location = new Point(130, 156);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new Size(250, 23);
            cmbEmpleado.TabIndex = 9;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(15, 195);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(76, 15);
            lblObservacion.TabIndex = 10;
            lblObservacion.Text = "Observación:";
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(130, 192);
            txtObservacion.MaxLength = 255;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.PlaceholderText = "Detalle del movimiento (opcional)";
            txtObservacion.ScrollBars = ScrollBars.Vertical;
            txtObservacion.Size = new Size(250, 60);
            txtObservacion.TabIndex = 11;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(160, 270);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 32);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(275, 270);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 32);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmIngresoPlataCaja
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(400, 316);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmIngresoPlataCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimiento de caja";
            Load += frmIngresoPlataCaja_Load;
            ((System.ComponentModel.ISupportInitialize)nudImporte).EndInit();
            // 
            // ttAyuda: explicación de cada combo al pasar el mouse
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbConcepto, "Elegí el motivo del movimiento de caja.");
            ttAyuda.SetToolTip(cmbMedioPago, "Elegí cómo entra o sale la plata (efectivo, transferencia, etc.).");
            ttAyuda.SetToolTip(cmbEmpleado, "Elegí el empleado relacionado con el movimiento, si corresponde.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

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
