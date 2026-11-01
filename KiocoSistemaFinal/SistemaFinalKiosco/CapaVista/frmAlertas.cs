using CapaEntidades.NegocioEntidades;
using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    // Lista completa de alertas: resumen, filtros y acceso directo a la pantalla donde se resuelve cada una.
    // La abre quien ve la campana (permiso 1110) y cada uno ve solo los tipos que le corresponden.
    // "Ir a resolver" solo funciona si el usuario puede entrar a la pantalla de destino.
    // Las alertas salen de sp_ObtenerAlertas, igual que la campana.
    public partial class frmAlertas : Form
    {
        private static readonly Color ColorUrgente = Color.Firebrick;
        private static readonly Color ColorAviso = Color.DarkOrange;

        private readonly ClsAlertaLogica logica = new ClsAlertaLogica();
        // Qué pantalla abre cada tipo de alerta (las mismas opciones del menú principal).
        private readonly Dictionary<TipoAlerta, Action> acciones;
        // Si el usuario puede entrar a la pantalla donde se resuelve cada tipo (null = siempre).
        private readonly Func<TipoAlerta, bool>? puedeResolver;
        // Se llama después de resolver algo, para refrescar la campana del menú principal.
        private readonly Action? alCambiar;

        private List<ClsAlertaEntidad> alertas = new List<ClsAlertaEntidad>();
        // Evita filtrar varias veces mientras se cargan los combos.
        private bool cargando = false;

        // Ítem del combo de tipos: null = todos.
        private class ItemTipo
        {
            public TipoAlerta? Tipo { get; set; }
            public string Texto { get; set; } = "";
            public override string ToString() => Texto;
        }

        public frmAlertas(Dictionary<TipoAlerta, Action> acciones, Func<TipoAlerta, bool>? puedeResolver = null, Action? alCambiar = null)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.acciones = acciones;
            this.puedeResolver = puedeResolver;
            this.alCambiar = alCambiar;

            cargando = true;
            cmbPrioridad.SelectedIndex = 0;
            ClsIdioma.TraducirOpciones(cmbPrioridad);   // se elige por posición
            cargando = false;

            CargarAlertas();
        }

        #region Metodos
        private void CargarAlertas()
        {
            try
            {
                alertas = logica.ObtenerAlertas();
            }
            catch (Exception ex)
            {
                alertas = new List<ClsAlertaEntidad>();

                MessageBox.Show(ClsIdioma.T("No se pudieron cargar las alertas.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarResumen();
            CargarTipos();
            Filtrar();
        }
        private void ActualizarResumen()
        {
            int urgentes = alertas.Count(a => a.Urgente);
            int avisos = alertas.Count - urgentes;

            btnTotal.Text = alertas.Count + ClsIdioma.T(" en total");
            btnUrgentes.Text = urgentes + (urgentes == 1 ? ClsIdioma.T(" urgente") : ClsIdioma.T(" urgentes"));
            btnAvisos.Text = avisos + (avisos == 1 ? ClsIdioma.T(" aviso") : ClsIdioma.T(" avisos"));
        }
        // Solo los tipos que tienen alertas, con su cantidad. Mantiene el tipo elegido si sigue habiendo.
        private void CargarTipos()
        {
            TipoAlerta? tipoElegido = (cmbTipo.SelectedItem as ItemTipo)?.Tipo;

            cargando = true;

            try
            {
                cmbTipo.Items.Clear();
                cmbTipo.Items.Add(new ItemTipo { Tipo = null, Texto = ClsIdioma.T("Todos") });

                foreach (var grupo in alertas.GroupBy(a => a.Tipo).OrderBy(g => ClsCampanaAlertas.TituloDe(g.Key)))
                {
                    cmbTipo.Items.Add(new ItemTipo
                    {
                        Tipo = grupo.Key,
                        Texto = ClsCampanaAlertas.TituloDe(grupo.Key) + " (" + grupo.Count() + ")"
                    });
                }

                int indice = cmbTipo.Items.Cast<ItemTipo>().ToList().FindIndex(i => i.Tipo == tipoElegido);
                cmbTipo.SelectedIndex = indice >= 0 ? indice : 0;
            }
            finally
            {
                cargando = false;
            }
        }
        // Llena la grilla con las alertas que cumplen los filtros: urgentes primero.
        private void Filtrar()
        {
            if (cargando)
            {
                return;
            }

            TipoAlerta? tipo = (cmbTipo.SelectedItem as ItemTipo)?.Tipo;
            int prioridad = cmbPrioridad.SelectedIndex;   // 0 todas, 1 urgentes, 2 avisos
            string texto = txtBuscar.Text.Trim();

            IEnumerable<ClsAlertaEntidad> filtradas = alertas
                .Where(a => tipo == null || a.Tipo == tipo)
                .Where(a => prioridad != 1 || a.Urgente)
                .Where(a => prioridad != 2 || !a.Urgente)
                .Where(a => texto == "" ||
                            (a.Descripcion ?? "").Contains(texto, StringComparison.CurrentCultureIgnoreCase) ||
                            ClsCampanaAlertas.TituloDe(a.Tipo).Contains(texto, StringComparison.CurrentCultureIgnoreCase))
                .OrderByDescending(a => a.Urgente);   // OrderBy es estable: dentro de cada prioridad queda el orden del SP

            dtgAlertas.Rows.Clear();

            foreach (ClsAlertaEntidad alerta in filtradas)
            {
                int indice = dtgAlertas.Rows.Add(
                    alerta.Urgente ? ClsIdioma.T("● Urgente") : ClsIdioma.T("● Aviso"),
                    ClsCampanaAlertas.TituloDe(alerta.Tipo),
                    alerta.Descripcion);

                DataGridViewRow fila = dtgAlertas.Rows[indice];

                fila.Tag = alerta;
                fila.Cells["clnPrioridad"].Style.ForeColor = alerta.Urgente ? ColorUrgente : ColorAviso;
                fila.Cells["clnPrioridad"].Style.SelectionForeColor = alerta.Urgente ? ColorUrgente : ColorAviso;
                fila.Cells["clnPrioridad"].Style.Font = new Font(dtgAlertas.Font, FontStyle.Bold);
            }

            if (alertas.Count == 0)
            {
                lblCantidad.Text = ClsIdioma.T("No hay alertas. Todo en orden.");
            }
            else if (dtgAlertas.Rows.Count == 0)
            {
                lblCantidad.Text = ClsIdioma.T("Ninguna alerta coincide con los filtros.");
            }
            else
            {
                lblCantidad.Text = ClsIdioma.T("Mostrando ") + dtgAlertas.Rows.Count + ClsIdioma.T(" de ") + alertas.Count +
                    (alertas.Count == 1 ? ClsIdioma.T(" alerta") : ClsIdioma.T(" alertas"));
            }

            MarcarResumen(prioridad);
            ActualizarBotones();
        }
        // Resalta el recuadro del resumen que corresponde al filtro de prioridad.
        private void MarcarResumen(int prioridad)
        {
            btnTotal.BackColor = prioridad == 0 ? Color.Gainsboro : SystemColors.Control;
            btnUrgentes.BackColor = prioridad == 1 ? Color.MistyRose : SystemColors.Control;
            btnAvisos.BackColor = prioridad == 2 ? Color.OldLace : SystemColors.Control;
        }
        // "Ir a resolver" solo con una alerta elegida que el usuario pueda resolver; si no puede, se le explica.
        private void ActualizarBotones()
        {
            ClsAlertaEntidad? alerta = AlertaElegida();
            bool puede = alerta != null && PuedeResolver(alerta.Tipo);

            btnIrResolver.Enabled = puede;
            lblPermiso.Visible = alerta != null && !puede;
        }
        private bool PuedeResolver(TipoAlerta tipo)
        {
            return puedeResolver == null || puedeResolver(tipo);
        }
        private ClsAlertaEntidad? AlertaElegida()
        {
            return dtgAlertas.CurrentRow?.Tag as ClsAlertaEntidad;
        }
        // Abre la pantalla donde se resuelve la alerta elegida y, al volver, recarga la lista.
        private void IrAResolver()
        {
            ClsAlertaEntidad? alerta = AlertaElegida();

            if (alerta == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione una alerta."), ClsIdioma.T("Alertas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!PuedeResolver(alerta.Tipo))
            {
                MessageBox.Show(ClsIdioma.T(ClsCampanaAlertas.MENSAJE_SIN_PERMISO), ClsIdioma.T("Alertas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!acciones.TryGetValue(alerta.Tipo, out Action? accion))
            {
                MessageBox.Show(ClsIdioma.T("Esta alerta no tiene una pantalla asociada para resolverla."), ClsIdioma.T("Alertas"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            accion();

            CargarAlertas();
            alCambiar?.Invoke();
        }

        #endregion

        #region Eventos
        private void Filtros_Changed(object? sender, EventArgs e)
        {
            Filtrar();
        }
        private void btnTotal_Click(object? sender, EventArgs e)
        {
            cmbPrioridad.SelectedIndex = 0;
        }
        private void btnUrgentes_Click(object? sender, EventArgs e)
        {
            cmbPrioridad.SelectedIndex = 1;
        }
        private void btnAvisos_Click(object? sender, EventArgs e)
        {
            cmbPrioridad.SelectedIndex = 2;
        }
        private void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            cargando = true;

            try
            {
                cmbTipo.SelectedIndex = 0;
                cmbPrioridad.SelectedIndex = 0;
                txtBuscar.Clear();
            }
            finally
            {
                cargando = false;
            }

            Filtrar();
            txtBuscar.Focus();
        }
        private void dtgAlertas_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IrAResolver();
            }
        }
        private void dtgAlertas_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // si no, Enter baja a la fila siguiente
                IrAResolver();
            }
        }
        private void dtgAlertas_SelectionChanged(object? sender, EventArgs e)
        {
            ActualizarBotones();
        }
        private void btnIrResolver_Click(object? sender, EventArgs e)
        {
            IrAResolver();
        }
        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            CargarAlertas();
            alCambiar?.Invoke();
        }
        private void btnSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
