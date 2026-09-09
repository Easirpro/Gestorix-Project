using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CapaLogica
{
    public class ValidacionCampoVacio 
    {
        public bool ValidarCamposVacios(string texto)
        {
            return string.IsNullOrWhiteSpace(texto);

        }
        public bool EsEspacioInicial(string texto, char tecla)
        {
            return texto.Length == 0 && tecla == ' ';
        }

    }
}
