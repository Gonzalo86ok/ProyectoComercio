using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class StockNegocio
    {
        public List<StockItem> listarStockItem()
        {
            List<StockItem> lista = new List<StockItem>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT s.Id AS StockId, p.Codigo AS ProductoCodigo, p.Nombre AS ProductoNombre, m.Tipo AS ProductoMedidaId, s.Cantidad AS StockCantidad " +
                                      "FROM Stock s " +
                                      "INNER JOIN PRODUCTOS p ON s.IdProducto = p.Id " +
                                      "INNER JOIN MEDIDAS m ON p.IdMedida = m.Id";


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    StockItem aux = new StockItem();
                    aux.StockId = (int)datos.Lector["StockId"];
                    aux.ProductoNombre = (string)datos.Lector["ProductoNombre"];
                    aux.ProductoCodigo = (string)datos.Lector["ProductoCodigo"];
                    aux.ProductoMedidaId = (string)datos.Lector["ProductoMedidaId"];
                    aux.StockCantidad = (decimal)datos.Lector["StockCantidad"];

                    lista.Add(aux);
                }

                datos.cerrarConexion();

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

   
        public StockItem ObtenerStockItemPorId(int stockId)
        {
            StockItem stockItem = null;
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT s.Id AS StockId, p.Codigo AS ProductoCodigo, p.Nombre AS ProductoNombre, m.Tipo AS ProductoMedidaId, s.Cantidad AS StockCantidad FROM Stock s INNER JOIN Productos p ON s.IdProducto = p.Id INNER JOIN MEDIDAS m ON p.IdMedida = m.Id WHERE s.Id = @StockId";


                datos.setearConsulta(consulta);
                datos.setearParametro("@StockId", stockId);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    stockItem = new StockItem();
                    stockItem.StockId = (int)datos.Lector["StockId"];
                    stockItem.ProductoNombre = (string)datos.Lector["ProductoNombre"];
                    stockItem.ProductoCodigo = (string)datos.Lector["ProductoCodigo"];
                    stockItem.ProductoMedidaId = (string)datos.Lector["ProductoMedidaId"];
                    stockItem.StockCantidad = (decimal)datos.Lector["StockCantidad"];
                }

                datos.cerrarConexion();

                return stockItem;
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
        public void IncrementarCantidadStock(int stockId, decimal cantidadAIncrementar)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                // Consulta SQL para actualizar la cantidad de stock sumando la cantidad a incrementar
                string consulta = "UPDATE Stock SET Cantidad = Cantidad + @CantidadIncrementar WHERE Id = @StockId";
                datos.setearConsulta(consulta);
                datos.setearParametro("@CantidadIncrementar", cantidadAIncrementar);
                datos.setearParametro("@StockId", stockId);

                datos.ejecutarAccion(); // Ejecutar una acción (actualización en este caso)

                datos.cerrarConexion();
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
        public void DecrementarCantidadStock(int stockId, decimal cantidadADecrementar)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                // Consulta SQL para actualizar la cantidad de stock restando la cantidad a decrementar
                string consulta = "UPDATE Stock SET Cantidad = Cantidad - @CantidadADecrementar WHERE Id = @StockId";
                datos.setearConsulta(consulta);
                datos.setearParametro("@CantidadADecrementar", cantidadADecrementar);
                datos.setearParametro("@StockId", stockId);

                datos.ejecutarAccion(); // Ejecutar una acción (actualización en este caso)

                datos.cerrarConexion();
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

        public void CraarStock (int idProducto)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                string consulta = "INSERT INTO STOCK (IdProducto, Cantidad, Activo) VALUES (@IdProducto, 0, 1)";
                dato.setearConsulta (consulta);
                dato.setearParametro("@IdProducto", idProducto);
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
