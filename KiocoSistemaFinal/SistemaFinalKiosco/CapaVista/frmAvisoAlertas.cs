using CapaEntidades.NegocioEntidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public class frmAvisoAlertas : Form
    {
        private const int SEGUNDOS_VISIBLE = 10;
        private const int MAXIMO_RENGLONES = 3;
        private const int ANCHO_MINIMO = 340;
        private const int ANCHO_MAXIMO = 600;
        private const int PORCENTAJE_ANCHO = 30;

        private readonly Action verAlertas;
        private readonly System.Windows.Forms.Timer cierre = new System.Windows.Forms.Timer();
        private readonly Label detalle;
        private readonly Label cerrar;

        public frmAvisoAlertas(List<ClsAlertaEntidad> urgentes, Action verAlertas)
        {
            this.verAlertas = verAlertas;

            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            BackColor = Color.White;
            Padding = new Padding(1);
            Size = new Size(340, 110);

            Panel borde = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            Panel franja = new Panel { Dock = DockStyle.Left, Width = 5, BackColor = Color.Firebrick };

            Label titulo = new Label
            {
                Text = urgentes.Count == 1 ? ClsIdioma.T("Tenés 1 alerta urgente") : ClsIdioma.T("Tenés ") + urgentes.Count + ClsIdioma.T(" alertas urgentes"),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Firebrick,
                Location = new Point(14, 8),
                AutoSize = true
            };

            detalle = new Label
            {
                Text = string.Join(Environment.NewLine, urgentes.Take(MAXIMO_RENGLONES).Select(a => "• " + ClsIdioma.TraducirAlerta(a.Descripcion)))
                       + (urgentes.Count > MAXIMO_RENGLONES ? Environment.NewLine + ClsIdioma.T("• y ") + (urgentes.Count - MAXIMO_RENGLONES) + ClsIdioma.T(" más…") : ""),
                Font = new Font("Segoe UI", 8.5F),
                Location = new Point(14, 30),
                Size = new Size(316, 52),
                AutoEllipsis = true
            };

            LinkLabel ver = new LinkLabel { Text = ClsIdioma.T("Ver alertas"), AutoSize = true, Location = new Point(14, 86) };
            ver.LinkClicked += (sender, e) => { Close(); this.verAlertas(); };

            cerrar = new Label
            {
                Text = "✕",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(318, 6),
                Cursor = Cursors.Hand
            };
            cerrar.Click += (sender, e) => Close();

            borde.Controls.AddRange(new Control[] { titulo, detalle, ver, cerrar });
            Controls.Add(borde);
            Controls.Add(franja);
            BackColor = Color.Silver;

            cierre.Interval = SEGUNDOS_VISIBLE * 1000;
            cierre.Tick += (sender, e) => Close();
        }

        protected override bool ShowWithoutActivation => true;

        public void Mostrar(Form duenio)
        {
            Owner = duenio;
            Acomodar();
            Show();

            duenio.Resize += Duenio_Cambio;
            duenio.LocationChanged += Duenio_Cambio;
            duenio.Shown += Duenio_Cambio;

            cierre.Start();
        }

        // esquina inferior derecha
        private void Acomodar()
        {
            if (Owner == null)
                return;

            Rectangle area = Owner.RectangleToScreen(Owner.ClientRectangle);

            // ancho segun el form
            int ancho = Math.Max(ANCHO_MINIMO, Math.Min(ANCHO_MAXIMO, area.Width * PORCENTAJE_ANCHO / 100));
            Width = ancho;
            detalle.Width = ancho - 24;
            cerrar.Left = ancho - 22;

            Location = new Point(area.Right - Width - 12, area.Bottom - Height - 12);
        }

        private void Duenio_Cambio(object sender, EventArgs e)
        {
            if (IsDisposed || Owner == null)
                return;

            Visible = Owner.WindowState != FormWindowState.Minimized;
            Acomodar();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Resize -= Duenio_Cambio;
                Owner.LocationChanged -= Duenio_Cambio;
                Owner.Shown -= Duenio_Cambio;
            }

            base.OnFormClosed(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                cierre.Dispose();

            base.Dispose(disposing);
        }
    }
}
