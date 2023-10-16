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
using Newtonsoft.Json;


namespace FormSelecciones
{
    public partial class FormPrincipal : Form
    {
        //JUGADORES
        public List<Jugador> jugadoresArgentina = new List<Jugador>();
        public List<Jugador> jugadoresBrasil = new List<Jugador>();
        public List<Jugador> jugadoresAlemania = new List<Jugador>();
        public List<Jugador> jugadoresItalia = new List<Jugador>();
        public List<Jugador> jugadoresFrancia = new List<Jugador>();

        //ENTRENADORES
        public List<Entrenador> entrenadorArgentina = new List<Entrenador>();
        public List<Entrenador> entrenadorBrasil = new List<Entrenador>();
        public List<Entrenador> entrenadorAlemania = new List<Entrenador>();
        public List<Entrenador> entrenadorItalia = new List<Entrenador>();
        public List<Entrenador> entrenadorFrancia = new List<Entrenador>();

        //MASAJEADORES
        public List<Masajista> masajeadoresArgentina = new List<Masajista>();
        public List<Masajista> masajeadoresBrasil = new List<Masajista>();
        public List<Masajista> masajeadoresItalia = new List<Masajista>();
        public List<Masajista> masajeadoresAlemania = new List<Masajista>();
        public List<Masajista> masajeadoresFrancia = new List<Masajista>();



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
            //JUGADORES
            Deserializar("JugadorArgentina.json", ref jugadoresArgentina);
            ActualizarVisor(jugadoresArgentina, lstArgentina);
            Deserializar("JugadorBrasil.json", ref jugadoresBrasil);
            ActualizarVisor(jugadoresBrasil, lstBrasil);
            Deserializar("JugadorItalia.json", ref jugadoresItalia);
            ActualizarVisor(jugadoresItalia, lstItalia);
            Deserializar("JugadorFrancia.json", ref jugadoresFrancia);
            ActualizarVisor(jugadoresFrancia, lstFrancia);
            Deserializar("JugadorAlemania.json", ref jugadoresAlemania);
            ActualizarVisor(jugadoresAlemania, lstAlemania);

            //ENTRENADORES
            Deserializar("EntrenadorArgentina.json", ref entrenadorArgentina);
            ActualizarVisor(entrenadorArgentina, lstArgentinaEntrenador);
            Deserializar("EntrenadorBrasil.json", ref entrenadorBrasil);
            ActualizarVisor(entrenadorBrasil, lstBrasilEntrenador);
            Deserializar("EntrenadorItalia.json", ref entrenadorItalia);
            ActualizarVisor(entrenadorItalia, lstItaliaEntrenador);
            Deserializar("EntrenadorFrancia.json", ref entrenadorFrancia);
            ActualizarVisor(entrenadorFrancia, lstFranciaEntrenador);
            Deserializar("EntrenadorAlemania.json", ref entrenadorAlemania);
            ActualizarVisor(entrenadorAlemania, lstAlemaniaEntrenador);

            //MASAJISTAS
            Deserializar("MasajistaArgentina.json", ref masajeadoresArgentina);
            ActualizarVisor(masajeadoresArgentina, lstArgentinaMasajeador);
            Deserializar("MasajistaBrasil.json", ref masajeadoresBrasil);
            ActualizarVisor(masajeadoresBrasil, lstBrasilMasajeador);
            Deserializar("MasajistaItalia.json", ref masajeadoresItalia);
            ActualizarVisor(masajeadoresItalia, lstItaliaMasajeador);
            Deserializar("MasajistaFrancia.json", ref masajeadoresFrancia);
            ActualizarVisor(masajeadoresFrancia, lstFranciaMasajeador);
            Deserializar("MasajistaFrancia.json", ref masajeadoresFrancia);
            ActualizarVisor(masajeadoresAlemania, lstAlemaniaMasajeador);
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
                            jugadoresBrasil.Add(jugador);
                            lstBrasil.Items.Add(jugador);
                            break;
                        case EPaises.Argentina:
                            jugadoresArgentina.Add(jugador);
                            lstArgentina.Items.Add(jugador);
                            break;
                        case EPaises.Italia:
                            jugadoresItalia.Add(jugador);
                            lstItalia.Items.Add(jugador);
                            break;
                        case EPaises.Alemania:
                            jugadoresAlemania.Add(jugador);
                            lstAlemania.Items.Add(jugador);
                            break;
                        case EPaises.Francia:
                            jugadoresFrancia.Add(jugador);
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
                            entrenadorBrasil.Add(entrenador);
                            lstBrasilEntrenador.Items.Add(entrenador);
                            break;
                        case EPaises.Argentina:
                            entrenadorArgentina.Add(entrenador);
                            lstArgentinaEntrenador.Items.Add(entrenador);

