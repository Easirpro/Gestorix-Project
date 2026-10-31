namespace CapaVista
{
    partial class frmAbrirCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbrirCaja));
            lblTitulo = new Label();
            lblUsuario = new Label();
            lblFecha = new Label();
            lblMonto = new Label();
            nudMontoInicial = new NumericUpDown();
            lblAyuda = new Label();
            btnAbrir = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudMontoInicial).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(124, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Apertura de caja";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(15, 50);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(58, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario: -";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(15, 75);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(49, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha: -";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(15, 112);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(131, 15);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Fondo inicial (efectivo):";
            // 
            // nudMontoInicial
            // 
            nudMontoInicial.DecimalPlaces = 2;
            nudMontoInicial.Location = new Point(175, 108);
            nudMontoInicial.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudMontoInicial.Name = "nudMontoInicial";
            nudMontoInicial.Size = new Size(140, 23);
            nudMontoInicial.TabIndex = 4;
            nudMontoInicial.TextAlign = HorizontalAlignment.Right;
            nudMontoInicial.ThousandsSeparator = true;
            // 
            // lblAyuda
            // 
            lblAyuda.AutoSize = true;
            lblAyuda.ForeColor = SystemColors.GrayText;
            lblAyuda.Location = new Point(15, 145);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(212, 15);
            lblAyuda.TabIndex = 5;
            lblAyuda.Text = "Es el cambio con el que arranca la caja.";
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(95, 180);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(105, 32);
            btnAbrir.TabIndex = 6;
            btnAbrir.Text = "Abrir caja";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(210, 180);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 32);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmAbrirCaja
            // 
            AcceptButton = btnAbrir;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(334, 226);
            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(lblFecha);
            Controls.Add(lblMonto);
            Controls.Add(nudMontoInicial);
            Controls.Add(lblAyuda);
            Controls.Add(btnAbrir);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbrirCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Abrir caja";
            Load += frmAbrirCaja_Load;
            ((System.ComponentModel.ISupportInitialize)nudMontoInicial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown nudMontoInicial;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnCancelar;
    }
}
