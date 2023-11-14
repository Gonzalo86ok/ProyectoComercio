using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar(string id = "")
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "select Id, Tipo, Activo from CATEGORIAS";
                if (id != "")
                    consulta += " and Id = " + id;

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (string)datos.Lector["Tipo"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    if (aux.Activo == true)
                        lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Categoria obtenerCategoria(string id)
        {
            Categoria categoria = new Categoria();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "select Tipo from CATEGORIAS where Id = @id ";              

                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    categoria.Id = int.Parse(id);
                    categoria.Tipo = (string)datos.Lector["Tipo"];
                }
                return categoria;
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
        public void agregarCategoria(Categoria nuevaCategoria)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO CATEGORIAS (Tipo) VALUES (@tipo)";
                datos.setearConsulta(consulta);

                datos.setearParametro("@tipo", nuevaCategoria.Tipo);

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
        public void modificarCategoria(Categoria nuevaCategoria)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                string consulta = "update CATEGORIAS set Tipo = @tipo where Id = @id";
                datos.setearConsulta(consulta);

                datos.setearParametro("@tipo", nuevaCategoria.Tipo);
                datos.setearParametro("@id", nuevaCategoria.Id);

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
        public void eliminacionLogica(int id)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                string consulta = "update CATEGORIAS set Activo = 0 where Id = @Id";

                dato.setearConsulta(consulta);

                dato.setearParametro("@Id", id);

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

