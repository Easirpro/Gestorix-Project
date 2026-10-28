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
                MessageBox.Show("Backup generado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR",
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
                    "Seleccione un backup para restaurar.", "Gestión de Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            DialogResult resultado = MessageBox.Show(
                "La restauración reemplazará completamente la información actual de la base de datos.\n" +
                "Todos los cambios realizados después de la fecha del backup seleccionado se perderán.\n" +
                "¿Desea continuar?",
                "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            
            if (resultado == DialogResult.Yes)
            {
                try
                {
          
                    string archivoBackup = lstBackup.SelectedItem.ToString();

                    ClsBackupLogica backupLogica = new ClsBackupLogica();
                    if (!backupLogica.ValidarHashBackup(archivoBackup))
                    {
                        DialogResult respuesta =
                            MessageBox.Show(@"ADVERTENCIA
                           Este respaldo no posee una firma válida de Gestorix o fue modificado después de ser generado.
                           Esto puede ocurrir si el archivo fue recibido de otro integrante del equipo.
                           ¿Desea continuar con la restauración?","Advertencia",

                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (respuesta == DialogResult.No)
                        {
                            return;
                        }
                    }
                    bool exito = backupLogica.RestaurarBackup(archivoBackup);

                    if (exito)
                    {
                        MessageBox.Show("Backup restaurado correctamente, el sistema se reiniciará.","Gestión de Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                        Environment.Exit(5);
                    }
                }
                
                catch (Exception ex)
                {
                
                MessageBox.Show(ex.Message,"ERROR AL RESTAURAR",MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }
    }
}
