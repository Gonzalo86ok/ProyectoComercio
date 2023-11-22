using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarActivos(string id = "")
        {
            List<Producto> lista = new List<Producto>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta =
                    "SELECT " +
                        "P.Id, " +
                        "P.Codigo, " +
                        "P.Nombre, " +
                        "P.Descripcion, " +
                        "P.Precio, " +
                        "P.Activo, " +
                        "C.Tipo AS Categoria, " +
                        "F.Nombre AS Fabricante, " +
                        "M.Tipo AS Medida " +
                    "FROM PRODUCTOS AS P " +
                    "INNER JOIN CATEGORIAS AS C ON P.IdCategoria = C.Id " +
                    "INNER JOIN FABRICANTES AS F ON P.IdFabricante = F.Id " +
                    "INNER JOIN MEDIDAS AS M ON P.IdMedida = M.Id ";
                if (id != "")
                    consulta += " and P.Id = " + id;

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    aux.Fabricante = new Fabricante();
                    aux.Fabricante.Nombre = (string)datos.Lector["Fabricante"];

                    aux.Medida = new Medida();
                    aux.Medida.Tipo = (string)datos.Lector["Medida"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Tipo = (string)datos.Lector["Categoria"];
                    if(aux.Activo == true)
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
        public Producto obtenerProducto(string id)
        {
            Producto producto = new Producto();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta =
                   "SELECT " +
                       "P.Id, " +
                       "P.Codigo, " +
                       "P.Nombre, " +
                       "P.Descripcion, " +
                       "P.Precio, " +
                       "P.Activo, " +
                       "C.Tipo AS Categoria, " +
                       "F.Nombre AS Fabricante, " +
                       "M.Tipo AS Medida " +
                   "FROM PRODUCTOS AS P " +
                   "INNER JOIN CATEGORIAS AS C ON P.IdCategoria = C.Id " +
                   "INNER JOIN FABRICANTES AS F ON P.IdFabricante = F.Id " +
                   "INNER JOIN MEDIDAS AS M ON P.IdMedida = M.Id where P.Id = @id" ;

                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    producto.Id = int.Parse(id);
                    producto.Codigo = (string)datos.Lector["Codigo"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["Precio"];                                      

                    producto.Fabricante = new Fabricante();
                    producto.Fabricante.Nombre = (string)datos.Lector["Fabricante"];

                    producto.Medida = new Medida();
                    producto.Medida.Tipo = (string)datos.Lector["Medida"];

                    producto.Categoria = new Categoria();
                    producto.Categoria.Tipo = (string)datos.Lector["Categoria"];                   
                }
                return producto;
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
        public Producto obtenerProducto(int id)
        {
            Producto producto = new Producto();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta =
                   "SELECT " +
                       "P.Id, " +
                       "P.Codigo, " +
                       "P.Nombre, " +
                       "P.Descripcion, " +
                       "P.Precio, " +
                       "P.Activo, " +
                       "C.Tipo AS Categoria, " +
                       "F.Nombre AS Fabricante, " +
                       "M.Tipo AS Medida " +
                   "FROM PRODUCTOS AS P " +
                   "INNER JOIN CATEGORIAS AS C ON P.IdCategoria = C.Id " +
                   "INNER JOIN FABRICANTES AS F ON P.IdFabricante = F.Id " +
                   "INNER JOIN MEDIDAS AS M ON P.IdMedida = M.Id WHERE P.Id = @Id";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    producto.Id = id;
                    producto.Codigo = (string)datos.Lector["Codigo"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["Precio"];

                    producto.Fabricante = new Fabricante();
                    producto.Fabricante.Nombre = (string)datos.Lector["Fabricante"];

                    producto.Medida = new Medida();
                    producto.Medida.Tipo = (string)datos.Lector["Medida"];

                    producto.Categoria = new Categoria();
                    producto.Categoria.Tipo = (string)datos.Lector["Categoria"];
                }

                return producto;
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
        public void agregar(Producto nuevo)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                  string consulta = "INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, IdCategoria, IdFabricante, IdMedida, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdCategoria, @IdFabricante, @IdMedida, @Precio)";

                dato.setearConsulta(consulta);

                dato.setearParametro("@Codigo", nuevo.Codigo);
                dato.setearParametro("@Nombre", nuevo.Nombre);
                dato.setearParametro("@Descripcion", nuevo.Descripcion);           
                dato.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                dato.setearParametro("@IdFabricante", nuevo.Fabricante.Id);
                dato.setearParametro("@IdMedida", nuevo.Medida.Id);
                dato.setearParametro("@Precio", nuevo.Precio);              

                dato.ejecutarAccion();                              
                
                int idProducto = obtenerIdProductoPorCodigo(nuevo.Codigo);
                StockNegocio stockNegocio = new StockNegocio();
                stockNegocio.CrearStock(idProducto);
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
        public void modificar(Producto nuevo)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                string consulta = "UPDATE PRODUCTOS SET Codigo = @Codigo , Nombre = @Nombre, Descripcion = @Descripcion, IdCategoria = @IdCategoria, IdFabricante = @IdFabricante, IdMedida = @IdMedida, Precio = @Precio where Id = @Id";

                dato.setearConsulta(consulta);

                dato.setearParametro("@Id", nuevo.Id);
                dato.setearParametro("@Codigo", nuevo.Codigo);
                dato.setearParametro("@Nombre", nuevo.Nombre);
                dato.setearParametro("@Descripcion", nuevo.Descripcion);
                dato.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                dato.setearParametro("@IdFabricante", nuevo.Fabricante.Id);
                dato.setearParametro("@IdMedida", nuevo.Medida.Id);
                dato.setearParametro("@Precio", nuevo.Precio);
                dato.setearParametro("@Activo", nuevo.Activo);

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
        public void eliminacionLogica(int id)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                string consulta = "update PRODUCTOS set Activo = 0 where Id = @Id";

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
        public int obtenerIdProductoPorCodigo(string codigo)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                string consulta = "SELECT Id FROM PRODUCTOS WHERE Codigo = @Codigo AND Activo = 1";

                dato.setearConsulta(consulta);
                dato.setearParametro("@Codigo", codigo);
                dato.ejecutarLectura();

                if (dato.Lector.Read())
                {
                    return (int)dato.Lector["Id"];
                }
                // Manejar el caso en que no se encontró el producto
                throw new Exception("No se encontró el producto con el código proporcionado.");
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
