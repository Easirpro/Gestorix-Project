namespace CapaVista
{
    partial class frmPrepararBase
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
            lblMensaje = new Label();
            pgbProgreso = new ProgressBar();
            lblPorcentaje = new Label();
            SuspendLayout();
            //
            // lblMensaje
            //
            lblMensaje.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMensaje.Location = new Point(20, 20);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(420, 45);
            lblMensaje.TabIndex = 0;
            lblMensaje.Text = "Preparando la base de datos por primera vez. Puede tardar unos minutos.";
            //
            // pgbProgreso
            //
            pgbProgreso.Location = new Point(20, 75);
            pgbProgreso.Name = "pgbProgreso";
            pgbProgreso.Size = new Size(420, 22);
            pgbProgreso.TabIndex = 1;
            //
            // lblPorcentaje
            //
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Location = new Point(20, 105);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(23, 15);
            lblPorcentaje.TabIndex = 2;
            lblPorcentaje.Text = "0%";
            //
            // frmPrepararBase
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 140);
            ControlBox = false;
            Controls.Add(lblMensaje);
            Controls.Add(pgbProgreso);
            Controls.Add(lblPorcentaje);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPrepararBase";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestorix";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMensaje;
        private ProgressBar pgbProgreso;
        private Label lblPorcentaje;
    }
}
