namespace CapaVista
{
    partial class frmBuscarArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarArticulo));
            label1 = new Label();
            chkDiscontinuo = new CheckBox();
            txtBuscarArticulo = new TextBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(177, 15);
            label1.TabIndex = 0;
            label1.Text = "Buscar por código o descripción";
            // 
            // chkDiscontinuo
            // 
            chkDiscontinuo.AutoSize = true;
            chkDiscontinuo.Location = new Point(430, 18);
            chkDiscontinuo.Name = "chkDiscontinuo";
            chkDiscontinuo.Size = new Size(131, 19);
            chkDiscontinuo.TabIndex = 1;
            chkDiscontinuo.Text = "Ocultar discontinuo";
            chkDiscontinuo.UseVisualStyleBackColor = true;
            // 
            // txtBuscarArticulo
            // 
            txtBuscarArticulo.Location = new Point(12, 40);
            txtBuscarArticulo.Name = "txtBuscarArticulo";
            txtBuscarArticulo.Size = new Size(278, 23);
            txtBuscarArticulo.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(15, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(571, 255);
            dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.HeaderText = "Código";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Descripción";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Rubro";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Precio";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Stock";
            Column5.Name = "Column5";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(430, 381);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(511, 382);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 21);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(311, 40);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // frmBuscarArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 450);
            Controls.Add(btnBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(dataGridView1);
            Controls.Add(txtBuscarArticulo);
            Controls.Add(chkDiscontinuo);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmBuscarArticulo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar Articulo";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox chkDiscontinuo;
        private TextBox txtBuscarArticulo;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnBuscar;
    }
}