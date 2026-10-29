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
            lblDesde = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            btnHoy = new System.Windows.Forms.Button();
            btnEsteMes = new System.Windows.Forms.Button();
            btnConsultar = new System.Windows.Forms.Button();
            btnExportar = new System.Windows.Forms.Button();
            tabBalance = new System.Windows.Forms.TabControl();
            tabResumen = new System.Windows.Forms.TabPage();
            tabMedioPago = new System.Windows.Forms.TabPage();
            tabPorDia = new System.Windows.Forms.TabPage();
            tabEmpleados = new System.Windows.Forms.TabPage();
            tabProductos = new System.Windows.Forms.TabPage();
            tabPromociones = new System.Windows.Forms.TabPage();
            tabDetalle = new System.Windows.Forms.TabPage();
            grpIndicadores = new System.Windows.Forms.GroupBox();
            lblTitVentas = new System.Windows.Forms.Label();
            lblIndVentas = new System.Windows.Forms.Label();
            lblTitTicket = new System.Windows.Forms.Label();
            lblIndTicket = new System.Windows.Forms.Label();
            lblTitAnuladas = new System.Windows.Forms.Label();
            lblIndAnuladas = new System.Windows.Forms.Label();
            lblTitDevoluciones = new System.Windows.Forms.Label();
            lblIndDevoluciones = new System.Windows.Forms.Label();
            lblTitCajas = new System.Windows.Forms.Label();
            lblIndCajas = new System.Windows.Forms.Label();
            lblTitFaltantes = new System.Windows.Forms.Label();
            lblIndFaltantes = new System.Windows.Forms.Label();
            dgvResumen = new System.Windows.Forms.DataGridView();
            dgvMedioPago = new System.Windows.Forms.DataGridView();
            dgvPorDia = new System.Windows.Forms.DataGridView();
            dgvEmpleados = new System.Windows.Forms.DataGridView();
            dgvProductos = new System.Windows.Forms.DataGridView();
            dgvPromociones = new System.Windows.Forms.DataGridView();
            lblTipoDetalle = new System.Windows.Forms.Label();
            cmbTipoDetalle = new System.Windows.Forms.ComboBox();
            lblMedioDetalle = new System.Windows.Forms.Label();
            cmbMedioDetalle = new System.Windows.Forms.ComboBox();
            lblUsuarioDetalle = new System.Windows.Forms.Label();
            cmbUsuarioDetalle = new System.Windows.Forms.ComboBox();
            btnFiltrarDetalle = new System.Windows.Forms.Button();
            dgvDetalle = new System.Windows.Forms.DataGridView();
            lblTotalDetalle = new System.Windows.Forms.Label();
            btnSalir = new System.Windows.Forms.Button();
            tabBalance.SuspendLayout();
            tabResumen.SuspendLayout();
            tabMedioPago.SuspendLayout();
            tabPorDia.SuspendLayout();
            tabEmpleados.SuspendLayout();
            tabProductos.SuspendLayout();
            tabPromociones.SuspendLayout();
            tabDetalle.SuspendLayout();
            grpIndicadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedioPago).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPorDia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPromociones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // lblDesde
            // 
            lblDesde.Location = new System.Drawing.Point(12, 18);
            lblDesde.Name = "lblDesde";
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            lblDesde.AutoSize = true;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new System.Drawing.Point(60, 14);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new System.Drawing.Size(120, 23);
            dtpDesde.TabIndex = 1;
            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblHasta
            // 
            lblHasta.Location = new System.Drawing.Point(195, 18);
            lblHasta.Name = "lblHasta";
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            lblHasta.AutoSize = true;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new System.Drawing.Point(240, 14);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new System.Drawing.Size(120, 23);
            dtpHasta.TabIndex = 3;
            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // btnHoy
            // 
            btnHoy.Location = new System.Drawing.Point(375, 12);
            btnHoy.Name = "btnHoy";
            btnHoy.Size = new System.Drawing.Size(80, 28);
            btnHoy.TabIndex = 4;
            btnHoy.Text = "Hoy";
            btnHoy.UseVisualStyleBackColor = true;
            btnHoy.Click += btnHoy_Click;
            // 
            // btnEsteMes
            // 
            btnEsteMes.Location = new System.Drawing.Point(460, 12);
            btnEsteMes.Name = "btnEsteMes";
            btnEsteMes.Size = new System.Drawing.Size(90, 28);
            btnEsteMes.TabIndex = 5;
            btnEsteMes.Text = "Este mes";
            btnEsteMes.UseVisualStyleBackColor = true;
            btnEsteMes.Click += btnEsteMes_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new System.Drawing.Point(560, 12);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new System.Drawing.Size(110, 28);
            btnConsultar.TabIndex = 6;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new System.Drawing.Point(958, 12);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new System.Drawing.Size(130, 28);
            btnExportar.TabIndex = 7;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnExportar.Click += btnExportar_Click;
            // 
            // tabBalance
            // 
            tabBalance.Controls.Add(tabResumen);
            tabBalance.Controls.Add(tabMedioPago);
            tabBalance.Controls.Add(tabPorDia);
            tabBalance.Controls.Add(tabEmpleados);
            tabBalance.Controls.Add(tabProductos);
            tabBalance.Controls.Add(tabPromociones);
            tabBalance.Controls.Add(tabDetalle);
            tabBalance.Location = new System.Drawing.Point(12, 50);
            tabBalance.Name = "tabBalance";
            tabBalance.Size = new System.Drawing.Size(1076, 576);
            tabBalance.TabIndex = 8;
            tabBalance.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // tabResumen
            // 
            tabResumen.Controls.Add(grpIndicadores);
            tabResumen.Controls.Add(dgvResumen);
            tabResumen.Location = new System.Drawing.Point(4, 24);
            tabResumen.Name = "tabResumen";
            tabResumen.Size = new System.Drawing.Size(1068, 548);
            tabResumen.TabIndex = 0;
            tabResumen.Text = "Resumen";
            tabResumen.Padding = new System.Windows.Forms.Padding(3);
            tabResumen.UseVisualStyleBackColor = true;
            // 
            // tabMedioPago
            // 
            tabMedioPago.Controls.Add(dgvMedioPago);
            tabMedioPago.Location = new System.Drawing.Point(4, 24);
            tabMedioPago.Name = "tabMedioPago";
            tabMedioPago.Size = new System.Drawing.Size(1068, 548);
            tabMedioPago.TabIndex = 1;
            tabMedioPago.Text = "Por medio de pago";
            tabMedioPago.Padding = new System.Windows.Forms.Padding(3);
            tabMedioPago.UseVisualStyleBackColor = true;
            // 
            // tabPorDia
            // 
            tabPorDia.Controls.Add(dgvPorDia);
            tabPorDia.Location = new System.Drawing.Point(4, 24);
            tabPorDia.Name = "tabPorDia";
            tabPorDia.Size = new System.Drawing.Size(1068, 548);
            tabPorDia.TabIndex = 2;
            tabPorDia.Text = "Por día";
            tabPorDia.Padding = new System.Windows.Forms.Padding(3);
            tabPorDia.UseVisualStyleBackColor = true;
            // 
            // tabEmpleados
            // 
            tabEmpleados.Controls.Add(dgvEmpleados);
            tabEmpleados.Location = new System.Drawing.Point(4, 24);
            tabEmpleados.Name = "tabEmpleados";
            tabEmpleados.Size = new System.Drawing.Size(1068, 548);
            tabEmpleados.TabIndex = 3;
            tabEmpleados.Text = "Por empleado";
            tabEmpleados.Padding = new System.Windows.Forms.Padding(3);
            tabEmpleados.UseVisualStyleBackColor = true;
            // 
            // tabProductos
            // 
            tabProductos.Controls.Add(dgvProductos);
            tabProductos.Location = new System.Drawing.Point(4, 24);
            tabProductos.Name = "tabProductos";
            tabProductos.Size = new System.Drawing.Size(1068, 548);
            tabProductos.TabIndex = 4;
            tabProductos.Text = "Por producto";
            tabProductos.Padding = new System.Windows.Forms.Padding(3);
            tabProductos.UseVisualStyleBackColor = true;
            // 
            // tabPromociones
            // 
            tabPromociones.Controls.Add(dgvPromociones);
            tabPromociones.Location = new System.Drawing.Point(4, 24);
            tabPromociones.Name = "tabPromociones";
            tabPromociones.Size = new System.Drawing.Size(1068, 548);
            tabPromociones.TabIndex = 5;
            tabPromociones.Text = "Por promoción";
            tabPromociones.Padding = new System.Windows.Forms.Padding(3);
            tabPromociones.UseVisualStyleBackColor = true;
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
            tabDetalle.Location = new System.Drawing.Point(4, 24);
            tabDetalle.Name = "tabDetalle";
            tabDetalle.Size = new System.Drawing.Size(1068, 548);
            tabDetalle.TabIndex = 6;
            tabDetalle.Text = "Detalle de movimientos";
            tabDetalle.Padding = new System.Windows.Forms.Padding(3);
            tabDetalle.UseVisualStyleBackColor = true;
            // 
            // grpIndicadores
            // 
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
            grpIndicadores.Location = new System.Drawing.Point(6, 6);
            grpIndicadores.Name = "grpIndicadores";
            grpIndicadores.Size = new System.Drawing.Size(1056, 80);
            grpIndicadores.TabIndex = 9;
            grpIndicadores.Text = "Indicadores del período";
            grpIndicadores.TabStop = false;
            grpIndicadores.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // lblTitVentas
            // 
            lblTitVentas.Location = new System.Drawing.Point(15, 22);
            lblTitVentas.Name = "lblTitVentas";
            lblTitVentas.TabIndex = 10;
            lblTitVentas.Text = "Ventas";
            lblTitVentas.AutoSize = true;
            // 
            // lblIndVentas
            // 
            lblIndVentas.Location = new System.Drawing.Point(15, 42);
            lblIndVentas.Name = "lblIndVentas";
            lblIndVentas.TabIndex = 11;
            lblIndVentas.Text = "0";
            lblIndVentas.AutoSize = true;
            lblIndVentas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblTitTicket
            // 
            lblTitTicket.Location = new System.Drawing.Point(180, 22);
            lblTitTicket.Name = "lblTitTicket";
            lblTitTicket.TabIndex = 12;
            lblTitTicket.Text = "Ticket promedio";
            lblTitTicket.AutoSize = true;
            // 
            // lblIndTicket
            // 
            lblIndTicket.Location = new System.Drawing.Point(180, 42);
            lblIndTicket.Name = "lblIndTicket";
            lblIndTicket.TabIndex = 13;
            lblIndTicket.Text = "$ 0,00";
            lblIndTicket.AutoSize = true;
            lblIndTicket.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblTitAnuladas
            // 
            lblTitAnuladas.Location = new System.Drawing.Point(360, 22);
            lblTitAnuladas.Name = "lblTitAnuladas";
            lblTitAnuladas.TabIndex = 14;
            lblTitAnuladas.Text = "Ventas anuladas";
            lblTitAnuladas.AutoSize = true;
            // 
            // lblIndAnuladas
            // 
            lblIndAnuladas.Location = new System.Drawing.Point(360, 42);
            lblIndAnuladas.Name = "lblIndAnuladas";
            lblIndAnuladas.TabIndex = 15;
            lblIndAnuladas.Text = "0";
            lblIndAnuladas.AutoSize = true;
            lblIndAnuladas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblTitDevoluciones
            // 
            lblTitDevoluciones.Location = new System.Drawing.Point(580, 22);
            lblTitDevoluciones.Name = "lblTitDevoluciones";
            lblTitDevoluciones.TabIndex = 16;
            lblTitDevoluciones.Text = "Devoluciones";
            lblTitDevoluciones.AutoSize = true;
            // 
            // lblIndDevoluciones
            // 
            lblIndDevoluciones.Location = new System.Drawing.Point(580, 42);
            lblIndDevoluciones.Name = "lblIndDevoluciones";
            lblIndDevoluciones.TabIndex = 17;
            lblIndDevoluciones.Text = "0";
            lblIndDevoluciones.AutoSize = true;
            lblIndDevoluciones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblTitCajas
            // 
            lblTitCajas.Location = new System.Drawing.Point(740, 22);
            lblTitCajas.Name = "lblTitCajas";
            lblTitCajas.TabIndex = 18;
            lblTitCajas.Text = "Cajas cerradas";
            lblTitCajas.AutoSize = true;
            // 
            // lblIndCajas
            // 
            lblIndCajas.Location = new System.Drawing.Point(740, 42);
            lblIndCajas.Name = "lblIndCajas";
            lblIndCajas.TabIndex = 19;
            lblIndCajas.Text = "0";
            lblIndCajas.AutoSize = true;
            lblIndCajas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // lblTitFaltantes
            // 
            lblTitFaltantes.Location = new System.Drawing.Point(900, 22);
            lblTitFaltantes.Name = "lblTitFaltantes";
            lblTitFaltantes.TabIndex = 20;
            lblTitFaltantes.Text = "Cajas con faltante";
            lblTitFaltantes.AutoSize = true;
            // 
            // lblIndFaltantes
            // 
            lblIndFaltantes.Location = new System.Drawing.Point(900, 42);
            lblIndFaltantes.Name = "lblIndFaltantes";
            lblIndFaltantes.TabIndex = 21;
            lblIndFaltantes.Text = "0";
            lblIndFaltantes.AutoSize = true;
            lblIndFaltantes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblIndFaltantes.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // dgvResumen
            // 
            dgvResumen.Location = new System.Drawing.Point(6, 92);
            dgvResumen.Name = "dgvResumen";
            dgvResumen.Size = new System.Drawing.Size(1056, 450);
            dgvResumen.TabIndex = 22;
            dgvResumen.AllowUserToAddRows = false;
            dgvResumen.AllowUserToDeleteRows = false;
            dgvResumen.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumen.ReadOnly = true;
            dgvResumen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvResumen.DataBindingComplete += dgvResumen_DataBindingComplete;
            // 
            // dgvMedioPago
            // 
            dgvMedioPago.Location = new System.Drawing.Point(3, 3);
            dgvMedioPago.Name = "dgvMedioPago";
            dgvMedioPago.Size = new System.Drawing.Size(1062, 542);
            dgvMedioPago.TabIndex = 23;
            dgvMedioPago.AllowUserToAddRows = false;
            dgvMedioPago.AllowUserToDeleteRows = false;
            dgvMedioPago.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvMedioPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedioPago.ReadOnly = true;
            dgvMedioPago.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMedioPago.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // dgvPorDia
            // 
            dgvPorDia.Location = new System.Drawing.Point(3, 3);
            dgvPorDia.Name = "dgvPorDia";
            dgvPorDia.Size = new System.Drawing.Size(1062, 542);
            dgvPorDia.TabIndex = 24;
            dgvPorDia.AllowUserToAddRows = false;
            dgvPorDia.AllowUserToDeleteRows = false;
            dgvPorDia.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvPorDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPorDia.ReadOnly = true;
            dgvPorDia.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPorDia.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.Location = new System.Drawing.Point(3, 3);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.Size = new System.Drawing.Size(1062, 542);
            dgvEmpleados.TabIndex = 25;
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvEmpleados.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // dgvProductos
            // 
            dgvProductos.Location = new System.Drawing.Point(3, 3);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new System.Drawing.Size(1062, 542);
            dgvProductos.TabIndex = 26;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.ReadOnly = true;
            dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvProductos.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // dgvPromociones
            // 
            dgvPromociones.Location = new System.Drawing.Point(3, 3);
            dgvPromociones.Name = "dgvPromociones";
            dgvPromociones.Size = new System.Drawing.Size(1062, 542);
            dgvPromociones.TabIndex = 27;
            dgvPromociones.AllowUserToAddRows = false;
            dgvPromociones.AllowUserToDeleteRows = false;
            dgvPromociones.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvPromociones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPromociones.ReadOnly = true;
            dgvPromociones.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPromociones.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // lblTipoDetalle
            // 
            lblTipoDetalle.Location = new System.Drawing.Point(6, 13);
            lblTipoDetalle.Name = "lblTipoDetalle";
            lblTipoDetalle.TabIndex = 28;
            lblTipoDetalle.Text = "Tipo:";
            lblTipoDetalle.AutoSize = true;
            // 
            // cmbTipoDetalle
            // 
            cmbTipoDetalle.Location = new System.Drawing.Point(45, 9);
            cmbTipoDetalle.Name = "cmbTipoDetalle";
            cmbTipoDetalle.Size = new System.Drawing.Size(120, 23);
            cmbTipoDetalle.TabIndex = 29;
            cmbTipoDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipoDetalle.FormattingEnabled = true;
            // 
            // lblMedioDetalle
            // 
            lblMedioDetalle.Location = new System.Drawing.Point(180, 13);
            lblMedioDetalle.Name = "lblMedioDetalle";
            lblMedioDetalle.TabIndex = 30;
            lblMedioDetalle.Text = "Medio de pago:";
            lblMedioDetalle.AutoSize = true;
            // 
            // cmbMedioDetalle
            // 
            cmbMedioDetalle.Location = new System.Drawing.Point(275, 9);
            cmbMedioDetalle.Name = "cmbMedioDetalle";
            cmbMedioDetalle.Size = new System.Drawing.Size(160, 23);
            cmbMedioDetalle.TabIndex = 31;
            cmbMedioDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMedioDetalle.FormattingEnabled = true;
            // 
            // lblUsuarioDetalle
            // 
            lblUsuarioDetalle.Location = new System.Drawing.Point(450, 13);
            lblUsuarioDetalle.Name = "lblUsuarioDetalle";
            lblUsuarioDetalle.TabIndex = 32;
            lblUsuarioDetalle.Text = "Registrado por:";
            lblUsuarioDetalle.AutoSize = true;
            // 
            // cmbUsuarioDetalle
            // 
            cmbUsuarioDetalle.Location = new System.Drawing.Point(550, 9);
            cmbUsuarioDetalle.Name = "cmbUsuarioDetalle";
            cmbUsuarioDetalle.Size = new System.Drawing.Size(200, 23);
            cmbUsuarioDetalle.TabIndex = 33;
            cmbUsuarioDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbUsuarioDetalle.FormattingEnabled = true;
            // 
            // btnFiltrarDetalle
            // 
            btnFiltrarDetalle.Location = new System.Drawing.Point(765, 7);
            btnFiltrarDetalle.Name = "btnFiltrarDetalle";
            btnFiltrarDetalle.Size = new System.Drawing.Size(100, 28);
            btnFiltrarDetalle.TabIndex = 34;
            btnFiltrarDetalle.Text = "Filtrar";
            btnFiltrarDetalle.UseVisualStyleBackColor = true;
            btnFiltrarDetalle.Click += btnFiltrarDetalle_Click;
            // 
            // dgvDetalle
            // 
            dgvDetalle.Location = new System.Drawing.Point(6, 42);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new System.Drawing.Size(1056, 470);
            dgvDetalle.TabIndex = 35;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvDetalle.DataBindingComplete += grilla_DataBindingComplete;
            // 
            // lblTotalDetalle
            // 
            lblTotalDetalle.Location = new System.Drawing.Point(6, 520);
            lblTotalDetalle.Name = "lblTotalDetalle";
            lblTotalDetalle.TabIndex = 36;
            lblTotalDetalle.Text = "";
            lblTotalDetalle.AutoSize = true;
            lblTotalDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotalDetalle.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            // 
            // btnSalir
            // 
            btnSalir.Location = new System.Drawing.Point(968, 634);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(120, 30);
            btnSalir.TabIndex = 37;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmBalance
            // 
            AcceptButton = btnConsultar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnSalir;
            ClientSize = new System.Drawing.Size(1100, 676);
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
            MinimumSize = new System.Drawing.Size(1116, 715);
            Name = "frmBalance";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Balance";
            Load += frmBalance_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedioPago).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPorDia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPromociones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            grpIndicadores.ResumeLayout(false);
            grpIndicadores.PerformLayout();
            tabDetalle.ResumeLayout(false);
            tabDetalle.PerformLayout();
            tabPromociones.ResumeLayout(false);
            tabPromociones.PerformLayout();
            tabProductos.ResumeLayout(false);
            tabProductos.PerformLayout();
            tabEmpleados.ResumeLayout(false);
            tabEmpleados.PerformLayout();
            tabPorDia.ResumeLayout(false);
            tabPorDia.PerformLayout();
            tabMedioPago.ResumeLayout(false);
            tabMedioPago.PerformLayout();
            tabResumen.ResumeLayout(false);
            tabResumen.PerformLayout();
            tabBalance.ResumeLayout(false);
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
