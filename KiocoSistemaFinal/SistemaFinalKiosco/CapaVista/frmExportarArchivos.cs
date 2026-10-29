using CapaLogica;
using CapaLogica.NegocioLogica;
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
    public partial class frmExportarArchivos : Form
    {
        private ClsGestorProductoLogica logicaProducto;
        private ClsLogicaProveedor logicaProveedor;

        public frmExportarArchivos()
        {
            InitializeComponent();

            logicaProducto = new ClsGestorProductoLogica();
            logicaProveedor = new ClsLogicaProveedor();
        }

        #region Metodos
        private void frmExportarArchivos_Load_1(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarRubros();
            CargarMarcas();
            CargarEstados();
        }

        private void CargarProveedores()
        {
            DataTable tablaProveedores = logicaProveedor.ObtenerProveedores();

            cmbProveedor.DataSource = tablaProveedores;
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "IdProveedor";

            cmbProveedor.SelectedIndex = -1;
        }
        private void CargarRubros()
        {
            DataTable tablaRubros = logicaProducto.CargarCategoriasActivas();

            cmbRubro.DataSource = tablaRubros;
            cmbRubro.DisplayMember = "Nombre";
            cmbRubro.ValueMember = "IdCategoria";

            cmbRubro.SelectedIndex = -1;
        }
        private void CargarMarcas()
        {
            DataTable tablaMarcas = logicaProducto.CargarMarcasActivas();

            DataRow filaTodos = tablaMarcas.NewRow();
            filaTodos["IdMarca"] = 0;
            filaTodos["Nombre"] = "Todos";

            tablaMarcas.Rows.InsertAt(filaTodos, 0);

            cmbMarca.DataSource = tablaMarcas;
            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "IdMarca";

            cmbMarca.SelectedIndex = 0;
        }
        private void CargarSucursales(int idProveedor)
        {
            if (idProveedor <= 0)
            {
                cmbSucursal.DataSource = null;
                return;
            }

            DataTable tablaSucursales = logicaProveedor.ObtenerSucursalesPorProveedor(idProveedor);

            cmbSucursal.DataSource = tablaSucursales;
            cmbSucursal.DisplayMember = "Sucursal";
            cmbSucursal.ValueMember = "IdSucursal";

            cmbSucursal.SelectedIndex = -1;
        }
        private void CargarEstados()
        {
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

            cmbEstado.SelectedIndex = 0;
        }
        private DataTable ObtenerArticulosFiltrados()
        {
            int idProveedor = 0;
            int idRubro = 0;
            int idMarca = 0;
            int idSucursal = 0;
            int estado = -1;

            if (cmbProveedor.SelectedValue != null)
            {
                int.TryParse(cmbProveedor.SelectedValue.ToString(), out idProveedor);
            }

            if (cmbRubro.SelectedValue != null)
            {
                int.TryParse(cmbRubro.SelectedValue.ToString(), out idRubro);
            }

            if (cmbMarca.SelectedValue != null)
            {
                int.TryParse(cmbMarca.SelectedValue.ToString(), out idMarca);
            }

            if (cmbSucursal.SelectedValue != null)
            {
                int.TryParse(cmbSucursal.SelectedValue.ToString(), out idSucursal);
            }

            if (cmbEstado.SelectedIndex == 1)
            {
                estado = 1;
            }
            else if (cmbEstado.SelectedIndex == 2)
            {
                estado = 0;
            }

            return logicaProducto.CargarArticulosParaExportar(idProveedor, idRubro, idMarca, idSucursal, estado,
                chkArticulosStock.Checked, chkArticulosVencimiento.Checked, chkArticuloLote.Checked);
        }
        private void CrearExcel(DataTable tabla, string rutaArchivo)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Articulos");

                string[] encabezados =
                {
                    "Código de Barra",
                    "Descripción",
                    "Rubro",
                    "Marca",
                    "Proveedor",
                    "Sucursal",
                    "Precio Costo",
                    "Precio Venta",
                    "IVA",
                    "Alicuota",
                    "Cantidad Actual",
                    "Stock Mínimo",
                    "Stock Ideal",
                    "Fecha Vencimiento",
                    "Estado"
                };

                for (int columna = 0; columna < encabezados.Length; columna++)
                {
                    hoja.Cell(1, columna + 1).Value = encabezados[columna];
                }

                for (int fila = 0; fila < tabla.Rows.Count; fila++)
                {
                    DataRow registro = tabla.Rows[fila];

                    hoja.Cell(fila + 2, 1).Value = registro["CodigoBarra"]?.ToString() ?? "";
                    hoja.Cell(fila + 2, 2).Value = registro["Descripcion"]?.ToString() ?? "";
                    hoja.Cell(fila + 2, 3).Value = registro["Rubro"]?.ToString() ?? "";
                    hoja.Cell(fila + 2, 4).Value = registro["Marca"]?.ToString() ?? "";
                    hoja.Cell(fila + 2, 5).Value = registro["Proveedor"]?.ToString() ?? "";
                    hoja.Cell(fila + 2, 6).Value = registro["Sucursal"]?.ToString() ?? "";
                    hoja.Cell(fila + 2, 7).Value = registro["PrecioCosto"] == DBNull.Value ? "" : Convert.ToDecimal(registro["PrecioCosto"]);
                    hoja.Cell(fila + 2, 8).Value = registro["PrecioVenta"] == DBNull.Value ? "" : Convert.ToDecimal(registro["PrecioVenta"]);
                    hoja.Cell(fila + 2, 9).Value = registro["IVA"]?.ToString() ?? "";
                    hoja.Cell(fila + 2, 10).Value = registro["Alicuota"] == DBNull.Value ? "" : Convert.ToDecimal(registro["Alicuota"]);
                    hoja.Cell(fila + 2, 11).Value = registro["CantidadActual"] == DBNull.Value ? 0 : Convert.ToDecimal(registro["CantidadActual"]);
                    hoja.Cell(fila + 2, 12).Value = registro["StockMinimo"] == DBNull.Value ? 0: Convert.ToDecimal(registro["StockMinimo"]);
                    hoja.Cell(fila + 2, 13).Value = registro["StockIdeal"] == DBNull.Value ? 0 : Convert.ToDecimal(registro["StockIdeal"]);


                    if (registro["FechaVencimiento"] != DBNull.Value)
                    {
                        hoja.Cell(fila + 2, 13).Value = Convert.ToDateTime(registro["FechaVencimiento"]);
                        hoja.Cell(fila + 2, 13).Style.DateFormat.Format = "dd/MM/yyyy";
                    }
                    else
                    {
                        hoja.Cell(fila + 2, 13).Value = "";
                    }

                    hoja.Cell(fila + 2, 14).Value = Convert.ToBoolean(registro["Activo"]) ? "Activo" : "Inactivo";
                }

                hoja.RangeUsed().SetAutoFilter();
                hoja.Columns().AdjustToContents();

                libro.SaveAs(rutaArchivo);

                
            }
        }

        #endregion


        #region Eventos
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedValue == null)
            {
                cmbSucursal.DataSource = null;
                return;
            }

            if (!int.TryParse(cmbProveedor.SelectedValue.ToString(), out int idProveedor))
            {
                cmbSucursal.DataSource = null;
                return;
            }

            CargarSucursales(idProveedor);
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataTable tabla = ObtenerArticulosFiltrados();

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron artículos con los filtros seleccionados.",
                    "Exportar artículos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Title = "Guardar archivo de artículos";
                guardar.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                guardar.DefaultExt = "xlsx";
                guardar.AddExtension = true;
                guardar.FileName = "Articulos.xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                { 
                    return; 
                }
                    

                CrearExcel(tabla, guardar.FileName);

                MessageBox.Show($"El archivo se exportó correctamente.\n\nArtículos exportados: {tabla.Rows.Count}",
                    "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }


        #endregion
        private void label5_Click(object sender, EventArgs e)
        {

        }




    }
}