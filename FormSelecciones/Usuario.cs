using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSelecciones
{
    internal class Usuario
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public string correo { get; set; } // Cambiar a minúscula para que coincida con el JSON
        public string clave { get; set; }  // Cambiar a minúscula para que coincida con el JSON
        public string perfil { get; set; }
    }
}
