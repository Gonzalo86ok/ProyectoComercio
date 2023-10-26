﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set;}
        public Medida Medida { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
    }
}
