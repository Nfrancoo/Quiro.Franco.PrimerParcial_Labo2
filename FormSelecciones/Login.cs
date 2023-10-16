using System.Text.Json;
using PrimerParcial;

namespace FormSelecciones
{
    /// <summary>
    /// Formulario de inicio de sesi�n de la aplicaci�n.
    public partial class Login : Form
    {
        private List<Usuario> usuarios;

        
        /// <summary>
        /// Constructor de la clase Login.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            usuarios = LeerUsuariosDesdeJSON(@"..//..//..//..//MOCK_DATA.json");
            this.StartPosition = FormStartPosition.CenterScreen;
            this.txtContrase�a.PasswordChar = '*';

        }

        /// <summary>
        /// Maneja el evento Click del bot�n de inicio de sesi�n.
        /// busca que el correo y la clave sean iguales al json usuario
        /// y luego abro mi FormPrincipal, con el lambda verifico que si se creo el evento FormClosed
        /// cierra el form Usuario(tuve que hacerlo asi por un error que no me dejaba cerrarlo)
        /// </summary>
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = this.txtCorreo.Text;
            string contrase�a = this.txtContrase�a.Text;

            
            Usuario usuario = usuarios.Find(u => u.correo == correo && u.clave == contrase�a);


            if (usuario != null)
            {
                // Mostrar un mensaje de bienvenida con el nombre, apellido y perfil del usuario.
                MessageBox.Show($"Bienvenido, {usuario.nombre} {usuario.apellido}. Perfil: {usuario.perfil}");

                this.Hide();

                FormPrincipal formPrincipal = new FormPrincipal(usuario);

                formPrincipal.Show();

                //manejo el evento FormClosed del FormPrincipal
                formPrincipal.FormClosed += (s, args) =>
                //expresion lambda que se va a ejecutar cuando el evento FormClosed pase
                {
                    // Cerrar otros formularios si es necesario
                    this.Close();
                };
            }
            else
            {
                MessageBox.Show("Correo o contrase�a incorrectos");
            }
        }

        /// <summary>
        /// Lee la lista de usuarios desde un archivo JSON.
        /// </summary>
        /// <param name="archivo">La ruta del archivo JSON que contiene la lista de usuarios.</param>
        /// <returns>La lista de usuarios le�da desde el archivo JSON.</returns>
        private List<Usuario> LeerUsuariosDesdeJSON(string archivo)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    // Leer y deserializar la lista de usuarios desde un archivo JSON.
                    string jsonString = reader.ReadToEnd();
                    return JsonSerializer.Deserialize<List<Usuario>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}");
                return new List<Usuario>();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}