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
            VentaHistorialDetalleNegocio ventaHistorialDetalleNegocio = new VentaHistorialDetalleNegocio();
            if (!IsPostBack)
            {
                try
                {
                    Session["listaVentaInforme"] = ventaHistorialDetalleNegocio.ObtenerVentasInforme();
                    dgvHistorialVentas.DataSource = Session["listaVentaInforme"];
                    dgvHistorialVentas.DataBind();

                    Session.Add("listaHistorialStock", stockHistorialNegocio.ListarStockHistorialGrilla());
                    dgvStockHistoria.DataSource = Session["listaHistorialStock"];
                    dgvStockHistoria.DataBind();

                    
                    lbVentaDia.Text = ventasHistorialNegocio.ObtenerCantidadVentasDelDia().ToString();
                    lbVentaMes.Text = ventasHistorialNegocio.ObtenerCantidadVentasDelMes().ToString();
                    lbVentaAnual.Text = ventasHistorialNegocio.ObtenerCantidadVentasDelAnio(DateTime.Now.Year).ToString();
                    lbMontoDia.Text = "$ " + (ventasHistorialNegocio.ObtenerTotalVentasHoy().ToString("N2"));
                    lbMontoMes.Text = "$ " + (ventasHistorialNegocio.ObtenerTotalVentasMesActual().ToString("N2"));
                    lbMontoAnual.Text = "$ " + (ventasHistorialNegocio.ObtenerTotalVentasAño(DateTime.Now.Year).ToString("N2"));

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

                List<VentaInforme> lista = (List<VentaInforme>)Session["listaVentaInforme"];
                List<VentaInforme> listaFiltrada = lista.FindAll(x => x.Fecha >= fechaDesde && x.Fecha <= fechaHasta); ;

                dgvHistorialVentas.DataSource = listaFiltrada;
                dgvHistorialVentas.DataBind();
            }
            Page.ClientScript.RegisterStartupScript(GetType(), "hash", "location.hash = '#stock-tab';", true);
        }

        protected void btnLimpiarVent_Click(object sender, EventArgs e)
        {
            txtDesdeV.Text = string.Empty;
            txtHastaV.Text = string.Empty;

            dgvHistorialVentas.DataSource = Session["listaVentaInforme"];
            dgvHistorialVentas.DataBind();

            Page.ClientScript.RegisterStartupScript(GetType(), "hash", "location.hash = '#stock-tab';", true);
        }

        protected void BtnbusquedaRapidaVent_Click(object sender, EventArgs e)
        {
            if (Session["listaVentaInforme"] != null)
            {
                List<VentaInforme> lista = (List<VentaInforme>)Session["listaVentaInforme"];
                

                List<VentaInforme> listaFiltrada = lista.FindAll(x => x.Producto.Nombre.ToUpper().Contains(TextBox3.Text.ToUpper()));

                dgvHistorialVentas.DataSource = listaFiltrada;
                dgvHistorialVentas.DataBind();
                Page.ClientScript.RegisterStartupScript(GetType(), "hash", "location.hash = '#stock-tab';", true);
            }
        }
        // Stock filtros-----------------------------------------------------------
        //-------------------------------------------------------------------------
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
            Page.ClientScript.RegisterStartupScript(GetType(), "hash", "location.hash = '#stock-tab';", true);
        }

        protected void btnLimpiarBusqStock_Click(object sender, EventArgs e)
        {
            txtDesde.Text = string.Empty;
            txtHasta.Text = string.Empty;

            dgvStockHistoria.DataSource = Session["listaHistorialStock"];
            dgvStockHistoria.DataBind();
            Page.ClientScript.RegisterStartupScript(GetType(), "hash", "location.hash = '#stock-tab';", true);
        }

        protected void btnBusqRapidaStock_Click(object sender, EventArgs e)
        {
            List<StockHistorialLista> lista = (List<StockHistorialLista>)Session["listaHistorialStock"];
            List<StockHistorialLista> listaFiltrada = lista.FindAll(x => x.producto.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()));           
            dgvStockHistoria.DataSource = listaFiltrada;
            dgvStockHistoria.DataBind();

            Page.ClientScript.RegisterStartupScript(GetType(), "hash", "location.hash = '#stock-tab';", true);
        }

        protected void dgvHistorialVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rowNumber = e.Row.RowIndex + 1; // El índice comienza desde cero, así que se suma 1

                // Encuentra el control donde deseas mostrar el número de fila
                TableCell cell = e.Row.Cells[0]; // Suponiendo que el número de fila irá en la primera columna

                // Agrega el número de fila a la celda
                cell.Text = rowNumber.ToString();
            }
        }
    }
}







