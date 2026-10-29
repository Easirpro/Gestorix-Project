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
            grpEstado = new System.Windows.Forms.GroupBox();
            lblEstado = new System.Windows.Forms.Label();
            lblAbiertaPor = new System.Windows.Forms.Label();
            lblFechaApertura = new System.Windows.Forms.Label();
            lblTituloFondo = new System.Windows.Forms.Label();
            lblFondo = new System.Windows.Forms.Label();
            lblTituloIngresos = new System.Windows.Forms.Label();
            lblIngresos = new System.Windows.Forms.Label();
            lblTituloEgresos = new System.Windows.Forms.Label();
            lblEgresos = new System.Windows.Forms.Label();
            lblTituloEsperado = new System.Windows.Forms.Label();
            lblEsperado = new System.Windows.Forms.Label();
            lblTituloOtros = new System.Windows.Forms.Label();
            lblOtrosMedios = new System.Windows.Forms.Label();
            btnAbrirCaja = new System.Windows.Forms.Button();
            btnNuevoIngreso = new System.Windows.Forms.Button();
            btnNuevoEgreso = new System.Windows.Forms.Button();
            btnAnularMovimiento = new System.Windows.Forms.Button();
            btnCerrarCaja = new System.Windows.Forms.Button();
            btnHistorial = new System.Windows.Forms.Button();
            btnActualizar = new System.Windows.Forms.Button();
            lblMovimientos = new System.Windows.Forms.Label();
            dgvMovimientos = new System.Windows.Forms.DataGridView();
            btnSalir = new System.Windows.Forms.Button();
            grpEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // grpEstado
            // 
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
            grpEstado.Location = new System.Drawing.Point(12, 12);
            grpEstado.Name = "grpEstado";
            grpEstado.Size = new System.Drawing.Size(960, 120);
            grpEstado.TabIndex = 0;
            grpEstado.Text = "Estado de la caja";
            grpEstado.TabStop = false;
            grpEstado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // lblEstado
            // 
            lblEstado.Location = new System.Drawing.Point(15, 25);
            lblEstado.Name = "lblEstado";
            lblEstado.TabIndex = 1;
            lblEstado.Text = "CAJA CERRADA";
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            // 
            // lblAbiertaPor
            // 
            lblAbiertaPor.Location = new System.Drawing.Point(15, 60);
            lblAbiertaPor.Name = "lblAbiertaPor";
            lblAbiertaPor.TabIndex = 2;
            lblAbiertaPor.Text = "Abierta por: -";
            lblAbiertaPor.AutoSize = true;
            // 
            // lblFechaApertura
            // 
            lblFechaApertura.Location = new System.Drawing.Point(15, 85);
            lblFechaApertura.Name = "lblFechaApertura";
            lblFechaApertura.TabIndex = 3;
            lblFechaApertura.Text = "Apertura: -";
            lblFechaApertura.AutoSize = true;
            // 
            // lblTituloFondo
            // 
            lblTituloFondo.Location = new System.Drawing.Point(330, 25);
            lblTituloFondo.Name = "lblTituloFondo";
            lblTituloFondo.TabIndex = 4;
            lblTituloFondo.Text = "Fondo inicial:";
            lblTituloFondo.AutoSize = true;
            // 
            // lblFondo
            // 
            lblFondo.Location = new System.Drawing.Point(480, 25);
            lblFondo.Name = "lblFondo";
            lblFondo.TabIndex = 5;
            lblFondo.Text = "$ 0,00";
            lblFondo.AutoSize = true;
            lblFondo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblTituloIngresos
            // 
            lblTituloIngresos.Location = new System.Drawing.Point(330, 50);
            lblTituloIngresos.Name = "lblTituloIngresos";
            lblTituloIngresos.TabIndex = 6;
            lblTituloIngresos.Text = "+ Ingresos en efectivo:";
            lblTituloIngresos.AutoSize = true;
            // 
            // lblIngresos
            // 
            lblIngresos.Location = new System.Drawing.Point(480, 50);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.TabIndex = 7;
            lblIngresos.Text = "$ 0,00";
            lblIngresos.AutoSize = true;
            lblIngresos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblTituloEgresos
            // 
            lblTituloEgresos.Location = new System.Drawing.Point(330, 75);
            lblTituloEgresos.Name = "lblTituloEgresos";
            lblTituloEgresos.TabIndex = 8;
            lblTituloEgresos.Text = "- Egresos en efectivo:";
            lblTituloEgresos.AutoSize = true;
            // 
            // lblEgresos
            // 
            lblEgresos.Location = new System.Drawing.Point(480, 75);
            lblEgresos.Name = "lblEgresos";
            lblEgresos.TabIndex = 9;
            lblEgresos.Text = "$ 0,00";
            lblEgresos.AutoSize = true;
            lblEgresos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblTituloEsperado
            // 
            lblTituloEsperado.Location = new System.Drawing.Point(640, 25);
            lblTituloEsperado.Name = "lblTituloEsperado";
            lblTituloEsperado.TabIndex = 10;
            lblTituloEsperado.Text = "Efectivo esperado en caja:";
            lblTituloEsperado.AutoSize = true;
            // 
            // lblEsperado
            // 
            lblEsperado.Location = new System.Drawing.Point(640, 48);
            lblEsperado.Name = "lblEsperado";
            lblEsperado.TabIndex = 11;
            lblEsperado.Text = "$ 0,00";
            lblEsperado.AutoSize = true;
            lblEsperado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            // 
            // lblTituloOtros
            // 
            lblTituloOtros.Location = new System.Drawing.Point(640, 85);
            lblTituloOtros.Name = "lblTituloOtros";
            lblTituloOtros.TabIndex = 12;
            lblTituloOtros.Text = "Otros medios (transf./débito):";
            lblTituloOtros.AutoSize = true;
            // 
            // lblOtrosMedios
            // 
            lblOtrosMedios.Location = new System.Drawing.Point(830, 85);
            lblOtrosMedios.Name = "lblOtrosMedios";
            lblOtrosMedios.TabIndex = 13;
            lblOtrosMedios.Text = "$ 0,00";
            lblOtrosMedios.AutoSize = true;
            lblOtrosMedios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // btnAbrirCaja
            // 
            btnAbrirCaja.Location = new System.Drawing.Point(12, 145);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new System.Drawing.Size(120, 35);
            btnAbrirCaja.TabIndex = 14;
            btnAbrirCaja.Text = "Abrir caja";
            btnAbrirCaja.UseVisualStyleBackColor = true;
            btnAbrirCaja.Click += btnAbrirCaja_Click;
            // 
            // btnNuevoIngreso
            // 
            btnNuevoIngreso.Location = new System.Drawing.Point(138, 145);
            btnNuevoIngreso.Name = "btnNuevoIngreso";
            btnNuevoIngreso.Size = new System.Drawing.Size(120, 35);
            btnNuevoIngreso.TabIndex = 15;
            btnNuevoIngreso.Text = "Nuevo ingreso";
            btnNuevoIngreso.UseVisualStyleBackColor = true;
            btnNuevoIngreso.Click += btnNuevoIngreso_Click;
            // 
            // btnNuevoEgreso
            // 
            btnNuevoEgreso.Location = new System.Drawing.Point(264, 145);
            btnNuevoEgreso.Name = "btnNuevoEgreso";
            btnNuevoEgreso.Size = new System.Drawing.Size(120, 35);
            btnNuevoEgreso.TabIndex = 16;
            btnNuevoEgreso.Text = "Nuevo egreso";
            btnNuevoEgreso.UseVisualStyleBackColor = true;
            btnNuevoEgreso.Click += btnNuevoEgreso_Click;
            // 
            // btnAnularMovimiento
            // 
            btnAnularMovimiento.Location = new System.Drawing.Point(390, 145);
            btnAnularMovimiento.Name = "btnAnularMovimiento";
            btnAnularMovimiento.Size = new System.Drawing.Size(140, 35);
            btnAnularMovimiento.TabIndex = 17;
            btnAnularMovimiento.Text = "Anular movimiento";
            btnAnularMovimiento.UseVisualStyleBackColor = true;
            btnAnularMovimiento.Click += btnAnularMovimiento_Click;
            // 
            // btnCerrarCaja
            // 
            btnCerrarCaja.Location = new System.Drawing.Point(536, 145);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Size = new System.Drawing.Size(120, 35);
            btnCerrarCaja.TabIndex = 18;
            btnCerrarCaja.Text = "Cerrar caja";
            btnCerrarCaja.UseVisualStyleBackColor = true;
            btnCerrarCaja.Click += btnCerrarCaja_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Location = new System.Drawing.Point(726, 145);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new System.Drawing.Size(120, 35);
            btnHistorial.TabIndex = 19;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new System.Drawing.Point(852, 145);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new System.Drawing.Size(120, 35);
            btnActualizar.TabIndex = 20;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // lblMovimientos
            // 
            lblMovimientos.Location = new System.Drawing.Point(12, 192);
            lblMovimientos.Name = "lblMovimientos";
            lblMovimientos.TabIndex = 21;
            lblMovimientos.Text = "Movimientos de la sesión";
            lblMovimientos.AutoSize = true;
            lblMovimientos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.Location = new System.Drawing.Point(12, 215);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new System.Drawing.Size(960, 345);
            dgvMovimientos.TabIndex = 22;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvMovimientos.DataBindingComplete += dgvMovimientos_DataBindingComplete;
            // 
            // btnSalir
            // 
            btnSalir.Location = new System.Drawing.Point(852, 570);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(120, 30);
            btnSalir.TabIndex = 23;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmCaja
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new System.Drawing.Size(984, 612);
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
            MinimumSize = new System.Drawing.Size(1000, 650);
            Name = "frmCaja";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Caja";
            Load += frmCaja_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            grpEstado.ResumeLayout(false);
            grpEstado.PerformLayout();
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
