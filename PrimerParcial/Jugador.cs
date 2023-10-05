using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    internal class Jugador : JugadoresSeleccion
    {
        protected List<JugadoresSeleccion> jugadores;
        private int dorsal;
        private String demarcacion;
        private EPosicion posicion;

        public Jugador(int edad, string nombre, string apellido, EPaises pais, int dorsal, string demarcacion, EPosicion posicion)
        : base(edad, nombre, apellido, pais)
        {
            this.dorsal = dorsal;
            this.demarcacion = demarcacion;
            this.posicion = posicion;
        }
        public override List<JugadoresSeleccion> Jugadores
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

        public string Demarcacion
        {
            get { return demarcacion; }
            set { demarcacion = value; }
        }

        public EPosicion Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }


    }
}
