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
            {
                string consulta = @"
                    SELECT
                        IdUnidad,
                        Nombre,
                        Simbolo,
                        Categoria
                    FROM Unidad
                    ORDER BY Nombre;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        da.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public int RegistrarProducto(ClsGestorEntidadProducto.ClsProducto producto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Producto
                    (
                        CodigoBarra,
                        SKU,
                        Nombre,
                        Descripcion,
                        IdMarca,
                        IdIVA,
                        IdCategoria,
                        IdUnidad,
                        PrecioVenta,
                        Activo
                    )
                    VALUES
                    (
                        @CodigoBarra,
                        @SKU,
                        @Nombre,
                        @Descripcion,
                        @IdMarca,
                        @IdIVA,
                        @IdCategoria,
                        @IdUnidad,
                        @PrecioVenta,
                        @Activo
                    );

                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@CodigoBarra", producto.CodigoBarra);
                    cmd.Parameters.AddWithValue("@SKU", producto.SKU);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@IdMarca", producto.IdMarca);
                    cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@IdUnidad", producto.IdUnidad);
                    cmd.Parameters.AddWithValue("@IdIVA", producto.IdIVA);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Activo", producto.Activo);

                    conexion.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public int ObtenerProximoSKU()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                    CASE
                        WHEN ISNULL(MAX(TRY_CONVERT(INT, SKU)), 999) < 999
                            THEN 1000
                        ELSE MAX(TRY_CONVERT(INT, SKU)) + 1
                    END
                    FROM Producto;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public bool ExisteCodigoBarra(string codigoBarra, int idProductoExcluir = 0)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT COUNT(*)
                    FROM Producto
                    WHERE CodigoBarra = @CodigoBarra
                      AND IdProducto <> @IdProductoExcluir;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);
                    cmd.Parameters.AddWithValue("@IdProductoExcluir", idProductoExcluir);

                    conexion.Open();

                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }
        public DataTable ObtenerProductoPorCodigoBarra(string codigoBarra)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
            SELECT
                p.IdProducto,
                p.CodigoBarra,
                p.SKU,
                p.Nombre,
                p.Descripcion,
                p.PrecioVenta,
                p.Activo,
                s.CantidadActual
            FROM Producto p
            LEFT JOIN Stock s
                ON p.IdProducto = s.IdProducto
            WHERE p.CodigoBarra = @CodigoBarra
              AND p.Activo = 1;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public DataTable CargarCategoriasActivas()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdCategoria,
                        Nombre,
                        Activo
                    FROM Categoria
                    WHERE Activo = 1
                    ORDER BY Nombre;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        da.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public DataTable CargarIVAsActivos()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdIVA,
                        Descripcion,
                        Alicuota,
                        Activo
                    FROM IVA
                    WHERE Activo = 1
                    ORDER BY Alicuota;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        da.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public int RegistrarMarca(ClsGestorEntidadProducto.ClsMarca marca)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Marca
                    (
                        Nombre,
                        Activo
                    )
                    Values
                    (
                        @Nombre,
                        @Activo
                    );

                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {

                    cmd.Parameters.AddWithValue("@Nombre", marca.Nombre);
                    cmd.Parameters.AddWithValue("@Activo", marca.Activo);

                    conexion.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
        }
        public DataTable CargarMarcasActivas()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                   SELECT
                        IdMarca,
                        Nombre,
                        Activo
                    FROM Marca
                    WHERE Activo = 1
                    ORDER BY Nombre;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        da.Fill(tabla);

                        return tabla;
                    }
                }

            }

        }
        public bool ModificarMarca(ClsGestorEntidadProducto.ClsMarca marca)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE Marca 
                    SET Nombre = @Nombre
                    WHERE IdMarca = @IdMarca";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdMarca", marca.IdMarca);
                    cmd.Parameters.AddWithValue("@Nombre", marca.Nombre);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool HabilitarMarca(int idMarca)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE Marca
                    SET Activo = 1
                    WHERE IdMarca = @IdMarca
                    AND Activo = 0";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdMarca", idMarca);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool DesactivarMarca(int idMarca)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE Marca
                    SET Activo = 0
                    WHERE IdMarca = @IdMarca
                    AND Activo = 1";
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdMarca", idMarca);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable CargarTodasLasMarcas()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdMarca,
                        Nombre,
                        Activo
                    FROM Marca
                    ORDER BY Nombre;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        da.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public DataTable BuscarMarcas(string nombre, bool soloActivos)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdMarca,
                        Nombre,
                        Activo
                    FROM Marca
                    WHERE Nombre LIKE @Nombre";

                if (soloActivos)
                {
                    consulta += @"
                        AND Activo = 1";
                }

                consulta += @"
                    ORDER BY Nombre;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        da.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public void RegistrarStock(int idProducto,decimal cantidadActual,decimal stockMinimo,decimal stockIdeal)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Stock
                    (
                        IdProducto,
                        CantidadActual,
                        StockMinimo,
                        StockIdeal
                    )
                    VALUES
                    (
                        @IdProducto,
                        @CantidadActual,
                        @StockMinimo,
                        @StockIdeal
                    );";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@CantidadActual", cantidadActual);
                    cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                    cmd.Parameters.AddWithValue("@StockIdeal", stockIdeal);

                    conexion.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool RegistrarStock (ClsGestorEntidadProducto.ClsStock stock)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Stock
                    (
                        IdProducto,
                        CantidadActual,
                        StockMinimo,
                        StockIdeal
                    )
                    VALUES
                    (
                        @IdProducto,
                        @CantidadActual,
                        @StockMinimo,
                        @StockIdeal
                    );";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", stock.IdProducto);
                    cmd.Parameters.AddWithValue("@CantidadActual", stock.CantidadActual);
                    cmd.Parameters.AddWithValue("@StockMinimo", stock.StockMinimo);
                    cmd.Parameters.AddWithValue("@StockIdeal", stock.StockIdeal);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0; 
                }
            }
        }
        public bool RegistrarLote(ClsLote lote)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO Lote
                    (
                        IdProducto,
                        CodigoLote,
                        FechaFabricacion,
                        FechaVencimiento,
                        FechaIngreso,
                        Stock,
                        Activo,
                        IdSucursal
                    )
                    VALUES
                    (
                        @IdProducto,
                        @CodigoLote,
                        @FechaFabricacion,
                        @FechaVencimiento,
                        @FechaIngreso,
                        @Stock,
                        @Activo,
                        @IdSucursal
                    );";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", lote.IdProducto);
                    cmd.Parameters.AddWithValue("@CodigoLote", lote.CodigoLote);
                    cmd.Parameters.AddWithValue("@FechaFabricacion", lote.FechaFabricacion);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", lote.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@FechaIngreso", lote.FechaIngreso);
                    cmd.Parameters.AddWithValue("@Stock", lote.Stock);
                    cmd.Parameters.AddWithValue("@Activo", lote.Activo);
                    cmd.Parameters.AddWithValue("@IdSucursal", lote.IdSucursal);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool ModificarLote(ClsLote lote)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE Lote
                    SET
                        CodigoLote = @CodigoLote,
                        FechaFabricacion = @FechaFabricacion,
                        FechaVencimiento = @FechaVencimiento,
                        IdSucursal = @IdSucursal
                    WHERE IdProducto = @IdProducto;

                    IF @@ROWCOUNT = 0
                    BEGIN
                        INSERT INTO Lote
                        (
                            IdProducto,
                            CodigoLote,
                            FechaFabricacion,
                            FechaVencimiento,
                            FechaIngreso,
                            Stock,
                            Activo,
                            IdSucursal
                        )
                        VALUES
                        (
                            @IdProducto,
                            @CodigoLote,
                            @FechaFabricacion,
                            @FechaVencimiento,
                            @FechaIngreso,
                            @Stock,
                            @Activo,
                            @IdSucursal
                        );
                    END";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", lote.IdProducto);
                    cmd.Parameters.AddWithValue("@CodigoLote", lote.CodigoLote);
                    cmd.Parameters.AddWithValue("@FechaFabricacion", lote.FechaFabricacion);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", lote.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@FechaIngreso", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Stock", lote.Stock);
                    cmd.Parameters.AddWithValue("@Activo", lote.Activo);
                    cmd.Parameters.AddWithValue("@IdSucursal", lote.IdSucursal);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable ObtenerProveedoresPorProducto(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        psp.IdProducto,
                        psp.IdSucursal,
                        sp.IdProveedor,
                        p.Nombre AS Proveedor,
                        sp.Nombre AS Sucursal,
                        psp.PrecioCompra,
                        psp.FechaPrecioCompra,
                        psp.CodigoProveedor,
                        psp.Activo
                    FROM ProductoSucursalProveedor psp
                    INNER JOIN SucursalProveedor sp
                        ON psp.IdSucursal = sp.IdSucursal
                    INNER JOIN Proveedor p
                        ON sp.IdProveedor = p.IdProveedor
                    WHERE psp.IdProducto = @IdProducto
                    ORDER BY p.Nombre, sp.Nombre;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public DataTable ObtenerProductoPorId(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        p.IdProducto,
                        p.CodigoBarra,
                        p.SKU,
                        p.Nombre,
                        p.Descripcion,
                        p.IdMarca,
                        p.IdCategoria,
                        p.IdUnidad,
                        p.PrecioVenta,
                        p.Activo,
                        p.IdIVA
                    FROM Producto p
                    WHERE p.IdProducto = @IdProducto;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public DataTable CargarArticulos()
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        p.IdProducto,
                        p.CodigoBarra,
                        p.Descripcion,
                        c.Nombre AS Rubro,
                        p.PrecioVenta,
                        p.Activo,
                        iva.Descripcion AS IVA,
                        iva.Alicuota,
                        s.CantidadActual,
                        s.StockMinimo,
                        s.StockIdeal,
                        prov.Proveedor,
                        prov.Sucursal,
                        prov.PrecioCosto,
                        lote.FechaVencimiento
                    FROM Producto p

                    INNER JOIN Categoria c
                        ON p.IdCategoria = c.IdCategoria

                    LEFT JOIN IVA iva
                        ON p.IdIVA = iva.IdIVA

                    LEFT JOIN Stock s
                        ON p.IdProducto = s.IdProducto

                    OUTER APPLY
                    (
                        SELECT TOP 1
                            pr.Nombre AS Proveedor,
                            sp.Nombre AS Sucursal,
                            psp.PrecioCompra AS PrecioCosto
                        FROM ProductoSucursalProveedor psp
                        INNER JOIN SucursalProveedor sp
                            ON psp.IdSucursal = sp.IdSucursal
                        INNER JOIN Proveedor pr
                            ON sp.IdProveedor = pr.IdProveedor
                        WHERE psp.IdProducto = p.IdProducto
                          AND psp.Activo = 1
                        ORDER BY
                            psp.FechaPrecioCompra DESC,
                            pr.Nombre,
                            sp.Nombre
                    ) prov

                    OUTER APPLY
                    (
                        SELECT TOP 1
                            l.FechaVencimiento
                        FROM Lote l
                        WHERE l.IdProducto = p.IdProducto
                          AND l.FechaVencimiento IS NOT NULL
                        ORDER BY l.FechaVencimiento ASC
                    ) lote

                    ORDER BY p.Descripcion;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public DataTable CargarArticulosParaExportar(int idProveedor, int idCategoria, int idMarca, int idSucursal, int estado, bool soloStock, bool soloVencimiento, bool soloLote)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        p.IdProducto,
                        p.CodigoBarra,
                        p.Descripcion,
                        c.Nombre AS Rubro,
                        m.Nombre AS Marca,
                        p.PrecioVenta,
                        p.Activo,
                        iva.Descripcion AS IVA,
                        iva.Alicuota,
                        s.CantidadActual,
                        s.StockMinimo,
                        s.StockIdeal,
                        prov.Proveedor,
                        prov.Sucursal,
                        prov.PrecioCosto,
                        lote.FechaVencimiento
                    FROM Producto p

                    INNER JOIN Categoria c
                        ON p.IdCategoria = c.IdCategoria

                    INNER JOIN Marca m
                         ON p.IdMarca = m.IdMarca

                    LEFT JOIN IVA iva
                        ON p.IdIVA = iva.IdIVA

                    LEFT JOIN Stock s
                        ON p.IdProducto = s.IdProducto

                    OUTER APPLY
                    (
                        SELECT TOP 1
                            pr.IdProveedor,
                            sp.IdSucursal,
                            pr.Nombre AS Proveedor,
                            sp.Nombre AS Sucursal,
                            psp.PrecioCompra AS PrecioCosto
                        FROM ProductoSucursalProveedor psp
                        INNER JOIN SucursalProveedor sp
                            ON psp.IdSucursal = sp.IdSucursal
                        INNER JOIN Proveedor pr
                            ON sp.IdProveedor = pr.IdProveedor
                        WHERE psp.IdProducto = p.IdProducto
                          AND psp.Activo = 1
                        ORDER BY
                            psp.FechaPrecioCompra DESC,
                            pr.Nombre,
                            sp.Nombre
                    ) prov

                    OUTER APPLY
                    (
                        SELECT TOP 1
                            l.FechaVencimiento
                        FROM Lote l
                        WHERE l.IdProducto = p.IdProducto
                          AND l.FechaVencimiento IS NOT NULL
                        ORDER BY l.FechaVencimiento ASC
                    ) lote

                    WHERE
                        (@IdProveedor = 0 OR prov.IdProveedor = @IdProveedor)
                        AND (@IdCategoria = 0 OR p.IdCategoria = @IdCategoria)
                        AND (@IdMarca = 0 OR m.IdMarca = @IdMarca)
                        AND (@IdSucursal = 0 OR prov.IdSucursal = @IdSucursal)
                        AND (@Estado = -1 OR p.Activo = @Estado)

                        AND (@SoloStock = 0 OR ISNULL(s.CantidadActual, 0) > 0)

                        AND (@SoloVencimiento = 0 OR lote.FechaVencimiento IS NOT NULL)

                        AND (
                            @SoloLote = 0
                            OR EXISTS
                            (
                                SELECT 1
                                FROM Lote l2
                                WHERE l2.IdProducto = p.IdProducto
                            )
                        )

                    ORDER BY p.Descripcion;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("@IdMarca", idMarca);
                    cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@SoloStock", soloStock ? 1 : 0);
                    cmd.Parameters.AddWithValue("@SoloVencimiento", soloVencimiento ? 1 : 0);
                    cmd.Parameters.AddWithValue("@SoloLote", soloLote ? 1 : 0);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public bool ModificarProducto(ClsGestorEntidadProducto.ClsProducto producto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE Producto
                    SET
                        CodigoBarra = @CodigoBarra,
                        SKU = @SKU,
                        Nombre = @Nombre,
                        Descripcion = @Descripcion,
                        IdMarca = @IdMarca,
                        IdIVA = @IdIVA,
                        IdCategoria = @IdCategoria,
                        IdUnidad = @IdUnidad,
                        PrecioVenta = @PrecioVenta
                    WHERE IdProducto = @IdProducto;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
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

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable ObtenerStockPorProducto(int idProducto)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        IdStock,
                        IdProducto,
                        CantidadActual,
                        StockMinimo,
                        StockIdeal
                    FROM Stock
                    WHERE IdProducto = @IdProducto;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }
        public void RegistrarProductoSucursalProveedor(ClsProductoSucursalProveedor relacion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    INSERT INTO ProductoSucursalProveedor
                    (
                        IdProducto,
                        IdSucursal,
                        PrecioCompra,
                        FechaPrecioCompra,
                        CodigoProveedor,
                        Activo
                    )
                    VALUES
                    (
                        @IdProducto,
                        @IdSucursal,
                        @PrecioCompra,
                        @FechaPrecioCompra,
                        @CodigoProveedor,
                        @Activo
                    );";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", relacion.IdProducto);
                    cmd.Parameters.AddWithValue("@IdSucursal", relacion.IdSucursal);
                    cmd.Parameters.AddWithValue("@PrecioCompra",(object)relacion.PrecioCompra ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaPrecioCompra",(object)relacion.FechaPrecioCompra ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CodigoProveedor",(object)relacion.CodigoProveedor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Activo", relacion.Activo);

                    conexion.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
        public bool ModificarProductoSucursalProveedor(ClsProductoSucursalProveedor relacion)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    UPDATE ProductoSucursalProveedor
                    SET
                        IdSucursal = @IdSucursal,
                        Activo = @Activo
                    WHERE IdProducto = @IdProducto;

                    IF @@ROWCOUNT = 0
                    BEGIN
                        INSERT INTO ProductoSucursalProveedor
                        (
                            IdProducto,
                            IdSucursal,
                            Activo
                        )
                        VALUES
                        (
                            @IdProducto,
                            @IdSucursal,
                            @Activo
                        );
                    END";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", relacion.IdProducto);
                    cmd.Parameters.AddWithValue("@IdSucursal", relacion.IdSucursal);
                    cmd.Parameters.AddWithValue("@Activo", relacion.Activo);

                    conexion.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable BuscarArticulos(string texto, bool ocultarDiscontinuos)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT
                        p.IdProducto,
                        p.CodigoBarra,
                        p.SKU,
                        p.Descripcion,
                        c.Nombre AS Rubro,
                        p.PrecioVenta,
                        p.Activo,
                        s.CantidadActual
                    FROM Producto p

                    INNER JOIN Categoria c
                        ON p.IdCategoria = c.IdCategoria

                    LEFT JOIN Stock s
                        ON p.IdProducto = s.IdProducto

                    WHERE
                        (
                            p.CodigoBarra LIKE @Texto
                            OR p.SKU LIKE @Texto
                            OR p.Descripcion LIKE @Texto
                        )";

                if (ocultarDiscontinuos)
                {
                    consulta += @"
                AND p.Activo = 1";
                }

                        consulta += @"
                    ORDER BY p.Descripcion;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }
        public int RegistrarProductoImportacion(ClsGestorEntidadProducto.ClsProducto producto, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"
                INSERT INTO Producto
                (
                    CodigoBarra,
                    SKU,
                    Nombre,
                    Descripcion,
                    IdMarca,
                    IdIVA,
                    IdCategoria,
                    IdUnidad,
                    PrecioVenta,
                    Activo
                )
                VALUES
                (
                    @CodigoBarra,
                    @SKU,
                    @Nombre,
                    @Descripcion,
                    @IdMarca,
                    @IdIVA,
                    @IdCategoria,
                    @IdUnidad,
                    @PrecioVenta,
                    @Activo
                );

                SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion))
            {
                cmd.Parameters.AddWithValue("@CodigoBarra",string.IsNullOrWhiteSpace(producto.CodigoBarra)? (object)DBNull.Value : producto.CodigoBarra);
                cmd.Parameters.AddWithValue("@SKU", producto.SKU);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion",string.IsNullOrWhiteSpace(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion);
                cmd.Parameters.AddWithValue("@IdMarca", producto.IdMarca);
                cmd.Parameters.AddWithValue("@IdIVA", producto.IdIVA);
                cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@IdUnidad", producto.IdUnidad);
                cmd.Parameters.AddWithValue("@PrecioVenta", 0);
                cmd.Parameters.AddWithValue("@Activo", true);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int ObtenerProximoSKUImportacion(SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"
                SELECT
                    CASE
                        WHEN ISNULL(MAX(TRY_CONVERT(INT, SKU)), 999) < 999
                            THEN 1000
                        ELSE ISNULL(MAX(TRY_CONVERT(INT, SKU)), 999) + 1
                    END
                FROM Producto WITH (UPDLOCK, HOLDLOCK);";

            using (SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void RegistrarProductoSucursalProveedorImportacion(ClsProductoSucursalProveedor relacion, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"
                INSERT INTO ProductoSucursalProveedor
                (
                    IdProducto,
                    IdSucursal,
                    PrecioCompra,
                    FechaPrecioCompra,
                    CodigoProveedor,
                    Activo
                )
                VALUES
                (
                    @IdProducto,
                    @IdSucursal,
                    @PrecioCompra,
                    @FechaPrecioCompra,
                    @CodigoProveedor,
                    @Activo
                );";

            using (SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion))
            {
                cmd.Parameters.AddWithValue("@IdProducto", relacion.IdProducto);
                cmd.Parameters.AddWithValue("@IdSucursal", relacion.IdSucursal);
                cmd.Parameters.AddWithValue("@PrecioCompra",(object)relacion.PrecioCompra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaPrecioCompra",(object)relacion.FechaPrecioCompra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodigoProveedor",(object)relacion.CodigoProveedor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", relacion.Activo);

                cmd.ExecuteNonQuery();
            }
        }
        public void RegistrarLoteImportacion(ClsLote lote,SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"
                INSERT INTO Lote
                (
                    IdProducto,
                    CodigoLote,
                    FechaFabricacion,
                    FechaVencimiento,
                    FechaIngreso,
                    Stock,
                    Activo,
                    IdSucursal
                )
                VALUES
                (
                    @IdProducto,
                    @CodigoLote,
                    @FechaFabricacion,
                    @FechaVencimiento,
                    @FechaIngreso,
                    @Stock,
                    @Activo,
                    @IdSucursal
                );";

            using (SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion))
            {
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
        public int ObtenerIdSucursalImportacion(string nombreProveedor, string nombreSucursal,SqlConnection conexion,SqlTransaction transaccion)
        {
            string consulta = @"
                SELECT sp.IdSucursal
                FROM SucursalProveedor sp
                INNER JOIN Proveedor p
                    ON sp.IdProveedor = p.IdProveedor
                WHERE p.Nombre = @NombreProveedor
                  AND sp.Nombre = @NombreSucursal
                  AND p.Activo = 1
                  AND sp.Activo = 1;";

            using (SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion))
            {
                cmd.Parameters.AddWithValue("@NombreProveedor", nombreProveedor);
                cmd.Parameters.AddWithValue("@NombreSucursal", nombreSucursal);

                object resultado = cmd.ExecuteScalar();

                if (resultado == null)
                {
                    return 0;
                }
                    

                return Convert.ToInt32(resultado);
            }
        }


    }
}
