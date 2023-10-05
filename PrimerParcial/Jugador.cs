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

        public override List<JugadoresSeleccion> Jugadores
        {
            get
            {
                return this.jugadores;
            }
        }
    }
}
