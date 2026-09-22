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
        private int? idRolInicial;
        private DataTable dtPermisos;
        public bool PermisosModificados { get; private set; }
        private bool cerrarAlGuardar;

        public frmPermisos()
        {
            InitializeComponent();

            this.Load += frmPermisos_Load;

            treePermisos.AfterCheck += treePermisos_AfterCheck;

        }
        public frmPermisos(bool cerrarAlGuardar) : this()
        {
            this.cerrarAlGuardar = cerrarAlGuardar;
        }
        public frmPermisos(int idRol) : this()
        {
            idRolInicial = idRol;
        }
        public frmPermisos(int idRol, bool cerrarAlGuardar) : this(idRol)
        {
            this.cerrarAlGuardar = cerrarAlGuardar;
        }

        public int IdRolSeleccionado
        {
            get
            {
                if (lstRoles.SelectedValue == null ||
                    lstRoles.SelectedValue is DataRowView)
                {
                    return 0;
                }

                return Convert.ToInt32(lstRoles.SelectedValue);
            }
        }
        public bool TienePermisosSeleccionados
        {
            get
            {
                return ObtenerPermisosSeleccionados().Count > 0;
            }
        }
        private void frmPermisos_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarPermisos();

            if (idRolInicial.HasValue)
            {
                lstRoles.SelectedValue = idRolInicial.Value;
                lstRoles_SelectedIndexChanged(lstRoles, EventArgs.Empty);
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

                nodoGrupo.Text = fila["Nombre"].ToString();
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

                nodoPermiso.Text = fila["Nombre"].ToString();
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
                    return "ARTÍCULOS";

                case 2:
                    return "VENTAS";

                case 3:
                    return "COMPRAS";

                case 4:
                    return "PROVEEDORES";

                case 5:
                    return "LISTADOS";

                case 6:
                    return "INFORMES";

                case 7:
                    return "CAJA";

                case 8:
                    return "AJUSTES";

                case 9:
                    return "AYUDA";

                case 10:
                    return "EMPLEADOS";

                case 11:
                    return "ALARMAS";

                case 12:
                    return "DATOS SENSIBLES";

                default:
                    return "SECCIÓN";
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
        private void treePermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null || dtPermisos == null)
            {
                return;
            }

            int idPermiso = Convert.ToInt32(e.Node.Tag);

            DataRow[] filas = dtPermisos.Select("IdPermiso = " + idPermiso);

            if (filas.Length == 0)
            {
                return;
            }

            DataRow fila = filas[0];

            lblPermisoSeleccionado.Text = "Permiso seleccionado: " + fila["Nombre"].ToString();
            lblDescripcion.Text = "Descripción:\r\n" + fila["Descripcion"].ToString();
            lblEstado.Text = "Estado del permiso:\r\n" + "Asignado al rol: " + (e.Node.Checked ? "SÍ" : "NO");
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

            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

            List<int> permisos = rol.ObtenerPermisos(idRol);

            foreach (TreeNode nodoSeccion in treePermisos.Nodes)
            {
                MarcarPermisos(nodoSeccion, permisos);
            }

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lstRoles.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un rol.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(lstRoles.SelectedValue?.ToString(), out int idRol))
            {
                MessageBox.Show("No se pudo obtener el rol seleccionado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            List<int> permisos = ObtenerPermisosSeleccionados();

            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

            try
            {
                rol.GuardarPermisos(idRol, permisos);

                PermisosModificados = true;

                MessageBox.Show("Los permisos del rol se guardaron correctamente.", "Permisos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cerrarAlGuardar)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron guardar los permisos.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Seleccione un rol para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(lstRoles.SelectedValue?.ToString(), out int idRol))
            {
                MessageBox.Show("No se pudo obtener el rol seleccionado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // Los 4 roles principales no se pueden eliminar
            if (idRol >= 1 && idRol <= 4)
            {
                MessageBox.Show("Los roles principales del sistema no se pueden eliminar.", "Rol protegido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            string nombreRol = lstRoles.Text;

            DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar el rol \"" + nombreRol + "\"?", "Eliminar Rol",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }


            try
            {
                CapaLogica.ClsRol rol = new CapaLogica.ClsRol();
                rol.EliminarRol(idRol);

                MessageBox.Show("El rol se eliminó correctamente.", "Eliminar Rol",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarRoles();

                if (lstRoles.Items.Count > 0)
                {
                    lstRoles.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el rol.\n\n" + ex.Message, "Error",
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
