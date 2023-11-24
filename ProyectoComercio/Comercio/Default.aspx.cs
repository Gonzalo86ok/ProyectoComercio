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
            VentasHistorialNegocio ventasHistorialNegocio = new VentasHistorialNegocio();
            StockHistorialNegocio stockHistorialNegocio = new StockHistorialNegocio();
            if (!IsPostBack)
            {
                try
                {
                    Session.Add("listaHistorialVentas", ventasHistorialNegocio.ListarHistorialVentas());
                    dgvHistorialVentas.DataSource = Session["listaHistorialVentas"];
                    dgvHistorialVentas.DataBind();

                    Session.Add("listaHistorialStock", stockHistorialNegocio.ListarStockHistorialGrilla());
                    dgvStockHistoria.DataSource = Session["listaHistorialStock"];
                    dgvStockHistoria.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    throw;
                }
            }
        }

        protected void BtnFechaVen_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde, fechaHasta;

            if (DateTime.TryParse(txtDesdeV.Text, out fechaDesde) && DateTime.TryParse(txtHastaV.Text, out fechaHasta))
            {
                fechaDesde = fechaDesde.Date;
                fechaHasta = fechaHasta.Date.AddDays(1).AddTicks(-1);

                List<VentasHistorial> lista = (List<VentasHistorial>)Session["listaHistorialVentas"];
                List<VentasHistorial> listaFiltrada = lista.FindAll(x => x.FechaHoraRegistro >= fechaDesde && x.FechaHoraRegistro <= fechaHasta); ;
                
                dgvStockHistoria.DataSource = listaFiltrada;
                dgvStockHistoria.DataBind();
            }
        }

        protected void btnLimpiarVent_Click(object sender, EventArgs e)
        {
            txtDesdeV.Text = string.Empty;
            txtHastaV.Text = string.Empty;
        }

        protected void BtnbusquedaRapidaVent_Click(object sender, EventArgs e)
        {
            List<VentasHistorial> lista = (List<VentasHistorial>)Session["listaHistorialVentas"];
            List<VentasHistorial> listaFiltrada = lista;
            dgvStockHistoria.DataSource = listaFiltrada;
            dgvStockHistoria.DataBind();
        }

        protected void btnStockFecha_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde, fechaHasta;         

            if (DateTime.TryParse(txtDesde.Text, out fechaDesde) && DateTime.TryParse(txtHasta.Text, out fechaHasta))
            {
                fechaDesde = fechaDesde.Date;
                fechaHasta = fechaHasta.Date.AddDays(1).AddTicks(-1);

                List<StockHistorialLista> lista = (List<StockHistorialLista>)Session["listaHistorialStock"];
                List<StockHistorialLista> listaFiltrada = lista.FindAll(x => x.FechaHoraRegistro >= fechaDesde && x.FechaHoraRegistro <= fechaHasta);

                dgvStockHistoria.DataSource = listaFiltrada;
                dgvStockHistoria.DataBind();
            }
        }

        protected void btnLimpiarBusqStock_Click(object sender, EventArgs e)
        {
            txtDesde.Text = string.Empty;
            txtHasta.Text = string.Empty;
        }

        protected void btnBusqRapidaStock_Click(object sender, EventArgs e)
        {
            List<StockHistorialLista> lista = (List<StockHistorialLista>)Session["listaHistorialStock"];
            List<StockHistorialLista> listaFiltrada = lista.FindAll(x => x.producto.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()) && x.usuario.User.ToUpper().Contains(txtBusqueda.Text.ToUpper()));           
            dgvStockHistoria.DataSource = listaFiltrada;
            dgvStockHistoria.DataBind();
        }
    }
}







