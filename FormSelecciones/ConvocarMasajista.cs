﻿using PrimerParcial;
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
    public partial class ConvocarMasajista : Form
    {
        public Masajista MasajeadorParaEditar {  get; set; }
        public Masajista NuevoMasajista;

        public ConvocarMasajista(Masajista masaj)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            Modificador(masaj);
        }

        public ConvocarMasajista()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de nombre.");
                return;
            }

            string apellido = this.txtApellido.Text;
            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de apellido.");
                return;
            }

            string titulo = this.txtTitulo.Text;
            if (string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de titulo.");
                return;
            }

            if (!int.TryParse(this.txtEdad.Text, out int edad))
            {
                MessageBox.Show("El valor ingresado en el campo de edad no es válido.");
                return;
            }

            string paisInput = this.txtPais.Text;
            if (!EsPaisValido(paisInput))
            {
                MessageBox.Show("Por favor, ingrese un país válido.");
                return; // Detener el proceso si el país no es válido
            }

            EPaises pais = (EPaises)Enum.Parse(typeof(EPaises), paisInput);


            NuevoMasajista = new Masajista(edad, nombre, apellido, pais, titulo);

            this.DialogResult = DialogResult.OK;
        }

        private bool EsPaisValido(string inputPais)
        {
            return Enum.IsDefined(typeof(EPaises), inputPais);
        }

        public void Modificador(Masajista masaj)
        {
            this.txtApellido.Text = masaj.Apellido;
            this.txtNombre.Text = masaj.Nombre;
            this.txtEdad.Text = masaj.Edad.ToString();
            this.txtPais.Text = masaj.Pais.ToString();
            this.txtTitulo.Text = masaj.CertificadoMasaje;
            this.txtApellido.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtPais.Enabled = false;
        }

    }
}
