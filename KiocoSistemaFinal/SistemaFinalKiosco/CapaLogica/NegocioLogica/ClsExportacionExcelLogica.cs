using ClosedXML.Excel;
using System;
using System.Data;

namespace CapaLogica.NegocioLogica
{

    public class ClsExportacionExcelLogica
    {
        public void ExportarArticulos(DataTable tabla, string rutaArchivo)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Articulos");

                string[] encabezados =
                {
                    "Código de Barra", "Descripción", "Rubro", "Marca", "Proveedor", "Sucursal",
                    "Precio Costo", "Precio Venta", "IVA", "Alicuota", "Cantidad Actual",
                    "Stock Mínimo", "Stock Ideal", "Fecha Vencimiento", "Estado"
                };

                for (int columna = 0; columna < encabezados.Length; columna++)
                    hoja.Cell(1, columna + 1).Value = encabezados[columna];

                for (int fila = 0; fila < tabla.Rows.Count; fila++)
                {
                    DataRow registro = tabla.Rows[fila];
                    int filaExcel = fila + 2;

                    hoja.Cell(filaExcel, 1).Value = Texto(registro, "CodigoBarra");
                    hoja.Cell(filaExcel, 2).Value = Texto(registro, "Descripcion");
                    hoja.Cell(filaExcel, 3).Value = Texto(registro, "Rubro");
                    hoja.Cell(filaExcel, 4).Value = Texto(registro, "Marca");
                    hoja.Cell(filaExcel, 5).Value = Texto(registro, "Proveedor");
                    hoja.Cell(filaExcel, 6).Value = Texto(registro, "Sucursal");
                    if (registro["PrecioCosto"] != DBNull.Value) hoja.Cell(filaExcel, 7).Value = Convert.ToDecimal(registro["PrecioCosto"]);
                    if (registro["PrecioVenta"] != DBNull.Value) hoja.Cell(filaExcel, 8).Value = Convert.ToDecimal(registro["PrecioVenta"]);
                    hoja.Cell(filaExcel, 9).Value = Texto(registro, "IVA");
                    if (registro["Alicuota"] != DBNull.Value) hoja.Cell(filaExcel, 10).Value = Convert.ToDecimal(registro["Alicuota"]); hoja.Cell(filaExcel, 11).Value = DecimalOrZero(registro, "CantidadActual");
                    hoja.Cell(filaExcel, 12).Value = DecimalOrZero(registro, "StockMinimo");
                    hoja.Cell(filaExcel, 13).Value = DecimalOrZero(registro, "StockIdeal");

                    if (registro["FechaVencimiento"] != DBNull.Value)
                    {
                        hoja.Cell(filaExcel, 14).Value = Convert.ToDateTime(registro["FechaVencimiento"]);
                        hoja.Cell(filaExcel, 14).Style.DateFormat.Format = "dd/MM/yyyy";
                    }
                    else
                    {
                        hoja.Cell(filaExcel, 14).Value = "";
                    }

                    hoja.Cell(filaExcel, 15).Value = Convert.ToBoolean(registro["Activo"]) ? "Activo" : "Inactivo";
                }

