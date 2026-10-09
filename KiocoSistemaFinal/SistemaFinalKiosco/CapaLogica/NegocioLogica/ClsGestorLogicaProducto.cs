using CapaDatos.NegocioDatos;
using CapaEntidades.NegocioEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaLogica.NegocioLogica
{
    public partial class ClsGestorLogicaProducto
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
        public DataTable ObtenerProductoPorCodigoBarra(string codigoBarra)
        {
            return datos.ObtenerProductoPorCodigoBarra(codigoBarra);
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
        public DataTable CargarTodasLasCategorias()
        {
            return datos.CargarTodasLasCategorias();
        }
        public int RegistrarCategoria(string nombre, string descripcion)
        {
            return datos.RegistrarCategoria(nombre, descripcion);
        }
        public bool ModificarCategoria(int idCategoria, string nombre, string descripcion)
        {
            return datos.ModificarCategoria(idCategoria, nombre, descripcion);
        }
        public bool DesactivarCategoria(int idCategoria)
        {
            return datos.DesactivarCategoria(idCategoria);
        }
        public bool HabilitarCategoria(int idCategoria)
        {
            return datos.HabilitarCategoria(idCategoria);
        }
        public bool EliminarCategoria(int idCategoria)
        {
            return datos.EliminarCategoria(idCategoria);
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
        public DataTable CargarArticulos()
        {
            return datos.CargarArticulos();
        }
        public DataTable CargarArticulosParaExportar(int idProveedor, int idCategoria, int idMarca, int idSucursal, int estado, bool soloStock, bool soloVencimiento, bool soloLote)
        {
            return datos.CargarArticulosParaExportar(idProveedor, idCategoria, idMarca, idSucursal, estado, soloStock, soloVencimiento, soloLote);
        }
        public DataTable BuscarArticulos(string texto, bool ocultarDiscontinuos)
        {
            return datos.BuscarArticulos(texto, ocultarDiscontinuos);
        }
        public DataTable ObtenerStockPorProducto(int idProducto)
        {
            return datos.ObtenerStockPorProducto(idProducto);
        }
        public void RegistrarProductoSucursalProveedor(ClsProductoSucursalProveedor relacion)
        {
            datos.RegistrarProductoSucursalProveedor(relacion);
        }
        public bool RegistrarLote(ClsLote lote)
        {
            return datos.RegistrarLote(lote);
        }
        public bool ModificarLote(ClsLote lote)
        {
            return datos.ModificarLote(lote);
        }
        public bool ModificarProductoSucursalProveedor(ClsProductoSucursalProveedor relacion)
        {
            return datos.ModificarProductoSucursalProveedor(relacion);
        }
        public bool EliminarProducto(int idProducto)
        {
            return datos.EliminarProducto(idProducto);
        }
        public bool DescontinuarProducto(int idProducto)
        {
            return datos.DescontinuarProducto(idProducto);
        }
        public bool ActivarProducto(int idProducto)
        {
            return datos.ActivarProducto(idProducto);
        }
        public DataTable BuscarProductoPorCodigoOSku(string texto)
        {
            return datos.BuscarProductoPorCodigoOSku(texto);
        }
        public bool AgregarStock(int idProducto, int cantidad)
        {
            return datos.AgregarStock(idProducto, cantidad);
        }
        public bool ModificarStock(int idProducto, decimal cantidadActual, decimal stockMinimo, decimal stockIdeal)
        {
            return datos.ModificarStock(idProducto, cantidadActual, stockMinimo, stockIdeal);
        }



        //Metodos para excel
        public int ObtenerIdMarcaPorNombre(string nombre)
        {
            DataTable tabla = datos.CargarMarcasActivas();

            foreach (DataRow fila in tabla.Rows)
            {
                string nombreBD = fila["Nombre"].ToString();

                if (string.Equals(nombreBD.Trim(), nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToInt32(fila["IdMarca"]);
                }
            }

            return 0;
        }
        public int ObtenerIdCategoriaPorNombre(string nombre)
        {
            DataTable tabla = datos.CargarCategoriasActivas();

            foreach (DataRow fila in tabla.Rows)
            {
                string nombreBD = fila["Nombre"].ToString();

                if (string.Equals(nombreBD.Trim(), nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToInt32(fila["IdCategoria"]);
                }
            }

            return 0;
        }
        public int ObtenerIdUnidadPorNombre(string nombre)
        {
            DataTable tabla = datos.CargarUnidades();

            foreach (DataRow fila in tabla.Rows)
            {
                string nombreBD = fila["Nombre"].ToString();

                if (string.Equals(nombreBD.Trim(), nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToInt32(fila["IdUnidad"]);
                }
            }

            return 0;
        }
        public int ObtenerIdIVAPorAlicuota(string alicuota)
        {
            DataTable tabla = datos.CargarIVAsActivos();

            foreach (DataRow fila in tabla.Rows)
            {
                string valorBD = fila["Alicuota"].ToString();

                if (string.Equals(valorBD.Trim(), alicuota.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToInt32(fila["IdIVA"]);
                }
            }

            return 0;
        }
        public int ObtenerIdIVAPorAlicuota(decimal alicuota)
        {
            DataTable tabla = datos.CargarIVAsActivos();

            foreach (DataRow fila in tabla.Rows)
            {
                decimal alicuotaBD = Convert.ToDecimal(fila["Alicuota"]);

                if (alicuotaBD == alicuota)
                {
                    return Convert.ToInt32(fila["IdIVA"]);
                }
            }

            return 0;
        }
        public int RegistrarProductoImportacion(ClsGestorEntidadProducto.ClsProducto producto,SqlConnection conexion,SqlTransaction transaccion)
        {
            return datos.RegistrarProductoImportacion(producto, conexion, transaccion);
        }
        public int ObtenerProximoSKUImportacion(SqlConnection conexion,SqlTransaction transaccion)
        {
            return datos.ObtenerProximoSKUImportacion(conexion, transaccion);
        }
        public void RegistrarProductoSucursalProveedorImportacion(ClsProductoSucursalProveedor relacion, SqlConnection conexion,SqlTransaction transaccion)
        {
            datos.RegistrarProductoSucursalProveedorImportacion(relacion, conexion, transaccion);
        }
        public void RegistrarLoteImportacion(ClsLote lote, SqlConnection conexion, SqlTransaction transaccion)
        {
            datos.RegistrarLoteImportacion(lote, conexion, transaccion);
        }
        public int ObtenerIdSucursalImportacion(string nombreProveedor, string nombreSucursal, SqlConnection conexion, SqlTransaction transaccion)
        {
            return datos.ObtenerIdSucursalImportacion(nombreProveedor, nombreSucursal, conexion, transaccion);
        }


        public int ObtenerIdSucursalImportacion(string nombreProveedor, string nombreSucursal)
        {
            return datos.ObtenerIdSucursalImportacion(nombreProveedor, nombreSucursal);
        }

        public void ImportarProductos(
            List<ClsGestorEntidadProducto.ClsProducto> productos,
            List<ClsGestorEntidadProducto.ClsImportacionProveedorCosto> proveedoresCostos,
            Dictionary<string, DateTime?> fechasVencimiento)
        {
            datos.ImportarProductos(productos, proveedoresCostos, fechasVencimiento);
        }

    }
}
