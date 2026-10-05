namespace CapaVista
{
    partial class frmBuscarRubro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarRubro));
            lblBuscarRubro = new Label();
            btnHabilitar = new Button();
            btnDiscontinuar = new Button();
            btnNuevoRubro = new Button();
            btnVolver = new Button();
            Modificar = new Button();
            dgtRubro = new DataGridView();
            dgvNombre = new DataGridViewTextBoxColumn();
            dgvActivo = new DataGridViewTextBoxColumn();
            chkSoloActivos = new CheckBox();
            btnBuscar = new Button();
            txtNombreRubro = new TextBox();
            label2 = new Label();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgtRubro).BeginInit();
            SuspendLayout();
            // 
            // lblBuscarRubro
            // 
            lblBuscarRubro.AutoSize = true;
            lblBuscarRubro.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscarRubro.Location = new Point(173, 30);
            lblBuscarRubro.Name = "lblBuscarRubro";
            lblBuscarRubro.Size = new Size(132, 25);
            lblBuscarRubro.TabIndex = 1;
            lblBuscarRubro.Text = "Buscar Rubro";
            // 
            // btnHabilitar
            // 
            btnHabilitar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.Location = new Point(364, 197);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(122, 44);
            btnHabilitar.TabIndex = 20;
            btnHabilitar.Text = "Habilitar";
            btnHabilitar.UseVisualStyleBackColor = true;
            btnHabilitar.Click += btnHabilitar_Click;
            // 
            // btnDiscontinuar
            // 
            btnDiscontinuar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDiscontinuar.Location = new Point(364, 147);
            btnDiscontinuar.Name = "btnDiscontinuar";
            btnDiscontinuar.Size = new Size(122, 44);
            btnDiscontinuar.TabIndex = 19;
            btnDiscontinuar.Text = "Discontinuar";
            btnDiscontinuar.UseVisualStyleBackColor = true;
            btnDiscontinuar.Click += btnDiscontinuar_Click;
            // 
            // btnNuevoRubro
            // 
            btnNuevoRubro.Location = new Point(94, 319);
            btnNuevoRubro.Name = "btnNuevoRubro";
            btnNuevoRubro.Size = new Size(102, 23);
            btnNuevoRubro.TabIndex = 18;
            btnNuevoRubro.Text = "Nuevo Rubro";
            btnNuevoRubro.UseVisualStyleBackColor = true;
            btnNuevoRubro.Click += btnNuevoRubro_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(283, 319);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // Modificar
            // 
            Modificar.Location = new Point(202, 319);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(75, 23);
            Modificar.TabIndex = 16;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Modificar_Click;
            // 
            // dgtRubro
            // 
            dgtRubro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtRubro.Columns.AddRange(new DataGridViewColumn[] { dgvNombre, dgvActivo });
            dgtRubro.Location = new Point(12, 147);
            dgtRubro.Name = "dgtRubro";
            dgtRubro.Size = new Size(346, 150);
            dgtRubro.TabIndex = 15;
            // 
            // dgvNombre
            // 
            dgvNombre.HeaderText = "Nombre";
            dgvNombre.Name = "dgvNombre";
            // 
            // dgvActivo
            // 
            dgvActivo.HeaderText = "Activo";
            dgvActivo.Name = "dgvActivo";
            // 
            // chkSoloActivos
            // 
            chkSoloActivos.AutoSize = true;
            chkSoloActivos.Location = new Point(324, 90);
            chkSoloActivos.Name = "chkSoloActivos";
            chkSoloActivos.Size = new Size(134, 19);
            chkSoloActivos.TabIndex = 14;
            chkSoloActivos.Text = "Mostrar solo Activos";
            chkSoloActivos.UseVisualStyleBackColor = true;
            chkSoloActivos.CheckedChanged += chkSoloActivos_CheckedChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.Transparent;
            btnBuscar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBuscar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.Transparent;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(266, 81);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(52, 35);
            btnBuscar.TabIndex = 13;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtNombreRubro
            // 
            txtNombreRubro.Location = new Point(67, 88);
            txtNombreRubro.Name = "txtNombreRubro";
            txtNombreRubro.Size = new Size(193, 23);
            txtNombreRubro.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 91);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 11;
            label2.Text = "Nombre:";
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(364, 247);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(122, 44);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // frmBuscarRubro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 366);
            Controls.Add(btnEliminar);
            Controls.Add(btnHabilitar);
            Controls.Add(btnDiscontinuar);
            Controls.Add(btnNuevoRubro);
            Controls.Add(btnVolver);
            Controls.Add(Modificar);
            Controls.Add(dgtRubro);
            Controls.Add(chkSoloActivos);
            Controls.Add(btnBuscar);
            Controls.Add(txtNombreRubro);
            Controls.Add(label2);
            Controls.Add(lblBuscarRubro);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmBuscarRubro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar Rubro";
            ((System.ComponentModel.ISupportInitialize)dgtRubro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscarRubro;
        private Button btnHabilitar;
        private Button btnDiscontinuar;
        private Button btnNuevoRubro;
        private Button btnVolver;
        private Button Modificar;
        private DataGridView dgtRubro;
        private DataGridViewTextBoxColumn dgvNombre;
        private DataGridViewTextBoxColumn dgvActivo;
        private CheckBox chkSoloActivos;
        private Button btnBuscar;
        private TextBox txtNombreRubro;
        private Label label2;
        private Button btnEliminar;
    }
}