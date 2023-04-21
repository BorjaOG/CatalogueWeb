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
    }
}
