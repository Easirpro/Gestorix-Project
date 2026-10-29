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
            lblTitulo = new System.Windows.Forms.Label();
            lblUsuario = new System.Windows.Forms.Label();
            lblFecha = new System.Windows.Forms.Label();
            lblMonto = new System.Windows.Forms.Label();
            nudMontoInicial = new System.Windows.Forms.NumericUpDown();
            lblAyuda = new System.Windows.Forms.Label();
            btnAbrir = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)nudMontoInicial).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new System.Drawing.Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Apertura de caja";
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new System.Drawing.Point(15, 50);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario: -";
            lblUsuario.AutoSize = true;
            // 
            // lblFecha
            // 
            lblFecha.Location = new System.Drawing.Point(15, 75);
            lblFecha.Name = "lblFecha";
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha: -";
            lblFecha.AutoSize = true;
            // 
            // lblMonto
            // 
            lblMonto.Location = new System.Drawing.Point(15, 112);
            lblMonto.Name = "lblMonto";
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Fondo inicial (efectivo):";
            lblMonto.AutoSize = true;
            // 
            // nudMontoInicial
            // 
            nudMontoInicial.Location = new System.Drawing.Point(175, 108);
            nudMontoInicial.Name = "nudMontoInicial";
            nudMontoInicial.Size = new System.Drawing.Size(140, 23);
            nudMontoInicial.TabIndex = 4;
            nudMontoInicial.DecimalPlaces = 2;
            nudMontoInicial.Maximum = new decimal(new int[] { 99999999, 0, 0, 131072 });
            nudMontoInicial.ThousandsSeparator = true;
            nudMontoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAyuda
            // 
            lblAyuda.Location = new System.Drawing.Point(15, 145);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.TabIndex = 5;
            lblAyuda.Text = "Es el cambio con el que arranca la caja.";
            lblAyuda.AutoSize = true;
            lblAyuda.ForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new System.Drawing.Point(95, 180);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new System.Drawing.Size(105, 32);
            btnAbrir.TabIndex = 6;
            btnAbrir.Text = "Abrir caja";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(210, 180);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(105, 32);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmAbrirCaja
            // 
            AcceptButton = btnAbrir;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new System.Drawing.Size(334, 226);
            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(lblFecha);
            Controls.Add(lblMonto);
            Controls.Add(nudMontoInicial);
            Controls.Add(lblAyuda);
            Controls.Add(btnAbrir);
            Controls.Add(btnCancelar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbrirCaja";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
