using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class StockItem
    {
        public int StockId { get; set; }
        public string ProductoCodigo { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoMedidaId { get; set; }
        public decimal StockCantidad { get; set; }
        public bool Activo { get; set; }
    }
}
