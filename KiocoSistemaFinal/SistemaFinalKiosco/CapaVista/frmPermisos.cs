    using System;
using System.Collections.Generic;
using CapaLogica;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmPermisos : Form
    {
        private const int ID_ROL_ADMINISTRADOR = 1;
        private const int PERMISO_ROLES = 1270;
        private int? idRolInicial;
        private DataTable dtPermisos;
        private bool actualizandoArbol = false;
        private HashSet<TreeNode> nodosBloqueados = new HashSet<TreeNode>();

        private bool soloEseRol = false;
        private bool hayCambios = false;
        private int idRolActual = 0;
        private bool cambiandoRol = false;

        public frmPermisos()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            this.Load += frmPermisos_Load;
            this.FormClosing += frmPermisos_FormClosing;

            btnSalir.Visible = false;
            btnCancelar.Bounds = btnSalir.Bounds;
            btnGuardar.Text = ClsIdioma.T("Guardar y volver");
            btnGuardar.SetBounds(btnCancelar.Left - 148, btnCancelar.Top, 140, btnCancelar.Height);

            treePermisos.BeforeCheck += treePermisos_BeforeCheck;
            treePermisos.AfterCheck += treePermisos_AfterCheck;

            treePermisos.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treePermisos.DrawNode += treePermisos_DrawNode;
        }
        public frmPermisos(int idRol, bool soloEseRol = false) : this()
        {
            idRolInicial = idRol;
            this.soloEseRol = soloEseRol;
        }

        private bool PuedeEditarPermisos
        {
            get { return CapaEntidades.SesionUsuario.Permisos.Contains(PERMISO_ROLES); }
        }
        private void frmPermisos_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarPermisos();

            btnGuardar.Enabled = PuedeEditarPermisos;
            btnNuevoRol.Enabled = PuedeEditarPermisos;
            btnEliminarRol.Enabled = PuedeEditarPermisos;

            if (idRolInicial.HasValue)
            {
                lstRoles.SelectedValue = idRolInicial.Value;
                lstRoles_SelectedIndexChanged(lstRoles, EventArgs.Empty);
            }

            if (soloEseRol && idRolInicial.HasValue)
            {
                lstRoles.Enabled = false;
                btnNuevoRol.Enabled = false;
                btnEliminarRol.Enabled = false;
            }

            ActualizarTitulo();
        }
        private void ActualizarTitulo()
        {
            if (lstRoles.SelectedIndex == -1 || !int.TryParse(lstRoles.SelectedValue?.ToString(), out int idRol))
            {
                Text = ClsIdioma.T("Permisos de los roles");
                return;
            }

            string nombre = lstRoles.Text;
            int cantidad = 0;

            try
            {
                cantidad = new CapaLogica.ClsRol().ContarUsuariosPorRol(idRol);
            }
            catch
            {
                cantidad = -1;
            }

            bool ingles = ClsIdioma.Ingles;
            string empleados = ingles ? cantidad + (cantidad == 1 ? " employee" : " employees")
                : cantidad + (cantidad == 1 ? " empleado" : " empleados");

            Text = cantidad < 0 ? (ingles ? "Permissions of role " : "Permisos del rol ") + nombre
                : (ingles ? "Permissions of role " + nombre + ": affects " : "Permisos del rol " + nombre + ": afecta a ") + empleados;

            gpbPermisos.Text = (ingles ? "PERMISSIONS OF ROLE " : "PERMISOS DEL ROL ") + nombre.ToUpper() +
                (cantidad < 0 ? "" : (ingles ? "  (affects " : "  (afecta a ") + empleados + ")");
        }
        private bool ConfirmarDescartarCambios()
        {
            if (!hayCambios)
            {
                return true;
            }

            DialogResult respuesta = MessageBox.Show(
                ClsIdioma.T("Tenés cambios sin guardar en los permisos del rol ") + lstRoles.Text + ClsIdioma.T(".\n\n¿Querés descartarlos?"),
                ClsIdioma.T("Cambios sin guardar"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return respuesta == DialogResult.Yes;
        }
        private void frmPermisos_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && !ConfirmarDescartarCambios())
            {
                e.Cancel = true;
            }
        }

        #region Metodos
        private void CargarRoles()
        {
            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();
            DataTable dt = rol.ObtenerRoles();

            lstRoles.DataSource = null;
            lstRoles.DisplayMember = "Nombre";
            lstRoles.ValueMember = "IdRol";
            lstRoles.DataSource = dt;
            ClsIdioma.TraducirDatosAlMostrar(lstRoles);
        }
        private void CargarPermisos()
        {
            CapaLogica.ClsPermiso permiso = new CapaLogica.ClsPermiso();

            dtPermisos = permiso.ObtenerPermisos();
            DataTable dt = dtPermisos;

            treePermisos.Nodes.Clear();

            Dictionary<int, TreeNode> secciones = new Dictionary<int, TreeNode>();
            Dictionary<string, TreeNode> grupos = new Dictionary<string, TreeNode>();

            foreach (DataRow fila in dt.Rows)
            {
                string codigo = fila["CodigoPermiso"].ToString();
                string[] partes = codigo.Split('.');

                if (partes.Length != 3)
                {
                    continue;
                }

                int seccion = Convert.ToInt32(partes[0]);
                int nivel2 = Convert.ToInt32(partes[1]);
                int nivel3 = Convert.ToInt32(partes[2]);

                if (nivel2 == 0 && nivel3 == 0)
                {
                    TreeNode nodoSeccion = new TreeNode();

                    nodoSeccion.Text = ObtenerNombreSeccion(seccion);
                    nodoSeccion.Tag = Convert.ToInt32(fila["IdPermiso"]);

                    treePermisos.Nodes.Add(nodoSeccion);

                    secciones.Add(seccion, nodoSeccion);
                }
            }

            foreach (DataRow fila in dt.Rows)
            {
                string codigo = fila["CodigoPermiso"].ToString();
                string[] partes = codigo.Split('.');

                if (partes.Length != 3)
                {
                    continue;
                }

                int seccion = Convert.ToInt32(partes[0]);
                int nivel2 = Convert.ToInt32(partes[1]);
                int nivel3 = Convert.ToInt32(partes[2]);

                if (nivel2 == 0 || nivel3 != 0)
                {
                    continue;
                }

                if (!secciones.ContainsKey(seccion))
                {
                    continue;
                }

                TreeNode nodoGrupo = new TreeNode();

                nodoGrupo.Text = ClsIdioma.Dato(fila["Nombre"]);
                nodoGrupo.Tag = Convert.ToInt32(fila["IdPermiso"]);

                secciones[seccion].Nodes.Add(nodoGrupo);

                string claveGrupo = seccion + "." + nivel2;

                grupos.Add(claveGrupo, nodoGrupo);
            }

            foreach (DataRow fila in dt.Rows)
            {
                string codigo = fila["CodigoPermiso"].ToString();
                string[] partes = codigo.Split('.');

                if (partes.Length != 3)
                {
                    continue;
                }

                int seccion = Convert.ToInt32(partes[0]);
                int nivel2 = Convert.ToInt32(partes[1]);
                int nivel3 = Convert.ToInt32(partes[2]);

                if (nivel2 == 0 || nivel3 == 0)
                {
                    continue;
                }

                string claveGrupo = seccion + "." + nivel2;

                if (!grupos.ContainsKey(claveGrupo))
                {
                    continue;
                }

                TreeNode nodoPermiso = new TreeNode();

                nodoPermiso.Text = ClsIdioma.Dato(fila["Nombre"]);
                nodoPermiso.Tag = Convert.ToInt32(fila["IdPermiso"]);

                grupos[claveGrupo].Nodes.Add(nodoPermiso);
            }

            treePermisos.ExpandAll();
        }
        private void MarcarPermisos(TreeNode nodo, List<int> permisos)
        {
            if (nodo.Tag != null)
            {
                int idPermiso = Convert.ToInt32(nodo.Tag);

                nodo.Checked = permisos.Contains(idPermiso);
            }

            foreach (TreeNode hijo in nodo.Nodes)
            {
                MarcarPermisos(hijo, permisos);
            }
        }
        private string ObtenerNombreSeccion(int numeroSeccion)
        {
            switch (numeroSeccion)
            {
                case 1:
                    return ClsIdioma.T("ARTÍCULOS");

                case 2:
                    return ClsIdioma.T("VENTAS");

                case 3:
                    return ClsIdioma.T("COMPRAS");

                case 4:
                    return ClsIdioma.T("PROVEEDORES");

                case 5:
                    return ClsIdioma.T("LISTADOS");

                case 6:
                    return ClsIdioma.T("INFORMES");

                case 7:
                    return ClsIdioma.T("CAJA");

                case 8:
                    return ClsIdioma.T("AJUSTES");

                case 9:
                    return ClsIdioma.T("AYUDA");

                case 10:
                    return ClsIdioma.T("EMPLEADOS");

                case 11:
                    return ClsIdioma.T("ALARMAS");

                case 12:
                    return ClsIdioma.T("DATOS SENSIBLES");

                default:
                    return ClsIdioma.T("SECCIÓN");
            }
        }
        private List<int> ObtenerPermisosSeleccionados()
        {
            List<int> permisos = new List<int>();

            foreach (TreeNode nodoSeccion in treePermisos.Nodes)
            {
                ObtenerPermisosNodo(nodoSeccion, permisos);
            }

            return permisos;
        }
        private void ObtenerPermisosNodo(TreeNode nodo, List<int> permisos)
        {
            if (nodo.Checked && nodo.Tag != null)
            {
                permisos.Add(Convert.ToInt32(nodo.Tag));
            }

            foreach (TreeNode hijo in nodo.Nodes)
            {
                ObtenerPermisosNodo(hijo, permisos);
            }
        }
        private void MarcarRama(TreeNode nodo, bool marcado)
        {
            foreach (TreeNode hijo in nodo.Nodes)
            {
                hijo.Checked = marcado;
                MarcarRama(hijo, marcado);
            }
        }
        private bool EsCabeza(TreeNode nodo)
        {
            return nodo.Parent == null;
        }
        private void MarcarRamaSinEventos(TreeNode nodo, bool marcado)
        {
            foreach (TreeNode hijo in nodo.Nodes)
            {
                hijo.Checked = marcado;
                MarcarRamaSinEventos(hijo, marcado);
            }
        }
        private void BloquearHijos(TreeNode nodo, bool bloquear)
        {
            foreach (TreeNode hijo in nodo.Nodes)
            {
                if (bloquear)
                {
                    nodosBloqueados.Add(hijo);
                }
                else
                {
                    nodosBloqueados.Remove(hijo);
                }

                BloquearHijos(hijo, bloquear);
            }
        }
        private void treePermisos_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (actualizandoArbol)
                return;

            if (nodosBloqueados.Contains(e.Node))
            {
                e.Cancel = true;
            }
        }
        private void treePermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null || dtPermisos == null)
            { 
                return; 
            }
                
            if (actualizandoArbol)
            {
                return;
            }

            hayCambios = true;

            actualizandoArbol = true;

            try
            {
                if (e.Node.Checked)
                {
                    MarcarRamaSinEventos(e.Node, true);
                    BloquearHijos(e.Node, true);
                }
                else
                {
                    MarcarRamaSinEventos(e.Node, false);
                    BloquearHijos(e.Node, false);
                }
            }
            finally
            {
                actualizandoArbol = false;
            }

            MostrarInformacionPermiso(e.Node);

            treePermisos.Invalidate();
        }
        private void MostrarInformacionPermiso(TreeNode nodo)
        {
            if (nodo == null || nodo.Tag == null || dtPermisos == null)
                return;

            int idPermiso = Convert.ToInt32(nodo.Tag);

            DataRow[] filas = dtPermisos.Select("IdPermiso = " + idPermiso);

            if (filas.Length == 0)
                return;

            DataRow fila = filas[0];

            lblPermisoSeleccionado.Text =
                ClsIdioma.T("Permiso seleccionado: ") + ClsIdioma.Dato(fila["Nombre"]);

            lblDescripcion.Text =
                ClsIdioma.T("Descripción:\r\n") + ClsIdioma.Dato(fila["Descripcion"]);

            lblEstado.Text =
                ClsIdioma.T("Estado del permiso:\r\n") +
                ClsIdioma.T("Asignado al rol: ") +
                (nodo.Checked ? ClsIdioma.T("SÍ") : "NO");
        }
        private void AplicarBloqueoSegunEstado(TreeNode nodo)
        {
            if (nodo.Checked)
            {
                BloquearHijos(nodo, true);
            }
            else
            {
                BloquearHijos(nodo, false);
            }

            foreach (TreeNode hijo in nodo.Nodes)
            {
                AplicarBloqueoSegunEstado(hijo);
            }
        }
        private void treePermisos_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Color colorTexto;

            if (nodosBloqueados.Contains(e.Node))
            {
                colorTexto = SystemColors.GrayText;
            }
            else
            {
                colorTexto = SystemColors.ControlText;
            }

            TextRenderer.DrawText(
                e.Graphics,
                e.Node.Text,
                treePermisos.Font,
                e.Bounds,
                colorTexto,
                TextFormatFlags.VerticalCenter
            );
        }
        private void BloquearNodo(TreeNode nodo)
        {
            nodosBloqueados.Add(nodo);
            BloquearHijos(nodo, true);
        }
        private void AplicarBloqueoSegunEstado(TreeNode nodo, bool padreBloqueado)
        {
            bool bloqueado = padreBloqueado;

            if (bloqueado)
            {
                nodosBloqueados.Add(nodo);
            }
            else
            {
                nodosBloqueados.Remove(nodo);
            }

            foreach (TreeNode hijo in nodo.Nodes)
            {
                AplicarBloqueoSegunEstado(hijo, bloqueado || nodo.Checked);
            }
        }

        #endregion



        #region Eventos
        private void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRoles.SelectedIndex == -1)
            {
                return;
            }

            if (lstRoles.SelectedValue == null)
            {
                return;
            }

            int idRol;

            if (!int.TryParse(lstRoles.SelectedValue.ToString(), out idRol))
            {
                return;
            }

            if (cambiandoRol)
            {
                return;
            }

            if (idRol != idRolActual && idRolActual != 0 && !ConfirmarDescartarCambios())
            {
                cambiandoRol = true;
                lstRoles.SelectedValue = idRolActual;
                cambiandoRol = false;
                return;
            }

            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

            List<int> permisos = rol.ObtenerPermisos(idRol);

            actualizandoArbol = true;

            try
            {
                nodosBloqueados.Clear();

                foreach (TreeNode nodoSeccion in treePermisos.Nodes)
                {
                    MarcarPermisos(nodoSeccion, permisos);
                }

                foreach (TreeNode nodoSeccion in treePermisos.Nodes)
                {
                    AplicarBloqueoSegunEstado(nodoSeccion, false);
                }

                bool esAdministrador = idRol == ID_ROL_ADMINISTRADOR;

                foreach (TreeNode nodoSeccion in treePermisos.Nodes)
                {
                    if (esAdministrador)
                    {
                        nodoSeccion.Checked = true;
                        MarcarRamaSinEventos(nodoSeccion, true);
                    }

                    if (esAdministrador || !PuedeEditarPermisos)
                    {
                        BloquearNodo(nodoSeccion);
                    }
                }
            }
            finally
            {
                actualizandoArbol = false;
            }

            idRolActual = idRol;
            hayCambios = false;
            ActualizarTitulo();

            treePermisos.Invalidate();

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lstRoles.SelectedIndex == -1)
            {
                MessageBox.Show(
                    ClsIdioma.T("Seleccione un rol."), ClsIdioma.T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(lstRoles.SelectedValue?.ToString(), out int idRol))
            {
                MessageBox.Show(ClsIdioma.T("No se pudo obtener el rol seleccionado."), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            List<int> permisos = ObtenerPermisosSeleccionados();

            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

            try
            {
                rol.GuardarPermisos(idRol, permisos);

                hayCambios = false;

                MessageBox.Show(ClsIdioma.T("Se guardaron los permisos del rol ") + lstRoles.Text + ".\n\n" +
                    ClsIdioma.T("Los empleados con ese rol los verán la próxima vez que inicien sesión."), ClsIdioma.T("Permisos"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron guardar los permisos.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            if (!ConfirmarDescartarCambios())
            {
                return;
            }

            hayCambios = false;

            using (frmNuevoRol formulario = new frmNuevoRol())
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    CargarRoles();

                    if (formulario.IdRolCreado > 0)
                    {
                        lstRoles.SelectedValue = formulario.IdRolCreado;
                    }
                }
            }
        }
        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            if (lstRoles.SelectedIndex == -1)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un rol para eliminar."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(lstRoles.SelectedValue?.ToString(), out int idRol))
            {
                MessageBox.Show(ClsIdioma.T("No se pudo obtener el rol seleccionado."), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (idRol >= 1 && idRol <= 4)
            {
                MessageBox.Show(ClsIdioma.T("Los roles principales del sistema no se pueden eliminar."), ClsIdioma.T("Rol protegido"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!ConfirmarDescartarCambios())
            {
                return;
            }

            string nombreRol = lstRoles.Text;

            DialogResult resultado = MessageBox.Show(ClsIdioma.T("¿Está seguro de eliminar el rol \"") + nombreRol + "\"?", ClsIdioma.T("Eliminar Rol"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }


            try
            {
                CapaLogica.ClsRol rol = new CapaLogica.ClsRol();
                rol.EliminarRol(idRol);

                hayCambios = false;
                idRolActual = 0;

                MessageBox.Show(ClsIdioma.T("El rol se eliminó correctamente."), ClsIdioma.T("Eliminar Rol"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarRoles();

                if (lstRoles.Items.Count > 0)
                {
                    lstRoles.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudo eliminar el rol.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion






    }
}
