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
                        if (lstArgentina.SelectedIndex != -1)
                        {
                            lstArgentina.Items.RemoveAt(lstArgentina.SelectedIndex);
                            //personalArgentina.RemoveAt(lstArgentina.SelectedIndex);
                        }
                        if (lstArgentinaEntrenador.SelectedIndex != -1)
                        {
                            lstArgentinaEntrenador.Items.RemoveAt(lstArgentinaEntrenador.SelectedIndex);
                            //personalArgentina.RemoveAt(lstArgentinaEntrenador.SelectedIndex);
                        }
                        if (lstArgentinaMasajeador.SelectedIndex != -1)
                        {
                            lstArgentinaMasajeador.Items.RemoveAt(lstArgentinaMasajeador.SelectedIndex);
                            //personalArgentina.RemoveAt(lstArgentinaMasajeador.SelectedIndex);
                        }
                        break;
                    case EPaises.Brasil:
                        if (lstBrasil.SelectedIndex != -1)
                        {
                            lstBrasil.Items.RemoveAt(lstBrasil.SelectedIndex);
                            //personalBrasil.RemoveAt(lstBrasil.SelectedIndex);
                        }
                        if (lstBrasilEntrenador.SelectedIndex != -1)
                        {
                            lstBrasilEntrenador.Items.RemoveAt(lstBrasilEntrenador.SelectedIndex);
                            //personalBrasil.RemoveAt(lstBrasilEntrenador.SelectedIndex);
                        }
                        if (lstBrasilMasajeador.SelectedIndex != -1)
                        {
                            lstBrasilMasajeador.Items.RemoveAt(lstBrasilMasajeador.SelectedIndex);
                            //personalBrasil.RemoveAt(lstBrasilMasajeador.SelectedIndex);
                        }
                        break;
                    case EPaises.Italia:
                        if (lstItalia.SelectedIndex != -1)
                        {
                            lstItalia.Items.RemoveAt(lstItalia.SelectedIndex);
                            //personalItalia.RemoveAt(lstItalia.SelectedIndex);
                        }
                        if (lstItaliaEntrenador.SelectedIndex != -1)
                        {
                            lstItaliaEntrenador.Items.RemoveAt(lstItaliaEntrenador.SelectedIndex);
                            //personalItalia.RemoveAt(lstItaliaEntrenador.SelectedIndex);
                        }
                        if (lstItaliaMasajeador.SelectedIndex != -1)
                        {
                            lstItaliaMasajeador.Items.RemoveAt(lstItaliaMasajeador.SelectedIndex);
                            //personalItalia.RemoveAt(lstItaliaMasajeador.SelectedIndex);
                        }
                        break;
                    case EPaises.Francia:
                        if (lstFrancia.SelectedIndex != -1)
                        {
                            lstFrancia.Items.RemoveAt(lstFrancia.SelectedIndex);
                            //personalFrancia.RemoveAt(lstFrancia.SelectedIndex);
                        }
                        if (lstFranciaEntrenador.SelectedIndex != -1)
                        {
                            lstFranciaEntrenador.Items.RemoveAt(lstFranciaEntrenador.SelectedIndex);
                            //personalFrancia.RemoveAt(lstFranciaEntrenador.SelectedIndex);
                        }
                        if (lstFranciaMasajeador.SelectedIndex != -1)
                        {
                            lstFranciaMasajeador.Items.RemoveAt(lstFranciaMasajeador.SelectedIndex);
                            //personalFrancia.RemoveAt(lstFranciaMasajeador.SelectedIndex);
                        }
                        break;
                    case EPaises.Alemania:
                        if (lstAlemania.SelectedIndex != -1)
                        {
                            lstAlemania.Items.RemoveAt(lstAlemania.SelectedIndex);
                            //personalAlemania.RemoveAt(lstAlemania.SelectedIndex);
                        }
                        if (lstAlemaniaEntrenador.SelectedIndex != -1)
                        {
                            lstAlemaniaEntrenador.Items.RemoveAt(lstAlemaniaEntrenador.SelectedIndex);
                            //personalAlemania.RemoveAt(lstAlemaniaEntrenador.SelectedIndex);
                        }
                        if (lstAlemaniaMasajeador.SelectedIndex != -1)
                        {
                            lstAlemaniaMasajeador.Items.RemoveAt(lstAlemaniaMasajeador.SelectedIndex);
                            //personalAlemania.RemoveAt(lstAlemaniaMasajeador.SelectedIndex);
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
                            ModificarListJugador(lstArgentina, jugadoresArgentina);
                        }

                        if (lstArgentinaEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstArgentinaEntrenador, entrenadorArgentina);
                        }
                        if (lstArgentinaMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstArgentinaMasajeador, masajeadoresArgentina);
                        }
                        break;
                    case EPaises.Brasil:
                        if (lstBrasil.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstBrasil, jugadoresBrasil);
                        }
                        if (lstBrasilEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstBrasilEntrenador, entrenadorBrasil);
                        }
                        if (lstBrasilMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstBrasilMasajeador, masajeadoresBrasil);
                        }
                        break;
                    case EPaises.Italia:
                        if (lstItalia.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstItalia, jugadoresItalia);
                        }
                        if (lstItaliaEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstItaliaEntrenador, entrenadorItalia);
                        }
                        if (lstItaliaMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstItaliaMasajeador, masajeadoresItalia);
                        }
                        break;
                    case EPaises.Francia:
                        if (lstFrancia.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstFrancia, jugadoresFrancia);
                        }
                        if (lstFranciaEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstFranciaEntrenador, entrenadorFrancia);
                        }
                        if (lstFranciaMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstFranciaMasajeador, masajeadoresFrancia);
                        }
                        break;
                    case EPaises.Alemania:
                        if (lstAlemania.SelectedIndex != -1)
                        {
                            ModificarListJugador(lstAlemania, jugadoresAlemania);
                        }
                        if (lstAlemaniaEntrenador.SelectedIndex != -1)
                        {
                            ModificarListEntrenador(lstAlemaniaEntrenador, entrenadorAlemania);
                        }
                        if (lstAlemaniaMasajeador.SelectedIndex != -1)
                        {
                            ModificarListMasajeador(lstAlemaniaMasajeador, masajeadoresAlemania);
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
        #region Metodos Modificar
        private void ModificarListJugador(ListBox lst, List<Jugador> personal)
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

        private void ModificarListEntrenador(ListBox lst, List<Entrenador> personal)
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

        private void ModificarListMasajeador(ListBox lst, List<Masajista> personal)
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
        #endregion

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
        //private void ActualizarVisor()
        //{
        //    this.lstArgentina.Items.Clear();
        //    foreach(Jugador jugador in this.jugadoresArgentina)
        //    {
        //        lstArgentina.Items.Add(jugador.ToString());
        //    }           
        //}
    }
}



