﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class TipoComercio
   {
        public int Id { get; set; }
        public string Descripcion {  get; set; } //// "Minorista", "Mayorista", Super, Kiosco

        public override string ToString()
        {
            return Descripcion;
        }
   }


}
