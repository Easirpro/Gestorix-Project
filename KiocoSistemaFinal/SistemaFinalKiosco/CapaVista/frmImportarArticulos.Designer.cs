namespace CapaVista
{
    partial class frmImportarArticulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarArticulos));
            label1 = new Label();
            label2 = new Label();
            txtTraerArchivo = new TextBox();
            btnSeleccionar = new Button();
            btnAceptar = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 32);
            label1.Name = "label1";
            label1.Size = new Size(291, 30);
            label1.TabIndex = 0;
            label1.Text = "Importar articulos desde Excel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 103);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Archivo";
            // 
            // txtTraerArchivo
            // 
            txtTraerArchivo.Location = new Point(66, 100);
            txtTraerArchivo.Name = "txtTraerArchivo";
            txtTraerArchivo.Size = new Size(170, 23);
            txtTraerArchivo.TabIndex = 2;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(242, 100);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(95, 23);
            btnSeleccionar.TabIndex = 3;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(262, 240);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(181, 240);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // frmImportarArticulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 353);
            Controls.Add(btnVolver);
            Controls.Add(btnAceptar);
            Controls.Add(btnSeleccionar);
            Controls.Add(txtTraerArchivo);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmImportarArticulos";
            Text = "frmImportarArticulos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTraerArchivo;
        private Button btnSeleccionar;
        private Button btnAceptar;
        private Button btnVolver;
    }
}