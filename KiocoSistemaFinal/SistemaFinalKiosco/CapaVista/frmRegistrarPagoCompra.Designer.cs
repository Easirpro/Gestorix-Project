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
            components = new System.ComponentModel.Container();
            ttAyuda = new ToolTip(components);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarPagoCompra));
            lblTitulo = new Label();
            lblCompra = new Label();
            lblSaldo = new Label();
            lblMedioPago = new Label();
            cmbMedioPago = new ComboBox();
            lblMonto = new Label();
            nudMonto = new NumericUpDown();
            btnTotal = new Button();
            chkDesdeCaja = new CheckBox();
            lblDisponible = new Label();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(122, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Pago de compra";
            // 
            // lblCompra
            // 
            lblCompra.AutoSize = true;
            lblCompra.Location = new Point(15, 45);
            lblCompra.Name = "lblCompra";
            lblCompra.Size = new Size(78, 15);
            lblCompra.TabIndex = 1;
            lblCompra.Text = "Compra N.º -";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSaldo.Location = new Point(15, 68);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(137, 15);
            lblSaldo.TabIndex = 2;
            lblSaldo.Text = "Saldo pendiente: $ 0,00";
            // 
            // lblMedioPago
            // 
            lblMedioPago.AutoSize = true;
            lblMedioPago.Location = new Point(15, 105);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(90, 15);
            lblMedioPago.TabIndex = 3;
            lblMedioPago.Text = "Medio de pago:";
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(130, 101);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(250, 23);
            cmbMedioPago.TabIndex = 4;
            cmbMedioPago.SelectedIndexChanged += cmbMedioPago_SelectedIndexChanged;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(15, 140);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(46, 15);
            lblMonto.TabIndex = 5;
            lblMonto.Text = "Monto:";
            // 
            // nudMonto
            // 
            nudMonto.DecimalPlaces = 2;
            nudMonto.Location = new Point(130, 136);
            nudMonto.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(140, 23);
            nudMonto.TabIndex = 6;
            nudMonto.TextAlign = HorizontalAlignment.Right;
            nudMonto.ThousandsSeparator = true;
            // 
            // btnTotal
            // 
            btnTotal.Location = new Point(280, 135);
            btnTotal.Name = "btnTotal";
            btnTotal.Size = new Size(100, 25);
            btnTotal.TabIndex = 7;
            btnTotal.Text = "Pagar todo";
            btnTotal.UseVisualStyleBackColor = true;
            btnTotal.Click += btnTotal_Click;
            // 
            // chkDesdeCaja
            // 
            chkDesdeCaja.AutoSize = true;
            chkDesdeCaja.Location = new Point(15, 172);
            chkDesdeCaja.Name = "chkDesdeCaja";
            chkDesdeCaja.Size = new Size(186, 19);
            chkDesdeCaja.TabIndex = 8;
            chkDesdeCaja.Text = "El dinero sale de la caja abierta";
            chkDesdeCaja.UseVisualStyleBackColor = true;
            chkDesdeCaja.CheckedChanged += chkDesdeCaja_CheckedChanged;
            // 
            // lblDisponible
            // 
            lblDisponible.AutoSize = true;
            lblDisponible.ForeColor = SystemColors.GrayText;
            lblDisponible.Location = new Point(35, 195);
            lblDisponible.Name = "lblDisponible";
            lblDisponible.Size = new Size(0, 15);
            lblDisponible.TabIndex = 9;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(15, 225);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(76, 15);
            lblObservacion.TabIndex = 10;
            lblObservacion.Text = "Observación:";
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(130, 222);
            txtObservacion.MaxLength = 255;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.PlaceholderText = "Detalle del pago (opcional)";
            txtObservacion.ScrollBars = ScrollBars.Vertical;
            txtObservacion.Size = new Size(250, 55);
            txtObservacion.TabIndex = 11;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(160, 295);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 32);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(275, 295);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 32);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmRegistrarPagoCompra
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(400, 342);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRegistrarPagoCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar pago";
            Load += frmRegistrarPagoCompra_Load;
            ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
            // 
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbMedioPago, "Elegí con qué se paga.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

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
