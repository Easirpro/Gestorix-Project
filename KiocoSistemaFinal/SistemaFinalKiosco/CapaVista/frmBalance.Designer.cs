namespace CapaVista
{
    partial class frmBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalance));
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnHoy = new Button();
            btnEsteMes = new Button();
            btnConsultar = new Button();
            btnExportar = new Button();
            tabBalance = new TabControl();
            tabResumen = new TabPage();
            grpIndicadores = new GroupBox();
            lblTitVentas = new Label();
            lblIndVentas = new Label();
            lblTitTicket = new Label();
            lblIndTicket = new Label();
            lblTitAnuladas = new Label();
            lblIndAnuladas = new Label();
            lblTitDevoluciones = new Label();
            lblIndDevoluciones = new Label();
            lblTitCajas = new Label();
            lblIndCajas = new Label();
            lblTitFaltantes = new Label();
            lblIndFaltantes = new Label();
            dgvResumen = new DataGridView();
            tabMedioPago = new TabPage();
            dgvMedioPago = new DataGridView();
            tabPorDia = new TabPage();
            dgvPorDia = new DataGridView();
            tabEmpleados = new TabPage();
            dgvEmpleados = new DataGridView();
            tabProductos = new TabPage();
            dgvProductos = new DataGridView();
            tabPromociones = new TabPage();
            dgvPromociones = new DataGridView();
            tabDetalle = new TabPage();
            lblTipoDetalle = new Label();
            cmbTipoDetalle = new ComboBox();
            lblMedioDetalle = new Label();
            cmbMedioDetalle = new ComboBox();
            lblUsuarioDetalle = new Label();
            cmbUsuarioDetalle = new ComboBox();
            btnFiltrarDetalle = new Button();
            dgvDetalle = new DataGridView();
            lblTotalDetalle = new Label();
            btnSalir = new Button();
            tabBalance.SuspendLayout();
            tabResumen.SuspendLayout();
            grpIndicadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            tabMedioPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedioPago).BeginInit();
            tabPorDia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPorDia).BeginInit();
            tabEmpleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            tabProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            tabPromociones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPromociones).BeginInit();
            tabDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(12, 18);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(60, 14);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(120, 23);
            dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(195, 18);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(240, 14);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(120, 23);
            dtpHasta.TabIndex = 3;
            // 
            // btnHoy
            // 
            btnHoy.Location = new Point(375, 12);
            btnHoy.Name = "btnHoy";
            btnHoy.Size = new Size(80, 28);
            btnHoy.TabIndex = 4;
            btnHoy.Text = "Hoy";
            btnHoy.UseVisualStyleBackColor = true;
            btnHoy.Click += btnHoy_Click;
            // 
            // btnEsteMes
            // 
            btnEsteMes.Location = new Point(460, 12);
            btnEsteMes.Name = "btnEsteMes";
            btnEsteMes.Size = new Size(90, 28);
            btnEsteMes.TabIndex = 5;
            btnEsteMes.Text = "Este mes";
            btnEsteMes.UseVisualStyleBackColor = true;
            btnEsteMes.Click += btnEsteMes_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(560, 12);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(110, 28);
            btnConsultar.TabIndex = 6;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportar.Location = new Point(958, 12);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(130, 28);
            btnExportar.TabIndex = 7;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // tabBalance
            // 
            tabBalance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabBalance.Controls.Add(tabResumen);
            tabBalance.Controls.Add(tabMedioPago);
            tabBalance.Controls.Add(tabPorDia);
            tabBalance.Controls.Add(tabEmpleados);
            tabBalance.Controls.Add(tabProductos);
            tabBalance.Controls.Add(tabPromociones);
            tabBalance.Controls.Add(tabDetalle);
            tabBalance.Location = new Point(12, 50);
            tabBalance.Name = "tabBalance";
            tabBalance.SelectedIndex = 0;
            tabBalance.Size = new Size(1076, 576);
            tabBalance.TabIndex = 8;
            // 
            // tabResumen
            // 
            tabResumen.Controls.Add(grpIndicadores);
            tabResumen.Controls.Add(dgvResumen);
            tabResumen.Location = new Point(4, 24);
            tabResumen.Name = "tabResumen";
            tabResumen.Padding = new Padding(3);
            tabResumen.Size = new Size(1068, 548);
            tabResumen.TabIndex = 0;
            tabResumen.Text = "Resumen";
            tabResumen.UseVisualStyleBackColor = true;
            // 
            // grpIndicadores
            // 
            grpIndicadores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpIndicadores.Controls.Add(lblTitVentas);
            grpIndicadores.Controls.Add(lblIndVentas);
            grpIndicadores.Controls.Add(lblTitTicket);
            grpIndicadores.Controls.Add(lblIndTicket);
            grpIndicadores.Controls.Add(lblTitAnuladas);
            grpIndicadores.Controls.Add(lblIndAnuladas);
            grpIndicadores.Controls.Add(lblTitDevoluciones);
            grpIndicadores.Controls.Add(lblIndDevoluciones);
            grpIndicadores.Controls.Add(lblTitCajas);
            grpIndicadores.Controls.Add(lblIndCajas);
            grpIndicadores.Controls.Add(lblTitFaltantes);
            grpIndicadores.Controls.Add(lblIndFaltantes);
            grpIndicadores.Location = new Point(6, 6);
            grpIndicadores.Name = "grpIndicadores";
            grpIndicadores.Size = new Size(1056, 80);
            grpIndicadores.TabIndex = 9;
            grpIndicadores.TabStop = false;
            grpIndicadores.Text = "Indicadores del período";
            // 
            // lblTitVentas
            // 
            lblTitVentas.AutoSize = true;
            lblTitVentas.Location = new Point(15, 22);
            lblTitVentas.Name = "lblTitVentas";
            lblTitVentas.Size = new Size(41, 15);
            lblTitVentas.TabIndex = 10;
            lblTitVentas.Text = "Ventas";
            // 
            // lblIndVentas
            // 
            lblIndVentas.AutoSize = true;
            lblIndVentas.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIndVentas.Location = new Point(15, 42);
            lblIndVentas.Name = "lblIndVentas";
            lblIndVentas.Size = new Size(18, 20);
            lblIndVentas.TabIndex = 11;
            lblIndVentas.Text = "0";
            // 
            // lblTitTicket
            // 
            lblTitTicket.AutoSize = true;
            lblTitTicket.Location = new Point(180, 22);
            lblTitTicket.Name = "lblTitTicket";
            lblTitTicket.Size = new Size(93, 15);
            lblTitTicket.TabIndex = 12;
            lblTitTicket.Text = "Ticket promedio";
            // 
            // lblIndTicket
            // 
            lblIndTicket.AutoSize = true;
            lblIndTicket.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIndTicket.Location = new Point(180, 42);
            lblIndTicket.Name = "lblIndTicket";
            lblIndTicket.Size = new Size(53, 20);
            lblIndTicket.TabIndex = 13;
            lblIndTicket.Text = "$ 0,00";
            // 
            // lblTitAnuladas
            // 
            lblTitAnuladas.AutoSize = true;
            lblTitAnuladas.Location = new Point(360, 22);
            lblTitAnuladas.Name = "lblTitAnuladas";
            lblTitAnuladas.Size = new Size(91, 15);
            lblTitAnuladas.TabIndex = 14;
            lblTitAnuladas.Text = "Ventas anuladas";
            // 
            // lblIndAnuladas
            // 
            lblIndAnuladas.AutoSize = true;
            lblIndAnuladas.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIndAnuladas.Location = new Point(360, 42);
            lblIndAnuladas.Name = "lblIndAnuladas";
            lblIndAnuladas.Size = new Size(18, 20);
            lblIndAnuladas.TabIndex = 15;
            lblIndAnuladas.Text = "0";
            // 
            // lblTitDevoluciones
            // 
            lblTitDevoluciones.AutoSize = true;
            lblTitDevoluciones.Location = new Point(580, 22);
            lblTitDevoluciones.Name = "lblTitDevoluciones";
            lblTitDevoluciones.Size = new Size(78, 15);
            lblTitDevoluciones.TabIndex = 16;
            lblTitDevoluciones.Text = "Devoluciones";
            // 
            // lblIndDevoluciones
            // 
            lblIndDevoluciones.AutoSize = true;
            lblIndDevoluciones.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIndDevoluciones.Location = new Point(580, 42);
            lblIndDevoluciones.Name = "lblIndDevoluciones";
            lblIndDevoluciones.Size = new Size(18, 20);
            lblIndDevoluciones.TabIndex = 17;
            lblIndDevoluciones.Text = "0";
            // 
            // lblTitCajas
            // 
            lblTitCajas.AutoSize = true;
            lblTitCajas.Location = new Point(740, 22);
            lblTitCajas.Name = "lblTitCajas";
            lblTitCajas.Size = new Size(82, 15);
            lblTitCajas.TabIndex = 18;
            lblTitCajas.Text = "Cajas cerradas";
            // 
            // lblIndCajas
            // 
            lblIndCajas.AutoSize = true;
            lblIndCajas.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIndCajas.Location = new Point(740, 42);
            lblIndCajas.Name = "lblIndCajas";
            lblIndCajas.Size = new Size(18, 20);
            lblIndCajas.TabIndex = 19;
            lblIndCajas.Text = "0";
            // 
            // lblTitFaltantes
            // 
            lblTitFaltantes.AutoSize = true;
            lblTitFaltantes.Location = new Point(900, 22);
            lblTitFaltantes.Name = "lblTitFaltantes";
            lblTitFaltantes.Size = new Size(101, 15);
            lblTitFaltantes.TabIndex = 20;
            lblTitFaltantes.Text = "Cajas con faltante";
            // 
            // lblIndFaltantes
            // 
            lblIndFaltantes.AutoSize = true;
            lblIndFaltantes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIndFaltantes.ForeColor = Color.Firebrick;
            lblIndFaltantes.Location = new Point(900, 42);
            lblIndFaltantes.Name = "lblIndFaltantes";
            lblIndFaltantes.Size = new Size(18, 20);
            lblIndFaltantes.TabIndex = 21;
            lblIndFaltantes.Text = "0";
            // 
            // dgvResumen
            // 
            dgvResumen.AllowUserToAddRows = false;
            dgvResumen.AllowUserToDeleteRows = false;
            dgvResumen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResumen.BackgroundColor = SystemColors.Window;
            dgvResumen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumen.Location = new Point(6, 92);
            dgvResumen.Name = "dgvResumen";
            dgvResumen.ReadOnly = true;
            dgvResumen.Size = new Size(1056, 450);
            dgvResumen.TabIndex = 22;
            dgvResumen.DataBindingComplete += dgvResumen_DataBindingComplete;
            // 
            // tabMedioPago
            // 
            tabMedioPago.Controls.Add(dgvMedioPago);
            tabMedioPago.Location = new Point(4, 24);
            tabMedioPago.Name = "tabMedioPago";
            tabMedioPago.Padding = new Padding(3);
            tabMedioPago.Size = new Size(1068, 548);
            tabMedioPago.TabIndex = 1;
            tabMedioPago.Text = "Por medio de pago";
            tabMedioPago.UseVisualStyleBackColor = true;
            // 
            // dgvMedioPago
            // 
            dgvMedioPago.AllowUserToAddRows = false;
            dgvMedioPago.AllowUserToDeleteRows = false;
            dgvMedioPago.BackgroundColor = SystemColors.Window;
            dgvMedioPago.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedioPago.Dock = DockStyle.Fill;
            dgvMedioPago.Location = new Point(3, 3);
            dgvMedioPago.Name = "dgvMedioPago";
            dgvMedioPago.ReadOnly = true;
            dgvMedioPago.Size = new Size(1062, 542);
            dgvMedioPago.TabIndex = 23;
            dgvMedioPago.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // tabPorDia
            // 
            tabPorDia.Controls.Add(dgvPorDia);
            tabPorDia.Location = new Point(4, 24);
            tabPorDia.Name = "tabPorDia";
            tabPorDia.Padding = new Padding(3);
            tabPorDia.Size = new Size(1068, 548);
            tabPorDia.TabIndex = 2;
            tabPorDia.Text = "Por día";
            tabPorDia.UseVisualStyleBackColor = true;
            // 
            // dgvPorDia
            // 
            dgvPorDia.AllowUserToAddRows = false;
            dgvPorDia.AllowUserToDeleteRows = false;
            dgvPorDia.BackgroundColor = SystemColors.Window;
            dgvPorDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPorDia.Dock = DockStyle.Fill;
            dgvPorDia.Location = new Point(3, 3);
            dgvPorDia.Name = "dgvPorDia";
            dgvPorDia.ReadOnly = true;
            dgvPorDia.Size = new Size(1062, 542);
            dgvPorDia.TabIndex = 24;
            dgvPorDia.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // tabEmpleados
            // 
            tabEmpleados.Controls.Add(dgvEmpleados);
            tabEmpleados.Location = new Point(4, 24);
            tabEmpleados.Name = "tabEmpleados";
            tabEmpleados.Padding = new Padding(3);
            tabEmpleados.Size = new Size(1068, 548);
            tabEmpleados.TabIndex = 3;
            tabEmpleados.Text = "Por empleado";
            tabEmpleados.UseVisualStyleBackColor = true;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.BackgroundColor = SystemColors.Window;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Dock = DockStyle.Fill;
            dgvEmpleados.Location = new Point(3, 3);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.Size = new Size(1062, 542);
            dgvEmpleados.TabIndex = 25;
            dgvEmpleados.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // tabProductos
            // 
            tabProductos.Controls.Add(dgvProductos);
            tabProductos.Location = new Point(4, 24);
            tabProductos.Name = "tabProductos";
            tabProductos.Padding = new Padding(3);
            tabProductos.Size = new Size(1068, 548);
            tabProductos.TabIndex = 4;
            tabProductos.Text = "Por producto";
            tabProductos.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.BackgroundColor = SystemColors.Window;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(3, 3);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.Size = new Size(1062, 542);
            dgvProductos.TabIndex = 26;
            dgvProductos.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // tabPromociones
            // 
            tabPromociones.Controls.Add(dgvPromociones);
            tabPromociones.Location = new Point(4, 24);
            tabPromociones.Name = "tabPromociones";
            tabPromociones.Padding = new Padding(3);
            tabPromociones.Size = new Size(1068, 548);
            tabPromociones.TabIndex = 5;
            tabPromociones.Text = "Por promoción";
            tabPromociones.UseVisualStyleBackColor = true;
            // 
            // dgvPromociones
            // 
            dgvPromociones.AllowUserToAddRows = false;
            dgvPromociones.AllowUserToDeleteRows = false;
            dgvPromociones.BackgroundColor = SystemColors.Window;
            dgvPromociones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPromociones.Dock = DockStyle.Fill;
            dgvPromociones.Location = new Point(3, 3);
            dgvPromociones.Name = "dgvPromociones";
            dgvPromociones.ReadOnly = true;
            dgvPromociones.Size = new Size(1062, 542);
            dgvPromociones.TabIndex = 27;
            dgvPromociones.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // tabDetalle
            // 
            tabDetalle.Controls.Add(lblTipoDetalle);
            tabDetalle.Controls.Add(cmbTipoDetalle);
            tabDetalle.Controls.Add(lblMedioDetalle);
            tabDetalle.Controls.Add(cmbMedioDetalle);
            tabDetalle.Controls.Add(lblUsuarioDetalle);
            tabDetalle.Controls.Add(cmbUsuarioDetalle);
            tabDetalle.Controls.Add(btnFiltrarDetalle);
            tabDetalle.Controls.Add(dgvDetalle);
            tabDetalle.Controls.Add(lblTotalDetalle);
            tabDetalle.Location = new Point(4, 24);
            tabDetalle.Name = "tabDetalle";
            tabDetalle.Padding = new Padding(3);
            tabDetalle.Size = new Size(1068, 548);
            tabDetalle.TabIndex = 6;
            tabDetalle.Text = "Detalle de movimientos";
            tabDetalle.UseVisualStyleBackColor = true;
            // 
            // lblTipoDetalle
            // 
            lblTipoDetalle.AutoSize = true;
            lblTipoDetalle.Location = new Point(6, 13);
            lblTipoDetalle.Name = "lblTipoDetalle";
            lblTipoDetalle.Size = new Size(33, 15);
            lblTipoDetalle.TabIndex = 28;
            lblTipoDetalle.Text = "Tipo:";
            // 
            // cmbTipoDetalle
            // 
            cmbTipoDetalle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDetalle.FormattingEnabled = true;
            cmbTipoDetalle.Location = new Point(45, 9);
            cmbTipoDetalle.Name = "cmbTipoDetalle";
            cmbTipoDetalle.Size = new Size(120, 23);
            cmbTipoDetalle.TabIndex = 29;
            // 
            // lblMedioDetalle
            // 
            lblMedioDetalle.AutoSize = true;
            lblMedioDetalle.Location = new Point(180, 13);
            lblMedioDetalle.Name = "lblMedioDetalle";
            lblMedioDetalle.Size = new Size(90, 15);
            lblMedioDetalle.TabIndex = 30;
            lblMedioDetalle.Text = "Medio de pago:";
            // 
            // cmbMedioDetalle
            // 
            cmbMedioDetalle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioDetalle.FormattingEnabled = true;
            cmbMedioDetalle.Location = new Point(275, 9);
            cmbMedioDetalle.Name = "cmbMedioDetalle";
            cmbMedioDetalle.Size = new Size(160, 23);
            cmbMedioDetalle.TabIndex = 31;
            // 
            // lblUsuarioDetalle
            // 
            lblUsuarioDetalle.AutoSize = true;
            lblUsuarioDetalle.Location = new Point(450, 13);
            lblUsuarioDetalle.Name = "lblUsuarioDetalle";
            lblUsuarioDetalle.Size = new Size(87, 15);
            lblUsuarioDetalle.TabIndex = 32;
            lblUsuarioDetalle.Text = "Registrado por:";
            // 
            // cmbUsuarioDetalle
            // 
            cmbUsuarioDetalle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarioDetalle.FormattingEnabled = true;
            cmbUsuarioDetalle.Location = new Point(550, 9);
            cmbUsuarioDetalle.Name = "cmbUsuarioDetalle";
            cmbUsuarioDetalle.Size = new Size(200, 23);
            cmbUsuarioDetalle.TabIndex = 33;
            // 
            // btnFiltrarDetalle
            // 
            btnFiltrarDetalle.Location = new Point(765, 7);
            btnFiltrarDetalle.Name = "btnFiltrarDetalle";
            btnFiltrarDetalle.Size = new Size(100, 28);
            btnFiltrarDetalle.TabIndex = 34;
            btnFiltrarDetalle.Text = "Filtrar";
            btnFiltrarDetalle.UseVisualStyleBackColor = true;
            btnFiltrarDetalle.Click += btnFiltrarDetalle_Click;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalle.BackgroundColor = SystemColors.Window;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(6, 42);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.Size = new Size(1056, 470);
            dgvDetalle.TabIndex = 35;
            dgvDetalle.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // lblTotalDetalle
            // 
            lblTotalDetalle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalDetalle.AutoSize = true;
            lblTotalDetalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalDetalle.Location = new Point(6, 520);
            lblTotalDetalle.Name = "lblTotalDetalle";
            lblTotalDetalle.Size = new Size(0, 15);
            lblTotalDetalle.TabIndex = 36;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(968, 634);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 30);
            btnSalir.TabIndex = 37;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmBalance
            // 
            AcceptButton = btnConsultar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new Size(1100, 676);
            Controls.Add(lblDesde);
            Controls.Add(dtpDesde);
            Controls.Add(lblHasta);
            Controls.Add(dtpHasta);
            Controls.Add(btnHoy);
            Controls.Add(btnEsteMes);
            Controls.Add(btnConsultar);
            Controls.Add(btnExportar);
            Controls.Add(tabBalance);
            Controls.Add(btnSalir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1116, 715);
            Name = "frmBalance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Balance";
            Load += frmBalance_Load;
            tabBalance.ResumeLayout(false);
            tabResumen.ResumeLayout(false);
            grpIndicadores.ResumeLayout(false);
            grpIndicadores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            tabMedioPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedioPago).EndInit();
            tabPorDia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPorDia).EndInit();
            tabEmpleados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            tabProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            tabPromociones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPromociones).EndInit();
            tabDetalle.ResumeLayout(false);
            tabDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnEsteMes;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TabControl tabBalance;
        private System.Windows.Forms.TabPage tabResumen;
        private System.Windows.Forms.TabPage tabMedioPago;
        private System.Windows.Forms.TabPage tabPorDia;
        private System.Windows.Forms.TabPage tabEmpleados;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.TabPage tabPromociones;
        private System.Windows.Forms.TabPage tabDetalle;
        private System.Windows.Forms.GroupBox grpIndicadores;
        private System.Windows.Forms.Label lblTitVentas;
        private System.Windows.Forms.Label lblIndVentas;
        private System.Windows.Forms.Label lblTitTicket;
        private System.Windows.Forms.Label lblIndTicket;
        private System.Windows.Forms.Label lblTitAnuladas;
        private System.Windows.Forms.Label lblIndAnuladas;
        private System.Windows.Forms.Label lblTitDevoluciones;
        private System.Windows.Forms.Label lblIndDevoluciones;
        private System.Windows.Forms.Label lblTitCajas;
        private System.Windows.Forms.Label lblIndCajas;
        private System.Windows.Forms.Label lblTitFaltantes;
        private System.Windows.Forms.Label lblIndFaltantes;
        private System.Windows.Forms.DataGridView dgvResumen;
        private System.Windows.Forms.DataGridView dgvMedioPago;
        private System.Windows.Forms.DataGridView dgvPorDia;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvPromociones;
        private System.Windows.Forms.Label lblTipoDetalle;
        private System.Windows.Forms.ComboBox cmbTipoDetalle;
        private System.Windows.Forms.Label lblMedioDetalle;
        private System.Windows.Forms.ComboBox cmbMedioDetalle;
        private System.Windows.Forms.Label lblUsuarioDetalle;
        private System.Windows.Forms.ComboBox cmbUsuarioDetalle;
        private System.Windows.Forms.Button btnFiltrarDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblTotalDetalle;
        private System.Windows.Forms.Button btnSalir;
    }
}
