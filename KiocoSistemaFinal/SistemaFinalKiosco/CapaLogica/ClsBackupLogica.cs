using CapaDatos;
using System.Security.Cryptography;
using System.Text;

namespace CapaLogica
{
    public class ClsBackupLogica
    {
        public const string ArchivoBaseInicial = @"C:\Gestorix\BaseInicial\Gestorix_inicial.bak";

        public bool ServidorDisponible(out string error)
        {
            return new ClsBackupDatos().ServidorDisponible(out error);
        }
        public bool ExisteBase()
        {
            return new ClsBackupDatos().ExisteBase();
        }
                public void CrearBaseInicial(IProgress<int> progreso = null)
        {
            if (!File.Exists(ArchivoBaseInicial))
            {
                throw new Exception("No se encontró la base inicial en " + ArchivoBaseInicial + ". Vuelva a ejecutar el instalador.");
            }

            if (!ValidarHashBackup(ArchivoBaseInicial))
            {
                throw new Exception("La base inicial está dañada o fue modificada (no coincide su firma). Vuelva a ejecutar el instalador.");
            }

            new ClsBackupDatos().CrearBaseDesdeBackup(ArchivoBaseInicial, progreso);
        }
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