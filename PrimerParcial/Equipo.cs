using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Equipo
    {
        private List<PersonalEquipoSeleccion> miembros = new List<PersonalEquipoSeleccion>();

        public static Equipo operator +(Equipo equipo, PersonalEquipoSeleccion miembro)
        {
            equipo.miembros.Add(miembro);
            return equipo;
        }

        public static Equipo operator -(Equipo equipo, PersonalEquipoSeleccion miembro)
        {
            equipo.miembros.Remove(miembro);
            return equipo;
        }

        public static bool operator ==(Equipo equipo, PersonalEquipoSeleccion miembro)
        {
            return equipo.miembros.Contains(miembro);
        }

        public static bool operator !=(Equipo equipo, PersonalEquipoSeleccion miembro)
        {
            return !equipo.miembros.Contains(miembro);
        }
        public void OrdenarPorNombreAscendente()
        {
            miembros.Sort((x, y) => x.nombre.CompareTo(y.nombre));
        }

        public void OrdenarPorEdadDescendente()
        {
            miembros.Sort((x, y) => y.edad.CompareTo(x.edad));
        }

        public void MostrarMiembros()
        {
            Console.WriteLine("Miembros del equipo:");
            foreach (var miembro in miembros)
            {
                Console.WriteLine(miembro.ToString());
            }
        }
    }
}
