using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VentasHistorial
    {
        public int ID { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public List<VentaHistorialDetalle> Detalle { get; set; }
    }
}
