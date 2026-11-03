using System;

namespace CapaEntidades
{
    // Un registro cuyo dígito verificador horizontal (DVH) no coincide con sus datos:
    // la fila se modificó por fuera del sistema o se guardó sin DVH.
    public class ClsInconsistenciaDVH
    {
        public string Tabla { get; set; }
        public int IdRegistro { get; set; }
        public string Registro { get; set; }
        public string Problema { get; set; }
    }
}
