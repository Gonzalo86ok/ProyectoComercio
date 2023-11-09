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
    public partial class FormularioStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                }
                //Configuracion si estamos modificando
                if (Request.QueryString["Id"] != null)
                {
                    StockItem item = new StockItem();
                    StockNegocio negocio = new StockNegocio();
                    item = negocio.ObtenerStockItemPorId(int.Parse(Request.QueryString["Id"]));

                    txtCodigoProducto.Text = item.ProductoCodigo.ToString();
                    txtNombreProducto.Text = item.ProductoNombre.ToString();
                    txtMedida.Text = item.ProductoMedidaId.ToString();
                    txtCantidadStock.Text = item.StockCantidad.ToString();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal cantidad = decimal.Parse(txtAgregaCantidad.Text);
            StockNegocio negocio = new StockNegocio();
            negocio.IncrementarCantidadStock(int.Parse(Request.QueryString["Id"]), cantidad);

            Response.Redirect("InventarioPage.aspx", false);
        }

        protected void btoEliminar_Click(object sender, EventArgs e)
        {
            decimal cantidad = decimal.Parse(txtAgregaCantidad.Text);
            StockNegocio negocio = new StockNegocio();
            negocio.DecrementarCantidadStock(int.Parse(Request.QueryString["Id"]), cantidad);

            Response.Redirect("InventarioPage.aspx", false);
        }
    }
}