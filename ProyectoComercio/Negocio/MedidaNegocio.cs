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
                datos.setearConsulta("select Id, Tipo from MEDIDAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medida aux = new Medida();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (string)datos.Lector["Tipo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Medida nuevaMedida)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO MEDIDAS (Tipo) VALUES (@Tipo)";
                datos.setearConsulta(consulta);

                // Usar parámetros para evitar la inyección de SQL y mejorar la seguridad
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

    }
}
