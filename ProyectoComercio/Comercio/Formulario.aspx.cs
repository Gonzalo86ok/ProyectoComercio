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
                    Producto seleccionado = producto.obtenerProducto(id);
                 
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    ddlFabricante.SelectedValue = seleccionado.Fabricante.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMedida.SelectedValue = seleccionado.Medida.Id.ToString();

                    btnAgregarProducto.Text = "Modificar";
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

                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                string precioText = txtPrecio.Text.Replace('.', ',');

                // Validación de cada campo individualmente
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    txtCodigo.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    txtCodigo.CssClass = "form-control is-valid";
                }

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    txtNombre.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    txtNombre.CssClass = "form-control is-valid";
                }

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    txtDescripcion.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    txtDescripcion.CssClass = "form-control is-valid";
                }

                if (string.IsNullOrWhiteSpace(precioText))
                {
                    txtPrecio.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    txtPrecio.CssClass = "form-control is-valid";
                }

                // Validación de precio numérico
                if (!decimal.TryParse(precioText, out decimal precio))
                {
                    txtPrecio.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    txtPrecio.CssClass = "form-control is-valid";
                }

                // Validación de precio no negativo
                if (precio < 0)
                {
                    txtPrecio.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    txtPrecio.CssClass = "form-control is-valid";
                }

                // Asignación de valores al producto
                nuevo.Codigo = codigo;
                nuevo.Nombre = nombre;
                nuevo.Descripcion = descripcion;
                nuevo.Precio = decimal.Parse(precioText);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Fabricante = new Fabricante();
                nuevo.Fabricante.Id = int.Parse(ddlFabricante.SelectedValue);
                nuevo.Medida = new Medida();
                nuevo.Medida.Id = int.Parse(ddlMedida.SelectedValue);
                nuevo.Activo = true;

                // Guardar el producto si todas las validaciones son exitosas
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    productoNegocio.modificar(nuevo);
                    Response.Redirect("Productos.aspx", false);
                }
                else
                {
                    if (productoNegocio.codigoRepetido(nuevo.Codigo))
                    {
                        lblMensajeError.Text = "El código del producto ya existe. No se puede ingresar.";
                        lblMensajeError.Visible = true;
                        txtCodigo.Text = "";
                        txtCodigo.CssClass = "form-control is-invalid";
                    }
                    else
                    {
                        lblMensajeError.Visible = false;
                        productoNegocio.agregar(nuevo);
                        Response.Redirect("Productos.aspx", false);
                    }
                }
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
                    StockNegocio stockNegocio = new StockNegocio();
                    int productoId = int.Parse(Request.QueryString["id"]);
                    decimal cantidadDeStock = stockNegocio.ObtenerCantidadStock(productoId);

                    if (cantidadDeStock == 0)
                    {
                        stockNegocio.EliminarStock(productoId);
                        producto.eliminacionLogica(productoId);
                        Response.Redirect("Productos.aspx", false);
                    }
                    else
                    {
                        mensaje.Visible = true;
                        lblMensaje.Text = "No se puede eliminar el producto porque hay stock asociado. Elimina el stock primero.";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}