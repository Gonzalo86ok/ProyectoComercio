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
        public List<VentaInforme> ObtenerVentasInforme()
        {
            List<VentaInforme> ventas = new List<VentaInforme>();

            string consulta = @"SELECT
                                    VHD.IdVenta AS NroVenta,
                                    VHD.NumeroOrden AS Numero,
                                    P.Nombre AS ProductoNombre,
                                    VHD.Cantidad AS Cantidad,
                                    VHD.Precio * VHD.Cantidad AS Monto,
                                    VH.FechaHoraRegistro AS Fecha,
                                    U.Usuario AS Usuario
                                FROM
                                    VentaHistorialDetalle VHD
                                JOIN
                                    VentasHistorial VH ON VH.ID = VHD.IdVenta
                                JOIN
                                    Productos P ON VHD.IdProducto = P.Id
                                JOIN
                                    Usuarios U ON VH.IdUsuario = U.ID";

            AccesoADatos datos = new AccesoADatos();
            datos.setearConsulta(consulta);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                VentaInforme venta = new VentaInforme
                {
                    Id = (int)datos.Lector["NroVenta"], // Este corresponde al numero de la venta
                    Numero = (int)datos.Lector["Numero"],
                    Cantidad = (decimal)datos.Lector["Cantidad"],
                    Monto = (decimal)datos.Lector["Monto"],
                    Fecha = (DateTime)datos.Lector["Fecha"],
                    Usuario = datos.Lector["Usuario"].ToString(),
                    Producto = new Producto // Asumiendo que tienes una clase Producto similar definida
                    {
                        Nombre = datos.Lector["ProductoNombre"].ToString()
                        // Agrega más propiedades de Producto si es necesario
                    }
                };

                ventas.Add(venta);
            }

            datos.cerrarConexion();

            return ventas;
        }

    }
}
