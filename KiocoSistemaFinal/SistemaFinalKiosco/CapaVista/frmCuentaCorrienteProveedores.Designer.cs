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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentaCorrienteProveedores));
            btnNuevoPago = new Button();
            label1 = new Label();
            txtBuscarProveedor = new TextBox();
            btnCambiarProveedor = new Button();
            btnActualizar = new Button();
            dgvCuentaCorriente = new DataGridView();
            clmFechaHora = new DataGridViewTextBoxColumn();
            clmCajero = new DataGridViewTextBoxColumn();
            clmConcepto = new DataGridViewTextBoxColumn();
            clmCreditos = new DataGridViewTextBoxColumn();
            clmDebito = new DataGridViewTextBoxColumn();
            clmSaldo = new DataGridViewTextBoxColumn();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCuentaCorriente).BeginInit();
            SuspendLayout();
            // 
            // btnNuevoPago
            // 
            btnNuevoPago.Image = (Image)resources.GetObject("btnNuevoPago.Image");
            btnNuevoPago.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevoPago.Location = new Point(22, 26);
            btnNuevoPago.Name = "btnNuevoPago";
            btnNuevoPago.Size = new Size(101, 32);
            btnNuevoPago.TabIndex = 0;
            btnNuevoPago.Text = "Nuevo pago";
            btnNuevoPago.TextAlign = ContentAlignment.MiddleRight;
            btnNuevoPago.UseVisualStyleBackColor = true;
            btnNuevoPago.Click += btnNuevoPago_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 35);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 1;
            label1.Text = "Proveedor:";
            // 
            // txtBuscarProveedor
            // 
            txtBuscarProveedor.Location = new Point(208, 31);
            txtBuscarProveedor.Name = "txtBuscarProveedor";
            txtBuscarProveedor.Size = new Size(194, 23);
            txtBuscarProveedor.TabIndex = 2;
            // 
            // btnCambiarProveedor
            // 
            btnCambiarProveedor.Image = (Image)resources.GetObject("btnCambiarProveedor.Image");
            btnCambiarProveedor.ImageAlign = ContentAlignment.MiddleLeft;
            btnCambiarProveedor.Location = new Point(415, 26);
            btnCambiarProveedor.Name = "btnCambiarProveedor";
            btnCambiarProveedor.Size = new Size(147, 32);
            btnCambiarProveedor.TabIndex = 3;
            btnCambiarProveedor.Text = "Cambiar Proveedor";
            btnCambiarProveedor.TextAlign = ContentAlignment.MiddleRight;
            btnCambiarProveedor.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.Location = new Point(576, 25);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 32);
            btnActualizar.TabIndex = 4;
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // dgvCuentaCorriente
            // 
            dgvCuentaCorriente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentaCorriente.Columns.AddRange(new DataGridViewColumn[] { clmFechaHora, clmCajero, clmConcepto, clmCreditos, clmDebito, clmSaldo });
            dgvCuentaCorriente.Location = new Point(22, 78);
            dgvCuentaCorriente.Name = "dgvCuentaCorriente";
            dgvCuentaCorriente.Size = new Size(629, 268);
            dgvCuentaCorriente.TabIndex = 5;
            // 
            // clmFechaHora
            // 
            clmFechaHora.HeaderText = "Fecha/Hora";
            clmFechaHora.Name = "clmFechaHora";
            // 
            // clmCajero
            // 
            clmCajero.HeaderText = "Cajero";
            clmCajero.Name = "clmCajero";
            // 
            // clmConcepto
            // 
            clmConcepto.HeaderText = "Concepto";
            clmConcepto.Name = "clmConcepto";
            // 
            // clmCreditos
            // 
            clmCreditos.HeaderText = "Creditos";
            clmCreditos.Name = "clmCreditos";
            // 
            // clmDebito
            // 
            clmDebito.HeaderText = "Debito";
            clmDebito.Name = "clmDebito";
            // 
            // clmSaldo
            // 
            clmSaldo.HeaderText = "Saldo";
            clmSaldo.Name = "clmSaldo";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(576, 387);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // frmCuentaCorrienteProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 445);
            Controls.Add(btnVolver);
            Controls.Add(dgvCuentaCorriente);
            Controls.Add(btnActualizar);
            Controls.Add(btnCambiarProveedor);
            Controls.Add(txtBuscarProveedor);
            Controls.Add(label1);
            Controls.Add(btnNuevoPago);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCuentaCorrienteProveedores";
            Text = "Cuenta Corriente de Proveedores";
            ((System.ComponentModel.ISupportInitialize)dgvCuentaCorriente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevoPago;
        private Label label1;
        private TextBox txtBuscarProveedor;
        private Button btnCambiarProveedor;
        private Button btnActualizar;
        private DataGridView dgvCuentaCorriente;
        private DataGridViewTextBoxColumn clmFechaHora;
        private DataGridViewTextBoxColumn clmCajero;
        private DataGridViewTextBoxColumn clmConcepto;
        private DataGridViewTextBoxColumn clmCreditos;
        private DataGridViewTextBoxColumn clmDebito;
        private DataGridViewTextBoxColumn clmSaldo;
        private Button btnVolver;
    }
}