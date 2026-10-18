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

                foreach (DataRow fila in tabla.Rows)
                {
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
                MessageBox.Show("Error al cargar las promociones: " + ex.Message, "Buscar promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                actualizandoCombo = false;
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
                dtgBuscarPromo.Rows[indice].Cells["clnEstado"].Value = Convert.ToBoolean(promo["Activo"]) ? "Activa" : "Inactiva";
                dtgBuscarPromo.Rows[indice].Tag = idPromocion;
                dtgBuscarPromo.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la promoción: " + ex.Message, "Buscar promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtgBuscarPromo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            dtgBuscarPromo.ClearSelection();
            dtgBuscarPromo.Rows[e.RowIndex].Selected = true;

            if (dtgBuscarPromo.Columns[e.ColumnIndex].Name == "clnDetalle")
            {
                object valor = dtgBuscarPromo.Rows[e.RowIndex].Tag;

                if (valor == null)
                {
                    MessageBox.Show("Primero buscá y seleccioná una promoción.", "Promociones",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IdPromocionSeleccionada = Convert.ToInt32(valor);
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

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
                MessageBox.Show("Error al filtrar las promociones: " + ex.Message, "Buscar promociones",
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
                MessageBox.Show("Seleccioná una promoción antes de continuar.", "Promociones",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            IdPromocionSeleccionada = Convert.ToInt32(dtgBuscarPromo.CurrentRow.Tag);

            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion







    }
}
