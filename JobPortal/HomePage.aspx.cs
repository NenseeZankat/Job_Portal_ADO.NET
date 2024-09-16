using System;
using System.Web.UI;

namespace JobPortal
{
    public partial class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                // User is logged in, show logout link and hide login/register links
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/LogOut.aspx'>Logout</a></li>"
                ));
            }
            else
            {
                // User is not logged in, show login/register links
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/Login.aspx'>Login</a></li>" +
                    "<li class='nav-item'><a class='nav-link' href='/Register.aspx'>Register</a></li>"
                ));
            }
        }
    }
}
