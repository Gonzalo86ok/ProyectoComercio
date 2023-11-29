using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class FabricanteNegocio
    {
        public List<Fabricante> listar()
        {
            List<Fabricante> lista = new List<Fabricante>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("select Id, Nombre, Activo from FABRICANTES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Fabricante aux = new Fabricante();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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
        public Fabricante obtenerFabricante(string id)
        {
            Fabricante fabricante = new Fabricante();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "select Nombre from FABRICANTES where Id = @id ";

                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    fabricante.Id = int.Parse(id);
                    fabricante.Nombre = (string)datos.Lector["Nombre"];
                }
                return fabricante;
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
        public void agregarFabricante(Fabricante nuevoFabricante)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO FABRICANTES (Nombre) VALUES (@Nombre)";
                datos.setearConsulta(consulta);
              
                datos.setearParametro("@Nombre", nuevoFabricante.Nombre);

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
        public void modificarFabricante(Fabricante nuevo)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                string consulta = "UPDATE FABRICANTES SET Nombre = @Nombre where Id = @Id";

                dato.setearConsulta(consulta);
              
                dato.setearParametro("@Nombre", nuevo.Nombre);
                dato.setearParametro("@id", nuevo.Id);

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
                string consulta = "update FABRICANTES set Activo = 0 where Id = @Id";

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
        public bool nombreRepetido(string nombre)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                string consulta = "SELECT Nombre, Activo FROM FABRICANTES WHERE Nombre = @Nombre AND Activo = 1";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nombre.ToUpper());
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string nombreEncontrado = (string)datos.Lector["Nombre"];
                    bool activo = (bool)datos.Lector["Activo"];

                    if (activo && nombreEncontrado.ToUpper() == nombre.ToUpper())
                    {
                        return true;
                    }
                }

                return false;
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
