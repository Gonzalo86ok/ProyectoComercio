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
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Necesitas Registro de Administrador");
                Response.Redirect("error.aspx", false);
            }

            Usuario usuario = new Usuario();
            UsuarioNegocio dato = new UsuarioNegocio();
            if (!IsPostBack)
            {
                List<Usuario> listaUsuario = dato.ListarUsuariosActivos();

                dgvUsuario.DataSource = listaUsuario;
                dgvUsuario.DataBind();

            }
        }
        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario(txtUsuario.Text, txtContraseña.Text, false, true);

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.agregar(nuevo);

                Response.Redirect("UsuarioPage.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }
        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string selectedId = btn.CommandArgument;
            Response.Redirect("FormularioUsuario.aspx?Id=" + selectedId);
        }
        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btn)
                {
                    string commandArgument = btn.CommandArgument;

                    if (int.TryParse(commandArgument, out int userId))
                    {
                        UsuarioNegocio negocio = new UsuarioNegocio();
                        negocio.eliminacionLogica(userId);
                        Response.Redirect("UsuarioPage.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
        protected void dgvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Código del evento aquí
        }

    }
}