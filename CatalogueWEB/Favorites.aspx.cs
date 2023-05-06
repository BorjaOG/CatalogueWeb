using Catalogo;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogueWEB
{
    public partial class Favorites : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int idArticulo))
            {
                FavoriteNegocio negocio = new FavoriteNegocio();
                Favorite nuevo = new Favorite();

                nuevo.IdUser = user.Id;
                nuevo.IdArticulo = int.Parse(id);

                negocio.insertarNuevoFavorito(nuevo);
            }
            ListaArticulo = new List<Articulo>();

            if (user != null)
            {
                FavoriteNegocio negocioart = new FavoriteNegocio();
                List<Articulo> ListaArticulo = new List<Articulo>();
                List<Favorite> favoritos = negocioart.listarFavoritos(user.Id);
                List<int> idArticulosFavoritos = favoritos.Select(f => f.IdArticulo).ToList();
                if (idArticulosFavoritos.Count > 0)
                {
                    ArticuloNegocio art = new ArticuloNegocio();
                    ListaArticulo = art.listarArtById(idArticulosFavoritos);
                    RepeaterArticles.DataSource = ListaArticulo;
                    RepeaterArticles.DataBind();
                }


            }
            else
            {
                Session.Add("error", "We are unable to show the favorites 😕");
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            FavoriteNegocio negocio = new FavoriteNegocio();

            int idArticulo = int.Parse(((Button)sender).CommandArgument);
            int idUser = user.Id;

            negocio.eliminarFavorito(idUser, idArticulo);

            // Agregar mensaje en pantalla
            string script = "alert('El artículo se eliminó correctamente.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eliminacionCorrecta", script, true);

            // Actualizar la página
            Response.Redirect("~/Favorites.aspx");

        }

    }
}