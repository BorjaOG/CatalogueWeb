using Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Service;

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

       
    }
}