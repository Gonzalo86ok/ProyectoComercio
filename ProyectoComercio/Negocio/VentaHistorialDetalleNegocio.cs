using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaHistorialDetalleNegocio
    {
        public List<VentaHistorialDetalle> ListarDetallesVenta(int idVentaHistorial)
        {
            List<VentaHistorialDetalle> lista = new List<VentaHistorialDetalle>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT Id, IdVenta, NumeroOrden, IdProducto, Precio, Cantidad FROM VentaHistorialDetalle WHERE IdVenta = @IdVentaHistorial";

                datos.setearConsulta(consulta);
                datos.setearParametro("@IdVentaHistorial", idVentaHistorial);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    VentaHistorialDetalle detalle = new VentaHistorialDetalle();
                    detalle.Id = (int)datos.Lector["Id"];
                    detalle.IdVenta = (int)datos.Lector["IdVenta"];
                    detalle.NumeroOrden = (int)datos.Lector["NumeroOrden"];
                    detalle.IdProducto = (int)datos.Lector["IdProducto"];
                    detalle.Precio = (decimal)datos.Lector["Precio"];
                    detalle.Cantidad = (decimal)datos.Lector["Cantidad"];

                    lista.Add(detalle);
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

        public void AgregarDetalleVenta(VentaHistorialDetalle detalle)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO VentaHistorialDetalle (IdVenta, NumeroOrden, IdProducto, Precio, Cantidad) VALUES (@IdVenta, @NumeroOrden, @IdProducto, @Precio, @Cantidad)";

                datos.setearConsulta(consulta);
                datos.setearParametro("@IdVenta", detalle.IdVenta);
                datos.setearParametro("@NumeroOrden", detalle.NumeroOrden);
                datos.setearParametro("@IdProducto", detalle.IdProducto);
                datos.setearParametro("@Precio", detalle.Precio);
                datos.setearParametro("@Cantidad", detalle.Cantidad);

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
        public void GuardarVentaHistorialDetalle(List<Venta> listaVentas, int idVenta)
        {
            VentaHistorialDetalleNegocio detalleNegocio = new VentaHistorialDetalleNegocio();
            VentaHistorialDetalle ventaHistorialDetalle = new VentaHistorialDetalle();

            foreach (Venta vent in listaVentas)
            {
                ventaHistorialDetalle.IdVenta = idVenta;
                ventaHistorialDetalle.NumeroOrden = vent.Numero;
                ventaHistorialDetalle.IdProducto = vent.Producto.Id;
                ventaHistorialDetalle.Precio = vent.Producto.Precio;
                ventaHistorialDetalle.Cantidad = vent.Cantidad;

                detalleNegocio.AgregarDetalleVenta(ventaHistorialDetalle);
            }

        }

    }
}
