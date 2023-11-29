using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MedidaNegocio
    {
        public List<Medida> listar()
        {
            List<Medida> lista = new List<Medida>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("select Id, Tipo, Activo from MEDIDAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medida aux = new Medida();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (string)datos.Lector["Tipo"];
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
        public Medida obtenerMedida(string id)
        {
            Medida medida = new Medida();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "select Tipo from MEDIDAS where Id = @id ";

                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    medida.Id = int.Parse(id);
                    medida.Tipo = (string)datos.Lector["Tipo"];
                }
                return medida;
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
        public void agregarMedida(Medida nuevaMedida)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO MEDIDAS (Tipo) VALUES (@Tipo)";
                datos.setearConsulta(consulta);
               
                datos.setearParametro("@Tipo", nuevaMedida.Tipo);

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
        public void modificarMedida(Medida nueva)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                string consulta = "update MEDIDAS set Tipo = @tipo where Id = @id";
                datos.setearConsulta(consulta);

                datos.setearParametro("@tipo", nueva.Tipo);
                datos.setearParametro("@id", nueva.Id);

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
        public void eliminacionLogica(int id)
        {
            AccesoADatos dato = new AccesoADatos();
            try
            {
                string consulta = "update MEDIDAS set Activo = 0 where Id = @Id";

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
        public bool tipoRepetido(string tipo)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                string consulta = "SELECT Tipo, Activo from MEDIDAS";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                Medida medida = new Medida();

                while (datos.Lector.Read())
                {
                    medida.Tipo = (string)datos.Lector["Tipo"];
                    medida.Activo = (bool)datos.Lector["Activo"];

                    if (medida.Activo == true)
                    {
                        if (tipo.ToUpper() == medida.Tipo)
                        {
                            return true;
                        }
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
