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
        ClsGestorLogicaProveedor logica = new ClsGestorLogicaProveedor();

        public frmNuevoProveedor()
        {
            InitializeComponent();

            CargarLocalidades();

            CargarTiposTelefono();

            CargarIVA();
        }

        #region Metodo
        private bool ValidarDatos()
        {
            ValidacionCampoVacio validarCampo = new ValidacionCampoVacio();

            if (validarCampo.ValidarCamposVacios(txtRazonSocial.Text))
            {
                MessageBox.Show("Ingrese la Razón Social.");
                txtRazonSocial.Focus();
                return false;
            }

            if (validarCampo.ValidarCamposVacios(txtNombreComercial.Text))
            {
                MessageBox.Show("Ingrese el Nombre Comercial.");
                txtNombreComercial.Focus();
                return false;
            }

            if (!ClsValidarNumero.ClsValidarNumeros.NumeroValido(txtCelular.Text))
            {
                MessageBox.Show("Ingrese un número de teléfono válido.");
                txtCelular.Focus();
                return false;
            }

            if (cmbTipoTelefono.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el tipo de teléfono.");
                cmbTipoTelefono.Focus();
                return false;
            }

            if (!ClsValidarCorreo.EsEmailValido(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Ingrese un e-mail válido.");
                txtEmail.Focus();
                return false;
            }

            if (validarCampo.ValidarCamposVacios(txtCalle.Text))
            {
                MessageBox.Show("Ingrese la calle.");
                txtCalle.Focus();
                return false;
            }

            if (validarCampo.ValidarCamposVacios(txtNumero.Text))
            {
                MessageBox.Show("Ingrese el número.");
                txtNumero.Focus();
                return false;
            }

            if (!ClsValidarNumero.ClsValidarNumeros.NumeroEnteroValido(txtNumero.Text))
            {
                MessageBox.Show("El número debe ser un valor numérico.");
                txtNumero.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                ClsValidarCUIL validar = new ClsValidarCUIL();

                if (!validar.CuitValido(txtCuit.Text.Trim()))
                {
                    MessageBox.Show("Ingrese un CUIT válido.");
                    txtCuit.Focus();
                    return false;
                }
            }

            if (cmbLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una localidad.");
                cmbLocalidad.Focus();
                return false;
            }

            if (cmbIva.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la condición de IVA.");
                cmbIva.Focus();
                return false;
            }

            return true;
        }
        private void CargarLocalidades()
        {
            DataTable tabla = logica.ObtenerLocalidades();

            DataRow fila = tabla.NewRow();
            fila["IdLocalidad"] = 0;
            fila["NomLocalidad"] = "-Seleccione Localidad-";
            tabla.Rows.InsertAt(fila, 0);

            cmbLocalidad.DataSource = tabla;

            cmbLocalidad.DisplayMember = "NomLocalidad";
            cmbLocalidad.ValueMember = "IdLocalidad";

            cmbLocalidad.SelectedIndex = 0;
        }
        private void CargarTiposTelefono()
        {
            DataTable tabla = logica.ObtenerTiposTelefono();

            DataRow fila = tabla.NewRow();
            fila["IdTipo"] = 0;
            fila["Tipo"] = "-Seleccione tipo de Teléfono-";
            tabla.Rows.InsertAt(fila, 0);

            cmbTipoTelefono.DataSource = tabla;

            cmbTipoTelefono.DisplayMember = "Tipo";
            cmbTipoTelefono.ValueMember = "IdTipo";

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

        #endregion

        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            ClsProveedor proveedor = new ClsProveedor
            {
                Nombre = txtRazonSocial.Text.Trim(),
                CUIT = txtCuit.Text.Trim(),
                Activo = true
            };

            int idProveedor = logica.RegistrarProveedor(proveedor);

            ClsDireccion direccion = new ClsDireccion
            {
                Calle = txtCalle.Text.Trim(),
                Altura = int.Parse(txtNumero.Text),
                Piso = txtPiso.Text.Trim(),
                Departamento = txtDepartamento.Text.Trim(),
                IdLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue)
            };

            int idDireccion = logica.RegistrarDireccion(direccion);

            ClsSucursalProveedor sucursal = new ClsSucursalProveedor
            {
                IdProveedor = idProveedor,
                Nombre = txtNombreComercial.Text.Trim(),
                Activo = true,
                IdDireccion = idDireccion,
                CondicionIVA = cmbIva.Text,
                Observacion = txtObservaciones.Text.Trim()
            };


            int idSucursal = logica.RegistrarSucursalProveedor(sucursal);

            ClsTelefono telefono = new ClsTelefono
            {
                NumTelefono = txtCelular.Text.Trim(),
                IdTipo = Convert.ToInt32(cmbTipoTelefono.SelectedValue)
            };

            int idTelefono = logica.RegistrarTelefono(telefono);

            ClsSucursalProveedorTelefono telefonoSucursal = new ClsSucursalProveedorTelefono
            {
                IdSucursal = idSucursal,
                IdTelefono = idTelefono,
                Activo = true
            };

            logica.RegistrarSucursalProveedorTelefono(telefonoSucursal);

            ClsCorreo correo = new ClsCorreo
            {
                Correo = txtEmail.Text.Trim()
            };

            int idCorreo = logica.RegistrarCorreo(correo);

            ClsSucursalProveedorCorreo correoSucursal = new ClsSucursalProveedorCorreo
            {
                IdCorreo = idCorreo,
                IdSucursal = idSucursal,
                Activo = true
            };

            logica.RegistrarSucursalProveedorCorreo(correoSucursal);
            MessageBox.Show("Proveedor registrado correctamente.");
            VaciarFormularios.LimpiarControles(this);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



    }
}
