namespace CapaVista
{
    partial class frmCategoriaMarca
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoriaMarca));
            lblTitulo = new Label();
            pnlModo = new Panel();
            lblModo = new Label();
            btnCategorias = new Button();
            btnMarcas = new Button();
            pnlBusqueda = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            btnBuscar = new Button();
            chkSoloActivos = new CheckBox();
            dgvItems = new DataGridView();
            dgvNombre = new DataGridViewTextBoxColumn();
            dgvActivo = new DataGridViewTextBoxColumn();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnDiscontinuar = new Button();
            btnHabilitar = new Button();
            btnEliminar = new Button();
            btnVolver = new Button();
            pnlModo.SuspendLayout();
            pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(13, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(600, 42);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Categorías y marcas";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlModo
            //
            pnlModo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlModo.Controls.Add(lblModo);
            pnlModo.Controls.Add(btnCategorias);
            pnlModo.Controls.Add(btnMarcas);
            pnlModo.Location = new Point(13, 55);
            pnlModo.Name = "pnlModo";
            pnlModo.Size = new Size(600, 40);
            pnlModo.TabIndex = 1;
            //
            // lblModo
            //
            lblModo.AutoSize = true;
            lblModo.Location = new Point(3, 14);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(109, 15);
            lblModo.TabIndex = 0;
            lblModo.Text = "¿Qué querés hacer?";
            //
            // btnCategorias
            //
            btnCategorias.Location = new Point(149, 3);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(150, 34);
            btnCategorias.TabIndex = 1;
            btnCategorias.Text = "Categorías";
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            //
            // btnMarcas
            //
            btnMarcas.Location = new Point(314, 3);
            btnMarcas.Name = "btnMarcas";
            btnMarcas.Size = new Size(150, 34);
            btnMarcas.TabIndex = 2;
            btnMarcas.Text = "Marcas";
            btnMarcas.UseVisualStyleBackColor = true;
            btnMarcas.Click += btnMarcas_Click;
            //
            // pnlBusqueda
            //
            pnlBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBusqueda.Controls.Add(lblNombre);
            pnlBusqueda.Controls.Add(txtNombre);
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(chkSoloActivos);
            pnlBusqueda.Location = new Point(13, 101);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Size = new Size(600, 42);
            pnlBusqueda.TabIndex = 2;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(3, 14);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(63, 11);
            txtNombre.MaxLength = 80;
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre de la categoría o marca";
            txtNombre.Size = new Size(300, 23);
            txtNombre.TabIndex = 1;
            txtNombre.KeyDown += txtNombre_KeyDown;
            //
            // btnBuscar
            //
            btnBuscar.BackColor = Color.Transparent;
            btnBuscar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBuscar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.Transparent;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(369, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(52, 35);
            btnBuscar.TabIndex = 2;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            //
            // chkSoloActivos
            //
            chkSoloActivos.AutoSize = true;
            chkSoloActivos.Location = new Point(435, 13);
            chkSoloActivos.Name = "chkSoloActivos";
            chkSoloActivos.Size = new Size(134, 19);
            chkSoloActivos.TabIndex = 3;
            chkSoloActivos.Text = "Mostrar solo activos";
            chkSoloActivos.UseVisualStyleBackColor = true;
            chkSoloActivos.CheckedChanged += chkSoloActivos_CheckedChanged;
            //
            // dgvItems
            //
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AllowUserToResizeColumns = false;
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.BackgroundColor = SystemColors.Window;
            dgvItems.ColumnHeadersHeight = 32;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { dgvNombre, dgvActivo });
            dgvItems.Location = new Point(13, 149);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(440, 300);
            dgvItems.TabIndex = 6;
            //
            // dgvNombre
            //
            dgvNombre.FillWeight = 70F;
            dgvNombre.HeaderText = "Nombre";
            dgvNombre.Name = "dgvNombre";
            dgvNombre.ReadOnly = true;
            //
            // dgvActivo
            //
            dgvActivo.FillWeight = 30F;
            dgvActivo.HeaderText = "Estado";
            dgvActivo.Name = "dgvActivo";
            dgvActivo.ReadOnly = true;
            //
            // btnNuevo
            //
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevo.Location = new Point(465, 149);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(148, 40);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnModificar
            //
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnModificar.Location = new Point(465, 195);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(148, 40);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            //
            // btnDiscontinuar
            //
            btnDiscontinuar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDiscontinuar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDiscontinuar.Location = new Point(465, 241);
            btnDiscontinuar.Name = "btnDiscontinuar";
            btnDiscontinuar.Size = new Size(148, 40);
            btnDiscontinuar.TabIndex = 5;
            btnDiscontinuar.Text = "Discontinuar";
            btnDiscontinuar.UseVisualStyleBackColor = true;
            btnDiscontinuar.Click += btnDiscontinuar_Click;
            //
            // btnHabilitar
            //
            btnHabilitar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHabilitar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHabilitar.Location = new Point(465, 287);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(148, 40);
            btnHabilitar.TabIndex = 7;
            btnHabilitar.Text = "Habilitar";
            btnHabilitar.UseVisualStyleBackColor = true;
            btnHabilitar.Click += btnHabilitar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.Location = new Point(465, 333);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(148, 40);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Location = new Point(513, 462);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 28);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // frmCategoriaMarca
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 502);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminar);
            Controls.Add(btnHabilitar);
            Controls.Add(btnDiscontinuar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvItems);
            Controls.Add(pnlBusqueda);
            Controls.Add(pnlModo);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(642, 541);
            MaximizeBox = false;
            Name = "frmCategoriaMarca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categorías y marcas";
            pnlModo.ResumeLayout(false);
            pnlModo.PerformLayout();
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlModo;
        private Label lblModo;
        private Button btnCategorias;
        private Button btnMarcas;
        private Panel pnlBusqueda;
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnBuscar;
        private CheckBox chkSoloActivos;
        private DataGridView dgvItems;
        private DataGridViewTextBoxColumn dgvNombre;
        private DataGridViewTextBoxColumn dgvActivo;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnDiscontinuar;
        private Button btnHabilitar;
        private Button btnEliminar;
        private Button btnVolver;
    }
}
