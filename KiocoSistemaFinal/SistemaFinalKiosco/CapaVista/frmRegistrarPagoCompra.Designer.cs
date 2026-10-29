namespace CapaVista
{
    partial class frmRegistrarPagoCompra
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
            lblCompra = new System.Windows.Forms.Label();
            lblSaldo = new System.Windows.Forms.Label();
            lblMedioPago = new System.Windows.Forms.Label();
            cmbMedioPago = new System.Windows.Forms.ComboBox();
            lblMonto = new System.Windows.Forms.Label();
            nudMonto = new System.Windows.Forms.NumericUpDown();
            btnTotal = new System.Windows.Forms.Button();
            chkDesdeCaja = new System.Windows.Forms.CheckBox();
            lblDisponible = new System.Windows.Forms.Label();
            lblObservacion = new System.Windows.Forms.Label();
            txtObservacion = new System.Windows.Forms.TextBox();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new System.Drawing.Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Pago de compra";
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblCompra
            // 
            lblCompra.Location = new System.Drawing.Point(15, 45);
            lblCompra.Name = "lblCompra";
            lblCompra.TabIndex = 1;
            lblCompra.Text = "Compra N.º -";
            lblCompra.AutoSize = true;
            // 
            // lblSaldo
            // 
            lblSaldo.Location = new System.Drawing.Point(15, 68);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.TabIndex = 2;
            lblSaldo.Text = "Saldo pendiente: $ 0,00";
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblMedioPago
            // 
            lblMedioPago.Location = new System.Drawing.Point(15, 105);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.TabIndex = 3;
            lblMedioPago.Text = "Medio de pago:";
            lblMedioPago.AutoSize = true;
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.Location = new System.Drawing.Point(130, 101);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new System.Drawing.Size(250, 23);
            cmbMedioPago.TabIndex = 4;
            cmbMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.SelectedIndexChanged += cmbMedioPago_SelectedIndexChanged;
            // 
            // lblMonto
            // 
            lblMonto.Location = new System.Drawing.Point(15, 140);
            lblMonto.Name = "lblMonto";
            lblMonto.TabIndex = 5;
            lblMonto.Text = "Monto:";
            lblMonto.AutoSize = true;
            // 
            // nudMonto
            // 
            nudMonto.Location = new System.Drawing.Point(130, 136);
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new System.Drawing.Size(140, 23);
            nudMonto.TabIndex = 6;
            nudMonto.DecimalPlaces = 2;
            nudMonto.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudMonto.ThousandsSeparator = true;
            nudMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnTotal
            // 
            btnTotal.Location = new System.Drawing.Point(280, 135);
            btnTotal.Name = "btnTotal";
            btnTotal.Size = new System.Drawing.Size(100, 25);
            btnTotal.TabIndex = 7;
            btnTotal.Text = "Pagar todo";
            btnTotal.UseVisualStyleBackColor = true;
            btnTotal.Click += btnTotal_Click;
            // 
            // chkDesdeCaja
            // 
            chkDesdeCaja.Location = new System.Drawing.Point(15, 172);
            chkDesdeCaja.Name = "chkDesdeCaja";
            chkDesdeCaja.TabIndex = 8;
            chkDesdeCaja.Text = "El dinero sale de la caja abierta";
            chkDesdeCaja.AutoSize = true;
            chkDesdeCaja.UseVisualStyleBackColor = true;
            chkDesdeCaja.CheckedChanged += chkDesdeCaja_CheckedChanged;
            // 
            // lblDisponible
            // 
            lblDisponible.Location = new System.Drawing.Point(35, 195);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.TabIndex = 9;
            lblDisponible.Text = "";
            lblDisponible.AutoSize = true;
            lblDisponible.ForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // lblObservacion
            // 
            lblObservacion.Location = new System.Drawing.Point(15, 225);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.TabIndex = 10;
            lblObservacion.Text = "Observación:";
            lblObservacion.AutoSize = true;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new System.Drawing.Point(130, 222);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new System.Drawing.Size(250, 55);
            txtObservacion.TabIndex = 11;
            txtObservacion.Multiline = true;
            txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtObservacion.MaxLength = 255;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new System.Drawing.Point(160, 295);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(105, 32);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(275, 295);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(105, 32);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmRegistrarPagoCompra
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new System.Drawing.Size(400, 342);
            Controls.Add(lblTitulo);
            Controls.Add(lblCompra);
            Controls.Add(lblSaldo);
            Controls.Add(lblMedioPago);
            Controls.Add(cmbMedioPago);
            Controls.Add(lblMonto);
            Controls.Add(nudMonto);
            Controls.Add(btnTotal);
            Controls.Add(chkDesdeCaja);
            Controls.Add(lblDisponible);
            Controls.Add(lblObservacion);
            Controls.Add(txtObservacion);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRegistrarPagoCompra";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Registrar pago";
            Load += frmRegistrarPagoCompra_Load;
            ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblMedioPago;
        private System.Windows.Forms.ComboBox cmbMedioPago;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.CheckBox chkDesdeCaja;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
