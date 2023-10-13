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

    public partial class Personal : Form
    {
        public Jugador nuevoJugador;
        public Entrenador nuevoEntrenador;
        FormPrincipal principal = new FormPrincipal();

        public Personal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnJugador_Click(object sender, EventArgs e)
        {

            principal.convocarJugadorSeleccionado = true;
            ConvocarJugador jugador = new ConvocarJugador();
            jugador.ShowDialog();

            if (jugador.DialogResult == DialogResult.OK)
            {
                nuevoJugador = jugador.NuevoJugador;
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            principal.convocarJugadorSeleccionado = false;
            ConvocarEntrenador entrenador = new ConvocarEntrenador();
            entrenador.ShowDialog();

            if (entrenador.DialogResult == DialogResult.OK)
            {
                nuevoEntrenador = entrenador.NuevoEntrenador;
                this.DialogResult = DialogResult.OK; // Establece DialogResult en OK
            }
            else
            {
                this.DialogResult = DialogResult.Cancel; // Establece DialogResult en Cancel si se presiona el botón Cancelar
            }

            this.Close();
        }
    }
}
