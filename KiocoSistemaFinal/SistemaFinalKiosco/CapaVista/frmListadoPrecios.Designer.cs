namespace CapaVista
{
    partial class frmListadoPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoPrecios));
            dgvListaPrecios = new DataGridView();
            clmCodigo = new DataGridViewTextBoxColumn();
            clmDescripcion = new DataGridViewTextBoxColumn();
            clmRubro = new DataGridViewTextBoxColumn();
            ClmPrecioVenta = new DataGridViewTextBoxColumn();
            clmPrecioActual = new DataGridViewTextBoxColumn();
            clmUnidadVenta = new DataGridViewTextBoxColumn();
            clmOferta = new DataGridViewTextBoxColumn();
            label1 = new Label();
            gpbSeleccionBusqueda = new GroupBox();
            cmbRubro = new ComboBox();
            chkOfertas = new CheckBox();
            label3 = new Label();
            txtProveedor = new TextBox();
            txtArticulo = new TextBox();
            label2 = new Label();
            btnBuscar = new Button();
            btnExportarPrecios = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListaPrecios).BeginInit();
            gpbSeleccionBusqueda.SuspendLayout();
            SuspendLayout();
            // 
            // dgvListaPrecios
            // 
            dgvListaPrecios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaPrecios.Columns.AddRange(new DataGridViewColumn[] { clmCodigo, clmDescripcion, clmRubro, ClmPrecioVenta, clmPrecioActual, clmUnidadVenta, clmOferta });
            dgvListaPrecios.Location = new Point(7, 163);
            dgvListaPrecios.Name = "dgvListaPrecios";
            dgvListaPrecios.Size = new Size(724, 150);
            dgvListaPrecios.TabIndex = 0;
            // 
            // clmCodigo
            // 
            clmCodigo.HeaderText = "Codigo";
            clmCodigo.Name = "clmCodigo";
            // 
            // clmDescripcion
            // 
            clmDescripcion.HeaderText = "Descripción";
            clmDescripcion.Name = "clmDescripcion";
            // 
            // clmRubro
            // 
            clmRubro.HeaderText = "Rubro";
            clmRubro.Name = "clmRubro";
            // 
            // ClmPrecioVenta
            // 
            ClmPrecioVenta.HeaderText = "Precio de Venta";
            ClmPrecioVenta.Name = "ClmPrecioVenta";
            // 
            // clmPrecioActual
            // 
            clmPrecioActual.HeaderText = "Precio actual";
            clmPrecioActual.Name = "clmPrecioActual";
            // 
            // clmUnidadVenta
            // 
            clmUnidadVenta.HeaderText = "Unidad Venta";
            clmUnidadVenta.Name = "clmUnidadVenta";
            // 
            // clmOferta
            // 
            clmOferta.HeaderText = "Oferta";
            clmOferta.Name = "clmOferta";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 29);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 3;
            label1.Text = "Articulo / Descripción";
            // 
            // gpbSeleccionBusqueda
            // 
            gpbSeleccionBusqueda.Controls.Add(cmbRubro);
            gpbSeleccionBusqueda.Controls.Add(chkOfertas);
            gpbSeleccionBusqueda.Controls.Add(label3);
            gpbSeleccionBusqueda.Controls.Add(txtProveedor);
            gpbSeleccionBusqueda.Controls.Add(txtArticulo);
            gpbSeleccionBusqueda.Controls.Add(label2);
            gpbSeleccionBusqueda.Controls.Add(label1);
            gpbSeleccionBusqueda.Location = new Point(7, 20);
            gpbSeleccionBusqueda.Name = "gpbSeleccionBusqueda";
            gpbSeleccionBusqueda.Size = new Size(446, 126);
            gpbSeleccionBusqueda.TabIndex = 4;
            gpbSeleccionBusqueda.TabStop = false;
            gpbSeleccionBusqueda.Text = "Buscar por Opciones";
            // 
            // cmbRubro
            // 
            cmbRubro.FormattingEnabled = true;
            cmbRubro.Location = new Point(139, 55);
            cmbRubro.Name = "cmbRubro";
            cmbRubro.Size = new Size(178, 23);
            cmbRubro.TabIndex = 11;
            // 
            // chkOfertas
            // 
            chkOfertas.AutoSize = true;
            chkOfertas.Location = new Point(353, 29);
            chkOfertas.Name = "chkOfertas";
            chkOfertas.Size = new Size(67, 19);
            chkOfertas.TabIndex = 10;
            chkOfertas.Text = "Ofertas ";
            chkOfertas.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 87);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 8;
            label3.Text = "Proveedor";
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(139, 84);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(178, 23);
            txtProveedor.TabIndex = 7;
            // 
            // txtArticulo
            // 
            txtArticulo.Location = new Point(139, 26);
            txtArticulo.Name = "txtArticulo";
            txtArticulo.Size = new Size(178, 23);
            txtArticulo.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 58);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Rubro";
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(459, 29);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(99, 64);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnExportarPrecios
            // 
            btnExportarPrecios.Image = (Image)resources.GetObject("btnExportarPrecios.Image");
            btnExportarPrecios.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportarPrecios.Location = new Point(564, 29);
            btnExportarPrecios.Name = "btnExportarPrecios";
            btnExportarPrecios.Size = new Size(113, 64);
            btnExportarPrecios.TabIndex = 6;
            btnExportarPrecios.Text = "Exportar Lista";
            btnExportarPrecios.TextAlign = ContentAlignment.MiddleRight;
            btnExportarPrecios.UseVisualStyleBackColor = true;
            btnExportarPrecios.Click += btnExportarPrecios_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(628, 340);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmListadoPrecios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 378);
            Controls.Add(btnSalir);
            Controls.Add(btnExportarPrecios);
            Controls.Add(btnBuscar);
            Controls.Add(gpbSeleccionBusqueda);
            Controls.Add(dgvListaPrecios);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmListadoPrecios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado de Precios";
            ((System.ComponentModel.ISupportInitialize)dgvListaPrecios).EndInit();
            gpbSeleccionBusqueda.ResumeLayout(false);
            gpbSeleccionBusqueda.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvListaPrecios;
        private DataGridViewTextBoxColumn clmCodigo;
        private DataGridViewTextBoxColumn clmDescripcion;
        private DataGridViewTextBoxColumn clmRubro;
        private DataGridViewTextBoxColumn ClmPrecioVenta;
        private DataGridViewTextBoxColumn clmPrecioActual;
        private DataGridViewTextBoxColumn clmUnidadVenta;
        private DataGridViewTextBoxColumn clmOferta;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private GroupBox gpbSeleccionBusqueda;
        private Label label3;
        private TextBox txtProveedor;
        private TextBox textBox2;
        private TextBox txtArticulo;
        private Label label2;
        private Button btnBuscar;
        private CheckBox chkOfertas;
        private Button btnExportarPrecios;
        private Button btnSalir;
        private ComboBox cmbRubro;
    }
}