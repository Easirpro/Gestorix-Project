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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBitacora));
            pnlEncabezado = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlCategorias = new Panel();
            btnUsuario = new Button();
            btnSeguridad = new Button();
            btnProducto = new Button();
            btnCompras = new Button();
            btnPromociones = new Button();
            btnErrores = new Button();
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
            btnSalir = new Button();
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
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Padding = new Padding(12, 10, 12, 0);
            pnlEncabezado.Size = new Size(1000, 58);
            pnlEncabezado.TabIndex = 4;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(190, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Bitácora del sistema";
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = SystemColors.GrayText;
            lblSubtitulo.Location = new Point(14, 37);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(344, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Registro y seguimiento de las operaciones realizadas en Gestorix";
            lblSubtitulo.Click += lblSubtitulo_Click;
            //
            // pnlCategorias
            //
            pnlCategorias.Controls.Add(btnUsuario);
            pnlCategorias.Controls.Add(btnSeguridad);
            pnlCategorias.Controls.Add(btnProducto);
            pnlCategorias.Controls.Add(btnCompras);
            pnlCategorias.Controls.Add(btnPromociones);
            pnlCategorias.Controls.Add(btnErrores);
            pnlCategorias.Dock = DockStyle.Top;
            pnlCategorias.Location = new Point(0, 58);
            pnlCategorias.Name = "pnlCategorias";
            pnlCategorias.Padding = new Padding(12, 4, 12, 4);
            pnlCategorias.Size = new Size(1000, 42);
            pnlCategorias.TabIndex = 3;
            //
            // btnUsuario
            //
            btnUsuario.Location = new Point(12, 4);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(120, 32);
            btnUsuario.TabIndex = 0;
            btnUsuario.Text = "Usuarios";
            btnUsuario.UseVisualStyleBackColor = true;
            btnUsuario.Click += btnUsuario_Click;
            //
            // btnSeguridad
            //
            btnSeguridad.Location = new Point(138, 4);
            btnSeguridad.Name = "btnSeguridad";
            btnSeguridad.Size = new Size(120, 32);
            btnSeguridad.TabIndex = 1;
            btnSeguridad.Text = "Seguridad";
            btnSeguridad.UseVisualStyleBackColor = true;
            btnSeguridad.Click += btnSeguridad_Click;
            //
            // btnProducto
            //
            btnProducto.Location = new Point(264, 4);
            btnProducto.Name = "btnProducto";
            btnProducto.Size = new Size(120, 32);
            btnProducto.TabIndex = 2;
            btnProducto.Text = "Productos";
            btnProducto.UseVisualStyleBackColor = true;
            btnProducto.Click += btnProducto_Click;
            //
            // btnCompras
            //
            btnCompras.Location = new Point(390, 4);
            btnCompras.Name = "btnCompras";
            btnCompras.Size = new Size(120, 32);
            btnCompras.TabIndex = 3;
            btnCompras.Text = "Compras";
            btnCompras.UseVisualStyleBackColor = true;
            btnCompras.Click += btnCompras_Click;
            //
            // btnPromociones
            //
            btnPromociones.Location = new Point(516, 4);
            btnPromociones.Name = "btnPromociones";
            btnPromociones.Size = new Size(120, 32);
            btnPromociones.TabIndex = 4;
            btnPromociones.Text = "Promociones";
            btnPromociones.UseVisualStyleBackColor = true;
            btnPromociones.Click += btnPromociones_Click;
            //
            // btnErrores
            //
            btnErrores.ForeColor = Color.Firebrick;
            btnErrores.Location = new Point(642, 4);
            btnErrores.Name = "btnErrores";
            btnErrores.Size = new Size(120, 32);
            btnErrores.TabIndex = 5;
            btnErrores.Text = "Errores técnicos";
            btnErrores.UseVisualStyleBackColor = true;
            btnErrores.Click += btnErrores_Click;
            //
            // pnlFiltros
            //
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
            pnlFiltros.Location = new Point(0, 100);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(12, 6, 12, 6);
            pnlFiltros.Size = new Size(1000, 44);
            pnlFiltros.TabIndex = 2;
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 15);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.Location = new Point(63, 11);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(230, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            //
            // lblFechaDesde
            //
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Location = new Point(310, 15);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(42, 15);
            lblFechaDesde.TabIndex = 2;
            lblFechaDesde.Text = "Desde:";
            //
            // dtpFechaDesde
            //
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(358, 11);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(115, 23);
            dtpFechaDesde.TabIndex = 3;
            //
            // lblFechaHasta
            //
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(485, 15);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(40, 15);
            lblFechaHasta.TabIndex = 4;
            lblFechaHasta.Text = "Hasta:";
            //
            // dtpFechaHasta
            //
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(531, 11);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(115, 23);
            dtpFechaHasta.TabIndex = 5;
            //
            // btnFiltrar
            //
            btnFiltrar.Location = new Point(660, 9);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(100, 28);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Location = new Point(766, 9);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 28);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // btnActualizar
            //
            btnActualizar.Location = new Point(872, 9);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 28);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // pnlContenido
            //
            pnlContenido.Controls.Add(dgvBitacora);
            pnlContenido.Controls.Add(lblCategoriaActual);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 144);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(12, 4, 12, 6);
            pnlContenido.Size = new Size(1000, 366);
            pnlContenido.TabIndex = 0;
            //
            // dgvBitacora
            //
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.AllowUserToDeleteRows = false;
            dgvBitacora.AllowUserToResizeColumns = false;
            dgvBitacora.AllowUserToResizeRows = false;
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBitacora.BackgroundColor = SystemColors.Window;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Dock = DockStyle.Fill;
            dgvBitacora.Location = new Point(12, 26);
            dgvBitacora.MultiSelect = false;
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.RowHeadersVisible = false;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.Size = new Size(976, 334);
            dgvBitacora.TabIndex = 0;
            //
            // lblCategoriaActual
            //
            lblCategoriaActual.Dock = DockStyle.Top;
            lblCategoriaActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoriaActual.Location = new Point(12, 4);
            lblCategoriaActual.Name = "lblCategoriaActual";
            lblCategoriaActual.Size = new Size(976, 22);
            lblCategoriaActual.TabIndex = 1;
            lblCategoriaActual.Text = "Registros de la bitácora";
            lblCategoriaActual.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlDetalles
            //
            pnlDetalles.BorderStyle = BorderStyle.FixedSingle;
            pnlDetalles.Controls.Add(lblDetalles);
            pnlDetalles.Controls.Add(lblDetalleFecha);
            pnlDetalles.Controls.Add(lblDetalleUsuario);
            pnlDetalles.Controls.Add(lblDetalleAccion);
            pnlDetalles.Controls.Add(lblDetalleDescripcion);
            pnlDetalles.Controls.Add(btnSalir);
            pnlDetalles.Dock = DockStyle.Bottom;
            pnlDetalles.Location = new Point(0, 510);
            pnlDetalles.Name = "pnlDetalles";
            pnlDetalles.Padding = new Padding(12, 6, 12, 6);
            pnlDetalles.Size = new Size(1000, 110);
            pnlDetalles.TabIndex = 1;
            //
            // lblDetalles
            //
            lblDetalles.AutoSize = true;
            lblDetalles.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetalles.Location = new Point(12, 6);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(114, 15);
            lblDetalles.TabIndex = 0;
            lblDetalles.Text = "Detalle del registro";
            //
            // lblDetalleFecha
            //
            lblDetalleFecha.AutoSize = true;
            lblDetalleFecha.Location = new Point(14, 32);
            lblDetalleFecha.Name = "lblDetalleFecha";
            lblDetalleFecha.Size = new Size(85, 15);
            lblDetalleFecha.TabIndex = 1;
            lblDetalleFecha.Text = "Fecha y hora: -";
            //
            // lblDetalleUsuario
            //
            lblDetalleUsuario.AutoSize = true;
            lblDetalleUsuario.Location = new Point(14, 56);
            lblDetalleUsuario.Name = "lblDetalleUsuario";
            lblDetalleUsuario.Size = new Size(60, 15);
            lblDetalleUsuario.TabIndex = 2;
            lblDetalleUsuario.Text = "Usuario: -";
            //
            // lblDetalleAccion
            //
            lblDetalleAccion.AutoSize = true;
            lblDetalleAccion.Location = new Point(330, 32);
            lblDetalleAccion.Name = "lblDetalleAccion";
            lblDetalleAccion.Size = new Size(54, 15);
            lblDetalleAccion.TabIndex = 3;
            lblDetalleAccion.Text = "Acción: -";
            //
            // lblDetalleDescripcion
            //
            lblDetalleDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetalleDescripcion.Location = new Point(330, 56);
            lblDetalleDescripcion.Name = "lblDetalleDescripcion";
            lblDetalleDescripcion.Size = new Size(530, 45);
            lblDetalleDescripcion.TabIndex = 4;
            lblDetalleDescripcion.Text = "Descripción: -";
            //
            // btnSalir
            //
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(876, 69);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(100, 32);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // frmBitacora
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 620);
            Controls.Add(pnlContenido);
            Controls.Add(pnlDetalles);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlCategorias);
            Controls.Add(pnlEncabezado);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1016, 659);
            Name = "frmBitacora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bitácora del sistema";
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
        private Button btnCompras;
        private Button btnSalir;
    }
}