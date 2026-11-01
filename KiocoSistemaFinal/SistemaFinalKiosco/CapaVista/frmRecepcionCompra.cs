using CapaEntidades.NegocioEntidades;
using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmRecepcionCompra : Form
    {
        private ClsCompraLogica logica = new ClsCompraLogica();
        private DataTable comprasPendientes;
        private int idCompraSeleccionada = 0;
        private decimal totalCompra = 0;
        private bool cargando = false;

        public frmRecepcionCompra()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ConfigurarFormulario();
            ConfigurarEventos();
            CargarComprasPendientes();
        }

        #region Metodos
        private void ConfigurarFormulario()
        {
            dgvProductos.ReadOnly = false;
            dgvProductos.EditMode = DataGridViewEditMode.EditOnEnter;
            clnNombreProducto.ReadOnly = true;
            clnCantidadPedida.ReadOnly = true;
            clnCantidadRecibida.ReadOnly = false;
            clnDiferencia.ReadOnly = true;

            clnCantidadPedida.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clnCantidadRecibida.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clnDiferencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            clnCantidadRecibida.DefaultCellStyle.BackColor = Color.LightYellow;

            dtpFechaFiltro.Checked = false;
            txtObservaciones.MaxLength = 500;

            LimpiarCompra();
        }
        private void ConfigurarEventos()
        {
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            dgvCompras.SelectionChanged += dgvCompras_SelectionChanged;
            dgvProductos.CellValidating += dgvProductos_CellValidating;
            dgvProductos.CellEndEdit += dgvProductos_CellEndEdit;
            txtTotalBoleta.TextChanged += txtTotalBoleta_TextChanged;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            btnQuitarProducto.Click += btnQuitarProducto_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnConfirmarRecepcion.Click += btnConfirmarRecepcion_Click;
        }
        private void CargarComprasPendientes()
        {
            try
            {
                DateTime? fecha = dtpFechaFiltro.Checked ? dtpFechaFiltro.Value.Date : (DateTime?)null;

                comprasPendientes = logica.ObtenerComprasPendientesRecepcion(txtBuscar.Text, fecha);

                cargando = true;
                dgvCompras.Rows.Clear();

                foreach (DataRow fila in comprasPendientes.Rows)
                {
                    string proveedor = fila["Proveedor"].ToString();

                    if (fila["Sucursal"] != DBNull.Value)
                    {
                        proveedor += " (" + fila["Sucursal"] + ")";
                    }

                    int indice = dgvCompras.Rows.Add(
                        fila["IdCompra"],
                        Convert.ToDateTime(fila["Fecha"]).ToString("dd/MM/yyyy"),
                        proveedor,
                        fila["Comprobante"],
                        ObtenerEstadoEntrega(fila, out Color color));

                    dgvCompras.Rows[indice].Cells[clnEstado.Name].Style.ForeColor = color;
                }

                dgvCompras.ClearSelection();
                cargando = false;

                lblComprasPendientes.Text = ClsIdioma.T("Compras pendientes de recepción (") + comprasPendientes.Rows.Count + ")";
                LimpiarCompra();
            }
            catch (Exception ex)
            {
                cargando = false;
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar las compras pendientes.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Estado de la compra según su entrega estimada: atrasada, llega hoy, fecha prevista o sin fecha.
        private static string ObtenerEstadoEntrega(DataRow compra, out Color color)
        {
            color = SystemColors.ControlText;

            if (compra["FechaEntregaEstimada"] == DBNull.Value)
            {
                return ClsIdioma.T("Pendiente");
            }

            DateTime entrega = Convert.ToDateTime(compra["FechaEntregaEstimada"]).Date;
            int diasAtraso = (DateTime.Today - entrega).Days;

            if (diasAtraso > 0)
            {
                color = Color.Firebrick;
                return ClsIdioma.T("Atrasada (") + diasAtraso + (diasAtraso == 1 ? ClsIdioma.T(" día)") : ClsIdioma.T(" días)"));
            }

            if (diasAtraso == 0)
            {
                color = Color.DarkOrange;
                return ClsIdioma.T("Llega hoy");
            }

            return ClsIdioma.T("Llega el ") + entrega.ToString("dd/MM");
        }
        private void CargarCompraSeleccionada()
        {
            if (cargando || dgvCompras.CurrentRow == null || !dgvCompras.CurrentRow.Selected)
            {
                return;
            }

            int idCompra = Convert.ToInt32(dgvCompras.CurrentRow.Cells[clnIdCompra.Name].Value);

            if (idCompra == idCompraSeleccionada)
            {
                return;
            }

            try
            {
                DataRow compra = comprasPendientes.Select("IdCompra = " + idCompra).FirstOrDefault();

                if (compra == null)
                {
                    return;
                }

                DataTable detalle = logica.ObtenerDetalleCompra(idCompra);

                LimpiarCompra();

                idCompraSeleccionada = idCompra;
                totalCompra = Convert.ToDecimal(compra["Total"]);

                string proveedor = compra["Proveedor"].ToString();

                if (compra["Sucursal"] != DBNull.Value)
                {
                    proveedor += " - " + compra["Sucursal"];
                }

                lblProveedorValor.Text = proveedor;
                lblFechaCompraValor.Text = Convert.ToDateTime(compra["Fecha"]).ToString("dd/MM/yyyy HH:mm");
                lblComprobanteCompraValor.Text = compra["Comprobante"].ToString();
                lblEstadoCompraValor.Text = ObtenerEstadoEntrega(compra, out Color colorEstado);
                lblEstadoCompraValor.ForeColor = colorEstado;
                lblTotalCompraValor.Text = totalCompra.ToString("C2");

                // Un mismo producto puede estar en varias líneas de la compra: se recibe por producto.
                var productos = detalle.AsEnumerable()
                    .GroupBy(f => Convert.ToInt32(f["IdProducto"]))
                    .Select(g => new
                    {
                        IdProducto = g.Key,
                        Nombre = g.First()["Producto"].ToString(),
                        Cantidad = g.Sum(f => Convert.ToDecimal(f["Cantidad"]))
                    });

                foreach (var producto in productos)
                {
                    int indice = dgvProductos.Rows.Add(
                        producto.IdProducto,
                        producto.Nombre,
                        FormatearCantidad(producto.Cantidad),
                        FormatearCantidad(producto.Cantidad),
                        FormatearCantidad(0));

                    RecalcularFila(dgvProductos.Rows[indice]);
                }

                txtTotalBoleta.Text = totalCompra.ToString("N2");
                HabilitarRecepcion(true);
                ActualizarEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo cargar el detalle de la compra.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCompra()
        {
            idCompraSeleccionada = 0;
            totalCompra = 0;

            dgvProductos.Rows.Clear();
            lblProveedorValor.Text = "-";
            lblFechaCompraValor.Text = "-";
            lblComprobanteCompraValor.Text = "-";
            lblEstadoCompraValor.Text = "-";
            lblEstadoCompraValor.ForeColor = SystemColors.ControlText;
            lblTotalCompraValor.Text = 0m.ToString("C2");
            txtTotalBoleta.Text = string.Empty;
            lblDiferenciaTotalValor.Text = 0m.ToString("C2");
            lblDiferenciaTotalValor.ForeColor = SystemColors.ControlText;
            txtObservaciones.Clear();

            for (int i = 0; i < clbMotivos.Items.Count; i++)
            {
                clbMotivos.SetItemChecked(i, false);
            }

            HabilitarRecepcion(false);
            lblEstadoRecepcion.ForeColor = SystemColors.ControlText;
            lblEstadoRecepcion.Text = ClsIdioma.T("Seleccione una compra pendiente.");
        }
        private void HabilitarRecepcion(bool habilitar)
        {
            dgvProductos.Enabled = habilitar;
            txtTotalBoleta.Enabled = habilitar;
            btnAgregarProducto.Enabled = habilitar;
            btnQuitarProducto.Enabled = habilitar;
            clbMotivos.Enabled = habilitar;
            txtObservaciones.Enabled = habilitar;
            btnConfirmarRecepcion.Enabled = habilitar;
        }
        private void RecalcularFila(DataGridViewRow fila)
        {
            decimal pedida = ObtenerDecimal(fila.Cells[clnCantidadPedida.Name].Value);
            decimal recibida = ObtenerDecimal(fila.Cells[clnCantidadRecibida.Name].Value);
            decimal diferencia = recibida - pedida;

            fila.Cells[clnDiferencia.Name].Value = FormatearCantidad(diferencia);
            fila.Cells[clnDiferencia.Name].Style.ForeColor =
                diferencia < 0 ? Color.Firebrick : diferencia > 0 ? Color.DarkGreen : SystemColors.ControlText;
        }
        private void ActualizarDiferenciaTotal()
        {
            if (!TryObtenerImporte(txtTotalBoleta.Text, out decimal totalBoleta))
            {
                lblDiferenciaTotalValor.Text = ClsIdioma.T("Importe inválido");
                lblDiferenciaTotalValor.ForeColor = Color.Firebrick;
                return;
            }

            decimal diferencia = totalBoleta - totalCompra;

            lblDiferenciaTotalValor.Text = diferencia.ToString("C2");
            lblDiferenciaTotalValor.ForeColor = diferencia == 0 ? SystemColors.ControlText : Color.Firebrick;
        }
        private bool HayDiferencias()
        {
            bool diferenciaCantidades = dgvProductos.Rows.Cast<DataGridViewRow>()
                .Any(f => ObtenerDecimal(f.Cells[clnCantidadRecibida.Name].Value) != ObtenerDecimal(f.Cells[clnCantidadPedida.Name].Value));

            bool diferenciaTotal = TryObtenerImporte(txtTotalBoleta.Text, out decimal totalBoleta) && totalBoleta != totalCompra;

            return diferenciaCantidades || diferenciaTotal;
        }
        private void ActualizarEstado()
        {
            if (idCompraSeleccionada == 0)
            {
                return;
            }

            ActualizarDiferenciaTotal();

            if (HayDiferencias())
            {
                lblEstadoRecepcion.ForeColor = Color.Firebrick;
                lblEstadoRecepcion.Text = ClsIdioma.T("Hay diferencias con la compra: indique el motivo antes de confirmar.");
            }
            else
            {
                lblEstadoRecepcion.ForeColor = Color.DarkGreen;
                lblEstadoRecepcion.Text = ClsIdioma.T("La mercadería coincide con la compra.");
            }
        }
        private void ConfirmarRecepcion()
        {
            dgvProductos.EndEdit();

            if (idCompraSeleccionada == 0)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione una compra pendiente."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryObtenerImporte(txtTotalBoleta.Text, out decimal totalBoleta) || totalBoleta < 0)
            {
                MessageBox.Show(ClsIdioma.T("Ingrese un total de boleta válido."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalBoleta.Focus();
                return;
            }

            ClsRecepcionCompraEntidad recepcion = new ClsRecepcionCompraEntidad();
            recepcion.IdCompra = idCompraSeleccionada;
            recepcion.TotalCompra = totalCompra;
            recepcion.TotalBoleta = decimal.Round(totalBoleta, 2, MidpointRounding.AwayFromZero);
            recepcion.Motivos = string.Join(", ", clbMotivos.CheckedItems.Cast<object>().Select(m => m.ToString()));
            recepcion.Observaciones = txtObservaciones.Text.Trim();
            recepcion.Detalles = new List<ClsDetalleRecepcionEntidad>();

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                recepcion.Detalles.Add(new ClsDetalleRecepcionEntidad
                {
                    IdProducto = Convert.ToInt32(fila.Cells[clnIdProducto.Name].Value),
                    CantidadPedida = ObtenerDecimal(fila.Cells[clnCantidadPedida.Name].Value),
                    CantidadRecibida = ObtenerDecimal(fila.Cells[clnCantidadRecibida.Name].Value)
                });
            }

            string mensaje = HayDiferencias()
                ? ClsIdioma.T("La recepción tiene diferencias con la compra. El stock se ajustará según lo recibido.\n\n¿Confirma la recepción?")
                : ClsIdioma.T("¿Confirma la recepción de la compra N.º ") + idCompraSeleccionada + "?";

            if (MessageBox.Show(mensaje, ClsIdioma.T("Confirmar recepción"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                logica.ConfirmarRecepcion(recepcion);

                MessageBox.Show(ClsIdioma.T("La recepción de la compra N.º ") + idCompraSeleccionada + ClsIdioma.T(" se confirmó correctamente."),
                    ClsIdioma.T("Recepción confirmada"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarComprasPendientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo confirmar la recepción.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AgregarProducto()
        {
            if (!ElegirProducto(out int idProducto, out string nombre))
            {
                return;
            }

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (Convert.ToInt32(fila.Cells[clnIdProducto.Name].Value) == idProducto)
                {
                    MessageBox.Show(ClsIdioma.T("El producto ya está en la lista. Modifique su cantidad recibida."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvProductos.CurrentCell = fila.Cells[clnCantidadRecibida.Name];
                    return;
                }
            }

            int indice = dgvProductos.Rows.Add(idProducto, nombre, FormatearCantidad(0), FormatearCantidad(1), FormatearCantidad(0));
            RecalcularFila(dgvProductos.Rows[indice]);

            int motivo = clbMotivos.Items.IndexOf("Producto adicional no solicitado");

            if (motivo >= 0)
            {
                clbMotivos.SetItemChecked(motivo, true);
            }

            dgvProductos.CurrentCell = dgvProductos.Rows[indice].Cells[clnCantidadRecibida.Name];
            ActualizarEstado();
        }
        private void QuitarProducto()
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un producto."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ObtenerDecimal(dgvProductos.CurrentRow.Cells[clnCantidadPedida.Name].Value) > 0)
            {
                MessageBox.Show(ClsIdioma.T("Este producto es parte de la compra y no se puede quitar.\n\nSi no llegó, indique 0 en la cantidad recibida."),
                    ClsIdioma.T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvProductos.Rows.Remove(dgvProductos.CurrentRow);
            ActualizarEstado();
        }
        private bool ElegirProducto(out int idProducto, out string nombre)
        {
            idProducto = 0;
            nombre = null;

            DataTable encontrados = null;

            using (Form dialogo = new Form())
            using (TextBox txtTexto = new TextBox())
            using (ListBox lstResultados = new ListBox())
            using (Button btnAceptar = new Button())
            using (Button btnCancelarDialogo = new Button())
            {
                dialogo.Text = ClsIdioma.T("Agregar producto recibido");
                dialogo.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialogo.StartPosition = FormStartPosition.CenterParent;
                dialogo.MinimizeBox = false;
                dialogo.MaximizeBox = false;
                dialogo.ShowInTaskbar = false;
                dialogo.ClientSize = new Size(420, 260);

                Label lblTexto = new Label { Text = ClsIdioma.T("Código de barras / nombre / SKU:"), Location = new Point(12, 12), AutoSize = true };

                txtTexto.Location = new Point(12, 32);
                txtTexto.Size = new Size(396, 23);

                lstResultados.Location = new Point(12, 62);
                lstResultados.Size = new Size(396, 150);
                lstResultados.IntegralHeight = false;

                btnAceptar.Text = ClsIdioma.T("Agregar");
                btnAceptar.Location = new Point(222, 222);
                btnAceptar.Size = new Size(90, 28);
                btnAceptar.DialogResult = DialogResult.OK;

                btnCancelarDialogo.Text = ClsIdioma.T("Cancelar");
                btnCancelarDialogo.Location = new Point(318, 222);
                btnCancelarDialogo.Size = new Size(90, 28);
                btnCancelarDialogo.DialogResult = DialogResult.Cancel;

                dialogo.Controls.AddRange(new Control[] { lblTexto, txtTexto, lstResultados, btnAceptar, btnCancelarDialogo });
                dialogo.AcceptButton = btnAceptar;
                dialogo.CancelButton = btnCancelarDialogo;

                txtTexto.TextChanged += (s, e) =>
                {
                    lstResultados.Items.Clear();
                    encontrados = null;

                    if (string.IsNullOrWhiteSpace(txtTexto.Text))
                    {
                        return;
                    }

                    try
                    {
                        encontrados = logica.BuscarProducto(txtTexto.Text.Trim());

                        foreach (DataRow fila in encontrados.Rows)
                        {
                            lstResultados.Items.Add(fila["CodigoBarra"] + " - " + fila["Nombre"]);
                        }

                        if (lstResultados.Items.Count > 0)
                        {
                            lstResultados.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ClsIdioma.T("No se pudieron buscar los productos.\n\n") + ex.Message, ClsIdioma.T("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                lstResultados.DoubleClick += (s, e) => dialogo.DialogResult = DialogResult.OK;

                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return false;
                }

                if (encontrados == null || lstResultados.SelectedIndex < 0 || lstResultados.SelectedIndex >= encontrados.Rows.Count)
                {
                    MessageBox.Show(ClsIdioma.T("No se seleccionó ningún producto."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                DataRow producto = encontrados.Rows[lstResultados.SelectedIndex];
                idProducto = Convert.ToInt32(producto["IdProducto"]);
                nombre = producto["Nombre"].ToString();

                return true;
            }
        }
        private static string FormatearCantidad(decimal cantidad)
        {
            return cantidad.ToString("0.###", CultureInfo.CurrentCulture);
        }
        private static decimal ObtenerDecimal(object valor)
        {
            if (valor == null || valor == DBNull.Value)
            {
                return 0;
            }

            if (valor is decimal numero)
            {
                return numero;
            }

            return decimal.TryParse(valor.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal resultado)
                ? resultado
                : 0;
        }
        private static bool TryObtenerImporte(string texto, out decimal importe)
        {
            string limpio = (texto ?? string.Empty).Replace("$", string.Empty).Trim();

            return decimal.TryParse(limpio, NumberStyles.Number, CultureInfo.CurrentCulture, out importe);
        }
        #endregion

        #region Eventos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarComprasPendientes();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            dtpFechaFiltro.Checked = false;
            CargarComprasPendientes();
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarComprasPendientes();
            }
        }
        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            CargarCompraSeleccionada();
        }
        private void dgvProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != clnCantidadRecibida.Index)
            {
                return;
            }

            string texto = Convert.ToString(e.FormattedValue);

            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal cantidad) || cantidad < 0)
            {
                MessageBox.Show(ClsIdioma.T("Ingrese una cantidad recibida válida (0 o mayor)."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != clnCantidadRecibida.Index)
            {
                return;
            }

            RecalcularFila(dgvProductos.Rows[e.RowIndex]);
            ActualizarEstado();
        }
        private void txtTotalBoleta_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstado();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }
        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            QuitarProducto();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirmarRecepcion_Click(object sender, EventArgs e)
        {
            ConfirmarRecepcion();
        }
        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void pnlObservaciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalBoleta_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
