using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    internal class FabricanteNegocio
    {
        public List<Fabricante> listar()
        {
            List<Fabricante> lista = new List<Fabricante>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("select Id, Nombre from FABRICANTES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Fabricante aux = new Fabricante();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Descripcion"];

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
