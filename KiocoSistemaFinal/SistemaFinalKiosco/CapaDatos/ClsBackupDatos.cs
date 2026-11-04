using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    
    public class ClsBackupDatos
    {
        private Conexion cn = new Conexion();

       
        private const int MensajePorcentaje = 3211;

        public void GenerarBackup(string archivo, IProgress<int> progreso = null)
        {
            EjecutarConProgreso(
                "BACKUP DATABASE Gestorix TO DISK = @Archivo WITH FORMAT, INIT, STATS = 5",
                archivo, progreso);
        }

        public void RestaurarBackup(string archivoBackup, IProgress<int> progreso = null)
        {
            
            string sql = @"
                ALTER DATABASE Gestorix SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE Gestorix FROM DISK = @Archivo WITH REPLACE, STATS = 5;
                ALTER DATABASE Gestorix SET MULTI_USER;";

            EjecutarConProgreso(sql, archivoBackup, progreso);
        }

       
        public bool ServidorDisponible(out string error)
        {
            try
            {
                using (SqlConnection conexion = cn.ObtenerConexionMaster())
                {
                    conexion.Open();
                }

                error = null;
                return true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool ExisteBase()
        {
            using (SqlConnection conexion = cn.ObtenerConexionMaster())
            using (SqlCommand cmd = new SqlCommand("SELECT CASE WHEN DB_ID('Gestorix') IS NULL THEN 0 ELSE 1 END", conexion))
            {
                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
        }

        public void CrearBaseDesdeBackup(string archivoBackup, IProgress<int> progreso = null)
        {
            List<(string Nombre, string Destino)> archivos = new List<(string, string)>();
            bool hayDatos = false;

            using (SqlConnection conexion = cn.ObtenerConexionMaster())
            {
                conexion.Open();

                string carpetaDatos;
                string carpetaLog;

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT CAST(SERVERPROPERTY('InstanceDefaultDataPath') AS NVARCHAR(260)), CAST(SERVERPROPERTY('InstanceDefaultLogPath') AS NVARCHAR(260))", conexion))
                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    lector.Read();
                    carpetaDatos = lector.GetString(0);
                    carpetaLog = lector.GetString(1);
                }

                using (SqlCommand cmd = new SqlCommand("RESTORE FILELISTONLY FROM DISK = @Archivo", conexion))
                {
                    cmd.Parameters.AddWithValue("@Archivo", archivoBackup);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string nombre = lector["LogicalName"].ToString();
                            bool esLog = lector["Type"].ToString() == "L";

                            string destino = Path.Combine(esLog ? carpetaLog : carpetaDatos,
                                esLog ? "Gestorix_log.ldf" : (hayDatos ? "Gestorix_" + nombre + ".ndf" : "Gestorix.mdf"));

                            hayDatos |= !esLog;

                            archivos.Add((nombre, destino));
                        }
                    }
                }
            }

            string mover = string.Join(", ", archivos.Select((a, i) => "MOVE @Nombre" + i + " TO @Destino" + i));

            EjecutarConProgreso("RESTORE DATABASE Gestorix FROM DISK = @Archivo WITH " + mover + ", STATS = 5",
                archivoBackup, progreso, cmd =>
                {
                    for (int i = 0; i < archivos.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@Nombre" + i, archivos[i].Nombre);
                        cmd.Parameters.AddWithValue("@Destino" + i, archivos[i].Destino);
                    }
                });
        }

        private void EjecutarConProgreso(string sql, string archivo, IProgress<int> progreso, Action<SqlCommand> masParametros = null)
        {
            List<string> errores = new List<string>();

            using (SqlConnection conexion = cn.ObtenerConexionMaster())
            {
                conexion.FireInfoMessageEventOnUserErrors = true;

                conexion.InfoMessage += (sender, e) =>
                {
                    foreach (SqlError mensaje in e.Errors)
                    {
                        if (mensaje.Class > 10)
                        {
                            errores.Add(mensaje.Message);
                        }
                        else if (mensaje.Number == MensajePorcentaje && progreso != null)
                        {
                            Match numero = Regex.Match(mensaje.Message, @"\d+");

                            if (numero.Success)
                            {
                                progreso.Report(Math.Min(100, int.Parse(numero.Value)));
                            }
                        }
                    }
                };

                conexion.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Archivo", archivo);
                    masParametros?.Invoke(cmd);
                    cmd.ExecuteNonQuery();
                }
            }

            if (errores.Count > 0)
            {
                throw new Exception(string.Join(Environment.NewLine, errores));
            }
        }
    }
}
