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
        private bool actualizandoControles = false;

        public bool EsRecurrente { get; private set; }
        public DateTime FechaInicioSeleccionada { get; private set; }
        public DateTime FechaFinSeleccionada { get; private set; }
        public TimeSpan HoraInicioSeleccionada { get; private set; }
        public TimeSpan HoraFinSeleccionada { get; private set; }
        public List<DayOfWeek> DiasSeleccionados { get; private set; } = new List<DayOfWeek>();
        public frmTiempoPromocion()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.Load += frmTiempoPromocion_Load;

            rdbPorPeriodo.CheckedChanged += rdbPorPeriodo_CheckedChanged;
            rdbRecurrente.CheckedChanged += rdbRecurrente_CheckedChanged;

            dtpFechaInicio.ValueChanged += dtpFechaInicio_ValueChanged;
            dtpFechaFin.ValueChanged += dtpFechaFin_ValueChanged;

            dtpHoraInicio.ValueChanged += dtpHoraInicio_ValueChanged;
            dtpHoraFin.ValueChanged += dtpHoraFin_ValueChanged;
        }


        #region Metodos

        private void frmTiempoPromocion_Load(object sender, EventArgs e)
        {
            DateTime ahora = DateTime.Now;
            DateTime hoy = ahora.Date;

            dtpFechaInicio.MinDate = hoy;
            dtpFechaInicio.Value = hoy;

            dtpFechaFin.MinDate = hoy;
            dtpFechaFin.Value = hoy;

            dtpHoraInicio.Value = ahora;
            dtpHoraFin.Value = ahora.AddHours(1);

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
        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value.Date;

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                dtpFechaFin.Value = dtpFechaInicio.Value.Date;
            }

            ValidarHorarioInicio();
            ValidarHorarioFin();
        }
        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            ValidarHorarioFin();
        }
        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            ValidarHorarioInicio();
            ValidarHorarioFin();
        }
        private void dtpHoraFin_ValueChanged(object sender, EventArgs e)
        {
            ValidarHorarioFin();
        }
        private void ValidarHorarioInicio()
        {

            if (rdbRecurrente.Checked)
                return;

            DateTime ahora = DateTime.Now;

            if (dtpFechaInicio.Value.Date == ahora.Date && dtpHoraInicio.Value.TimeOfDay < ahora.TimeOfDay)
            {
                DateTime horaActual = DateTime.Now;

                DateTime nuevaHora = dtpHoraInicio.Value.Date.AddHours(horaActual.Hour).AddMinutes(horaActual.Minute).AddSeconds(horaActual.Second);

                if (nuevaHora >= dtpHoraInicio.MinDate &&
                    nuevaHora <= dtpHoraInicio.MaxDate)
                {
                    dtpHoraInicio.Value = nuevaHora;
                }
            }
        }
        private void ValidarHorarioFin()
        {
            if (rdbRecurrente.Checked)
            {

                if (dtpFechaFin.Value.Date == dtpFechaInicio.Value.Date && dtpHoraFin.Value.TimeOfDay <= dtpHoraInicio.Value.TimeOfDay)
                {
                    if (dtpHoraInicio.Value.TimeOfDay < new TimeSpan(23, 59, 0))
                    {
                        dtpHoraFin.Value = dtpHoraInicio.Value.AddMinutes(1);
                    }
                }

                return;
            }

            DateTime ahora = DateTime.Now;

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                dtpFechaFin.Value = dtpFechaInicio.Value.Date;
            }

            if (dtpFechaFin.Value.Date == dtpFechaInicio.Value.Date && dtpHoraFin.Value.TimeOfDay <= dtpHoraInicio.Value.TimeOfDay)
            {
                if (dtpHoraInicio.Value.TimeOfDay < new TimeSpan(23, 59, 0))
                {
                    dtpHoraFin.Value = dtpHoraInicio.Value.AddMinutes(1);
                }
            }

            if (dtpFechaFin.Value.Date == ahora.Date && dtpHoraFin.Value.TimeOfDay < ahora.TimeOfDay)
            {
                dtpHoraFin.Value = ahora;
            }
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
            if (dtpFechaFin.Value.Date == dtpFechaInicio.Value.Date && dtpHoraFin.Value.TimeOfDay <= dtpHoraInicio.Value.TimeOfDay)
            {
                MessageBox.Show(ClsIdioma.T("La hora de fin no puede ser igual a la hora de inicio."), ClsIdioma.T("Horario inválido"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdbPorPeriodo.Checked)
            {
                if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
                {
                    MessageBox.Show(ClsIdioma.T("La fecha de fin no puede ser anterior a la fecha de inicio."), ClsIdioma.T("Fechas inválidas"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            else
            {
                bool hayDiaSeleccionado = chkLunes.Checked || chkMartes.Checked || chkMiercoles.Checked || chkJueves.Checked || chkViernes.Checked || chkSabado.Checked || chkDomingo.Checked;

                if (!hayDiaSeleccionado)
                {
                    MessageBox.Show(ClsIdioma.T("Seleccioná al menos un día de la semana."), ClsIdioma.T("Falta seleccionar días"),
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
        private void chkTodaSemana_CheckedChanged(object sender, EventArgs e)
        {
            bool seleccionarTodos = chkTodaSemana.Checked;

            chkLunes.Checked = seleccionarTodos;
            chkMartes.Checked = seleccionarTodos;
            chkMiercoles.Checked = seleccionarTodos;
            chkJueves.Checked = seleccionarTodos;
            chkViernes.Checked = seleccionarTodos;
            chkSabado.Checked = seleccionarTodos;
            chkDomingo.Checked = seleccionarTodos;
        }
        #endregion




    }
}
