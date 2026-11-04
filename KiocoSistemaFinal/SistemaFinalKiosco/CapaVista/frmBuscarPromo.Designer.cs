namespace CapaVista
{
    partial class frmBuscarPromo
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
            ttAyuda = new ToolTip(components);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarPromo));
            lblBuscarPromo = new Label();
            lblDescipcionPromo = new Label();
            btnLimpiarBusqueda = new Button();
            btnContinuar = new Button();
            dtgBuscarPromo = new DataGridView();
            clnCodigo = new DataGridViewTextBoxColumn();
            clnNombre = new DataGridViewTextBoxColumn();
            clnEstado = new DataGridViewTextBoxColumn();
            clnDetalle = new DataGridViewButtonColumn();
            cmbBuscarPromo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dtgBuscarPromo).BeginInit();
            SuspendLayout();
            // 
            // lblBuscarPromo
            // 
            lblBuscarPromo.AutoSize = true;
            lblBuscarPromo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscarPromo.Location = new Point(12, 21);
            lblBuscarPromo.Name = "lblBuscarPromo";
            lblBuscarPromo.Size = new Size(148, 21);
            lblBuscarPromo.TabIndex = 0;
            lblBuscarPromo.Text = "Buscar Promoción";
            // 
            // lblDescipcionPromo
            // 
            lblDescipcionPromo.AutoSize = true;
            lblDescipcionPromo.Location = new Point(12, 59);
            lblDescipcionPromo.Name = "lblDescipcionPromo";
            lblDescipcionPromo.Size = new Size(247, 15);
            lblDescipcionPromo.TabIndex = 1;
            lblDescipcionPromo.Text = "Buscá por código o nombre de la promoción.";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLimpiarBusqueda.Location = new Point(246, 281);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(127, 23);
            btnLimpiarBusqueda.TabIndex = 3;
            btnLimpiarBusqueda.Text = "Limpiar busqueda";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            // 
            // btnContinuar
            // 
            btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnContinuar.Location = new Point(379, 281);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(75, 23);
            btnContinuar.TabIndex = 4;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // dtgBuscarPromo
            // 
            dtgBuscarPromo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgBuscarPromo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgBuscarPromo.Columns.AddRange(new DataGridViewColumn[] { clnCodigo, clnNombre, clnEstado, clnDetalle });
            dtgBuscarPromo.Location = new Point(12, 120);
            dtgBuscarPromo.Name = "dtgBuscarPromo";
            dtgBuscarPromo.Size = new Size(501, 150);
            dtgBuscarPromo.TabIndex = 5;
            dtgBuscarPromo.CellClick += dtgBuscarPromo_CellClick;
            dtgBuscarPromo.CellContentClick += dtgBuscarPromo_CellContentClick;
            // 
            // clnCodigo
            // 
            clnCodigo.Frozen = true;
            clnCodigo.HeaderText = "Codigo";
            clnCodigo.Name = "clnCodigo";
            clnCodigo.ReadOnly = true;
            // 
            // clnNombre
            // 
            clnNombre.Frozen = true;
            clnNombre.HeaderText = "Nombre (producto)";
            clnNombre.Name = "clnNombre";
            clnNombre.ReadOnly = true;
            // 
            // clnEstado
            // 
            clnEstado.Frozen = true;
            clnEstado.HeaderText = "Estado";
            clnEstado.Name = "clnEstado";
            clnEstado.ReadOnly = true;
            // 
            // clnDetalle
            // 
            clnDetalle.HeaderText = "Detalle";
            clnDetalle.Name = "clnDetalle";
            clnDetalle.Resizable = DataGridViewTriState.False;
            clnDetalle.Text = "Ver Detalle";
            clnDetalle.UseColumnTextForButtonValue = true;
            // 
            // cmbBuscarPromo
            // 
            cmbBuscarPromo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbBuscarPromo.FormattingEnabled = true;
            cmbBuscarPromo.Location = new Point(15, 80);
            cmbBuscarPromo.Name = "cmbBuscarPromo";
            cmbBuscarPromo.Size = new Size(244, 23);
            cmbBuscarPromo.TabIndex = 6;
            cmbBuscarPromo.SelectedIndexChanged += cmbBuscarPromo_SelectedIndexChanged;
            cmbBuscarPromo.TextUpdate += cmbBuscarPromo_TextUpdate;
            // 
            // frmBuscarPromo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 316);
            Controls.Add(cmbBuscarPromo);
            Controls.Add(dtgBuscarPromo);
            Controls.Add(btnContinuar);
            Controls.Add(btnLimpiarBusqueda);
            Controls.Add(lblDescipcionPromo);
            Controls.Add(lblBuscarPromo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            MinimumSize = new Size(541, 355);
            Name = "frmBuscarPromo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar Promoción";
            Load += frmBuscarPromo_Load_1;
            ((System.ComponentModel.ISupportInitialize)dtgBuscarPromo).EndInit();
            // 
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbBuscarPromo, "Escribí el código o el nombre de la promoción y elegila de la lista.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

        private Label lblBuscarPromo;
        private Label lblDescipcionPromo;
        private Button btnLimpiarBusqueda;
        private Button btnContinuar;
        private DataGridView dtgBuscarPromo;
        private ComboBox cmbBuscarPromo;
        private DataGridViewTextBoxColumn clnCodigo;
        private DataGridViewTextBoxColumn clnNombre;
        private DataGridViewTextBoxColumn clnEstado;
        private DataGridViewButtonColumn clnDetalle;
    }
}