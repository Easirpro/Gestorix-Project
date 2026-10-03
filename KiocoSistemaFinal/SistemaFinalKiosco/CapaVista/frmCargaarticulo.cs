using CapaEntidades;
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

            dtgCargaarticulo.AutoGenerateColumns = false;

            dtgCargaarticulo.ReadOnly = true;

            dtgCargaarticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCargaarticulo.MultiSelect = false;

            dtgCargaarticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgCargaarticulo.AllowUserToResizeColumns = false;
            dtgCargaarticulo.AllowUserToOrderColumns = false;
            dtgCargaarticulo.RowHeadersVisible = false;

            foreach (DataGridViewColumn columna in dtgCargaarticulo.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

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
                bool activo = fila["Activo"] != DBNull.Value && Convert.ToBoolean(fila["Activo"]);

                if (chkArticulodiscontinaudo.Checked && activo)
                {
                    continue;
                }

                if (!chkArticulodiscontinaudo.Checked && !activo)
                {
                    continue;
                }

                int indice = dtgCargaarticulo.Rows.Add(
                    fila["CodigoBarra"],
                    fila["Descripcion"],
                    fila["Rubro"],
                    fila["Marca"]?.ToString() ?? "",
                    fila["Proveedor"]?.ToString() ?? "",
                    fila["Sucursal"]?.ToString() ?? "",
                    "", // Vencimiento
                    "", // Última Actualización
                    "", // Última Venta
                    fila["PrecioCosto"] == DBNull.Value ? "" : fila["PrecioCosto"],
                    fila["PrecioVenta"],
                    fila["IVA"],
                    fila["CantidadActual"] == DBNull.Value ? 0 : Convert.ToInt32(fila["CantidadActual"]),
                    fila["StockMinimo"] == DBNull.Value ? 0 : Convert.ToInt32(fila["StockMinimo"]),
                    fila["StockIdeal"] == DBNull.Value ? 0 : Convert.ToInt32(fila["StockIdeal"]),
                    fila["Activo"] == DBNull.Value ? "Activo" : (Convert.ToBoolean(fila["Activo"]) ? "Activo" : "Inactivo")
                );

                dtgCargaarticulo.Rows[indice].Tag = fila["IdProducto"];
                dtgCargaarticulo.Rows[indice].Cells["clnVencimiento"].Value = fila["FechaVencimiento"] == DBNull.Value ? "" : Convert.ToDateTime(fila["FechaVencimiento"]).ToString("dd/MM/yyyy");
            }
        }
        private void AplicarPermisos()
        {
            bool puedeCrear = SesionUsuario.Permisos.Contains(100) || SesionUsuario.Permisos.Contains(111);
            bool puedeModificar = SesionUsuario.Permisos.Contains(100) || SesionUsuario.Permisos.Contains(112);

            btnNuevoArticulo.Enabled = puedeCrear;
            btnModificar.Enabled = puedeModificar;
            btnEliminar.Enabled = puedeModificar;
        }
        private void FiltrarArticulos()
        {
            string texto = txtBuscarCodigoNombre.Text.Trim().ToLower();
            string rubroSeleccionado = cmbRubro.SelectedIndex > 0 ? cmbRubro.Text.Trim().ToLower() : "";
            string marcaSeleccionada = cmbMarca.SelectedIndex > 0 ? cmbMarca.Text.Trim().ToLower() : "";

            foreach (DataGridViewRow fila in dtgCargaarticulo.Rows)
            {
                if (fila.IsNewRow)
                {
                    continue;
                }

                string codigoBarra = fila.Cells[0].Value?.ToString().ToLower() ?? "";
                string descripcion = fila.Cells[1].Value?.ToString().ToLower() ?? "";
                string rubro = fila.Cells[2].Value?.ToString().ToLower() ?? "";
                string marca = fila.Cells[3].Value?.ToString().ToLower() ?? "";
                bool coincideTexto = string.IsNullOrEmpty(texto) || codigoBarra.Contains(texto) || descripcion.Contains(texto);
                bool coincideRubro = string.IsNullOrEmpty(rubroSeleccionado) || rubro == rubroSeleccionado;
                bool coincideMarca = string.IsNullOrEmpty(marcaSeleccionada) || marca == marcaSeleccionada;

                fila.Visible = coincideTexto && coincideRubro && coincideMarca;
            }
        }
        private void CargarRubros()
        {
            DataTable tabla = logica.CargarCategoriasActivas();

            DataRow fila = tabla.NewRow();
            fila["IdCategoria"] = 0;
            fila["Nombre"] = "-Seleccione Rubro-";
            tabla.Rows.InsertAt(fila, 0);

            cmbRubro.DataSource = tabla;
            cmbRubro.DisplayMember = "Nombre";
            cmbRubro.ValueMember = "IdCategoria";
        }
        private void CargarMarcas()
        {
            DataTable tabla = logica.CargarMarcasActivas();

            DataRow fila = tabla.NewRow();
            fila["IdMarca"] = 0;
            fila["Nombre"] = "-Seleccione Marca-";
            tabla.Rows.InsertAt(fila, 0);

            cmbMarca.DataSource = tabla;
            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "IdMarca";
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
            AplicarPermisos();
            CargarRubros();
            CargarMarcas();
            CargarArticulos();
        }
        private void dtgCargaarticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgCargaarticulo.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }

            int idProducto = Convert.ToInt32(dtgCargaarticulo.CurrentRow.Tag);

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar el artículo seleccionado?",
                "Eliminar artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            bool eliminado = logica.EliminarProducto(idProducto);

            if (eliminado)
            {
                MessageBox.Show("El artículo fue eliminado correctamente.", "Artículo eliminado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarArticulos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el artículo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDiscontinuar_Click(object sender, EventArgs e)
        {
            if (dtgCargaarticulo.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }

            int idProducto = Convert.ToInt32(dtgCargaarticulo.CurrentRow.Tag);

            if (chkArticulodiscontinaudo.Checked)
            {
                bool activado = logica.ActivarProducto(idProducto);

                if (activado)
                {
                    MessageBox.Show("El artículo fue activado correctamente.", "Artículo activado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarArticulos();
                }
                else
                {
                    MessageBox.Show("No se pudo activar el artículo.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea discontinuar el artículo seleccionado?",
                "Discontinuar artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            bool discontinuado = logica.DescontinuarProducto(idProducto);

            if (discontinuado)
            {
                CargarArticulos();
            }
            else
            {
                MessageBox.Show("No se pudo discontinuar el artículo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkArticulodiscontinaudo_CheckedChanged(object sender, EventArgs e)
        {
            btnDiscontinuar.Text = chkArticulodiscontinaudo.Checked ? "Activar" : "Descontinuar";

            CargarArticulos();
        }
        private void txtBuscarCodigoNombre_TextChanged(object sender, EventArgs e)
        {
            FiltrarArticulos();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarArticulos();

            cmbRubro.SelectedIndex = 0;
            cmbMarca.SelectedIndex = 0;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion







    }
}


