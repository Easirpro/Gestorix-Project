using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVista
{
    partial class frmNuevoArticulo
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ttAyuda = new ToolTip(components);
            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmNuevoArticulo));
            pnlEncabezado = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlContenido = new Panel();
            tabControl1 = new TabControl();
            tbpPrecio = new TabPage();
            gpbCargarPrecio = new GroupBox();
            label3 = new Label();
            txtPrecioCosto = new TextBox();
            label4 = new Label();
            cmbIva = new ComboBox();
            chkActivarIva = new CheckBox();
            label5 = new Label();
            txtGanancia = new TextBox();
            label6 = new Label();
            txtPrecioVenta = new TextBox();
            tbpStock = new TabPage();
            chkControlStock = new CheckBox();
            label7 = new Label();
            txtStockActual = new TextBox();
            label8 = new Label();
            txtStockMinimo = new TextBox();
            label9 = new Label();
            txtStockMaximo = new TextBox();
            tbpVencimiento = new TabPage();
            chkAlertaVencimiento = new CheckBox();
            label10 = new Label();
            dtpFechaVencimiento = new DateTimePicker();
            label11 = new Label();
            txtAlertaVencimiento = new TextBox();
            tbpLotes = new TabPage();
            chkControlLote = new CheckBox();
            txtCodigoLote = new Label();
            txtCodigoPorLote = new TextBox();
            lblFechaFabricacion = new Label();
            dtpFechaFabricacion = new DateTimePicker();
            tbpProveedor = new TabPage();
            label13 = new Label();
            cmbProveedor = new ComboBox();
            label14 = new Label();
            cmbSucursal = new ComboBox();
            btnAgregarProveedor = new Button();
            dgvProveedores = new DataGridView();
            btnQuitarProveedor = new Button();
            grpIdentificacion = new GroupBox();
            label16 = new Label();
            txtNombreProducto = new TextBox();
            label17 = new Label();
            cmbMarca = new ComboBox();
            label1 = new Label();
            cmbUnidadVenta = new ComboBox();
            label2 = new Label();
            cmbRubro = new ComboBox();
            pnlPie = new Panel();
            btnCancelar = new Button();
            btnGuardar = new Button();
            grpDatosPrincipales = new GroupBox();
            label12 = new Label();
            txtCodigo = new TextBox();
            label18 = new Label();
            txtSKU = new TextBox();
            label15 = new Label();
            txtDescripcion = new TextBox();
            tpgGeneral = new TabPage();
            Marca = new TabPage();
            pnlEncabezado.SuspendLayout();
            pnlContenido.SuspendLayout();
            tabControl1.SuspendLayout();
            tbpPrecio.SuspendLayout();
            gpbCargarPrecio.SuspendLayout();
            tbpStock.SuspendLayout();
            tbpVencimiento.SuspendLayout();
            tbpLotes.SuspendLayout();
            tbpProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            grpIdentificacion.SuspendLayout();
            pnlPie.SuspendLayout();
            grpDatosPrincipales.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 

            btnCancelar.Location = new Point(313, 311);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 27);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;

            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Padding = new Padding(16, 6, 14, 3);
            pnlEncabezado.Size = new Size(845, 51);
            pnlEncabezado.TabIndex = 3;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblTitulo.Location = new Point(16, 6);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(128, 17);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registar artículo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(19, 29);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(303, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Completá los datos necesarios para registrar el producto";
            // 
            // pnlContenido
            // 
            pnlContenido.Controls.Add(tabControl1);
            pnlContenido.Controls.Add(grpIdentificacion);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 169);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(9, 8, 9, 8);
            pnlContenido.Size = new Size(845, 361);
            pnlContenido.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbpPrecio);
            tabControl1.Controls.Add(tbpStock);
            tabControl1.Controls.Add(tbpVencimiento);
            tabControl1.Controls.Add(tbpLotes);
            tabControl1.Controls.Add(tbpProveedor);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(277, 8);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(10, 4);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(559, 345);
            tabControl1.TabIndex = 0;
            // 
            // tbpPrecio
            // 
            tbpPrecio.Controls.Add(gpbCargarPrecio);
            tbpPrecio.Location = new Point(4, 26);
            tbpPrecio.Name = "tbpPrecio";
            tbpPrecio.Padding = new Padding(9);
            tbpPrecio.Size = new Size(551, 315);
            tbpPrecio.TabIndex = 0;
            tbpPrecio.Text = "Precios";
            // 
            // gpbCargarPrecio
            // 
            gpbCargarPrecio.Controls.Add(label3);
            gpbCargarPrecio.Controls.Add(txtPrecioCosto);
            gpbCargarPrecio.Controls.Add(label4);
            gpbCargarPrecio.Controls.Add(cmbIva);
            gpbCargarPrecio.Controls.Add(chkActivarIva);
            gpbCargarPrecio.Controls.Add(label5);
            gpbCargarPrecio.Controls.Add(txtGanancia);
            gpbCargarPrecio.Controls.Add(label6);
            gpbCargarPrecio.Controls.Add(txtPrecioVenta);
            gpbCargarPrecio.Dock = DockStyle.Top;
            gpbCargarPrecio.Location = new Point(9, 9);
            gpbCargarPrecio.Name = "gpbCargarPrecio";
            gpbCargarPrecio.Padding = new Padding(12);
            gpbCargarPrecio.Size = new Size(533, 219);
            gpbCargarPrecio.TabIndex = 0;
            gpbCargarPrecio.TabStop = false;
            gpbCargarPrecio.Text = "Configuración de precios";
            gpbCargarPrecio.Enter += gpbCargarPrecio_Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 32);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 0;
            label3.Text = "Precio de costo";
            // 
            // txtPrecioCosto
            // 
            txtPrecioCosto.Location = new Point(18, 54);
            txtPrecioCosto.Name = "txtPrecioCosto";
            txtPrecioCosto.PlaceholderText = "Costo sin IVA, ej.: 1500";
            txtPrecioCosto.Size = new Size(192, 23);
            txtPrecioCosto.TabIndex = 1;
            txtPrecioCosto.TextChanged += txtPrecioCosto_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(239, 32);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 2;
            label4.Text = "IVA";
            // 
            // cmbIva
            // 
            cmbIva.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIva.Location = new Point(243, 54);
            cmbIva.Name = "cmbIva";
            cmbIva.Size = new Size(151, 23);
            cmbIva.TabIndex = 3;
            // 
            // chkActivarIva
            // 
            chkActivarIva.AutoSize = true;
            chkActivarIva.Location = new Point(408, 57);
            chkActivarIva.Name = "chkActivarIva";
            chkActivarIva.Size = new Size(83, 19);
            chkActivarIva.TabIndex = 4;
            chkActivarIva.Text = "Aplicar IVA";
            chkActivarIva.CheckedChanged += chkActivarIva_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 105);
            label5.Name = "label5";
            label5.Size = new Size(136, 15);
            label5.TabIndex = 5;
            label5.Text = "Margen de ganancia (%)";
            // 
            // txtGanancia
            // 
            txtGanancia.Location = new Point(18, 127);
            txtGanancia.Name = "txtGanancia";
            txtGanancia.PlaceholderText = "Ej.: 30";
            txtGanancia.Size = new Size(192, 23);
            txtGanancia.TabIndex = 6;
            txtGanancia.TextChanged += txtGanancia_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(239, 105);
            label6.Name = "label6";
            label6.Size = new Size(142, 15);
            label6.TabIndex = 7;
            label6.Text = "Precio de venta calculado";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(243, 127);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.ReadOnly = true;
            txtPrecioVenta.Size = new Size(209, 23);
            txtPrecioVenta.TabIndex = 8;
            txtPrecioVenta.TabStop = false;
            // 
            // tbpStock
            // 
            tbpStock.Controls.Add(chkControlStock);
            tbpStock.Controls.Add(label7);
            tbpStock.Controls.Add(txtStockActual);
            tbpStock.Controls.Add(label8);
            tbpStock.Controls.Add(txtStockMinimo);
            tbpStock.Controls.Add(label9);
            tbpStock.Controls.Add(txtStockMaximo);
            tbpStock.Location = new Point(4, 26);
            tbpStock.Name = "tbpStock";
            tbpStock.Padding = new Padding(9);
            tbpStock.Size = new Size(551, 315);
            tbpStock.TabIndex = 1;
            tbpStock.Text = "Stock";
            // 
            // chkControlStock
            // 
            chkControlStock.AutoSize = true;
            chkControlStock.Location = new Point(18, 20);
            chkControlStock.Name = "chkControlStock";
            chkControlStock.Size = new Size(151, 19);
            chkControlStock.TabIndex = 0;
            chkControlStock.Text = "Activar control de stock";
            chkControlStock.CheckedChanged += chkControlStock_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 62);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 1;
            label7.Text = "Stock actual";
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(18, 84);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.PlaceholderText = "Cantidad que hay hoy";
            txtStockActual.Size = new Size(204, 23);
            txtStockActual.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(251, 62);
            label8.Name = "label8";
            label8.Size = new Size(144, 15);
            label8.TabIndex = 3;
            label8.Text = "Stock mínimo para alertas";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(254, 84);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.PlaceholderText = "Avisa cuando baja de esta cantidad";
            txtStockMinimo.Size = new Size(204, 23);
            txtStockMinimo.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 129);
            label9.Name = "label9";
            label9.Size = new Size(83, 15);
            label9.TabIndex = 5;
            label9.Text = "Stock máximo";
            // 
            // txtStockMaximo
            // 
            txtStockMaximo.Location = new Point(18, 151);
            txtStockMaximo.Name = "txtStockMaximo";
            txtStockMaximo.PlaceholderText = "Cantidad ideal al reponer";
            txtStockMaximo.Size = new Size(204, 23);
            txtStockMaximo.TabIndex = 6;
            // 
            // tbpVencimiento
            // 
            tbpVencimiento.Controls.Add(chkAlertaVencimiento);
            tbpVencimiento.Controls.Add(label10);
            tbpVencimiento.Controls.Add(dtpFechaVencimiento);
            tbpVencimiento.Controls.Add(label11);
            tbpVencimiento.Controls.Add(txtAlertaVencimiento);
            tbpVencimiento.Location = new Point(4, 26);
            tbpVencimiento.Name = "tbpVencimiento";
            tbpVencimiento.Padding = new Padding(9);
            tbpVencimiento.Size = new Size(551, 315);
            tbpVencimiento.TabIndex = 2;
            tbpVencimiento.Text = "Vencimiento";
            // 
            // chkAlertaVencimiento
            // 
            chkAlertaVencimiento.AutoSize = true;
            chkAlertaVencimiento.Location = new Point(18, 20);
            chkAlertaVencimiento.Name = "chkAlertaVencimiento";
            chkAlertaVencimiento.Size = new Size(185, 19);
            chkAlertaVencimiento.TabIndex = 0;
            chkAlertaVencimiento.Text = "Activar alertas de vencimiento";
            chkAlertaVencimiento.CheckedChanged += chkAlertaVencimiento_CheckedChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 60);
            label10.Name = "label10";
            label10.Size = new Size(123, 15);
            label10.TabIndex = 1;
            label10.Text = "Fecha de vencimiento";
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Format = DateTimePickerFormat.Short;
            dtpFechaVencimiento.Location = new Point(18, 82);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(204, 23);
            dtpFechaVencimiento.TabIndex = 2;
            dtpFechaVencimiento.ValueChanged += dtpFechaVencimiento_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(245, 60);
            label11.Name = "label11";
            label11.Size = new Size(154, 15);
            label11.TabIndex = 3;
            label11.Text = "Anticipación de alerta (días)";
            // 
            // txtAlertaVencimiento
            // 
            txtAlertaVencimiento.Location = new Point(248, 82);
            txtAlertaVencimiento.Name = "txtAlertaVencimiento";
            txtAlertaVencimiento.PlaceholderText = "Días antes del vencimiento para avisar";
            txtAlertaVencimiento.Size = new Size(204, 23);
            txtAlertaVencimiento.TabIndex = 4;
            // 
            // tbpLotes
            // 
            tbpLotes.Controls.Add(chkControlLote);
            tbpLotes.Controls.Add(txtCodigoLote);
            tbpLotes.Controls.Add(txtCodigoPorLote);
            tbpLotes.Controls.Add(lblFechaFabricacion);
            tbpLotes.Controls.Add(dtpFechaFabricacion);
            tbpLotes.Location = new Point(4, 26);
            tbpLotes.Name = "tbpLotes";
            tbpLotes.Padding = new Padding(9);
            tbpLotes.Size = new Size(551, 315);
            tbpLotes.TabIndex = 3;
            tbpLotes.Text = "Lotes";
            // 
            // chkControlLote
            // 
            chkControlLote.AutoSize = true;
            chkControlLote.Location = new Point(18, 20);
            chkControlLote.Name = "chkControlLote";
            chkControlLote.Size = new Size(148, 19);
            chkControlLote.TabIndex = 0;
            chkControlLote.Text = "Activar control por lote";
            chkControlLote.CheckedChanged += chkControlLote_CheckedChanged;
            // 
            // txtCodigoLote
            // 
            txtCodigoLote.AutoSize = true;
            txtCodigoLote.Location = new Point(14, 60);
            txtCodigoLote.Name = "txtCodigoLote";
            txtCodigoLote.Size = new Size(85, 15);
            txtCodigoLote.TabIndex = 1;
            txtCodigoLote.Text = "Código de lote";
            // 
            // txtCodigoPorLote
            // 
            txtCodigoPorLote.Location = new Point(18, 82);
            txtCodigoPorLote.Name = "txtCodigoPorLote";
            txtCodigoPorLote.PlaceholderText = "Código del lote (opcional)";
            txtCodigoPorLote.Size = new Size(204, 23);
            txtCodigoPorLote.TabIndex = 2;
            // 
            // lblFechaFabricacion
            // 
            lblFechaFabricacion.AutoSize = true;
            lblFechaFabricacion.Location = new Point(245, 60);
            lblFechaFabricacion.Name = "lblFechaFabricacion";
            lblFechaFabricacion.Size = new Size(116, 15);
            lblFechaFabricacion.TabIndex = 3;
            lblFechaFabricacion.Text = "Fecha de fabricación";
            // 
            // dtpFechaFabricacion
            // 
            dtpFechaFabricacion.Format = DateTimePickerFormat.Short;
            dtpFechaFabricacion.Location = new Point(248, 82);
            dtpFechaFabricacion.Name = "dtpFechaFabricacion";
            dtpFechaFabricacion.Size = new Size(204, 23);
            dtpFechaFabricacion.TabIndex = 4;
            // 
            // tbpProveedor
            // 
            tbpProveedor.Controls.Add(label13);
            tbpProveedor.Controls.Add(cmbProveedor);
            tbpProveedor.Controls.Add(label14);
            tbpProveedor.Controls.Add(cmbSucursal);
            tbpProveedor.Controls.Add(btnAgregarProveedor);
            tbpProveedor.Controls.Add(dgvProveedores);
            tbpProveedor.Controls.Add(btnQuitarProveedor);
            tbpProveedor.Location = new Point(4, 26);
            tbpProveedor.Name = "tbpProveedor";
            tbpProveedor.Padding = new Padding(9);
            tbpProveedor.Size = new Size(551, 315);
            tbpProveedor.TabIndex = 4;
            tbpProveedor.Text = "Proveedor";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(14, 12);
            label13.Name = "label13";
            label13.Size = new Size(61, 15);
            label13.TabIndex = 0;
            label13.Text = "Proveedor";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Location = new Point(18, 32);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(230, 23);
            cmbProveedor.TabIndex = 1;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(258, 12);
            label14.Name = "label14";
            label14.Size = new Size(51, 15);
            label14.TabIndex = 2;
            label14.Text = "Sucursal";
            // 
            // cmbSucursal
            // 
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursal.Location = new Point(262, 32);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(180, 23);
            cmbSucursal.TabIndex = 3;
            // 
            // btnAgregarProveedor
            // 
            btnAgregarProveedor.Location = new Point(452, 31);
            btnAgregarProveedor.Name = "btnAgregarProveedor";
            btnAgregarProveedor.Size = new Size(85, 25);
            btnAgregarProveedor.TabIndex = 4;
            btnAgregarProveedor.Text = "Agregar";
            btnAgregarProveedor.UseVisualStyleBackColor = true;
            btnAgregarProveedor.Click += btnAgregarProveedor_Click;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AllowUserToDeleteRows = false;
            dgvProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.BackgroundColor = SystemColors.Window;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(18, 70);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(519, 200);
            dgvProveedores.TabIndex = 5;
            // 
            // btnQuitarProveedor
            // 
            btnQuitarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnQuitarProveedor.Location = new Point(18, 278);
            btnQuitarProveedor.Name = "btnQuitarProveedor";
            btnQuitarProveedor.Size = new Size(85, 25);
            btnQuitarProveedor.TabIndex = 6;
            btnQuitarProveedor.Text = "Quitar";
            btnQuitarProveedor.UseVisualStyleBackColor = true;
            btnQuitarProveedor.Click += btnQuitarProveedor_Click;
            // 
            // grpIdentificacion
            // 
            grpIdentificacion.Controls.Add(label16);
            grpIdentificacion.Controls.Add(txtNombreProducto);
            grpIdentificacion.Controls.Add(label17);
            grpIdentificacion.Controls.Add(cmbMarca);
            grpIdentificacion.Controls.Add(label1);
            grpIdentificacion.Controls.Add(cmbUnidadVenta);
            grpIdentificacion.Controls.Add(label2);
            grpIdentificacion.Controls.Add(cmbRubro);
            grpIdentificacion.Dock = DockStyle.Left;
            grpIdentificacion.Location = new Point(9, 8);
            grpIdentificacion.Name = "grpIdentificacion";
            grpIdentificacion.Padding = new Padding(12);
            grpIdentificacion.Size = new Size(268, 345);
            grpIdentificacion.TabIndex = 1;
            grpIdentificacion.TabStop = false;
            grpIdentificacion.Text = "Identificación";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(14, 29);
            label16.Name = "label16";
            label16.Size = new Size(130, 15);
            label16.TabIndex = 0;
            label16.Text = "Nombre del producto *";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombreProducto.Location = new Point(18, 51);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.PlaceholderText = "Ej.: Coca Cola 500 ml";
            txtNombreProducto.Size = new Size(226, 23);
            txtNombreProducto.TabIndex = 1;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(14, 89);
            label17.Name = "label17";
            label17.Size = new Size(40, 15);
            label17.TabIndex = 2;
            label17.Text = "Marca";
            // 
            // cmbMarca
            // 
            cmbMarca.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.Location = new Point(18, 111);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(226, 23);
            cmbMarca.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 149);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 4;
            label1.Text = "Unidad de venta";
            // 
            // cmbUnidadVenta
            // 
            cmbUnidadVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbUnidadVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidadVenta.Location = new Point(18, 171);
            cmbUnidadVenta.Name = "cmbUnidadVenta";
            cmbUnidadVenta.Size = new Size(226, 23);
            cmbUnidadVenta.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 209);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 6;
            label2.Text = "Rubro o categoría";
            // 
            // cmbRubro
            // 
            cmbRubro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbRubro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRubro.Location = new Point(18, 231);
            cmbRubro.Name = "cmbRubro";
            cmbRubro.Size = new Size(226, 23);
            cmbRubro.TabIndex = 7;
            // 
            // pnlPie
            // 
            pnlPie.Controls.Add(btnCancelar);
            pnlPie.Controls.Add(btnGuardar);
            pnlPie.Dock = DockStyle.Bottom;
            pnlPie.Location = new Point(0, 530);
            pnlPie.Name = "pnlPie";
            pnlPie.Padding = new Padding(10, 8, 12, 8);
            pnlPie.Size = new Size(845, 48);
            pnlPie.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.Location = new Point(594, 9);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 28);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Salir";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Location = new Point(711, 8);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 28);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // grpDatosPrincipales
            // 
            grpDatosPrincipales.Controls.Add(label12);
            grpDatosPrincipales.Controls.Add(txtCodigo);
            grpDatosPrincipales.Controls.Add(label18);
            grpDatosPrincipales.Controls.Add(txtSKU);
            grpDatosPrincipales.Controls.Add(label15);
            grpDatosPrincipales.Controls.Add(txtDescripcion);
            grpDatosPrincipales.Dock = DockStyle.Top;
            grpDatosPrincipales.Location = new Point(0, 51);
            grpDatosPrincipales.Name = "grpDatosPrincipales";
            grpDatosPrincipales.Padding = new Padding(12);
            grpDatosPrincipales.Size = new Size(845, 118);
            grpDatosPrincipales.TabIndex = 2;
            grpDatosPrincipales.TabStop = false;
            grpDatosPrincipales.Text = "Datos principales";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(16, 23);
            label12.Name = "label12";
            label12.Size = new Size(54, 15);
            label12.TabIndex = 0;
            label12.Text = "Código *";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(20, 45);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "Código de barras o código interno";
            txtCodigo.Size = new Size(204, 23);
            txtCodigo.TabIndex = 1;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(239, 23);
            label18.Name = "label18";
            label18.Size = new Size(92, 15);
            label18.TabIndex = 2;
            label18.Text = "SKU automático";
            // 
            // txtSKU
            // 
            txtSKU.Location = new Point(243, 45);
            txtSKU.Name = "txtSKU";
            txtSKU.ReadOnly = true;
            txtSKU.Size = new Size(204, 23);
            txtSKU.TabIndex = 3;
            txtSKU.TabStop = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(16, 73);
            label15.Name = "label15";
            label15.Size = new Size(77, 15);
            label15.TabIndex = 4;
            label15.Text = "Descripción *";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.Location = new Point(20, 92);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Descripción que se ve al vender";
            txtDescripcion.Size = new Size(800, 23);
            txtDescripcion.TabIndex = 5;
            // 
            // tpgGeneral
            // 
            tpgGeneral.Location = new Point(0, 0);
            tpgGeneral.Name = "tpgGeneral";
            tpgGeneral.Size = new Size(200, 100);
            tpgGeneral.TabIndex = 0;
            // 
            // Marca
            // 
            Marca.Location = new Point(0, 0);
            Marca.Name = "Marca";
            Marca.Size = new Size(200, 100);
            Marca.TabIndex = 0;
            // 
            // frmNuevoArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 578);
            Controls.Add(pnlContenido);
            Controls.Add(pnlPie);
            Controls.Add(grpDatosPrincipales);
            Controls.Add(pnlEncabezado);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(861, 617);
            Name = "frmNuevoArticulo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar articulo nuevo";
            Load += frmNuevoArticulo_Load;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlContenido.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tbpPrecio.ResumeLayout(false);
            gpbCargarPrecio.ResumeLayout(false);
            gpbCargarPrecio.PerformLayout();
            tbpStock.ResumeLayout(false);
            tbpStock.PerformLayout();
            tbpVencimiento.ResumeLayout(false);
            tbpVencimiento.PerformLayout();
            tbpLotes.ResumeLayout(false);
            tbpLotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            tbpProveedor.ResumeLayout(false);
            tbpProveedor.PerformLayout();
            grpIdentificacion.ResumeLayout(false);
            grpIdentificacion.PerformLayout();
            pnlPie.ResumeLayout(false);
            grpDatosPrincipales.ResumeLayout(false);
            grpDatosPrincipales.PerformLayout();
            // 
            // ttAyuda: explicación de cada combo al pasar el mouse
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbRubro, "Rubro o categoría del producto.");
            ttAyuda.SetToolTip(cmbMarca, "Marca del producto.");
            ttAyuda.SetToolTip(cmbUnidadVenta, "Cómo se vende: por unidad, por kilo, etc.");
            ttAyuda.SetToolTip(cmbProveedor, "Proveedor que vende este producto.");
            ttAyuda.SetToolTip(cmbSucursal, "Sucursal del proveedor que lo vende.");
            ttAyuda.SetToolTip(cmbIva, "Alícuota de IVA del producto.");
            ResumeLayout(false);
        }

        #endregion

        private ToolTip ttAyuda;

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlContenido;
        private GroupBox grpDatosPrincipales;
        private Label label12;
        private TextBox txtCodigo;
        private Label label18;
        private TextBox txtSKU;
        private Label label15;
        private TextBox txtDescripcion;
        private GroupBox grpIdentificacion;
        private Label label16;
        private TextBox txtNombreProducto;
        private Label label17;
        private ComboBox cmbMarca;
        private Label label1;
        private ComboBox cmbUnidadVenta;
        private Label label2;
        private ComboBox cmbRubro;
        private TabControl tabControl1;
        private TabPage tpgGeneral;
        private TabPage tbpPrecio;
        private TabPage tbpStock;
        private TabPage tbpVencimiento;
        private TabPage tbpLotes;
        private TabPage tbpProveedor;
        private TabPage Marca;
        private GroupBox gpbCargarPrecio;
        private Label label3;
        private TextBox txtPrecioCosto;
        private Label label4;
        private ComboBox cmbIva;
        private CheckBox chkActivarIva;
        private Label label5;
        private TextBox txtGanancia;
        private Label label6;
        private TextBox txtPrecioVenta;
        private CheckBox chkControlStock;
        private Label label7;
        private TextBox txtStockActual;
        private Label label8;
        private TextBox txtStockMinimo;
        private Label label9;
        private TextBox txtStockMaximo;
        private CheckBox chkAlertaVencimiento;
        private Label label10;
        private DateTimePicker dtpFechaVencimiento;
        private Label label11;
        private TextBox txtAlertaVencimiento;
        private CheckBox chkControlLote;
        private Label txtCodigoLote;
        private TextBox txtCodigoPorLote;
        private Label lblFechaFabricacion;
        private DateTimePicker dtpFechaFabricacion;
        private Label label13;
        private ComboBox cmbProveedor;
        private Label label14;
        private ComboBox cmbSucursal;
        private Button btnAgregarProveedor;
        private DataGridView dgvProveedores;
        private Button btnQuitarProveedor;
        private Panel pnlPie;
        private Button btnCancelar;
        private Button btnGuardar;
    }
}