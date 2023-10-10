using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimerParcial;

namespace FormSelecciones
{
    public partial class FormPrincipal : Form
    {
        private List<Jugador> jugadores = new List<Jugador>();
        private BindingSource bindingSource = new BindingSource();
        public FormPrincipal()
        {
            InitializeComponent();
            lstJugadores.DataSource = bindingSource;
            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Convocar convocarForm = new Convocar())
            {
                DialogResult result = convocarForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Jugador nuevoJugador = convocarForm.NuevoJugador;

                    jugadores.Add(nuevoJugador);

                    // Actualizar el ComboBox y el ListBox en FormPrincipal
                    LlenarComboBoxNacionalidades();
                    cmbPaises_SelectedIndexChanged(null, null); // Forzar la actualización del ListBox
                }
            }
        }
        private void LlenarComboBoxNacionalidades()
        {
            // Obtener las nacionalidades únicas de la lista de jugadores y convertirlas en una lista de cadenas
            var nacionalidades = jugadores.Select(jugador => jugador.Pais.ToString()).Distinct().ToList();

            // Asignar la lista de nacionalidades al ListBox
            lstJugadores.DataSource = nacionalidades;
        }

        private void cmbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedItem == null)
            {
                return; // No hacer nada si no hay un elemento seleccionado
            }

            string paisSeleccionado = (string)cmbPaises.SelectedItem;

            // Convierte la cadena seleccionada en un valor enumerado EPaises
            if (Enum.TryParse(paisSeleccionado, out EPaises nacionalidadSeleccionada))
            {
                List<Jugador> jugadoresFiltrados = jugadores.Where(jugador => jugador.Pais == nacionalidadSeleccionada).ToList();

                lstJugadores.DataSource = null; // Limpia cualquier origen de datos existente
                lstJugadores.DataSource = jugadoresFiltrados; // Asigna la lista de jugadores filtrados directamente
                lstJugadores.DisplayMember = "Nombre"; // Cambia "Nombre" por la propiedad que desees mostrar en el ListBox
            }

        }
    }
}



