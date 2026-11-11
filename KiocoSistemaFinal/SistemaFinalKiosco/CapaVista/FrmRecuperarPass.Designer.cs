namespace CapaVista
{
    partial class FrmRecuperarPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecuperarPass));
            lblArriba = new Label();
            txtCorreo = new TextBox();
            btnEnviarCodigo = new Button();
            txtIngCodigo = new TextBox();
            lblAbajo = new Label();
            btnVolver = new Button();
            btnMostrar = new Button();
            btnMostrar1 = new Button();
            SuspendLayout();
            // 
            // lblArriba
            // 
            lblArriba.AutoSize = true;
            lblArriba.Location = new Point(22, 19);
            lblArriba.Name = "lblArriba";
            lblArriba.Size = new Size(153, 15);
            lblArriba.TabIndex = 0;
            lblArriba.Text = "Ingresa la nueva contraseña";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(22, 48);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Tu nueva contraseña";
            txtCorreo.Size = new Size(196, 23);
            txtCorreo.TabIndex = 1;
            txtCorreo.UseSystemPasswordChar = true;
            txtCorreo.KeyPress += txtCorreo_KeyPress;
            // 
            // btnEnviarCodigo
            // 
            btnEnviarCodigo.Location = new Point(123, 141);
            btnEnviarCodigo.Name = "btnEnviarCodigo";
            btnEnviarCodigo.Size = new Size(122, 23);
            btnEnviarCodigo.TabIndex = 6;
            btnEnviarCodigo.Text = "Cambiar contraseña";
            btnEnviarCodigo.UseVisualStyleBackColor = true;
            btnEnviarCodigo.Click += btnEnviarCodigo_Click;
            // 
            // txtIngCodigo
            // 
            txtIngCodigo.Location = new Point(22, 98);
            txtIngCodigo.Name = "txtIngCodigo";
            txtIngCodigo.PlaceholderText = "Repetí la nueva contraseña";
            txtIngCodigo.Size = new Size(196, 23);
            txtIngCodigo.TabIndex = 4;
            txtIngCodigo.UseSystemPasswordChar = true;
            txtIngCodigo.KeyPress += txtIngCodigo_KeyPress;
            // 
            // lblAbajo
            // 
            lblAbajo.AutoSize = true;
            lblAbajo.Location = new Point(22, 74);
            lblAbajo.Name = "lblAbajo";
            lblAbajo.Size = new Size(113, 15);
            lblAbajo.TabIndex = 3;
            lblAbajo.Text = "Repeti la contraseña";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(22, 141);
            btnVolver.Name = "btnVolver";
            btnVolver.RightToLeft = RightToLeft.Yes;
            btnVolver.Size = new Size(95, 23);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Cursor = Cursors.Hand;
            btnMostrar.FlatAppearance.BorderSize = 0;
            btnMostrar.FlatStyle = FlatStyle.Flat;
            btnMostrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMostrar.Location = new Point(224, 48);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(46, 24);
            btnMostrar.TabIndex = 2;
            btnMostrar.Text = "👁";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btnMostrar1
            // 
            btnMostrar1.Cursor = Cursors.Hand;
            btnMostrar1.FlatAppearance.BorderSize = 0;
            btnMostrar1.FlatStyle = FlatStyle.Flat;
            btnMostrar1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMostrar1.Location = new Point(224, 98);
            btnMostrar1.Name = "btnMostrar1";
            btnMostrar1.Size = new Size(46, 24);
            btnMostrar1.TabIndex = 5;
            btnMostrar1.Text = "👁";
            btnMostrar1.UseVisualStyleBackColor = true;
            btnMostrar1.Click += btnMostrar1_Click;
            // 
            // FrmRecuperarPass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AcceptButton = btnEnviarCodigo;
            ClientSize = new Size(282, 204);
            Controls.Add(btnMostrar1);
            Controls.Add(btnMostrar);
            Controls.Add(lblAbajo);
            Controls.Add(btnVolver);
            Controls.Add(txtIngCodigo);
            Controls.Add(btnEnviarCodigo);
            Controls.Add(txtCorreo);
            Controls.Add(lblArriba);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmRecuperarPass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuperar Contraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblArriba;
        private TextBox txtCorreo;
        private Button btnEnviarCodigo;
        private TextBox txtIngCodigo;
        private Label lblAbajo;
        private Button btnVolver;
        private Button btnMostrar;
        private Button btnMostrar1;
    }
}