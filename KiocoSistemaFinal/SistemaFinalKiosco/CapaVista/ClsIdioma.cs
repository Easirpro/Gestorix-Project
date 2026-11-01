using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CapaVista
{
    // Idioma de las pantallas (castellano / inglés) para todo el sistema.
    // - El idioma elegido se guarda en la configuración del usuario de Windows de esta PC.
    // - Cada formulario se traduce solo al abrirse (ClsIdioma.Registrar en su constructor).
    // - Al cambiar de idioma se traducen también las ventanas que ya están abiertas.
    // Se traducen títulos, etiquetas, botones, casillas, recuadros, pestañas, columnas, menús,
    // textos de ayuda y globos. NO se traduce lo que escribe el usuario, los datos de las grillas
    // ni las opciones de los combos (algunas se guardan en la base tal cual).
    public static class ClsIdioma
    {
        public static bool Ingles { get; private set; }

        // Para pantallas que arman textos por código y quieren actualizarlos al cambiar de idioma.
        public static event Action? IdiomaCambiado;

        private static readonly Dictionary<string, string> aIngles;
        private static readonly Dictionary<string, string> aCastellano;
        private static readonly List<KeyValuePair<string, string>> prefijosIngles;
        private static readonly List<KeyValuePair<string, string>> prefijosCastellano;

        // Texto original en castellano de cada objeto traducido (por propiedad), para volver exactamente a él.
        // Hace falta porque hay textos distintos con la misma traducción (ej. "Activa" y "Activo" = "Active").
        private sealed class Originales : Dictionary<string, (string Castellano, string Ingles)> { }
        private static readonly ConditionalWeakTable<object, Originales> originales = new ConditionalWeakTable<object, Originales>();

        // Controles a los que ya se les enganchó el aviso de cambio de texto.
        private static readonly ConditionalWeakTable<object, object> enganchados = new ConditionalWeakTable<object, object>();
        private static bool cambiandoTexto = false;

        static ClsIdioma()
        {
            aIngles = ClsIdiomaTextos.Crear();

            aCastellano = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> par in aIngles)
            {
                // Solo se usa si no hay texto original guardado (por ejemplo, textos que puso el código).
                if (!aCastellano.ContainsKey(par.Value))
                {
                    aCastellano[par.Value] = par.Key;
                }
            }

            // Prefijos: claves que terminan en espacio (ej. "Fecha: " + valor). Primero los más largos.
            prefijosIngles = aIngles.Where(p => p.Key.EndsWith(" ") && p.Key.Trim().Length > 1)
                .OrderByDescending(p => p.Key.Length).ToList();
            prefijosCastellano = aCastellano.Where(p => p.Key.EndsWith(" ") && p.Key.Trim().Length > 1)
                .OrderByDescending(p => p.Key.Length).ToList();
        }

        private static string Archivo
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Gestorix", "idioma.txt");
            }
        }

        // Lee el idioma guardado en esta PC (llamar al iniciar el programa).
        public static void Cargar()
        {
            try
            {
                Ingles = File.Exists(Archivo) && File.ReadAllText(Archivo).Trim() == "en";
            }
            catch
            {
                Ingles = false;
            }
        }

        // Cambia el idioma, lo guarda en esta PC y traduce las ventanas abiertas.
        public static void CambiarIdioma(bool ingles)
        {
            Ingles = ingles;

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Archivo)!);
                File.WriteAllText(Archivo, ingles ? "en" : "es");
            }
            catch
            {
                // Si no se puede guardar, el idioma igual cambia durante esta sesión.
            }

            foreach (Form formulario in Application.OpenForms.Cast<Form>().ToList())
            {
                Aplicar(formulario);
            }

            IdiomaCambiado?.Invoke();
        }

        // Llamar en el constructor de cada formulario, después de InitializeComponent: lo traduce al cargarse
        // (después del Load propio del formulario, así también se traducen los textos que pone el código).
        public static void Registrar(Form formulario)
        {
            formulario.Load += (sender, e) =>
            {
                if (Ingles)
                {
                    Aplicar(formulario);
                }
            };
        }

        // Traduce un texto suelto al idioma actual (para textos que arma el código).
        public static string T(string texto)
        {
            return Ingles ? Buscar(texto, aIngles, prefijosIngles) : texto;
        }

        // Traduce las opciones de combos que el código elige por POSICIÓN (SelectedIndex), nunca por texto.
        // No usar en combos cuyo texto se guarda en la base o se compara (IVA, motivos, medios de pago...).
        // Guarda las opciones originales para poder volver a castellano.
        private static readonly ConditionalWeakTable<ComboBox, object[]> opcionesOriginales = new ConditionalWeakTable<ComboBox, object[]>();

        public static void TraducirOpciones(params ComboBox[] combos)
        {
            foreach (ComboBox combo in combos)
            {
                if (combo.DataSource != null)
                {
                    continue;
                }

                if (!opcionesOriginales.TryGetValue(combo, out object[]? originalesCombo))
                {
                    originalesCombo = combo.Items.Cast<object>().ToArray();
                    opcionesOriginales.Add(combo, originalesCombo);
                }

                int elegido = combo.SelectedIndex;

                combo.BeginUpdate();

                try
                {
                    for (int i = 0; i < combo.Items.Count && i < originalesCombo.Length; i++)
                    {
                        if (originalesCombo[i] is string texto)
                        {
                            combo.Items[i] = Ingles ? Buscar(texto, aIngles, prefijosIngles) : texto;
                        }
                    }
                }
                finally
                {
                    combo.EndUpdate();
                }

                combo.SelectedIndex = elegido;
            }
        }

        public static void Aplicar(Form formulario)
        {
            formulario.Text = Convertir(formulario, "Text", formulario.Text);
            EngancharTexto(formulario);

            AplicarControles(formulario.Controls);
            AplicarToolTips(formulario);
        }

        private static void AplicarControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                switch (control)
                {
                    case TextBox textBox:
                        // Solo el texto de ayuda: lo que escribe el usuario no se toca.
                        textBox.PlaceholderText = Convertir(textBox, "Placeholder", textBox.PlaceholderText);
                        break;

                    case ComboBox:
                    case ListBox:
                    case NumericUpDown:
                    case DateTimePicker:
                    case MaskedTextBox:
                    case RichTextBox:
                    case TreeView:
                        // Datos u opciones: no se traducen.
                        break;

                    case DataGridView grilla:
                        foreach (DataGridViewColumn columna in grilla.Columns)
                        {
                            columna.HeaderText = Convertir(columna, "Header", columna.HeaderText);

                            if (columna is DataGridViewButtonColumn boton && boton.UseColumnTextForButtonValue)
                            {
                                boton.Text = Convertir(boton, "Text", boton.Text);
                            }
                        }
                        break;

                    case ToolStrip barra:
                        AplicarItems(barra.Items);
                        break;

                    default:
                        control.Text = Convertir(control, "Text", control.Text);
                        EngancharTexto(control);
                        break;
                }

                if (control.HasChildren && control is not DataGridView)
                {
                    AplicarControles(control.Controls);
                }
            }
        }

        private static void AplicarItems(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                item.Text = Convertir(item, "Text", item.Text);
                item.ToolTipText = Convertir(item, "ToolTip", item.ToolTipText);

                if (!enganchados.TryGetValue(item, out _))
                {
                    enganchados.Add(item, true);
                    item.TextChanged += (sender, e) => TextoCambiado(item, () => item.Text, valor => item.Text = valor);
                }

                if (item is ToolStripDropDownItem desplegable)
                {
                    AplicarItems(desplegable.DropDownItems);
                }
            }
        }

        // Globos de ayuda: se buscan los ToolTip que tenga el formulario.
        private static void AplicarToolTips(Form formulario)
        {
            List<ToolTip> toolTips = formulario.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(f => f.FieldType == typeof(ToolTip))
                .Select(f => f.GetValue(formulario) as ToolTip)
                .Where(t => t != null)
                .Select(t => t!)
                .ToList();

            if (toolTips.Count == 0)
            {
                return;
            }

            List<Control> todos = new List<Control>();
            Juntar(formulario, todos);

            foreach (ToolTip toolTip in toolTips)
            {
                string clave = "Tip" + toolTip.GetHashCode();

                foreach (Control control in todos)
                {
                    string texto = toolTip.GetToolTip(control);

                    if (!string.IsNullOrEmpty(texto))
                    {
                        toolTip.SetToolTip(control, Convertir(control, clave, texto));
                    }
                }
            }
        }

        private static void Juntar(Control padre, List<Control> lista)
        {
            foreach (Control control in padre.Controls)
            {
                lista.Add(control);

                if (control.HasChildren)
                {
                    Juntar(control, lista);
                }
            }
        }

        // Si el código cambia el texto de un botón o etiqueta mientras se ve en inglés
        // (por ejemplo, Anular/Activar), se traduce al momento.
        private static void EngancharTexto(Control control)
        {
            if (enganchados.TryGetValue(control, out _))
            {
                return;
            }

            enganchados.Add(control, true);
            control.TextChanged += (sender, e) => TextoCambiado(control, () => control.Text, valor => control.Text = valor);
        }

        private static void TextoCambiado(object objeto, Func<string> leer, Action<string> escribir)
        {
            // En castellano el código ya pone los textos en castellano: no hay nada que hacer.
            if (cambiandoTexto || !Ingles)
            {
                return;
            }

            string actual = leer();
            string traducido = Convertir(objeto, "Text", actual);

            if (traducido != actual)
            {
                cambiandoTexto = true;

                try
                {
                    escribir(traducido);
                }
                finally
                {
                    cambiandoTexto = false;
                }
            }
        }

        // Devuelve el texto en el idioma actual para esa propiedad del objeto.
        // En inglés traduce y guarda el original; en castellano vuelve al original guardado.
        private static string Convertir(object objeto, string propiedad, string actual)
        {
            if (string.IsNullOrEmpty(actual))
            {
                return actual;
            }

            Originales guardados = originales.GetOrCreateValue(objeto);

            if (Ingles)
            {
                // Ya está traducido (por ejemplo, se vuelve a aplicar con la ventana abierta).
                if (guardados.TryGetValue(propiedad, out var previo) && previo.Ingles == actual)
                {
                    return actual;
                }

                string traducido = Buscar(actual, aIngles, prefijosIngles);

                if (traducido != actual)
                {
                    guardados[propiedad] = (actual, traducido);
                }

                return traducido;
            }

            if (guardados.TryGetValue(propiedad, out var original))
            {
                guardados.Remove(propiedad);

                // Si el texto sigue siendo el que puso la traducción, se vuelve al original exacto.
                if (original.Ingles == actual)
                {
                    return original.Castellano;
                }
            }

            // Sin original guardado: si el texto está en inglés (del diccionario), se pasa a castellano.
            return Buscar(actual, aCastellano, prefijosCastellano);
        }

        // Busca el texto exacto, después sin espacios de más y después por prefijo.
        // Si no lo encuentra, lo devuelve igual (datos, números, textos que no están en el diccionario).
        private static string Buscar(string texto, Dictionary<string, string> diccionario, List<KeyValuePair<string, string>> prefijos)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }

            if (diccionario.TryGetValue(texto, out string? traducido))
            {
                return traducido;
            }

            string recortado = texto.Trim();

            if (recortado.Length > 0 && recortado != texto && diccionario.TryGetValue(recortado, out traducido))
            {
                return texto.Replace(recortado, traducido);
            }

            foreach (KeyValuePair<string, string> prefijo in prefijos)
            {
                if (texto.StartsWith(prefijo.Key, StringComparison.Ordinal) && texto.Length > prefijo.Key.Length)
                {
                    return prefijo.Value + texto.Substring(prefijo.Key.Length);
                }
            }

            return texto;
        }
    }
}
