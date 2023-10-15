using System.Text;

namespace PrimerParcial
{
    public abstract class PersonalEquipoSeleccion
    {
        public int edad;
        public string nombre;
        public string apellido;
        public EPaises paises;

        public abstract void RealizarAccion();
        public PersonalEquipoSeleccion()
        {
            this.edad = 0;
            this.nombre = "SIN NOMBRE";
            this.apellido = "SIN APELLIDO";
            this.paises = EPaises.Brasil;
        }
        public PersonalEquipoSeleccion(int edad) : this()
        {
            this.edad= edad;
        }

        public PersonalEquipoSeleccion(int edad, string nombre) : this(edad)
        {
            this.nombre = nombre;
        }

        public PersonalEquipoSeleccion(int edad, string nombre, string apellido) : this(edad, nombre)
        {
            this.apellido = apellido;
        }

        public PersonalEquipoSeleccion(int edad, string nombre, string apellido, EPaises paises) : this(edad, nombre, apellido)
        {
            this.paises = paises;
        }


        public virtual string Concentrarse()
        {
            return $"{this.nombre} {this.apellido}";
            //Console.WriteLine($"{this.nombre} {this.apellido} se está concentrando.");
        }

        public virtual string Viajar()
        {
            return $"{this.nombre} {this.apellido}";
            //Console.WriteLine($"{this.nombre} {this.apellido} está viajando con el equipo.");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is PersonalEquipoSeleccion)
            {
                retorno = this == (PersonalEquipoSeleccion)obj;
            }
            return retorno;
        }

        

        //public static bool operator ==(GenteEquipoSeleccion a, GenteEquipoSeleccion b)
        //{
        //    if (ReferenceEquals(a, b))
        //        return true;
        //    if (a is null || b is null)
        //        return false;

        //    return a.Equals(b);
        //}

        //public static bool operator !=(GenteEquipoSeleccion a, GenteEquipoSeleccion b)
        //{
        //    return !(a == b);
        //}
    }
}