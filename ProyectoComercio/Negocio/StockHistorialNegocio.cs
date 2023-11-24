using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class StockHistorialNegocio
    {
        public List<StockHistorial> ListarTodosStockHistorial()
        {
            List<StockHistorial> lista = new List<StockHistorial>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                string consulta = "SELECT Id, IdProducto, CantidadAnterior, CantidadNueva, FechaHoraRegistro, Operacion, Comentario, UsuarioId " +
                   "FROM StockHistorial ORDER BY FechaHoraRegistro DESC";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    StockHistorial historial = new StockHistorial();
                    historial.Id = (int)datos.Lector["Id"];
                    historial.IdProducto = (int)datos.Lector["IdProducto"];
                    historial.CantidadAnterior = (decimal)datos.Lector["CantidadAnterior"];
                    historial.CantidadNueva = (decimal)datos.Lector["CantidadNueva"];
                    historial.FechaHoraRegistro = (DateTime)datos.Lector["FechaHoraRegistro"];
                    historial.Operacion = (string)datos.Lector["Operacion"];
                    historial.Comentario = datos.Lector["Comentario"] != DBNull.Value ? (string)datos.Lector["Comentario"] : string.Empty;
                    historial.IdUsuario = (int)datos.Lector["UsuarioId"];

                    lista.Add(historial);
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
        // Para listar por producto
        public List<StockHistorial> ListarStockHistorial(int idProducto)
        {
            List<StockHistorial> lista = new List<StockHistorial>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                string consulta = "SELECT Id, IdProducto, CantidadAnterior, CantidadNueva, FechaHoraRegistro, Operacion, Comentario, IdUsuario " +
                  "FROM StockHistorial WHERE IdProducto = @IdProducto ORDER BY FechaHoraRegistro DESC";
                datos.setearConsulta(consulta);
                datos.setearParametro("@IdProducto", idProducto);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    StockHistorial historial = new StockHistorial();
                    historial.Id = (int)datos.Lector["Id"];
                    historial.IdProducto = (int)datos.Lector["IdProducto"];
                    historial.CantidadAnterior = (decimal)datos.Lector["CantidadAnterior"];
                    historial.CantidadNueva = (decimal)datos.Lector["CantidadNueva"];
                    historial.FechaHoraRegistro = (DateTime)datos.Lector["FechaHoraRegistro"];
                    historial.Operacion = (string)datos.Lector["Operacion"];
                    historial.Comentario = (string)datos.Lector["Comentario"];
                    historial.IdUsuario = (int)datos.Lector["IdUsuario"];



                    lista.Add(historial);
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
        public void InsertarStockHistorial(StockHistorial historial)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                string consulta = "INSERT INTO StockHistorial (IdProducto, CantidadAnterior, CantidadNueva, FechaHoraRegistro, Operacion, Comentario, UsuarioId) " +
                                  "VALUES (@IdProducto, @CantidadAnterior, @CantidadNueva, @FechaHoraRegistro, @Operacion, @Comentario, @UsuarioId)";

                datos.setearConsulta(consulta);

                datos.setearParametro("@IdProducto", historial.IdProducto);
                datos.setearParametro("@CantidadAnterior", historial.CantidadAnterior);
                datos.setearParametro("@CantidadNueva", historial.CantidadNueva);
                datos.setearParametro("@FechaHoraRegistro", historial.FechaHoraRegistro);
                datos.setearParametro("@Operacion", historial.Operacion);
                datos.setearParametro("@Comentario", historial.Comentario ?? (object)DBNull.Value);
                datos.setearParametro("@UsuarioId", historial.IdUsuario);

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
        public List<StockHistorialLista> ListarStockHistorialGrilla()
        {
            List<StockHistorialLista> lista = new List<StockHistorialLista>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT sh.Id, sh.IdProducto, sh.CantidadAnterior, sh.CantidadNueva, sh.FechaHoraRegistro, sh.Operacion, sh.Comentario, sh.UsuarioId AS HistorialUsuarioId, " +
                                  "p.Id AS ProductoId, p.Nombre AS ProductoNombre, p.Codigo AS ProductoCodigo, " +
                                  "u.Id AS UsuarioId, u.Usuario AS UsuarioNombre " +
                                  "FROM StockHistorial sh " +
                                  "INNER JOIN PRODUCTOS p ON sh.IdProducto = p.Id " +
                                  "INNER JOIN USUARIOS u ON sh.UsuarioId = u.Id";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    StockHistorialLista historial = new StockHistorialLista();
                    historial.Id = (int)datos.Lector["Id"];
                    historial.CantidadAnterior = (decimal)datos.Lector["CantidadAnterior"];
                    historial.CantidadNueva = (decimal)datos.Lector["CantidadNueva"];
                    historial.FechaHoraRegistro = (DateTime)datos.Lector["FechaHoraRegistro"];
                    historial.Operacion = (string)datos.Lector["Operacion"];
                    historial.Comentario = datos.Lector["Comentario"] != DBNull.Value ? (string)datos.Lector["Comentario"] : string.Empty;

                    historial.producto = new Producto
                    {
                        Id = (int)datos.Lector["ProductoId"],
                        Nombre = (string)datos.Lector["ProductoNombre"],
                        Codigo = (string)datos.Lector["ProductoCodigo"]
                        // Agrega otros campos si es necesario
                    };

                    historial.usuario = new Usuario
                    {
                        Id = (int)datos.Lector["UsuarioId"],
                        User = (string)datos.Lector["UsuarioNombre"]
                        // Agrega otros campos si es necesario
                    };

                    lista.Add(historial);
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



    }
}
