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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StockHistorialNegocio stockHistorialNegocio = new StockHistorialNegocio();
            VentasHistorialNegocio ventasHistorialNegocio = new VentasHistorialNegocio();
            if (!IsPostBack)
            {
                try
                {
                    List<StockHistorial> listaStockHistorials = stockHistorialNegocio.ListarTodosStockHistorial();
                    dgvStockHistoria.DataSource = listaStockHistorials;
                    dgvStockHistoria.DataBind();

                    List<VentasHistorial> listaVentas = ventasHistorialNegocio.ListarHistorialVentas();
                    dgvHistorialVentas.DataSource = listaVentas;
                    dgvHistorialVentas.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    throw;
                }
            }

           

        }
    }
}