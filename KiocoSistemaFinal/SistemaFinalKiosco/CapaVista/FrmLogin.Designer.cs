namespace CapaVista
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            lblUsuario = new Label();
            txtUser = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            lkbOlvideContraseña = new LinkLabel();
            btnSalir = new Button();
            btnMostrar = new Button();
            panel1 = new Panel();
            lblContraseña = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.Black;
            lblUsuario.Location = new Point(14, 64);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(101, 56);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(171, 23);
            txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            txtPass.Cursor = Cursors.IBeam;
            txtPass.Location = new Point(101, 110);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(171, 23);
            txtPass.TabIndex = 3;
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(197, 206);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lkbOlvideContraseña
            // 
            lkbOlvideContraseña.AutoSize = true;
            lkbOlvideContraseña.BackColor = Color.Transparent;
            lkbOlvideContraseña.Location = new Point(118, 159);
            lkbOlvideContraseña.Name = "lkbOlvideContraseña";
            lkbOlvideContraseña.Size = new Size(119, 15);
            lkbOlvideContraseña.TabIndex = 5;
            lkbOlvideContraseña.TabStop = true;
            lkbOlvideContraseña.Text = "Olvide mi contraseña";
            lkbOlvideContraseña.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(57, 206);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.BackColor = Color.Transparent;
            btnMostrar.FlatAppearance.BorderColor = Color.White;
            btnMostrar.FlatAppearance.BorderSize = 0;
            btnMostrar.FlatStyle = FlatStyle.Flat;
            btnMostrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMostrar.ForeColor = SystemColors.ControlText;
            btnMostrar.Location = new Point(277, 110);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(46, 23);
            btnMostrar.TabIndex = 7;
            btnMostrar.Text = "👁";
            btnMostrar.UseVisualStyleBackColor = false;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(lblContraseña);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(btnMostrar);
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(lkbOlvideContraseña);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(326, 259);
            panel1.TabIndex = 9;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.Location = new Point(14, 118);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(67, 15);
            lblContraseña.TabIndex = 1;
            lblContraseña.Text = "Contraseña";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(326, 259);
            Controls.Add(btnSalir);
            Controls.Add(txtPass);
            Controls.Add(txtUser);
            Controls.Add(panel1);
            Cursor = Cursors.Hand;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;
        private LinkLabel lkbOlvideContraseña;
        private Button btnSalir;
        private Button btnMostrar;
        private Panel panel1;
        private Label lblContraseña;
    }
}