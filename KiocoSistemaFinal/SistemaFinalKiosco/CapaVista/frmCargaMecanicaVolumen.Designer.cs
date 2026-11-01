namespace CapaVista
{
    partial class frmCargaMecanicaVolumen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaMecanicaVolumen));
            lblCantidadLleva = new Label();
            lblCantidadPaga = new Label();
            lblVistaPrevia = new Label();
            lblLoQueLleva = new Label();
            lblLoQueRecibe = new Label();
            label6 = new Label();
            txtCantidadLleva = new TextBox();
            txtCantidadPaga = new TextBox();
            btnCancelar = new Button();
            btnGuardarMecanica = new Button();
            SuspendLayout();
            // 
            // lblCantidadLleva
            // 
            lblCantidadLleva.AutoSize = true;
            lblCantidadLleva.Location = new Point(23, 68);
            lblCantidadLleva.Name = "lblCantidadLleva";
            lblCantidadLleva.Size = new Size(108, 15);
            lblCantidadLleva.TabIndex = 0;
            lblCantidadLleva.Text = "Cantidad que lleva.";
            // 
            // lblCantidadPaga
            // 
            lblCantidadPaga.AutoSize = true;
            lblCantidadPaga.Location = new Point(216, 68);
            lblCantidadPaga.Name = "lblCantidadPaga";
            lblCantidadPaga.Size = new Size(110, 15);
            lblCantidadPaga.TabIndex = 1;
            lblCantidadPaga.Text = "Cantidad que paga.";
            // 
            // lblVistaPrevia
            // 
            lblVistaPrevia.AutoSize = true;
            lblVistaPrevia.Location = new Point(23, 145);
            lblVistaPrevia.Name = "lblVistaPrevia";
            lblVistaPrevia.Size = new Size(67, 15);
            lblVistaPrevia.TabIndex = 2;
            lblVistaPrevia.Text = "Vista previa";
            // 
            // lblLoQueLleva
            // 
            lblLoQueLleva.AutoSize = true;
            lblLoQueLleva.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoQueLleva.Location = new Point(145, 177);
            lblLoQueLleva.Name = "lblLoQueLleva";
            lblLoQueLleva.Size = new Size(57, 21);
            lblLoQueLleva.TabIndex = 3;
            lblLoQueLleva.Text = "label4";
            // 
            // lblLoQueRecibe
            // 
            lblLoQueRecibe.AutoSize = true;
            lblLoQueRecibe.Location = new Point(154, 214);
            lblLoQueRecibe.Name = "lblLoQueRecibe";
            lblLoQueRecibe.Size = new Size(38, 15);
            lblLoQueRecibe.TabIndex = 4;
            lblLoQueRecibe.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 18);
            label6.Name = "label6";
            label6.Size = new Size(284, 30);
            label6.TabIndex = 5;
            label6.Text = "Agregar mecánica por volumen\nConfigurá una nueva promoción del tipo lleva/paga.";
            // 
            // txtCantidadLleva
            // 
            txtCantidadLleva.Location = new Point(24, 93);
            txtCantidadLleva.Name = "txtCantidadLleva";
            txtCantidadLleva.PlaceholderText = "Ej.: 3 (lleva 3)";
            txtCantidadLleva.Size = new Size(107, 23);
            txtCantidadLleva.TabIndex = 6;
            txtCantidadLleva.TextChanged += txtCantidadLleva_TextChanged;
            // 
            // txtCantidadPaga
            // 
            txtCantidadPaga.Location = new Point(216, 93);
            txtCantidadPaga.Name = "txtCantidadPaga";
            txtCantidadPaga.PlaceholderText = "Ej.: 2 (paga 2)";
            txtCantidadPaga.Size = new Size(107, 23);
            txtCantidadPaga.TabIndex = 7;
            txtCantidadPaga.TextChanged += txtCantidadPaga_TextChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(23, 245);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(128, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardarMecanica
            // 
            btnGuardarMecanica.Location = new Point(195, 245);
            btnGuardarMecanica.Name = "btnGuardarMecanica";
            btnGuardarMecanica.Size = new Size(128, 23);
            btnGuardarMecanica.TabIndex = 9;
            btnGuardarMecanica.Text = "Guardar Mecnica";
            btnGuardarMecanica.UseVisualStyleBackColor = true;
            btnGuardarMecanica.Click += btnGuardarMecanica_Click_1;
            // 
            // frmCargaMecanicaVolumen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 280);
            Controls.Add(btnGuardarMecanica);
            Controls.Add(btnCancelar);
            Controls.Add(txtCantidadPaga);
            Controls.Add(txtCantidadLleva);
            Controls.Add(label6);
            Controls.Add(lblLoQueRecibe);
            Controls.Add(lblLoQueLleva);
            Controls.Add(lblVistaPrevia);
            Controls.Add(lblCantidadPaga);
            Controls.Add(lblCantidadLleva);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCargaMecanicaVolumen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Mecanica de Volumen";
            Load += frmCargaMecanicaVolumen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCantidadLleva;
        private Label lblCantidadPaga;
        private Label lblVistaPrevia;
        private Label lblLoQueLleva;
        private Label lblLoQueRecibe;
        private Label label6;
        private TextBox txtCantidadLleva;
        private TextBox txtCantidadPaga;
        private Button btnCancelar;
        private Button btnGuardarMecanica;
    }
}