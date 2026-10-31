namespace CapaVista
{
    partial class frmRecupResSegur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecupResSegur));
            lblPregun = new Label();
            txtRespuesta = new TextBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // lblPregun
            // 
            lblPregun.AutoSize = true;
            lblPregun.Location = new Point(28, 40);
            lblPregun.Name = "lblPregun";
            lblPregun.Size = new Size(38, 15);
            lblPregun.TabIndex = 0;
            lblPregun.Text = "label1";
            // 
            // txtRespuesta
            // 
            txtRespuesta.Location = new Point(28, 78);
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.PlaceholderText = "Tu respuesta a la pregunta";
            txtRespuesta.Size = new Size(161, 23);
            txtRespuesta.TabIndex = 1;
            txtRespuesta.KeyPress += txtRespuesta_KeyPress;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(72, 174);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // frmRecupResSegur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 278);
            Controls.Add(btnAceptar);
            Controls.Add(txtRespuesta);
            Controls.Add(lblPregun);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmRecupResSegur";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuperar respuesta de seguridad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPregun;
        private TextBox txtRespuesta;
        private Button btnAceptar;
    }
}