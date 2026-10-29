namespace CapaVista
{
    partial class frmCerrarCaja
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
            grpResumen = new System.Windows.Forms.GroupBox();
            lblTituloFondo = new System.Windows.Forms.Label();
            lblFondo = new System.Windows.Forms.Label();
            lblTituloIngresos = new System.Windows.Forms.Label();
            lblIngresos = new System.Windows.Forms.Label();
            lblTituloEgresos = new System.Windows.Forms.Label();
            lblEgresos = new System.Windows.Forms.Label();
            lblTituloEsperado = new System.Windows.Forms.Label();
            lblEsperado = new System.Windows.Forms.Label();
            lblContado = new System.Windows.Forms.Label();
            nudEfectivoContado = new System.Windows.Forms.NumericUpDown();
            lblTituloDiferencia = new System.Windows.Forms.Label();
            lblDiferencia = new System.Windows.Forms.Label();
            lblObservacion = new System.Windows.Forms.Label();
            txtObservacion = new System.Windows.Forms.TextBox();
            btnCerrar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            grpResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEfectivoContado).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new System.Drawing.Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cierre de caja - Arqueo";
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // grpResumen
            // 
            grpResumen.Controls.Add(lblTituloFondo);
            grpResumen.Controls.Add(lblFondo);
            grpResumen.Controls.Add(lblTituloIngresos);
            grpResumen.Controls.Add(lblIngresos);
            grpResumen.Controls.Add(lblTituloEgresos);
            grpResumen.Controls.Add(lblEgresos);
            grpResumen.Controls.Add(lblTituloEsperado);
            grpResumen.Controls.Add(lblEsperado);
            grpResumen.Location = new System.Drawing.Point(15, 45);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new System.Drawing.Size(370, 130);
            grpResumen.TabIndex = 1;
            grpResumen.Text = "Según el sistema";
            grpResumen.TabStop = false;
            // 
            // lblTituloFondo
            // 
            lblTituloFondo.Location = new System.Drawing.Point(15, 25);
            lblTituloFondo.Name = "lblTituloFondo";
            lblTituloFondo.TabIndex = 2;
            lblTituloFondo.Text = "Fondo inicial:";
            lblTituloFondo.AutoSize = true;
            // 
            // lblFondo
            // 
            lblFondo.Location = new System.Drawing.Point(230, 25);
            lblFondo.Name = "lblFondo";
            lblFondo.TabIndex = 3;
            lblFondo.Text = "$ 0,00";
            lblFondo.AutoSize = true;
            lblFondo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblTituloIngresos
            // 
            lblTituloIngresos.Location = new System.Drawing.Point(15, 50);
            lblTituloIngresos.Name = "lblTituloIngresos";
            lblTituloIngresos.TabIndex = 4;
            lblTituloIngresos.Text = "+ Ingresos en efectivo:";
            lblTituloIngresos.AutoSize = true;
            // 
            // lblIngresos
            // 
            lblIngresos.Location = new System.Drawing.Point(230, 50);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.TabIndex = 5;
            lblIngresos.Text = "$ 0,00";
            lblIngresos.AutoSize = true;
            lblIngresos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblTituloEgresos
            // 
            lblTituloEgresos.Location = new System.Drawing.Point(15, 75);
            lblTituloEgresos.Name = "lblTituloEgresos";
            lblTituloEgresos.TabIndex = 6;
            lblTituloEgresos.Text = "- Egresos en efectivo:";
            lblTituloEgresos.AutoSize = true;
            // 
            // lblEgresos
            // 
            lblEgresos.Location = new System.Drawing.Point(230, 75);
            lblEgresos.Name = "lblEgresos";
            lblEgresos.TabIndex = 7;
            lblEgresos.Text = "$ 0,00";
            lblEgresos.AutoSize = true;
            lblEgresos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblTituloEsperado
            // 
            lblTituloEsperado.Location = new System.Drawing.Point(15, 100);
            lblTituloEsperado.Name = "lblTituloEsperado";
            lblTituloEsperado.TabIndex = 8;
            lblTituloEsperado.Text = "= Efectivo esperado:";
            lblTituloEsperado.AutoSize = true;
            lblTituloEsperado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblEsperado
            // 
            lblEsperado.Location = new System.Drawing.Point(230, 100);
            lblEsperado.Name = "lblEsperado";
            lblEsperado.TabIndex = 9;
            lblEsperado.Text = "$ 0,00";
            lblEsperado.AutoSize = true;
            lblEsperado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // 
            // lblContado
            // 
            lblContado.Location = new System.Drawing.Point(15, 192);
            lblContado.Name = "lblContado";
            lblContado.TabIndex = 10;
            lblContado.Text = "Efectivo contado:";
            lblContado.AutoSize = true;
            // 
            // nudEfectivoContado
            // 
            nudEfectivoContado.Location = new System.Drawing.Point(245, 188);
            nudEfectivoContado.Name = "nudEfectivoContado";
            nudEfectivoContado.Size = new System.Drawing.Size(140, 23);
            nudEfectivoContado.TabIndex = 11;
            nudEfectivoContado.DecimalPlaces = 2;
            nudEfectivoContado.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudEfectivoContado.ThousandsSeparator = true;
            nudEfectivoContado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudEfectivoContado.ValueChanged += nudEfectivoContado_ValueChanged;
            // 
            // lblTituloDiferencia
            // 
            lblTituloDiferencia.Location = new System.Drawing.Point(15, 225);
            lblTituloDiferencia.Name = "lblTituloDiferencia";
            lblTituloDiferencia.TabIndex = 12;
            lblTituloDiferencia.Text = "Diferencia:";
            lblTituloDiferencia.AutoSize = true;
            // 
            // lblDiferencia
            // 
            lblDiferencia.Location = new System.Drawing.Point(245, 222);
            lblDiferencia.Name = "lblDiferencia";
            lblDiferencia.TabIndex = 13;
            lblDiferencia.Text = "$ 0,00";
            lblDiferencia.AutoSize = true;
            lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblObservacion
            // 
            lblObservacion.Location = new System.Drawing.Point(15, 260);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.TabIndex = 14;
            lblObservacion.Text = "Observación (obligatoria si hay diferencia):";
            lblObservacion.AutoSize = true;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new System.Drawing.Point(15, 280);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new System.Drawing.Size(370, 55);
            txtObservacion.TabIndex = 15;
            txtObservacion.Multiline = true;
            txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtObservacion.MaxLength = 255;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new System.Drawing.Point(165, 350);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(105, 32);
            btnCerrar.TabIndex = 16;
            btnCerrar.Text = "Cerrar caja";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(280, 350);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(105, 32);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmCerrarCaja
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new System.Drawing.Size(400, 396);
            Controls.Add(lblTitulo);
            Controls.Add(grpResumen);
            Controls.Add(lblContado);
            Controls.Add(nudEfectivoContado);
            Controls.Add(lblTituloDiferencia);
            Controls.Add(lblDiferencia);
            Controls.Add(lblObservacion);
            Controls.Add(txtObservacion);
            Controls.Add(btnCerrar);
            Controls.Add(btnCancelar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCerrarCaja";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cerrar caja";
            Load += frmCerrarCaja_Load;
            ((System.ComponentModel.ISupportInitialize)nudEfectivoContado).EndInit();
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpResumen;
        private System.Windows.Forms.Label lblTituloFondo;
        private System.Windows.Forms.Label lblFondo;
        private System.Windows.Forms.Label lblTituloIngresos;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label lblTituloEgresos;
        private System.Windows.Forms.Label lblEgresos;
        private System.Windows.Forms.Label lblTituloEsperado;
        private System.Windows.Forms.Label lblEsperado;
        private System.Windows.Forms.Label lblContado;
        private System.Windows.Forms.NumericUpDown nudEfectivoContado;
        private System.Windows.Forms.Label lblTituloDiferencia;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
