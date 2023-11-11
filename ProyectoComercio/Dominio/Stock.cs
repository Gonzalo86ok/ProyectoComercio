using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  public  class Stock
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public bool Activo { get; set; }
    }
}
