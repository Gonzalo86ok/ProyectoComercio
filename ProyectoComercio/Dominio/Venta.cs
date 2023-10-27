using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public Producto VentaProducto {  get; set; }
        public decimal Cantidad { get; set; }
    }
}
