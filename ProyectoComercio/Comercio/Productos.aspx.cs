using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Comercio
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio dato = new CategoriaNegocio();

            Medida medida = new Medida();
            MedidaNegocio medidaNegocio = new MedidaNegocio();
        
            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            
            if (!IsPostBack)
            {
                List<Categoria> listaCategoria = dato.listar();
                List<Medida> listaMedidas = medidaNegocio.listar();             
                List<Producto> listaProductos = productoNegocio.listar();  

                dgvCategoria.DataSource = listaCategoria;
                dgvCategoria.DataBind();

                dgvMedida.DataSource = listaMedidas;
                dgvMedida.DataBind();
            
                dgvProducto.DataSource = listaProductos;
                dgvProducto.DataBind();                             
            }
        }

        protected void dgvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}