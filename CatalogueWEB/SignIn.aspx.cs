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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User(); 
                UsuarioNegocio userNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                user.Id = userNegocio.InsertarNuevo(user);
                Session.Add("user", user);

                emailService.armarCorreo(user.Email, "Welcome user", "Hey there, Welcome to the articles page! Thank you for signing in.");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}