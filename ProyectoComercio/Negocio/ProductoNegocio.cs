using Dominio;
using System;
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
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT p.Id, p.Codigo, p.Nombre, p.Descripcion, p.IdFabricante, p.IdCategoria, p.IdMedida, p.Precio, p.Activo,\r\n       f.Nombre AS NombreFabricante, c.Tipo AS TipoCategoria, me.Tipo AS TipoMedida\r\nFROM PRODUCTOS AS p\r\nINNER JOIN FABRICANTES AS f ON p.IdFabricante = f.Id\r\nINNER JOIN CATEGORIAS AS c ON p.IdCategoria = c.Id\r\nINNER JOIN MEDIDAS AS me ON p.IdMedida = me.Id\r\n";


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    aux.Fabricante = new Fabricante();
                    aux.Fabricante.Id = (int)datos.Lector["Id"];
                    aux.Fabricante.Nombre = (string)datos.Lector["Nombre"];
                    
                    aux.Medida = new Medida();
                    aux.Medida.Id = (int)datos.Lector["IdMedida"];
                    aux.Medida.Tipo = (string)datos.Lector["Tipo"];
                    
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Categoria")))
                    {
                        aux.Categoria.Tipo = (string)datos.Lector["Tipo"];
                    }
                    else
                    {
                        aux.Categoria.Tipo = "";
                    }
                    
                    aux.Precio = (decimal)datos.Lector["Precio"];
                   
                    aux.Activo = (bool)datos.Lector["Activo"];

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
        public List<Producto> listar2()
        {
            List<Producto> lista = new List<Producto>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT p.Id, p.Codigo, p.Nombre, p.Descripcion, p.IdMarca, p.IdCategoria, p.IdMedida, p.Precio, p.Activo, " +
                                 "m.Nombre AS NombreMarca, c.Tipo AS TipoCategoria, me.Tipo AS TipoMedida " +
                                 "FROM PRODUCTOS AS p " +
                                 "INNER JOIN MARCAS AS m ON p.IdMarca = m.Id " +
                                 "INNER JOIN CATEGORIAS AS c ON p.IdCategoria = c.Id " +
                                 "INNER JOIN MEDIDAS AS me ON p.IdMedida = me.Id";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    // Create a new Producto object and populate its properties.
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    // Create a Fabricante object and populate its properties.
                    aux.Fabricante = new Fabricante();
                    aux.Fabricante.Id = (int)datos.Lector["IdMarca"];
                    aux.Fabricante.Nombre = (string)datos.Lector["NombreMarca"];

                    // Create a Medida object and populate its properties.
                    aux.Medida = new Medida();
                    aux.Medida.Id = (int)datos.Lector["IdMedida"];
                    aux.Medida.Tipo = (string)datos.Lector["TipoMedida"];

                    // Create a Categoria object and populate its properties.
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Tipo = (string)datos.Lector["TipoCategoria"];

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    // Add the populated Producto object to the list.
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex; // You may want to handle the exception more gracefully.
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
                string consulta = "INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)";

                dato.setearConsulta(consulta);

                
                dato.setearParametro("@Codigo", nuevo.Codigo);
                dato.setearParametro("@Nombre", nuevo.Nombre);
                dato.setearParametro("@Descripcion", nuevo.Descripcion);
                dato.setearParametro("@IdMarca", nuevo.Fabricante.Id); 
                dato.setearParametro("@IdCategoria", nuevo.Categoria.Id); 
                dato.setearParametro("@Precio", nuevo.Precio);

                
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
