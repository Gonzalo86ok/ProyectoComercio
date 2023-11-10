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

                nuevo.Tipo= TxtCategoria.Text;              

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    categoriaNegocio.modificarCategoria(nuevo);
                }
                else
                    categoriaNegocio.agregarCategoria(nuevo);

                Response.Redirect("Productos.aspx", false);
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
                    ProductoNegocio producto = new ProductoNegocio();
                    producto.eliminacionLogica(int.Parse(Request.QueryString["id"]));
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