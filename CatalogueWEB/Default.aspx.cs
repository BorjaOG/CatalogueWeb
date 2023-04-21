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
            // Verificar si la sesión "idUser" está establecida
            if (Session["idUser"] != null)
            {
                // Obtener el id del usuario que ha iniciado sesión
                int userId = Convert.ToInt32(Session["idUser"]);

                // Obtener el id del artículo correspondiente al botón que se ha pulsado
                Button btn = (Button)sender;
                RepeaterItem item = (RepeaterItem)btn.NamingContainer;
                int articuloId = Convert.ToInt32(((HiddenField)item.FindControl("hfId")).Value);

                // Crear un objeto Favorite con los ids del usuario y del artículo
                Favorite fav = new Favorite
                {
                    Id = userId,
                    IdArticulo = articuloId
                };

                // Llamar al método InsertarNuevoFav del objeto FavoriteNegocio para agregar el favorito a la base de datos
                FavoriteNegocio favNegocio = new FavoriteNegocio();
                favNegocio.InsertarNuevoFav(fav);
            }
            else
            {
                // Si la sesión "idUser" no está establecida, redirigir al usuario a la página de inicio de sesión
                Response.Redirect("Favorites.aspx");
            }
        }
    }
}