using CapaDatos;
using CapaEntidades;
using CapaLogica;
using CapaVista;
using Microsoft.Data.SqlClient;
using SistemaKiosco;
using System.ComponentModel;
using System.Data;
using static CapaLogica.ClsValidarNumero;
using CapaLogica.BitacoraLogi;
using CapaSesion;


namespace CapaVista
{
    public partial class frmCargaEmpleados : Form
    {
        private Conexion cadena = new Conexion();
        private ClsPersona personaOriginal;
        private ClsDomicilio domicilioOriginal;
        private ClsCorreo correoOriginal;
        private ClsTelefono telefonoOriginal;
        private int idRolSeleccionado;
        private bool cargandoDatosUsuario = false;
        private bool cargandoUsuarios = false;
        private bool permisosModificados = false;

        public frmCargaEmpleados()
        {
            InitializeComponent();
            txtNombre.KeyPress += txt_KeyPress;
            txtApellido.KeyPress += txt_KeyPress;
            txtCorreo.KeyPress += txt_KeyPress;
            txtTelefono.KeyPress += txt_KeyPress;
            txtCalle.KeyPress += txt_KeyPress;
            txtAltura.KeyPress += txt_KeyPress;
            txtPiso.KeyPress += txt_KeyPress;
            txtDepartamento.KeyPress += txt_KeyPress;
            txtPostal.KeyPress += txt_KeyPress;

            CargarProvincias();
        }


        #region Metodos
        private bool ValidarCamposVacios(Control.ControlCollection controles)

