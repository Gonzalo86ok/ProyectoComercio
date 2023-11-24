using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class StockHistorialLista
    {
        public int Id { get; set; }
        public Producto producto { get; set; }
        public decimal CantidadAnterior { get; set; }
        public decimal CantidadNueva { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public string Operacion { get; set; }
        public string Comentario { get; set; }
        public Usuario usuario { get; set; }
    }
}
