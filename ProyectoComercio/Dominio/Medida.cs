﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medida
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get; set; }
        public override string ToString()
        {
            return Tipo;
        }
    }
}
