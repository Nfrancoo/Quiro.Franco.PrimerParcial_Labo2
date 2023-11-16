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
using System.Security.Cryptography;
using Microsoft.Win32;


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
            this.registro = new Equipo();
            this.StartPosition = FormStartPosition.CenterScreen;
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

            if (personalForm.esJugador)
            {
                if (personalForm.DialogResult == DialogResult.OK)
                {
                    if (this.registro + personalForm.nuevoJugador)
                    {
                        this.ActualizarRegistro();
                    }
                    else
                    {
                        MessageBox.Show("el jugador ya esta agregado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
            }
            else if (personalForm.esEntrenador)
            {
                if (personalForm.DialogResult == DialogResult.OK)
                {
                    if (this.registro + personalForm.nuevoEntrenador)
                    {
                        this.ActualizarRegistro();
                    }
                    else
                    {
                        MessageBox.Show("el jugador ya esta agregadoO", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
            }
            else if (personalForm.esEntrenador)
            {
                if (personalForm.DialogResult == DialogResult.OK)
                {
                    if (this.registro + personalForm.nuevoMasajista)
                    {
                        this.ActualizarRegistro();
                    }
                    else
                    {
                        MessageBox.Show("el jugador ya esta agregado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
            }
        }

        /// <summary>
        /// Manejador de eventos al cerrar el formulario.
        /// Realiza la serialización de los datos de jugadores, entrenadores y masajistas.
        /// </summary>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

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
            int indice = this.lstPersonal.SelectedIndex;

            if (indice == -1)
            {
                return;
            }

            if (indice == -1)
            {
                MessageBox.Show("Por favor, selecciona un elemento en la lista antes de intentar eliminarlo.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // No se hace nada si no se selecciona ningún elemento
            }

            PersonalEquipoSeleccion claseJugador = this.registro.ListaPesonal[indice];
            // Muestra un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar estos elementos?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && this.registro - claseJugador)
            {

                this.ActualizarRegistro();
            }
            else
            {
                MessageBox.Show("no se pudo eliminar el jugador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Modificar". 
        /// Modifica un elemento seleccionado en la lista correspondiente 
        /// (jugadores, entrenadores o masajistas) según el país seleccionado.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = this.lstPersonal.SelectedIndex;

            if (indice == -1)
            {
                return;
            }

            PersonalEquipoSeleccion personalAModificar = this.registro.ListaPesonal[indice];

            if (personalAModificar is Jugador)
            {
                Jugador futbolista = (Jugador)personalAModificar;
                ConvocarJugador fmrf = new ConvocarJugador(futbolista);
                this.ModificarJugador(fmrf, indice);

            }
            else if (personalAModificar is Entrenador)
            {
                Entrenador Entrenador = (Entrenador)personalAModificar;
                ConvocarEntrenador fmrba = new ConvocarEntrenador(Entrenador);
                this.ModificarEntrenador(fmrba, indice);
            }
            else
            {
                Masajista masajista = (Masajista)personalAModificar;
                ConvocarMasajista fmrbe = new ConvocarMasajista(masajista);
                this.ModificarMasajista(fmrbe, indice);
            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            int indice = this.lstPersonal.SelectedIndex;

            if (indice == -1)
            {
                return;
            }
            PersonalEquipoSeleccion jugadorAModificar = this.registro.ListaPesonal[indice];

            // Verifica si el objeto seleccionado es de tipo Jugador.
            if (jugadorAModificar is Jugador jugador)
            {
                // Llama al método RealizarAccion del jugador seleccionado.
                string accion = jugador.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (jugadorAModificar is Entrenador entrenador)
            {
                string accion = entrenador.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Entrenador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (jugadorAModificar is Masajista masajista)
            {
                // Llama al método RealizarAccion del jugador seleccionado.
                string accion = masajista.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Masajeador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Maneja el evento Click del formulario principal y deselecciona todos los elementos en las listas.
        /// </summary>
        private void FormPrincipal_Click(object sender, EventArgs e)
        {
            lstPersonal.ClearSelected();
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Ordenar". 
        /// Ordena los elementos de la lista correspondiente (jugadores, entrenadores o masajistas) 
        /// en función de la opción seleccionada (ascendente o descendente) y el país seleccionado
        /// Los jugadores de van a poder ordenar en cuanto a posicion y edad y los entrenador y masajistas solo por edad
        /// </summary>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.rdoAscendenteEdad.Checked)
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorEdadAS);
                ActualizarRegistro();

            }
            else if (this.rdoDescendenteEdad.Checked)
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorEdadDes);
                ActualizarRegistro();

            }
            else if (this.rdoAscendentePosicion.Checked)
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorPaisAs);
                ActualizarRegistro();
            }
            else
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorPaisDes);
                ActualizarRegistro();
            }
        }
        private void btnGuardarManualmente_Click(object sender, EventArgs e)
        {
            GuardarDatosManualmente();
        }

        private void btnCargarDatos_Click_1(object sender, EventArgs e)
        {
            RecuperarDatos();
        }

        #region metodos
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
            btnCargarDatos.BackColor = colorin;
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
            btnCargarDatos.FlatStyle = flat;
            btnCargarDatos.FlatAppearance.BorderColor = colorin;
            btnCargarDatos.FlatAppearance.BorderSize = tamaño;
        }

        /// <summary>
        /// Agrega un entrenador a la lista correspondiente, asegurándose de que solo haya un entrenador por país.
        /// </summary>
        /// <param name="lista">Lista de entrenadores del país</param>
        /// <param name="lst">ListBox que muestra los entrenadores</param>
        /// <param name="entrenador">Entrenador a agregar</param>
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

        #region Metodos Modificar
        private void ModificarJugador(ConvocarJugador fmr, int indice)
        {
            fmr.ShowDialog();

            if (fmr.DialogResult == DialogResult.OK)
            {
                this.registro.ListaPesonal[indice] = fmr.NuevoJugador;
                this.ActualizarRegistro();

            }
        }
        /// <summary>
        /// te muestra los datos del jugador de basket y te da la opurtunidad de cambiarles sus caracteristicas
        /// </summary>
        /// <param name="fmr">sera el formulario del jugador de basket</param>
        /// <param name="indice">el indice que va a localizar el jugador a eliminar</param>
        private void ModificarEntrenador(ConvocarEntrenador fmr, int indice)
        {
            fmr.ShowDialog();

            if (fmr.DialogResult == DialogResult.OK)
            {

                this.registro.ListaPesonal[indice] = fmr.NuevoEntrenador;
                this.ActualizarRegistro();

            }
        }
        /// <summary>
        /// te muestra el form del jugador de beisbol y le modificas sus datos
        /// </summary>
        /// <param name="fmr">sera el formulario del jugador de beisbol</param>
        /// <param name="indice">identficara el jugador a eliminar</param>
        private void ModificarMasajista(ConvocarMasajista fmr, int indice)
        {
            fmr.ShowDialog();

            if (fmr.DialogResult == DialogResult.OK)
            {
                this.registro.ListaPesonal[indice] = fmr.NuevoMasajista;
                this.ActualizarRegistro();

            }
        }

        #endregion

        #region Metodos para Serializar y Deserializar

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
                        serializador.Serialize(escritorxml, this.registro.ListaPesonal);
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
                        this.registro.ListaPesonal = (List<PersonalEquipoSeleccion>)serializador.Deserialize(lectorxml);

                        this.ActualizarRegistro();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void ActualizarRegistro()
        {
            this.lstPersonal.Items.Clear();

            foreach (PersonalEquipoSeleccion personal in this.registro.ListaPesonal)
            {
                lstPersonal.Items.Add(personal.ToString());
            }
        }
    }
}