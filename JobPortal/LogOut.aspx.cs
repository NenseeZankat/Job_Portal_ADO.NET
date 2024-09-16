using System;
using System.Web.UI;

namespace JobPortal
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear the session variables
            Session.Clear();
            Session.Abandon();

            // Optionally, you can also clear authentication cookies if used
            // Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            // Response.Cookies.Add(new HttpCookie("YourAuthCookieName", ""));

            // Redirect the user to the login page
            Response.Redirect("Login.aspx");
        }
    }
}
