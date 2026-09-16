namespace CapaVista
{
    partial class frmNuevoArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoArticulo));
            btnCancelar = new Button();
            btnGuardar = new Button();
            label12 = new Label();
            label15 = new Label();
            txtCodigo = new TextBox();
            txtDescripcion = new TextBox();
            tbpVencimiento = new TabPage();
            chkControlLote = new CheckBox();
            dtpFechaFabricacion = new DateTimePicker();
            txtCodigoPorLote = new TextBox();
            lblFechaFabricacion = new Label();
            txtCodigoLote = new Label();
            txtAlertaVencimiento = new TextBox();
            dtpFechaVencimiento = new DateTimePicker();
            label11 = new Label();
            label10 = new Label();
            chkAlertaVencimiento = new CheckBox();
            tbpStock = new TabPage();
            chkControlStock = new CheckBox();
            txtStockMaximo = new TextBox();
            txtStockMinimo = new TextBox();
            txtStockActual = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            tbpPrecio = new TabPage();
            gpbCargarPrecio = new GroupBox();
            chkActivarIva = new CheckBox();
            cmbIva = new ComboBox();
            txtPrecioVenta = new TextBox();
            txtGanancia = new TextBox();
            txtPrecioCosto = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            tpgGeneral = new TabPage();
            cmbRubro = new ComboBox();
            cmbUnidadVenta = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            tabControl1 = new TabControl();
            Marca = new TabPage();
            cmbMarca = new ComboBox();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            txtSKU = new TextBox();
            txtNombreProducto = new TextBox();
            tbpProveedor = new TabPage();
            cmbSucursal = new ComboBox();
            cmbProveedor = new ComboBox();
            label14 = new Label();
            label13 = new Label();
            tbpVencimiento.SuspendLayout();
            tbpStock.SuspendLayout();
            tbpPrecio.SuspendLayout();
            gpbCargarPrecio.SuspendLayout();
            tpgGeneral.SuspendLayout();
            tabControl1.SuspendLayout();
            Marca.SuspendLayout();
            tbpProveedor.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(313, 311);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 27);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(221, 311);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(82, 27);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(16, 28);
            label12.Name = "label12";
            label12.Size = new Size(57, 15);
            label12.TabIndex = 5;
            label12.Text = "Código: *";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(16, 58);
            label15.Name = "label15";
            label15.Size = new Size(80, 15);
            label15.TabIndex = 6;
            label15.Text = "Descripción: *";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(96, 21);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(141, 23);
            txtCodigo.TabIndex = 7;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(96, 50);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(301, 23);
            txtDescripcion.TabIndex = 8;
            // 
            // tbpVencimiento
            // 
            tbpVencimiento.Controls.Add(chkControlLote);
            tbpVencimiento.Controls.Add(dtpFechaFabricacion);
            tbpVencimiento.Controls.Add(txtCodigoPorLote);
            tbpVencimiento.Controls.Add(lblFechaFabricacion);
            tbpVencimiento.Controls.Add(txtCodigoLote);
            tbpVencimiento.Controls.Add(txtAlertaVencimiento);
            tbpVencimiento.Controls.Add(dtpFechaVencimiento);
            tbpVencimiento.Controls.Add(label11);
            tbpVencimiento.Controls.Add(label10);
            tbpVencimiento.Controls.Add(chkAlertaVencimiento);
            tbpVencimiento.Location = new Point(4, 24);
            tbpVencimiento.Name = "tbpVencimiento";
            tbpVencimiento.Size = new Size(381, 194);
            tbpVencimiento.TabIndex = 5;
            tbpVencimiento.Text = "Vencimiento";
            tbpVencimiento.UseVisualStyleBackColor = true;
            // 
            // chkControlLote
            // 
            chkControlLote.AutoSize = true;
            chkControlLote.Location = new Point(145, 102);
            chkControlLote.Name = "chkControlLote";
            chkControlLote.Size = new Size(137, 19);
            chkControlLote.TabIndex = 15;
            chkControlLote.Text = "Usar control por lote.";
            chkControlLote.UseVisualStyleBackColor = true;
            chkControlLote.CheckedChanged += chkControlLote_CheckedChanged;
            // 
            // dtpFechaFabricacion
            // 
            dtpFechaFabricacion.Format = DateTimePickerFormat.Custom;
            dtpFechaFabricacion.Location = new Point(145, 158);
            dtpFechaFabricacion.Name = "dtpFechaFabricacion";
            dtpFechaFabricacion.Size = new Size(108, 23);
            dtpFechaFabricacion.TabIndex = 14;
            // 
            // txtCodigoPorLote
            // 
            txtCodigoPorLote.Location = new Point(145, 127);
            txtCodigoPorLote.Name = "txtCodigoPorLote";
            txtCodigoPorLote.Size = new Size(108, 23);
            txtCodigoPorLote.TabIndex = 13;
            // 
            // lblFechaFabricacion
            // 
            lblFechaFabricacion.AutoSize = true;
            lblFechaFabricacion.Location = new Point(18, 164);
            lblFechaFabricacion.Name = "lblFechaFabricacion";
            lblFechaFabricacion.Size = new Size(121, 15);
            lblFechaFabricacion.TabIndex = 12;
            lblFechaFabricacion.Text = "Fecha de Fabricación:";
            // 
            // txtCodigoLote
            // 
            txtCodigoLote.AutoSize = true;
            txtCodigoLote.Location = new Point(45, 130);
            txtCodigoLote.Name = "txtCodigoLote";
            txtCodigoLote.Size = new Size(94, 15);
            txtCodigoLote.TabIndex = 11;
            txtCodigoLote.Text = "Codigo del Lote:";
            // 
            // txtAlertaVencimiento
            // 
            txtAlertaVencimiento.Location = new Point(145, 63);
            txtAlertaVencimiento.Name = "txtAlertaVencimiento";
            txtAlertaVencimiento.Size = new Size(96, 23);
            txtAlertaVencimiento.TabIndex = 10;
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaVencimiento.Location = new Point(145, 34);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(96, 23);
            dtpFechaVencimiento.TabIndex = 9;
            dtpFechaVencimiento.ValueChanged += dtpFechaVencimiento_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 71);
            label11.Name = "label11";
            label11.Size = new Size(126, 15);
            label11.TabIndex = 2;
            label11.Text = "Alerta de Vencimiento:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 40);
            label10.Name = "label10";
            label10.Size = new Size(126, 15);
            label10.TabIndex = 1;
            label10.Text = "Fecha de Vencimiento:";
            // 
            // chkAlertaVencimiento
            // 
            chkAlertaVencimiento.AutoSize = true;
            chkAlertaVencimiento.Location = new Point(143, 7);
            chkAlertaVencimiento.Name = "chkAlertaVencimiento";
            chkAlertaVencimiento.Size = new Size(162, 19);
            chkAlertaVencimiento.TabIndex = 0;
            chkAlertaVencimiento.Text = "Usar Alerta de Venciminto";
            chkAlertaVencimiento.UseVisualStyleBackColor = true;
            chkAlertaVencimiento.CheckedChanged += chkAlertaVencimiento_CheckedChanged;
            // 
            // tbpStock
            // 
            tbpStock.Controls.Add(chkControlStock);
            tbpStock.Controls.Add(txtStockMaximo);
            tbpStock.Controls.Add(txtStockMinimo);
            tbpStock.Controls.Add(txtStockActual);
            tbpStock.Controls.Add(label9);
            tbpStock.Controls.Add(label8);
            tbpStock.Controls.Add(label7);
            tbpStock.Location = new Point(4, 24);
            tbpStock.Name = "tbpStock";
            tbpStock.Size = new Size(381, 194);
            tbpStock.TabIndex = 4;
            tbpStock.Text = "Stock";
            tbpStock.UseVisualStyleBackColor = true;
            // 
            // chkControlStock
            // 
            chkControlStock.AutoSize = true;
            chkControlStock.Location = new Point(105, 11);
            chkControlStock.Name = "chkControlStock";
            chkControlStock.Size = new Size(147, 19);
            chkControlStock.TabIndex = 6;
            chkControlStock.Text = "Usuar Control de Stock";
            chkControlStock.UseVisualStyleBackColor = true;
            chkControlStock.CheckedChanged += chkControlStock_CheckedChanged;
            // 
            // txtStockMaximo
            // 
            txtStockMaximo.Location = new Point(105, 87);
            txtStockMaximo.Name = "txtStockMaximo";
            txtStockMaximo.Size = new Size(100, 23);
            txtStockMaximo.TabIndex = 5;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(105, 61);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(100, 23);
            txtStockMinimo.TabIndex = 4;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(105, 36);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(100, 23);
            txtStockActual.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 95);
            label9.Name = "label9";
            label9.Size = new Size(86, 15);
            label9.TabIndex = 2;
            label9.Text = "Stock Maximo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 69);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 1;
            label8.Text = "Stock Minimo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 44);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 0;
            label7.Text = "Stock Actual:";
            // 
            // tbpPrecio
            // 
            tbpPrecio.Controls.Add(gpbCargarPrecio);
            tbpPrecio.Location = new Point(4, 24);
            tbpPrecio.Name = "tbpPrecio";
            tbpPrecio.Padding = new Padding(3);
            tbpPrecio.Size = new Size(381, 194);
            tbpPrecio.TabIndex = 2;
            tbpPrecio.Text = "Precios";
            tbpPrecio.UseVisualStyleBackColor = true;
            // 
            // gpbCargarPrecio
            // 
            gpbCargarPrecio.Controls.Add(chkActivarIva);
            gpbCargarPrecio.Controls.Add(cmbIva);
            gpbCargarPrecio.Controls.Add(txtPrecioVenta);
            gpbCargarPrecio.Controls.Add(txtGanancia);
            gpbCargarPrecio.Controls.Add(txtPrecioCosto);
            gpbCargarPrecio.Controls.Add(label6);
            gpbCargarPrecio.Controls.Add(label5);
            gpbCargarPrecio.Controls.Add(label4);
            gpbCargarPrecio.Controls.Add(label3);
            gpbCargarPrecio.Location = new Point(6, 6);
            gpbCargarPrecio.Name = "gpbCargarPrecio";
            gpbCargarPrecio.Size = new Size(267, 182);
            gpbCargarPrecio.TabIndex = 0;
            gpbCargarPrecio.TabStop = false;
            gpbCargarPrecio.Text = "Cargar Precio";
            gpbCargarPrecio.Enter += gpbCargarPrecio_Enter;
            // 
            // chkActivarIva
            // 
            chkActivarIva.AutoSize = true;
            chkActivarIva.Location = new Point(169, 56);
            chkActivarIva.Name = "chkActivarIva";
            chkActivarIva.Size = new Size(83, 19);
            chkActivarIva.TabIndex = 8;
            chkActivarIva.Text = "Activar IVA";
            chkActivarIva.UseVisualStyleBackColor = true;
            chkActivarIva.CheckedChanged += chkActivarIva_CheckedChanged;
            // 
            // cmbIva
            // 
            cmbIva.FormattingEnabled = true;
            cmbIva.Location = new Point(108, 52);
            cmbIva.Name = "cmbIva";
            cmbIva.Size = new Size(55, 23);
            cmbIva.TabIndex = 1;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(108, 110);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.ReadOnly = true;
            txtPrecioVenta.Size = new Size(144, 23);
            txtPrecioVenta.TabIndex = 7;
            // 
            // txtGanancia
            // 
            txtGanancia.Location = new Point(108, 81);
            txtGanancia.Name = "txtGanancia";
            txtGanancia.Size = new Size(144, 23);
            txtGanancia.TabIndex = 6;
            txtGanancia.TextChanged += txtGanancia_TextChanged;
            // 
            // txtPrecioCosto
            // 
            txtPrecioCosto.Location = new Point(108, 27);
            txtPrecioCosto.Name = "txtPrecioCosto";
            txtPrecioCosto.Size = new Size(144, 23);
            txtPrecioCosto.TabIndex = 4;
            txtPrecioCosto.TextChanged += txtPrecioCosto_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 119);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 3;
            label6.Text = "Precio Venta: $";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 88);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 2;
            label5.Text = "%Ganancia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 57);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 1;
            label4.Text = "IVA:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 30);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 0;
            label3.Text = "Precio Costo: $";
            // 
            // tpgGeneral
            // 
            tpgGeneral.Controls.Add(cmbRubro);
            tpgGeneral.Controls.Add(cmbUnidadVenta);
            tpgGeneral.Controls.Add(label2);
            tpgGeneral.Controls.Add(label1);
            tpgGeneral.Location = new Point(4, 24);
            tpgGeneral.Name = "tpgGeneral";
            tpgGeneral.Padding = new Padding(3);
            tpgGeneral.Size = new Size(381, 194);
            tpgGeneral.TabIndex = 0;
            tpgGeneral.Text = "General";
            tpgGeneral.UseVisualStyleBackColor = true;
            // 
            // cmbRubro
            // 
            cmbRubro.FormattingEnabled = true;
            cmbRubro.Location = new Point(115, 71);
            cmbRubro.Name = "cmbRubro";
            cmbRubro.Size = new Size(121, 23);
            cmbRubro.TabIndex = 3;
            // 
            // cmbUnidadVenta
            // 
            cmbUnidadVenta.FormattingEnabled = true;
            cmbUnidadVenta.Location = new Point(113, 17);
            cmbUnidadVenta.Name = "cmbUnidadVenta";
            cmbUnidadVenta.Size = new Size(121, 23);
            cmbUnidadVenta.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 72);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Rubro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 20);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 0;
            label1.Text = "Unidad de Venta";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpgGeneral);
            tabControl1.Controls.Add(tbpPrecio);
            tabControl1.Controls.Add(tbpStock);
            tabControl1.Controls.Add(tbpVencimiento);
            tabControl1.Controls.Add(Marca);
            tabControl1.Controls.Add(tbpProveedor);
            tabControl1.Location = new Point(12, 83);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(389, 222);
            tabControl1.TabIndex = 0;
            // 
            // Marca
            // 
            Marca.Controls.Add(cmbMarca);
            Marca.Controls.Add(label18);
            Marca.Controls.Add(label17);
            Marca.Controls.Add(label16);
            Marca.Controls.Add(txtSKU);
            Marca.Controls.Add(txtNombreProducto);
            Marca.Location = new Point(4, 24);
            Marca.Name = "Marca";
            Marca.Padding = new Padding(3);
            Marca.Size = new Size(381, 194);
            Marca.TabIndex = 6;
            Marca.Text = "Marca";
            Marca.UseVisualStyleBackColor = true;
            // 
            // cmbMarca
            // 
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(164, 56);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(192, 23);
            cmbMarca.TabIndex = 6;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(130, 88);
            label18.Name = "label18";
            label18.Size = new Size(31, 15);
            label18.TabIndex = 5;
            label18.Text = "SKU:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(118, 59);
            label17.Name = "label17";
            label17.Size = new Size(43, 15);
            label17.TabIndex = 4;
            label17.Text = "Marca:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(36, 30);
            label16.Name = "label16";
            label16.Size = new Size(125, 15);
            label16.TabIndex = 3;
            label16.Text = "Nombre del Producto:";
            // 
            // txtSKU
            // 
            txtSKU.Location = new Point(164, 85);
            txtSKU.Name = "txtSKU";
            txtSKU.ReadOnly = true;
            txtSKU.Size = new Size(123, 23);
            txtSKU.TabIndex = 2;
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(164, 27);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(192, 23);
            txtNombreProducto.TabIndex = 0;
            // 
            // tbpProveedor
            // 
            tbpProveedor.Controls.Add(cmbSucursal);
            tbpProveedor.Controls.Add(cmbProveedor);
            tbpProveedor.Controls.Add(label14);
            tbpProveedor.Controls.Add(label13);
            tbpProveedor.Location = new Point(4, 24);
            tbpProveedor.Name = "tbpProveedor";
            tbpProveedor.Padding = new Padding(3);
            tbpProveedor.Size = new Size(381, 194);
            tbpProveedor.TabIndex = 7;
            tbpProveedor.Text = "Proveedor";
            tbpProveedor.UseVisualStyleBackColor = true;
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(80, 58);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(150, 23);
            cmbSucursal.TabIndex = 4;
            // 
            // cmbProveedor
            // 
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(80, 24);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(150, 23);
            cmbProveedor.TabIndex = 3;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(23, 61);
            label14.Name = "label14";
            label14.Size = new Size(57, 15);
            label14.TabIndex = 1;
            label14.Text = "Sucursal :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(13, 27);
            label13.Name = "label13";
            label13.Size = new Size(70, 15);
            label13.TabIndex = 0;
            label13.Text = "Proveedor : ";
            // 
            // frmNuevoArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 377);
            Controls.Add(txtDescripcion);
            Controls.Add(txtCodigo);
            Controls.Add(label15);
            Controls.Add(label12);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmNuevoArticulo";
            Text = "Nuevo Articulo";
            tbpVencimiento.ResumeLayout(false);
            tbpVencimiento.PerformLayout();
            tbpStock.ResumeLayout(false);
            tbpStock.PerformLayout();
            tbpPrecio.ResumeLayout(false);
            gpbCargarPrecio.ResumeLayout(false);
            gpbCargarPrecio.PerformLayout();
            tpgGeneral.ResumeLayout(false);
            tpgGeneral.PerformLayout();
            tabControl1.ResumeLayout(false);
            Marca.ResumeLayout(false);
            Marca.PerformLayout();
            tbpProveedor.ResumeLayout(false);
            tbpProveedor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancelar;
        private Button btnGuardar;
        private Label label12;
        private Label label15;
        private TextBox txtCodigo;
        private TextBox txtDescripcion;
        private TabPage tbpVencimiento;
        private Label label11;
        private Label label10;
        private CheckBox chkAlertaVencimiento;
        private TabPage tbpStock;
        private CheckBox chkControlStock;
        private TextBox txtStockMaximo;
        private TextBox txtStockMinimo;
        private TextBox txtStockActual;
        private Label label9;
        private Label label8;
        private Label label7;
        private TabPage tbpPrecio;
        private GroupBox gpbCargarPrecio;
        private ComboBox cmbIva;
        private TextBox txtPrecioVenta;
        private TextBox txtGanancia;
        private TextBox txtPrecioCosto;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TabPage tpgGeneral;
        private ComboBox cmbRubro;
        private ComboBox cmbUnidadVenta;
        private Label label2;
        private Label label1;
        private TabControl tabControl1;
        private TabPage Marca;
        private Label label18;
        private Label label17;
        private Label label16;
        private TextBox txtSKU;
        private TextBox txtNombreProducto;
        private ComboBox cmbMarca;
        private DateTimePicker dtpFechaVencimiento;
        private TextBox txtAlertaVencimiento;
        private CheckBox chkActivarIva;
        private CheckBox chkControlLote;
        private DateTimePicker dtpFechaFabricacion;
        private TextBox txtCodigoPorLote;
        private Label lblFechaFabricacion;
        private Label txtCodigoLote;
        private TabPage tbpProveedor;
        private ComboBox cmbSucursal;
        private ComboBox cmbProveedor;
        private Label label14;
        private Label label13;
    }
}