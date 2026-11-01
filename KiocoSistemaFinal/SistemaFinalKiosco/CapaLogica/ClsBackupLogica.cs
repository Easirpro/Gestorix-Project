using CapaDatos;
using System.Security.Cryptography;
using System.Text;

namespace CapaLogica
{
    public class ClsBackupLogica
    {
        // Genera el backup en el servidor SQL y lo guarda en la carpeta indicada de esta PC.
        public bool GenerarBackup(string ruta)
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

                datos.GenerarBackupLocal(archivo);

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
        // RESTORE lee el archivo desde el disco del servidor SQL, así que por ahora solo se
        // puede restaurar desde la PC donde está la base.
        public bool ServidorEsEstaPc()
        {
            ClsBackupDatos datos = new ClsBackupDatos();

            return string.Equals(datos.ObtenerNombreServidor(), Environment.MachineName, StringComparison.OrdinalIgnoreCase);
        }
        public bool RestaurarBackup(string archivoBackup)
        {
            try
            {
                if (!ServidorEsEstaPc())
                {
                    throw new Exception("La base de datos está en otra PC. Por ahora el backup solo se puede restaurar desde la PC donde está la base.");
                }

                ClsBackupDatos datos = new ClsBackupDatos();

                datos.RestaurarBackup(archivoBackup);

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
            // Primero se consulta el historial del servidor: con la base compartida alcanza con un
            // backup automático por día entre todas las PCs (no uno por cada PC que abre el sistema).
            bool? enServidor = new ClsBackupDatos().ExisteBackupHoyEnServidor();

            if (enServidor.HasValue)
            {
                return enServidor.Value;
            }

            // Sin acceso a msdb: se revisa la carpeta local como antes.

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