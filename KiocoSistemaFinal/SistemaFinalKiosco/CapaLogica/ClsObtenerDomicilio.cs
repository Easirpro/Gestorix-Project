using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaLogica
{
    public class ClsObtenerDomicilio
    {
        ClsObtenerDomicilioPersona datos = new ClsObtenerDomicilioPersona();
        public ClsDomicilio ObtenerDomicilioPorPersona(int idPersona)
        {
            return datos.ObtenerDomicilioPorPersona(idPersona);
        }
    }
}
