using System.Text.Json;
using PrimerParcial;

namespace FormSelecciones
{
    public partial class Login : Form
    {
        private List<Usuario> usuarios;
        public Login()
        {
            InitializeComponent();
            usuarios = LeerUsuariosDesdeJSON(@"..//..//..//..//MOCK_DATA.json");
            this.StartPosition = FormStartPosition.CenterScreen;
            this.txtContraseña.PasswordChar = '*';

        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = this.txtCorreo.Text;
            string contraseña = this.txtContraseña.Text;

            
            Usuario usuario = usuarios.Find(u => u.correo == correo && u.clave == contraseña);


            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido, {usuario.nombre} {usuario.apellido}. Perfil: {usuario.perfil}");

                this.Hide();

                FormPrincipal formPrincipal = new FormPrincipal();

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
                MessageBox.Show("Correo o contraseña incorrectos");
            }
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

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}