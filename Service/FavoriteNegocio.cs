using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Service;

namespace Service
{
    public class FavoriteNegocio
    {
        public int InsertarNuevoFav(Favorite fav)
        {
            DataAcces data = new DataAcces();
            try
            {
                data.setearProcedimiento("insertNewFav");
                data.setearParametro("@idUser", fav.Id); 
                data.setearParametro("@idArticulo", fav.IdArticulo);
                return data.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Favorite> ListarFavoritosPorUsuario(int idUsuario)
        {
            List<Favorite> listaFavoritos = new List<Favorite>();
            DataAcces data = new DataAcces();
            string consulta = "Select * from FAVORITOS where idUser = @idUser";
            data.setearConsulta(consulta);
            data.setearParametro("@idUser", idUsuario);
            data.ejecutarLectura();
            while (data.Reader.Read())
            {
                Favorite fav = new Favorite();
                fav.Id = Convert.ToInt32(data.Reader["id"]);
                fav.IdArticulo = Convert.ToInt32(data.Reader["idArticulo"]);

                listaFavoritos.Add(fav);
            }
            data.cerrarConection();
            return listaFavoritos;    
        }

    }
}
