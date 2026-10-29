namespace CapaVista
{
    partial class frmPromocion
    {
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromocion));
            lblNombrePromo = new Label();
            txtNombrePromocion = new TextBox();
            lblCodigoPromo = new Label();
            txtCodigoPromocion = new TextBox();
            gpbDatosGenerales = new GroupBox();
            btnCofigurarFechas = new Button();
            lblResumenVigencia = new Label();
            gpbSeleccionarArticulo = new GroupBox();
            btnAgregarProducto = new Button();
            lblDescripcion = new Label();
            dgtCargaArticulo = new DataGridView();
            clnProducto = new DataGridViewTextBoxColumn();
            clnCantidad = new DataGridViewTextBoxColumn();
            clnPrecio = new DataGridViewTextBoxColumn();
            clnEliminar = new DataGridViewButtonColumn();
            gpbTipoPromocion = new GroupBox();
            cmbDescuentoVolumen = new ComboBox();
            lblDescuentoVolumen = new Label();
            btnAgregarMecanica = new Button();
            txtBajaPrecio = new TextBox();
            label3 = new Label();
            label2 = new Label();
            cmbMecanicaPromocional = new ComboBox();
            txtDescuentoPorcentual = new TextBox();
            lblMecanicaPromo = new Label();
            lblDescuentoPorcentual = new Label();
            lstPromocionesEncontradas = new ListBox();
            gpbVistaPrevia = new GroupBox();
            label12 = new Label();
            lblPrecioPromocional = new Label();
            label10 = new Label();
            lblDescuento = new Label();
            label8 = new Label();
            label7 = new Label();
            lblPrecioNormal = new Label();
            label5 = new Label();
            label4 = new Label();
            btnGuardarPromo = new Button();
            btnEliminar = new Button();
            btnVolver = new Button();
            label14 = new Label();
            lblBuscarPromo = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtBuscarPromo = new TextBox();
            chkDesactivarPromo = new CheckBox();
            gpbModificar = new GroupBox();
            lblPromoDescrip = new Label();
            gpbDatosGenerales.SuspendLayout();
            gpbSeleccionarArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgtCargaArticulo).BeginInit();
            gpbTipoPromocion.SuspendLayout();
            gpbVistaPrevia.SuspendLayout();
            gpbModificar.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombrePromo
            // 
            lblNombrePromo.AutoSize = true;
            lblNombrePromo.Location = new Point(6, 19);
            lblNombrePromo.Name = "lblNombrePromo";
            lblNombrePromo.Size = new Size(141, 15);
            lblNombrePromo.TabIndex = 1;
            lblNombrePromo.Text = "Nombre de la Promoción";
            // 
            // txtNombrePromocion
            // 
            txtNombrePromocion.Location = new Point(9, 36);
            txtNombrePromocion.Name = "txtNombrePromocion";
            txtNombrePromocion.Size = new Size(218, 23);
            txtNombrePromocion.TabIndex = 5;
            // 
            // lblCodigoPromo
            // 
            lblCodigoPromo.AutoSize = true;
            lblCodigoPromo.Location = new Point(259, 19);
            lblCodigoPromo.Name = "lblCodigoPromo";
            lblCodigoPromo.Size = new Size(136, 15);
            lblCodigoPromo.TabIndex = 6;
            lblCodigoPromo.Text = "Código de la promoción";
            // 
            // txtCodigoPromocion
            // 
            txtCodigoPromocion.Enabled = false;
            txtCodigoPromocion.BackColor = SystemColors.Window;
            txtCodigoPromocion.Location = new Point(259, 36);
            txtCodigoPromocion.Multiline = true;
            txtCodigoPromocion.Name = "txtCodigoPromocion";
            txtCodigoPromocion.Size = new Size(136, 23);
            txtCodigoPromocion.TabIndex = 7;
            txtCodigoPromocion.TabStop = false;
            txtCodigoPromocion.Cursor = Cursors.Default;
            txtCodigoPromocion.WordWrap = false;
            // 
            // gpbDatosGenerales
            // 
            gpbDatosGenerales.Controls.Add(btnCofigurarFechas);
            gpbDatosGenerales.Controls.Add(lblResumenVigencia);
            gpbDatosGenerales.Controls.Add(lblNombrePromo);
            gpbDatosGenerales.Controls.Add(txtCodigoPromocion);
            gpbDatosGenerales.Controls.Add(lblCodigoPromo);
            gpbDatosGenerales.Controls.Add(txtNombrePromocion);
            gpbDatosGenerales.Location = new Point(12, 73);
            gpbDatosGenerales.Name = "gpbDatosGenerales";
            gpbDatosGenerales.Size = new Size(494, 155);
            gpbDatosGenerales.TabIndex = 8;
            gpbDatosGenerales.TabStop = false;
            gpbDatosGenerales.Text = "Datos Generales";
            // 
            // btnCofigurarFechas
            // 
            btnCofigurarFechas.FlatStyle = FlatStyle.Popup;
            btnCofigurarFechas.Location = new Point(15, 65);
            btnCofigurarFechas.Name = "btnCofigurarFechas";
            btnCofigurarFechas.Size = new Size(453, 44);
            btnCofigurarFechas.TabIndex = 8;
            btnCofigurarFechas.Text = "Configurar fechas y horarios \r\nFechas, días de la semana y franjas horarias.\r\n";
            btnCofigurarFechas.UseVisualStyleBackColor = true;
            btnCofigurarFechas.Click += btnCofigurarFechas_Click;
            // 
            // lblResumenVigencia
            // 
            lblResumenVigencia.BackColor = Color.Honeydew;
            lblResumenVigencia.BorderStyle = BorderStyle.FixedSingle;
            lblResumenVigencia.ForeColor = Color.DarkGreen;
            lblResumenVigencia.Location = new Point(15, 110);
            lblResumenVigencia.Name = "lblResumenVigencia";
            lblResumenVigencia.Size = new Size(453, 35);
            lblResumenVigencia.TabIndex = 22;
            lblResumenVigencia.Text = "Vigencia sin configurar";
            lblResumenVigencia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gpbSeleccionarArticulo
            // 
            gpbSeleccionarArticulo.Controls.Add(btnAgregarProducto);
            gpbSeleccionarArticulo.Controls.Add(lblDescripcion);
            gpbSeleccionarArticulo.Controls.Add(dgtCargaArticulo);
            gpbSeleccionarArticulo.Location = new Point(12, 234);
            gpbSeleccionarArticulo.Name = "gpbSeleccionarArticulo";
            gpbSeleccionarArticulo.Size = new Size(494, 238);
            gpbSeleccionarArticulo.TabIndex = 9;
            gpbSeleccionarArticulo.TabStop = false;
            gpbSeleccionarArticulo.Text = "Seleccionar Artículos";
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(333, 202);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(135, 30);
            btnAgregarProducto.TabIndex = 2;
            btnAgregarProducto.Text = "+Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(6, 28);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(436, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Buscás cada producto por nombre, código de barras o SKU y lo agregás a la grilla.";
            // 
            // dgtCargaArticulo
            // 
            dgtCargaArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtCargaArticulo.Columns.AddRange(new DataGridViewColumn[] { clnProducto, clnCantidad, clnPrecio, clnEliminar });
            dgtCargaArticulo.Location = new Point(9, 46);
            dgtCargaArticulo.Name = "dgtCargaArticulo";
            dgtCargaArticulo.Size = new Size(459, 150);
            dgtCargaArticulo.TabIndex = 0;
            dgtCargaArticulo.CellContentClick += dgtCargaArticulo_CellContentClick;
            // 
            // clnProducto
            // 
            clnProducto.HeaderText = "Producto";
            clnProducto.Name = "clnProducto";
            // 
            // clnCantidad
            // 
            clnCantidad.HeaderText = "Cantidad";
            clnCantidad.Name = "clnCantidad";
            // 
            // clnPrecio
            // 
            clnPrecio.HeaderText = "Precio";
            clnPrecio.Name = "clnPrecio";
            // 
            // clnEliminar
            // 
            clnEliminar.HeaderText = "Eliminar";
            clnEliminar.Name = "clnEliminar";
            clnEliminar.Resizable = DataGridViewTriState.True;
            clnEliminar.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // gpbTipoPromocion
            // 
            gpbTipoPromocion.Controls.Add(cmbDescuentoVolumen);
            gpbTipoPromocion.Controls.Add(lblDescuentoVolumen);
            gpbTipoPromocion.Controls.Add(btnAgregarMecanica);
            gpbTipoPromocion.Controls.Add(txtBajaPrecio);
            gpbTipoPromocion.Controls.Add(label3);
            gpbTipoPromocion.Controls.Add(label2);
            gpbTipoPromocion.Controls.Add(cmbMecanicaPromocional);
            gpbTipoPromocion.Controls.Add(txtDescuentoPorcentual);
            gpbTipoPromocion.Controls.Add(lblMecanicaPromo);
            gpbTipoPromocion.Controls.Add(lblDescuentoPorcentual);
            gpbTipoPromocion.Location = new Point(525, 166);
            gpbTipoPromocion.Name = "gpbTipoPromocion";
            gpbTipoPromocion.Size = new Size(494, 165);
            gpbTipoPromocion.TabIndex = 10;
            gpbTipoPromocion.TabStop = false;
            gpbTipoPromocion.Text = "Tipo de Promoción";
            // 
            // cmbDescuentoVolumen
            // 
            cmbDescuentoVolumen.FormattingEnabled = true;
            cmbDescuentoVolumen.Location = new Point(11, 101);
            cmbDescuentoVolumen.Name = "cmbDescuentoVolumen";
            cmbDescuentoVolumen.Size = new Size(134, 23);
            cmbDescuentoVolumen.TabIndex = 9;
            cmbDescuentoVolumen.SelectedIndexChanged += cmbDescuentoVolumen_SelectedIndexChanged;
            // 
            // lblDescuentoVolumen
            // 
            lblDescuentoVolumen.AutoSize = true;
            lblDescuentoVolumen.Location = new Point(11, 83);
            lblDescuentoVolumen.Name = "lblDescuentoVolumen";
            lblDescuentoVolumen.Size = new Size(134, 15);
            lblDescuentoVolumen.TabIndex = 8;
            lblDescuentoVolumen.Text = "Descuento por volumen";
            // 
            // btnAgregarMecanica
            // 
            btnAgregarMecanica.Location = new Point(307, 105);
            btnAgregarMecanica.Name = "btnAgregarMecanica";
            btnAgregarMecanica.Size = new Size(161, 30);
            btnAgregarMecanica.TabIndex = 7;
            btnAgregarMecanica.Text = "+ Agregar mecánica";
            btnAgregarMecanica.UseVisualStyleBackColor = true;
            btnAgregarMecanica.Click += btnAgregarMecanica_Click;
            // 
            // txtBajaPrecio
            // 
            txtBajaPrecio.Location = new Point(185, 40);
            txtBajaPrecio.Name = "txtBajaPrecio";
            txtBajaPrecio.Size = new Size(118, 23);
            txtBajaPrecio.TabIndex = 6;
            txtBajaPrecio.TextChanged += txtBajaPrecio_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(185, 22);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 5;
            label3.Text = "Precio especial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(403, 43);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 4;
            label2.Text = "%";
            // 
            // cmbMecanicaPromocional
            // 
            cmbMecanicaPromocional.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMecanicaPromocional.FormattingEnabled = true;
            cmbMecanicaPromocional.Location = new Point(10, 40);
            cmbMecanicaPromocional.Name = "cmbMecanicaPromocional";
            cmbMecanicaPromocional.Size = new Size(151, 23);
            cmbMecanicaPromocional.TabIndex = 3;
            cmbMecanicaPromocional.SelectedIndexChanged += cmbMecanicaPromocional_SelectedIndexChanged;
            // 
            // txtDescuentoPorcentual
            // 
            txtDescuentoPorcentual.Location = new Point(332, 40);
            txtDescuentoPorcentual.Name = "txtDescuentoPorcentual";
            txtDescuentoPorcentual.Size = new Size(65, 23);
            txtDescuentoPorcentual.TabIndex = 2;
            txtDescuentoPorcentual.TextChanged += txtDescuentoPorcentual_TextChanged;
            // 
            // lblMecanicaPromo
            // 
            lblMecanicaPromo.AutoSize = true;
            lblMecanicaPromo.Location = new Point(10, 22);
            lblMecanicaPromo.Name = "lblMecanicaPromo";
            lblMecanicaPromo.Size = new Size(148, 15);
            lblMecanicaPromo.TabIndex = 1;
            lblMecanicaPromo.Text = "Mecánica de la promoción";
            lblMecanicaPromo.Click += lblMecanicaPromo_Click;
            // 
            // lblDescuentoPorcentual
            // 
            lblDescuentoPorcentual.AutoSize = true;
            lblDescuentoPorcentual.Location = new Point(332, 22);
            lblDescuentoPorcentual.Name = "lblDescuentoPorcentual";
            lblDescuentoPorcentual.Size = new Size(123, 15);
            lblDescuentoPorcentual.TabIndex = 0;
            lblDescuentoPorcentual.Text = "Descuento porcentual";
            // 
            // lstPromocionesEncontradas
            // 
            lstPromocionesEncontradas.FormattingEnabled = true;
            lstPromocionesEncontradas.ItemHeight = 15;
            lstPromocionesEncontradas.Location = new Point(113, 52);
            lstPromocionesEncontradas.Name = "lstPromocionesEncontradas";
            lstPromocionesEncontradas.Size = new Size(244, 79);
            lstPromocionesEncontradas.TabIndex = 21;
            lstPromocionesEncontradas.DrawItem += lstPromocionesEncontradas_DrawItem;
            lstPromocionesEncontradas.SelectedIndexChanged += lstPromocionesEncontradas_SelectedIndexChanged;
            lstPromocionesEncontradas.DoubleClick += lstPromocionesEncontradas_DoubleClick;
            // 
            // gpbVistaPrevia
            // 
            gpbVistaPrevia.Controls.Add(label12);
            gpbVistaPrevia.Controls.Add(lblPrecioPromocional);
            gpbVistaPrevia.Controls.Add(label10);
            gpbVistaPrevia.Controls.Add(lblDescuento);
            gpbVistaPrevia.Controls.Add(label8);
            gpbVistaPrevia.Controls.Add(label7);
            gpbVistaPrevia.Controls.Add(lblPrecioNormal);
            gpbVistaPrevia.Controls.Add(label5);
            gpbVistaPrevia.Controls.Add(label4);
            gpbVistaPrevia.Location = new Point(525, 337);
            gpbVistaPrevia.Name = "gpbVistaPrevia";
            gpbVistaPrevia.Size = new Size(494, 135);
            gpbVistaPrevia.TabIndex = 11;
            gpbVistaPrevia.TabStop = false;
            gpbVistaPrevia.Text = "Vista previa";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(395, 99);
            label12.Name = "label12";
            label12.Size = new Size(23, 25);
            label12.TabIndex = 8;
            label12.Text = "$";
            // 
            // lblPrecioPromocional
            // 
            lblPrecioPromocional.AutoSize = true;
            lblPrecioPromocional.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioPromocional.Location = new Point(424, 99);
            lblPrecioPromocional.Name = "lblPrecioPromocional";
            lblPrecioPromocional.Size = new Size(56, 25);
            lblPrecioPromocional.TabIndex = 7;
            lblPrecioPromocional.Text = "0000";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(6, 99);
            label10.Name = "label10";
            label10.Size = new Size(187, 25);
            label10.TabIndex = 6;
            label10.Text = "Precio Promocional";
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Location = new Point(81, 72);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(19, 15);
            lblDescuento.TabIndex = 5;
            lblDescuento.Text = "00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(118, 72);
            label8.Name = "label8";
            label8.Size = new Size(17, 15);
            label8.TabIndex = 4;
            label8.Text = "%";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 72);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 3;
            label7.Text = "Descuento";
            // 
            // lblPrecioNormal
            // 
            lblPrecioNormal.AutoSize = true;
            lblPrecioNormal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioNormal.Location = new Point(29, 44);
            lblPrecioNormal.Name = "lblPrecioNormal";
            lblPrecioNormal.Size = new Size(36, 17);
            lblPrecioNormal.TabIndex = 2;
            lblPrecioNormal.Text = "0000";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(10, 44);
            label5.Name = "label5";
            label5.Size = new Size(15, 17);
            label5.TabIndex = 1;
            label5.Text = "$";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 19);
            label4.Name = "label4";
            label4.Size = new Size(141, 15);
            label4.TabIndex = 0;
            label4.Text = "Precio normal del combo";
            // 
            // btnGuardarPromo
            // 
            btnGuardarPromo.Location = new Point(889, 495);
            btnGuardarPromo.Name = "btnGuardarPromo";
            btnGuardarPromo.Size = new Size(125, 23);
            btnGuardarPromo.TabIndex = 12;
            btnGuardarPromo.Text = "Guardar Promoción";
            btnGuardarPromo.UseVisualStyleBackColor = true;
            btnGuardarPromo.Click += btnGuardarPromo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(810, 495);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(729, 495);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 15;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(15, 9);
            label14.Name = "label14";
            label14.Size = new Size(392, 42);
            label14.TabIndex = 16;
            label14.Text = "Gestión de promociones\r\nCrear, editar y administrar promociones del kiosco";
            // 
            // lblBuscarPromo
            // 
            lblBuscarPromo.AutoSize = true;
            lblBuscarPromo.Location = new Point(6, 34);
            lblBuscarPromo.Name = "lblBuscarPromo";
            lblBuscarPromo.Size = new Size(107, 15);
            lblBuscarPromo.TabIndex = 18;
            lblBuscarPromo.Text = "Buscar Promoción.";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtBuscarPromo
            // 
            txtBuscarPromo.Location = new Point(113, 26);
            txtBuscarPromo.Name = "txtBuscarPromo";
            txtBuscarPromo.Size = new Size(244, 23);
            txtBuscarPromo.TabIndex = 20;
            txtBuscarPromo.TextChanged += txtBuscarPromo_TextChanged;
            // 
            // chkDesactivarPromo
            // 
            chkDesactivarPromo.AutoSize = true;
            chkDesactivarPromo.Location = new Point(371, 27);
            chkDesactivarPromo.Name = "chkDesactivarPromo";
            chkDesactivarPromo.Size = new Size(142, 19);
            chkDesactivarPromo.TabIndex = 22;
            chkDesactivarPromo.Text = "Desactivar Promoción";
            chkDesactivarPromo.UseVisualStyleBackColor = true;
            chkDesactivarPromo.CheckedChanged += chkDesactivarPromo_CheckedChanged;
            // 
            // gpbModificar
            // 
            gpbModificar.Controls.Add(lblPromoDescrip);
            gpbModificar.Controls.Add(lstPromocionesEncontradas);
            gpbModificar.Controls.Add(lblBuscarPromo);
            gpbModificar.Controls.Add(chkDesactivarPromo);
            gpbModificar.Controls.Add(txtBuscarPromo);
            gpbModificar.Location = new Point(512, 12);
            gpbModificar.Name = "gpbModificar";
            gpbModificar.Size = new Size(519, 135);
            gpbModificar.TabIndex = 23;
            gpbModificar.TabStop = false;
            gpbModificar.Text = "Seleccionar promoción para modificar";
            // 
            // lblPromoDescrip
            // 
            lblPromoDescrip.AutoSize = true;
            lblPromoDescrip.Location = new Point(6, 105);
            lblPromoDescrip.Name = "lblPromoDescrip";
            lblPromoDescrip.Size = new Size(352, 15);
            lblPromoDescrip.TabIndex = 23;
            lblPromoDescrip.Text = "* Las promociónes que estan en rojo son las que estan desactivas.";
            // 
            // frmPromocion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 530);
            Controls.Add(label14);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardarPromo);
            Controls.Add(gpbVistaPrevia);
            Controls.Add(gpbTipoPromocion);
            Controls.Add(gpbSeleccionarArticulo);
            Controls.Add(gpbDatosGenerales);
            Controls.Add(gpbModificar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPromocion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Promociones";
            Load += frmPromocion_Load;
            gpbDatosGenerales.ResumeLayout(false);
            gpbDatosGenerales.PerformLayout();
            gpbSeleccionarArticulo.ResumeLayout(false);
            gpbSeleccionarArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgtCargaArticulo).EndInit();
            gpbTipoPromocion.ResumeLayout(false);
            gpbTipoPromocion.PerformLayout();
            gpbVistaPrevia.ResumeLayout(false);
            gpbVistaPrevia.PerformLayout();
            gpbModificar.ResumeLayout(false);
            gpbModificar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombrePromo;
        private TextBox txtNombrePromocion;
        private Label lblCodigoPromo;
        private TextBox txtCodigoPromocion;
        private GroupBox gpbDatosGenerales;
        private GroupBox gpbSeleccionarArticulo;
        private Button btnAgregarProducto;
        private Label lblDescripcion;
        private DataGridView dgtCargaArticulo;
        private GroupBox gpbTipoPromocion;
        private Label lblDescuentoPorcentual;
        private ComboBox cmbMecanicaPromocional;
        private TextBox txtDescuentoPorcentual;
        private Label lblMecanicaPromo;
        private TextBox txtBajaPrecio;
        private Label label3;
        private Label label2;
        private Button btnAgregarMecanica;
        private GroupBox gpbVistaPrevia;
        private Label label13;
        private Label label12;
        private Label lblPrecioPromocional;
        private Label label10;
        private Label lblDescuento;
        private Label label8;
        private Label label7;
        private Label lblPrecioNormal;
        private Label label5;
        private Label label4;
        private Button btnGuardarPromo;
        private Button btnEliminar;
        private Button btnVolver;
        private Label label14;
        private Label lblBuscarPromo;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtBuscarPromo;
        private ListBox lstPromocionesEncontradas;
        private Button btnCofigurarFechas;
        private Label lblResumenVigencia;
        private ComboBox cmbDescuentoVolumen;
        private Label lblDescuentoVolumen;
        private DataGridViewTextBoxColumn clnProducto;
        private DataGridViewTextBoxColumn clnCantidad;
        private DataGridViewTextBoxColumn clnPrecio;
        private DataGridViewButtonColumn clnEliminar;
        private CheckBox chkDesactivarPromo;
        private GroupBox gpbModificar;
        private Label lblPromoDescrip;
    }
}
