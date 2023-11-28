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
        public decimal ObtenerTotalVentasHoy()
        {
            decimal totalVentas = 0;

            string consulta = @"
                             SELECT SUM(VHD.Precio * VHD.Cantidad) AS TotalVentas
                                FROM VentasHistorial VH
                             JOIN VentaHistorialDetalle VHD ON VH.ID = VHD.IdVenta
                                WHERE CONVERT(date, VH.FechaHoraRegistro) = CONVERT(date, GETDATE())";

            AccesoADatos datos = new AccesoADatos();
            datos.setearConsulta(consulta);
            datos.ejecutarLectura();

            if (datos.Lector.Read() && datos.Lector["TotalVentas"] != DBNull.Value)
            {
                totalVentas = Convert.ToDecimal(datos.Lector["TotalVentas"]);
            }

            datos.cerrarConexion();

            return totalVentas;
        }
       
        public decimal ObtenerTotalVentasMesActual()
        {
            decimal totalVentas = 0;

            string consulta = @"
                    SELECT SUM(VHD.Precio * VHD.Cantidad) AS TotalVentas
                    FROM VentasHistorial VH
                    JOIN VentaHistorialDetalle VHD ON VH.ID = VHD.IdVenta
                    WHERE YEAR(VH.FechaHoraRegistro) = YEAR(GETDATE())
                    AND MONTH(VH.FechaHoraRegistro) = MONTH(GETDATE())";

            AccesoADatos datos = new AccesoADatos();
            datos.setearConsulta(consulta);
            datos.ejecutarLectura();

            if (datos.Lector.Read() && datos.Lector["TotalVentas"] != DBNull.Value)
            {
                totalVentas = Convert.ToDecimal(datos.Lector["TotalVentas"]);
            }

            datos.cerrarConexion();

            return totalVentas;
        }
        public decimal ObtenerTotalVentasAño(int año)
        {
            decimal totalVentas = 0;

            string consulta = @"
                            SELECT SUM(VHD.Precio * VHD.Cantidad) AS TotalVentas
                        FROM VentasHistorial VH
                            JOIN VentaHistorialDetalle VHD ON VH.ID = VHD.IdVenta
                        WHERE YEAR(VH.FechaHoraRegistro) = @Año";

            AccesoADatos datos = new AccesoADatos();
            datos.setearConsulta(consulta);
            datos.setearParametro("@Año", año);
            datos.ejecutarLectura();

            if (datos.Lector.Read() && datos.Lector["TotalVentas"] != DBNull.Value)
            {
                totalVentas = Convert.ToDecimal(datos.Lector["TotalVentas"]);
            }

            datos.cerrarConexion();

            return totalVentas;
        }
        public int ObtenerCantidadVentasDelDia()
        {
            int cantidadVentas = 0;

            try
            {
                string consulta = @"SELECT COUNT(*) AS CantidadVentas
                            FROM VentasHistorial VH
                            WHERE CONVERT(date, VH.FechaHoraRegistro) = CONVERT(date, GETDATE())";

                AccesoADatos datos = new AccesoADatos();
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cantidadVentas = Convert.ToInt32(datos.Lector["CantidadVentas"]);
                }

                datos.cerrarConexion();
            }
            catch (Exception)
            {
                // Manejo de excepciones
            }

            return cantidadVentas;
        }
        public int ObtenerCantidadVentasDelMes()
        {
            int cantidadVentas = 0;

            try
            {
                string consulta = @"SELECT COUNT(*) AS CantidadVentas
                            FROM VentasHistorial VH
                            WHERE YEAR(VH.FechaHoraRegistro) = YEAR(GETDATE())
                            AND MONTH(VH.FechaHoraRegistro) = MONTH(GETDATE())";

                AccesoADatos datos = new AccesoADatos();
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cantidadVentas = Convert.ToInt32(datos.Lector["CantidadVentas"]);
                }

                datos.cerrarConexion();
            }
            catch (Exception)
            {
                // Manejo de excepciones
            }

            return cantidadVentas;
        }
        public int ObtenerCantidadVentasDelAnio(int year)
        {
            int cantidadVentas = 0;

            try
            {
                string consulta = $@"SELECT COUNT(*) AS CantidadVentas
                            FROM VentasHistorial VH
                            WHERE YEAR(VH.FechaHoraRegistro) = {year}";

                AccesoADatos datos = new AccesoADatos();
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cantidadVentas = Convert.ToInt32(datos.Lector["CantidadVentas"]);
                }

                datos.cerrarConexion();
            }
            catch (Exception)
            {
                // Manejo de excepciones
            }

            return cantidadVentas;
        }


    }
}
