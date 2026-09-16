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
    public partial class frmCargaarticulo : Form
    {
        ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();
        public frmCargaarticulo()
        {
            InitializeComponent();

            dtgCargaarticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCargaarticulo.MultiSelect = false;

            dtgCargaarticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgCargaarticulo.AllowUserToResizeColumns = false;
            dtgCargaarticulo.AllowUserToOrderColumns = false;

            this.Load += frmCargaarticulo_Load;

        }

        //Metodos
        #region Metodos
        private void CargarArticulos()
        {
            DataTable tabla = logica.CargarArticulos();

            dtgCargaarticulo.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {

                int indice = dtgCargaarticulo.Rows.Add(
                    fila["CodigoBarra"],
                    fila["Descripcion"],
                    fila["Rubro"],
                    fila["Proveedor"]?.ToString() ?? "",
                    fila["Sucursal"]?.ToString() ?? "",
                    "",
                    fila["PrecioVenta"],
                    "",
                    "",
                    "",
                    "",
                    fila["IVA"],
                    fila["CantidadActual"] == DBNull.Value ? 0 : Convert.ToInt32(fila["CantidadActual"]),
                    fila["StockMinimo"] == DBNull.Value ? 0 : Convert.ToInt32(fila["StockMinimo"]),
                    fila["StockIdeal"] == DBNull.Value ? 0 : Convert.ToInt32(fila["StockIdeal"])
                );

                dtgCargaarticulo.Rows[indice].Cells["clnVencimiento"].Value = fila["FechaVencimiento"] == DBNull.Value
                ? "" : Convert.ToDateTime(fila["FechaVencimiento"]).ToString("dd/MM/yyyy");

            }
        }

        #endregion


        //Evevnto
        #region Evento
        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            frmNuevoArticulo nuevoArticulo = new frmNuevoArticulo();
            nuevoArticulo.ShowDialog();

            CargarArticulos();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgCargaarticulo.CurrentRow == null) 
            { 
                MessageBox.Show("Seleccione un artículo."); 
                return; 
            }
            int idProducto = Convert.ToInt32(dtgCargaarticulo.CurrentRow.Tag); 
            
            frmNuevoArticulo modificararticulo = new frmNuevoArticulo(idProducto); 
            
            modificararticulo.Text = "Modificar Articulo"; 
            modificararticulo.ShowDialog(this); 
            
            CargarArticulos();
        }
        private void frmCargaarticulo_Load(object sender, EventArgs e)
        {
            CargarArticulos();
        }
        private void dtgCargaarticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
#endregion

