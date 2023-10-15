using System;
using System.Text;


namespace PrimerParcial
{
    public class Jugador : PersonalEquipoSeleccion
    {
        private int dorsal;
        private EPosicion posicion;

        public Jugador(int edad, string nombre, string apellido, EPaises pais, int dorsal, EPosicion posicion)
            : base(edad, nombre, apellido, pais)
        {
            this.dorsal = dorsal;
            this.posicion = posicion;
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }


        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }

        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }

        public EPaises Pais
        {
            get { return this.paises; }
            set { this.paises = value;}
        }
        public int Dorsal
        {
            get { return this.dorsal; }
            set { this.dorsal = value; }
        }

        public EPosicion Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}, Posicion: {this.posicion}, Dorsal: {this.dorsal}");
            return sb.ToString();
        }

        public override void RealizarAccion()
        {
            Console.WriteLine($"El jugador {this.nombre} {this.apellido} está entrenando.");
        }
    }
}
