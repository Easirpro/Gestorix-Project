using System;
using System.Threading;
using System.Windows.Forms;
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
            Application.Run(new FrmLogin());
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