using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
			List<Categoria> lista = new List<Categoria>();
			DataAcces data = new DataAcces();
			try
			{
				data.setearConsulta("select Id, Descripcion from CATEGORIAS");
				data.ejecutarLectura();

				while (data.Reader.Read())
				{
					Categoria aux = new Categoria();
					aux.Id = (int)data.Reader["Id"];
					aux.Descripcion = (string)data.Reader["Descripcion"];
					lista.Add(aux);
				}

				return lista;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				data.cerrarConection();
			}
        }
    }
}
