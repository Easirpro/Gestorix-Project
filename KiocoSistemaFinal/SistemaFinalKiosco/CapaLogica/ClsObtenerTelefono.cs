using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsObtenerTelefono
    {
        private ClsObtenerTelefonoPersona datos =new ClsObtenerTelefonoPersona();

        public ClsTelefono ObtenerTelefonoPorPersona(int idPersona)
        {
            return datos.ObtenerTelefonoPorPersona(idPersona);
        }

        public int ObtenerIdTelefonoPorPersona(int idPersona)
        {
            return datos.ObtenerIdTelefonoPorPersona(idPersona);
        }
    }
}
