using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    // BACKUP y RESTORE trabajan con el disco de la PC donde corre SQL Server, que es esta
    // misma PC porque la base es local. El servicio de SQL Server tiene que poder escribir y
    // leer en la carpeta elegida.
    public class ClsBackupDatos
    {
        private Conexion cn = new Conexion();

        // Mensaje 3211 de SQL Server: "N percent processed." (lo manda BACKUP/RESTORE con STATS).
        private const int MensajePorcentaje = 3211;

        public void GenerarBackup(string archivo, IProgress<int> progreso = null)
        {
            EjecutarConProgreso(
                "BACKUP DATABASE Gestorix TO DISK = @Archivo WITH FORMAT, INIT, STATS = 5",
                archivo, progreso);
        }

        public void RestaurarBackup(string archivoBackup, IProgress<int> progreso = null)
        {
            // SINGLE_USER desconecta a todos los que estén usando la base.
            string sql = @"
                ALTER DATABASE Gestorix SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE Gestorix FROM DISK = @Archivo WITH REPLACE, STATS = 5;
                ALTER DATABASE Gestorix SET MULTI_USER;";

            EjecutarConProgreso(sql, archivoBackup, progreso);
        }

        // Para recibir los porcentajes mientras el comando corre (y no todos juntos al final) hay que
        // activar FireInfoMessageEventOnUserErrors. Con eso los errores tampoco cortan el comando:
        // llegan como mensajes, se juntan y se lanzan al terminar.
        private void EjecutarConProgreso(string sql, string archivo, IProgress<int> progreso)
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
