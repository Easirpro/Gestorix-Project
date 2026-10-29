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

namespace CapaVista
{
    // Listado de devoluciones. Usa el diseño (frmDevolucion.Designer.cs) que ya
    // tiene el proyecto: solo se reemplaza este archivo de código.
    public partial class frmDevolucion : Form
    {
        private ClsDevolucionLogica logica = new ClsDevolucionLogica();

        public frmDevolucion()
        {
            InitializeComponent();

            // Eventos que el diseño todavía no tenía conectados
            btnBuscar.Click += btnBuscar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnVolver.Click += btnVolver_Click;
            this.Load += frmDevolucion_Load;

            // El listado no se edita: el botón Guardar no se usa
            btnGuardar.Visible = false;

            ConfigurarGrid();
        }

        private void frmDevolucion_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today;
            CargarDevoluciones();
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
        }

        private void CargarDevoluciones()
        {
            DateTime desde = dateTimePicker1.Value.Date;
            DateTime hasta = dateTimePicker2.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable tabla = logica.ObtenerDevoluciones(desde, hasta);

                dataGridView1.Rows.Clear();

                foreach (DataRow fila in tabla.Rows)
                {
                    int indice = dataGridView1.Rows.Add();
                    DataGridViewRow renglon = dataGridView1.Rows[indice];

                    // Columnas del diseño:
                    // Column1 Fecha | Column10 Estado | Column2 Nro. Transacción | Column3 Nro. Caja
                    // Column4 Cajero | Column5 Tipo de Comprobante | Column6 Nro. Comprobante
                    // Column8 Total | Column9 Producto/Servicio
                    renglon.Cells["Column1"].Value = Convert.ToDateTime(fila["FechaHora"]).ToString("dd/MM/yyyy HH:mm");
                    renglon.Cells["Column10"].Value = fila["Estado"].ToString();
                    renglon.Cells["Column2"].Value = fila["IdDevolucion"].ToString();
                    renglon.Cells["Column3"].Value = fila["IdSesionCaja"] == DBNull.Value ? "-" : fila["IdSesionCaja"].ToString();
                    renglon.Cells["Column4"].Value = fila["Cajero"].ToString();
                    renglon.Cells["Column5"].Value = "Venta";
                    renglon.Cells["Column6"].Value = fila["IdVenta"] == DBNull.Value ? "-" : fila["IdVenta"].ToString();
                    renglon.Cells["Column8"].Value = Convert.ToDecimal(fila["ImporteDevuelto"]).ToString("N2");
                    renglon.Cells["Column9"].Value = fila["Producto"].ToString() + " x " +
                                                     Convert.ToDecimal(fila["Cantidad"]).ToString("0.###");

                    renglon.Cells["Column9"].ToolTipText = "Motivo: " + fila["Motivo"];
                    renglon.Tag = Convert.ToInt32(fila["IdDevolucion"]);

                    if (fila["Estado"].ToString() == "Cambio de unidad")
                    {
                        renglon.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron obtener las devoluciones.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos

        private void btnNuevaDevolucion_Click(object sender, EventArgs e)
        {
            using (frmNuevaDevolucion devolucion = new frmNuevaDevolucion())
            {
                if (devolucion.ShowDialog() == DialogResult.OK)
                {
                    CargarDevoluciones();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDevoluciones();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today;
            CargarDevoluciones();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
