using System;
using System.Text.Json.Serialization;

namespace PrimerParcial
{
    public class Masajista : PersonalEquipoSeleccion
    {
        private string lugarDeTituloDeEstudio;


        [JsonConstructor]
        public Masajista()
        {
            // Constructor sin parámetros necesario para la deserialización
        }

        public Masajista(int edad, string nombre, string apellido, EPaises pais, string lugarDeTituloDeEstudio) : base(edad, nombre, apellido, pais)
        {
            this.lugarDeTituloDeEstudio = lugarDeTituloDeEstudio;
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }


        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EPaises Pais
        {
            get { return this.paises; }
            set { this.paises = value; }
        }


        public string CertificadoMasaje
        {
            get { return lugarDeTituloDeEstudio; }
            set { this.lugarDeTituloDeEstudio = value; }
        }

        public override void RealizarAccion()
        {
            Console.WriteLine($"{this.nombre} {this.apellido} está masajeando a los jugadores.");
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
            return $"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}, Facultadad donde estudio: {this.lugarDeTituloDeEstudio}";
        }
    }
}
