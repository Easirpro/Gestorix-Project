using System;
using System.Windows.Forms;

namespace CapaVista
{
    public static class VaciarFormularios
    {
        //este metodo esta trabajando directamente con los controles de windows forms
        public static void LimpiarControles(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is MaskedTextBox maskedTextBox)
                {
                    maskedTextBox.Clear();
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
                else if (control is DateTimePicker dateTimePicker)
                {

                    DateTime fecha = DateTime.Today;

                    if (fecha < dateTimePicker.MinDate)
                    {
                        fecha = dateTimePicker.MinDate;
                    }

                    if (fecha > dateTimePicker.MaxDate)
                    {
                        fecha = dateTimePicker.MaxDate;
                    }

                    dateTimePicker.Value = fecha;
                }

                if (control.HasChildren)
                {
                    LimpiarControles(control);
                }
            }
        }
    }
}