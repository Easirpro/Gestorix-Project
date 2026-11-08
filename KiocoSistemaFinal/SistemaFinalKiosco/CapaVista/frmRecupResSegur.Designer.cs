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
            lblTitulo = new Label();
            lblIndicacion = new Label();
            lblIntentos = new Label();
            SuspendLayout();
            //
            // lblPregun
            //
            lblPregun.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPregun.Location = new Point(28, 98);
            lblPregun.Name = "lblPregun";
            lblPregun.Size = new Size(257, 20);
            lblPregun.TabIndex = 0;
            lblPregun.Text = "";
            //
            // txtRespuesta
            //
            txtRespuesta.Location = new Point(28, 122);
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.PlaceholderText = "Tu respuesta a la pregunta";
            txtRespuesta.Size = new Size(257, 23);
            txtRespuesta.TabIndex = 1;
            txtRespuesta.KeyPress += txtRespuesta_KeyPress;
            //
            // lblTitulo
            //
            lblTitulo.Font = new Font("Segoe UI", 14.25F);
            lblTitulo.Location = new Point(28, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(257, 30);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Pregunta de seguridad";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblIndicacion
            //
            lblIndicacion.ForeColor = SystemColors.GrayText;
            lblIndicacion.Location = new Point(28, 54);
            lblIndicacion.Name = "lblIndicacion";
            lblIndicacion.Size = new Size(257, 36);
            lblIndicacion.TabIndex = 4;
            lblIndicacion.Text = "Para crear una contraseña nueva, escribí la respuesta que guardaste para esta pregunta.";
            //
            // lblIntentos
            //
            lblIntentos.ForeColor = SystemColors.GrayText;
            lblIntentos.Location = new Point(28, 153);
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Size = new Size(257, 36);
            lblIntentos.TabIndex = 5;
            //
            // btnAceptar
            //
            btnAceptar.Location = new Point(119, 198);
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
            AcceptButton = btnAceptar;
            ClientSize = new Size(313, 240);
            Controls.Add(lblIntentos);
            Controls.Add(lblIndicacion);
            Controls.Add(lblTitulo);
            Controls.Add(btnAceptar);
            Controls.Add(txtRespuesta);
            Controls.Add(lblPregun);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmRecupResSegur";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuperar contraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPregun;
        private TextBox txtRespuesta;
        private Button btnAceptar;
        private Label lblTitulo;
        private Label lblIndicacion;
        private Label lblIntentos;
    }
}