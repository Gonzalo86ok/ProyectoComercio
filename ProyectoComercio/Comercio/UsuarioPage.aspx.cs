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
    public partial class UsuarioPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo;
                UsuarioNegocio negocio = new UsuarioNegocio();

                nuevo = new Usuario(txtUsuario.Text, txtContraseña.Text, false);

                nuevo.User = txtUsuario.Text;
                nuevo.Pass = txtContraseña.Text;


                negocio.agregar(nuevo);
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