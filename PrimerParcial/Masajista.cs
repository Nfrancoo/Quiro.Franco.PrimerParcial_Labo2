using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Masajista : GenteEquipoSeleccion
    {
        protected List<GenteEquipoSeleccion> masajistas;
        private string certificadoMasaje;

        public Masajista(int edad, string nombre, string apellido, EPaises pais, string certificadoMasaje)
            : base(edad, nombre, apellido, pais)
        {
            this.certificadoMasaje = certificadoMasaje;
            this.masajistas = new List<GenteEquipoSeleccion>();
        }

        public override List<GenteEquipoSeleccion> Equipo
        {
            get
            {
                return this.masajistas;
            }
        }

        public string CertificadoMasaje
        {
            get { return certificadoMasaje; }
            set { certificadoMasaje = value; }
        }

        public override void RealizarAccion()
        {
            Console.WriteLine($"{this.nombre} {this.apellido} esta masajeando a los jugadores.");
        }
    }
}
