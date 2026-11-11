namespace CapaVista
{
    partial class frmPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisos));
            gpbRoles = new GroupBox();
            lstRoles = new ListBox();
            gpbPermisos = new GroupBox();
            treePermisos = new TreeView();
            gpbDetalle = new GroupBox();
            lblEstado = new Label();
            lblDescripcion = new Label();
            lblPermisoSeleccionado = new Label();
            btnNuevoRol = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            btnSalir = new Button();
            btnEliminarRol = new Button();
            gpbRoles.SuspendLayout();
            gpbPermisos.SuspendLayout();
            gpbDetalle.SuspendLayout();
            SuspendLayout();
            // 
            // gpbRoles
            // 
            gpbRoles.Controls.Add(lstRoles);
            gpbRoles.Location = new Point(15, 15);
            gpbRoles.Name = "gpbRoles";
            gpbRoles.Size = new Size(190, 510);
            gpbRoles.TabIndex = 0;
            gpbRoles.TabStop = false;
            gpbRoles.Text = "ROLES";
            // 
            // lstRoles
            // 
            lstRoles.BorderStyle = BorderStyle.FixedSingle;
            lstRoles.FormattingEnabled = true;
            lstRoles.ItemHeight = 15;
            lstRoles.Location = new Point(10, 30);
            lstRoles.Name = "lstRoles";
            lstRoles.Size = new Size(170, 452);
            lstRoles.TabIndex = 0;
            lstRoles.SelectedIndexChanged += lstRoles_SelectedIndexChanged;
            // 
            // gpbPermisos
            // 
            gpbPermisos.Controls.Add(treePermisos);
            gpbPermisos.Location = new Point(215, 15);
            gpbPermisos.Name = "gpbPermisos";
            gpbPermisos.Size = new Size(500, 510);
            gpbPermisos.TabIndex = 1;
            gpbPermisos.TabStop = false;
            gpbPermisos.Text = "PERMISOS DEL ROL";
            // 
            // treePermisos
            // 
            treePermisos.BorderStyle = BorderStyle.FixedSingle;
            treePermisos.CheckBoxes = true;
            treePermisos.FullRowSelect = true;
            treePermisos.HideSelection = false;
            treePermisos.Location = new Point(15, 30);
            treePermisos.Name = "treePermisos";
            treePermisos.Size = new Size(470, 452);
            treePermisos.TabIndex = 0;
            // 
            // gpbDetalle
            // 
            gpbDetalle.Controls.Add(lblEstado);
            gpbDetalle.Controls.Add(lblDescripcion);
            gpbDetalle.Controls.Add(lblPermisoSeleccionado);
            gpbDetalle.Location = new Point(730, 15);
            gpbDetalle.Name = "gpbDetalle";
            gpbDetalle.Size = new Size(255, 510);
            gpbDetalle.TabIndex = 2;
            gpbDetalle.TabStop = false;
            gpbDetalle.Text = "DETALLE DEL PERMISO";
            // 
            // lblEstado
            // 
            lblEstado.Location = new Point(15, 229);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(225, 70);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Estado del permiso:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(15, 99);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(225, 110);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblPermisoSeleccionado
            // 
            lblPermisoSeleccionado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPermisoSeleccionado.Location = new Point(15, 35);
            lblPermisoSeleccionado.Name = "lblPermisoSeleccionado";
            lblPermisoSeleccionado.Size = new Size(225, 50);
            lblPermisoSeleccionado.TabIndex = 0;
            lblPermisoSeleccionado.Text = "Permiso seleccionado";
            lblPermisoSeleccionado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnNuevoRol
            // 
            btnNuevoRol.Location = new Point(15, 545);
            btnNuevoRol.Name = "btnNuevoRol";
            btnNuevoRol.Size = new Size(120, 35);
            btnNuevoRol.TabIndex = 3;
            btnNuevoRol.Text = "Nuevo Rol";
            btnNuevoRol.UseVisualStyleBackColor = true;
            btnNuevoRol.Click += btnNuevoRol_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(650, 545);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(760, 545);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(870, 545);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(115, 35);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminarRol
            // 
            btnEliminarRol.Location = new Point(153, 545);
            btnEliminarRol.Name = "btnEliminarRol";
            btnEliminarRol.Size = new Size(120, 35);
            btnEliminarRol.TabIndex = 4;
            btnEliminarRol.Text = "Eliminar Rol";
            btnEliminarRol.UseVisualStyleBackColor = true;
            btnEliminarRol.Click += btnEliminarRol_Click;
            // 
            // frmPermisos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 620);
            Controls.Add(btnEliminarRol);
            Controls.Add(btnSalir);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevoRol);
            Controls.Add(gpbDetalle);
            Controls.Add(gpbPermisos);
            Controls.Add(gpbRoles);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 620);
            Name = "frmPermisos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Roles y Permisos";
            gpbRoles.ResumeLayout(false);
            gpbPermisos.ResumeLayout(false);
            gpbDetalle.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private GroupBox gpbRoles;
        private ListBox lstRoles;

        private GroupBox gpbPermisos;
        private TreeView treePermisos;

        private GroupBox gpbDetalle;
        private Label lblPermisoSeleccionado;
        private Label lblDescripcion;
        private Label lblEstado;

        private Button btnNuevoRol;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnSalir;
        private Button btnEliminarRol;
    }
}