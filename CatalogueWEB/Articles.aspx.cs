using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Catalogo;
using Domain;


namespace CatalogueWEB
{
    public partial class Articles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticles.DataSource = negocio.listarSP();
            dgvArticles.DataBind();
        }

        protected void dgvArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvArticles.SelectedDataKey.Value.ToString();
            Response.Redirect("ArticlesForm.aspx?Id=" + Id);
        }

        protected void dgvArticles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticles.PageIndex = e.NewPageIndex;
            dgvArticles.DataBind();
        }
    }
}