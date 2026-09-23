namespace CapaVista
{
    partial class frmCargaEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaEmpleados));
            label20 = new Label();
            cmbTipoTelefono = new ComboBox();
            mkdCuil = new MaskedTextBox();
            dtpFechaNacimiento = new DateTimePicker();
            cmbGenero = new ComboBox();
            label18 = new Label();
            label17 = new Label();
            txtPostal = new TextBox();
            label15 = new Label();
            txtDepartamento = new TextBox();
            txtPiso = new TextBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            txtAltura = new TextBox();
            label11 = new Label();
            cmbLocalidad = new ComboBox();
            cmbPartido = new ComboBox();
            txtCorreo = new TextBox();
            label6 = new Label();
            txtCalle = new TextBox();
            cmbProvincia = new ComboBox();
            label10 = new Label();
            txtTelefono = new TextBox();
            label9 = new Label();
            rdbMasculino = new RadioButton();
            label4 = new Label();
            rdbFemenino = new RadioButton();
            txtDNI = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label16 = new Label();
            chkActivo = new CheckBox();
            btnCrear = new Button();
            btnVolver = new Button();
            label19 = new Label();
            lstUsuarios = new ComboBox();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnActualizar = new Button();
            btnPermisos = new Button();
            tpgDatosUsuario = new TabControl();
            tpgDatosPersonales = new TabPage();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tpgDireccion = new TabPage();
            tpgLocalidad = new TabPage();
            tpgContacto = new TabPage();
            label21 = new Label();
            txtRolActual = new TextBox();
            chkHabilitarEdicion = new CheckBox();
            tpgDatosUsuario.SuspendLayout();
            tpgDatosPersonales.SuspendLayout();
            tpgDireccion.SuspendLayout();
            tpgLocalidad.SuspendLayout();
            tpgContacto.SuspendLayout();
            SuspendLayout();
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(145, 19);
            label20.Name = "label20";
            label20.Size = new Size(94, 15);
            label20.TabIndex = 39;
            label20.Text = "Tipo de Telefono";
            // 
            // cmbTipoTelefono
            // 
            cmbTipoTelefono.FormattingEnabled = true;
            cmbTipoTelefono.Location = new Point(146, 37);
            cmbTipoTelefono.Name = "cmbTipoTelefono";
            cmbTipoTelefono.Size = new Size(121, 23);
            cmbTipoTelefono.TabIndex = 38;
            // 
            // mkdCuil
            // 
            mkdCuil.Location = new Point(12, 239);
            mkdCuil.Mask = "00-00000000-0";
            mkdCuil.Name = "mkdCuil";
            mkdCuil.Size = new Size(134, 23);
            mkdCuil.TabIndex = 5;
            mkdCuil.Enter += mkdCuil_Enter;
            mkdCuil.KeyPress += mkdCuil_KeyPress;
            mkdCuil.Leave += mkdCuil_Leave;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(12, 105);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(220, 23);
            dtpFechaNacimiento.TabIndex = 4;
            // 
            // cmbGenero
            // 
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Location = new Point(12, 172);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(121, 23);
            cmbGenero.TabIndex = 7;
            cmbGenero.SelectedIndexChanged += cmbGenero_SelectedIndexChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(10, 150);
            label18.Name = "label18";
            label18.Size = new Size(45, 15);
            label18.TabIndex = 37;
            label18.Text = "Genero";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(19, 220);
            label17.Name = "label17";
            label17.Size = new Size(32, 15);
            label17.TabIndex = 36;
            label17.Text = "CUIT";
            // 
            // txtPostal
            // 
            txtPostal.Enabled = false;
            txtPostal.Location = new Point(162, 107);
            txtPostal.Name = "txtPostal";
            txtPostal.Size = new Size(69, 23);
            txtPostal.TabIndex = 10;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 103);
            label15.Name = "label15";
            label15.Size = new Size(105, 15);
            label15.TabIndex = 30;
            label15.Text = "Correo Electronico";
            // 
            // txtDepartamento
            // 
            txtDepartamento.Location = new Point(86, 223);
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.Size = new Size(83, 23);
            txtDepartamento.TabIndex = 17;
            // 
            // txtPiso
            // 
            txtPiso.Location = new Point(6, 223);
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(71, 23);
            txtPiso.TabIndex = 16;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(86, 205);
            label14.Name = "label14";
            label14.Size = new Size(83, 15);
            label14.TabIndex = 27;
            label14.Text = "Departamento";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 205);
            label13.Name = "label13";
            label13.Size = new Size(29, 15);
            label13.TabIndex = 26;
            label13.Text = "Piso";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(227, 149);
            label12.Name = "label12";
            label12.Size = new Size(39, 15);
            label12.TabIndex = 25;
            label12.Text = "Altura";
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(227, 167);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(100, 23);
            txtAltura.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(147, 89);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 23;
            label11.Text = "Cod. Postal";
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(11, 107);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(146, 23);
            cmbLocalidad.TabIndex = 13;
            cmbLocalidad.SelectedIndexChanged += cmbLocalidad_SelectedIndexChanged_1;
            // 
            // cmbPartido
            // 
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(158, 44);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(125, 23);
            cmbPartido.TabIndex = 12;
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(6, 127);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(213, 23);
            txtCorreo.TabIndex = 11;
            txtCorreo.Validating += txtCorreo_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 149);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 5;
            label6.Text = "Calle";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(6, 167);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(215, 23);
            txtCalle.TabIndex = 14;
            // 
            // cmbProvincia
            // 
            cmbProvincia.DropDownWidth = 350;
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Location = new Point(6, 44);
            cmbProvincia.MaxDropDownItems = 4;
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(146, 23);
            cmbProvincia.TabIndex = 11;
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(158, 26);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 19;
            label10.Text = "Partido";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(6, 37);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(134, 23);
            txtTelefono.TabIndex = 18;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(11, 26);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 18;
            label9.Text = "Provincia";
            // 
            // rdbMasculino
            // 
            rdbMasculino.AutoSize = true;
            rdbMasculino.Location = new Point(231, 176);
            rdbMasculino.Name = "rdbMasculino";
            rdbMasculino.Size = new Size(69, 19);
            rdbMasculino.TabIndex = 9;
            rdbMasculino.TabStop = true;
            rdbMasculino.Text = "Hombre";
            rdbMasculino.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 87);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 3;
            label4.Text = "Fecha de Nacimiento";
            // 
            // rdbFemenino
            // 
            rdbFemenino.AutoSize = true;
            rdbFemenino.Location = new Point(166, 176);
            rdbFemenino.Name = "rdbFemenino";
            rdbFemenino.Size = new Size(56, 19);
            rdbFemenino.TabIndex = 8;
            rdbFemenino.TabStop = true;
            rdbFemenino.Text = "Mujer";
            rdbFemenino.UseVisualStyleBackColor = true;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(151, 239);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(134, 23);
            txtDNI.TabIndex = 6;
            txtDNI.KeyPress += txtDNI_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 89);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 7;
            label8.Text = "Localidad";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 19);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 6;
            label7.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(151, 221);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 4;
            label5.Text = "DNI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 154);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 2;
            label3.Text = "Sexo";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(315, 40);
            label16.Name = "label16";
            label16.Size = new Size(98, 15);
            label16.TabIndex = 32;
            label16.Text = "Estado Empleado";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(315, 58);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 31;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(325, 498);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(75, 23);
            btnCrear.TabIndex = 21;
            btnCrear.Text = "GUARDAR";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(167, 498);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 19;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(28, 26);
            label19.Name = "label19";
            label19.Size = new Size(52, 15);
            label19.TabIndex = 4;
            label19.Text = "Usuarios";
            // 
            // lstUsuarios
            // 
            lstUsuarios.FormattingEnabled = true;
            lstUsuarios.Location = new Point(31, 52);
            lstUsuarios.Name = "lstUsuarios";
            lstUsuarios.Size = new Size(159, 23);
            lstUsuarios.TabIndex = 1;
            lstUsuarios.SelectedIndexChanged += lstUsuarios_SelectedIndexChanged_1;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(248, 498);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(71, 23);
            btnNuevo.TabIndex = 20;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(68, 498);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(93, 23);
            btnModificar.TabIndex = 18;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.Location = new Point(201, 47);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(57, 34);
            btnActualizar.TabIndex = 33;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnPermisos
            // 
            btnPermisos.BackColor = Color.Transparent;
            btnPermisos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPermisos.Image = (Image)resources.GetObject("btnPermisos.Image");
            btnPermisos.ImageAlign = ContentAlignment.TopCenter;
            btnPermisos.Location = new Point(405, 163);
            btnPermisos.Name = "btnPermisos";
            btnPermisos.Size = new Size(106, 102);
            btnPermisos.TabIndex = 34;
            btnPermisos.Text = "Permisos";
            btnPermisos.TextAlign = ContentAlignment.BottomCenter;
            btnPermisos.UseVisualStyleBackColor = false;
            btnPermisos.Click += btnPermisos_Click;
            // 
            // tpgDatosUsuario
            // 
            tpgDatosUsuario.Controls.Add(tpgDatosPersonales);
            tpgDatosUsuario.Controls.Add(tpgDireccion);
            tpgDatosUsuario.Controls.Add(tpgLocalidad);
            tpgDatosUsuario.Controls.Add(tpgContacto);
            tpgDatosUsuario.Location = new Point(31, 139);
            tpgDatosUsuario.Name = "tpgDatosUsuario";
            tpgDatosUsuario.SelectedIndex = 0;
            tpgDatosUsuario.Size = new Size(372, 317);
            tpgDatosUsuario.TabIndex = 35;
            // 
            // tpgDatosPersonales
            // 
            tpgDatosPersonales.Controls.Add(mkdCuil);
            tpgDatosPersonales.Controls.Add(label5);
            tpgDatosPersonales.Controls.Add(txtApellido);
            tpgDatosPersonales.Controls.Add(txtDNI);
            tpgDatosPersonales.Controls.Add(txtNombre);
            tpgDatosPersonales.Controls.Add(label17);
            tpgDatosPersonales.Controls.Add(label2);
            tpgDatosPersonales.Controls.Add(cmbGenero);
            tpgDatosPersonales.Controls.Add(label18);
            tpgDatosPersonales.Controls.Add(dtpFechaNacimiento);
            tpgDatosPersonales.Controls.Add(label1);
            tpgDatosPersonales.Controls.Add(label4);
            tpgDatosPersonales.Controls.Add(label3);
            tpgDatosPersonales.Controls.Add(rdbFemenino);
            tpgDatosPersonales.Controls.Add(rdbMasculino);
            tpgDatosPersonales.Location = new Point(4, 24);
            tpgDatosPersonales.Name = "tpgDatosPersonales";
            tpgDatosPersonales.Padding = new Padding(3);
            tpgDatosPersonales.Size = new Size(364, 289);
            tpgDatosPersonales.TabIndex = 0;
            tpgDatosPersonales.Text = "Datos Personales";
            tpgDatosPersonales.UseVisualStyleBackColor = true;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(151, 45);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(134, 23);
            txtApellido.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(11, 45);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(134, 23);
            txtNombre.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(151, 27);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // tpgDireccion
            // 
            tpgDireccion.Controls.Add(txtCalle);
            tpgDireccion.Controls.Add(label6);
            tpgDireccion.Controls.Add(txtAltura);
            tpgDireccion.Controls.Add(label12);
            tpgDireccion.Controls.Add(txtPiso);
            tpgDireccion.Controls.Add(label13);
            tpgDireccion.Controls.Add(label14);
            tpgDireccion.Controls.Add(txtDepartamento);
            tpgDireccion.Location = new Point(4, 24);
            tpgDireccion.Name = "tpgDireccion";
            tpgDireccion.Padding = new Padding(3);
            tpgDireccion.Size = new Size(364, 289);
            tpgDireccion.TabIndex = 1;
            tpgDireccion.Text = "Dirección";
            tpgDireccion.UseVisualStyleBackColor = true;
            // 
            // tpgLocalidad
            // 
            tpgLocalidad.Controls.Add(cmbProvincia);
            tpgLocalidad.Controls.Add(label9);
            tpgLocalidad.Controls.Add(label10);
            tpgLocalidad.Controls.Add(cmbPartido);
            tpgLocalidad.Controls.Add(cmbLocalidad);
            tpgLocalidad.Controls.Add(label8);
            tpgLocalidad.Controls.Add(label11);
            tpgLocalidad.Controls.Add(txtPostal);
            tpgLocalidad.Location = new Point(4, 24);
            tpgLocalidad.Name = "tpgLocalidad";
            tpgLocalidad.Padding = new Padding(3);
            tpgLocalidad.Size = new Size(364, 289);
            tpgLocalidad.TabIndex = 2;
            tpgLocalidad.Text = "Localidad";
            tpgLocalidad.UseVisualStyleBackColor = true;
            // 
            // tpgContacto
            // 
            tpgContacto.Controls.Add(txtTelefono);
            tpgContacto.Controls.Add(label7);
            tpgContacto.Controls.Add(label20);
            tpgContacto.Controls.Add(txtCorreo);
            tpgContacto.Controls.Add(label15);
            tpgContacto.Controls.Add(cmbTipoTelefono);
            tpgContacto.Location = new Point(4, 24);
            tpgContacto.Name = "tpgContacto";
            tpgContacto.Padding = new Padding(3);
            tpgContacto.Size = new Size(364, 289);
            tpgContacto.TabIndex = 3;
            tpgContacto.Text = "Contacto";
            tpgContacto.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(405, 276);
            label21.Name = "label21";
            label21.Size = new Size(64, 15);
            label21.TabIndex = 36;
            label21.Text = "Rol Actual:";
            // 
            // txtRolActual
            // 
            txtRolActual.Enabled = false;
            txtRolActual.Location = new Point(405, 294);
            txtRolActual.Name = "txtRolActual";
            txtRolActual.ReadOnly = true;
            txtRolActual.Size = new Size(100, 23);
            txtRolActual.TabIndex = 37;
            txtRolActual.TabStop = false;
            // 
            // chkHabilitarEdicion
            // 
            chkHabilitarEdicion.AutoSize = true;
            chkHabilitarEdicion.Location = new Point(31, 103);
            chkHabilitarEdicion.Name = "chkHabilitarEdicion";
            chkHabilitarEdicion.Size = new Size(113, 19);
            chkHabilitarEdicion.TabIndex = 38;
            chkHabilitarEdicion.Text = "Habilitar Edición";
            chkHabilitarEdicion.UseVisualStyleBackColor = true;
            chkHabilitarEdicion.CheckedChanged += chkHabilitarEdicion_CheckedChanged;
            // 
            // frmCargaEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 550);
            Controls.Add(chkHabilitarEdicion);
            Controls.Add(txtRolActual);
            Controls.Add(label21);
            Controls.Add(tpgDatosUsuario);
            Controls.Add(btnPermisos);
            Controls.Add(btnActualizar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lstUsuarios);
            Controls.Add(label19);
            Controls.Add(btnCrear);
            Controls.Add(btnVolver);
            Controls.Add(label16);
            Controls.Add(chkActivo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCargaEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carga de Empleados";
            Load += frmCargaEmpleados_Load;
            tpgDatosUsuario.ResumeLayout(false);
            tpgDatosPersonales.ResumeLayout(false);
            tpgDatosPersonales.PerformLayout();
            tpgDireccion.ResumeLayout(false);
            tpgDireccion.PerformLayout();
            tpgLocalidad.ResumeLayout(false);
            tpgLocalidad.PerformLayout();
            tpgContacto.ResumeLayout(false);
            tpgContacto.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtCorreo;
        private TextBox txtDNI;
        private Label label8;
        private TextBox txtTelefono;
        private TextBox txtCalle;
        private TextBox txtAltura;
        private RadioButton rdbMasculino;
        private RadioButton rdbFemenino;
        private Label label11;
        private ComboBox cmbLocalidad;
        private ComboBox cmbPartido;
        private Label label10;
        private Label label9;
        private Label label16;
        private CheckBox chkActivo;
        private Label label15;
        private TextBox txtDepartamento;
        private TextBox txtPiso;
        private Label label14;
        private Label label13;
        private Label label12;
        internal ComboBox cmbProvincia;
        private TextBox txtPostal;
        private Button btnCrear;
        private Label label17;
        private Button btnVolver;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cmbGenero;
        private Label label18;
        private Label label19;
        private ComboBox lstUsuarios;
        private Button btnNuevo;
        private MaskedTextBox mkdCuil;
        private Button btnModificar;
        private Button btnActualizar;
        private Label label20;
        private ComboBox cmbTipoTelefono;
        private Button btnPermisos;
        private TabControl tpgDatosUsuario;
        private TabPage tpgDatosPersonales;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label2;
        private Label label1;
        private TabPage tpgDireccion;
        private TabPage tpgLocalidad;
        private TabPage tpgContacto;
        private Label label21;
        private TextBox txtRolActual;
        private CheckBox chkHabilitarEdicion;
    }
}