using PrimerParcial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSelecciones
{
    public partial class ConvocarEntrenador : Form
    {
        public Entrenador NuevoEntrenador;
        public Entrenador EntrendorParaEditar {  get; set; }

        public ConvocarEntrenador(Entrenador jug)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            Modificador(jug);
        }
        public ConvocarEntrenador()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de nombre.");
                return;
            }

            string apellido = this.txtApellido.Text;
            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de apellido.");
                return;
            }

            if (!int.TryParse(this.txtEdad.Text, out int edad))
            {
                MessageBox.Show("El valor ingresado en el campo de edad no es válido.");
                return;
            }

            string tactica = this.txtTactica.Text;
            if (string.IsNullOrEmpty(tactica))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de tactica.");
                return;
            }

            string paisInput = this.txtPais.Text;


            // Verificar si el país ingresado es válido
            if (!EsPaisValido(paisInput))
            {
                MessageBox.Show("Por favor, ingrese un país válido.");
                return; // Detener el proceso si el país no es válido
            }
            EPaises pais = (EPaises)Enum.Parse(typeof(EPaises), paisInput);


            // Crear el nuevo entrenador
            NuevoEntrenador = new Entrenador(edad, nombre, apellido, pais, tactica);



            // Establecer el resultado del formulario como "Aceptar"
            this.DialogResult |= DialogResult.OK;

            
        }
        private bool EsPaisValido(string inputPais)
        {
            return Enum.IsDefined(typeof(EPaises), inputPais);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void Modificador(Entrenador jug)
        {
            this.txtApellido.Text = jug.Apellido;
            this.txtNombre.Text = jug.Nombre;
            this.txtEdad.Text = jug.Edad.ToString();
            this.txtPais.Text = jug.Pais.ToString();
            this.txtTactica.Text = jug.Tactica;
            this.txtApellido.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtPais.Enabled = false;
        }
    }
}
