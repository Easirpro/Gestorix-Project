namespace CapaVista
{
    partial class frmNuevoProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoProveedor));
            lblTitulo = new Label();
            lblAyuda = new Label();
            grpDatos = new GroupBox();
            lblRazonSocial = new Label();
            txtRazonSocial = new TextBox();
            lblSucursal = new Label();
            txtSucursalProveedor = new TextBox();
            lblCuit = new Label();
            txtCuit = new TextBox();
            lblIva = new Label();
            cmbIva = new ComboBox();
            grpContacto = new GroupBox();
            lblTelefono = new Label();
            txtCelular = new TextBox();
            lblTipoTelefono = new Label();
            cmbTipoTelefono = new ComboBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            grpDireccion = new GroupBox();
            lblProvincia = new Label();
            cmbProvincia = new ComboBox();
            lblPartido = new Label();
            cmbPartido = new ComboBox();
            lblLocalidad = new Label();
            cmbLocalidad = new ComboBox();
            lblPostal = new Label();
            txtPostal = new TextBox();
            lblCalle = new Label();
            txtCalle = new TextBox();
            lblNumero = new Label();
            txtNumero = new TextBox();
            chkSinNumero = new CheckBox();
            lblPiso = new Label();
            txtPiso = new TextBox();
            lblDepartamento = new Label();
            txtDepartamento = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            lblContador = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            grpDatos.SuspendLayout();
            grpContacto.SuspendLayout();
            grpDireccion.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(150, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo proveedor";
            //
            // lblAyuda
            //
            lblAyuda.AutoSize = true;
            lblAyuda.ForeColor = SystemColors.GrayText;
            lblAyuda.Location = new Point(13, 36);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(200, 15);
            lblAyuda.TabIndex = 1;
            lblAyuda.Text = "Los campos marcados con * son obligatorios.";
            //
            // grpDatos
            //
            grpDatos.Controls.Add(lblRazonSocial);
            grpDatos.Controls.Add(txtRazonSocial);
            grpDatos.Controls.Add(lblSucursal);
            grpDatos.Controls.Add(txtSucursalProveedor);
            grpDatos.Controls.Add(lblCuit);
            grpDatos.Controls.Add(txtCuit);
            grpDatos.Controls.Add(lblIva);
            grpDatos.Controls.Add(cmbIva);
            grpDatos.Location = new Point(12, 60);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(616, 92);
            grpDatos.TabIndex = 2;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del proveedor";
            //
            // lblRazonSocial
            //
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Location = new Point(12, 28);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(84, 15);
            lblRazonSocial.TabIndex = 0;
            lblRazonSocial.Text = "Razón social: *";
            //
            // txtRazonSocial
            //
            txtRazonSocial.Location = new Point(110, 25);
            txtRazonSocial.MaxLength = 100;
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.PlaceholderText = "Nombre legal del proveedor";
            txtRazonSocial.Size = new Size(190, 23);
            txtRazonSocial.TabIndex = 1;
            //
            // lblSucursal
            //
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(315, 28);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(63, 15);
            lblSucursal.TabIndex = 2;
            lblSucursal.Text = "Sucursal: *";
            //
            // txtSucursalProveedor
            //
            txtSucursalProveedor.Location = new Point(410, 25);
            txtSucursalProveedor.MaxLength = 100;
            txtSucursalProveedor.Name = "txtSucursalProveedor";
            txtSucursalProveedor.PlaceholderText = "Ej.: Casa central";
            txtSucursalProveedor.Size = new Size(190, 23);
            txtSucursalProveedor.TabIndex = 3;
            //
            // lblCuit
            //
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(12, 59);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(35, 15);
            lblCuit.TabIndex = 4;
            lblCuit.Text = "CUIT:";
            //
            // txtCuit
            //
            txtCuit.Location = new Point(110, 56);
            txtCuit.MaxLength = 13;
            txtCuit.Name = "txtCuit";
            txtCuit.PlaceholderText = "Opcional, ej.: 30-12345678-9";
            txtCuit.Size = new Size(190, 23);
            txtCuit.TabIndex = 5;
            txtCuit.KeyPress += txtCuit_KeyPress;
            //
            // lblIva
            //
            lblIva.AutoSize = true;
            lblIva.Location = new Point(315, 59);
            lblIva.Name = "lblIva";
            lblIva.Size = new Size(94, 15);
            lblIva.TabIndex = 6;
            lblIva.Text = "Condición IVA: *";
            //
            // cmbIva
            //
            cmbIva.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIva.FormattingEnabled = true;
            cmbIva.Location = new Point(410, 56);
            cmbIva.Name = "cmbIva";
            cmbIva.Size = new Size(190, 23);
            cmbIva.TabIndex = 7;
            //
            // grpContacto
            //
            grpContacto.Controls.Add(lblTelefono);
            grpContacto.Controls.Add(txtCelular);
            grpContacto.Controls.Add(lblTipoTelefono);
            grpContacto.Controls.Add(cmbTipoTelefono);
            grpContacto.Controls.Add(lblEmail);
            grpContacto.Controls.Add(txtEmail);
            grpContacto.Location = new Point(12, 160);
            grpContacto.Name = "grpContacto";
            grpContacto.Size = new Size(616, 92);
            grpContacto.TabIndex = 3;
            grpContacto.TabStop = false;
            grpContacto.Text = "Contacto";
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(12, 28);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(65, 15);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono: *";
            //
            // txtCelular
            //
            txtCelular.Location = new Point(110, 25);
            txtCelular.MaxLength = 20;
            txtCelular.Name = "txtCelular";
            txtCelular.PlaceholderText = "Solo números";
            txtCelular.Size = new Size(190, 23);
            txtCelular.TabIndex = 1;
            txtCelular.KeyPress += SoloNumeros_KeyPress;
            //
            // lblTipoTelefono
            //
            lblTipoTelefono.AutoSize = true;
            lblTipoTelefono.Location = new Point(315, 28);
            lblTipoTelefono.Name = "lblTipoTelefono";
            lblTipoTelefono.Size = new Size(43, 15);
            lblTipoTelefono.TabIndex = 2;
            lblTipoTelefono.Text = "Tipo: *";
            //
            // cmbTipoTelefono
            //
            cmbTipoTelefono.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoTelefono.FormattingEnabled = true;
            cmbTipoTelefono.Location = new Point(410, 25);
            cmbTipoTelefono.Name = "cmbTipoTelefono";
            cmbTipoTelefono.Size = new Size(190, 23);
            cmbTipoTelefono.TabIndex = 3;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 59);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "E-mail: *";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(110, 56);
            txtEmail.MaxLength = 50;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "ejemplo@proveedor.com";
            txtEmail.Size = new Size(490, 23);
            txtEmail.TabIndex = 5;
            //
            // grpDireccion
            //
            grpDireccion.Controls.Add(lblProvincia);
            grpDireccion.Controls.Add(cmbProvincia);
            grpDireccion.Controls.Add(lblPartido);
            grpDireccion.Controls.Add(cmbPartido);
            grpDireccion.Controls.Add(lblLocalidad);
            grpDireccion.Controls.Add(cmbLocalidad);
            grpDireccion.Controls.Add(lblPostal);
            grpDireccion.Controls.Add(txtPostal);
            grpDireccion.Controls.Add(lblCalle);
            grpDireccion.Controls.Add(txtCalle);
            grpDireccion.Controls.Add(lblNumero);
            grpDireccion.Controls.Add(txtNumero);
            grpDireccion.Controls.Add(chkSinNumero);
            grpDireccion.Controls.Add(lblPiso);
            grpDireccion.Controls.Add(txtPiso);
            grpDireccion.Controls.Add(lblDepartamento);
            grpDireccion.Controls.Add(txtDepartamento);
            grpDireccion.Location = new Point(12, 260);
            grpDireccion.Name = "grpDireccion";
            grpDireccion.Size = new Size(616, 154);
            grpDireccion.TabIndex = 4;
            grpDireccion.TabStop = false;
            grpDireccion.Text = "Dirección";
            //
            // lblProvincia
            //
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(12, 28);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(68, 15);
            lblProvincia.TabIndex = 0;
            lblProvincia.Text = "Provincia: *";
            //
            // cmbProvincia
            //
            cmbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Location = new Point(110, 25);
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(190, 23);
            cmbProvincia.TabIndex = 1;
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            //
            // lblPartido
            //
            lblPartido.AutoSize = true;
            lblPartido.Location = new Point(315, 28);
            lblPartido.Name = "lblPartido";
            lblPartido.Size = new Size(57, 15);
            lblPartido.TabIndex = 2;
            lblPartido.Text = "Partido: *";
            //
            // cmbPartido
            //
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(410, 25);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(190, 23);
            cmbPartido.TabIndex = 3;
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;
            //
            // lblLocalidad
            //
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(12, 59);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(70, 15);
            lblLocalidad.TabIndex = 4;
            lblLocalidad.Text = "Localidad: *";
            //
            // cmbLocalidad
            //
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(110, 56);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(190, 23);
            cmbLocalidad.TabIndex = 5;
            cmbLocalidad.SelectedIndexChanged += cmbLocalidad_SelectedIndexChanged;
            //
            // lblPostal
            //
            lblPostal.AutoSize = true;
            lblPostal.Location = new Point(315, 59);
            lblPostal.Name = "lblPostal";
            lblPostal.Size = new Size(70, 15);
            lblPostal.TabIndex = 6;
            lblPostal.Text = "Cód. postal:";
            //
            // txtPostal
            //
            txtPostal.Location = new Point(410, 56);
            txtPostal.Name = "txtPostal";
            txtPostal.ReadOnly = true;
            txtPostal.Size = new Size(80, 23);
            txtPostal.TabIndex = 7;
            txtPostal.TabStop = false;
            //
            // lblCalle
            //
            lblCalle.AutoSize = true;
            lblCalle.Location = new Point(12, 90);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(45, 15);
            lblCalle.TabIndex = 8;
            lblCalle.Text = "Calle: *";
            //
            // txtCalle
            //
            txtCalle.Location = new Point(110, 87);
            txtCalle.MaxLength = 100;
            txtCalle.Name = "txtCalle";
            txtCalle.PlaceholderText = "Nombre de la calle";
            txtCalle.Size = new Size(190, 23);
            txtCalle.TabIndex = 9;
            //
            // lblNumero
            //
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(315, 90);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(63, 15);
            lblNumero.TabIndex = 10;
            lblNumero.Text = "Número: *";
            //
            // txtNumero
            //
            txtNumero.Location = new Point(410, 87);
            txtNumero.MaxLength = 6;
            txtNumero.Name = "txtNumero";
            txtNumero.PlaceholderText = "Ej.: 1234";
            txtNumero.Size = new Size(80, 23);
            txtNumero.TabIndex = 11;
            txtNumero.KeyPress += SoloNumeros_KeyPress;
            //
            // chkSinNumero
            //
            chkSinNumero.AutoSize = true;
            chkSinNumero.Location = new Point(500, 89);
            chkSinNumero.Name = "chkSinNumero";
            chkSinNumero.Size = new Size(87, 19);
            chkSinNumero.TabIndex = 11;
            chkSinNumero.Text = "Sin número";
            chkSinNumero.UseVisualStyleBackColor = true;
            chkSinNumero.CheckedChanged += chkSinNumero_CheckedChanged;
            //
            // lblPiso
            //
            lblPiso.AutoSize = true;
            lblPiso.Location = new Point(12, 121);
            lblPiso.Name = "lblPiso";
            lblPiso.Size = new Size(32, 15);
            lblPiso.TabIndex = 12;
            lblPiso.Text = "Piso:";
            //
            // txtPiso
            //
            txtPiso.Location = new Point(110, 118);
            txtPiso.MaxLength = 10;
            txtPiso.Name = "txtPiso";
            txtPiso.PlaceholderText = "Opcional";
            txtPiso.Size = new Size(80, 23);
            txtPiso.TabIndex = 13;
            //
            // lblDepartamento
            //
            lblDepartamento.AutoSize = true;
            lblDepartamento.Location = new Point(315, 121);
            lblDepartamento.Name = "lblDepartamento";
            lblDepartamento.Size = new Size(86, 15);
            lblDepartamento.TabIndex = 14;
            lblDepartamento.Text = "Departamento:";
            //
            // txtDepartamento
            //
            txtDepartamento.Location = new Point(410, 118);
            txtDepartamento.MaxLength = 10;
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.PlaceholderText = "Opcional";
            txtDepartamento.Size = new Size(80, 23);
            txtDepartamento.TabIndex = 15;
            //
            // lblObservaciones
            //
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(12, 422);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(87, 15);
            lblObservaciones.TabIndex = 5;
            lblObservaciones.Text = "Observaciones:";
            //
            // txtObservaciones
            //
            txtObservaciones.Location = new Point(12, 440);
            txtObservaciones.MaxLength = 255;
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Notas sobre el proveedor (opcional)";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(616, 64);
            txtObservaciones.TabIndex = 6;
            txtObservaciones.TextChanged += txtObservaciones_TextChanged;
            //
            // lblContador
            //
            lblContador.ForeColor = SystemColors.GrayText;
            lblContador.Location = new Point(528, 422);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(100, 15);
            lblContador.TabIndex = 7;
            lblContador.Text = "0 / 255";
            lblContador.TextAlign = ContentAlignment.TopRight;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(432, 516);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(95, 34);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Location = new Point(533, 516);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(95, 34);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // frmNuevoProveedor
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 562);
            Controls.Add(lblTitulo);
            Controls.Add(lblAyuda);
            Controls.Add(grpDatos);
            Controls.Add(grpContacto);
            Controls.Add(grpDireccion);
            Controls.Add(lblObservaciones);
            Controls.Add(txtObservaciones);
            Controls.Add(lblContador);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNuevoProveedor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nuevo proveedor";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpContacto.ResumeLayout(false);
            grpContacto.PerformLayout();
            grpDireccion.ResumeLayout(false);
            grpDireccion.PerformLayout();
            // 
            // ttAyuda: explicación de cada combo al pasar el mouse
            // 
            ttAyuda.AutoPopDelay = 10000;
            ttAyuda.InitialDelay = 300;
            ttAyuda.ReshowDelay = 100;
            ttAyuda.SetToolTip(cmbIva, "Condición del proveedor frente al IVA.");
            ttAyuda.SetToolTip(cmbTipoTelefono, "Elegí el tipo de teléfono (celular, fijo, etc.).");
            ttAyuda.SetToolTip(cmbProvincia, "Elegí la provincia: después se cargan sus partidos.");
            ttAyuda.SetToolTip(cmbPartido, "Elegí el partido (primero elegí la provincia).");
            ttAyuda.SetToolTip(cmbLocalidad, "Elegí la localidad (primero el partido). El código postal se completa solo.");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip ttAyuda;

        private Label lblTitulo;
        private Label lblAyuda;
        private GroupBox grpDatos;
        private Label lblRazonSocial;
        private TextBox txtRazonSocial;
        private Label lblSucursal;
        private TextBox txtSucursalProveedor;
        private Label lblCuit;
        private TextBox txtCuit;
        private Label lblIva;
        private ComboBox cmbIva;
        private GroupBox grpContacto;
        private Label lblTelefono;
        private TextBox txtCelular;
        private Label lblTipoTelefono;
        private ComboBox cmbTipoTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private GroupBox grpDireccion;
        private Label lblProvincia;
        private ComboBox cmbProvincia;
        private Label lblPartido;
        private ComboBox cmbPartido;
        private Label lblLocalidad;
        private ComboBox cmbLocalidad;
        private Label lblPostal;
        private TextBox txtPostal;
        private Label lblCalle;
        private TextBox txtCalle;
        private Label lblNumero;
        private TextBox txtNumero;
        private CheckBox chkSinNumero;
        private Label lblPiso;
        private TextBox txtPiso;
        private Label lblDepartamento;
        private TextBox txtDepartamento;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Label lblContador;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
