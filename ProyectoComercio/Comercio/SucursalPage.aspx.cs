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
    public partial class SucursalPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            SucursalNegocio sucursalNegocio = new SucursalNegocio();

            if (!IsPostBack)
            {              
                List<Sucursal> listaSucursal = sucursalNegocio.listar();               

                lvSucursal.DataSource = listaSucursal;
                lvSucursal.DataBind();

                dgvSucursal.DataSource = listaSucursal;
                dgvSucursal.DataBind();
            }
        }

        protected void dgvSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }   
}