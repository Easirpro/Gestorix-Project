using CapaDatos;
using CapaEntidades;
using CapaLogica;
using CapaLogica.BitacoraLogi;
using CapaSesion;
using EnviarMail;

public class ClsAltaEmpleado
{
    // Si el usuario se creó pero el correo con la contraseña temporal no se pudo enviar, quedan acá
    // el usuario y la contraseña para que quien hizo el alta se los entregue al empleado.
    public string UsuarioSinCorreo { get; private set; }
    public string PasswordTemporalSinCorreo { get; private set; }

    public bool CrearEmpleado( string nombre, string apellido, DateTime fechaNacimiento,
         string dni, string cuit, bool sexo, int idGenero, int idRol,
         string correo, string telefono, int idTipoTelefono, string calle,
         int altura, string piso, string departamento, int idLocalidad, bool activo)
    {
        clsCorreoDatos correoDatos = new clsCorreoDatos();
        clsTelefonoDatos telefonoDatos = new clsTelefonoDatos();
        clsDomicilioDatos domicilioDatos = new clsDomicilioDatos();
        clsPersonaDatos personaDatos = new clsPersonaDatos();
        clsPersonaCorreoDatos pcDatos = new clsPersonaCorreoDatos();
        clsPersonaTelefonoDatos ptDatos = new clsPersonaTelefonoDatos();
        clsPersonaDomicilioDatos pdDatos = new clsPersonaDomicilioDatos();
        ClsUsuarioDatos usuarioDatos = new ClsUsuarioDatos();
        ClsGenerarUsername genUser = new ClsGenerarUsername();

        int idPersona = personaDatos.ObtenerIdPersonaPorDniOCuit(dni, cuit);

        if (idPersona > 0)
        {
            if (usuarioDatos.ExisteUsuarioPorIdPersona(idPersona))
            {
                throw new Exception(
                    "No se puede crear el usuario porque la persona ya tiene " +
                    "un usuario registrado.\n\n" +
                    "DNI: " + dni + "\n" +
                    "CUIT: " + cuit
                );
            }

            string correoExistente = correoDatos.ObtenerCorreoPorPersona(idPersona);

            if (string.IsNullOrWhiteSpace(correoExistente))
            {
                throw new Exception(
                    "La persona ya existe, pero no tiene un correo registrado.\n\n" +
                    "No se puede crear el usuario hasta que la persona tenga " +
                    "un correo asociado."
                );
            }

            int idTelefonoExistente = ptDatos.ObtenerIdTelefonoPorPersona(idPersona);

            if (idTelefonoExistente <= 0)
            {
                throw new Exception(
                    "La persona ya existe, pero no tiene un teléfono asociado.\n\n" +
                    "No se puede completar el alta del usuario."
                );
            }

            int idDomicilioExistente = pdDatos.ObtenerIdDomicilioPorPersona(idPersona);

            if (idDomicilioExistente <= 0)
            {
                throw new Exception(
                    "La persona ya existe, pero no tiene un domicilio asociado.\n\n" +
                    "No se puede completar el alta del usuario."
                );
            }

            string usernameExistente = genUser.CrearUsuario(nombre, apellido);
            string passwordTemporalExistente = Aleatorios.Armar(true, 10, 1);

            ClslUsuario usuarioExistente = new ClslUsuario
            {
                IdPersona = idPersona,
                IdRol = idRol,
                Username = usernameExistente,
                PassActual = ClsSeguridad.SHA256(usernameExistente + passwordTemporalExistente),
                Estado = true,
                PrimerIngreso = true,
                PreguntasCompletadas = false
            };

            int idUsuarioExistente = usuarioDatos.RegistrarUsuario(usuarioExistente);

            if (idUsuarioExistente <= 0)
            {
                return false;
            }

            clsBitacoraLogica bitacora = new clsBitacoraLogica();

            bitacora.RegistrarBitacora(
                SesionUsuario.IdUsuario > 0 ? SesionUsuario.IdUsuario : (int?)null,
                "CREAR",
                "Usuario",
                idUsuarioExistente,
                "Alta de usuario: " + usernameExistente
            );

            EnviarCorreoAlta(correoExistente, usernameExistente, passwordTemporalExistente);

            return true;
        }

        ClsCorreo objCorreo = new ClsCorreo
        {
            DireccionCorreo = correo
        };

        int idCorreo = correoDatos.RegistrarCorreo(objCorreo);

        if (idCorreo <= 0)
        {
            return false;
        }

        ClsTelefono objTel = new ClsTelefono
        {
            NumTelefono = telefono,
            IdTipo = idTipoTelefono
        };

        int idTelefono = telefonoDatos.RegistrarTelefono(objTel);

        if (idTelefono <= 0)
        {
            return false;
        }

        ClsDomicilio objDom = new ClsDomicilio
        {
            Calle = calle,
            Altura = altura,
            Piso = piso,
            Departamento = departamento,
            IdLocalidad = idLocalidad
        };

        int idDomicilio = domicilioDatos.RegistrarDomicilio(objDom);

        if (idDomicilio <= 0)
        {
            return false;
        }

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

        try
        {
            idPersona = personaDatos.RegistrarPersona(persona);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "ERROR AL REGISTRAR PERSONA.\n\n" +
                "DNI: " + dni + "\n" +
                "CUIT: " + cuit + "\n\n" +
                "MENSAJE:\n" +
                ex.Message,
                ex
            );
        }

        if (idPersona <= 0)
        {
            return false;
        }

        pcDatos.RegistrarPersonaCorreo(idPersona, idCorreo);
        ptDatos.RegistrarPersonaTelefono(idPersona, idTelefono);
        pdDatos.RegistrarPersonaDomicilio(idPersona, idDomicilio);

        string username = genUser.CrearUsuario(nombre, apellido);

        string passwordTemporal = Aleatorios.Armar(true, 10, 1);

        ClslUsuario usuario = new ClslUsuario
        {
            IdPersona = idPersona,
            IdRol = idRol,
            Username = username,
            PassActual = ClsSeguridad.SHA256(
                username + passwordTemporal
            ),
            Estado = true,
            PrimerIngreso = true,
            PreguntasCompletadas = false
        };

        int idUsuario = usuarioDatos.RegistrarUsuario(usuario);

        if (idUsuario <= 0)
        {
            return false;
        }

        clsBitacoraLogica bitacoraNuevo = new clsBitacoraLogica();

        bitacoraNuevo.RegistrarBitacora(
            SesionUsuario.IdUsuario > 0 ? SesionUsuario.IdUsuario : (int?)null,
            "CREAR",
            "Usuario",
            idUsuario,
            "Alta de usuario: " + username
        );

        EnviarCorreoAlta(correo, username, passwordTemporal);

        return true;
    }

    // El usuario ya está creado: si el correo falla no se corta el alta, se guardan los datos
    // para mostrarlos (si no, el empleado quedaría con una contraseña temporal que nadie conoce).
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
