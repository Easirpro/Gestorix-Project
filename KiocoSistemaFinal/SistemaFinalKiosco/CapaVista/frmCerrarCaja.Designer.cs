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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCerrarCaja));
            lblTitulo = new Label();
            grpResumen = new GroupBox();
            lblTituloFondo = new Label();
            lblFondo = new Label();
            lblTituloIngresos = new Label();
            lblIngresos = new Label();
            lblTituloEgresos = new Label();
            lblEgresos = new Label();
            lblTituloEsperado = new Label();
            lblEsperado = new Label();
            lblContado = new Label();
            nudEfectivoContado = new NumericUpDown();
            lblTituloDiferencia = new Label();
            lblDiferencia = new Label();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            btnCerrar = new Button();
            btnCancelar = new Button();
            grpResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEfectivoContado).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(168, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cierre de caja - Arqueo";
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
            grpResumen.Location = new Point(15, 45);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(370, 130);
            grpResumen.TabIndex = 1;
            grpResumen.TabStop = false;
            grpResumen.Text = "Según el sistema";
            // 
            // lblTituloFondo
            // 
            lblTituloFondo.AutoSize = true;
            lblTituloFondo.Location = new Point(15, 25);
            lblTituloFondo.Name = "lblTituloFondo";
            lblTituloFondo.Size = new Size(78, 15);
            lblTituloFondo.TabIndex = 2;
            lblTituloFondo.Text = "Fondo inicial:";
            // 
            // lblFondo
            // 
            lblFondo.AutoSize = true;
            lblFondo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFondo.Location = new Point(230, 25);
            lblFondo.Name = "lblFondo";
            lblFondo.Size = new Size(41, 15);
            lblFondo.TabIndex = 3;
            lblFondo.Text = "$ 0,00";
            // 
            // lblTituloIngresos
            // 
            lblTituloIngresos.AutoSize = true;
            lblTituloIngresos.Location = new Point(15, 50);
            lblTituloIngresos.Name = "lblTituloIngresos";
            lblTituloIngresos.Size = new Size(126, 15);
            lblTituloIngresos.TabIndex = 4;
            lblTituloIngresos.Text = "+ Ingresos en efectivo:";
            // 
            // lblIngresos
            // 
            lblIngresos.AutoSize = true;
            lblIngresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIngresos.Location = new Point(230, 50);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(41, 15);
            lblIngresos.TabIndex = 5;
            lblIngresos.Text = "$ 0,00";
            // 
            // lblTituloEgresos
            // 
            lblTituloEgresos.AutoSize = true;
            lblTituloEgresos.Location = new Point(15, 75);
            lblTituloEgresos.Name = "lblTituloEgresos";
            lblTituloEgresos.Size = new Size(119, 15);
            lblTituloEgresos.TabIndex = 6;
            lblTituloEgresos.Text = "- Egresos en efectivo:";
            // 
            // lblEgresos
            // 
            lblEgresos.AutoSize = true;
            lblEgresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEgresos.Location = new Point(230, 75);
            lblEgresos.Name = "lblEgresos";
            lblEgresos.Size = new Size(41, 15);
            lblEgresos.TabIndex = 7;
            lblEgresos.Text = "$ 0,00";
            // 
            // lblTituloEsperado
            // 
            lblTituloEsperado.AutoSize = true;
            lblTituloEsperado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloEsperado.Location = new Point(15, 100);
            lblTituloEsperado.Name = "lblTituloEsperado";
            lblTituloEsperado.Size = new Size(121, 15);
            lblTituloEsperado.TabIndex = 8;
            lblTituloEsperado.Text = "= Efectivo esperado:";
            // 
            // lblEsperado
            // 
            lblEsperado.AutoSize = true;
            lblEsperado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEsperado.Location = new Point(230, 100);
            lblEsperado.Name = "lblEsperado";
            lblEsperado.Size = new Size(41, 15);
            lblEsperado.TabIndex = 9;
            lblEsperado.Text = "$ 0,00";
            // 
            // lblContado
            // 
            lblContado.AutoSize = true;
            lblContado.Location = new Point(15, 192);
            lblContado.Name = "lblContado";
            lblContado.Size = new Size(99, 15);
            lblContado.TabIndex = 10;
            lblContado.Text = "Efectivo contado:";
            // 
            // nudEfectivoContado
            // 
            nudEfectivoContado.DecimalPlaces = 2;
            nudEfectivoContado.Location = new Point(245, 188);
            nudEfectivoContado.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudEfectivoContado.Name = "nudEfectivoContado";
            nudEfectivoContado.Size = new Size(140, 23);
            nudEfectivoContado.TabIndex = 11;
            nudEfectivoContado.TextAlign = HorizontalAlignment.Right;
            nudEfectivoContado.ThousandsSeparator = true;
            nudEfectivoContado.ValueChanged += nudEfectivoContado_ValueChanged;
            // 
            // lblTituloDiferencia
            // 
            lblTituloDiferencia.AutoSize = true;
            lblTituloDiferencia.Location = new Point(15, 225);
            lblTituloDiferencia.Name = "lblTituloDiferencia";
            lblTituloDiferencia.Size = new Size(63, 15);
            lblTituloDiferencia.TabIndex = 12;
            lblTituloDiferencia.Text = "Diferencia:";
            // 
            // lblDiferencia
            // 
            lblDiferencia.AutoSize = true;
            lblDiferencia.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDiferencia.Location = new Point(245, 222);
            lblDiferencia.Name = "lblDiferencia";
            lblDiferencia.Size = new Size(53, 20);
            lblDiferencia.TabIndex = 13;
            lblDiferencia.Text = "$ 0,00";
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(15, 260);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(232, 15);
            lblObservacion.TabIndex = 14;
            lblObservacion.Text = "Observación (obligatoria si hay diferencia):";
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(15, 280);
            txtObservacion.MaxLength = 255;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.PlaceholderText = "Si lo contado no coincide con lo esperado, explicá por qué";
            txtObservacion.ScrollBars = ScrollBars.Vertical;
            txtObservacion.Size = new Size(370, 55);
            txtObservacion.TabIndex = 15;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(165, 350);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(105, 32);
            btnCerrar.TabIndex = 16;
            btnCerrar.Text = "Cerrar caja";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(280, 350);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 32);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmCerrarCaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(400, 396);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCerrarCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cerrar caja";
            Load += frmCerrarCaja_Load;
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEfectivoContado).EndInit();
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
