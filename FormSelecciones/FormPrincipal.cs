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
        public static List<GenteEquipoSeleccion> personalBrasil = new List<GenteEquipoSeleccion>();
        public static List<GenteEquipoSeleccion> personalArgentina = new List<GenteEquipoSeleccion>();
        public static List<GenteEquipoSeleccion> personalItalia = new List<GenteEquipoSeleccion>();
        public static List<GenteEquipoSeleccion> personalAlemania = new List<GenteEquipoSeleccion>();
        public static List<GenteEquipoSeleccion> personalFrancia = new List<GenteEquipoSeleccion>();
        public bool convocarJugadorSeleccionado = true;

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

        private void btnConvocar_Click(object sender, EventArgs e)
        {
            Personal personalForm = new Personal();
            personalForm.ShowDialog();

            if (personalForm.DialogResult == DialogResult.OK)
            {
                if (personalForm.nuevoJugador is Jugador jugador)
                {
                    // Es un jugador
                    // Agregar el nuevo jugador al ListBox y a la lista correspondiente
                    switch (jugador.Pais)
                    {
                        case EPaises.Brasil:
                            personalBrasil.Add(jugador);
                            lstBrasil.Items.Add(jugador);
                            break;
                        case EPaises.Argentina:
                            personalArgentina.Add(jugador);
                            lstArgentina.Items.Add(jugador);
                            break;
                        case EPaises.Italia:
                            personalItalia.Add(jugador);
                            lstItalia.Items.Add(jugador);
                            break;
                        case EPaises.Alemania:
                            personalAlemania.Add(jugador);
                            lstAlemania.Items.Add(jugador);
                            break;
                        case EPaises.Francia:
                            personalFrancia.Add(jugador);
                            lstFrancia.Items.Add(jugador);
                            break;
                    }
                }
                else if (personalForm.nuevoEntrenador is Entrenador entrenador)
                {
                    // Es un entrenador
                    // Agregar el nuevo entrenador al ListBox y a la lista correspondiente
                    switch (entrenador.Pais)
                    {
                        case EPaises.Brasil:
                            personalBrasil.Add(entrenador);
                            lstBrasil.Items.Add(entrenador);
                            break;
                        case EPaises.Argentina:
                            personalArgentina.Add(entrenador);
                            lstArgentina.Items.Add(entrenador);
                            break;
                        case EPaises.Italia:
                            personalItalia.Add(entrenador);
                            lstItalia.Items.Add(entrenador);
                            break;
                        case EPaises.Alemania:
                            personalAlemania.Add(entrenador);
                            lstAlemania.Items.Add(entrenador);
                            break;
                        case EPaises.Francia:
                            personalFrancia.Add(entrenador);
                            lstFrancia.Items.Add(entrenador);
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
    }
}



