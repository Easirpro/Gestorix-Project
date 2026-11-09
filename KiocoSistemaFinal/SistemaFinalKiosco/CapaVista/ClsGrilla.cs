using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public static class ClsGrilla
    {
        // grilla fija que ocupa todo el ancho
        public static void Fijar(DataGridView grilla)
        {
            grilla.AllowUserToResizeColumns = false;
            grilla.AllowUserToResizeRows = false;
            grilla.AllowUserToOrderColumns = false;
            grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grilla.BackgroundColor = ColorFila(grilla, 0);

            foreach (DataGridViewColumn columna in grilla.Columns)
            {
                columna.Resizable = DataGridViewTriState.False;
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.MinimumWidth = Math.Max(columna.MinimumWidth, 50);
            }

            grilla.Paint += (sender, e) => PintarEspacioVacio(grilla, e.Graphics);
            grilla.Scroll += (sender, e) => grilla.Invalidate();
            grilla.ColumnWidthChanged += (sender, e) => grilla.Invalidate();

            AjustarAlContenido(grilla, repartir: true);
        }

        private static Color ColorFila(DataGridView grilla, int indice)
        {
            Color alterno = grilla.AlternatingRowsDefaultCellStyle.BackColor;

            if (indice % 2 == 1 && !alterno.IsEmpty)
                return alterno;

            Color normal = grilla.RowsDefaultCellStyle.BackColor;

            if (normal.IsEmpty)
                normal = grilla.DefaultCellStyle.BackColor;

            return normal.IsEmpty ? SystemColors.Window : normal;
        }

        // dibuja filas vacias
        private static void PintarEspacioVacio(DataGridView grilla, Graphics g)
        {
            var columnas = grilla.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .Select(c => grilla.GetColumnDisplayRectangle(c.Index, false))
                .Where(r => r.Width > 0)
                .ToList();

            if (columnas.Count == 0)
                return;

            Rectangle area = grilla.DisplayRectangle;
            int finColumnas = columnas.Max(r => r.Right);
            int altoFila = grilla.Rows.Count > 0 ? grilla.Rows[0].Height : grilla.RowTemplate.Height;

            if (altoFila <= 0)
                return;

            int inicio = grilla.ColumnHeadersVisible ? grilla.ColumnHeadersHeight : 0;
            int ultima = grilla.Rows.GetLastRow(DataGridViewElementStates.Visible);

            using (Pen linea = new Pen(grilla.GridColor))
            {
                // linea del encabezado
                if (grilla.ColumnHeadersVisible && finColumnas < area.Right)
                {
                    g.DrawLine(linea, finColumnas, grilla.ColumnHeadersHeight - 1, area.Right, grilla.ColumnHeadersHeight - 1);
                }

                if (ultima >= 0)
                {
                    Rectangle ultimaFila = grilla.GetRowDisplayRectangle(ultima, false);

                    // sin espacio vacio
                    inicio = ultimaFila.Height == 0 ? area.Bottom : ultimaFila.Bottom;

                    if (finColumnas < area.Right)
                    {
                        int primera = Math.Max(grilla.FirstDisplayedScrollingRowIndex, 0);

                        for (int i = primera; i <= ultima; i++)
                        {
                            Rectangle fila = grilla.GetRowDisplayRectangle(i, false);

                            if (fila.Height > 0)
                                g.DrawLine(linea, finColumnas, fila.Bottom - 1, area.Right, fila.Bottom - 1);
                        }
                    }
                }

                if (inicio >= area.Bottom)
                    return;

                int indice = ultima + 1;

                for (int y = inicio; y < area.Bottom; y += altoFila, indice++)
                {
                    using (SolidBrush fondo = new SolidBrush(ColorFila(grilla, indice)))
                    {
                        g.FillRectangle(fondo, area.Left, y, area.Width, altoFila);
                    }

                    g.DrawLine(linea, area.Left, y + altoFila - 1, area.Right, y + altoFila - 1);
                }

                foreach (Rectangle columna in columnas)
                {
                    g.DrawLine(linea, columna.Right - 1, inicio, columna.Right - 1, area.Bottom);
                }
            }
        }

        // estirar = false: sin rellenar
        public static void AjustarAlContenido(DataGridView grilla, string? columnaFlexible = null, bool estirar = true, bool repartir = false)
        {
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grilla.ScrollBars = ScrollBars.Both;

            bool pendiente = false;

            void Programar()
            {
                if (pendiente || !grilla.IsHandleCreated || grilla.IsDisposed)
                {
                    if (!grilla.IsHandleCreated)
                    {
                        Ajustar(grilla, columnaFlexible, estirar, repartir);
                    }

                    return;
                }

                pendiente = true;
                grilla.BeginInvoke(new Action(() =>
                {
                    pendiente = false;

                    if (!grilla.IsDisposed)
                    {
                        Ajustar(grilla, columnaFlexible, estirar, repartir);
                    }
                }));
            }

            grilla.DataBindingComplete += (sender, e) => Programar();
            grilla.RowsAdded += (sender, e) => Programar();
            grilla.RowsRemoved += (sender, e) => Programar();
            grilla.Resize += (sender, e) => Programar();
            grilla.HandleCreated += (sender, e) => Programar();
            grilla.VisibleChanged += (sender, e) => Programar(); 

            Action idioma = Programar;
            ClsIdioma.IdiomaCambiado += idioma;
            grilla.Disposed += (sender, e) => ClsIdioma.IdiomaCambiado -= idioma;

            Ajustar(grilla, columnaFlexible, estirar, repartir);
        }

        public static void Ajustar(DataGridView grilla, string? columnaFlexible = null, bool estirar = true, bool repartir = false)
        {
            var visibles = grilla.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();

            if (visibles.Count == 0)
            {
                return;
            }

            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grilla.ScrollBars = ScrollBars.Both;

            foreach (DataGridViewColumn columna in visibles)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            grilla.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            if (!estirar && !repartir)
            {
                return;
            }

            bool barraVertical = grilla.ColumnHeadersHeight + grilla.Rows.GetRowsHeight(DataGridViewElementStates.Visible) > grilla.ClientSize.Height;
            int disponible = grilla.ClientSize.Width - 4 - (barraVertical ? SystemInformation.VerticalScrollBarWidth : 0) - (grilla.RowHeadersVisible ? grilla.RowHeadersWidth : 0);

            if (repartir)
            {
                RepartirSobrante(visibles, disponible);
                return;
            }

            DataGridViewColumn? flexible = columnaFlexible != null && grilla.Columns.Contains(columnaFlexible) && grilla.Columns[columnaFlexible].Visible ? grilla.Columns[columnaFlexible] : visibles.OrderByDescending(c => c.Width).First();
            int otras = visibles.Where(c => c != flexible).Sum(c => c.Width);

            flexible.Width = Math.Max(flexible.Width, disponible - otras);
        }

        // reparte el ancho sobrante
        private static void RepartirSobrante(System.Collections.Generic.List<DataGridViewColumn> visibles, int disponible)
        {
            int total = visibles.Sum(c => c.Width);
            int sobrante = disponible - total;

            if (sobrante <= 0 || total <= 0)
            {
                return;
            }

            int repartido = 0;

            for (int i = 0; i < visibles.Count; i++)
            {
                int extra = i == visibles.Count - 1
                    ? sobrante - repartido
                    : (int)((long)sobrante * visibles[i].Width / total);

                visibles[i].Width += extra;
                repartido += extra;
            }
        }
    }
}
