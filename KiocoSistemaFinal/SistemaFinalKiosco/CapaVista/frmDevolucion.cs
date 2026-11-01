using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaVista
{
    public partial class frmDevolucion : Form
    {
        private ClsDevolucionLogica logica = new ClsDevolucionLogica();

        private DataTable? devolucionesCargadas;
        private bool cargando = false;

        public frmDevolucion()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ClsGrilla.AjustarAlContenido(dataGridView1, "clnProducto");

            btnNuevaDevolucion.Enabled = SesionUsuario.Permisos.Contains(220) || SesionUsuario.Permisos.Contains(221);

            cargando = true;
            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today;
            cmbTipo.SelectedIndex = 0;
            ClsIdioma.TraducirOpciones(cmbTipo);   // se elige por posicion
            cargando = false;

            CargarDevoluciones();
        }

        #region Metodos

        private void CargarDevoluciones(int? idAElegir = null)
        {
            if (cargando)
            {
                return;
            }

            try
            {
                devolucionesCargadas = logica.ObtenerDevoluciones(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            }
            catch (Exception ex)
            {
                devolucionesCargadas = null;

                MessageBox.Show(ClsIdioma.T("No se pudieron obtener las devoluciones.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarDevoluciones(idAElegir);
        }
        private void MostrarDevoluciones(int? idAElegir = null)
        {
            dataGridView1.Rows.Clear();

            decimal totalReintegrado = 0m;

            if (devolucionesCargadas != null)
            {
                string[] tiposDato = { "", "Reintegro en efectivo", "Cambio de unidad" };
                string tipoElegido = cmbTipo.SelectedIndex > 0 && cmbTipo.SelectedIndex < tiposDato.Length ? tiposDato[cmbTipo.SelectedIndex] : "";
                string texto = txtBuscar.Text.Trim();

                foreach (DataRow fila in devolucionesCargadas.Rows)
                {
                    string tipo = fila["Estado"]?.ToString() ?? "";
                    string venta = fila["IdVenta"] == DBNull.Value ? "" : fila["IdVenta"].ToString() ?? "";
                    string producto = fila["Producto"]?.ToString() ?? "";
                    string cajero = fila["Cajero"]?.ToString() ?? "";

                    if (tipoElegido != "" && tipo != tipoElegido)
                    {
                        continue;
                    }

                    if (texto != "" &&
                        !venta.Contains(texto) &&
                        !producto.Contains(texto, StringComparison.CurrentCultureIgnoreCase) &&
                        !cajero.Contains(texto, StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }

                    bool esEfectivo = tipo == "Reintegro en efectivo";
                    bool reingresa = fila["ReingresaStock"] != DBNull.Value && Convert.ToBoolean(fila["ReingresaStock"]);
                    decimal importe = fila["ImporteDevuelto"] == DBNull.Value ? 0m : Convert.ToDecimal(fila["ImporteDevuelto"]);

                    int indice = dataGridView1.Rows.Add(
                        fila["IdDevolucion"].ToString(),
                        Convert.ToDateTime(fila["FechaHora"]).ToString("dd/MM/yyyy HH:mm"),
                        venta == "" ? "-" : venta,
                        producto,
                        Convert.ToDecimal(fila["Cantidad"]).ToString("0.###"),
                        tipo,
                        esEfectivo ? importe.ToString("C2") : ClsIdioma.T("Sin reintegro"),
                        reingresa ? ClsIdioma.T("Sí") : ClsIdioma.T("No (descartada)"),
                        cajero,
                        fila["IdSesionCaja"] == DBNull.Value ? "-" : fila["IdSesionCaja"].ToString());

                    DataGridViewRow renglon = dataGridView1.Rows[indice];
                    renglon.Tag = fila;

                    if (!esEfectivo)
                    {
                        renglon.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                    }
                    else
                    {
                        totalReintegrado += importe;
                    }

                    if (!reingresa)
                    {
                        renglon.Cells["clnStock"].Style.ForeColor = Color.Firebrick;
                    }
                }
            }

            ElegirFila(idAElegir);

            lblResumen.Text = dataGridView1.Rows.Count == 0
                ? ClsIdioma.T("No hay devoluciones para mostrar con estos filtros.")
                : dataGridView1.Rows.Count + (dataGridView1.Rows.Count == 1 ? ClsIdioma.T(" devolución") : ClsIdioma.T(" devoluciones")) +
                  ClsIdioma.T("   ·   Total reintegrado en efectivo: ") + totalReintegrado.ToString("C2");

            MostrarMotivo();
        }
        private void ElegirFila(int? idDevolucion)
        {
            dataGridView1.ClearSelection();

            DataGridViewRow? fila = null;

            if (idDevolucion.HasValue)
            {
                fila = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(f => f.Cells["clnId"].Value?.ToString() == idDevolucion.Value.ToString());
            }

            if (fila == null && dataGridView1.Rows.Count > 0)
            {
                fila = dataGridView1.Rows[0];
            }

            if (fila != null)
            {
                dataGridView1.CurrentCell = fila.Cells["clnId"];
                fila.Selected = true;
            }
        }
        private void MostrarMotivo()
        {
            if (dataGridView1.CurrentRow?.Tag is not DataRow fila)
            {
                txtMotivo.Clear();
                return;
            }

            string motivo = fila["Motivo"]?.ToString() ?? "";
            txtMotivo.Text = string.IsNullOrWhiteSpace(motivo) ? ClsIdioma.T("Sin motivo registrado.") : ClsIdioma.TraducirBitacora(motivo);
        }
        private int? IdDevolucionElegida()
        {
            return dataGridView1.CurrentRow?.Tag is DataRow fila ? Convert.ToInt32(fila["IdDevolucion"]) : null;
        }

        #endregion

        #region Eventos

        private void btnNuevaDevolucion_Click(object sender, EventArgs e)
        {
            using (frmNuevaDevolucion devolucion = new frmNuevaDevolucion())
            {
                devolucion.ShowDialog(this);
            }

            CargarDevoluciones();
        }
        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            CargarDevoluciones(IdDevolucionElegida());
        }
        private void dataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarMotivo();
        }
        private void dateTimePicker1_ValueChanged(object? sender, EventArgs e)
        {
            if (cargando)
                return;

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.Date;
                return;
            }

            CargarDevoluciones();
        }
        private void dateTimePicker2_ValueChanged(object? sender, EventArgs e)
        {
            if (cargando)
                return;

            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                dateTimePicker1.Value = dateTimePicker2.Value.Date;
                return;
            }

            CargarDevoluciones();
        }
        private void Filtros_Changed(object? sender, EventArgs e)
        {
            if (cargando)
                return;

            MostrarDevoluciones();
        }
        private void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            cargando = true;

            try
            {
                dateTimePicker1.Value = DateTime.Today.AddDays(-30);
                dateTimePicker2.Value = DateTime.Today;
                cmbTipo.SelectedIndex = 0;
                txtBuscar.Clear();
            }
            finally
            {
                cargando = false;
            }

            CargarDevoluciones();
            txtBuscar.Focus();
        }
        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
