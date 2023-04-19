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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
        }

        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                // write img
                string ruta = Server.MapPath("./Images/");
                User user = (User)Session["user"];
                txtPhoto.PostedFile.SaveAs(ruta + "profile-" + user.Id + ".jpg");

                user.UrlImagenPerfil = "profile-" + user.Id + ".jpg";
                user.Nombre = txtName.Text;
                user.Apellido = TxtSurname.Text;
                

                negocio.actualizar(user);
                //read img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + user.UrlImagenPerfil;


                
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }
    }
}