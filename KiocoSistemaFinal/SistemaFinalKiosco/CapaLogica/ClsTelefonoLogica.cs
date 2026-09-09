using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
     public class ClsTelefonoLogica
     {
        ClsObtenerTelefonoPersona datos = new ClsObtenerTelefonoPersona();

        public int ObtenerIdTelefonoPorPersona(int idPersona)
        {
            return datos.ObtenerIdTelefonoPorPersona(idPersona);
        }
     }
    
}
