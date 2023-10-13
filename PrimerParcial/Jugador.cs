using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Jugador : GenteEquipoSeleccion
    {
        protected List<GenteEquipoSeleccion> jugadores;
        private int dorsal;
        private EPosicion posicion;

        public Jugador(int edad, string nombre, string apellido, EPaises pais, int dorsal, EPosicion posicion)
            : base(edad, nombre, apellido, pais)
        {
            this.dorsal = dorsal;
            this.posicion = posicion;
            this.jugadores = new List<GenteEquipoSeleccion>();
        }
        public override List<GenteEquipoSeleccion> Equipo
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
            sb.AppendLine(base.ToString());
            foreach (Jugador pasajero in this.jugadores)
            {
                sb.AppendLine(pasajero.ToString());
            }
            return sb.ToString();
        }
        public override void RealizarAccion()
        {
            Console.WriteLine($"El jugador {base.nombre} {base.apellido} está entrenando.");
        }

    }
}
