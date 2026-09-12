namespace CapaVista
{
    partial class frmCambioProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioProveedor));
            label1 = new Label();
            txtDatosProveedor = new TextBox();
            dataGridView1 = new DataGridView();
            clnNumProveedor = new DataGridViewTextBoxColumn();
            clnRazonSacial = new DataGridViewTextBoxColumn();
            clnCuit = new DataGridViewTextBoxColumn();
            clnCondicionIva = new DataGridViewTextBoxColumn();
            clnTelefono = new DataGridViewTextBoxColumn();
            clnDomicilio = new DataGridViewTextBoxColumn();
            clnLocalidad = new DataGridViewTextBoxColumn();
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 20);
            label1.Name = "label1";
            label1.Size = new Size(178, 15);
            label1.TabIndex = 0;
            label1.Text = "Buscar por Razón Social por Cuit";
            // 
            // txtDatosProveedor
            // 
            txtDatosProveedor.Location = new Point(3, 38);
            txtDatosProveedor.Name = "txtDatosProveedor";
            txtDatosProveedor.Size = new Size(567, 23);
            txtDatosProveedor.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clnNumProveedor, clnRazonSacial, clnCuit, clnCondicionIva, clnTelefono, clnDomicilio, clnLocalidad });
            dataGridView1.Location = new Point(3, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(727, 289);
            dataGridView1.TabIndex = 2;
            // 
            // clnNumProveedor
            // 
            clnNumProveedor.HeaderText = "Nro. Proveedor";
            clnNumProveedor.Name = "clnNumProveedor";
            // 
            // clnRazonSacial
            // 
            clnRazonSacial.HeaderText = "Razón Social";
            clnRazonSacial.Name = "clnRazonSacial";
            // 
            // clnCuit
            // 
            clnCuit.HeaderText = "CUIT";
            clnCuit.Name = "clnCuit";
            // 
            // clnCondicionIva
            // 
            clnCondicionIva.HeaderText = "Condición IVA";
            clnCondicionIva.Name = "clnCondicionIva";
            // 
            // clnTelefono
            // 
            clnTelefono.HeaderText = "Telefono";
            clnTelefono.Name = "clnTelefono";
            // 
            // clnDomicilio
            // 
            clnDomicilio.HeaderText = "Domicilio";
            clnDomicilio.Name = "clnDomicilio";
            // 
            // clnLocalidad
            // 
            clnLocalidad.HeaderText = "Localidad";
            clnLocalidad.Name = "clnLocalidad";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(557, 375);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(655, 375);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmCambioProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 410);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(dataGridView1);
            Controls.Add(txtDatosProveedor);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmCambioProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambio de Proveedor";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDatosProveedor;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn clnNumProveedor;
        private DataGridViewTextBoxColumn clnRazonSacial;
        private DataGridViewTextBoxColumn clnCuit;
        private DataGridViewTextBoxColumn clnCondicionIva;
        private DataGridViewTextBoxColumn clnTelefono;
        private DataGridViewTextBoxColumn clnDomicilio;
        private DataGridViewTextBoxColumn clnLocalidad;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}