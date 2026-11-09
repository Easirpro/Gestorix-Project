using CapaEntidades;
using CapaLogica.NegocioLogica;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    // devolucion de lote vencido
    public class frmDevolucionProveedor : Form
    {
        private const string MOTIVO_VENCIDO = "Producto vencido";

        private readonly ClsDevolucionProveedorLogica logica = new ClsDevolucionProveedorLogica();
        private readonly int idProducto;
        private DataTable lotes = new DataTable();

        private readonly Label lblProducto = Valor(true);
        private readonly Label lblCodigo = Valor();
        private readonly ComboBox cmbLote = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 260 };
        private readonly Label lblVencimiento = Valor();
        private readonly Label lblProveedor = Valor();
        private readonly Label lblStock = Valor();
        private readonly NumericUpDown nudCantidad = new NumericUpDown { Width = 100, TextAlign = HorizontalAlignment.Right, ThousandsSeparator = true };
        private readonly Label lblCosto = Valor();
        private readonly Label lblImporte = Valor(true);
        private readonly TextBox txtMotivo = new TextBox { Width = 260, MaxLength = 200, Text = MOTIVO_VENCIDO };
        private readonly Button btnGuardar = new Button { Text = "Guardar devolución", AutoSize = true, Padding = new Padding(8, 2, 8, 2) };
        private readonly Button btnCancelar = new Button { Text = "Cancelar", AutoSize = true, Padding = new Padding(8, 2, 8, 2), DialogResult = DialogResult.Cancel };

        public frmDevolucionProveedor(int idProducto)
        {
            this.idProducto = idProducto;

            Text = "Devolución a proveedor";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Font = new Font("Segoe UI", 9F);
            Padding = new Padding(12);

            Label titulo = new Label
            {
                Text = "Devolución a proveedor por vencimiento",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.Firebrick,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 10)
            };

            TableLayoutPanel tabla = new TableLayoutPanel { ColumnCount = 2, AutoSize = true, Dock = DockStyle.Fill };
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            tabla.Controls.Add(titulo, 0, 0);
            tabla.SetColumnSpan(titulo, 2);

            Fila(tabla, "Producto:", lblProducto);
            Fila(tabla, "Código:", lblCodigo);
            Fila(tabla, "Lote:", cmbLote);
            Fila(tabla, "Venció el:", lblVencimiento);
            Fila(tabla, "Proveedor:", lblProveedor);
            Fila(tabla, "Stock actual:", lblStock);
            Fila(tabla, "Cantidad a devolver:", nudCantidad);
            Fila(tabla, "Costo unitario:", lblCosto);
            Fila(tabla, "Importe al costo:", lblImporte);
            Fila(tabla, "Motivo:", txtMotivo);

            FlowLayoutPanel botones = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 12, 0, 0)
            };
            botones.Controls.Add(btnCancelar);
            botones.Controls.Add(btnGuardar);
            tabla.Controls.Add(botones, 0, tabla.RowCount);
            tabla.SetColumnSpan(botones, 2);

            Controls.Add(tabla);

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            cmbLote.SelectedIndexChanged += (sender, e) => MostrarLote();
            nudCantidad.ValueChanged += (sender, e) => ActualizarImporte();
            btnGuardar.Click += (sender, e) => Guardar();

            ClsIdioma.Registrar(this);

            Load += (sender, e) => CargarLotes();
            Shown += (sender, e) =>
            {
                if (lotes.Rows.Count == 0)
                {
                    MessageBox.Show(ClsIdioma.T("El producto no tiene lotes vencidos para devolver."), ClsIdioma.T("Devolución a proveedor"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }

                btnGuardar.Focus();
            };
        }

        private static Label Valor(bool negrita = false)
        {
            return new Label
            {
                AutoSize = true,
                MaximumSize = new Size(320, 0),
                Margin = new Padding(3, 6, 3, 3),
                Font = new Font("Segoe UI", 9F, negrita ? FontStyle.Bold : FontStyle.Regular)
            };
        }

        private static void Fila(TableLayoutPanel tabla, string texto, Control control)
        {
            int fila = tabla.RowCount;
            tabla.RowCount++;
            tabla.Controls.Add(new Label { Text = texto, AutoSize = true, Margin = new Padding(3, 6, 12, 3) }, 0, fila);
            tabla.Controls.Add(control, 1, fila);
        }

        private void CargarLotes()
        {
            try
            {
                lotes = logica.ObtenerLotesVencidos(idProducto);
            }
            catch (Exception ex)
            {
                lotes = new DataTable();
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los lotes vencidos.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lotes.Rows.Count == 0)
                return;

            DataRow primero = lotes.Rows[0];
            lblProducto.Text = primero["Producto"].ToString();
            lblCodigo.Text = primero["CodigoBarra"] == DBNull.Value ? "-" : primero["CodigoBarra"].ToString();
            lblStock.Text = FormatoCantidad(Convert.ToDecimal(primero["StockActual"]));

            cmbLote.Items.Clear();
            foreach (DataRow lote in lotes.Rows)
            {
                string codigo = lote["CodigoLote"] == DBNull.Value || string.IsNullOrWhiteSpace(lote["CodigoLote"].ToString())
                    ? ClsIdioma.T("(sin código)")
                    : lote["CodigoLote"].ToString();

                cmbLote.Items.Add(codigo + " - " + ClsIdioma.T("vencido el ") + Convert.ToDateTime(lote["FechaVencimiento"]).ToString("dd/MM/yyyy"));
            }

            cmbLote.Enabled = lotes.Rows.Count > 1;
            cmbLote.SelectedIndex = 0;
        }

        private DataRow? LoteElegido()
        {
            return cmbLote.SelectedIndex >= 0 && cmbLote.SelectedIndex < lotes.Rows.Count ? lotes.Rows[cmbLote.SelectedIndex] : null;
        }

        private void MostrarLote()
        {
            DataRow? lote = LoteElegido();

            if (lote == null)
                return;

            decimal stock = Convert.ToDecimal(lote["StockActual"]);
            decimal sugerida = Convert.ToDecimal(lote["CantidadSugerida"]);
            bool conDecimales = stock != Math.Floor(stock) || sugerida != Math.Floor(sugerida);

            lblVencimiento.Text = Convert.ToDateTime(lote["FechaVencimiento"]).ToString("dd/MM/yyyy");
            lblProveedor.Text = lote["Proveedor"] + " - " + lote["Sucursal"];
            lblCosto.Text = Convert.ToDecimal(lote["CostoUnitario"]).ToString("C2");

            nudCantidad.DecimalPlaces = conDecimales ? 3 : 0;
            nudCantidad.Minimum = 0;
            nudCantidad.Maximum = Math.Max(stock, 0);
            nudCantidad.Value = Math.Min(Math.Max(sugerida, 0), nudCantidad.Maximum);

            ActualizarImporte();
        }

        private void ActualizarImporte()
        {
            DataRow? lote = LoteElegido();

            if (lote == null)
                return;

            lblImporte.Text = (Convert.ToDecimal(lote["CostoUnitario"]) * nudCantidad.Value).ToString("C2");
        }

        private static string FormatoCantidad(decimal cantidad)
        {
            return cantidad.ToString("0.###");
        }

        private void Guardar()
        {
            DataRow? lote = LoteElegido();

            if (lote == null)
                return;

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show(ClsIdioma.T("No hay stock para devolver de este producto."), ClsIdioma.T("Devolución a proveedor"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show(ClsIdioma.T("Ingrese el motivo de la devolución."), ClsIdioma.T("Devolución a proveedor"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return;
            }

            try
            {
                btnGuardar.Enabled = false;

                var resultado = logica.Registrar(Convert.ToInt32(lote["IdLote"]), nudCantidad.Value, txtMotivo.Text, SesionUsuario.IdUsuario);

                MessageBox.Show(ClsIdioma.T("Devolución a proveedor N.º ") + resultado.IdDevolucion + ClsIdioma.T(" registrada.\n\n") +
                                lblProducto.Text + " x " + FormatoCantidad(nudCantidad.Value) + "\n" +
                                lblProveedor.Text + "\n" +
                                ClsIdioma.T("Importe al costo: ") + resultado.Importe.ToString("C2"),
                    ClsIdioma.T("Devolución a proveedor"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                btnGuardar.Enabled = true;
                MessageBox.Show(ClsIdioma.T("No se pudo registrar la devolución.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
