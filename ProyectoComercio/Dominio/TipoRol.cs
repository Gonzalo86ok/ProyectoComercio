using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoRol
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } // "Interno", "Externo", 

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
