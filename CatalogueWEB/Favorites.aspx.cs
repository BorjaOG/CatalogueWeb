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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                var listaArticulos = negocio.listarSP();

                // Obtener el id del usuario que ha iniciado sesión
                int userId = Convert.ToInt32(Session["idUser"]);

                // Obtener la lista de favoritos del usuario
                FavoriteNegocio favNegocio = new FavoriteNegocio();
                var listaFavoritos = favNegocio.ListarFavoritosPorUsuario(userId);

                // Iterar sobre la lista de artículos y establecer la propiedad Visible de lblFav según si el artículo está en la lista de favoritos
                foreach (GridViewRow row in dgvArticles.Rows)

                {
                    var hfId = (HiddenField)row.FindControl("hfId");
                    var lblFav = (Label)row.FindControl("lblFav");
                    var idArticulo = Convert.ToInt32(hfId.Value);

                    if (listaFavoritos.Any(f => f.IdArticulo == idArticulo))
                    {
                        lblFav.Visible = true;
                    }
                }

                dgvArticles.DataSource = listaArticulos;
                dgvArticles.DataBind();
            }
        }

        protected void dgvArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticles.SelectedDataKey.Value.ToString();
            Response.Redirect("Favorites.aspx?id=" + id);
        }

        protected void dgvArticles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticles.DataSource = Session["listaArticulosFavoritos"];
            dgvArticles.PageIndex = e.NewPageIndex;
            dgvArticles.DataBind();
        }

    }
}