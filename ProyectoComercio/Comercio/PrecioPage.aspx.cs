﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class PrecioPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                     
                    
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            if (!IsPostBack)
            {
                
                List<Producto> listaProductos = productoNegocio.listar();
                                         

                dgvProducto.DataSource = listaProductos;
                dgvProducto.DataBind();
            }
        }

        protected void dgvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}