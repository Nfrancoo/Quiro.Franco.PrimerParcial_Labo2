using System.Text;

namespace PrimerParcial
{
    public abstract class JugadoresSeleccion
    {
        public int edad;
        public string nombre;
        public string apellido;
        public EPaises paises;

        public abstract List<JugadoresSeleccion> Jugadores { get; }
        public JugadoresSeleccion()
        {
            this.edad = 0;
            this.nombre = "SIN NOMBRE";
            this.apellido = "SIN APELLIDO";
            this.paises = EPaises.Argentina;
        }
        public JugadoresSeleccion(int edad) : this()
        {
            this.edad= edad;
        }

        public JugadoresSeleccion(int edad, string nombre) : this(edad)
        {
            this.nombre = nombre;
        }

        public JugadoresSeleccion(int edad, string nombre, string apellido) : this(edad, nombre)
        {
            this.apellido = apellido;
        }

        public JugadoresSeleccion(int edad, string nombre, string apellido, EPaises paises) : this(edad, nombre, apellido)
        {
            this.paises = paises;
        }


        public virtual void Concentrarse()
        {
            Console.WriteLine($"{this.nombre} {this.apellido} se está concentrando.");
        }

        public virtual void Viajar()
        {
            Console.WriteLine($"{this.nombre} {this.apellido} está viajando con el equipo.");
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
            if (obj is JugadoresSeleccion)
            {
                returno = this == (JugadoresSeleccion)obj;
            }
            return returno;
        }

        public static bool operator ==(JugadoresSeleccion a, JugadoresSeleccion b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(JugadoresSeleccion a, JugadoresSeleccion b)
        {
            return !(a == b);
        }
    }
}