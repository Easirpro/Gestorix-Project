using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SistemaKiosco
{
    public class ClsDigitoVerificador
    {
      public static string GenerarHash(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));

                return Convert.ToHexString(bytes);
            }
        }
    
      
    }
}
