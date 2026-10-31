namespace CapaVista
{
    partial class frmNuevoRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoRol));
            label1 = new Label();
            label2 = new Label();
            txtNuevoRol = new TextBox();
            btnVolver = new Button();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(113, 9);
            label1.Name = "label1";
            label1.Size = new Size(116, 30);
            label1.TabIndex = 0;
            label1.Text = "Nuevo Rol";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 86);
            label2.Name = "label2";
            label2.Size = new Size(132, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del nuevo Rol: ";
            // 
            // txtNuevoRol
            // 
            txtNuevoRol.Location = new Point(132, 83);
            txtNuevoRol.Name = "txtNuevoRol";
            txtNuevoRol.PlaceholderText = "Ej.: Cajero de fin de semana";
            txtNuevoRol.Size = new Size(158, 23);
            txtNuevoRol.TabIndex = 2;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(154, 150);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(250, 150);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // frmNuevoRol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 204);
            Controls.Add(btnGuardar);
            Controls.Add(btnVolver);
            Controls.Add(txtNuevoRol);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmNuevoRol";
            Text = "Nuevo Rol";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNuevoRol;
        private Button btnVolver;
        private Button btnGuardar;
    }
}