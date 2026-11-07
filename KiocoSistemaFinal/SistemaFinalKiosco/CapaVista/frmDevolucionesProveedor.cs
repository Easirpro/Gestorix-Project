using CapaLogica.NegocioLogica;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    // devoluciones a proveedor
    public class frmDevolucionesProveedor : Form
    {
        private readonly ClsDevolucionProveedorLogica logica = new ClsDevolucionProveedorLogica();

        private readonly DateTimePicker dtpDesde = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 110 };
        private readonly DateTimePicker dtpHasta = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 110 };
        private readonly Button btnBuscar = new Button { Text = "Buscar", AutoSize = true };
        private readonly DataGridView dgvDevoluciones = new DataGridView { Dock = DockStyle.Fill };
        private readonly Label lblTotal = new Label { AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Margin = new Padding(3, 8, 3, 3) };
        private readonly Button btnCerrar = new Button { Text = "Cerrar", AutoSize = true, DialogResult = DialogResult.Cancel };

        public frmDevolucionesProveedor()
        {
            Text = "Devoluciones a proveedor";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(820, 480);
            MinimumSize = new Size(600, 320);
            Font = new Font("Segoe UI", 9F);
            Padding = new Padding(8);

            FlowLayoutPanel filtros = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, WrapContents = false };
            filtros.Controls.Add(new Label { Text = "Desde:", AutoSize = true, Margin = new Padding(3, 7, 3, 3) });
            filtros.Controls.Add(dtpDesde);
            filtros.Controls.Add(new Label { Text = "Hasta:", AutoSize = true, Margin = new Padding(12, 7, 3, 3) });
            filtros.Controls.Add(dtpHasta);
            filtros.Controls.Add(btnBuscar);

            FlowLayoutPanel pie = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true, FlowDirection = FlowDirection.RightToLeft };
            pie.Controls.Add(btnCerrar);
            pie.Controls.Add(lblTotal);

            dgvDevoluciones.ReadOnly = true;
            dgvDevoluciones.AllowUserToAddRows = false;
            dgvDevoluciones.AllowUserToDeleteRows = false;
            dgvDevoluciones.RowHeadersVisible = false;
            dgvDevoluciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevoluciones.MultiSelect = false;
            dgvDevoluciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDevoluciones.BackgroundColor = SystemColors.Window;
            dgvDevoluciones.DataBindingComplete += (sender, e) => FormatearColumnas();

            Controls.Add(dgvDevoluciones);
            Controls.Add(filtros);
            Controls.Add(pie);

            AcceptButton = btnBuscar;
            CancelButton = btnCerrar;

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            btnBuscar.Click += (sender, e) => Buscar();
            Load += (sender, e) => Buscar();

            ClsIdioma.Registrar(this);
        }

        private void Buscar()
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(ClsIdioma.T("La fecha desde no puede ser mayor a la fecha hasta."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable tabla = logica.ObtenerDevoluciones(dtpDesde.Value.Date, dtpHasta.Value.Date);
                dgvDevoluciones.DataSource = tabla;

                decimal total = tabla.Rows.Cast<DataRow>().Sum(f => Convert.ToDecimal(f["Importe"]));
                lblTotal.Text = tabla.Rows.Count + (tabla.Rows.Count == 1 ? ClsIdioma.T(" devolución") : ClsIdioma.T(" devoluciones")) +
                                ClsIdioma.T(" - Total al costo: ") + total.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar las devoluciones.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearColumnas()
        {
            if (dgvDevoluciones.Columns.Count == 0)
                return;

            Formato("Fecha", "dd/MM/yyyy HH:mm", 18, false);
            Formato("Producto", null, 36, false);
            Formato("Cantidad", "0.###", 12, true);
            Formato("Proveedor", null, 40, false);
            Formato("Importe", "C2", 16, true);
        }

        private void Formato(string columna, string? formato, float peso, bool derecha)
        {
            if (!dgvDevoluciones.Columns.Contains(columna))
                return;

            DataGridViewColumn c = dgvDevoluciones.Columns[columna];
            c.FillWeight = peso;
            c.HeaderText = ClsIdioma.T(columna);

            if (formato != null)
                c.DefaultCellStyle.Format = formato;

            if (derecha)
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
