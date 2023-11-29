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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.User = txtUsuario.Text;
                usuario.Pass = txtContraseña.Text;
                if (negocio.Login(usuario) && usuario.User != null)
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblMsj.Text = "Usuario o Contraseña incorrecta, pruebe nuevamente.";
                    //  Response.Redirect("LoginPage.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}