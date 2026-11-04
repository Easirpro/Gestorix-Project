namespace CapaVista
{
    partial class frmInformeCobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformeCobro));
            lblRestaPago = new Label();
            pnlTotal = new Panel();
            lblTotal = new Label();
            lblTextoTotal = new Label();
            btnEfectivo = new Button();
            lblTextoPagos = new Label();
            dtgPagos = new DataGridView();
            ClnIdMetodoPago = new DataGridViewTextBoxColumn();
            ClnMetodoPago = new DataGridViewTextBoxColumn();
            ClnMontoPago = new DataGridViewTextBoxColumn();
            lblTextoPagado = new Label();
            lblPagado = new Label();
            lblTextoRestante = new Label();
            lblRestante = new Label();
            btnCancelar = new Button();
            btnConfirmar = new Button();
            txtMontoRecibido = new TextBox();
            lblTextoVuelto = new Label();
            lblVuelto = new Label();
            label1 = new Label();
            btnTransferencia = new Button();
            btnDebito = new Button();
            pnlResta = new Panel();
            lblRestaP = new Label();
            lblCobro = new Label();
            pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgPagos).BeginInit();
            pnlResta.SuspendLayout();
            SuspendLayout();
            // 
            // lblRestaPago
            // 
            lblRestaPago.AutoSize = true;
            lblRestaPago.Location = new Point(227, 79);
            lblRestaPago.Name = "lblRestaPago";
            lblRestaPago.Size = new Size(79, 15);
            lblRestaPago.TabIndex = 0;
            lblRestaPago.Text = "RESTA PAGAR";
            // 
            // pnlTotal
            // 
            pnlTotal.BackColor = Color.Green;
            pnlTotal.Controls.Add(lblTotal);
            pnlTotal.Location = new Point(169, 27);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(200, 38);
            pnlTotal.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Font = new Font("Segoe UI", 14F);
            lblTotal.ForeColor = SystemColors.ButtonFace;
            lblTotal.Location = new Point(0, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(200, 38);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "$ 0,00";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTextoTotal
            // 
            lblTextoTotal.AutoSize = true;
            lblTextoTotal.Location = new Point(227, 9);
            lblTextoTotal.Name = "lblTextoTotal";
            lblTextoTotal.Size = new Size(90, 15);
            lblTextoTotal.TabIndex = 2;
            lblTextoTotal.Text = "TOTAL A PAGAR";
            // 
            // btnEfectivo
            // 
            btnEfectivo.Location = new Point(23, 143);
            btnEfectivo.Name = "btnEfectivo";
            btnEfectivo.Size = new Size(93, 36);
            btnEfectivo.TabIndex = 10;
            btnEfectivo.Text = "Efectivo";
            btnEfectivo.UseVisualStyleBackColor = true;
            btnEfectivo.Click += btnEfectivo_Click;
            // 
            // lblTextoPagos
            // 
            lblTextoPagos.AutoSize = true;
            lblTextoPagos.Font = new Font("Segoe UI", 7F);
            lblTextoPagos.Location = new Point(24, 194);
            lblTextoPagos.Name = "lblTextoPagos";
            lblTextoPagos.Size = new Size(96, 12);
            lblTextoPagos.TabIndex = 11;
            lblTextoPagos.Text = "PAGOS AGREGADOS";
            // 
            // dtgPagos
            // 
            dtgPagos.AllowUserToAddRows = false;
            dtgPagos.AllowUserToDeleteRows = false;
            dtgPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgPagos.Columns.AddRange(new DataGridViewColumn[] { ClnIdMetodoPago, ClnMetodoPago, ClnMontoPago });
            dtgPagos.Location = new Point(24, 214);
            dtgPagos.MultiSelect = false;
            dtgPagos.Name = "dtgPagos";
            dtgPagos.ReadOnly = true;
            dtgPagos.RowHeadersVisible = false;
            dtgPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPagos.Size = new Size(318, 117);
            dtgPagos.TabIndex = 12;
            // 
            // ClnIdMetodoPago
            // 
            ClnIdMetodoPago.HeaderText = "ID";
            ClnIdMetodoPago.Name = "ClnIdMetodoPago";
            ClnIdMetodoPago.ReadOnly = true;
            // 
            // ClnMetodoPago
            // 
            ClnMetodoPago.HeaderText = "Método de pago";
            ClnMetodoPago.Name = "ClnMetodoPago";
            ClnMetodoPago.ReadOnly = true;
            // 
            // ClnMontoPago
            // 
            ClnMontoPago.HeaderText = "Monto";
            ClnMontoPago.Name = "ClnMontoPago";
            ClnMontoPago.ReadOnly = true;
            // 
            // lblTextoPagado
            // 
            lblTextoPagado.AutoSize = true;
            lblTextoPagado.Location = new Point(23, 345);
            lblTextoPagado.Name = "lblTextoPagado";
            lblTextoPagado.Size = new Size(54, 15);
            lblTextoPagado.TabIndex = 15;
            lblTextoPagado.Text = "PAGADO";
            // 
            // lblPagado
            // 
            lblPagado.AutoSize = true;
            lblPagado.Location = new Point(304, 345);
            lblPagado.Name = "lblPagado";
            lblPagado.Size = new Size(37, 15);
            lblPagado.TabIndex = 16;
            lblPagado.Text = "$ 0,00";
            // 
            // lblTextoRestante
            // 
            lblTextoRestante.AutoSize = true;
            lblTextoRestante.Location = new Point(23, 360);
            lblTextoRestante.Name = "lblTextoRestante";
            lblTextoRestante.Size = new Size(60, 15);
            lblTextoRestante.TabIndex = 17;
            lblTextoRestante.Text = "RESTANTE";
            // 
            // lblRestante
            // 
            lblRestante.AutoSize = true;
            lblRestante.Location = new Point(304, 360);
            lblRestante.Name = "lblRestante";
            lblRestante.Size = new Size(37, 15);
            lblRestante.TabIndex = 18;
            lblRestante.Text = "$ 0,00";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(121, 392);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 21);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(202, 392);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(139, 21);
            btnConfirmar.TabIndex = 20;
            btnConfirmar.Text = "CONFIRMAR VENTA";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Visible = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // txtMontoRecibido
            // 
            txtMontoRecibido.Location = new Point(23, 79);
            txtMontoRecibido.Name = "txtMontoRecibido";
            txtMontoRecibido.PlaceholderText = "Monto que entrega el cliente";
            txtMontoRecibido.Size = new Size(118, 23);
            txtMontoRecibido.TabIndex = 22;
            txtMontoRecibido.TextChanged += txtMontoRecibido_TextChanged;
            // 
            // lblTextoVuelto
            // 
            lblTextoVuelto.AutoSize = true;
            lblTextoVuelto.Location = new Point(24, 375);
            lblTextoVuelto.Name = "lblTextoVuelto";
            lblTextoVuelto.Size = new Size(47, 15);
            lblTextoVuelto.TabIndex = 23;
            lblTextoVuelto.Text = "VUELTO";
            // 
            // lblVuelto
            // 
            lblVuelto.AutoSize = true;
            lblVuelto.Location = new Point(304, 375);
            lblVuelto.Name = "lblVuelto";
            lblVuelto.Size = new Size(37, 15);
            lblVuelto.TabIndex = 24;
            lblVuelto.Text = "$ 0,00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F);
            label1.Location = new Point(22, 64);
            label1.Name = "label1";
            label1.Size = new Size(89, 12);
            label1.TabIndex = 25;
            label1.Text = "MONTO RECIBIDO";
            // 
            // btnTransferencia
            // 
            btnTransferencia.Location = new Point(132, 143);
            btnTransferencia.Name = "btnTransferencia";
            btnTransferencia.Size = new Size(92, 35);
            btnTransferencia.TabIndex = 26;
            btnTransferencia.Text = "Transferencia";
            btnTransferencia.UseVisualStyleBackColor = true;
            btnTransferencia.Click += btnTransferencia_Click;
            // 
            // btnDebito
            // 
            btnDebito.Location = new Point(249, 144);
            btnDebito.Name = "btnDebito";
            btnDebito.Size = new Size(92, 35);
            btnDebito.TabIndex = 27;
            btnDebito.Text = "Debito";
            btnDebito.UseVisualStyleBackColor = true;
            btnDebito.Click += btnDebito_Click;
            // 
            // pnlResta
            // 
            pnlResta.BackColor = Color.Green;
            pnlResta.BorderStyle = BorderStyle.FixedSingle;
            pnlResta.Controls.Add(lblRestaP);
            pnlResta.Location = new Point(170, 94);
            pnlResta.Name = "pnlResta";
            pnlResta.Size = new Size(200, 38);
            pnlResta.TabIndex = 28;
            // 
            // lblRestaP
            // 
            lblRestaP.AutoSize = true;
            lblRestaP.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRestaP.ForeColor = SystemColors.Control;
            lblRestaP.Location = new Point(75, 8);
            lblRestaP.Name = "lblRestaP";
            lblRestaP.Size = new Size(50, 20);
            lblRestaP.TabIndex = 0;
            lblRestaP.Text = "label2";
            // 
            // lblCobro
            // 
            lblCobro.AutoSize = true;
            lblCobro.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCobro.Location = new Point(12, 9);
            lblCobro.Name = "lblCobro";
            lblCobro.Size = new Size(76, 25);
            lblCobro.TabIndex = 29;
            lblCobro.Text = "COBRO";
            // 
            // frmInformeCobro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 435);
            Controls.Add(lblCobro);
            Controls.Add(pnlResta);
            Controls.Add(btnDebito);
            Controls.Add(btnTransferencia);
            Controls.Add(label1);
            Controls.Add(lblVuelto);
            Controls.Add(lblTextoVuelto);
            Controls.Add(txtMontoRecibido);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            Controls.Add(lblRestante);
            Controls.Add(lblTextoRestante);
            Controls.Add(lblPagado);
            Controls.Add(lblTextoPagado);
            Controls.Add(dtgPagos);
            Controls.Add(lblTextoPagos);
            Controls.Add(btnEfectivo);
            Controls.Add(lblTextoTotal);
            Controls.Add(pnlTotal);
            Controls.Add(lblRestaPago);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmInformeCobro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Informe de Cobro";
            pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgPagos).EndInit();
            pnlResta.ResumeLayout(false);
            pnlResta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRestaPago;
        private Panel pnlTotal;
        private Label lblTextoTotal;
        private Label lblTotal;
        private Button btnEfectivo;
        private Label lblTextoPagos;
        private DataGridView dtgPagos;
        private DataGridViewTextBoxColumn ClnIdMetodoPago;
        private DataGridViewTextBoxColumn ClnMetodoPago;
        private DataGridViewTextBoxColumn ClnMontoPago;
        private Label lblTextoPagado;
        private Label lblPagado;
        private Label lblTextoRestante;
        private Label lblRestante;
        private Button btnCancelar;
        private Button btnConfirmar;
        private TextBox txtMontoRecibido;
        private Label lblTextoVuelto;
        private Label lblVuelto;
        private Label label1;
        private Button btnTransferencia;
        private Button btnDebito;
        private Panel pnlResta;
        private Label lblRestaP;
        private Label lblCobro;
    }
}