using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class FormularioStock : System.Web.UI.Page
    {
        decimal cantidad;
        bool bandera;
        decimal cantidadDeStock;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                    cantidadDeStock = item.StockCantidad;


                    txtCodigoProducto.Enabled = false;
                    txtNombreProducto.Enabled = false;
                    txtMedida.Enabled = false;
                    txtCantidadStock.Enabled = false;

                    txtMotivo.Enabled = false;
                    btnAceptar.Enabled = false;

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

            if (!decimal.TryParse(txtAgregaCantidad.Text, out cantidad) || cantidad < 0 || txtAgregaCantidad.Text.Contains("."))
            {
                lblMensaje.Text = "Ingrese una cantidad válida y no negativa, sin puntos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
            else if (cantidad == 0 || cantidad > 9999999)
            {
                lblMensaje.Text = "Está intentando ingresar un valor incorrecto.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
            else
            {
                txtAgregaCantidad.Enabled = false;
                lblMensaje.Text = "Ingreso Correcto, Aceptar para guardar cambios..";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                StockNegocio negocio = new StockNegocio();

                btnAgregar.Enabled = false;
                btoEliminar.Enabled = false;

                bandera = true;
                ViewState["Bandera"] = bandera;
                btnAceptar.Enabled = true;

            }
        }

        protected void btoEliminar_Click(object sender, EventArgs e)
        {



            if (!decimal.TryParse(txtAgregaCantidad.Text, out cantidad) || cantidad < 0 || txtAgregaCantidad.Text.Contains("."))
            {
                lblMensaje.Text = "Ingrese una cantidad válida y no negativa, sin puntos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
            else if (cantidad == 0 || cantidad > 9999999)
            {
                lblMensaje.Text = "Está intentando ingresar un valor incorrecto.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
            else if ((cantidad - cantidadDeStock) > 0)
            {
                lblMensaje.Text = "El Stock no puede ser negativo...";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
            else
            {
                txtAgregaCantidad.Enabled = false;
                txtMotivo.Enabled = true;

                lblMensaje.Text = "Ingreso Correcto...";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Visible = true;

                lbMotivo.Text = "Ingresar motivo ";
                lbMotivo.ForeColor = System.Drawing.Color.Yellow;
                lbMotivo.Visible = true;

                btnAgregar.Enabled = false;
                btoEliminar.Enabled = false;

                lbAceptarCambio.Text = " Aceptar para confirmar el cambio.. ";
                lbAceptarCambio.ForeColor = System.Drawing.Color.Yellow;
                lbAceptarCambio.Visible = true;

                bandera = false;
                ViewState["Bandera"] = bandera;

                btnAceptar.Enabled = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventarioPage.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                decimal cantidad = decimal.Parse(txtAgregaCantidad.Text);

                StockNegocio negocio = new StockNegocio();
                StockHistorialNegocio stockHistorialNegocio = new StockHistorialNegocio();
                StockHistorial stockHistorial = new StockHistorial();

                bandera = (bool)ViewState["Bandera"];
                if (bandera)
                {
                    negocio.IncrementarCantidadStock(int.Parse(Request.QueryString["Id"]), cantidad);

                    stockHistorial.IdProducto = int.Parse(Request.QueryString["Id"]);
                    stockHistorial.CantidadAnterior = cantidadDeStock;
                    stockHistorial.CantidadNueva = cantidad;
                    stockHistorial.FechaHoraRegistro = DateTime.Now;
                    stockHistorial.Operacion = "Ingreso";
                    stockHistorial.Comentario = null; // No se proporciona comentario
                    stockHistorial.IdUsuario = 1;// remplazar con el usuario cundo se cargue en session;

                    stockHistorialNegocio.InsertarStockHistorial(stockHistorial);
                }
                else
                {
                    negocio.DecrementarCantidadStock(int.Parse(Request.QueryString["Id"]), cantidad);

                    stockHistorial.IdProducto = int.Parse(Request.QueryString["Id"]);
                    stockHistorial.CantidadAnterior = cantidadDeStock;
                    stockHistorial.CantidadNueva = cantidad;
                    stockHistorial.FechaHoraRegistro = DateTime.Now;
                    stockHistorial.Operacion = "Egreso";
                    stockHistorial.Comentario = txtMotivo.Text; // Si se proporciona comentario
                    stockHistorial.IdUsuario = 1;// remplazar con el usuario cundo se cargue en session;

                    stockHistorialNegocio.InsertarStockHistorial(stockHistorial);
                }
                Response.Redirect("InventarioPage.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }

}