using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    internal class Jugador : EquipoSeleccion
    {
        protected List<EquipoSeleccion> jugadores;
        private int dorsal;
        private EPosicion posicion;

        public Jugador(int edad, string nombre, string apellido, EPaises pais, int dorsal, EPosicion posicion) : base(edad, nombre, apellido, pais)
        {
            this.dorsal = dorsal;
            this.posicion = posicion;
        }
        public override List<EquipoSeleccion> Equipo
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
        public override string Concentrarse()
        {
            return $"{base.nombre} {base.apellido} se está concentrando.";
        }

        public override string Viajar()
        {
            return $"{base.nombre} {base.apellido} está viajando con el equipo.";
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

    }
}
