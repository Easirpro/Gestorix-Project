using CapaDatos;
using CapaEntidades;
using CapaLogica;
using CapaLogica.BitacoraLogi;
using CapaSesion;
using EnviarMail;

public class ClsAltaEmpleado
{
    public string UsuarioSinCorreo { get; private set; }
    public string PasswordTemporalSinCorreo { get; private set; }

    public bool CrearEmpleado( string nombre, string apellido, DateTime fechaNacimiento,
         string dni, string cuit, bool sexo, int idGenero, int idRol,
         string correo, string telefono, int idTipoTelefono, string calle,
         int altura, string piso, string departamento, int idLocalidad, bool activo)
    {
        clsPersonaDatos personaDatos = new clsPersonaDatos();
        ClsGenerarUsername genUser = new ClsGenerarUsername();

        string motivoRol = new ClsUsuarioLogica().ValidarRolAsignable(idRol);

        if (motivoRol != string.Empty)
        {
            throw new InvalidOperationException(motivoRol);
        }

        // CU03 6.1: si ya existe se informa, no se reutilizan datos viejos
        if (personaDatos.ObtenerIdPersonaPorDniOCuit(dni, cuit) > 0)
        {
            throw new InvalidOperationException("El empleado ya está registrado.");
        }

        string username = genUser.CrearUsuario(nombre, apellido);
        string passwordTemporal = Aleatorios.Armar(true, 10, 1);

        ClsPersona persona = new ClsPersona
        {
            Nombre = nombre,
            Apellido = apellido,
            FeNac = fechaNacimiento,
            DNI = dni,
            CUIT = cuit,
            Sexo = sexo,
            IdGenero = idGenero,
            Activo = activo
        };

        ClsCorreo objCorreo = new ClsCorreo
        {
            DireccionCorreo = correo
        };

        ClsTelefono objTel = new ClsTelefono
        {
            NumTelefono = telefono,
            IdTipo = idTipoTelefono
        };

        ClsDomicilio objDom = new ClsDomicilio
        {
            Calle = calle,
            Altura = altura,
            Piso = piso,
            Departamento = departamento,
            IdLocalidad = idLocalidad
        };

        ClslUsuario usuario = new ClslUsuario
        {
            IdRol = idRol,
            Username = username,
            PassActual = ClsSeguridad.SHA256(username + passwordTemporal),
            Estado = true,
            PrimerIngreso = true,
            PreguntasCompletadas = false
        };

        // CU03 8.1: todo o nada
        int idUsuario = new ClsAltaEmpleadoDatos().RegistrarEmpleado(persona, objCorreo, objTel, objDom, usuario);

        if (idUsuario <= 0)
        {
            return false;
        }

        clsBitacoraLogica bitacora = new clsBitacoraLogica();

        bitacora.RegistrarBitacora(
            SesionUsuario.IdUsuario > 0 ? SesionUsuario.IdUsuario : (int?)null,
            "CREAR",
            "Usuario",
            idUsuario,
            "Alta de usuario: " + username
        );

        EnviarCorreoAlta(correo, username, passwordTemporal);

        return true;
    }

    private void EnviarCorreoAlta(string correo, string username, string passwordTemporal)
    {
        UsuarioSinCorreo = null;
        PasswordTemporalSinCorreo = null;

        string asunto = "Alta de Usuario - Gestorix";

        string cuerpo =
            $@"<h2>Bienvenido a Gestorix</h2>

                <p>Su usuario ha sido creado correctamente.</p>

                <p><b>Usuario:</b> {username}</p>

                <p><b>Contraseña Temporal:</b> {passwordTemporal}</p>

                <p>
                    Por razones de seguridad, deberá cambiar su contraseña
                    en el primer inicio de sesión.
                </p>";

        try
        {
            MailHelper.Enviar(correo, asunto, cuerpo);
        }
        catch
        {
            UsuarioSinCorreo = username;
            PasswordTemporalSinCorreo = passwordTemporal;
        }
    }
}
