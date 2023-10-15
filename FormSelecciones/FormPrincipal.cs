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
using System.IO;
using System.Text.Json;

namespace FormSelecciones
{
    public partial class FormPrincipal : Form
    {
        public List<PersonalEquipoSeleccion> personalBrasil = new List<PersonalEquipoSeleccion>();
        public List<PersonalEquipoSeleccion> personalArgentina = new List<PersonalEquipoSeleccion>();
        public List<PersonalEquipoSeleccion> personalItalia = new List<PersonalEquipoSeleccion>();
        public List<PersonalEquipoSeleccion> personalAlemania = new List<PersonalEquipoSeleccion>();
        public List<PersonalEquipoSeleccion> personalFrancia = new List<PersonalEquipoSeleccion>();

        public FormPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbPaises.DataSource = Enum.GetValues(typeof(EPaises));
            this.Click += FormPrincipal_Click;

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (File.Exists("./personal.json"))
            {
                using (StreamReader reader = new StreamReader("./personal.json"))
                {
                    string jsonString = reader.ReadToEnd();

                    this.listaDeListas = (List<List<PersonalEquipoSeleccion>>)JsonSerializer.Deserialize(jsonString, typeof(List<List < PersonalEquipoSeleccion>>));
                }
            }

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
                            lstBrasilEntrenador.Items.Add(entrenador);
                            break;
                        case EPaises.Argentina:
                            personalArgentina.Add(entrenador);
                            lstArgentinaEntrenador.Items.Add(entrenador);
                            break;
                        case EPaises.Italia:
                            personalItalia.Add(entrenador);
                            lstItaliaEntrenador.Items.Add(entrenador);
                            break;
                        case EPaises.Alemania:
                            personalAlemania.Add(entrenador);
                            lstAlemaniaEntrenador.Items.Add(entrenador);
                            break;
                        case EPaises.Francia:
                            personalFrancia.Add(entrenador);
                            lstFranciaEntrenador.Items.Add(entrenador);
                            break;
                    }
                }
                else if (personalForm.nuevoMasajista is Masajista masajista)
                {
                    switch (masajista.Pais)
                    {
                        case EPaises.Brasil:
                            personalBrasil.Add(masajista);
                            lstBrasilMasajeador.Items.Add(masajista);
                            break;
                        case EPaises.Argentina:
                            personalArgentina.Add(masajista);
                            lstArgentinaMasajeador.Items.Add(masajista);
                            break;
                        case EPaises.Italia:
                            personalItalia.Add(masajista);
                            lstItaliaMasajeador.Items.Add(masajista);
                            break;
                        case EPaises.Alemania:
                            personalAlemania.Add(masajista);
                            lstAlemaniaMasajeador.Items.Add(masajista);
                            break;
                        case EPaises.Francia:
                            personalFrancia.Add(masajista);
                            lstFranciaMasajeador.Items.Add(masajista);
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
                lstArgentinaEntrenador.Visible = false;
                lstBrasilEntrenador.Visible = false;
                lstAlemaniaEntrenador.Visible = false;
                lstFranciaEntrenador.Visible = false;
                lstItaliaEntrenador.Visible = false;
                lstArgentinaMasajeador.Visible = false;
                lstBrasilMasajeador.Visible = false;
                lstItaliaMasajeador.Visible = false;
                lstFranciaMasajeador.Visible = false;
                lstAlemaniaMasajeador.Visible = false;

                // Muestra el ListBox correspondiente al país seleccionado
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;
                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        CambiarVisualizacion(lstArgentina, lstArgentinaEntrenador, lstArgentinaMasajeador);
                        break;
                    case EPaises.Brasil:
                        CambiarVisualizacion(lstBrasil, lstBrasilEntrenador, lstBrasilMasajeador);
                        break;
                    case EPaises.Italia:
                        CambiarVisualizacion(lstItalia, lstItaliaEntrenador, lstItaliaMasajeador);
                        break;
                    case EPaises.Francia:
                        CambiarVisualizacion(lstFrancia, lstFranciaEntrenador, lstFranciaMasajeador);
                        break;
                    case EPaises.Alemania:
                        CambiarVisualizacion(lstAlemania, lstAlemaniaEntrenador, lstAlemaniaMasajeador);
                        break;
                }
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(this.listaDeListas);
            using (StreamWriter writer = new StreamWriter("./personal.json"))
            {
                writer.WriteLine(jsonString);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (cmbPaises.SelectedItem != null)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        if (lstArgentina.SelectedIndex != -1)
                        {
                            lstArgentina.Items.RemoveAt(lstArgentina.SelectedIndex);
                        }
                        if (lstArgentinaEntrenador.SelectedIndex != -1)
                        {
                            lstArgentinaEntrenador.Items.RemoveAt(lstArgentinaEntrenador.SelectedIndex);
                        }
                        if (lstArgentinaMasajeador.SelectedIndex != -1)
                        {
                            lstArgentinaMasajeador.Items.RemoveAt(lstArgentinaMasajeador.SelectedIndex);
                        }
                        break;
                    case EPaises.Brasil:
                        if (lstBrasil.SelectedIndex != -1)
                        {
                            lstBrasil.Items.RemoveAt(lstBrasil.SelectedIndex);
                        }
                        if (lstBrasilEntrenador.SelectedIndex != -1)
                        {
                            lstBrasilEntrenador.Items.RemoveAt(lstBrasilEntrenador.SelectedIndex);
                        }
                        if (lstBrasilMasajeador.SelectedIndex != -1)
                        {
                            lstBrasilMasajeador.Items.RemoveAt(lstBrasilMasajeador.SelectedIndex);
                        }
                        break;
                    case EPaises.Italia:
                        if (lstItalia.SelectedIndex != -1)
                        {
                            lstItalia.Items.RemoveAt(lstItalia.SelectedIndex);
                        }
                        if (lstItaliaEntrenador.SelectedIndex != -1)
                        {
                            lstItaliaEntrenador.Items.RemoveAt(lstItaliaEntrenador.SelectedIndex);
                        }
                        if (lstItaliaMasajeador.SelectedIndex != -1)
                        {
                            lstItaliaMasajeador.Items.RemoveAt(lstItaliaMasajeador.SelectedIndex);
                        }
                        break;
                    case EPaises.Francia:
                        if (lstFrancia.SelectedIndex != -1)
                        {
                            lstFrancia.Items.RemoveAt(lstFrancia.SelectedIndex);
                        }
                        if (lstFranciaEntrenador.SelectedIndex != -1)
                        {
                            lstFranciaEntrenador.Items.RemoveAt(lstFranciaEntrenador.SelectedIndex);
                        }
                        if (lstFranciaMasajeador.SelectedIndex != -1)
                        {
                            lstFranciaMasajeador.Items.RemoveAt(lstFranciaMasajeador.SelectedIndex);
                        }
                        break;
                    case EPaises.Alemania:
                        if (lstAlemania.SelectedIndex != -1)
                        {
                            lstAlemania.Items.RemoveAt(lstAlemania.SelectedIndex);
                        }
                        if (lstAlemaniaEntrenador.SelectedIndex != -1)
                        {
                            lstAlemaniaEntrenador.Items.RemoveAt(lstAlemaniaEntrenador.SelectedIndex);
                        }
                        if (lstAlemaniaMasajeador.SelectedIndex != -1)
                        {
                            lstAlemaniaMasajeador.Items.RemoveAt(lstAlemaniaMasajeador.SelectedIndex);
                        }
                        break;
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedItem != null)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        if (lstArgentina.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstArgentina, personalArgentina);
                        }

                        if (lstArgentinaEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstArgentinaEntrenador, personalArgentina);
                        }
                        if (lstArgentinaMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstArgentinaMasajeador, personalArgentina);
                        }
                        break;
                    case EPaises.Brasil:
                        if (lstBrasil.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstBrasil, personalBrasil);
                        }
                        if (lstBrasilEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstBrasilEntrenador, personalBrasil);
                        }
                        if (lstBrasilMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstBrasilMasajeador, personalBrasil);
                        }
                        break;
                    case EPaises.Italia:
                        if (lstItalia.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstItalia, personalItalia);
                        }
                        if (lstItaliaEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstItaliaEntrenador, personalItalia);
                        }
                        if (lstItaliaMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstItaliaMasajeador, personalItalia);
                        }
                        break;
                    case EPaises.Francia:
                        if (lstFrancia.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstFrancia, personalFrancia);
                        }
                        if (lstFranciaEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstFranciaEntrenador, personalFrancia);
                        }
                        if (lstFranciaMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstFranciaMasajeador, personalFrancia);
                        }
                        break;
                    case EPaises.Alemania:
                        if (lstAlemania.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstAlemania, personalAlemania);
                        }
                        if (lstAlemaniaEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstAlemaniaEntrenador, personalAlemania);
                        }
                        if (lstAlemaniaMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstAlemaniaMasajeador, personalAlemania);
                        }
                        break;
                }
            }
        }

        private void FormPrincipal_Click(object sender, EventArgs e)
        {
            lstArgentina.ClearSelected();
            lstBrasil.ClearSelected();
            lstItalia.ClearSelected();
            lstFrancia.ClearSelected();
            lstAlemania.ClearSelected();
            lstArgentinaEntrenador.ClearSelected();
            lstBrasilEntrenador.ClearSelected();
            lstItaliaEntrenador.ClearSelected();
            lstFranciaEntrenador.ClearSelected();
            lstAlemaniaEntrenador.ClearSelected();
            lstArgentinaMasajeador.ClearSelected();
            lstBrasilMasajeador.ClearSelected();
            lstItaliaMasajeador.ClearSelected();
            lstFranciaMasajeador.ClearSelected();
            lstAlemaniaMasajeador.ClearSelected();
        }

        private void CambiarVisualizacion(ListBox lst1, ListBox lst2, ListBox lst3)
        {
            lst1.Visible = true;
            lst2.Visible = true;
            lst3.Visible = true;
        }

        private void ModificarListJugador(ListBox lst, List<PersonalEquipoSeleccion> personal)
        {
            // Abre un formulario de edición para el jugador seleccionado

            Jugador jugadorSeleccionado = (Jugador)lst.SelectedItem;
            ConvocarJugador editarJugadorForm = new ConvocarJugador(jugadorSeleccionado);

            // Pasa el jugador seleccionado al formulario de edición
            editarJugadorForm.JugadorParaEditar = jugadorSeleccionado;

            editarJugadorForm.ShowDialog();

            if (editarJugadorForm.DialogResult == DialogResult.OK)
            {
                // Obtén el jugador modificado del formulario de edición
                Jugador jugadorModificado = editarJugadorForm.NuevoJugador;

                // Actualiza la lista con los cambios realizados por el usuario
                int selectedIndex = lst.SelectedIndex;

                // Actualiza el jugador en la lista y la ListBox
                personal[selectedIndex] = jugadorModificado;
                lst.Items[selectedIndex] = jugadorModificado;
            }
        }

        private void ModificarListEntrenador(ListBox lst, List<PersonalEquipoSeleccion> personal)
        {
            Entrenador entrenadorSeleccionado = (Entrenador)lst.SelectedItem;
            ConvocarEntrenador editarEntrenadorForm = new ConvocarEntrenador(entrenadorSeleccionado);

            editarEntrenadorForm.EntrendorParaEditar = entrenadorSeleccionado;

            editarEntrenadorForm.ShowDialog();

            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
            {
                Entrenador entrenadorModificado = editarEntrenadorForm.NuevoEntrenador;

                int selectedIndex = lst.SelectedIndex;

                personal[selectedIndex] = entrenadorModificado;
                lst.Items[selectedIndex] = entrenadorModificado;
            }
        }

        private void ModificarListMasajeador(ListBox lst, List<PersonalEquipoSeleccion> personal)
        {
            // Abre un formulario de edición para el jugador seleccionado

            Masajista masajistaSeleccionado = (Masajista)lst.SelectedItem;
            ConvocarMasajista editarEntrenadorForm = new ConvocarMasajista(masajistaSeleccionado);

            // Pasa el jugador seleccionado al formulario de edición
            editarEntrenadorForm.MasajeadorParaEditar = masajistaSeleccionado;

            editarEntrenadorForm.ShowDialog();

            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
            {
                // Obtén el jugador modificado del formulario de edición
                Masajista entrenadorModificado = editarEntrenadorForm.NuevoMasajista;

                // Actualiza la lista con los cambios realizados por el usuario
                int selectedIndex = lst.SelectedIndex;

                // Actualiza el jugador en la lista y la ListBox
                personal[selectedIndex] = entrenadorModificado;
                lst.Items[selectedIndex] = entrenadorModificado;
            }
        }       
    }
}



