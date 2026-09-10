using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace CapaVista
{
    public partial class frmListadoReposicion : Form
    {
        public frmListadoReposicion()
        {
            InitializeComponent();
        }
        private void ExportarStockAExcel(DataGridView dgv)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Guardar lista de Stock";
                guardar.FileName = "Lista de Stock.xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                using (XLWorkbook libro = new XLWorkbook())
                {
                    // Crear hoja
                    IXLWorksheet hoja = libro.Worksheets.Add("Stock");

                    //titulo
                    hoja.Range("A1:G1").Merge();
                    hoja.Cell("A1").Value = "Lista de Stock";
                    hoja.Cell("A1").Style.Font.Bold = true;
                    hoja.Cell("A1").Style.Font.FontSize = 16;
                    hoja.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    hoja.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    hoja.Row(1).Height = 30;

                    //fecha
                    hoja.Range("A2:G2").Merge();
                    hoja.Cell("A2").Value = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
                    hoja.Cell("A2").Style.Font.Bold = true;

                    //espacio fecha encabezado
                    hoja.Row(3).Height = 8;
                    
                    //encabezado
                    string[] encabezados ={"Código","Descripción","Rubro","Stock Actual","Stock Mínimo","Stock Máximo", "Proveedor"};

                    for (int columna = 0; columna < encabezados.Length; columna++)
                    {
                        hoja.Cell(4, columna + 1).Value = encabezados[columna];
                    }
                    
                    //forma encabezado
                    var encabezado = hoja.Range("A4:G4");
                    encabezado.Style.Font.Bold = true;
                    encabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    encabezado.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    encabezado.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    encabezado.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    encabezado.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    hoja.Row(4).Height = 25;
                    
                    //copia datos dgv
                    int filaExcel = 5;

                    for (int fila = 0; fila < dgv.Rows.Count; fila++)
                    {
                        if (dgv.Rows[fila].IsNewRow)
                            continue;

                        for (int columna = 0;
                             columna < dgv.Columns.Count;
                             columna++)
                        {
                            object valor = dgv.Rows[fila].Cells[columna].Value;

                            hoja.Cell(filaExcel, columna + 1).Value = valor?.ToString() ?? "";
                        }

                        filaExcel++;
                    }

                    if (filaExcel > 5)
                    {
                        var rangoDatos = hoja.Range("A5:G" + (filaExcel - 1));
                        rangoDatos.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        rangoDatos.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    }
                    //alineacion
                    // Código
                    hoja.Column("A").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    // Rubro
                    hoja.Column("C").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    // Stock Actual
                    hoja.Column("D").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    // Stock Mínimo
                    hoja.Column("E").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    // Stock Máximo
                    hoja.Column("F").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    //Anchor columna
                    hoja.Column("A").Width = 12;
                    hoja.Column("B").Width = 35;
                    hoja.Column("C").Width = 20;
                    hoja.Column("D").Width = 18;
                    hoja.Column("E").Width = 18;
                    hoja.Column("F").Width = 18;
                    hoja.Column("G").Width = 30;

                    //filtro
                    if (filaExcel > 5)
                    {
                        hoja.Range(
                            "A4:G" + (filaExcel - 1)
                        ).SetAutoFilter();
                    }
                    
                    //congela encabezado
                    hoja.SheetView.FreezeRows(4);
                    
                    //guarda archivo
                    libro.SaveAs(guardar.FileName);
                }

                MessageBox.Show(
                    "El archivo Excel se exportó correctamente.",
                    "Exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnExportarStock_Click(object sender, EventArgs e)
        {
            ExportarStockAExcel(dgvStock);

        }
    }
}
