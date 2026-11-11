namespace CapaVista
{
    partial class frmTiempoPromocion
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpTipoVigencia;
        private System.Windows.Forms.RadioButton rdbPorPeriodo;
        private System.Windows.Forms.RadioButton rdbRecurrente;
        private System.Windows.Forms.GroupBox grpPeriodo;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.GroupBox grpDiasSemana;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.CheckBox chkDomingo;
        private System.Windows.Forms.GroupBox grpHorario;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiempoPromocion));
            grpTipoVigencia = new GroupBox();
            rdbPorPeriodo = new RadioButton();
            rdbRecurrente = new RadioButton();
            grpPeriodo = new GroupBox();
            lblFechaInicio = new Label();
            lblFechaFin = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            grpDiasSemana = new GroupBox();
            chkTodaSemana = new CheckBox();
            chkLunes = new CheckBox();
            chkMartes = new CheckBox();
            chkMiercoles = new CheckBox();
            chkJueves = new CheckBox();
            chkViernes = new CheckBox();
            chkSabado = new CheckBox();
            chkDomingo = new CheckBox();
            grpHorario = new GroupBox();
            lblHoraInicio = new Label();
            lblHoraFin = new Label();
            dtpHoraInicio = new DateTimePicker();
            dtpHoraFin = new DateTimePicker();
            btnAceptar = new Button();
            btnCancelar = new Button();
            grpTipoVigencia.SuspendLayout();
            grpPeriodo.SuspendLayout();
            grpDiasSemana.SuspendLayout();
            grpHorario.SuspendLayout();
            SuspendLayout();
            // 
            // grpTipoVigencia
            // 
            grpTipoVigencia.Controls.Add(rdbPorPeriodo);
            grpTipoVigencia.Controls.Add(rdbRecurrente);
            grpTipoVigencia.Location = new Point(15, 12);
            grpTipoVigencia.Name = "grpTipoVigencia";
            grpTipoVigencia.Size = new Size(560, 65);
            grpTipoVigencia.TabIndex = 0;
            grpTipoVigencia.TabStop = false;
            grpTipoVigencia.Text = "Tipo de vigencia";
            // 
            // rdbPorPeriodo
            // 
            rdbPorPeriodo.AutoSize = true;
            rdbPorPeriodo.Checked = true;
            rdbPorPeriodo.Location = new Point(18, 27);
            rdbPorPeriodo.Name = "rdbPorPeriodo";
            rdbPorPeriodo.Size = new Size(87, 19);
            rdbPorPeriodo.TabIndex = 0;
            rdbPorPeriodo.TabStop = true;
            rdbPorPeriodo.Text = "Por período";
            // 
            // rdbRecurrente
            // 
            rdbRecurrente.AutoSize = true;
            rdbRecurrente.Location = new Point(180, 27);
            rdbRecurrente.Name = "rdbRecurrente";
            rdbRecurrente.Size = new Size(129, 19);
            rdbRecurrente.TabIndex = 1;
            rdbRecurrente.Text = "Recurrente semanal";
            // 
            // grpPeriodo
            // 
            grpPeriodo.Controls.Add(lblFechaInicio);
            grpPeriodo.Controls.Add(lblFechaFin);
            grpPeriodo.Controls.Add(dtpFechaInicio);
            grpPeriodo.Controls.Add(dtpFechaFin);
            grpPeriodo.Location = new Point(15, 85);
            grpPeriodo.Name = "grpPeriodo";
            grpPeriodo.Size = new Size(560, 105);
            grpPeriodo.TabIndex = 1;
            grpPeriodo.TabStop = false;
            grpPeriodo.Text = "Vigencia por fechas";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(15, 30);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(89, 15);
            lblFechaInicio.TabIndex = 0;
            lblFechaInicio.Text = "Fecha de inicio:";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(15, 65);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(74, 15);
            lblFechaFin.TabIndex = 2;
            lblFechaFin.Text = "Fecha de fin:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(130, 26);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(150, 23);
            dtpFechaInicio.TabIndex = 1;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(130, 61);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(150, 23);
            dtpFechaFin.TabIndex = 3;
            // 
            // grpDiasSemana
            // 
            grpDiasSemana.Controls.Add(chkTodaSemana);
            grpDiasSemana.Controls.Add(chkLunes);
            grpDiasSemana.Controls.Add(chkMartes);
            grpDiasSemana.Controls.Add(chkMiercoles);
            grpDiasSemana.Controls.Add(chkJueves);
            grpDiasSemana.Controls.Add(chkViernes);
            grpDiasSemana.Controls.Add(chkSabado);
            grpDiasSemana.Controls.Add(chkDomingo);
            grpDiasSemana.Location = new Point(15, 200);
            grpDiasSemana.Name = "grpDiasSemana";
            grpDiasSemana.Size = new Size(560, 95);
            grpDiasSemana.TabIndex = 2;
            grpDiasSemana.TabStop = false;
            grpDiasSemana.Text = "Días de la semana (para vigencia recurrente)";
            // 
            // chkTodaSemana
            // 
            chkTodaSemana.AutoSize = true;
            chkTodaSemana.Location = new Point(206, 60);
            chkTodaSemana.Name = "chkTodaSemana";
            chkTodaSemana.Size = new Size(172, 19);
            chkTodaSemana.TabIndex = 7;
            chkTodaSemana.Text = "Seleccionar toda la semana.";
            chkTodaSemana.UseVisualStyleBackColor = true;
            chkTodaSemana.CheckedChanged += chkTodaSemana_CheckedChanged;
            // 
            // chkLunes
            // 
            chkLunes.AutoSize = true;
            chkLunes.Location = new Point(15, 30);
            chkLunes.Name = "chkLunes";
            chkLunes.Size = new Size(57, 19);
            chkLunes.TabIndex = 0;
            chkLunes.Text = "Lunes";
            // 
            // chkMartes
            // 
            chkMartes.AutoSize = true;
            chkMartes.Location = new Point(90, 30);
            chkMartes.Name = "chkMartes";
            chkMartes.Size = new Size(62, 19);
            chkMartes.TabIndex = 1;
            chkMartes.Text = "Martes";
            // 
            // chkMiercoles
            // 
            chkMiercoles.AutoSize = true;
            chkMiercoles.Location = new Point(175, 30);
            chkMiercoles.Name = "chkMiercoles";
            chkMiercoles.Size = new Size(77, 19);
            chkMiercoles.TabIndex = 2;
            chkMiercoles.Text = "Miércoles";
            // 
            // chkJueves
            // 
            chkJueves.AutoSize = true;
            chkJueves.Location = new Point(275, 30);
            chkJueves.Name = "chkJueves";
            chkJueves.Size = new Size(60, 19);
            chkJueves.TabIndex = 3;
            chkJueves.Text = "Jueves";
            // 
            // chkViernes
            // 
            chkViernes.AutoSize = true;
            chkViernes.Location = new Point(365, 30);
            chkViernes.Name = "chkViernes";
            chkViernes.Size = new Size(64, 19);
            chkViernes.TabIndex = 4;
            chkViernes.Text = "Viernes";
            // 
            // chkSabado
            // 
            chkSabado.AutoSize = true;
            chkSabado.Location = new Point(15, 60);
            chkSabado.Name = "chkSabado";
            chkSabado.Size = new Size(65, 19);
            chkSabado.TabIndex = 5;
            chkSabado.Text = "Sábado";
            // 
            // chkDomingo
            // 
            chkDomingo.AutoSize = true;
            chkDomingo.Location = new Point(110, 60);
            chkDomingo.Name = "chkDomingo";
            chkDomingo.Size = new Size(76, 19);
            chkDomingo.TabIndex = 6;
            chkDomingo.Text = "Domingo";
            // 
            // grpHorario
            // 
            grpHorario.Controls.Add(lblHoraInicio);
            grpHorario.Controls.Add(lblHoraFin);
            grpHorario.Controls.Add(dtpHoraInicio);
            grpHorario.Controls.Add(dtpHoraFin);
            grpHorario.Location = new Point(15, 305);
            grpHorario.Name = "grpHorario";
            grpHorario.Size = new Size(560, 85);
            grpHorario.TabIndex = 3;
            grpHorario.TabStop = false;
            grpHorario.Text = "Horario de aplicación";
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(15, 35);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(42, 15);
            lblHoraInicio.TabIndex = 0;
            lblHoraInicio.Text = "Desde:";
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Location = new Point(220, 35);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(40, 15);
            lblHoraFin.TabIndex = 2;
            lblHoraFin.Text = "Hasta:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.Location = new Point(75, 30);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(100, 23);
            dtpHoraInicio.TabIndex = 1;
            dtpHoraInicio.Value = new DateTime(2026, 10, 10, 10, 0, 0, 0);
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.Location = new Point(275, 30);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(100, 23);
            dtpHoraFin.TabIndex = 3;
            dtpHoraFin.Value = new DateTime(2026, 10, 10, 18, 0, 0, 0);
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(345, 415);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(105, 32);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(460, 415);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 32);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmTiempoPromocion
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(590, 475);
            Controls.Add(grpTipoVigencia);
            Controls.Add(grpPeriodo);
            Controls.Add(grpDiasSemana);
            Controls.Add(grpHorario);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmTiempoPromocion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configurar fechas y horarios";
            grpTipoVigencia.ResumeLayout(false);
            grpTipoVigencia.PerformLayout();
            grpPeriodo.ResumeLayout(false);
            grpPeriodo.PerformLayout();
            grpDiasSemana.ResumeLayout(false);
            grpDiasSemana.PerformLayout();
            grpHorario.ResumeLayout(false);
            grpHorario.PerformLayout();
            ResumeLayout(false);
        }
        private CheckBox chkTodaSemana;
    }
}
