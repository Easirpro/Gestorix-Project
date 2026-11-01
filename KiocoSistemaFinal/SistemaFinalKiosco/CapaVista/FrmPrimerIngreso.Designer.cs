namespace CapaVista
{
    partial class FrmPrimerIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrimerIngreso));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCambiarPass = new Button();
            txtPassTemporal = new TextBox();
            txtNuevaPass = new TextBox();
            txtConfirmarPass = new TextBox();
            lblMinimo = new Label();
            lblMayuscula = new Label();
            lblMinuscula = new Label();
            lblNumero = new Label();
            lblCoincide = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 46);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 0;
            label1.Text = "Contraseña temporal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 109);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 1;
            label2.Text = "Nueva contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(82, 233);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 2;
            label3.Text = "Confirmar contraseña";
            // 
            // btnCambiarPass
            // 
            btnCambiarPass.Location = new Point(82, 311);
            btnCambiarPass.Name = "btnCambiarPass";
            btnCambiarPass.Size = new Size(122, 23);
            btnCambiarPass.TabIndex = 3;
            btnCambiarPass.Text = "Cambiar contraseña";
            btnCambiarPass.UseVisualStyleBackColor = true;
            btnCambiarPass.Click += btnCambiarPass_Click;
            // 
            // txtPassTemporal
            // 
            txtPassTemporal.Location = new Point(84, 64);
            txtPassTemporal.Name = "txtPassTemporal";
            txtPassTemporal.PlaceholderText = "La que te llegó por correo";
            txtPassTemporal.Size = new Size(120, 23);
            txtPassTemporal.TabIndex = 4;
            // 
            // txtNuevaPass
            // 
            txtNuevaPass.Location = new Point(84, 127);
            txtNuevaPass.Name = "txtNuevaPass";
            txtNuevaPass.PlaceholderText = "Tu nueva contraseña";
            txtNuevaPass.Size = new Size(120, 23);
            txtNuevaPass.TabIndex = 5;
            txtNuevaPass.TextChanged += txtNuevaPass_TextChanged;
            // 
            // txtConfirmarPass
            // 
            txtConfirmarPass.Location = new Point(84, 253);
            txtConfirmarPass.Name = "txtConfirmarPass";
            txtConfirmarPass.PlaceholderText = "Repetí la nueva contraseña";
            txtConfirmarPass.Size = new Size(120, 23);
            txtConfirmarPass.TabIndex = 6;
            txtConfirmarPass.TextChanged += txtConfirmarPass_TextChanged;
            // 
            // lblMinimo
            // 
            lblMinimo.AutoSize = true;
            lblMinimo.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMinimo.ForeColor = Color.Red;
            lblMinimo.Location = new Point(84, 162);
            lblMinimo.Name = "lblMinimo";
            lblMinimo.Size = new Size(87, 12);
            lblMinimo.TabIndex = 7;
            lblMinimo.Text = "Maximo 8 caracteres";
            // 
            // lblMayuscula
            // 
            lblMayuscula.AutoSize = true;
            lblMayuscula.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMayuscula.ForeColor = Color.Red;
            lblMayuscula.Location = new Point(84, 177);
            lblMayuscula.Name = "lblMayuscula";
            lblMayuscula.Size = new Size(65, 12);
            lblMayuscula.TabIndex = 8;
            lblMayuscula.Text = "Una Mayúscula";
            // 
            // lblMinuscula
            // 
            lblMinuscula.AutoSize = true;
            lblMinuscula.Font = new Font("Segoe UI", 7F);
            lblMinuscula.ForeColor = Color.Red;
            lblMinuscula.Location = new Point(84, 192);
            lblMinuscula.Name = "lblMinuscula";
            lblMinuscula.Size = new Size(71, 12);
            lblMinuscula.TabIndex = 9;
            lblMinuscula.Text = "Una Minúscula";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI", 7F);
            lblNumero.ForeColor = Color.Red;
            lblNumero.Location = new Point(84, 208);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(57, 12);
            lblNumero.TabIndex = 10;
            lblNumero.Text = "Un Numero";
            // 
            // lblCoincide
            // 
            lblCoincide.AutoSize = true;
            lblCoincide.Font = new Font("Segoe UI", 7F);
            lblCoincide.ForeColor = Color.Red;
            lblCoincide.Location = new Point(84, 287);
            lblCoincide.Name = "lblCoincide";
            lblCoincide.Size = new Size(120, 12);
            lblCoincide.TabIndex = 11;
            lblCoincide.Text = "Las contraseñas coinciden";
            // 
            // FrmPrimerIngreso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 364);
            Controls.Add(lblCoincide);
            Controls.Add(lblNumero);
            Controls.Add(lblMinuscula);
            Controls.Add(lblMayuscula);
            Controls.Add(lblMinimo);
            Controls.Add(txtConfirmarPass);
            Controls.Add(txtNuevaPass);
            Controls.Add(txtPassTemporal);
            Controls.Add(btnCambiarPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPrimerIngreso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Primer Ingreso";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCambiarPass;
        private TextBox txtPassTemporal;
        private TextBox txtNuevaPass;
        private TextBox txtConfirmarPass;
        private Label lblMinimo;
        private Label lblMayuscula;
        private Label lblMinuscula;
        private Label lblNumero;
        private Label lblCoincide;
    }
}