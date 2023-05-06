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
        
            public List<Favorite> listarFavUserId(int idUser)
            {
               DataAcces datos = new DataAcces();
                List<Favorite> lista = new List<Favorite>();

                try
                {
                    datos.setearConsulta("Select IdArticulo from FAVORITOS where IdUser = @idUser");
                    datos.setearParametro("@idUser", idUser);
                    datos.ejecutarLectura();
                    while (datos.Reader.Read())
                    {
                    int aux = (int)datos.Reader["idArticulo"];
                    Favorite favorite = new Favorite();
                    favorite.IdArticulo = aux;
                    lista.Add(favorite);
                }

                    datos.cerrarConection();
                    return lista;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

        public List<Favorite> listarFavoritos(int idUsuario)
        {
            DataAcces dataAccess = new DataAcces();
            try
            {
                dataAccess.setearConsulta("SELECT * FROM favoritos WHERE idUser = @idUser");
                dataAccess.setearParametro("@idUser", idUsuario);
                dataAccess.ejecutarLectura();

                List<Favorite> listaFavoritos = new List<Favorite>();

                while (dataAccess.Reader.Read())
                {
                    Favorite fav = new Favorite();
                    fav.Id = (int)dataAccess.Reader["id"];
                    fav.IdUser = (int)dataAccess.Reader["idUser"];
                    fav.IdArticulo = (int)dataAccess.Reader["idArticulo"];

                    listaFavoritos.Add(fav);
                }

                return listaFavoritos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.cerrarConection();
            }
        }



        public void insertarNuevoFavorito(Favorite nuevo)
            {
                DataAcces datos = new DataAcces();
                try
                {
                    datos.setearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo)VALUES(@idUser, @idArticulo)");
                    datos.setearParametro("@idUser", nuevo.IdUser);
                    datos.setearParametro("@idArticulo", nuevo.IdArticulo);
                    datos.ejecutarAccion();

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    datos.cerrarConection();
                }

            }

            public void eliminarFavorito(int idUser, int id)
            {
                try
                {
                    DataAcces datos = new DataAcces();
                    datos.setearConsulta("delete from FAVORITOS where IdArticulo = @idArticulo and IdUser = @idUser");
                    datos.setearParametro("IdArticulo", id);
                    datos.setearParametro("idUser", idUser);
                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        public void eliminarFav(int id)
        {
            DataAcces datos = new DataAcces();
            datos.setearConsulta("delete from FAVORITOS where IdArticulo = @idArticulo");
            datos.setearParametro("@idArticulo", id);
            datos.ejecutarAccion();
        }
    } 
    } 



        
    
