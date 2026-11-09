using CapaEntidades.NegocioEntidad;
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

        private ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();
        private DataTable tablaProductosEncontrados;

        private DataGridView grillaPrincipal;

        private readonly List<ClsPromocionVentaEntidad> promocionesAplicadas = new List<ClsPromocionVentaEntidad>();

        public frmCobroSecundario()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ClsCampoNumerico.Decimales(txtCantidad);
        }

        public frmCobroSecundario(DataGridView grillaPrincipal)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ClsCampoNumerico.Decimales(txtCantidad);
            this.grillaPrincipal = grillaPrincipal;

            botonVaciar = ClsBotonVaciarVenta.Agregar(dtgPresentacion, ClnPrecioUnitario, ClnImporte, "ClnIdProducto",
                LimpiarVenta, () => txtCodigoBarra.Focus());
        }

        private ClsBotonVaciarVenta botonVaciar;


        #region Metodos
        private void RegistrarPromocionAplicada(int idPromocion, string nombre, decimal importeLista, decimal importeCobrado)
        {
            ClsPromocionVentaEntidad existente = promocionesAplicadas.FirstOrDefault(p => p.IdPromocion == idPromocion);

            if (existente == null)
            {
                promocionesAplicadas.Add(new ClsPromocionVentaEntidad
                {
                    IdPromocion = idPromocion,
                    Nombre = nombre,
                    Veces = 1,
                    ImporteLista = Math.Round(importeLista, 2),
                    ImporteCobrado = Math.Round(importeCobrado, 2)
                });
            }
            else
            {
                existente.Veces += 1;
                existente.ImporteLista += Math.Round(importeLista, 2);
                existente.ImporteCobrado += Math.Round(importeCobrado, 2);
            }
        }
        private bool AgregarProductoAGrilla(int idProducto, string sku, string codigoBarra, string descripcion, decimal precio, decimal cantidad, decimal stockDisponible)
        {
            if (cantidad <= 0)
            {
                MessageBox.Show(ClsIdioma.T("La cantidad debe ser mayor a cero."), ClsIdioma.T("Cantidad inválida"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (precio < 0)
            {
                MessageBox.Show(ClsIdioma.T("El precio no puede ser negativo."), ClsIdioma.T("Precio inválido"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Precio 0 = artículo cargado sin precio: no se vende hasta que se le cargue uno.
            if (precio == 0)
            {
                MessageBox.Show(ClsIdioma.T("El artículo no tiene precio de venta. Cárguelo en Artículos antes de venderlo."), ClsIdioma.T("Precio inválido"),
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

                MessageBox.Show((ClsIdioma.Ingles ? $"Insufficient stock.\n" : $"Stock insuficiente.\n") + (ClsIdioma.Ingles ? $"Stock in system: {stockDisponible}\n" : $"Stock en sistema: {stockDisponible}\n") +
                    (ClsIdioma.Ingles ? $"Quantity in main sale: {cantidadEnGrillaPrincipal}\n" : $"Cantidad en venta principal: {cantidadEnGrillaPrincipal}\n") + (ClsIdioma.Ingles ? $"Quantity in secondary sale: {cantidadYaCargada}\n" : $"Cantidad en venta secundaria: {cantidadYaCargada}\n") + (ClsIdioma.Ingles ? $"Stock available to add: {stockRestante}\n" : $"Stock disponible para agregar: {stockRestante}\n") +
                    (ClsIdioma.Ingles ? $"Quantity to add: {cantidad}" : $"Cantidad a agregar: {cantidad}"), ClsIdioma.T("Stock insuficiente"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }


            if (codigoBarra != "PROMOCION")
            {
                foreach (DataGridViewRow fila in dtgPresentacion.Rows)
                {
                    if (fila.IsNewRow || Convert.ToString(fila.Cells["ClnCodigo"].Value) == "PROMOCION")
                        continue;

                    if (int.TryParse(Convert.ToString(fila.Cells["ClnIdProducto"].Value), out int idFila) && idFila == idProducto)
                    {
                        decimal.TryParse(Convert.ToString(fila.Cells["ClnCantidad"].Value), out decimal cantidadFila);
                        decimal.TryParse(Convert.ToString(fila.Cells["ClnPrecioUnitario"].Value), out decimal precioFila);

                        decimal nuevaCantidad = cantidadFila + cantidad;

                        fila.Cells["ClnCantidad"].Value = nuevaCantidad;
                        fila.Cells["ClnImporte"].Value = Math.Round(nuevaCantidad * precioFila, 2);

                        dtgPresentacion.ClearSelection();
                        dtgPresentacion.CurrentCell = fila.Cells["ClnDescripcion"];
                        fila.Selected = true;

                        CalcularYMostrarMontos();
                        dtgPresentacion.Refresh();

                        return true;
                    }
                }
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
                    MessageBox.Show(ClsIdioma.T("Ingrese una cantidad válida mayor a 0."), ClsIdioma.T("Cantidad inválida"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }
            }

            ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();

            DataTable tablaProducto = logicaProducto.ObtenerProductoPorCodigoBarra(codigoBarra);

            if (tablaProducto == null || tablaProducto.Rows.Count == 0)
            {
                MessageBox.Show(ClsIdioma.T("No se encontró un producto con ese código de barras."), ClsIdioma.T("Producto no encontrado"),
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
            lblTotalMonto.Text = total.ToString("C2");

            botonVaciar?.Actualizar();
        }
        private void LimpiarVenta()
        {
            dtgPresentacion.Rows.Clear();

            subtotal = 0m;
            descuentoRecargo = 0m;
            total = 0m;
            promocionesAplicadas.Clear();

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

            decimal cantidad = 1;

            if (!string.IsNullOrWhiteSpace(txtCantidad.Text) &&
                (!decimal.TryParse(txtCantidad.Text.Trim(), out cantidad) || cantidad <= 0))
            {
                MessageBox.Show(ClsIdioma.T("Ingresá una cantidad válida mayor que cero."), ClsIdioma.T("Cantidad inválida"),
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
            txtCantidad.Clear();
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
            dtgPresentacion.AllowUserToResizeColumns = true;
            dtgPresentacion.AllowUserToResizeRows = false;

            foreach (DataGridViewColumn columna in dtgPresentacion.Columns)
            {
                columna.Resizable = DataGridViewTriState.True;
                columna.MinimumWidth = 50;
            }
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
                MessageBox.Show(ClsIdioma.T("No hay productos para cobrar."), ClsIdioma.T("Venta vacía"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!frmmenuPres.VerificarCajaAbierta())
            {
                return;
            }

            using (frmInformeCobro formularioCobro = new frmInformeCobro(total, dtgPresentacion, promocionesAplicadas))
            {
                if (formularioCobro.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (ClsListaSugerencias.Navegar(lstDescripcion, e))
                return;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // elegido con las flechas o el codigo escrito
                if (ClsListaSugerencias.HayElegido(lstDescripcion))
                    AgregarProductoSeleccionado();
                else
                    IngresarProductoPorCodigo();
            }
        }
        private void btnCambiarcantidad_Click(object sender, EventArgs e)
        {
            if (dtgPresentacion.CurrentRow == null || dtgPresentacion.CurrentRow.IsNewRow || dtgPresentacion.CurrentRow.Cells["ClnIdProducto"].Value == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un producto para cambiar la cantidad."), ClsIdioma.T("Cambiar cantidad"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dtgPresentacion.CurrentRow;

            string codigoFila = Convert.ToString(fila.Cells["ClnCodigo"].Value);

            if (codigoFila == "PROMOCION")
            {
                MessageBox.Show(ClsIdioma.T("No se puede modificar la cantidad de un producto que pertenece a una promoción."), ClsIdioma.T("Cambiar cantidad"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCodigoBarra.Focus();
                return;
            }

            int idProducto = Convert.ToInt32(fila.Cells["ClnIdProducto"].Value);

            decimal cantidadActual = Convert.ToDecimal(fila.Cells["ClnCantidad"].Value);

            string entrada = Microsoft.VisualBasic.Interaction.InputBox(ClsIdioma.T("Ingrese la nueva cantidad:"), ClsIdioma.T("Cambiar cantidad"), cantidadActual.ToString());

            if (string.IsNullOrWhiteSpace(entrada))
                return;

            if (!decimal.TryParse(entrada, out decimal nuevaCantidad) || nuevaCantidad <= 0)
            {
                MessageBox.Show(ClsIdioma.T("Ingrese una cantidad válida mayor a 0."), ClsIdioma.T("Cantidad inválida"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();

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

                MessageBox.Show((ClsIdioma.Ingles ? $"Insufficient stock.\n\n" : $"Stock insuficiente.\n\n") + (ClsIdioma.Ingles ? $"Stock in system: {stockDisponible}\n" : $"Stock en sistema: {stockDisponible}\n") + (ClsIdioma.Ingles ? $"Other units in secondary sale: {cantidadEnSecundariaSinFila}\n" : $"Otras unidades en venta secundaria: {cantidadEnSecundariaSinFila}\n") +
                    (ClsIdioma.Ingles ? $"Units in main sale: {cantidadEnPrincipal}\n" : $"Unidades en venta principal: {cantidadEnPrincipal}\n") + (ClsIdioma.Ingles ? $"Available for this row: {stockRestante}\n" : $"Disponible para esta fila: {stockRestante}\n") + (ClsIdioma.Ingles ? $"Requested quantity: {nuevaCantidad}" : $"Cantidad solicitada: {nuevaCantidad}"),
                    ClsIdioma.T("Stock insuficiente"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    ClsGestorProductoLogica logicaProducto = new ClsGestorProductoLogica();

                    DataSet datos = logicaPromo.ObtenerPromocionPorId(idPromocion);

                    if (datos == null || datos.Tables.Count < 2 || datos.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(ClsIdioma.T("No se encontraron los datos de la promoción."));
                        return;
                    }

                    DataRow promo = datos.Tables[0].Rows[0];

                    if (promo["Activo"] == DBNull.Value || !Convert.ToBoolean(promo["Activo"]))
                    {
                        MessageBox.Show(ClsIdioma.T("La promoción seleccionada está inactiva."));
                        return;
                    }

                    DataTable detalles = datos.Tables[1];

                    if (detalles.Rows.Count == 0)
                    {
                        MessageBox.Show(ClsIdioma.T("La promoción no tiene productos asociados."));
                        return;
                    }

                    int idTipoPromocion = Convert.ToInt32(promo["IdTipoPromocion"]);
                    decimal valor = Convert.ToDecimal(promo["Valor"]);

                    DataTable tipos = logicaPromo.ObtenerTiposPromocion();

                    DataRow[] tiposEncontrados = tipos.Select("IdTipoPromocion = " + idTipoPromocion);

                    if (tiposEncontrados.Length == 0)
                    {
                        MessageBox.Show(ClsIdioma.T("No se encontró el tipo de promoción."));
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
                            MessageBox.Show(ClsIdioma.T("La mecánica de volumen no es válida."));
                            return;
                        }
                    }
                    else if (idTipoPromocion == 4)
                    {
                        if (valor <= 0 || valor > 100)
                        {
                            MessageBox.Show(ClsIdioma.T("El porcentaje de descuento no es válido."));
                            return;
                        }
                    }
                    else if (idTipoPromocion == 5)
                    {
                        if (valor <= 0)
                        {
                            MessageBox.Show(ClsIdioma.T("El precio especial no es válido."));
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(ClsIdioma.T("El tipo de promoción no es válido."));
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
                            MessageBox.Show(ClsIdioma.T("La cantidad o el precio de un producto no son válidos."));
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
                                (ClsIdioma.Ingles ? $"Insufficient stock for product ID {producto.Key}.\n" : $"Stock insuficiente para el producto ID {producto.Key}.\n") +
                                (ClsIdioma.Ingles ? $"Stock available in system: {stockDisponible}\n" : $"Stock disponible en sistema: {stockDisponible}\n") +
                                (ClsIdioma.Ingles ? $"Main sale: {cantidadPrincipal}\n" : $"Venta principal: {cantidadPrincipal}\n") +
                                (ClsIdioma.Ingles ? $"Secondary sale: {cantidadSecundaria}\n" : $"Venta secundaria: {cantidadSecundaria}\n") +
                                (ClsIdioma.Ingles ? $"Required quantity: {producto.Value}" : $"Cantidad requerida: {producto.Value}"),
                                ClsIdioma.T("Promociones"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

                            RellenarFilas();
                            CalcularYMostrarMontos();
                            txtCodigoBarra.Focus();

                            MessageBox.Show(ClsIdioma.T("No se pudo cargar toda la promoción. Se restauró la venta anterior."),
                                ClsIdioma.T("Promociones"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    decimal importeNormalAgregado = subtotal - subtotalAnterior;
                    decimal descuentoPromocion = importeNormalAgregado - precioFinal;

                    descuentoRecargo = ajusteAnterior - descuentoPromocion;

                    RegistrarPromocionAplicada(
                        idPromocion,
                        promo.Table.Columns.Contains("Nombre") ? Convert.ToString(promo["Nombre"]) : "",
                        importeNormalAgregado,
                        precioFinal);

                    CalcularYMostrarMontos();
                    txtCodigoBarra.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ClsIdioma.T("Error al cargar la promoción: ") + ex.Message, ClsIdioma.T("Promociones"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

                MessageBox.Show(ClsIdioma.T("Error al buscar artículos: ") + ex.Message, ClsIdioma.T("Búsqueda de artículos"),
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
        private void txtCantidad_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                IngresarProductoPorCodigo();
            }
        }
        private void btnQuitar_Click(object? sender, EventArgs e)
        {
            if (dtgPresentacion.CurrentRow == null || dtgPresentacion.CurrentRow.Cells["ClnIdProducto"].Value == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un producto para quitar."), ClsIdioma.T("Quitar producto"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dtgPresentacion.CurrentRow;

            if (Convert.ToString(fila.Cells["ClnCodigo"].Value) == "PROMOCION")
            {
                DialogResult quitarPromos = MessageBox.Show(
                    ClsIdioma.T("Ese producto pertenece a una promoción.\n\n") +
                    ClsIdioma.T("Se van a quitar todos los productos de promociones y su descuento. ¿Continuar?"),
                    ClsIdioma.T("Quitar promoción"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (quitarPromos != DialogResult.Yes)
                {
                    return;
                }

                List<DataGridViewRow> filasPromo = dtgPresentacion.Rows.Cast<DataGridViewRow>()
                    .Where(f => !f.IsNewRow && Convert.ToString(f.Cells["ClnCodigo"].Value) == "PROMOCION")
                    .ToList();

                foreach (DataGridViewRow filaPromo in filasPromo)
                {
                    dtgPresentacion.Rows.Remove(filaPromo);
                }

                promocionesAplicadas.Clear();
                descuentoRecargo = 0m;

                RellenarFilas();
                CalcularYMostrarMontos();
                txtCodigoBarra.Focus();
                return;
            }

            dtgPresentacion.Rows.Remove(fila);

            RellenarFilas();
            CalcularYMostrarMontos();

            txtCodigoBarra.Focus();
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
    }
}
