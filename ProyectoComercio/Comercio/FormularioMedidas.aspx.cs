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
    public partial class FormularioMedidas : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                MedidaNegocio medida = new MedidaNegocio();
                Medida seleccionado = medida.obtenerMedida(id);

                TxtMedida.Text = seleccionado.Tipo;
                btnAgregarMedida.Text = "Modificar";
            }
        }
        protected void btnAgregarMedida_Click(object sender, EventArgs e)
        {
            try
            {
                Medida nuevo = new Medida();
                MedidaNegocio medidaNegocio = new MedidaNegocio();

                string medida = TxtMedida.Text.Trim();

                // Validar si el campo de la medida está vacío
                if (string.IsNullOrWhiteSpace(medida))
                {
                    // Manejar la validación de campo vacío aquí
                    // Por ejemplo, cambiar el estilo del campo de texto a 'is-invalid'
                    TxtMedida.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    // El campo es válido, cambiar el estilo a 'is-valid'
                    TxtMedida.CssClass = "form-control is-valid";
                }

                nuevo.Tipo = medida;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    medidaNegocio.modificarMedida(nuevo);
                    Response.Redirect("Productos.aspx", false);
                }
                else
                {
                    if (medidaNegocio.tipoRepetido(nuevo.Tipo))
                    {
                        lblMensajeError.Text = "El tipo de medida ya existe. No se puede ingresar.";
                        lblMensajeError.Visible = true;
                        TxtMedida.Text = "";
                        TxtMedida.CssClass = "form-control is-valid";
                    }
                    else
                    {
                        lblMensajeError.Visible = false;                       
                        medidaNegocio.agregarMedida(nuevo);
                        Response.Redirect("Productos.aspx", false);
                    }
                }               
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnCancelarMedida_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
        protected void btnEliminarMedida_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    MedidaNegocio medida = new MedidaNegocio();
                    medida.eliminacionLogica(int.Parse(Request.QueryString["id"]));
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