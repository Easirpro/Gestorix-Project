using CapaDatos.NegocioDatos;
using System.Data;

namespace CapaLogica.NegocioLogica
{
    public class ClsPrecioLogica
    {
        private ClsPrecioDatos datos = new ClsPrecioDatos();

        public DataTable BuscarProductos(string texto)
        {
            return datos.BuscarProductos(texto);
        }

        public void ActualizarPrecios(DataTable precios)
        {
            datos.ActualizarPrecios(precios);
        }
    }
}