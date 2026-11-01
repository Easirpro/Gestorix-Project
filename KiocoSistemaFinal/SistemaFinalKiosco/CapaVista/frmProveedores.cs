using System;
using CapaLogica.NegocioLogica;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaVista
{
    public partial class frmProveedores : Form
    {
        ClsLogicaProveedor logica = new ClsLogicaProveedor();
        DataTable? tablaProveedores;

        // Proveedor elegido en el buscador (null = todos).
        private int? idProveedorSeleccionado = null;
        // Evita que poner el nombre elegido en el cuadro vuelva a abrir la lista.
        private bool cambiandoTexto = false;

        private bool puedeCrear;
        private bool puedeModificar;

        // Ítem de la lista de sugerencias: muestra el nombre (y CUIT) y guarda el id.
        private class ItemProveedor
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = "";
            public string Texto { get; set; } = "";
            public override string ToString() => Texto;
        }

        public frmProveedores()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            AplicarPermisos();
            CargarProveedores();
        }
        #region Metodos
        private void AplicarPermisos()
        {
            puedeCrear = SesionUsuario.Permisos.Contains(410) || SesionUsuario.Permisos.Contains(411);
            puedeModificar = SesionUsuario.Permisos.Contains(410) || SesionUsuario.Permisos.Contains(412);

            btnNuevoProveedor.Enabled = puedeCrear;
            ActualizarBotones();
        }
        // Modificar y Descontinuar/Activar solo con permiso y con un proveedor elegido en la grilla.
        private void ActualizarBotones()
        {
            bool hayFila = dtgProveedores.CurrentRow != null;

            btnModificar.Enabled = puedeModificar && hayFila;
            btnDescontinuar.Enabled = puedeModificar && hayFila;
        }
        // Vuelve a leer los proveedores de la base. Si se indica, deja elegido ese proveedor.
        private void CargarProveedores(int? idProveedorAElegir = null)
        {
            try
            {
                tablaProveedores = logica.ObtenerProveedores();
            }
            catch (Exception ex)
            {
                tablaProveedores = null;

                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los proveedores.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FiltrarProveedores(idProveedorAElegir);
        }
        // Llena la grilla solo con el proveedor elegido en el buscador (sin proveedor elegido queda vacía).
        private void FiltrarProveedores(int? idProveedorAElegir = null)
        {
            dtgProveedores.Rows.Clear();

            if (tablaProveedores != null && idProveedorSeleccionado.HasValue)
            {
                foreach (DataRow fila in tablaProveedores.Rows)
                {
                    int idProveedor = Convert.ToInt32(fila["IdProveedor"]);
                    string estado = fila["Estado"]?.ToString() ?? "";

                    if (chkOcultarProveedores.Checked && estado == "Inactivo")
                    {
                        continue;
                    }

                    if (idProveedor != idProveedorSeleccionado.Value)
                    {
                        continue;
                    }

                    string sucursal = fila["Sucursal"] == DBNull.Value ? "Sin sucursal" : fila["Sucursal"]?.ToString() ?? "Sin sucursal";

                    int indice = dtgProveedores.Rows.Add(
                        idProveedor,
                        sucursal,
                        fila["RazonSocial"],
                        fila["CUIT"],
                        fila["CondiciónIVA"],
                        fila["NumTelefono"],
                        fila["Correo"],
                        fila["Direccion"],
                        estado);

                    DataGridViewRow filaGrilla = dtgProveedores.Rows[indice];

                    filaGrilla.Tag = fila["Observacion"]?.ToString() ?? "";

                    // Los inactivos en gris, para distinguirlos de un vistazo.
                    if (estado == "Inactivo")
                    {
                        filaGrilla.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                    }
                }
            }

            dtgProveedores.ClearSelection();

            DataGridViewRow? filaAElegir = null;

            if (idProveedorAElegir.HasValue)
            {
                filaAElegir = dtgProveedores.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(f => Convert.ToInt32(f.Cells["clnId"].Value) == idProveedorAElegir.Value);
            }

            if (filaAElegir == null && dtgProveedores.Rows.Count > 0)
            {
                filaAElegir = dtgProveedores.Rows[0];
            }

            if (filaAElegir != null)
            {
                dtgProveedores.CurrentCell = filaAElegir.Cells["clnRazonSocial"];
                filaAElegir.Selected = true;
            }

            if (!idProveedorSeleccionado.HasValue)
            {
                lblCantidad.Text = ClsIdioma.T("Busque un proveedor arriba para ver sus datos.");
            }
            else if (dtgProveedores.Rows.Count == 0)
            {
                lblCantidad.Text = ClsIdioma.T("El proveedor elegido está inactivo y oculto por el filtro.");
            }
            else
            {
                lblCantidad.Text = dtgProveedores.Rows.Count == 1 ? ClsIdioma.T("1 sucursal") : dtgProveedores.Rows.Count + ClsIdioma.T(" sucursales");
            }

            MostrarDatosFilaActual();
        }
        // Observaciones y texto del botón Descontinuar/Activar según la fila elegida.
        private void MostrarDatosFilaActual()
        {
            DataGridViewRow? fila = dtgProveedores.CurrentRow;

            if (fila == null)
            {
                txtObsevaciones.Clear();
                btnDescontinuar.Text = ClsIdioma.T("Descontinuar");
                ActualizarBotones();
                return;
            }

            txtObsevaciones.Text = fila.Tag?.ToString() ?? "";

            string estado = fila.Cells["clnEstado"].Value?.ToString() ?? "";

            btnDescontinuar.Text = estado == "Inactivo" ? ClsIdioma.T("Activar") : ClsIdioma.T("Descontinuar");

            ActualizarBotones();
        }
        // Lista los proveedores cuyo nombre empieza con lo escrito (o cuyo CUIT empieza con esos números).
        private void MostrarSugerencias(string texto)
        {
            lstProveedores.Items.Clear();

            if (tablaProveedores != null)
            {
                string textoCuit = texto.Replace("-", "");

                IEnumerable<ItemProveedor> items = tablaProveedores.AsEnumerable()
                    .Where(f => !chkOcultarProveedores.Checked || (f["Estado"]?.ToString() ?? "") != "Inactivo")
                    .Select(f => new
                    {
                        Id = Convert.ToInt32(f["IdProveedor"]),
                        Nombre = f["RazonSocial"]?.ToString() ?? "",
                        Cuit = f["CUIT"]?.ToString() ?? ""
                    })
                    .Where(p => p.Nombre.StartsWith(texto, StringComparison.CurrentCultureIgnoreCase) ||
                                (textoCuit != "" && p.Cuit.Replace("-", "").StartsWith(textoCuit)))
                    .GroupBy(p => p.Id)
                    .Select(g => g.First())
                    .OrderBy(p => p.Nombre)
                    .Select(p => new ItemProveedor
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Texto = p.Cuit == "" ? p.Nombre : p.Nombre + "   (CUIT " + p.Cuit + ")"
                    });

                foreach (ItemProveedor item in items)
                {
                    lstProveedores.Items.Add(item);
                }
            }

            lstProveedores.Visible = lstProveedores.Items.Count > 0;

            if (lstProveedores.Visible)
            {
                lstProveedores.SelectedIndex = 0;
                lstProveedores.BringToFront();
            }
        }
        // Toma el proveedor marcado en la lista y deja en la grilla solo ese proveedor.
        private void SeleccionarProveedor()
        {
            if (!lstProveedores.Visible || lstProveedores.SelectedItem is not ItemProveedor item)
            {
                return;
            }

            idProveedorSeleccionado = item.Id;

            cambiandoTexto = true;

            try
            {
                txtBuscar.Text = item.Nombre;
                txtBuscar.SelectionStart = txtBuscar.Text.Length;
            }
            finally
            {
                cambiandoTexto = false;
            }

            OcultarSugerencias();
            FiltrarProveedores(item.Id);

            dtgProveedores.Focus();
        }
        private void OcultarSugerencias()
        {
            lstProveedores.Items.Clear();
            lstProveedores.Visible = false;
        }
        private int? IdProveedorFilaActual()
        {
            if (dtgProveedores.CurrentRow == null || dtgProveedores.CurrentRow.Cells["clnId"].Value == null)
            {
                return null;
            }

            return Convert.ToInt32(dtgProveedores.CurrentRow.Cells["clnId"].Value);
        }


        #endregion



        #region Eventos
        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            using (frmNuevoProveedor nuevoProveedor = new frmNuevoProveedor())
            {
                nuevoProveedor.ShowDialog(this);
            }

            CargarProveedores(IdProveedorFilaActual());
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            int? idProveedor = IdProveedorFilaActual();

            if (!idProveedor.HasValue)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un proveedor para modificar."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmNuevoProveedor modproveedor = new frmNuevoProveedor(idProveedor.Value))
            {
                modproveedor.ShowDialog(this);
            }

            // Se recarga y se vuelve a elegir el mismo proveedor.
            CargarProveedores(idProveedor.Value);
        }
        private void dtgProveedores_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Doble clic en una fila (no en el encabezado) = Modificar, si tiene permiso.
            if (e.RowIndex >= 0 && btnModificar.Enabled)
            {
                BtnModificar_Click(btnModificar, EventArgs.Empty);
            }
        }
        private void dtgProveedores_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarDatosFilaActual();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarProveedores(IdProveedorFilaActual());
        }
        private void chkOcultarProveedores_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarProveedores(IdProveedorFilaActual());
        }
        private void txtBuscar_TextChanged(object? sender, EventArgs e)
        {
            if (cambiandoTexto)
            {
                return;
            }

            string texto = txtBuscar.Text.Trim();

            // Al escribir de nuevo, la grilla se vacía hasta elegir otro proveedor de la lista.
            if (idProveedorSeleccionado.HasValue)
            {
                idProveedorSeleccionado = null;
                FiltrarProveedores();
            }

            if (texto == string.Empty)
            {
                OcultarSugerencias();
                return;
            }

            MostrarSugerencias(texto);
        }
        private void txtBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SeleccionarProveedor();
                return;
            }

            if (!lstProveedores.Visible || lstProveedores.Items.Count == 0)
            {
                return;
            }

            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;

                if (lstProveedores.SelectedIndex < lstProveedores.Items.Count - 1)
                {
                    lstProveedores.SelectedIndex++;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;

                if (lstProveedores.SelectedIndex > 0)
                {
                    lstProveedores.SelectedIndex--;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                OcultarSugerencias();
            }
        }
        private void lstProveedores_DoubleClick(object? sender, EventArgs e)
        {
            SeleccionarProveedor();
        }
        private void lstProveedores_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SeleccionarProveedor();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                OcultarSugerencias();
                txtBuscar.Focus();
            }
        }
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            idProveedorSeleccionado = null;

            cambiandoTexto = true;

            try
            {
                txtBuscar.Clear();
            }
            finally
            {
                cambiandoTexto = false;
            }

            OcultarSugerencias();

            if (chkOcultarProveedores.Checked)
            {
                chkOcultarProveedores.Checked = false;   // su evento ya vuelve a llenar la grilla
            }
            else
            {
                FiltrarProveedores();
            }

            txtBuscar.Focus();
        }
        private void btnDescontinuar_Click(object sender, EventArgs e)
        {
            int? idProveedor = IdProveedorFilaActual();

            if (!idProveedor.HasValue || dtgProveedores.CurrentRow == null)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un proveedor."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string razonSocial = dtgProveedores.CurrentRow.Cells["clnRazonSocial"].Value?.ToString() ?? "";
            string estado = dtgProveedores.CurrentRow.Cells["clnEstado"].Value?.ToString() ?? "";
            bool activar = estado == "Inactivo";

            string pregunta = activar
                ? ClsIdioma.T("¿Desea volver a activar al proveedor ") + razonSocial + "?"
                : ClsIdioma.T("¿Está seguro de descontinuar al proveedor ") + razonSocial + ClsIdioma.T("?\n\nNo va a aparecer al cargar compras nuevas.");

            DialogResult resultado = MessageBox.Show(pregunta,
                activar ? ClsIdioma.T("Activar proveedor") : ClsIdioma.T("Descontinuar proveedor"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (activar)
                {
                    logica.ActivarProveedor(idProveedor.Value);
                }
                else
                {
                    logica.DescontinuarProveedor(idProveedor.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((activar ? ClsIdioma.T("No se pudo activar el proveedor.") : ClsIdioma.T("No se pudo descontinuar el proveedor.")) +
                    "\n\n" + ex.Message, ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarProveedores(idProveedor.Value);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
