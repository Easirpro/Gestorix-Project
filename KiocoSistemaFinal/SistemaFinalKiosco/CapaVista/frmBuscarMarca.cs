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
    public partial class frmBuscarMarca : Form
    {
        public frmBuscarMarca()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.Columns["dgvNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns["dgvNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.Load += frmBuscarMarca_Load;
        }

        #region Metodos

        private void CargarMarcas()
        {
            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            DataTable marcas;

            if (chkSoloActivos.Checked)
            {
                marcas = logica.CargarMarcasActivas();
            }
            else
            {
                marcas = logica.CargarTodasLasMarcas();
            }

            dataGridView1.Rows.Clear();

            foreach (DataRow fila in marcas.Rows)
            {
                string estado;

                if (Convert.ToBoolean(fila["Activo"]))
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "Discontinuado";
                }

                int filaIndex = dataGridView1.Rows.Add(fila["Nombre"], estado);

                dataGridView1.Rows[filaIndex].Tag = fila["IdMarca"];
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarMarca_Load(object sender, EventArgs e)
        {
            CargarMarcas();
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            frmNuevaMarca nuevamarca = new frmNuevaMarca();

            nuevamarca.ShowDialog();

            CargarMarcas();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca para modificar.", "Modificar marca.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idMarca = Convert.ToInt32(dataGridView1.CurrentRow.Tag);

            string nombre = dataGridView1.CurrentRow.Cells["dgvNombre"].Value.ToString();

            frmNuevaMarca modificarMarca = new frmNuevaMarca();

            modificarMarca.Text = "Modificar Marca";
            modificarMarca.IdMarca = idMarca;
            modificarMarca.NombreMarca = nombre;

            modificarMarca.ShowDialog();

            CargarMarcas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            string nombre = textBox1.Text.Trim();

            bool soloActivos = chkSoloActivos.Checked;

            DataTable marcas = logica.BuscarMarcas(nombre, soloActivos);

            dataGridView1.Rows.Clear();

            foreach (DataRow fila in marcas.Rows)
            {
                string estado;

                if (Convert.ToBoolean(fila["Activo"]))
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "Discontinuado";
                }

                int filaIndex = dataGridView1.Rows.Add(fila["Nombre"],estado);

                dataGridView1.Rows[filaIndex].Tag = fila["IdMarca"];
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDiscontinuar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca para discontinuar.", "Discontinuar marca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            int idMarca = Convert.ToInt32(dataGridView1.CurrentRow.Tag);


            string nombreMarca = dataGridView1.CurrentRow.Cells["dgvNombre"].Value.ToString();

            DialogResult resultado = MessageBox.Show("¿Está seguro de discontinuar la marca \"" + nombreMarca + "\"?", "Discontinuar marca",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            bool resultadoDesactivar = logica.DesactivarMarca(idMarca);

            if (resultadoDesactivar)
            {
                MessageBox.Show("La marca fue discontinuada correctamente.", "Discontinuar marca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarMarcas();
            }
        }

        private void chkSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarMarcas();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca para habilitar.", "Habilitar marca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idMarca = Convert.ToInt32(dataGridView1.CurrentRow.Tag);

            string nombreMarca = dataGridView1.CurrentRow.Cells["dgvNombre"].Value.ToString();

            DialogResult resultado = MessageBox.Show("¿Está seguro de habilitar la marca \"" + nombreMarca + "\"?", "Habilitar marca",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

            bool resultadoHabilitar = logica.HabilitarMarca(idMarca);

            if (resultadoHabilitar)
            {
                MessageBox.Show("La marca fue habilitada correctamente.", "Habilitar marca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarMarcas();
            }
        }
    }

    #endregion


}
