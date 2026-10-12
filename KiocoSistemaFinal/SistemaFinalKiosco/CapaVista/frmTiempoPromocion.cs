using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmTiempoPromocion : Form
    {
        public bool EsRecurrente { get; private set; }
        public DateTime FechaInicioSeleccionada { get; private set; }
        public DateTime FechaFinSeleccionada { get; private set; }
        public TimeSpan HoraInicioSeleccionada { get; private set; }
        public TimeSpan HoraFinSeleccionada { get; private set; }
        public List<DayOfWeek> DiasSeleccionados { get; private set; } = new List<DayOfWeek>();
        public frmTiempoPromocion()
        {
            InitializeComponent();

            this.Load += frmTiempoPromocion_Load;
            rdbPorPeriodo.CheckedChanged += rdbPorPeriodo_CheckedChanged;
            rdbRecurrente.CheckedChanged += rdbRecurrente_CheckedChanged;
            btnAceptar.Click += btnAceptar_Click;
        }

        #region Metodos
        private void frmTiempoPromocion_Load(object sender, EventArgs e)
        {
            rdbPorPeriodo.Checked = true;
            ActualizarControlesVigencia();
        }
        private void rdbPorPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarControlesVigencia();
        }
        private void rdbRecurrente_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarControlesVigencia();
        }
        private void ActualizarControlesVigencia()
        {
            bool porPeriodo = rdbPorPeriodo.Checked;

            grpPeriodo.Enabled = porPeriodo;
            grpDiasSemana.Enabled = !porPeriodo;
        }


        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtpHoraFin.Value.TimeOfDay == dtpHoraInicio.Value.TimeOfDay)
            {
                MessageBox.Show("La hora de fin no puede ser igual a la hora de inicio.", "Horario inválido",
                    MessageBoxButtons.OK,  MessageBoxIcon.Warning);
                return;
            }

            if (rdbPorPeriodo.Checked)
            {
                if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
                {
                    MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Fechas inválidas",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            else
            {
                bool hayDiaSeleccionado = chkLunes.Checked || chkMartes.Checked ||chkMiercoles.Checked || chkJueves.Checked || chkViernes.Checked || chkSabado.Checked || chkDomingo.Checked;

                if (!hayDiaSeleccionado)
                {
                    MessageBox.Show("Seleccioná al menos un día de la semana.", "Falta seleccionar días",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            EsRecurrente = rdbRecurrente.Checked;

            if (!EsRecurrente)
            {
                DiasSeleccionados.Clear();
            }

            FechaInicioSeleccionada = dtpFechaInicio.Value.Date;
            FechaFinSeleccionada = dtpFechaFin.Value.Date;

            HoraInicioSeleccionada = dtpHoraInicio.Value.TimeOfDay;
            HoraFinSeleccionada = dtpHoraFin.Value.TimeOfDay;

            DiasSeleccionados.Clear();

            if (chkLunes.Checked)
                DiasSeleccionados.Add(DayOfWeek.Monday);

            if (chkMartes.Checked)
                DiasSeleccionados.Add(DayOfWeek.Tuesday);

            if (chkMiercoles.Checked)
                DiasSeleccionados.Add(DayOfWeek.Wednesday);

            if (chkJueves.Checked)
                DiasSeleccionados.Add(DayOfWeek.Thursday);

            if (chkViernes.Checked)
                DiasSeleccionados.Add(DayOfWeek.Friday);

            if (chkSabado.Checked)
                DiasSeleccionados.Add(DayOfWeek.Saturday);

            if (chkDomingo.Checked)
                DiasSeleccionados.Add(DayOfWeek.Sunday);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion



    }
}
