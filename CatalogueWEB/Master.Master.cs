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
            if(!(Page is LogIn || Page is SignIn || Page is Default))
            {
                if (!Security.ActiveSession(Session["user"]))
                     Response.Redirect("Login.aspx", false);
            }
            if (Security.ActiveSession(Session["user"]))
            {
                btnLogout.Visible = true;
                btnLogIn.Visible = false;
                btnSignIn.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Login.aspx", false);
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}