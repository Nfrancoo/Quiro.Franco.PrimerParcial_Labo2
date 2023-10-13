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
        public Jugador NuevoJugador;
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

            // Verificar si el país ingresado es válido
            if (!EsPaisValido(paisInput))
            {
                MessageBox.Show("Por favor, ingrese un país válido.");
                return; // Detener el proceso si el país no es válido
            }
            EPaises pais = (EPaises)Enum.Parse(typeof(EPaises), paisInput);

            // Verificar si la posición ingresada es válida
            if (!Enum.TryParse(posicionInput, out EPosicion posicion))
            {
                MessageBox.Show("Por favor, ingrese una posición válida.");
                return; // Detener el proceso si la posición no es válida
            }

            // Crear el nuevo jugador
            NuevoJugador = new Jugador(edad, nombre, apellido, pais, dorsal, posicion);



            // Establecer el resultado del formulario como "Aceptar"
            this.DialogResult = DialogResult.OK;

            // Agregar al jugador a la lista correspondiente según su país
            switch (pais)
            {
                case EPaises.Argentina:
                    FormPrincipal.jugadoresArgentina.Add(NuevoJugador);
                    break;
                case EPaises.Brasil:
                    FormPrincipal.jugadoresBrasil.Add(NuevoJugador);
                    break;
                case EPaises.Italia:
                    FormPrincipal.jugadoresItalia.Add(NuevoJugador);
                    break;
                case EPaises.Alemania:
                    FormPrincipal.jugadoresAlemania.Add(NuevoJugador);
                    break;
                case EPaises.Francia:
                    FormPrincipal.jugadoresFrancia.Add(NuevoJugador);
                    break;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool EsPaisValido(string inputPais)
        {
            return Enum.IsDefined(typeof(EPaises), inputPais);
        }
    }
}
