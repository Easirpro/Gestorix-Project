namespace CapaVista
{
    partial class frmNuevaCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaCompra));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            gpbProveedor = new GroupBox();
            btnBuscar = new Button();
            txtProveedor = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            txtCodigobarra = new TextBox();
            btnBuscarProducto = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnEliminarProducto = new Button();
            gpbOpciones = new GroupBox();
            chkActualizarStock = new CheckBox();
            chkActualizarPrecio = new CheckBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtSubsinImpuesto = new TextBox();
            txtImpuestosInternos = new TextBox();
            txtSubConImpuesto = new TextBox();
            txtIva = new TextBox();
            txtTotal = new TextBox();
            gpbFormasdePago = new GroupBox();
            txtPagosDebito = new TextBox();
            txtPagosCuenta = new TextBox();
            txtPagoTransferencia = new TextBox();
            txtPagoEfectivo = new TextBox();
            txtPagoTarjeta = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            Efectivo = new Label();
            label4 = new Label();
            txtObservaciones = new TextBox();
            btnGuardar = new Button();
            btnCacelar = new Button();
            comboBox1 = new ComboBox();
            chkCompraAnulada = new CheckBox();
            gpbProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            gpbOpciones.SuspendLayout();
            gpbFormasdePago.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 98);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Código de Barra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(379, 40);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 1;
            label2.Text = "Tipo de Factura";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(380, 67);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 2;
            label3.Text = "Fecha";
            // 
            // gpbProveedor
            // 
            gpbProveedor.Controls.Add(btnBuscar);
            gpbProveedor.Controls.Add(txtProveedor);
            gpbProveedor.Location = new Point(12, 22);
            gpbProveedor.Name = "gpbProveedor";
            gpbProveedor.Size = new Size(355, 73);
            gpbProveedor.TabIndex = 4;
            gpbProveedor.TabStop = false;
            gpbProveedor.Text = "Proveedor";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(244, 31);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(105, 23);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(6, 32);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(216, 23);
            txtProveedor.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(424, 61);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.Value = new DateTime(2026, 6, 13, 0, 0, 0, 0);
            // 
            // txtCodigobarra
            // 
            txtCodigobarra.Location = new Point(18, 116);
            txtCodigobarra.Name = "txtCodigobarra";
            txtCodigobarra.Size = new Size(145, 23);
            txtCodigobarra.TabIndex = 7;
            // 
            // btnBuscarProducto
            // 
            btnBuscarProducto.Location = new Point(180, 116);
            btnBuscarProducto.Name = "btnBuscarProducto";
            btnBuscarProducto.Size = new Size(75, 23);
            btnBuscarProducto.TabIndex = 8;
            btnBuscarProducto.Text = "Buscar";
            btnBuscarProducto.UseVisualStyleBackColor = true;
            btnBuscarProducto.Click += btnBuscarProducto_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridView1.Location = new Point(18, 149);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(605, 134);
            dataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            Column1.HeaderText = "Código";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Cantidad";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Descripción";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Precio sin IVA";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "%IVA";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Total";
            Column6.Name = "Column6";
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.Location = new Point(16, 296);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(75, 23);
            btnEliminarProducto.TabIndex = 10;
            btnEliminarProducto.Text = "Eliminar";
            btnEliminarProducto.UseVisualStyleBackColor = true;
            // 
            // gpbOpciones
            // 
            gpbOpciones.Controls.Add(chkActualizarStock);
            gpbOpciones.Controls.Add(chkActualizarPrecio);
            gpbOpciones.Location = new Point(15, 326);
            gpbOpciones.Name = "gpbOpciones";
            gpbOpciones.Size = new Size(262, 58);
            gpbOpciones.TabIndex = 11;
            gpbOpciones.TabStop = false;
            gpbOpciones.Text = "Opciones";
            // 
            // chkActualizarStock
            // 
            chkActualizarStock.AutoSize = true;
            chkActualizarStock.Location = new Point(144, 22);
            chkActualizarStock.Name = "chkActualizarStock";
            chkActualizarStock.Size = new Size(110, 19);
            chkActualizarStock.TabIndex = 1;
            chkActualizarStock.Text = "Actualizar Stock";
            chkActualizarStock.UseVisualStyleBackColor = true;
            // 
            // chkActualizarPrecio
            // 
            chkActualizarPrecio.AutoSize = true;
            chkActualizarPrecio.Location = new Point(6, 22);
            chkActualizarPrecio.Name = "chkActualizarPrecio";
            chkActualizarPrecio.Size = new Size(119, 19);
            chkActualizarPrecio.TabIndex = 0;
            chkActualizarPrecio.Text = "Actualizar Precios";
            chkActualizarPrecio.UseVisualStyleBackColor = true;
            chkActualizarPrecio.CheckedChanged += chkActualizarprecio_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(429, 326);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 12;
            label5.Text = "Subtotal S/I";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(429, 356);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 13;
            label6.Text = "Imp. Internos";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(429, 387);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 14;
            label7.Text = "Subtotal C/I";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(429, 418);
            label8.Name = "label8";
            label8.Size = new Size(24, 15);
            label8.TabIndex = 15;
            label8.Text = "IVA";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(429, 449);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 16;
            label9.Text = "Total";
            // 
            // txtSubsinImpuesto
            // 
            txtSubsinImpuesto.Location = new Point(518, 322);
            txtSubsinImpuesto.Name = "txtSubsinImpuesto";
            txtSubsinImpuesto.Size = new Size(105, 23);
            txtSubsinImpuesto.TabIndex = 17;
            // 
            // txtImpuestosInternos
            // 
            txtImpuestosInternos.Location = new Point(518, 353);
            txtImpuestosInternos.Name = "txtImpuestosInternos";
            txtImpuestosInternos.Size = new Size(105, 23);
            txtImpuestosInternos.TabIndex = 18;
            // 
            // txtSubConImpuesto
            // 
            txtSubConImpuesto.Location = new Point(518, 384);
            txtSubConImpuesto.Name = "txtSubConImpuesto";
            txtSubConImpuesto.Size = new Size(105, 23);
            txtSubConImpuesto.TabIndex = 19;
            // 
            // txtIva
            // 
            txtIva.Location = new Point(518, 415);
            txtIva.Name = "txtIva";
            txtIva.Size = new Size(105, 23);
            txtIva.TabIndex = 20;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(518, 446);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(105, 23);
            txtTotal.TabIndex = 21;
            // 
            // gpbFormasdePago
            // 
            gpbFormasdePago.Controls.Add(txtPagosDebito);
            gpbFormasdePago.Controls.Add(txtPagosCuenta);
            gpbFormasdePago.Controls.Add(txtPagoTransferencia);
            gpbFormasdePago.Controls.Add(txtPagoEfectivo);
            gpbFormasdePago.Controls.Add(txtPagoTarjeta);
            gpbFormasdePago.Controls.Add(label13);
            gpbFormasdePago.Controls.Add(label12);
            gpbFormasdePago.Controls.Add(label11);
            gpbFormasdePago.Controls.Add(label10);
            gpbFormasdePago.Controls.Add(Efectivo);
            gpbFormasdePago.Location = new Point(14, 391);
            gpbFormasdePago.Name = "gpbFormasdePago";
            gpbFormasdePago.Size = new Size(399, 76);
            gpbFormasdePago.TabIndex = 22;
            gpbFormasdePago.TabStop = false;
            gpbFormasdePago.Text = "Formas de Pago";
            // 
            // txtPagosDebito
            // 
            txtPagosDebito.Location = new Point(320, 45);
            txtPagosDebito.Name = "txtPagosDebito";
            txtPagosDebito.Size = new Size(73, 23);
            txtPagosDebito.TabIndex = 23;
            // 
            // txtPagosCuenta
            // 
            txtPagosCuenta.Location = new Point(241, 45);
            txtPagosCuenta.Name = "txtPagosCuenta";
            txtPagosCuenta.Size = new Size(73, 23);
            txtPagosCuenta.TabIndex = 23;
            // 
            // txtPagoTransferencia
            // 
            txtPagoTransferencia.Location = new Point(162, 45);
            txtPagoTransferencia.Name = "txtPagoTransferencia";
            txtPagoTransferencia.Size = new Size(73, 23);
            txtPagoTransferencia.TabIndex = 24;
            // 
            // txtPagoEfectivo
            // 
            txtPagoEfectivo.Location = new Point(4, 45);
            txtPagoEfectivo.Name = "txtPagoEfectivo";
            txtPagoEfectivo.Size = new Size(73, 23);
            txtPagoEfectivo.TabIndex = 5;
            // 
            // txtPagoTarjeta
            // 
            txtPagoTarjeta.Location = new Point(83, 45);
            txtPagoTarjeta.Name = "txtPagoTarjeta";
            txtPagoTarjeta.Size = new Size(73, 23);
            txtPagoTarjeta.TabIndex = 23;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(320, 27);
            label13.Name = "label13";
            label13.Size = new Size(42, 15);
            label13.TabIndex = 4;
            label13.Text = "Debito";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(241, 27);
            label12.Name = "label12";
            label12.Size = new Size(49, 15);
            label12.TabIndex = 3;
            label12.Text = "Cta. Cte";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(161, 27);
            label11.Name = "label11";
            label11.Size = new Size(76, 15);
            label11.TabIndex = 2;
            label11.Text = "Transferencia";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(83, 27);
            label10.Name = "label10";
            label10.Size = new Size(41, 15);
            label10.TabIndex = 1;
            label10.Text = "Tarjeta";
            // 
            // Efectivo
            // 
            Efectivo.AutoSize = true;
            Efectivo.Location = new Point(4, 27);
            Efectivo.Name = "Efectivo";
            Efectivo.Size = new Size(49, 15);
            Efectivo.TabIndex = 0;
            Efectivo.Text = "Efectivo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 481);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 23;
            label4.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(107, 478);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(516, 78);
            txtObservaciones.TabIndex = 24;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(467, 582);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 25;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCacelar
            // 
            btnCacelar.Location = new Point(548, 582);
            btnCacelar.Name = "btnCacelar";
            btnCacelar.Size = new Size(75, 23);
            btnCacelar.TabIndex = 26;
            btnCacelar.Text = "Cancelar";
            btnCacelar.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Factura A" });
            comboBox1.Location = new Point(473, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 23);
            comboBox1.TabIndex = 27;
            // 
            // chkCompraAnulada
            // 
            chkCompraAnulada.AutoSize = true;
            chkCompraAnulada.Location = new Point(14, 596);
            chkCompraAnulada.Name = "chkCompraAnulada";
            chkCompraAnulada.Size = new Size(116, 19);
            chkCompraAnulada.TabIndex = 28;
            chkCompraAnulada.Text = "Compra Anulada";
            chkCompraAnulada.UseVisualStyleBackColor = true;
            chkCompraAnulada.CheckedChanged += chkCompraAnulada_CheckedChanged;
            // 
            // frmNuevaCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 635);
            Controls.Add(chkCompraAnulada);
            Controls.Add(comboBox1);
            Controls.Add(btnCacelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservaciones);
            Controls.Add(label4);
            Controls.Add(gpbFormasdePago);
            Controls.Add(txtTotal);
            Controls.Add(txtIva);
            Controls.Add(txtSubConImpuesto);
            Controls.Add(txtImpuestosInternos);
            Controls.Add(txtSubsinImpuesto);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(gpbOpciones);
            Controls.Add(btnEliminarProducto);
            Controls.Add(dataGridView1);
            Controls.Add(btnBuscarProducto);
            Controls.Add(txtCodigobarra);
            Controls.Add(dateTimePicker1);
            Controls.Add(gpbProveedor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmNuevaCompra";
            Text = "Nueva Compra";
            gpbProveedor.ResumeLayout(false);
            gpbProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            gpbOpciones.ResumeLayout(false);
            gpbOpciones.PerformLayout();
            gpbFormasdePago.ResumeLayout(false);
            gpbFormasdePago.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox gpbProveedor;
        private Button btnBuscar;
        private TextBox txtProveedor;
        private DateTimePicker dateTimePicker1;
        private TextBox txtCodigobarra;
        private Button btnBuscarProducto;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Button btnEliminarProducto;
        private GroupBox gpbOpciones;
        private CheckBox chkActualizarStock;
        private CheckBox chkActualizarPrecio;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtSubsinImpuesto;
        private TextBox txtImpuestosInternos;
        private TextBox txtSubConImpuesto;
        private TextBox txtIva;
        private TextBox txtTotal;
        private GroupBox gpbFormasdePago;
        private TextBox txtPagosDebito;
        private TextBox txtPagosCuenta;
        private TextBox txtPagoTransferencia;
        private TextBox txtPagoEfectivo;
        private TextBox txtPagoTarjeta;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label Efectivo;
        private Label label4;
        private TextBox txtObservaciones;
        private Button btnGuardar;
        private Button btnCacelar;
        private ComboBox comboBox1;
        private CheckBox chkCompraAnulada;
    }
}