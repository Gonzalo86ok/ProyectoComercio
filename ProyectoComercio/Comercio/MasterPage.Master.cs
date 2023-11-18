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

            if (!(Page is LoginPage || Page is RegistrarUsuario || Page is Default))
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    /* Session.Add("error", "Se necesita iniciar sesion con Usuario y Contraseña para acceder");
                     Response.Redirect("error.aspx", false);*/
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