        {
            foreach (Control control in controles)
            {
                // Verifica si el control es un TextBox
                if (control is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(control.Text))
                    {
                        MessageBox.Show("El campo " + control.Name + " no puede estar vacío.",
                                        "Validación",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                        control.Focus();
                        return false;
                    }
                }


                if (control.HasChildren)
                {
                    if (!ValidarCamposVacios(control.Controls))
                    {
                        return false;
                    }
                }

            }

            return true;

        }
        private void CargarGeneros()
        {
            ClsGenero genero = new ClsGenero();

            DataTable dt = genero.CargarGeneros();

            DataRow fila = dt.NewRow();

            fila["IdGenero"] = 0;
            fila["Tipo"] = "Seleccione un género";

            dt.Rows.InsertAt(fila, 0);

            cmbGenero.DataSource = dt;

            cmbGenero.DisplayMember = "Tipo";
            cmbGenero.ValueMember = "IdGenero";


            cmbGenero.SelectedIndex = 0;
        }
        private void CargarProvincias()
        {

            ClsProvincia provincia = new ClsProvincia();

            DataTable dt = provincia.CargarProvincias();

            DataRow fila = dt.NewRow();

            fila["idProvincia"] = 0;
            fila["NomProvincia"] = "-Seleccione Provincia -";

            dt.Rows.InsertAt(fila, 0);

            cmbProvincia.DataSource = dt;
            cmbProvincia.DisplayMember = "NomProvincia";
            cmbProvincia.ValueMember = "IdProvincia";

            cmbProvincia.SelectedIndex = 0;
        }
        private void CargarUsuarios(int? idPersonaSeleccionado = null)
        {
            try
            {
                cargandoUsuarios = true;

                ClsUsuarioLogica usuario = new ClsUsuarioLogica();

                DataTable dt = usuario.ObtenerUsuarios();

                DataRow fila = dt.NewRow();
                fila["IdPersona"] = 0;
                fila["Username"] = "-Seleccione un Usuario-";

                dt.Rows.InsertAt(fila, 0);

                lstUsuarios.DataSource = null;
                lstUsuarios.DataSource = dt;
                lstUsuarios.DisplayMember = "Username";
                lstUsuarios.ValueMember = "IdPersona";

                if (idPersonaSeleccionado.HasValue)
                {
                    lstUsuarios.SelectedValue = idPersonaSeleccionado.Value;
                }
                else
                {
                    lstUsuarios.SelectedIndex = 0;
                }
            }
            finally
            {
                cargandoUsuarios = false;
            }
        }
        private void txt_KeyPress(object? sender, KeyPressEventArgs e)
        {
            ValidacionCampoVacio validacion = new ValidacionCampoVacio();

            if (sender is TextBox txt)
            {
                if (validacion.EsEspacioInicial(txt.Text, e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void txtCorreo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                return;
            }

            if (!ClsValidarCorreo.EsEmailValido(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                e.Cancel = true;
                txtCorreo.Focus();
            }
        }
        private void CargarDatosUsuario(int idPersona)
        {
            try
            {

                ClsUsuarioLogica logica = new ClsUsuarioLogica();
                ClsObtenerCorreoPersona traerCorreo = new ClsObtenerCorreoPersona();
                ClsObtenerTelefono traerTelefono = new ClsObtenerTelefono();
                ClsObtenerDomicilio traerDomicilio = new ClsObtenerDomicilio();
                ClsObtenerLocalidadPerson traerLocalidad = new ClsObtenerLocalidadPerson();
                ClsObtenerPartidoPer traerPartido = new ClsObtenerPartidoPer();
                ClsObtenerProvinciaPer traerProvincia = new ClsObtenerProvinciaPer();
                ClsPersona persona = logica.ObtenerPersonaPorId(idPersona);

                int idRol = logica.ObtenerIdRolPorPersona(idPersona);

                if (idRol > 0)
                {
                    CapaLogica.ClsRol rol = new CapaLogica.ClsRol();
                    txtRolActual.Text = rol.ObtenerNombreRol(idRol);
                }
                else
                {
                    txtRolActual.Clear();
                }

                if (persona == null)
                {
                    MessageBox.Show("No se encontraron los datos de la persona.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                ClsDomicilio domicilio = traerDomicilio.ObtenerDomicilioPorPersona(idPersona);

                string correoActual = traerCorreo.ObtenerCorreoPorPersona(idPersona);

                ClsTelefono telefonoActual = traerTelefono.ObtenerTelefonoPorPersona(idPersona);

                CapaEntidades.ClsLocalidad localidad = null;

                if (domicilio != null)
                {
                    localidad = traerLocalidad.ObtenerLocalidad(idPersona);
                }

                ClsTraerPartido partido = null;

                if (localidad != null)
                {
                    partido = traerPartido.ObtenerPartido(localidad.IdLocalidad);
                }

                ClsTraeProvincia provincia = null;

                if (partido != null)
                {
                    provincia = traerProvincia.ObtenerProvincia(partido.IdProvincia);
                }

                cargandoDatosUsuario = true;

                try
                {

                    txtNombre.Text = persona.Nombre ?? "";
                    txtApellido.Text = persona.Apellido ?? "";
                    txtDNI.Text = persona.DNI ?? "";
                    mkdCuil.Text = persona.CUIT ?? "";

                    chkActivo.Checked = persona.Activo;

                    if (persona.IdGenero > 0)
                    {
                        cmbGenero.SelectedValue = persona.IdGenero;
                    }
                    else
                    {
                        cmbGenero.SelectedIndex = 0;
                    }

                    rdbMasculino.Checked = persona.Sexo;
                    rdbFemenino.Checked = !persona.Sexo;

                    if (persona.FeNac != DateTime.MinValue &&
                        persona.FeNac >= dtpFechaNacimiento.MinDate &&
                        persona.FeNac <= dtpFechaNacimiento.MaxDate)
                    {
                        dtpFechaNacimiento.Value = persona.FeNac;
                    }
                    else
                    {
                        dtpFechaNacimiento.Value = DateTime.Today;
                    }

                    txtCorreo.Text = correoActual ?? "";

                    if (telefonoActual != null)
                    {
                        txtTelefono.Text = telefonoActual.NumTelefono ?? "";

                        if (telefonoActual.IdTipo > 0)
                        {
                            cmbTipoTelefono.SelectedValue =
                                telefonoActual.IdTipo;
                        }
                        else
                        {
                            cmbTipoTelefono.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        txtTelefono.Clear();
                        cmbTipoTelefono.SelectedIndex = -1;
                    }

                    if (domicilio != null)
                    {
                        txtCalle.Text = domicilio.Calle ?? "";
                        txtAltura.Text = domicilio.Altura.ToString();
                        txtPiso.Text = domicilio.Piso ?? "";
                        txtDepartamento.Text = domicilio.Departamento ?? "";
                    }
                    else
                    {
                        txtCalle.Clear();
                        txtAltura.Clear();
                        txtPiso.Clear();
                        txtDepartamento.Clear();
                    }

                    if (provincia != null)
                    {
                        cmbProvincia.SelectedValue = provincia.IdProvincia;

                        ClsPartido cargarPartidos = new ClsPartido();

                        DataTable dtPartidos = cargarPartidos.CargarPartidos(provincia.IdProvincia);

                        cmbPartido.DataSource = null;
                        cmbPartido.DataSource = dtPartidos;
                        cmbPartido.DisplayMember = "NomPartido";
                        cmbPartido.ValueMember = "IdPartido";

                        if (partido != null)
                        {
                            cmbPartido.SelectedValue = partido.IdPartido;

                            CapaLogica.ClsLocalidad cargarLocalidades = new CapaLogica.ClsLocalidad();

                            DataTable dtLocalidades = cargarLocalidades.CargarLocalidades(partido.IdPartido);

                            cmbLocalidad.DataSource = null;
                            cmbLocalidad.DataSource = dtLocalidades;
                            cmbLocalidad.DisplayMember = "NomLocalidad";
                            cmbLocalidad.ValueMember = "IdLocalidad";

                            if (localidad != null)
                            {
                                cmbLocalidad.SelectedValue = localidad.IdLocalidad;
                                txtPostal.Text = localidad.CodigoPostal ?? "";
                            }
                            else
                            {
                                cmbLocalidad.SelectedIndex = -1;
                                txtPostal.Clear();
                            }
                        }
                        else
                        {
                            cmbPartido.SelectedIndex = -1;
                            cmbLocalidad.DataSource = null;
                            txtPostal.Clear();
                        }
                    }
                    else
                    {
                        cmbProvincia.SelectedIndex = 0;
                        cmbPartido.DataSource = null;
                        cmbLocalidad.DataSource = null;
                        txtPostal.Clear();
                    }
                }
                finally
                {
                    cargandoDatosUsuario = false;
                }

                personaOriginal = new ClsPersona
                {
                    IdPersona = persona.IdPersona,
                    Activo = persona.Activo,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Sexo = persona.Sexo,
                    IdGenero = persona.IdGenero,
                    FeNac = persona.FeNac,
                    DNI = persona.DNI,
                    CUIT = persona.CUIT
                };

                domicilioOriginal = null;

                if (domicilio != null)
                {
                    domicilioOriginal = new ClsDomicilio
                    {
                        IdDireccion = domicilio.IdDireccion,
                        Calle = domicilio.Calle,
                        Altura = domicilio.Altura,
                        Piso = domicilio.Piso,
                        Departamento = domicilio.Departamento,
                        IdLocalidad = domicilio.IdLocalidad
                    };
                }

                correoOriginal = new ClsCorreo
                {
                    DireccionCorreo = correoActual ?? "",

                };

                telefonoOriginal = null;

                if (telefonoActual != null)
                {
                    telefonoOriginal = new ClsTelefono
                    {
                        IdTelefono = telefonoActual.IdTelefono,
                        NumTelefono = telefonoActual.NumTelefono,
                        IdTipo = telefonoActual.IdTipo
                    };
                }
            }
            catch (Exception ex)
            {
                cargandoDatosUsuario = false;

                MessageBox.Show("ERROR COMPLETO:\n\n" + ex.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool ModificarDatosUsuario(int idPersona, int idRol)
        {

            ClsPersona persona = new ClsPersona();

            persona.IdPersona = idPersona;
            persona.Activo = chkActivo.Checked;
            persona.Nombre = txtNombre.Text.Trim();
            persona.Apellido = txtApellido.Text.Trim();
            persona.DNI = txtDNI.Text.Trim();
            persona.CUIT = mkdCuil.Text.Trim();
            persona.IdGenero = Convert.ToInt32(cmbGenero.SelectedValue);
            persona.Sexo = rdbMasculino.Checked;
            persona.FeNac = dtpFechaNacimiento.Value;

            ClsModificarPersona modificarPersona = new ClsModificarPersona();

            if (!modificarPersona.ModificarPersona(persona, idRol))
            {
                MessageBox.Show("No se pudo modificar la información de la persona.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            ClsObtenerDomicilio traerDomicilio = new ClsObtenerDomicilio();
            ClsDomicilio domicilio = traerDomicilio.ObtenerDomicilioPorPersona(idPersona);

            if (domicilio == null)
            {
                MessageBox.Show("La persona no tiene un domicilio asociado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            domicilio.Calle = txtCalle.Text.Trim();
            domicilio.Altura = Convert.ToInt32(txtAltura.Text);
            domicilio.Piso = txtPiso.Text.Trim();
            domicilio.Departamento = txtDepartamento.Text.Trim();
            domicilio.IdLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);

            ClsModificarDomicilio modificarDomicilio = new ClsModificarDomicilio();

            if (!modificarDomicilio.ModificarDomicilio(domicilio))
            {
                MessageBox.Show("La persona se modificó, pero no el domicilio.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            ClsTelefonoLogica telefonoLogica = new ClsTelefonoLogica();

            int idTelefono = telefonoLogica.ObtenerIdTelefonoPorPersona(idPersona);

            if (idTelefono <= 0)
            {
                MessageBox.Show("La persona no tiene un teléfono asociado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            ClsTelefono telefono = new ClsTelefono();

            telefono.IdTelefono = idTelefono;
            telefono.NumTelefono = txtTelefono.Text.Trim();
            telefono.IdTipo = Convert.ToInt32(cmbTipoTelefono.SelectedValue);

            ClsModificarTelefono modificarTelefono = new ClsModificarTelefono();

            if (!modificarTelefono.ModificarTelefono(telefono))
            {
                MessageBox.Show("No se pudo modificar el teléfono.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;

        }
        private bool CambiarCorreoUsuario(int idPersona, int idRol)
        {
            string correoNuevo = txtCorreo.Text.Trim();

            if (correoOriginal != null && correoOriginal.DireccionCorreo.Trim().Equals(correoNuevo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(correoNuevo))
            {
                MessageBox.Show(
                    "El correo electrónico no puede estar vacío.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }

            if (!ClsValidarCorreo.EsEmailValido(correoNuevo))
            {
                MessageBox.Show(
                    "Ingrese un correo electrónico válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }

            ClsCorreoLogica correoLogica = new ClsCorreoLogica();

            bool resultado = correoLogica.CambiarCorreoPersona(idPersona, correoNuevo);

            if (!resultado)
            {
                MessageBox.Show(
                    "No se pudo actualizar el correo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
        private bool CargarDNIDesdeCUIL()
        {
            ClsValidarCUIL validarCUIL = new ClsValidarCUIL();

            string cuil = mkdCuil.Text.Trim();

            if (string.IsNullOrWhiteSpace(cuil))
            {
                return false;
            }

            if (!validarCUIL.CuilValido(cuil))
            {
                MessageBox.Show(
                    "El CUIL ingresado no es válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDNI.Clear();
                txtDNI.ReadOnly = false;

                return false;
            }

            string dni = validarCUIL.ObtenerDNI(cuil);

            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show(
                    "No se pudo obtener el DNI correspondiente al CUIL.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDNI.Clear();
                txtDNI.ReadOnly = false;

                return false;
            }

            txtDNI.Text = dni;
            txtDNI.ReadOnly = true;

            return true;
        }
        private void CargarTiposTelefono()
        {
            try
            {
                ClsTipoTelefonoLogica logica = new ClsTipoTelefonoLogica();

                cmbTipoTelefono.DataSource = null;
                cmbTipoTelefono.DataSource = logica.CargarTiposTelefono();

                cmbTipoTelefono.DisplayMember = "Tipo";
                cmbTipoTelefono.ValueMember = "IdTipo";

                cmbTipoTelefono.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los tipos de teléfono: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void HabilitarEdicion(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtDNI.Enabled = habilitar;
            mkdCuil.Enabled = habilitar;
            dtpFechaNacimiento.Enabled = habilitar;
            cmbGenero.Enabled = habilitar;
            rdbMasculino.Enabled = habilitar;
            rdbFemenino.Enabled = habilitar;

            txtCalle.Enabled = habilitar;
            txtAltura.Enabled = habilitar;
            txtPiso.Enabled = habilitar;
            txtDepartamento.Enabled = habilitar;

            cmbProvincia.Enabled = habilitar;
            cmbPartido.Enabled = habilitar;
            cmbLocalidad.Enabled = habilitar;

            txtPostal.Enabled = false;

            txtTelefono.Enabled = habilitar;
            cmbTipoTelefono.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;

            chkActivo.Enabled = habilitar;

            btnPermisos.Enabled = habilitar;
        }
        #endregion


        #region Eventos
        //Evento Formulario
        private void frmCargaEmpleados_Load(object sender, EventArgs e)
        {
            CargarGeneros();
            CargarProvincias();
            CargarTiposTelefono();

            cmbGenero.SelectedIndex = 0;

            chkActivo.Checked = true;

            DataTable dtPartidoInicial = new DataTable();
            dtPartidoInicial.Columns.Add("IdPartido", typeof(int));
            dtPartidoInicial.Columns.Add("NomPartido", typeof(string));

            dtPartidoInicial.Rows.Add(0, "-Seleccione Partido-");

            cmbPartido.DataSource = dtPartidoInicial;
            cmbPartido.DisplayMember = "NomPartido";
            cmbPartido.ValueMember = "IdPartido";
            cmbPartido.SelectedIndex = 0;

            DataTable dtLocalidadInicial = new DataTable();
            dtLocalidadInicial.Columns.Add("IdLocalidad", typeof(int));
            dtLocalidadInicial.Columns.Add("NomLocalidad", typeof(string));

            dtLocalidadInicial.Rows.Add(0, "-Seleccione Localidad-");

            cmbLocalidad.DataSource = dtLocalidadInicial;
            cmbLocalidad.DisplayMember = "NomLocalidad";
            cmbLocalidad.ValueMember = "IdLocalidad";
            cmbLocalidad.SelectedIndex = 0;

            txtPostal.Clear();

            CargarUsuarios();


        }
        //Evento Boton Crear
        private void btnCrear_Click(object sender, EventArgs e)
        {
            ClsValidarCUIL validarCUIL = new ClsValidarCUIL();

            if (!validarCUIL.CuilValido(mkdCuil.Text))
            {
                MessageBox.Show("El CUIL ingresado no es válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mkdCuil.Focus();
                return;
            }

            string dniDelCUIL = validarCUIL.ObtenerDNI(mkdCuil.Text);

            if (dniDelCUIL != txtDNI.Text.Trim())
            {
                MessageBox.Show("El DNI no corresponde al CUIL ingresado.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!ValidarCamposVacios(this.Controls))
            {
                return;
            }

            if (cmbTipoTelefono.SelectedValue == null || cmbTipoTelefono.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de teléfono.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbTipoTelefono.Focus();
                return;
            }

            try
            {
                frmPermisos permisos = new frmPermisos(true);
                permisos.ShowDialog();

                int idRol = permisos.IdRolSeleccionado;

                if (idRol <= 0)
                {
                    MessageBox.Show("Debe seleccionar un rol para el empleado.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (!permisos.TienePermisosSeleccionados)
                {
                    MessageBox.Show("Debe seleccionar al menos un permiso para el empleado.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                ClsAltaEmpleado emp = new ClsAltaEmpleado();

                bool ok = emp.CrearEmpleado(
                    txtNombre.Text,
                    txtApellido.Text,
                    dtpFechaNacimiento.Value,
                    txtDNI.Text,
                    mkdCuil.Text,
                    rdbMasculino.Checked,
                    Convert.ToInt32(cmbGenero.SelectedValue),
                    idRol,
                    txtCorreo.Text,
                    txtTelefono.Text,
                    Convert.ToInt32(cmbTipoTelefono.SelectedValue),
                    txtCalle.Text,
                    int.Parse(txtAltura.Text),
                    txtPiso.Text,
                    txtDepartamento.Text,
                    Convert.ToInt32(cmbLocalidad.SelectedValue),
                    chkActivo.Checked
                );

                if (ok)
                {
                    MessageBox.Show("Empleado creado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string detalle = ex.Message;

                if (ex.InnerException != null)
                {
                    detalle += "\n\nERROR INTERNO:\n" + ex.InnerException.Message;
                }

                MessageBox.Show("NO SE PUDO CREAR EL EMPLEADO\n\n" + "ERROR:\n" + detalle + "\n\nTIPO:\n" + ex.GetType().FullName +
                    "\n\nSTACK TRACE:\n" + ex.StackTrace, "Error al crear empleado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Evento DNI
        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (!ClsVerificarDNI.DniValido(txtDNI.Text))
            {
                MessageBox.Show("El DNI debe tener exactamente 8 números y no pueden ser todos iguales.");
                txtDNI.Focus();
                txtDNI.SelectAll();
            }
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionCampoVacio validacion = new ValidacionCampoVacio();

            if (validacion.EsEspacioInicial(txtDNI.Text, e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            txtDNI.MaxLength = 8;
        }
        //Evento CUIL
        private void mkdCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionCampoVacio validacion = new ValidacionCampoVacio();

            if (validacion.EsEspacioInicial(mkdCuil.Text, e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void mkdCuil_Enter(object sender, EventArgs e)
        {
            mkdCuil.MaxLength = 11;
            BeginInvoke(new Action(() =>
            {
                mkdCuil.SelectionStart = 0;
                mkdCuil.SelectionLength = 0;
            }));
        }
        private void mkdCuil_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mkdCuil.Text))
            {
                txtDNI.Clear();
                txtDNI.ReadOnly = false;
                return;
            }

            CargarDNIDesdeCUIL();
        }
        //Evento Telefono
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ClsValidarNumeros.SoloNumeros(e.KeyChar))
            {
                e.Handled = true;
            }

            txtTelefono.MaxLength = 10;
        }
        //Evento Partido
        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatosUsuario)
            {
                return;
            }


            if (cmbPartido.SelectedIndex == -1)
            {
                return;
            }


            if (cmbPartido.SelectedValue is DataRowView)
            {
                return;
            }


            if (!int.TryParse(cmbPartido.SelectedValue.ToString(), out int idPartido))
            {
                return;
            }


            CapaLogica.ClsLocalidad localidad = new CapaLogica.ClsLocalidad();

            cmbLocalidad.DataSource = localidad.CargarLocalidades(idPartido);
            cmbLocalidad.DisplayMember = "NomLocalidad";
            cmbLocalidad.ValueMember = "IdLocalidad";



        }
        //Evento Provincia
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatosUsuario)
            {
                return;
            }

            if (cmbProvincia.SelectedValue == null)
            {
                return;
            }


            if (cmbProvincia.SelectedValue is DataRowView)
            {
                return;
            }


            if (int.TryParse(cmbProvincia.SelectedValue.ToString(), out int idProvincia))
            {
                ClsPartido partido = new ClsPartido();

                cmbPartido.DataSource = partido.CargarPartidos(idProvincia);

                cmbPartido.DisplayMember = "NomPartido";

                cmbPartido.ValueMember = "IdPartido";
            }
        }
        //Evento localidad
        private void cmbLocalidad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cargandoDatosUsuario)
            {
                return;
            }


            if (cmbLocalidad.SelectedIndex == -1)
            {
                txtPostal.Clear();
                return;
            }

            if (cmbLocalidad.SelectedItem is DataRowView fila)
            {
                if (fila.Row.Table.Columns.Contains("CodigoPostal"))
                {
                    txtPostal.Text = fila["CodigoPostal"]?.ToString() ?? "";
                }
                else
                {
                    txtPostal.Clear();
                }
            }
        }
        //Evento lista buscar usuario
        private void lstUsuarios_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cargandoUsuarios)
                return;

            if (lstUsuarios.SelectedValue == null)
                return;

            if (lstUsuarios.SelectedValue is DataRowView)
                return;

            int idPersona = Convert.ToInt32(lstUsuarios.SelectedValue);

            if (idPersona <= 0)
                return;

            CargarDatosUsuario(idPersona);

            chkHabilitarEdicion.Checked = false;
            HabilitarEdicion(false);
        }
        // evento para limpiar
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            VaciarFormularios.LimpiarControles(this);
            txtRolActual.Clear();

            chkHabilitarEdicion.Checked = false;
            HabilitarEdicion(true);

            txtDNI.ReadOnly = false;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstUsuarios.SelectedValue == null || !int.TryParse(lstUsuarios.SelectedValue.ToString(), out int idPersonaSeleccionada))
                {
                    MessageBox.Show("Seleccione un usuario para modificar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                int idPersona = idPersonaSeleccionada;

                if (cmbGenero.SelectedValue == null || !int.TryParse(cmbGenero.SelectedValue.ToString(), out int idGenero) || idGenero <= 0)
                {
                    MessageBox.Show("Seleccione un género.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbGenero.Focus();
                    return;
                }

                if (cmbLocalidad.SelectedValue == null || !int.TryParse(cmbLocalidad.SelectedValue.ToString(), out int idLocalidad) || idLocalidad <= 0)
                {
                    MessageBox.Show("Seleccione una localidad.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbLocalidad.Focus();
                    return;
                }

                if (cmbTipoTelefono.SelectedValue == null || !int.TryParse(cmbTipoTelefono.SelectedValue.ToString(), out int idTipoTelefono) || idTipoTelefono <= 0)
                {
                    MessageBox.Show("Seleccione un tipo de teléfono.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbTipoTelefono.Focus();
                    return;
                }

                if (personaOriginal == null || domicilioOriginal == null || correoOriginal == null)
                {
                    MessageBox.Show("No se pudieron cargar correctamente los datos originales del usuario.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                ClsValidarCUIL validarCUIL = new ClsValidarCUIL();

                string cuil = mkdCuil.Text.Trim();

                if (!validarCUIL.CuilValido(cuil))
                {
                    MessageBox.Show("El CUIL ingresado no es válido.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    mkdCuil.Focus();
                    return;
                }

                string dniDelCUIL = validarCUIL.ObtenerDNI(cuil);

                if (dniDelCUIL != txtDNI.Text.Trim())
                {
                    MessageBox.Show("El DNI no corresponde al CUIL ingresado.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    mkdCuil.Focus();
                    return;
                }

                ClsUsuarioLogica logica = new ClsUsuarioLogica();

                bool existe = logica.ExistePersonaDatos(txtDNI.Text.Trim(), cuil, idPersona);

                if (existe)
                {
                    MessageBox.Show("Ya existe otra persona registrada con ese DNI o CUIL.", "Datos duplicados",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                bool huboCambios =
                    personaOriginal.Nombre != txtNombre.Text.Trim() ||
                    personaOriginal.Apellido != txtApellido.Text.Trim() ||
                    personaOriginal.DNI != txtDNI.Text.Trim() ||
                    personaOriginal.CUIT != cuil ||
                    personaOriginal.Activo != chkActivo.Checked ||
                    personaOriginal.IdGenero != idGenero ||
                    personaOriginal.Sexo != rdbMasculino.Checked ||
                    personaOriginal.FeNac.Date != dtpFechaNacimiento.Value.Date ||
                    domicilioOriginal.Calle != txtCalle.Text.Trim() ||
                    domicilioOriginal.Altura != Convert.ToInt32(txtAltura.Text) ||
                    domicilioOriginal.Piso != txtPiso.Text.Trim() ||
                    domicilioOriginal.Departamento != txtDepartamento.Text.Trim() ||
                    domicilioOriginal.IdLocalidad != idLocalidad ||
                    !correoOriginal.DireccionCorreo.Trim().Equals(txtCorreo.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase);

                if (telefonoOriginal != null)
                {
                    huboCambios = huboCambios || telefonoOriginal.NumTelefono != txtTelefono.Text.Trim() || telefonoOriginal.IdTipo != idTipoTelefono;
                }

                huboCambios = huboCambios || permisosModificados;

                bool estadoAnterior = personaOriginal.Activo;
                bool estadoNuevo = chkActivo.Checked;


                if (!huboCambios)
                {
                    MessageBox.Show("No realizó ningún cambio. Modifique algún dato antes de guardar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                int idRol;

                if (permisosModificados)
                {
                    idRol = idRolSeleccionado;
                }
                else
                {
                    idRol = logica.ObtenerIdRolPorPersona(idPersona);
                }

                if (idRol <= 0)
                {
                    MessageBox.Show("No se pudo determinar el rol del empleado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (!CambiarCorreoUsuario(idPersona, idRol))
                {
                    return;
                }

                bool resultado = ModificarDatosUsuario(idPersona, idRol);

                if (!resultado)
                {
                    return;
                }
                string accionBitacora;

                if (estadoAnterior && !estadoNuevo)
                {
                    accionBitacora = "BAJA";
                }
                else if (!estadoAnterior && estadoNuevo)
                {
                    accionBitacora = "REACTIVAR";
                }
                else
                {
                    accionBitacora = "MODIFICAR";
                }

                ClsUsuarioLogica logicaUsuario = new ClsUsuarioLogica();

                DataRowView filaSeleccionada = lstUsuarios.SelectedItem as DataRowView;

                if (filaSeleccionada == null)
                {
                    throw new Exception("No se pudo identificar el usuario seleccionado.");
                }

                string usernameAfectado = filaSeleccionada["Username"].ToString();

                int idUsuarioAfectado = logicaUsuario.ObtenerIdUsuario(usernameAfectado);

                if (idUsuarioAfectado <= 0)
                {
                    throw new Exception("No se pudo obtener el ID del usuario afectado.");
                }

                clsBitacoraLogica bitacora = new clsBitacoraLogica();

                string descripcionBitacora;

                if (accionBitacora == "BAJA")
                {
                    descripcionBitacora = "Baja lógica del usuario: " + usernameAfectado;
                }
                else if (accionBitacora == "REACTIVAR")
                {
                    descripcionBitacora = "Reactivación del usuario: " + usernameAfectado;
                }
                else
                {
                    descripcionBitacora = "Modificación de datos del usuario: " + usernameAfectado;
                }

                bitacora.RegistrarBitacora(SesionUsuario.IdUsuario > 0 ? SesionUsuario.IdUsuario : (int?)null, accionBitacora,
                    "Usuario", idUsuarioAfectado, descripcionBitacora);

                MessageBox.Show(permisosModificados ? "Los cambios se guardaron correctamente." : "Los datos se modificaron correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                permisosModificados = false;
                idRolSeleccionado = 0;

                CargarUsuarios(idPersona);
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique que la altura sea un número válido.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
        private void btnPermisos_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDNI.Text) || lstUsuarios.SelectedValue == null || lstUsuarios.SelectedValue is DataRowView || Convert.ToInt32(lstUsuarios.SelectedValue) <= 0)
            {
                using (frmPermisos permiso = new frmPermisos(true))
                {
                    permiso.ShowDialog();

                    if (permiso.IdRolSeleccionado > 0)
                    {
                        idRolSeleccionado = permiso.IdRolSeleccionado;
                        permisosModificados = permiso.PermisosModificados;
                        txtRolActual.Text = permiso.IdRolSeleccionado.ToString();
                    }
                }

                return;
            }

            int idPersona = Convert.ToInt32(lstUsuarios.SelectedValue);

            ClsUsuarioLogica usuario = new ClsUsuarioLogica();
            int idRol = usuario.ObtenerIdRolPorPersona(idPersona);

            if (idRol <= 0)
            {
                MessageBox.Show("El empleado no tiene un rol asignado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmPermisos permiso = new frmPermisos(idRol))
            {
                permiso.ShowDialog();

                permisosModificados = permiso.PermisosModificados;
                idRolSeleccionado = permiso.IdRolSeleccionado;
            }
        }
        private void chkHabilitarEdicion_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarEdicion(chkHabilitarEdicion.Checked);
        }

        #endregion














    }
}
