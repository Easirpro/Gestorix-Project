using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using SistemaKiosco;

namespace CapaLogica
{
    public class ClsBackupLogica
    {
        public bool GenerarBackup(string ruta)
        {
            Conexion conexion = new Conexion();

            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                
                string fecha =
                    DateTime.Now.ToString("dd-MM-yyyy_HHmmss");

                string archivo = Path.Combine(ruta,$"Gestorix_{fecha}.bak");

                string sql =
                $@"BACKUP DATABASE Gestorix
                   TO DISK='{archivo}'
                   WITH FORMAT";

                using (SqlConnection cn =
                       conexion.ObtenerConexionMaster())
                {
                    cn.Open();

                    using (SqlCommand cmd =
                           new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RestaurarBackup(string archivoBackup)
        {
            Conexion conexion = new Conexion();

            try
            {
                using (SqlConnection cn =
                    conexion.ObtenerConexionMaster())
                {
                    cn.Open();

                    string sql = $@"USE master;ALTER DATABASE Gestorix SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE Gestorix 
                    FROM DISK = '{archivoBackup}'WITH REPLACE;
                    ALTER DATABASE Gestorix SET MULTI_USER;";

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                    }
                }

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