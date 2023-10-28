using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SucursalNegocio
    {
        public List<Sucursal> listar()
        {
            List<Sucursal> lista = new List<Sucursal>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("select Id, Nombre, Direccion  from SUCURSALES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Sucursal aux = new Sucursal();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Direccion = (string)datos.Lector["Direccion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Sucursal nuevaSucursal)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO SUCURSALES (Nombre, Direccion) VALUES (@Nombre, @Direccion)";
                datos.setearConsulta(consulta);

                
                datos.setearParametro("@Nombre", nuevaSucursal.Nombre);
                datos.setearParametro("@Direccion", nuevaSucursal.Direccion);

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

    }
}
