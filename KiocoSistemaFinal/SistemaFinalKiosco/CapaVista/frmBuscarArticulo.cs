using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaVista
{
    public partial class frmBuscarArticulo : Form
    {
        private CapaLogica.NegocioLogica.ClsGestorLogicaProducto logica = new CapaLogica.NegocioLogica.ClsGestorLogicaProducto();
        public frmBuscarArticulo()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            btnBuscar.Click += btnBuscar_Click;
        }
        public ClsProducto ProductoSeleccionado { get; private set; }

        #region Metodos

        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }

            DataRow fila = (DataRow)dataGridView1.CurrentRow.Tag;

            ClsProducto producto = new ClsProducto
            {
                IdProducto = Convert.ToInt32(fila["IdProducto"]),
                CodigoBarra = fila["CodigoBarra"]?.ToString() ?? "",
                SKU = fila["SKU"]?.ToString() ?? "",
                Descripcion = fila["Descripcion"]?.ToString() ?? "",
                PrecioVenta = Convert.ToDecimal(fila["PrecioVenta"]),
                Activo = Convert.ToBoolean(fila["Activo"])
            };

            ProductoSeleccionado = producto;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscarArticulo.Text.Trim();

            bool ocultarDiscontinuos = chkDiscontinuo.Checked;

            DataTable tabla = logica.BuscarArticulos(texto, ocultarDiscontinuos);

            dataGridView1.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                int indice = dataGridView1.Rows.Add(
                    fila["CodigoBarra"],
                    fila["Descripcion"],
                    fila["Rubro"],
                    fila["PrecioVenta"],
                    fila["CantidadActual"] == DBNull.Value ? 0 : Convert.ToInt32(fila["CantidadActual"])
                );

                dataGridView1.Rows[indice].Tag = fila;
            }
        }
        #endregion

        private void txtBuscarArticulo_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarArticulo.Text.Trim();

            bool ocultarDiscontinuos = chkDiscontinuo.Checked;

            DataTable tabla = logica.BuscarArticulos(texto, ocultarDiscontinuos);

            dataGridView1.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                int indice = dataGridView1.Rows.Add(
                    fila["CodigoBarra"],
                    fila["Descripcion"],
                    fila["Rubro"],
                    fila["PrecioVenta"],
                    fila["CantidadActual"] == DBNull.Value ? 0 : Convert.ToInt32(fila["CantidadActual"])
                );

                dataGridView1.Rows[indice].Tag = fila;
            }
        }
    }
}
