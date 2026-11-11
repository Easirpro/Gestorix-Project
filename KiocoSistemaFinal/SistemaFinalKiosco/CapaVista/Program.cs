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

        private static bool mostrandoError;

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            RegistrarErrorGlobal(e.Exception);
            AvisarError(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                RegistrarErrorGlobal(ex);
                AvisarError(ex);
            }
        }

        // antes el error solo se registraba y el usuario no se enteraba
        private static void AvisarError(Exception ex)
        {
            // evita encadenar avisos si el mismo error se repite mientras el mensaje esta abierto
            if (mostrandoError)
            {
                return;
            }

            mostrandoError = true;

            try
            {
                MessageBox.Show(ClsIdioma.T("Ocurrió un error inesperado y la operación no se completó.\n\n") + ClsIdioma.T(ex.Message) + "\n\n" +
                    ClsIdioma.T("El detalle quedó registrado en la bitácora (Errores técnicos)."),
                    ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
            }
            finally
            {
                mostrandoError = false;
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
            }
        }
    }
}