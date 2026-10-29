namespace CapaVista
{
    partial class frmCuentaCorrienteProveedores
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
            lblProveedor = new System.Windows.Forms.Label();
            cmbProveedor = new System.Windows.Forms.ComboBox();
            chkTodos = new System.Windows.Forms.CheckBox();
            chkIncluirPagadas = new System.Windows.Forms.CheckBox();
            btnBuscar = new System.Windows.Forms.Button();
            lblCompras = new System.Windows.Forms.Label();
            dgvCompras = new System.Windows.Forms.DataGridView();
            lblTotalDeuda = new System.Windows.Forms.Label();
            lblVencido = new System.Windows.Forms.Label();
            btnRegistrarPago = new System.Windows.Forms.Button();
            btnAnularPago = new System.Windows.Forms.Button();
            lblPagos = new System.Windows.Forms.Label();
            dgvPagos = new System.Windows.Forms.DataGridView();
            btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.Location = new System.Drawing.Point(12, 17);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            lblProveedor.AutoSize = true;
            // 
            // cmbProveedor
            // 
            cmbProveedor.Location = new System.Drawing.Point(85, 13);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new System.Drawing.Size(260, 23);
            cmbProveedor.TabIndex = 1;
            cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            // 
            // chkTodos
            // 
            chkTodos.Location = new System.Drawing.Point(360, 15);
            chkTodos.Name = "chkTodos";
            chkTodos.TabIndex = 2;
            chkTodos.Text = "Todos los proveedores";
            chkTodos.AutoSize = true;
            chkTodos.UseVisualStyleBackColor = true;
            chkTodos.CheckedChanged += chkTodos_CheckedChanged;
            // 
            // chkIncluirPagadas
            // 
            chkIncluirPagadas.Location = new System.Drawing.Point(530, 15);
            chkIncluirPagadas.Name = "chkIncluirPagadas";
            chkIncluirPagadas.TabIndex = 3;
            chkIncluirPagadas.Text = "Incluir compras pagadas";
            chkIncluirPagadas.AutoSize = true;
            chkIncluirPagadas.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new System.Drawing.Point(715, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(100, 28);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblCompras
            // 
            lblCompras.Location = new System.Drawing.Point(12, 52);
            lblCompras.Name = "lblCompras";
            lblCompras.TabIndex = 5;
            lblCompras.Text = "Compras";
            lblCompras.AutoSize = true;
            lblCompras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // dgvCompras
            // 
            dgvCompras.Location = new System.Drawing.Point(12, 72);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.Size = new System.Drawing.Size(960, 250);
            dgvCompras.TabIndex = 6;
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.ReadOnly = true;
            dgvCompras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvCompras.DataBindingComplete += dgvCompras_DataBindingComplete;
            dgvCompras.SelectionChanged += dgvCompras_SelectionChanged;
            // 
            // lblTotalDeuda
            // 
            lblTotalDeuda.Location = new System.Drawing.Point(12, 332);
            lblTotalDeuda.Name = "lblTotalDeuda";
            lblTotalDeuda.TabIndex = 7;
            lblTotalDeuda.Text = "Deuda total: $ 0,00";
            lblTotalDeuda.AutoSize = true;
            lblTotalDeuda.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblVencido
            // 
            lblVencido.Location = new System.Drawing.Point(300, 335);
            lblVencido.Name = "lblVencido";
            lblVencido.TabIndex = 8;
            lblVencido.Text = "Vencido: $ 0,00";
            lblVencido.AutoSize = true;
            lblVencido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblVencido.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new System.Drawing.Point(712, 328);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new System.Drawing.Size(130, 32);
            btnRegistrarPago.TabIndex = 9;
            btnRegistrarPago.Text = "Registrar pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            btnRegistrarPago.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // btnAnularPago
            // 
            btnAnularPago.Location = new System.Drawing.Point(848, 328);
            btnAnularPago.Name = "btnAnularPago";
            btnAnularPago.Size = new System.Drawing.Size(124, 32);
            btnAnularPago.TabIndex = 10;
            btnAnularPago.Text = "Anular pago";
            btnAnularPago.UseVisualStyleBackColor = true;
            btnAnularPago.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAnularPago.Click += btnAnularPago_Click;
            // 
            // lblPagos
            // 
            lblPagos.Location = new System.Drawing.Point(12, 372);
            lblPagos.Name = "lblPagos";
            lblPagos.TabIndex = 11;
            lblPagos.Text = "Pagos de la compra seleccionada";
            lblPagos.AutoSize = true;
            lblPagos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // dgvPagos
            // 
            dgvPagos.Location = new System.Drawing.Point(12, 392);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.Size = new System.Drawing.Size(960, 170);
            dgvPagos.TabIndex = 12;
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.ReadOnly = true;
            dgvPagos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvPagos.DataBindingComplete += dgvPagos_DataBindingComplete;
            // 
            // btnSalir
            // 
            btnSalir.Location = new System.Drawing.Point(852, 572);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(120, 30);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmCuentaCorrienteProveedores
            // 
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new System.Drawing.Size(984, 614);
            Controls.Add(lblProveedor);
            Controls.Add(cmbProveedor);
            Controls.Add(chkTodos);
            Controls.Add(chkIncluirPagadas);
            Controls.Add(btnBuscar);
            Controls.Add(lblCompras);
            Controls.Add(dgvCompras);
            Controls.Add(lblTotalDeuda);
            Controls.Add(lblVencido);
            Controls.Add(btnRegistrarPago);
            Controls.Add(btnAnularPago);
            Controls.Add(lblPagos);
            Controls.Add(dgvPagos);
            Controls.Add(btnSalir);
            MinimumSize = new System.Drawing.Size(1000, 650);
            Name = "frmCuentaCorrienteProveedores";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cuenta corriente de proveedores";
            Load += frmCuentaCorrienteProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.CheckBox chkIncluirPagadas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label lblTotalDeuda;
        private System.Windows.Forms.Label lblVencido;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnAnularPago;
        private System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Button btnSalir;
    }
}
