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
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;

namespace CapaVista
{
    public partial class frmCobroSecundario : Form
    {
        private decimal subtotal = 0.00m;
        private decimal descuentoRecargo = 0.00m;
        private decimal total = 0.00m;

        private ClsLogicaProducto logicaProducto = new ClsLogicaProducto();
        private DataTable tablaProductosEncontrados;

        private DataGridView grillaPrincipal;

        public frmCobroSecundario()
        {
            InitializeComponent();
        }

        public frmCobroSecundario(DataGridView grillaPrincipal)
        {
            InitializeComponent();
            this.grillaPrincipal = grillaPrincipal;
        }


        #region Metodos
        private bool AgregarProductoAGrilla(int idProducto, string sku, string codigoBarra, string descripcion, decimal precio, decimal cantidad, decimal stockDisponible)
        {
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Cantidad inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.", "Precio inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal cantidadYaCargada = 0m;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    continue;

                if (Convert.ToInt32(fila.Cells["ClnIdProducto"].Value) == idProducto)
                {
                    cantidadYaCargada += Convert.ToDecimal(fila.Cells["ClnCantidad"].Value);
                }
            }

            decimal cantidadEnGrillaPrincipal = 0m;

            if (grillaPrincipal != null)
            {
                foreach (DataGridViewRow fila in grillaPrincipal.Rows)
                {
                    if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                        continue;

                    if (int.TryParse(Convert.ToString(fila.Cells["ClnIdProducto"].Value), out int idCargado) && idCargado == idProducto)
                    {
                        if (decimal.TryParse(Convert.ToString(fila.Cells["ClnCantidad"].Value), out decimal cantidadCargada))
                        {
                            cantidadEnGrillaPrincipal += cantidadCargada;
                        }
                    }
                }
            }

            decimal cantidadTotal = cantidadYaCargada + cantidadEnGrillaPrincipal + cantidad;

            if (stockDisponible <= 0 || cantidadTotal > stockDisponible)
            {
                decimal stockRestante = Math.Max(0m, stockDisponible - cantidadYaCargada - cantidadEnGrillaPrincipal);

                MessageBox.Show($"Stock insuficiente.\n" + $"Stock en sistema: {stockDisponible}\n" +
                    $"Cantidad en venta principal: {cantidadEnGrillaPrincipal}\n" + $"Cantidad en venta secundaria: {cantidadYaCargada}\n" + $"Stock disponible para agregar: {stockRestante}\n" +
                    $"Cantidad a agregar: {cantidad}", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }


            DataGridViewRow filaDestino = null;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["ClnIdProducto"].Value == null || string.IsNullOrWhiteSpace(Convert.ToString(fila.Cells["ClnIdProducto"].Value)))
                {
                    filaDestino = fila;
                    break;
                }
            }

            if (filaDestino == null)
            {
                int indice = dtgPresentacion.Rows.Add();
                filaDestino = dtgPresentacion.Rows[indice];
            }

            filaDestino.Cells["ClnIdProducto"].Value = idProducto;
            filaDestino.Cells["ClnSKU"].Value = sku;
            filaDestino.Cells["ClnCodigo"].Value = codigoBarra;
            filaDestino.Cells["ClnDescripcion"].Value = descripcion;
            filaDestino.Cells["ClnCantidad"].Value = cantidad;
            filaDestino.Cells["ClnPrecioUnitario"].Value = precio;
            filaDestino.Cells["ClnImporte"].Value = Math.Round(cantidad * precio, 2);

            CalcularYMostrarMontos();
            dtgPresentacion.Refresh();