                            break;
                        case EPaises.Italia:
                            entrenadorItalia.Add(entrenador);
                            lstItaliaEntrenador.Items.Add(entrenador);
                            break;
                        case EPaises.Alemania:
                            entrenadorAlemania.Add(entrenador);
                            lstAlemaniaEntrenador.Items.Add(entrenador);
                            break;
                        case EPaises.Francia:
                            entrenadorFrancia.Add(entrenador);
                            lstFranciaEntrenador.Items.Add(entrenador);
                            break;
                    }
                }
                else if (personalForm.nuevoMasajista is Masajista masajista)
                {
                    switch (masajista.Pais)
                    {
                        case EPaises.Brasil:
                            masajeadoresBrasil.Add(masajista);
                            lstBrasilMasajeador.Items.Add(masajista);
                            break;
                        case EPaises.Argentina:
                            masajeadoresArgentina.Add(masajista);
                            lstArgentinaMasajeador.Items.Add(masajista);
                            break;
                        case EPaises.Italia:
                            masajeadoresItalia.Add(masajista);
                            lstItaliaMasajeador.Items.Add(masajista);
                            break;
                        case EPaises.Alemania:
                            masajeadoresAlemania.Add(masajista);
                            lstAlemaniaMasajeador.Items.Add(masajista);
                            break;
                        case EPaises.Francia:
                            masajeadoresFrancia.Add(masajista);
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
                CambiarVisualizacion(lstArgentina, lstArgentinaEntrenador, lstArgentinaMasajeador, pctArgentina, false);
                CambiarVisualizacion(lstBrasil, lstBrasilEntrenador, lstBrasilMasajeador, pctBrasil, false);
                CambiarVisualizacion(lstAlemania, lstAlemaniaEntrenador, lstAlemaniaMasajeador, pctAlemania, false);
                CambiarVisualizacion(lstFrancia, lstFranciaEntrenador, lstFranciaMasajeador, pctFrancia, false);
                CambiarVisualizacion(lstItalia, lstItaliaEntrenador, lstItaliaMasajeador, pctItalia, false);

                // Muestra el ListBox correspondiente al país seleccionado
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;
                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        CambiarVisualizacion(lstArgentina, lstArgentinaEntrenador, lstArgentinaMasajeador, pctArgentina, true);
                        break;
                    case EPaises.Brasil:
                        CambiarVisualizacion(lstBrasil, lstBrasilEntrenador, lstBrasilMasajeador, pctBrasil, true);
                        break;
                    case EPaises.Italia:
                        CambiarVisualizacion(lstItalia, lstItaliaEntrenador, lstItaliaMasajeador, pctItalia, true);
                        break;
                    case EPaises.Francia:
                        CambiarVisualizacion(lstFrancia, lstFranciaEntrenador, lstFranciaMasajeador, pctFrancia, true);
                        break;
                    case EPaises.Alemania:
                        CambiarVisualizacion(lstAlemania, lstAlemaniaEntrenador, lstAlemaniaMasajeador, pctAlemania, true);
                        break;
                }
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //JUGADORES
            Serializar("JugadorArgentina.json", jugadoresArgentina);
            Serializar("JugadorBrasil.json", jugadoresBrasil);
            Serializar("JugadorItalia.json", jugadoresItalia);
            Serializar("JugadorFrancia.json", jugadoresFrancia);
            Serializar("JugadorAlemania.json", jugadoresAlemania);

            //ENTRENADORES
            Serializar("EntrenadorArgentina.json", entrenadorArgentina);
            Serializar("EntrenadorBrasil.json", entrenadorBrasil);
            Serializar("EntrenadorItalia.json", entrenadorItalia);
            Serializar("EntrenadorFrancia.json", entrenadorFrancia);
            Serializar("EntrenadorAlemania.json", entrenadorAlemania);

            //MASAJISTAS
            Serializar("MasajistaArgentina.json", masajeadoresArgentina);
            Serializar("MasajistaBrasil.json", masajeadoresBrasil);
            Serializar("MasajistaItalia.json", masajeadoresItalia);
            Serializar("MasajistaFrancia.json", masajeadoresFrancia);
            Serializar("MasajistaAlemania.json", masajeadoresAlemania);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (cmbPaises.SelectedItem != null)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        EliminarElemento(lstArgentina, jugadoresArgentina);
                        EliminarElemento(lstArgentinaEntrenador, entrenadorArgentina);
                        EliminarElemento(lstArgentinaMasajeador, masajeadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        EliminarElemento(lstBrasil, jugadoresBrasil);
                        EliminarElemento(lstBrasilEntrenador, entrenadorBrasil);
                        EliminarElemento(lstBrasilMasajeador, masajeadoresBrasil);
                        break;
                    case EPaises.Italia:
                        EliminarElemento(lstItalia, jugadoresItalia);
                        EliminarElemento(lstItaliaEntrenador, entrenadorItalia);
                        EliminarElemento(lstItaliaMasajeador, masajeadoresItalia);
                        break;
                    case EPaises.Francia:
                        EliminarElemento(lstFrancia, jugadoresFrancia);
                        EliminarElemento(lstFranciaEntrenador, entrenadorFrancia);
                        EliminarElemento(lstFranciaMasajeador, masajeadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        EliminarElemento(lstAlemania, jugadoresAlemania);
                        EliminarElemento(lstAlemaniaEntrenador, entrenadorAlemania);
                        EliminarElemento(lstAlemaniaMasajeador, masajeadoresAlemania);
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
                        ModificarElemento(lstArgentina, jugadoresArgentina);
                        ModificarElemento(lstArgentinaEntrenador, entrenadorArgentina);
                        ModificarElemento(lstArgentinaMasajeador, masajeadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        ModificarElemento(lstBrasil, jugadoresBrasil);
                        ModificarElemento(lstBrasilEntrenador, entrenadorBrasil);
                        ModificarElemento(lstBrasilMasajeador, masajeadoresBrasil);
                        break;
                    case EPaises.Italia:
                        ModificarElemento(lstItalia, jugadoresItalia);
                        ModificarElemento(lstItaliaEntrenador, entrenadorItalia);
                        ModificarElemento(lstItaliaMasajeador, masajeadoresItalia);
                        break;
                    case EPaises.Francia:
                        ModificarElemento(lstFrancia, jugadoresFrancia);
                        ModificarElemento(lstFranciaEntrenador, entrenadorFrancia);
                        ModificarElemento(lstFranciaMasajeador, masajeadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        ModificarElemento(lstAlemania, jugadoresAlemania);
                        ModificarElemento(lstAlemaniaEntrenador, entrenadorAlemania);
                        ModificarElemento(lstAlemaniaMasajeador, masajeadoresAlemania);
                        break;
                }
            }
        }

        #region metodos
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
        

        private void CambiarVisualizacion(ListBox lst1, ListBox lst2, ListBox lst3, PictureBox pictur, bool algo)
        {
            lst1.Visible = algo;
            lst2.Visible = algo;
            lst3.Visible = algo;
            pictur.Visible = algo;
        }
        #endregion

        #region Metodos Eliminar
        private void EliminarElemento(ListBox listBox, List<Jugador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                int selectedIndex = listBox.SelectedIndex;
                listBox.Items.RemoveAt(selectedIndex);
                lista.RemoveAt(selectedIndex);
            }
        }
        private void EliminarElemento(ListBox listBox, List<Entrenador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                int selectedIndex = listBox.SelectedIndex;
                listBox.Items.RemoveAt(selectedIndex);
                lista.RemoveAt(selectedIndex);
            }
        }
        private void EliminarElemento(ListBox listBox, List<Masajista> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                int selectedIndex = listBox.SelectedIndex;
                listBox.Items.RemoveAt(selectedIndex);
                lista.RemoveAt(selectedIndex);
            }
        }
        #endregion

        #region Metodos Modificar
        private void ModificarList(ListBox lst, List<Jugador> personal)
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

        private void ModificarList(ListBox lst, List<Entrenador> personal)
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

        private void ModificarList(ListBox lst, List<Masajista> personal)
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

        public void ModificarElemento(ListBox listBox, List<Jugador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                ModificarList(listBox, lista);
            }
        }
        public void ModificarElemento(ListBox listBox, List<Masajista> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                ModificarList(listBox, lista);
            }
        }
        public void ModificarElemento(ListBox listBox, List<Entrenador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                ModificarList(listBox, lista);
            }
        }


        #endregion

        #region Metodos para Serializar y Deserializar
        public void Serializar(string path, List<Jugador> listJugador)
        {
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;

            string objJson = System.Text.Json.JsonSerializer.Serialize(listJugador, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }

        public void Serializar(string path, List<Entrenador> listEntrenador)
        {
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;

            string objJson = System.Text.Json.JsonSerializer.Serialize(listEntrenador, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }

        public void Serializar(string path, List<Masajista> listMasajista)
        {
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;

            string objJson = System.Text.Json.JsonSerializer.Serialize(listMasajista, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }

        public void Deserializar(string path, ref List<Jugador> listJugadores)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();

                    // Deserializa en una lista de objetos Jugador
                    listJugadores = System.Text.Json.JsonSerializer.Deserialize<List<Jugador>>(jsonString);
                }
            }
        }
        public void Deserializar(string path, ref List<Entrenador> listEntrenador)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();

                    listEntrenador = System.Text.Json.JsonSerializer.Deserialize<List<Entrenador>>(jsonString);
                }
            }
        }

        public void Deserializar(string path, ref List<Masajista> listMasajista)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();

                    listMasajista = System.Text.Json.JsonSerializer.Deserialize<List<Masajista>>(jsonString);
                }
            }
        }

        private void ActualizarVisor(List<Jugador> listJugador, ListBox lst)
        {
            lst.Items.Clear();
            foreach (Jugador jugadores in listJugador)
            {
                lst.Items.Add(jugadores);
            }
        }
        private void ActualizarVisor(List<Entrenador> listEntrenador, ListBox lst)
        {
            lst.Items.Clear();
            foreach (Entrenador entrenador in listEntrenador)
            {
                lst.Items.Add(entrenador);
            }
        }
        private void ActualizarVisor(List<Masajista> listMasajista, ListBox lst)
        {
            lst.Items.Clear();
            foreach (Masajista masajista in listMasajista)
            {
                lst.Items.Add(masajista);
            }
        }

        #endregion
    }
}



