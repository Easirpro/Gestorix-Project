namespace CapaVista
{
    partial class frmIngresoUsuarioContra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoUsuarioContra));
            label1 = new Label();
            txtIngresoUsuario = new TextBox();
            btnValidarUsuario = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 45);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese su usuario";
            // 
            // txtIngresoUsuario
            // 
            txtIngresoUsuario.Location = new Point(33, 77);
            txtIngresoUsuario.Name = "txtIngresoUsuario";
            txtIngresoUsuario.PlaceholderText = "Tu nombre de usuario";
            txtIngresoUsuario.Size = new Size(173, 23);
            txtIngresoUsuario.TabIndex = 1;
            txtIngresoUsuario.KeyPress += txtIngresoUsuario_KeyPress;
            // 
            // btnValidarUsuario
            // 
            btnValidarUsuario.Location = new Point(71, 159);
            btnValidarUsuario.Name = "btnValidarUsuario";
            btnValidarUsuario.Size = new Size(104, 23);
            btnValidarUsuario.TabIndex = 2;
            btnValidarUsuario.Text = "Validar Usuario";
            btnValidarUsuario.UseVisualStyleBackColor = true;
            btnValidarUsuario.Click += btnValidarUsuario_Click;
            // 
            // frmIngresoUsuarioContra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 234);
            Controls.Add(btnValidarUsuario);
            Controls.Add(txtIngresoUsuario);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmIngresoUsuarioContra";
            Text = "Ingreso usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIngresoUsuario;
        private Button btnValidarUsuario;
    }
}