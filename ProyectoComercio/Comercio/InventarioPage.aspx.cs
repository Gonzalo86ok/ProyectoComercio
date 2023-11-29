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
    public partial class InventarioPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Necesitas Registro de Administrador");
                Response.Redirect("error.aspx", false);
            }

            StockItem stockItem = new StockItem();
            StockNegocio stockNegocio = new StockNegocio();
            if (!IsPostBack)
            {
                try
                {
                    List<StockItem> listastockItem = stockNegocio.listarStockItem();

                    dgvStockItem.DataSource = listastockItem;
                    dgvStockItem.DataBind();

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    throw;
                }

            }
        }

        protected void btoModificar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;

            Response.Redirect("FormularioStock.aspx?Id=" + selectedId);

        }

    }
}