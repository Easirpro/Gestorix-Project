using System.Windows.Forms;

namespace CapaVista
{
    // flechas en el campo del codigo para elegir de la lista de sugerencias
    public static class ClsListaSugerencias
    {
        // true si la tecla movio la seleccion o cerro la lista
        public static bool Navegar(ListBox lista, KeyEventArgs e)
        {
            if (!lista.Visible || lista.Items.Count == 0)
                return false;

            if (e.KeyCode == Keys.Down)
            {
                lista.SelectedIndex = lista.SelectedIndex < lista.Items.Count - 1 ? lista.SelectedIndex + 1 : lista.Items.Count - 1;
            }
            else if (e.KeyCode == Keys.Up)
            {
                // arriba del primero vuelve a escribir el codigo
                lista.SelectedIndex = lista.SelectedIndex > 0 ? lista.SelectedIndex - 1 : -1;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lista.SelectedIndex = -1;
                lista.Visible = false;
            }
            else
            {
                return false;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
            return true;
        }

        // hay un producto elegido con las flechas
        public static bool HayElegido(ListBox lista)
        {
            return lista.Visible && lista.SelectedIndex >= 0;
        }
    }
}
