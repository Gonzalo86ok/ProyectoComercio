using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Comercio
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] as Usuario;
            if (usuario != null && Negocio.Seguridad.sesionActiva(usuario))
            {
                lblNombreUsuario.Text = usuario.User;
            }

            
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    
                    Response.Redirect("LoginPage.aspx", false);
                }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LoginPage.aspx");
        }
    }
}