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
                    List<Categoria> listaCategoria = dato.listar();
                    List<Medida> listaMedidas = medidaNegocio.listar();
                    List<Producto> listaProductos = productoNegocio.listar();
                    List<Fabricante> listaFabricante = fabricanteNegocio.listar();

                    dgvCategoria.DataSource = listaCategoria;
                    dgvCategoria.DataBind();

                    dgvMedida.DataSource = listaMedidas;
                    dgvMedida.DataBind();

                    dgvFabricante.DataSource = listaFabricante;
                    dgvFabricante.DataBind();


                    dgvProducto.DataSource = listaProductos;
                    dgvProducto.DataBind();

                    //Desplegables de Producto sobre categoria
                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Tipo";
                    ddlCategoria.DataBind();

                    //Desplegables de Producto sobre Medida
                    dllMedida.DataSource = listaMedidas;
                    dllMedida.DataValueField = "Id";
                    dllMedida.DataTextField = "Tipo";
                    dllMedida.DataBind();

                    //Desplegables de Producto sobre Fabricante
                    dllFabricante.DataSource = listaFabricante;
                    dllFabricante.DataValueField = "Id";// Dato que va a estar escondido
                    dllFabricante.DataTextField = "Nombre"; // Dato que va a mostrar
                    dllFabricante.DataBind();
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

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                
                Producto nuevo = new Producto();
                ProductoNegocio productoNegocio = new ProductoNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Fabricante = new Fabricante();
                nuevo.Fabricante.Id = int.Parse(dllFabricante.SelectedValue);

                nuevo.Medida = new Medida();
                nuevo.Medida.Id = int.Parse(dllMedida.SelectedValue);

                productoNegocio.agregar(nuevo);
                Response.Redirect("Productos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

            
        }
    }
}