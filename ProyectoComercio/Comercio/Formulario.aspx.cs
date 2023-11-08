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
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            try
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

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ProductoNegocio producto = new ProductoNegocio();
                    List<Producto> lista = producto.listar(id);
                    Producto seleccionado = lista[0];


                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    ddlFabricante.SelectedValue = seleccionado.Fabricante.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMedida.SelectedValue = seleccionado.Medida.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
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

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    productoNegocio.modificar(nuevo);
                }
                else
                    productoNegocio.agregar(nuevo);

                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ProductoNegocio producto = new ProductoNegocio();
                    producto.eliminar(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("Productos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}