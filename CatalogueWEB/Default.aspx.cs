using Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Service;
using System.Web.UI.HtmlControls;
using System.Web.Services.Description;
using System.Drawing;

namespace CatalogueWEB
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarSP();
            if (!IsPostBack)
            {
                RepeaterArticles.DataSource = ListaArticulos;
                RepeaterArticles.DataBind();
            }
        }

        protected void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtFilter.Text.ToLower();
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarSP().Where(x => x.Nombre.ToLower().Contains(searchValue)).ToList();
            RepeaterArticles.DataSource = ListaArticulos;
            RepeaterArticles.DataBind();
        }

        protected void btnFav_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                // Redirigir a la página de login
                Response.Redirect("Login.aspx");
            }
            else
            {
                int idArticulo = int.Parse(((Button)sender).CommandArgument);
                User user = (User)Session["user"];

                // Crear objeto Favorite con los datos del artículo y el usuario
                Favorite nuevoFavorito = new Favorite();
                nuevoFavorito.IdArticulo = idArticulo;
                nuevoFavorito.IdUser = user.Id;

                // Llamar al método para insertar el nuevo favorito en la base de datos
                FavoriteNegocio negocio = new FavoriteNegocio();
                negocio.insertarNuevoFavorito(nuevoFavorito);

                // Redirigir a la página de favoritos
                Response.Redirect("Favorites.aspx");
            }
        }



    }
}