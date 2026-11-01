using System;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public static class ClsGrilla
    {
        public static void AjustarAlContenido(DataGridView grilla, string? columnaFlexible = null)
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
                        Ajustar(grilla, columnaFlexible);
                    }

                    return;
                }

                pendiente = true;
                grilla.BeginInvoke(new Action(() =>
                {
                    pendiente = false;

                    if (!grilla.IsDisposed)
                    {
                        Ajustar(grilla, columnaFlexible);
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

            Ajustar(grilla, columnaFlexible);
        }

        public static void Ajustar(DataGridView grilla, string? columnaFlexible = null)
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

            DataGridViewColumn? flexible = columnaFlexible != null && grilla.Columns.Contains(columnaFlexible) && grilla.Columns[columnaFlexible].Visible ? grilla.Columns[columnaFlexible] : visibles.OrderByDescending(c => c.Width).First();

            bool barraVertical = grilla.ColumnHeadersHeight + grilla.Rows.GetRowsHeight(DataGridViewElementStates.Visible) > grilla.ClientSize.Height;
            int disponible = grilla.ClientSize.Width - 4 - (barraVertical ? SystemInformation.VerticalScrollBarWidth : 0) - (grilla.RowHeadersVisible ? grilla.RowHeadersWidth : 0);
            int otras = visibles.Where(c => c != flexible).Sum(c => c.Width);

            flexible.Width = Math.Max(flexible.Width, disponible - otras);
        }
    }
}
