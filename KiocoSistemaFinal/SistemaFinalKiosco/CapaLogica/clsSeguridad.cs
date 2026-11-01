using System;
using System.Security.Cryptography;
using System.Text;


namespace CapaSesion
{
    public static class ClsSeguridad
    {
        // Encripta una cadena
        public static string Encriptar(this string _cadenaAencriptar)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            string result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            string result = Encoding.Unicode.GetString(decryted);
            return result;
        }


        public static string SHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string HashRespuesta(int idUsuario, string respuesta)
        {
            string texto = idUsuario + "|" + (respuesta ?? "").Trim().ToLowerInvariant();

            using (SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.Unicode.GetBytes(texto));

                return Convert.ToHexString(hash);
            }
        }
    }
}
