using CapaEntidades.NegocioEntidades;
using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public class ClsCampanaAlertas : IDisposable
    {
        public static Image ImagenCampana { get; set; }

        private const int MINUTOS_ACTUALIZACION = 5;
        private const int SEGUNDOS_ENTRE_ACTUALIZACIONES = 20;
        private const int DESCRIPCIONES_POR_GRUPO = 2;
        private const int LARGO_MAXIMO_DESCRIPCION = 60;

        private static readonly Color ColorUrgente = Color.Firebrick;
        private static readonly Color ColorAviso = Color.DarkOrange;

        private static readonly Dictionary<TipoAlerta, string> Titulos = new Dictionary<TipoAlerta, string>
        {
            [TipoAlerta.Lote] = "Vencimientos",
            [TipoAlerta.Stock] = "Stock en el mínimo",
            [TipoAlerta.Entrega] = "Pedidos para recibir",
            [TipoAlerta.Caja] = "Caja sin cerrar",
            [TipoAlerta.Pago] = "Pagos a proveedores",
            [TipoAlerta.Promocion] = "Promociones vencidas",
            [TipoAlerta.Precio] = "Precio menor que el costo"
        };

        private readonly ClsAlertaLogica logica = new ClsAlertaLogica();
        private readonly Form formulario;
        private readonly ToolStripMenuItem campana;
        private readonly Dictionary<TipoAlerta, Action<ClsAlertaEntidad?>> acciones;
        private readonly System.Windows.Forms.Timer temporizador;
        private DateTime ultimaActualizacion = DateTime.MinValue;

        public List<ClsAlertaEntidad> Alertas { get; private set; } = new List<ClsAlertaEntidad>();

        public Action? VerTodas { get; set; }
        public Func<TipoAlerta, bool>? PuedeResolver { get; set; }
        public const string MENSAJE_SIN_PERMISO = "No tenés permiso para resolver esta alerta. Avisale al administrador.";
        public static string TituloDe(TipoAlerta tipo)
        {
            return ClsIdioma.T(Titulos.TryGetValue(tipo, out string? titulo) ? titulo : tipo.ToString());
        }

        public ClsCampanaAlertas(Form formulario, MenuStrip menu, ToolStripItem antesDe, Dictionary<TipoAlerta, Action<ClsAlertaEntidad?>> acciones)
        {
            this.formulario = formulario;
            this.acciones = acciones;

            campana = new ToolStripMenuItem
            {
                Name = "mnuAlertas",
                Alignment = ToolStripItemAlignment.Right,
                ImageScaling = ToolStripItemImageScaling.None,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                AutoToolTip = false
            };

            antesDe.Alignment = ToolStripItemAlignment.Right;
            menu.Items.Remove(antesDe);
            menu.Items.Add(antesDe);
            menu.Items.Add(campana);

            campana.DropDown.ShowItemToolTips = true;

            temporizador = new System.Windows.Forms.Timer { Interval = MINUTOS_ACTUALIZACION * 60 * 1000 };
            temporizador.Tick += (sender, e) => Actualizar();

            ClsIdioma.IdiomaCambiado += Actualizar;

            formulario.Activated += (sender, e) =>
            {
                if ((DateTime.Now - ultimaActualizacion).TotalSeconds >= SEGUNDOS_ENTRE_ACTUALIZACIONES)
                    Actualizar();
            };
        }

        public void Iniciar(bool mostrarAviso)
        {
            Actualizar();
            temporizador.Start();

            List<ClsAlertaEntidad> urgentes = Alertas.Where(a => a.Urgente).ToList();

            if (mostrarAviso && urgentes.Count > 0)
            {
                frmAvisoAlertas aviso = new frmAvisoAlertas(urgentes, () => campana.ShowDropDown());
                aviso.Mostrar(formulario);
            }
        }
        public void Actualizar()
        {
            ultimaActualizacion = DateTime.Now;

            try
            {
                Alertas = logica.ObtenerAlertas();
                ConstruirLista();
            }
            catch (Exception ex)
            {
                Alertas = new List<ClsAlertaEntidad>();
                campana.DropDownItems.Clear();
                campana.DropDownItems.Add(new ToolStripMenuItem(ClsIdioma.T("No se pudieron cargar las alertas")) { Enabled = false, ToolTipText = ex.Message });
                AgregarActualizar();
                campana.Image = DibujarCampana(0, false);
                campana.ToolTipText = ClsIdioma.T("No se pudieron cargar las alertas");
                return;
            }

            int urgentes = Alertas.Count(a => a.Urgente);

            campana.Image = DibujarCampana(Alertas.Count, urgentes > 0);
            campana.ToolTipText = Alertas.Count == 0 ? ClsIdioma.T("No hay alertas")
                : Alertas.Count + (Alertas.Count == 1 ? ClsIdioma.T(" alerta") : ClsIdioma.T(" alertas")) + (urgentes > 0 ? " (" + urgentes + (urgentes == 1 ? ClsIdioma.T(" urgente)") : ClsIdioma.T(" urgentes)")) : "");
        }
        private void ConstruirLista()
        {
            campana.DropDownItems.Clear();

            ToolStripLabel titulo = new ToolStripLabel(ClsIdioma.T("Alertas"))
            {
                Font = new Font(SystemFonts.MenuFont, FontStyle.Bold),
                Padding = new Padding(4, 4, 4, 2)
            };
            campana.DropDownItems.Add(titulo);
            campana.DropDownItems.Add(new ToolStripSeparator());

            if (Alertas.Count == 0)
            {
                campana.DropDownItems.Add(new ToolStripMenuItem(ClsIdioma.T("No hay alertas. Todo en orden."))
                {
                    Enabled = false,
                    Image = DibujarPunto(Color.SeaGreen)
                });
            }

            var grupos = Alertas.GroupBy(a => a.Tipo).OrderByDescending(g => g.Any(a => a.Urgente)) .ThenByDescending(g => g.Count());

            foreach (var grupo in grupos)
            {
                List<ClsAlertaEntidad> lista = grupo.OrderByDescending(a => a.Urgente).ToList();
                bool urgente = lista.Any(a => a.Urgente);

                List<string> renglones = new List<string> { TituloDe(grupo.Key) + " (" + lista.Count + ")" };
                renglones.AddRange(lista.Take(DESCRIPCIONES_POR_GRUPO).Select(a => "    " + Recortar(ClsIdioma.TraducirAlerta(a.Descripcion))));

                if (lista.Count > DESCRIPCIONES_POR_GRUPO)
                    renglones.Add(ClsIdioma.T("    y ") + (lista.Count - DESCRIPCIONES_POR_GRUPO) + ClsIdioma.T(" más…"));

                ToolStripMenuItem item = new ToolStripMenuItem(string.Join(Environment.NewLine, renglones))
                {
                    Image = DibujarPunto(urgente ? ColorUrgente : ColorAviso),
                    ImageAlign = ContentAlignment.TopCenter,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ToolTipText = string.Join(Environment.NewLine, lista.Take(15).Select(a => ClsIdioma.TraducirAlerta(a.Descripcion)))
                        + (lista.Count > 15 ? Environment.NewLine + ClsIdioma.T("y ") + (lista.Count - 15) + ClsIdioma.T(" más…") : "")
                };

                TipoAlerta tipo = grupo.Key;
                item.Click += (sender, e) => Abrir(tipo);

                campana.DropDownItems.Add(item);
            }

            AgregarActualizar();
        }
        private void AgregarActualizar()
        {
            campana.DropDownItems.Add(new ToolStripSeparator());

            if (VerTodas != null)
            {
                ToolStripMenuItem verTodas = new ToolStripMenuItem(ClsIdioma.T("Ver todas las alertas…"))
                {
                    Font = new Font(SystemFonts.MenuFont, FontStyle.Bold)
                };
                verTodas.Click += (sender, e) => VerTodas();
                campana.DropDownItems.Add(verTodas);
            }

            ToolStripMenuItem actualizar = new ToolStripMenuItem(ClsIdioma.T("Actualizar"));
            actualizar.Click += (sender, e) => Actualizar();
            campana.DropDownItems.Add(actualizar);
        }
        private void Abrir(TipoAlerta tipo)
        {
            if (PuedeResolver != null && !PuedeResolver(tipo))
            {
                MessageBox.Show(ClsIdioma.T(MENSAJE_SIN_PERMISO), ClsIdioma.T("Alertas"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // desde la campana: sin registro puntual
            if (acciones.TryGetValue(tipo, out Action<ClsAlertaEntidad?> accion))
                accion(null);

            Actualizar();
        }
        private static string Recortar(string texto)
        {
            return texto.Length <= LARGO_MAXIMO_DESCRIPCION ? texto : texto.Substring(0, LARGO_MAXIMO_DESCRIPCION - 1) + "…";
        }
        private static Bitmap DibujarCampana(int cantidad, bool hayUrgentes)
        {
            Bitmap imagen = new Bitmap(24, 22);

            using (Graphics g = Graphics.FromImage(imagen))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                if (ImagenCampana != null)
                {
                    g.DrawImage(ImagenCampana, new Rectangle(1, 3, 18, 18));
                }
                else
                {
                    Color color = cantidad > 0 ? Color.FromArgb(64, 64, 64) : Color.FromArgb(150, 150, 150);

                    using (GraphicsPath cuerpo = new GraphicsPath())
                    using (SolidBrush pincel = new SolidBrush(color))
                    {
                        cuerpo.AddBezier(5, 15, 5, 9, 6, 5, 10, 5);
                        cuerpo.AddBezier(10, 5, 14, 5, 15, 9, 15, 15);
                        cuerpo.AddLine(15, 15, 17, 17);
                        cuerpo.AddLine(17, 17, 3, 17);
                        cuerpo.AddLine(3, 17, 5, 15);
                        cuerpo.CloseFigure();

                        g.FillPath(pincel, cuerpo);
                        g.FillEllipse(pincel, 9, 3, 2, 3);
                        g.FillEllipse(pincel, 8.5f, 17.5f, 3, 3);
                    }
                }

                if (cantidad > 0)
                {
                    string texto = cantidad > 9 ? "9+" : cantidad.ToString();
                    RectangleF circulo = new RectangleF(12, 0, 12, 12);

                    using (SolidBrush fondo = new SolidBrush(hayUrgentes ? ColorUrgente : ColorAviso))
                    using (Font fuente = new Font("Segoe UI", cantidad > 9 ? 5.5f : 6.5f, FontStyle.Bold))
                    using (StringFormat centrado = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        g.FillEllipse(fondo, circulo);
                        g.DrawString(texto, fuente, Brushes.White, circulo, centrado);
                    }
                }
            }

            return imagen;
        }
        private static Bitmap DibujarPunto(Color color)
        {
            Bitmap imagen = new Bitmap(16, 16);

            using (Graphics g = Graphics.FromImage(imagen))
            using (SolidBrush pincel = new SolidBrush(color))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(pincel, 3, 3, 10, 10);
            }

            return imagen;
        }
        public void Dispose()
        {
            ClsIdioma.IdiomaCambiado -= Actualizar;
            temporizador.Dispose();
        }
    }
}
