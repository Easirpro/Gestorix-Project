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
    public partial class frmCategoriaMarca : Form
    {
        private const string MODO_CATEGORIAS = "CATEGORIAS";
        private const string MODO_MARCAS = "MARCAS";

        private ClsGestorProductoLogica logica = new ClsGestorProductoLogica();
        private string modoActual = "";

        public frmCategoriaMarca()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            AplicarModo("");
        }

        #region Metodos
        private bool EsCategorias
        {
            get { return modoActual == MODO_CATEGORIAS; }
        }
        private void AplicarModo(string modo)
        {
            if (modoActual == modo && modo != "")
                modo = "";

            modoActual = modo;

            bool modoActivo = modo != "";

            txtNombre.Clear();
            dgvItems.Rows.Clear();

            txtNombre.Enabled = modoActivo;
            btnBuscar.Enabled = modoActivo;
            chkSoloActivos.Enabled = modoActivo;

            btnEliminar.Visible = EsCategorias;

            // Textos segun el modo
            if (EsCategorias)
            {
                lblTitulo.Text = ClsIdioma.T("Categorías");
                btnNuevo.Text = ClsIdioma.T("Nueva categoría");
            }
            else if (modo == MODO_MARCAS)
            {
                lblTitulo.Text = ClsIdioma.T("Marcas");
                btnNuevo.Text = ClsIdioma.T("Nueva marca");
            }
            else
            {
                lblTitulo.Text = ClsIdioma.T("Categorías y marcas");
                btnNuevo.Text = ClsIdioma.T("Nuevo");
            }

            // Estilo de los botones
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnMarcas.FlatStyle = FlatStyle.Flat;

            btnCategorias.UseVisualStyleBackColor = false;
            btnMarcas.UseVisualStyleBackColor = false;

            btnCategorias.BackColor = EsCategorias ? Color.DodgerBlue : SystemColors.Control;
            btnCategorias.ForeColor = EsCategorias ? Color.White : Color.Black;

            btnMarcas.BackColor = modo == MODO_MARCAS ? Color.SeaGreen : SystemColors.Control;
            btnMarcas.ForeColor = modo == MODO_MARCAS ? Color.White : Color.Black;

            // Colores de la grilla
            if (EsCategorias)
            {
                dgvItems.BackgroundColor = Color.AliceBlue;
                dgvItems.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            }
            else if (modo == MODO_MARCAS)
            {
                dgvItems.BackgroundColor = Color.Honeydew;
                dgvItems.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            }
            else
            {
                dgvItems.BackgroundColor = SystemColors.Window;
                dgvItems.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                dgvItems.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            }

            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.DefaultCellStyle.SelectionForeColor = modoActivo ? Color.Black : SystemColors.HighlightText;
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = modoActivo ? Color.White : SystemColors.ControlText;

            AplicarPermisos();

            if (modoActivo)
            {
                CargarDatos();
                txtNombre.Focus();
            }
        }
        private void AplicarPermisos()
        {
            List<int> permisos = SesionUsuario.Permisos;

            btnCategorias.Enabled = permisos.Contains(120) || permisos.Contains(121) || permisos.Contains(122);
            btnMarcas.Enabled = permisos.Contains(130) || permisos.Contains(131) || permisos.Contains(132);

            bool puedeCrear = false;
            bool puedeModificar = false;

            if (EsCategorias)
            {
                puedeCrear = permisos.Contains(121);
                puedeModificar = permisos.Contains(122);
            }
            else if (modoActual == MODO_MARCAS)
            {
                puedeCrear = permisos.Contains(131);
                puedeModificar = permisos.Contains(132);
            }

            btnNuevo.Enabled = puedeCrear;
            btnModificar.Enabled = puedeModificar && (EsCategorias ? ClsDatosSensibles.Rubro : ClsDatosSensibles.Marca);
            btnDiscontinuar.Enabled = puedeModificar;
            btnHabilitar.Enabled = puedeModificar;
            btnEliminar.Enabled = puedeModificar;
        }
        private void CargarDatos()
        {
            if (EsCategorias)
            {
                CargarCategorias();
            }
            else if (modoActual == MODO_MARCAS)
            {
                CargarMarcas();
            }
        }
        private void CargarCategorias()
        {
            DataTable tabla;

            if (chkSoloActivos.Checked)
            {
                tabla = logica.CargarCategoriasActivas();
            }
            else
            {
                tabla = logica.CargarTodasLasCategorias();
            }

            dgvItems.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                bool activo = Convert.ToBoolean(fila["Activo"]);
                int indice = dgvItems.Rows.Add(fila["Nombre"], activo ? ClsIdioma.T("Activo") : ClsIdioma.T("Inactivo"));

                dgvItems.Rows[indice].Tag = fila["IdCategoria"];
            }

            FiltrarCategorias();
        }
        private void FiltrarCategorias()
        {
            string texto = txtNombre.Text.Trim().ToLower();

            foreach (DataGridViewRow fila in dgvItems.Rows)
            {
                if (fila.IsNewRow)
                {
                    continue;
                }

                string nombre = fila.Cells["dgvNombre"].Value?.ToString().ToLower() ?? "";

                fila.Visible = string.IsNullOrEmpty(texto) || nombre.Contains(texto);
            }
        }
        private void CargarMarcas()
        {
            DataTable marcas;

            string nombre = txtNombre.Text.Trim();

            if (!string.IsNullOrEmpty(nombre))
            {
                marcas = logica.BuscarMarcas(nombre, chkSoloActivos.Checked);
            }
            else if (chkSoloActivos.Checked)
            {
                marcas = logica.CargarMarcasActivas();
            }
            else
            {
                marcas = logica.CargarTodasLasMarcas();
            }

            dgvItems.Rows.Clear();

            foreach (DataRow fila in marcas.Rows)
            {
                bool activo = Convert.ToBoolean(fila["Activo"]);
                int indice = dgvItems.Rows.Add(fila["Nombre"], activo ? ClsIdioma.T("Activo") : ClsIdioma.T("Discontinuado"));

                dgvItems.Rows[indice].Tag = fila["IdMarca"];
            }
        }
        private DataGridViewRow ObtenerFilaSeleccionada(string accion)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                string elemento = EsCategorias ? ClsIdioma.T("una categoría") : ClsIdioma.T("una marca");

                MessageBox.Show(ClsIdioma.T("Seleccione ") + elemento + ClsIdioma.T(" para ") + accion + ".", ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return null;
            }

            return dgvItems.SelectedRows[0];
        }
        private bool EsCategoriaProtegida(int idCategoria, string mensaje)
        {
            if (idCategoria >= 1002 && idCategoria <= 1012)
            {
                MessageBox.Show(mensaje, ClsIdioma.T("Categoría protegida"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }

            return false;
        }
        #endregion

        #region Eventos
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AplicarModo(MODO_CATEGORIAS);
        }
        private void btnMarcas_Click(object sender, EventArgs e)
        {
            AplicarModo(MODO_MARCAS);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (EsCategorias)
            {
                FiltrarCategorias();
            }
            else
            {
                CargarMarcas();
            }
        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar_Click(sender, EventArgs.Empty);
            }
        }
        private void chkSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (EsCategorias)
            {
                using (frmNuevoRubro formulario = new frmNuevoRubro())
                {
                    if (formulario.ShowDialog() == DialogResult.OK)
                    {
                        CargarCategorias();
                    }
                }
            }
            else
            {
                using (frmNuevaMarca formulario = new frmNuevaMarca())
                {
                    formulario.ShowDialog();
                }

                CargarMarcas();
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = ObtenerFilaSeleccionada(ClsIdioma.T("modificar"));

            if (fila == null)
            {
                return;
            }

            int id = Convert.ToInt32(fila.Tag);
            string nombre = fila.Cells["dgvNombre"].Value?.ToString();

            if (EsCategorias)
            {
                if (EsCategoriaProtegida(id, ClsIdioma.T("Las categorías predeterminadas del sistema no se pueden modificar.")))
                {
                    return;
                }

                using (frmNuevoRubro formulario = new frmNuevoRubro(id, nombre))
                {
                    if (formulario.ShowDialog() == DialogResult.OK)
                    {
                        CargarCategorias();
                    }
                }
            }
            else
            {
                using (frmNuevaMarca formulario = new frmNuevaMarca())
                {
                    formulario.Text = ClsIdioma.T("Modificar Marca");
                    formulario.IdMarca = id;
                    formulario.NombreMarca = nombre;

                    formulario.ShowDialog();
                }

                CargarMarcas();
            }
        }
        private void btnDiscontinuar_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = ObtenerFilaSeleccionada(ClsIdioma.T("discontinuar"));

            if (fila == null)
            {
                return;
            }

            int id = Convert.ToInt32(fila.Tag);
            string nombre = fila.Cells["dgvNombre"].Value?.ToString();

            if (EsCategorias)
            {
                if (EsCategoriaProtegida(id, ClsIdioma.T("Las categorías predeterminadas del sistema no se pueden desactivar.")))
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Está seguro de desactivar la categoría \"") + nombre + "\"?", ClsIdioma.T("Confirmar"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    if (logica.DesactivarCategoria(id))
                    {
                        CargarCategorias();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ClsIdioma.T("No se pudo desactivar la categoría.\n\n") + ClsIdioma.T(ex.Message),
                        ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Está seguro de discontinuar la marca \"") + nombre + "\"?", ClsIdioma.T("Discontinuar marca"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                if (logica.DesactivarMarca(id))
                {
                    MessageBox.Show(ClsIdioma.T("La marca fue discontinuada correctamente."), ClsIdioma.T("Discontinuar marca"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarMarcas();
                }
            }
        }
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = ObtenerFilaSeleccionada(ClsIdioma.T("habilitar"));

            if (fila == null)
            {
                return;
            }

            int id = Convert.ToInt32(fila.Tag);
            string nombre = fila.Cells["dgvNombre"].Value?.ToString();

            if (EsCategorias)
            {
                if (EsCategoriaProtegida(id, ClsIdioma.T("Las categorías predeterminadas del sistema no necesitan ser habilitadas.")))
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Está seguro de habilitar la categoría \"") + nombre + "\"?", ClsIdioma.T("Confirmar"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    if (logica.HabilitarCategoria(id))
                    {
                        CargarCategorias();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ClsIdioma.T("No se pudo habilitar la categoría.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult respuesta = MessageBox.Show(ClsIdioma.T("¿Está seguro de habilitar la marca \"") + nombre + "\"?", ClsIdioma.T("Habilitar marca"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                if (logica.HabilitarMarca(id))
                {
                    MessageBox.Show(ClsIdioma.T("La marca fue habilitada correctamente."), ClsIdioma.T("Habilitar marca"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarMarcas();
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!EsCategorias)
            {
                return;
            }

            DataGridViewRow fila = ObtenerFilaSeleccionada(ClsIdioma.T("eliminar"));

            if (fila == null)
            {
                return;
            }

            int idCategoria = Convert.ToInt32(fila.Tag);
            string nombre = fila.Cells["dgvNombre"].Value?.ToString();

            if (EsCategoriaProtegida(idCategoria, ClsIdioma.T("Las categorías predeterminadas del sistema no se pueden eliminar.")))
            {
                return;
            }

            // con articulos (aunque esten discontinuados) no se borra, se discontinua
            try
            {
                int articulos = logica.ContarProductosCategoria(idCategoria);

                if (articulos > 0)
                {
                    MessageBox.Show(ClsIdioma.T("La categoría tiene ") + articulos + ClsIdioma.T(" artículo(s), contando los discontinuados, y no se puede eliminar.\n\n") +
                        ClsIdioma.T("Para que no se ofrezca al cargar artículos, presione «Discontinuar»."),
                        ClsIdioma.T("Eliminar categoría"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo eliminar la categoría.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult respuesta = MessageBox.Show((ClsIdioma.Ingles ? $"Are you sure you want to delete the category \"{nombre}\"?" : $"¿Está seguro de eliminar la categoría \"{nombre}\"?"), ClsIdioma.T("Confirmar eliminación"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (logica.EliminarCategoria(idCategoria))
                {
                    CargarCategorias();
                }
                else
                {
                    MessageBox.Show(ClsIdioma.T("No se pudo eliminar la categoría."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo eliminar la categoría.\n\n") + ClsIdioma.T(ex.Message), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
