using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            DataAcces data = new DataAcces();
            try
            {
                data.setearConsulta("select Id, Descripcion from marcas");
                data.ejecutarLectura();
                while (data.Reader.Read())
                {
                    Marca aux = new Marca();
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

