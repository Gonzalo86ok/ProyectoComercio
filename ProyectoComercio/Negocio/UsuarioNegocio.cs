using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public void agregar(Usuario nuevoUsuario)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                //string consulta = "INSERT INTO USUARIOS (Usuario, Contraseña, TipoUsuario) VALUES ('@user', '@pass', @tipoUsuario)";
                string consulta = "INSERT INTO USUARIOS (Usuario, Contraseña, TipoUsuario) VALUES (@user, @pass, @tipoUsuario)";
                datos.setearConsulta(consulta);

                datos.setearParametro("@user", nuevoUsuario.User);
                datos.setearParametro("@pass", nuevoUsuario.Pass);
                datos.setearParametro("@tipoUsuario", nuevoUsuario.TipoUsuario);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
