using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public int IdProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public int IdSucursal { get; set; }
    }
}
