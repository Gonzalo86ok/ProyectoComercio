using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int Numero { get; set; }
        public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
    }
    public class VentaInforme
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }

}
