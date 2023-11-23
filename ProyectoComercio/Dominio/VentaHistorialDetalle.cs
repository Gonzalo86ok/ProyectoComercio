using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VentaHistorialDetalle
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int NumeroOrden { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
    }
}
