using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Masajista : PersonalEquipoSeleccion
    {
        protected List<PersonalEquipoSeleccion> masajistas;
        private string lugarDeTituloDeEstudio;

        public Masajista(int edad, string nombre, string apellido, EPaises pais, string lugarDeTituloDeEstudio)
            : base(edad, nombre, apellido, pais)
        {
            this.lugarDeTituloDeEstudio = lugarDeTituloDeEstudio;
            this.masajistas = new List<PersonalEquipoSeleccion>();
        }

        public override List<PersonalEquipoSeleccion> Equipo
        {
            get
            {
                return this.masajistas;
            }
        }

        public EPaises Paises
        {
            get { return this.paises; }
            set { this.paises = value; }
        }


        public string CertificadoMasaje
        {
            get { return lugarDeTituloDeEstudio; }
            set { lugarDeTituloDeEstudio = value; }
        }

        public override void RealizarAccion()
        {
            Console.WriteLine($"{this.nombre} {this.apellido} esta masajeando a los jugadores.");
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
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}, Facultadad donde estudio: {this.lugarDeTituloDeEstudio}");
            foreach (Jugador jugadores in this.masajistas)
            {
                sb.AppendLine(jugadores.ToString());
            }
            return sb.ToString();
        }
    }
}
