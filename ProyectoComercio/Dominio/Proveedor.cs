using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Proveedor
    {
        public int Id { get; set; }
        public Persona Persona { get; set; }
        public Categoria Categoria { get; set; }
        public TipoRol TipoRol { get; set; }
        public bool Activo { get; set; }
    }
}
