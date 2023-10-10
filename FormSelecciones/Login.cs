using System.Text.Json;

namespace FormSelecciones
{
    public partial class Login : Form
    {
        private List<Usuario> usuarios;
        public Login()
        {
            InitializeComponent();
            usuarios = LeerUsuariosDesdeJSON("C://Users//User//Downloads//MOCK_DATA.json");
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private List<Usuario> LeerUsuariosDesdeJSON(string archivo)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
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

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;

            
            Usuario usuario = usuarios.Find(u => u.correo == correo && u.clave == contraseña);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido, {usuario.nombre} {usuario.apellido}. Perfil: {usuario.perfil}");
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}