namespace PrimerParcial
{
    public abstract class JugadoresSeleccion
    {
        public int edad;
        public string nombre;
        public string apellido;
        public EPaises paises;

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

        public abstract void RealizarAccionEquipo();


        public virtual void Concentrarse()
        {
            Console.WriteLine($"{nombre} {apellido} se está concentrando.");
            
        }

        public virtual void Viajar()
        {
            Console.WriteLine($"{nombre} {apellido} está viajando con el equipo.");
            
        }
    }
}