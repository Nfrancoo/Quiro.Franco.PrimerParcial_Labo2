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
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;


namespace FormSelecciones
{
    /// <summary>
    /// Formulario principal que gestiona los miembros de los equipos de selección.
    /// </summary>
    public partial class FormPrincipal : Form
    {
        private List<PersonalEquipoSeleccion> personal;
        private Equipo registro;

        private Usuario usuarioLog;

        /// <summary>
        /// Constructor del formulario principal.
        /// </summary>
        public FormPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.personal = new List<PersonalEquipoSeleccion>();
            this.StartPosition = FormStartPosition.CenterScreen;
            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BackColor = Color.LightCyan;
            ModificarColores(Color.LightBlue);
            BordesBoton(FlatStyle.Flat, Color.LightSkyBlue, 2, btnConvocar, btnModificar, btnEliminar, btnOrdenar, btnGuardarManualmente, btnAccion, btnMostrar);
            this.usuarioLog = usuario;

            if (usuario != null)
            {
                this.Text = $"Operador: {usuario.nombre} - fecha actual: {DateTime.Now.ToShortDateString()}";
            }

            string rutaArchivoLog = "usuarios.log";
            try
            {
                using (StreamWriter sw = File.AppendText(rutaArchivoLog))
                {
                    sw.WriteLine($"Nombre: {usuario.nombre} - Apellido: {usuario.apellido} - Horario de entrada: {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo crear el archivo .log" + ex.Message);
            }

            cmbPaises.DataSource = Enum.GetValues(typeof(EPaises));
            this.Click += FormPrincipal_Click;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerLogForm archivo = new VerLogForm();

            archivo.ShowDialog();
        }

        /// <summary>
        /// Manejador de eventos al cargar el formulario.
        /// Carga datos de jugadores, entrenadores y masajistas.
        /// </summary>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Manejador de eventos para el botón de convocar.
        /// Abre el formulario de creación de personal y agrega el nuevo personal a las listas correspondientes.
        /// </summary>
        private void btnConvocar_Click(object sender, EventArgs e)
        {
            Personal personalForm = new Personal();
            personalForm.ShowDialog();

            if (personalForm.DialogResult == DialogResult.OK)
            {
                if (personalForm.NuevoPersonal is Jugador jugador)
                {
                    // Es un jugador
                    Añadir(jugador, lstPorPais(jugador, jugador.Pais));
                }
                else if (personalForm.NuevoPersonal is Entrenador entrenador)
                {
                    // Es un entrenador
                    SoloUnEntrenador(entrenador, lstPorPais(entrenador, entrenador.Pais));
                }
                else if (personalForm.NuevoPersonal is Masajista masajista)
                {
                    // Es un masajista
                    Añadir(masajista, lstPorPais(masajista, masajista.Pais));
                }
            }
        }

        /// <summary>
        /// Manejador de eventos para el cambio en la selección del país en el ComboBox.
        /// Muestra el ListBox correspondiente al país seleccionado y oculta los demás.
        /// </summary>
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

        /// <summary>
        /// Manejador de eventos al cerrar el formulario.
        /// Realiza la serialización de los datos de jugadores, entrenadores y masajistas.
        /// </summary>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarDatos("personal.xml");

            DialogResult result = MessageBox.Show("¿Estás seguro que quieres salir de la aplicación?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón de eliminar.
        /// Elimina el elemento seleccionado en el ListBox correspondiente al país seleccionado.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedItem != null)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                // Verifica si se ha seleccionado algún elemento en algún ListBox del país seleccionado
                bool elementoSeleccionado = false;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        elementoSeleccionado = lstArgentina.SelectedIndex != -1 || lstArgentinaEntrenador.SelectedIndex != -1 || lstArgentinaMasajeador.SelectedIndex != -1;
                        break;
                    case EPaises.Brasil:
                        elementoSeleccionado = lstBrasil.SelectedIndex != -1 || lstBrasilEntrenador.SelectedIndex != -1 || lstBrasilMasajeador.SelectedIndex != -1;
                        break;
                    case EPaises.Italia:
                        elementoSeleccionado = lstItalia.SelectedIndex != -1 || lstItaliaEntrenador.SelectedIndex != -1 || lstItaliaMasajeador.SelectedIndex != -1;
                        break;
                    case EPaises.Francia:
                        elementoSeleccionado = lstFrancia.SelectedIndex != -1 || lstFranciaEntrenador.SelectedIndex != -1 || lstFranciaMasajeador.SelectedIndex != -1;
                        break;
                    case EPaises.Alemania:
                        elementoSeleccionado = lstAlemania.SelectedIndex != -1 || lstAlemaniaEntrenador.SelectedIndex != -1 || lstAlemaniaMasajeador.SelectedIndex != -1;
                        break;
                }

