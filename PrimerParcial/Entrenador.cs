using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Entrenador : PersonalEquipoSeleccion
    {
        protected List<PersonalEquipoSeleccion> entrenadores;
        public string tactica;

        public Entrenador(int edad, string nombre,string apellido,EPaises pais ,string tactica):base(edad, nombre, apellido, pais)
        {
            this.tactica = tactica;
            this.entrenadores = new List<PersonalEquipoSeleccion> ();
        }
        public override List<PersonalEquipoSeleccion> Equipo
        {
            get
            {
                return this.entrenadores;
            }
        }

        public EPaises Pais
        {
            get { return paises; }
            set { paises = value; }
        }

        public override string Concentrarse()
        {
            return $"{base.nombre} {base.apellido} se está concentrando con el equipo.";
        }

        public override string Viajar()
        {
            return $"{base.nombre} {base.apellido} está viajando con el equipo.";
        }

        public override void RealizarAccion()
        {
            Console.WriteLine($"{this.nombre} {this.apellido} esta revisando las tacticas y la que tiene pensado usar es {this.tactica}.");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}, Tactica a usar: {this.tactica}");
            foreach (Jugador jugadores in this.entrenadores)
            {
                sb.AppendLine(jugadores.ToString());
            }
            return sb.ToString();
        }
    }
}
