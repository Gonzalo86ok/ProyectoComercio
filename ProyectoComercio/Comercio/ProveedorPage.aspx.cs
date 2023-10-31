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
    public partial class ProveedorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FabricanteNegocio fabricanteNegocio = new FabricanteNegocio();                         
                List<Fabricante> fabricantes = fabricanteNegocio.listar();
                 
                RepeaterFabricantes.DataSource = fabricantes;
                RepeaterFabricantes.DataBind();             
            }

        }
    }
}