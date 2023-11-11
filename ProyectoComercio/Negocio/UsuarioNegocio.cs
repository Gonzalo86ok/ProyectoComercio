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
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("Select ID,Usuario, TipoUsuario From USUARIOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.User = (string)datos.Lector["Usuario"];
                    aux.TipoUsuario = (int)(datos.Lector["TipoUsuario"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Empledo;

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
