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
    public partial class FormularioCetgoria : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                CategoriaNegocio categoria = new CategoriaNegocio();            
                Categoria seleccionado = categoria.obtenerCategoria(id);

                TxtCategoria.Text = seleccionado.Tipo;
                btnAgregar.Text = "Modificar";
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nuevo = new Categoria();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                string categoria = TxtCategoria.Text.Trim();

                // Validar si el campo de categoría está vacío
                if (string.IsNullOrWhiteSpace(categoria))
                {
                    // Manejar la validación de campo vacío aquí
                    // Por ejemplo, cambiar el estilo del campo de texto a 'is-invalid' 
                    TxtCategoria.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    // El campo es válido, cambiar el estilo a 'is-valid'
                    TxtCategoria.CssClass = "form-control is-valid";
                }

                nuevo.Tipo = categoria;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    categoriaNegocio.modificarCategoria(nuevo);
                    Response.Redirect("Productos.aspx", false);
                }
                else
                {
                    if (categoriaNegocio.tipoRepetido(nuevo.Tipo))
                    {
                        lblMensajeError.Text = "El tipo de categoria ya existe. No se puede ingresar.";
                        lblMensajeError.Visible = true;
                        TxtCategoria.Text = "";
                        TxtCategoria.CssClass = "form-control is-invalid";
                    }
                    else
                    {
                        lblMensajeError.Visible = false;
                        categoriaNegocio.agregarCategoria(nuevo);
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
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    categoria.eliminacionLogica(int.Parse(Request.QueryString["id"]));
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