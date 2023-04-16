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
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                 ArticuloNegocio negocio = new ArticuloNegocio();
                 dgvArticles.DataSource = negocio.listarSP();
                 dgvArticles.DataBind();
            }
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

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;   
            
        }

        protected void ddField_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddCriteria.Items.Clear();
            if (ddField.SelectedItem.ToString() == "Price")
            {
                ddCriteria.Items.Add("More than");
                ddCriteria.Items.Add("Less than");
                ddCriteria.Items.Add("equal to");
            }
            else
            {
                ddCriteria.Items.Add("Contains");
                ddCriteria.Items.Add("Start with");
                ddCriteria.Items.Add("Ends with");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticles.DataSource = negocio.filtrar(ddField.SelectedItem.ToString(),
                ddCriteria.SelectedItem.ToString()); 
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}