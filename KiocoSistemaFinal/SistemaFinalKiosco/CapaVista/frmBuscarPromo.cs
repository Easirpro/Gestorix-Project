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
    public partial class frmBuscarPromo : Form
    {
        private readonly ClsPromocionLogica logica = new ClsPromocionLogica();
        private DataView vistaPromociones;
        private bool actualizandoCombo = false;
        public int IdPromocionSeleccionada { get; private set; }


        public frmBuscarPromo()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
        }

        private void frmBuscarPromo_Load_1(object sender, EventArgs e)
        {
            dtgBuscarPromo.RowHeadersVisible = false;

            dtgBuscarPromo.AllowUserToResizeColumns = false;
            dtgBuscarPromo.AllowUserToResizeRows = false;
            dtgBuscarPromo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dtgBuscarPromo.ReadOnly = true;

            dtgBuscarPromo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgBuscarPromo.MultiSelect = false;

            foreach (DataGridViewColumn columna in dtgBuscarPromo.Columns)
            {
                columna.Frozen = false;
            }

            dtgBuscarPromo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgBuscarPromo.Columns["clnCodigo"].FillWeight = 20;
            dtgBuscarPromo.Columns["clnNombre"].FillWeight = 50;
            dtgBuscarPromo.Columns["clnEstado"].FillWeight = 15;
            dtgBuscarPromo.Columns["clnDetalle"].FillWeight = 15;

            CargarPromociones("");

            dtgBuscarPromo.ClearSelection();
        }

        #region Metodos
        private void CargarPromociones(string texto)
        {
            try
            {
                DataTable tabla = logica.BuscarPromociones("");

                if (!tabla.Columns.Contains("TextoMostrar"))
                    tabla.Columns.Add("TextoMostrar", typeof(string));

                if (!tabla.Columns.Contains("TextoBusqueda"))
                    tabla.Columns.Add("TextoBusqueda", typeof(string));

                for (int i = tabla.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow fila = tabla.Rows[i];
                    int idPromocion = Convert.ToInt32(fila["IdPromocion"]);

                    if (!TieneStockSuficiente(idPromocion))
                    {
                        tabla.Rows.RemoveAt(i);
                        continue;
                    }

                    string codigo = fila["CodigoPromocion"].ToString();
                    string nombre = fila["Nombre"].ToString();
                    string descripcion = tabla.Columns.Contains("Descripcion") ? fila["Descripcion"].ToString() : "";

                    fila["TextoMostrar"] = codigo + " - " + nombre;
                    fila["TextoBusqueda"] = codigo + " " + nombre + " " + descripcion;
                }

                actualizandoCombo = true;

                cmbBuscarPromo.DataSource = null;

                vistaPromociones = tabla.DefaultView;
                vistaPromociones.RowFilter = "";

                cmbBuscarPromo.DisplayMember = "TextoMostrar";
                cmbBuscarPromo.ValueMember = "IdPromocion";
                cmbBuscarPromo.DataSource = vistaPromociones;

                cmbBuscarPromo.SelectedIndex = -1;
                cmbBuscarPromo.Text = "";

                dtgBuscarPromo.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("Error al cargar las promociones: ") + ex.Message, ClsIdioma.T("Buscar promociones"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                actualizandoCombo = false;
            }
        }
        private bool TieneStockSuficiente(int idPromocion)
        {
            try
            {
                DataSet datos = logica.ObtenerPromocionPorId(idPromocion);

                if (datos.Tables.Count < 2 || datos.Tables[1].Rows.Count == 0)
                    return false;

                DataRow promo = datos.Tables[0].Rows[0];

                bool esVolumen = promo["CantidadLleva"] != DBNull.Value && promo["CantidadPaga"] != DBNull.Value;

                decimal cantidadLleva = esVolumen ? Convert.ToDecimal(promo["CantidadLleva"]) : 1m;

                var logicaProducto = new ClsGestorProductoLogica();

                foreach (DataRow detalle in datos.Tables[1].Rows)
                {
                    int idProducto = Convert.ToInt32(detalle["IdProducto"]);
                    decimal cantidad = Convert.ToDecimal(detalle["Cantidad"]);

                    if (esVolumen)
                        cantidad *= cantidadLleva;

                    DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

                    if (tablaStock == null || tablaStock.Rows.Count == 0)
                        return false;

                    decimal stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);

                    if (stockDisponible < cantidad)
                        return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }



        #endregion


        #region Eventos
        private void cmbBuscarPromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizandoCombo)
                return;

            if (cmbBuscarPromo.SelectedIndex < 0 || cmbBuscarPromo.SelectedValue == null || !(cmbBuscarPromo.SelectedValue is int))
            {
                dtgBuscarPromo.Rows.Clear();
                return;
            }

            try
            {
                int idPromocion = Convert.ToInt32(cmbBuscarPromo.SelectedValue);
                DataSet datos = logica.ObtenerPromocionPorId(idPromocion);

                dtgBuscarPromo.Rows.Clear();

                if (datos.Tables.Count == 0 || datos.Tables[0].Rows.Count == 0)
                    return;

                DataRow promo = datos.Tables[0].Rows[0];

                string nombresProductos = string.Empty;

                if (datos.Tables.Count > 1)
                {
                    nombresProductos = string.Join(", ", datos.Tables[1].AsEnumerable().Select(fila => fila["NombreProducto"].ToString()));
                }

                int indice = dtgBuscarPromo.Rows.Add();

                dtgBuscarPromo.Rows[indice].Cells["clnCodigo"].Value = promo["CodigoPromocion"];
                dtgBuscarPromo.Rows[indice].Cells["clnNombre"].Value = nombresProductos;
                dtgBuscarPromo.Rows[indice].Cells["clnEstado"].Value = Convert.ToBoolean(promo["Activo"]) ? ClsIdioma.T("Activa") : ClsIdioma.T("Inactiva");
                dtgBuscarPromo.Rows[indice].Tag = idPromocion;
                dtgBuscarPromo.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("Error al cargar el detalle de la promoción: ") + ex.Message, ClsIdioma.T("Buscar promociones"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtgBuscarPromo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            dtgBuscarPromo.ClearSelection();
            dtgBuscarPromo.Rows[e.RowIndex].Selected = true;

            if (dtgBuscarPromo.Columns[e.ColumnIndex].Name == "clnDetalle")
                return;

            dtgBuscarPromo.Rows[e.RowIndex].Cells["clnDetalle"].Selected = false;
        }
        private void cmbBuscarPromo_TextUpdate(object sender, EventArgs e)
        {
            if (vistaPromociones == null || actualizandoCombo)
                return;

            string texto = cmbBuscarPromo.Text;
            int posicion = cmbBuscarPromo.SelectionStart;

            try
            {
                actualizandoCombo = true;

                string busqueda = texto.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    vistaPromociones.RowFilter = "";
                }
                else
                {
                    vistaPromociones.RowFilter = $"TextoBusqueda LIKE '%{busqueda}%'";
                }

                cmbBuscarPromo.SelectedIndex = -1;
                cmbBuscarPromo.Text = texto;
                cmbBuscarPromo.SelectionStart = Math.Min(posicion, cmbBuscarPromo.Text.Length);
                cmbBuscarPromo.SelectionLength = 0;
                cmbBuscarPromo.DroppedDown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("Error al filtrar las promociones: ") + ex.Message, ClsIdioma.T("Buscar promociones"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                actualizandoCombo = false;
            }
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (dtgBuscarPromo.CurrentRow == null || dtgBuscarPromo.CurrentRow.Tag == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccioná una promoción antes de continuar."), ClsIdioma.T("Promociones"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            IdPromocionSeleccionada = Convert.ToInt32(dtgBuscarPromo.CurrentRow.Tag);

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            dtgBuscarPromo.Rows.Clear();
        }
        private void dtgBuscarPromo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dtgBuscarPromo.Columns[e.ColumnIndex].Name != "clnDetalle")
                return;

            try
            {
                string codigo = Convert.ToString(dtgBuscarPromo.Rows[e.RowIndex].Cells["clnCodigo"].Value);

                DataTable tablaPromociones = logica.BuscarPromociones("");

                DataRow[] coincidencias = tablaPromociones.Select("CodigoPromocion = '" + codigo.Replace("'", "''") + "'");

                if (coincidencias.Length == 0)
                {
                    MessageBox.Show(ClsIdioma.T("No se encontró la promoción seleccionada."), ClsIdioma.T("Detalle de la promoción"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPromocion = Convert.ToInt32(coincidencias[0]["IdPromocion"]);

                DataSet datos = logica.ObtenerPromocionPorId(idPromocion);

                if (datos.Tables.Count < 2 || datos.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(ClsIdioma.T("No se encontraron los datos de la promoción."), ClsIdioma.T("Detalle de la promoción"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow promo = datos.Tables[0].Rows[0];
                DataTable detalles = datos.Tables[1];

                StringBuilder mensaje = new StringBuilder();

                mensaje.AppendLine(ClsIdioma.T("PROMOCIÓN"));
                mensaje.AppendLine("--------------------------------");
                mensaje.AppendLine(ClsIdioma.T("Código: ") + promo["CodigoPromocion"]);
                mensaje.AppendLine(ClsIdioma.T("Nombre: ") + promo["Nombre"]);

                if (promo["Descripcion"] != DBNull.Value)
                    mensaje.AppendLine(ClsIdioma.T("Descripción: ") + promo["Descripcion"]);

                mensaje.AppendLine(ClsIdioma.T("Tipo: ") + promo["NombreTipoPromocion"]);
                mensaje.AppendLine();

                mensaje.AppendLine(ClsIdioma.T("PRODUCTOS INCLUIDOS"));
                mensaje.AppendLine("--------------------------------");

                if (detalles.Rows.Count == 0)
                {
                    mensaje.AppendLine(ClsIdioma.T("No hay productos asociados."));
                }
                else
                {
                    foreach (DataRow detalle in detalles.Rows)
                    {
                        mensaje.AppendLine("- " + detalle["NombreProducto"] + ClsIdioma.T(" | Cantidad: ") + detalle["Cantidad"]);
                    }
                }

                mensaje.AppendLine();
                mensaje.AppendLine(ClsIdioma.T("VALOR CONFIGURADO"));
                mensaje.AppendLine("--------------------------------");

                string nombreTipo = Convert.ToString(promo["NombreTipoPromocion"]).ToLowerInvariant();

                decimal valor = Convert.ToDecimal(promo["Valor"]);

                if (nombreTipo.Contains("porcent"))
                {
                    mensaje.AppendLine(ClsIdioma.T("Descuento: ") + valor + "%");
                }
                else if (nombreTipo.Contains("precio"))
                {
                    mensaje.AppendLine(ClsIdioma.T("Precio especial: ") + valor.ToString("C2"));
                }
                else if (promo["CantidadLleva"] != DBNull.Value && promo["CantidadPaga"] != DBNull.Value)
                {
                    int lleva = Convert.ToInt32(promo["CantidadLleva"]);
                    int paga = Convert.ToInt32(promo["CantidadPaga"]);

                    mensaje.AppendLine(ClsIdioma.T("Promoción por cantidad: llevás ") + lleva + ClsIdioma.T(" y pagás ") + paga + ".");
                }
                else
                {
                    mensaje.AppendLine(ClsIdioma.T("Promoción por cantidad o condición especial."));
                }

                mensaje.AppendLine();
                mensaje.AppendLine("VIGENCIA");
                mensaje.AppendLine("--------------------------------");

                if (promo["FechaInicio"] != DBNull.Value)
                {
                    mensaje.AppendLine(ClsIdioma.T("Fecha de inicio: ") + Convert.ToDateTime(promo["FechaInicio"]).ToShortDateString());
                }

                if (promo["FechaFin"] != DBNull.Value)
                {
                    mensaje.AppendLine(ClsIdioma.T("Fecha de fin: ") + Convert.ToDateTime(promo["FechaFin"]).ToShortDateString());
                }

                if (promo["EsRecurrente"] != DBNull.Value && Convert.ToBoolean(promo["EsRecurrente"]))
                {
                    mensaje.AppendLine(ClsIdioma.T("Vigencia recurrente: Sí"));

                    if (promo["HoraInicio"] != DBNull.Value && promo["HoraFin"] != DBNull.Value)
                    {
                        mensaje.AppendLine(ClsIdioma.T("Horario: ") + promo["HoraInicio"] + " a " + promo["HoraFin"]);
                    }

                    if (datos.Tables.Count >= 3 && datos.Tables[2].Rows.Count > 0)
                    {
                        string[] dias = datos.Tables[2].AsEnumerable().Select(f => Convert.ToString(f["DiaSemana"])).ToArray();

                        mensaje.AppendLine(ClsIdioma.T("Días: ") + string.Join(", ", dias));
                    }
                }

                MessageBox.Show(mensaje.ToString(), ClsIdioma.T("Detalle de la promoción"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("Error al mostrar el detalle: ") + ex.Message, ClsIdioma.T("Detalle de la promoción"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion








    }
}
