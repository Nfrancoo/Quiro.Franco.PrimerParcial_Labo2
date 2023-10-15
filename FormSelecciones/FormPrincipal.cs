﻿using System;
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
    public partial class FormPrincipal : Form
    {
        public static List<PersonalEquipoSeleccion> personalBrasil = new List<PersonalEquipoSeleccion>();
        public static List<PersonalEquipoSeleccion> personalArgentina = new List<PersonalEquipoSeleccion>();
        public static List<PersonalEquipoSeleccion> personalItalia = new List<PersonalEquipoSeleccion>();
        public static List<PersonalEquipoSeleccion> personalAlemania = new List<PersonalEquipoSeleccion>();
        public static List<PersonalEquipoSeleccion> personalFrancia = new List<PersonalEquipoSeleccion>();

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
                        lstArgentina.Visible = true;
                        lstArgentinaEntrenador.Visible = true;
                        lstArgentinaMasajeador.Visible = true;
                        break;
                    case EPaises.Brasil:
                        lstBrasil.Visible = true;
                        lstBrasilEntrenador.Visible = true;
                        lstBrasilMasajeador.Visible = true;
                        break;
                    case EPaises.Italia:
                        lstItalia.Visible = true;
                        lstItaliaEntrenador.Visible = true;
                        lstItaliaMasajeador.Visible = true;
                        break;
                    case EPaises.Francia:
                        lstFrancia.Visible = true;
                        lstFranciaEntrenador.Visible = true;
                        lstFranciaMasajeador.Visible = true;
                        break;
                    case EPaises.Alemania:
                        lstAlemania.Visible = true;
                        lstAlemaniaEntrenador.Visible = true;
                        lstAlemaniaMasajeador.Visible = true;
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
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Jugador jugadorSeleccionado = (Jugador)lstArgentina.SelectedItem;
                            ConvocarJugador editarJugadorForm = new ConvocarJugador(jugadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarJugadorForm.JugadorParaEditar = jugadorSeleccionado;

                            editarJugadorForm.ShowDialog();

                            if (editarJugadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Jugador jugadorModificado = editarJugadorForm.NuevoJugador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstArgentina.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalArgentina[selectedIndex] = jugadorModificado;
                                lstArgentina.Items[selectedIndex] = jugadorModificado;
                            }
                        }
                        if (lstArgentinaEntrenador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Entrenador entrenadorSeleccionado = (Entrenador)lstArgentinaEntrenador.SelectedItem;
                            ConvocarEntrenador editarEntrenadorForm = new ConvocarEntrenador(entrenadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarEntrenadorForm.EntrenadorParaEditar = entrenadorSeleccionado;

                            editarEntrenadorForm.ShowDialog();

                            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Entrenador entrenadorModificado = editarEntrenadorForm.NuevoEntrenador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstArgentinaEntrenador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalArgentina[selectedIndex] = entrenadorModificado;
                                lstArgentinaEntrenador.Items[selectedIndex] = entrenadorModificado;
                            }
                        }
                        if (lstArgentinaMasajeador.SelectedIndex != -1)
                        {

                            // Abre un formulario de edición para el jugador seleccionado
                            Masajista masajeadorSeleccionado = (Masajista)lstArgentinaMasajeador.SelectedItem;
                            ConvocarMasajista editarMasajeadorForm = new ConvocarMasajista(masajeadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarMasajeadorForm.MasajeadorParaEditar = masajeadorSeleccionado;

                            editarMasajeadorForm.ShowDialog();

                            if (editarMasajeadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Masajista masajeadorModificado = editarMasajeadorForm.NuevoMasajista;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstArgentinaMasajeador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalArgentina[selectedIndex] = masajeadorModificado;
                                lstArgentinaMasajeador.Items[selectedIndex] = masajeadorModificado;
                            }
                        }
                        break;
                    case EPaises.Brasil:
                        if (lstBrasil.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Jugador jugadorSeleccionado = (Jugador)lstBrasil.SelectedItem;
                            ConvocarJugador editarJugadorForm = new ConvocarJugador(jugadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarJugadorForm.JugadorParaEditar = jugadorSeleccionado;

                            editarJugadorForm.ShowDialog();

                            if (editarJugadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Jugador jugadorModificado = editarJugadorForm.NuevoJugador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstBrasil.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalBrasil[selectedIndex] = jugadorModificado;
                                lstBrasil.Items[selectedIndex] = jugadorModificado;
                            }
                        }
                        if (lstBrasilEntrenador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado

                            Entrenador entrenadorSeleccionado = (Entrenador)lstBrasilEntrenador.SelectedItem;
                            ConvocarEntrenador editarEntrenadorForm = new ConvocarEntrenador(entrenadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarEntrenadorForm.EntrenadorParaEditar = entrenadorSeleccionado;

                            editarEntrenadorForm.ShowDialog();

                            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Entrenador entrenadorModificado = editarEntrenadorForm.NuevoEntrenador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstBrasilEntrenador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalBrasil[selectedIndex] = entrenadorModificado;
                                lstBrasilEntrenador.Items[selectedIndex] = entrenadorModificado;
                            }
                        }
                        if (lstBrasilMasajeador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Masajista masajeadorSeleccionado = (Masajista)lstBrasilMasajeador.SelectedItem;
                            ConvocarMasajista editarMasajeadorForm = new ConvocarMasajista(masajeadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarMasajeadorForm.MasajeadorParaEditar = masajeadorSeleccionado;

                            editarMasajeadorForm.ShowDialog();

                            if (editarMasajeadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Masajista masajeadorModificado = editarMasajeadorForm.NuevoMasajista;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstBrasilMasajeador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalBrasil[selectedIndex] = masajeadorModificado;
                                lstBrasilMasajeador.Items[selectedIndex] = masajeadorModificado;
                            }
                        }
                        break;
                    case EPaises.Italia:
                        if (lstItalia.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Jugador jugadorSeleccionado = (Jugador)lstItalia.SelectedItem;
                            ConvocarJugador editarJugadorForm = new ConvocarJugador(jugadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarJugadorForm.JugadorParaEditar = jugadorSeleccionado;

                            editarJugadorForm.ShowDialog();

                            if (editarJugadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Jugador jugadorModificado = editarJugadorForm.NuevoJugador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstItalia.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalItalia[selectedIndex] = jugadorModificado;
                                lstItalia.Items[selectedIndex] = jugadorModificado;
                            }
                        }
                        if (lstItaliaEntrenador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Entrenador entrenadorSeleccionado = (Entrenador)lstItaliaEntrenador.SelectedItem;
                            ConvocarEntrenador editarEntrenadorForm = new ConvocarEntrenador(entrenadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarEntrenadorForm.EntrenadorParaEditar = entrenadorSeleccionado;

                            editarEntrenadorForm.ShowDialog();

                            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Entrenador entrenadorModificado = editarEntrenadorForm.NuevoEntrenador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstItaliaEntrenador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalItalia[selectedIndex] = entrenadorModificado;
                                lstItaliaEntrenador.Items[selectedIndex] = entrenadorModificado;
                            }
                        }
                        if (lstItaliaMasajeador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Masajista masajeadorSeleccionado = (Masajista)lstItaliaMasajeador.SelectedItem;
                            ConvocarMasajista editarMasajeadorForm = new ConvocarMasajista(masajeadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarMasajeadorForm.MasajeadorParaEditar = masajeadorSeleccionado;

                            editarMasajeadorForm.ShowDialog();

                            if (editarMasajeadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Masajista masajeadorModificado = editarMasajeadorForm.NuevoMasajista;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstItaliaMasajeador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalItalia[selectedIndex] = masajeadorModificado;
                                lstItaliaMasajeador.Items[selectedIndex] = masajeadorModificado;
                            }
                        }
                        break;
                    case EPaises.Francia:
                        if (lstFrancia.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Jugador jugadorSeleccionado = (Jugador)lstFrancia.SelectedItem;
                            ConvocarJugador editarJugadorForm = new ConvocarJugador(jugadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarJugadorForm.JugadorParaEditar = jugadorSeleccionado;

                            editarJugadorForm.ShowDialog();

                            if (editarJugadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Jugador jugadorModificado = editarJugadorForm.NuevoJugador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstFrancia.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalFrancia[selectedIndex] = jugadorModificado;
                                lstFrancia.Items[selectedIndex] = jugadorModificado;
                            }
                        }
                        if (lstFranciaEntrenador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Entrenador entrenadorSeleccionado = (Entrenador)lstFranciaEntrenador.SelectedItem;
                            ConvocarEntrenador editarEntrenadorForm = new ConvocarEntrenador(entrenadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarEntrenadorForm.EntrenadorParaEditar = entrenadorSeleccionado;

                            editarEntrenadorForm.ShowDialog();

                            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Entrenador entrenadorModificado = editarEntrenadorForm.NuevoEntrenador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstFranciaEntrenador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalFrancia[selectedIndex] = entrenadorModificado;
                                lstFranciaEntrenador.Items[selectedIndex] = entrenadorModificado;
                            }
                        }
                        if (lstFranciaMasajeador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Masajista masajeadorSeleccionado = (Masajista)lstFranciaMasajeador.SelectedItem;
                            ConvocarMasajista editarMasajeadorForm = new ConvocarMasajista(masajeadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarMasajeadorForm.MasajeadorParaEditar = masajeadorSeleccionado;

                            editarMasajeadorForm.ShowDialog();

                            if (editarMasajeadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Masajista masajeadorModificado = editarMasajeadorForm.NuevoMasajista;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstFranciaMasajeador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalFrancia[selectedIndex] = masajeadorModificado;
                                lstFranciaMasajeador.Items[selectedIndex] = masajeadorModificado;
                            }
                        }
                        break;
                    case EPaises.Alemania:
                        if (lstAlemania.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Jugador jugadorSeleccionado = (Jugador)lstAlemania.SelectedItem;
                            ConvocarJugador editarJugadorForm = new ConvocarJugador(jugadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarJugadorForm.JugadorParaEditar = jugadorSeleccionado;

                            editarJugadorForm.ShowDialog();

                            if (editarJugadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Jugador jugadorModificado = editarJugadorForm.NuevoJugador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstAlemania.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalAlemania[selectedIndex] = jugadorModificado;
                                lstAlemania.Items[selectedIndex] = jugadorModificado;
                            }
                        }
                        if (lstAlemaniaEntrenador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Entrenador entrenadorSeleccionado = (Entrenador)lstAlemaniaEntrenador.SelectedItem;
                            ConvocarEntrenador editarEntrenadorForm = new ConvocarEntrenador(entrenadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarEntrenadorForm.EntrenadorParaEditar = entrenadorSeleccionado;

                            editarEntrenadorForm.ShowDialog();

                            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Entrenador entrenadorModificado = editarEntrenadorForm.NuevoEntrenador;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstAlemaniaEntrenador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalAlemania[selectedIndex] = entrenadorModificado;
                                lstAlemaniaEntrenador.Items[selectedIndex] = entrenadorModificado;
                            }
                        }
                        if (lstAlemaniaMasajeador.SelectedIndex != -1)
                        {
                            // Abre un formulario de edición para el jugador seleccionado
                            
                            Masajista masajeadorSeleccionado = (Masajista)lstAlemaniaMasajeador.SelectedItem;
                            ConvocarMasajista editarMasajeadorForm = new ConvocarMasajista(masajeadorSeleccionado);

                            // Pasa el jugador seleccionado al formulario de edición
                            editarMasajeadorForm.MasajeadorParaEditar = masajeadorSeleccionado;

                            editarMasajeadorForm.ShowDialog();

                            if (editarMasajeadorForm.DialogResult == DialogResult.OK)
                            {
                                // Obtén el jugador modificado del formulario de edición
                                Masajista masajeadorModificado = editarMasajeadorForm.NuevoMasajista;

                                // Actualiza la lista con los cambios realizados por el usuario
                                int selectedIndex = lstAlemaniaMasajeador.SelectedIndex;

                                // Actualiza el jugador en la lista y la ListBox
                                personalAlemania[selectedIndex] = masajeadorModificado;
                                lstAlemaniaMasajeador.Items[selectedIndex] = masajeadorModificado;
                            }
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
    }
}



