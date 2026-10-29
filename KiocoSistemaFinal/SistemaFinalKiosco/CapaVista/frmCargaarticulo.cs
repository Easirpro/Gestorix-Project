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
        private bool formularioCargado = false;

        ClsGestorProductoLogica logica = new ClsGestorProductoLogica();

        public frmCargaarticulo()
        {
            InitializeComponent();

            dtgCargaarticulo.AutoGenerateColumns = false;
            dtgCargaarticulo.ReadOnly = true;

            dtgCargaarticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCargaarticulo.MultiSelect = false;

            dtgCargaarticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgCargaarticulo.AllowUserToResizeColumns = false;
            dtgCargaarticulo.AllowUserToOrderColumns = false;
            dtgCargaarticulo.RowHeadersVisible = false;
            dtgCargaarticulo.Columns["clnCodigo"].FillWeight = 80;
            dtgCargaarticulo.Columns["clnDescripcion"].FillWeight = 200;
            dtgCargaarticulo.Columns["clnRubro"].FillWeight = 100;
            dtgCargaarticulo.Columns["clnMarca"].FillWeight = 100;
            dtgCargaarticulo.Columns["clnPrecioVenta"].FillWeight = 90;
            dtgCargaarticulo.Columns["clnStockActual"].FillWeight = 90;
            dtgCargaarticulo.Columns["clnDetalle"].FillWeight = 90;

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
                bool activo = Convert.ToBoolean(fila["Activo"]);

                if (chkArticulodiscontinaudo.Checked && activo)
                    continue;

                if (!chkArticulodiscontinaudo.Checked && !activo)
                    continue;

                int indice = dtgCargaarticulo.Rows.Add();

                DataGridViewRow filaGrilla = dtgCargaarticulo.Rows[indice];

                filaGrilla.Tag = fila["IdProducto"];
                filaGrilla.Cells["clnCodigo"].Value = fila["CodigoBarra"];
                filaGrilla.Cells["clnDescripcion"].Value = fila["Descripcion"];
                filaGrilla.Cells["clnRubro"].Value = fila["Rubro"];
                filaGrilla.Cells["clnMarca"].Value = fila["Marca"];
                filaGrilla.Cells["clnPrecioVenta"].Value = fila["PrecioVenta"] == DBNull.Value ? 0m : Convert.ToDecimal(fila["PrecioVenta"]);
                filaGrilla.Cells["clnStockActual"].Value = fila["CantidadActual"] == DBNull.Value ? 0m : Convert.ToDecimal(fila["CantidadActual"]);

            }

            FiltrarArticulos();
        }
        private void AplicarPermisos()
        {
            bool puedeCrear = SesionUsuario.Permisos.Contains(100) || SesionUsuario.Permisos.Contains(111);
            bool puedeModificar = SesionUsuario.Permisos.Contains(100) || SesionUsuario.Permisos.Contains(112);

            //btnNuevoArticulo.Enabled = puedeCrear;
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

            dtgCargaarticulo.Rows.Clear();

            formularioCargado = true;
        }
        private void dtgCargaarticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dtgCargaarticulo.Columns[e.ColumnIndex].Name != "clnDetalle")
                return;

            object valorId = dtgCargaarticulo.Rows[e.RowIndex].Tag;

            if (valorId == null || !int.TryParse(valorId.ToString(), out int idProducto))
            {
                MessageBox.Show(
                    "No se pudo identificar el artículo seleccionado.", "Gestorix",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tabla = logica.CargarArticulos();
            DataRow detalle = null;

            foreach (DataRow fila in tabla.Rows)
            {
                if (Convert.ToInt32(fila["IdProducto"]) == idProducto)
                {
                    detalle = fila;
                    break;
                }
            }

            if (detalle == null)
            {
                MessageBox.Show("No se encontró el artículo.", "Gestorix");
                return;
            }

            string ObtenerTexto(string columna)
            {
                if (!tabla.Columns.Contains(columna) || detalle[columna] == DBNull.Value)
                    return "No disponible";

                return detalle[columna].ToString();
            }

            string mensaje =
                $"Código: {ObtenerTexto("CodigoBarra")}\n" +
                $"Descripción: {ObtenerTexto("Descripcion")}\n" +
                $"Rubro: {ObtenerTexto("Rubro")}\n" +
                $"Marca: {ObtenerTexto("Marca")}\n" +
                $"Proveedor: {ObtenerTexto("Proveedor")}\n" +
                $"Sucursal: {ObtenerTexto("Sucursal")}\n" +
                $"Precio de costo: {ObtenerTexto("PrecioCosto")}\n" +
                $"Precio de venta: {ObtenerTexto("PrecioVenta")}\n" +
                $"IVA: {ObtenerTexto("IVA")}\n" +
                $"Alícuota: {ObtenerTexto("Alicuota")}\n" +
                $"Stock actual: {ObtenerTexto("CantidadActual")}\n" +
                $"Stock mínimo: {ObtenerTexto("StockMinimo")}\n" +
                $"Stock ideal: {ObtenerTexto("StockIdeal")}\n" +
                $"Vencimiento: {ObtenerTexto("FechaVencimiento")}\n" +
                $"Estado: {(Convert.ToBoolean(detalle["Activo"]) ? "Activo" : "Discontinuado")}";

            MessageBox.Show(mensaje, "Detalle del artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            object valorId = dtgCargaarticulo.CurrentRow.Tag;

            if (valorId == null || !int.TryParse(valorId.ToString(), out int idProducto))
            {
                MessageBox.Show("No se pudo identificar el artículo seleccionado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool estaDiscontinuado = chkArticulodiscontinaudo.Checked;

            string mensaje = estaDiscontinuado ? "¿Desea volver a activar este artículo?" : "¿Desea discontinuar este artículo?";

            DialogResult respuesta = MessageBox.Show(mensaje, estaDiscontinuado ? "Activar artículo" : "Descontinuar artículo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                bool resultado = estaDiscontinuado ? logica.ActivarProducto(idProducto) : logica.DescontinuarProducto(idProducto);

                if (resultado)
                {
                    MessageBox.Show(estaDiscontinuado ? "El artículo fue activado correctamente." : "El artículo fue discontinuado correctamente.", "Operación exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarArticulos();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado del artículo.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cambiar el estado del artículo.\n\nDetalle: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkArticulodiscontinaudo_CheckedChanged(object sender, EventArgs e)
        {
            btnDiscontinuar.Text = chkArticulodiscontinaudo.Checked ? "Activar" : "Descontinuar";
        }
        private void txtBuscarCodigoNombre_TextChanged(object sender, EventArgs e)
        {
            if (formularioCargado && dtgCargaarticulo.Rows.Count > 0)
                FiltrarArticulos();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarArticulos();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formularioCargado)
                FiltrarArticulos();
        }
        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formularioCargado)
                FiltrarArticulos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }


        #endregion









    }
}


