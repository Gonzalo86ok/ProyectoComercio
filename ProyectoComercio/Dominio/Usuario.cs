﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        Empledo = 1,
        Admin = 2
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public bool Activo { get; set; }

        public Usuario(string user, string pass, bool admin, bool activo)
        {
            User = user;
            Pass = pass;
            TipoUsuario = admin ? TipoUsuario.Admin : TipoUsuario.Empledo;
            Activo = activo;
        }
        public Usuario()
        {

        }

    }
}
