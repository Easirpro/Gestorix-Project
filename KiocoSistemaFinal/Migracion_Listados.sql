-- Migración: listados de precios y reposición (formulario frmListados).
-- sp_ListadoArticulos devuelve los datos de los dos listados; el formulario muestra las columnas de cada uno.
-- Se puede ejecutar más de una vez sin problemas.
USE Gestorix;
GO

/* ---------------------------------------------------------------------
   sp_ListadoArticulos: artículos activos con precio, costo, oferta
   vigente y stock, para la lista de precios y la de reposición.
   - @Texto: código de barras o SKU que empiezan así, o nombre que lo contiene.
   - @IdProducto: un artículo puntual (al agregarlo desde el buscador).
   - @IdProveedor: solo artículos de alguna sucursal de ese proveedor.
   - @IdSucursal: solo artículos de esa sucursal de proveedor (y su costo).
     Sin sucursal se toma la sucursal (del proveedor, si se indicó) con el costo más reciente.
   - @SoloOfertas: solo con una promoción vigente.
   - @SoloReponer: solo con stock en el mínimo o por debajo.
   - @Fecha: día para el que se calculan las ofertas (por defecto, hoy).
   Una oferta está vigente si la promoción está activa y vale ese día:
   por su rango de fechas y, si es recurrente, por sus días de la semana
   (DiaVigenciaPromocion usa 0 = domingo ... 6 = sábado, como DayOfWeek).
   El horario no filtra: se muestra junto al nombre de la oferta.
   --------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE dbo.sp_ListadoArticulos
    @Texto       NVARCHAR(100) = NULL,
    @IdProducto  INT           = NULL,
    @IdProveedor INT           = NULL,
    @IdSucursal  INT           = NULL,
    @IdCategoria INT           = NULL,
    @IdMarca     INT           = NULL,
    @SoloOfertas BIT           = 0,
    @SoloReponer BIT           = 0,
    @Fecha       DATE          = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SET @Texto = NULLIF(LTRIM(RTRIM(@Texto)), N'');

    DECLARE @Hoy DATE = ISNULL(@Fecha, CONVERT(DATE, GETDATE()));
    -- 0 = domingo ... 6 = sábado, sin depender de SET DATEFIRST (el 07/01/1900 fue domingo).
    DECLARE @DiaSemana TINYINT = DATEDIFF(DAY, '19000107', @Hoy) % 7;

    SELECT
        p.IdProducto,
        p.CodigoBarra,
        p.SKU,
        p.Nombre,
        c.Nombre AS Categoria,
        m.Nombre AS Marca,
        u.Simbolo AS Unidad,
        prov.Proveedor,
        prov.Sucursal,
        prov.Costo,
        p.PrecioVenta,
        promo.Oferta,
        ISNULL(s.CantidadActual, 0) AS StockActual,
        ISNULL(s.StockMinimo, 0) AS StockMinimo,
        ISNULL(s.StockIdeal, 0) AS StockIdeal,
        CASE
            WHEN ISNULL(s.StockIdeal, 0) > ISNULL(s.CantidadActual, 0)
            THEN ISNULL(s.StockIdeal, 0) - ISNULL(s.CantidadActual, 0)
            ELSE 0
        END AS AReponer,
        CASE
            WHEN ISNULL(s.CantidadActual, 0) <= 0 THEN N'Sin stock'
            WHEN ISNULL(s.CantidadActual, 0) <= ISNULL(s.StockMinimo, 0) THEN N'Bajo mínimo'
            ELSE N'Normal'
        END AS EstadoStock
    FROM dbo.Producto AS p
    LEFT JOIN dbo.Categoria AS c
        ON c.IdCategoria = p.IdCategoria
    LEFT JOIN dbo.Marca AS m
        ON m.IdMarca = p.IdMarca
    LEFT JOIN dbo.Unidad AS u
        ON u.IdUnidad = p.IdUnidad
    LEFT JOIN dbo.Stock AS s
        ON s.IdProducto = p.IdProducto
    OUTER APPLY
    (
        SELECT TOP 1
            pr.Nombre AS Proveedor,
            sp.Nombre AS Sucursal,
            psp.PrecioCompra AS Costo
        FROM dbo.ProductoSucursalProveedor AS psp
        INNER JOIN dbo.SucursalProveedor AS sp
            ON sp.IdSucursal = psp.IdSucursal
        INNER JOIN dbo.Proveedor AS pr
            ON pr.IdProveedor = sp.IdProveedor
        WHERE psp.IdProducto = p.IdProducto
          AND psp.Activo = 1
          AND (@IdProveedor IS NULL OR sp.IdProveedor = @IdProveedor)
          AND (@IdSucursal IS NULL OR psp.IdSucursal = @IdSucursal)
        ORDER BY psp.FechaPrecioCompra DESC, pr.Nombre, sp.Nombre
    ) AS prov
    OUTER APPLY
    (
        -- Todas las promociones que valen ese día, separadas por " / ".
        SELECT STRING_AGG(
            pm.Nombre +
            CASE
                WHEN v.IdPromocion IS NOT NULL
                THEN N' (' + CONVERT(NVARCHAR(5), v.HoraInicio, 108) + N' a ' + CONVERT(NVARCHAR(5), v.HoraFin, 108) + N')'
                ELSE N''
            END, N' / ') WITHIN GROUP (ORDER BY pm.Nombre) AS Oferta
        FROM dbo.DetallePromocion AS dp
        INNER JOIN dbo.Promocion AS pm
            ON pm.IdPromocion = dp.IdPromocion
        LEFT JOIN dbo.VigenciaPromocion AS v
            ON v.IdPromocion = pm.IdPromocion
        WHERE dp.IdProducto = p.IdProducto
          AND pm.Activo = 1
          AND (
                -- Sin vigencia detallada: el rango de fechas de la promoción.
                (
                    v.IdPromocion IS NULL
                    AND CONVERT(DATE, pm.FechaInicio) <= @Hoy
                    AND (pm.FechaFin IS NULL OR CONVERT(DATE, pm.FechaFin) >= @Hoy)
                )
                OR
                -- Con vigencia: su rango de fechas y, si es recurrente, que hoy sea uno de sus días.
                (
                    v.IdPromocion IS NOT NULL
                    AND v.FechaInicio <= @Hoy
                    AND (v.FechaFin IS NULL OR v.FechaFin >= @Hoy)
                    AND (
                            v.EsRecurrente = 0
                            OR NOT EXISTS (SELECT 1 FROM dbo.DiaVigenciaPromocion AS d WHERE d.IdPromocion = pm.IdPromocion)
                            OR EXISTS (SELECT 1 FROM dbo.DiaVigenciaPromocion AS d WHERE d.IdPromocion = pm.IdPromocion AND d.DiaSemana = @DiaSemana)
                        )
                )
              )
    ) AS promo
    WHERE p.Activo = 1
      AND (@IdProducto IS NULL OR p.IdProducto = @IdProducto)
      AND (
            @Texto IS NULL
            OR p.CodigoBarra LIKE @Texto + N'%'
            OR p.SKU LIKE @Texto + N'%'
            OR p.Nombre LIKE N'%' + @Texto + N'%'
          )
      AND (@IdCategoria IS NULL OR p.IdCategoria = @IdCategoria)
      AND (@IdMarca IS NULL OR p.IdMarca = @IdMarca)
      AND ((@IdProveedor IS NULL AND @IdSucursal IS NULL) OR prov.Sucursal IS NOT NULL)
      AND (@SoloOfertas = 0 OR promo.Oferta IS NOT NULL)
      AND (@SoloReponer = 0 OR ISNULL(s.CantidadActual, 0) <= ISNULL(s.StockMinimo, 0))
    ORDER BY p.Nombre;
END;
GO
