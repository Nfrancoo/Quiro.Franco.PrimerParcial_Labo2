using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrimerParcial
{
    /// <summary>
    /// Clase que representa un equipo y contiene una lista de miembros del equipo.
    /// </summary>
    public class Equipo
    {
        private List<PersonalEquipoSeleccion> listaPersonal;


        public List<PersonalEquipoSeleccion> ListaPesonal
        {
            get { return this.listaPersonal; }
            set { this.listaPersonal = value; }
        }

        public Equipo()
        {
            this.listaPersonal = new List<PersonalEquipoSeleccion>();
        }
        public static bool operator +(Equipo r, PersonalEquipoSeleccion j)
        {
            bool agregado = true;
            if (r.listaPersonal.Count > 0)
            {
                foreach (PersonalEquipoSeleccion personal in r.listaPersonal)
                {
                    if (personal.Equals(j))
                    {
                        agregado = false;
                        break;
                    }

                }
            }

            if (agregado || r.listaPersonal.Count == 0)
            {
                r.listaPersonal.Add(j);

            }
            return agregado;
        }

        /// <summary>
        /// Sobrecarga del operador '+' para agregar un miembro al equipo.
        /// </summary>
        //public static Equipo operator +(Equipo equipo, PersonalEquipoSeleccion miembro)
        //{
        //    equipo.miembros.Add(miembro);
        //    return equipo;
        //}

        /// <summary>
        /// Sobrecarga del operador '-' para eliminar un miembro del equipo.
        /// </summary>
        public static bool operator -(Equipo r, PersonalEquipoSeleccion j)
        {
            bool eliminado = false;
            if (r.listaPersonal.Count > 0)
            {
                foreach (PersonalEquipoSeleccion personal in r.listaPersonal)
                {
                    if (personal.Equals(j))
                    {
                        r.listaPersonal.Remove(personal);
                        eliminado = true;
                        break;
                    }
                }
            }

            return eliminado;
        }

        ///// <summary>
        ///// Sobrecarga del operador '==' para verificar si un miembro está en el equipo.
        ///// </summary>
        //public static bool operator ==(Equipo equipo, PersonalEquipoSeleccion miembro)
        //{
        //    return equipo.miembros.Contains(miembro);
        //}

        ///// <summary>
        ///// Sobrecarga del operador '!=' para verificar si un miembro no está en el equipo.
        ///// </summary>
        //public static bool operator !=(Equipo equipo, PersonalEquipoSeleccion miembro)
        //{
        //    return !equipo.miembros.Contains(miembro);
        //}

        ///// <summary>
        ///// Muestra en la consola los miembros del equipo con sus respectivas representaciones en cadena.
        ///// </summary>
        //public void MostrarMiembros()
        //{
        //    Console.WriteLine("Miembros del equipo:");
        //    foreach (var miembro in miembros)
        //    {
        //        Console.WriteLine(miembro.ToString());
        //    }
        //}
    }
}
