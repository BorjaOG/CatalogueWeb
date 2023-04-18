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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogIn_Click(object sender, EventArgs e)
        {
                User user = new User();
                UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                user.Email = txtEmailLogin.Text;
                user.Pass = txtPassLogin.Text;
                if (negocio.logIn(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Profile.aspx",false);
                }
                else
                {
                    Session.Add("error", "Incorrect User/Pass");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}