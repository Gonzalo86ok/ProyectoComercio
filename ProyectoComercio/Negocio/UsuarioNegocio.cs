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

        public List<Usuario> ListarUsuariosActivos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                
                datos.setearConsulta("SELECT ID, Usuario, TipoUsuario FROM USUARIOS WHERE Activo = 1");
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
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Usuario nuevoUsuario)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO USUARIOS (Usuario, Contraseña, TipoUsuario,Activo) VALUES (@user, @pass, @tipoUsuario,@activo)";
                datos.setearConsulta(consulta);

                datos.setearParametro("@user", nuevoUsuario.User);
                datos.setearParametro("@pass", nuevoUsuario.Pass);
                datos.setearParametro("@tipoUsuario", nuevoUsuario.TipoUsuario);
                datos.setearParametro("@activo", nuevoUsuario.Activo);

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

        public void modificarUsuario(Usuario nuevo)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {

                string consulta = "UPDATE USUARIOS SET Usuario = @nuevoUser, Contraseña = @NuevaPass WHERE ID = @Id";
                datos.setearConsulta(consulta);

                datos.setearParametro("@nuevoUser", nuevo.User);
                datos.setearParametro("@NuevaPass", nuevo.Pass);
                datos.setearParametro("@Id", nuevo.Id);

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
        public void eliminacionLogica(int Id)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                string consulta = "update USUARIOS set Activo = 0 where ID = @Id";

                dato.setearConsulta(consulta);

                dato.setearParametro("@Id", Id);

                dato.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dato.cerrarConexion();
            }
        }
    }
}
