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
            TreeNode treeNode1 = new TreeNode("Archivo");
            TreeNode treeNode2 = new TreeNode("Admistrador de Articulos");
            TreeNode treeNode3 = new TreeNode("Administrador de Rubro");
            TreeNode treeNode4 = new TreeNode("Reposición Rapida de Stock");
            TreeNode treeNode5 = new TreeNode("Importar Articulos desde Excel");
            TreeNode treeNode6 = new TreeNode("Exportar Articulos desde Excel");
            TreeNode treeNode7 = new TreeNode("Articulo", new TreeNode[] { treeNode2, treeNode3, treeNode4, treeNode5, treeNode6 });
            TreeNode treeNode8 = new TreeNode("Administrador de Ventas");
            TreeNode treeNode9 = new TreeNode("Nota de Credito");
            TreeNode treeNode10 = new TreeNode("Presupuesto");
            TreeNode treeNode11 = new TreeNode("Ventas", new TreeNode[] { treeNode8, treeNode9, treeNode10 });
            TreeNode treeNode12 = new TreeNode("Administrador de Compras");
            TreeNode treeNode13 = new TreeNode("Compras", new TreeNode[] { treeNode12 });
            TreeNode treeNode14 = new TreeNode("Administrador de Proveedores");
            TreeNode treeNode15 = new TreeNode("Proveedor", new TreeNode[] { treeNode14 });
            TreeNode treeNode16 = new TreeNode("Catalogo");
            TreeNode treeNode17 = new TreeNode("Informes");
            TreeNode treeNode18 = new TreeNode("Herramientas");
            TreeNode treeNode19 = new TreeNode("Caja");
            TreeNode treeNode20 = new TreeNode("Ayuda");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaEmpleados));
            groupBox1 = new GroupBox();
            label20 = new Label();
            cmbTipoTelefono = new ComboBox();
            mkdCuil = new MaskedTextBox();
            dtpFechaNacimiento = new DateTimePicker();
            cmbGenero = new ComboBox();
            label18 = new Label();
            gpbPermisos = new GroupBox();
            treeView1 = new TreeView();
            label17 = new Label();
            Rol = new Label();
            cmbRol = new ComboBox();
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
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label16 = new Label();
            chkActivo = new CheckBox();
            btnCrear = new Button();
            btnVolver = new Button();
            label19 = new Label();
            lstUsuarios = new ComboBox();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnActualizar = new Button();
            btneliminar = new Button();
            groupBox1.SuspendLayout();
            gpbPermisos.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(cmbTipoTelefono);
            groupBox1.Controls.Add(mkdCuil);
            groupBox1.Controls.Add(dtpFechaNacimiento);
            groupBox1.Controls.Add(cmbGenero);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(gpbPermisos);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(Rol);
            groupBox1.Controls.Add(cmbRol);
            groupBox1.Controls.Add(txtPostal);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(txtDepartamento);
            groupBox1.Controls.Add(txtPiso);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtAltura);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cmbLocalidad);
            groupBox1.Controls.Add(cmbPartido);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtCalle);
            groupBox1.Controls.Add(cmbProvincia);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(rdbMasculino);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(rdbFemenino);
            groupBox1.Controls.Add(txtDNI);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(28, 98);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(713, 413);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Empleado";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(146, 287);
            label20.Name = "label20";
            label20.Size = new Size(94, 15);
            label20.TabIndex = 39;
            label20.Text = "Tipo de Telefono";
            // 
            // cmbTipoTelefono
            // 
            cmbTipoTelefono.FormattingEnabled = true;
            cmbTipoTelefono.Location = new Point(147, 305);
            cmbTipoTelefono.Name = "cmbTipoTelefono";
            cmbTipoTelefono.Size = new Size(121, 23);
            cmbTipoTelefono.TabIndex = 38;
            // 
            // mkdCuil
            // 
            mkdCuil.Location = new Point(7, 98);
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
            dtpFechaNacimiento.Location = new Point(290, 43);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(220, 23);
            dtpFechaNacimiento.TabIndex = 4;
            // 
            // cmbGenero
            // 
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Location = new Point(9, 158);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(121, 23);
            cmbGenero.TabIndex = 7;
            cmbGenero.SelectedIndexChanged += cmbGenero_SelectedIndexChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(7, 136);
            label18.Name = "label18";
            label18.Size = new Size(45, 15);
            label18.TabIndex = 37;
            label18.Text = "Genero";
            // 
            // gpbPermisos
            // 
            gpbPermisos.Controls.Add(treeView1);
            gpbPermisos.Location = new Point(528, 79);
            gpbPermisos.Name = "gpbPermisos";
            gpbPermisos.Size = new Size(185, 205);
            gpbPermisos.TabIndex = 3;
            gpbPermisos.TabStop = false;
            gpbPermisos.Text = "Permisos";
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(3, 19);
            treeView1.Name = "treeView1";
            treeNode1.Name = "Nodo0";
            treeNode1.Text = "Archivo";
            treeNode2.Name = "Nodo2";
            treeNode2.Text = "Admistrador de Articulos";
            treeNode3.Name = "Nodo3";
            treeNode3.Text = "Administrador de Rubro";
            treeNode4.Name = "Nodo4";
            treeNode4.Text = "Reposición Rapida de Stock";
            treeNode5.Name = "Nodo5";
            treeNode5.Text = "Importar Articulos desde Excel";
            treeNode6.Name = "Nodo6";
            treeNode6.Text = "Exportar Articulos desde Excel";
            treeNode7.Name = "Nodo1";
            treeNode7.Text = "Articulo";
            treeNode8.Name = "Nodo8";
            treeNode8.Text = "Administrador de Ventas";
            treeNode9.Name = "Nodo9";
            treeNode9.Text = "Nota de Credito";
            treeNode10.Name = "Nodo10";
            treeNode10.Text = "Presupuesto";
            treeNode11.Name = "Nodo7";
            treeNode11.Text = "Ventas";
            treeNode12.Name = "Nodo12";
            treeNode12.Text = "Administrador de Compras";
            treeNode13.Name = "Nodo11";
            treeNode13.Text = "Compras";
            treeNode14.Name = "Nodo14";
            treeNode14.Text = "Administrador de Proveedores";
            treeNode15.Name = "Nodo13";
            treeNode15.Text = "Proveedor";
            treeNode16.Checked = true;
            treeNode16.Name = "Nodo15";
            treeNode16.Text = "Catalogo";
            treeNode17.Name = "Nodo16";
            treeNode17.Text = "Informes";
            treeNode18.Name = "Nodo17";
            treeNode18.Text = "Herramientas";
            treeNode19.Name = "Nodo18";
            treeNode19.Text = "Caja";
            treeNode20.Name = "Nodo19";
            treeNode20.Text = "Ayuda";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode7, treeNode11, treeNode13, treeNode15, treeNode16, treeNode17, treeNode18, treeNode19, treeNode20 });
            treeView1.Size = new Size(179, 183);
            treeView1.TabIndex = 24;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(14, 79);
            label17.Name = "label17";
            label17.Size = new Size(32, 15);
            label17.TabIndex = 36;
            label17.Text = "CUIT";
            // 
            // Rol
            // 
            Rol.AutoSize = true;
            Rol.Location = new Point(554, 25);
            Rol.Name = "Rol";
            Rol.Size = new Size(24, 15);
            Rol.TabIndex = 34;
            Rol.Text = "Rol";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(554, 43);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(121, 23);
            cmbRol.TabIndex = 19;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged_1;
            // 
            // txtPostal
            // 
            txtPostal.Enabled = false;
            txtPostal.Location = new Point(441, 207);
            txtPostal.Name = "txtPostal";
            txtPostal.Size = new Size(69, 23);
            txtPostal.TabIndex = 10;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(10, 335);
            label15.Name = "label15";
            label15.Size = new Size(105, 15);
            label15.TabIndex = 30;
            label15.Text = "Correo Electronico";
            // 
            // txtDepartamento
            // 
            txtDepartamento.Location = new Point(414, 261);
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.Size = new Size(83, 23);
            txtDepartamento.TabIndex = 17;
            // 
            // txtPiso
            // 
            txtPiso.Location = new Point(334, 261);
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(71, 23);
            txtPiso.TabIndex = 16;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(414, 243);
            label14.Name = "label14";
            label14.Size = new Size(83, 15);
            label14.TabIndex = 27;
            label14.Text = "Departamento";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(343, 243);
            label13.Name = "label13";
            label13.Size = new Size(29, 15);
            label13.TabIndex = 26;
            label13.Text = "Piso";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(228, 243);
            label12.Name = "label12";
            label12.Size = new Size(39, 15);
            label12.TabIndex = 25;
            label12.Text = "Altura";
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(228, 261);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(100, 23);
            txtAltura.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(426, 189);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 23;
            label11.Text = "Cod. Postal";
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(290, 207);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(146, 23);
            cmbLocalidad.TabIndex = 13;
            cmbLocalidad.SelectedIndexChanged += cmbLocalidad_SelectedIndexChanged_1;
            // 
            // cmbPartido
            // 
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(159, 207);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(125, 23);
            cmbPartido.TabIndex = 12;
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(9, 359);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(213, 23);
            txtCorreo.TabIndex = 11;
            txtCorreo.Validating += txtCorreo_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 243);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 5;
            label6.Text = "Calle";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(7, 261);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(215, 23);
            txtCalle.TabIndex = 14;
            // 
            // cmbProvincia
            // 
            cmbProvincia.DropDownWidth = 350;
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Location = new Point(7, 207);
            cmbProvincia.MaxDropDownItems = 4;
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(146, 23);
            cmbProvincia.TabIndex = 11;
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(159, 189);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 19;
            label10.Text = "Partido";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(7, 305);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(134, 23);
            txtTelefono.TabIndex = 18;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 189);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 18;
            label9.Text = "Provincia";
            // 
            // rdbMasculino
            // 
            rdbMasculino.AutoSize = true;
            rdbMasculino.Location = new Point(228, 162);
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
            label4.Location = new Point(290, 25);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 3;
            label4.Text = "Fecha de Nacimiento";
            // 
            // rdbFemenino
            // 
            rdbFemenino.AutoSize = true;
            rdbFemenino.Location = new Point(163, 162);
            rdbFemenino.Name = "rdbFemenino";
            rdbFemenino.Size = new Size(56, 19);
            rdbFemenino.TabIndex = 8;
            rdbFemenino.TabStop = true;
            rdbFemenino.Text = "Mujer";
            rdbFemenino.UseVisualStyleBackColor = true;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(146, 98);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(134, 23);
            txtDNI.TabIndex = 6;
            txtDNI.KeyPress += txtDNI_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(146, 43);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(134, 23);
            txtApellido.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(6, 43);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(134, 23);
            txtNombre.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(286, 189);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 7;
            label8.Text = "Localidad";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 287);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 6;
            label7.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(146, 80);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 4;
            label5.Text = "DNI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 140);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 2;
            label3.Text = "Sexo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 25);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 25);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(582, 26);
            label16.Name = "label16";
            label16.Size = new Size(98, 15);
            label16.TabIndex = 32;
            label16.Text = "Estado Empleado";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(582, 56);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 31;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(628, 609);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(75, 23);
            btnCrear.TabIndex = 21;
            btnCrear.Text = "GUARDAR";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(470, 609);
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
            btnNuevo.Location = new Point(551, 609);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(71, 23);
            btnNuevo.TabIndex = 20;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(371, 609);
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
            // btneliminar
            // 
            btneliminar.Location = new Point(72, 546);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(75, 23);
            btneliminar.TabIndex = 34;
            btneliminar.Text = "button1";
            btneliminar.UseVisualStyleBackColor = true;
            // 
            // frmCargaEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 644);
            Controls.Add(btneliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lstUsuarios);
            Controls.Add(label19);
            Controls.Add(btnCrear);
            Controls.Add(btnVolver);
            Controls.Add(groupBox1);
            Controls.Add(label16);
            Controls.Add(chkActivo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCargaEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carga de Empleados";
            Load += frmCargaEmpleados_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gpbPermisos.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtCorreo;
        private TextBox txtDNI;
        private TextBox txtApellido;
        private TextBox txtNombre;
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
        private Label Rol;
        private ComboBox cmbRol;
        private Button btnVolver;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cmbGenero;
        private Label label18;
        private TreeView treeView1;
        private GroupBox gpbPermisos;
        private Label label19;
        private ComboBox lstUsuarios;
        private Button btnNuevo;
        private MaskedTextBox mkdCuil;
        private Button btnModificar;
        private Button btnActualizar;
        private Label label20;
        private ComboBox cmbTipoTelefono;
        private Button btneliminar;
    }
}