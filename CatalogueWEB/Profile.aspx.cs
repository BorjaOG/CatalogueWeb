using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Domain;
using Service;

namespace CatalogueWEB
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                if (user != null)
                {
                    txtEmail.Text = user.Email;
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    user = negocio.obtenerPorId(user.Id);
                    txtName.Text = user.Nombre;
                    TxtSurname.Text = user.Apellido;
                    if (string.IsNullOrEmpty(user.UrlImagenPerfil))
                    {
                        ImgPerfil.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
                    }
                    else
                    {
                        ImgPerfil.ImageUrl = "~/Images/" + user.UrlImagenPerfil;
                    }
                }
            }
            
            else
            {
                User user = (User)Session["user"];
                if (user == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

        }

        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                User user = (User)Session["user"];
                string ruta = Server.MapPath("./Images/");
                string fileName = "profile-" + user.Id + ".jpg";
                string filePath = ruta + fileName;

                // guardar imagen
                txtPhoto.PostedFile.SaveAs(filePath);

                if (File.Exists(filePath))
                {
                    user.UrlImagenPerfil = fileName;
                    user.Nombre = txtName.Text;
                    user.Apellido = TxtSurname.Text;

                    negocio.actualizar(user);

                    // actualizar imagen del avatar
                    Image img = (Image)Master.FindControl("imgAvatar");
                    img.ImageUrl = "~/Images/" + user.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                    ;

                    // actualizar imagen del perfil
                    ImgPerfil.ImageUrl = "~/Images/" + user.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                    Debug.WriteLine("Imagen guardada en: " + filePath);
                }
                else
                {
                    Session.Add("Error", "No se pudo guardar la imagen.");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
            }
        }

    }
}
