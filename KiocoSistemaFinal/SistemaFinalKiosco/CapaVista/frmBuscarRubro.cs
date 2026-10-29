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
    public partial class frmBuscarRubro : Form
    {
        ClsGestorProductoLogica logica = new ClsGestorProductoLogica();
        public frmBuscarRubro()
        {
            InitializeComponent();

            dgtRubro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgtRubro.MultiSelect = false;
            dgtRubro.RowHeadersVisible = false;
            dgtRubro.ReadOnly = true;

            AplicarPermisos();

            CargarRubros();
        }

        #region Metodos
        private void CargarRubros()
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

            dgtRubro.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                bool activo = Convert.ToBoolean(fila["Activo"]);
                int indice = dgtRubro.Rows.Add(fila["Nombre"], activo ? "Activo" : "Inactivo");

                dgtRubro.Rows[indice].Tag = fila["IdCategoria"];
            }
        }
        private void FiltrarRubros()
        {
            string texto = txtNombreRubro.Text.Trim().ToLower();

            foreach (DataGridViewRow fila in dgtRubro.Rows)
            {
                if (fila.IsNewRow)
                {
                    continue;
                }

                string nombre = fila.Cells["dgvNombre"].Value?.ToString().ToLower() ?? "";

                fila.Visible = string.IsNullOrEmpty(texto) || nombre.Contains(texto);
            }
        }
        private void AplicarPermisos()
        {
            bool puedeCrear = SesionUsuario.Permisos.Contains(121);
            bool puedeModificar = SesionUsuario.Permisos.Contains(122);

            btnNuevoRubro.Enabled = puedeCrear;

            Modificar.Enabled = puedeModificar;
            btnDiscontinuar.Enabled = puedeModificar;
            btnHabilitar.Enabled = puedeModificar;
            btnEliminar.Enabled = puedeModificar;
        }

        #endregion

        #region Eventos
        private void btnNuevoRubro_Click(object sender, EventArgs e)
        {
            using (frmNuevoRubro formulario = new frmNuevoRubro())
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    CargarRubros();
                }
            }
        }
        private void chkSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarRubros();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarRubros();
        }
        private void Modificar_Click(object sender, EventArgs e)
        {
            if (dgtRubro.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dgtRubro.SelectedRows[0];

            int idCategoria = Convert.ToInt32(fila.Tag);
            string nombre = fila.Cells["dgvNombre"].Value?.ToString();

            if (idCategoria >= 1002 && idCategoria <= 1012)
            {
                MessageBox.Show("Las categorías predeterminadas del sistema no se pueden modificar.", "Categoría protegida",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            using (frmNuevoRubro formulario = new frmNuevoRubro(idCategoria, nombre))
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    CargarRubros();
                }
            }

        }
        private void btnDiscontinuar_Click(object sender, EventArgs e)
        {
            if (dgtRubro.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dgtRubro.SelectedRows[0];

            int idCategoria = Convert.ToInt32(fila.Tag);

            if (idCategoria >= 1002 && idCategoria <= 1012)
            {
                MessageBox.Show("Las categorías predeterminadas del sistema no se pueden desactivar.",
                    "Categoría protegida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de desactivar la categoría seleccionada?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                if (logica.DesactivarCategoria(idCategoria))
                {
                    CargarRubros();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo desactivar la categoría.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (dgtRubro.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dgtRubro.SelectedRows[0];

            int idCategoria = Convert.ToInt32(fila.Tag);

            if (idCategoria >= 1002 && idCategoria <= 1012)
            {
                MessageBox.Show("Las categorías predeterminadas del sistema no necesitan ser habilitadas.",
                    "Categoría protegida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de habilitar la categoría seleccionada?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }


            try
            {
                if (logica.HabilitarCategoria(idCategoria))
                {
                    CargarRubros();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo habilitar la categoría.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgtRubro.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dgtRubro.SelectedRows[0];

            int idCategoria = Convert.ToInt32(fila.Tag);
            string nombre = fila.Cells["dgvNombre"].Value?.ToString();

            if (idCategoria >= 1002 && idCategoria <= 1012)
            {
                MessageBox.Show("Las categorías predeterminadas del sistema no se pueden eliminar.", "Categoría protegida",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            DialogResult respuesta = MessageBox.Show($"¿Está seguro de eliminar la categoría \"{nombre}\"?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }


            try
            {
                if (logica.EliminarCategoria(idCategoria))
                {
                    CargarRubros();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la categoría.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la categoría.\n\n" + ex.Message, "Error",
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
