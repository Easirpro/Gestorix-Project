using System;
using System.Threading;
using System.Windows.Forms;
using CapaLogica;
using CapaLogica.BitacoraLogi;

namespace CapaVista
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException +=CurrentDomain_UnhandledException;
            // Idioma de las pantallas elegido la última vez en esta PC.
            ClsIdioma.Cargar();

            if (!PrepararBaseDeDatos())
            {
                return;
            }

            Application.Run(new FrmLogin());
        }

        // Antes del login: SQL Server tiene que responder y la base tiene que existir. En una PC
        // recién instalada la base no existe todavía y se crea desde la base de referencia.
        private static bool PrepararBaseDeDatos()
        {
            ClsBackupLogica backup = new ClsBackupLogica();

            if (!backup.ServidorDisponible(out string error))
            {
                MessageBox.Show(ClsIdioma.T("No se pudo conectar con SQL Server (instancia SQLEXPRESS de esta PC).\n") +
                    ClsIdioma.T("Verifique que SQL Server 2025 Express esté instalado y que su servicio esté iniciado.\n\n") + error,
                    "Gestorix", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (backup.ExisteBase())
            {
                return true;
            }

            using (frmPrepararBase preparar = new frmPrepararBase())
            {
                return preparar.ShowDialog() == DialogResult.OK;
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            RegistrarErrorGlobal(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                RegistrarErrorGlobal(ex);
            }
        }

        private static void RegistrarErrorGlobal(Exception ex)
        {
            try
            {
                clsBitacoraLogica logica = new clsBitacoraLogica();

                logica.RegistrarError(null, "Aplicacion", ex.GetType().FullName ?? ex.GetType().Name, ex.Message, ex.ToString());
            }
            catch
            {
                // Evita que un fallo del registro genere otra excepcion.
            }
        }
    }
}