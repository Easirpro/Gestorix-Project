using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaLogica
{
    public class ClsObtenerLocalidadPerson
    {
       

        public CapaEntidades.ClsLocalidad ObtenerLocalidad (int idPersona)
        {
            ClsObtenerLocalidad datos = new ClsObtenerLocalidad();
            return datos.ObtenerLocalidad(idPersona);
        }

    }
}
