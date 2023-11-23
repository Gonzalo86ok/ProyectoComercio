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
                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;


                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
                {

                    lblMensaje2.Text = "El usuario y la contraseña son obligatorios.";
                    return;
                }

                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                if (negocio.UsuarioExiste(usuario))
                {
                    lblMensaje2.Text = "El usuario ya existe. Por favor, elija otro.";
                    return;
                }

                user.User = usuario;

                user.Pass = contraseña;
                int id = negocio.insertarNuevo(user);

                Response.Redirect("LoginPage.aspx", false);
            }
            catch (Exception ex)
            {

                lblMensaje2.Text = "El usuario ya existe. Por favor, elija otro.";
            }
        }
    }
}