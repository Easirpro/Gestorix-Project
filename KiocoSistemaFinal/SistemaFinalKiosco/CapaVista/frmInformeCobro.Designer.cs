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
            lblTitulo = new Label();
            pnlTotal = new Panel();
            lblTextoTotal = new Label();
            lblTotal = new Label();
            cmbMetodoPago = new ComboBox();
            txtMonto = new TextBox();
            btnAgregarPago = new Button();
            lblTextoPagos = new Label();
            dtgPagos = new DataGridView();
            btnQuitarPago = new Button();
            lblTextoPagado = new Label();
            lblPagado = new Label();
            lblTextoRestante = new Label();
            lblRestante = new Label();
            btnCancelar = new Button();
            btnConfirmar = new Button();
            ClnIdMetodoPago = new DataGridViewTextBoxColumn();
            ClnMetodoPago = new DataGridViewTextBoxColumn();
            ClnMontoPago = new DataGridViewTextBoxColumn();
            txtMontoRecibido = new TextBox();
            lblTextoVuelto = new Label();
            lblVuelto = new Label();
            label1 = new Label();
            label2 = new Label();
            lblMetodo = new Label();
            pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgPagos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(11, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(118, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "INFORME DE COBRO";
            // 
            // pnlTotal
            // 
            pnlTotal.BackColor = Color.Green;
            pnlTotal.Controls.Add(lblTotal);
            pnlTotal.Location = new Point(181, 48);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(158, 38);
            pnlTotal.TabIndex = 1;
            // 
            // lblTextoTotal
            // 
            lblTextoTotal.AutoSize = true;
            lblTextoTotal.Location = new Point(215, 27);
            lblTextoTotal.Name = "lblTextoTotal";
            lblTextoTotal.Size = new Size(90, 15);
            lblTextoTotal.TabIndex = 2;
            lblTextoTotal.Text = "TOTAL A PAGAR";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.Font = new Font("Segoe UI", 14F);
            lblTotal.Location = new Point(39, 5);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(71, 30);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "$ 0,00";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(24, 134);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(118, 23);
            cmbMetodoPago.TabIndex = 6;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(23, 89);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(119, 23);
            txtMonto.TabIndex = 9;
            // 
            // btnAgregarPago
            // 
            btnAgregarPago.Location = new Point(162, 134);
            btnAgregarPago.Name = "btnAgregarPago";
            btnAgregarPago.Size = new Size(180, 24);
            btnAgregarPago.TabIndex = 10;
            btnAgregarPago.Text = "AGREGAR MÉTODO DE PAGO";
            btnAgregarPago.UseVisualStyleBackColor = true;
            btnAgregarPago.Click += btnAgregarPago_Click;
            // 
            // lblTextoPagos
            // 
            lblTextoPagos.AutoSize = true;
            lblTextoPagos.Font = new Font("Segoe UI", 7F);
            lblTextoPagos.Location = new Point(24, 176);
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
            dtgPagos.Location = new Point(24, 196);
            dtgPagos.MultiSelect = false;
            dtgPagos.Name = "dtgPagos";
            dtgPagos.ReadOnly = true;
            dtgPagos.RowHeadersVisible = false;
            dtgPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPagos.Size = new Size(318, 117);
            dtgPagos.TabIndex = 12;
            // 
            // btnQuitarPago
            // 
            btnQuitarPago.Location = new Point(97, 392);
            btnQuitarPago.Name = "btnQuitarPago";
            btnQuitarPago.Size = new Size(116, 21);
            btnQuitarPago.TabIndex = 13;
            btnQuitarPago.Text = "QUITAR MÉTODO";
            btnQuitarPago.UseVisualStyleBackColor = true;
            // 
            // lblTextoPagado
            // 
            lblTextoPagado.AutoSize = true;
            lblTextoPagado.Location = new Point(23, 327);
            lblTextoPagado.Name = "lblTextoPagado";
            lblTextoPagado.Size = new Size(54, 15);
            lblTextoPagado.TabIndex = 15;
            lblTextoPagado.Text = "PAGADO";
            // 
            // lblPagado
            // 
            lblPagado.AutoSize = true;
            lblPagado.Location = new Point(304, 327);
            lblPagado.Name = "lblPagado";
            lblPagado.Size = new Size(37, 15);
            lblPagado.TabIndex = 16;
            lblPagado.Text = "$ 0,00";
            // 
            // lblTextoRestante
            // 
            lblTextoRestante.AutoSize = true;
            lblTextoRestante.Location = new Point(23, 342);
            lblTextoRestante.Name = "lblTextoRestante";
            lblTextoRestante.Size = new Size(60, 15);
            lblTextoRestante.TabIndex = 17;
            lblTextoRestante.Text = "RESTANTE";
            // 
            // lblRestante
            // 
            lblRestante.AutoSize = true;
            lblRestante.Location = new Point(304, 342);
            lblRestante.Name = "lblRestante";
            lblRestante.Size = new Size(37, 15);
            lblRestante.TabIndex = 18;
            lblRestante.Text = "$ 0,00";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(16, 392);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 22);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(220, 392);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(127, 21);
            btnConfirmar.TabIndex = 20;
            btnConfirmar.Text = "CONFIRMAR COMPRA";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Visible = false;
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
            // txtMontoRecibido
            // 
            txtMontoRecibido.Location = new Point(23, 45);
            txtMontoRecibido.Name = "txtMontoRecibido";
            txtMontoRecibido.Size = new Size(119, 23);
            txtMontoRecibido.TabIndex = 22;
            // 
            // lblTextoVuelto
            // 
            lblTextoVuelto.AutoSize = true;
            lblTextoVuelto.Location = new Point(24, 357);
            lblTextoVuelto.Name = "lblTextoVuelto";
            lblTextoVuelto.Size = new Size(47, 15);
            lblTextoVuelto.TabIndex = 23;
            lblTextoVuelto.Text = "VUELTO";
            // 
            // lblVuelto
            // 
            lblVuelto.AutoSize = true;
            lblVuelto.Location = new Point(304, 357);
            lblVuelto.Name = "lblVuelto";
            lblVuelto.Size = new Size(37, 15);
            lblVuelto.TabIndex = 24;
            lblVuelto.Text = "$ 0,00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F);
            label1.Location = new Point(24, 30);
            label1.Name = "label1";
            label1.Size = new Size(89, 12);
            label1.TabIndex = 25;
            label1.Text = "MONTO RECIBIDO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F);
            label2.Location = new Point(26, 71);
            label2.Name = "label2";
            label2.Size = new Size(92, 12);
            label2.TabIndex = 26;
            label2.Text = "MONTO A APLICAR";
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.Font = new Font("Segoe UI", 7F);
            lblMetodo.Location = new Point(26, 116);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(91, 12);
            lblMetodo.TabIndex = 27;
            lblMetodo.Text = "METODO DE PAGO";
            // 
            // frmInformeCobro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 435);
            Controls.Add(lblMetodo);
            Controls.Add(label2);
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
            Controls.Add(btnQuitarPago);
            Controls.Add(dtgPagos);
            Controls.Add(lblTextoPagos);
            Controls.Add(btnAgregarPago);
            Controls.Add(txtMonto);
            Controls.Add(cmbMetodoPago);
            Controls.Add(lblTextoTotal);
            Controls.Add(pnlTotal);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmInformeCobro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Informe de Cobro";
            Load += frmInformeCobro_Load;
            pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlTotal;
        private Label lblTextoTotal;
        private Label lblTotal;
        private ComboBox cmbMetodoPago;
        private TextBox txtMonto;
        private Button btnAgregarPago;
        private Label lblTextoPagos;
        private DataGridView dtgPagos;
        private Button btnQuitarPago;
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
        private Label label2;
        private Label lblMetodo;
    }
}