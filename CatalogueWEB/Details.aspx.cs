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
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["fromFavorites"] == "true")
                {
                    lblFav.Visible = true;
                }
                else
                {
                    lblFav.Visible = false;
                }
                //Inital Config..//
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> listaMarcas = marcaNegocio.listar();

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> listaCategorias = categoriaNegocio.listar();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

                //Modification Config..//
                string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (Id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();                  
                    Articulo selected = (negocio.listar(Id))[0];

                   
                    txtId.Text = Id;
                    txtNombre.Text = selected.Nombre;
                    txtCodigo.Text = selected.Codigo;
                    txtDescripcion.Text = selected.Descripcion;
                    txtUrlImagen.Text = selected.UrlImagen;
                    txtPrecio.Text = selected.Precio.ToString();
                    ddlMarca.SelectedValue = selected.Marca.Id.ToString();
                    ddlMarca.Enabled = false;
                    ddlCategoria.SelectedValue = selected.Categoria.Id.ToString();
                    ddlCategoria.Enabled = false;

                    txtUrlImagen_TextChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["fromFavorites"] == "true")
            {
                Response.Redirect("Favorites.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }


        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticle.ImageUrl = txtUrlImagen.Text;
        }
    }
}