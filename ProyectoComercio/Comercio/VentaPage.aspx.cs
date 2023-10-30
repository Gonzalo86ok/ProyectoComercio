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
    public partial class VentaPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio dato = new CategoriaNegocio();

            if (!IsPostBack)
            {
                List<Categoria> listaCategoria = dato.listar();
                dgvCategoria.DataSource = listaCategoria;
                dgvCategoria.DataBind();
            }

        }

        protected void dgvCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}