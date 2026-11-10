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
        private bool trabajando = false;

        public frmGestionBackup()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            txtRutabk.Text = @"C:\Gestorix\Backups";
            this.CancelButton = btnCancelar;
            CargarBackups();
            this.FormClosing += frmGestionBackup_FormClosing;
        }
        private void frmGestionBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trabajando)
            {
                e.Cancel = true;
                MessageBox.Show(ClsIdioma.T("Espere a que termine el backup o la restauración."), ClsIdioma.T("Gestión de Backup"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        private async void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            string ruta = txtRutabk.Text;
            IProgress<int> progreso = MostrarProgreso(pgbGenerarBackup, lblProgresoBackup, ClsIdioma.T("Generando backup..."));

            try
            {
                ClsBackupLogica backup = new ClsBackupLogica();

                await Task.Run(() => backup.GenerarBackup(ruta, progreso));

                MessageBox.Show(ClsIdioma.T("Backup generado correctamente en ") + ruta);
                CargarBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                OcultarProgreso(pgbGenerarBackup, lblProgresoBackup);
            }
        }
       
        private IProgress<int> MostrarProgreso(ProgressBar barra, Label etiqueta, string texto)
        {
            HabilitarBotones(false);

            barra.Value = 0;
            barra.Visible = true;
            etiqueta.Text = texto + " 0%";
            etiqueta.Visible = true;

            return new Progress<int>(porcentaje =>
            {
                barra.Value = porcentaje;
                etiqueta.Text = texto + " " + porcentaje + "%";
            });
        }
        private void OcultarProgreso(ProgressBar barra, Label etiqueta)
        {
            barra.Visible = false;
            etiqueta.Visible = false;

            HabilitarBotones(true);
        }
        private void HabilitarBotones(bool habilitar)
        {
            trabajando = !habilitar;

            btnGenerarBackup.Enabled = habilitar;
            btnRestaurarBackup.Enabled = habilitar;
            btnExaminar.Enabled = habilitar;
            btnActualizar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            lstBackup.Enabled = habilitar;
            txtRutabk.Enabled = habilitar;
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
        private async void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            if (lstBackup.SelectedItem == null)
            {
                MessageBox.Show(
                    ClsIdioma.T("Seleccione un backup para restaurar."), ClsIdioma.T("Gestión de Backup"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                    IProgress<int> progreso = MostrarProgreso(pgbRestaurarBackup, lblProgresoRestaurar, ClsIdioma.T("Restaurando backup..."));

                    bool exito = await Task.Run(() => backupLogica.RestaurarBackup(archivoBackup, progreso));

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
                finally
                {
                    OcultarProgreso(pgbRestaurarBackup, lblProgresoRestaurar);
                }

            }
        }
    }
}
