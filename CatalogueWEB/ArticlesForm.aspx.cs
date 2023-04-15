using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Catalogo;
using Domain;
using Service;


namespace CatalogueWEB
{
    public partial class ArticlesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtId.Enabled = false;

                //Inital Config..//
                if (!IsPostBack)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    List<Categoria> listaC = negocio.listar();

                    ddlCategoria.DataSource = listaC;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
                if (!IsPostBack)
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    List<Marca> listaC = negocio.listar();

                    ddlMarca.DataSource = listaC;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

                //Modification Config..//
                string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (Id != "" && !IsPostBack)
                {
                   ArticuloNegocio negocio = new ArticuloNegocio();
                    //List<Articulo> lista = negocio.listar(Id);
                    //Articulo selected = lista[0];
                   Articulo selected = (negocio.listar(Id))[0];


                    // datos precargados //
                    txtId.Text = Id;
                    txtNombre.Text = selected.Nombre;
                    txtCodigo.Text = selected.Codigo;
                    txtDescripcion.Text = selected.Descripcion;
                    txtUrlImagen.Text = selected.UrlImagen;
                    txtPrecio.Text = selected.Precio.ToString();

                    ddlCategoria.SelectedValue = selected.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = selected.Marca.Id.ToString();
                    txtUrlImagen_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticle.ImageUrl = txtUrlImagen.Text;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarSP(nuevo);
                }
                else
                negocio.AgregarSP(nuevo);


                Response.Redirect("Articles.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}