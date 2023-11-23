using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Comercio
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioPage.aspx", false);
        }
        protected void btnModificacion_Click1(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;
                nuevo.User = usuario;
                nuevo.Pass = contraseña;
                if (negocio.UsuarioExiste(usuario))
                {
                    lblMensaje2.Text = "El usuario ya existe. Por favor, elija otro.";
                    return;
                }
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
                {

                    lblMensaje2.Text = "El usuario y la contraseña son obligatorios.";
                    return;
                }

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["Id"]);
                    negocio.modificarUsuario(nuevo);
                }
                else
                    negocio.modificarUsuario(nuevo);

                Response.Redirect("UsuarioPage.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }


        }
    }
}