namespace CapaVista
{
    partial class frmReporapida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporapida));
            label1 = new Label();
            lblCodigoArticulo = new Label();
            lblNuevoStock = new Label();
            txtCodigo = new TextBox();
            txtNuevoStock = new TextBox();
            btnVolver = new Button();
            btnAceptar = new Button();
            lblNombre = new Label();
            txtNombre = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 40);
            label1.Name = "label1";
            label1.Size = new Size(281, 29);
            label1.TabIndex = 0;
            label1.Text = "Reposición rápida de Stock";
            // 
            // lblCodigoArticulo
            // 
            lblCodigoArticulo.AutoSize = true;
            lblCodigoArticulo.Location = new Point(78, 131);
            lblCodigoArticulo.Name = "lblCodigoArticulo";
            lblCodigoArticulo.Size = new Size(91, 15);
            lblCodigoArticulo.TabIndex = 1;
            lblCodigoArticulo.Text = "Código Articulo";
            // 
            // lblNuevoStock
            // 
            lblNuevoStock.AutoSize = true;
            lblNuevoStock.Location = new Point(45, 218);
            lblNuevoStock.Name = "lblNuevoStock";
            lblNuevoStock.Size = new Size(124, 15);
            lblNuevoStock.TabIndex = 2;
            lblNuevoStock.Text = "Carga de Nuevo Stock";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(182, 123);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(156, 23);
            txtCodigo.TabIndex = 3;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            // 
            // txtNuevoStock
            // 
            txtNuevoStock.Location = new Point(182, 210);
            txtNuevoStock.Name = "txtNuevoStock";
            txtNuevoStock.Size = new Size(156, 23);
            txtNuevoStock.TabIndex = 4;
            // 
            // btnVolver
            // 
            btnVolver.ForeColor = SystemColors.ActiveCaptionText;
            btnVolver.Location = new Point(263, 289);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(169, 289);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(105, 173);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(182, 170);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(156, 23);
            txtNombre.TabIndex = 8;
            // 
            // frmReporapida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 357);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(btnAceptar);
            Controls.Add(btnVolver);
            Controls.Add(txtNuevoStock);
            Controls.Add(txtCodigo);
            Controls.Add(lblNuevoStock);
            Controls.Add(lblCodigoArticulo);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmReporapida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reposición Rapida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCodigoArticulo;
        private Label lblNuevoStock;
        private TextBox txtCodigo;
        private TextBox txtNuevoStock;
        private Button btnVolver;
        private Button btnAceptar;
        private Label lblNombre;
        private TextBox txtNombre;
    }
}