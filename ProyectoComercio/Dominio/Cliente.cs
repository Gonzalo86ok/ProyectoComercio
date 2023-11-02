using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Cliente
    {
        public Persona Persona { get; set; }
        public TipoComercio Comercio { get; set; }
        public TipoRol TipoRol { get; set; }
        public bool Activo { get; set; }
        // Modificar la clase, y crear una nueva que administre la cantidad de ventas.
    }
}
