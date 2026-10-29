namespace CapaVista
{
    partial class frmBitacora
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlCategorias;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnPromociones;
        private System.Windows.Forms.Button btnErrores;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblCategoriaActual;
        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.Label lblDetalleFecha;
        private System.Windows.Forms.Label lblDetalleUsuario;
        private System.Windows.Forms.Label lblDetalleAccion;
        private System.Windows.Forms.Label lblDetalleDescripcion;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBitacora));
            pnlEncabezado = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlCategorias = new Panel();
            btnProducto = new Button();
            btnSeguridad = new Button();
            btnErrores = new Button();
            btnPromociones = new Button();
            btnUsuario = new Button();
            pnlFiltros = new Panel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblFechaDesde = new Label();
            dtpFechaDesde = new DateTimePicker();
            lblFechaHasta = new Label();
            dtpFechaHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnLimpiar = new Button();
            btnActualizar = new Button();
            pnlContenido = new Panel();
            dgvBitacora = new DataGridView();
            lblCategoriaActual = new Label();
            pnlDetalles = new Panel();
            lblDetalles = new Label();
            lblDetalleFecha = new Label();
            lblDetalleUsuario = new Label();
            lblDetalleAccion = new Label();
            lblDetalleDescripcion = new Label();
            pnlEncabezado.SuspendLayout();
            pnlCategorias.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            pnlDetalles.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.White;
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Padding = new Padding(25, 15, 15, 10);
            pnlEncabezado.Size = new Size(1236, 70);
            pnlEncabezado.TabIndex = 4;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.Location = new Point(22, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(243, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Bitácora del sistema";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.Black;
            lblSubtitulo.Location = new Point(28, 45);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(344, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Registro y seguimiento de las operaciones realizadas en Gestorix";
            lblSubtitulo.Click += lblSubtitulo_Click;
            // 
            // pnlCategorias
            // 
            pnlCategorias.BackColor = Color.White;
            pnlCategorias.Controls.Add(btnProducto);
            pnlCategorias.Controls.Add(btnSeguridad);
            pnlCategorias.Controls.Add(btnErrores);
            pnlCategorias.Controls.Add(btnPromociones);
            pnlCategorias.Controls.Add(btnUsuario);
            pnlCategorias.Dock = DockStyle.Top;
            pnlCategorias.Location = new Point(0, 70);
            pnlCategorias.Name = "pnlCategorias";
            pnlCategorias.Padding = new Padding(18, 16, 18, 16);
            pnlCategorias.Size = new Size(1236, 73);
            pnlCategorias.TabIndex = 3;
            // 
            // btnProducto
            // 
            btnProducto.BackColor = Color.FromArgb(52, 73, 94);
            btnProducto.Cursor = Cursors.Hand;
            btnProducto.FlatAppearance.BorderSize = 0;
            btnProducto.FlatStyle = FlatStyle.Flat;
            btnProducto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnProducto.ForeColor = Color.White;
            btnProducto.Location = new Point(309, 16);
            btnProducto.Name = "btnProducto";
            btnProducto.Size = new Size(130, 40);
            btnProducto.TabIndex = 8;
            btnProducto.Text = "Productos";
            btnProducto.UseVisualStyleBackColor = false;
            btnProducto.Click += btnProducto_Click;
            // 
            // btnSeguridad
            // 
            btnSeguridad.BackColor = Color.FromArgb(52, 73, 94);
            btnSeguridad.Cursor = Cursors.Hand;
            btnSeguridad.FlatAppearance.BorderSize = 0;
            btnSeguridad.FlatStyle = FlatStyle.Flat;
            btnSeguridad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSeguridad.ForeColor = Color.White;
            btnSeguridad.Location = new Point(164, 16);
            btnSeguridad.Name = "btnSeguridad";
            btnSeguridad.Size = new Size(140, 40);
            btnSeguridad.TabIndex = 2;
            btnSeguridad.Text = "Seguridad";
            btnSeguridad.UseVisualStyleBackColor = false;
            btnSeguridad.Click += btnSeguridad_Click;
            // 
            // btnErrores
            // 
            btnErrores.BackColor = Color.FromArgb(192, 57, 43);
            btnErrores.Cursor = Cursors.Hand;
            btnErrores.FlatAppearance.BorderSize = 0;
            btnErrores.FlatStyle = FlatStyle.Flat;
            btnErrores.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnErrores.ForeColor = Color.White;
            btnErrores.Location = new Point(581, 16);
            btnErrores.Name = "btnErrores";
            btnErrores.Size = new Size(130, 40);
            btnErrores.TabIndex = 5;
            btnErrores.Text = "Errores técnicos";
            btnErrores.UseVisualStyleBackColor = false;
            btnErrores.Click += btnErrores_Click;
            // 
            // btnPromociones
            // 
            btnPromociones.BackColor = Color.FromArgb(52, 73, 94);
            btnPromociones.Cursor = Cursors.Hand;
            btnPromociones.FlatAppearance.BorderSize = 0;
            btnPromociones.FlatStyle = FlatStyle.Flat;
            btnPromociones.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPromociones.ForeColor = Color.White;
            btnPromociones.Location = new Point(445, 16);
            btnPromociones.Name = "btnPromociones";
            btnPromociones.Size = new Size(130, 40);
            btnPromociones.TabIndex = 4;
            btnPromociones.Text = "Promociones";
            btnPromociones.UseVisualStyleBackColor = false;
            btnPromociones.Click += btnPromociones_Click;
            // 
            // btnUsuario
            // 
            btnUsuario.BackColor = Color.FromArgb(52, 73, 94);
            btnUsuario.Cursor = Cursors.Hand;
            btnUsuario.FlatAppearance.BorderSize = 0;
            btnUsuario.FlatStyle = FlatStyle.Flat;
            btnUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUsuario.ForeColor = Color.White;
            btnUsuario.Location = new Point(18, 16);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(140, 40);
            btnUsuario.TabIndex = 0;
            btnUsuario.Text = "Usuarios ";
            btnUsuario.UseVisualStyleBackColor = false;
            btnUsuario.Click += btnUsuario_Click;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Controls.Add(lblBuscar);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(lblFechaDesde);
            pnlFiltros.Controls.Add(dtpFechaDesde);
            pnlFiltros.Controls.Add(lblFechaHasta);
            pnlFiltros.Controls.Add(dtpFechaHasta);
            pnlFiltros.Controls.Add(btnFiltrar);
            pnlFiltros.Controls.Add(btnLimpiar);
            pnlFiltros.Controls.Add(btnActualizar);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 143);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(20, 12, 20, 12);
            pnlFiltros.Size = new Size(1236, 75);
            pnlFiltros.TabIndex = 2;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(52, 73, 94);
            lblBuscar.Location = new Point(20, 9);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(44, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(20, 35);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(245, 25);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaDesde.ForeColor = Color.FromArgb(52, 73, 94);
            lblFechaDesde.Location = new Point(285, 10);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(42, 15);
            lblFechaDesde.TabIndex = 2;
            lblFechaDesde.Text = "Desde";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(285, 35);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(125, 23);
            dtpFechaDesde.TabIndex = 3;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaHasta.ForeColor = Color.FromArgb(52, 73, 94);
            lblFechaHasta.Location = new Point(425, 10);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(38, 15);
            lblFechaHasta.TabIndex = 4;
            lblFechaHasta.Text = "Hasta";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(425, 35);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(125, 23);
            dtpFechaHasta.TabIndex = 5;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(41, 128, 185);
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(565, 29);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(105, 34);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(236, 240, 241);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(210, 215, 220);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.FromArgb(52, 73, 94);
            btnLimpiar.Location = new Point(689, 29);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(105, 34);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(39, 174, 96);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(817, 29);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 34);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.White;
            pnlContenido.Controls.Add(dgvBitacora);
            pnlContenido.Controls.Add(lblCategoriaActual);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 218);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(18, 12, 18, 12);
            pnlContenido.Size = new Size(1236, 482);
            pnlContenido.TabIndex = 0;
            // 
            // dgvBitacora
            // 
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.AllowUserToDeleteRows = false;
            dgvBitacora.AllowUserToResizeColumns = false;
            dgvBitacora.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 247, 250);
            dgvBitacora.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBitacora.BackgroundColor = Color.White;
            dgvBitacora.BorderStyle = BorderStyle.None;
            dgvBitacora.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBitacora.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBitacora.ColumnHeadersHeight = 30;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(214, 234, 248);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(31, 45, 61);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBitacora.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBitacora.Dock = DockStyle.Fill;
            dgvBitacora.EnableHeadersVisualStyles = false;
            dgvBitacora.GridColor = Color.FromArgb(230, 234, 238);
            dgvBitacora.Location = new Point(18, 47);
            dgvBitacora.MultiSelect = false;
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.RowHeadersVisible = false;
            dgvBitacora.RowTemplate.Height = 22;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.Size = new Size(1200, 423);
            dgvBitacora.TabIndex = 0;
            // 
            // lblCategoriaActual
            // 
            lblCategoriaActual.Dock = DockStyle.Top;
            lblCategoriaActual.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCategoriaActual.ForeColor = Color.FromArgb(31, 45, 61);
            lblCategoriaActual.Location = new Point(18, 12);
            lblCategoriaActual.Name = "lblCategoriaActual";
            lblCategoriaActual.Size = new Size(1200, 35);
            lblCategoriaActual.TabIndex = 1;
            lblCategoriaActual.Text = "Registros de la bitácora";
            lblCategoriaActual.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDetalles
            // 
            pnlDetalles.BackColor = Color.White;
            pnlDetalles.Controls.Add(lblDetalles);
            pnlDetalles.Controls.Add(lblDetalleFecha);
            pnlDetalles.Controls.Add(lblDetalleUsuario);
            pnlDetalles.Controls.Add(lblDetalleAccion);
            pnlDetalles.Controls.Add(lblDetalleDescripcion);
            pnlDetalles.Dock = DockStyle.Bottom;
            pnlDetalles.Location = new Point(0, 550);
            pnlDetalles.Name = "pnlDetalles";
            pnlDetalles.Padding = new Padding(20, 5, 20, 5);
            pnlDetalles.Size = new Size(1236, 150);
            pnlDetalles.TabIndex = 1;
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetalles.ForeColor = Color.FromArgb(31, 45, 61);
            lblDetalles.Location = new Point(20, 5);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(138, 19);
            lblDetalles.TabIndex = 0;
            lblDetalles.Text = "Detalle del registro";
            // 
            // lblDetalleFecha
            // 
            lblDetalleFecha.AutoSize = true;
            lblDetalleFecha.Font = new Font("Segoe UI", 8F);
            lblDetalleFecha.ForeColor = Color.FromArgb(52, 73, 94);
            lblDetalleFecha.Location = new Point(22, 32);
            lblDetalleFecha.Name = "lblDetalleFecha";
            lblDetalleFecha.Size = new Size(82, 13);
            lblDetalleFecha.TabIndex = 1;
            lblDetalleFecha.Text = "Fecha y hora: -";
            // 
            // lblDetalleUsuario
            // 
            lblDetalleUsuario.AutoSize = true;
            lblDetalleUsuario.Font = new Font("Segoe UI", 8F);
            lblDetalleUsuario.ForeColor = Color.FromArgb(52, 73, 94);
            lblDetalleUsuario.Location = new Point(22, 55);
            lblDetalleUsuario.Name = "lblDetalleUsuario";
            lblDetalleUsuario.Size = new Size(57, 13);
            lblDetalleUsuario.TabIndex = 2;
            lblDetalleUsuario.Text = "Usuario: -";
            // 
            // lblDetalleAccion
            // 
            lblDetalleAccion.AutoSize = true;
            lblDetalleAccion.Font = new Font("Segoe UI", 8F);
            lblDetalleAccion.ForeColor = Color.FromArgb(52, 73, 94);
            lblDetalleAccion.Location = new Point(350, 32);
            lblDetalleAccion.Name = "lblDetalleAccion";
            lblDetalleAccion.Size = new Size(51, 13);
            lblDetalleAccion.TabIndex = 3;
            lblDetalleAccion.Text = "Acción: -";
            // 
            // lblDetalleDescripcion
            // 
            lblDetalleDescripcion.Font = new Font("Segoe UI", 8F);
            lblDetalleDescripcion.ForeColor = Color.FromArgb(52, 73, 94);
            lblDetalleDescripcion.Location = new Point(350, 55);
            lblDetalleDescripcion.Name = "lblDetalleDescripcion";
            lblDetalleDescripcion.Size = new Size(800, 55);
            lblDetalleDescripcion.TabIndex = 4;
            lblDetalleDescripcion.Text = "Descripción: -";
            // 
            // frmBitacora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1236, 700);
            Controls.Add(pnlDetalles);
            Controls.Add(pnlContenido);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlCategorias);
            Controls.Add(pnlEncabezado);
            Font = new Font("Segoe UI", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 700);
            Name = "frmBitacora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bitácora del sistema";
            WindowState = FormWindowState.Maximized;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlCategorias.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            pnlDetalles.ResumeLayout(false);
            pnlDetalles.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSeguridad;
        private Button btnProducto;
    }
}