                if (!elementoSeleccionado)
                {
                    MessageBox.Show("Por favor, selecciona un elemento en la lista antes de intentar eliminarlo.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // No se hace nada si no se selecciona ningún elemento
                }

                // Muestra un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar estos elementos?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Elimina los elementos seleccionados según el país
                    switch (paisSeleccionado)
                    {
                        case EPaises.Argentina:
                            EliminarElemento(lstArgentina, paisSeleccionado, this.personal);
                            EliminarElemento(lstArgentinaEntrenador, paisSeleccionado, this.personal);
                            EliminarElemento(lstArgentinaMasajeador, paisSeleccionado, this.personal);
                            break;
                        case EPaises.Brasil:
                            EliminarElemento(lstBrasil, paisSeleccionado, this.personal);
                            EliminarElemento(lstBrasilEntrenador, paisSeleccionado, this.personal);
                            EliminarElemento(lstBrasilMasajeador, paisSeleccionado, this.personal);
                            break;
                        case EPaises.Italia:
                            EliminarElemento(lstItalia, paisSeleccionado, this.personal);
                            EliminarElemento(lstItaliaEntrenador, paisSeleccionado, this.personal);
                            EliminarElemento(lstItaliaMasajeador, paisSeleccionado, this.personal);
                            break;
                        case EPaises.Francia:
                            EliminarElemento(lstFrancia, paisSeleccionado, this.personal);
                            EliminarElemento(lstFranciaEntrenador, paisSeleccionado, this.personal);
                            EliminarElemento(lstFranciaMasajeador, paisSeleccionado, this.personal);
                            break;
                        case EPaises.Alemania:
                            EliminarElemento(lstAlemania, paisSeleccionado, this.personal);
                            EliminarElemento(lstAlemaniaEntrenador, paisSeleccionado, this.personal);
                            EliminarElemento(lstAlemaniaMasajeador, paisSeleccionado, this.personal);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Modificar". 
        /// Modifica un elemento seleccionado en la lista correspondiente 
        /// (jugadores, entrenadores o masajistas) según el país seleccionado.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedItem != null)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        ModificarElemento(lstArgentina, personal, (jugador, index) => personal[index] = jugador);
                        ModificarElemento(lstArgentinaEntrenador, personal, (entrenador, index) => personal[index] = entrenador);
                        ModificarElemento(lstArgentinaMasajeador, personal, (entrenador, index) => personal[index] = entrenador);
                        break;
                    case EPaises.Brasil:
                        ModificarElemento(lstBrasil, personal, (jugador, index) => personal[index] = jugador);
                        ModificarElemento(lstBrasilEntrenador, personal, (entrenador, index) => personal[index] = entrenador);
                        ModificarElemento(lstBrasilMasajeador, personal, (entrenador, index) => personal[index] = entrenador);
                        break;
                    case EPaises.Italia:
                        ModificarElemento(lstItalia, personal, (jugador, index) => personal[index] = jugador);
                        ModificarElemento(lstItaliaEntrenador, personal, (entrenador, index) => personal[index] = entrenador);
                        ModificarElemento(lstItaliaMasajeador, personal, (entrenador, index) => personal[index] = entrenador);
                        break;
                    case EPaises.Francia:
                        ModificarElemento(lstFrancia, personal, (jugador, index) => personal[index] = jugador);
                        ModificarElemento(lstFranciaEntrenador, personal, (entrenador, index) => personal[index] = entrenador);
                        ModificarElemento(lstFranciaMasajeador, personal, (entrenador, index) => personal[index] = entrenador);
                        break;
                    case EPaises.Alemania:
                        ModificarElemento(lstAlemania, personal, (jugador, index) => personal[index] = jugador);
                        ModificarElemento(lstAlemaniaEntrenador, personal, (entrenador, index) => personal[index] = entrenador);
                        ModificarElemento(lstAlemaniaMasajeador, personal, (entrenador, index) => personal[index] = entrenador);
                        break;
                }
            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedItem != null)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        AccionJugador(lstArgentina);
                        AccionEntrenador(lstArgentinaEntrenador);
                        AccionMasajista(lstArgentinaMasajeador);
                        break;
                    case EPaises.Brasil:
                        AccionJugador(lstBrasil);
                        AccionEntrenador(lstBrasilEntrenador);
                        AccionMasajista(lstBrasilMasajeador);
                        break;
                    case EPaises.Italia:
                        AccionJugador(lstItalia);
                        AccionEntrenador(lstItaliaEntrenador);
                        AccionMasajista(lstItaliaMasajeador);
                        break;
                    case EPaises.Francia:
                        AccionJugador(lstFrancia);
                        AccionEntrenador(lstFranciaEntrenador);
                        AccionMasajista(lstFranciaMasajeador); ;
                        break;
                    case EPaises.Alemania:
                        AccionJugador(lstAlemania);
                        AccionEntrenador(lstAlemaniaEntrenador);
                        AccionMasajista(lstAlemaniaMasajeador);
                        break;
                }
            }
        }

        /// <summary>
        /// Maneja el evento Click del formulario principal y deselecciona todos los elementos en las listas.
        /// </summary>
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

        /// <summary>
        /// Método que maneja el evento Click del botón "Ordenar". 
        /// Ordena los elementos de la lista correspondiente (jugadores, entrenadores o masajistas) 
        /// en función de la opción seleccionada (ascendente o descendente) y el país seleccionado
        /// Los jugadores de van a poder ordenar en cuanto a posicion y edad y los entrenador y masajistas solo por edad
        /// </summary>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            //if (rdoascendenteedad.checked)
            //{
            //    epaises paisseleccionado = (epaises)cmbpaises.selecteditem;

            //    switch (paisseleccionado)
            //    {
            //        case epaises.argentina:
            //            ordenaredadas(lstargentina, jugadoresargentina);
            //            ordenaredadas(lstargentinaentrenador, entrenadorargentina);
            //            ordenaredadas(lstargentinamasajeador, masajeadoresargentina);
            //            break;
            //        case epaises.brasil:
            //            ordenaredadas(lstbrasil, jugadoresbrasil);
            //            ordenaredadas(lstbrasilentrenador, entrenadorbrasil);
            //            ordenaredadas(lstbrasilmasajeador, masajeadoresbrasil);
            //            break;
            //        case epaises.italia:
            //            ordenaredadas(lstitalia, jugadoresitalia);
            //            ordenaredadas(lstitaliaentrenador, entrenadoritalia);
            //            ordenaredadas(lstitaliamasajeador, masajeadoresitalia);
            //            break;
            //        case epaises.francia:
            //            ordenaredadas(lstfrancia, jugadoresfrancia);
            //            ordenaredadas(lstfranciaentrenador, entrenadorfrancia);
            //            ordenaredadas(lstfranciamasajeador, masajeadoresfrancia);
            //            break;
            //        case epaises.alemania:
            //            ordenaredadas(lstalemania, jugadoresalemania);
            //            ordenaredadas(lstalemaniaentrenador, entrenadoralemania);
            //            ordenaredadas(lstalemaniamasajeador, masajeadoresalemania);
            //            break;
            //    }
            //}
            //else if (rdodescendenteedad.checked)
            //{
            //    epaises paisseleccionado = (epaises)cmbpaises.selecteditem;

            //    switch (paisseleccionado)
            //    {
            //        case epaises.argentina:
            //            ordenaredaddes(lstargentina, jugadoresargentina);
            //            ordenaredaddes(lstargentinaentrenador, entrenadorargentina);
            //            ordenaredaddes(lstargentinamasajeador, masajeadoresargentina);
            //            break;
            //        case epaises.brasil:
            //            ordenaredaddes(lstbrasil, jugadoresbrasil);
            //            ordenaredaddes(lstbrasilentrenador, entrenadorbrasil);
            //            ordenaredaddes(lstbrasilmasajeador, masajeadoresbrasil);
            //            break;
            //        case epaises.italia:
            //            ordenaredaddes(lstitalia, jugadoresitalia);
            //            ordenaredaddes(lstitaliaentrenador, entrenadoritalia);
            //            ordenaredaddes(lstitaliamasajeador, masajeadoresitalia);
            //            break;
            //        case epaises.francia:
            //            ordenaredaddes(lstfrancia, jugadoresfrancia);
            //            ordenaredaddes(lstfranciaentrenador, entrenadorfrancia);
            //            ordenaredaddes(lstfranciamasajeador, masajeadoresfrancia);
            //            break;
            //        case epaises.alemania:
            //            ordenaredaddes(lstalemania, jugadoresalemania);
            //            ordenaredaddes(lstalemaniaentrenador, entrenadoralemania);
            //            ordenaredaddes(lstalemaniamasajeador, masajeadoresalemania);
            //            break;
            //    }
            //}
            //else if (rdoascendenteposicion.checked)
            //{
            //    epaises paisseleccionado = (epaises)cmbpaises.selecteditem;

            //    switch (paisseleccionado)
            //    {
            //        case epaises.argentina:
            //            ordenarposicionas(lstargentina, jugadoresargentina);
            //            break;
            //        case epaises.brasil:
            //            ordenarposicionas(lstbrasil, jugadoresbrasil);
            //            break;
            //        case epaises.italia:
            //            ordenarposicionas(lstitalia, jugadoresitalia);
            //            break;
            //        case epaises.francia:
            //            ordenarposicionas(lstfrancia, jugadoresfrancia);
            //            break;
            //        case epaises.alemania:
            //            ordenarposicionas(lstalemania, jugadoresalemania);
            //            break;
            //    }
            //}
            //else if (rdodescendenteposicion.checked)
            //{
            //    epaises paisseleccionado = (epaises)cmbpaises.selecteditem;

            //    switch (paisseleccionado)
            //    {
            //        case epaises.argentina:
            //            ordenarposiciondes(lstargentina, jugadoresargentina);
            //            break;
            //        case epaises.brasil:
            //            ordenarposiciondes(lstbrasil, jugadoresbrasil);
            //            break;
            //        case epaises.italia:
            //            ordenarposiciondes(lstitalia, jugadoresitalia);
            //            break;
            //        case epaises.francia:
            //            ordenarposiciondes(lstfrancia, jugadoresfrancia);
            //            break;
            //        case epaises.alemania:
            //            ordenarposiciondes(lstalemania, jugadoresalemania);
            //            break;
            //    }
            //}

        }
        private void btnGuardarManualmente_Click(object sender, EventArgs e)
        {
            GuardarDatosManualmente();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            RecuperarDatos();

            foreach (PersonalEquipoSeleccion personal in this.personal)
            {
                if (personal is Jugador jugador)
                {
                    if (jugador.Pais == EPaises.Argentina)
                    {
                        ActualizarVisor(jugador, lstArgentina);
                    }
                    else if (jugador.Pais == EPaises.Brasil)
                    {
                        ActualizarVisor(jugador, lstBrasil);
                    }
                    else if (jugador.Pais == EPaises.Alemania)
                    {
                        ActualizarVisor(jugador, lstAlemania);
                    }
                    else if (jugador.Pais == EPaises.Italia)
                    {
                        ActualizarVisor(jugador, lstItalia);
                    }
                    else if (jugador.Pais == EPaises.Francia)
                    {
                        ActualizarVisor(jugador, lstFrancia);
                    }
                }
                else if (personal is Entrenador entrenador)
                {
                    if (entrenador.Pais == EPaises.Argentina)
                    {
                        ActualizarVisor(entrenador, lstArgentinaEntrenador);
                    }
                    else if (entrenador.Pais == EPaises.Brasil)
                    {
                        ActualizarVisor(entrenador, lstBrasilEntrenador);
                    }
                    else if (entrenador.Pais == EPaises.Alemania)
                    {
                        ActualizarVisor(entrenador, lstAlemaniaEntrenador);
                    }
                    else if (entrenador.Pais == EPaises.Italia)
                    {
                        ActualizarVisor(entrenador, lstItaliaEntrenador);
                    }
                    else if (entrenador.Pais == EPaises.Francia)
                    {
                        ActualizarVisor(entrenador, lstFranciaEntrenador);
                    }
                }
                else if (personal is Masajista masajista)
                {
                    if (masajista.Pais == EPaises.Argentina)
                    {
                        ActualizarVisor(masajista, lstArgentinaMasajeador);
                    }
                    else if (masajista.Pais == EPaises.Brasil)
                    {
                        ActualizarVisor(masajista, lstBrasilMasajeador);
                    }
                    else if (masajista.Pais == EPaises.Alemania)
                    {
                        ActualizarVisor(masajista, lstAlemaniaMasajeador);
                    }
                    else if (masajista.Pais == EPaises.Italia)
                    {
                        ActualizarVisor(masajista, lstItaliaMasajeador);
                    }
                    else if (masajista.Pais == EPaises.Francia)
                    {
                        ActualizarVisor(masajista, lstFranciaMasajeador);
                    }
                }
            }
        }

        /// <summary>
        /// metodo en el que el usuario puede guardar manualmente los archivos json, lo que si cuando se cierra el program
        /// de igual manera se va a guardar manualmente
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="lista"></param>
        #region Serializacion Manual
        public void SerializarManual<T>(string path, List<T> lista)
        {
            try
            {
                string nombreArchivo = path;

                SaveFileDialog guardar = new SaveFileDialog();

                guardar.FileName = nombreArchivo;

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(guardar.FileName))
                    {
                        JsonSerializerOptions opciones = new JsonSerializerOptions();
                        opciones.WriteIndented = true;

                        string objJson = System.Text.Json.JsonSerializer.Serialize(lista, opciones);
                        sw.WriteLine(objJson);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Cambia la visibilidad de los controles ListBox y PictureBox.
        /// </summary>
        /// <param name="lst1">Primer ListBox a controlar</param>
        /// <param name="lst2">Segundo ListBox a controlar</param>
        /// <param name="lst3">Tercer ListBox a controlar</param>
        /// <param name="pictur">PictureBox a controlar</param>
        /// <param name="algo">Indica si se deben mostrar (true) o ocultar (false) los controles</param>
        private void CambiarVisualizacion(ListBox lst1, ListBox lst2, ListBox lst3, PictureBox pictur, bool algo)
        {
            lst1.Visible = algo;
            lst2.Visible = algo;
            lst3.Visible = algo;
            pictur.Visible = algo;
        }

        /// <summary>
        /// Modifica el color de fondo de los botones de convocar, eliminar y modificar.
        /// </summary>
        /// <param name="colorin">Color de fondo a establecer para los botones</param>
        private void ModificarColores(Color colorin)
        {
            btnConvocar.BackColor = colorin;
            btnEliminar.BackColor = colorin;
            btnModificar.BackColor = colorin;
            btnOrdenar.BackColor = colorin;
            btnGuardarManualmente.BackColor = colorin;
            btnMostrar.BackColor = colorin;
            btnAccion.BackColor = colorin;
        }

        /// <summary>
        /// Configura el estilo y borde de los botones para personalizar su apariencia.
        /// </summary>
        /// <param name="flat">Estilo de los botones (FlatStyle)</param>
        /// <param name="colorin">Color del borde</param>
        /// <param name="tamaño">Grosor del borde en píxeles</param>
        /// <param name="FrmCRUD1">Primer botón a configurar</param>
        /// <param name="FrmCRUD2">Segundo botón a configurar</param>
        /// <param name="FrmCRUD3">Tercer botón a configurar</param>
        /// <param name="FrmCRUD4">Cuarto botón a configurar</param>
        /// <param name="FrmCRUD5">Quinto botón a configurar</param>
        /// <param name="FrmCRUD6">Sexto botón a configurar</param>
        /// <param name="FrmCRUD7">Septimo botón a configurar</param>
        private void BordesBoton(FlatStyle flat, Color colorin, int tamaño, Button FrmCRUD1, Button FrmCRUD2, Button FrmCRUD3, Button FrmCRUD4, Button FrmCRUD5, Button FrmCRUD6, Button FrmCRUD7)
        {
            FrmCRUD1.FlatStyle = flat;
            FrmCRUD1.FlatAppearance.BorderColor = colorin; // Color del borde
            FrmCRUD1.FlatAppearance.BorderSize = tamaño; // Grosor del borde en píxeles
            FrmCRUD2.FlatStyle = flat;
            FrmCRUD2.FlatAppearance.BorderColor = colorin;
            FrmCRUD2.FlatAppearance.BorderSize = tamaño;
            FrmCRUD3.FlatStyle = flat;
            FrmCRUD3.FlatAppearance.BorderColor = colorin;
            FrmCRUD3.FlatAppearance.BorderSize = tamaño;
            FrmCRUD4.FlatStyle = flat;
            FrmCRUD4.FlatAppearance.BorderColor = colorin;
            FrmCRUD4.FlatAppearance.BorderSize = tamaño;
            FrmCRUD5.FlatStyle = flat;
            FrmCRUD5.FlatAppearance.BorderColor = colorin;
            FrmCRUD5.FlatAppearance.BorderSize = tamaño;
            FrmCRUD6.FlatStyle = flat;
            FrmCRUD6.FlatAppearance.BorderColor = colorin;
            FrmCRUD6.FlatAppearance.BorderSize = tamaño;
            FrmCRUD7.FlatStyle = flat;
            FrmCRUD7.FlatAppearance.BorderColor = colorin;
            FrmCRUD7.FlatAppearance.BorderSize = tamaño;
        }

        /// <summary>
        /// Agrega un entrenador a la lista correspondiente, asegurándose de que solo haya un entrenador por país.
        /// </summary>
        /// <param name="lista">Lista de entrenadores del país</param>
        /// <param name="lst">ListBox que muestra los entrenadores</param>
        /// <param name="entrenador">Entrenador a agregar</param>
        //public void SoloUnEntrenador(List<Entrenador> lista, ListBox lst, Entrenador entrenador)
        //{
        //    if (lista.Count > 0)
        //    {
        //        MessageBox.Show("Ya hay un entrenador para este país. Debes eliminar el entrenador existente antes de agregar uno nuevo.", "Error");
        //    }
        //    else
        //    {
        //        Añadir(entrenador, lst);
        //    }
        //}
        public void SoloUnEntrenador(Entrenador entrenador, ListBox lst)
        {
            if (this.personal.Any(p => p is Entrenador && p.Pais == entrenador.Pais))
            {
                // Ya hay un entrenador para ese país
                MessageBox.Show("Ya existe un entrenador para este país.");
            }
            else
            {
                // No hay ningún entrenador para ese país, agrégalo.
                this.personal.Add(entrenador);
                lst.Items.Add(entrenador);
            }
        }
        #endregion

        #region Metodos Eliminar
        /// <summary>
        /// Estos tres metodos eliminan un elemento de la lista (jugador,entrenador,masajista)
        /// y de la ListBox correspondiente.
        /// </summary>
        /// <param name="listBox">ListBox que contiene la lista de jugadores</param>
        /// <param name="lista">Lista de jugadores</param>
        private void EliminarElemento(ListBox lst, EPaises pais, List<PersonalEquipoSeleccion> lista)
        {
            // Obtén la lista correspondiente al país seleccionado
            //List<PersonalEquipoSeleccion> lista = ObtenerListaSegunPais(pais);

            // Verifica si se ha seleccionado algún elemento en el ListBox
            if (lst.SelectedIndex != -1)
            {
                int selectedIndex = lst.SelectedIndex;
                lst.Items.RemoveAt(selectedIndex);
                lista.RemoveAt(selectedIndex);
            }
        }

        #endregion

        #region Metodos Modificar
        /// <summary>
        /// Estos tres metodos abreb un formulario de edición para modificar el personal
        /// seleccionado y actualiza la lista con los cambios realizados.
        /// </summary>
        /// <param name="lst">ListBox que contiene la lista de jugadores</param>
        /// <param name="personal">Lista de jugadores</param>

        private void ModificarList<T>(ListBox lst, List<T> personal, Action<T, int> actualizarElemento) where T : PersonalEquipoSeleccion
        {
            // Verifica si se ha seleccionado un elemento en la ListBox
            if (lst.SelectedIndex != -1)
            {
                // Abre un formulario de edición para el personal seleccionado
                T personalSeleccionado = personal[lst.SelectedIndex];

                if (personalSeleccionado is Jugador)
                {
                    ConvocarJugador editarForm = new ConvocarJugador(personalSeleccionado as Jugador);
                    editarForm.ShowDialog();

                    if (editarForm.DialogResult == DialogResult.OK)
                    {
                        // Obtén el jugador modificado del formulario de edición
                        Jugador jugadorModificado = editarForm.NuevoJugador;

                        // Actualiza la lista con los cambios realizados por el usuario
                        int selectedIndex = lst.SelectedIndex;

                        // Usa la función adicional para actualizar el elemento en la lista
                        actualizarElemento(jugadorModificado as T, selectedIndex);

                        // Actualiza la ListBox
                        lst.Items[selectedIndex] = jugadorModificado;
                    }
                }
                else if (personalSeleccionado is Entrenador)
                {
                    ConvocarEntrenador editarForm = new ConvocarEntrenador(personalSeleccionado as Entrenador);
                    editarForm.ShowDialog();

                    if (editarForm.DialogResult == DialogResult.OK)
                    {
                        // Obtén el jugador modificado del formulario de edición
                        Entrenador jugadorModificado = editarForm.NuevoEntrenador;

                        // Actualiza la lista con los cambios realizados por el usuario
                        int selectedIndex = lst.SelectedIndex;

                        // Usa la función adicional para actualizar el elemento en la lista
                        actualizarElemento(jugadorModificado as T, selectedIndex);

                        // Actualiza la ListBox
                        lst.Items[selectedIndex] = jugadorModificado;
                    }
                }
                else if (personalSeleccionado is Masajista)
                {
                    ConvocarMasajista editarForm = new ConvocarMasajista(personalSeleccionado as Masajista);
                    editarForm.ShowDialog();

                    if (editarForm.DialogResult == DialogResult.OK)
                    {
                        // Obtén el jugador modificado del formulario de edición
                        Masajista jugadorModificado = editarForm.NuevoMasajista;

                        // Actualiza la lista con los cambios realizados por el usuario
                        int selectedIndex = lst.SelectedIndex;

                        // Usa la función adicional para actualizar el elemento en la lista
                        actualizarElemento(jugadorModificado as T, selectedIndex);

                        // Actualiza la ListBox
                        lst.Items[selectedIndex] = jugadorModificado;
                    }
                }
            }
        }

        /// <summary>
        /// Estos tres metodos abren un formulario de edición para el elemento seleccionado en la ListBox 
        /// y lo modifica en la lista llamando a el metodo ModificarList().
        /// </summary>
        /// <param name="listBox">ListBox que contiene el elemento a modificar</param>
        /// <param name="lista">Lista de elementos del mismo tipo</param
        public void ModificarElemento<T>(ListBox listBox, List<T> lista, Action<T, int> actualizarElemento) where T : PersonalEquipoSeleccion
        {
            if (listBox.SelectedIndex != -1)
            {
                T elementoSeleccionado = lista[listBox.SelectedIndex];

                if (elementoSeleccionado is Jugador)
                {
                    ModificarList(listBox, lista, actualizarElemento);
                }
                else if (elementoSeleccionado is Entrenador)
                {
                    ModificarList(listBox, lista, actualizarElemento);
                }
                else if (elementoSeleccionado is Masajista)
                {
                    ModificarList(listBox, lista, actualizarElemento);
                }
            }
        }


        #endregion

        #region Metodos para Serializar y Deserializar
        public void GuardarDatos(string path)
        {
            try
            {
                using (XmlTextWriter escritorxml = new XmlTextWriter(path, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<PersonalEquipoSeleccion>));
                    serializador.Serialize(escritorxml, this.personal);
                    MessageBox.Show("Se acaban de guardar todos los datos automáticamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        public void GuardarDatosManualmente()
        {
            try
            {
                SaveFileDialog guardarDatos = new SaveFileDialog();

                if (guardarDatos.ShowDialog() == DialogResult.OK)
                {
                    string filePath = guardarDatos.FileName;
                    using (XmlTextWriter escritorxml = new XmlTextWriter(filePath, Encoding.UTF8))
                    {
                        XmlSerializer serializador = new XmlSerializer(typeof(List<PersonalEquipoSeleccion>));
                        serializador.Serialize(escritorxml, this.personal);
                        MessageBox.Show("se pudieron guardar los datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void RecuperarDatos()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (XmlTextReader lectorxml = new XmlTextReader(filePath))
                    {
                        XmlSerializer serializador = new XmlSerializer(typeof(List<PersonalEquipoSeleccion>));
                        this.personal = (List<PersonalEquipoSeleccion>)serializador.Deserialize(lectorxml);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Actualiza la ListBox con una lista que le pase por parametro(Jugador,Masajista,Entrenador).
        /// </summary>
        /// <param name="listJugador">Lista de jugadores</param>
        /// <param name="lst">ListBox que se actualizará</param>
        private void ActualizarVisor<T>(T item, ListBox lst) where T : PersonalEquipoSeleccion
        {
            lst.Items.Clear();

            lst.Items.Add(item);

        }

        #endregion

        #region Metodos para Ordenar



        /// <summary>
        /// los 3 metodos ordenan una lista (puede ser Juagador, Masajista o Entrenador)
        /// por edad en orden ascendente y actualiza una ListBox.
        /// </summary>
        /// <param name="lst">ListBox que se actualizará con la lista ordenada</param>
        /// <param name="lista">Lista de jugadores que se ordenará</param>
        public void OrdenarEdadAs(ListBox lst, List<Jugador> lista)
        {

            if (rdoAscendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j1.Edad.CompareTo(j2.Edad));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        public void OrdenarEdadAs(ListBox lst, List<Entrenador> lista)
        {

            if (rdoAscendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j1.Edad.CompareTo(j2.Edad));
            }

            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        public void OrdenarEdadAs(ListBox lst, List<Masajista> lista)
        {

            if (rdoAscendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j1.Edad.CompareTo(j2.Edad));
            }

            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }

        /// <summary>
        /// los 3 metodos ordenan una lista (puede ser Juagador, Masajista o Entrenador)
        /// por edad en orden descendente y actualiza una ListBox.
        /// </summary>
        /// <param name="lst">ListBox que se actualizará con la lista ordenada</param>
        /// <param name="lista">Lista de jugadores que se ordenará</param>
        public void OrdenarEdadDes(ListBox lst, List<Jugador> lista)
        {
            if (rdoDescendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j2.Edad.CompareTo(j1.Edad));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        public void OrdenarEdadDes(ListBox lst, List<Entrenador> lista)
        {
            if (rdoDescendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j2.Edad.CompareTo(j1.Edad));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        public void OrdenarEdadDes(ListBox lst, List<Masajista> lista)
        {
            if (rdoDescendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j2.Edad.CompareTo(j1.Edad));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }

        /// <summary>
        /// Ordena solamente una lista de jugadores por posición en orden ascendente y actualiza una ListBox.
        /// </summary>
        /// <param name="lst">ListBox que se actualizará con la lista ordenada</param>
        /// <param name="lista">Lista de jugadores que se ordenará</param>
        public void OrdenarPosicionAs(ListBox lst, List<Jugador> lista)
        {
            if (rdoAscendentePosicion.Checked)
            {
                lista.Sort((j1, j2) => j1.Posicion.CompareTo(j2.Posicion));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }

        /// <summary>
        /// Ordena solamente una lista de jugadores por posición en orden descendente y actualiza una ListBox.
        /// </summary>
        /// <param name="lst">ListBox que se actualizará con la lista ordenada</param>
        /// <param name="lista">Lista de jugadores que se ordenará</param>

        public void OrdenarPosicionDes(ListBox lst, List<Jugador> lista)
        {
            if (rdoDescendentePosicion.Checked)
            {
                lista.Sort((j1, j2) => j2.Posicion.CompareTo(j1.Posicion));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        #endregion

        #region Añadir
        public void Añadir(Jugador nuevoJugador, ListBox lst)
        {
            bool jugadorRepetido = this.personal.OfType<Jugador>().Any(j => j.Equals(nuevoJugador));
            if (jugadorRepetido)
            {
                // Aquí puedes mostrar un mensaje de error o tomar alguna otra acción.
                MessageBox.Show("El jugador ya existe en la lista.");
            }
            else
            {
                // Si el jugador no existe en la lista, agrégalo.
                this.personal.Add(nuevoJugador);
                lst.Items.Add(nuevoJugador);
            }
        }

        public void Añadir(Entrenador nuevoEntrenador, ListBox lst)
        {
            bool entrenadorRepetido = this.personal.OfType<Entrenador>().Any(e => e.Equals(nuevoEntrenador));
            if (entrenadorRepetido)
            {
                // Aquí puedes mostrar un mensaje de error o tomar alguna otra acción.
                MessageBox.Show("El entrenador ya existe en la lista.");
            }
            else
            {
                // Si el entrenador no existe en la lista, agrégalo.
                this.personal.Add(nuevoEntrenador);
                lst.Items.Add(nuevoEntrenador);
            }
        }

        public void Añadir(Masajista nuevoMasajista, ListBox lst)
        {
            bool masajistaRepetido = this.personal.OfType<Masajista>().Any(m => m.Equals(nuevoMasajista));
            if (masajistaRepetido)
            {
                // Aquí puedes mostrar un mensaje de error o tomar alguna otra acción.
                MessageBox.Show("El masajista ya existe en la lista.");
            }
            else
            {
                // Si el masajista no existe en la lista, agrégalo.
                this.personal.Add(nuevoMasajista);
                lst.Items.Add(nuevoMasajista);
            }
        }
        #endregion

        #region
        private void AccionJugador(ListBox listBox)
        {
            if (listBox.SelectedIndex != -1)
            {
                // Verifica si el objeto seleccionado es de tipo Jugador.
                if (listBox.SelectedItem is Jugador jugador)
                {
                    // Llama al método RealizarAccion del jugador seleccionado.
                    string accion = jugador.RealizarAccion();

                    // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                    MessageBox.Show(accion, "Acción del Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void AccionEntrenador(ListBox listBox)
        {
            if (listBox.SelectedIndex != -1)
            {
                // Verifica si el objeto seleccionado es de tipo Jugador.
                if (listBox.SelectedItem is Entrenador entrenador)
                {
                    // Llama al método RealizarAccion del jugador seleccionado.
                    string accion = entrenador.RealizarAccion();

                    // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                    MessageBox.Show(accion, "Acción del Entrenador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void AccionMasajista(ListBox listBox)
        {
            if (listBox.SelectedIndex != -1)
            {
                // Verifica si el objeto seleccionado es de tipo Jugador.
                if (listBox.SelectedItem is Masajista masajista)
                {
                    // Llama al método RealizarAccion del jugador seleccionado.
                    string accion = masajista.RealizarAccion();

                    // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                    MessageBox.Show(accion, "Acción del Masajeador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion


        private ListBox lstPorPais(PersonalEquipoSeleccion personal, EPaises pais)
        {
            if (personal is Jugador)
            {
                switch (pais)
                {
                    case EPaises.Brasil:
                        return lstBrasil;
                    case EPaises.Argentina:
                        return lstArgentina;
                    case EPaises.Italia:
                        return lstItalia;
                    case EPaises.Alemania:
                        return lstAlemania;
                    case EPaises.Francia:
                        return lstFrancia;
                    default:
                        return null;
                }
            }
            else if (personal is Entrenador)
            {
                switch (pais)
                {
                    case EPaises.Brasil:
                        return lstBrasilEntrenador;
                    case EPaises.Argentina:
                        return lstArgentinaEntrenador;
                    case EPaises.Italia:
                        return lstItaliaEntrenador;
                    case EPaises.Alemania:
                        return lstAlemaniaEntrenador;
                    case EPaises.Francia:
                        return lstFranciaEntrenador;
                    default:
                        return null;
                }
            }
            else if (personal is Masajista)
            {
                switch (pais)
                {
                    case EPaises.Brasil:
                        return lstBrasilMasajeador;
                    case EPaises.Argentina:
                        return lstArgentinaMasajeador;
                    case EPaises.Italia:
                        return lstItaliaMasajeador;
                    case EPaises.Alemania:
                        return lstAlemaniaMasajeador;
                    case EPaises.Francia:
                        return lstFranciaMasajeador;
                    default:
                        return null;
                }
            }
            return null;
        }


    }
}