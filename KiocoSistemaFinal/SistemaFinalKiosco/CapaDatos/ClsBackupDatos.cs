using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Data;
using System.IO;

namespace CapaDatos
{
    // BACKUP y RESTORE siempre trabajan con el disco de la PC donde corre SQL Server.
    // Como la base está en la PC de un compañero, el backup se genera en una carpeta del
    // servidor y después se descarga a la PC que lo pidió con OPENROWSET(BULK).
    //
    // Permisos que necesita el usuario de la conexión:
    //   - BACKUP DATABASE en Gestorix (rol db_backupoperator o db_owner).
    //   - ADMINISTER BULK OPERATIONS en el servidor (rol bulkadmin) para leer el archivo.
    //   - Para restaurar: rol dbcreator (o sysadmin).
    public class ClsBackupDatos
    {
        private Conexion cn = new Conexion();

        public void GenerarBackupLocal(string archivoLocal)
        {
            using (SqlConnection conexion = cn.ObtenerConexionMaster())
            {
                conexion.Open();

                string archivoServidor = ObtenerRutaServidor(conexion);

                using (SqlCommand cmd = new SqlCommand(
                    "BACKUP DATABASE Gestorix TO DISK = @Archivo WITH FORMAT, INIT, COPY_ONLY", conexion))
                {
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Archivo", archivoServidor);
                    cmd.ExecuteNonQuery();
                }

                DescargarArchivo(conexion, archivoServidor, archivoLocal);
            }
        }

        public void RestaurarBackup(string archivoBackup)
        {
            using (SqlConnection conexion = cn.ObtenerConexionMaster())
            {
                conexion.Open();

                // SINGLE_USER desconecta a todos los que estén usando la base.
                string sql = @"
                    ALTER DATABASE Gestorix SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE Gestorix FROM DISK = @Archivo WITH REPLACE;
                    ALTER DATABASE Gestorix SET MULTI_USER;";

                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Archivo", archivoBackup);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Nombre de la PC donde corre SQL Server.
        public string ObtenerNombreServidor()
        {
            using (SqlConnection conexion = cn.ObtenerConexionMaster())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT CAST(SERVERPROPERTY('MachineName') AS NVARCHAR(128))", conexion))
                {
                    return cmd.ExecuteScalar()?.ToString() ?? "";
                }
            }
        }

        // Carpeta de backups por defecto de la instancia; si no está configurada,
        // la carpeta donde están los archivos de datos de la base.
        private string ObtenerRutaServidor(SqlConnection conexion)
        {
            string sql = @"
                SELECT COALESCE(
                    CAST(SERVERPROPERTY('InstanceDefaultBackupPath') AS NVARCHAR(260)),
                    (
                        SELECT TOP 1
                            LEFT(physical_name, LEN(physical_name) - CHARINDEX('\', REVERSE(physical_name)) + 1)
                        FROM Gestorix.sys.database_files
                        WHERE type = 0
                    ))";

            using (SqlCommand cmd = new SqlCommand(sql, conexion))
            {
                object resultado = cmd.ExecuteScalar();

                if (resultado == null || resultado == DBNull.Value)
                {
                    throw new Exception("No se pudo obtener una carpeta del servidor para generar el backup.");
                }

                // Un archivo por PC: si dos PCs hacen backup a la vez no se pisan entre sí.
                // Se reutiliza en cada backup para no acumular archivos en el servidor.
                string archivo = "Gestorix_transferencia_" + Environment.MachineName + ".bak";

                return resultado.ToString().TrimEnd('\\') + "\\" + archivo;
            }
        }

        private void DescargarArchivo(SqlConnection conexion, string archivoServidor, string archivoLocal)
        {
            // OPENROWSET(BULK) no acepta parámetros: la ruta se arma con las comillas escapadas.
            string sql = "SELECT BulkColumn FROM OPENROWSET(BULK N'" + archivoServidor.Replace("'", "''") + "', SINGLE_BLOB) AS archivo";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    cmd.CommandTimeout = 0;

                    using (SqlDataReader lector = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        if (!lector.Read())
                        {
                            throw new Exception("El servidor no devolvió el archivo de backup.");
                        }

                        using (Stream origen = lector.GetStream(0))
                        using (FileStream destino = File.Create(archivoLocal))
                        {
                            origen.CopyTo(destino);
                        }
                    }
                }
            }
            catch
            {
                // No dejar un .bak incompleto en la PC.
                if (File.Exists(archivoLocal))
                {
                    File.Delete(archivoLocal);
                }

                throw;
            }
        }
    }
}