            return true;
        }
        private void IngresarProductoPorCodigo()
        {
            string codigoBarra = txtCodigoBarra.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigoBarra))
            {
                txtCodigoBarra.Focus();
                return;
            }

            decimal cantidad = 1m;

            if (!string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                if (!decimal.TryParse(txtCantidad.Text, out cantidad) ||
                    cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Cantidad inválida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }
            }

            ClsLogicaProducto logicaProducto = new ClsLogicaProducto();

            DataTable tablaProducto = logicaProducto.ObtenerProductoPorCodigoBarra(codigoBarra);

            if (tablaProducto == null || tablaProducto.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró un producto con ese código de barras.", "Producto no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigoBarra.SelectAll();
                txtCodigoBarra.Focus();
                return;
            }

            DataRow producto = tablaProducto.Rows[0];

            int idProducto = Convert.ToInt32(producto["IdProducto"]);
            string sku = Convert.ToString(producto["SKU"]);
            string codigo = Convert.ToString(producto["CodigoBarra"]);
            string descripcion = Convert.ToString(producto["Descripcion"]);
            decimal precio = Convert.ToDecimal(producto["PrecioVenta"]);

            decimal stockDisponible = producto["CantidadActual"] == DBNull.Value ? 0m : Convert.ToDecimal(producto["CantidadActual"]);

            bool agregado = AgregarProductoAGrilla(idProducto, sku, codigo, descripcion, precio, cantidad, stockDisponible);

            if (agregado)
            {
                txtCodigoBarra.Clear();
                txtCantidad.Clear();
            }

            txtCodigoBarra.Focus();
        }
        private void CalcularYMostrarMontos()
        {
            decimal nuevoSubtotal = 0m;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    continue;

                object valorImporte = fila.Cells["ClnImporte"].Value;

                if (valorImporte != null && valorImporte != DBNull.Value && decimal.TryParse(Convert.ToString(valorImporte), out decimal importe))
                {
                    nuevoSubtotal += importe;
                }
            }

            subtotal = Math.Round(nuevoSubtotal, 2);
            total = Math.Max(0m, Math.Round(subtotal + descuentoRecargo, 2));

            lblSubtotalMonto.Text = subtotal.ToString("C2");
            lblDescuentoMonto.Text = Math.Abs(descuentoRecargo).ToString("C2");
            lblTotalMonto.Visible = true;
            lblTotalMonto.AutoSize = false;
            lblTotalMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblTotalMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            lblTotalMonto.Text = total.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("es-AR"));
        }
        private void LimpiarVenta()
        {
            dtgPresentacion.Rows.Clear();

            subtotal = 0m;
            descuentoRecargo = 0m;
            total = 0m;

            CalcularYMostrarMontos();
            RellenarFilas();

            txtCodigoBarra.Clear();
            txtCantidad.Clear();
            txtCodigoBarra.Focus();
        }
        private void RellenarFilas()
        {
            int filasVisibles = dtgPresentacion.Height / dtgPresentacion.RowTemplate.Height;

            while (dtgPresentacion.Rows.Count < filasVisibles)
            {
                dtgPresentacion.Rows.Add();
            }
        }
        public decimal ObtenerCantidadCargada(int idProducto)
        {
            decimal cantidadTotal = 0m;

            foreach (DataGridViewRow fila in dtgPresentacion.Rows)
            {
                if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    continue;

                if (int.TryParse(Convert.ToString(fila.Cells["ClnIdProducto"].Value), out int idCargado) && idCargado == idProducto)
                {
                    if (decimal.TryParse(Convert.ToString(fila.Cells["ClnCantidad"].Value), out decimal cantidad))
                    {
                        cantidadTotal += cantidad;
                    }
                }
            }

            return cantidadTotal;
        }
        private decimal ObtenerCantidadEnGrillaPrincipal(int idProducto)
        {
            decimal cantidadTotal = 0m;

            foreach (DataGridViewRow fila in grillaPrincipal.Rows)
            {
                if (fila.IsNewRow || fila.Cells["ClnIdProducto"].Value == null)
                    continue;

                if (int.TryParse(Convert.ToString(fila.Cells["ClnIdProducto"].Value), out int idCargado) && idCargado == idProducto)
                {
                    if (decimal.TryParse(Convert.ToString(fila.Cells["ClnCantidad"].Value), out decimal cantidad))
                    {
                        cantidadTotal += cantidad;
                    }
                }
            }

            return cantidadTotal;
        }
        private void AgregarProductoSeleccionado()
        {
            if (lstDescripcion.SelectedIndex < 0 || tablaProductosEncontrados == null)
                return;

            decimal cantidad;

            if (!decimal.TryParse(txtCantidad.Text.Trim(), out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingresá una cantidad válida mayor que cero.", "Cantidad inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCantidad.Focus();
                txtCantidad.SelectAll();
                return;
            }

            int indice = lstDescripcion.SelectedIndex;

            if (indice >= tablaProductosEncontrados.Rows.Count)
                return;

            DataRow fila = tablaProductosEncontrados.Rows[indice];

            int idProducto = Convert.ToInt32(fila["IdProducto"]);
            string sku = fila["SKU"].ToString();
            string codigoBarra = fila["CodigoBarra"].ToString();
            string descripcion = fila["Descripcion"].ToString();
            decimal precio = Convert.ToDecimal(fila["PrecioVenta"]);

            DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

            decimal stockDisponible = 0m;

            if (tablaStock != null && tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
            {
                stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
            }

            AgregarProductoAGrilla(idProducto, sku, codigoBarra, descripcion, precio, cantidad, stockDisponible);

            lstDescripcion.Visible = false;
            lstDescripcion.Items.Clear();
            txtCodigoBarra.Clear();
            txtCodigoBarra.Focus();
        }





        #endregion



        #region Eventos
        private void frmCobroSecundario_Load(object sender, EventArgs e)
        {
            dtgPresentacion.ReadOnly = true;
            dtgPresentacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPresentacion.MultiSelect = false;
            dtgPresentacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgPresentacion.AllowUserToResizeColumns = false;
            dtgPresentacion.AllowUserToResizeRows = false;
            dtgPresentacion.AllowUserToOrderColumns = false;
            dtgPresentacion.RowHeadersVisible = false;
            txtCantidad.Text = "1";

            this.KeyPreview = true;

            CalcularYMostrarMontos();
            RellenarFilas();

            txtCodigoBarra.Focus();
        }
        private void btnCobrar_Click_1(object sender, EventArgs e)
        {
            CalcularYMostrarMontos();

            if (total <= 0)
            {
                MessageBox.Show("No hay productos para cobrar.", "Venta vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            using (frmInformeCobro formularioCobro = new frmInformeCobro(total, dtgPresentacion))
            {
                if (formularioCobro.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            using (frmBuscarArticulo buscarArticulo = new frmBuscarArticulo())
            {
                buscarArticulo.ShowDialog();

                ClsProducto producto = buscarArticulo.ProductoSeleccionado;

                if (producto == null)
                {
                    MessageBox.Show("No se recibió ningún producto seleccionado. " + "Revisá el botón de selección de frmBuscarArticulo.", "Producto no seleccionado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClsLogicaProducto logicaProducto = new ClsLogicaProducto();

                DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(producto.IdProducto);

                decimal stockDisponible = 0m;

                if (tablaStock != null && tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                {
                    stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                }

                AgregarProductoAGrilla(producto.IdProducto, producto.SKU, producto.CodigoBarra, producto.Descripcion, producto.PrecioVenta, 1m, stockDisponible);

                txtCodigoBarra.Focus();
            }
        }
        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                IngresarProductoPorCodigo();
            }
        }
        private void btnCambiarcantidad_Click(object sender, EventArgs e)
        {
            if (dtgPresentacion.CurrentRow == null || dtgPresentacion.CurrentRow.IsNewRow || dtgPresentacion.CurrentRow.Cells["ClnIdProducto"].Value == null)
            {
                MessageBox.Show("Seleccione un producto para cambiar la cantidad.", "Cambiar cantidad",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dtgPresentacion.CurrentRow;

            string codigoFila = Convert.ToString(fila.Cells["ClnCodigo"].Value);

            if (codigoFila == "PROMOCION")
            {
                MessageBox.Show("No se puede modificar la cantidad de un producto que pertenece a una promoción.", "Cambiar cantidad",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigoBarra.Focus();
                return;
            }

            int idProducto = Convert.ToInt32(fila.Cells["ClnIdProducto"].Value);

            decimal cantidadActual = Convert.ToDecimal(fila.Cells["ClnCantidad"].Value);

            string entrada = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nueva cantidad:", "Cambiar cantidad", cantidadActual.ToString());

            if (string.IsNullOrWhiteSpace(entrada))
                return;

            if (!decimal.TryParse(entrada, out decimal nuevaCantidad) || nuevaCantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Cantidad inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClsLogicaProducto logicaProducto = new ClsLogicaProducto();

            DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

            decimal stockDisponible = 0m;

            if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
            {
                stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
            }

            decimal cantidadEnSecundariaSinFila = 0m;

            foreach (DataGridViewRow otraFila in dtgPresentacion.Rows)
            {
                if (otraFila.IsNewRow || otraFila == fila || otraFila.Cells["ClnIdProducto"].Value == null)
                    continue;

                if (int.TryParse(Convert.ToString(otraFila.Cells["ClnIdProducto"].Value), out int idCargado) && idCargado == idProducto)
                {
                    if (decimal.TryParse(Convert.ToString(otraFila.Cells["ClnCantidad"].Value), out decimal cantidadCargada))
                    {
                        cantidadEnSecundariaSinFila += cantidadCargada;
                    }
                }
            }

            decimal cantidadEnPrincipal = grillaPrincipal == null ? 0m : ObtenerCantidadEnGrillaPrincipal(idProducto);
            decimal cantidadTotal = cantidadEnSecundariaSinFila + cantidadEnPrincipal + nuevaCantidad;

            if (stockDisponible <= 0 || cantidadTotal > stockDisponible)
            {
                decimal stockRestante = Math.Max(0m, stockDisponible - cantidadEnSecundariaSinFila - cantidadEnPrincipal);

                MessageBox.Show($"Stock insuficiente.\n\n" + $"Stock en sistema: {stockDisponible}\n" + $"Otras unidades en venta secundaria: {cantidadEnSecundariaSinFila}\n" +
                    $"Unidades en venta principal: {cantidadEnPrincipal}\n" + $"Disponible para esta fila: {stockRestante}\n" + $"Cantidad solicitada: {nuevaCantidad}",
                    "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precioUnitario = Convert.ToDecimal(fila.Cells["ClnPrecioUnitario"].Value);

            fila.Cells["ClnCantidad"].Value = nuevaCantidad;
            fila.Cells["ClnImporte"].Value = Math.Round(nuevaCantidad * precioUnitario, 2);

            CalcularYMostrarMontos();
            dtgPresentacion.Refresh();
        }
        private void btnPromocion_Click(object sender, EventArgs e)
        {
            using (frmBuscarPromo buscarPromo = new frmBuscarPromo())
            {
                if (buscarPromo.ShowDialog() != DialogResult.OK)
                    return;

                int idPromocion = buscarPromo.IdPromocionSeleccionada;

                try
                {
                    ClsPromocionLogica logicaPromo = new ClsPromocionLogica();
                    ClsLogicaProducto logicaProducto = new ClsLogicaProducto();

                    DataSet datos = logicaPromo.ObtenerPromocionPorId(idPromocion);

                    if (datos == null || datos.Tables.Count < 2 || datos.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron los datos de la promoción.");
                        return;
                    }

                    DataRow promo = datos.Tables[0].Rows[0];

                    if (promo["Activo"] == DBNull.Value || !Convert.ToBoolean(promo["Activo"]))
                    {
                        MessageBox.Show("La promoción seleccionada está inactiva.");
                        return;
                    }

                    DataTable detalles = datos.Tables[1];

                    if (detalles.Rows.Count == 0)
                    {
                        MessageBox.Show("La promoción no tiene productos asociados.");
                        return;
                    }

                    int idTipoPromocion = Convert.ToInt32(promo["IdTipoPromocion"]);
                    decimal valor = Convert.ToDecimal(promo["Valor"]);

                    DataTable tipos = logicaPromo.ObtenerTiposPromocion();

                    DataRow[] tiposEncontrados = tipos.Select("IdTipoPromocion = " + idTipoPromocion);

                    if (tiposEncontrados.Length == 0)
                    {
                        MessageBox.Show("No se encontró el tipo de promoción.");
                        return;
                    }

                    DataRow tipoPromocion = tiposEncontrados[0];

                    bool esVolumen = tipoPromocion["CantidadLleva"] != DBNull.Value && tipoPromocion["CantidadPaga"] != DBNull.Value;

                    int cantidadLleva = 0;
                    int cantidadPaga = 0;

                    if (esVolumen)
                    {
                        cantidadLleva = Convert.ToInt32(tipoPromocion["CantidadLleva"]);
                        cantidadPaga = Convert.ToInt32(tipoPromocion["CantidadPaga"]);

                        if (cantidadLleva <= 0 || cantidadPaga <= 0 || cantidadPaga >= cantidadLleva)
                        {
                            MessageBox.Show("La mecánica de volumen no es válida.");
                            return;
                        }
                    }
                    else if (idTipoPromocion == 4)
                    {
                        if (valor <= 0 || valor > 100)
                        {
                            MessageBox.Show("El porcentaje de descuento no es válido.");
                            return;
                        }
                    }
                    else if (idTipoPromocion == 5)
                    {
                        if (valor <= 0)
                        {
                            MessageBox.Show("El precio especial no es válido.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El tipo de promoción no es válido.");
                        return;
                    }

                    decimal precioFinal = 0m;
                    var cantidadesPromocion = new Dictionary<int, decimal>();

                    foreach (DataRow detalle in detalles.Rows)
                    {
                        int idProducto = Convert.ToInt32(detalle["IdProducto"]);
                        decimal cantidadConfigurada = Convert.ToDecimal(detalle["Cantidad"]);
                        decimal precioUnitario = Convert.ToDecimal(detalle["PrecioVenta"]);

                        if (cantidadConfigurada <= 0 || precioUnitario < 0)
                        {
                            MessageBox.Show("La cantidad o el precio de un producto no son válidos.");
                            return;
                        }

                        decimal cantidadAgregar = esVolumen ? cantidadConfigurada * cantidadLleva : cantidadConfigurada;

                        if (esVolumen)
                        {
                            precioFinal += cantidadConfigurada * cantidadPaga * precioUnitario;
                        }
                        else if (idTipoPromocion == 4)
                        {
                            precioFinal += cantidadConfigurada * precioUnitario * (1m - valor / 100m);
                        }
                        else if (idTipoPromocion == 5)
                        {
                            precioFinal += cantidadConfigurada * valor;
                        }

                        if (cantidadesPromocion.ContainsKey(idProducto))
                            cantidadesPromocion[idProducto] += cantidadAgregar;
                        else
                            cantidadesPromocion[idProducto] = cantidadAgregar;
                    }

                    precioFinal = Math.Round(precioFinal, 2);

                    foreach (var producto in cantidadesPromocion)
                    {
                        DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(producto.Key);

                        decimal stockDisponible = 0m;

                        if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                        {
                            stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                        }

                        decimal cantidadPrincipal = ObtenerCantidadEnGrillaPrincipal(producto.Key);
                        decimal cantidadSecundaria = ObtenerCantidadCargada(producto.Key);

                        if (cantidadPrincipal + cantidadSecundaria + producto.Value > stockDisponible)
                        {
                            MessageBox.Show(
                                $"Stock insuficiente para el producto ID {producto.Key}.\n" +
                                $"Stock disponible en sistema: {stockDisponible}\n" +
                                $"Venta principal: {cantidadPrincipal}\n" +
                                $"Venta secundaria: {cantidadSecundaria}\n" +
                                $"Cantidad requerida: {producto.Value}",
                                "Promociones", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    DataTable respaldoGrilla = new DataTable();

                    foreach (DataGridViewColumn columna in dtgPresentacion.Columns)
                        respaldoGrilla.Columns.Add(columna.Name, typeof(object));

                    foreach (DataGridViewRow fila in dtgPresentacion.Rows)
                    {
                        if (fila.IsNewRow)
                            continue;

                        DataRow nuevaFila = respaldoGrilla.NewRow();

                        foreach (DataGridViewColumn columna in dtgPresentacion.Columns)
                            nuevaFila[columna.Name] = fila.Cells[columna.Name].Value ?? DBNull.Value;

                        respaldoGrilla.Rows.Add(nuevaFila);
                    }

                    decimal subtotalAnterior = subtotal;
                    decimal ajusteAnterior = descuentoRecargo;
                    decimal totalAnterior = total;

                    foreach (DataRow detalle in detalles.Rows)
                    {
                        int idProducto = Convert.ToInt32(detalle["IdProducto"]);
                        string sku = Convert.ToString(detalle["SKU"]);
                        string codigoPromocion = "PROMOCION";
                        string descripcion = Convert.ToString(detalle["NombreProducto"]);
                        decimal precio = Convert.ToDecimal(detalle["PrecioVenta"]);
                        decimal cantidadConfigurada = Convert.ToDecimal(detalle["Cantidad"]);
                        decimal cantidadAgregar = esVolumen ? cantidadConfigurada * cantidadLleva : cantidadConfigurada;

                        DataTable tablaStock = logicaProducto.ObtenerStockPorProducto(idProducto);

                        decimal stockDisponible = 0m;

                        if (tablaStock.Rows.Count > 0 && tablaStock.Rows[0]["CantidadActual"] != DBNull.Value)
                        {
                            stockDisponible = Convert.ToDecimal(tablaStock.Rows[0]["CantidadActual"]);
                        }
                        bool agregado = AgregarProductoAGrilla(idProducto, sku, codigoPromocion, descripcion, precio, cantidadAgregar, stockDisponible);

                        if (!agregado)
                        {
                            dtgPresentacion.Rows.Clear();

                            foreach (DataRow filaRespaldo in respaldoGrilla.Rows)
                            {
                                int indice = dtgPresentacion.Rows.Add();

                                foreach (DataGridViewColumn columna in dtgPresentacion.Columns)
                                {
                                    object valorCelda = filaRespaldo[columna.Name];

                                    dtgPresentacion.Rows[indice].Cells[columna.Name].Value = valorCelda == DBNull.Value ? null : valorCelda;
                                }
                            }

                            subtotal = subtotalAnterior;
                            descuentoRecargo = ajusteAnterior;
                            total = totalAnterior;

                            CalcularYMostrarMontos();
                            txtCodigoBarra.Focus();

                            MessageBox.Show("No se pudo cargar toda la promoción. Se restauró la venta anterior.",
                                "Promociones", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    decimal importeNormalAgregado = subtotal - subtotalAnterior;
                    decimal descuentoPromocion = importeNormalAgregado - precioFinal;

                    descuentoRecargo = ajusteAnterior - descuentoPromocion;

                    CalcularYMostrarMontos();
                    txtCodigoBarra.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la promoción: " + ex.Message, "Promociones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lstDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCodigoBarra.Text.Trim();

            lstDescripcion.Items.Clear();
            tablaProductosEncontrados = null;

            if (string.IsNullOrWhiteSpace(texto))
            {
                lstDescripcion.Visible = false;
                return;
            }

            try
            {
                tablaProductosEncontrados = logicaProducto.BuscarArticulos(texto, true);

                if (tablaProductosEncontrados == null || tablaProductosEncontrados.Rows.Count == 0)
                {
                    lstDescripcion.Visible = false;
                    return;
                }

                foreach (DataRow fila in tablaProductosEncontrados.Rows)
                {
                    lstDescripcion.Items.Add(fila["Descripcion"].ToString());
                }

                lstDescripcion.Visible = lstDescripcion.Items.Count > 0;
            }
            catch (Exception ex)
            {
                lstDescripcion.Visible = false;

                MessageBox.Show("Error al buscar artículos: " + ex.Message, "Búsqueda de artículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lstDescripcion_DoubleClick(object sender, EventArgs e)
        {
            AgregarProductoSeleccionado();
        }
        private void lstDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AgregarProductoSeleccionado();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmCobroSecundario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.SuppressKeyPress = true;
                btnCobrar.PerformClick();
            }
        }


        #endregion
















        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
