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

            Fabricante fabricante= new Fabricante();
            FabricanteNegocio fabricanteNegocio = new FabricanteNegocio();
            
            if (!IsPostBack)
            {
                try
                {

                    List<Producto> listaProductos = productoNegocio.listarActivos();
                    Session.Add("listaProductos", listaProductos);
                    dgvProducto.DataSource = Session["listaProductos"];
                    dgvProducto.DataBind();

                    List<Categoria> listaCategoria = dato.listar();
                    dgvCategoria.DataSource = listaCategoria;
                    dgvCategoria.DataBind();

                    List<Medida> listaMedidas = medidaNegocio.listar();
                    dgvMedida.DataSource = listaMedidas;
                    dgvMedida.DataBind();

                    List<Fabricante> listaFabricante = fabricanteNegocio.listar();
                    dgvFabricante.DataSource = listaFabricante;
                    dgvFabricante.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    throw;
                }
            }
        }
        protected void dgvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void btnAgregarProducto_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Formulario.aspx");
        }
        protected void btnModificarProducto_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("Formulario.aspx?id=" + selectedId);
        }

        protected void EliminarProducto_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("Formulario.aspx?id=" + selectedId);
        }
        protected void agregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioCategoria.aspx");
        }

        protected void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("FormularioCategoria.aspx?id=" + selectedId);
        }

        protected void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("FormularioCategoria.aspx?id=" + selectedId);
        }
        protected void agregarFabricante_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioFabricante.aspx");
        }
        protected void ModificarFabricante_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("FormularioFabricante.aspx?id=" + selectedId);
        }
        protected void EliminarFabricante_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("FormularioFabricante.aspx?id=" + selectedId);
        }

        protected void btnAgregarMedida_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioMedidas.aspx");
        }

        protected void modificarMedida_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("FormularioMedidas.aspx?id=" + selectedId);
        }

        protected void eliminarMedida_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("FormularioMedidas.aspx?id=" + selectedId);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> lista = (List<Producto>)Session["listaProductos"];
            List<Producto> listaFiltrar = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvProducto.DataSource = listaFiltrar;
            dgvProducto.DataBind();
        }
    }
}