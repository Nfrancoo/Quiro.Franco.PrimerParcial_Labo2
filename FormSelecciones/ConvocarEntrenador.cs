using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimerParcial;

namespace FormSelecciones
{
    public partial class ConvocarEntrenador : Form
    {
        public Entrenador NuevoEntrenador;
        public ConvocarEntrenador()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
        }

        private void button1_Click(object sender, EventArgs e)
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

            string tactica = this.txtTactica.Text;
            if (string.IsNullOrEmpty(tactica))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de tactica.");
                return;
            }

            if (!int.TryParse(this.txtEdad.Text, out int edad))
            {
                MessageBox.Show("El valor ingresado en el campo de edad no es válido.");
                return;
            }

            string paisInput = this.txtPais.Text;
            if (!EsPaisValido(paisInput))
            {
                MessageBox.Show("Por favor, ingrese un país válido.");
                return; // Detener el proceso si el país no es válido
            }

            EPaises pais = (EPaises)Enum.Parse(typeof(EPaises), paisInput);


            NuevoEntrenador = new Entrenador(edad, nombre, apellido, pais, tactica);

            this.DialogResult = DialogResult.OK;
        }
        private bool EsPaisValido(string inputPais)
        {
            return Enum.IsDefined(typeof(EPaises), inputPais);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
        }
    }
}
