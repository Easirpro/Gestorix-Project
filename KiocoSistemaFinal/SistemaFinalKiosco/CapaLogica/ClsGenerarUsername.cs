using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaLogica
{
    public class ClsGenerarUsername
    {
        public string CrearUsuario(string Nombre, string Apellido)
        {
            ClsUsuarioDatos datos = new ClsUsuarioDatos();

            string username = Nombre.ToLower() + Apellido.ToLower();
            string usernameOriginal = username;

            int contador = 1;

            while (datos.ExisteUsuario(username))
            {
                username = usernameOriginal + contador;
                contador++;
            }

            return username;
        }

    }
}
