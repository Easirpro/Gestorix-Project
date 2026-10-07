namespace CapaVista
{
    partial class frmCobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobro));
            label1 = new Label();
            lblVuelto = new Label();
            lblTextoVuelto = new Label();
            txtMontoRecibido = new TextBox();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            lblRestante = new Label();
            lblTextoRestante = new Label();
            lblPagado = new Label();
            lblTextoPagado = new Label();
            dtgPagos = new DataGridView();
            ClnIdMetodoPago = new DataGridViewTextBoxColumn();
            ClnMetodoPago = new DataGridViewTextBoxColumn();
            ClnMontoPago = new DataGridViewTextBoxColumn();
            lblTextoPagos = new Label();
            lblTextoTotal = new Label();
            pnlTotal = new Panel();
            lblRestoPago = new Label();
            lblTitulo = new Label();
            btnEfectivo = new Button();
            btnTransferencia = new Button();
            btnCuentaCorriente = new Button();
            btnDebito = new Button();
            panel1 = new Panel();
            lblTotal = new Label();
            lblTotalPagar = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgPagos).BeginInit();
            pnlTotal.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F);
            label1.Location = new Point(23, 88);
            label1.Name = "label1";
            label1.Size = new Size(89, 12);
            label1.TabIndex = 46;
            label1.Text = "MONTO RECIBIDO";
            // 
            // lblVuelto
            // 
            lblVuelto.AutoSize = true;
            lblVuelto.Location = new Point(306, 370);
            lblVuelto.Name = "lblVuelto";
            lblVuelto.Size = new Size(37, 15);
            lblVuelto.TabIndex = 45;
            lblVuelto.Text = "$ 0,00";
            // 
            // lblTextoVuelto
            // 
            lblTextoVuelto.AutoSize = true;
            lblTextoVuelto.Location = new Point(26, 370);
            lblTextoVuelto.Name = "lblTextoVuelto";
            lblTextoVuelto.Size = new Size(47, 15);
            lblTextoVuelto.TabIndex = 44;
            lblTextoVuelto.Text = "VUELTO";
            // 
            // txtMontoRecibido
            // 
            txtMontoRecibido.Location = new Point(25, 103);
            txtMontoRecibido.Name = "txtMontoRecibido";
            txtMontoRecibido.Size = new Size(118, 23);
            txtMontoRecibido.TabIndex = 43;
            txtMontoRecibido.TextChanged += txtMontoRecibido_TextChanged;
            txtMontoRecibido.KeyDown += txtMontoRecibido_KeyDown;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(221, 406);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(139, 21);
            btnConfirmar.TabIndex = 42;
            btnConfirmar.Text = "CONFIRMAR COMPRA";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(138, 406);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 21);
            btnCancelar.TabIndex = 41;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblRestante
            // 
            lblRestante.AutoSize = true;
            lblRestante.Location = new Point(306, 355);
            lblRestante.Name = "lblRestante";
            lblRestante.Size = new Size(37, 15);
            lblRestante.TabIndex = 40;
            lblRestante.Text = "$ 0,00";
            // 
            // lblTextoRestante
            // 
            lblTextoRestante.AutoSize = true;
            lblTextoRestante.Location = new Point(25, 355);
            lblTextoRestante.Name = "lblTextoRestante";
            lblTextoRestante.Size = new Size(60, 15);
            lblTextoRestante.TabIndex = 39;
            lblTextoRestante.Text = "RESTANTE";
            // 
            // lblPagado
            // 
            lblPagado.AutoSize = true;
            lblPagado.Location = new Point(306, 340);
            lblPagado.Name = "lblPagado";
            lblPagado.Size = new Size(37, 15);
            lblPagado.TabIndex = 38;
            lblPagado.Text = "$ 0,00";
            // 
            // lblTextoPagado
            // 
            lblTextoPagado.AutoSize = true;
            lblTextoPagado.Location = new Point(25, 340);
            lblTextoPagado.Name = "lblTextoPagado";
            lblTextoPagado.Size = new Size(54, 15);
            lblTextoPagado.TabIndex = 37;
            lblTextoPagado.Text = "PAGADO";
            // 
            // dtgPagos
            // 
            dtgPagos.AllowUserToAddRows = false;
            dtgPagos.AllowUserToDeleteRows = false;
            dtgPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgPagos.Columns.AddRange(new DataGridViewColumn[] { ClnIdMetodoPago, ClnMetodoPago, ClnMontoPago });
            dtgPagos.Location = new Point(25, 220);
            dtgPagos.MultiSelect = false;
            dtgPagos.Name = "dtgPagos";
            dtgPagos.ReadOnly = true;
            dtgPagos.RowHeadersVisible = false;
            dtgPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPagos.Size = new Size(334, 117);
            dtgPagos.TabIndex = 35;
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
            // lblTextoPagos
            // 
            lblTextoPagos.AutoSize = true;
            lblTextoPagos.Font = new Font("Segoe UI", 7F);
            lblTextoPagos.Location = new Point(25, 200);
            lblTextoPagos.Name = "lblTextoPagos";
            lblTextoPagos.Size = new Size(96, 12);
            lblTextoPagos.TabIndex = 34;
            lblTextoPagos.Text = "PAGOS AGREGADOS";
            // 
            // lblTextoTotal
            // 
            lblTextoTotal.AutoSize = true;
            lblTextoTotal.Location = new Point(227, 111);
            lblTextoTotal.Name = "lblTextoTotal";
            lblTextoTotal.Size = new Size(79, 15);
            lblTextoTotal.TabIndex = 30;
            lblTextoTotal.Text = "RESTA PAGAR";
            // 
            // pnlTotal
            // 
            pnlTotal.BackColor = Color.Green;
            pnlTotal.Controls.Add(lblRestoPago);
            pnlTotal.Location = new Point(191, 129);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(158, 28);
            pnlTotal.TabIndex = 29;
            // 
            // lblRestoPago
            // 
            lblRestoPago.Dock = DockStyle.Fill;
            lblRestoPago.Font = new Font("Segoe UI", 14F);
            lblRestoPago.ForeColor = SystemColors.ButtonFace;
            lblRestoPago.Location = new Point(0, 0);
            lblRestoPago.Name = "lblRestoPago";
            lblRestoPago.Size = new Size(158, 28);
            lblRestoPago.TabIndex = 3;
            lblRestoPago.Text = "$ 0,00";
            lblRestoPago.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(18, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(195, 25);
            lblTitulo.TabIndex = 28;
            lblTitulo.Text = "INFORME DE COBRO";
            // 
            // btnEfectivo
            // 
            btnEfectivo.Location = new Point(26, 170);
            btnEfectivo.Name = "btnEfectivo";
            btnEfectivo.Size = new Size(75, 23);
            btnEfectivo.TabIndex = 50;
            btnEfectivo.Text = "Efectivo";
            btnEfectivo.UseVisualStyleBackColor = true;
            btnEfectivo.Click += btnEfectivo_Click;
            // 
            // btnTransferencia
            // 
            btnTransferencia.Location = new Point(107, 170);
            btnTransferencia.Name = "btnTransferencia";
            btnTransferencia.Size = new Size(91, 23);
            btnTransferencia.TabIndex = 51;
            btnTransferencia.Text = "Transferencia";
            btnTransferencia.UseVisualStyleBackColor = true;
            btnTransferencia.Click += btnTransferencia_Click;
            // 
            // btnCuentaCorriente
            // 
            btnCuentaCorriente.Location = new Point(204, 170);
            btnCuentaCorriente.Name = "btnCuentaCorriente";
            btnCuentaCorriente.Size = new Size(75, 23);
            btnCuentaCorriente.TabIndex = 52;
            btnCuentaCorriente.Text = "C / C";
            btnCuentaCorriente.UseVisualStyleBackColor = true;
            // 
            // btnDebito
            // 
            btnDebito.Location = new Point(285, 170);
            btnDebito.Name = "btnDebito";
            btnDebito.Size = new Size(75, 23);
            btnDebito.TabIndex = 53;
            btnDebito.Text = "Debito";
            btnDebito.UseVisualStyleBackColor = true;
            btnDebito.Click += btnDebito_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblTotal);
            panel1.Location = new Point(164, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 46);
            panel1.TabIndex = 54;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = SystemColors.Control;
            lblTotal.Location = new Point(72, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(63, 25);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "label2";
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPagar.Location = new Point(237, 36);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(56, 21);
            lblTotalPagar.TabIndex = 55;
            lblTotalPagar.Text = "TOTAL";
            // 
            // frmCobro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 450);
            Controls.Add(lblTotalPagar);
            Controls.Add(panel1);
            Controls.Add(btnDebito);
            Controls.Add(btnCuentaCorriente);
            Controls.Add(btnTransferencia);
            Controls.Add(btnEfectivo);
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
            Controls.Add(lblTextoTotal);
            Controls.Add(pnlTotal);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCobro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cobro";
            ((System.ComponentModel.ISupportInitialize)dtgPagos).EndInit();
            pnlTotal.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMetodo;
        private Label label2;
        private Label label1;
        private Label lblVuelto;
        private Label lblTextoVuelto;
        private TextBox txtMontoRecibido;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label lblRestante;
        private Label lblTextoRestante;
        private Label lblPagado;
        private Label lblTextoPagado;
        private DataGridView dtgPagos;
        private DataGridViewTextBoxColumn ClnIdMetodoPago;
        private DataGridViewTextBoxColumn ClnMetodoPago;
        private DataGridViewTextBoxColumn ClnMontoPago;
        private Label lblTextoPagos;
        private Button btnAgregarPago;
        private TextBox txtMonto;
        private ComboBox cmbMetodoPago;
        private Label lblTextoTotal;
        private Panel pnlTotal;
        private Label lblRestoPago;
        private Label lblTitulo;
        private Button button1;
        private Button btnEfectivo;
        private Button btnTransferencia;
        private Button btnCuentaCorriente;
        private Button btnDebito;
        private Panel panel1;
        private Label lblTotal;
        private Label lblTotalPagar;
    }
}