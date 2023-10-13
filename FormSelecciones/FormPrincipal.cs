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
        public static List<Jugador> jugadoresBrasil = new List<Jugador>();
        public static List<Jugador> jugadoresArgentina = new List<Jugador>();
        public static List<Jugador> jugadoresItalia = new List<Jugador>();
        public static List<Jugador> jugadoresAlemania = new List<Jugador>();
        public static List<Jugador> jugadoresFrancia = new List<Jugador>();

        public FormPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbPaises.DataSource = Enum.GetValues(typeof(EPaises));

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //Inicializa los ListBox y oculta todos excepto uno
            lstArgentina.Visible = false;
            lstFrancia.Visible = false;
            lstBrasil.Visible = false;
            lstItalia.Visible = false;
            lstAlemania.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConvocarJugador convocarForm = new ConvocarJugador();
            using (Personal personal = new Personal(convocarForm))
            {
                personal.ShowDialog();

                if (convocarForm.DialogResult == DialogResult.OK)
                {
                    Jugador nuevoJugador = convocarForm.NuevoJugador;

                    switch (nuevoJugador.Pais)
                    {
                        case EPaises.Brasil:
                            jugadoresBrasil.Add(nuevoJugador);
                            lstBrasil.Items.Add(nuevoJugador); // Agregar al ListBox de Brasil
                            break;
                        case EPaises.Argentina:
                            jugadoresArgentina.Add(nuevoJugador);
                            lstArgentina.Items.Add(nuevoJugador); // Agregar al ListBox de Argentina
                            break;
                        case EPaises.Italia:
                            jugadoresItalia.Add(nuevoJugador);
                            lstItalia.Items.Add(nuevoJugador); // Agregar al ListBox de Italia
                            break;
                        case EPaises.Alemania:
                            jugadoresAlemania.Add(nuevoJugador);
                            lstAlemania.Items.Add(nuevoJugador); // Agregar al ListBox de Alemania
                            break;
                        case EPaises.Francia:
                            jugadoresFrancia.Add(nuevoJugador);
                            lstFrancia.Items.Add(nuevoJugador); // Agregar al ListBox de Francia
                            break;
                    }
                }
            }
        }

        private void cmbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedItem != null)
            {
                // Oculta todos los ListBox
                lstArgentina.Visible = false;
                lstBrasil.Visible = false;
                lstAlemania.Visible = false;
                lstFrancia.Visible = false;
                lstItalia.Visible = false;

                // Muestra el ListBox correspondiente al país seleccionado
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;
                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        lstArgentina.Visible = true;
                        break;
                    case EPaises.Brasil:
                        lstBrasil.Visible = true;
                        break;
                    case EPaises.Italia:
                        lstItalia.Visible = true;
                        break;
                    case EPaises.Francia:
                        lstFrancia.Visible = true;
                        break;
                    case EPaises.Alemania:
                        lstAlemania.Visible = true;
                        break;
                }
            }
        }

        private void FormPrincipal_Leave(object sender, EventArgs e)
        {
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void ManejarListas(ListBox pepe = null)
        {

            ConvocarJugador convocarForm = new ConvocarJugador();
            using (Personal personal = new Personal(convocarForm))
            {
                personal.ShowDialog();

                if (convocarForm.DialogResult == DialogResult.OK)
                {
                    Jugador nuevoJugador = convocarForm.NuevoJugador;

                    if (pepe != null)
                    {
                        switch (nuevoJugador.Pais)
                        {
                            case EPaises.Brasil:
                                jugadoresBrasil.Add(nuevoJugador);
                                pepe.Items.Add(nuevoJugador); // Agregar al ListBox de Brasil
                                break;
                            case EPaises.Argentina:
                                jugadoresArgentina.Add(nuevoJugador);
                                lstArgentina.Items.Add(nuevoJugador); // Agregar al ListBox de Argentina
                                break;
                            case EPaises.Italia:
                                jugadoresItalia.Add(nuevoJugador);
                                lstItalia.Items.Add(nuevoJugador); // Agregar al ListBox de Italia
                                break;
                            case EPaises.Alemania:
                                jugadoresAlemania.Add(nuevoJugador);
                                lstAlemania.Items.Add(nuevoJugador); // Agregar al ListBox de Alemania
                                break;
                            case EPaises.Francia:
                                jugadoresFrancia.Add(nuevoJugador);
                                lstFrancia.Items.Add(nuevoJugador); // Agregar al ListBox de Francia
                                break;
                        }
                    }
                    
                }
            }
        }
    }
}



