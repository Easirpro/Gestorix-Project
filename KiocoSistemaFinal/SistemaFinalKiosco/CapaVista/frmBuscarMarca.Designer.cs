namespace CapaVista
{
    partial class frmBuscarMarca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarMarca));
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            btnBuscar = new Button();
            chkSoloActivos = new CheckBox();
            dataGridView1 = new DataGridView();
            dgvNombre = new DataGridViewTextBoxColumn();
            dgvActivo = new DataGridViewTextBoxColumn();
            Modificar = new Button();
            btnVolver = new Button();
            btnNuevaMarca = new Button();
            btnDiscontinuar = new Button();
            btnHabilitar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(124, 29);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 0;
            label1.Text = "Buscar la marca";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 91);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 23);
            textBox1.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.Transparent;
            btnBuscar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBuscar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.Transparent;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(289, 81);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(52, 35);
            btnBuscar.TabIndex = 3;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // chkSoloActivos
            // 
            chkSoloActivos.AutoSize = true;
            chkSoloActivos.Location = new Point(347, 90);
            chkSoloActivos.Name = "chkSoloActivos";
            chkSoloActivos.Size = new Size(134, 19);
            chkSoloActivos.TabIndex = 4;
            chkSoloActivos.Text = "Mostrar solo Activos";
            chkSoloActivos.UseVisualStyleBackColor = true;
            chkSoloActivos.CheckedChanged += chkSoloActivos_CheckedChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dgvNombre, dgvActivo });
            dataGridView1.Location = new Point(35, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(346, 150);
            dataGridView1.TabIndex = 5;
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
            // Modificar
            // 
            Modificar.Location = new Point(225, 319);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(75, 23);
            Modificar.TabIndex = 6;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Modificar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(306, 319);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnNuevaMarca
            // 
            btnNuevaMarca.Location = new Point(117, 319);
            btnNuevaMarca.Name = "btnNuevaMarca";
            btnNuevaMarca.Size = new Size(102, 23);
            btnNuevaMarca.TabIndex = 8;
            btnNuevaMarca.Text = "Nueva Marca";
            btnNuevaMarca.UseVisualStyleBackColor = true;
            btnNuevaMarca.Click += btnNuevaMarca_Click;
            // 
            // btnDiscontinuar
            // 
            btnDiscontinuar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDiscontinuar.Location = new Point(387, 147);
            btnDiscontinuar.Name = "btnDiscontinuar";
            btnDiscontinuar.Size = new Size(122, 44);
            btnDiscontinuar.TabIndex = 9;
            btnDiscontinuar.Text = "Discontinuar";
            btnDiscontinuar.UseVisualStyleBackColor = true;
            btnDiscontinuar.Click += btnDiscontinuar_Click;
            // 
            // btnHabilitar
            // 
            btnHabilitar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.Location = new Point(387, 197);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(122, 44);
            btnHabilitar.TabIndex = 10;
            btnHabilitar.Text = "Habilitar";
            btnHabilitar.UseVisualStyleBackColor = true;
            btnHabilitar.Click += btnHabilitar_Click;
            // 
            // frmBuscarMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 364);
            Controls.Add(btnHabilitar);
            Controls.Add(btnDiscontinuar);
            Controls.Add(btnNuevaMarca);
            Controls.Add(btnVolver);
            Controls.Add(Modificar);
            Controls.Add(dataGridView1);
            Controls.Add(chkSoloActivos);
            Controls.Add(btnBuscar);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmBuscarMarca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva Marca";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button btnBuscar;
        private CheckBox chkSoloActivos;
        private DataGridView dataGridView1;
        private Button Modificar;
        private Button btnVolver;
        private Button btnNuevaMarca;
        private DataGridViewTextBoxColumn dgvNombre;
        private DataGridViewTextBoxColumn dgvActivo;
        private Button btnDiscontinuar;
        private Button btnHabilitar;
    }
}