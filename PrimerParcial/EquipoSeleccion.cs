using System.Text;

namespace PrimerParcial
{
    public abstract class EquipoSeleccion
    {
        public int edad;
        public string nombre;
        public string apellido;
        public EPaises paises;

        public abstract List<EquipoSeleccion> Equipo { get; }
        public EquipoSeleccion()
        {
            this.edad = 0;
            this.nombre = "SIN NOMBRE";
            this.apellido = "SIN APELLIDO";
            this.paises = EPaises.Argentina;
        }
        public EquipoSeleccion(int edad) : this()
        {
            this.edad= edad;
        }

        public EquipoSeleccion(int edad, string nombre) : this(edad)
        {
            this.nombre = nombre;
        }

        public EquipoSeleccion(int edad, string nombre, string apellido) : this(edad, nombre)
        {
            this.apellido = apellido;
        }

        public EquipoSeleccion(int edad, string nombre, string apellido, EPaises paises) : this(edad, nombre, apellido)
        {
            this.paises = paises;
        }


        public virtual string Concentrarse()
        {
            return $"{this.nombre} {this.apellido} se está concentrando.";
            //Console.WriteLine($"{this.nombre} {this.apellido} se está concentrando.");
        }

        public virtual string Viajar()
        {
            return $"{this.nombre} {this.apellido} está viajando con el equipo.";
            //Console.WriteLine($"{this.nombre} {this.apellido} está viajando con el equipo.");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            bool returno = false;
            if (obj is EquipoSeleccion)
            {
                returno = this == (EquipoSeleccion)obj;
            }
            return returno;
        }

        public static bool operator ==(EquipoSeleccion a, EquipoSeleccion b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EquipoSeleccion a, EquipoSeleccion b)
        {
            return !(a == b);
        }
    }
}