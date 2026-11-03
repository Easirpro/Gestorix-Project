using CapaLogica;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    // Primera vez en una PC: crea la base Gestorix desde la base de referencia que deja el
    // instalador, mostrando el avance. Devuelve OK si la base quedó creada.
    public partial class frmPrepararBase : Form
    {
        public frmPrepararBase()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.Shown += frmPrepararBase_Shown;
        }
        private async void frmPrepararBase_Shown(object? sender, EventArgs e)
        {
            IProgress<int> progreso = new Progress<int>(porcentaje =>
            {
                pgbProgreso.Value = porcentaje;
                lblPorcentaje.Text = porcentaje + "%";
            });

            try
            {
                ClsBackupLogica backup = new ClsBackupLogica();

                await Task.Run(() => backup.CrearBaseInicial(progreso));

                MessageBox.Show(ClsIdioma.T("La base de datos se creó correctamente."), "Gestorix",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo crear la base de datos.\n\n") + ex.Message, "Gestorix",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
