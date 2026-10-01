using CapaEntidades.NegocioEntidad;
using CapaLogica.NegocioLogica;
using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaVista
{
    public partial class frmImportarArticulos : Form
    {
        public frmImportarArticulos()
        {
            InitializeComponent();
        }

        #region Metodos
        private void ImportarArticulosDesdeExcel(string rutaArchivo)
        {
            try
            {
                ClsGestorLogicaProducto logica = new ClsGestorLogicaProducto();

                using (XLWorkbook libro = new XLWorkbook(rutaArchivo))
                {
                    //Verifica las hojas de los articulos
                    if (!libro.Worksheets.Contains("ARTICULOS"))
                    {
                        MessageBox.Show("El archivo no contiene la hoja 'ARTICULOS'.", "Importación de artículos",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    IXLWorksheet hoja = libro.Worksheet("ARTICULOS");

                    int ultimaFila = hoja.LastRowUsed()?.RowNumber() ?? 0;

                    if (ultimaFila < 3)
                    {
                        MessageBox.Show("No se encontraron artículos para importar.","Importación de artículos",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    //Listas temporalres
                    List<string> errores = new List<string>();
                    List<ClsGestorEntidadProducto.ClsProducto> productos = new List<ClsGestorEntidadProducto.ClsProducto>();
                    List<ClsGestorEntidadProducto.ClsProductoSucursalProveedor> relaciones = new List<ClsGestorEntidadProducto.ClsProductoSucursalProveedor>();
                    List<(string CodigoBarra, string Proveedor, string Sucursal, decimal PrecioCompra)> proveedoresCostos = new List<(string CodigoBarra, string Proveedor, string Sucursal, decimal PrecioCompra)>();
                    Dictionary<string, DateTime?> fechasVencimiento = new Dictionary<string, DateTime?>();

                    int cantidadArticulos = 0;

                    //Leer articuos
                    for (int fila = 3; fila <= ultimaFila; fila++)
                    {
                        string codigoBarra = hoja.Cell(fila, 1).GetString().Trim();
                        string nombre = hoja.Cell(fila, 2).GetString().Trim();
                        string descripcion = hoja.Cell(fila, 3).GetString().Trim();
                        string marca = hoja.Cell(fila, 4).GetString().Trim();
                        string categoria = hoja.Cell(fila, 5).GetString().Trim();
                        string unidad = hoja.Cell(fila, 6).GetString().Trim();
                        string ivaTexto = hoja.Cell(fila, 7).GetString().Trim();

                     
                        //Fecha vencimineto
                        DateTime? fechaVencimiento = null;

                        IXLCell celdaFecha = hoja.Cell(fila, 8);

                        if (!celdaFecha.IsEmpty())
                        {
                            //Reconoce fecha como celda
                            if (celdaFecha.DataType == XLDataType.DateTime)
                            {
                                fechaVencimiento = celdaFecha.GetDateTime().Date;
                            }
                            else
                            {
                                string fechaTexto = celdaFecha.GetString().Trim();

                                //fecha escritacomo dd/mm/aaaa
                                if (DateTime.TryParseExact(fechaTexto,new string[]
                                    {
                                        "dd/MM/yyyy",
                                        "d/M/yyyy",
                                        "dd/M/yyyy",
                                        "d/MM/yyyy"
                                    },
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None,
                                    out DateTime fechaExacta))
                                {
                                    fechaVencimiento = fechaExacta.Date;
                                }
                                
                                //Fecha como ocho digitos
                                if (!fechaVencimiento.HasValue)
                                {
                                    string numeroTexto = fechaTexto.Replace("/", "").Replace("-", "").Trim();

                                    if (numeroTexto.All(char.IsDigit))
                                    {

                                        numeroTexto = numeroTexto.PadLeft(8, '0');

                                        if (numeroTexto.Length == 8 && DateTime.TryParseExact( numeroTexto,
                                                "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime fechaNumerica))
                                        {
                                            fechaVencimiento = fechaNumerica.Date;
                                        }
                                    }
                                }

                                if (!fechaVencimiento.HasValue && DateTime.TryParse(fechaTexto,
                                        System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out DateTime fechaConvertida))
                                {
                                    fechaVencimiento =
                                        fechaConvertida.Date;
                                }

                                //La fecha no es valida
                                if (!fechaVencimiento.HasValue)
                                {
                                    errores.Add( $"Fila {fila}: la Fecha Vencimiento '{fechaTexto}' no tiene un formato válido. Use dd/MM/yyyy o 8 dígitos, por ejemplo 25092026.");

                                    continue;
                                }
                            }
                        }

                        //Fila vacia
                        if (string.IsNullOrWhiteSpace(codigoBarra) && string.IsNullOrWhiteSpace(nombre) && string.IsNullOrWhiteSpace(descripcion) && string.IsNullOrWhiteSpace(marca) &&
                            string.IsNullOrWhiteSpace(categoria) && string.IsNullOrWhiteSpace(unidad) && string.IsNullOrWhiteSpace(ivaTexto) &&
                            fechaVencimiento == null)
                        {
                            continue;
                        }

                        //Codigo de barra
                        if (!string.IsNullOrWhiteSpace(codigoBarra))
                        {
                            if (logica.ExisteCodigoBarra(codigoBarra))
                            {
                                errores.Add($"Fila {fila}: el código de barra '{codigoBarra}' ya existe en la base de datos.");

                                continue;
                            }
                        }

                        //Campos obligatorio
                        if (string.IsNullOrWhiteSpace(nombre))
                        {
                            errores.Add($"Fila {fila}: el campo 'Nombre' es obligatorio.");

                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(marca))
                        {
                            errores.Add($"Fila {fila}: el campo 'Marca' es obligatorio.");

                            continue;
                        }

                        int idMarca = logica.ObtenerIdMarcaPorNombre(marca);

                        if (idMarca == 0)
                        {
                            errores.Add($"Fila {fila}: la marca '{marca}' no existe o no está activa.");

                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(categoria))
                        {
                            errores.Add($"Fila {fila}: el campo 'Categoría' es obligatorio.");

                            continue;
                        }

                        int idCategoria = logica.ObtenerIdCategoriaPorNombre(categoria);

                        if (idCategoria == 0)
                        {
                            errores.Add($"Fila {fila}: la categoría '{categoria}' no existe o no está activa.");

                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(unidad))
                        {
                            errores.Add($"Fila {fila}: el campo 'Unidad' es obligatorio.");

                            continue;
                        }

                        int idUnidad = logica.ObtenerIdUnidadPorNombre(unidad);

                        if (idUnidad == 0)
                        {
                            errores.Add($"Fila {fila}: la unidad '{unidad}' no existe.");

                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(ivaTexto))
                        {
                            errores.Add($"Fila {fila}: el campo 'IVA' es obligatorio.");

                            continue;
                        }

                        decimal alicuota;

                        if (!decimal.TryParse(ivaTexto, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out alicuota))
                        {
                            errores.Add($"Fila {fila}: el IVA '{ivaTexto}' no tiene un formato válido.");

                            continue;
                        }

                        int idIVA = logica.ObtenerIdIVAPorAlicuota(alicuota);

                        if (idIVA == 0)
                        {
                            errores.Add($"Fila {fila}: no existe un IVA activo con alícuota {alicuota}.");

                            continue;
                        }

                        //Crear Producto
                        ClsGestorEntidadProducto.ClsProducto producto = new ClsGestorEntidadProducto.ClsProducto();

                        producto.CodigoBarra = codigoBarra;
                        producto.Nombre = nombre;
                        producto.Descripcion = descripcion;
                        producto.IdMarca = idMarca;
                        producto.IdCategoria = idCategoria;
                        producto.IdUnidad = idUnidad;
                        producto.IdIVA = idIVA;
                        producto.Activo = true;
                        producto.PrecioVenta = 0;

                        productos.Add(producto);

                        if (!string.IsNullOrWhiteSpace(codigoBarra))
                        {
                            fechasVencimiento[codigoBarra] = fechaVencimiento;
                        }

                        cantidadArticulos++;
                    }

                    //Validar articulo
                    if (cantidadArticulos == 0 && errores.Count == 0)
                    {
                        MessageBox.Show("No se encontraron artículos para importar.","Importación de artículos",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    if (errores.Count > 0)
                    {
                        string mensaje = "Se encontraron los siguientes errores:\n\n";

                        mensaje += string.Join(Environment.NewLine, errores);

                        mensaje += "\n\nNo se importó ningún artículo. Corrija el archivo y vuelva a intentarlo.";

                        MessageBox.Show(mensaje,"Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    //Verificacion proveedores costo
                    if (!libro.Worksheets.Contains("PROVEEDORES_COSTOS"))
                    {
                        MessageBox.Show("El archivo no contiene la hoja 'PROVEEDORES_COSTOS'.", "Importación de artículos",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    IXLWorksheet hojaProveedoresCostos = libro.Worksheet("PROVEEDORES_COSTOS");

                    int ultimaFilaProveedores = hojaProveedoresCostos.LastRowUsed()?.RowNumber() ?? 0;

                    //Leer proveedores costo
                    if (ultimaFilaProveedores >= 3)
                    {
                        for (int fila = 3; fila <= ultimaFilaProveedores; fila++)
                        {
                            string codigoBarra = hojaProveedoresCostos.Cell(fila, 1).GetString().Trim();
                            string proveedor = hojaProveedoresCostos.Cell(fila, 2).GetString().Trim();
                            string sucursal = hojaProveedoresCostos.Cell(fila, 3).GetString().Trim();
                            string precioTexto = hojaProveedoresCostos.Cell(fila, 4).GetString().Trim();

                            // Fila vacía
                            if (string.IsNullOrWhiteSpace(codigoBarra) && string.IsNullOrWhiteSpace(proveedor) && string.IsNullOrWhiteSpace(sucursal) && string.IsNullOrWhiteSpace(precioTexto))
                            {
                                continue;
                            }

                            if (string.IsNullOrWhiteSpace(codigoBarra))
                            {
                                errores.Add($"PROVEEDORES_COSTOS - Fila {fila}: el Código de Barra es obligatorio.");

                                continue;
                            }

                            if (string.IsNullOrWhiteSpace(proveedor))
                            {
                                errores.Add($"PROVEEDORES_COSTOS - Fila {fila}: el Proveedor es obligatorio.");

                                continue;
                            }

                            if (string.IsNullOrWhiteSpace(sucursal))
                            {
                                errores.Add($"PROVEEDORES_COSTOS - Fila {fila}: la Sucursal es obligatoria.");

                                continue;
                            }

                            if (string.IsNullOrWhiteSpace(precioTexto))
                            {
                                errores.Add($"PROVEEDORES_COSTOS - Fila {fila}: el Precio de Compra es obligatorio.");

                                continue;
                            }

                            decimal precioCompra;

                            if (!decimal.TryParse(precioTexto, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out precioCompra))
                            {
                                errores.Add($"PROVEEDORES_COSTOS - Fila {fila}: el Precio de Compra '{precioTexto}' no tiene un formato válido.");

                                continue;
                            }

                            if (precioCompra < 0)
                            {
                                errores.Add( $"PROVEEDORES_COSTOS - Fila {fila}: el Precio de Compra no puede ser negativo.");

                                continue;
                            }

                            proveedoresCostos.Add((codigoBarra, proveedor, sucursal, precioCompra));
                        }
                    }

                    //Validar codigo de barra
                    foreach (var proveedorCosto in proveedoresCostos)
                    {
                        bool existeArticuloEnImportacion = productos.Any(p => p.CodigoBarra == proveedorCosto.CodigoBarra);

                        if (!existeArticuloEnImportacion)
                        {
                            errores.Add($"PROVEEDORES_COSTOS: el código de barra '{proveedorCosto.CodigoBarra}' " + $"no corresponde a ningún artículo de la hoja ARTICULOS.");
                        }
                    }

                    //Validar proveedores y sucursales
                    if (errores.Count == 0 && proveedoresCostos.Count > 0)
                    {
                        Conexion conexionValidacion = new Conexion();

                        using (SqlConnection conexion = conexionValidacion.ObtenerConexion())
                        {
                            conexion.Open();

                            using (SqlTransaction transaccion = conexion.BeginTransaction())
                            {
                                try
                                {
                                    foreach (var proveedorCosto in proveedoresCostos)
                                    {
                                        int idSucursal = logica.ObtenerIdSucursalImportacion( proveedorCosto.Proveedor,  proveedorCosto.Sucursal, conexion, transaccion);

                                        if (idSucursal == 0)
                                        {
                                            errores.Add($"PROVEEDORES_COSTOS: el proveedor '{proveedorCosto.Proveedor}' " +
                                                $"no tiene una sucursal activa llamada '{proveedorCosto.Sucursal}'.");
                                        }
                                    }

                                    transaccion.Rollback();
                                }
                                catch
                                {
                                    try
                                    {
                                        transaccion.Rollback();
                                    }
                                    catch
                                    {
                                    }

                                    throw;
                                }
                            }
                        }
                    }

                    if (errores.Count > 0)
                    {
                        string mensaje = "Se encontraron los siguientes errores:\n\n";

                        mensaje += string.Join(Environment.NewLine,errores);
                        mensaje += "\n\nNo se importó ningún artículo. Corrija el archivo y vuelva a intentarlo.";

                        MessageBox.Show(mensaje,"Errores de validación",MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    //Guardartodo en una transaccion
                    Conexion cn = new Conexion();

                    using (SqlConnection conexion = cn.ObtenerConexion())
                    {
                        conexion.Open();

                        using (SqlTransaction transaccion = conexion.BeginTransaction())
                        {
                            try
                            {

                                //Obtener siguiente sku
                                int siguienteSKU = logica.ObtenerProximoSKUImportacion(conexion, transaccion);

                                //Registrar producto
                                foreach (ClsGestorEntidadProducto.ClsProducto producto in productos)
                                {
                                    producto.SKU = siguienteSKU.ToString();

                                    int idProducto = logica.RegistrarProductoImportacion(producto, conexion, transaccion);

                                    producto.IdProducto = idProducto;

                                    siguienteSKU++;
                                }

                                //Registrarproveedore costo y lote
                                foreach (var proveedorCosto in proveedoresCostos)
                                {
                                    ClsGestorEntidadProducto.ClsProducto producto = productos.FirstOrDefault(p => p.CodigoBarra == proveedorCosto.CodigoBarra);

                                    if (producto == null)
                                    {
                                        throw new Exception($"No se encontró el artículo con código de barra '{proveedorCosto.CodigoBarra}'.");
                                    }

                                    int idSucursal = logica.ObtenerIdSucursalImportacion(proveedorCosto.Proveedor,proveedorCosto.Sucursal,conexion, transaccion);

                                    if (idSucursal == 0)
                                    {
                                        throw new Exception($"No se encontró la sucursal '{proveedorCosto.Sucursal}' " +
                                            $"del proveedor '{proveedorCosto.Proveedor}'.");
                                    }

                                    //Relacion sucursal proveedor
                                    ClsGestorEntidadProducto.ClsProductoSucursalProveedor relacion = new ClsGestorEntidadProducto.ClsProductoSucursalProveedor();

                                    relacion.IdProducto = producto.IdProducto;
                                    relacion.IdSucursal = idSucursal;
                                    relacion.PrecioCompra = proveedorCosto.PrecioCompra;
                                    relacion.FechaPrecioCompra = DateTime.Now;
                                    relacion.CodigoProveedor = null;
                                    relacion.Activo = true;
                                    logica.RegistrarProductoSucursalProveedorImportacion(relacion, conexion,transaccion);
                                    relaciones.Add(relacion);

                                    //Lote
                                    DateTime? fechaVencimiento = null;

                                    if (!string.IsNullOrWhiteSpace(proveedorCosto.CodigoBarra))
                                    {
                                        fechasVencimiento.TryGetValue(proveedorCosto.CodigoBarra, out fechaVencimiento);
                                    }

                                    if (fechaVencimiento.HasValue)
                                    {
                                        ClsLote lote = new ClsLote();

                                        lote.IdProducto = producto.IdProducto;
                                        lote.CodigoLote = "IMP-" + producto.SKU;
                                        lote.FechaFabricacion = DateTime.Now.Date;
                                        lote.FechaVencimiento = fechaVencimiento.Value.Date;
                                        lote.FechaIngreso = DateTime.Now;
                                        lote.Stock = 0;
                                        lote.Activo = true;
                                        lote.IdSucursal = idSucursal;
                                        logica.RegistrarLoteImportacion(lote, conexion, transaccion);
                                    }
                                }

                                //Confirmar todo
                                transaccion.Commit();

                                MessageBox.Show($"Importación realizada correctamente.\n\n" +$"Artículos importados: {productos.Count}\n" +
                                    $"Relaciones proveedor/sucursal: {relaciones.Count}", "Importación de artículos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    transaccion.Rollback();
                                }
                                catch
                                {
                                }

                                MessageBox.Show("No se pudo completar la importación.\n\n" +
                                    "No se guardó ningún artículo, proveedor, costo ni lote.\n\n" +ex.Message, "Error de importación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al leer o procesar el archivo de Excel.\n\n" +ex.Message, "Importación de artículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerarPlantillaImportacion()
        {
            try
            {
                using (XLWorkbook libro = new XLWorkbook())
                {
                    //Colores
                    XLColor colorTitulo = XLColor.FromHtml("#1F4E78");
                    XLColor colorEncabezado = XLColor.FromHtml("#4472C4");
                    XLColor colorCarga = XLColor.FromHtml("#F3F8FC");
                    XLColor colorCargaAlterna = XLColor.FromHtml("#EAF2F8");
                    XLColor colorObligatorio = XLColor.FromHtml("#FCE4D6");
                    XLColor colorBorde = XLColor.FromHtml("#B4C7E7");
                    XLColor colorInstrucciones = XLColor.FromHtml("#FFF2CC");

                    //Constantes de filas
                    int filaEncabezado = 2;
                    int primeraFilaDatos = 3;
                    int ultimaFilaDatos = 502;

                    //Hoja de los articulos
                    IXLWorksheet hojaArticulos = libro.Worksheets.Add("ARTICULOS");

                    hojaArticulos.Cell(1, 1).Value = "PLANTILLA DE IMPORTACIÓN DE ARTÍCULOS";
                    hojaArticulos.Range("A1:H1").Merge();

                    //Encabezado
                    hojaArticulos.Cell(filaEncabezado, 1).Value = "Código de Barra";
                    hojaArticulos.Cell(filaEncabezado, 2).Value = "Nombre (*)";
                    hojaArticulos.Cell(filaEncabezado, 3).Value = "Descripción";
                    hojaArticulos.Cell(filaEncabezado, 4).Value = "Marca (*)";
                    hojaArticulos.Cell(filaEncabezado, 5).Value = "Categoría (*)";
                    hojaArticulos.Cell(filaEncabezado, 6).Value = "Unidad (*)";
                    hojaArticulos.Cell(filaEncabezado, 7).Value = "IVA (*)";
                    hojaArticulos.Cell(filaEncabezado, 8).Value = "Fecha Vencimiento";

                    //Estilo del titulo
                    hojaArticulos.Range("A1:H1").Style.Fill.SetBackgroundColor(colorTitulo);
                    hojaArticulos.Range("A1:H1").Style.Font.Bold = true;
                    hojaArticulos.Range("A1:H1").Style.Font.FontColor = XLColor.White;
                    hojaArticulos.Range("A1:H1").Style.Font.FontSize = 16;
                    hojaArticulos.Range("A1:H1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    hojaArticulos.Range("A1:H1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    hojaArticulos.Row(1).Height = 30;

                    //Estilo del encabedo
                    hojaArticulos.Range("A2:H2").Style.Fill.SetBackgroundColor(colorEncabezado);
                    hojaArticulos.Range("A2:H2").Style.Font.Bold = true;
                    hojaArticulos.Range("A2:H2").Style.Font.FontColor = XLColor.White;
                    hojaArticulos.Range("A2:H2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    hojaArticulos.Range("A2:H2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    hojaArticulos.Range("A2:H2").Style.Alignment.WrapText = true;
                    hojaArticulos.Row(2).Height = 30;

                    //Bordes
                    hojaArticulos.Range($"A2:H{ultimaFilaDatos}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    hojaArticulos.Range($"A2:H{ultimaFilaDatos}").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    hojaArticulos.Range($"A2:H{ultimaFilaDatos}").Style.Border.OutsideBorderColor = colorBorde;
                    hojaArticulos.Range($"A2:H{ultimaFilaDatos}").Style.Border.InsideBorderColor = colorBorde;

                    //Colo de las filas
                    hojaArticulos.Range($"A{primeraFilaDatos}:H{ultimaFilaDatos}").Style.Fill.SetBackgroundColor(colorCarga);

                    for (int fila = primeraFilaDatos; fila <= ultimaFilaDatos; fila++)
                    {
                        if (fila % 2 == 0)
                        {
                            hojaArticulos.Range($"A{fila}:H{fila}").Style.Fill.SetBackgroundColor(colorCargaAlterna);
                        }
                    }

                    //Campo oblogatorios
                    hojaArticulos.Range($"B{primeraFilaDatos}:B{ultimaFilaDatos}").Style.Fill.SetBackgroundColor(colorObligatorio);
                    hojaArticulos.Range($"D{primeraFilaDatos}:G{ultimaFilaDatos}").Style.Fill.SetBackgroundColor(colorObligatorio);

                    //Codigo de barras
                    hojaArticulos.Range($"A{primeraFilaDatos}:A{ultimaFilaDatos}").Style.NumberFormat.Format = "@";
                    hojaArticulos.Range($"A{primeraFilaDatos}:A{ultimaFilaDatos}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    //Fecha
                    IXLRange rangoFechas = hojaArticulos.Range($"H{primeraFilaDatos}:H{ultimaFilaDatos}");

                    rangoFechas.Style.NumberFormat.Format = "00\\/00\\/0000";
                    rangoFechas.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    //Alineacion
                    hojaArticulos.Range($"D{primeraFilaDatos}:G{ultimaFilaDatos}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    //Anchos
                    hojaArticulos.Column(1).Width = 18;
                    hojaArticulos.Column(2).Width = 28;
                    hojaArticulos.Column(3).Width = 35;
                    hojaArticulos.Column(4).Width = 22;
                    hojaArticulos.Column(5).Width = 22;
                    hojaArticulos.Column(6).Width = 18;
                    hojaArticulos.Column(7).Width = 15;
                    hojaArticulos.Column(8).Width = 20;

                    //Hojas auxiliares
                    IXLWorksheet hojaMarcas = libro.Worksheets.Add("_MARCAS");
                    IXLWorksheet hojaCategorias = libro.Worksheets.Add("_CATEGORIAS");
                    IXLWorksheet hojaUnidades = libro.Worksheets.Add("_UNIDADES");
                    IXLWorksheet hojaIVA = libro.Worksheets.Add("_IVA");
                    IXLWorksheet hojaProveedores = libro.Worksheets.Add("_PROVEEDORES");
                    IXLWorksheet hojaSucursales = libro.Worksheets.Add("_SUCURSALES");

                    //Marcas
                    DataTable tablaMarcas = new ClsGestorLogicaProducto().CargarMarcasActivas();

                    hojaMarcas.Cell(1, 1).Value = "Marca";

                    int filaMarca = 2;

                    foreach (DataRow fila in tablaMarcas.Rows)
                    {
                        hojaMarcas.Cell(filaMarca, 1).Value = fila["Nombre"].ToString();

                        filaMarca++;
                    }

                    //Categorias
                    DataTable tablaCategorias = new ClsGestorLogicaProducto().CargarCategoriasActivas();

                    hojaCategorias.Cell(1, 1).Value = "Categoría";

                    int filaCategoria = 2;

                    foreach (DataRow fila in tablaCategorias.Rows)
                    {
                        hojaCategorias.Cell(filaCategoria, 1).Value = fila["Nombre"].ToString();

                        filaCategoria++;
                    }

                    //Unidades
                    DataTable tablaUnidades = new ClsGestorLogicaProducto().CargarUnidades();

                    hojaUnidades.Cell(1, 1).Value = "Unidad";

                    int filaUnidad = 2;

                    foreach (DataRow fila in tablaUnidades.Rows)
                    {
                        hojaUnidades.Cell(filaUnidad, 1).Value = fila["Nombre"].ToString();

                        filaUnidad++;
                    }

                    //Iva
                    DataTable tablaIVA = new ClsGestorLogicaProducto().CargarIVAsActivos();

                    hojaIVA.Cell(1, 1).Value = "Alicuota";

                    int filaIVA = 2;

                    foreach (DataRow fila in tablaIVA.Rows)
                    {
                        hojaIVA.Cell(filaIVA, 1).Value = Convert.ToDecimal(fila["Alicuota"]);

                        filaIVA++;
                    }

                    //Proveedores
                    ClsGestorLogicaProveedor logicaProveedor = new ClsGestorLogicaProveedor();
                    DataTable tablaProveedores = logicaProveedor.ObtenerProveedores();

                    hojaProveedores.Cell(1, 1).Value = "IdProveedor";
                    hojaProveedores.Cell(1, 2).Value = "Proveedor";

                    int filaProveedor = 2;

                    foreach (DataRow fila in tablaProveedores.Rows)
                    {
                        bool proveedorActivo = false;

                        if (fila["Estado"] != DBNull.Value)
                        {
                            string estado = fila["Estado"].ToString().Trim();

                            proveedorActivo = estado.Equals("Activo", StringComparison.OrdinalIgnoreCase) ||
                            estado.Equals("1", StringComparison.OrdinalIgnoreCase) || estado.Equals("True", StringComparison.OrdinalIgnoreCase);
                        }

                        if (proveedorActivo)
                        {
                            int idProveedor;

                            if (!int.TryParse(fila["IdProveedor"].ToString(), out idProveedor))
                            {
                                continue;
                            }

                            hojaProveedores.Cell(filaProveedor, 1).Value = idProveedor;
                            hojaProveedores.Cell(filaProveedor, 2).Value = fila["RazonSocial"].ToString();

                            filaProveedor++;
                        }
                    }

                    //Sucursales
                    hojaSucursales.Cell(1, 1).Value = "IdProveedor";
                    hojaSucursales.Cell(1, 2).Value = "Proveedor";
                    hojaSucursales.Cell(1, 3).Value = "IdSucursal";
                    hojaSucursales.Cell(1, 4).Value = "Sucursal";

                    int filaSucursalAuxiliar = 2;

                    for (int fila = 2; fila < filaProveedor; fila++)
                    {
                        string valorIdProveedor = hojaProveedores.Cell(fila, 1).GetString().Trim();

                        if (!int.TryParse(valorIdProveedor, out int idProveedor))
                        {
                            continue;
                        }

                        string nombreProveedor = hojaProveedores.Cell(fila, 2).GetString().Trim();

                        if (idProveedor <= 0 || string.IsNullOrWhiteSpace(nombreProveedor))
                        {
                            continue;
                        }

                        DataTable tablaSucursales = logicaProveedor.ObtenerSucursalesPorProveedor(idProveedor);

                        if (tablaSucursales == null || tablaSucursales.Rows.Count == 0)
                        {
                            continue;
                        }

                        foreach (DataRow sucursal in tablaSucursales.Rows)
                        {
                            if (!tablaSucursales.Columns.Contains("Sucursal"))
                            {
                                continue;
                            }

                            if (sucursal["Sucursal"] == DBNull.Value)
                            {
                                continue;
                            }

                            string nombreSucursal = sucursal["Sucursal"].ToString().Trim();

                            if (string.IsNullOrWhiteSpace(nombreSucursal))
                            {
                                continue;
                            }

                            int idSucursal;

                            if (!int.TryParse(sucursal["IdSucursal"].ToString(), out idSucursal))
                            {
                                continue;
                            }

                            hojaSucursales.Cell(filaSucursalAuxiliar, 1).Value = idProveedor;
                            hojaSucursales.Cell(filaSucursalAuxiliar, 2).Value = nombreProveedor;
                            hojaSucursales.Cell(filaSucursalAuxiliar, 3).Value = idSucursal;
                            hojaSucursales.Cell(filaSucursalAuxiliar, 4).Value = nombreSucursal;

                            filaSucursalAuxiliar++;
                        }
                    }

                    //Rango nombrados
                    if (filaMarca > 2)
                    {
                        hojaMarcas.Range($"A2:A{filaMarca - 1}").AddToNamed("ListaMarcas");
                    }

                    if (filaCategoria > 2)
                    {
                        hojaCategorias.Range($"A2:A{filaCategoria - 1}").AddToNamed("ListaCategorias");
                    }

                    if (filaUnidad > 2)
                    {
                        hojaUnidades.Range($"A2:A{filaUnidad - 1}").AddToNamed("ListaUnidades");
                    }

                    if (filaIVA > 2)
                    {
                        hojaIVA.Range($"A2:A{filaIVA - 1}").AddToNamed("ListaIVA");
                    }

                    hojaArticulos.Range($"A{primeraFilaDatos}:A{ultimaFilaDatos}").AddToNamed("ListaCodigosBarra");

                    if (filaProveedor > 2)
                    {
                        hojaProveedores.Range($"B2:B{filaProveedor - 1}").AddToNamed("ListaProveedores");
                    }

                    //Validacionde los los articulos
                    if (filaMarca > 2)
                    {
                        hojaArticulos.Range($"D{primeraFilaDatos}:D{ultimaFilaDatos}").CreateDataValidation().List("=ListaMarcas");
                    }

                    if (filaCategoria > 2)
                    {
                        hojaArticulos.Range($"E{primeraFilaDatos}:E{ultimaFilaDatos}").CreateDataValidation().List("=ListaCategorias");
                    }

                    if (filaUnidad > 2)
                    {
                        hojaArticulos.Range($"F{primeraFilaDatos}:F{ultimaFilaDatos}").CreateDataValidation().List("=ListaUnidades");
                    }

                    if (filaIVA > 2)
                    {
                        hojaArticulos.Range($"G{primeraFilaDatos}:G{ultimaFilaDatos}").CreateDataValidation().List("=ListaIVA");
                    }

                    //Validacion de la fecha
                    var validacionFecha = rangoFechas.CreateDataValidation();

                    validacionFecha.IgnoreBlanks = true;

                    //Hoja de los proveedores costo

                    IXLWorksheet hojaProveedoresCostos = libro.Worksheets.Add("PROVEEDORES_COSTOS");

                    hojaProveedoresCostos.Cell(1, 1).Value = "PROVEEDORES Y COSTOS";
                    hojaProveedoresCostos.Range("A1:D1").Merge();

                    //Encabezados
                    hojaProveedoresCostos.Cell(2, 1).Value = "Código de Barra";
                    hojaProveedoresCostos.Cell(2, 2).Value = "Proveedor (*)";
                    hojaProveedoresCostos.Cell(2, 3).Value = "Sucursal (*)";
                    hojaProveedoresCostos.Cell(2, 4).Value = "Precio Compra (*)";

                    //Titulo pagina 2


                    hojaProveedoresCostos.Range("A1:D1").Style.Fill.SetBackgroundColor(colorTitulo);
                    hojaProveedoresCostos.Range("A1:D1").Style.Font.Bold = true;
                    hojaProveedoresCostos.Range("A1:D1").Style.Font.FontColor = XLColor.White;
                    hojaProveedoresCostos.Range("A1:D1").Style.Font.FontSize = 16;
                    hojaProveedoresCostos.Range("A1:D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    hojaProveedoresCostos.Range("A1:D1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    hojaProveedoresCostos.Row(1).Height = 30;

                    //Encabezados
                    hojaProveedoresCostos.Range("A2:D2").Style.Fill.SetBackgroundColor(colorEncabezado);
                    hojaProveedoresCostos.Range("A2:D2").Style.Font.Bold = true;
                    hojaProveedoresCostos.Range("A2:D2").Style.Font.FontColor = XLColor.White;
                    hojaProveedoresCostos.Range("A2:D2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    hojaProveedoresCostos.Range("A2:D2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    hojaProveedoresCostos.Range("A2:D2").Style.Alignment.WrapText = true;
                    hojaProveedoresCostos.Row(2).Height = 30;

                    //Borde
                    hojaProveedoresCostos.Range($"A2:D{ultimaFilaDatos}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    hojaProveedoresCostos.Range($"A2:D{ultimaFilaDatos}").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    hojaProveedoresCostos.Range($"A2:D{ultimaFilaDatos}").Style.Border.OutsideBorderColor = colorBorde;
                    hojaProveedoresCostos.Range($"A2:D{ultimaFilaDatos}").Style.Border.InsideBorderColor = colorBorde;

                    //Colo de las filad
                    hojaProveedoresCostos.Range($"A{primeraFilaDatos}:D{ultimaFilaDatos}").Style.Fill.SetBackgroundColor(colorCarga);

                    for (int fila = primeraFilaDatos; fila <= ultimaFilaDatos; fila++)
                    {
                        if (fila % 2 == 0)
                        {
                            hojaProveedoresCostos.Range($"A{fila}:D{fila}").Style.Fill.SetBackgroundColor(colorCargaAlterna);
                        }
                    }

                    //Obligatorios
                    hojaProveedoresCostos.Range($"B{primeraFilaDatos}:D{ultimaFilaDatos}").Style.Fill.SetBackgroundColor(colorObligatorio);

                    //Codigo de barra
                    hojaProveedoresCostos.Range($"A{primeraFilaDatos}:A{ultimaFilaDatos}").Style.NumberFormat.Format = "@";
                    hojaProveedoresCostos.Range($"A{primeraFilaDatos}:A{ultimaFilaDatos}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    //Precio
                    hojaProveedoresCostos.Range($"D{primeraFilaDatos}:D{ultimaFilaDatos}").Style.NumberFormat.Format = "#,##0.00";
                    hojaProveedoresCostos.Range($"D{primeraFilaDatos}:D{ultimaFilaDatos}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    //Sucursal
                    hojaProveedoresCostos.Range($"C{primeraFilaDatos}:C{ultimaFilaDatos}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    //Anchos
                    hojaProveedoresCostos.Column(1).Width = 20;
                    hojaProveedoresCostos.Column(2).Width = 30;
                    hojaProveedoresCostos.Column(3).Width = 30;
                    hojaProveedoresCostos.Column(4).Width = 20;

                    //Validacioon del codgigo de barras
                    var validacionCodigo = hojaProveedoresCostos.Range($"A{primeraFilaDatos}:A{ultimaFilaDatos}").CreateDataValidation();

                    validacionCodigo.List("=ListaCodigosBarra");
                    validacionCodigo.IgnoreBlanks = true;

                    //Validacion de los proveedores
                    if (filaProveedor > 2)
                    {
                        hojaProveedoresCostos.Range($"B{primeraFilaDatos}:B{ultimaFilaDatos}").CreateDataValidation().List("=ListaProveedores");
                    }

                    //Rango de sucursales
                    int ultimaFilaSucursales = 0;

                    if (hojaSucursales.LastRowUsed() != null)
                    {
                        ultimaFilaSucursales = hojaSucursales.LastRowUsed().RowNumber();
                    }

                    for (int fila = 2; fila < filaProveedor; fila++)
                    {
                        string valorIdProveedor = hojaProveedores.Cell(fila, 1).GetString().Trim();

                        if (!int.TryParse(valorIdProveedor, out int idProveedor))
                        {
                            continue;
                        }

                        string nombreRango = "Proveedor_" + idProveedor;

                        List<string> sucursales = new List<string>();

                        for (int filaS = 2; filaS <= ultimaFilaSucursales; filaS++)
                        {
                            string valorIdProveedorSucursal = hojaSucursales.Cell(filaS, 1).GetString().Trim();

                            if (!int.TryParse(valorIdProveedorSucursal, out int idProveedorSucursal))
                            {
                                continue;
                            }

                            if (idProveedorSucursal == idProveedor)
                            {
                                string nombreSucursal = hojaSucursales.Cell(filaS, 4).GetString().Trim();

                                if (!string.IsNullOrWhiteSpace(nombreSucursal))
                                {
                                    sucursales.Add(nombreSucursal);
                                }
                            }
                        }

                        if (sucursales.Count > 0)
                        {
                            int columna = 5 + idProveedor;

                            for (int i = 0; i < sucursales.Count; i++)
                            {
                                hojaSucursales.Cell(i + 2, columna).Value = sucursales[i];
                            }

                            IXLRange rangoSucursal = hojaSucursales.Range(hojaSucursales.Cell(2, columna), hojaSucursales.Cell( sucursales.Count + 1, columna));

                            libro.NamedRanges.Add(nombreRango, rangoSucursal);
                        }
                    }

                    //Sucursal dependiente
                    if (filaProveedor > 2)
                    {
                        string ultimaFilaProveedor = (filaProveedor - 1).ToString();

                        for (int fila = primeraFilaDatos; fila <= ultimaFilaDatos; fila++)
                        {
                            string formulaSucursal = "=INDIRECT(" +
                                "\"Proveedor_\"&" +
                                "INDEX(" +
                                "_PROVEEDORES!$A$2:$A$" +
                                ultimaFilaProveedor +
                                ",MATCH(B" +
                                fila +
                                ",_PROVEEDORES!$B$2:$B$" +
                                ultimaFilaProveedor +
                                ",0)" +
                                ")" +
                                ")";

                            var validacionSucursal = hojaProveedoresCostos.Cell(fila, 3).CreateDataValidation();
                            validacionSucursal.List(formulaSucursal);
                            validacionSucursal.IgnoreBlanks = true;
                            validacionSucursal.InCellDropdown = true;
                        }
                    }

                    IXLWorksheet hojaInstrucciones = libro.Worksheets.Add("INSTRUCCIONES");

                    hojaInstrucciones.Cell(1, 1).Value = "INSTRUCCIONES PARA IMPORTAR ARTÍCULOS";
                    hojaInstrucciones.Range("A1:D1").Merge();

                    //Instrucciones
                    hojaInstrucciones.Cell(2, 1).Value = "IMPORTACIÓN DE ARTÍCULOS";
                    hojaInstrucciones.Range("A2:D2").Merge();
                    hojaInstrucciones.Cell(3, 1).Value = "1. Complete la hoja ARTICULOS.";
                    hojaInstrucciones.Cell(4, 1).Value = "2. Los campos marcados con (*) son obligatorios.";
                    hojaInstrucciones.Cell(5, 1).Value = "3. Seleccione Marca, Categoría, Unidad e IVA mediante los desplegables.";
                    hojaInstrucciones.Cell(6, 1).Value = "4. La Fecha Vencimiento puede cargarse como dd/MM/yyyy o como 8 dígitos, por ejemplo 25092026.";
                    hojaInstrucciones.Cell(7, 1).Value = "5. En PROVEEDORES_COSTOS puede cargar más de una fila para el mismo artículo.";
                    hojaInstrucciones.Cell(8, 1).Value = "6. Seleccione primero el Proveedor y luego la Sucursal correspondiente.";
                    hojaInstrucciones.Cell(9, 1).Value = "7. La Sucursal se filtra automáticamente según el Proveedor seleccionado.";
                    hojaInstrucciones.Cell(10, 1).Value = "8. El Código de Barra de PROVEEDORES_COSTOS se obtiene de los códigos cargados en ARTICULOS.";
                    hojaInstrucciones.Cell(11, 1).Value = "9. El Precio de Compra debe ser mayor o igual a cero.";
                    hojaInstrucciones.Cell(13, 1).Value = "IMPORTANTE";
                    hojaInstrucciones.Range("A13:D13").Merge();
                    hojaInstrucciones.Cell(14, 1).Value = "No modifique ni elimine las hojas auxiliares ocultas.";
                    hojaInstrucciones.Cell(15, 1).Value = "Los campos con (*) son necesarios para realizar la importación.";
                    hojaInstrucciones.Column(1).Width = 100;

                    //Estilo instrucciones
                    hojaInstrucciones.Range("A1:D1").Style.Fill.SetBackgroundColor(colorTitulo);
                    hojaInstrucciones.Range("A1:D1").Style.Font.Bold = true;
                    hojaInstrucciones.Range("A1:D1").Style.Font.FontColor = XLColor.White;
                    hojaInstrucciones.Range("A1:D1").Style.Font.FontSize = 16;
                    hojaInstrucciones.Range("A1:D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    hojaInstrucciones.Range("A2:D2").Style.Fill.SetBackgroundColor(colorEncabezado);
                    hojaInstrucciones.Range("A2:D2").Style.Font.Bold = true;
                    hojaInstrucciones.Range("A2:D2").Style.Font.FontColor = XLColor.White;
                    hojaInstrucciones.Range("A2:D2").Style.Font.FontSize = 13;
                    hojaInstrucciones.Range("A13:D13").Style.Fill.SetBackgroundColor(colorObligatorio);
                    hojaInstrucciones.Range("A13:D13").Style.Font.Bold = true;
                    hojaInstrucciones.Range("A14:D15").Style.Fill.SetBackgroundColor(colorInstrucciones);
                    hojaInstrucciones.Range("A3:A15").Style.Alignment.WrapText = true;

                    //Filtros
                    hojaArticulos.Range($"A2:H{ultimaFilaDatos}").SetAutoFilter();
                    hojaProveedoresCostos.Range($"A2:D{ultimaFilaDatos}").SetAutoFilter();

                    //Congelar los encabezados
                    hojaArticulos.SheetView.FreezeRows(2);
                    hojaProveedoresCostos.SheetView.FreezeRows(2);

                    //Oculta las hojas auxiliares
                    hojaMarcas.Visibility = XLWorksheetVisibility.VeryHidden;
                    hojaCategorias.Visibility = XLWorksheetVisibility.VeryHidden;
                    hojaUnidades.Visibility = XLWorksheetVisibility.VeryHidden;
                    hojaIVA.Visibility = XLWorksheetVisibility.VeryHidden;
                    hojaProveedores.Visibility = XLWorksheetVisibility.VeryHidden;
                    hojaSucursales.Visibility = XLWorksheetVisibility.VeryHidden;

                    //Guardar
                    SaveFileDialog guardar = new SaveFileDialog();

                    guardar.Title = "Guardar plantilla de importación";
                    guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                    guardar.FileName = "Plantilla_Importacion_Articulos.xlsx";
                    guardar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        libro.SaveAs(guardar.FileName);

                        MessageBox.Show("La plantilla fue generada correctamente.","Plantilla de importación",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar la plantilla.\n\n" + ex.Message, "Plantilla de importación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Eventos
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirArchivo = new OpenFileDialog();

            abrirArchivo.Title = "Seleccionar plantilla de artículos";
            abrirArchivo.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
            abrirArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            abrirArchivo.Multiselect = false;

            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                txtTraerArchivo.Text = abrirArchivo.FileName;
            }
        }
        private void btnDescargarPlanilla_Click(object sender, EventArgs e)
        {
            GenerarPlantillaImportacion();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTraerArchivo.Text))
            {
                MessageBox.Show("Debe seleccionar un archivo de Excel.", "Importación de artículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!File.Exists(txtTraerArchivo.Text))
            {
                MessageBox.Show("El archivo seleccionado no existe.", "Importación de artículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            ImportarArticulosDesdeExcel(txtTraerArchivo.Text);
        }
        #endregion

    }
}
