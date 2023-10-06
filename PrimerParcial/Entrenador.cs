using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    internal class Entrenador : EquipoSeleccion
    {
        protected List<EquipoSeleccion> entrenador;



        public override List<EquipoSeleccion> Equipo
        {
            get
            {
                return this.entrenador;
            }
        }


    }
}
