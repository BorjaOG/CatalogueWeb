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
                Response.Redirect("Login.aspx");
            }
            else
            {
                int idArticulo = int.Parse(((Button)sender).CommandArgument);
                User user = (User)Session["user"];

                Favorite nuevoFavorito = new Favorite();
                nuevoFavorito.IdArticulo = idArticulo;
                nuevoFavorito.IdUser = user.Id;

                FavoriteNegocio negocio = new FavoriteNegocio();
                negocio.insertarNuevoFavorito(nuevoFavorito);

                Response.Redirect("Favorites.aspx");
            }
        }



    }
}