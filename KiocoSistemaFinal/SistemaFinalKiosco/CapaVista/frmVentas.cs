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
        private readonly CapaLogica.NegocioLogica.ClsVentaLogica logicaVenta = new CapaLogica.NegocioLogica.ClsVentaLogica();

        public frmVentas()
        {
            InitializeComponent();

            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            Load += frmVentas_Load;
            btnActualizar.Click += btnActualizar_Click;
            btnVolver.Click += btnVolver_Click;
            btnAnuladas.Checked = false;
            CargarVentas();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

         
        }


        #region Metodos
        private void AplicarPermisos()
        {
            bool puedeGestionarVentas = SesionUsuario.Permisos.Contains(200) || SesionUsuario.Permisos.Contains(210);

            btnAnular.Enabled = puedeGestionarVentas;
        }
        private void CargarVentas()
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date;

                DataTable ventas = logicaVenta.ObtenerVentas(desde, hasta);
                if (ventas.Columns.Contains("Anulada"))
                {
                    ventas.Columns.Add("EstadoVenta", typeof(string));

                    foreach (DataRow fila in ventas.Rows)
                    {
                        bool anulada = fila["Anulada"] != DBNull.Value && Convert.ToBoolean(fila["Anulada"]);

                        fila["EstadoVenta"] = anulada ? "Anulada" : "Activa";
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;

                clnFecha.DataPropertyName = "Fecha";
                clnTransaccion.DataPropertyName = "Nro. Transacción";
                clnCajero.DataPropertyName = "Cajero";
                clnTotal.DataPropertyName = "Total";
                clnAnulada.DataPropertyName = "Anulada";

                clnDetalle.UseColumnTextForButtonValue = true;
                clnDetalle.Text = "Ver detalle";
                dataGridView1.DataSource = ventas;

                AplicarFiltroAnuladas();

                dataGridView1.CellFormatting -= dataGridView1_CellFormatting;
                dataGridView1.CellFormatting += dataGridView1_CellFormatting;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ActualizarBotonAnular();
                CargarObservaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las ventas.\n\n" + ex.Message, "Error al consultar ventas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarDetalleVenta(DataGridViewRow fila)
        {
            if (!(fila.DataBoundItem is DataRowView registro))
            {
                MessageBox.Show("No se pudieron obtener los datos de la venta.");
                return;
            }

            DataRow venta = registro.Row;

            string ObtenerDato(string columna)
            {
                if (!venta.Table.Columns.Contains(columna) || venta.IsNull(columna))
                    return "No disponible";

                return venta[columna].ToString();
            }

            string ObtenerMoneda(string columna)
            {
                if (!venta.Table.Columns.Contains(columna) || venta.IsNull(columna))
                    return "No disponible";

                return Convert.ToDecimal(venta[columna]).ToString("C2");
            }

            string detalle =
                $"Fecha: {ObtenerDato("Fecha")}\n" +
                $"N.º de transacción: {ObtenerDato("Nro. Transacción")}\n" +
                $"N.º de comprobante: {ObtenerDato("Nro. Transacción")}\n" +
                $"Cajero: {ObtenerDato("Cajero")}\n\n" +
                $"Subtotal: {ObtenerMoneda("Subtotal")}\n" +
                $"Descuento/Recargo: {ObtenerMoneda("Descuento/Recargo")}\n" +
                $"TOTAL VENDIDO: {ObtenerMoneda("Total")}\n\n" +
                $"Efectivo: {ObtenerMoneda("Efectivo")}\n" +
                $"Tarjeta de crédito: {ObtenerMoneda("Tarjeta de Credito")}\n" +
                $"Cuenta corriente: {ObtenerMoneda("Cta. Cte")}\n" +
                $"Débito: {ObtenerMoneda("Debito")}\n" +
                $"Transferencia: {ObtenerMoneda("Tranferencia")}\n\n" +
                $"Factura activa: {(Convert.ToBoolean(venta["Anulada"]) ? "No" : "Sí")}\n" +
                $"Factura anulada: {(Convert.ToBoolean(venta["Anulada"]) ? "Sí" : "No")}";

            MessageBox.Show(detalle, "Detalle de la venta",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ActualizarBotonAnular()
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                btnAnular.Text = "Anular";
                btnAnular.Enabled = false;
                return;
            }

            bool anulada = false;

            if (dataGridView1.CurrentRow.DataBoundItem is DataRowView registro && registro.Row.Table.Columns.Contains("Anulada") && !registro.Row.IsNull("Anulada"))
            {
                anulada = Convert.ToBoolean(registro.Row["Anulada"]);
            }

            btnAnular.Text = anulada ? "Activar" : "Anular";

            btnAnular.Enabled = SesionUsuario.Permisos.Contains(200) || SesionUsuario.Permisos.Contains(210);
        }
        private void CargarObservaciones()
        {
            lstObservaciones.Items.Clear();

            if (dataGridView1.CurrentRow?.DataBoundItem is not DataRowView registro)
                return;

            DataRow venta = registro.Row;

            if (venta.Table.Columns.Contains("Observaciones") && !venta.IsNull("Observaciones"))
            {
                string observaciones = Convert.ToString(venta["Observaciones"]);

                if (!string.IsNullOrWhiteSpace(observaciones))
                    lstObservaciones.Items.Add("Observaciones: " + observaciones);
            }

            if (venta.Table.Columns.Contains("MotivoAnulacion") && !venta.IsNull("MotivoAnulacion"))
            {
                string motivo = Convert.ToString(venta["MotivoAnulacion"]);

                if (!string.IsNullOrWhiteSpace(motivo))
                    lstObservaciones.Items.Add("Motivo de anulación: " + motivo);
            }

            if (lstObservaciones.Items.Count == 0)
                lstObservaciones.Items.Add("Sin observaciones ni motivo de anulación.");
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonAnular();
            CargarObservaciones();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Columns[e.ColumnIndex].Name != "clnAnulada")
                return;

            if (e.Value == null || e.Value == DBNull.Value)
                return;

            bool anulada = Convert.ToBoolean(e.Value);

            e.Value = anulada ? "Anulada" : "Activa";
            e.FormattingApplied = true;
        }
        private void AplicarFiltroAnuladas()
        {
            string filtro = btnAnuladas.Checked ? "Anulada = true" : "Anulada = false";

            if (dataGridView1.DataSource is DataTable tabla)
            {
                tabla.DefaultView.RowFilter = filtro;
            }
            else if (dataGridView1.DataSource is DataView vista)
            {
                vista.RowFilter = filtro;
            }
        }

        #endregion


        #region Eventos
        private void frmVentas_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
            CargarVentas();
        }
        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta.");
                return;
            }

            DataGridViewRow fila = dataGridView1.CurrentRow;

            int idVenta = Convert.ToInt32(fila.Cells["clnTransaccion"].Value);

            bool anulada = Convert.ToBoolean(fila.Cells["clnAnulada"].Value);

            string motivo = null;

            if (!anulada)
            {
                using (Form ventana = new Form())
                {
                    ventana.Text = "Anular venta";
                    ventana.StartPosition = FormStartPosition.CenterParent;
                    ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
                    ventana.ClientSize = new Size(380, 170);
                    ventana.MinimizeBox = false;
                    ventana.MaximizeBox = false;

                    Label lblMotivo = new Label
                    {
                        Text = "Ingrese el motivo de anulación:",
                        Location = new Point(15, 15),
                        AutoSize = true
                    };

                    TextBox txtMotivo = new TextBox
                    {
                        Location = new Point(15, 40),
                        Size = new Size(350, 50),
                        Multiline = true,
                        MaxLength = 500
                    };

                    Button btnAceptar = new Button
                    {
                        Text = "Aceptar",
                        Location = new Point(185, 110),
                        Size = new Size(85, 30)
                    };

                    Button btnCancelar = new Button
                    {
                        Text = "Cancelar",
                        Location = new Point(280, 110),
                        Size = new Size(85, 30),
                        DialogResult = DialogResult.Cancel
                    };

                    btnAceptar.Click += (s, ev) =>
                    {
                        if (string.IsNullOrWhiteSpace(txtMotivo.Text))
                        {
                            MessageBox.Show("Ingrese el motivo de anulación.");
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
                    ventana.AcceptButton = btnAceptar;
                    ventana.CancelButton = btnCancelar;

                    if (ventana.ShowDialog(this) != DialogResult.OK)
                        return;

                    motivo = ventana.Tag.ToString();
                }
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Desea activar nuevamente esta venta?", "Activar venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;
            }

            try
            {
                logicaVenta.CambiarEstadoVenta(idVenta, !anulada, motivo);

                MessageBox.Show(anulada ? "La venta fue activada." : "La venta fue anulada.", "Ventas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarVentas();
                ActualizarBotonAnular();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado de la venta.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name != "clnDetalle")
                return;

            MostrarDetalleVenta(dataGridView1.Rows[e.RowIndex]);
        }
        private void lstObservaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnAnuladas_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltroAnuladas();
           
        }
        #endregion









    }
}
