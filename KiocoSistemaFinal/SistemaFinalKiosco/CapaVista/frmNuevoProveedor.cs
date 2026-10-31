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
        // Si el proveedor a modificar no se pudo cargar, el formulario se cierra al abrirse.
        private bool proveedorNoEncontrado = false;

        public frmNuevoProveedor()
        {
            InitializeComponent();

            CargarCombos();
        }
        public frmNuevoProveedor(int idProveedor)
        {
            InitializeComponent();

            idProveedorModificar = idProveedor;

            lblTitulo.Text = "Modificar proveedor";
            Text = "Modificar proveedor";

            CargarCombos();
            CargarProveedorModificar();

            this.Load += frmNuevoProveedor_Load;
        }

        #region Metodo
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
                MessageBox.Show("No se pudieron cargar las listas del formulario.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Valida en el mismo orden en que aparecen los campos en pantalla.
        private bool ValidarDatos()
        {
            // --- Datos del proveedor ---
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                return Aviso("Ingrese la razón social.", txtRazonSocial);
            }

            if (string.IsNullOrWhiteSpace(txtSucursalProveedor.Text))
            {
                return Aviso("Ingrese la sucursal (por ejemplo, \"Casa central\").", txtSucursalProveedor);
            }

            if (!string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                ClsValidarCUIL validar = new ClsValidarCUIL();

                if (!validar.CuitValido(txtCuit.Text.Trim()))
                {
                    return Aviso("El CUIT no es válido. Debe tener 11 números (con o sin guiones) y el dígito verificador correcto.", txtCuit);
                }

                if (logica.ExisteCuitProveedor(txtCuit.Text.Trim(), idProveedorModificar))
                {
                    return Aviso("Ya existe otro proveedor registrado con ese CUIT.", txtCuit);
                }
            }

            if (cmbIva.SelectedIndex <= 0)
            {
                return Aviso("Seleccione la condición de IVA.", cmbIva);
            }

            // --- Contacto ---
            if (!ClsValidarNumero.ClsValidarNumeros.NumeroValido(txtCelular.Text))
            {
                return Aviso("Ingrese el teléfono (solo números).", txtCelular);
            }

            if (txtCelular.Text.Trim().Length < 6)
            {
                return Aviso("El teléfono es muy corto. Ingréselo con la característica.", txtCelular);
            }

            if (cmbTipoTelefono.SelectedIndex <= 0)
            {
                return Aviso("Seleccione el tipo de teléfono.", cmbTipoTelefono);
            }

            if (!ClsValidarCorreo.EsEmailValido(txtEmail.Text.Trim()))
            {
                return Aviso("Ingrese un e-mail válido.", txtEmail);
            }

            // --- Dirección ---
            if (cmbProvincia.SelectedIndex <= 0)
            {
                return Aviso("Seleccione la provincia.", cmbProvincia);
            }

            if (cmbPartido.SelectedIndex <= 0)
            {
                return Aviso("Seleccione el partido.", cmbPartido);
            }

            if (cmbLocalidad.SelectedIndex <= 0)
            {
                return Aviso("Seleccione la localidad.", cmbLocalidad);
            }

            if (string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                return Aviso("Ingrese la calle.", txtCalle);
            }

            if (!int.TryParse(txtNumero.Text.Trim(), out int altura) || altura <= 0)
            {
                return Aviso("Ingrese el número de la calle (mayor que cero).", txtNumero);
            }

            // Sin CUIT, la razón social es lo único que distingue al proveedor: se avisa si ya existe.
            if (string.IsNullOrWhiteSpace(txtCuit.Text) &&
                logica.ExisteNombreProveedor(txtRazonSocial.Text.Trim(), idProveedorModificar))
            {
                DialogResult respuesta = MessageBox.Show("Ya existe un proveedor llamado \"" + txtRazonSocial.Text.Trim() + "\".\n\n" +
                    "¿Desea guardarlo igual?", "Razón social repetida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    txtRazonSocial.Focus();
                    return false;
                }
            }

            return true;
        }
        private bool Aviso(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }
        // CUIT siempre con el formato XX-XXXXXXXX-X (ya validado). Vacío queda vacío.
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
            fila["NomProvincia"] = "-Seleccione provincia-";
            tabla.Rows.InsertAt(fila, 0);

            cmbProvincia.DisplayMember = "NomProvincia";
            cmbProvincia.ValueMember = "IdProvincia";
            cmbProvincia.DataSource = tabla;

            cmbProvincia.SelectedIndex = 0;
        }
        // Partidos de la provincia elegida (solo el "-Seleccione-" si no hay provincia).
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
            fila["NomPartido"] = idProvincia > 0 ? "-Seleccione partido-" : "-Elija primero la provincia-";
            tabla.Rows.InsertAt(fila, 0);

            cmbPartido.DisplayMember = "NomPartido";
            cmbPartido.ValueMember = "IdPartido";
            cmbPartido.DataSource = tabla;

            cmbPartido.SelectedIndex = 0;
        }
        // Localidades del partido elegido, con su código postal.
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
            fila["NomLocalidad"] = idPartido > 0 ? "-Seleccione localidad-" : "-Elija primero el partido-";
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
            fila["Tipo"] = "-Seleccione tipo-";
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
                    // Pasa si al proveedor le falta la sucursal o la dirección: no se puede modificar.
                    MessageBox.Show("No se encontraron los datos completos del proveedor (sucursal o dirección), " +
                        "por eso no se puede modificar.", "Proveedor incompleto",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    proveedorNoEncontrado = true;
                    return;
                }

                DataRow fila = tabla.Rows[0];

                txtRazonSocial.Text = fila["RazonSocial"]?.ToString() ?? "";
                txtSucursalProveedor.Text = fila["Sucursal"]?.ToString() ?? "";
                txtCuit.Text = fila["CUIT"]?.ToString() ?? "";
                txtObservaciones.Text = fila["Observacion"]?.ToString() ?? "";
                idDireccionModificar = Convert.ToInt32(fila["IdDireccion"]);
                idSucursalModificar = Convert.ToInt32(fila["IdSucursal"]);
                txtCalle.Text = fila["Calle"]?.ToString() ?? "";
                txtNumero.Text = fila["Altura"]?.ToString() ?? "";
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
                MessageBox.Show("No se pudieron cargar los datos del proveedor.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                proveedorNoEncontrado = true;
            }
        }
        // Elige provincia, partido y localidad a partir de la localidad guardada.
        private void SeleccionarLocalidad(int idLocalidad)
        {
            CapaEntidades.ClsTraerPartido? partido = new ClsObtenerPartidoPer().ObtenerPartido(idLocalidad);

            if (partido == null)
            {
                return;
            }

            // Cada SelectedValue dispara la carga del combo siguiente.
            cmbProvincia.SelectedValue = partido.IdProvincia;
            cmbPartido.SelectedValue = partido.IdPartido;
            cmbLocalidad.SelectedValue = idLocalidad;
        }
        // Vacía el formulario dejando los combos en "-Seleccione…-" (no en blanco).
        private void LimpiarFormulario()
        {
            VaciarFormularios.LimpiarControles(this);

            cmbProvincia.SelectedIndex = 0;   // recarga partido y localidad vacíos
            cmbTipoTelefono.SelectedIndex = 0;
            cmbIva.SelectedIndex = 0;

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
        // Teléfono y número de calle: solo dígitos.
        private void SoloNumeros_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // CUIT: dígitos y guiones.
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

                if (esNuevo)
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
                    Altura = int.Parse(txtNumero.Text.Trim()),
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

                // Si se está modificando un proveedor que no tenía teléfono, se crea uno nuevo.
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

                // Igual con el correo: si no tenía, se crea.
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
                    MessageBox.Show("Proveedor registrado correctamente.\n\nPuede cargar otro o tocar Cancelar para volver.", "Proveedores",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Proveedor modificado correctamente.", "Proveedores",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((esNuevo ? "No se pudo registrar el proveedor." : "No se pudo modificar el proveedor.") +
                    "\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



    }
}
