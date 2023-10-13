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
    public partial class Personal : Form
    {
        ConvocarJugador jugador;
        public Personal(ConvocarJugador jugador)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.jugador = jugador;
        }

        private void btnJugador_Click(object sender, EventArgs e)
        {
            Jugador(jugador);
        }

        public void Jugador(ConvocarJugador jugador)
        {
            jugador.ShowDialog();

            this.Close();
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {

        }
    }
}
