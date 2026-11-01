using CapaLogica;
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
using static CapaEntidades.NegocioEntidad.ClsGestorEntidadProducto;


namespace CapaVista
{

    public partial class frmNuevoProveedor : Form
    {
        ClsLogicaProveedor logica = new ClsLogicaProveedor();

        private int idProveedorModificar = 0;
        private int idDireccionModificar = 0;
        private int idSucursalModificar = 0;
        private int idTelefonoModificar = 0;
        private int idCorreoModificar = 0;
        private bool proveedorNoEncontrado = false;
        // sucursal a modificar (0 = la primera)
        private int idSucursalElegida = 0;
        // proveedor al que se le agrega sucursal
        private int idProveedorSucursalNueva = 0;
        // abierto desde el botón Nueva sucursal
        private bool abiertoParaSucursal = false;

        private bool EsSoloSucursal => idProveedorSucursalNueva > 0;

        public frmNuevoProveedor()
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            CargarCombos();
        }
        public frmNuevoProveedor(int idProveedor, int idSucursal = 0)
        {
            InitializeComponent();
            ClsIdioma.Registrar(this);

            idProveedorModificar = idProveedor;
            idSucursalElegida = idSucursal;

            lblTitulo.Text = ClsIdioma.T("Modificar proveedor");
            Text = ClsIdioma.T("Modificar proveedor");

            CargarCombos();
            CargarProveedorModificar();

            this.Load += frmNuevoProveedor_Load;
        }

        // Nueva sucursal de un proveedor existente
        public static frmNuevoProveedor ParaNuevaSucursal(int idProveedor, string razonSocial, string cuit, string condicionIva)
        {
            frmNuevoProveedor formulario = new frmNuevoProveedor();

            formulario.abiertoParaSucursal = true;
            formulario.PasarAModoSucursal(idProveedor, razonSocial, cuit);

            int indiceIva = formulario.cmbIva.Items.IndexOf(condicionIva ?? "");
            formulario.cmbIva.SelectedIndex = indiceIva > 0 ? indiceIva : 0;

            formulario.ActiveControl = formulario.txtSucursalProveedor;

            return formulario;
        }

