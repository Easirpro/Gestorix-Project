using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace CapaVista
{
    public partial class frmGestionBackup : Form
    {
        public frmGestionBackup()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            txtRutabk.Text = @"C:\Gestorix\Backups";
            this.CancelButton = btnCancelar;
            CargarBackups();
        }
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog carpeta = new FolderBrowserDialog();
            if (carpeta.ShowDialog() == DialogResult.OK)
            {
                txtRutabk.Text =
                    carpeta.SelectedPath;
            }
        }
        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                ClsBackupLogica backup = new ClsBackupLogica();
                
                bool resultado = backup.GenerarBackup(txtRutabk.Text);
                MessageBox.Show(ClsIdioma.T("Backup generado correctamente en ") + txtRutabk.Text);
                CargarBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarBackups()
        {
            lstBackup.Items.Clear();

            if (!Directory.Exists(txtRutabk.Text))
                return;

            var archivos = Directory.GetFiles(txtRutabk.Text, "*.bak").OrderByDescending(f => new FileInfo(f).CreationTime).ToArray();
            lstBackup.Items.AddRange(archivos);
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarBackups();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            if (lstBackup.SelectedItem == null)
            {
                MessageBox.Show(
                    ClsIdioma.T("Seleccione un backup para restaurar."), ClsIdioma.T("Gestión de Backup"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Avisar antes de pedir confirmación: con la base en otra PC no se puede restaurar.
            try
            {
                if (!new ClsBackupLogica().ServidorEsEstaPc())
                {
                    MessageBox.Show(
                        ClsIdioma.T("La base de datos está en otra PC. Por ahora el backup solo se puede restaurar desde la PC donde está la base."),
                        ClsIdioma.T("Gestión de Backup"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            DialogResult resultado = MessageBox.Show(
                ClsIdioma.T("La restauración reemplazará completamente la información actual de la base de datos.\n") +
                ClsIdioma.T("Todos los cambios realizados después de la fecha del backup seleccionado se perderán.\n") +
                ClsIdioma.T("¿Desea continuar?"),
                ClsIdioma.T("Advertencia"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            
            if (resultado == DialogResult.Yes)
            {
                try
                {
          
                    string archivoBackup = lstBackup.SelectedItem.ToString();

                    ClsBackupLogica backupLogica = new ClsBackupLogica();
                    if (!backupLogica.ValidarHashBackup(archivoBackup))
                    {
                        DialogResult respuesta =
                            MessageBox.Show(ClsIdioma.Ingles ? "WARNING\n\nThis backup does not have a valid Gestorix signature or was modified after it was created.\nThis can happen if the file was received from another team member.\n\nDo you want to continue with the restore?" : @"ADVERTENCIA
                           Este respaldo no posee una firma válida de Gestorix o fue modificado después de ser generado.
                           Esto puede ocurrir si el archivo fue recibido de otro integrante del equipo.
                           ¿Desea continuar con la restauración?",ClsIdioma.T("Advertencia"),

                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (respuesta == DialogResult.No)
                        {
                            return;
                        }
                    }
                    bool exito = backupLogica.RestaurarBackup(archivoBackup);

                    if (exito)
                    {
                        MessageBox.Show(ClsIdioma.T("Backup restaurado correctamente, el sistema se reiniciará."),ClsIdioma.T("Gestión de Backup"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                        Environment.Exit(5);
                    }
                }
                
                catch (Exception ex)
                {
                
                MessageBox.Show(ex.Message,ClsIdioma.T("ERROR AL RESTAURAR"),MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }
    }
}
