using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> categorias = categoriaNegocio.listar();

                FabricanteNegocio fabricanteNegocio = new FabricanteNegocio();
                List<Fabricante> fabricantes = fabricanteNegocio.listar();

                MedidaNegocio medidaNegocio = new MedidaNegocio();
                List<Medida> medidas = medidaNegocio.listar();

                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataTextField = "Tipo"; 
                ddlCategoria.DataValueField = "Id"; 
                ddlCategoria.DataBind();

                ddlFabricante.DataSource = fabricantes;
                ddlFabricante.DataTextField = "Nombre";
                ddlFabricante.DataValueField = "Id";
                ddlFabricante.DataBind();

                ddlMedida.DataSource = medidas;
                ddlMedida.DataTextField = "Tipo";
                ddlMedida.DataValueField = "Id";
                ddlMedida.DataBind();
            }
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
                nuevo.Fabricante.Id = int.Parse(ddlFabricante.SelectedValue);

                nuevo.Medida = new Medida();
                nuevo.Medida.Id = int.Parse(ddlMedida.SelectedValue);

                nuevo.Activo = true;

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