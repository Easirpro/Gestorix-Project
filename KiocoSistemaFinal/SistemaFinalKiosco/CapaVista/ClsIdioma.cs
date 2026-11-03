using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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

            AplicarMoneda();
        }

        // Los importes se muestran en pesos argentinos (ARS) y en inglés en dólares (USD).
        // Se parte siempre de es-AR (no de la configuración regional de Windows, que puede estar
        // en euros) y en inglés solo cambia el formato de moneda: la forma de escribir números y
        // fechas en los campos sigue siendo la misma en los dos idiomas.
        // No se convierte el valor: solo cambia el símbolo y el formato del importe.
        private static void AplicarMoneda()
        {
            CultureInfo cultura = (CultureInfo)CultureInfo.GetCultureInfo("es-AR").Clone();

            if (Ingles)
            {
                NumberFormatInfo dolares = CultureInfo.GetCultureInfo("en-US").NumberFormat;

                cultura.NumberFormat.CurrencySymbol = "US$";
                cultura.NumberFormat.CurrencyDecimalSeparator = dolares.CurrencyDecimalSeparator;
                cultura.NumberFormat.CurrencyGroupSeparator = dolares.CurrencyGroupSeparator;
            }

            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.CurrentCulture = cultura;
        }

        // Importe sin el símbolo, con los separadores de la moneda actual (para pantallas que
        // muestran el símbolo en una etiqueta aparte).
        public static string ImporteSinSimbolo(decimal valor)
        {
            NumberFormatInfo formato = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();

            formato.NumberDecimalSeparator = formato.CurrencyDecimalSeparator;
            formato.NumberGroupSeparator = formato.CurrencyGroupSeparator;

            return valor.ToString("N2", formato);
        }

        // Formato de importe para las planillas de Excel que se exportan.
        public static string FormatoMonedaExcel
        {
            get
            {
                return Ingles ? "\"US$\" #,##0.00" : "\"$\" #,##0.00";
            }
        }

        // Cambia el idioma, lo guarda en esta PC y traduce las ventanas abiertas.
        public static void CambiarIdioma(bool ingles)
        {
            Ingles = ingles;
            AplicarMoneda();

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

        // Grillas: los valores fijos que vienen de la base (estados, medios de pago, conceptos...)
        // se traducen solo AL DIBUJARLOS. El valor de la celda no cambia, así el código que lo lee
        // o lo compara sigue viendo el dato en castellano. Solo celdas de solo lectura, para no
        // meter texto traducido al editar. Nombres de artículos o texto libre no están en el
        // diccionario y quedan como vienen.
        private static void EngancharGrilla(DataGridView grilla)
        {
            grilla.CellFormatting -= GrillaCellFormatting;
            grilla.CellFormatting += GrillaCellFormatting;
            grilla.DataBindingComplete -= GrillaDataBindingComplete;
            grilla.DataBindingComplete += GrillaDataBindingComplete;
            grilla.Invalidate();
        }

        private static void GrillaCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!Ingles || sender is not DataGridView grilla || e.Value is not string texto || e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (!grilla.ReadOnly && !grilla.Columns[e.ColumnIndex].ReadOnly)
            {
                return;
            }

            string traducido = Dato(texto);

            if (!ReferenceEquals(traducido, texto))
            {
                e.Value = traducido;
            }
        }

        // Columnas creadas al cargar datos (DataSource): sus encabezados se traducen al terminar de cargar.
        private static void GrillaDataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!Ingles || sender is not DataGridView grilla)
            {
                return;
            }

            foreach (DataGridViewColumn columna in grilla.Columns)
            {
                columna.HeaderText = Convertir(columna, "Header", columna.HeaderText);
            }
        }

        // Descripciones de la bitácora: se guardan en castellano (registro de auditoría).
        // En inglés se traducen solo las frases fijas; nombres, importes y motivos quedan igual.
        private static readonly (string es, string en)[] frasesBitacora =
        {
            ("Intento de inicio de sesión fallido para el usuario: ", "Failed login attempt for user: "),
            ("Inicio de sesión correcto.", "Successful login."),
            ("Cierre de sesión.", "Logout."),
            ("Se modificó el producto: ", "Product modified: "),
            ("Se creó el producto: ", "Product created: "),
            ("Se eliminó el producto con ID ", "Product deleted, ID "),
            ("Se discontinuó el producto con ID ", "Product discontinued, ID "),
            ("Modificación de datos del usuario: ", "User data modified: "),
            ("Alta de usuario: ", "User created: "),
            ("Baja lógica del usuario: ", "User deactivated: "),
            ("Reactivación del usuario: ", "User reactivated: "),
            ("Apertura de caja #", "Cash register opening #"),
            ("Fondo inicial: ", "Opening float: "),
            ("Esperado: ", "Expected: "),
            ("Contado: ", "Counted: "),
            ("FALTANTE: ", "SHORTAGE: "),
            ("SOBRANTE: ", "OVERAGE: "),
            ("Sin diferencias", "No differences"),
            ("Recepción compra #", "Purchase receipt #"),
            ("Total compra: ", "Purchase total: "),
            ("Total boleta: ", "Invoice total: "),
            ("Pago compra #", "Purchase payment #"),
            ("Saldo restante: ", "Remaining balance: "),
            ("Compra #", "Purchase #"),
            ("| CONTADO", "| CASH"),
            ("| CTA_CTE", "| CURRENT ACCOUNT"),
            ("Pagada con ", "Paid with "),
            ("Devolución #", "Return #"),
            ("Venta #", "Sale #"),
            ("Cambio por otra unidad", "Exchange for another unit"),
            ("Reintegro en efectivo", "Cash refund"),
            ("Motivo: ", "Reason: "),
            ("Egreso manual / gasto", "Manual withdrawal / expense"),
            ("Ingreso manual", "Manual deposit"),
            ("Vale / adelanto a empleado", "Employee advance"),
            ("Pago de sueldo", "Salary payment"),
            ("Retiro de caja", "Cash withdrawal"),
            ("Pagos: ", "Payments: "),
            ("Promoción: ", "Promotion: "),
            ("Código: ", "Code: "),
            ("Creación de la promoción", "Promotion created"),
            ("Eliminación de la promoción", "Promotion deleted"),
            ("Modificación de la promoción", "Promotion modified"),
            ("Nombre anterior: ", "Previous name: "),
            ("Nombre nuevo: ", "New name: "),
            ("Valor anterior: ", "Previous value: "),
            ("Valor nuevo: ", "New value: "),
            ("Estado anterior: ", "Previous status: "),
            ("Estado nuevo: ", "New status: "),
            ("Vigencia anterior: ", "Previous validity: "),
            ("Vigencia nueva: ", "New validity: "),
            ("Horario anterior: ", "Previous schedule: "),
            ("Horario nuevo: ", "New schedule: "),
            ("Días anteriores: ", "Previous days: "),
            ("Días nuevos: ", "New days: "),
            ("Sin fecha fin", "No end date"),
            ("No recurrente", "Not recurring"),
            ("Sin datos", "No data"),
            ("El cliente se arrepintió", "Customer changed their mind"),
            ("Producto fallado", "Defective product"),
            ("Producto vencido", "Expired product"),
            ("Error en la venta", "Sales error"),
            ("Reason: Otro", "Reason: Other"),
            ("Efectivo", "Cash"),
            ("Débito", "Debit"),
            ("Transferencia", "Transfer"),
            ("Cuenta Corriente", "Current account"),
        };

        public static string TraducirBitacora(string? descripcion)
        {
            if (!Ingles || string.IsNullOrEmpty(descripcion))
            {
                return descripcion ?? "";
            }

            foreach (var (es, en) in frasesBitacora)
            {
                descripcion = descripcion.Replace(es, en);
            }

            // Rangos "desde a hasta" de fechas y horarios (después de traducir "Sin datos" y "Sin fecha fin").
            descripcion = Regex.Replace(descripcion, @"(\d{2}/\d{2}/\d{4}|\d{2}:\d{2}(:\d{2})?|No data) a ", "$1 to ");

            return descripcion;
        }

        // Las descripciones de las alertas las arma sp_ObtenerAlertas en castellano, mezclando
        // nombres (artículos, proveedores) con frases fijas. En inglés se traducen solo esas frases.
        private static readonly (Regex patron, string reemplazo)[] frasesAlertas =
        {
            (new Regex(@" \(lote "), " (batch "),
            (new Regex(@": venció el "), ": expired on "),
            (new Regex(@": vence hoy"), ": expires today"),
            (new Regex(@": vence el "), ": expires on "),
            (new Regex(@" \(en (\d+) días\)"), " (in $1 days)"),
            (new Regex(@": quedan (.+) \(mínimo (.+)\)$"), ": $1 left (minimum $2)"),
            (new Regex(@"^Compra N\.º "), "Purchase No. "),
            (new Regex(@": atrasada (\d+) día\(s\)"), ": $1 day(s) late"),
            (new Regex(@": llega hoy"), ": arrives today"),
            (new Regex(@"^Caja abierta desde el (.+) sin cerrar$"), "Cash register open since $1 and not closed"),
            (new Regex(@": saldo "), ": balance "),
            (new Regex(@", venció el "), ", was due on "),
            (new Regex(@", vence hoy"), ", due today"),
            (new Regex(@", vence el "), ", due on "),
            (new Regex(@": terminó el (.+) y sigue activa$"), ": ended on $1 and is still active"),
            (new Regex(@": se vende a (.+) y cuesta (.+) \("), ": sells for $1 and costs $2 ("),
        };

        public static string TraducirAlerta(string? descripcion)
        {
            if (!Ingles || string.IsNullOrEmpty(descripcion))
            {
                return descripcion ?? "";
            }

            foreach (var (patron, reemplazo) in frasesAlertas)
            {
                descripcion = patron.Replace(descripcion, reemplazo, 1);
            }

            return descripcion;
        }

        // Textos que vienen de la base solo para mostrar (nombres de permisos, roles...):
        // se traducen si están en el diccionario y, si no, quedan como vinieron.
        public static string Dato(object? valor)
        {
            string texto = Convert.ToString(valor) ?? "";

            return Ingles && aIngles.TryGetValue(texto.Trim(), out string? traducido) && traducido != texto ? traducido : texto;
        }

        // Traduce al mostrar los ítems de un combo cargado desde la base (DataSource),
        // sin tocar los datos ni el valor elegido.
        public static void TraducirDatosAlMostrar(ListControl combo)
        {
            combo.FormattingEnabled = true;   // sin esto la lista no usa el evento Format
            combo.Format -= FormatoTraducido;
            combo.Format += FormatoTraducido;
        }

        private static void FormatoTraducido(object? sender, ListControlConvertEventArgs e)
        {
            if (Ingles && e.Value is string texto)
            {
                e.Value = Dato(texto);
            }
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
                        EngancharGrilla(grilla);

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
