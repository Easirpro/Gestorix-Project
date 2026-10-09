using CapaEntidades.NegocioEntidad;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaDatos.NegocioDatos
{
    public class ClsGestorProducto
    {
        Conexion cn = new Conexion();

        public DataTable CargarUnidades()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_CargarUnidades", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public int RegistrarProducto(ClsGestorEntidadProducto.ClsProducto producto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoBarra", producto.CodigoBarra);
                cmd.Parameters.AddWithValue("@SKU", producto.SKU);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@IdMarca", producto.IdMarca);
                cmd.Parameters.AddWithValue("@IdIVA", producto.IdIVA);
                cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@IdUnidad", producto.IdUnidad);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Activo", true);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int ObtenerProximoSKU()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ObtenerProximoSKU", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public bool ExisteCodigoBarra(string codigoBarra, int idProductoExcluir = 0)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ExisteCodigoBarra", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);
                cmd.Parameters.AddWithValue("@IdProductoExcluir", idProductoExcluir);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public DataTable ObtenerProductoPorCodigoBarra(string codigoBarra)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ObtenerProductoPorCodigoBarra", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable BuscarProductoPorCodigoOSku(string texto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_BuscarProductoPorCodigoOSku", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", texto);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable CargarCategoriasActivas()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_CargarCategoriasActivas", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable CargarIVAsActivos()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_CargarIVAsActivos", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public int RegistrarMarca(ClsGestorEntidadProducto.ClsMarca marca)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_RegistrarMarca", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", marca.Nombre);
                cmd.Parameters.AddWithValue("@Activo", marca.Activo);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public DataTable CargarMarcasActivas()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_CargarMarcasActivas", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable CargarTodasLasCategorias()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_CargarTodasLasCategorias", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public bool ModificarMarca(ClsGestorEntidadProducto.ClsMarca marca)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ModificarMarca", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMarca", marca.IdMarca);
                cmd.Parameters.AddWithValue("@Nombre", marca.Nombre);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool HabilitarMarca(int idMarca)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_HabilitarMarca", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMarca", idMarca);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool DesactivarMarca(int idMarca)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_DesactivarMarca", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMarca", idMarca);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public DataTable CargarTodasLasMarcas()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_CargarTodasLasMarcas", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable BuscarMarcas(string nombre, bool soloActivos)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_BuscarMarcas", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@SoloActivos", soloActivos);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
        public void RegistrarStock(int idProducto, decimal cantidadActual, decimal stockMinimo, decimal stockIdeal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_RegistrarStock", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.Parameters.AddWithValue("@CantidadActual", cantidadActual);
                cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                cmd.Parameters.AddWithValue("@StockIdeal", stockIdeal);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public bool RegistrarStock(ClsGestorEntidadProducto.ClsStock stock)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_RegistrarStock", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", stock.IdProducto);
                cmd.Parameters.AddWithValue("@CantidadActual", stock.CantidadActual);
                cmd.Parameters.AddWithValue("@StockMinimo", stock.StockMinimo);
                cmd.Parameters.AddWithValue("@StockIdeal", stock.StockIdeal);

                conexion.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool AgregarStock(int idProducto, int cantidad)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_AgregarStock", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool RegistrarLote(ClsLote lote)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_RegistrarLote", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", lote.IdProducto);
                cmd.Parameters.AddWithValue("@CodigoLote", lote.CodigoLote);
                cmd.Parameters.AddWithValue("@FechaFabricacion", lote.FechaFabricacion);
                cmd.Parameters.AddWithValue("@FechaVencimiento", lote.FechaVencimiento);
                cmd.Parameters.AddWithValue("@FechaIngreso", lote.FechaIngreso);
                cmd.Parameters.AddWithValue("@Stock", lote.Stock);
                cmd.Parameters.AddWithValue("@Activo", lote.Activo);
                cmd.Parameters.AddWithValue("@IdSucursal", lote.IdSucursal);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool ModificarLote(ClsLote lote)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ModificarLote", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = lote.IdProducto;
                cmd.Parameters.Add("@CodigoLote", SqlDbType.NVarChar, 100).Value = lote.CodigoLote;
                cmd.Parameters.Add("@FechaFabricacion", SqlDbType.Date).Value = lote.FechaFabricacion;
                cmd.Parameters.Add("@FechaVencimiento", SqlDbType.Date).Value = lote.FechaVencimiento;
                cmd.Parameters.Add("@FechaIngreso", SqlDbType.DateTime2).Value = lote.FechaIngreso;

                SqlParameter parametroStock = cmd.Parameters.Add("@Stock", SqlDbType.Decimal);

                parametroStock.Precision = 10;
                parametroStock.Scale = 3;
                parametroStock.Value = lote.Stock;

                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value =  lote.Activo;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = lote.IdSucursal;

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public DataTable ObtenerProveedoresPorProducto(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ObtenerProveedoresPorProducto", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable ObtenerProductoPorId(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ObtenerProductoPorId", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable CargarArticulos()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_CargarArticulos", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable CargarArticulosParaExportar(int idProveedor, int idCategoria, int idMarca, int idSucursal, int estado, bool soloStock, bool soloVencimiento, bool soloLote)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_CargarArticulosParaExportar", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                cmd.Parameters.AddWithValue("@IdMarca", idMarca);
                cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@SoloStock", soloStock);
                cmd.Parameters.AddWithValue("@SoloVencimiento", soloVencimiento);
                cmd.Parameters.AddWithValue("@SoloLote", soloLote);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public bool ModificarProducto( ClsGestorEntidadProducto.ClsProducto producto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ModificarProducto", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                cmd.Parameters.AddWithValue("@CodigoBarra", producto.CodigoBarra);
                cmd.Parameters.AddWithValue("@SKU", producto.SKU);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@IdMarca", producto.IdMarca);
                cmd.Parameters.AddWithValue("@IdIVA", producto.IdIVA);
                cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@IdUnidad", producto.IdUnidad);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public DataTable ObtenerStockPorProducto(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ObtenerStockPorProducto", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public void RegistrarProductoSucursalProveedor( ClsProductoSucursalProveedor relacion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_RegistrarProductoSucursalProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", relacion.IdProducto);
                cmd.Parameters.AddWithValue("@IdSucursal", relacion.IdSucursal);
                cmd.Parameters.AddWithValue("@PrecioCompra", (object)relacion.PrecioCompra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaPrecioCompra", (object)relacion.FechaPrecioCompra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodigoProveedor", (object)relacion.CodigoProveedor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", relacion.Activo);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public bool ModificarProductoSucursalProveedor(ClsProductoSucursalProveedor relacion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ModificarProductoSucursalProveedor", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdProducto", relacion.IdProducto);
                cmd.Parameters.AddWithValue("@IdSucursal", relacion.IdSucursal);
                cmd.Parameters.AddWithValue("@Activo", relacion.Activo);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public DataTable BuscarArticulos( string texto, bool ocultarDiscontinuos)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_BuscarArticulos", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", texto);
                cmd.Parameters.AddWithValue("@OcultarDiscontinuos", ocultarDiscontinuos);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }
        public int RegistrarProductoImportacion( ClsGestorEntidadProducto.ClsProducto producto, SqlConnection conexion, SqlTransaction transaccion)
        {
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarProductoImportacion", conexion, transaccion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoBarra", string.IsNullOrWhiteSpace(producto.CodigoBarra) ? (object)DBNull.Value : producto.CodigoBarra);
                cmd.Parameters.AddWithValue("@SKU", producto.SKU);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion);
                cmd.Parameters.AddWithValue("@IdMarca", producto.IdMarca);
                cmd.Parameters.AddWithValue("@IdIVA", producto.IdIVA);
                cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@IdUnidad", producto.IdUnidad);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int ObtenerProximoSKUImportacion(SqlConnection conexion, SqlTransaction transaccion)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerProximoSKUImportacion", conexion, transaccion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void RegistrarProductoSucursalProveedorImportacion(ClsProductoSucursalProveedor relacion, SqlConnection conexion, SqlTransaction transaccion)
        {
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarProductoSucursalProveedorImportacion", conexion, transaccion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", relacion.IdProducto);
                cmd.Parameters.AddWithValue("@IdSucursal", relacion.IdSucursal);
                cmd.Parameters.AddWithValue("@PrecioCompra", (object)relacion.PrecioCompra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaPrecioCompra", (object)relacion.FechaPrecioCompra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodigoProveedor", (object)relacion.CodigoProveedor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", relacion.Activo);

                cmd.ExecuteNonQuery();
            }
        }
        public void RegistrarLoteImportacion(ClsLote lote, SqlConnection conexion, SqlTransaction transaccion)
        {
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarLoteImportacion", conexion, transaccion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", lote.IdProducto);
                cmd.Parameters.AddWithValue("@CodigoLote", lote.CodigoLote);
                cmd.Parameters.AddWithValue("@FechaFabricacion", lote.FechaFabricacion);
                cmd.Parameters.AddWithValue("@FechaVencimiento", lote.FechaVencimiento);
                cmd.Parameters.AddWithValue("@FechaIngreso", lote.FechaIngreso);
                cmd.Parameters.AddWithValue("@Stock", lote.Stock);
                cmd.Parameters.AddWithValue("@Activo", lote.Activo);
                cmd.Parameters.AddWithValue("@IdSucursal", lote.IdSucursal);

                cmd.ExecuteNonQuery();
            }
        }
        public int ObtenerIdSucursalImportacion(string nombreProveedor, string nombreSucursal, SqlConnection conexion, SqlTransaction transaccion)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerIdSucursalImportacion", conexion, transaccion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreProveedor", nombreProveedor);

                cmd.Parameters.AddWithValue("@NombreSucursal", nombreSucursal);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int ObtenerIdSucursalImportacion(string nombreProveedor, string nombreSucursal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerIdSucursalImportacion", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreProveedor", nombreProveedor);
                    cmd.Parameters.AddWithValue("@NombreSucursal", nombreSucursal);
                    object resultado = cmd.ExecuteScalar();
                    return resultado == null || resultado == DBNull.Value ? 0 : Convert.ToInt32(resultado);
                }
            }
        }

        public void ImportarProductos(
            List<ClsGestorEntidadProducto.ClsProducto> productos,
            List<ClsGestorEntidadProducto.ClsImportacionProveedorCosto> proveedoresCostos,
            Dictionary<string, DateTime?> fechasVencimiento)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        int siguienteSKU = ObtenerProximoSKUImportacion(conexion, transaccion);

                        foreach (var producto in productos)
                        {
                            producto.SKU = siguienteSKU.ToString();
                            producto.IdProducto = RegistrarProductoImportacion(producto, conexion, transaccion);
                            siguienteSKU++;
                        }

                        foreach (var proveedorCosto in proveedoresCostos)
                        {
                            var producto = productos.FirstOrDefault(p => p.CodigoBarra == proveedorCosto.CodigoBarra);
                            if (producto == null)
                                throw new Exception($"No se encontró el artículo '{proveedorCosto.CodigoBarra}'.");

                            int idSucursal = ObtenerIdSucursalImportacion(
                                proveedorCosto.Proveedor, proveedorCosto.Sucursal, conexion, transaccion);

                            if (idSucursal == 0)
                                throw new Exception($"No se encontró la sucursal '{proveedorCosto.Sucursal}' del proveedor '{proveedorCosto.Proveedor}'.");

                            var relacion = new ClsGestorEntidadProducto.ClsProductoSucursalProveedor
                            {
                                IdProducto = producto.IdProducto,
                                IdSucursal = idSucursal,
                                PrecioCompra = proveedorCosto.PrecioCompra,
                                FechaPrecioCompra = DateTime.Now,
                                CodigoProveedor = null,
                                Activo = true
                            };

                            RegistrarProductoSucursalProveedorImportacion(relacion, conexion, transaccion);

                            if (fechasVencimiento.TryGetValue(proveedorCosto.CodigoBarra, out DateTime? fecha)
                                && fecha.HasValue)
                            {
                                var lote = new ClsGestorEntidadProducto.ClsLote
                                {
                                    IdProducto = producto.IdProducto,
                                    CodigoLote = "IMP-" + producto.SKU,
                                    FechaFabricacion = DateTime.Now.Date,
                                    FechaVencimiento = fecha.Value.Date,
                                    FechaIngreso = DateTime.Now,
                                    Stock = 0,
                                    Activo = true,
                                    IdSucursal = idSucursal
                                };

                                RegistrarLoteImportacion(lote, conexion, transaccion);
                            }
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        try { transaccion.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        public bool EliminarProducto(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_EliminarProducto", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                try
                {
                    conexion.Open();

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DescontinuarProducto(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_DescontinuarProducto", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool ActivarProducto(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ActivarProducto", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public int RegistrarCategoria(string nombre, string descripcion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_RegistrarCategoria", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public bool ModificarCategoria(int idCategoria, string nombre, string descripcion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_ModificarCategoria", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue( "@Descripcion", string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool DesactivarCategoria(int idCategoria)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_DesactivarCategoria", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool HabilitarCategoria(int idCategoria)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_HabilitarCategoria", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool EliminarCategoria(int idCategoria)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())

            using (SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool ModificarStock(int idProducto, decimal cantidadActual, decimal stockMinimo, decimal stockIdeal)
        {
            try
            {
                using (SqlConnection conexion = cn.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ModificarStock", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;

                        SqlParameter parametroCantidad = cmd.Parameters.Add("@CantidadActual", SqlDbType.Decimal);
                        parametroCantidad.Precision = 10;
                        parametroCantidad.Scale = 3;
                        parametroCantidad.Value = cantidadActual;

                        SqlParameter parametroMinimo = cmd.Parameters.Add("@StockMinimo", SqlDbType.Decimal);
                        parametroMinimo.Precision = 10;
                        parametroMinimo.Scale = 3;
                        parametroMinimo.Value = stockMinimo;

                        SqlParameter parametroIdeal = cmd.Parameters.Add("@StockIdeal", SqlDbType.Decimal);
                        parametroIdeal.Precision = 10;
                        parametroIdeal.Scale = 3;
                        parametroIdeal.Value = stockIdeal;

                        return Convert.ToBoolean(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
