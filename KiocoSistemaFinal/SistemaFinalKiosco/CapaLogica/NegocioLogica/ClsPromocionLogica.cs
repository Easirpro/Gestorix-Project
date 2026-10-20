using CapaDatos.NegocioDatos;
using CapaEntidades;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogica.NegocioLogica
{
    public class ClsPromocionLogica
    {
        private ClsPromocionDatos datos = new ClsPromocionDatos();

        public DataTable BuscarProductos(string texto)
        {
            return datos.BuscarProductos(texto);
        }
        public void ValidarPromocion(ClsPromocion promocion)
        {
            if (promocion == null)
                throw new Exception("La promoción no contiene datos.");

            if (string.IsNullOrWhiteSpace(promocion.Nombre))
                throw new Exception("Debe ingresar el nombre de la promoción.");

            if (promocion.IdTipoPromocion <= 0)
                throw new Exception("El tipo de promoción seleccionado no es válido.");

            if (promocion.FechaFin.HasValue && promocion.FechaFin.Value < promocion.FechaInicio)
            {
                throw new Exception("La fecha de finalización no puede ser anterior a la fecha de inicio.");
            }


            if (promocion.HoraFin <= promocion.HoraInicio)
            {
                throw new Exception("La hora de finalización debe ser posterior a la hora de inicio.");
            }

            if (promocion.EsRecurrente)
            {
                if (promocion.DiasSeleccionados == null || promocion.DiasSeleccionados.Count == 0)
                {
                    throw new Exception(
                        "Debe seleccionar al menos un día para una promoción recurrente.");
                }

                if (promocion.DiasSeleccionados.Distinct().Count() != promocion.DiasSeleccionados.Count)
                {
                    throw new Exception(
                        "Hay días de la semana duplicados en la vigencia.");
                }
            }
            else
            {
                if (!promocion.FechaFin.HasValue)
                {
                    throw new Exception(
                        "Debe indicar la fecha de finalización de la promoción.");
                }
            }


            DataTable tipos = datos.ObtenerTiposPromocion();

            DataRow[] encontrados = tipos.Select(
                "IdTipoPromocion = " + promocion.IdTipoPromocion);

            if (encontrados.Length == 0)
                throw new Exception("El tipo de promoción seleccionado no existe.");

            DataRow tipo = encontrados[0];

            bool esVolumen = tipo["CantidadLleva"] != DBNull.Value && tipo["CantidadPaga"] != DBNull.Value;

            if (esVolumen)
            {
                int lleva = Convert.ToInt32(tipo["CantidadLleva"]);
                int paga = Convert.ToInt32(tipo["CantidadPaga"]);

                if (lleva <= 0 || paga <= 0 || paga >= lleva)
                {
                    throw new Exception("La mecánica por volumen no tiene cantidades válidas.");
                }

                return;
            }

            switch (promocion.IdTipoPromocion)
            {
                case 4:
                    if (promocion.Valor <= 0 || promocion.Valor > 100)
                        throw new Exception("El descuento debe ser mayor que cero y no superar el 100 %.");
                    break;

                case 5:
                    if (promocion.Valor <= 0)
                        throw new Exception("El precio especial debe ser mayor que cero.");
                    break;

                default: throw new Exception("El tipo de promoción no tiene una mecánica válida.");
            }
        }
        public DataTable ObtenerTiposPromocion()
        {
            return datos.ObtenerTiposPromocion();
        }
        public int AgregarMecanicaVolumen(string nombre, int lleva, int paga)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Debe ingresar un nombre para la mecánica.");

            if (lleva <= 0 || paga <= 0)
                throw new Exception("Las cantidades deben ser mayores que cero.");

            if (paga >= lleva)
                throw new Exception("La cantidad que paga debe ser menor que la cantidad que lleva.");

            return datos.AgregarMecanicaVolumen(nombre.Trim(), lleva, paga);
        }
        public int GuardarPromocion(ClsPromocion promocion, List<ClsDetallePromocion> detalles, out string codigoPromocion)
        {
            ValidarPromocion(promocion);

            if (detalles == null || detalles.Count == 0)
                throw new Exception("Debe agregar al menos un artículo a la promoción.");

            foreach (ClsDetallePromocion detalle in detalles)
            {
                if (detalle.IdProducto <= 0)
                    throw new Exception("Hay un artículo inválido en la promoción.");

                if (detalle.Cantidad <= 0)
                    throw new Exception("La cantidad de cada artículo debe ser mayor que cero.");
            }

            return datos.GuardarPromocion(promocion, detalles, out codigoPromocion);
        }
        public DataTable BuscarPromociones(string texto)
        {
            return datos.BuscarPromociones(texto);
        }
        public decimal CalcularPorcentajeDescuento(decimal precioNormal, decimal precioPromocional)
        {
            if (precioNormal <= 0)
                return 0;

            if (precioPromocional < 0)
                throw new Exception("El precio promocional no puede ser negativo.");

            if (precioPromocional >= precioNormal)
                return 0;

            decimal descuento = ((precioNormal - precioPromocional) / precioNormal) * 100;

            return Math.Round(descuento, 2);
        }
        public decimal CalcularPrecioPromocional(decimal precioNormal, int idTipoPromocion, decimal valor, int cantidadLleva = 0, int cantidadPaga = 0)
        {
            if (precioNormal < 0)
                throw new Exception("El precio normal no puede ser negativo.");

            if (valor < 0)
                throw new Exception("El valor promocional no puede ser negativo.");

            DataTable tipos = datos.ObtenerTiposPromocion();

            DataRow[] encontrados = tipos.Select("IdTipoPromocion = " + idTipoPromocion);

            if (encontrados.Length == 0)
                throw new Exception("El tipo de promoción no es válido.");

            DataRow tipo = encontrados[0];

            bool esVolumen = tipo["CantidadLleva"] != DBNull.Value && tipo["CantidadPaga"] != DBNull.Value;

            if (esVolumen)
            {
                cantidadLleva = Convert.ToInt32(tipo["CantidadLleva"]);
                cantidadPaga = Convert.ToInt32(tipo["CantidadPaga"]);

                if (cantidadLleva <= 0 || cantidadPaga <= 0 || cantidadPaga >= cantidadLleva)
                {
                    throw new Exception("Las cantidades de la promoción por volumen no son válidas.");
                }

                return Math.Round(precioNormal * cantidadPaga / cantidadLleva, 2);
            }

            switch (idTipoPromocion)
            {
                case 4:
                    if (valor <= 0 || valor > 100)
                        throw new Exception("El descuento debe ser mayor que cero y no superar el 100 %.");

                    return Math.Round(precioNormal * (1m - valor / 100m), 2);

                case 5:
                    if (valor <= 0)
                        throw new Exception("El precio especial debe ser mayor que cero.");

                    return valor;

                default:
                    throw new Exception("El tipo de promoción no tiene una mecánica válida.");
            }
        }
        public DataSet ObtenerPromocionPorId(int idPromocion)
        {
            if (idPromocion <= 0)
                throw new Exception("El identificador de la promoción no es válido.");

            return datos.ObtenerPromocionPorId(idPromocion);
        }
        public void EliminarPromocion(int idPromocion)
        {
            if (idPromocion <= 0)
            {
                throw new Exception("El identificador de la promoción no es válido.");
            }

            datos.EliminarPromocion(idPromocion);
        }
        public void ModificarPromocion(ClsPromocion promocion, List<ClsDetallePromocion> detalles)
        {
            if (promocion == null)
                throw new ArgumentNullException(nameof(promocion));

            if (promocion.IdPromocion <= 0)
                throw new Exception("La promoción seleccionada no es válida.");

            ValidarPromocion(promocion);

            if (promocion.IdTipoPromocion <= 0)
                throw new Exception("Debe seleccionar un tipo de promoción.");

            if (promocion.IdTipoPromocion == 4 && (promocion.Valor <= 0 || promocion.Valor > 100))
            {
                throw new Exception("El descuento debe ser mayor que cero y no superar el 100 %.");
            }

            if (promocion.IdTipoPromocion == 5 && promocion.Valor <= 0)
            {
                throw new Exception("El precio especial debe ser mayor que cero.");
            }

            if (detalles == null || detalles.Count == 0)
                throw new Exception("Debe agregar al menos un artículo a la promoción.");

            foreach (ClsDetallePromocion detalle in detalles)
            {
                if (detalle == null || detalle.IdProducto <= 0)
                    throw new Exception("Hay un artículo inválido en la promoción.");

                if (detalle.Cantidad <= 0)
                    throw new Exception("La cantidad de cada artículo debe ser mayor que cero.");
            }

            datos.ModificarPromocion(promocion, detalles);
        }
        public decimal CalcularPrecioPromocionalPorCantidad( decimal precioUnitario, decimal cantidad, int idTipoPromocion, decimal valor, int cantidadLleva = 0, int cantidadPaga = 0)
        {
            if (precioUnitario < 0)
                throw new Exception("El precio unitario no puede ser negativo.");

            if (cantidad < 0)
                throw new Exception("La cantidad no puede ser negativa.");

            if (idTipoPromocion <= 0)
                throw new Exception("El tipo de promoción no es válido.");

            if (cantidad == 0)
                return 0m;

            DataTable tipos = datos.ObtenerTiposPromocion();

            DataRow[] encontrados = tipos.Select("IdTipoPromocion = " + idTipoPromocion);

            if (encontrados.Length == 0)
                throw new Exception("El tipo de promoción no existe.");

            DataRow tipo = encontrados[0];

            bool esVolumen = tipo["CantidadLleva"] != DBNull.Value && tipo["CantidadPaga"] != DBNull.Value;

            if (esVolumen)
            {
                cantidadLleva = Convert.ToInt32(tipo["CantidadLleva"]);
                cantidadPaga = Convert.ToInt32(tipo["CantidadPaga"]);

                if (cantidadLleva <= 0 || cantidadPaga <= 0 || cantidadPaga >= cantidadLleva)
                {
                    throw new Exception("Las cantidades de la promoción por volumen no son válidas.");
                }

                if (cantidad != Math.Truncate(cantidad))
                {
                    throw new Exception("Las promociones por volumen requieren unidades enteras.");
                }

                decimal gruposCompletos = Math.Floor(cantidad / cantidadLleva);
                decimal unidadesRestantes = cantidad % cantidadLleva;
                decimal unidadesAPagar = (gruposCompletos * cantidadPaga) + unidadesRestantes;

                return Math.Round(unidadesAPagar * precioUnitario, 2);
            }

            switch (idTipoPromocion)
            {
                case 4:
                    if (valor <= 0 || valor > 100)
                        throw new Exception("El descuento debe ser mayor que cero y no superar el 100 %.");

                    return Math.Round(
                        precioUnitario * cantidad * (1m - valor / 100m), 2);

                case 5:
                    if (valor <= 0)
                        throw new Exception("El precio especial debe ser mayor que cero.");

                    return Math.Round(cantidad * valor, 2);

                default:
                    throw new Exception("El tipo de promoción no tiene una mecánica válida.");
            }
        }
        public void CambiarEstadoPromocion(int idPromocion, bool activo)
        {
            if (idPromocion <= 0)
                throw new Exception("Debe seleccionar una promoción válida.");

            datos.CambiarEstadoPromocion(idPromocion, activo);
        }






    }
}