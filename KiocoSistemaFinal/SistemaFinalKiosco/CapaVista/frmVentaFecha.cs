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
    public partial class frmVentaFecha : Form
    {
        private frmmenuPres.TipoInforme tipoInforme;
        public frmVentaFecha(frmmenuPres.TipoInforme tipo)
        {
            InitializeComponent();

            tipoInforme = tipo;

            ConfigurarFormulario();
        }

        #region Metodos
        private void ConfigurarFormulario()
        {
            switch (tipoInforme)
            {
                case frmmenuPres.TipoInforme.VentasPorFecha:
                    this.Text = " Informe de Venta por Fecha";
                    label1.Text = "Seleccione el rango de fechas para su informe.";

                    break;

                case frmmenuPres.TipoInforme.VentasConDetallePorFecha:
                    this.Text = "Informe de Venta con detalle por fecha.";
                    label1.Text = "Seleccione el rango de fechas para un informe mas detallado. ";

                    break;

                case frmmenuPres.TipoInforme.VentasPorRubro:
                    this.Text = "Informe de Venta por Rubro ";
                    label1.Text = "Seleccione el rango de fecha para su informe por Rubro. ";

                    break;

                case frmmenuPres.TipoInforme.VentasPorArticulo:
                    this.Text = " Informe de ventas por articulo.";
                    label1.Text = "Seleccione el rango de fecha para su informe por Articulo.";

                    break;

                case frmmenuPres.TipoInforme.VentaPorMedioPago:
                    this.Text = "Informe de ventas por Medio de Pagos";
                    label1.Text = "Seleccione el rango de fecha para su informe por Medios de Pagos.";

                    break;

            }

        }

        #endregion



        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "";

            switch (tipoInforme)
            {
                case frmmenuPres.TipoInforme.VentasPorFecha:
                    nombreArchivo = "Informe_Ventas_Por_Fecha.xlsx";

                    break;

                case frmmenuPres.TipoInforme.VentasConDetallePorFecha:
                    nombreArchivo = "Informe_Ventas_Con_Detalle_Por_Fecha.xlsx";

                    break;

                case frmmenuPres.TipoInforme.VentasPorRubro:
                    nombreArchivo = "Informe_Ventas_Por_Rubro.xlsx";

                    break;

                case frmmenuPres.TipoInforme.VentasPorArticulo:
                    nombreArchivo = "Informe_Ventas_Por_Articulo.xlsx";

                    break;

                case frmmenuPres.TipoInforme.VentaPorMedioPago:
                    nombreArchivo = "Informe_Ventas_Por_Medio_Pago.xlsx";

                    break;
            }

            SaveFileDialog guardar = new SaveFileDialog();

            guardar.Title = "Guardar informe de Excel";
            guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
            guardar.FileName = nombreArchivo;
            guardar.DefaultExt = "xlsx";
            guardar.AddExtension = true;

            if (guardar.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var libro = new XLWorkbook())
            {
                var hoja = libro.Worksheets.Add("Ventas");

                hoja.Cell(1, 1).Value = "Fecha";
                hoja.Cell(1, 2).Value = "Artículo";
                hoja.Cell(1, 3).Value = "Rubro";
                hoja.Cell(1, 4).Value = "Cantidad";
                hoja.Cell(1, 5).Value = "Precio";
                hoja.Cell(1, 6).Value = "Total";

                libro.SaveAs(guardar.FileName);
            }

            MessageBox.Show("El Informe se exporto correctamente.",
                "Informe generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

    }
}
