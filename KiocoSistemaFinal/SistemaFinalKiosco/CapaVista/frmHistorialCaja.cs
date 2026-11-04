using CapaLogica.NegocioLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmHistorialCaja : Form
    {
        private ClsCajaLogica logica = new ClsCajaLogica();

        public frmHistorialCaja()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
            ClsGrilla.AjustarAlContenido(dgvSesiones);
            ConfigurarGrid();
        }

        private void frmHistorialCaja_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;
            CargarSesiones();
        }

        #region Metodos

        private void ConfigurarGrid()
        {
            dgvSesiones.AutoGenerateColumns = true;
            dgvSesiones.ReadOnly = true;
            dgvSesiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSesiones.MultiSelect = false;
            dgvSesiones.AllowUserToAddRows = false;
            dgvSesiones.AllowUserToResizeColumns = false;
            dgvSesiones.AllowUserToOrderColumns = false;
            dgvSesiones.RowHeadersVisible = false;
            dgvSesiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarSesiones()
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(ClsIdioma.T("La fecha desde no puede ser mayor a la fecha hasta."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable tabla = logica.ObtenerSesiones(dtpDesde.Value.Date, dtpHasta.Value.Date);
                dgvSesiones.DataSource = tabla;

                decimal faltantes = 0;
                decimal sobrantes = 0;
                foreach (DataRow fila in tabla.Rows)
                {
                    if (fila["Diferencia"] == DBNull.Value)
                    {
                        continue;
                    }

                    decimal diferencia = Convert.ToDecimal(fila["Diferencia"]);
                    if (diferencia < 0) faltantes += diferencia;
                    if (diferencia > 0) sobrantes += diferencia;
                }

                lblTotales.Text = (ClsIdioma.Ingles ? $"Cash registers: {tabla.Rows.Count}    Shortages: $ {faltantes:N2}    Overages: $ {sobrantes:N2}" : $"Cajas: {tabla.Rows.Count}    Faltantes: $ {faltantes:N2}    Sobrantes: $ {sobrantes:N2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo obtener el historial de cajas.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos

        private void dgvSesiones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Dictionary<string, string> titulos = new Dictionary<string, string>
            {
                { "IdSesionCaja", "Sesión" },
                { "FechaApertura", "Apertura" },
                { "AbiertaPor", "Abierta por" },
                { "MontoInicial", "Fondo inicial" },
                { "FechaCierre", "Cierre" },
                { "CerradaPor", "Cerrada por" },
                { "EfectivoEsperado", "Esperado" },
                { "EfectivoContado", "Contado" },
                { "ObservacionCierre", "Observación" }
            };

            foreach (KeyValuePair<string, string> titulo in titulos)
            {
                if (dgvSesiones.Columns.Contains(titulo.Key))
                {
                    dgvSesiones.Columns[titulo.Key].HeaderText = ClsIdioma.T(titulo.Value);
                }
            }

            foreach (string fecha in new[] { "FechaApertura", "FechaCierre" })
            {
                if (dgvSesiones.Columns.Contains(fecha))
                {
                    dgvSesiones.Columns[fecha].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }

            foreach (string importe in new[] { "MontoInicial", "EfectivoEsperado", "EfectivoContado", "Diferencia" })
            {
                if (dgvSesiones.Columns.Contains(importe))
                {
                    dgvSesiones.Columns[importe].DefaultCellStyle.Format = "N2";
                    dgvSesiones.Columns[importe].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            foreach (DataGridViewRow fila in dgvSesiones.Rows)
            {
                string estado = fila.Cells["Estado"].Value?.ToString();
                if (estado == "Faltante")
                {
                    fila.DefaultCellStyle.ForeColor = Color.Firebrick;
                }
                else if (estado == "Abierta")
                {
                    fila.DefaultCellStyle.ForeColor = Color.SeaGreen;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarSesiones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
