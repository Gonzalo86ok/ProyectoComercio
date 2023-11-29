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
    public partial class FormularioFabricante : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                FabricanteNegocio categoria = new FabricanteNegocio();
                Fabricante seleccionado = categoria.obtenerFabricante(id);

                TxtFabricante.Text = seleccionado.Nombre;
                btnAgregarFabricante.Text = "Modificar";
            }
        }
        protected void agregarFabricante_Click(object sender, EventArgs e)
        {
            try
            {
                Fabricante nuevo = new Fabricante();
                FabricanteNegocio fabricanteNegocio = new FabricanteNegocio();
                string fabricante = TxtFabricante.Text.Trim(); 

                // Validar si el campo del fabricante está vacío
                if (string.IsNullOrWhiteSpace(fabricante))
                {
                    // Manejar la validación de campo vacío aquí
                    // Por ejemplo, cambiar el estilo del campo de texto a 'is-invalid'
                    TxtFabricante.CssClass = "form-control is-invalid";
                    return;
                }
                else
                {
                    // El campo es válido, cambiar el estilo a 'is-valid'
                    TxtFabricante.CssClass = "form-control is-valid";
                }

                nuevo.Nombre = fabricante;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    fabricanteNegocio.modificarFabricante(nuevo);
                    Response.Redirect("Productos.aspx", false);
                }
                else
                {
                    if(fabricanteNegocio.nombreRepetido(nuevo.Nombre))
                    {
                        lblMensajeError.Text = "El nombre del fabeicante está repetido. No se puede ingresar.";
                        lblMensajeError.Visible = true;
                        TxtFabricante.Text = "";
                        TxtFabricante.CssClass = "form-control is-valid";
                    }
                    else
                    {
                        lblMensajeError.Visible = false;
                        fabricanteNegocio.agregarFabricante(nuevo);
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
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    FabricanteNegocio fabricante = new FabricanteNegocio();
                    fabricante.eliminacionLogica(int.Parse(Request.QueryString["id"]));
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