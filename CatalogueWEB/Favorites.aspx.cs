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
            if (!Security.IsAdmin(Session["user"]))
            {
                Session.Add("error", "Need to be admin");
                Response.Redirect("Error.aspx");
            }
  
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticles.DataSource = negocio.listarSP();
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