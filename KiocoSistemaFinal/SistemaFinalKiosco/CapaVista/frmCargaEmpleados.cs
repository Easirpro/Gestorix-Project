using CapaEntidades;
using CapaLogica;
using CapaVista;
using System.ComponentModel;
using System.Data;
using static CapaLogica.ClsValidarNumero;
using CapaLogica.BitacoraLogi;
using CapaSesion;


namespace CapaVista
{
    public partial class frmCargaEmpleados : Form
    {
        private ClsPersona personaOriginal;
        private ClsDomicilio domicilioOriginal;
        private ClsCorreo correoOriginal;
        private ClsTelefono telefonoOriginal;
        private int idRolOriginal;
        private bool cargandoDatosUsuario = false;
        private bool cargandoUsuarios = false;
        private bool modoNuevo = false;

        public frmCargaEmpleados()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);
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
        private string NombreCampo(Control control)
        {
            if (control == txtNombre) return ClsIdioma.T("Nombre");
            if (control == txtApellido) return ClsIdioma.T("Apellido");
            if (control == txtDNI) return ClsIdioma.T("DNI");
            if (control == txtCalle) return ClsIdioma.T("Calle");
            if (control == txtAltura) return ClsIdioma.T("Altura");
            if (control == txtPostal) return ClsIdioma.T("Código Postal");
            if (control == txtTelefono) return ClsIdioma.T("Teléfono");
            if (control == txtCorreo) return ClsIdioma.T("Correo Electrónico");

            return control.Name;
        }
        private void MostrarControl(Control control)
        {
            Control? padre = control.Parent;

            while (padre != null && padre is not TabPage)
            {
                padre = padre.Parent;
            }

            if (padre is TabPage pestania)
            {
                tpgDatosUsuario.SelectedTab = pestania;
            }

            control.Focus();
        }
        private bool ValidarCamposVacios(Control.ControlCollection controles)

