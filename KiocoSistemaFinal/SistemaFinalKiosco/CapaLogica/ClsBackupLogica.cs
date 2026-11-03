using CapaDatos;
using System.Security.Cryptography;
using System.Text;

namespace CapaLogica
{
    public class ClsBackupLogica
    {
        // Genera el backup de la base local en la carpeta indicada.
        public bool GenerarBackup(string ruta, IProgress<int> progreso = null)
        {
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                string fecha =
                    DateTime.Now.ToString("dd-MM-yyyy_HHmmss");

                string archivo = Path.Combine(ruta,$"Gestorix_{fecha}.bak");

                ClsBackupDatos datos = new ClsBackupDatos();

                datos.GenerarBackup(archivo, progreso);

                string hash = CalcularHashArchivo(archivo);

                File.WriteAllText(archivo + ".hash",hash);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string CalcularHashArchivo(string rutaArchivo)
        {
            using (FileStream stream =
                   File.OpenRead(rutaArchivo))
            {
                using (SHA256 sha =
                       SHA256.Create())
                {
                    byte[] hash =
                        sha.ComputeHash(stream);

                    return Convert.ToHexString(hash);
                }
            }
        }
        public bool ValidarHashBackup(string archivoBackup)
        {
            string archivoHash = archivoBackup + ".hash";

            if (!File.Exists(archivoHash))
                return false;

            string hashGuardado =File.ReadAllText(archivoHash);

            string hashActual =CalcularHashArchivo(archivoBackup);

            return hashGuardado == hashActual;
        }
        public bool RestaurarBackup(string archivoBackup, IProgress<int> progreso = null)
        {
            try
            {
                ClsBackupDatos datos = new ClsBackupDatos();

                datos.RestaurarBackup(archivoBackup, progreso);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarBackupsAntiguos(string ruta)
        {
            if (!Directory.Exists(ruta))
                return;

            string[] archivos =
                Directory.GetFiles(ruta,"*.bak");

            foreach (string archivo in archivos)
            {
                FileInfo info = new FileInfo(archivo);

                if (info.CreationTime < DateTime.Now.AddDays(-7))
                {
                    File.Delete(archivo);

                    // Borrar también la firma del backup para que no quede suelta.
                    if (File.Exists(archivo + ".hash"))
                    {
                        File.Delete(archivo + ".hash");
                    }
                }
            }
        }
        public void BackupAutomatico()
        {
            string ruta = @"C:\Gestorix\Backups";

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            if (!ExisteBackupHoy(ruta))
            {
                GenerarBackup(ruta);
            }

            EliminarBackupsAntiguos(ruta);
        }
        public bool ExisteBackupHoy(string ruta)
        {
            if (!Directory.Exists(ruta))
                return false;

            string[] archivos =
                Directory.GetFiles(ruta, "*.bak");

            foreach (string archivo in archivos)
            {
                FileInfo info =
                    new FileInfo(archivo);

                if (info.CreationTime.Date ==
                    DateTime.Today)
                {
                    return true;
                }
            }

            return false;
        }

    }

}