using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class ClsModificarDomicilio
    {
        ClsModificarDomicilioPer datos = new ClsModificarDomicilioPer();

        public bool ModificarDomicilio(ClsDomicilio domicilio)
        {
            return datos.ModificarDomicilio(domicilio);
        }
    }
}
