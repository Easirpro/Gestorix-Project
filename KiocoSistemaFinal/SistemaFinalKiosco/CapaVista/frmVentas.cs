using CapaEntidades;
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
    public partial class frmVentas : Form
    {
        private readonly CapaLogica.NegocioLogica.ClsGestorVentaLogica logicaVenta = new CapaLogica.NegocioLogica.ClsGestorVentaLogica();

        // Ventas del rango de fechas; los filtros de estado y búsqueda se aplican sobre esta tabla.
        private DataTable? ventasCargadas;
        // Evita recargar mientras se acomodan las fechas o los filtros por código.
        private bool cargando = false;

        public frmVentas()
        {
            InitializeComponent();

            // Los eventos se enganchan en el Designer. Antes se enganchaban también acá y
            // Actualizar y la carga inicial se ejecutaban dos veces.
            cargando = true;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            cmbEstado.SelectedIndex = 0;   // Activas
            cargando = false;

            CargarVentas();
        }


        #region Metodos
        private bool PuedeAnular
        {
            get { return SesionUsuario.Permisos.Contains(250); }
        }
        // Lee de la base las ventas del rango de fechas. Si se indica, deja elegida esa venta.
        private void CargarVentas(int? idVentaAElegir = null)
        {
            if (cargando)
            {
                return;
            }

            try
            {
                ventasCargadas = logicaVenta.ObtenerVentasListado(dtpDesde.Value.Date, dtpHasta.Value.Date);
            }
            catch (Exception ex)
            {
                ventasCargadas = null;

                MessageBox.Show("No se pudieron cargar las ventas.\n\n" + ex.Message, "Error al consultar ventas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarVentas(idVentaAElegir);
        }
        // Llena la grilla con las ventas que cumplen el estado y la búsqueda.
        private void MostrarVentas(int? idVentaAElegir = null)
        {
            dtgVentas.Rows.Clear();

            decimal totalVendido = 0m;
            int cantidadActivas = 0;

            if (ventasCargadas != null)
            {
                int estado = cmbEstado.SelectedIndex;   // 0 activas, 1 anuladas, 2 todas
                string texto = txtBuscar.Text.Trim();

                foreach (DataRow venta in ventasCargadas.Rows)
                {
                    bool anulada = venta["Anulada"] != DBNull.Value && Convert.ToBoolean(venta["Anulada"]);

                    if ((estado == 0 && anulada) || (estado == 1 && !anulada))
                    {
                        continue;
                    }

                    string numero = venta["IdVenta"].ToString() ?? "";
                    string cajero = venta["Cajero"]?.ToString() ?? "";
                    string medios = venta["MediosPago"]?.ToString() ?? "";

                    if (texto != "" &&
                        !numero.Contains(texto) &&
                        !cajero.Contains(texto, StringComparison.CurrentCultureIgnoreCase) &&
                        !medios.Contains(texto, StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }

                    decimal total = Convert.ToDecimal(venta["Total"]);

                    int indice = dtgVentas.Rows.Add(
                        numero,
                        Convert.ToDateTime(venta["FechaHora"]).ToString("dd/MM/yyyy HH:mm"),
                        cajero,
                        venta["IdSesionCaja"] == DBNull.Value ? "" : venta["IdSesionCaja"].ToString(),
                        Convert.ToDecimal(venta["Articulos"]).ToString("0.###"),
                        medios,
                        total.ToString("C2"),
                        anulada ? "Anulada" : "Activa");

                    DataGridViewRow fila = dtgVentas.Rows[indice];
                    fila.Tag = venta;

                    if (anulada)
                    {
                        // Las anuladas en gris y con el estado en rojo, para distinguirlas.
                        fila.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                        fila.Cells["clnEstado"].Style.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        totalVendido += total;
                        cantidadActivas++;
                    }
                }
            }

            ElegirFila(idVentaAElegir);

            // Total vendido: solo las ventas activas que se ven en la lista.
            lblResumen.Text = dtgVentas.Rows.Count == 0
                ? "No hay ventas para mostrar con estos filtros."
                : dtgVentas.Rows.Count + (dtgVentas.Rows.Count == 1 ? " venta" : " ventas") +
                  "   ·   Total vendido (activas): " + totalVendido.ToString("C2") +
                  (cantidadActivas < dtgVentas.Rows.Count ? "   ·   Las anuladas no suman." : "");

            MostrarDatosVentaElegida();
        }
        private void ElegirFila(int? idVenta)
        {
            dtgVentas.ClearSelection();

            DataGridViewRow? fila = null;

            if (idVenta.HasValue)
            {
                fila = dtgVentas.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(f => f.Cells["clnTransaccion"].Value?.ToString() == idVenta.Value.ToString());
            }

            if (fila == null && dtgVentas.Rows.Count > 0)
            {
                fila = dtgVentas.Rows[0];
            }

            if (fila != null)
            {
                dtgVentas.CurrentCell = fila.Cells["clnTransaccion"];
                fila.Selected = true;
            }
        }
        private DataRow? VentaElegida()
        {
            return dtgVentas.CurrentRow?.Tag as DataRow;
        }
        // Observaciones, motivo y estado de los botones según la venta elegida.
        private void MostrarDatosVentaElegida()
        {
            DataRow? venta = VentaElegida();

            btnDetalle.Enabled = venta != null;

            if (venta == null)
            {
                txtObservaciones.Clear();
                btnAnular.Text = "Anular";
                btnAnular.Enabled = false;
                return;
            }

            bool anulada = venta["Anulada"] != DBNull.Value && Convert.ToBoolean(venta["Anulada"]);

            btnAnular.Text = anulada ? "Activar" : "Anular";
            btnAnular.Enabled = PuedeAnular;

            StringBuilder notas = new StringBuilder();

            string observaciones = venta["Observaciones"]?.ToString() ?? "";
            string motivo = venta["MotivoAnulacion"]?.ToString() ?? "";

            if (!string.IsNullOrWhiteSpace(observaciones))
                notas.AppendLine("Observaciones: " + observaciones);

            if (!string.IsNullOrWhiteSpace(motivo))
                notas.AppendLine("Motivo de anulación: " + motivo);

            txtObservaciones.Text = notas.Length > 0 ? notas.ToString().TrimEnd() : "Sin observaciones ni motivo de anulación.";
        }
        private void MostrarDetalle()
        {
            DataRow? venta = VentaElegida();

            if (venta == null)
            {
                MessageBox.Show("Seleccione una venta para ver el detalle.", "Ventas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmDetalleVenta detalle = new frmDetalleVenta(venta))
            {
                detalle.Icon = Icon;
                detalle.ShowDialog(this);
            }
        }
        // Pide el motivo de anulación en una ventana chica. Devuelve null si se cancela.
        private string? PedirMotivoAnulacion(int idVenta)
        {
            using (Form ventana = new Form())
            {
                ventana.Text = "Anular venta N.º " + idVenta;
                ventana.StartPosition = FormStartPosition.CenterParent;
                ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
                ventana.ClientSize = new Size(380, 170);
                ventana.MinimizeBox = false;
                ventana.MaximizeBox = false;
                ventana.ShowInTaskbar = false;

                Label lblMotivo = new Label
                {
                    Text = "Ingrese el motivo de anulación:",
                    Location = new Point(15, 15),
                    AutoSize = true
                };

                TextBox txtMotivo = new TextBox
                {
                    Location = new Point(15, 40),
                    Size = new Size(350, 55),
                    Multiline = true,
                    MaxLength = 500
                };

                Button btnAceptar = new Button
                {
                    Text = "Anular",
                    Location = new Point(185, 115),
                    Size = new Size(85, 32)
                };

                Button btnCancelar = new Button
                {
                    Text = "Cancelar",
                    Location = new Point(280, 115),
                    Size = new Size(85, 32),
                    DialogResult = DialogResult.Cancel
                };

                btnAceptar.Click += (s, ev) =>
                {
                    if (string.IsNullOrWhiteSpace(txtMotivo.Text))
                    {
                        MessageBox.Show("Ingrese el motivo de anulación.", "Anular venta",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMotivo.Focus();
                        return;
                    }

                    ventana.Tag = txtMotivo.Text.Trim();
                    ventana.DialogResult = DialogResult.OK;
                    ventana.Close();
                };

                ventana.Controls.Add(lblMotivo);
                ventana.Controls.Add(txtMotivo);
                ventana.Controls.Add(btnAceptar);
                ventana.Controls.Add(btnCancelar);
                ventana.CancelButton = btnCancelar;

                if (ventana.ShowDialog(this) != DialogResult.OK)
                    return null;

                return ventana.Tag?.ToString();
            }
        }

        #endregion


        #region Eventos
        private void btnAnular_Click(object? sender, EventArgs e)
        {
            DataRow? venta = VentaElegida();

            if (venta == null)
            {
                MessageBox.Show("Seleccione una venta.", "Ventas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!PuedeAnular)
            {
                MessageBox.Show("No tenés permiso para anular ventas.", "Ventas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idVenta = Convert.ToInt32(venta["IdVenta"]);
            bool anulada = venta["Anulada"] != DBNull.Value && Convert.ToBoolean(venta["Anulada"]);

            string? motivo = null;

            if (!anulada)
            {
                motivo = PedirMotivoAnulacion(idVenta);

                if (motivo == null)
                    return;
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Desea activar nuevamente la venta N.º " + idVenta + "?", "Activar venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;
            }

            try
            {
                logicaVenta.CambiarEstadoVenta(idVenta, !anulada, motivo);

                MessageBox.Show(anulada ? "La venta fue activada." : "La venta fue anulada.", "Ventas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Si la venta queda fuera del filtro de estado (por ejemplo, se anuló viendo "Activas"),
                // se pasa a "Todas" para que siga a la vista.
                if (cmbEstado.SelectedIndex != 2)
                {
                    cargando = true;
                    cmbEstado.SelectedIndex = 2;
                    cargando = false;
                }

                CargarVentas(idVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado de la venta.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDetalle_Click(object? sender, EventArgs e)
        {
            MostrarDetalle();
        }
        private void dtgVentas_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MostrarDetalle();
            }
        }
        private void dtgVentas_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // si no, Enter baja a la fila siguiente
                MostrarDetalle();
            }
        }
        private void dtgVentas_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarDatosVentaElegida();
        }
        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            CargarVentas(VentaElegida() == null ? null : Convert.ToInt32(VentaElegida()!["IdVenta"]));
        }
        // Al cambiar una fecha se recarga sola. Si Desde queda después de Hasta, se corre la otra fecha.
        private void dtpDesde_ValueChanged(object? sender, EventArgs e)
        {
            if (cargando)
                return;

            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                dtpHasta.Value = dtpDesde.Value.Date;   // dispara su ValueChanged, que recarga
                return;
            }

            CargarVentas();
        }
        private void dtpHasta_ValueChanged(object? sender, EventArgs e)
        {
            if (cargando)
                return;

            if (dtpHasta.Value.Date < dtpDesde.Value.Date)
            {
                dtpDesde.Value = dtpHasta.Value.Date;
                return;
            }

            CargarVentas();
        }
        private void Filtros_Changed(object? sender, EventArgs e)
        {
            if (cargando)
                return;

            MostrarVentas();
        }
        private void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            cargando = true;

            try
            {
                dtpDesde.Value = DateTime.Today;
                dtpHasta.Value = DateTime.Today;
                cmbEstado.SelectedIndex = 0;
                txtBuscar.Clear();
            }
            finally
            {
                cargando = false;
            }

            CargarVentas();
            txtBuscar.Focus();
        }
        private void btnVolver_Click(object? sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
