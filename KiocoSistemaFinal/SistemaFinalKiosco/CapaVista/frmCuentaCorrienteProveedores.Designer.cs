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
            components = new System.ComponentModel.Container();
            ttAyuda = new ToolTip(components);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentaCorrienteProveedores));
            lblProveedor = new Label();
            cmbProveedor = new ComboBox();
            chkTodos = new CheckBox();
            chkIncluirPagadas = new CheckBox();
            btnBuscar = new Button();
            lblCompras = new Label();
            dgvCompras = new DataGridView();
            lblTotalDeuda = new Label();
            lblVencido = new Label();
            btnRegistrarPago = new Button();
            btnAnularPago = new Button();
            lblPagos = new Label();
            dgvPagos = new DataGridView();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(12, 17);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(64, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(85, 13);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(260, 23);
            cmbProveedor.TabIndex = 1;
            // 
            // chkTodos
            // 
            chkTodos.AutoSize = true;
            chkTodos.Location = new Point(360, 15);
            chkTodos.Name = "chkTodos";
            chkTodos.Size = new Size(143, 19);
            chkTodos.TabIndex = 2;
            chkTodos.Text = "Todos los proveedores";
            chkTodos.UseVisualStyleBackColor = true;
            chkTodos.CheckedChanged += chkTodos_CheckedChanged;
            // 
            // chkIncluirPagadas
            // 
            chkIncluirPagadas.AutoSize = true;
            chkIncluirPagadas.Location = new Point(530, 15);
            chkIncluirPagadas.Name = "chkIncluirPagadas";
            chkIncluirPagadas.Size = new Size(155, 19);
            chkIncluirPagadas.TabIndex = 3;
            chkIncluirPagadas.Text = "Incluir compras pagadas";
            chkIncluirPagadas.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(715, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 28);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblCompras
            // 
            lblCompras.AutoSize = true;
            lblCompras.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCompras.Location = new Point(12, 52);
            lblCompras.Name = "lblCompras";
            lblCompras.Size = new Size(55, 15);
            lblCompras.TabIndex = 5;
            lblCompras.Text = "Compras";
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCompras.BackgroundColor = SystemColors.Window;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Location = new Point(12, 72);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.Size = new Size(960, 250);
            dgvCompras.TabIndex = 6;
            dgvCompras.DataBindingComplete += dgvCompras_DataBindingComplete;
            dgvCompras.SelectionChanged += dgvCompras_SelectionChanged;
            // 
            // lblTotalDeuda
            // 
            lblTotalDeuda.AutoSize = true;
            lblTotalDeuda.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalDeuda.Location = new Point(12, 332);
            lblTotalDeuda.Name = "lblTotalDeuda";
            lblTotalDeuda.Size = new Size(143, 20);
            lblTotalDeuda.TabIndex = 7;
            lblTotalDeuda.Text = "Deuda total: $ 0,00";
            // 
            // lblVencido
            // 
            lblVencido.AutoSize = true;
            lblVencido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVencido.ForeColor = Color.Firebrick;
            lblVencido.Location = new Point(300, 335);
            lblVencido.Name = "lblVencido";
            lblVencido.Size = new Size(91, 15);
            lblVencido.TabIndex = 8;
            lblVencido.Text = "Vencido: $ 0,00";
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistrarPago.Location = new Point(712, 328);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(130, 32);
            btnRegistrarPago.TabIndex = 9;
            btnRegistrarPago.Text = "Registrar pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // btnAnularPago
            // 
            btnAnularPago.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnularPago.Location = new Point(848, 328);
            btnAnularPago.Name = "btnAnularPago";
            btnAnularPago.Size = new Size(124, 32);
            btnAnularPago.TabIndex = 10;
            btnAnularPago.Text = "Anular pago";
            btnAnularPago.UseVisualStyleBackColor = true;
            btnAnularPago.Click += btnAnularPago_Click;
            // 
            // lblPagos
            // 
            lblPagos.AutoSize = true;
            lblPagos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPagos.Location = new Point(12, 372);
            lblPagos.Name = "lblPagos";
            lblPagos.Size = new Size(186, 15);
            lblPagos.TabIndex = 11;
            lblPagos.Text = "Pagos de la compra seleccionada";
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPagos.BackgroundColor = SystemColors.Window;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(12, 392);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.Size = new Size(960, 170);
            dgvPagos.TabIndex = 12;
            dgvPagos.DataBindingComplete += dgvPagos_DataBindingComplete;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(852, 572);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 30);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmCuentaCorrienteProveedores
            // 
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new Size(984, 614);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 650);
            Name = "frmCuentaCorrienteProveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cuenta corriente de proveedores";
            Load += frmCuentaCorrienteProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            // 
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbProveedor, "Elegí el proveedor para ver sus compras y su saldo.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

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
