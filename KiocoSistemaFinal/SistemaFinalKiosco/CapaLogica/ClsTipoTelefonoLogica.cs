using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClsTipoTelefonoLogica
    {
        private ClsTipoTelefonoDatos datos = new ClsTipoTelefonoDatos();

        public DataTable CargarTiposTelefono()
        {
            return datos.CargarTiposTelefono();
        }
    }
}
