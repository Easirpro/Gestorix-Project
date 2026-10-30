using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica.NegocioLogica;


namespace CapaVista
{
    public partial class frmCompras : Form
    {
        private ClsCompraLogica logica = new ClsCompraLogica();

        public frmCompras()
        {
            InitializeComponent();

            ConfigurarGrid();
            CargarCompras();

        }

        #region Metodos
        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            clnFecha.Width = 100;
            clnProveedor.Width = 220;
            clnTipoFactura.Width = 130;
            clnNCoprobante.Width = 150;
            clnTotal.Width = 120;
            clnEstado.Width = 100;
        }
        private void CargarCompras()
        {
            try
            {
                DateTime desde = dateTimePicker1.Value.Date;
                DateTime hasta = dateTimePicker2.Value.Date;

                DataTable tabla = logica.ObtenerCompras(desde, hasta);

                dataGridView1.Rows.Clear();

                foreach (DataRow fila in tabla.Rows)
                {
                    int indice = dataGridView1.Rows.Add();

                    dataGridView1.Rows[indice].Cells["clnFecha"].Value = Convert.ToDateTime(fila["Fecha"]).ToString("dd/MM/yyyy");
                    dataGridView1.Rows[indice].Cells["clnProveedor"].Value = fila["Proveedor"].ToString();
                    dataGridView1.Rows[indice].Cells["clnTipoFactura"].Value = fila["TipoComprobante"].ToString();
                    dataGridView1.Rows[indice].Cells["clnNCoprobante"].Value = fila["NumeroComprobante"].ToString(); dataGridView1.Rows[indice].Cells["clnTotal"].Value = Convert.ToDecimal(fila["Total"]).ToString("N2");
                    dataGridView1.Rows[indice].Cells["clnEstado"].Value = fila["Estado"].ToString();
                    dataGridView1.Rows[indice].Tag = Convert.ToInt32(fila["IdCompra"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las compras.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion



        #region Eventos
        private void btnNuevacompra_Click(object sender, EventArgs e)
        {
            frmNuevaCompra Nuevacomp = new frmNuevaCompra(false);
            Nuevacomp.ShowDialog();

            CargarCompras();
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una compra para ver el detalle.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dataGridView1.SelectedRows[0];

            if (fila.Tag == null)
            {
                MessageBox.Show("No se pudo obtener el identificador de la compra.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int idCompra = Convert.ToInt32(fila.Tag);

            using (frmDetalleCompra formulario = new frmDetalleCompra(idCompra))
            {
                formulario.ShowDialog();
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            CargarCompras();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("La fecha Desde no puede ser posterior a la fecha Hasta.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            CargarCompras();
        }
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            // Vuelve los filtros al estado con el que abre el formulario (hoy - hoy).
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            txtBuscarCompra.Clear();

            CargarCompras();

            txtBuscarCompra.Focus();
        }
        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una compra para anular.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dataGridView1.SelectedRows[0];

            if (fila.Tag == null)
            {
                MessageBox.Show("No se pudo obtener el identificador de la compra.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string estado = fila.Cells["clnEstado"].Value?.ToString();

            if (estado == "Anulada")
            {
                MessageBox.Show("La compra seleccionada ya se encuentra anulada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            int idCompra = Convert.ToInt32(fila.Tag);

            string motivo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el motivo de la anulación:", "Anular compra", "");

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debe ingresar un motivo para anular la compra.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de anular esta compra?\n\nMotivo: " + motivo, "Confirmar anulación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                logica.AnularCompra(idCompra, motivo);

                MessageBox.Show("La compra fue anulada correctamente.", "Compra anulada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo anular la compra.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion



    }
}