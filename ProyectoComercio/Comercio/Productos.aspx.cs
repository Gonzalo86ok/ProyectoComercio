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

            Sucursal sucursal = new Sucursal();
            SucursalNegocio sucursalNegocio = new SucursalNegocio();

            Medida medida = new Medida();
            MedidaNegocio medidaNegocio = new MedidaNegocio();

            Fabricante frabricante =new Fabricante();
            FabricanteNegocio fabricanteNegocio = new FabricanteNegocio();

            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            
            if (!IsPostBack)
            {
                List<Categoria> listaCategoria = dato.listar();
                List<Sucursal> listaSucursal = sucursalNegocio.listar();
                List<Medida> listaMedidas = medidaNegocio.listar();
                List<Fabricante>listaFabricante =fabricanteNegocio.listar();
                List<Producto> listaProductos = productoNegocio.listar();  

                dgvCategoria.DataSource = listaCategoria;
                dgvCategoria.DataBind();

                dgvSucursal.DataSource = listaSucursal;
                dgvSucursal.DataBind();

                dgvMedida.DataSource = listaMedidas;
                dgvMedida.DataBind();

                dgvFabricante.DataSource = listaFabricante;
                dgvFabricante.DataBind();

                dgvProducto.DataSource = listaProductos;
                dgvProducto.DataBind();                             
            }
        }

        protected void dgvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}