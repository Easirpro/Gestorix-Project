using CapaDatos.NegocioDatos;
using CapaEntidades.NegocioEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaLogica.NegocioLogica
{
    public class ClsGestorLogicaProducto
    {
        ClsGestorProducto datos = new ClsGestorProducto();

        public int RegistrarProducto(ClsProducto producto)
        {
            return datos.RegistrarProducto(producto);
        }
        public int ObtenerProximoSKU()
        {
            return datos.ObtenerProximoSKU();
        }
        public bool ExisteCodigoBarra(string codigoBarra, int idProductoExcluir = 0)
        {
            return datos.ExisteCodigoBarra(codigoBarra, idProductoExcluir);
        }
        public DataTable CargarIVAsActivos()
        {
            return datos.CargarIVAsActivos();
        }
        public DataTable CargarUnidades()
        {
            return datos.CargarUnidades();
        }
        public int RegistrarMarca(ClsMarca marca)
        {
            return datos.RegistrarMarca(marca);
        }
        public DataTable CargarMarcasActivas()
        {
            return datos.CargarMarcasActivas();
        }
        public DataTable CargarTodasLasMarcas()
        {
            return datos.CargarTodasLasMarcas();
        }
        public bool ModificarMarca(ClsMarca marca)
        {
            return datos.ModificarMarca(marca);
        }
        public bool DesactivarMarca(int idMarca)
        {
            return datos.DesactivarMarca(idMarca);
        }
        public bool HabilitarMarca(int idMarca)
        {
            return datos.HabilitarMarca(idMarca);
        }
        public DataTable BuscarMarcas(string nombre, bool soloActivos)
        {
            return datos.BuscarMarcas(nombre, soloActivos);
        }
        public DataTable CargarCategoriasActivas()
        {
            return datos.CargarCategoriasActivas();
        }
        public void RegistrarStock(int idProducto,decimal cantidadActual,decimal stockMinimo, decimal stockIdeal)
        {
            datos.RegistrarStock(idProducto,cantidadActual,stockMinimo,stockIdeal);
        }
        public bool RegistrarStock(ClsStock stock)
        {
            return datos.RegistrarStock(stock);
        }
        public DataTable ObtenerProveedoresPorProducto(int idProducto)
        {
            return datos.ObtenerProveedoresPorProducto(idProducto);
        }
        public DataTable ObtenerProductoPorId(int idProducto)
        {
            return datos.ObtenerProductoPorId(idProducto);
        }
        public bool ModificarProducto(ClsProducto producto)
        {
            return datos.ModificarProducto(producto);
        }
    }
}
