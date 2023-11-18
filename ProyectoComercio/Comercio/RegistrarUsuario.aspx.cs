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
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAgregarUser_Click1(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                user.User = txtUsuario.Text;
                user.Pass = txtContraseña.Text;
                int id = negocio.insertarNuevo(user);

                Response.Redirect("LoginPage.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}