using CapaEntidades;
using CapaLogica;
using CapaSesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVista
{
    // Muestra los registros de Producto, Usuario y Venta cuyo DVH no coincide con sus datos.
    // El administrador puede dar los datos por buenos (recalcular) o volver a un backup.
    public partial class frmVerificarIntegridad : Form
    {
        private ClsIntegridadLogica logica = new ClsIntegridadLogica();

        public frmVerificarIntegridad() : this(null)
        {
        }
        // Desde el login se pasa la verificación ya hecha, para no repetirla al abrir.
        public frmVerificarIntegridad(List<ClsInconsistenciaDVH> inconsistencias)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            this.CancelButton = btnCerrar;

            this.Shown += (s, e) =>
            {
                if (inconsistencias == null)
                {
                    Verificar();
                }
                else
                {
                    MostrarResultado(inconsistencias);
                }
            };
        }
        private void Verificar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                MostrarResultado(logica.Verificar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo verificar la integridad de la base de datos.\n\n") + ClsIdioma.T(ex.Message),
                    ClsIdioma.T("Verificar integridad"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void MostrarResultado(List<ClsInconsistenciaDVH> inconsistencias)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Tabla", typeof(string));
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Registro", typeof(string));
            tabla.Columns.Add("Problema", typeof(string));

            foreach (ClsInconsistenciaDVH inconsistencia in inconsistencias)
            {
                tabla.Rows.Add(inconsistencia.Tabla, inconsistencia.IdRegistro, inconsistencia.Registro, inconsistencia.Problema);
            }

            dgvInconsistencias.DataSource = tabla;
            dgvInconsistencias.Columns["Tabla"].FillWeight = 15;
            dgvInconsistencias.Columns["Id"].FillWeight = 8;
            dgvInconsistencias.Columns["Registro"].FillWeight = 35;
            dgvInconsistencias.Columns["Problema"].FillWeight = 42;

            if (inconsistencias.Count == 0)
            {
                lblResultado.ForeColor = Color.DarkGreen;
                lblResultado.Text = ClsIdioma.T("La base de datos está íntegra: todos los registros coinciden con su DVH.");
            }
            else
            {
                lblResultado.ForeColor = Color.DarkRed;
                lblResultado.Text = ClsIdioma.T("Se encontraron registros modificados por fuera del sistema: ") + inconsistencias.Count;
            }

            btnRecalcular.Enabled = inconsistencias.Count > 0;
        }
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            Verificar();
        }
        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                ClsIdioma.T("Se van a dar por válidos los datos actuales y se recalculará el DVH de todos los registros.\n") +
                ClsIdioma.T("Hágalo solo si revisó los registros de la lista y sus datos son correctos.\n\n¿Desea continuar?"),
                ClsIdioma.T("Recalcular DVH"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                logica.RecalcularTodo(SesionUsuario.IdUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo recalcular el DVH.\n\n") + ClsIdioma.T(ex.Message),
                    ClsIdioma.T("Recalcular DVH"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            Verificar();
        }
        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            using (frmGestionBackup backup = new frmGestionBackup())
            {
                backup.ShowDialog(this);
            }

            Verificar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
