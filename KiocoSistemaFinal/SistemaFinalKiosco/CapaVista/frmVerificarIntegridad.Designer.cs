namespace CapaVista
{
    partial class frmVerificarIntegridad
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
            components = new System.ComponentModel.Container();
            lblResultado = new Label();
            dgvInconsistencias = new DataGridView();
            btnVerificar = new Button();
            btnRecalcular = new Button();
            btnRestaurarBackup = new Button();
            btnCerrar = new Button();
            ttAyuda = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvInconsistencias).BeginInit();
            SuspendLayout();
            // 
            // lblResultado
            // 
            lblResultado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblResultado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResultado.Location = new Point(12, 12);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(736, 40);
            lblResultado.TabIndex = 0;
            lblResultado.Text = "Verificando...";
            // 
            // dgvInconsistencias
            // 
            dgvInconsistencias.AllowUserToAddRows = false;
            dgvInconsistencias.AllowUserToDeleteRows = false;
            dgvInconsistencias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInconsistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInconsistencias.BackgroundColor = SystemColors.Window;
            dgvInconsistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInconsistencias.Location = new Point(12, 58);
            dgvInconsistencias.MultiSelect = false;
            dgvInconsistencias.Name = "dgvInconsistencias";
            dgvInconsistencias.ReadOnly = true;
            dgvInconsistencias.RowHeadersVisible = false;
            dgvInconsistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInconsistencias.Size = new Size(736, 300);
            dgvInconsistencias.TabIndex = 1;
            // 
            // btnVerificar
            // 
            btnVerificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVerificar.Location = new Point(12, 372);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(140, 40);
            btnVerificar.TabIndex = 2;
            btnVerificar.Text = "Verificar de nuevo";
            ttAyuda.SetToolTip(btnVerificar, "Vuelve a revisar el DVH de productos, usuarios y ventas.");
            btnVerificar.UseVisualStyleBackColor = true;
            btnVerificar.Click += btnVerificar_Click;
            // 
            // btnRecalcular
            // 
            btnRecalcular.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRecalcular.Location = new Point(162, 372);
            btnRecalcular.Name = "btnRecalcular";
            btnRecalcular.Size = new Size(140, 40);
            btnRecalcular.TabIndex = 3;
            btnRecalcular.Text = "Recalcular DVH";
            ttAyuda.SetToolTip(btnRecalcular, "Da por válidos los datos actuales y vuelve a calcular el DVH de todos los registros.");
            btnRecalcular.UseVisualStyleBackColor = true;
            btnRecalcular.Click += btnRecalcular_Click;
            // 
            // btnRestaurarBackup
            // 
            btnRestaurarBackup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRestaurarBackup.Location = new Point(312, 372);
            btnRestaurarBackup.Name = "btnRestaurarBackup";
            btnRestaurarBackup.Size = new Size(140, 40);
            btnRestaurarBackup.TabIndex = 4;
            btnRestaurarBackup.Text = "Restaurar backup";
            ttAyuda.SetToolTip(btnRestaurarBackup, "Abre Gestión de Backup para volver a una copia anterior a la modificación.");
            btnRestaurarBackup.UseVisualStyleBackColor = true;
            btnRestaurarBackup.Click += btnRestaurarBackup_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Location = new Point(628, 372);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(120, 40);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // ttAyuda
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            // 
            // frmVerificarIntegridad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 424);
            Controls.Add(lblResultado);
            Controls.Add(dgvInconsistencias);
            Controls.Add(btnVerificar);
            Controls.Add(btnRecalcular);
            Controls.Add(btnRestaurarBackup);
            Controls.Add(btnCerrar);
            MinimumSize = new Size(640, 360);
            Name = "frmVerificarIntegridad";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Verificar integridad";
            ((System.ComponentModel.ISupportInitialize)dgvInconsistencias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblResultado;
        private DataGridView dgvInconsistencias;
        private Button btnVerificar;
        private Button btnRecalcular;
        private Button btnRestaurarBackup;
        private Button btnCerrar;
        private ToolTip ttAyuda;
    }
}