                hoja.RangeUsed()?.SetAutoFilter();
                hoja.Columns().AdjustToContents();
                libro.SaveAs(rutaArchivo);
            }
        }

        public void ExportarListaPrecios(DataTable tabla, string rutaArchivo)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Lista de Precios");
                PrepararTitulo(hoja, "Lista de precios", 7);
                string[] encabezados = { "Código", "Descripción", "Rubro", "Precio Venta", "Act. Precio Venta", "Unidad Venta", "Oferta" };
                EscribirEncabezado(hoja, encabezados, 4);
                EscribirTabla(hoja, tabla, 5, 7);

                if (tabla.Rows.Count > 0)
                    hoja.Range("D5:E" + (tabla.Rows.Count + 4)).Style.NumberFormat.Format = "$ #,##0.00";

                AplicarBordes(hoja, 5, tabla.Rows.Count + 4, 7);
                Centrar(hoja, "A");
                Centrar(hoja, "C");
                AlinearDerecha(hoja, "D");
                AlinearDerecha(hoja, "E");
                Centrar(hoja, "F");
                Centrar(hoja, "G");
                hoja.Column("A").Width = 12;
                hoja.Column("B").Width = 35;
                hoja.Column("C").Width = 20;
                hoja.Column("D").Width = 18;
                hoja.Column("E").Width = 20;
                hoja.Column("F").Width = 18;
                hoja.Column("G").Width = 15;
                AplicarFiltroYCongelar(hoja, tabla.Rows.Count + 4, 7);
                libro.SaveAs(rutaArchivo);
            }
        }

        public void ExportarStock(DataTable tabla, string rutaArchivo)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Stock");
                PrepararTitulo(hoja, "Lista de Stock", 7);
                string[] encabezados = { "Código", "Descripción", "Rubro", "Stock Actual", "Stock Mínimo", "Stock Máximo", "Proveedor" };
                EscribirEncabezado(hoja, encabezados, 4);
                EscribirTabla(hoja, tabla, 5, 7);
                AplicarBordes(hoja, 5, tabla.Rows.Count + 4, 7);
                Centrar(hoja, "A");
                Centrar(hoja, "C");
                Centrar(hoja, "D");
                Centrar(hoja, "E");
                Centrar(hoja, "F");
                hoja.Column("A").Width = 12;
                hoja.Column("B").Width = 35;
                hoja.Column("C").Width = 20;
                hoja.Column("D").Width = 18;
                hoja.Column("E").Width = 18;
                hoja.Column("F").Width = 18;
                hoja.Column("G").Width = 30;
                AplicarFiltroYCongelar(hoja, tabla.Rows.Count + 4, 7);
                libro.SaveAs(rutaArchivo);
            }
        }

        public void ExportarInformeVentas(string rutaArchivo)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Ventas");
                hoja.Cell(1, 1).Value = "Fecha";
                hoja.Cell(1, 2).Value = "Artículo";
                hoja.Cell(1, 3).Value = "Rubro";
                hoja.Cell(1, 4).Value = "Cantidad";
                hoja.Cell(1, 5).Value = "Precio";
                hoja.Cell(1, 6).Value = "Total";
                libro.SaveAs(rutaArchivo);
            }
        }

        private static void PrepararTitulo(IXLWorksheet hoja, string titulo, int columnas)
        {
            string rango = $"A1:{Columna(columnas)}1";
            hoja.Range(rango).Merge();
            hoja.Cell("A1").Value = titulo;
            hoja.Cell("A1").Style.Font.Bold = true;
            hoja.Cell("A1").Style.Font.FontSize = 16;
            hoja.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            hoja.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            hoja.Row(1).Height = 30;

            hoja.Range($"A2:{Columna(columnas)}2").Merge();
            hoja.Cell("A2").Value = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            hoja.Cell("A2").Style.Font.Bold = true;
            hoja.Row(3).Height = 8;
        }

        private static void EscribirEncabezado(IXLWorksheet hoja, string[] encabezados, int fila)
        {
            for (int columna = 0; columna < encabezados.Length; columna++)
                hoja.Cell(fila, columna + 1).Value = encabezados[columna];

            var rango = hoja.Range(fila, 1, fila, encabezados.Length);
            rango.Style.Font.Bold = true;
            rango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rango.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rango.Style.Fill.BackgroundColor = XLColor.LightBlue;
            rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            hoja.Row(fila).Height = 25;
        }

        private static void EscribirTabla(IXLWorksheet hoja, DataTable tabla, int filaInicial, int columnas)
        {
            for (int fila = 0; fila < tabla.Rows.Count; fila++)
            {
                for (int columna = 0; columna < columnas && columna < tabla.Columns.Count; columna++)
                    hoja.Cell(filaInicial + fila, columna + 1).Value = tabla.Rows[fila][columna]?.ToString() ?? "";
            }
        }

        private static void AplicarBordes(IXLWorksheet hoja, int filaInicial, int filaFinal, int columnas)
        {
            if (filaFinal < filaInicial)
                return;

            var rango = hoja.Range(filaInicial, 1, filaFinal, columnas);
            rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        }

        private static void AplicarFiltroYCongelar(IXLWorksheet hoja, int filaFinal, int columnas)
        {
            if (filaFinal >= 5)
                hoja.Range(4, 1, filaFinal, columnas).SetAutoFilter();
            hoja.SheetView.FreezeRows(4);
        }

        private static void Centrar(IXLWorksheet hoja, string columna) => hoja.Column(columna).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        private static void AlinearDerecha(IXLWorksheet hoja, string columna) => hoja.Column(columna).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

        private static string Texto(DataRow fila, string columna) => fila[columna] == DBNull.Value ? "" : fila[columna]?.ToString() ?? "";
        private static object DecimalOrEmpty(DataRow fila, string columna) => fila[columna] == DBNull.Value ? "" : Convert.ToDecimal(fila[columna]);
        private static decimal DecimalOrZero(DataRow fila, string columna) => fila[columna] == DBNull.Value ? 0m : Convert.ToDecimal(fila[columna]);

        private static string Columna(int numero)
        {
            string resultado = "";
            while (numero > 0)
            {
                numero--;
                resultado = (char)('A' + numero % 26) + resultado;
                numero /= 26;
            }
            return resultado;
        }
    }
}
