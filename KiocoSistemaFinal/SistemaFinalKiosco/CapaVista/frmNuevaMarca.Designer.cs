namespace CapaVista
{
    partial class frmNuevaMarca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaMarca));
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            btnVolver = new Button();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(85, 19);
            label1.Name = "label1";
            label1.Size = new Size(129, 25);
            label1.TabIndex = 0;
            label1.Text = "Nueva Marca";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 87);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(71, 84);
            txtNombre.MaxLength = 80;
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre de la marca";
            txtNombre.Size = new Size(170, 23);
            txtNombre.TabIndex = 2;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(166, 152);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(85, 152);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // frmNuevaMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 211);
            Controls.Add(btnAceptar);
            Controls.Add(btnVolver);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmNuevaMarca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva Marca";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private Button btnVolver;
        private Button btnAceptar;
    }
}