        {
            foreach (Control control in controles)
            {
                if (control is TextBox && control != txtPiso && control != txtDepartamento)
                {
                    if (string.IsNullOrWhiteSpace(control.Text))
                    {
                        bool esPostal = control == txtPostal;

                        string mensaje = esPostal
                            ? ClsIdioma.T("Seleccione provincia, partido y localidad para completar el Código Postal.")
                            : ClsIdioma.T("El campo ") + NombreCampo(control) + ClsIdioma.T(" no puede estar vacío.");

                        MessageBox.Show(mensaje,
                                        ClsIdioma.T("Validación"),
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                        MostrarControl(esPostal ? cmbLocalidad : control);
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
            fila["Tipo"] = ClsIdioma.T("Seleccione un género");

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
            fila["NomProvincia"] = ClsIdioma.T("-Seleccione Provincia -");

            dt.Rows.InsertAt(fila, 0);

            cmbProvincia.DataSource = dt;
            cmbProvincia.DisplayMember = "NomProvincia";
            cmbProvincia.ValueMember = "IdProvincia";

            cmbProvincia.SelectedIndex = 0;
        }
        private void CargarRoles()
        {
            int idRolActual = RolSeleccionado();

            CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

            DataTable dt = rol.ObtenerRoles();

            DataRow fila = dt.NewRow();
            fila["IdRol"] = 0;
            fila["Nombre"] = ClsIdioma.T("-Seleccione un rol-");

            dt.Rows.InsertAt(fila, 0);

            cmbRol.DataSource = null;
            cmbRol.DataSource = dt;
            cmbRol.DisplayMember = "Nombre";
            ClsIdioma.TraducirDatosAlMostrar(cmbRol);
            cmbRol.ValueMember = "IdRol";

            SeleccionarRol(idRolActual);
        }
        private int RolSeleccionado()
        {
            if (cmbRol.SelectedValue == null || cmbRol.SelectedValue is DataRowView)
            {
                return 0;
            }

            return Convert.ToInt32(cmbRol.SelectedValue);
        }
        private void SeleccionarRol(int idRol)
        {
            if (cmbRol.Items.Count == 0)
            {
                return;
            }

            cmbRol.SelectedValue = idRol;

            if (cmbRol.SelectedIndex == -1)
            {
                cmbRol.SelectedIndex = 0;
            }
        }
        private bool PuedeCambiarRol
        {
            get { return SesionUsuario.Permisos.Contains(1270); }
        }
        private bool EsUnoMismo
        {
            get { return !modoNuevo && personaOriginal != null && personaOriginal.IdPersona == SesionUsuario.IdPersona; }
        }
        private void ActualizarBotones()
        {
            bool puedeCrear = SesionUsuario.Permisos.Contains(1000) || SesionUsuario.Permisos.Contains(1010);
            bool puedeModificar = SesionUsuario.Permisos.Contains(1000) || SesionUsuario.Permisos.Contains(1020);
            bool haySeleccionado = !modoNuevo && personaOriginal != null;

            btnNuevo.Enabled = puedeCrear;
            btnCrear.Enabled = puedeCrear;
            btnModificar.Enabled = puedeModificar;
            chkHabilitarEdicion.Enabled = !modoNuevo && haySeleccionado;
            btnPermisos.Enabled = PuedeCambiarRol && (modoNuevo || haySeleccionado);
        }
        private void LimpiarFormulario()
        {
            VaciarFormularios.LimpiarControles(this);

            personaOriginal = null;
            domicilioOriginal = null;
            correoOriginal = null;
            telefonoOriginal = null;
            idRolOriginal = 0;

            SeleccionarRol(0);

            if (cmbGenero.Items.Count > 0)
            {
                cmbGenero.SelectedIndex = 0;
            }

            txtDNI.ReadOnly = false;

            cargandoUsuarios = true;

            try
            {
                if (lstUsuarios.Items.Count > 0)
                {
                    lstUsuarios.SelectedIndex = 0;
                }
            }
            finally
            {
                cargandoUsuarios = false;
            }
        }
        private string CuilIngresado()
        {
            ClsValidarCUIL validarCUIL = new ClsValidarCUIL();

            return validarCUIL.CuilVacio(mkdCuil.Text) ? string.Empty : mkdCuil.Text.Trim();
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
                fila["Username"] = ClsIdioma.T("-Seleccione un Usuario-");

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
                MessageBox.Show(ClsIdioma.T("Ingrese un correo electrónico válido."),
                                ClsIdioma.T("Validación"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                e.Cancel = true;
                MostrarControl(txtCorreo);
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

                idRolOriginal = idRol;
                SeleccionarRol(idRol);

                if (persona == null)
                {
                    MessageBox.Show(ClsIdioma.T("No se encontraron los datos de la persona."), ClsIdioma.T("Aviso"),
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

                MessageBox.Show(ClsIdioma.T("ERROR COMPLETO:\n\n") + ex.ToString(), ClsIdioma.T("Error"),
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
            persona.CUIT = CuilIngresado();
            persona.IdGenero = Convert.ToInt32(cmbGenero.SelectedValue);
            persona.Sexo = rdbMasculino.Checked;
            persona.FeNac = dtpFechaNacimiento.Value;

            ClsModificarPersona modificarPersona = new ClsModificarPersona();

            if (!modificarPersona.ModificarPersona(persona, idRol))
            {
                MessageBox.Show(ClsIdioma.T("No se pudo modificar la información de la persona."), ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            ClsObtenerDomicilio traerDomicilio = new ClsObtenerDomicilio();
            ClsDomicilio domicilio = traerDomicilio.ObtenerDomicilioPorPersona(idPersona);

            if (domicilio == null)
            {
                MessageBox.Show(ClsIdioma.T("La persona no tiene un domicilio asociado."), ClsIdioma.T("Aviso"),
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
                MessageBox.Show(ClsIdioma.T("La persona se modificó, pero no el domicilio."), ClsIdioma.T("Aviso"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            ClsTelefonoLogica telefonoLogica = new ClsTelefonoLogica();

            int idTelefono = telefonoLogica.ObtenerIdTelefonoPorPersona(idPersona);

            if (idTelefono <= 0)
            {
                MessageBox.Show(ClsIdioma.T("La persona no tiene un teléfono asociado."), ClsIdioma.T("Aviso"),
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
                MessageBox.Show(ClsIdioma.T("No se pudo modificar el teléfono."), ClsIdioma.T("Aviso"),
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
                    ClsIdioma.T("El correo electrónico no puede estar vacío."),
                    ClsIdioma.T("Validación"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                MostrarControl(txtCorreo);

                return false;
            }

            if (!ClsValidarCorreo.EsEmailValido(correoNuevo))
            {
                MessageBox.Show(
                    ClsIdioma.T("Ingrese un correo electrónico válido."),
                    ClsIdioma.T("Validación"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                MostrarControl(txtCorreo);

                return false;
            }

            ClsCorreoLogica correoLogica = new ClsCorreoLogica();

            bool resultado = correoLogica.CambiarCorreoPersona(idPersona, correoNuevo);

            if (!resultado)
            {
                MessageBox.Show(
                    ClsIdioma.T("No se pudo actualizar el correo."),
                    ClsIdioma.T("Error"),
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

            if (validarCUIL.CuilVacio(cuil))
            {
                return false;
            }

            string motivo = validarCUIL.MotivoCuilInvalido(cuil);

            if (motivo != string.Empty)
            {
                MessageBox.Show(
                    motivo,
                    ClsIdioma.T("Validación"),
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
                    ClsIdioma.T("No se pudo obtener el DNI correspondiente al CUIL."),
                    ClsIdioma.T("Validación"),
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
                    ClsIdioma.T("Error al cargar los tipos de teléfono: ") + ex.Message,
                    ClsIdioma.T("Error"),
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

            chkActivo.Enabled = habilitar && !EsUnoMismo;
            cmbRol.Enabled = habilitar && PuedeCambiarRol && !EsUnoMismo;
        }
        #endregion


        #region Eventos
        // Evento Formulario
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

            dtPartidoInicial.Rows.Add(0, ClsIdioma.T("-Seleccione Partido-"));

            cmbPartido.DataSource = dtPartidoInicial;
            cmbPartido.DisplayMember = "NomPartido";
            cmbPartido.ValueMember = "IdPartido";
            cmbPartido.SelectedIndex = 0;

            DataTable dtLocalidadInicial = new DataTable();
            dtLocalidadInicial.Columns.Add("IdLocalidad", typeof(int));
            dtLocalidadInicial.Columns.Add("NomLocalidad", typeof(string));

            dtLocalidadInicial.Rows.Add(0, ClsIdioma.T("-Seleccione Localidad-"));

            cmbLocalidad.DataSource = dtLocalidadInicial;
            cmbLocalidad.DisplayMember = "NomLocalidad";
            cmbLocalidad.ValueMember = "IdLocalidad";
            cmbLocalidad.SelectedIndex = 0;

            txtPostal.Clear();

            CargarRoles();
            CargarUsuarios();

            HabilitarEdicion(false);
            ActualizarBotones();
        }
        // Evento Boton Crear
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!modoNuevo)
            {
                MessageBox.Show(personaOriginal != null
                        ? ClsIdioma.T("Este botón es para crear empleados nuevos.\n\nPara guardar cambios del empleado elegido, tildá «Habilitar Edición», cambiá los datos y tocá GUARDAR CAMBIOS.\nPara crear uno nuevo, tocá NUEVO primero.")
                        : ClsIdioma.T("Para crear un empleado, tocá NUEVO primero y completá sus datos."),
                    ClsIdioma.T("Crear empleado"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClsValidarCUIL validarCUIL = new ClsValidarCUIL();

            string motivoCuil = validarCUIL.MotivoCuilInvalido(mkdCuil.Text);

            if (motivoCuil != string.Empty)
            {
                MessageBox.Show(motivoCuil, ClsIdioma.T("Validación"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                MostrarControl(mkdCuil);
                return;
            }

            string dniDelCUIL = validarCUIL.ObtenerDNI(mkdCuil.Text);

            if (dniDelCUIL != txtDNI.Text.Trim())
            {
                MessageBox.Show(ClsIdioma.T("El DNI no corresponde al CUIL ingresado."), ClsIdioma.T("Validación"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            int idRol = RolSeleccionado();

            if (idRol <= 0)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione el rol del empleado."), ClsIdioma.T("Validación"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbRol.Focus();
                return;
            }

            if (!ValidarCamposVacios(this.Controls))
            {
                return;
            }

            if (cmbTipoTelefono.SelectedValue == null || cmbTipoTelefono.SelectedIndex == -1)
            {
                MessageBox.Show(ClsIdioma.T("Seleccione un tipo de teléfono."), ClsIdioma.T("Validación"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                MostrarControl(cmbTipoTelefono);
                return;
            }

            try
            {
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
                    if (emp.UsuarioSinCorreo != null)
                    {
                        MessageBox.Show(ClsIdioma.T("El empleado se creó, pero no se pudo enviar el correo con la contraseña temporal.\n\n") +
                            ClsIdioma.T("Entréguele estos datos al empleado:\n\n") +
                            ClsIdioma.T("Usuario: ") + emp.UsuarioSinCorreo + "\n" +
                            ClsIdioma.T("Contraseña temporal: ") + emp.PasswordTemporalSinCorreo + "\n\n" +
                            ClsIdioma.T("Deberá cambiarla en el primer inicio de sesión."), ClsIdioma.T("Empleado creado"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(ClsIdioma.T("Empleado creado correctamente."), ClsIdioma.T("Éxito"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    modoNuevo = false;
                    CargarUsuarios();
                    LimpiarFormulario();
                    chkHabilitarEdicion.Checked = false;
                    HabilitarEdicion(false);
                    ActualizarBotones();
                }
            }
            catch (Exception ex)
            {
                string detalle = ex.Message;

                if (ex.InnerException != null)
                {
                    detalle += ClsIdioma.T("\n\nERROR INTERNO:\n") + ex.InnerException.Message;
                }

                MessageBox.Show(ClsIdioma.T("NO SE PUDO CREAR EL EMPLEADO\n\n") + ClsIdioma.T("ERROR:\n") + detalle + ClsIdioma.T("\n\nTIPO:\n") + ex.GetType().FullName +
                    ClsIdioma.T("\n\nSTACK TRACE:\n") + ex.StackTrace, ClsIdioma.T("Error al crear empleado"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Evento DNI
        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (!ClsVerificarDNI.DniValido(txtDNI.Text))
            {
                MessageBox.Show(ClsIdioma.T("El DNI debe tener exactamente 8 números y no pueden ser todos iguales."));
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
        // Evento CUIL
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
            if (new ClsValidarCUIL().CuilVacio(mkdCuil.Text))
            {
                txtDNI.Clear();
                txtDNI.ReadOnly = false;
                return;
            }

            if (!modoNuevo && personaOriginal != null && CuilIngresado() == (personaOriginal.CUIT ?? "").Trim())
            {
                return;
            }

            CargarDNIDesdeCUIL();
        }
        // Evento Telefono
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ClsValidarNumeros.SoloNumeros(e.KeyChar))
            {
                e.Handled = true;
            }

            txtTelefono.MaxLength = 10;
        }
        // Evento Partido
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
        // Evento Provincia
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
        // Evento localidad
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
        // Evento lista buscar usuario
        private void lstUsuarios_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cargandoUsuarios)
                return;

            if (lstUsuarios.SelectedValue == null)
                return;

            if (lstUsuarios.SelectedValue is DataRowView)
                return;

            int idPersona = Convert.ToInt32(lstUsuarios.SelectedValue);

            modoNuevo = false;

            if (idPersona <= 0)
            {
                LimpiarFormulario();
                chkHabilitarEdicion.Checked = false;
                HabilitarEdicion(false);
                ActualizarBotones();
                return;
            }

            CargarDatosUsuario(idPersona);

            chkHabilitarEdicion.Checked = false;
            HabilitarEdicion(false);
            ActualizarBotones();
        }
        // evento para limpiar
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoNuevo = true;

            LimpiarFormulario();

            chkHabilitarEdicion.Checked = true;
            chkActivo.Checked = true;
            HabilitarEdicion(true);
            ActualizarBotones();

            txtNombre.Focus();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (modoNuevo)
            {
                MessageBox.Show(ClsIdioma.T("Estás cargando un empleado nuevo: para guardarlo tocá CREAR EMPLEADO."), ClsIdioma.T("Guardar cambios"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (personaOriginal == null)
            {
                MessageBox.Show(ClsIdioma.T("Elegí un empleado de la lista «Usuarios» para modificar sus datos."), ClsIdioma.T("Guardar cambios"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstUsuarios.Focus();
                return;
            }

            if (!chkHabilitarEdicion.Checked)
            {
                MessageBox.Show(ClsIdioma.T("Para modificar al empleado, tildá «Habilitar Edición», cambiá los datos y después tocá GUARDAR CAMBIOS.\n\n") +
                    ClsIdioma.T("Los permisos no se guardan acá: se guardan desde «Permisos del rol»."), ClsIdioma.T("Guardar cambios"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkHabilitarEdicion.Focus();
                return;
            }

            try
            {
                if (lstUsuarios.SelectedValue == null || !int.TryParse(lstUsuarios.SelectedValue.ToString(), out int idPersonaSeleccionada))
                {
                    MessageBox.Show(ClsIdioma.T("Seleccione un usuario para modificar."), ClsIdioma.T("Aviso"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                int idPersona = idPersonaSeleccionada;

                if (cmbGenero.SelectedValue == null || !int.TryParse(cmbGenero.SelectedValue.ToString(), out int idGenero) || idGenero <= 0)
                {
                    MessageBox.Show(ClsIdioma.T("Seleccione un género."), ClsIdioma.T("Validación"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    MostrarControl(cmbGenero);
                    return;
                }

                if (cmbLocalidad.SelectedValue == null || !int.TryParse(cmbLocalidad.SelectedValue.ToString(), out int idLocalidad) || idLocalidad <= 0)
                {
                    MessageBox.Show(ClsIdioma.T("Seleccione una localidad."), ClsIdioma.T("Validación"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    MostrarControl(cmbLocalidad);
                    return;
                }

                if (cmbTipoTelefono.SelectedValue == null || !int.TryParse(cmbTipoTelefono.SelectedValue.ToString(), out int idTipoTelefono) || idTipoTelefono <= 0)
                {
                    MessageBox.Show(ClsIdioma.T("Seleccione un tipo de teléfono."), ClsIdioma.T("Validación"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    MostrarControl(cmbTipoTelefono);
                    return;
                }

                if (personaOriginal == null || domicilioOriginal == null || correoOriginal == null)
                {
                    MessageBox.Show(ClsIdioma.T("No se pudieron cargar correctamente los datos originales del usuario."),
                        ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                ClsValidarCUIL validarCUIL = new ClsValidarCUIL();

                string cuil = CuilIngresado();

                bool cuilCambio = cuil != (personaOriginal.CUIT ?? "").Trim();
                bool dniCambio = txtDNI.Text.Trim() != (personaOriginal.DNI ?? "").Trim();

                if (cuilCambio || dniCambio)
                {
                    string motivoCuil = validarCUIL.MotivoCuilInvalido(cuil);

                    if (motivoCuil != string.Empty)
                    {
                        MessageBox.Show(motivoCuil, ClsIdioma.T("Validación"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        MostrarControl(mkdCuil);
                        return;
                    }

                    string dniDelCUIL = validarCUIL.ObtenerDNI(cuil);

                    if (dniDelCUIL != txtDNI.Text.Trim())
                    {
                        MessageBox.Show(ClsIdioma.T("El DNI no corresponde al CUIL ingresado."), ClsIdioma.T("Validación"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        MostrarControl(mkdCuil);
                        return;
                    }
                }

                int idRol = PuedeCambiarRol ? RolSeleccionado() : idRolOriginal;

                if (idRol <= 0)
                {
                    MessageBox.Show(ClsIdioma.T("Seleccione el rol del empleado."), ClsIdioma.T("Validación"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbRol.Focus();
                    return;
                }

                bool rolCambio = idRol != idRolOriginal;

                ClsUsuarioLogica logica = new ClsUsuarioLogica();

                bool existe = logica.ExistePersonaDatos(txtDNI.Text.Trim(), cuil, idPersona);

                if (existe)
                {
                    MessageBox.Show(ClsIdioma.T("Ya existe otra persona registrada con ese DNI o CUIL."), ClsIdioma.T("Datos duplicados"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                bool huboCambios =
                    personaOriginal.Nombre != txtNombre.Text.Trim() ||
                    personaOriginal.Apellido != txtApellido.Text.Trim() ||
                    dniCambio ||
                    cuilCambio ||
                    rolCambio ||
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

                bool estadoAnterior = personaOriginal.Activo;
                bool estadoNuevo = chkActivo.Checked;


                if (!huboCambios)
                {
                    MessageBox.Show(ClsIdioma.T("No hay cambios en los datos del empleado.\n\n") +
                        ClsIdioma.T("Si cambiaste permisos, no hace falta guardar acá: los permisos se guardan desde «Permisos del rol» ") +
                        ClsIdioma.T("y ya quedaron guardados ahí."), ClsIdioma.T("Sin cambios"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                string motivoRol = logica.ValidarCambioRolYEstado(idPersona, idRol, estadoNuevo);

                if (motivoRol != string.Empty)
                {
                    MessageBox.Show(motivoRol, ClsIdioma.T("Cambio no permitido"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                    throw new Exception(ClsIdioma.T("No se pudo identificar el usuario seleccionado."));
                }

                string usernameAfectado = filaSeleccionada["Username"].ToString();

                int idUsuarioAfectado = logicaUsuario.ObtenerIdUsuario(usernameAfectado);

                if (idUsuarioAfectado <= 0)
                {
                    throw new Exception(ClsIdioma.T("No se pudo obtener el ID del usuario afectado."));
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

                if (rolCambio)
                {
                    CapaLogica.ClsRol rol = new CapaLogica.ClsRol();

                    bitacora.RegistrarBitacora(SesionUsuario.IdUsuario > 0 ? SesionUsuario.IdUsuario : (int?)null, "CAMBIO_ROL",
                        "Usuario", idUsuarioAfectado, "Cambio de rol del usuario " + usernameAfectado + ": " +
                        rol.ObtenerNombreRol(idRolOriginal) + " → " + rol.ObtenerNombreRol(idRol));
                }

                MessageBox.Show(ClsIdioma.T("Los datos se modificaron correctamente."),
                    ClsIdioma.T("Éxito"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios(idPersona);
                CargarDatosUsuario(idPersona);

                chkHabilitarEdicion.Checked = false;
                HabilitarEdicion(false);
                ActualizarBotones();
            }
            catch (FormatException)
            {
                MessageBox.Show(ClsIdioma.T("Verifique que la altura sea un número válido."), ClsIdioma.T("Datos incorrectos"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
        private void btnPermisos_Click(object sender, EventArgs e)
        {
            int idRol = RolSeleccionado();

            using (frmPermisos permiso = idRol > 0 ? new frmPermisos(idRol, soloEseRol: true) : new frmPermisos())
            {
                permiso.Icon = Icon;
                permiso.ShowDialog(this);
            }

            CargarRoles();
        }
        private void chkHabilitarEdicion_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarEdicion(chkHabilitarEdicion.Checked);
        }
        private void btnVolver_Click(object? sender, EventArgs e)
        {
            if (modoNuevo || chkHabilitarEdicion.Checked)
            {
                DialogResult respuesta = MessageBox.Show(
                    modoNuevo
                        ? ClsIdioma.T("Estás cargando un empleado nuevo y todavía no lo creaste.\n\n¿Salir sin guardar?")
                        : ClsIdioma.T("La edición del empleado está habilitada. Si cambiaste datos y no tocaste GUARDAR CAMBIOS, se pierden.\n\n¿Salir igual?"),
                    ClsIdioma.T("Volver"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }
            }

            Close();
        }

        #endregion














    }
}
