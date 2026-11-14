using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    // filtra lo que se escribe o se pega en los campos numericos y de texto
    public static class ClsCampoNumerico
    {
        private enum Tipo { Entero, Decimal, Comprobante, Nombre, Direccion, Alfanumerico, Correo }

        public static void Enteros(params TextBox[] campos)
        {
            Aplicar(Tipo.Entero, campos);
        }
        // letras, espacio, apostrofo y guion (ej: D'Angelo, Garcia-Lopez)
        public static void Nombres(params TextBox[] campos)
        {
            Aplicar(Tipo.Nombre, campos);
        }
        // letras, numeros, espacio, punto, apostrofo y guion (ej: Av. 9 de Julio)
        public static void Direcciones(params TextBox[] campos)
        {
            Aplicar(Tipo.Direccion, campos);
        }
        // solo letras y numeros (ej: PB, 4B)
        public static void Alfanumericos(params TextBox[] campos)
        {
            Aplicar(Tipo.Alfanumerico, campos);
        }
        // sin espacios
        public static void Correos(params TextBox[] campos)
        {
            Aplicar(Tipo.Correo, campos);
        }
        public static void Decimales(params TextBox[] campos)
        {
            Aplicar(Tipo.Decimal, campos);
        }
        public static void Comprobantes(params TextBox[] campos)
        {
            Aplicar(Tipo.Comprobante, campos);
        }

        // sin separador de miles: "1.5" no se lee como 15
        public static bool EsCantidadEntera(object valor, out decimal cantidad)
        {
            return decimal.TryParse(Convert.ToString(valor), NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out cantidad)
                && cantidad == decimal.Truncate(cantidad);
        }
        private static void Aplicar(Tipo tipo, TextBox[] campos)
        {
            foreach (TextBox campo in campos)
            {
                campo.KeyPress += (sender, e) => FiltrarTecla(tipo, campo, e);
                new FiltroPegado(tipo, campo);
            }
        }
        private static bool EsTexto(Tipo tipo)
        {
            return tipo == Tipo.Nombre || tipo == Tipo.Direccion || tipo == Tipo.Alfanumerico || tipo == Tipo.Correo;
        }
        private static bool CaracterValido(Tipo tipo, char c)
        {
            switch (tipo)
            {
                case Tipo.Nombre:
                    return char.IsLetter(c) || c == ' ' || c == '\'' || c == '-';
                case Tipo.Direccion:
                    return char.IsLetterOrDigit(c) || c == ' ' || c == '.' || c == '\'' || c == '-';
                case Tipo.Alfanumerico:
                    return char.IsLetterOrDigit(c);
                case Tipo.Correo:
                    return !char.IsWhiteSpace(c) && !char.IsControl(c);
                default:
                    return false;
            }
        }
        private static void FiltrarTecla(Tipo tipo, TextBox campo, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (EsTexto(tipo))
            {
                // sin espacio al principio ni dos seguidos
                bool espacioDeMas = e.KeyChar == ' ' && (campo.SelectionStart == 0 || campo.Text[campo.SelectionStart - 1] == ' ');

                if (!CaracterValido(tipo, e.KeyChar) || espacioDeMas)
                    e.Handled = true;

                return;
            }

            if (char.IsAsciiDigit(e.KeyChar))
                return;

            if (tipo == Tipo.Comprobante && e.KeyChar == '-')
                return;

            // el punto se escribe como coma: en es-AR el punto es de miles
            if (tipo == Tipo.Decimal && (e.KeyChar == ',' || e.KeyChar == '.') && !TieneComa(campo))
            {
                e.KeyChar = ',';
                return;
            }

            e.Handled = true;
        }
        // coma fuera de lo seleccionado
        private static bool TieneComa(TextBox campo)
        {
            return campo.Text.Remove(campo.SelectionStart, campo.SelectionLength).Contains(',');
        }
        private static string Limpiar(Tipo tipo, string texto)
        {
            if (EsTexto(tipo))
            {
                string filtrado = new string(texto.Select(c => char.IsWhiteSpace(c) ? ' ' : c).Where(c => CaracterValido(tipo, c)).ToArray());

                while (filtrado.Contains("  "))
                    filtrado = filtrado.Replace("  ", " ");

                return filtrado;
            }

            if (tipo == Tipo.Entero)
                return new string(texto.Where(char.IsAsciiDigit).ToArray());

            if (tipo == Tipo.Comprobante)
                return new string(texto.Where(c => char.IsAsciiDigit(c) || c == '-').ToArray());

            string numero = new string(texto.Where(c => char.IsAsciiDigit(c) || c == ',' || c == '.').ToArray());

            int coma = numero.LastIndexOf(',');
            int punto = numero.LastIndexOf('.');

            // sin coma y con tres digitos despues del punto: son miles
            if (coma < 0 && punto >= 0 && numero.Length - punto - 1 == 3)
                return numero.Replace(".", "");

            int separador = Math.Max(coma, punto);

            if (separador < 0)
                return numero;

            string entera = numero.Substring(0, separador).Replace(".", "").Replace(",", "");

            return entera + "," + numero.Substring(separador + 1);
        }

        private sealed class FiltroPegado : NativeWindow
        {
            private const int WM_PASTE = 0x0302;

            private readonly Tipo tipo;
            private readonly TextBox campo;

            public FiltroPegado(Tipo tipo, TextBox campo)
            {
                this.tipo = tipo;
                this.campo = campo;

                campo.HandleCreated += (sender, e) => AssignHandle(campo.Handle);
                campo.HandleDestroyed += (sender, e) => ReleaseHandle();

                if (campo.IsHandleCreated)
                    AssignHandle(campo.Handle);
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg != WM_PASTE)
                {
                    base.WndProc(ref m);
                    return;
                }

                if (!campo.ReadOnly)
                    Pegar();
            }
            private void Pegar()
            {
                string texto;

                try
                {
                    texto = Clipboard.GetText();
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    return;
                }

                string limpio = Limpiar(tipo, texto);

                if (tipo == Tipo.Decimal && TieneComa(campo))
                    limpio = limpio.Replace(",", "");

                // asignar SelectedText no respeta MaxLength
                int disponible = campo.MaxLength - (campo.TextLength - campo.SelectionLength);

                if (limpio.Length > disponible)
                    limpio = limpio.Substring(0, Math.Max(0, disponible));

                campo.SelectedText = limpio;
            }
        }
    }
}
