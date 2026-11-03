namespace CapaVista
{
    partial class frmGestionBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionBackup));
            btnExaminar = new Button();
            lbRutaBk = new Label();
            txtRutabk = new TextBox();
            btnGenerarBackup = new Button();
            lstBackup = new ListBox();
            btnActualizar = new Button();
            btnCancelar = new Button();
            btnRestaurarBackup = new Button();
            lbListado = new Label();
            lblProgresoBackup = new Label();
            pgbGenerarBackup = new ProgressBar();
            pgbRestaurarBackup = new ProgressBar();
            lblProgresoRestaurar = new Label();
            SuspendLayout();
            // 
            // btnExaminar
            // 
            resources.ApplyResources(btnExaminar, "btnExaminar");
            btnExaminar.Name = "btnExaminar";
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // lbRutaBk
            // 
            resources.ApplyResources(lbRutaBk, "lbRutaBk");
            lbRutaBk.Name = "lbRutaBk";
            // 
            // txtRutabk
            // 
            resources.ApplyResources(txtRutabk, "txtRutabk");
            txtRutabk.Name = "txtRutabk";
            // 
            // btnGenerarBackup
            // 
            resources.ApplyResources(btnGenerarBackup, "btnGenerarBackup");
            btnGenerarBackup.Name = "btnGenerarBackup";
            btnGenerarBackup.UseVisualStyleBackColor = true;
            btnGenerarBackup.Click += btnGenerarBackup_Click;
            // 
            // lstBackup
            // 
            lstBackup.FormattingEnabled = true;
            resources.ApplyResources(lstBackup, "lstBackup");
            lstBackup.Name = "lstBackup";
            // 
            // btnActualizar
            // 
            resources.ApplyResources(btnActualizar, "btnActualizar");
            btnActualizar.Name = "btnActualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCancelar
            // 
            resources.ApplyResources(btnCancelar, "btnCancelar");
            btnCancelar.Name = "btnCancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnRestaurarBackup
            // 
            resources.ApplyResources(btnRestaurarBackup, "btnRestaurarBackup");
            btnRestaurarBackup.Name = "btnRestaurarBackup";
            btnRestaurarBackup.UseVisualStyleBackColor = true;
            btnRestaurarBackup.Click += btnRestaurarBackup_Click;
            // 
            // lbListado
            // 
            resources.ApplyResources(lbListado, "lbListado");
            lbListado.Name = "lbListado";
            // 
            // lblProgresoBackup
            // 
            lblProgresoBackup.AutoSize = true;
            lblProgresoBackup.Location = new Point(12, 124);
            lblProgresoBackup.Name = "lblProgresoBackup";
            lblProgresoBackup.Size = new Size(0, 15);
            lblProgresoBackup.TabIndex = 9;
            lblProgresoBackup.Visible = false;
            // 
            // pgbGenerarBackup
            // 
            pgbGenerarBackup.Location = new Point(12, 143);
            pgbGenerarBackup.Name = "pgbGenerarBackup";
            pgbGenerarBackup.Size = new Size(334, 20);
            pgbGenerarBackup.TabIndex = 10;
            pgbGenerarBackup.Visible = false;
            // 
            // pgbRestaurarBackup
            // 
            pgbRestaurarBackup.Location = new Point(12, 377);
            pgbRestaurarBackup.Name = "pgbRestaurarBackup";
            pgbRestaurarBackup.Size = new Size(334, 20);
            pgbRestaurarBackup.TabIndex = 11;
            pgbRestaurarBackup.Visible = false;
            // 
            // lblProgresoRestaurar
            // 
            lblProgresoRestaurar.AutoSize = true;
            lblProgresoRestaurar.Location = new Point(12, 402);
            lblProgresoRestaurar.Name = "lblProgresoRestaurar";
            lblProgresoRestaurar.Size = new Size(0, 15);
            lblProgresoRestaurar.TabIndex = 12;
            lblProgresoRestaurar.Visible = false;
            // 
            // frmGestionBackup
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblProgresoRestaurar);
            Controls.Add(pgbRestaurarBackup);
            Controls.Add(pgbGenerarBackup);
            Controls.Add(lblProgresoBackup);
            Controls.Add(lbListado);
            Controls.Add(btnRestaurarBackup);
            Controls.Add(btnCancelar);
            Controls.Add(btnActualizar);
            Controls.Add(lstBackup);
            Controls.Add(btnGenerarBackup);
            Controls.Add(txtRutabk);
            Controls.Add(lbRutaBk);
            Controls.Add(btnExaminar);
            MaximizeBox = false;
            Name = "frmGestionBackup";
            ShowIcon = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExaminar;
        private Label lbRutaBk;
        private TextBox txtRutabk;
        private Button btnGenerarBackup;
        private ListBox lstBackup;
        private Button btnActualizar;
        private Button btnCancelar;
        private Button btnRestaurarBackup;
        private Label lbListado;
        private Label lblProgresoBackup;
        private ProgressBar pgbGenerarBackup;
        private ProgressBar pgbRestaurarBackup;
        private Label lblProgresoRestaurar;
    }
}