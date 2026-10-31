namespace CapaVista
{
    partial class frmCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaja));
            grpEstado = new GroupBox();
            lblEstado = new Label();
            lblAbiertaPor = new Label();
            lblFechaApertura = new Label();
            lblTituloFondo = new Label();
            lblFondo = new Label();
            lblTituloIngresos = new Label();
            lblIngresos = new Label();
            lblTituloEgresos = new Label();
            lblEgresos = new Label();
            lblTituloEsperado = new Label();
            lblEsperado = new Label();
            lblTituloOtros = new Label();
            lblOtrosMedios = new Label();
            btnAbrirCaja = new Button();
            btnNuevoIngreso = new Button();
            btnNuevoEgreso = new Button();
            btnAnularMovimiento = new Button();
            btnCerrarCaja = new Button();
            btnHistorial = new Button();
            btnActualizar = new Button();
            lblMovimientos = new Label();
            dgvMovimientos = new DataGridView();
            btnSalir = new Button();
            grpEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // grpEstado
            // 
            grpEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpEstado.Controls.Add(lblEstado);
            grpEstado.Controls.Add(lblAbiertaPor);
            grpEstado.Controls.Add(lblFechaApertura);
            grpEstado.Controls.Add(lblTituloFondo);
            grpEstado.Controls.Add(lblFondo);
            grpEstado.Controls.Add(lblTituloIngresos);
            grpEstado.Controls.Add(lblIngresos);
            grpEstado.Controls.Add(lblTituloEgresos);
            grpEstado.Controls.Add(lblEgresos);
            grpEstado.Controls.Add(lblTituloEsperado);
            grpEstado.Controls.Add(lblEsperado);
            grpEstado.Controls.Add(lblTituloOtros);
            grpEstado.Controls.Add(lblOtrosMedios);
            grpEstado.Location = new Point(12, 12);
            grpEstado.Name = "grpEstado";
            grpEstado.Size = new Size(960, 120);
            grpEstado.TabIndex = 0;
            grpEstado.TabStop = false;
            grpEstado.Text = "Estado de la caja";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblEstado.Location = new Point(15, 25);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(149, 25);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "CAJA CERRADA";
            // 
            // lblAbiertaPor
            // 
            lblAbiertaPor.AutoSize = true;
            lblAbiertaPor.Location = new Point(15, 60);
            lblAbiertaPor.Name = "lblAbiertaPor";
            lblAbiertaPor.Size = new Size(77, 15);
            lblAbiertaPor.TabIndex = 2;
            lblAbiertaPor.Text = "Abierta por: -";
            // 
            // lblFechaApertura
            // 
            lblFechaApertura.AutoSize = true;
            lblFechaApertura.Location = new Point(15, 85);
            lblFechaApertura.Name = "lblFechaApertura";
            lblFechaApertura.Size = new Size(64, 15);
            lblFechaApertura.TabIndex = 3;
            lblFechaApertura.Text = "Apertura: -";
            // 
            // lblTituloFondo
            // 
            lblTituloFondo.AutoSize = true;
            lblTituloFondo.Location = new Point(330, 25);
            lblTituloFondo.Name = "lblTituloFondo";
            lblTituloFondo.Size = new Size(78, 15);
            lblTituloFondo.TabIndex = 4;
            lblTituloFondo.Text = "Fondo inicial:";
            // 
            // lblFondo
            // 
            lblFondo.AutoSize = true;
            lblFondo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFondo.Location = new Point(480, 25);
            lblFondo.Name = "lblFondo";
            lblFondo.Size = new Size(41, 15);
            lblFondo.TabIndex = 5;
            lblFondo.Text = "$ 0,00";
            // 
            // lblTituloIngresos
            // 
            lblTituloIngresos.AutoSize = true;
            lblTituloIngresos.Location = new Point(330, 50);
            lblTituloIngresos.Name = "lblTituloIngresos";
            lblTituloIngresos.Size = new Size(126, 15);
            lblTituloIngresos.TabIndex = 6;
            lblTituloIngresos.Text = "+ Ingresos en efectivo:";
            // 
            // lblIngresos
            // 
            lblIngresos.AutoSize = true;
            lblIngresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIngresos.Location = new Point(480, 50);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(41, 15);
            lblIngresos.TabIndex = 7;
            lblIngresos.Text = "$ 0,00";
            // 
            // lblTituloEgresos
            // 
            lblTituloEgresos.AutoSize = true;
            lblTituloEgresos.Location = new Point(330, 75);
            lblTituloEgresos.Name = "lblTituloEgresos";
            lblTituloEgresos.Size = new Size(119, 15);
            lblTituloEgresos.TabIndex = 8;
            lblTituloEgresos.Text = "- Egresos en efectivo:";
            // 
            // lblEgresos
            // 
            lblEgresos.AutoSize = true;
            lblEgresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEgresos.Location = new Point(480, 75);
            lblEgresos.Name = "lblEgresos";
            lblEgresos.Size = new Size(41, 15);
            lblEgresos.TabIndex = 9;
            lblEgresos.Text = "$ 0,00";
            // 
            // lblTituloEsperado
            // 
            lblTituloEsperado.AutoSize = true;
            lblTituloEsperado.Location = new Point(640, 25);
            lblTituloEsperado.Name = "lblTituloEsperado";
            lblTituloEsperado.Size = new Size(143, 15);
            lblTituloEsperado.TabIndex = 10;
            lblTituloEsperado.Text = "Efectivo esperado en caja:";
            // 
            // lblEsperado
            // 
            lblEsperado.AutoSize = true;
            lblEsperado.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblEsperado.Location = new Point(640, 48);
            lblEsperado.Name = "lblEsperado";
            lblEsperado.Size = new Size(66, 25);
            lblEsperado.TabIndex = 11;
            lblEsperado.Text = "$ 0,00";
            // 
            // lblTituloOtros
            // 
            lblTituloOtros.AutoSize = true;
            lblTituloOtros.Location = new Point(640, 85);
            lblTituloOtros.Name = "lblTituloOtros";
            lblTituloOtros.Size = new Size(164, 15);
            lblTituloOtros.TabIndex = 12;
            lblTituloOtros.Text = "Otros medios (transf./débito):";
            // 
            // lblOtrosMedios
            // 
            lblOtrosMedios.AutoSize = true;
            lblOtrosMedios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOtrosMedios.Location = new Point(830, 85);
            lblOtrosMedios.Name = "lblOtrosMedios";
            lblOtrosMedios.Size = new Size(41, 15);
            lblOtrosMedios.TabIndex = 13;
            lblOtrosMedios.Text = "$ 0,00";
            // 
            // btnAbrirCaja
            // 
            btnAbrirCaja.Location = new Point(12, 145);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new Size(120, 35);
            btnAbrirCaja.TabIndex = 14;
            btnAbrirCaja.Text = "Abrir caja";
            btnAbrirCaja.UseVisualStyleBackColor = true;
            btnAbrirCaja.Click += btnAbrirCaja_Click;
            // 
            // btnNuevoIngreso
            // 
            btnNuevoIngreso.Location = new Point(138, 145);
            btnNuevoIngreso.Name = "btnNuevoIngreso";
            btnNuevoIngreso.Size = new Size(120, 35);
            btnNuevoIngreso.TabIndex = 15;
            btnNuevoIngreso.Text = "Nuevo ingreso";
            btnNuevoIngreso.UseVisualStyleBackColor = true;
            btnNuevoIngreso.Click += btnNuevoIngreso_Click;
            // 
            // btnNuevoEgreso
            // 
            btnNuevoEgreso.Location = new Point(264, 145);
            btnNuevoEgreso.Name = "btnNuevoEgreso";
            btnNuevoEgreso.Size = new Size(120, 35);
            btnNuevoEgreso.TabIndex = 16;
            btnNuevoEgreso.Text = "Nuevo egreso";
            btnNuevoEgreso.UseVisualStyleBackColor = true;
            btnNuevoEgreso.Click += btnNuevoEgreso_Click;
            // 
            // btnAnularMovimiento
            // 
            btnAnularMovimiento.Location = new Point(390, 145);
            btnAnularMovimiento.Name = "btnAnularMovimiento";
            btnAnularMovimiento.Size = new Size(140, 35);
            btnAnularMovimiento.TabIndex = 17;
            btnAnularMovimiento.Text = "Anular movimiento";
            btnAnularMovimiento.UseVisualStyleBackColor = true;
            btnAnularMovimiento.Click += btnAnularMovimiento_Click;
            // 
            // btnCerrarCaja
            // 
            btnCerrarCaja.Location = new Point(536, 145);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Size = new Size(120, 35);
            btnCerrarCaja.TabIndex = 18;
            btnCerrarCaja.Text = "Cerrar caja";
            btnCerrarCaja.UseVisualStyleBackColor = true;
            btnCerrarCaja.Click += btnCerrarCaja_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHistorial.Location = new Point(726, 145);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(120, 35);
            btnHistorial.TabIndex = 19;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(852, 145);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 35);
            btnActualizar.TabIndex = 20;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // lblMovimientos
            // 
            lblMovimientos.AutoSize = true;
            lblMovimientos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMovimientos.Location = new Point(12, 192);
            lblMovimientos.Name = "lblMovimientos";
            lblMovimientos.Size = new Size(146, 15);
            lblMovimientos.TabIndex = 21;
            lblMovimientos.Text = "Movimientos de la sesión";
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMovimientos.BackgroundColor = SystemColors.Window;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Location = new Point(12, 215);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.Size = new Size(960, 345);
            dgvMovimientos.TabIndex = 22;
            dgvMovimientos.DataBindingComplete += dgvMovimientos_DataBindingComplete;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(852, 570);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 30);
            btnSalir.TabIndex = 23;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmCaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new Size(984, 612);
            Controls.Add(grpEstado);
            Controls.Add(btnAbrirCaja);
            Controls.Add(btnNuevoIngreso);
            Controls.Add(btnNuevoEgreso);
            Controls.Add(btnAnularMovimiento);
            Controls.Add(btnCerrarCaja);
            Controls.Add(btnHistorial);
            Controls.Add(btnActualizar);
            Controls.Add(lblMovimientos);
            Controls.Add(dgvMovimientos);
            Controls.Add(btnSalir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 650);
            Name = "frmCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caja";
            Load += frmCaja_Load;
            grpEstado.ResumeLayout(false);
            grpEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblAbiertaPor;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.Label lblTituloFondo;
        private System.Windows.Forms.Label lblFondo;
        private System.Windows.Forms.Label lblTituloIngresos;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label lblTituloEgresos;
        private System.Windows.Forms.Label lblEgresos;
        private System.Windows.Forms.Label lblTituloEsperado;
        private System.Windows.Forms.Label lblEsperado;
        private System.Windows.Forms.Label lblTituloOtros;
        private System.Windows.Forms.Label lblOtrosMedios;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.Button btnNuevoIngreso;
        private System.Windows.Forms.Button btnNuevoEgreso;
        private System.Windows.Forms.Button btnAnularMovimiento;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblMovimientos;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Button btnSalir;
    }
}
