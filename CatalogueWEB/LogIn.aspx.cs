using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public bool IsAdmin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmailLogin.Text))
            {
                lblMessage.Text = "Please enter an email address.";
                return;
            }
            if (!IsValidEmail(txtEmailLogin.Text))
            {
                lblMessage.Text = "Please enter a valid email address.";
                return;
            }
            if (string.IsNullOrEmpty(txtPassLogin.Text))
            {
                lblMessage1.Text = "Incorrect Password, try again.";
                return;
            }

            User user = new User();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                user.Email = txtEmailLogin.Text;
                user.Pass = txtPassLogin.Text;
                if (negocio.logIn(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblError.Text = "The email or password you entered is incorrect. Please try again.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        protected void txtEmailLogin_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmailLogin.Text) && IsValidEmail(txtEmailLogin.Text))
            {
                lblMessage.Visible = false;
            }
        }

    }
}