namespace CapaVista
{
    partial class frmNuevoRubro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoRubro));
            btnAceptar = new Button();
            btnVolver = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            lblNuevoRubro = new Label();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(79, 170);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(160, 170);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(65, 102);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre del rubro";
            txtNombre.Size = new Size(170, 23);
            txtNombre.TabIndex = 7;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(13, 105);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(57, 15);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "Nombre: ";
            // 
            // lblNuevoRubro
            // 
            lblNuevoRubro.AutoSize = true;
            lblNuevoRubro.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNuevoRubro.Location = new Point(79, 37);
            lblNuevoRubro.Name = "lblNuevoRubro";
            lblNuevoRubro.Size = new Size(132, 25);
            lblNuevoRubro.TabIndex = 5;
            lblNuevoRubro.Text = "Nuevo Rubro";
            // 
            // frmNuevoRubro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 230);
            Controls.Add(btnAceptar);
            Controls.Add(btnVolver);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblNuevoRubro);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmNuevoRubro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo Rubro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnVolver;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblNuevoRubro;
    }
}