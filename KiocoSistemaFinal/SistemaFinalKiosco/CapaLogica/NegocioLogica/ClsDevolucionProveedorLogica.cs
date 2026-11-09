using CapaDatos.NegocioDatos;
using System;
using System.Data;

namespace CapaLogica.NegocioLogica
{
    public class ClsDevolucionProveedorLogica
    {
        private ClsDevolucionProveedorDatos datos = new ClsDevolucionProveedorDatos();

        public DataTable ObtenerLotesVencidos(int idProducto)
        {
            return datos.ObtenerLotesVencidos(idProducto);
        }

        public DataTable ObtenerDevoluciones(DateTime desde, DateTime hasta)
        {
            return datos.ObtenerDevoluciones(desde, hasta);
        }

        public (int IdDevolucion, decimal Importe) Registrar(int idLote, decimal cantidad, string motivo, int idUsuario)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a devolver debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("Debe ingresar el motivo de la devolución.");

            return datos.Registrar(idLote, cantidad, motivo.Trim(), idUsuario);
        }
    }
}
