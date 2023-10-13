using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Jugador : PersonalEquipoSeleccion
    {
        protected List<PersonalEquipoSeleccion> jugadores;
        private int dorsal;
        private EPosicion posicion;

        public Jugador(int edad, string nombre, string apellido, EPaises pais, int dorsal, EPosicion posicion)
            : base(edad, nombre, apellido, pais)
        {
            this.dorsal = dorsal;
            this.posicion = posicion;
            this.jugadores = new List<PersonalEquipoSeleccion>();
        }
        public override List<PersonalEquipoSeleccion> Equipo
        {
            get
            {
                return this.jugadores;
            }
        }
        public int Dorsal
        {
            get { return dorsal; }
            set { dorsal = value; }
        }

        public EPosicion Posicion
        {
            get { return posicion; }
            set { posicion = value; }

        }

        public EPaises Pais 
        {
            get { return paises; }
            set { paises = value; } 
        }

        public override string Concentrarse()
        {
            return $"{base.nombre} {base.apellido} se está concentrando.";
        }

        public override string Viajar()
        {
            return $"{base.nombre} {base.apellido} esta viajando con el equipo.";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}, Posicion: {this.posicion}, Dorsal: {this.dorsal}");
            foreach (Jugador jugadores in this.jugadores)
            {
                sb.AppendLine(jugadores.ToString());
            }
            return sb.ToString();
        }
        public override void RealizarAccion()
        {
            Console.WriteLine($"El jugador {base.nombre} {base.apellido} está entrenando.");
        }

    }
}
