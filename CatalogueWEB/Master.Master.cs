using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using Domain;

namespace CatalogueWEB
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is LogIn || Page is SignIn || Page is Default || Page is ContactUs))
            {
                if (!Security.ActiveSession(Session["user"]))
                    Response.Redirect("Login.aspx", false);
            }
            if (Security.ActiveSession(Session["user"]))
            {
                User currentUser = (User)Session["user"];
                if (!string.IsNullOrEmpty(currentUser.UrlImagenPerfil))
                {
                    imgAvatar.ImageUrl = "~/Images/" + currentUser.UrlImagenPerfil;
                }
                else
                {
                    imgAvatar.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
                }
                btnLogout.Visible = true;
                btnLogIn.Visible = false;
                btnSignIn.Visible = false;
            }


            else
            {
                imgAvatar.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
                btnLogout.Visible = false;
                btnLogIn.Visible = true;
                btnSignIn.Visible = true;
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Login.aspx", false);
        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("SignIn.aspx");
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUS.aspx", false);
        }
    }
}