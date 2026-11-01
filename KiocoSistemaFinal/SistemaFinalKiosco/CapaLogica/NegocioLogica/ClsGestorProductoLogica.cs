using CapaDatos.NegocioDatos;
using CapaEntidades;
using CapaEntidades.NegocioEntidad;
using CapaLogica.BitacoraLogi;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaLogica.NegocioLogica
{
    public partial class ClsGestorProductoLogica
    {
        private clsBitacoraLogica bitacora = new clsBitacoraLogica();
        CapaDatos.NegocioDatos.ClsGestorProductoDatos datos = new CapaDatos.NegocioDatos.ClsGestorProductoDatos();



        public int RegistrarProducto(ClsGestorEntidadProducto.ClsProducto producto)
        {
            int idProducto = this.datos.RegistrarProducto(producto);

            if (idProducto > 0)
            {
                this.RegistrarEventoBitacora(
                    "CREAR",
                    "Producto",
                    idProducto,
                    "Se creó el producto: " + producto.Nombre
                );
            }

            return idProducto;
        }
        public bool ModificarProducto(ClsGestorEntidadProducto.ClsProducto producto)
        {
            bool modificado = this.datos.ModificarProducto(producto);

            if (modificado)
            {
                this.RegistrarEventoBitacora(
                    "MODIFICAR",
                    "Producto",
                    producto.IdProducto,
                    "Se modificó el producto: " + producto.Nombre
                );
            }

            return modificado;
        }
        public bool EliminarProducto(int idProducto)
        {
            bool eliminado = this.datos.EliminarProducto(idProducto);

            if (eliminado)
            {
                this.RegistrarEventoBitacora(
                    "ELIMINAR",
                    "Producto",
                    idProducto,
                    "Se eliminó el producto con ID " + idProducto
                );
            }

            return eliminado;
        }
        public bool DescontinuarProducto(int idProducto)
        {
            bool descontinuado = this.datos.DescontinuarProducto(idProducto);

            if (descontinuado)
            {
                this.RegistrarEventoBitacora(
                    "DISCONTINUAR",
                    "Producto",
                    idProducto,
                    "Se discontinuó el producto con ID " + idProducto
                );
            }

            return descontinuado;
        }
        public bool ActivarProducto(int idProducto)
        {
            bool activado = this.datos.ActivarProducto(idProducto);

            if (activado)
            {
                this.RegistrarEventoBitacora(
                    "ACTIVAR",
                    "Producto",
                    idProducto,
                    "Se reactivó el producto con ID " + idProducto
                );
            }

            return activado;
        }
        public void RecalcularDVHProductos()
        {
            datos.RecalcularDVHProductos();
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
        private void RegistrarEventoBitacora(string accion, string tablaAfectada, int? idRegistroAfectado, string descripcion)
        {
            try
            {
                this.bitacora.RegistrarBitacora(
                    SesionUsuario.IdUsuario,
                    accion,
                    tablaAfectada,
                    idRegistroAfectado,
                    descripcion
                );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al registrar la bitácora: " + ex.ToString()
                );
            }
        }
        public DataTable BuscarProductosConFiltrosRapida( string texto, int? idProveedor, int? idSucursal, int? idCategoria, int? idMarca)
        {
            return datos.BuscarProductosConFiltrosRapida(
                texto, idProveedor, idSucursal, idCategoria, idMarca);
        }
        public DataTable ObtenerListadoArticulos(string texto, int? idProducto, int? idProveedor, int? idSucursal, int? idCategoria, int? idMarca, bool soloOfertas, bool soloReponer)
        {
            return datos.ObtenerListadoArticulos(texto, idProducto, idProveedor, idSucursal, idCategoria, idMarca, soloOfertas, soloReponer);
        }


        // Metodos para excel
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
        public int ObtenerIdSucursalImportacion(string nombreProveedor, string nombreSucursal)
        {
            return datos.ObtenerIdSucursalImportacion(nombreProveedor, nombreSucursal);
        }
        public void ImportarProductos(List<ClsGestorEntidadProducto.ClsProducto> productos, List<ClsGestorEntidadProducto.ClsImportacionProveedorCosto> proveedoresCostos, Dictionary<string, DateTime?> fechasVencimiento)
        {
            this.datos.ImportarProductos(
                productos,
                proveedoresCostos,
                fechasVencimiento
            );

            if (productos != null && productos.Count > 0)
            {
                this.RegistrarEventoBitacora(
                    "IMPORTAR",
                    "Producto",
                    null,
                    "Se importaron " + productos.Count + " productos."
                );
            }
        }


    }
}
