﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  public  class Stock
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public Sucursal Sucursal { get; set; }
        public decimal CantidadMinima { get; set; }
    }
}
