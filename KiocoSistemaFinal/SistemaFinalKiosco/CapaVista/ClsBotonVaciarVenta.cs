using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    // boton rojo debajo del ultimo producto que vacia la venta
    public sealed class ClsBotonVaciarVenta
    {
        private static readonly string[] Textos = { "Eliminar todos los artículos", "Eliminar artículos", "Vaciar" };

        private readonly DataGridView grilla;
        private readonly DataGridViewColumn precio;
        private readonly DataGridViewColumn importe;
        private readonly string columnaId;
        private readonly Action vaciar;
        private readonly Action alCancelar;
        private readonly Button boton;
        private readonly ToolTip ayuda = new ToolTip();
        private bool pendiente;
        private int lineasAnteriores;

        private ClsBotonVaciarVenta(DataGridView grilla, DataGridViewColumn precio, DataGridViewColumn importe, string columnaId, Action vaciar, Action alCancelar)
        {
            this.grilla = grilla;
            this.precio = precio;
            this.importe = importe;
            this.columnaId = columnaId;
            this.vaciar = vaciar;
            this.alCancelar = alCancelar;

            boton = new Button
            {
                BackColor = Color.FromArgb(198, 40, 40),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(grilla.Font, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TabStop = false,
                Visible = false
            };

            boton.FlatAppearance.BorderSize = 0;
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 57, 53);
            boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 25, 25);
            boton.Click += Boton_Click;

            grilla.Controls.Add(boton);

            grilla.Scroll += (s, e) => Ubicar(false);
            grilla.Resize += (s, e) => Actualizar();
            grilla.ColumnWidthChanged += (s, e) => Actualizar();
            grilla.RowsRemoved += (s, e) => Actualizar();
            grilla.HandleCreated += (s, e) => Actualizar();
            grilla.Disposed += (s, e) => ayuda.Dispose();
        }

        public static ClsBotonVaciarVenta Agregar(DataGridView grilla, DataGridViewColumn precio, DataGridViewColumn importe, string columnaId, Action vaciar, Action alCancelar)
        {
            return new ClsBotonVaciarVenta(grilla, precio, importe, columnaId, vaciar, alCancelar);
        }

        // llamar cada vez que cambia la venta
        public void Actualizar()
        {
            if (pendiente || grilla.IsDisposed || !grilla.IsHandleCreated)
                return;

            pendiente = true;

            grilla.BeginInvoke(new Action(() =>
            {
                pendiente = false;

                if (!grilla.IsDisposed)
                    Ubicar(true);
            }));
        }

        private bool TieneProducto(DataGridViewRow fila)
        {
            return !fila.IsNewRow && !string.IsNullOrWhiteSpace(Convert.ToString(fila.Cells[columnaId].Value));
        }

        private void Ubicar(bool mostrarFila)
        {
            int ultima = -1;
            int lineas = 0;

            foreach (DataGridViewRow fila in grilla.Rows)
            {
                if (!TieneProducto(fila))
                    continue;

                ultima = fila.Index;
                lineas++;
            }

            // aparece desde el segundo producto
            if (lineas < 2)
            {
                boton.Visible = false;
                lineasAnteriores = lineas;
                return;
            }

            // siempre una fila libre debajo del ultimo producto
            if (ultima == grilla.Rows.Count - 1)
                grilla.Rows.Add();

            int filaBoton = ultima + 1;

            // al sumar un producto se muestra la fila del boton
            if (mostrarFila && lineas > lineasAnteriores)
            {
                int visibles = Math.Max(1, grilla.DisplayedRowCount(false));
                int primera = Math.Max(0, grilla.FirstDisplayedScrollingRowIndex);

                if (filaBoton >= primera + visibles)
                    grilla.FirstDisplayedScrollingRowIndex = Math.Max(0, filaBoton - visibles + 1);
            }

            lineasAnteriores = lineas;

            Rectangle celdaPrecio = grilla.GetCellDisplayRectangle(precio.Index, filaBoton, false);
            Rectangle celdaImporte = grilla.GetCellDisplayRectangle(importe.Index, filaBoton, false);

            if (celdaPrecio.IsEmpty || celdaImporte.IsEmpty)
            {
                boton.Visible = false;
                return;
            }

            Rectangle zona = Rectangle.Union(celdaPrecio, celdaImporte);
            zona.Inflate(-2, -2);

            // el texto mas largo que entre
            string texto = "🗑";

            foreach (string opcion in Textos)
            {
                string candidato = "🗑 " + ClsIdioma.T(opcion);

                if (TextRenderer.MeasureText(candidato, boton.Font).Width + 12 <= zona.Width)
                {
                    texto = candidato;
                    break;
                }
            }

            boton.Text = texto;
            boton.Bounds = zona;
            boton.Visible = true;
            boton.BringToFront();
            ayuda.SetToolTip(boton, ClsIdioma.T("Vacía la venta para empezar de nuevo (por ejemplo, si el cliente se fue)."));
        }

        private void Boton_Click(object? sender, EventArgs e)
        {
            int lineas = grilla.Rows.Cast<DataGridViewRow>().Count(TieneProducto);

            // No por defecto, para que un Enter del lector no la borre
            DialogResult respuesta = MessageBox.Show(
                ClsIdioma.T("¿Eliminar los ") + lineas + ClsIdioma.T(" artículos de la venta?\n\nLa venta queda vacía para empezar de nuevo."),
                ClsIdioma.T("Eliminar todos los artículos"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (respuesta == DialogResult.Yes)
            {
                vaciar();
                return;
            }

            alCancelar();
        }
    }
}
