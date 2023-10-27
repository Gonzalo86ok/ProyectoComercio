using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class MedidaNegocio
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
                    aux.Tipo = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
