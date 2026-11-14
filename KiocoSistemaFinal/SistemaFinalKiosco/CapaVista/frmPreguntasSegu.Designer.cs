namespace CapaVista
{
    partial class frmPreguntasSegu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreguntasSegu));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNombreMascota = new TextBox();
            label4 = new Label();
            txtLibro = new TextBox();
            txtComida = new TextBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 124);
            label1.Name = "label1";
            label1.Size = new Size(190, 15);
            label1.TabIndex = 1;
            label1.Text = "¿Cuál es el nombre de tu mascota?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 182);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 3;
            label2.Text = "¿Cuál es tu libro favorito?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 245);
            label3.Name = "label3";
            label3.Size = new Size(155, 15);
            label3.TabIndex = 5;
            label3.Text = "¿Cuál es tu comida favorita?";
            // 
            // txtNombreMascota
            // 
            txtNombreMascota.Location = new Point(35, 142);
            txtNombreMascota.MaxLength = 100;
            txtNombreMascota.Name = "txtNombreMascota";
            txtNombreMascota.PlaceholderText = "Tu respuesta";
            txtNombreMascota.Size = new Size(177, 23);
            txtNombreMascota.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(30, 44);
            label4.Name = "label4";
            label4.Size = new Size(214, 25);
            label4.TabIndex = 0;
            label4.Text = "Preguntas de Seguridad";
            // 
            // txtLibro
            // 
            txtLibro.Location = new Point(35, 200);
            txtLibro.MaxLength = 100;
            txtLibro.Name = "txtLibro";
            txtLibro.PlaceholderText = "Tu respuesta";
            txtLibro.Size = new Size(177, 23);
            txtLibro.TabIndex = 4;
            // 
            // txtComida
            // 
            txtComida.Location = new Point(35, 263);
            txtComida.MaxLength = 100;
            txtComida.Name = "txtComida";
            txtComida.PlaceholderText = "Tu respuesta";
            txtComida.Size = new Size(177, 23);
            txtComida.TabIndex = 6;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(132, 322);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click_1;
            // 
            // frmPreguntasSegu
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 368);
            Controls.Add(btnAceptar);
            Controls.Add(txtComida);
            Controls.Add(txtLibro);
            Controls.Add(label4);
            Controls.Add(txtNombreMascota);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmPreguntasSegu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preguntas de Seguridad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNombreMascota;
        private Label label4;
        private TextBox txtLibro;
        private TextBox txtComida;
        private Button btnAceptar;
    }
}