using CapaEntidades.NegocioEntidad;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    SELECT ISNULL(MAX(TRY_CONVERT(INT, SKU)), 99) + 1
                    FROM Producto;";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public bool ExisteCodigoBarra(string codigoBarra)
        {
            using (SqlConnection conexion = cn.ObtenerConexion())
            {
                string consulta = @"
                    SELECT COUNT(*)
                    FROM Producto
                    WHERE CodigoBarra = @CodigoBarra";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);

                    conexion.Open();

                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                    return cantidad > 0;
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
    }
}
