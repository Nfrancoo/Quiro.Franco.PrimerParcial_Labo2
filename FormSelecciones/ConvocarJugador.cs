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
    public partial class ConvocarJugador : Form
    {
        public Jugador JugadorParaEditar { get; set; }
        public Jugador NuevoJugador;

        public ConvocarJugador(Jugador jug)
        {
            InitializeComponent();
             this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            Modificador(jug);
        }
        public ConvocarJugador()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
        }

        private void label5_Click(object sender, EventArgs e)
        {

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

            if (!int.TryParse(this.txtDorsal.Text, out int dorsal))
            {
                MessageBox.Show("El valor ingresado en el campo de dorsal no es válido.");
                return;
            }

            string paisInput = this.txtPais.Text;
            string posicionInput = this.txtPosicion.Text;

            if (!EsPaisValido(paisInput))
            {
                MessageBox.Show("Por favor, ingrese un país válido.");
                return;
            }
            EPaises pais = (EPaises)Enum.Parse(typeof(EPaises), paisInput);

            // Verificar si la posición ingresada es válida
            if (!Enum.TryParse(posicionInput, out EPosicion posicion))
            {
                MessageBox.Show("Por favor, ingrese una posición válida.");
                return;
            }

            NuevoJugador = new Jugador(edad, nombre, apellido, pais, dorsal, posicion);
 

            this.DialogResult |= DialogResult.OK;


        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void Modificador(Jugador jug)
        {
            this.txtApellido.Text = jug.Apellido;
            this.txtNombre.Text = jug.Nombre;
            this.txtEdad.Text = jug.Edad.ToString();
            this.txtDorsal.Text = jug.Dorsal.ToString();
            this.txtPais.Text = jug.Pais.ToString();
            this.txtPosicion.Text = jug.Posicion.ToString();
            this.txtApellido.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtPais.Enabled = false;
        }

        private bool EsPaisValido(string inputPais)
        {
            return Enum.IsDefined(typeof(EPaises), inputPais);
        }
    }
}