        #region Metodo
        private void PasarAModoSucursal(int idProveedor, string razonSocial, string cuit)
        {
            idProveedorSucursalNueva = idProveedor;

            txtRazonSocial.Text = razonSocial;
            txtCuit.Text = cuit;
            txtRazonSocial.ReadOnly = true;
            txtCuit.ReadOnly = true;

            lblTitulo.Text = ClsIdioma.T("Nueva sucursal de ") + razonSocial;
            Text = lblTitulo.Text;
        }
        private void VolverAModoProveedorNuevo()
        {
            idProveedorSucursalNueva = 0;

            txtRazonSocial.ReadOnly = false;
            txtCuit.ReadOnly = false;

            lblTitulo.Text = ClsIdioma.T("Nuevo proveedor");
            Text = lblTitulo.Text;
        }
        private void CargarCombos()
        {
            try
            {
                CargarProvincias();
                CargarTiposTelefono();
                CargarIVA();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar las listas del formulario.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarDatos()
        {
            // datos del proveedor
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                return Aviso(ClsIdioma.T("Ingrese la razón social."), txtRazonSocial);
            }

            if (string.IsNullOrWhiteSpace(txtSucursalProveedor.Text))
            {
                return Aviso(ClsIdioma.T("Ingrese la sucursal (por ejemplo, \"Casa central\")."), txtSucursalProveedor);
            }

            if (!EsSoloSucursal && !string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                ClsValidarCUIL validar = new ClsValidarCUIL();

                if (!validar.CuitValido(txtCuit.Text.Trim()))
                {
                    return Aviso(ClsIdioma.T("El CUIT no es válido. Debe tener 11 números (con o sin guiones) y el dígito verificador correcto."), txtCuit);
                }

                if (logica.ExisteCuitProveedor(txtCuit.Text.Trim(), idProveedorModificar))
                {
                    return Aviso(ClsIdioma.T("Ya existe otro proveedor registrado con ese CUIT."), txtCuit);
                }
            }

            if (cmbIva.SelectedIndex <= 0)
            {
                return Aviso(ClsIdioma.T("Seleccione la condición de IVA."), cmbIva);
            }

            if (SucursalRepetida(txtSucursalProveedor.Text.Trim()))
            {
                return Aviso(ClsIdioma.T("Este proveedor ya tiene una sucursal con ese nombre."), txtSucursalProveedor);
            }

            // contacto
            if (!ClsValidarNumero.ClsValidarNumeros.NumeroValido(txtCelular.Text))
            {
                return Aviso(ClsIdioma.T("Ingrese el teléfono (solo números)."), txtCelular);
            }

            if (txtCelular.Text.Trim().Length < 6)
            {
                return Aviso(ClsIdioma.T("El teléfono es muy corto. Ingréselo con la característica."), txtCelular);
            }

            if (cmbTipoTelefono.SelectedIndex <= 0)
            {
                return Aviso(ClsIdioma.T("Seleccione el tipo de teléfono."), cmbTipoTelefono);
            }

            if (!ClsValidarCorreo.EsEmailValidoCualquierDominio(txtEmail.Text.Trim()))
            {
                return Aviso(ClsIdioma.T("Ingrese un e-mail válido."), txtEmail);
            }

            // direccion
            if (cmbProvincia.SelectedIndex <= 0)
            {
                return Aviso(ClsIdioma.T("Seleccione la provincia."), cmbProvincia);
            }

            if (cmbPartido.SelectedIndex <= 0)
            {
                return Aviso(ClsIdioma.T("Seleccione el partido."), cmbPartido);
            }

            if (cmbLocalidad.SelectedIndex <= 0)
            {
                return Aviso(ClsIdioma.T("Seleccione la localidad."), cmbLocalidad);
            }

            if (string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                return Aviso(ClsIdioma.T("Ingrese la calle."), txtCalle);
            }

            if (!chkSinNumero.Checked && (!int.TryParse(txtNumero.Text.Trim(), out int altura) || altura <= 0))
            {
                return Aviso(ClsIdioma.T("Ingrese el número de la calle (mayor que cero) o marque \"Sin número\"."), txtNumero);
            }

            if (!EsSoloSucursal && string.IsNullOrWhiteSpace(txtCuit.Text) &&
                logica.ExisteNombreProveedor(txtRazonSocial.Text.Trim(), idProveedorModificar))
            {
                DialogResult respuesta = MessageBox.Show(ClsIdioma.T("Ya existe un proveedor llamado \"") + txtRazonSocial.Text.Trim() + "\".\n\n" +
                    ClsIdioma.T("¿Desea guardarlo igual?"), ClsIdioma.T("Razón social repetida"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    txtRazonSocial.Focus();
                    return false;
                }
            }

            return true;
        }
        // sucursal con el mismo nombre
        private bool SucursalRepetida(string nombre)
        {
            int idProveedor = EsSoloSucursal ? idProveedorSucursalNueva : idProveedorModificar;

            if (idProveedor == 0)
            {
                return false;
            }

            DataTable sucursales = logica.ObtenerSucursalesPorProveedor(idProveedor);

            return sucursales.AsEnumerable().Any(f =>
                Convert.ToInt32(f["IdSucursal"]) != idSucursalModificar &&
                string.Equals((f["Sucursal"]?.ToString() ?? "").Trim(), nombre, StringComparison.CurrentCultureIgnoreCase));
        }
        private bool Aviso(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, ClsIdioma.T("Validación"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }
        private string CuitFormateado()
        {
            string numeros = txtCuit.Text.Replace("-", "").Trim();

            if (numeros.Length != 11)
            {
                return txtCuit.Text.Trim();
            }

            return numeros.Substring(0, 2) + "-" + numeros.Substring(2, 8) + "-" + numeros.Substring(10, 1);
        }
        private static int ValorCombo(ComboBox combo)
        {
            if (combo.SelectedValue == null || combo.SelectedValue is DataRowView)
            {
                return 0;
            }

            return int.TryParse(combo.SelectedValue.ToString(), out int valor) ? valor : 0;
        }
        private void CargarProvincias()
        {
            DataTable tabla = new ClsProvincia().CargarProvincias();

            DataRow fila = tabla.NewRow();
            fila["IdProvincia"] = 0;
            fila["NomProvincia"] = ClsIdioma.T("-Seleccione provincia-");
            tabla.Rows.InsertAt(fila, 0);

            cmbProvincia.DisplayMember = "NomProvincia";
            cmbProvincia.ValueMember = "IdProvincia";
            cmbProvincia.DataSource = tabla;

            cmbProvincia.SelectedIndex = 0;
        }
        private void CargarPartidos(int idProvincia)
        {
            DataTable tabla;

            if (idProvincia > 0)
            {
                tabla = new ClsPartido().CargarPartidos(idProvincia);
            }
            else
            {
                tabla = new DataTable();
                tabla.Columns.Add("IdPartido", typeof(int));
                tabla.Columns.Add("NomPartido", typeof(string));
            }

            DataRow fila = tabla.NewRow();
            fila["IdPartido"] = 0;
            fila["NomPartido"] = idProvincia > 0 ? ClsIdioma.T("-Seleccione partido-") : ClsIdioma.T("-Elija primero la provincia-");
            tabla.Rows.InsertAt(fila, 0);

            cmbPartido.DisplayMember = "NomPartido";
            cmbPartido.ValueMember = "IdPartido";
            cmbPartido.DataSource = tabla;

            cmbPartido.SelectedIndex = 0;
        }
        private void CargarLocalidadesPartido(int idPartido)
        {
            DataTable tabla;

            if (idPartido > 0)
            {
                tabla = new CapaLogica.ClsLocalidad().CargarLocalidades(idPartido);
            }
            else
            {
                tabla = new DataTable();
                tabla.Columns.Add("IdLocalidad", typeof(int));
                tabla.Columns.Add("NomLocalidad", typeof(string));
                tabla.Columns.Add("CodigoPostal", typeof(string));
            }

            DataRow fila = tabla.NewRow();
            fila["IdLocalidad"] = 0;
            fila["NomLocalidad"] = idPartido > 0 ? ClsIdioma.T("-Seleccione localidad-") : ClsIdioma.T("-Elija primero el partido-");
            tabla.Rows.InsertAt(fila, 0);

            cmbLocalidad.DisplayMember = "NomLocalidad";
            cmbLocalidad.ValueMember = "IdLocalidad";
            cmbLocalidad.DataSource = tabla;

            cmbLocalidad.SelectedIndex = 0;
        }
        private void CargarTiposTelefono()
        {
            DataTable tabla = logica.ObtenerTiposTelefono();

            DataRow fila = tabla.NewRow();
            fila["IdTipo"] = 0;
            fila["Tipo"] = ClsIdioma.T("-Seleccione tipo-");
            tabla.Rows.InsertAt(fila, 0);

            cmbTipoTelefono.DisplayMember = "Tipo";
            cmbTipoTelefono.ValueMember = "IdTipo";
            cmbTipoTelefono.DataSource = tabla;

            cmbTipoTelefono.SelectedIndex = 0;
        }
        private void CargarIVA()
        {
            cmbIva.Items.Clear();

            cmbIva.Items.Add("-Seleccione condición de IVA-");
            cmbIva.Items.Add("Responsable Inscripto");
            cmbIva.Items.Add("Monotributista");
            cmbIva.Items.Add("Exento");
            cmbIva.Items.Add("Consumidor Final");
            cmbIva.Items.Add("Sujeto No Categorizado");

            cmbIva.SelectedIndex = 0;
        }
        private void CargarProveedorModificar()
        {
            try
            {
                DataTable tabla = logica.ObtenerProveedorPorId(idProveedorModificar);

                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show(ClsIdioma.T("No se encontraron los datos completos del proveedor (sucursal o dirección), ") +
                        ClsIdioma.T("por eso no se puede modificar."), ClsIdioma.T("Proveedor incompleto"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    proveedorNoEncontrado = true;
                    return;
                }

                DataRow fila = tabla.AsEnumerable()
                    .FirstOrDefault(f => Convert.ToInt32(f["IdSucursal"]) == idSucursalElegida) ?? tabla.Rows[0];

                txtRazonSocial.Text = fila["RazonSocial"]?.ToString() ?? "";
                txtSucursalProveedor.Text = fila["Sucursal"]?.ToString() ?? "";
                txtCuit.Text = fila["CUIT"]?.ToString() ?? "";
                txtObservaciones.Text = fila["Observacion"]?.ToString() ?? "";
                idDireccionModificar = Convert.ToInt32(fila["IdDireccion"]);
                idSucursalModificar = Convert.ToInt32(fila["IdSucursal"]);
                txtCalle.Text = fila["Calle"]?.ToString() ?? "";
                txtNumero.Text = fila["Altura"]?.ToString() ?? "";
                chkSinNumero.Checked = fila["Altura"] == DBNull.Value;
                txtPiso.Text = fila["Piso"]?.ToString() ?? "";
                txtDepartamento.Text = fila["Departamento"]?.ToString() ?? "";

                txtCelular.Text = fila["NumTelefono"]?.ToString() ?? "";
                txtEmail.Text = fila["Correo"]?.ToString() ?? "";

                if (fila["IdLocalidad"] != DBNull.Value)
                {
                    SeleccionarLocalidad(Convert.ToInt32(fila["IdLocalidad"]));
                }

                if (fila["IdTelefono"] != DBNull.Value)
                {
                    idTelefonoModificar = Convert.ToInt32(fila["IdTelefono"]);
                }

                if (fila["IdCorreo"] != DBNull.Value)
                {
                    idCorreoModificar = Convert.ToInt32(fila["IdCorreo"]);
                }

                if (fila["IdTipo"] != DBNull.Value)
                {
                    cmbTipoTelefono.SelectedValue = Convert.ToInt32(fila["IdTipo"]);
                }

                int indiceIva = cmbIva.Items.IndexOf(fila["CondiciónIVA"]?.ToString() ?? "");
                cmbIva.SelectedIndex = indiceIva > 0 ? indiceIva : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsIdioma.T("No se pudieron cargar los datos del proveedor.\n\n") + ex.Message, ClsIdioma.T("Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                proveedorNoEncontrado = true;
            }
        }
        private void SeleccionarLocalidad(int idLocalidad)
        {
            CapaEntidades.ClsTraerPartido? partido = new ClsObtenerPartidoPer().ObtenerPartido(idLocalidad);

            if (partido == null)
            {
                return;
            }

            cmbProvincia.SelectedValue = partido.IdProvincia;
            cmbPartido.SelectedValue = partido.IdPartido;
            cmbLocalidad.SelectedValue = idLocalidad;
        }
        private void LimpiarFormulario()
        {
            VaciarFormularios.LimpiarControles(this);

            cmbProvincia.SelectedIndex = 0;
            cmbTipoTelefono.SelectedIndex = 0;
            cmbIva.SelectedIndex = 0;
            chkSinNumero.Checked = false;

            txtRazonSocial.Focus();
        }
        private void frmNuevoProveedor_Load(object? sender, EventArgs e)
        {
            if (proveedorNoEncontrado)
            {
                BeginInvoke(new Action(Close));
            }
        }

        #endregion

        #region Eventos
        private void cmbProvincia_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CargarPartidos(ValorCombo(cmbProvincia));
        }
        private void cmbPartido_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CargarLocalidadesPartido(ValorCombo(cmbPartido));
        }
        private void cmbLocalidad_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbLocalidad.SelectedItem is DataRowView fila && ValorCombo(cmbLocalidad) > 0 &&
                fila.Row.Table.Columns.Contains("CodigoPostal"))
            {
                txtPostal.Text = fila["CodigoPostal"]?.ToString() ?? "";
            }
            else
            {
                txtPostal.Clear();
            }
        }
        private void SoloNumeros_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void chkSinNumero_CheckedChanged(object? sender, EventArgs e)
        {
            txtNumero.Enabled = !chkSinNumero.Checked;

            if (chkSinNumero.Checked)
            {
                txtNumero.Clear();
            }
        }
        private void txtCuit_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
        private void txtObservaciones_TextChanged(object? sender, EventArgs e)
        {
            lblContador.Text = txtObservaciones.TextLength + " / " + txtObservaciones.MaxLength;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool esNuevo = idProveedorModificar == 0;

            try
            {
                if (!ValidarDatos())
                {
                    return;
                }

                ClsProveedor proveedor = new ClsProveedor
                {
                    IdProveedor = idProveedorModificar,
                    Nombre = txtRazonSocial.Text.Trim(),
                    CUIT = CuitFormateado(),
                    Activo = true
                };

                int idProveedor;

                if (EsSoloSucursal)
                {
                    idProveedor = idProveedorSucursalNueva;
                }
                else if (esNuevo)
                {
                    idProveedor = logica.RegistrarProveedor(proveedor);
                }
                else
                {
                    logica.ModificarProveedor(proveedor);
                    idProveedor = idProveedorModificar;
                }

                ClsDireccion direccion = new ClsDireccion
                {
                    Calle = txtCalle.Text.Trim(),
                    Altura = chkSinNumero.Checked ? null : int.Parse(txtNumero.Text.Trim()),
                    Piso = txtPiso.Text.Trim(),
                    Departamento = txtDepartamento.Text.Trim(),
                    IdLocalidad = ValorCombo(cmbLocalidad)
                };

                int idDireccion;

                if (esNuevo)
                {
                    idDireccion = logica.RegistrarDireccion(direccion);
                }
                else
                {
                    direccion.IdDireccion = idDireccionModificar;

                    logica.ModificarDireccion(direccion);

                    idDireccion = idDireccionModificar;
                }

                ClsSucursalProveedor sucursal = new ClsSucursalProveedor
                {
                    IdProveedor = idProveedor,
                    Nombre = txtSucursalProveedor.Text.Trim(),
                    Activo = true,
                    IdDireccion = idDireccion,
                    CondicionIVA = cmbIva.Text,
                    Observacion = txtObservaciones.Text.Trim()
                };

                int idSucursal;

                if (esNuevo)
                {
                    idSucursal = logica.RegistrarSucursalProveedor(sucursal);
                }
                else
                {
                    sucursal.IdSucursal = idSucursalModificar;

                    logica.ModificarSucursalProveedor(sucursal);

                    idSucursal = idSucursalModificar;
                }

                ClsTelefono telefono = new ClsTelefono
                {
                    NumTelefono = txtCelular.Text.Trim(),
                    IdTipo = ValorCombo(cmbTipoTelefono)
                };

                if (esNuevo || idTelefonoModificar == 0)
                {
                    int idTelefono = logica.RegistrarTelefono(telefono);

                    ClsSucursalProveedorTelefono telefonoSucursal = new ClsSucursalProveedorTelefono
                    {
                        IdSucursal = idSucursal,
                        IdTelefono = idTelefono,
                        Activo = true
                    };

                    logica.RegistrarSucursalProveedorTelefono(telefonoSucursal);

                    idTelefonoModificar = esNuevo ? 0 : idTelefono;
                }
                else
                {
                    telefono.IdTelefono = idTelefonoModificar;
                    logica.ModificarTelefono(telefono);
                }

                ClsCorreo correo = new ClsCorreo
                {
                    Correo = txtEmail.Text.Trim()
                };

                if (esNuevo || idCorreoModificar == 0)
                {
                    int idCorreo = logica.RegistrarCorreo(correo);

                    ClsSucursalProveedorCorreo correoSucursal = new ClsSucursalProveedorCorreo
                    {
                        IdCorreo = idCorreo,
                        IdSucursal = idSucursal,
                        Activo = true
                    };

                    logica.RegistrarSucursalProveedorCorreo(correoSucursal);

                    idCorreoModificar = esNuevo ? 0 : idCorreo;
                }
                else
                {
                    correo.IdCorreo = idCorreoModificar;

                    logica.ModificarCorreo(correo);
                }

                if (esNuevo)
                {
                    string registrado = EsSoloSucursal ? ClsIdioma.T("Sucursal registrada correctamente.") : ClsIdioma.T("Proveedor registrado correctamente.");

                    DialogResult otra = MessageBox.Show(registrado + "\n\n" + ClsIdioma.T("¿Desea cargar otra sucursal de este proveedor?"),
                        ClsIdioma.T("Proveedores"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (otra == DialogResult.Yes)
                    {
                        // otra sucursal del mismo proveedor
                        string razonSocial = txtRazonSocial.Text.Trim();
                        string cuit = CuitFormateado();
                        int indiceIva = cmbIva.SelectedIndex;

                        LimpiarFormulario();
                        PasarAModoSucursal(idProveedor, razonSocial, cuit);
                        cmbIva.SelectedIndex = indiceIva;

                        txtSucursalProveedor.Focus();
                    }
                    else if (abiertoParaSucursal)
                    {
                        this.Close();
                    }
                    else
                    {
                        VolverAModoProveedorNuevo();
                        LimpiarFormulario();
                    }
                }
                else
                {
                    MessageBox.Show(ClsIdioma.T("Proveedor modificado correctamente."), ClsIdioma.T("Proveedores"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((esNuevo ? ClsIdioma.T("No se pudo registrar el proveedor.") : ClsIdioma.T("No se pudo modificar el proveedor.")) +
                    "\n\n" + ex.Message, ClsIdioma.T("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



    }
}
