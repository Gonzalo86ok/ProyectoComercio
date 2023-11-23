using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasHistorialNegocio
    {
        public List<VentasHistorial> ListarHistorialVentas()
        {
            List<VentasHistorial> lista = new List<VentasHistorial>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT ID, IdUsuario, FechaHoraRegistro FROM VentasHistorial";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    VentasHistorial ventaHistorial = new VentasHistorial();
                    ventaHistorial.ID = (int)datos.Lector["ID"];
                    ventaHistorial.IdUsuario = (int)datos.Lector["IdUsuario"];
                    ventaHistorial.FechaHoraRegistro = (DateTime)datos.Lector["FechaHoraRegistro"];

                    // Obtener detalles de la venta
                    VentaHistorialDetalleNegocio detalleNegocio = new VentaHistorialDetalleNegocio();
                    ventaHistorial.Detalle = detalleNegocio.ListarDetallesVenta(ventaHistorial.ID);

                    lista.Add(ventaHistorial);
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

        public void AgregarVentaHistorial(List<Venta> listaVenta, int idUsuario)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO VentasHistorial (IdUsuario, FechaHoraRegistro) VALUES (@IdUsuario, GETDATE())";

                datos.setearConsulta(consulta);
                datos.setearParametro("@IdUsuario", idUsuario); // Aquí asignamos el ID de usuario

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

        public int AgregarVentaHistorial(int idUsuario)
        {
            AccesoADatos datos = new AccesoADatos();
            int idVenta = 0;
            try
            {
                string consulta = "INSERT INTO VentasHistorial (IdUsuario, FechaHoraRegistro) VALUES (@IdUsuario, GETDATE())";

                datos.setearConsulta(consulta);
                datos.setearParametro("@IdUsuario", idUsuario);

                datos.ejecutarAccion(); // Ejecutar la acción de inserción sin esperar ningún resultado
                idVenta = ObtenerUltimaVenta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return idVenta;
        }

        public int ObtenerUltimaVenta()
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT TOP 1 ID FROM VentasHistorial ORDER BY ID DESC";

                datos.setearConsulta(consulta);

                object resultadoScalar = datos.EjecutarScalar(consulta);

                if (resultadoScalar != null && int.TryParse(resultadoScalar.ToString(), out int idUltimaVenta))
                {
                    return idUltimaVenta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return -1; // O algún valor que indique que no se encontró ninguna venta
        }

    }
}
